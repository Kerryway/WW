// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockXYParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockXYParameter : DxfBlockTwoPointsParameter
  {
    private string string_1;
    private string string_2;
    private double double_0;
    private string string_3;
    private string string_4;
    private double double_1;
    private DxfBlockParametersValueSet dxfBlockParametersValueSet_0;
    private DxfBlockParametersValueSet dxfBlockParametersValueSet_1;

    public double LabelOffsetX
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

    public string LabelTextX
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

    public string DescriptionX
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

    public DxfBlockParametersValueSet ParameterValueSetX
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

    public double LabelOffsetY
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    public string LabelTextY
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

    public string DescriptionY
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

    public DxfBlockParametersValueSet ParameterValueSetY
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
        return "BLOCKXYPARAMETER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockXYParameter";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockXYParameter blockXyParameter = (DxfBlockXYParameter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockXyParameter == null)
      {
        blockXyParameter = new DxfBlockXYParameter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockXyParameter);
        blockXyParameter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockXyParameter;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockXYParameter blockXyParameter = (DxfBlockXYParameter) from;
      this.LabelOffsetX = blockXyParameter.LabelOffsetX;
      this.LabelTextX = blockXyParameter.LabelTextX;
      this.DescriptionX = blockXyParameter.DescriptionX;
      this.ParameterValueSetX = (DxfBlockParametersValueSet) blockXyParameter.ParameterValueSetX.Clone(cloneContext);
      this.LabelOffsetY = blockXyParameter.LabelOffsetY;
      this.LabelTextY = blockXyParameter.LabelTextY;
      this.DescriptionY = blockXyParameter.DescriptionY;
      this.ParameterValueSetY = (DxfBlockParametersValueSet) blockXyParameter.ParameterValueSetY.Clone(cloneContext);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_9.ClassNumber;
    }
  }
}
