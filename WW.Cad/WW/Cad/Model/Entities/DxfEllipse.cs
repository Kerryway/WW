// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfEllipse
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns28;
using ns33;
using System;
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
  public class DxfEllipse : DxfEntity, IClipBoundaryProvider
  {
    private double double_1 = 1.0;
    private double double_3 = 2.0 * System.Math.PI;
    private Vector3D vector3D_1 = Vector3D.ZAxis;
    private WW.Math.Point3D point3D_0;
    private Vector3D vector3D_0;
    private double double_2;

    public DxfEllipse()
    {
    }

    public DxfEllipse(WW.Math.Point3D center, Vector3D majorAxisEndPoint, double minorToMajorRatio)
    {
      this.point3D_0 = center;
      this.vector3D_0 = majorAxisEndPoint;
      this.MinorToMajorRatio = minorToMajorRatio;
    }

    public DxfEllipse(
      WW.Math.Point3D center,
      Vector3D majorAxisEndPoint,
      double minorToMajorRatio,
      Vector3D zaxis)
    {
      this.point3D_0 = center;
      this.vector3D_0 = majorAxisEndPoint;
      this.MinorToMajorRatio = minorToMajorRatio;
      this.vector3D_1 = zaxis;
    }

    public DxfEllipse(
      WW.Math.Point3D center,
      Vector3D majorAxisEndPoint,
      double minorToMajorRatio,
      Vector3D zaxis,
      double startParameter,
      double endParameter)
    {
      this.point3D_0 = center;
      this.vector3D_0 = majorAxisEndPoint;
      this.MinorToMajorRatio = minorToMajorRatio;
      this.vector3D_1 = zaxis;
      this.double_2 = startParameter;
      this.double_3 = endParameter;
    }

    public WW.Math.Point3D Center
    {
      get
      {
        return this.point3D_0;
      }
      set
      {
        this.point3D_0 = value;
      }
    }

    public Vector3D MajorAxisEndPoint
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        this.vector3D_0 = value;
      }
    }

    public Vector3D MinorAxisEndPoint
    {
      get
      {
        Vector3D vector3D0 = this.vector3D_0;
        vector3D0.Normalize();
        Vector3D vector3D = Vector3D.CrossProduct(this.vector3D_1, vector3D0);
        vector3D.Normalize();
        return this.double_1 * this.vector3D_0.GetLength() * vector3D;
      }
    }

    public double MinorToMajorRatio
    {
      get
      {
        return this.double_1;
      }
      set
      {
        if (value > 1.0)
          throw new ArgumentException("Ellipse MinorToMajorRatio may not be bigger than 1.");
        this.double_1 = value;
      }
    }

    public double StartParameter
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
      }
    }

    public double EndParameter
    {
      get
      {
        return this.double_3;
      }
      set
      {
        this.double_3 = value;
      }
    }

    public Vector3D ZAxis
    {
      get
      {
        return this.vector3D_1;
      }
      set
      {
        this.vector3D_1 = value;
      }
    }

    public override string EntityType
    {
      get
      {
        return "ELLIPSE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbEllipse";
      }
    }

    public static double AngleToParameter(double angle, double minorToMajorRatio)
    {
      double x = System.Math.Cos(angle);
      return System.Math.Atan2(System.Math.Sin(angle) / minorToMajorRatio, x);
    }

    public static double ParameterToAngle(double parameter, double minorToMajorRatio)
    {
      double x = System.Math.Cos(parameter);
      return System.Math.Atan2(System.Math.Sin(parameter) * minorToMajorRatio, x);
    }

    public override void TransformMe(TransformConfig config, Matrix4D matrix)
    {
      this.TransformMe(config, matrix, (CommandGroup) null);
    }

    public override void TransformMe(
      TransformConfig config,
      Matrix4D matrix,
      CommandGroup undoGroup)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfEllipse.Class637 class637 = new DxfEllipse.Class637();
      // ISSUE: reference to a compiler-generated field
      class637.dxfEllipse_0 = this;
      // ISSUE: reference to a compiler-generated field
      class637.point3D_0 = this.point3D_0;
      // ISSUE: reference to a compiler-generated field
      class637.vector3D_0 = this.vector3D_0;
      // ISSUE: reference to a compiler-generated field
      class637.vector3D_1 = this.vector3D_1;
      Vector3D vector3D = Vector3D.CrossProduct(this.vector3D_1, this.vector3D_0);
      vector3D.Normalize();
      Vector3D vector = vector3D * (this.vector3D_0.GetLength() * this.double_1);
      // ISSUE: reference to a compiler-generated field
      class637.double_0 = this.double_1;
      this.point3D_0 = matrix.Transform(this.point3D_0);
      this.vector3D_0 = matrix.Transform(this.vector3D_0);
      Vector3D v = matrix.Transform(vector);
      if (v != Vector3D.Zero && this.vector3D_0 != Vector3D.Zero)
      {
        this.double_1 = v.GetLength() / this.vector3D_0.GetLength();
        this.vector3D_1 = Vector3D.CrossProduct(this.vector3D_0, v);
      }
      else
        this.vector3D_1 = matrix.Transform(this.vector3D_1);
      this.vector3D_1.Normalize();
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfEllipse.Class638()
      {
        class637_0 = class637,
        point3D_0 = this.point3D_0,
        vector3D_0 = this.vector3D_0,
        vector3D_1 = this.vector3D_1,
        double_0 = this.double_1
      }.method_0), new System.Action(class637.method_0)));
    }

    public WW.Math.Point3D GetPoint(double parameter)
    {
      Vector3D vector3D0 = this.vector3D_0;
      vector3D0.Normalize();
      Vector3D vector3D = Vector3D.CrossProduct(this.vector3D_1, vector3D0);
      vector3D.Normalize();
      double length = this.vector3D_0.GetLength();
      double num = this.double_1 * length;
      return (WW.Math.Point3D) (length * System.Math.Cos(parameter) * vector3D0 + num * System.Math.Sin(parameter) * vector3D) + (Vector3D) this.Center;
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
      graphicsFactory.SetColor(context.GetPlotColor((DxfEntity) this));
      IList<WW.Math.Geometry.Polyline3D> polylines;
      IList<FlatShape4D> shapes;
      this.GetPolylines((DrawContext) context, context.GetTransformer().LineTypeScaler, out polylines, out shapes);
      Class940.smethod_16((DxfEntity) this, context, graphicsFactory, polylines, false);
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
      double lineTypeScale = context.TotalLineTypeScale * this.LineTypeScale;
      if (!graphics.AddExistingGraphicElement2(parentGraphicElementBlock, (DxfEntity) this, plotColor, lineType, lineTypeScale, false))
        return;
      GraphicElement2 graphicElement2 = new GraphicElement2(plotColor, lineType, lineTypeScale, true);
      graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, (GraphicElement1) graphicElement2);
      WW.Math.Geometry.Polyline3D polyline = this.method_14(context.Config);
      graphicElement2.Geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive(polyline));
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfEllipse dxfEllipse = (DxfEllipse) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfEllipse == null)
      {
        dxfEllipse = new DxfEllipse();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfEllipse);
        dxfEllipse.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfEllipse;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfEllipse dxfEllipse = (DxfEllipse) from;
      this.point3D_0 = dxfEllipse.point3D_0;
      this.vector3D_0 = dxfEllipse.vector3D_0;
      this.double_1 = dxfEllipse.double_1;
      this.double_2 = dxfEllipse.double_2;
      this.double_3 = dxfEllipse.double_3;
      this.vector3D_1 = dxfEllipse.vector3D_1;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal void method_13(double value)
    {
      this.double_1 = value;
    }

    internal override short vmethod_6(Class432 w)
    {
      return 35;
    }

    public IList<Polygon2D> GetClipBoundary(GraphicsConfig graphicsConfig)
    {
      if (this.vector3D_0 == Vector3D.Zero || this.double_1 == 0.0)
        return (IList<Polygon2D>) new Polygon2D[0];
      WW.Math.Geometry.Polyline3D polyline3D = this.method_14(graphicsConfig);
      Polygon2D polygon2D = new Polygon2D(polyline3D.Count);
      foreach (WW.Math.Point3D point3D in (List<WW.Math.Point3D>) polyline3D)
        polygon2D.Add((WW.Math.Point2D) point3D);
      return (IList<Polygon2D>) new Polygon2D[1]{ polygon2D };
    }

    private new Matrix4D Transform
    {
      get
      {
        return Transformation4D.Translation((Vector3D) this.Center);
      }
    }

    private void GetPolylines4D(
      DrawContext context,
      IClippingTransformer transformer,
      out IList<Polyline4D> polylines4D,
      out IList<FlatShape4D> shapes)
    {
      IList<WW.Math.Geometry.Polyline3D> polylines;
      this.GetPolylines(context, transformer.LineTypeScaler, out polylines, out shapes);
      polylines4D = DxfUtil.smethod_36(polylines, false, transformer);
    }

    private void GetPolylines(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<WW.Math.Geometry.Polyline3D> polylines,
      out IList<FlatShape4D> shapes)
    {
      WW.Math.Geometry.Polyline3D polyline = this.method_14(context.Config);
      polylines = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>();
      if (context.Config.ApplyLineType)
      {
        shapes = (IList<FlatShape4D>) new List<FlatShape4D>();
        DxfUtil.smethod_4(context.Config, polylines, shapes, polyline, this.GetLineType(context), this.vector3D_1, context.TotalLineTypeScale * this.LineTypeScale, lineTypeScaler);
        if (shapes.Count != 0)
          return;
        shapes = (IList<FlatShape4D>) null;
      }
      else
      {
        polylines.Add(polyline);
        shapes = (IList<FlatShape4D>) null;
      }
    }

    private WW.Math.Geometry.Polyline3D method_14(GraphicsConfig graphicsConfig)
    {
      double num1 = 2.0 * System.Math.PI / (double) graphicsConfig.NoOfArcLineSegments;
      double double2 = this.double_2;
      double double3 = this.double_3;
      if (double3 <= double2)
        double3 += 2.0 * System.Math.PI;
      Matrix4D transform = this.Transform;
      Vector3D vector3D0 = this.vector3D_0;
      vector3D0.Normalize();
      Vector3D vector3D = Vector3D.CrossProduct(this.vector3D_1, vector3D0);
      vector3D.Normalize();
      double length = this.vector3D_0.GetLength();
      double num2 = this.double_1 * length;
      WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D();
      for (; double2 < double3; double2 += num1)
      {
        WW.Math.Point3D point = (WW.Math.Point3D) (length * System.Math.Cos(double2) * vector3D0 + num2 * System.Math.Sin(double2) * vector3D);
        polyline3D.Add(transform.Transform(point));
      }
      polyline3D.Add(transform.Transform((WW.Math.Point3D) (length * System.Math.Cos(double3) * vector3D0 + num2 * System.Math.Sin(double3) * vector3D)));
      return polyline3D;
    }
  }
}
