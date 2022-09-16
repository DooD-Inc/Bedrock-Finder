﻿// Copyright (c) 2011-2016 Siegfried Pammer
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using System.Linq;
using Amplifier.Decompiler.TypeSystem;

namespace Amplifier.Decompiler.IL.Transforms
{
	public class CachedDelegateInitialization : IBlockTransform
	{
		BlockTransformContext context;

		public void Run(Block block, BlockTransformContext context)
		{
			this.context = context;
			if (!context.Settings.AnonymousMethods)
				return;
			for (int i = block.Instructions.Count - 1; i >= 0; i--) {
				if (block.Instructions[i] is IfInstruction inst) {
					if (CachedDelegateInitializationWithField(inst)) {
						block.Instructions.RemoveAt(i);
						continue;
					}
					if (CachedDelegateInitializationWithLocal(inst)) {
						ILInlining.InlineOneIfPossible(block, i, InliningOptions.Aggressive, context);
						continue;
					}
					if (CachedDelegateInitializationRoslynInStaticWithLocal(inst) || CachedDelegateInitializationRoslynWithLocal(inst)) {
						block.Instructions.RemoveAt(i);
						continue;
					}
				}
			}
		}

		/// <summary>
		/// if (comp(ldsfld CachedAnonMethodDelegate == ldnull)) {
		///     stsfld CachedAnonMethodDelegate(DelegateConstruction)
		/// }
		/// ... one usage of CachedAnonMethodDelegate ...
		/// =>
		/// ... one usage of DelegateConstruction ...
		/// </summary>
		bool CachedDelegateInitializationWithField(IfInstruction inst)
		{

			Block trueInst = inst.TrueInst as Block;
			if (trueInst == null || trueInst.Instructions.Count != 1 || !inst.FalseInst.MatchNop())
				return false;
			var storeInst = trueInst.Instructions[0];
			if (!inst.Condition.MatchCompEquals(out ILInstruction left, out ILInstruction right) || !left.MatchLdsFld(out IField field) || !right.MatchLdNull())
				return false;
			if (!storeInst.MatchStsFld(out IField field2, out ILInstruction value) || !field.Equals(field2) || !field.IsCompilerGeneratedOrIsInCompilerGeneratedClass())
				return false;
			if (!DelegateConstruction.IsDelegateConstruction(value as NewObj, true))
				return false;
			var nextInstruction = inst.Parent.Children.ElementAtOrDefault(inst.ChildIndex + 1);
			if (nextInstruction == null)
				return false;
			var usages = nextInstruction.Descendants.Where(i => i.MatchLdsFld(field)).ToArray();
			if (usages.Length != 1)
				return false;
			context.Step("CachedDelegateInitializationWithField", inst);
			usages[0].ReplaceWith(value);
			return true;
		}

		/// <summary>
		/// if (comp(ldloc v == ldnull)) {
		///     stloc v(DelegateConstruction)
		/// }
		/// =>
		/// stloc v(DelegateConstruction)
		/// </summary>
		bool CachedDelegateInitializationWithLocal(IfInstruction inst)
		{
			Block trueInst = inst.TrueInst as Block;
			if (trueInst == null || (trueInst.Instructions.Count != 1) || !inst.FalseInst.MatchNop())
				return false;
			if (!inst.Condition.MatchCompEquals(out ILInstruction left, out ILInstruction right) || !left.MatchLdLoc(out ILVariable v) || !right.MatchLdNull())
				return false;
			var storeInst = trueInst.Instructions.Last();
			if (!storeInst.MatchStLoc(v, out ILInstruction value))
				return false;
			if (!DelegateConstruction.IsDelegateConstruction(value as NewObj, true))
				return false;
			// do not transform if there are other stores/loads of this variable
			if (v.StoreCount != 2 || v.StoreInstructions.Count != 2 || v.LoadCount != 2 || v.AddressCount != 0)
				return false;
			// do not transform if the first assignment is not assigning null:
			var otherStore = v.StoreInstructions.OfType<StLoc>().SingleOrDefault(store => store != storeInst);
			if (otherStore == null || !otherStore.Value.MatchLdNull() || !(otherStore.Parent is Block))
				return false;
			// do not transform if there is no usage directly afterwards
			var nextInstruction = inst.Parent.Children.ElementAtOrDefault(inst.ChildIndex + 1);
			if (nextInstruction == null)
				return false;
			var usages = nextInstruction.Descendants.Where(i => i.MatchLdLoc(v)).ToArray();
			if (usages.Length != 1)
				return false;
			context.Step("CachedDelegateInitializationWithLocal", inst);
			((Block)otherStore.Parent).Instructions.Remove(otherStore);
			inst.ReplaceWith(storeInst);
			return true;
		}

		/// <summary>
		/// stloc s(ldobj(ldsflda(CachedAnonMethodDelegate))
		/// if (comp(ldloc s == null)) {
		///		stloc s(stobj(ldsflda(CachedAnonMethodDelegate), DelegateConstruction))
		///	}
		///	=>
		///	stloc s(DelegateConstruction)
		/// </summary>
		bool CachedDelegateInitializationRoslynInStaticWithLocal(IfInstruction inst)
		{
			Block trueInst = inst.TrueInst as Block;
			if (trueInst == null || (trueInst.Instructions.Count != 1) || !inst.FalseInst.MatchNop())
				return false;
			if (!inst.Condition.MatchCompEquals(out ILInstruction left, out ILInstruction right) || !left.MatchLdLoc(out ILVariable s) || !right.MatchLdNull())
				return false;
			var storeInst = trueInst.Instructions.Last() as StLoc;
			var storeBeforeIf = inst.Parent.Children.ElementAtOrDefault(inst.ChildIndex - 1) as StLoc;
			if (storeBeforeIf == null || storeInst == null || storeBeforeIf.Variable != s || storeInst.Variable != s)
				return false;
			if (!(storeInst.Value is StObj stobj) || !(storeBeforeIf.Value is LdObj ldobj))
				return false;
			if (!(stobj.Value is NewObj))
				return false;
			if (!stobj.Target.MatchLdsFlda(out var field1) || !ldobj.Target.MatchLdsFlda(out var field2) || !field1.Equals(field2))
				return false;
			if (!DelegateConstruction.IsDelegateConstruction((NewObj)stobj.Value, true))
				return false;
			context.Step("CachedDelegateInitializationRoslynInStaticWithLocal", inst);
			storeBeforeIf.Value = stobj.Value;
			return true;
		}

		/// <summary>
		/// stloc s(ldobj(ldflda(CachedAnonMethodDelegate))
		/// if (comp(ldloc s == null)) {
		///		stloc s(stobj(ldflda(CachedAnonMethodDelegate), DelegateConstruction))
		///	}
		///	=>
		///	stloc s(DelegateConstruction)
		/// </summary>
		bool CachedDelegateInitializationRoslynWithLocal(IfInstruction inst)
		{
			Block trueInst = inst.TrueInst as Block;
			if (trueInst == null || (trueInst.Instructions.Count != 1) || !inst.FalseInst.MatchNop())
				return false;
			if (!inst.Condition.MatchCompEquals(out ILInstruction left, out ILInstruction right) || !left.MatchLdLoc(out ILVariable s) || !right.MatchLdNull())
				return false;
			var storeInst = trueInst.Instructions.Last() as StLoc;
			var storeBeforeIf = inst.Parent.Children.ElementAtOrDefault(inst.ChildIndex - 1) as StLoc;
			if (storeBeforeIf == null || storeInst == null || storeBeforeIf.Variable != s || storeInst.Variable != s)
				return false;
			if (!(storeInst.Value is StObj stobj) || !(storeBeforeIf.Value is LdObj ldobj))
				return false;
			if (!(stobj.Value is NewObj))
				return false;
			if (!stobj.Target.MatchLdFlda(out var _, out var field1) || !ldobj.Target.MatchLdFlda(out var __, out var field2) || !field1.Equals(field2))
				return false;
			if (!DelegateConstruction.IsDelegateConstruction((NewObj)stobj.Value, true))
				return false;
			context.Step("CachedDelegateInitializationRoslynWithLocal", inst);
			storeBeforeIf.Value = stobj.Value;
			return true;
		}
	}
}
