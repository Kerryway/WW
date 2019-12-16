// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockAlignmentParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockAlignmentParameter : DxfBlockTwoPointsParameter
  {
    private bool bool_2;

    public bool IsPerpendicular
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override string ObjectType
    {
      get
      {
        return "BLOCKALIGNMENTPARAMETER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockAlignmentParameter";
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockAlignmentParameter alignmentParameter = (DxfBlockAlignmentParameter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (alignmentParameter == null)
      {
        alignmentParameter = new DxfBlockAlignmentParameter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) alignmentParameter);
        alignmentParameter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) alignmentParameter;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      this.IsPerpendicular = ((DxfBlockAlignmentParameter) from).IsPerpendicular;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_11.ClassNumber;
    }
  }
}
