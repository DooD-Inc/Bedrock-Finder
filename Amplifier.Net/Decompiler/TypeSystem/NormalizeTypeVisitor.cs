﻿using System;
using System.Collections.Generic;
using System.Text;
using Amplifier.Decompiler.TypeSystem.Implementation;

namespace Amplifier.Decompiler.TypeSystem
{
	sealed class NormalizeTypeVisitor : TypeVisitor
	{
		/// <summary>
		/// NormalizeTypeVisitor that does not normalize type parameters,
		/// but performs type erasure (object->dynamic; tuple->underlying type).
		/// </summary>
		internal static readonly NormalizeTypeVisitor TypeErasure = new NormalizeTypeVisitor {
			ReplaceClassTypeParametersWithDummy = false,
			ReplaceMethodTypeParametersWithDummy = false,
			DynamicAndObject = true,
			TupleToUnderlyingType = true,
			RemoveModOpt = true,
			RemoveModReq = true,
			RemoveNullability = true,
		};

		public bool EquivalentTypes(IType a, IType b)
		{
			a = a.AcceptVisitor(this);
			b = b.AcceptVisitor(this);
			return a.Equals(b);
		}

		public bool RemoveModOpt = true;
		public bool RemoveModReq = true;
		public bool ReplaceClassTypeParametersWithDummy = true;
		public bool ReplaceMethodTypeParametersWithDummy = true;
		public bool DynamicAndObject = true;
		public bool TupleToUnderlyingType = true;
		public bool RemoveNullability = true;

		public override IType VisitTypeParameter(ITypeParameter type)
		{
			if (type.OwnerType == SymbolKind.Method && ReplaceMethodTypeParametersWithDummy) {
				return DummyTypeParameter.GetMethodTypeParameter(type.Index);
			} else if (type.OwnerType == SymbolKind.TypeDefinition && ReplaceClassTypeParametersWithDummy) {
				return DummyTypeParameter.GetClassTypeParameter(type.Index);
			} else {
				return base.VisitTypeParameter(type);
			}
		}

		public override IType VisitTypeDefinition(ITypeDefinition type)
		{
			if (DynamicAndObject && type.KnownTypeCode == KnownTypeCode.Object) {
				// Instead of normalizing dynamic->object,
				// we do this the opposite direction, so that we don't need a compilation to find the object type.
				if (RemoveNullability)
					return SpecialType.Dynamic;
				else
					return SpecialType.Dynamic.ChangeNullability(type.Nullability);
			}
			return base.VisitTypeDefinition(type);
		}

		public override IType VisitTupleType(TupleType type)
		{
			if (TupleToUnderlyingType) {
				return type.UnderlyingType.AcceptVisitor(this);
			} else {
				return base.VisitTupleType(type);
			}
		}

		public override IType VisitNullabilityAnnotatedType(NullabilityAnnotatedType type)
		{
			if (RemoveNullability)
				return base.VisitNullabilityAnnotatedType(type).ChangeNullability(Nullability.Oblivious);
			else
				return base.VisitNullabilityAnnotatedType(type);
		}

		public override IType VisitArrayType(ArrayType type)
		{
			if (RemoveNullability)
				return base.VisitArrayType(type).ChangeNullability(Nullability.Oblivious);
			else
				return base.VisitArrayType(type);
		}

		public override IType VisitModOpt(ModifiedType type)
		{
			if (RemoveModOpt) {
				return type.ElementType.AcceptVisitor(this);
			} else {
				return base.VisitModOpt(type);
			}
		}

		public override IType VisitModReq(ModifiedType type)
		{
			if (RemoveModReq) {
				return type.ElementType.AcceptVisitor(this);
			} else {
				return base.VisitModReq(type);
			}
		}
	}
}
