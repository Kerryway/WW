// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockFlipParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockFlipParameter : DxfBlockTwoPointsParameter
  {
    private string string_1;
    private string string_2;
    private WW.Math.Point3D point3D_2;
    private string string_3;
    private string string_4;
    private DxfConnectionPoint dxfConnectionPoint_0;

    public WW.Math.Point3D LabelPosition
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

    public string NotFlippedState
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

    public string FlippedState
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

    public DxfConnectionPoint Connection
    {
      get
      {
        return this.dxfConnectionPoint_0;
      }
      set
      {
        this.dxfConnectionPoint_0 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "BLOCKFLIPPARAMETER";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockFlipParameter";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockFlipParameter blockFlipParameter = (DxfBlockFlipParameter) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockFlipParameter == null)
      {
        blockFlipParameter = new DxfBlockFlipParameter();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockFlipParameter);
        blockFlipParameter.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockFlipParameter;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockFlipParameter blockFlipParameter = (DxfBlockFlipParameter) from;
      this.LabelPosition = blockFlipParameter.LabelPosition;
      this.LabelText = blockFlipParameter.LabelText;
      this.Description = blockFlipParameter.Description;
      this.NotFlippedState = blockFlipParameter.NotFlippedState;
      this.FlippedState = blockFlipParameter.FlippedState;
      this.Connection = (DxfConnectionPoint) cloneContext.Clone((IGraphCloneable) blockFlipParameter.Connection);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_10.ClassNumber;
    }
  }
}
