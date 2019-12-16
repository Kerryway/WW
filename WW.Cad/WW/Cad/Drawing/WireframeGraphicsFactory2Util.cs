// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.WireframeGraphicsFactory2Util
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Math;

namespace WW.Cad.Drawing
{
  public static class WireframeGraphicsFactory2Util
  {
    public static void CreateDrawables(
      IWireframeGraphicsFactory2 graphicsFactory,
      GraphicsConfig graphicsConfig,
      DxfModel model,
      Matrix4D modelTransform)
    {
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, graphicsConfig, modelTransform))
        model.Draw(context, graphicsFactory);
    }

    public static void CreateDrawables(
      IWireframeGraphicsFactory2 graphicsFactory,
      GraphicsConfig graphicsConfig,
      DxfModel model,
      IList<DxfEntity> entities,
      Matrix4D modelTransform)
    {
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.ModelSpace(model, graphicsConfig, modelTransform))
      {
        foreach (DxfEntity entity in (IEnumerable<DxfEntity>) entities)
          entity.Draw(context, graphicsFactory);
      }
    }

    public static void CreateDrawables(
      IWireframeGraphicsFactory2 graphicsFactory,
      GraphicsConfig graphicsConfig,
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports)
    {
      if (layout.PaperSpace)
      {
        if (viewports == null)
          viewports = (ICollection<DxfViewport>) layout.Viewports;
        bool flag;
        if (flag = (layout.PlotLayoutFlags & PlotLayoutFlags.DrawViewportsFirst) != PlotLayoutFlags.None)
          WireframeGraphicsFactory2Util.smethod_0(graphicsFactory, graphicsConfig, model, layout, (IEnumerable<DxfViewport>) viewports);
        using (DrawContext.Wireframe.PaperToPaperSpace paperToPaperSpace = new DrawContext.Wireframe.PaperToPaperSpace(model, layout, graphicsConfig, Matrix4D.Identity))
          layout.Draw((DrawContext.Wireframe) paperToPaperSpace, graphicsFactory);
        if (flag)
          return;
        WireframeGraphicsFactory2Util.smethod_0(graphicsFactory, graphicsConfig, model, layout, (IEnumerable<DxfViewport>) viewports);
      }
      else
        WireframeGraphicsFactory2Util.CreateDrawables(graphicsFactory, graphicsConfig, model, Matrix4D.Identity);
    }

    public static void CreateDrawables(
      IWireframeGraphicsFactory2 graphicsFactory,
      GraphicsConfig graphicsConfig,
      DxfModel model,
      IList<DxfEntity> modelSpaceEntities,
      IList<DxfEntity> paperSpaceEntities,
      DxfLayout layout,
      ICollection<DxfViewport> viewports)
    {
      if (viewports == null)
        viewports = (ICollection<DxfViewport>) layout.Viewports;
      bool flag;
      if (flag = (layout.PlotLayoutFlags & PlotLayoutFlags.DrawViewportsFirst) != PlotLayoutFlags.None)
        WireframeGraphicsFactory2Util.smethod_1(graphicsFactory, graphicsConfig, model, modelSpaceEntities, layout, viewports);
      using (DrawContext.Wireframe.PaperToPaperSpace paperToPaperSpace = new DrawContext.Wireframe.PaperToPaperSpace(model, layout, graphicsConfig, Matrix4D.Identity))
      {
        foreach (DxfEntity paperSpaceEntity in (IEnumerable<DxfEntity>) paperSpaceEntities)
          paperSpaceEntity.Draw((DrawContext.Wireframe) paperToPaperSpace, graphicsFactory);
      }
      if (flag)
        return;
      WireframeGraphicsFactory2Util.smethod_1(graphicsFactory, graphicsConfig, model, modelSpaceEntities, layout, viewports);
    }

    private static void smethod_0(
      IWireframeGraphicsFactory2 graphicsFactory,
      GraphicsConfig graphicsConfig,
      DxfModel model,
      DxfLayout layout,
      IEnumerable<DxfViewport> viewports)
    {
      foreach (DxfViewport viewport in viewports)
      {
        if (viewport.ModelSpaceVisible)
        {
          using (DrawContext.Wireframe.ModelToPaperSpace modelToPaperSpace = new DrawContext.Wireframe.ModelToPaperSpace(model, layout, graphicsConfig, viewport, Matrix4D.Identity))
            model.Draw((DrawContext.Wireframe) modelToPaperSpace, graphicsFactory);
        }
      }
    }

    private static void smethod_1(
      IWireframeGraphicsFactory2 graphicsFactory,
      GraphicsConfig graphicsConfig,
      DxfModel model,
      IList<DxfEntity> modelSpaceEntities,
      DxfLayout layout,
      ICollection<DxfViewport> viewports)
    {
      foreach (DxfViewport viewport in (IEnumerable<DxfViewport>) viewports)
      {
        if (viewport.ModelSpaceVisible)
        {
          using (DrawContext.Wireframe.ModelToPaperSpace modelToPaperSpace = new DrawContext.Wireframe.ModelToPaperSpace(model, layout, graphicsConfig, viewport, Matrix4D.Identity))
          {
            foreach (DxfEntity modelSpaceEntity in (IEnumerable<DxfEntity>) modelSpaceEntities)
              modelSpaceEntity.Draw((DrawContext.Wireframe) modelToPaperSpace, graphicsFactory);
          }
        }
      }
    }
  }
}
