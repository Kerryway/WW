// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfPolyline3DSpline
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns1;
using ns2;
using ns33;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfPolyline3DSpline : DxfPolyline3DBase
  {
    private DxfVertex3DCollection dxfVertex3DCollection_0 = new DxfVertex3DCollection();
    private DxfVertex3DCollection dxfVertex3DCollection_1 = new DxfVertex3DCollection();
    private SplineType splineType_0;

    public DxfPolyline3DSpline(SplineType splineType)
    {
      this.splineType_0 = splineType;
    }

    public DxfPolyline3DSpline()
    {
      this.splineType_0 = SplineType.CubicBSpline;
    }

    public DxfPolyline3DSpline(SplineType splineType, params DxfVertex3D[] controlPoints)
    {
      this.splineType_0 = splineType;
      this.dxfVertex3DCollection_0.AddRange((IEnumerable<DxfVertex3D>) controlPoints);
    }

    public DxfPolyline3DSpline(params DxfVertex3D[] controlPoints)
      : this(SplineType.CubicBSpline, controlPoints)
    {
    }

    public DxfPolyline3DSpline(SplineType splineType, params WW.Math.Point3D[] controlPoints)
    {
      this.splineType_0 = splineType;
      this.dxfVertex3DCollection_0.AddRange(controlPoints);
    }

    public DxfPolyline3DSpline(params WW.Math.Point3D[] controlPoints)
      : this(SplineType.CubicBSpline, controlPoints)
    {
    }

    public DxfPolyline3DSpline(SplineType splineType, IEnumerable<WW.Math.Point3D> controlPoints)
    {
      this.splineType_0 = splineType;
      this.dxfVertex3DCollection_0.AddRange(controlPoints);
    }

    public DxfPolyline3DSpline(IEnumerable<WW.Math.Point3D> controlPoints)
      : this(SplineType.CubicBSpline, controlPoints)
    {
    }

    public DxfVertex3DCollection ControlPoints
    {
      get
      {
        return this.dxfVertex3DCollection_0;
      }
    }

    public DxfVertex3DCollection ApproximationPoints
    {
      get
      {
        return this.dxfVertex3DCollection_1;
      }
    }

    public SplineType SplineType
    {
      get
      {
        return this.splineType_0;
      }
      set
      {
        this.splineType_0 = value;
      }
    }

    public override void TransformMe(
      TransformConfig config,
      Matrix4D matrix,
      CommandGroup undoGroup)
    {
      CommandGroup undoGroup1 = (CommandGroup) null;
      if (undoGroup != null)
      {
        undoGroup1 = new CommandGroup((object) this);
        undoGroup.UndoStack.Push((ICommand) undoGroup1);
      }
      foreach (DxfEntity dxfEntity in (DxfHandledObjectCollection<DxfVertex3D>) this.dxfVertex3DCollection_0)
        dxfEntity.TransformMe(config, matrix, undoGroup1);
      foreach (DxfEntity dxfEntity in (DxfHandledObjectCollection<DxfVertex3D>) this.dxfVertex3DCollection_1)
        dxfEntity.TransformMe(config, matrix, undoGroup1);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      IList<Polyline4D> polylines4D;
      IList<FlatShape4D> shapes;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out polylines4D, out shapes);
      if (polylines4D.Count > 0)
        graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, polylines4D, false, true);
      if (shapes == null)
        return;
      Class940.smethod_23((IPathDrawer) new ns0.Class0((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      IList<Polyline4D> polylines4D;
      IList<FlatShape4D> shapes;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out polylines4D, out shapes);
      if (polylines4D.Count > 0)
        Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, false, true, polylines4D);
      if (shapes == null)
        return;
      Class940.smethod_23((IPathDrawer) new Class396((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      Interface41 transformer = (Interface41) context.GetTransformer().Clone();
      transformer.SetPreTransform(this.Transform);
      IList<WW.Math.Geometry.Polyline3D> polylines;
      IList<FlatShape4D> shapes;
      this.method_13((DrawContext) context, transformer.LineTypeScaler, out polylines, out shapes);
      IList<Polyline4D> polyline4DList = DxfUtil.smethod_51(polylines, transformer);
      if (polyline4DList.Count > 0)
      {
        graphicsFactory.SetColor(context.GetPlotColor((DxfEntity) this));
        foreach (Polyline4D polyline4D in (IEnumerable<Polyline4D>) polyline4DList)
          graphicsFactory.CreatePolyline((IList<Vector4D>) polyline4D, polyline4D.Closed);
      }
      if (shapes == null)
        return;
      Class940.smethod_24((IPathDrawer) new Class473((DxfEntity) this, context, graphicsFactory), (IEnumerable<FlatShape4D>) shapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this), 0.0);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      DxfLineType lineType = this.GetLineType((DrawContext) context);
      bool plinegen = (this.Flags & Enum21.flag_8) != Enum21.flag_0;
      double lineTypeScale = context.TotalLineTypeScale * this.LineTypeScale;
      if (!graphics.AddExistingGraphicElement2(parentGraphicElementBlock, (DxfEntity) this, plotColor, lineType, lineTypeScale, plinegen))
        return;
      GraphicElement2 graphicElement2 = new GraphicElement2(plotColor, lineType, lineTypeScale, plinegen);
      graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, (GraphicElement1) graphicElement2);
      bool approximationPointsDrawn;
      WW.Math.Geometry.Polyline3D polyline = this.method_14(context.Config, out approximationPointsDrawn);
      graphicElement2.Geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive(polyline));
      if (context.Config.ShowSplineControlPoints)
        graphicElement2.Geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive(this.method_16()));
      if (!context.Config.ShowSplineApproximationPoints || approximationPointsDrawn)
        return;
      graphicElement2.Geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive(this.method_17()));
    }

    public void RecalculateApproximationPoints(int noOfSplineLineParts)
    {
      WW.Math.Geometry.Polyline3D polyline3D = this.method_18(this.method_15(), noOfSplineLineParts);
      this.dxfVertex3DCollection_1.Clear();
      for (int index = 0; index < polyline3D.Count; ++index)
        this.dxfVertex3DCollection_1.Add(new DxfVertex3D(polyline3D[index]));
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfPolyline3DSpline polyline3Dspline = (DxfPolyline3DSpline) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (polyline3Dspline == null)
      {
        polyline3Dspline = new DxfPolyline3DSpline();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) polyline3Dspline);
        polyline3Dspline.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) polyline3Dspline;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfPolyline3DSpline polyline3Dspline = (DxfPolyline3DSpline) from;
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfVertex3D>) polyline3Dspline.dxfVertex3DCollection_0)
        this.dxfVertex3DCollection_0.Add((DxfVertex3D) dxfHandledObject.Clone(cloneContext));
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfVertex3D>) polyline3Dspline.dxfVertex3DCollection_1)
        this.dxfVertex3DCollection_1.Add((DxfVertex3D) dxfHandledObject.Clone(cloneContext));
      this.splineType_0 = polyline3Dspline.splineType_0;
    }

    protected internal override void ExecuteDeepHelper(
      WW.Cad.Model.Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfVertex3D>) this.dxfVertex3DCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfVertex3D>) this.dxfVertex3DCollection_1)
        dxfHandledObject.vmethod_0(action, callerStack);
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IList<Polygon2D> GetClipBoundary(GraphicsConfig graphicsConfig)
    {
      bool approximationPointsDrawn;
      WW.Math.Geometry.Polyline3D polyline3D = this.method_14(graphicsConfig, out approximationPointsDrawn);
      Polygon2D polygon2D = new Polygon2D(polyline3D.Count);
      foreach (WW.Math.Point3D point3D in (List<WW.Math.Point3D>) polyline3D)
        polygon2D.Add((WW.Math.Point2D) point3D);
      return (IList<Polygon2D>) new Polygon2D[1]{ polygon2D };
    }

    private void GetPolylines4D(
      DrawContext context,
      IClippingTransformer transformer,
      out IList<Polyline4D> polylines4D,
      out IList<FlatShape4D> shapes)
    {
      IList<WW.Math.Geometry.Polyline3D> polylines;
      this.method_13(context, transformer.LineTypeScaler, out polylines, out shapes);
      IClippingTransformer transformer1 = (IClippingTransformer) transformer.Clone();
      transformer1.SetPreTransform(this.Transform);
      polylines4D = DxfUtil.smethod_36(polylines, false, transformer1);
    }

    private void method_13(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<WW.Math.Geometry.Polyline3D> polylines,
      out IList<FlatShape4D> shapes)
    {
      DxfHeader header = context.Model.Header;
      GraphicsConfig config = context.Config;
      polylines = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>();
      shapes = (IList<FlatShape4D>) null;
      bool approximationPointsDrawn;
      WW.Math.Geometry.Polyline3D polyline = this.method_14(config, out approximationPointsDrawn);
      if (polyline != null)
      {
        if (config.ApplyLineType)
        {
          shapes = (IList<FlatShape4D>) new List<FlatShape4D>();
          DxfUtil.smethod_4(context.Config, polylines, shapes, polyline, this.GetLineType(context), Vector3D.ZAxis, context.TotalLineTypeScale * this.LineTypeScale, lineTypeScaler);
        }
        else
          polylines.Add(polyline);
      }
      if (config.ShowSplineControlPoints)
        polylines.Add(this.method_16());
      if (!config.ShowSplineApproximationPoints || approximationPointsDrawn)
        return;
      polylines.Add(this.method_17());
    }

    private WW.Math.Geometry.Polyline3D method_14(
      GraphicsConfig config,
      out bool approximationPointsDrawn)
    {
      approximationPointsDrawn = false;
      WW.Math.Geometry.Polyline3D polyline3D = (WW.Math.Geometry.Polyline3D) null;
      if (config.ShowSplineInterpolatedPoints)
      {
        switch (this.splineType_0)
        {
          case SplineType.None:
            polyline3D = this.method_17();
            approximationPointsDrawn = true;
            break;
          case SplineType.QuadraticBSpline:
            polyline3D = this.method_18(2, (int) config.NoOfSplineLineSegments);
            break;
          case SplineType.CubicBSpline:
            polyline3D = this.method_18(3, (int) config.NoOfSplineLineSegments);
            break;
        }
      }
      return polyline3D;
    }

    private int method_15()
    {
      switch (this.splineType_0)
      {
        case SplineType.QuadraticBSpline:
          return 2;
        case SplineType.CubicBSpline:
          return 3;
        default:
          return 0;
      }
    }

    private WW.Math.Geometry.Polyline3D method_16()
    {
      WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D(this.Closed);
      foreach (DxfVertex3D dxfVertex3D in (DxfHandledObjectCollection<DxfVertex3D>) this.dxfVertex3DCollection_0)
        polyline3D.Add(new WW.Math.Point3D(dxfVertex3D.Position));
      return polyline3D;
    }

    private WW.Math.Geometry.Polyline3D method_17()
    {
      WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D(this.Closed);
      foreach (DxfVertex3D dxfVertex3D in (DxfHandledObjectCollection<DxfVertex3D>) this.dxfVertex3DCollection_1)
        polyline3D.Add(dxfVertex3D.Position);
      return polyline3D;
    }

    private WW.Math.Geometry.Polyline3D method_18(int power, int noOfSplineLineParts)
    {
      WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D(this.Closed);
      int count = this.dxfVertex3DCollection_0.Count;
      if (count < power + 1)
        return this.method_17();
      BSplineD bsplineD = new BSplineD(power, count, this.Closed);
      double[] result = new double[power + 1];
      double maxU = bsplineD.MaxU;
      int num1 = noOfSplineLineParts + 1;
      double num2 = maxU / (double) (num1 - 1);
      int num3 = 0;
      double u = 0.0;
      while (num3 < num1)
      {
        int knotSpanIndex = bsplineD.GetKnotSpanIndex(u);
        bsplineD.EvaluateBasisFunctions(knotSpanIndex, u, result);
        WW.Math.Point3D zero = WW.Math.Point3D.Zero;
        for (int index = 0; index < power + 1; ++index)
        {
          DxfVertex3D dxfVertex3D = this.dxfVertex3DCollection_0[(knotSpanIndex - power + index) % count];
          zero += result[index] * (Vector3D) dxfVertex3D.Position;
        }
        polyline3D.Add(zero);
        ++num3;
        u += num2;
      }
      return polyline3D;
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      foreach (DxfVertex3D dxfVertex3D in (DxfHandledObjectCollection<DxfVertex3D>) this.dxfVertex3DCollection_0)
      {
        dxfVertex3D.vmethod_2((IDxfHandledObject) this);
        dxfVertex3D.vmethod_1(context);
      }
      if (this.dxfVertex3DCollection_1.Count == 0)
        this.RecalculateApproximationPoints((int) System.Math.Abs(this.Model.Header.NumberOfSplineSegments));
      foreach (DxfVertex3D dxfVertex3D in (DxfHandledObjectCollection<DxfVertex3D>) this.dxfVertex3DCollection_1)
      {
        dxfVertex3D.vmethod_2((IDxfHandledObject) this);
        dxfVertex3D.vmethod_1(context);
      }
    }
  }
}
