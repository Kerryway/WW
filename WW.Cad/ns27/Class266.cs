// Decompiled with JetBrains decompiler
// Type: ns27.Class266
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using WW.Cad.Model.Objects.DynamicBlock;

namespace ns27
{
  internal class Class266 : Class265
  {
    private ulong ulong_2;

    public Class266(DxfBlockConstraintParameter obj)
      : base((DxfEvalGraphExpression) obj)
    {
    }

    public ulong Dependency
    {
      get
      {
        return this.ulong_2;
      }
      set
      {
        this.ulong_2 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfBlockConstraintParameter constraintParameter = this.Object as DxfBlockConstraintParameter;
      if (constraintParameter == null)
        return;
      constraintParameter.Dependency = modelBuilder.method_3(this.Dependency);
    }
  }
}
