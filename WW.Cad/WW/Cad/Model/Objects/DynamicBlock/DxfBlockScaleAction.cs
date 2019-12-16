// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockScaleAction
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockScaleAction : DxfBlockBasePointAction
  {
    private DxfConnectionPoint[] dxfConnectionPoint_1 = new DxfConnectionPoint[3];
    private DxfBlockAction.ScaleTypeXY scaleTypeXY_0;

    public DxfBlockAction.ScaleTypeXY ScaleType
    {
      get
      {
        return this.scaleTypeXY_0;
      }
      set
      {
        this.scaleTypeXY_0 = value;
      }
    }

    public DxfConnectionPoint[] ActionConnections
    {
      get
      {
        return this.dxfConnectionPoint_1;
      }
      set
      {
        this.dxfConnectionPoint_1 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "BLOCKSCALEACTION";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockScaleAction";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockScaleAction blockScaleAction = (DxfBlockScaleAction) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockScaleAction == null)
      {
        blockScaleAction = new DxfBlockScaleAction();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockScaleAction);
        blockScaleAction.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockScaleAction;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockScaleAction blockScaleAction = (DxfBlockScaleAction) from;
      this.ScaleType = blockScaleAction.ScaleType;
      this.ActionConnections = DxfConnectionPoint.Clone(cloneContext, blockScaleAction.ActionConnections);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_13.ClassNumber;
    }
  }
}
