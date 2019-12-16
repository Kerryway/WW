// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.IWireframeGraphicsFactory
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model.Entities;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public interface IWireframeGraphicsFactory
  {
    void BeginEntity(DxfEntity entity, DrawContext.Wireframe drawContext);

    void EndEntity();

    void BeginInsert(DxfInsert insert);

    void EndInsert();

    void CreateDot(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      Vector4D position);

    void CreateLine(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      Vector4D start,
      Vector4D end);

    void CreateRay(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      Segment4D segment);

    void CreateXLine(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      Vector4D? startPoint,
      Segment4D segment);

    void CreatePath(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      IList<Polyline4D> polylines,
      bool fill,
      bool correctForBackgroundColor);

    void CreatePathAsOne(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      IList<Polyline4D> polylines,
      bool fill,
      bool correctForBackgroundColor);

    void CreateShape(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      IShape4D shape);

    bool SupportsText { get; }

    void CreateText(DxfText text, DrawContext.Wireframe drawContext, ArgbColor color);

    void CreateMText(DxfMText text, DrawContext.Wireframe drawContext);

    void CreateImage(
      DxfRasterImage rasterImage,
      DrawContext.Wireframe drawContext,
      Polyline4D clipPolygon,
      Polyline4D imageBoundary,
      Vector4D transformedOrigin,
      Vector4D transformedXAxis,
      Vector4D transformedYAxis);

    void CreateScalableImage(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      IBitmapProvider bitmapProvider,
      Polyline4D clipPolygon,
      Size2D displaySize,
      Vector4D transformedOrigin,
      Vector4D transformedXAxis,
      Vector4D transformedYAxis);
  }
}
