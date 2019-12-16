// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfPolyline2DSpline
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using ns2;
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
  public class DxfPolyline2DSpline : DxfPolyline2DBase
  {
    private DxfVertex2DCollection dxfVertex2DCollection_0 = new DxfVertex2DCollection();
    private DxfVertex2DCollection dxfVertex2DCollection_1 = new DxfVertex2DCollection();
    private SplineType splineType_0;

    public DxfPolyline2DSpline(SplineType splineType)
    {
      this.splineType_0 = splineType;
    }

    public DxfPolyline2DSpline()
    {
      this.splineType_0 = SplineType.CubicBSpline;
    }

    public DxfPolyline2DSpline(SplineType splineType, params DxfVertex2D[] controlPoints)
    {
      this.splineType_0 = splineType;
      if (controlPoints == null)
        return;
      this.dxfVertex2DCollection_0.AddRange((IEnumerable<DxfVertex2D>) controlPoints);
    }

    public DxfPolyline2DSpline(params DxfVertex2D[] controlPoints)
      : this(SplineType.CubicBSpline, controlPoints)
    {
    }

    public DxfPolyline2DSpline(SplineType splineType, params WW.Math.Point2D[] controlPoints)
    {
      this.splineType_0 = splineType;
      if (controlPoints == null)
        return;
      this.dxfVertex2DCollection_0.AddRange(controlPoints);
    }

    public DxfPolyline2DSpline(params WW.Math.Point2D[] controlPoints)
      : this(SplineType.CubicBSpline, controlPoints)
    {
    }

    public DxfPolyline2DSpline(SplineType splineType, IEnumerable<WW.Math.Point2D> controlPoints)
    {
      this.splineType_0 = splineType;
      if (controlPoints == null)
        return;
      this.dxfVertex2DCollection_0.AddRange(controlPoints);
    }

    public DxfPolyline2DSpline(IEnumerable<WW.Math.Point2D> controlPoints)
      : this(SplineType.CubicBSpline, controlPoints)
    {
    }

    public DxfVertex2DCollection ControlPoints
    {
      get
      {
        return this.dxfVertex2DCollection_0;
      }
    }

    public DxfVertex2DCollection ApproximationPoints
    {
      get
      {
        return this.dxfVertex2DCollection_1;
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
      Matrix4D transformationWithOcs;
      this.method_13(matrix, undoGroup1, out transformationWithOcs);
      foreach (DxfVertex2D dxfVertex2D in (DxfHandledObjectCollection<DxfVertex2D>) this.dxfVertex2DCollection_0)
        dxfVertex2D.TransformMeInOcs(transformationWithOcs, undoGroup1);
      foreach (DxfVertex2D dxfVertex2D in (DxfHandledObjectCollection<DxfVertex2D>) this.dxfVertex2DCollection_1)
        dxfVertex2D.TransformMeInOcs(transformationWithOcs, undoGroup1);
    }

    public void RecalculateApproximationPoints(int noOfSplineLineParts)
    {
      WW.Cad.Drawing.Polyline2D2WN polyline2D2Wn = this.method_31(this.method_15(), noOfSplineLineParts);
      this.dxfVertex2DCollection_1.Clear();
      for (int index = 0; index < polyline2D2Wn.Count; ++index)
      {
        Point2D2WN point2D2Wn = polyline2D2Wn[index];
        this.dxfVertex2DCollection_1.Add(new DxfVertex2D(point2D2Wn.Position)
        {
          Bulge = 0.0,
          StartWidth = point2D2Wn.StartWidth,
          EndWidth = point2D2Wn.EndWidth
        });
      }
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
      if (this.Thickness != 0.0)
        graphicElement2.Geometry.Extrusion = this.Thickness * Vector3D.ZAxis;
      bool flag = false;
      if (context.Config.ShowSplineInterpolatedPoints)
      {
        switch (this.splineType_0)
        {
          case SplineType.None:
            if (this.dxfVertex2DCollection_1.Count > 0)
            {
              bool allWidthsAreZero = this.method_32(this.dxfVertex2DCollection_1);
              this.method_14((DrawContext) context, graphicElement2.Geometry, (DxfPolyline2DSpline.Interface43) new DxfPolyline2DSpline.Class947(this), allWidthsAreZero);
              flag = allWidthsAreZero && this.Thickness == 0.0;
              break;
            }
            break;
          case SplineType.QuadraticBSpline:
            if (this.dxfVertex2DCollection_0.Count > 0)
            {
              bool allWidthsAreZero = this.method_32(this.dxfVertex2DCollection_0);
              this.method_14((DrawContext) context, graphicElement2.Geometry, (DxfPolyline2DSpline.Interface43) new DxfPolyline2DSpline.Class948(this, 2, context.Config), allWidthsAreZero);
              break;
            }
            break;
          case SplineType.CubicBSpline:
            if (this.dxfVertex2DCollection_0.Count > 0)
            {
              bool allWidthsAreZero = this.method_32(this.dxfVertex2DCollection_0);
              this.method_14((DrawContext) context, graphicElement2.Geometry, (DxfPolyline2DSpline.Interface43) new DxfPolyline2DSpline.Class948(this, 3, context.Config), allWidthsAreZero);
              break;
            }
            break;
        }
      }
      DxfHeader header = context.Model.Header;
      GraphicsConfig config = context.Config;
      if (config.ShowSplineControlPoints && this.dxfVertex2DCollection_0.Count > 0)
        graphicElement2.Geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Polyline2DE(this.method_17(), this.Transform));
      if (!config.ShowSplineApproximationPoints || this.dxfVertex2DCollection_1.Count <= 0 || flag)
        return;
      graphicElement2.Geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Polyline2DE(this.method_19(), this.Transform));
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfPolyline2DSpline polyline2Dspline = (DxfPolyline2DSpline) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (polyline2Dspline == null)
      {
        polyline2Dspline = new DxfPolyline2DSpline();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) polyline2Dspline);
        polyline2Dspline.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) polyline2Dspline;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfPolyline2DSpline polyline2Dspline = (DxfPolyline2DSpline) from;
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfVertex2D>) polyline2Dspline.dxfVertex2DCollection_0)
        this.dxfVertex2DCollection_0.Add((DxfVertex2D) dxfHandledObject.Clone(cloneContext));
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfVertex2D>) polyline2Dspline.dxfVertex2DCollection_1)
        this.dxfVertex2DCollection_1.Add((DxfVertex2D) dxfHandledObject.Clone(cloneContext));
      this.splineType_0 = polyline2Dspline.splineType_0;
    }

    protected internal override void ExecuteDeepHelper(
      WW.Cad.Model.Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfVertex2D>) this.dxfVertex2DCollection_0)
        dxfHandledObject.vmethod_0(action, callerStack);
      foreach (DxfHandledObject dxfHandledObject in (DxfHandledObjectCollection<DxfVertex2D>) this.dxfVertex2DCollection_1)
        dxfHandledObject.vmethod_0(action, callerStack);
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IList<Polygon2D> GetClipBoundary(GraphicsConfig graphicsConfig)
    {
      WW.Cad.Drawing.Polyline2DE polyline2De = (WW.Cad.Drawing.Polyline2DE) null;
      switch (this.splineType_0)
      {
        case SplineType.None:
          if (!graphicsConfig.ShowSplineApproximationPoints)
          {
            polyline2De = this.method_19();
            break;
          }
          break;
        case SplineType.QuadraticBSpline:
          polyline2De = this.method_28(2, (int) graphicsConfig.NoOfSplineLineSegments);
          break;
        case SplineType.CubicBSpline:
          polyline2De = this.method_28(3, (int) graphicsConfig.NoOfSplineLineSegments);
          break;
      }
      if (polyline2De == null)
        return (IList<Polygon2D>) new Polygon2D[0];
      Polygon2D polygon2D = new Polygon2D(polyline2De.Count);
      foreach (Point2DE point2De in (List<Point2DE>) polyline2De)
        polygon2D.Add(point2De.Position);
      return (IList<Polygon2D>) new Polygon2D[1]{ polygon2D };
    }

    private void method_14(
      DrawContext context,
      WW.Cad.Drawing.Surface.Geometry geometry,
      DxfPolyline2DSpline.Interface43 polylineProvider,
      bool allWidthsAreZero)
    {
      if (allWidthsAreZero)
      {
        if (this.Thickness == 0.0)
        {
          WW.Cad.Drawing.Polyline2DE wrappee = polylineProvider.imethod_0();
          geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Polyline2DE(wrappee, this.Transform));
        }
        else
        {
          WW.Cad.Drawing.Polyline2D2N wrappee1 = polylineProvider.imethod_1();
          if (wrappee1.Count > 0)
          {
            geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Polyline2D2N(wrappee1, this.Transform));
          }
          else
          {
            WW.Cad.Drawing.Polyline2DE wrappee2 = polylineProvider.imethod_0();
            geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Polyline2DE(wrappee2, this.Transform));
          }
        }
      }
      else if (this.Thickness == 0.0)
      {
        WW.Cad.Drawing.Polyline2D2WN wrappee1 = polylineProvider.imethod_2();
        if (wrappee1.Count > 0)
        {
          geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Polyline2D2WN(wrappee1, context.Model.Header.FillMode, this.Transform));
        }
        else
        {
          WW.Cad.Drawing.Polyline2DE wrappee2 = polylineProvider.imethod_0();
          geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Polyline2DE(wrappee2, this.Transform));
        }
      }
      else
      {
        WW.Cad.Drawing.Polyline2D2WN wrappee1 = polylineProvider.imethod_2();
        if (wrappee1.Count > 0)
        {
          geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Polyline2D2WN(wrappee1, context.Model.Header.FillMode, this.Transform));
        }
        else
        {
          WW.Cad.Drawing.Polyline2DE wrappee2 = polylineProvider.imethod_0();
          geometry.Add((IPrimitive) new WW.Cad.Drawing.Surface.Polyline2DE(wrappee2, this.Transform));
        }
      }
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

    private Polyline2D method_16()
    {
      return this.method_24(this.dxfVertex2DCollection_0);
    }

    private WW.Cad.Drawing.Polyline2DE method_17()
    {
      return this.method_25(this.dxfVertex2DCollection_0, false);
    }

    private Polyline2D method_18()
    {
      return this.method_24(this.dxfVertex2DCollection_1);
    }

    private WW.Cad.Drawing.Polyline2DE method_19()
    {
      return this.method_25(this.dxfVertex2DCollection_1, true);
    }

    private WW.Cad.Drawing.Polyline2D2N method_20()
    {
      return this.method_26(this.dxfVertex2DCollection_0, true);
    }

    private WW.Cad.Drawing.Polyline2D2N method_21()
    {
      return this.method_26(this.dxfVertex2DCollection_1, true);
    }

    private WW.Cad.Drawing.Polyline2D2WN method_22()
    {
      return this.method_27(this.dxfVertex2DCollection_0, true);
    }

    private WW.Cad.Drawing.Polyline2D2WN method_23()
    {
      return this.method_27(this.dxfVertex2DCollection_1, true);
    }

    private Polyline2D method_24(DxfVertex2DCollection points)
    {
      bool closed = this.Closed;
      int count = points.Count;
      Polyline2D polyline2D = new Polyline2D(count, closed);
      if (count > 0)
      {
        DxfVertex2D dxfVertex2D = points[0];
        polyline2D.Add(dxfVertex2D.Position);
        for (int index = 1; index < count; ++index)
        {
          DxfVertex2D point = points[index];
          if (!(dxfVertex2D.Position == point.Position))
          {
            polyline2D.Add(point.Position);
            dxfVertex2D = point;
          }
        }
        if (closed && count > 1 && polyline2D[0] == polyline2D[polyline2D.Count - 1])
          polyline2D.RemoveAt(polyline2D.Count - 1);
      }
      return polyline2D;
    }

    private WW.Cad.Drawing.Polyline2DE method_25(
      DxfVertex2DCollection points,
      bool isInterpolated)
    {
      bool closed = this.Closed;
      int count = points.Count;
      WW.Cad.Drawing.Polyline2DE polyline2De = new WW.Cad.Drawing.Polyline2DE(count, closed);
      if (count > 0)
      {
        DxfVertex2D dxfVertex2D = points[0];
        polyline2De.Add(new Point2DE(dxfVertex2D.Position)
        {
          IsInterpolatedPoint = isInterpolated
        });
        for (int index = 1; index < count; ++index)
        {
          DxfVertex2D point = points[index];
          if (!(dxfVertex2D.Position == point.Position))
          {
            polyline2De.Add(new Point2DE(point.Position)
            {
              IsInterpolatedPoint = isInterpolated
            });
            dxfVertex2D = point;
          }
        }
        if (closed && count > 1 && polyline2De[0].Position == polyline2De[polyline2De.Count - 1].Position)
          polyline2De.RemoveAt(polyline2De.Count - 1);
      }
      return polyline2De;
    }

    private WW.Cad.Drawing.Polyline2D2N method_26(
      DxfVertex2DCollection points,
      bool isInterpolatedPoint)
    {
      bool closed = this.Closed;
      int count = points.Count;
      WW.Cad.Drawing.Polyline2D2N polyline2D2N = new WW.Cad.Drawing.Polyline2D2N(count, closed);
      if (count > 0)
      {
        DxfVertex2D dxfVertex2D = points[0];
        for (int index = 1; index < count; ++index)
        {
          DxfVertex2D point = points[index];
          if (!(dxfVertex2D.Position == point.Position))
          {
            Vector2D unit = (point.Position - dxfVertex2D.Position).GetUnit();
            Vector2D vector2D = new Vector2D(-unit.Y, unit.X);
            polyline2D2N.Add(new Point2D2N(dxfVertex2D.Position, vector2D, vector2D)
            {
              IsInterpolatedPoint = isInterpolatedPoint
            });
            dxfVertex2D = point;
          }
        }
        if (closed)
        {
          DxfVertex2D point = points[0];
          if (dxfVertex2D.Position != point.Position)
          {
            Vector2D unit = (point.Position - dxfVertex2D.Position).GetUnit();
            Vector2D vector2D = new Vector2D(-unit.Y, unit.X);
            polyline2D2N.Add(new Point2D2N(dxfVertex2D.Position, vector2D, vector2D)
            {
              IsInterpolatedPoint = isInterpolatedPoint
            });
          }
        }
        else
          polyline2D2N.Add(new Point2D2N(dxfVertex2D.Position)
          {
            IsInterpolatedPoint = isInterpolatedPoint
          });
      }
      return polyline2D2N;
    }

    private WW.Cad.Drawing.Polyline2D2WN method_27(
      DxfVertex2DCollection points,
      bool isInterpolatedPoint)
    {
      bool closed = this.Closed;
      int count = points.Count;
      WW.Cad.Drawing.Polyline2D2WN polyline2D2Wn = new WW.Cad.Drawing.Polyline2D2WN(count, closed);
      if (count > 0)
      {
        DxfVertex2D dxfVertex2D = points[0];
        for (int index = 1; index < count; ++index)
        {
          DxfVertex2D point = points[index];
          if (!(dxfVertex2D.Position == point.Position))
          {
            Vector2D unit = (point.Position - dxfVertex2D.Position).GetUnit();
            Vector2D vector2D = new Vector2D(-unit.Y, unit.X);
            polyline2D2Wn.Add(new Point2D2WN(dxfVertex2D.Position, dxfVertex2D.StartWidth, dxfVertex2D.EndWidth, vector2D, vector2D)
            {
              IsInterpolatedPoint = isInterpolatedPoint
            });
            dxfVertex2D = point;
          }
        }
        if (closed)
        {
          DxfVertex2D point = points[0];
          if (dxfVertex2D.Position != point.Position)
          {
            Vector2D unit = (point.Position - dxfVertex2D.Position).GetUnit();
            Vector2D vector2D = new Vector2D(-unit.Y, unit.X);
            polyline2D2Wn.Add(new Point2D2WN(dxfVertex2D.Position, dxfVertex2D.StartWidth, dxfVertex2D.EndWidth, vector2D, vector2D)
            {
              IsInterpolatedPoint = isInterpolatedPoint
            });
          }
        }
        else
          polyline2D2Wn.Add(new Point2D2WN(dxfVertex2D.Position)
          {
            IsInterpolatedPoint = isInterpolatedPoint
          });
      }
      return polyline2D2Wn;
    }

    internal override void GetPolylines(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<IList<Polyline2D>> polylinesList1,
      out IList<IList<Polyline2D>> polylinesList2,
      out IList<FlatShape4D> shapes,
      out bool fill)
    {
      DxfHeader header = context.Model.Header;
      GraphicsConfig config = context.Config;
      polylinesList1 = (IList<IList<Polyline2D>>) new List<IList<Polyline2D>>();
      polylinesList2 = (IList<IList<Polyline2D>>) new List<IList<Polyline2D>>();
      shapes = (IList<FlatShape4D>) null;
      if (config.ShowSplineControlPoints)
      {
        polylinesList1.Add((IList<Polyline2D>) new Polyline2D[1]
        {
          this.method_16()
        });
        polylinesList2.Add((IList<Polyline2D>) null);
      }
      if (config.ShowSplineApproximationPoints)
      {
        polylinesList1.Add((IList<Polyline2D>) new Polyline2D[1]
        {
          this.method_18()
        });
        polylinesList2.Add((IList<Polyline2D>) null);
      }
      if (this.method_32(this.dxfVertex2DCollection_0))
      {
        Polyline2D polyline = (Polyline2D) null;
        if (config.ShowSplineInterpolatedPoints)
        {
          switch (this.splineType_0)
          {
            case SplineType.None:
              if (!config.ShowSplineApproximationPoints)
              {
                polyline = this.method_18();
                break;
              }
              break;
            case SplineType.QuadraticBSpline:
              polyline = this.method_30(2, context.Config);
              break;
            case SplineType.CubicBSpline:
              polyline = this.method_30(3, context.Config);
              break;
          }
        }
        fill = false;
        if (polyline != null)
        {
          IList<Polyline2D> resultLines = (IList<Polyline2D>) new List<Polyline2D>();
          shapes = (IList<FlatShape4D>) new List<FlatShape4D>();
          DxfUtil.smethod_0(context.Config, resultLines, shapes, polyline, context.Config.ApplyLineType ? this.GetLineType(context) : (DxfLineType) null, context.TotalLineTypeScale * this.LineTypeScale, lineTypeScaler);
          polylinesList1.Add(resultLines);
          polylinesList2.Add((IList<Polyline2D>) null);
          if (shapes != null && shapes.Count == 0)
            shapes = (IList<FlatShape4D>) null;
        }
      }
      else
      {
        WW.Cad.Drawing.Polyline2D2WN polyline = (WW.Cad.Drawing.Polyline2D2WN) null;
        if (config.ShowSplineInterpolatedPoints)
        {
          switch (this.splineType_0)
          {
            case SplineType.None:
              if (!config.ShowSplineApproximationPoints)
              {
                polyline = this.method_23();
                break;
              }
              break;
            case SplineType.QuadraticBSpline:
              polyline = this.method_31(2, (int) context.Config.NoOfSplineLineSegments);
              break;
            case SplineType.CubicBSpline:
              polyline = this.method_31(3, (int) context.Config.NoOfSplineLineSegments);
              break;
          }
        }
        fill = false;
        if (polyline != null)
        {
          IList<Polyline2D> resultPolylines1;
          IList<Polyline2D> resultPolylines2;
          DxfUtil.smethod_25(context.Config, polyline, context.Config.ApplyLineType ? this.GetLineType(context) : (DxfLineType) null, context.TotalLineTypeScale * this.LineTypeScale, lineTypeScaler, false, out resultPolylines1, out resultPolylines2, out shapes, out fill);
          polylinesList1.Add(resultPolylines1);
          polylinesList2.Add(resultPolylines2);
        }
      }
      if (shapes != null && shapes.Count == 0)
        shapes = (IList<FlatShape4D>) null;
      fill &= context.Model.Header.FillMode;
    }

    internal override void GetPolylines(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<IList<WW.Cad.Drawing.Polyline2D2N>> polylinesList1,
      out IList<IList<WW.Cad.Drawing.Polyline2D2N>> polylinesList2,
      out IList<FlatShape4D> shapes,
      out bool fill)
    {
      DxfHeader header = context.Model.Header;
      GraphicsConfig config = context.Config;
      polylinesList1 = (IList<IList<WW.Cad.Drawing.Polyline2D2N>>) new List<IList<WW.Cad.Drawing.Polyline2D2N>>();
      polylinesList2 = (IList<IList<WW.Cad.Drawing.Polyline2D2N>>) new List<IList<WW.Cad.Drawing.Polyline2D2N>>();
      shapes = (IList<FlatShape4D>) null;
      if (config.ShowSplineControlPoints)
      {
        polylinesList1.Add((IList<WW.Cad.Drawing.Polyline2D2N>) new WW.Cad.Drawing.Polyline2D2N[1]
        {
          this.method_20()
        });
        polylinesList2.Add((IList<WW.Cad.Drawing.Polyline2D2N>) null);
      }
      if (config.ShowSplineApproximationPoints)
      {
        polylinesList1.Add((IList<WW.Cad.Drawing.Polyline2D2N>) new WW.Cad.Drawing.Polyline2D2N[1]
        {
          this.method_21()
        });
        polylinesList2.Add((IList<WW.Cad.Drawing.Polyline2D2N>) null);
      }
      WW.Cad.Drawing.Polyline2D2WN polyline = (WW.Cad.Drawing.Polyline2D2WN) null;
      if (config.ShowSplineInterpolatedPoints)
      {
        switch (this.splineType_0)
        {
          case SplineType.None:
            if (!config.ShowSplineApproximationPoints)
            {
              polyline = this.method_23();
              break;
            }
            break;
          case SplineType.QuadraticBSpline:
            polyline = this.method_31(2, (int) context.Config.NoOfSplineLineSegments);
            break;
          case SplineType.CubicBSpline:
            polyline = this.method_31(3, (int) context.Config.NoOfSplineLineSegments);
            break;
        }
      }
      fill = false;
      IList<WW.Cad.Drawing.Polyline2D2N> resultPolylines1;
      IList<WW.Cad.Drawing.Polyline2D2N> resultPolylines2;
      if (polyline != null && DxfUtil.smethod_27(context.Config, polyline, context.Config.ApplyLineType ? this.GetLineType(context) : (DxfLineType) null, context.TotalLineTypeScale * this.LineTypeScale, lineTypeScaler, false, out resultPolylines1, out resultPolylines2, out shapes, out fill))
      {
        polylinesList1.Add(resultPolylines1);
        polylinesList2.Add(resultPolylines2);
        if (shapes != null && shapes.Count == 0)
          shapes = (IList<FlatShape4D>) null;
      }
      fill &= context.Model.Header.FillMode;
    }

    private WW.Cad.Drawing.Polyline2DE method_28(int power, int noOfSplineLineParts)
    {
      WW.Cad.Drawing.Polyline2DE polyline2De = new WW.Cad.Drawing.Polyline2DE();
      int count = this.dxfVertex2DCollection_0.Count;
      if (count <= power)
        return this.method_19();
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
        WW.Math.Point2D zero = WW.Math.Point2D.Zero;
        for (int index = 0; index <= power; ++index)
        {
          DxfVertex2D dxfVertex2D = this.dxfVertex2DCollection_0[(knotSpanIndex - power + index) % count];
          zero += result[index] * new Vector2D(dxfVertex2D.Position);
        }
        Point2DE point2De = new Point2DE(zero) { IsInterpolatedPoint = true };
        polyline2De.Add(point2De);
        ++num3;
        u += num2;
      }
      return polyline2De;
    }

    private WW.Cad.Drawing.Polyline2D2N method_29(int power, int noOfSplineLineParts)
    {
      WW.Cad.Drawing.Polyline2D2N polyline2D2N = new WW.Cad.Drawing.Polyline2D2N();
      int count = this.dxfVertex2DCollection_0.Count;
      if (count <= power)
        return this.method_21();
      BSplineD bsplineD = new BSplineD(power, count, this.Closed);
      double[] result = new double[power + 1];
      double maxU = bsplineD.MaxU;
      int num1 = noOfSplineLineParts + 1;
      double num2 = maxU / (double) (num1 - 1);
      double[,] derivatives = new double[2, power + 1];
      Point2D2N point2D2N1 = (Point2D2N) null;
      int num3 = 0;
      double u = 0.0;
      while (num3 < num1)
      {
        int knotSpanIndex = bsplineD.GetKnotSpanIndex(u);
        bsplineD.EvaluateBasisFunctions(knotSpanIndex, u, result);
        WW.Math.Point2D zero1 = WW.Math.Point2D.Zero;
        for (int index = 0; index <= power; ++index)
        {
          DxfVertex2D dxfVertex2D = this.dxfVertex2DCollection_0[(knotSpanIndex - power + index) % count];
          zero1 += result[index] * new Vector2D(dxfVertex2D.Position);
        }
        bsplineD.GetDerivativesBasisFunctions(knotSpanIndex, u, 1, derivatives);
        Vector2D zero2 = Vector2D.Zero;
        for (int index = 0; index <= power; ++index)
          zero2 += (Vector2D) this.dxfVertex2DCollection_0[(knotSpanIndex - power + index) % count].Position * derivatives[1, index];
        Vector2D unit = new Vector2D(-zero2.Y, zero2.X).GetUnit();
        Point2D2N point2D2N2 = new Point2D2N(zero1) { IsInterpolatedPoint = true };
        point2D2N2.StartNormal = unit;
        if (point2D2N1 != null)
          point2D2N1.EndNormal = unit;
        polyline2D2N.Add(point2D2N2);
        point2D2N1 = point2D2N2;
        ++num3;
        u += num2;
      }
      if (this.Closed)
        polyline2D2N[num1 - 1].EndNormal = polyline2D2N[0].StartNormal;
      return polyline2D2N;
    }

    private Polyline2D method_30(int degree, GraphicsConfig config)
    {
      int count1 = this.dxfVertex2DCollection_0.Count;
      if (count1 <= degree)
        return this.method_18();
      BSplineCurve2D bsplineCurve2D = new BSplineCurve2D(degree);
      bsplineCurve2D.AddKnots(BSplineD.CreateDefaultKnotValues(degree, count1, this.Closed));
      foreach (DxfVertex2D dxfVertex2D in (DxfHandledObjectCollection<DxfVertex2D>) this.dxfVertex2DCollection_0)
        bsplineCurve2D.ControlPoints.AddLast(dxfVertex2D.Position);
      if (this.Closed)
      {
        for (int index = 0; index < degree; ++index)
          bsplineCurve2D.ControlPoints.AddLast(this.dxfVertex2DCollection_0[index].Position);
        double u = 0.0;
        LinkedListNode<double> previousKnot1 = bsplineCurve2D.Knots.First;
        LinkedListNode<WW.Math.Point2D> previousPoint1 = bsplineCurve2D.ControlPoints.First;
        for (int index = 0; index < degree; ++index)
          previousKnot1 = previousKnot1.Next;
        for (int index = 0; index < degree; ++index)
        {
          bsplineCurve2D.InsertKnot(previousKnot1, previousPoint1, u);
          previousKnot1 = previousKnot1.Next;
          previousPoint1 = previousPoint1.Next;
        }
        double count2 = (double) this.dxfVertex2DCollection_0.Count;
        LinkedListNode<double> previousKnot2 = bsplineCurve2D.Knots.Last.Previous;
        LinkedListNode<WW.Math.Point2D> previousPoint2 = bsplineCurve2D.ControlPoints.Last;
        for (int index = 0; index < degree; ++index)
        {
          previousKnot2 = previousKnot2.Previous;
          previousPoint2 = previousPoint2.Previous;
        }
        for (int index = 0; index < degree; ++index)
        {
          bsplineCurve2D.InsertKnot(previousKnot2, previousPoint2, count2);
          previousKnot2 = previousKnot2.Next;
          previousPoint2 = previousPoint2.Next;
        }
        for (int index = 0; index < degree; ++index)
        {
          bsplineCurve2D.ControlPoints.RemoveFirst();
          bsplineCurve2D.Knots.RemoveFirst();
          bsplineCurve2D.ControlPoints.RemoveLast();
          bsplineCurve2D.Knots.RemoveLast();
        }
      }
      double epsilon = config.ShapeFlattenEpsilon;
      if (epsilon < 0.0)
      {
        Bounds2D bounds2D = new Bounds2D();
        foreach (DxfVertex2D dxfVertex2D in (DxfHandledObjectCollection<DxfVertex2D>) this.dxfVertex2DCollection_0)
          bounds2D.Update(dxfVertex2D.Position);
        epsilon = !bounds2D.Initialized ? 0.01 : -epsilon * bounds2D.Delta.GetLength();
      }
      bsplineCurve2D.RefineKnots(epsilon, 20);
      Polyline2D polyline2D = new Polyline2D(this.Closed);
      foreach (WW.Math.Point2D controlPoint in bsplineCurve2D.ControlPoints)
        polyline2D.Add(controlPoint);
      return polyline2D;
    }

    private WW.Cad.Drawing.Polyline2D2WN method_31(int power, int noOfSplineLineParts)
    {
      WW.Cad.Drawing.Polyline2D2WN polyline2D2Wn = new WW.Cad.Drawing.Polyline2D2WN();
      int count = this.dxfVertex2DCollection_0.Count;
      if (count <= power)
        return this.method_23();
      BSplineD bsplineD = new BSplineD(power, count, this.Closed);
      double[] result = new double[power + 1];
      double maxU = bsplineD.MaxU;
      int num1 = noOfSplineLineParts + 1;
      double num2 = maxU / (double) (num1 - 1);
      double num3 = 0.0;
      double num4 = 0.0;
      int num5 = -1;
      double[,] derivatives = new double[2, power + 1];
      Point2D2WN point2D2Wn1 = (Point2D2WN) null;
      int num6 = 0;
      double u = 0.0;
      while (num6 < num1)
      {
        double d = (double) (count - 1) * u / maxU;
        int num7 = (int) System.Math.Floor(d);
        if (num5 != num7)
        {
          DxfVertex2D dxfVertex2D = this.dxfVertex2DCollection_0[num7 % count];
          num3 = dxfVertex2D.StartWidth == 0.0 ? this.DefaultStartWidth : dxfVertex2D.StartWidth;
          num4 = (dxfVertex2D.EndWidth == 0.0 ? this.DefaultEndWidth : dxfVertex2D.EndWidth) - num3;
        }
        double num8 = d - (double) num7;
        num5 = num7;
        int knotSpanIndex = bsplineD.GetKnotSpanIndex(u);
        bsplineD.EvaluateBasisFunctions(knotSpanIndex, u, result);
        WW.Math.Point2D zero1 = WW.Math.Point2D.Zero;
        for (int index = 0; index <= power; ++index)
        {
          DxfVertex2D dxfVertex2D = this.dxfVertex2DCollection_0[(knotSpanIndex - power + index) % count];
          zero1 += result[index] * new Vector2D(dxfVertex2D.Position);
        }
        bsplineD.GetDerivativesBasisFunctions(knotSpanIndex, u, 1, derivatives);
        Vector2D zero2 = Vector2D.Zero;
        for (int index = 0; index <= power; ++index)
          zero2 += (Vector2D) this.dxfVertex2DCollection_0[(knotSpanIndex - power + index) % count].Position * derivatives[1, index];
        Vector2D unit = new Vector2D(-zero2.Y, zero2.X).GetUnit();
        Point2D2WN point2D2Wn2 = new Point2D2WN(zero1, num3 + num8 * num4, num3 + (num8 + num2) * num4) { IsInterpolatedPoint = true };
        point2D2Wn2.StartNormal = unit;
        if (point2D2Wn1 != null)
          point2D2Wn1.EndNormal = unit;
        polyline2D2Wn.Add(point2D2Wn2);
        point2D2Wn1 = point2D2Wn2;
        ++num6;
        u += num2;
      }
      if (this.Closed)
        polyline2D2Wn[num1 - 1].EndNormal = polyline2D2Wn[0].StartNormal;
      return polyline2D2Wn;
    }

    private bool method_32(DxfVertex2DCollection vertices)
    {
      bool flag;
      if (flag = this.DefaultStartWidth == 0.0 && this.DefaultEndWidth == 0.0)
      {
        int num = this.Closed ? vertices.Count : vertices.Count - 1;
        for (int index = 0; index < num; ++index)
        {
          IVertex2D ivertex2D = vertices.GetIVertex2D(index);
          if (ivertex2D.StartWidth != 0.0 || ivertex2D.EndWidth != 0.0)
          {
            flag = false;
            break;
          }
        }
      }
      return flag;
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      foreach (DxfVertex2D dxfVertex2D in (DxfHandledObjectCollection<DxfVertex2D>) this.dxfVertex2DCollection_0)
      {
        dxfVertex2D.vmethod_2((IDxfHandledObject) this);
        dxfVertex2D.vmethod_1(context);
      }
      if (this.dxfVertex2DCollection_1.Count == 0)
        this.RecalculateApproximationPoints((int) System.Math.Abs(this.Model.Header.NumberOfSplineSegments));
      foreach (DxfVertex2D dxfVertex2D in (DxfHandledObjectCollection<DxfVertex2D>) this.dxfVertex2DCollection_1)
      {
        dxfVertex2D.vmethod_2((IDxfHandledObject) this);
        dxfVertex2D.vmethod_1(context);
      }
    }

    private interface Interface43
    {
      WW.Cad.Drawing.Polyline2DE imethod_0();

      WW.Cad.Drawing.Polyline2D2N imethod_1();

      WW.Cad.Drawing.Polyline2D2WN imethod_2();
    }

    private class Class947 : DxfPolyline2DSpline.Interface43
    {
      private DxfPolyline2DSpline dxfPolyline2DSpline_0;

      public Class947(DxfPolyline2DSpline spline)
      {
        this.dxfPolyline2DSpline_0 = spline;
      }

      public WW.Cad.Drawing.Polyline2DE imethod_0()
      {
        return this.dxfPolyline2DSpline_0.method_25(this.dxfPolyline2DSpline_0.dxfVertex2DCollection_1, true);
      }

      public WW.Cad.Drawing.Polyline2D2N imethod_1()
      {
        return this.dxfPolyline2DSpline_0.method_26(this.dxfPolyline2DSpline_0.dxfVertex2DCollection_1, true);
      }

      public WW.Cad.Drawing.Polyline2D2WN imethod_2()
      {
        return this.dxfPolyline2DSpline_0.method_27(this.dxfPolyline2DSpline_0.dxfVertex2DCollection_1, true);
      }
    }

    private class Class948 : DxfPolyline2DSpline.Interface43
    {
      private GraphicsConfig graphicsConfig_0;
      private DxfPolyline2DSpline dxfPolyline2DSpline_0;
      private int int_0;

      public Class948(DxfPolyline2DSpline spline, int power, GraphicsConfig graphicsConfig)
      {
        this.dxfPolyline2DSpline_0 = spline;
        this.int_0 = power;
        this.graphicsConfig_0 = graphicsConfig;
      }

      public WW.Cad.Drawing.Polyline2DE imethod_0()
      {
        return this.dxfPolyline2DSpline_0.method_28(this.int_0, (int) this.graphicsConfig_0.NoOfSplineLineSegments);
      }

      public WW.Cad.Drawing.Polyline2D2N imethod_1()
      {
        return this.dxfPolyline2DSpline_0.method_29(this.int_0, (int) this.graphicsConfig_0.NoOfSplineLineSegments);
      }

      public WW.Cad.Drawing.Polyline2D2WN imethod_2()
      {
        return this.dxfPolyline2DSpline_0.method_31(this.int_0, (int) this.graphicsConfig_0.NoOfSplineLineSegments);
      }
    }
  }
}
