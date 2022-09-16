﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using Amplifier.Decompiler.TypeSystem;

namespace Amplifier.Decompiler.IL.Transforms
{
	class ProxyCallReplacer : IILTransform
	{
		public void Run(ILFunction function, ILTransformContext context)
		{
			foreach (var inst in function.Descendants.OfType<CallInstruction>()) {
				Run(inst, context);
			}
		}

		void Run(CallInstruction inst, ILTransformContext context)
		{
			if (inst.Method.IsStatic)
				return;
			if (inst.Method.MetadataToken.IsNil || inst.Method.MetadataToken.Kind != HandleKind.MethodDefinition)
				return;
			var handle = (MethodDefinitionHandle)inst.Method.MetadataToken;
			if (!IsDefinedInCurrentOrOuterClass(inst.Method, context.Function.Method.DeclaringTypeDefinition))
				return;
			if (!inst.Method.IsCompilerGeneratedOrIsInCompilerGeneratedClass())
				return;
			var metadata = context.PEFile.Metadata;
			MethodDefinition methodDef = metadata.GetMethodDefinition((MethodDefinitionHandle)inst.Method.MetadataToken);
			if (!methodDef.HasBody())
				return;
			var genericContext = DelegateConstruction.GenericContextFromTypeArguments(inst.Method.Substitution);
			if (genericContext == null)
				return;
			// partially copied from CSharpDecompiler
			var ilReader = context.CreateILReader();
			var body = context.PEFile.Reader.GetMethodBody(methodDef.RelativeVirtualAddress);
			var proxyFunction = ilReader.ReadIL(handle, body, genericContext.Value, context.CancellationToken);
			var transformContext = new ILTransformContext(context, proxyFunction);
			proxyFunction.RunTransforms(CSharp.CSharpDecompiler.EarlyILTransforms(), transformContext);
			if (!(proxyFunction.Body is BlockContainer blockContainer))
				return;
			if (blockContainer.Blocks.Count != 1)
				return;
			var block = blockContainer.Blocks[0];
			Call call;
			ILInstruction returnValue;
			switch (block.Instructions.Count) {
				case 1:
					// leave IL_0000 (call Test(ldloc this, ldloc A_1))
					if (!block.Instructions[0].MatchLeave(blockContainer, out returnValue))
						return;
					call = returnValue as Call;
					break;
				case 2:
					// call Test(ldloc this, ldloc A_1)
					// leave IL_0000(nop)
					call = block.Instructions[0] as Call;
					if (!block.Instructions[1].MatchLeave(blockContainer, out returnValue))
						return;
					if (!returnValue.MatchNop())
						return;
					break;
				default:
					return;
			}
			if (call == null || call.Method.IsConstructor) {
				return;
			}
			if (call.Method.IsStatic || call.Method.Parameters.Count != inst.Method.Parameters.Count) {
				return;
			}
			// check if original arguments are only correct ldloc calls
			for (int i = 0; i < call.Arguments.Count; i++) {
				var originalArg = call.Arguments[i];
				if (!originalArg.MatchLdLoc(out ILVariable var) ||
					var.Kind != VariableKind.Parameter ||
					var.Index != i - 1) {
					return;
				}
			}
			context.Step("Replace proxy: " + inst.Method.Name + " with " + call.Method.Name, inst);
			Call newInst = (Call)call.Clone();

			newInst.Arguments.ReplaceList(inst.Arguments);
			inst.ReplaceWith(newInst);
		}

		static bool IsDefinedInCurrentOrOuterClass(IMethod method, ITypeDefinition declaringTypeDefinition)
		{
			while (declaringTypeDefinition != null) {
				if (method.DeclaringTypeDefinition == declaringTypeDefinition)
					return true;
				declaringTypeDefinition = declaringTypeDefinition.DeclaringTypeDefinition;
			}
			return false;
		}
	}
}
