// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfWipeout
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns33;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfWipeout : DxfRasterImage
  {
    public DxfWipeout()
    {
      this.Size = new Size2D(1.0, 1.0);
      this.ImageDisplayFlags = ImageDisplayFlags.ShowImage | ImageDisplayFlags.ShowUnalignedImage | ImageDisplayFlags.UseClippingBoundary;
      this.ClippingEnabled = true;
    }

    public override string EntityType
    {
      get
      {
        return "WIPEOUT";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbWipeout";
      }
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfWipeout dxfWipeout = (DxfWipeout) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfWipeout == null)
      {
        dxfWipeout = new DxfWipeout();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfWipeout);
        dxfWipeout.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfWipeout;
    }

    public void SetWipeoutPolygon(IList<WW.Math.Point2D> polygon)
    {
      Bounds2D bounds2D = new Bounds2D();
      bounds2D.Update(polygon);
      this.InsertionPoint = (WW.Math.Point3D) bounds2D.Min;
      this.XAxis = new Vector3D(bounds2D.Delta.X, 0.0, 0.0);
      this.YAxis = new Vector3D(0.0, bounds2D.Delta.Y, 0.0);
      Matrix3D matrix3D = Transformation3D.Scaling(1.0 / this.XAxis.X, -1.0 / this.YAxis.Y, 1.0) * Transformation3D.Translation(WW.Math.Point2D.Zero - bounds2D.Center);
      this.BoundaryVertices.Clear();
      foreach (WW.Math.Point2D point in (IEnumerable<WW.Math.Point2D>) polygon)
        this.BoundaryVertices.Add(matrix3D.Transform(point));
      if (this.BoundaryVertices.Count <= 2 || !(this.BoundaryVertices[0] != this.BoundaryVertices[this.BoundaryVertices.Count - 1]))
        return;
      this.BoundaryVertices.Add(this.BoundaryVertices[0]);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.short_5;
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      Polyline3DT imageBoundaryPolyline;
      IClippingTransformer transformer;
      IList<Polyline4D> polylines1 = this.method_16(context, out imageBoundaryPolyline, out transformer);
      if (polylines1.Count <= 0)
        return;
      graphicsFactory.CreatePath((DxfEntity) this, context, context.Config.BackColor, false, polylines1, true, false);
      IList<FlatShape4D> flatShape4DList = (IList<FlatShape4D>) null;
      if (!context.WipeoutVariables.DisplayFrame)
        return;
      IList<WW.Math.Geometry.Polyline3D> polyline3DList;
      if (context.Config.ApplyLineType)
      {
        IList<FlatShape4D> resultShapes = (IList<FlatShape4D>) new List<FlatShape4D>();
        polyline3DList = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>();
        Vector3D upward = Vector3D.CrossProduct(this.XAxis, this.YAxis);
        if (upward == Vector3D.Zero)
          upward = Vector3D.ZAxis;
        else
          upward.Normalize();
        DxfUtil.smethod_11(context.Config, polyline3DList, resultShapes, imageBoundaryPolyline, this.GetLineType((DrawContext) context), upward, context.TotalLineTypeScale * this.LineTypeScale, context.GetTransformer().LineTypeScaler);
        if (resultShapes.Count == 0)
          flatShape4DList = (IList<FlatShape4D>) null;
      }
      else
      {
        polyline3DList = (IList<WW.Math.Geometry.Polyline3D>) new WW.Math.Geometry.Polyline3D[1]
        {
          imageBoundaryPolyline.ToPolyline3D()
        };
        flatShape4DList = (IList<FlatShape4D>) null;
      }
      IList<Polyline4D> polylines2 = DxfUtil.smethod_36(polyline3DList, false, transformer);
      graphicsFactory.CreatePath((DxfEntity) this, context, this.GetColor((DrawContext) context), false, polylines2, false, true);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      Polyline3DT imageBoundaryPolyline;
      IClippingTransformer transformer;
      IList<Polyline4D> polyline4DList1 = this.method_16(context, out imageBoundaryPolyline, out transformer);
      if (polyline4DList1.Count <= 0)
        return;
      graphicsFactory.BeginGeometry((DxfEntity) this, context, context.Config.BackColor, false, true, false, false);
      foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polyline4DList1)
        graphicsFactory.CreatePolyline((DxfEntity) this, polyline);
      graphicsFactory.EndGeometry();
      IList<FlatShape4D> flatShape4DList = (IList<FlatShape4D>) null;
      if (!context.WipeoutVariables.DisplayFrame)
        return;
      IList<WW.Math.Geometry.Polyline3D> polyline3DList;
      if (context.Config.ApplyLineType)
      {
        IList<FlatShape4D> resultShapes = (IList<FlatShape4D>) new List<FlatShape4D>();
        polyline3DList = (IList<WW.Math.Geometry.Polyline3D>) new List<WW.Math.Geometry.Polyline3D>();
        Vector3D upward = Vector3D.CrossProduct(this.XAxis, this.YAxis);
        if (upward == Vector3D.Zero)
          upward = Vector3D.ZAxis;
        else
          upward.Normalize();
        DxfUtil.smethod_11(context.Config, polyline3DList, resultShapes, imageBoundaryPolyline, this.GetLineType((DrawContext) context), upward, context.TotalLineTypeScale * this.LineTypeScale, context.GetTransformer().LineTypeScaler);
        if (resultShapes.Count == 0)
          flatShape4DList = (IList<FlatShape4D>) null;
      }
      else
      {
        polyline3DList = (IList<WW.Math.Geometry.Polyline3D>) new WW.Math.Geometry.Polyline3D[1]
        {
          imageBoundaryPolyline.ToPolyline3D()
        };
        flatShape4DList = (IList<FlatShape4D>) null;
      }
      IList<Polyline4D> polyline4DList2 = DxfUtil.smethod_36(polyline3DList, false, transformer);
      graphicsFactory.BeginGeometry((DxfEntity) this, context, this.GetColor((DrawContext) context), false, false, true, true);
      foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polyline4DList2)
        graphicsFactory.CreatePolyline((DxfEntity) this, polyline);
      graphicsFactory.EndGeometry();
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      WW.Math.Geometry.Polyline3D polyline3D = this.method_17(context);
      if (polyline3D.Count <= 0)
        return;
      graphicsFactory.SetColor(context.Config.BackColor);
      Class940.smethod_16((DxfEntity) this, context, graphicsFactory, (IList<WW.Math.Geometry.Polyline3D>) new WW.Math.Geometry.Polyline3D[1]
      {
        polyline3D
      }, true);
      if (!context.WipeoutVariables.DisplayFrame)
        return;
      graphicsFactory.SetColor(this.GetColor((DrawContext) context));
      Class940.smethod_16((DxfEntity) this, context, graphicsFactory, (IList<WW.Math.Geometry.Polyline3D>) new WW.Math.Geometry.Polyline3D[1]
      {
        polyline3D
      }, false);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      WW.Math.Geometry.Polyline3D polyline = this.method_17(context);
      if (polyline.Count <= 0 || !context.WipeoutVariables.DisplayFrame)
        return;
      ArgbColor plotColor = context.GetPlotColor((DxfEntity) this);
      DxfLineType lineType = this.GetLineType((DrawContext) context);
      double lineTypeScale = context.TotalLineTypeScale * this.LineTypeScale;
      if (!graphics.AddExistingGraphicElement2(parentGraphicElementBlock, (DxfEntity) this, plotColor, lineType, lineTypeScale, false))
        return;
      GraphicElement2 graphicElement2 = new GraphicElement2(plotColor, lineType, lineTypeScale, false);
      graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, (GraphicElement1) graphicElement2);
      graphicElement2.Geometry.Add(WW.Cad.Drawing.Surface.Polyline3D.CreatePrimitive(polyline));
    }

    private IList<Polyline4D> method_16(
      DrawContext.Wireframe context,
      out Polyline3DT imageBoundaryPolyline,
      out IClippingTransformer transformer)
    {
      Polygon2D clipBoundary = this.GetClipBoundary((DrawContext) context);
      if (clipBoundary != null && clipBoundary.Count != 0)
      {
        Matrix4D preTransform = this.method_15();
        transformer = context.GetTransformer();
        transformer = (IClippingTransformer) transformer.Clone();
        transformer.SetPreTransform(preTransform);
        imageBoundaryPolyline = new Polyline3DT(true);
        foreach (WW.Math.Point2D point2D in (List<WW.Math.Point2D>) clipBoundary)
          imageBoundaryPolyline.Add(new Point3DT((WW.Math.Point3D) point2D, 0U));
        return (IList<Polyline4D>) new List<Polyline4D>((IEnumerable<Polyline4D>) transformer.Transform(imageBoundaryPolyline.ToPolyline3D(), true));
      }
      imageBoundaryPolyline = (Polyline3DT) null;
      transformer = (IClippingTransformer) null;
      return (IList<Polyline4D>) new Polyline4D[0];
    }

    private WW.Math.Geometry.Polyline3D method_17(DrawContext.Surface context)
    {
      Polygon2D clipBoundary = this.GetClipBoundary((DrawContext) context);
      if (clipBoundary == null || clipBoundary.Count == 0)
        return new WW.Math.Geometry.Polyline3D();
      Matrix4D matrix4D = this.method_15();
      WW.Math.Geometry.Polyline3D polyline3D = new WW.Math.Geometry.Polyline3D(true);
      foreach (WW.Math.Point2D point in (List<WW.Math.Point2D>) clipBoundary)
        polyline3D.Add(matrix4D.TransformTo3D(point));
      return polyline3D;
    }
  }
}
