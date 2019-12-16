// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockDiametricConstraintParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns3;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockDiametricConstraintParameter : DxfBlockLinearConstraintParameter
  {
    public override string ObjectType
    {
      get
      {
        return "BLOCKDIAMETRICCONSTRAINTPARAMETER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockDiametricConstraintParameter";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockDiametricConstraintParameter constraintParameter = (DxfBlockDiametricConstraintParameter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (constraintParameter == null)
      {
        constraintParameter = new DxfBlockDiametricConstraintParameter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) constraintParameter);
        constraintParameter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) constraintParameter;
    }

    internal override void vmethod_11(DxfWriter w)
    {
      w.method_234("AcDbBlockDiametricConstraintParameter");
      this.method_8(w);
    }

    internal override void vmethod_12(DxfReader r, Class259 objectBuilder)
    {
      this.method_9(r, "AcDbBlockDiametricConstraintParameter");
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_38.ClassNumber;
    }
  }
}
