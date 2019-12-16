// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.ProcessedGraphics
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model.Tables;
using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class ProcessedGraphics : ProcessedGraphicElementBlock
  {
    private Dictionary<GraphicElement2, ProcessedGraphics.Class733> dictionary_0 = new Dictionary<GraphicElement2, ProcessedGraphics.Class733>();
    private Dictionary<GraphicElementBlock1, ProcessedGraphicElementBlock> dictionary_1 = new Dictionary<GraphicElementBlock1, ProcessedGraphicElementBlock>();
    private Dictionary<GraphicElementBlock2, ProcessedGraphics.Class734> dictionary_2 = new Dictionary<GraphicElementBlock2, ProcessedGraphics.Class734>();

    public ProcessedGraphics()
      : base(Matrix4D.Identity)
    {
    }

    public void Process(GraphicsConfig graphicsConfig, Graphics graphics)
    {
      ProcessedGraphics.Class731 class731 = new ProcessedGraphics.Class731(this, graphicsConfig, (ProcessedGraphicElementBlock) this, Matrix4D.Identity);
      foreach (IGraphicElement graphicElement in graphics.GraphicElements)
        graphicElement.Accept((IGraphicElementVisitor) class731);
    }

    private static bool smethod_0(DxfLineType lineType)
    {
      return lineType.Elements.Count == 0;
    }

    private static Matrix4D smethod_1(Matrix4D transform)
    {
      Matrix4D matrix4D = transform;
      matrix4D.M03 = 0.0;
      matrix4D.M13 = 0.0;
      matrix4D.M23 = 0.0;
      return matrix4D;
    }

    private class Class731 : IGraphicElementVisitor
    {
      private readonly ProcessedGraphics processedGraphics_0;
      private readonly GraphicsConfig graphicsConfig_0;
      private readonly ProcessedGraphicElementBlock processedGraphicElementBlock_0;
      private readonly Matrix4D matrix4D_0;
      private readonly Matrix4D matrix4D_1;

      public Class731(
        ProcessedGraphics processedGraphics,
        GraphicsConfig graphicsConfig,
        ProcessedGraphicElementBlock block,
        Matrix4D toWcsTransform)
      {
        this.processedGraphics_0 = processedGraphics;
        this.graphicsConfig_0 = graphicsConfig;
        this.processedGraphicElementBlock_0 = block;
        this.matrix4D_0 = toWcsTransform;
        this.matrix4D_1 = ProcessedGraphics.smethod_1(toWcsTransform);
      }

      public void Visit(NullGraphicElement visitee)
      {
      }

      public void Visit(GraphicElement1 visitee)
      {
        this.processedGraphicElementBlock_0.GraphicElements.Add(visitee);
      }

      public void Visit(GraphicElement1Node visitee)
      {
        this.processedGraphicElementBlock_0.GraphicElements.Add((GraphicElement1) visitee);
      }

      public void Visit(GraphicElement2 visitee)
      {
        GraphicElement1 graphicElement1_1 = (GraphicElement1) null;
        GraphicElement1 graphicElement1_2 = (GraphicElement1) null;
        ProcessedGraphics.Class733 class733_1;
        if (this.processedGraphics_0.dictionary_0.TryGetValue(visitee, out class733_1))
        {
          graphicElement1_1 = class733_1.GraphicElementWithoutLineType;
          graphicElement1_2 = class733_1.method_0(this.matrix4D_1);
        }
        if (ProcessedGraphics.smethod_0(visitee.LineType))
        {
          if (graphicElement1_1 == null)
          {
            graphicElement1_1 = (GraphicElement1) visitee;
            ProcessedGraphics.Class733 class733_2 = new ProcessedGraphics.Class733() { GraphicElementWithoutLineType = graphicElement1_1 };
            this.processedGraphics_0.dictionary_0.Add(visitee, class733_2);
          }
        }
        else
        {
          if (graphicElement1_2 == null)
          {
            GraphicElement1 graphicElementWithoutLineType = (GraphicElement1) null;
            if (graphicElement1_1 == null)
            {
              graphicElementWithoutLineType = new GraphicElement1(new WW.Cad.Drawing.Surface.Geometry(), visitee.Color);
              if (visitee.Geometry.HasExtrusion)
                graphicElementWithoutLineType.Geometry.Extrusion = visitee.Geometry.Extrusion;
            }
            graphicElement1_2 = new GraphicElement1(new WW.Cad.Drawing.Surface.Geometry(), visitee.Color);
            if (visitee.Geometry.HasExtrusion)
              graphicElement1_2.Geometry.Extrusion = visitee.Geometry.Extrusion;
            ProcessedGraphics.Class731.Class732 class732 = new ProcessedGraphics.Class731.Class732(this.graphicsConfig_0, graphicElementWithoutLineType, graphicElement1_2, this.matrix4D_1, visitee.LineType, visitee.LineTypeScale, visitee.Plinegen);
            foreach (IPrimitive primitive in (List<IPrimitive>) visitee.Geometry)
              primitive.Accept((IPrimitiveVisitor) class732);
            if (graphicElement1_1 == null)
              graphicElement1_1 = graphicElementWithoutLineType;
          }
          if (class733_1 == null)
          {
            class733_1 = new ProcessedGraphics.Class733()
            {
              GraphicElementWithoutLineType = graphicElement1_1
            };
            this.processedGraphics_0.dictionary_0.Add(visitee, class733_1);
          }
          class733_1.GraphicElementsWithLineType.Add(new Pair<Matrix4D, GraphicElement1>(this.matrix4D_1, graphicElement1_2));
        }
        if (graphicElement1_1 != null && graphicElement1_1.Geometry.Count > 0)
          this.processedGraphicElementBlock_0.GraphicElements.Add(graphicElement1_1);
        if (graphicElement1_2 == null || graphicElement1_2.Geometry.Count <= 0)
          return;
        this.processedGraphicElementBlock_0.GraphicElements.Add(graphicElement1_2);
      }

      public void Visit(GraphicElementInsert visitee)
      {
        ProcessedGraphicElementBlock second = (ProcessedGraphicElementBlock) null;
        Matrix4D matrix4D = ProcessedGraphics.smethod_1(visitee.InsertCells[0, 0].Transform);
        ProcessedGraphics.Class734 class734;
        if (this.processedGraphics_0.dictionary_2.TryGetValue(visitee.UnclippedBlock, out class734))
          second = class734.method_0(matrix4D);
        bool flag;
        if (!(flag = second != null))
          second = new ProcessedGraphicElementBlock(visitee.UnclippedBlock.Transform);
        if (class734 == null)
        {
          class734 = new ProcessedGraphics.Class734();
          this.processedGraphics_0.dictionary_2.Add(visitee.UnclippedBlock, class734);
        }
        class734.Blocks.Add(new Pair<Matrix4D, ProcessedGraphicElementBlock>(matrix4D, second));
        ProcessedGraphicElementInsert graphicElementInsert = new ProcessedGraphicElementInsert() { UnclippedBlock = second };
        if (!flag)
        {
          GraphicElementInsert.InsertCell insertCell = visitee.InsertCells[0, 0];
          ProcessedGraphics.Class731 class731 = new ProcessedGraphics.Class731(this.processedGraphics_0, this.graphicsConfig_0, graphicElementInsert.UnclippedBlock, this.matrix4D_0 * insertCell.Transform);
          foreach (IGraphicElement graphicElement in visitee.UnclippedBlock.GraphicElements)
            graphicElement.Accept((IGraphicElementVisitor) class731);
        }
        int length1 = visitee.InsertCells.GetLength(0);
        int length2 = visitee.InsertCells.GetLength(1);
        graphicElementInsert.InsertCells = new ProcessedGraphicElementInsert.InsertCell[length1, length2];
        for (int index1 = 0; index1 < length1; ++index1)
        {
          for (int index2 = 0; index2 < length2; ++index2)
          {
            GraphicElementInsert.InsertCell insertCell = visitee.InsertCells[index1, index2];
            graphicElementInsert.InsertCells[index1, index2] = new ProcessedGraphicElementInsert.InsertCell(insertCell.Transform)
            {
              ClippedBlock = graphicElementInsert.UnclippedBlock
            };
          }
        }
        if (visitee.AttributeBlock != null)
        {
          ProcessedGraphicElementBlock graphicElementBlock;
          if (this.processedGraphics_0.dictionary_1.TryGetValue(visitee.AttributeBlock, out graphicElementBlock))
          {
            graphicElementInsert.AttributeBlock = graphicElementBlock;
          }
          else
          {
            graphicElementInsert.AttributeBlock = new ProcessedGraphicElementBlock(visitee.AttributeBlock.Transform);
            foreach (IGraphicElement graphicElement in visitee.AttributeBlock.GraphicElements)
            {
              GraphicElement1 graphicElement1 = graphicElement as GraphicElement1;
              if (graphicElement1 != null)
                graphicElementInsert.AttributeBlock.GraphicElements.Add(graphicElement1);
            }
            this.processedGraphics_0.dictionary_1.Add(visitee.AttributeBlock, graphicElementBlock);
          }
          graphicElementInsert.AttributeBlockCells = visitee.AttributeBlockCells;
        }
        this.processedGraphicElementBlock_0.Inserts.Add(graphicElementInsert);
      }

      private class Class732 : IPrimitiveVisitor
      {
        private GraphicsConfig graphicsConfig_0;
        private GraphicElement1 graphicElement1_0;
        private GraphicElement1 graphicElement1_1;
        private Matrix4D matrix4D_0;
        private DxfLineType dxfLineType_0;
        private double double_0;
        private bool bool_0;

        public Class732(
          GraphicsConfig graphicsConfig,
          GraphicElement1 graphicElementWithoutLineType,
          GraphicElement1 graphicElementWithLineType,
          Matrix4D toPseudoWcsTransform,
          DxfLineType lineType,
          double lineTypeScale,
          bool plinegen)
        {
          this.graphicsConfig_0 = graphicsConfig;
          this.graphicElement1_0 = graphicElementWithoutLineType;
          this.graphicElement1_1 = graphicElementWithLineType;
          this.matrix4D_0 = toPseudoWcsTransform;
          this.dxfLineType_0 = lineType;
          this.double_0 = lineTypeScale;
          this.bool_0 = plinegen;
        }

        public void Visit(Point visitee)
        {
          this.method_0((IPrimitive) visitee);
        }

        public void Visit(PolygonMesh visitee)
        {
          this.method_0((IPrimitive) visitee);
        }

        public void Visit(Polyline2DE visitee)
        {
          List<WW.Cad.Drawing.Polyline2DE> polyline2DeList = new List<WW.Cad.Drawing.Polyline2DE>();
          DxfUtil.smethod_19<Point2DE, WW.Cad.Drawing.Polyline2DE>(this.graphicsConfig_0, WW.Cad.Drawing.Polyline2DE.Factory, (IList<WW.Cad.Drawing.Polyline2DE>) polyline2DeList, visitee.Wrappee, this.matrix4D_0 * visitee.Transform, this.dxfLineType_0, this.double_0, this.bool_0);
          foreach (WW.Cad.Drawing.Polyline2DE wrappee in polyline2DeList)
            this.graphicElement1_1.Geometry.Add((IPrimitive) new Polyline2DE(wrappee, visitee.Transform));
        }

        public void Visit(Polyline3D visitee)
        {
          this.method_1(visitee.Points as WW.Math.Geometry.Polyline3D ?? new WW.Math.Geometry.Polyline3D(visitee.Closed, visitee.Points));
        }

        public void Visit(Polyline2D2N visitee)
        {
          List<WW.Cad.Drawing.Polyline2D2N> polyline2D2NList = new List<WW.Cad.Drawing.Polyline2D2N>();
          DxfUtil.smethod_19<Point2D2N, WW.Cad.Drawing.Polyline2D2N>(this.graphicsConfig_0, WW.Cad.Drawing.Polyline2D2N.Factory, (IList<WW.Cad.Drawing.Polyline2D2N>) polyline2D2NList, visitee.Wrappee, this.matrix4D_0 * visitee.Transform, this.dxfLineType_0, this.double_0, this.bool_0);
          foreach (WW.Cad.Drawing.Polyline2D2N wrappee in polyline2D2NList)
            this.graphicElement1_1.Geometry.Add((IPrimitive) new Polyline2D2N(wrappee, visitee.Transform));
        }

        public void Visit(Polyline2D2WN visitee)
        {
          List<WW.Cad.Drawing.Polyline2D2WN> polyline2D2WnList = new List<WW.Cad.Drawing.Polyline2D2WN>();
          DxfUtil.smethod_19<Point2D2WN, WW.Cad.Drawing.Polyline2D2WN>(this.graphicsConfig_0, WW.Cad.Drawing.Polyline2D2WN.Factory, (IList<WW.Cad.Drawing.Polyline2D2WN>) polyline2D2WnList, visitee.Wrappee, this.matrix4D_0 * visitee.Transform, this.dxfLineType_0, this.double_0, this.bool_0);
          foreach (WW.Cad.Drawing.Polyline2D2WN wrappee in polyline2D2WnList)
            this.graphicElement1_1.Geometry.Add((IPrimitive) new Polyline2D2WN(wrappee, visitee.Fill, visitee.Transform));
        }

        public void Visit(Quad visitee)
        {
          this.method_0((IPrimitive) visitee);
        }

        public void Visit(QuadStrip1 visitee)
        {
          this.method_0((IPrimitive) visitee);
        }

        public void Visit(QuadStrip2 visitee)
        {
          this.method_0((IPrimitive) visitee);
        }

        public void Visit(QuadWithEdges visitee)
        {
          this.method_0((IPrimitive) visitee);
        }

        public void Visit(Segment visitee)
        {
          this.method_1(new WW.Math.Geometry.Polyline3D(false, new Point3D[2]
          {
            visitee.Start,
            visitee.End
          }));
        }

        public void Visit(TexturedTriangleList visitee)
        {
          this.method_0((IPrimitive) visitee);
        }

        public void Visit(Triangle visitee)
        {
          this.method_0((IPrimitive) visitee);
        }

        public void Visit(TriangleWithEdges visitee)
        {
          this.method_0((IPrimitive) visitee);
        }

        private void method_0(IPrimitive value)
        {
          if (this.graphicElement1_0 == null)
            return;
          this.graphicElement1_0.Geometry.Add(value);
        }

        private void method_1(WW.Math.Geometry.Polyline3D polyline)
        {
          List<WW.Math.Geometry.Polyline3D> result = new List<WW.Math.Geometry.Polyline3D>();
          DxfUtil.smethod_22(this.graphicsConfig_0, (IList<WW.Math.Geometry.Polyline3D>) result, polyline, this.matrix4D_0, this.dxfLineType_0, this.double_0, this.bool_0);
          this.vmethod_0(result);
        }

        protected virtual void vmethod_0(List<WW.Math.Geometry.Polyline3D> result)
        {
          foreach (WW.Math.Geometry.Polyline3D polyline in result)
            this.graphicElement1_1.Geometry.Add(Polyline3D.CreatePrimitive(polyline));
        }
      }
    }

    private class Class733
    {
      private readonly List<Pair<Matrix4D, GraphicElement1>> list_0 = new List<Pair<Matrix4D, GraphicElement1>>();
      private GraphicElement1 graphicElement1_0;

      public GraphicElement1 GraphicElementWithoutLineType
      {
        get
        {
          return this.graphicElement1_0;
        }
        set
        {
          this.graphicElement1_0 = value;
        }
      }

      public List<Pair<Matrix4D, GraphicElement1>> GraphicElementsWithLineType
      {
        get
        {
          return this.list_0;
        }
      }

      public GraphicElement1 method_0(Matrix4D toPwcsTransform)
      {
        GraphicElement1 graphicElement1 = (GraphicElement1) null;
        foreach (Pair<Matrix4D, GraphicElement1> pair in this.list_0)
        {
          if (Matrix4D.AreApproxEqual(pair.First, toPwcsTransform))
          {
            graphicElement1 = pair.Second;
            break;
          }
        }
        return graphicElement1;
      }
    }

    private class Class734
    {
      private List<Pair<Matrix4D, ProcessedGraphicElementBlock>> list_0 = new List<Pair<Matrix4D, ProcessedGraphicElementBlock>>();

      public List<Pair<Matrix4D, ProcessedGraphicElementBlock>> Blocks
      {
        get
        {
          return this.list_0;
        }
        set
        {
          this.list_0 = value;
        }
      }

      public ProcessedGraphicElementBlock method_0(
        Matrix4D toPwcsTransform)
      {
        ProcessedGraphicElementBlock graphicElementBlock = (ProcessedGraphicElementBlock) null;
        foreach (Pair<Matrix4D, ProcessedGraphicElementBlock> pair in this.list_0)
        {
          if (Matrix4D.AreApproxEqual(pair.First, toPwcsTransform))
          {
            graphicElementBlock = pair.Second;
            break;
          }
        }
        return graphicElementBlock;
      }
    }
  }
}
