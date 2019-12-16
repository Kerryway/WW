// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockLinearParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockLinearParameter : DxfBlockTwoPointsParameter
  {
    private string string_1;
    private string string_2;
    private double double_0;
    private DxfBlockParametersValueSet dxfBlockParametersValueSet_0;

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

    public override string ObjectType
    {
      get
      {
        return "BLOCKLINEARPARAMETER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockLinearParameter";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockLinearParameter blockLinearParameter = (DxfBlockLinearParameter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockLinearParameter == null)
      {
        blockLinearParameter = new DxfBlockLinearParameter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockLinearParameter);
        blockLinearParameter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockLinearParameter;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockLinearParameter blockLinearParameter = (DxfBlockLinearParameter) from;
      this.LabelOffset = blockLinearParameter.LabelOffset;
      this.LabelText = blockLinearParameter.LabelText;
      this.Description = blockLinearParameter.Description;
      this.Distance = (DxfBlockParametersValueSet) blockLinearParameter.Distance.Clone(cloneContext);
    }

    public override string ToString()
    {
      return this.string_1;
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_8.ClassNumber;
    }
  }
}
