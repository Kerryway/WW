// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.WireframeGraphicsFactory2ColorChanger
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Cad.Model.Entities;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public class WireframeGraphicsFactory2ColorChanger : IWireframeGraphicsFactory2
  {
    private IWireframeGraphicsFactory2 iwireframeGraphicsFactory2_0;
    private Func<ArgbColor, ArgbColor> func_0;

    public WireframeGraphicsFactory2ColorChanger(
      IWireframeGraphicsFactory2 graphicsFactory,
      Func<ArgbColor, ArgbColor> colorChanger)
    {
      this.iwireframeGraphicsFactory2_0 = graphicsFactory;
      this.func_0 = colorChanger;
    }

    public IWireframeGraphicsFactory2 GraphicsFactory
    {
      get
      {
        return this.iwireframeGraphicsFactory2_0;
      }
    }

    public Func<ArgbColor, ArgbColor> ColorChanger
    {
      get
      {
        return this.func_0;
      }
      set
      {
        this.func_0 = value;
      }
    }

    public void BeginEntity(DxfEntity entity, DrawContext.Wireframe drawContext)
    {
      this.iwireframeGraphicsFactory2_0.BeginEntity(entity, drawContext);
    }

    public void EndEntity()
    {
      this.iwireframeGraphicsFactory2_0.EndEntity();
    }

    public void BeginInsert(DxfInsert insert)
    {
      this.iwireframeGraphicsFactory2_0.BeginInsert(insert);
    }

    public void EndInsert()
    {
      this.iwireframeGraphicsFactory2_0.EndInsert();
    }

    public void BeginGeometry(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      bool fill,
      bool stroke,
      bool correctForBackgroundColor)
    {
      this.iwireframeGraphicsFactory2_0.BeginGeometry(entity, drawContext, this.func_0(color), forText, fill, stroke, correctForBackgroundColor);
    }

    public void EndGeometry()
    {
      this.iwireframeGraphicsFactory2_0.EndGeometry();
    }

    public void CreateDot(DxfEntity entity, Vector4D position)
    {
      this.iwireframeGraphicsFactory2_0.CreateDot(entity, position);
    }

    public void CreateLine(DxfEntity entity, Vector4D start, Vector4D end)
    {
      this.iwireframeGraphicsFactory2_0.CreateLine(entity, start, end);
    }

    public void CreateRay(DxfEntity entity, Segment4D segment)
    {
      this.iwireframeGraphicsFactory2_0.CreateRay(entity, segment);
    }

    public void CreateXLine(DxfEntity entity, Vector4D? startPoint, Segment4D segment)
    {
      this.iwireframeGraphicsFactory2_0.CreateXLine(entity, startPoint, segment);
    }

    public void CreatePolyline(DxfEntity entity, Polyline4D polyline)
    {
      this.iwireframeGraphicsFactory2_0.CreatePolyline(entity, polyline);
    }

    public void CreateShape(DxfEntity entity, IShape4D shape)
    {
      this.iwireframeGraphicsFactory2_0.CreateShape(entity, shape);
    }

    public bool SupportsText
    {
      get
      {
        return this.iwireframeGraphicsFactory2_0.SupportsText;
      }
    }

    public void CreateText(DxfText text)
    {
      this.iwireframeGraphicsFactory2_0.CreateText(text);
    }

    public void CreateMText(DxfMText text)
    {
      this.iwireframeGraphicsFactory2_0.CreateMText(text);
    }

    public void CreateImage(
      DxfRasterImage rasterImage,
      Point2D imageCorner1,
      Point2D imageCorner2,
      Vector4D transformedOrigin,
      Vector4D transformedXAxis,
      Vector4D transformedYAxis,
      DrawContext.Wireframe drawContext)
    {
      this.iwireframeGraphicsFactory2_0.CreateImage(rasterImage, imageCorner1, imageCorner2, transformedOrigin, transformedXAxis, transformedYAxis, drawContext);
    }
  }
}
