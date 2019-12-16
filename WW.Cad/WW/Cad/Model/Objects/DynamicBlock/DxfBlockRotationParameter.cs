// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockRotationParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockRotationParameter : DxfBlockTwoPointsParameter
  {
    private string string_1;
    private string string_2;
    private double double_0;
    private DxfBlockParametersValueSet dxfBlockParametersValueSet_0;
    private WW.Math.Point3D point3D_2;

    public WW.Math.Point3D StartPoint
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

    public double LabelOffset
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

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

    public DxfBlockParametersValueSet Angle
    {
      get
      {
        return this.dxfBlockParametersValueSet_0;
      }
      set
      {
        this.dxfBlockParametersValueSet_0 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "BLOCKROTATIONPARAMETER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockRotationParameter";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockRotationParameter rotationParameter = (DxfBlockRotationParameter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (rotationParameter == null)
      {
        rotationParameter = new DxfBlockRotationParameter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) rotationParameter);
        rotationParameter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) rotationParameter;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockRotationParameter rotationParameter = (DxfBlockRotationParameter) from;
      this.StartPoint = rotationParameter.StartPoint;
      this.LabelOffset = rotationParameter.LabelOffset;
      this.LabelText = rotationParameter.LabelText;
      this.Description = rotationParameter.Description;
      this.Angle = (DxfBlockParametersValueSet) rotationParameter.Angle.Clone(cloneContext);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_7.ClassNumber;
    }
  }
}
