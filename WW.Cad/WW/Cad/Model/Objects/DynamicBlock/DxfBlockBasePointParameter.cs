// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockBasePointParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockBasePointParameter : DxfBlockSinglePointParameter
  {
    private WW.Math.Point3D point3D_1;
    private WW.Math.Point3D point3D_2;

    public WW.Math.Point3D BasePoint1
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

    public WW.Math.Point3D BasePoint2
    {
      get
      {
        return this.point3D_2;
      }
      set
      {
        this.point3D_2 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "BLOCKBASEPOINTPARAMETER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockBasepointParameter";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockBasePointParameter basePointParameter = (DxfBlockBasePointParameter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (basePointParameter == null)
      {
        basePointParameter = new DxfBlockBasePointParameter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) basePointParameter);
        basePointParameter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) basePointParameter;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockBasePointParameter basePointParameter = (DxfBlockBasePointParameter) from;
      this.BasePoint1 = basePointParameter.BasePoint1;
      this.BasePoint2 = basePointParameter.BasePoint2;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_2.ClassNumber;
    }
  }
}
