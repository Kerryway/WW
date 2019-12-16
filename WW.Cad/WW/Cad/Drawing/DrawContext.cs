// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.DrawContext
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using ns33;
using System;
using System.Collections.Generic;
using System.Drawing;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Objects.Annotations;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public abstract class DrawContext : IDisposable, WW.ICloneable
  {
    private EntityColor entityColor_0 = EntityColors.White;
    private Transparency transparency_0 = Transparency.Opaque;
    private double double_0 = 1.0;
    private DxfModel dxfModel_0;
    private DxfLayout dxfLayout_0;
    private DxfLayer dxfLayer_0;
    private DxfLayer dxfLayer_1;
    private DxfEntity dxfEntity_0;
    private DxfBlock dxfBlock_0;
    private DxfColor dxfColor_0;
    private DxfLineType dxfLineType_0;
    private short short_0;
    private GraphicsConfig graphicsConfig_0;
    private DrawContext drawContext_0;
    private int int_0;
    private int int_1;
    private Graphics graphics_0;
    private Image image_0;
    private IShape2D ishape2D_0;
    private DrawContext drawContext_1;
    private DxfEntity dxfEntity_1;
    private DxfWipeoutVariables dxfWipeoutVariables_0;
    private Dictionary<DxfEntity, object> dictionary_0;
    private double double_1;

    protected DrawContext(DxfModel model, DxfLayout layout, GraphicsConfig config)
    {
      this.dxfModel_0 = model;
      this.dxfLayout_0 = layout;
      this.graphicsConfig_0 = config;
      this.dxfLineType_0 = model.ContinuousLineType;
      this.short_0 = (short) -3;
      this.dxfLayer_0 = model.ZeroLayer;
      this.dxfLayer_1 = model.method_14();
      this.dxfWipeoutVariables_0 = model.DictionaryRoot.Entries.GetFirstValue("ACAD_WIPEOUT_VARS") as DxfWipeoutVariables ?? new DxfWipeoutVariables();
      this.dictionary_0 = new Dictionary<DxfEntity, object>();
      this.image_0 = (Image) new Bitmap(1, 1);
      this.graphics_0 = Class940.smethod_0(this.image_0);
      this.method_0();
    }

    protected DrawContext(DrawContext from)
    {
      this.image_0 = from.image_0;
      this.graphics_0 = from.graphics_0;
      this.dxfModel_0 = from.dxfModel_0;
      this.dxfLayout_0 = from.dxfLayout_0;
      this.graphicsConfig_0 = from.graphicsConfig_0;
      this.dxfLayer_0 = from.dxfLayer_0;
      this.dxfLayer_1 = from.dxfLayer_1;
      this.dxfEntity_0 = from.dxfEntity_0;
      this.dxfBlock_0 = from.dxfBlock_0;
      this.drawContext_0 = from.drawContext_0;
      this.dxfEntity_1 = from.dxfEntity_1;
      this.entityColor_0 = from.entityColor_0;
      this.transparency_0 = from.transparency_0;
      this.dxfColor_0 = from.dxfColor_0;
      this.dxfLineType_0 = from.dxfLineType_0;
      this.short_0 = from.short_0;
      this.int_0 = from.int_0;
      this.int_1 = from.int_1;
      this.dxfWipeoutVariables_0 = from.dxfWipeoutVariables_0;
      this.dictionary_0 = from.dictionary_0;
      this.double_0 = from.double_0;
      this.double_1 = from.double_1;
    }

    public DxfLayer Layer
    {
      get
      {
        return this.dxfLayer_0;
      }
    }

    public DrawContext RootContext
    {
      get
      {
        if (this.drawContext_1 == null)
          this.drawContext_1 = this.drawContext_0 != null ? this.drawContext_0.RootContext : this;
        return this.drawContext_1;
      }
    }

    public DxfEntity BlockContext
    {
      get
      {
        return this.dxfEntity_0;
      }
      protected set
      {
        this.dxfEntity_0 = value;
        if (this.dxfEntity_1 == null)
          this.dxfEntity_1 = this.dxfEntity_0;
        if (this.dxfEntity_0 == null)
          return;
        if (this.dxfEntity_0.Layer != this.dxfModel_0.ZeroLayer && this.dxfEntity_0.Layer != null)
          this.dxfLayer_0 = this.dxfEntity_0.Layer;
        switch (this.dxfEntity_0.Color.ColorType)
        {
          case ColorType.ByLayer:
            this.entityColor_0 = EntityColor.CreateFrom(this.dxfLayer_0.Color);
            break;
          case ColorType.ByColor:
          case ColorType.ByColorIndex:
          case ColorType.ByPenIndex:
          case ColorType.Foreground:
            this.entityColor_0 = value.Color;
            this.dxfColor_0 = value.DxfColor;
            break;
        }
        switch (this.dxfEntity_0.Transparency.TransparencyType)
        {
          case TransparencyType.ByLayer:
            this.transparency_0 = this.dxfLayer_0.Transparency;
            break;
          case TransparencyType.ByValue:
            this.transparency_0 = value.Transparency;
            break;
        }
        if (this.dxfEntity_0.LineType != null && this.dxfEntity_0.LineType != this.dxfModel_0.ByBlockLineType)
          this.dxfLineType_0 = this.dxfEntity_0.LineType != this.dxfModel_0.ByLayerLineType ? value.LineType : this.dxfLayer_0.LineType;
        if (this.dxfEntity_0.LineWeight == (short) -2)
          return;
        if (this.dxfEntity_0.LineWeight == (short) -1)
          this.short_0 = this.dxfLayer_0.LineWeight;
        else
          this.short_0 = value.LineWeight;
      }
    }

    public DxfBlock ExternalBlock
    {
      get
      {
        return this.dxfBlock_0;
      }
      set
      {
        this.dxfBlock_0 = value;
      }
    }

    public DxfEntity RootBlockContext
    {
      get
      {
        return this.dxfEntity_1;
      }
    }

    public GraphicsConfig Config
    {
      get
      {
        return this.graphicsConfig_0;
      }
    }

    public DxfModel Model
    {
      get
      {
        return this.dxfModel_0;
      }
    }

    public DxfLayout Layout
    {
      get
      {
        return this.dxfLayout_0;
      }
    }

    public DrawContext ParentContext
    {
      get
      {
        return this.drawContext_0;
      }
    }

    public EntityColor ByBlockColor
    {
      get
      {
        return this.entityColor_0;
      }
      set
      {
        this.entityColor_0 = value;
      }
    }

    public DxfColor ByBlockDxfColor
    {
      get
      {
        return this.dxfColor_0;
      }
      set
      {
        this.dxfColor_0 = value;
      }
    }

    public Transparency ByBlockTransparency
    {
      get
      {
        return this.transparency_0;
      }
      set
      {
        this.transparency_0 = value;
      }
    }

    public DxfLineType ByBlockLineType
    {
      get
      {
        return this.dxfLineType_0;
      }
      set
      {
        this.dxfLineType_0 = value;
      }
    }

    public short ByBlockLineWeight
    {
      get
      {
        return this.short_0;
      }
      set
      {
        this.short_0 = value;
      }
    }

    public int Row
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public int Column
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public DxfWipeoutVariables WipeoutVariables
    {
      get
      {
        return this.dxfWipeoutVariables_0;
      }
    }

    public abstract bool IsVisible(DxfEntity entity);

    public DxfLayer GetEffectiveLayer(DxfLayer candidate)
    {
      DxfLayer dxfLayer = this.dxfLayer_0 == null || candidate != null && !candidate.IsZeroLayer ? candidate : this.dxfLayer_0;
      if (dxfLayer != null && this.dxfBlock_0 != null)
      {
        DxfLayer layerWithName = this.dxfBlock_0.Model.GetLayerWithName(this.dxfBlock_0.Name + "|" + dxfLayer.Name);
        if (layerWithName != null)
          dxfLayer = layerWithName;
      }
      return dxfLayer;
    }

    public ArgbColor GetPlotColor(DxfEntity entity)
    {
      if (this.graphicsConfig_0.PlotStyleManager == null)
        return entity.GetColor(this);
      return this.graphicsConfig_0.PlotStyleManager((IPlotPropertyOwner) entity, this).Color;
    }

    public ArgbColor GetPlotColor(DxfEntity localBlockContext, WW.Cad.Model.Color color)
    {
      ArgbColor argbColor;
      if (this.graphicsConfig_0.PlotStyleManager != null)
        argbColor = this.graphicsConfig_0.PlotStyleManager((IPlotPropertyOwner) new Class1065((IPlotPropertyOwner) localBlockContext, color), this).Color;
      else if (color == WW.Cad.Model.Color.ByBlock)
      {
        if (localBlockContext.Color == EntityColor.ByLayer)
        {
          DxfLayer layer = localBlockContext.GetLayer(this);
          argbColor = layer == null ? DxfIndexedColor.DefaultColor : layer.Color.ToArgbColor(this.graphicsConfig_0.IndexedColors);
        }
        else
          argbColor = localBlockContext.DxfColor != null ? localBlockContext.DxfColor.Color.ToArgbColor(this.graphicsConfig_0.IndexedColors) : (!(localBlockContext.Color == EntityColor.ByBlock) ? localBlockContext.Color.ToArgbColor(this.graphicsConfig_0.IndexedColors) : (this.dxfColor_0 == null ? this.entityColor_0.ToArgbColor(this.graphicsConfig_0.IndexedColors) : this.dxfColor_0.Color.ToArgbColor(this.graphicsConfig_0.IndexedColors)));
      }
      else if (color == WW.Cad.Model.Color.ByLayer)
      {
        DxfLayer layer = localBlockContext.GetLayer(this);
        argbColor = layer == null ? DxfIndexedColor.DefaultColor : layer.Color.ToArgbColor(this.graphicsConfig_0.IndexedColors);
      }
      else
        argbColor = color.ToArgbColor(this.graphicsConfig_0.IndexedColors);
      return argbColor;
    }

    public short GetLineWeight(DxfEntity entity)
    {
      if (this.graphicsConfig_0.PlotStyleManager == null)
        return entity.GetLineWeight(this);
      return this.graphicsConfig_0.PlotStyleManager((IPlotPropertyOwner) entity, this).LineWeight;
    }

    public IPlotStyle GetEffectivePlotStyle(IPlotPropertyOwner plotPropertyOwner)
    {
      if (this.graphicsConfig_0.PlotStyleManager == null)
        return (IPlotStyle) new DefaultPlotStyle(plotPropertyOwner, this);
      return this.graphicsConfig_0.PlotStyleManager(plotPropertyOwner, this);
    }

    public bool HaveSameBlockContextChain(DrawContext other)
    {
      if (other == null)
        return false;
      DrawContext drawContext1 = this;
      DrawContext drawContext2 = other;
      bool flag = true;
      while (drawContext1 != null && (flag = drawContext1.dxfEntity_0 == drawContext2.dxfEntity_0 && drawContext1.int_0 == drawContext2.int_0 && drawContext1.int_1 == drawContext2.int_1))
      {
        drawContext1 = drawContext1.drawContext_0;
        drawContext2 = drawContext2.drawContext_0;
        if (!(flag = drawContext1 == null == (drawContext2 == null)))
          break;
      }
      return flag;
    }

    public abstract object Clone();

    protected virtual void CopyFrom(DrawContext from)
    {
      this.dxfModel_0 = from.dxfModel_0;
      this.dxfLayout_0 = from.dxfLayout_0;
      this.graphicsConfig_0 = from.graphicsConfig_0;
      this.dxfLayer_0 = from.dxfLayer_0;
      this.dxfLayer_1 = from.dxfLayer_1;
      this.dxfEntity_0 = from.dxfEntity_0;
      this.dxfBlock_0 = from.dxfBlock_0;
      this.drawContext_0 = from.drawContext_0;
      this.dxfEntity_1 = from.dxfEntity_1;
      this.entityColor_0 = from.entityColor_0;
      this.dxfColor_0 = from.dxfColor_0;
      this.transparency_0 = from.transparency_0;
      this.dxfLineType_0 = from.dxfLineType_0;
      this.short_0 = from.short_0;
      this.int_0 = from.int_0;
      this.int_1 = from.int_1;
      this.dxfWipeoutVariables_0 = from.dxfWipeoutVariables_0;
      this.dictionary_0 = from.dictionary_0;
      this.double_0 = from.double_0;
      this.double_1 = from.double_1;
    }

    protected void SetParent(DrawContext parent, DxfEntity blockContext)
    {
      this.drawContext_0 = parent;
      this.BlockContext = blockContext;
    }

    protected void SetExternalBlock(DxfBlock externalBlock, DxfModel externalModel)
    {
      this.dxfBlock_0 = externalBlock;
      this.dxfModel_0 = externalModel;
      this.dxfLayout_0 = this.dxfModel_0.ModelLayout;
    }

    internal virtual DxfViewport Viewport
    {
      get
      {
        return (DxfViewport) null;
      }
    }

    internal Graphics MeasureGraphics
    {
      get
      {
        return this.graphics_0;
      }
    }

    internal Image DummyMeasureImage
    {
      get
      {
        return this.image_0;
      }
    }

    public DxfLayer DefPointsLayer
    {
      get
      {
        return this.dxfLayer_1;
      }
    }

    internal IShape2D PointShape2D
    {
      get
      {
        if (this.ishape2D_0 == null)
          this.ishape2D_0 = Class384.CreateShape(this.Model.Header.PointDisplayMode, this.Model.Header.PointDisplaySize <= 0.0 ? 1.0 : this.Model.Header.PointDisplaySize);
        return this.ishape2D_0;
      }
    }

    public Dictionary<DxfEntity, object> EntityToRenderCache
    {
      get
      {
        return this.dictionary_0;
      }
    }

    internal abstract void vmethod_0(IClippingTransformer clipper);

    internal abstract void vmethod_1();

    internal abstract Matrix4D vmethod_2();

    internal double AnnotationScaleFactor
    {
      get
      {
        return this.double_0;
      }
      set
      {
        if (value == 0.0 || double.IsNaN(value) || double.IsInfinity(value))
          value = 1.0;
        this.double_0 = value;
        this.method_0();
      }
    }

    internal void method_0()
    {
      this.double_1 = this.dxfModel_0.Header.LineTypeScale * this.double_0;
    }

    public double TotalLineTypeScale
    {
      get
      {
        return this.double_1;
      }
    }

    public virtual void Dispose()
    {
      if (this.graphics_0 != null)
      {
        this.graphics_0.Dispose();
        this.graphics_0 = (Graphics) null;
      }
      if (this.image_0 == null)
        return;
      this.image_0.Dispose();
      this.image_0 = (Image) null;
    }

    public abstract class Wireframe : DrawContext, IDrawContext<DrawContext.Wireframe>
    {
      private ClippingTransformerChain clippingTransformerChain_0;

      protected Wireframe(
        DxfModel model,
        DxfLayout layout,
        GraphicsConfig config,
        IClippingTransformer initialTransformer)
        : base(model, layout, config)
      {
        this.clippingTransformerChain_0 = new ClippingTransformerChain();
        this.clippingTransformerChain_0.Push(initialTransformer);
      }

      protected Wireframe(DrawContext.Wireframe from)
        : base((DrawContext) from)
      {
        this.clippingTransformerChain_0 = (ClippingTransformerChain) from.clippingTransformerChain_0.Clone();
      }

      public IClippingTransformer GetTransformer()
      {
        return (IClippingTransformer) this.clippingTransformerChain_0;
      }

      public abstract DrawContext.Wireframe CreateChildContext(
        DxfEntity blockContext,
        Matrix4D preTransform);

      public virtual DrawContext.Wireframe CreateChildContext(
        DxfEntity blockContext,
        Matrix4D preTransform,
        DxfBlock externalBlock,
        DxfModel externalModel)
      {
        DrawContext.Wireframe childContext = this.CreateChildContext(blockContext, preTransform);
        childContext.SetExternalBlock(externalBlock, externalModel);
        return childContext;
      }

      protected override void CopyFrom(DrawContext from)
      {
        base.CopyFrom(from);
        this.clippingTransformerChain_0 = (ClippingTransformerChain) ((DrawContext.Wireframe) from).clippingTransformerChain_0.Clone();
      }

      internal override void vmethod_0(IClippingTransformer clipper)
      {
        this.clippingTransformerChain_0.Push(clipper);
      }

      internal override Matrix4D vmethod_2()
      {
        return this.clippingTransformerChain_0.Matrix;
      }

      internal override void vmethod_1()
      {
        this.clippingTransformerChain_0.Pop();
      }

      public class ModelSpace : DrawContext.Wireframe
      {
        public ModelSpace(DxfModel model, GraphicsConfig config, Matrix4D transform)
          : base(model, model.ModelLayout, config, (IClippingTransformer) new Class383(transform, Matrix3D.Identity, (ILineTypeScaler) Class624.Class626.class626_0))
        {
          if (model.Header.CurrentAnnotationScale == null || !model.Header.ModelSpaceAnnotationScalingEnabled)
            return;
          this.AnnotationScaleFactor = model.Header.CurrentAnnotationScale.DrawingUnits / model.Header.CurrentAnnotationScale.PaperUnits;
        }

        private ModelSpace(DrawContext.Wireframe.ModelSpace from)
          : base((DrawContext.Wireframe) from)
        {
        }

        public override bool IsVisible(DxfEntity entity)
        {
          return !entity.InPaperSpace(this.RootBlockContext);
        }

        public override object Clone()
        {
          return (object) new DrawContext.Wireframe.ModelSpace(this);
        }

        public override DrawContext.Wireframe CreateChildContext(
          DxfEntity blockContext,
          Matrix4D preTransform)
        {
          DrawContext.Wireframe.ModelSpace modelSpace = new DrawContext.Wireframe.ModelSpace(this);
          modelSpace.SetParent((DrawContext) this, blockContext);
          modelSpace.clippingTransformerChain_0.SetPreTransform(preTransform);
          return (DrawContext.Wireframe) modelSpace;
        }
      }

      public class ModelToPaperSpace : DrawContext.Wireframe
      {
        private DxfViewport dxfViewport_0;
        private DxfScale dxfScale_0;

        public ModelToPaperSpace(
          DxfModel model,
          DxfLayout layout,
          GraphicsConfig config,
          DxfViewport viewport,
          Matrix4D postTransform)
          : base(model, layout, config, viewport.method_17(model, config, postTransform))
        {
          this.dxfViewport_0 = viewport;
          if (viewport.AnnotationScale == null || !model.Header.PaperSpaceAnnotationScalingEnabled)
            return;
          this.double_0 = viewport.AnnotationScale.ScaleFactor;
          this.dxfScale_0 = model.Header.CurrentAnnotationScale;
          model.Header.CurrentAnnotationScale = viewport.AnnotationScale;
        }

        private ModelToPaperSpace(DrawContext.Wireframe.ModelToPaperSpace from)
          : base((DrawContext.Wireframe) from)
        {
          this.dxfViewport_0 = from.dxfViewport_0;
        }

        internal override DxfViewport Viewport
        {
          get
          {
            return this.dxfViewport_0;
          }
        }

        public override bool IsVisible(DxfEntity entity)
        {
          if (entity.InPaperSpace(this.RootBlockContext))
            return false;
          return !this.dxfViewport_0.FrozenLayers.Contains(this.GetEffectiveLayer(entity.Layer));
        }

        public override object Clone()
        {
          return (object) new DrawContext.Wireframe.ModelToPaperSpace(this);
        }

        protected override void CopyFrom(DrawContext from)
        {
          base.CopyFrom(from);
          this.dxfViewport_0 = ((DrawContext.Wireframe.ModelToPaperSpace) from).dxfViewport_0;
        }

        public override DrawContext.Wireframe CreateChildContext(
          DxfEntity blockContext,
          Matrix4D preTransform)
        {
          DrawContext.Wireframe.ModelToPaperSpace modelToPaperSpace = new DrawContext.Wireframe.ModelToPaperSpace(this);
          modelToPaperSpace.SetParent((DrawContext) this, blockContext);
          modelToPaperSpace.clippingTransformerChain_0.SetPreTransform(preTransform);
          return (DrawContext.Wireframe) modelToPaperSpace;
        }

        public override void Dispose()
        {
          base.Dispose();
          if (this.dxfScale_0 == null)
            return;
          this.dxfModel_0.Header.CurrentAnnotationScale = this.dxfScale_0;
        }
      }

      public class PaperToPaperSpace : DrawContext.Wireframe
      {
        public PaperToPaperSpace(
          DxfModel model,
          DxfLayout layout,
          GraphicsConfig config,
          Matrix4D postTransform)
          : base(model, layout, config, (IClippingTransformer) new Class383(postTransform, Matrix3D.Identity, (ILineTypeScaler) Class624.Class626.class626_0))
        {
        }

        private PaperToPaperSpace(DrawContext.Wireframe.PaperToPaperSpace from)
          : base((DrawContext.Wireframe) from)
        {
        }

        public override bool IsVisible(DxfEntity entity)
        {
          return entity.InPaperSpace(this.RootBlockContext);
        }

        public override object Clone()
        {
          return (object) new DrawContext.Wireframe.PaperToPaperSpace(this);
        }

        public override DrawContext.Wireframe CreateChildContext(
          DxfEntity blockContext,
          Matrix4D preTransform)
        {
          DrawContext.Wireframe.PaperToPaperSpace paperToPaperSpace = new DrawContext.Wireframe.PaperToPaperSpace(this);
          paperToPaperSpace.SetParent((DrawContext) this, blockContext);
          paperToPaperSpace.clippingTransformerChain_0.SetPreTransform(preTransform);
          return (DrawContext.Wireframe) paperToPaperSpace;
        }
      }
    }

    public abstract class Surface : DrawContext, IDrawContext<DrawContext.Surface>
    {
      private Class803 class803_0;
      private CharTriangulationCache charTriangulationCache_0;

      public Surface(
        DxfModel model,
        DxfLayout layout,
        GraphicsConfig config,
        Matrix4D transform,
        CharTriangulationCache charTriangulationCache)
        : base(model, layout, config)
      {
        this.class803_0 = new Class803(transform, Matrix3D.Identity, (ILineTypeScaler) Class624.Class626.class626_0);
        this.charTriangulationCache_0 = charTriangulationCache;
      }

      protected Surface(DrawContext.Surface from)
        : base((DrawContext) from)
      {
        this.class803_0 = (Class803) from.GetTransformer().Clone();
        this.charTriangulationCache_0 = from.charTriangulationCache_0;
      }

      public CharTriangulationCache CharTriangulationCache
      {
        get
        {
          return this.charTriangulationCache_0;
        }
      }

      internal Interface41 GetTransformer()
      {
        return (Interface41) this.class803_0;
      }

      public abstract DrawContext.Surface CreateChildContext(
        DxfEntity blockContext,
        Matrix4D preTransform);

      public virtual DrawContext.Surface CreateChildContext(
        DxfEntity blockContext,
        Matrix4D preTransform,
        DxfBlock externalBlock,
        DxfModel externalModel)
      {
        DrawContext.Surface childContext = this.CreateChildContext(blockContext, preTransform);
        childContext.SetExternalBlock(externalBlock, externalModel);
        return childContext;
      }

      protected override void CopyFrom(DrawContext from)
      {
        base.CopyFrom(from);
        this.class803_0 = (Class803) ((DrawContext.Surface) from).GetTransformer().Clone();
      }

      internal override void vmethod_0(IClippingTransformer clipper)
      {
      }

      internal override void vmethod_1()
      {
      }

      internal override Matrix4D vmethod_2()
      {
        return this.class803_0.Matrix;
      }

      public class ModelSpace : DrawContext.Surface
      {
        public ModelSpace(
          DxfModel model,
          GraphicsConfig config,
          Matrix4D transform,
          CharTriangulationCache charTriangulationCache)
          : base(model, model.ModelLayout, config, transform, charTriangulationCache)
        {
          if (model.Header.CurrentAnnotationScale == null || !model.Header.ModelSpaceAnnotationScalingEnabled)
            return;
          this.AnnotationScaleFactor = model.Header.CurrentAnnotationScale.ScaleFactor;
        }

        private ModelSpace(DrawContext.Surface.ModelSpace from)
          : base((DrawContext.Surface) from)
        {
        }

        public override bool IsVisible(DxfEntity entity)
        {
          return !entity.InPaperSpace(this.RootBlockContext);
        }

        public override object Clone()
        {
          return (object) new DrawContext.Surface.ModelSpace(this);
        }

        public override DrawContext.Surface CreateChildContext(
          DxfEntity blockContext,
          Matrix4D preTransform)
        {
          DrawContext.Surface.ModelSpace modelSpace = new DrawContext.Surface.ModelSpace(this);
          modelSpace.SetParent((DrawContext) this, blockContext);
          modelSpace.class803_0.SetPreTransform(preTransform);
          return (DrawContext.Surface) modelSpace;
        }
      }

      public class ModelToPaperSpace : DrawContext.Surface
      {
        private DxfViewport dxfViewport_0;

        public ModelToPaperSpace(
          DxfModel model,
          DxfLayout layout,
          GraphicsConfig config,
          DxfViewport viewport,
          Matrix4D postTransform,
          CharTriangulationCache charTriangulationCache)
          : base(model, layout, config, postTransform, charTriangulationCache)
        {
          this.dxfViewport_0 = viewport;
        }

        private ModelToPaperSpace(DrawContext.Surface.ModelToPaperSpace from)
          : base((DrawContext.Surface) from)
        {
          this.dxfViewport_0 = from.dxfViewport_0;
        }

        public new DxfViewport Viewport
        {
          get
          {
            return this.dxfViewport_0;
          }
        }

        public override bool IsVisible(DxfEntity entity)
        {
          if (entity.InPaperSpace(this.RootBlockContext))
            return false;
          return !this.dxfViewport_0.FrozenLayers.Contains(this.GetEffectiveLayer(entity.Layer));
        }

        public override object Clone()
        {
          return (object) new DrawContext.Surface.ModelToPaperSpace(this);
        }

        protected override void CopyFrom(DrawContext from)
        {
          base.CopyFrom(from);
          this.dxfViewport_0 = ((DrawContext.Surface.ModelToPaperSpace) from).dxfViewport_0;
        }

        public override DrawContext.Surface CreateChildContext(
          DxfEntity blockContext,
          Matrix4D preTransform)
        {
          DrawContext.Surface.ModelToPaperSpace modelToPaperSpace = new DrawContext.Surface.ModelToPaperSpace(this);
          modelToPaperSpace.SetParent((DrawContext) this, blockContext);
          modelToPaperSpace.class803_0.SetPreTransform(preTransform);
          return (DrawContext.Surface) modelToPaperSpace;
        }
      }

      public class PaperToPaperSpace : DrawContext.Surface
      {
        public PaperToPaperSpace(
          DxfModel model,
          DxfLayout layout,
          GraphicsConfig config,
          Matrix4D postTransform,
          CharTriangulationCache charTriangulationCache)
          : base(model, layout, config, postTransform, charTriangulationCache)
        {
        }

        private PaperToPaperSpace(DrawContext.Surface.PaperToPaperSpace from)
          : base((DrawContext.Surface) from)
        {
        }

        public override bool IsVisible(DxfEntity entity)
        {
          return entity.InPaperSpace(this.RootBlockContext);
        }

        public override object Clone()
        {
          return (object) new DrawContext.Surface.PaperToPaperSpace(this);
        }

        public override DrawContext.Surface CreateChildContext(
          DxfEntity blockContext,
          Matrix4D preTransform)
        {
          DrawContext.Surface.PaperToPaperSpace paperToPaperSpace = new DrawContext.Surface.PaperToPaperSpace(this);
          paperToPaperSpace.SetParent((DrawContext) this, blockContext);
          paperToPaperSpace.class803_0.SetPreTransform(preTransform);
          return (DrawContext.Surface) paperToPaperSpace;
        }
      }
    }
  }
}
