// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.BaseWireframeGraphicsFactory
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
  public class BaseWireframeGraphicsFactory : IWireframeGraphicsFactory
  {
    public virtual void BeginEntity(DxfEntity entity, DrawContext.Wireframe drawContext)
    {
    }

    public virtual void EndEntity()
    {
    }

    public virtual void BeginInsert(DxfInsert insert)
    {
    }

    public virtual void EndInsert()
    {
    }

    public virtual void CreateDot(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      Vector4D position)
    {
    }

    public virtual void CreateLine(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      Vector4D start,
      Vector4D end)
    {
    }

    public virtual void CreateRay(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      Segment4D segment)
    {
    }

    public virtual void CreateXLine(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      Vector4D? startPoint,
      Segment4D segment)
    {
    }

    public virtual void CreatePath(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      IList<Polyline4D> polylines,
      bool fill,
      bool correctForBackgroundColor)
    {
    }

    public virtual void CreatePathAsOne(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      IList<Polyline4D> polylines,
      bool fill,
      bool correctForBackgroundColor)
    {
    }

    public virtual void CreateShape(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      IShape4D shape)
    {
    }

    public virtual bool SupportsText
    {
      get
      {
        return false;
      }
    }

    public virtual void CreateText(
      DxfText text,
      DrawContext.Wireframe drawContext,
      ArgbColor color)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public virtual void CreateMText(DxfMText text, DrawContext.Wireframe drawContext)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public virtual void CreateImage(
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
  }
}
