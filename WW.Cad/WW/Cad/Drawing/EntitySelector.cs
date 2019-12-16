// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.EntitySelector
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns36;
using ns38;
using System;
using System.Collections;
using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public static class EntitySelector
  {
    static EntitySelector()
    {
      Class809.smethod_0(Enum15.const_2);
    }

    public static IList<RenderedEntityInfo> GetClosestEntities(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D transformation,
      WW.Math.Point2D referencePoint,
      EntityFilterDelegate filterDelegate,
      out double distance)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class582 class582 = new EntitySelector.Class582(referencePoint, filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, config, transformation))
        model.Draw(context, (IWireframeGraphicsFactory) class582);
      distance = class582.ClosestDistance;
      return (IList<RenderedEntityInfo>) class582.ClosestEntities;
    }

    public static IList<RenderedEntityInfo> GetClosestEntities(
      DxfModel model,
      IEnumerable<DxfEntity> entities,
      GraphicsConfig config,
      Matrix4D transformation,
      WW.Math.Point2D referencePoint,
      EntityFilterDelegate filterDelegate,
      out double distance)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class582 class582 = new EntitySelector.Class582(referencePoint, filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, config, transformation))
      {
        foreach (DxfEntity entity in entities)
          entity.Draw(context, (IWireframeGraphicsFactory) class582);
      }
      distance = class582.ClosestDistance;
      return (IList<RenderedEntityInfo>) class582.ClosestEntities;
    }

    public static IList<RenderedEntityInfo> GetClosestEntities(
      DxfModel model,
      DxfLayout layout,
      GraphicsConfig config,
      Matrix4D transformation,
      WW.Math.Point2D referencePoint,
      EntityFilterDelegate filterDelegate,
      out double distance)
    {
      return EntitySelector.GetClosestEntities(model, layout, (ICollection<DxfViewport>) layout.Viewports, config, transformation, referencePoint, filterDelegate, out distance);
    }

    public static IList<RenderedEntityInfo> GetClosestEntities(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D transformation,
      WW.Math.Point2D referencePoint,
      out double distance)
    {
      return EntitySelector.GetClosestEntities(model, layout, viewports, config, transformation, referencePoint, (EntityFilterDelegate) null, out distance);
    }

    public static IList<RenderedEntityInfo> GetClosestEntities(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D transformation,
      WW.Math.Point2D referencePoint,
      EntityFilterDelegate filterDelegate,
      out double distance)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class582 class582 = new EntitySelector.Class582(referencePoint, filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.PaperToPaperSpace(model, layout, config, transformation))
        layout.Draw(context, (IWireframeGraphicsFactory) class582);
      if (viewports == null)
        viewports = (ICollection<DxfViewport>) layout.Viewports;
      foreach (DxfViewport viewport in (IEnumerable<DxfViewport>) viewports)
      {
        if (viewport.ModelSpaceVisible)
        {
          using (DrawContext.Wireframe.ModelToPaperSpace modelToPaperSpace = new DrawContext.Wireframe.ModelToPaperSpace(model, layout, config, viewport, transformation))
            model.Draw((DrawContext.Wireframe) modelToPaperSpace, (IWireframeGraphicsFactory) class582);
        }
      }
      distance = class582.ClosestDistance;
      return (IList<RenderedEntityInfo>) class582.ClosestEntities;
    }

    public static IList<RenderedEntityInfo> GetClosestEntities(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D transformation,
      WW.Math.Point2D referencePoint,
      out double distance)
    {
      return EntitySelector.GetClosestEntities(model, config, transformation, referencePoint, (EntityFilterDelegate) null, out distance);
    }

    public static IList<RenderedEntityInfo> GetClosestEntities(
      DxfModel model,
      DxfLayout layout,
      GraphicsConfig config,
      Matrix4D transformation,
      WW.Math.Point2D referencePoint,
      out double distance)
    {
      return EntitySelector.GetClosestEntities(model, layout, config, transformation, referencePoint, (EntityFilterDelegate) null, out distance);
    }

    public static IList<RenderedEntityInfo> GetEntitiesCloseToPoint(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D transformation,
      WW.Math.Point2D referencePoint,
      double testSquareWidth,
      EntityFilterDelegate filterDelegate)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class584 class584 = new EntitySelector.Class584(referencePoint, testSquareWidth, filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, config, transformation))
        model.Draw(context, (IWireframeGraphicsFactory) class584);
      return (IList<RenderedEntityInfo>) class584.Entities;
    }

    public static IList<RenderedEntityInfo> GetEntitiesCloseToPoint(
      DxfModel model,
      IEnumerable<DxfEntity> entities,
      GraphicsConfig config,
      Matrix4D transformation,
      WW.Math.Point2D referencePoint,
      double testSquareWidth,
      EntityFilterDelegate filterDelegate)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class584 class584 = new EntitySelector.Class584(referencePoint, 0.5 * testSquareWidth, filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, config, transformation))
      {
        foreach (DxfEntity entity in entities)
          entity.Draw(context, (IWireframeGraphicsFactory) class584);
      }
      return (IList<RenderedEntityInfo>) class584.Entities;
    }

    public static IList<RenderedEntityInfo> GetEntitiesCloseToPoint(
      DxfModel model,
      DxfLayout layout,
      GraphicsConfig config,
      Matrix4D transformation,
      WW.Math.Point2D referencePoint,
      double testSquareWidth,
      EntityFilterDelegate filterDelegate)
    {
      return EntitySelector.GetEntitiesCloseToPoint(model, layout, (ICollection<DxfViewport>) layout.Viewports, config, transformation, referencePoint, testSquareWidth, filterDelegate);
    }

    public static IList<RenderedEntityInfo> GetEntitiesCloseToPoint(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D transformation,
      WW.Math.Point2D referencePoint,
      double testSquareWidth)
    {
      return EntitySelector.GetEntitiesCloseToPoint(model, layout, viewports, config, transformation, referencePoint, testSquareWidth, (EntityFilterDelegate) null);
    }

    public static IList<RenderedEntityInfo> GetEntitiesCloseToPoint(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D transformation,
      WW.Math.Point2D referencePoint,
      double testSquareWidth,
      EntityFilterDelegate filterDelegate)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class584 class584 = new EntitySelector.Class584(referencePoint, 0.5 * testSquareWidth, filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.PaperToPaperSpace(model, layout, config, transformation))
        layout.Draw(context, (IWireframeGraphicsFactory) class584);
      if (viewports == null)
        viewports = (ICollection<DxfViewport>) layout.Viewports;
      foreach (DxfViewport viewport in (IEnumerable<DxfViewport>) viewports)
      {
        if (viewport.ModelSpaceVisible)
        {
          using (DrawContext.Wireframe.ModelToPaperSpace modelToPaperSpace = new DrawContext.Wireframe.ModelToPaperSpace(model, layout, config, viewport, transformation))
            model.Draw((DrawContext.Wireframe) modelToPaperSpace, (IWireframeGraphicsFactory) class584);
        }
      }
      return (IList<RenderedEntityInfo>) class584.Entities;
    }

    public static IList<RenderedEntityInfo> GetEntitiesCloseToPoint(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D transformation,
      WW.Math.Point2D referencePoint,
      double testSquareWidth)
    {
      return EntitySelector.GetEntitiesCloseToPoint(model, config, transformation, referencePoint, testSquareWidth, (EntityFilterDelegate) null);
    }

    public static IList<RenderedEntityInfo> GetEntitiesCloseToPoint(
      DxfModel model,
      DxfLayout layout,
      GraphicsConfig config,
      Matrix4D transformation,
      WW.Math.Point2D referencePoint,
      double testSquareWidth)
    {
      return EntitySelector.GetEntitiesCloseToPoint(model, layout, config, transformation, referencePoint, testSquareWidth, (EntityFilterDelegate) null);
    }

    public static IList<RenderedEntityInfo> GetEntitiesInRectangle(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D transformation,
      Rectangle2D rectangle,
      EntityFilterDelegate filterDelegate)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class583 class583 = new EntitySelector.Class583(rectangle, filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, config, transformation))
        model.Draw(context, (IWireframeGraphicsFactory) class583);
      return (IList<RenderedEntityInfo>) class583.Entities;
    }

    public static IList<RenderedEntityInfo> GetEntitiesInRectangle(
      DxfModel model,
      IEnumerable<DxfEntity> entities,
      GraphicsConfig config,
      Matrix4D transformation,
      Rectangle2D rectangle,
      EntityFilterDelegate filterDelegate)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class583 class583 = new EntitySelector.Class583(rectangle, filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, config, transformation))
      {
        foreach (DxfEntity entity in entities)
          entity.Draw(context, (IWireframeGraphicsFactory) class583);
      }
      return (IList<RenderedEntityInfo>) class583.Entities;
    }

    public static IList<RenderedEntityInfo> GetEntitiesInRectangle(
      DxfModel model,
      DxfLayout layout,
      GraphicsConfig config,
      Matrix4D transformation,
      Rectangle2D rectangle,
      EntityFilterDelegate filterDelegate)
    {
      return EntitySelector.GetEntitiesInRectangle(model, layout, (ICollection<DxfViewport>) layout.Viewports, config, transformation, rectangle, filterDelegate);
    }

    public static IList<RenderedEntityInfo> GetEntitiesInRectangle(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D transformation,
      Rectangle2D rectangle)
    {
      return EntitySelector.GetEntitiesInRectangle(model, layout, viewports, config, transformation, rectangle, (EntityFilterDelegate) null);
    }

    public static IList<RenderedEntityInfo> GetEntitiesInRectangle(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D transformation,
      Rectangle2D rectangle,
      EntityFilterDelegate filterDelegate)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class583 class583 = new EntitySelector.Class583(rectangle, filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.PaperToPaperSpace(model, layout, config, transformation))
        layout.Draw(context, (IWireframeGraphicsFactory) class583);
      if (viewports == null)
        viewports = (ICollection<DxfViewport>) layout.Viewports;
      foreach (DxfViewport viewport in (IEnumerable<DxfViewport>) viewports)
      {
        if (viewport.ModelSpaceVisible)
        {
          using (DrawContext.Wireframe.ModelToPaperSpace modelToPaperSpace = new DrawContext.Wireframe.ModelToPaperSpace(model, layout, config, viewport, transformation))
            model.Draw((DrawContext.Wireframe) modelToPaperSpace, (IWireframeGraphicsFactory) class583);
        }
      }
      return (IList<RenderedEntityInfo>) class583.Entities;
    }

    public static IList<RenderedEntityInfo> GetEntitiesInRectangle(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D transformation,
      Rectangle2D rectangle)
    {
      return EntitySelector.GetEntitiesInRectangle(model, config, transformation, rectangle, (EntityFilterDelegate) null);
    }

    public static IList<RenderedEntityInfo> GetEntitiesInRectangle(
      DxfModel model,
      DxfLayout layout,
      GraphicsConfig config,
      Matrix4D transformation,
      Rectangle2D rectangle)
    {
      return EntitySelector.GetEntitiesInRectangle(model, layout, config, transformation, rectangle, (EntityFilterDelegate) null);
    }

    public static IList<RenderedEntityInfo> GetEntitiesPartiallyInRectangle(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D transformation,
      Rectangle2D rectangle,
      EntityFilterDelegate filterDelegate)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class585 class585 = new EntitySelector.Class585(rectangle, filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, config, transformation))
        model.Draw(context, (IWireframeGraphicsFactory) class585);
      return (IList<RenderedEntityInfo>) class585.Entities;
    }

    public static IList<RenderedEntityInfo> GetEntitiesPartiallyInRectangle(
      DxfModel model,
      IEnumerable<DxfEntity> entities,
      GraphicsConfig config,
      Matrix4D transformation,
      Rectangle2D rectangle,
      EntityFilterDelegate filterDelegate)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class585 class585 = new EntitySelector.Class585(rectangle, filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, config, transformation))
      {
        foreach (DxfEntity entity in entities)
          entity.Draw(context, (IWireframeGraphicsFactory) class585);
      }
      return (IList<RenderedEntityInfo>) class585.Entities;
    }

    public static IList<RenderedEntityInfo> GetEntitiesPartiallyInRectangle(
      DxfModel model,
      DxfLayout layout,
      GraphicsConfig config,
      Matrix4D transformation,
      Rectangle2D rectangle,
      EntityFilterDelegate filterDelegate)
    {
      return EntitySelector.GetEntitiesPartiallyInRectangle(model, layout, (ICollection<DxfViewport>) layout.Viewports, config, transformation, rectangle, filterDelegate);
    }

    public static IList<RenderedEntityInfo> GetEntitiesPartiallyInRectangle(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D transformation,
      Rectangle2D rectangle)
    {
      return EntitySelector.GetEntitiesPartiallyInRectangle(model, layout, viewports, config, transformation, rectangle, (EntityFilterDelegate) null);
    }

    public static IList<RenderedEntityInfo> GetEntitiesPartiallyInRectangle(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D transformation,
      Rectangle2D rectangle,
      EntityFilterDelegate filterDelegate)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class585 class585 = new EntitySelector.Class585(rectangle, filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.PaperToPaperSpace(model, layout, config, transformation))
        layout.Draw(context, (IWireframeGraphicsFactory) class585);
      if (viewports == null)
        viewports = (ICollection<DxfViewport>) layout.Viewports;
      foreach (DxfViewport viewport in (IEnumerable<DxfViewport>) viewports)
      {
        if (viewport.ModelSpaceVisible)
        {
          using (DrawContext.Wireframe.ModelToPaperSpace modelToPaperSpace = new DrawContext.Wireframe.ModelToPaperSpace(model, layout, config, viewport, transformation))
            model.Draw((DrawContext.Wireframe) modelToPaperSpace, (IWireframeGraphicsFactory) class585);
        }
      }
      return (IList<RenderedEntityInfo>) class585.Entities;
    }

    public static IList<RenderedEntityInfo> GetEntitiesPartiallyInRectangle(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D transformation,
      Rectangle2D rectangle)
    {
      return EntitySelector.GetEntitiesPartiallyInRectangle(model, config, transformation, rectangle, (EntityFilterDelegate) null);
    }

    public static IList<RenderedEntityInfo> GetEntitiesPartiallyInRectangle(
      DxfModel model,
      DxfLayout layout,
      GraphicsConfig config,
      Matrix4D transformation,
      Rectangle2D rectangle)
    {
      return EntitySelector.GetEntitiesPartiallyInRectangle(model, layout, config, transformation, rectangle, (EntityFilterDelegate) null);
    }

    public static IList<RenderedEntityInfo> GetFilteredEntities(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D transformation,
      EntityFilterDelegate filterDelegate)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class586 class586 = new EntitySelector.Class586(filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, config, transformation))
        model.Draw(context, (IWireframeGraphicsFactory) class586);
      return (IList<RenderedEntityInfo>) class586.Entities;
    }

    public static IList<RenderedEntityInfo> GetFilteredEntities(
      DxfModel model,
      IEnumerable<DxfEntity> entities,
      GraphicsConfig config,
      Matrix4D transformation,
      EntityFilterDelegate filterDelegate)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class586 class586 = new EntitySelector.Class586(filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, config, transformation))
      {
        foreach (DxfEntity entity in entities)
          entity.Draw(context, (IWireframeGraphicsFactory) class586);
      }
      return (IList<RenderedEntityInfo>) class586.Entities;
    }

    public static IList<RenderedEntityInfo> GetFilteredEntities(
      DxfModel model,
      DxfLayout layout,
      GraphicsConfig config,
      Matrix4D transformation,
      EntityFilterDelegate filterDelegate)
    {
      return EntitySelector.GetFilteredEntities(model, layout, (ICollection<DxfViewport>) layout.Viewports, config, transformation, filterDelegate);
    }

    public static IList<RenderedEntityInfo> GetFilteredEntities(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D transformation,
      EntityFilterDelegate filterDelegate)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class586 class586 = new EntitySelector.Class586(filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.PaperToPaperSpace(model, layout, config, transformation))
        layout.Draw(context, (IWireframeGraphicsFactory) class586);
      if (viewports == null)
        viewports = (ICollection<DxfViewport>) layout.Viewports;
      foreach (DxfViewport viewport in (IEnumerable<DxfViewport>) viewports)
      {
        if (viewport.ModelSpaceVisible)
        {
          using (DrawContext.Wireframe.ModelToPaperSpace modelToPaperSpace = new DrawContext.Wireframe.ModelToPaperSpace(model, layout, config, viewport, transformation))
            model.Draw((DrawContext.Wireframe) modelToPaperSpace, (IWireframeGraphicsFactory) class586);
        }
      }
      return (IList<RenderedEntityInfo>) class586.Entities;
    }

    public static IList<RenderedEntityInfo> GetFilteredEntities(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D transformation,
      EntitySelector.IFilter filter)
    {
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, config, transformation))
        model.Draw(context, (IWireframeGraphicsFactory) filter);
      return (IList<RenderedEntityInfo>) filter.Entities;
    }

    public static IList<RenderedEntityInfo> GetFilteredEntities(
      DxfModel model,
      DxfLayout layout,
      GraphicsConfig config,
      Matrix4D transformation,
      EntitySelector.IFilter filter)
    {
      return EntitySelector.GetFilteredEntities(model, layout, (ICollection<DxfViewport>) layout.Viewports, config, transformation, filter);
    }

    public static IList<RenderedEntityInfo> GetFilteredEntities(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D transformation,
      EntitySelector.IFilter filter)
    {
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.PaperToPaperSpace(model, layout, config, transformation))
        layout.Draw(context, (IWireframeGraphicsFactory) filter);
      if (viewports == null)
        viewports = (ICollection<DxfViewport>) layout.Viewports;
      foreach (DxfViewport viewport in (IEnumerable<DxfViewport>) viewports)
      {
        if (viewport.ModelSpaceVisible)
        {
          using (DrawContext.Wireframe.ModelToPaperSpace modelToPaperSpace = new DrawContext.Wireframe.ModelToPaperSpace(model, layout, config, viewport, transformation))
            model.Draw((DrawContext.Wireframe) modelToPaperSpace, (IWireframeGraphicsFactory) filter);
        }
      }
      return (IList<RenderedEntityInfo>) filter.Entities;
    }

    public static bool AlwaysTrueEntityFilter(DrawContext drawContext, DxfEntity entity)
    {
      return true;
    }

    public static RenderedEntityInfo GetRenderedEntityInfo(
      DxfEntity entity,
      DrawContext.Wireframe drawContext)
    {
      RenderedEntityInfo renderedEntityInfo1 = new RenderedEntityInfo(entity, drawContext.GetTransformer().Matrix);
      RenderedEntityInfo renderedEntityInfo2 = renderedEntityInfo1;
      DxfEntity dxfEntity = (DxfEntity) null;
      for (; drawContext != null; drawContext = (DrawContext.Wireframe) drawContext.ParentContext)
      {
        if (drawContext.BlockContext != null && drawContext.BlockContext != dxfEntity)
        {
          RenderedEntityInfo parent = new RenderedEntityInfo(drawContext.BlockContext, ((DrawContext.Wireframe) drawContext.ParentContext).GetTransformer().Matrix);
          renderedEntityInfo1.SetParent(parent);
          renderedEntityInfo1 = parent;
          dxfEntity = drawContext.BlockContext;
        }
      }
      return renderedEntityInfo2;
    }

    public static EntitySelector.IFilter CreateClosestEntityFilter(
      WW.Math.Point2D referencePoint,
      EntityFilterDelegate entityFilterDelegate)
    {
      return (EntitySelector.IFilter) new EntitySelector.Class582(referencePoint, entityFilterDelegate);
    }

    public static EntitySelector.IFilter CreateEntityInRectangleFilter(
      Rectangle2D rectangle,
      EntityFilterDelegate entityFilterDelegate)
    {
      return (EntitySelector.IFilter) new EntitySelector.Class583(rectangle, entityFilterDelegate);
    }

    public static EntitySelector.IFilter CreateEntityPartiallyInSquareFilter(
      WW.Math.Point2D center,
      double halfWidth,
      EntityFilterDelegate entityFilterDelegate)
    {
      return (EntitySelector.IFilter) new EntitySelector.Class584(center, halfWidth, entityFilterDelegate);
    }

    public interface IFilter : IWireframeGraphicsFactory
    {
      List<RenderedEntityInfo> Entities { get; }
    }

    internal abstract class Class581 : IWireframeGraphicsFactory, EntitySelector.IFilter
    {
      public virtual void BeginEntity(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
      }

      public virtual void EndEntity()
      {
      }

      public void BeginInsert(DxfInsert insert)
      {
      }

      public void EndInsert()
      {
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

      public abstract List<RenderedEntityInfo> Entities { get; }

      public void CreateDot(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D position)
      {
        throw new NotImplementedException();
      }

      public void CreateLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D start,
        Vector4D end)
      {
        throw new NotImplementedException();
      }

      public void CreateRay(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Segment4D segment)
      {
        throw new NotImplementedException();
      }

      public void CreateXLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Vector4D? startPoint,
        Segment4D segment)
      {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
      }

      public void CreateShape(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IShape4D shape)
      {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
      }
    }

    internal class Class582 : EntitySelector.Class581, IWireframeGraphicsFactory
    {
      private Dictionary<DxfEntity, DxfEntity> dictionary_0 = new Dictionary<DxfEntity, DxfEntity>();
      private List<RenderedEntityInfo> list_0 = new List<RenderedEntityInfo>();
      private double double_0 = double.MaxValue;
      private WW.Math.Point2D point2D_0;
      private EntityFilterDelegate entityFilterDelegate_0;

      public Class582(WW.Math.Point2D referencePoint, EntityFilterDelegate filter)
      {
        this.point2D_0 = referencePoint;
        this.entityFilterDelegate_0 = filter;
      }

      public override List<RenderedEntityInfo> Entities
      {
        get
        {
          return this.list_0;
        }
      }

      public List<RenderedEntityInfo> ClosestEntities
      {
        get
        {
          return this.list_0;
        }
      }

      public double ClosestDistance
      {
        get
        {
          return System.Math.Sqrt(this.double_0);
        }
      }

      public new void CreateDot(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D position)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        double lengthSquared = ((WW.Math.Point2D) position - this.point2D_0).GetLengthSquared();
        this.method_0(entity, drawContext, lengthSquared);
      }

      public new void CreateLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D start,
        Vector4D end)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        double distanceSquared = new Segment2D((WW.Math.Point2D) start, (WW.Math.Point2D) end).GetDistanceSquared(this.point2D_0);
        this.method_0(entity, drawContext, distanceSquared);
      }

      public new void CreateRay(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Segment4D segment)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        double distanceSquared = new Segment2D((WW.Math.Point2D) segment.Start, (WW.Math.Point2D) segment.End).GetDistanceSquared(this.point2D_0);
        this.method_0(entity, drawContext, distanceSquared);
      }

      public new void CreateXLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Vector4D? startPoint,
        Segment4D segment)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        double distanceSquared = new Segment2D((WW.Math.Point2D) segment.Start, (WW.Math.Point2D) segment.End).GetDistanceSquared(this.point2D_0);
        this.method_0(entity, drawContext, distanceSquared);
      }

      public new void CreatePath(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IList<Polyline4D> polylines,
        bool fill,
        bool correctForBackgroundColor)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        if (fill)
        {
          foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polylines)
          {
            if (!Class749.IsInside(this.point2D_0, polyline))
            {
              double squaredDistance = Class749.smethod_3(polyline, this.point2D_0);
              this.method_0(entity, drawContext, squaredDistance);
            }
            else
            {
              this.method_0(entity, drawContext, 0.0);
              break;
            }
          }
        }
        else
        {
          foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polylines)
          {
            double squaredDistance = Class749.smethod_3(polyline, this.point2D_0);
            this.method_0(entity, drawContext, squaredDistance);
          }
        }
      }

      public new void CreatePathAsOne(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IList<Polyline4D> polylines,
        bool fill,
        bool correctForBackgroundColor)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        if (fill && Class749.IsInside(this.point2D_0, (IEnumerable<Polyline4D>) polylines))
        {
          this.method_0(entity, drawContext, 0.0);
        }
        else
        {
          foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polylines)
          {
            double squaredDistance = Class749.smethod_3(polyline, this.point2D_0);
            this.method_0(entity, drawContext, squaredDistance);
          }
        }
      }

      public new void CreateShape(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IShape4D shape)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        IList<Polyline2D> flattened = (IList<Polyline2D>) ShapeTool.GetFlattened(shape.ToShape2D(Matrix4D.Identity), drawContext.Config.ShapeFlattenEpsilon);
        if (shape.IsFilled && Polygon2D.IsInsidePolygons(this.point2D_0, (IEnumerator) flattened.GetEnumerator()))
        {
          this.method_0(entity, drawContext, 0.0);
        }
        else
        {
          foreach (Polyline2D polyline in (IEnumerable<Polyline2D>) flattened)
          {
            double squaredDistance = Class749.smethod_4(polyline, this.point2D_0);
            this.method_0(entity, drawContext, squaredDistance);
          }
        }
      }

      public new void CreateImage(
        DxfRasterImage rasterImage,
        DrawContext.Wireframe drawContext,
        Polyline4D clipPolygon,
        Polyline4D imageBoundary,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, (DxfEntity) rasterImage))
          return;
        double squaredDistance = Class749.smethod_3(imageBoundary, this.point2D_0);
        this.method_0((DxfEntity) rasterImage, drawContext, squaredDistance);
      }

      public new void CreateScalableImage(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        IBitmapProvider bitmapProvider,
        Polyline4D clipPolygon,
        Size2D displaySize,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        Polyline4D polyline = new Polyline4D(4, true);
        Vector4D vector4D1 = displaySize.X * transformedXAxis;
        Vector4D vector4D2 = displaySize.Y * transformedYAxis;
        polyline.Add(transformedOrigin);
        polyline.Add(transformedOrigin + vector4D1);
        polyline.Add(transformedOrigin + vector4D2);
        polyline.Add(transformedOrigin + vector4D1 + vector4D2);
        double squaredDistance = Class749.smethod_3(polyline, this.point2D_0);
        this.method_0(entity, drawContext, squaredDistance);
      }

      private void method_0(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        double squaredDistance)
      {
        if (squaredDistance == this.double_0)
        {
          if (this.dictionary_0.ContainsKey(entity))
            return;
          this.dictionary_0.Add(entity, entity);
          this.list_0.Add(EntitySelector.GetRenderedEntityInfo(entity, drawContext));
        }
        else
        {
          if (squaredDistance >= this.double_0)
            return;
          this.double_0 = squaredDistance;
          this.list_0.Clear();
          this.list_0.Add(EntitySelector.GetRenderedEntityInfo(entity, drawContext));
          this.dictionary_0.Clear();
          this.dictionary_0.Add(entity, entity);
        }
      }
    }

    internal class Class583 : EntitySelector.Class581, IWireframeGraphicsFactory
    {
      private Dictionary<DxfEntity, List<RenderedEntityInfo>> dictionary_0 = new Dictionary<DxfEntity, List<RenderedEntityInfo>>();
      private List<RenderedEntityInfo> list_0 = new List<RenderedEntityInfo>();
      private Rectangle2D rectangle2D_0;
      private EntityFilterDelegate entityFilterDelegate_0;

      public Class583(Rectangle2D rectangle, EntityFilterDelegate filter)
      {
        this.rectangle2D_0 = rectangle;
        this.entityFilterDelegate_0 = filter;
      }

      public override List<RenderedEntityInfo> Entities
      {
        get
        {
          return this.list_0;
        }
      }

      public new void CreateDot(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D position)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity) || !this.rectangle2D_0.IsInside((WW.Math.Point2D) position))
          return;
        this.method_2(entity, drawContext);
      }

      public new void CreateLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D start,
        Vector4D end)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        Segment2D segment2D = new Segment2D((WW.Math.Point2D) start, (WW.Math.Point2D) end);
        if (!this.rectangle2D_0.IsInside(segment2D.Start) || !this.rectangle2D_0.IsInside(segment2D.End))
          return;
        this.method_2(entity, drawContext);
      }

      public new void CreateRay(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Segment4D segment)
      {
      }

      public new void CreateXLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Vector4D? startPoint,
        Segment4D segment)
      {
      }

      public new void CreatePath(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IList<Polyline4D> polylines,
        bool fill,
        bool correctForBackgroundColor)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        this.method_1(entity, drawContext, polylines);
      }

      public new void CreatePathAsOne(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IList<Polyline4D> polylines,
        bool fill,
        bool correctForBackgroundColor)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        this.method_1(entity, drawContext, polylines);
      }

      public new void CreateShape(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IShape4D shape)
      {
        this.CreatePathAsOne(entity, drawContext, color, forText, shape.ToPolylines4D(drawContext.Config.ShapeFlattenEpsilon), shape.IsFilled, true);
      }

      public new void CreateImage(
        DxfRasterImage rasterImage,
        DrawContext.Wireframe drawContext,
        Polyline4D clipPolygon,
        Polyline4D imageBoundary,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, (DxfEntity) rasterImage))
          return;
        this.method_0((DxfEntity) rasterImage, drawContext, imageBoundary);
      }

      public new void CreateScalableImage(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        IBitmapProvider bitmapProvider,
        Polyline4D clipPolygon,
        Size2D displaySize,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        Polyline4D polyline = new Polyline4D(4, true);
        Vector4D vector4D1 = displaySize.X * transformedXAxis;
        Vector4D vector4D2 = displaySize.Y * transformedYAxis;
        polyline.Add(transformedOrigin);
        polyline.Add(transformedOrigin + vector4D1);
        polyline.Add(transformedOrigin + vector4D2);
        polyline.Add(transformedOrigin + vector4D1 + vector4D2);
        this.method_0(entity, drawContext, polyline);
      }

      private void method_0(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        Polyline4D polyline)
      {
        foreach (Vector4D vector4D in (List<Vector4D>) polyline)
        {
          if (!this.rectangle2D_0.IsInside((WW.Math.Point2D) vector4D))
            return;
        }
        this.method_2(entity, drawContext);
      }

      private void method_1(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        IList<Polyline4D> polylines)
      {
        foreach (List<Vector4D> polyline in (IEnumerable<Polyline4D>) polylines)
        {
          foreach (Vector4D vector4D in polyline)
          {
            if (!this.rectangle2D_0.IsInside((WW.Math.Point2D) vector4D))
              return;
          }
        }
        this.method_2(entity, drawContext);
      }

      private void method_2(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
        RenderedEntityInfo renderedEntityInfo1 = EntitySelector.GetRenderedEntityInfo(entity, drawContext);
        List<RenderedEntityInfo> renderedEntityInfoList;
        if (this.dictionary_0.TryGetValue(entity, out renderedEntityInfoList))
        {
          foreach (RenderedEntityInfo renderedEntityInfo2 in renderedEntityInfoList)
          {
            if (renderedEntityInfo2.method_0(renderedEntityInfo1))
              return;
          }
        }
        else
        {
          renderedEntityInfoList = new List<RenderedEntityInfo>();
          this.dictionary_0.Add(entity, renderedEntityInfoList);
        }
        renderedEntityInfoList.Add(renderedEntityInfo1);
        this.list_0.Add(renderedEntityInfo1);
      }
    }

    internal class Class584 : EntitySelector.Class581, IWireframeGraphicsFactory
    {
      private Dictionary<DxfEntity, DxfEntity> dictionary_0 = new Dictionary<DxfEntity, DxfEntity>();
      private List<RenderedEntityInfo> list_0 = new List<RenderedEntityInfo>();
      private Rectangle2D rectangle2D_0;
      private WW.Math.Point2D point2D_0;
      private double double_0;
      private EntityFilterDelegate entityFilterDelegate_0;

      public Class584(WW.Math.Point2D center, double halfWidth, EntityFilterDelegate filter)
      {
        this.point2D_0 = center;
        this.double_0 = halfWidth;
        this.entityFilterDelegate_0 = filter;
        this.rectangle2D_0 = new Rectangle2D(center.X - halfWidth, center.Y - halfWidth, center.X + halfWidth, center.Y + halfWidth);
      }

      public override List<RenderedEntityInfo> Entities
      {
        get
        {
          return this.list_0;
        }
      }

      public new void CreateDot(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D position)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity) || !this.rectangle2D_0.IsInside((WW.Math.Point2D) position))
          return;
        this.method_4(entity, drawContext);
      }

      public new void CreateLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D start,
        Vector4D end)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity) || !this.method_0(new Segment2D((WW.Math.Point2D) start, (WW.Math.Point2D) end).GetClosestPoint(this.point2D_0)))
          return;
        this.method_4(entity, drawContext);
      }

      public new void CreateRay(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Segment4D segment)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity) || !this.method_0(new Segment2D((WW.Math.Point2D) segment.Start, (WW.Math.Point2D) segment.End).GetClosestPoint(this.point2D_0)))
          return;
        this.method_4(entity, drawContext);
      }

      public new void CreateXLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Vector4D? startPoint,
        Segment4D segment)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity) || !this.method_0(new Segment2D((WW.Math.Point2D) segment.Start, (WW.Math.Point2D) segment.End).GetClosestPoint(this.point2D_0)))
          return;
        this.method_4(entity, drawContext);
      }

      public new void CreatePath(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IList<Polyline4D> polylines,
        bool fill,
        bool correctForBackgroundColor)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        this.method_3(entity, drawContext, polylines);
      }

      public new void CreatePathAsOne(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IList<Polyline4D> polylines,
        bool fill,
        bool correctForBackgroundColor)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        this.method_3(entity, drawContext, polylines);
      }

      public new void CreateShape(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IShape4D shape)
      {
        this.CreatePathAsOne(entity, drawContext, color, forText, shape.ToPolylines4D(drawContext.Config.ShapeFlattenEpsilon), shape.IsFilled, true);
      }

      public new void CreateImage(
        DxfRasterImage rasterImage,
        DrawContext.Wireframe drawContext,
        Polyline4D clipPolygon,
        Polyline4D imageBoundary,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, (DxfEntity) rasterImage))
          return;
        this.method_2((DxfEntity) rasterImage, drawContext, imageBoundary);
      }

      public new void CreateScalableImage(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        IBitmapProvider bitmapProvider,
        Polyline4D clipPolygon,
        Size2D displaySize,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        Polyline4D polyline = new Polyline4D(4, true);
        Vector4D vector4D1 = displaySize.X * transformedXAxis;
        Vector4D vector4D2 = displaySize.Y * transformedYAxis;
        polyline.Add(transformedOrigin);
        polyline.Add(transformedOrigin + vector4D1);
        polyline.Add(transformedOrigin + vector4D2);
        polyline.Add(transformedOrigin + vector4D1 + vector4D2);
        this.method_2(entity, drawContext, polyline);
      }

      private bool method_0(WW.Math.Point2D closestPoint)
      {
        if (System.Math.Abs(closestPoint.X - this.point2D_0.X) <= this.double_0)
          return System.Math.Abs(closestPoint.Y - this.point2D_0.Y) <= this.double_0;
        return false;
      }

      private bool method_1(Polyline4D polyline)
      {
        bool flag = false;
        if (polyline.Count > 0)
        {
          if (polyline.Count > 1)
          {
            if (polyline.Closed)
            {
              WW.Math.Point2D start = (WW.Math.Point2D) polyline[polyline.Count - 1];
              for (int index = 0; index < polyline.Count; ++index)
              {
                WW.Math.Point2D end = (WW.Math.Point2D) polyline[index];
                if (!this.method_0(new Segment2D(start, end).GetClosestPoint(this.point2D_0)))
                {
                  start = end;
                }
                else
                {
                  flag = true;
                  break;
                }
              }
            }
            else
            {
              WW.Math.Point2D start = (WW.Math.Point2D) polyline[0];
              for (int index = 1; index < polyline.Count; ++index)
              {
                WW.Math.Point2D end = (WW.Math.Point2D) polyline[index];
                if (!this.method_0(new Segment2D(start, end).GetClosestPoint(this.point2D_0)))
                {
                  start = end;
                }
                else
                {
                  flag = true;
                  break;
                }
              }
            }
          }
          else if (this.rectangle2D_0.IsInside((WW.Math.Point2D) polyline[0]))
            flag = true;
        }
        return flag;
      }

      private void method_2(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        Polyline4D polyline)
      {
        if (!this.method_1(polyline))
          return;
        this.method_4(entity, drawContext);
      }

      private void method_3(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        IList<Polyline4D> polylines)
      {
        bool flag = false;
        foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polylines)
        {
          if (flag = this.method_1(polyline))
            break;
        }
        if (!flag)
          return;
        this.method_4(entity, drawContext);
      }

      private void method_4(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
        if (this.dictionary_0.ContainsKey(entity))
          return;
        this.dictionary_0.Add(entity, entity);
        this.list_0.Add(EntitySelector.GetRenderedEntityInfo(entity, drawContext));
      }
    }

    internal class Class585 : EntitySelector.Class581, IWireframeGraphicsFactory
    {
      private Dictionary<DxfEntity, DxfEntity> dictionary_0 = new Dictionary<DxfEntity, DxfEntity>();
      private List<RenderedEntityInfo> list_0 = new List<RenderedEntityInfo>();
      private Rectangle2D rectangle2D_0;
      private WW.Math.Point2D point2D_0;
      private double double_0;
      private double double_1;
      private EntityFilterDelegate entityFilterDelegate_0;

      public Class585(Rectangle2D rectangle, EntityFilterDelegate filter)
      {
        this.point2D_0 = rectangle.Center;
        this.double_0 = 0.5 * rectangle.Width;
        this.double_1 = 0.5 * rectangle.Height;
        this.entityFilterDelegate_0 = filter;
        this.rectangle2D_0 = rectangle;
      }

      public override List<RenderedEntityInfo> Entities
      {
        get
        {
          return this.list_0;
        }
      }

      public new void CreateDot(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D position)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity) || !this.rectangle2D_0.IsInside((WW.Math.Point2D) position))
          return;
        this.method_4(entity, drawContext);
      }

      public new void CreateLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D start,
        Vector4D end)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity) || !this.method_0(new Segment2D((WW.Math.Point2D) start, (WW.Math.Point2D) end).GetClosestPoint(this.point2D_0)))
          return;
        this.method_4(entity, drawContext);
      }

      public new void CreateRay(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Segment4D segment)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity) || !this.method_0(new Segment2D((WW.Math.Point2D) segment.Start, (WW.Math.Point2D) segment.End).GetClosestPoint(this.point2D_0)))
          return;
        this.method_4(entity, drawContext);
      }

      public new void CreateXLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Vector4D? startPoint,
        Segment4D segment)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity) || !this.method_0(new Segment2D((WW.Math.Point2D) segment.Start, (WW.Math.Point2D) segment.End).GetClosestPoint(this.point2D_0)))
          return;
        this.method_4(entity, drawContext);
      }

      public new void CreatePath(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IList<Polyline4D> polylines,
        bool fill,
        bool correctForBackgroundColor)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        this.method_3(entity, drawContext, polylines);
      }

      public new void CreatePathAsOne(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IList<Polyline4D> polylines,
        bool fill,
        bool correctForBackgroundColor)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        this.method_3(entity, drawContext, polylines);
      }

      public new void CreateShape(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IShape4D shape)
      {
        this.CreatePathAsOne(entity, drawContext, color, forText, shape.ToPolylines4D(drawContext.Config.ShapeFlattenEpsilon), shape.IsFilled, true);
      }

      public new void CreateImage(
        DxfRasterImage rasterImage,
        DrawContext.Wireframe drawContext,
        Polyline4D clipPolygon,
        Polyline4D imageBoundary,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, (DxfEntity) rasterImage))
          return;
        this.method_2((DxfEntity) rasterImage, drawContext, imageBoundary);
      }

      public new void CreateScalableImage(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        IBitmapProvider bitmapProvider,
        Polyline4D clipPolygon,
        Size2D displaySize,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        Polyline4D polyline = new Polyline4D(4, true);
        Vector4D vector4D1 = displaySize.X * transformedXAxis;
        Vector4D vector4D2 = displaySize.Y * transformedYAxis;
        polyline.Add(transformedOrigin);
        polyline.Add(transformedOrigin + vector4D1);
        polyline.Add(transformedOrigin + vector4D2);
        polyline.Add(transformedOrigin + vector4D1 + vector4D2);
        this.method_2(entity, drawContext, polyline);
      }

      private bool method_0(WW.Math.Point2D closestPoint)
      {
        if (System.Math.Abs(closestPoint.X - this.point2D_0.X) <= this.double_0)
          return System.Math.Abs(closestPoint.Y - this.point2D_0.Y) <= this.double_1;
        return false;
      }

      private bool method_1(Polyline4D polyline)
      {
        bool flag = false;
        if (polyline.Count > 0)
        {
          if (polyline.Count > 1)
          {
            if (polyline.Closed)
            {
              WW.Math.Point2D start = (WW.Math.Point2D) polyline[polyline.Count - 1];
              for (int index = 0; index < polyline.Count; ++index)
              {
                WW.Math.Point2D end = (WW.Math.Point2D) polyline[index];
                if (!this.method_0(new Segment2D(start, end).GetClosestPoint(this.point2D_0)))
                {
                  start = end;
                }
                else
                {
                  flag = true;
                  break;
                }
              }
            }
            else
            {
              WW.Math.Point2D start = (WW.Math.Point2D) polyline[0];
              for (int index = 1; index < polyline.Count; ++index)
              {
                WW.Math.Point2D end = (WW.Math.Point2D) polyline[index];
                if (!this.method_0(new Segment2D(start, end).GetClosestPoint(this.point2D_0)))
                {
                  start = end;
                }
                else
                {
                  flag = true;
                  break;
                }
              }
            }
          }
          else if (this.rectangle2D_0.IsInside((WW.Math.Point2D) polyline[0]))
            flag = true;
        }
        return flag;
      }

      private void method_2(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        Polyline4D polyline)
      {
        if (!this.method_1(polyline))
          return;
        this.method_4(entity, drawContext);
      }

      private void method_3(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        IList<Polyline4D> polylines)
      {
        bool flag = false;
        foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polylines)
        {
          if (flag = this.method_1(polyline))
            break;
        }
        if (!flag)
          return;
        this.method_4(entity, drawContext);
      }

      private void method_4(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
        if (this.dictionary_0.ContainsKey(entity))
          return;
        this.dictionary_0.Add(entity, entity);
        this.list_0.Add(EntitySelector.GetRenderedEntityInfo(entity, drawContext));
      }
    }

    internal class Class586 : EntitySelector.Class581, IWireframeGraphicsFactory, EntitySelector.IFilter
    {
      private HashSet<DxfEntity> hashSet_0 = new HashSet<DxfEntity>();
      private List<RenderedEntityInfo> list_0 = new List<RenderedEntityInfo>();
      private EntityFilterDelegate entityFilterDelegate_0;

      public Class586(EntityFilterDelegate filter)
      {
        this.entityFilterDelegate_0 = filter;
      }

      public override List<RenderedEntityInfo> Entities
      {
        get
        {
          return this.list_0;
        }
      }

      public override void BeginEntity(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        this.method_0(entity, drawContext);
      }

      public new void CreateDot(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D position)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        this.method_0(entity, drawContext);
      }

      public new void CreateLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D start,
        Vector4D end)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        this.method_0(entity, drawContext);
      }

      public new void CreateRay(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Segment4D segment)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        this.method_0(entity, drawContext);
      }

      public new void CreateXLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Vector4D? startPoint,
        Segment4D segment)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        this.method_0(entity, drawContext);
      }

      public new void CreatePath(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IList<Polyline4D> polylines,
        bool fill,
        bool correctForBackgroundColor)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        this.method_0(entity, drawContext);
      }

      public new void CreatePathAsOne(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IList<Polyline4D> polylines,
        bool fill,
        bool correctForBackgroundColor)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        this.method_0(entity, drawContext);
      }

      public new void CreateShape(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IShape4D shape)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        this.method_0(entity, drawContext);
      }

      public new void CreateImage(
        DxfRasterImage rasterImage,
        DrawContext.Wireframe drawContext,
        Polyline4D clipPolygon,
        Polyline4D imageBoundary,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, (DxfEntity) rasterImage))
          return;
        this.method_0((DxfEntity) rasterImage, drawContext);
      }

      public new void CreateScalableImage(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        IBitmapProvider bitmapProvider,
        Polyline4D clipPolygon,
        Size2D displaySize,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, entity))
          return;
        this.method_0(entity, drawContext);
      }

      private void method_0(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
        if (this.hashSet_0.Contains(entity))
          return;
        this.hashSet_0.Add(entity);
        this.list_0.Add(EntitySelector.GetRenderedEntityInfo(entity, drawContext));
      }
    }

    internal class Class587 : EntitySelector.Class581, IWireframeGraphicsFactory, EntitySelector.IFilter
    {
      private HashSet<DxfEntity> hashSet_0 = new HashSet<DxfEntity>();
      private List<RenderedEntityInfo> list_0 = new List<RenderedEntityInfo>();
      private EntityFilterDelegate entityFilterDelegate_0;

      public Class587(EntityFilterDelegate filter)
      {
        this.entityFilterDelegate_0 = filter;
      }

      public override List<RenderedEntityInfo> Entities
      {
        get
        {
          return this.list_0;
        }
      }

      public new void CreateDot(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D position)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, drawContext.RootBlockContext))
          return;
        this.method_0(drawContext.RootBlockContext, drawContext);
      }

      public new void CreateLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D start,
        Vector4D end)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, drawContext.RootBlockContext))
          return;
        this.method_0(drawContext.RootBlockContext, drawContext);
      }

      public new void CreateRay(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Segment4D segment)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, drawContext.RootBlockContext))
          return;
        this.method_0(drawContext.RootBlockContext, drawContext);
      }

      public new void CreateXLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Vector4D? startPoint,
        Segment4D segment)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, drawContext.RootBlockContext))
          return;
        this.method_0(drawContext.RootBlockContext, drawContext);
      }

      public new void CreatePath(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IList<Polyline4D> polylines,
        bool fill,
        bool correctForBackgroundColor)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, drawContext.RootBlockContext))
          return;
        this.method_0(drawContext.RootBlockContext, drawContext);
      }

      public new void CreatePathAsOne(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IList<Polyline4D> polylines,
        bool fill,
        bool correctForBackgroundColor)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, drawContext.RootBlockContext))
          return;
        this.method_0(drawContext.RootBlockContext, drawContext);
      }

      public new void CreateShape(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IShape4D shape)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, drawContext.RootBlockContext))
          return;
        this.method_0(drawContext.RootBlockContext, drawContext);
      }

      public new void CreateImage(
        DxfRasterImage rasterImage,
        DrawContext.Wireframe drawContext,
        Polyline4D clipPolygon,
        Polyline4D imageBoundary,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, drawContext.RootBlockContext))
          return;
        this.method_0(drawContext.RootBlockContext, drawContext);
      }

      public new void CreateScalableImage(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        IBitmapProvider bitmapProvider,
        Polyline4D clipPolygon,
        Size2D displaySize,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis)
      {
        if (!this.entityFilterDelegate_0((DrawContext) drawContext, drawContext.RootBlockContext))
          return;
        this.method_0(drawContext.RootBlockContext, drawContext);
      }

      private void method_0(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
        if (this.hashSet_0.Contains(entity))
          return;
        this.hashSet_0.Add(entity);
        this.list_0.Add(EntitySelector.GetRenderedEntityInfo(entity, drawContext));
      }
    }
  }
}
