// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfConnectionPoint
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfConnectionPoint : IGraphCloneable
  {
    private DxfEvalGraph.GraphNodeId graphNodeId_0;
    private string string_0;

    public DxfEvalGraph.GraphNodeId ConnectionPointId
    {
      get
      {
        return this.graphNodeId_0;
      }
      set
      {
        this.graphNodeId_0 = value;
      }
    }

    public string ConnectionString
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfConnectionPoint dxfConnectionPoint = (DxfConnectionPoint) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfConnectionPoint == null)
      {
        dxfConnectionPoint = new DxfConnectionPoint();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfConnectionPoint);
        dxfConnectionPoint.CopyFrom(cloneContext, this);
      }
      return (IGraphCloneable) dxfConnectionPoint;
    }

    protected virtual void CopyFrom(CloneContext cloneContext, DxfConnectionPoint from)
    {
      this.graphNodeId_0 = (DxfEvalGraph.GraphNodeId) cloneContext.Clone((IGraphCloneable) from.graphNodeId_0);
      this.string_0 = from.string_0;
    }

    public static DxfConnectionPoint[] Clone(
      CloneContext cloneContext,
      DxfConnectionPoint[] cloneFrom)
    {
      if (cloneFrom == null)
        return (DxfConnectionPoint[]) null;
      DxfConnectionPoint[] dxfConnectionPointArray = new DxfConnectionPoint[cloneFrom.Length];
      for (int index = 0; index < cloneFrom.Length; ++index)
        dxfConnectionPointArray[index] = (DxfConnectionPoint) cloneContext.Clone((IGraphCloneable) cloneFrom[index]);
      return dxfConnectionPointArray;
    }
  }
}
