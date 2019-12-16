// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.BoundsCalculator
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public class BoundsCalculator
  {
    private readonly Bounds3D bounds3D_0;
    private readonly GraphicsConfig graphicsConfig_0;

    public BoundsCalculator()
      : this(GraphicsConfig.AcadLikeWithBlackBackground)
    {
    }

    public BoundsCalculator(Bounds3D bounds)
      : this(bounds, GraphicsConfig.AcadLikeWithBlackBackground)
    {
    }

    public BoundsCalculator(GraphicsConfig graphicsConfig)
      : this(new Bounds3D(), graphicsConfig)
    {
    }

    public BoundsCalculator(Bounds3D bounds, GraphicsConfig graphicsConfig)
    {
      this.bounds3D_0 = bounds;
      this.graphicsConfig_0 = graphicsConfig;
    }

    public Bounds3D Bounds
    {
      get
      {
        return this.bounds3D_0;
      }
    }

    public void GetBounds(DxfModel model)
    {
      this.GetBounds(model, Matrix4D.Identity);
    }

    public void GetBounds(DxfModel model, Matrix4D modelTransform)
    {
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, this.graphicsConfig_0, modelTransform))
      {
        IWireframeGraphicsFactory graphicsFactory = this.CreateGraphicsFactory();
        foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) model.Entities)
          entity.Draw(context, graphicsFactory);
      }
    }

    public void GetBounds(DxfModel model, DxfEntity entity)
    {
      this.GetBounds(model, entity, Matrix4D.Identity);
    }

    public void GetBounds(DxfModel model, DxfEntity entity, Matrix4D modelTransform)
    {
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, this.graphicsConfig_0, modelTransform))
      {
        IWireframeGraphicsFactory graphicsFactory = this.CreateGraphicsFactory();
        entity.Draw(context, graphicsFactory);
      }
    }

    public void GetBounds(DxfModel model, IEnumerable<DxfEntity> entities)
    {
      this.GetBounds(model, entities, Matrix4D.Identity);
    }

    public void GetBounds(DxfModel model, IEnumerable<DxfEntity> entities, Matrix4D modelTransform)
    {
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, this.graphicsConfig_0, modelTransform))
      {
        IWireframeGraphicsFactory graphicsFactory = this.CreateGraphicsFactory();
        foreach (DxfEntity entity in entities)
          entity.Draw(context, graphicsFactory);
      }
    }

    public void GetBounds(DxfModel model, DxfLayout layout)
    {
      this.GetBounds(model, layout, (ICollection<DxfViewport>) layout.Viewports);
    }

    public void GetBounds(DxfModel model, DxfLayout layout, Matrix4D postTransform)
    {
      this.GetBounds(model, layout, (ICollection<DxfViewport>) layout.Viewports, postTransform);
    }

    public void GetBounds(DxfModel model, DxfLayout layout, ICollection<DxfViewport> viewports)
    {
      this.GetBounds(model, layout, viewports, Matrix4D.Identity);
    }

    public void GetBounds(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      Matrix4D postTransform)
    {
      if (viewports == null)
        viewports = (ICollection<DxfViewport>) layout.Viewports;
      IWireframeGraphicsFactory graphicsFactory = this.CreateGraphicsFactory();
      using (DrawContext.Wireframe.PaperToPaperSpace paperToPaperSpace = new DrawContext.Wireframe.PaperToPaperSpace(layout.Model, layout, this.graphicsConfig_0, postTransform))
      {
        foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) layout.Entities)
          entity.Draw((DrawContext.Wireframe) paperToPaperSpace, graphicsFactory);
        layout.DrawFrame((DrawContext.Wireframe) paperToPaperSpace, graphicsFactory);
      }
      foreach (DxfViewport viewport in (IEnumerable<DxfViewport>) viewports)
      {
        if (viewport.ModelSpaceVisible)
        {
          using (DrawContext.Wireframe.ModelToPaperSpace modelToPaperSpace = new DrawContext.Wireframe.ModelToPaperSpace(layout.Model, layout, this.graphicsConfig_0, viewport, postTransform))
          {
            foreach (DxfEntity entity in (DxfHandledObjectCollection<DxfEntity>) model.Entities)
              entity.Draw((DrawContext.Wireframe) modelToPaperSpace, graphicsFactory);
          }
        }
      }
    }

    public void GetBounds(
      DxfModel model,
      DxfLayout layout,
      DxfEntity paperSpaceEntity,
      Matrix4D postTransform)
    {
      using (DrawContext.Wireframe.PaperToPaperSpace paperToPaperSpace = new DrawContext.Wireframe.PaperToPaperSpace(layout.Model, layout, this.graphicsConfig_0, postTransform))
        paperSpaceEntity.Draw((DrawContext.Wireframe) paperToPaperSpace, this.CreateGraphicsFactory());
    }

    public void GetBounds(
      DxfModel model,
      DxfLayout layout,
      IEnumerable<DxfEntity> paperSpaceEntities,
      Matrix4D postTransform)
    {
      using (DrawContext.Wireframe.PaperToPaperSpace paperToPaperSpace = new DrawContext.Wireframe.PaperToPaperSpace(layout.Model, layout, this.graphicsConfig_0, postTransform))
      {
        foreach (DxfEntity paperSpaceEntity in paperSpaceEntities)
          paperSpaceEntity.Draw((DrawContext.Wireframe) paperToPaperSpace, this.CreateGraphicsFactory());
      }
    }

    public IWireframeGraphicsFactory CreateGraphicsFactory()
    {
      return (IWireframeGraphicsFactory) new BoundsCalculator.Class1053(this.bounds3D_0);
    }

    public IWireframeGraphicsFactory CreateTransformingGraphicsFactory(
      Matrix4D transform)
    {
      return (IWireframeGraphicsFactory) new BoundsCalculator.Class1054(this.bounds3D_0, transform);
    }

    private class Class1053 : IWireframeGraphicsFactory
    {
      private readonly Bounds3D bounds3D_0;

      public Class1053(Bounds3D bounds)
      {
        this.bounds3D_0 = bounds;
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
        this.bounds3D_0.Update(position);
      }

      public void CreateLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D start,
        Vector4D end)
      {
        this.bounds3D_0.Update(start);
        this.bounds3D_0.Update(end);
      }

      public void CreateRay(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Segment4D segment)
      {
      }

      public void CreateXLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Vector4D? startPoint,
        Segment4D segment)
      {
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
        foreach (IList<Vector4D> polyline in (IEnumerable<Polyline4D>) polylines)
          this.bounds3D_0.Update(polyline);
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
        foreach (IList<Vector4D> polyline in (IEnumerable<Polyline4D>) polylines)
          this.bounds3D_0.Update(polyline);
      }

      public void CreateShape(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IShape4D shape)
      {
        shape.UpdateBounds(this.bounds3D_0, Matrix4D.Identity);
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
        if (imageBoundary == null)
          return;
        this.bounds3D_0.Update((IList<Vector4D>) imageBoundary);
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
        transformedXAxis *= displaySize.X;
        transformedYAxis *= displaySize.Y;
        this.bounds3D_0.Update(transformedOrigin);
        this.bounds3D_0.Update(transformedOrigin + transformedXAxis);
        this.bounds3D_0.Update(transformedOrigin + transformedYAxis);
        this.bounds3D_0.Update(transformedOrigin + transformedXAxis + transformedYAxis);
      }
    }

    private class Class1054 : IWireframeGraphicsFactory
    {
      private readonly Bounds3D bounds3D_0;
      private readonly Matrix4D matrix4D_0;

      public Class1054(Bounds3D bounds, Matrix4D transform)
      {
        this.bounds3D_0 = bounds;
        this.matrix4D_0 = transform;
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
        this.bounds3D_0.Update(this.matrix4D_0.TransformToPoint3D(position));
      }

      public void CreateLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D start,
        Vector4D end)
      {
        this.bounds3D_0.Update(this.matrix4D_0.TransformToPoint3D(start));
        this.bounds3D_0.Update(this.matrix4D_0.TransformToPoint3D(end));
      }

      public void CreateRay(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Segment4D segment)
      {
      }

      public void CreateXLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Vector4D? startPoint,
        Segment4D segment)
      {
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
        foreach (IList<Vector4D> polyline in (IEnumerable<Polyline4D>) polylines)
          this.bounds3D_0.Update(polyline, this.matrix4D_0);
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
        foreach (IList<Vector4D> polyline in (IEnumerable<Polyline4D>) polylines)
          this.bounds3D_0.Update(polyline, this.matrix4D_0);
      }

      public void CreateShape(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IShape4D shape)
      {
        shape.UpdateBounds(this.bounds3D_0, this.matrix4D_0);
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
        this.bounds3D_0.Update((IList<Vector4D>) imageBoundary, this.matrix4D_0);
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
        transformedXAxis *= displaySize.X;
        transformedYAxis *= displaySize.Y;
        this.bounds3D_0.Update(this.matrix4D_0.TransformTo3D(transformedOrigin));
        this.bounds3D_0.Update(this.matrix4D_0.TransformTo3D(transformedOrigin + transformedXAxis));
        this.bounds3D_0.Update(this.matrix4D_0.TransformTo3D(transformedOrigin + transformedYAxis));
        this.bounds3D_0.Update(this.matrix4D_0.TransformTo3D(transformedOrigin + transformedXAxis + transformedYAxis));
      }
    }
  }
}
