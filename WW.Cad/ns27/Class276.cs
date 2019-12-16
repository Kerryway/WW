// Decompiled with JetBrains decompiler
// Type: ns27.Class276
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns3;
using ns46;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.DynamicBlock;

namespace ns27
{
  internal class Class276 : Class260
  {
    private ulong[] ulong_2;

    public Class276(DxfEvalGraph obj)
      : base((DxfObject) obj)
    {
    }

    public ulong[] ExpressionHandles
    {
      get
      {
        return this.ulong_2;
      }
      set
      {
        this.ulong_2 = value;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      DxfEvalGraph evalGraph = this.Object as DxfEvalGraph;
      if (evalGraph.Nodes == null)
        return;
      int num = Class740.smethod_12(evalGraph.Nodes);
      for (int index = 0; index < num; ++index)
      {
        evalGraph.Nodes[index].Expression = modelBuilder.method_4<DxfObject>(this.ExpressionHandles[index]);
        DxfObject expression = evalGraph.Nodes[index].Expression;
      }
      foreach (DxfEvalGraph.GraphNode node in evalGraph.Nodes)
      {
        if (node.Expression == null)
        {
          Class740.smethod_14(evalGraph);
          break;
        }
      }
    }
  }
}
