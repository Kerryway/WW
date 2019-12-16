// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockPolarParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockPolarParameter : DxfBlockTwoPointsParameter
  {
    private string string_1;
    private string string_2;
    private string string_3;
    private string string_4;
    private double double_0;
    private DxfBlockParametersValueSet dxfBlockParametersValueSet_0;
    private DxfBlockParametersValueSet dxfBlockParametersValueSet_1;

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

    public string AngleDescription
    {
      get
      {
        return this.string_4;
      }
      set
      {
        this.string_4 = value;
      }
    }

    public string AngleLabelText
    {
      get
      {
        return this.string_3;
      }
      set
      {
        this.string_3 = value;
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

    public DxfBlockParametersValueSet Distance
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

    public DxfBlockParametersValueSet Angle
    {
      get
      {
        return this.dxfBlockParametersValueSet_1;
      }
      set
      {
        this.dxfBlockParametersValueSet_1 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "BLOCKPOLARPARAMETER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockPolarParameter";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockPolarParameter blockPolarParameter = (DxfBlockPolarParameter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockPolarParameter == null)
      {
        blockPolarParameter = new DxfBlockPolarParameter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockPolarParameter);
        blockPolarParameter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockPolarParameter;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockPolarParameter blockPolarParameter = (DxfBlockPolarParameter) from;
      this.LabelText = blockPolarParameter.LabelText;
      this.Description = blockPolarParameter.Description;
      this.AngleLabelText = blockPolarParameter.AngleLabelText;
      this.AngleDescription = blockPolarParameter.AngleDescription;
      this.LabelOffset = blockPolarParameter.LabelOffset;
      this.Distance = (DxfBlockParametersValueSet) blockPolarParameter.Distance.Clone(cloneContext);
      this.Angle = (DxfBlockParametersValueSet) blockPolarParameter.Angle.Clone(cloneContext);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_6.ClassNumber;
    }
  }
}
