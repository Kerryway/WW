// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.IWireframeGraphicsFactory2
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model.Entities;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public interface IWireframeGraphicsFactory2
  {
    void BeginEntity(DxfEntity entity, DrawContext.Wireframe drawContext);

    void EndEntity();

    void BeginInsert(DxfInsert insert);

    void EndInsert();

    void BeginGeometry(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      bool fill,
      bool stroke,
      bool correctForBackgroundColor);

    void EndGeometry();

    void CreateDot(DxfEntity entity, Vector4D position);

    void CreateLine(DxfEntity entity, Vector4D start, Vector4D end);

    void CreateRay(DxfEntity entity, Segment4D segment);

    void CreateXLine(DxfEntity entity, Vector4D? startPoint, Segment4D segment);

    void CreatePolyline(DxfEntity entity, Polyline4D polyline);

    void CreateShape(DxfEntity entity, IShape4D shape);

    bool SupportsText { get; }

    void CreateText(DxfText text);

    void CreateMText(DxfMText text);

    void CreateImage(
      DxfRasterImage rasterImage,
      Point2D imageCorner1,
      Point2D imageCorner2,
      Vector4D transformedOrigin,
      Vector4D transformedXAxis,
      Vector4D transformedYAxis,
      DrawContext.Wireframe drawContext);
  }
}
