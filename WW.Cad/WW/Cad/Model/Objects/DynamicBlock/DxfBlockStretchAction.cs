// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockStretchAction
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockStretchAction : DxfBlockAngleOffsetAction
  {
    private DxfConnectionPoint[] dxfConnectionPoint_0 = new DxfConnectionPoint[2];
    private WW.Math.Point2D[] point2D_0;
    private DxfBlockPolarStretchAction.StretchEntity[] stretchEntity_0;
    private DxfBlockPolarStretchAction.StretchNode[] stretchNode_0;

    public DxfConnectionPoint[] ActionConnections
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

    public WW.Math.Point2D[] Frame
    {
      get
      {
        return this.point2D_0;
      }
      set
      {
        this.point2D_0 = value;
      }
    }

    public DxfBlockPolarStretchAction.StretchEntity[] StretchEntities
    {
      get
      {
        return this.stretchEntity_0;
      }
      set
      {
        this.stretchEntity_0 = value;
      }
    }

    public DxfBlockPolarStretchAction.StretchNode[] StretchNodes
    {
      get
      {
        return this.stretchNode_0;
      }
      set
      {
        this.stretchNode_0 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "BLOCKSTRETCHACTION";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockStretchAction";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockStretchAction blockStretchAction = (DxfBlockStretchAction) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockStretchAction == null)
      {
        blockStretchAction = new DxfBlockStretchAction();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockStretchAction);
        blockStretchAction.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockStretchAction;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockStretchAction blockStretchAction = (DxfBlockStretchAction) from;
      this.ActionConnections = DxfConnectionPoint.Clone(cloneContext, blockStretchAction.ActionConnections);
      this.Frame = new WW.Math.Point2D[blockStretchAction.Frame.Length];
      for (int index = 0; index < blockStretchAction.Frame.Length; ++index)
        this.Frame[index] = blockStretchAction.Frame[index];
      this.StretchEntities = DxfBlockPolarStretchAction.StretchEntity.Clone(blockStretchAction.StretchEntities, cloneContext);
      this.StretchNodes = DxfBlockPolarStretchAction.StretchNode.Clone(cloneContext, blockStretchAction.StretchNodes);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_19.ClassNumber;
    }
  }
}
