// Decompiled with JetBrains decompiler
// Type: ns27.Class272
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns46;
using WW.Cad.Model;
using WW.Cad.Model.Objects.DynamicBlock;

namespace ns27
{
  internal class Class272 : Class265
  {
    private ulong ulong_2;

    public Class272(DxfBlockUserParameter obj)
      : base((DxfEvalGraphExpression) obj)
    {
    }

    public ulong Variable
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
      DxfBlockUserParameter blockUserParameter = this.Object as DxfBlockUserParameter;
      if (blockUserParameter == null)
        return;
      blockUserParameter.Variable = (DxfHandledObject) null;
      if (this.ulong_2 == 0UL)
        return;
      blockUserParameter.Variable = modelBuilder.method_3(this.ulong_2);
      if (blockUserParameter.Variable != null)
        return;
      Class740.smethod_14(blockUserParameter.OwnerObjectSoftReference as DxfEvalGraph);
    }
  }
}
