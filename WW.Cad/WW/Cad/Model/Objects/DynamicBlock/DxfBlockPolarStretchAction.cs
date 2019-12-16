// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockPolarStretchAction
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockPolarStretchAction : DxfBlockAngleOffsetAction
  {
    private DxfConnectionPoint[] dxfConnectionPoint_0 = new DxfConnectionPoint[6];
    private WW.Math.Point2D[] point2D_0;
    private DxfHandledObjectCollection<DxfHandledObject> dxfHandledObjectCollection_2;
    private DxfBlockPolarStretchAction.StretchEntity[] stretchEntity_0;
    private DxfBlockPolarStretchAction.StretchNode[] stretchNode_0;
    private DxfEvalGraph.GraphNodeId[] graphNodeId_2;

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

    public DxfHandledObjectCollection<DxfHandledObject> RotateSelection
    {
      get
      {
        return this.dxfHandledObjectCollection_2;
      }
      set
      {
        this.dxfHandledObjectCollection_2 = value;
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

    public DxfEvalGraph.GraphNodeId[] SelectionSet2
    {
      get
      {
        return this.graphNodeId_2;
      }
      set
      {
        this.graphNodeId_2 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "BLOCKPOLARSTRETCHACTION";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockPolarStretchAction";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockPolarStretchAction polarStretchAction = (DxfBlockPolarStretchAction) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (polarStretchAction == null)
      {
        polarStretchAction = new DxfBlockPolarStretchAction();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) polarStretchAction);
        polarStretchAction.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) polarStretchAction;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockPolarStretchAction polarStretchAction = (DxfBlockPolarStretchAction) from;
      this.ActionConnections = DxfConnectionPoint.Clone(cloneContext, polarStretchAction.ActionConnections);
      if (polarStretchAction.Frame == null)
      {
        this.Frame = (WW.Math.Point2D[]) null;
      }
      else
      {
        this.Frame = new WW.Math.Point2D[polarStretchAction.Frame.Length];
        for (int index = 0; index < polarStretchAction.Frame.Length; ++index)
          this.Frame[index] = polarStretchAction.Frame[index];
      }
      if (polarStretchAction.RotateSelection == null)
      {
        this.RotateSelection = (DxfHandledObjectCollection<DxfHandledObject>) null;
      }
      else
      {
        int count = polarStretchAction.RotateSelection.Count;
        this.RotateSelection = new DxfHandledObjectCollection<DxfHandledObject>(count);
        for (int index = 0; index < count; ++index)
          this.RotateSelection.Add(cloneContext.SourceModel == cloneContext.TargetModel ? polarStretchAction.RotateSelection[index] : polarStretchAction.RotateSelection[index].Clone(cloneContext) as DxfHandledObject);
      }
      this.StretchEntities = DxfBlockPolarStretchAction.StretchEntity.Clone(polarStretchAction.StretchEntities, cloneContext);
      this.StretchNodes = DxfBlockPolarStretchAction.StretchNode.Clone(cloneContext, polarStretchAction.StretchNodes);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_18.ClassNumber;
    }

    public struct StretchEntity
    {
      private DxfObjectReference dxfObjectReference_0;
      private int[] int_0;

      public DxfHandledObject Entity
      {
        get
        {
          if (this.dxfObjectReference_0 != null)
            return (DxfHandledObject) this.dxfObjectReference_0.Value;
          return (DxfHandledObject) null;
        }
        set
        {
          this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        }
      }

      public int[] PointIndexes
      {
        get
        {
          return this.int_0;
        }
        set
        {
          this.int_0 = value;
        }
      }

      public static DxfBlockPolarStretchAction.StretchEntity Clone(
        DxfBlockPolarStretchAction.StretchEntity cloneFrom,
        CloneContext cloneContext)
      {
        DxfBlockPolarStretchAction.StretchEntity stretchEntity = new DxfBlockPolarStretchAction.StretchEntity();
        stretchEntity.Entity = cloneContext.SourceModel == cloneContext.TargetModel ? cloneFrom.Entity : (DxfHandledObject) cloneContext.Clone((IGraphCloneable) cloneFrom.Entity);
        if (cloneFrom.PointIndexes == null)
        {
          stretchEntity.PointIndexes = (int[]) null;
        }
        else
        {
          stretchEntity.PointIndexes = new int[cloneFrom.PointIndexes.Length];
          cloneFrom.PointIndexes.CopyTo((Array) stretchEntity.PointIndexes, 0);
        }
        return stretchEntity;
      }

      public static DxfBlockPolarStretchAction.StretchEntity[] Clone(
        DxfBlockPolarStretchAction.StretchEntity[] cloneFrom,
        CloneContext cloneContext)
      {
        if (cloneFrom == null)
          return (DxfBlockPolarStretchAction.StretchEntity[]) null;
        DxfBlockPolarStretchAction.StretchEntity[] stretchEntityArray = new DxfBlockPolarStretchAction.StretchEntity[cloneFrom.Length];
        for (int index = 0; index < cloneFrom.Length; ++index)
          stretchEntityArray[index] = DxfBlockPolarStretchAction.StretchEntity.Clone(cloneFrom[index], cloneContext);
        return stretchEntityArray;
      }
    }

    public struct StretchNode : IGraphCloneable
    {
      public DxfEvalGraph.GraphNodeId Node;
      public int[] PointIndexes;

      public IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfBlockPolarStretchAction.StretchNode stretchNode = new DxfBlockPolarStretchAction.StretchNode();
        stretchNode.Node = (DxfEvalGraph.GraphNodeId) cloneContext.Clone((IGraphCloneable) this.Node);
        stretchNode.PointIndexes = new int[this.PointIndexes.Length];
        this.PointIndexes.CopyTo((Array) stretchNode.PointIndexes, 0);
        return (IGraphCloneable) stretchNode;
      }

      public static DxfBlockPolarStretchAction.StretchNode[] Clone(
        CloneContext cloneContext,
        DxfBlockPolarStretchAction.StretchNode[] cloneFrom)
      {
        if (cloneFrom == null)
          return (DxfBlockPolarStretchAction.StretchNode[]) null;
        DxfBlockPolarStretchAction.StretchNode[] stretchNodeArray = new DxfBlockPolarStretchAction.StretchNode[cloneFrom.Length];
        for (int index = 0; index < cloneFrom.Length; ++index)
          stretchNodeArray[index] = (DxfBlockPolarStretchAction.StretchNode) cloneFrom[index].Clone(cloneContext);
        return stretchNodeArray;
      }
    }
  }
}
