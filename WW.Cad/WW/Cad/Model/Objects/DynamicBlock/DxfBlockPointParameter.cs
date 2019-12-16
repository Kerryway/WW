// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockPointParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockPointParameter : DxfBlockSinglePointParameter
  {
    private string string_1;
    private string string_2;
    private WW.Math.Point3D point3D_1;

    public string LabelText
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public string Description
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value;
      }
    }

    public WW.Math.Point3D LabelPosition
    {
      get
      {
        return this.point3D_1;
      }
      set
      {
        this.point3D_1 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "BLOCKPOINTPARAMETER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockPointParameter";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockPointParameter blockPointParameter = (DxfBlockPointParameter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockPointParameter == null)
      {
        blockPointParameter = new DxfBlockPointParameter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockPointParameter);
        blockPointParameter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockPointParameter;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockPointParameter blockPointParameter = (DxfBlockPointParameter) from;
      this.LabelText = blockPointParameter.LabelText;
      this.Description = blockPointParameter.Description;
      this.LabelPosition = blockPointParameter.LabelPosition;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_1.ClassNumber;
    }
  }
}
