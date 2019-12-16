// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.GDI.ToGraphicsPathConverter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Cad.Model.Entities;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing.GDI
{
  public class ToGraphicsPathConverter : IWireframeGraphicsFactory
  {
    private float float_1 = 1f / 1000f;
    private float float_2 = 0.0005f;
    private const float float_0 = 0.001f;
    private readonly GraphicsPath graphicsPath_0;

    public ToGraphicsPathConverter(GraphicsPath graphicsPath)
    {
      this.graphicsPath_0 = graphicsPath;
    }

    public float DotSize
    {
      get
      {
        return this.float_1;
      }
      set
      {
        this.float_1 = value;
        this.float_2 = 0.5f * this.float_1;
      }
    }

    public void BeginEntity(DxfEntity entity, DrawContext.Wireframe drawContext)
    {
    }

    public void EndEntity()
    {
    }

    public void BeginInsert(DxfInsert insert)
    {
    }

    public void EndInsert()
    {
    }

    public void CreateDot(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      Vector4D position)
    {
      this.method_1((Point2D) position);
    }

    public void CreateLine(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      Vector4D start,
      Vector4D end)
    {
      Point2D point2D1 = (Point2D) start;
      Point2D point2D2 = (Point2D) end;
      this.graphicsPath_0.AddLine((float) point2D1.X, (float) point2D1.Y, (float) point2D2.X, (float) point2D2.Y);
    }

    public void CreateRay(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      Segment4D segment)
    {
      Point2D start = (Point2D) segment.Start;
      Point2D end = (Point2D) segment.End;
      this.graphicsPath_0.AddLine((float) start.X, (float) start.Y, (float) end.X, (float) end.Y);
    }

    public void CreateXLine(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      Vector4D? startPoint,
      Segment4D segment)
    {
      Point2D start = (Point2D) segment.Start;
      Point2D end = (Point2D) segment.End;
      this.graphicsPath_0.AddLine((float) start.X, (float) start.Y, (float) end.X, (float) end.Y);
    }

    public void CreatePath(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      IList<Polyline4D> polylines,
      bool fill,
      bool correctForBackgroundColor)
    {
      this.method_0(polylines);
    }

    public void CreatePathAsOne(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      IList<Polyline4D> polylines,
      bool fill,
      bool correctForBackgroundColor)
    {
      this.method_0(polylines);
    }

    public void CreateShape(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      IShape4D shape)
    {
      using (GraphicsPath graphicsPath = ShapeTool.ToGraphicsPath(shape.ToShape2D(Matrix4D.Identity)))
        this.graphicsPath_0.AddPath(graphicsPath, false);
    }

    private static void smethod_0(GraphicsPath graphicsPath)
    {
      PointF[] pathPoints = graphicsPath.PathPoints;
      int num1 = 0;
      while (num1 < pathPoints.Length)
        ++num1;
      byte[] pathTypes = graphicsPath.PathTypes;
      int num2 = 0;
      while (num2 < pathTypes.Length)
        ++num2;
    }

    public bool SupportsText
    {
      get
      {
        return false;
      }
    }

    public void CreateText(DxfText text, DrawContext.Wireframe drawContext, ArgbColor color)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public void CreateMText(DxfMText text, DrawContext.Wireframe drawContext)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public void CreateImage(
      DxfRasterImage rasterImage,
      DrawContext.Wireframe drawContext,
      Polyline4D clipPolygon,
      Polyline4D imageBoundary,
      Vector4D transformedOrigin,
      Vector4D transformedXAxis,
      Vector4D transformedYAxis)
    {
    }

    public void CreateScalableImage(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      IBitmapProvider bitmapProvider,
      Polyline4D clipPolygon,
      Size2D displaySize,
      Vector4D transformedOrigin,
      Vector4D transformedXAxis,
      Vector4D transformedYAxis)
    {
    }

    private void method_0(IList<Polyline4D> polylines)
    {
      foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polylines)
      {
        if (polyline.Count > 0)
        {
          if (polyline.Count == 1)
          {
            this.method_1((Point2D) polyline[0]);
          }
          else
          {
            PointF[] points = new PointF[polyline.Count];
            for (int index = 0; index < polyline.Count; ++index)
            {
              Point2D point2D = (Point2D) polyline[index];
              points[index] = new PointF((float) point2D.X, (float) point2D.Y);
            }
            this.graphicsPath_0.StartFigure();
            if (polyline.Closed && polyline.Count > 2)
              this.graphicsPath_0.AddPolygon(points);
            else
              this.graphicsPath_0.AddLines(points);
          }
        }
      }
    }

    private void method_1(Point2D p)
    {
      this.graphicsPath_0.AddRectangle(new RectangleF((float) p.X - this.float_2, (float) p.Y - this.float_2, this.float_1, this.float_1));
    }
  }
}
