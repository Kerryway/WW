// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.WireframeGraphicsFactoryColorChanger
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Cad.Model.Entities;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public class WireframeGraphicsFactoryColorChanger : IWireframeGraphicsFactory
  {
    private IWireframeGraphicsFactory iwireframeGraphicsFactory_0;
    private Func<ArgbColor, ArgbColor> func_0;

    public WireframeGraphicsFactoryColorChanger(
      IWireframeGraphicsFactory graphicsFactory,
      Func<ArgbColor, ArgbColor> colorChanger)
    {
      this.iwireframeGraphicsFactory_0 = graphicsFactory;
      this.func_0 = colorChanger;
    }

    public IWireframeGraphicsFactory GraphicsFactory
    {
      get
      {
        return this.iwireframeGraphicsFactory_0;
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
      this.iwireframeGraphicsFactory_0.BeginEntity(entity, drawContext);
    }

    public void EndEntity()
    {
      this.iwireframeGraphicsFactory_0.EndEntity();
    }

    public void BeginInsert(DxfInsert insert)
    {
      this.iwireframeGraphicsFactory_0.BeginInsert(insert);
    }

    public void EndInsert()
    {
      this.iwireframeGraphicsFactory_0.EndInsert();
    }

    public void CreateDot(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      Vector4D position)
    {
      this.iwireframeGraphicsFactory_0.CreateDot(entity, drawContext, this.func_0(color), forText, position);
    }

    public void CreateLine(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      Vector4D start,
      Vector4D end)
    {
      this.iwireframeGraphicsFactory_0.CreateLine(entity, drawContext, this.func_0(color), forText, start, end);
    }

    public void CreateRay(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      Segment4D segment)
    {
      this.iwireframeGraphicsFactory_0.CreateRay(entity, drawContext, this.func_0(color), segment);
    }

    public void CreateXLine(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      Vector4D? startPoint,
      Segment4D segment)
    {
      this.iwireframeGraphicsFactory_0.CreateXLine(entity, drawContext, this.func_0(color), startPoint, segment);
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
      this.iwireframeGraphicsFactory_0.CreatePath(entity, drawContext, this.func_0(color), forText, polylines, fill, correctForBackgroundColor);
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
      this.iwireframeGraphicsFactory_0.CreatePathAsOne(entity, drawContext, this.func_0(color), forText, polylines, fill, correctForBackgroundColor);
    }

    public void CreateShape(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      IShape4D shape)
    {
      this.iwireframeGraphicsFactory_0.CreateShape(entity, drawContext, this.func_0(color), forText, shape);
    }

    public bool SupportsText
    {
      get
      {
        return this.iwireframeGraphicsFactory_0.SupportsText;
      }
    }

    public void CreateText(DxfText text, DrawContext.Wireframe drawContext, ArgbColor color)
    {
      this.iwireframeGraphicsFactory_0.CreateText(text, drawContext, this.func_0(color));
    }

    public void CreateMText(DxfMText text, DrawContext.Wireframe drawContext)
    {
      this.iwireframeGraphicsFactory_0.CreateMText(text, drawContext);
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
      this.iwireframeGraphicsFactory_0.CreateImage(rasterImage, drawContext, clipPolygon, imageBoundary, transformedOrigin, transformedXAxis, transformedYAxis);
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
      this.iwireframeGraphicsFactory_0.CreateScalableImage(entity, drawContext, bitmapProvider, clipPolygon, displaySize, transformedOrigin, transformedXAxis, transformedYAxis);
    }
  }
}
