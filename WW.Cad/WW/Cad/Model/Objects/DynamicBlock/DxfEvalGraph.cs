// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfEvalGraph
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System.Collections.Generic;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfEvalGraph : DxfObject
  {
    private DxfEvalGraph.GraphNodeId graphNodeId_0;
    private DxfEvalGraph.GraphNode[] graphNode_0;
    private DxfEvalGraph.GraphEdge[] graphEdge_0;

    public DxfEvalGraph.GraphNodeId LastNodeId
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

    public DxfEvalGraph.GraphNode[] Nodes
    {
      get
      {
        return this.graphNode_0;
      }
      set
      {
        this.graphNode_0 = value;
      }
    }

    public DxfEvalGraph.GraphEdge[] Edges
    {
      get
      {
        return this.graphEdge_0;
      }
      set
      {
        this.graphEdge_0 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "ACAD_EVALUATION_GRAPH";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbEvalGraph";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
      DxfEvalGraph.GraphNode[] nodes = this.Nodes;
      if (nodes == null)
        return;
      foreach (DxfEvalGraph.GraphNode graphNode in nodes)
      {
        if (graphNode.Expression != null)
          graphNode.Expression.Accept(visitor);
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfEvalGraph dxfEvalGraph = (DxfEvalGraph) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfEvalGraph == null)
      {
        dxfEvalGraph = new DxfEvalGraph();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfEvalGraph);
        dxfEvalGraph.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfEvalGraph;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfEvalGraph dxfEvalGraph = (DxfEvalGraph) from;
      this.LastNodeId = (DxfEvalGraph.GraphNodeId) cloneContext.Clone((IGraphCloneable) dxfEvalGraph.LastNodeId);
      if (dxfEvalGraph.Nodes == null)
      {
        this.Nodes = (DxfEvalGraph.GraphNode[]) null;
      }
      else
      {
        this.Nodes = new DxfEvalGraph.GraphNode[dxfEvalGraph.Nodes.Length];
        for (int index = 0; index < this.Nodes.Length; ++index)
        {
          this.Nodes[index] = (DxfEvalGraph.GraphNode) dxfEvalGraph.Nodes[index].Clone(cloneContext);
          this.Nodes[index].Expression.vmethod_2((IDxfHandledObject) this);
        }
      }
      if (dxfEvalGraph.Edges == null)
      {
        this.Edges = (DxfEvalGraph.GraphEdge[]) null;
      }
      else
      {
        this.Edges = dxfEvalGraph.Edges;
        for (int index = 0; index < this.Edges.Length; ++index)
          this.Edges[index] = (DxfEvalGraph.GraphEdge) dxfEvalGraph.Edges[index].Clone(cloneContext);
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_0.ClassNumber;
    }

    protected internal override void ExecuteDeepHelper(
      Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      foreach (DxfEvalGraph.GraphNode node in this.Nodes)
      {
        if (node.Expression != null)
          node.Expression.vmethod_0(action, callerStack);
      }
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf13OrHigher;
    }

    public class GraphNodeId : IGraphCloneable
    {
      public int Id;

      public GraphNodeId()
      {
        this.Id = 0;
      }

      public GraphNodeId(int id)
      {
        this.Id = id;
      }

      public IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfEvalGraph.GraphNodeId graphNodeId = (DxfEvalGraph.GraphNodeId) cloneContext.GetExistingClone((IGraphCloneable) this);
        if (graphNodeId == null)
        {
          graphNodeId = new DxfEvalGraph.GraphNodeId();
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) graphNodeId);
          graphNodeId.CopyFrom(this);
        }
        return (IGraphCloneable) graphNodeId;
      }

      protected virtual void CopyFrom(DxfEvalGraph.GraphNodeId from)
      {
        this.Id = from.Id;
      }

      public static DxfEvalGraph.GraphNodeId[] Clone(
        CloneContext cloneContext,
        DxfEvalGraph.GraphNodeId[] cloneFrom)
      {
        if (cloneFrom == null)
          return (DxfEvalGraph.GraphNodeId[]) null;
        DxfEvalGraph.GraphNodeId[] graphNodeIdArray = new DxfEvalGraph.GraphNodeId[cloneFrom.Length];
        for (int index = 0; index < cloneFrom.Length; ++index)
          graphNodeIdArray[index] = (DxfEvalGraph.GraphNodeId) cloneContext.Clone((IGraphCloneable) cloneFrom[index]);
        return graphNodeIdArray;
      }

      public override string ToString()
      {
        return this.Id.ToString();
      }
    }

    public class GraphNode : IGraphCloneable
    {
      private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
      private DxfEvalGraph.GraphNodeId graphNodeId_0;
      private int int_0;
      private int int_1;
      private int int_2;
      private int int_3;

      public GraphNode()
      {
        this.FirstIncomingEdge = -1;
        this.LastIncomingEdge = -1;
        this.FirstOutgoingEdge = -1;
        this.LastOutgoingEdge = -1;
      }

      public GraphNode(
        int id,
        DxfObject expression,
        int firstIncomingEdge,
        int lastIncomingEdge,
        int firstOutgoingEdge,
        int lastOutgoingEdge)
      {
        this.graphNodeId_0 = new DxfEvalGraph.GraphNodeId(id);
        this.int_0 = firstIncomingEdge;
        this.int_1 = lastIncomingEdge;
        this.int_2 = firstOutgoingEdge;
        this.int_3 = lastOutgoingEdge;
        this.Expression = expression;
      }

      public DxfEvalGraph.GraphNodeId Id
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

      public DxfObject Expression
      {
        get
        {
          return (DxfObject) this.dxfObjectReference_0.Value;
        }
        set
        {
          this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
        }
      }

      public int FirstIncomingEdge
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

      public int LastIncomingEdge
      {
        get
        {
          return this.int_1;
        }
        set
        {
          this.int_1 = value;
        }
      }

      public int FirstOutgoingEdge
      {
        get
        {
          return this.int_2;
        }
        set
        {
          this.int_2 = value;
        }
      }

      public int LastOutgoingEdge
      {
        get
        {
          return this.int_3;
        }
        set
        {
          this.int_3 = value;
        }
      }

      public IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfEvalGraph.GraphNode graphNode = (DxfEvalGraph.GraphNode) cloneContext.GetExistingClone((IGraphCloneable) this);
        if (graphNode == null)
        {
          graphNode = new DxfEvalGraph.GraphNode();
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) graphNode);
          graphNode.CopyFrom(cloneContext, this);
        }
        return (IGraphCloneable) graphNode;
      }

      protected virtual void CopyFrom(CloneContext cloneContext, DxfEvalGraph.GraphNode from)
      {
        this.graphNodeId_0 = (DxfEvalGraph.GraphNodeId) cloneContext.Clone((IGraphCloneable) from.graphNodeId_0);
        this.Expression = (DxfObject) cloneContext.Clone((IGraphCloneable) from.Expression);
        this.int_0 = from.int_0;
        this.int_1 = from.int_1;
        this.int_2 = from.int_2;
        this.int_3 = from.int_3;
      }

      public override string ToString()
      {
        return string.Format("Id: {0}, Expression: {1}", (object) this.graphNodeId_0, (object) this.Expression);
      }
    }

    public enum EdgeFlags
    {
      Undefined = 0,
      Suppressed = 2,
      Invertible = 4,
    }

    public class GraphEdge : IGraphCloneable
    {
      public int StartNode;
      public int EndNode;
      public int Flags;
      public int ReferenceCount;
      public int PreviousIncoming;
      public int NextIncoming;
      public int PreviousOutgoing;
      public int NextOutgoing;
      public int ReverseEdgeIndex;

      public GraphEdge()
      {
        this.StartNode = -1;
        this.EndNode = -1;
        this.Flags = 0;
        this.PreviousIncoming = -1;
        this.NextIncoming = -1;
        this.PreviousOutgoing = -1;
        this.NextOutgoing = -1;
        this.ReverseEdgeIndex = -1;
        this.ReferenceCount = 1;
      }

      public GraphEdge(
        int startNode,
        int endNode,
        int flags,
        int referenceCount,
        int previousIncoming,
        int nextIncoming,
        int previousOutgoing,
        int nextOutgoing,
        int reverseEdgeIndex)
      {
        this.StartNode = startNode;
        this.EndNode = endNode;
        this.Flags = flags;
        this.ReferenceCount = referenceCount;
        this.PreviousIncoming = previousIncoming;
        this.NextIncoming = nextIncoming;
        this.PreviousOutgoing = previousOutgoing;
        this.NextOutgoing = nextOutgoing;
        this.ReverseEdgeIndex = reverseEdgeIndex;
      }

      public IGraphCloneable Clone(CloneContext cloneContext)
      {
        DxfEvalGraph.GraphEdge graphEdge = (DxfEvalGraph.GraphEdge) cloneContext.GetExistingClone((IGraphCloneable) this);
        if (graphEdge == null)
        {
          graphEdge = new DxfEvalGraph.GraphEdge();
          cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) graphEdge);
          graphEdge.CopyFrom(cloneContext, this);
        }
        return (IGraphCloneable) graphEdge;
      }

      protected virtual void CopyFrom(CloneContext cloneContext, DxfEvalGraph.GraphEdge from)
      {
        this.StartNode = from.StartNode;
        this.EndNode = from.EndNode;
        this.Flags = from.Flags;
        this.ReferenceCount = from.ReferenceCount;
        this.PreviousIncoming = from.PreviousIncoming;
        this.NextIncoming = from.NextIncoming;
        this.PreviousOutgoing = from.PreviousOutgoing;
        this.NextOutgoing = from.NextOutgoing;
        this.ReverseEdgeIndex = from.ReverseEdgeIndex;
      }
    }
  }
}
