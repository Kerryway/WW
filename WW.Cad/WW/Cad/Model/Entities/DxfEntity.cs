// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfEntity
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns1;
using ns28;
using ns3;
using ns30;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WW.Actions;
using WW.Cad.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.GDI;
using WW.Cad.Drawing.Surface;
using WW.Cad.IO;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;

namespace WW.Cad.Model.Entities
{
  public abstract class DxfEntity : DxfHandledObject, IPlotPropertyOwner
  {
    private DxfObjectReference dxfObjectReference_3 = DxfObjectReference.Null;
    private EntityColor entityColor_0 = EntityColors.ByLayer;
    private Transparency transparency_0 = Transparency.ByLayer;
    private DxfObjectReference dxfObjectReference_4 = DxfObjectReference.Null;
    private DxfObjectReference dxfObjectReference_5 = DxfObjectReference.Null;
    private double double_0 = 1.0;
    private short short_0 = -1;
    private bool bool_0 = true;
    private bool bool_1;

    public DxfEntity()
    {
    }

    public DxfEntity(DxfEntity templateEntity)
    {
      this.method_12(templateEntity);
    }

    public DxfLayer Layer
    {
      get
      {
        return (DxfLayer) this.dxfObjectReference_3.Value;
      }
      set
      {
        this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public virtual EntityColor Color
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

    public Transparency Transparency
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

    public DxfColor DxfColor
    {
      get
      {
        return (DxfColor) this.dxfObjectReference_4.Value;
      }
      set
      {
        this.dxfObjectReference_4 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public DxfLineType LineType
    {
      get
      {
        return (DxfLineType) this.dxfObjectReference_5.Value;
      }
      set
      {
        this.dxfObjectReference_5 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public short LineWeight
    {
      get
      {
        return this.short_0;
      }
      set
      {
        if (value > (short) 211)
          throw new ArgumentException("Lineweight may not be larger than 211.");
        this.short_0 = value;
      }
    }

    public double LineTypeScale
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

    public bool Visible
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public bool PaperSpace
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public abstract string EntityType { get; }

    public abstract string AcClass { get; }

    public virtual Matrix4D Transform
    {
      get
      {
        return Matrix4D.Identity;
      }
    }

    public void Draw(DrawContext.Wireframe context, IWireframeGraphicsFactory graphicsFactory)
    {
      graphicsFactory.BeginEntity(this, context);
      if (this.IsEntityVisibleInContext((DrawContext) context, this.UseLayerEnabled))
        this.DrawInternal(context, graphicsFactory);
      graphicsFactory.EndEntity();
    }

    public abstract void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory);

    public void Draw(DrawContext.Wireframe context, IWireframeGraphicsFactory2 graphicsFactory)
    {
      graphicsFactory.BeginEntity(this, context);
      if (this.IsEntityVisibleInContext((DrawContext) context, this.UseLayerEnabled))
        this.DrawInternal(context, graphicsFactory);
      graphicsFactory.EndEntity();
    }

    public abstract void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory);

    public void Draw(DrawContext.Surface context, ISurfaceGraphicsFactory graphicsFactory)
    {
      graphicsFactory.BeginNode(this, context);
      if (this.IsEntityVisibleInContext((DrawContext) context, this.UseLayerEnabled))
        this.DrawInternal(context, graphicsFactory);
      graphicsFactory.EndNode();
    }

    public virtual void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
    }

    public void Draw(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      if (!this.IsEntityVisibleInContext((DrawContext) context, this.UseLayerEnabled))
        return;
      this.DrawInternal(context, graphics, parentGraphicElementBlock);
    }

    public virtual void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
    }

    public bool InPaperSpace(DxfEntity parentEntityContext)
    {
      if (parentEntityContext != null && parentEntityContext.PaperSpace)
        return true;
      return this.bool_1;
    }

    public DxfLayer GetLayer(DrawContext context)
    {
      return context.GetEffectiveLayer(this.Layer);
    }

    public ArgbColor GetColor(DxfIndexedColorSet indexedColors)
    {
      return this.DxfColor == null ? this.entityColor_0.ToArgbColor(indexedColors) : this.DxfColor.Color.ToArgbColor(indexedColors);
    }

    [Obsolete("Use GetColor(DxfIndexedColorSet) instead")]
    public ArgbColor GetColor()
    {
      return this.DxfColor == null ? this.entityColor_0.ToArgbColor() : this.DxfColor.Color.ToArgbColor();
    }

    public ArgbColor GetColor(DrawContext context)
    {
      ArgbColor baseColor;
      if (this.DxfColor == null)
      {
        if (this.entityColor_0 == EntityColor.ByBlock)
          baseColor = context.ByBlockDxfColor == null ? context.ByBlockColor.ToArgbColor(context.Config.IndexedColors) : context.ByBlockDxfColor.Color.ToArgbColor(context.Config.IndexedColors);
        else if (this.entityColor_0 == EntityColor.ByLayer)
        {
          DxfLayer layer = this.GetLayer(context);
          baseColor = layer == null ? context.Config.IndexedColors[7] : layer.GetColor(context.Viewport).ToArgbColor(context.Config.IndexedColors);
        }
        else
          baseColor = this.Color.ToArgbColor(context.Config.IndexedColors);
      }
      else
        baseColor = this.DxfColor.Color.ToArgbColor(context.Config.IndexedColors);
      byte alpha = this.GetAlpha(context);
      if (alpha != byte.MaxValue)
        return ArgbColor.FromArgb((int) alpha, baseColor);
      return baseColor;
    }

    public EntityColor GetEntityColor(DrawContext context)
    {
      EntityColor entityColor;
      if (this.DxfColor == null)
      {
        if (this.entityColor_0 == EntityColor.ByBlock)
          entityColor = context.ByBlockDxfColor == null ? context.ByBlockColor : EntityColor.CreateFrom(context.ByBlockDxfColor.Color);
        else if (this.entityColor_0 == EntityColor.ByLayer)
        {
          DxfLayer layer = this.GetLayer(context);
          entityColor = layer == null ? EntityColor.CreateFromColorIndex((short) 7) : EntityColor.CreateFrom(layer.GetColor(context.Viewport));
        }
        else
          entityColor = this.Color;
      }
      else
        entityColor = EntityColor.CreateFrom(this.DxfColor.Color);
      return entityColor;
    }

    public byte GetAlpha(DrawContext context)
    {
      if (this.transparency_0 == Transparency.ByBlock)
        return context.ByBlockTransparency.Alpha;
      if (!(this.transparency_0 == Transparency.ByLayer))
        return this.transparency_0.Alpha;
      DxfLayer layer = this.GetLayer(context);
      if (layer != null)
        return layer.GetTransparency(context.Viewport).Alpha;
      return Transparency.Opaque.Alpha;
    }

    public static ArgbColor GetColor(
      DxfIndexedColorSet indexedColors,
      WW.Cad.Model.Color color,
      EntityColor byBlockColor,
      DxfColor byBlockDxfColor,
      DxfLayer layer)
    {
      switch (color.ColorType)
      {
        case ColorType.ByLayer:
          if (layer != null)
            return layer.Color.ToArgbColor(indexedColors);
          return ArgbColors.White;
        case ColorType.ByBlock:
          if (byBlockDxfColor != null)
            return byBlockDxfColor.Color.ToArgbColor(indexedColors);
          return byBlockColor.ToArgbColor(indexedColors);
        case ColorType.ByColor:
        case ColorType.ByColorIndex:
        case ColorType.ByPenIndex:
        case ColorType.Foreground:
          return color.ToArgbColor(indexedColors);
        default:
          return ArgbColor.Empty;
      }
    }

    [Obsolete("Use GetColor(DxfIndexedColorSet,Color,EntityColor,DxfColor,DxfLayer) instead.")]
    public static ArgbColor GetColor(
      WW.Cad.Model.Color color,
      EntityColor byBlockColor,
      DxfColor byBlockDxfColor,
      DxfLayer layer)
    {
      switch (color.ColorType)
      {
        case ColorType.ByLayer:
          if (layer != null)
            return layer.Color.ToArgbColor();
          return ArgbColors.White;
        case ColorType.ByBlock:
          if (byBlockDxfColor != null)
            return byBlockDxfColor.Color.ToArgbColor();
          return byBlockColor.ToArgbColor();
        case ColorType.ByColor:
        case ColorType.ByColorIndex:
        case ColorType.ByPenIndex:
        case ColorType.Foreground:
          return color.ToArgbColor();
        default:
          return DxfIndexedColor.Color[0];
      }
    }

    public DxfLineType GetLineType(DrawContext context)
    {
      DxfLineType dxfLineType;
      if (this.LineType == null)
      {
        this.LineType = context.Model.ByLayerLineType;
        dxfLineType = this.LineType;
      }
      else if (this.LineType == context.Model.ByBlockLineType)
        dxfLineType = context.ByBlockLineType;
      else if (this.LineType == context.Model.ByLayerLineType)
      {
        DxfLayer layer = this.GetLayer(context);
        dxfLineType = layer == null ? context.Model.ContinuousLineType : layer.GetLineType(context.Viewport);
      }
      else
        dxfLineType = this.LineType;
      return dxfLineType;
    }

    public short GetLineWeight(DrawContext context)
    {
      if (!context.Model.Header.DisplayLineWeight && (!context.Layout.PaperSpace || (context.Layout.PlotLayoutFlags & PlotLayoutFlags.PrintLineweights) == PlotLayoutFlags.None))
        return context.Config.DefaultLineWeight;
      short effectiveLineWeight = this.EffectiveLineWeight;
      switch (effectiveLineWeight)
      {
        case -3:
          return context.Config.DefaultLineWeight;
        case -2:
          short num = context.ByBlockLineWeight;
          if (num < (short) 0)
            num = context.Config.DefaultLineWeight;
          return num;
        case -1:
          DxfLayer layer = this.GetLayer(context);
          if (layer != null)
            return layer.GetLineWeight(context.Viewport, context.Config);
          return context.Config.DefaultLineWeight;
        default:
          return effectiveLineWeight;
      }
    }

    public abstract void Accept(IEntityVisitor visitor);

    public virtual void TransformMe(TransformConfig config, Matrix4D matrix)
    {
      throw new Exception("TransformMe method is not implemented.");
    }

    public virtual void TransformMe(
      TransformConfig config,
      Matrix4D matrix,
      CommandGroup undoGroup)
    {
      throw new Exception("TransformMe method is not implemented.");
    }

    public override string ToString()
    {
      return string.Format("Handle = 0x{0}, Type = {1}", (object) this.HandleString, (object) this.GetType().Name);
    }

    public virtual IControlPointCollection InteractionControlPoints
    {
      get
      {
        return ControlPointCollection.Empty;
      }
    }

    public virtual DxfEntity.Interactor CreateCreateInteractor(Transaction transaction)
    {
      return (DxfEntity.Interactor) null;
    }

    public virtual DxfEntity.Interactor CreateEditInteractor()
    {
      return (DxfEntity.Interactor) null;
    }

    public virtual IList<InteractorDescriptor> GetEditInteractorDescriptors()
    {
      return (IList<InteractorDescriptor>) new InteractorDescriptor[0];
    }

    public virtual DxfEntity.Interactor CreateEditInteractor(
      int index,
      CommandInvoker commandInvoker)
    {
      return (DxfEntity.Interactor) null;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfEntity dxfEntity = (DxfEntity) from;
      this.Layer = Class906.GetLayer(cloneContext, dxfEntity.Layer);
      this.entityColor_0 = dxfEntity.entityColor_0;
      this.transparency_0 = dxfEntity.transparency_0;
      this.DxfColor = Class906.smethod_10(cloneContext, dxfEntity.DxfColor);
      this.LineType = Class906.GetLineType(cloneContext, dxfEntity.LineType);
      this.double_0 = dxfEntity.double_0;
      this.short_0 = dxfEntity.short_0;
      this.bool_0 = dxfEntity.bool_0;
      this.bool_1 = dxfEntity.bool_1;
    }

    protected bool IsEntityVisibleInContext(DrawContext context, bool useLayerEnabled)
    {
      if (!this.Visible)
        return false;
      DxfLayer layer = this.GetLayer(context);
      return this.IsVisibleOnLayer(context, layer, useLayerEnabled) && context.IsVisible(this);
    }

    internal override Class259 vmethod_9(FileFormat fileFormat)
    {
      return (Class259) new Class285(this);
    }

    internal override void vmethod_8(Class434 or, Class259 objectBuilder)
    {
    }

    internal override void Read(Class434 or, Class259 objectBuilder)
    {
      or.method_90((Class285) objectBuilder);
    }

    internal virtual void vmethod_11(Class434 or, Class285 entityBuilder, long imageSize)
    {
      or.ObjectBitStream.imethod_52((int) imageSize);
    }

    internal override void Write(Class432 ow)
    {
      ow.method_73(this);
    }

    internal virtual void vmethod_12(Class432 ow)
    {
      ow.ObjectWriter.imethod_14(false);
    }

    internal void method_8(DxfReader r, Class285 entityBuilder)
    {
      r.method_132(entityBuilder);
    }

    internal bool method_9(DxfReader r, Class285 entityBuilder)
    {
      return r.method_133(entityBuilder);
    }

    internal override void Write(DxfWriter w)
    {
      w.method_114(this);
    }

    internal virtual bool vmethod_13(bool blockContextIsPaperSpace)
    {
      return blockContextIsPaperSpace;
    }

    internal virtual short EffectiveLineWeight
    {
      get
      {
        return this.short_0;
      }
    }

    internal override void Repair(DxfModelRepairer repairer)
    {
      base.Repair(repairer);
      if (this.Layer == null)
        this.Layer = repairer.Model.ZeroLayer;
      if (this.LineType != null)
        return;
      this.LineType = repairer.Model.ByLayerLineType;
    }

    internal void method_10(bool paperSpace)
    {
      this.bool_1 = paperSpace;
    }

    internal void method_11(DxfColor dxfColor)
    {
      this.DxfColor = dxfColor;
    }

    protected internal virtual bool UseLayerEnabled
    {
      get
      {
        return true;
      }
    }

    protected internal bool IsVisibleOnLayer(
      DrawContext context,
      DxfLayer layer,
      bool useLayerEnabled)
    {
      bool flag = true;
      if (layer != null && (useLayerEnabled && (!layer.Enabled || context.Config.Plot && !layer.PlotEnabled) && !context.Config.ShowDisabledLayers || layer.Frozen && !context.Config.ShowFrozenLayers))
        flag = false;
      return flag;
    }

    internal void method_12(DxfEntity from)
    {
      this.Layer = from.Layer;
      this.entityColor_0 = from.entityColor_0;
      this.transparency_0 = from.transparency_0;
      this.DxfColor = from.DxfColor;
      this.LineType = from.LineType;
      this.double_0 = from.double_0;
      this.short_0 = from.short_0;
      this.bool_0 = from.bool_0;
      this.bool_1 = from.bool_1;
    }

    internal override void vmethod_3(DxfModel modelContext)
    {
      base.vmethod_3(modelContext);
      if (this.LineType != null)
        return;
      this.LineType = modelContext.ByLayerLineType;
    }

    public abstract class Interactor : WW.Actions.Interactor
    {
      private static readonly IControlPoint[] icontrolPoint_0 = new IControlPoint[0];
      private DxfEntity dxfEntity_0;
      private WW.Math.Point3D? nullable_0;
      private bool bool_0;

      public event EventHandler<EntityEventArgs> EntityChanged;

      protected Interactor(DxfEntity entity)
      {
        this.dxfEntity_0 = entity;
      }

      public DxfEntity Entity
      {
        get
        {
          return this.dxfEntity_0;
        }
      }

      public virtual IControlPointCollection ControlPoints
      {
        get
        {
          return this.dxfEntity_0.InteractionControlPoints;
        }
      }

      public WW.Math.Point3D? MouseWcsPosition
      {
        get
        {
          return this.nullable_0;
        }
      }

      public bool PositionIsSnapped
      {
        get
        {
          return this.bool_0;
        }
      }

      public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
      {
        if (this.IsActive)
        {
          this.nullable_0 = new WW.Math.Point3D?(this.GetWcsPosition(e, context));
          this.bool_0 = e.WcsPositionIsSnapped;
        }
        return this.IsActive;
      }

      public virtual bool TryCommit()
      {
        return false;
      }

      public abstract void Cancel();

      public WW.Math.Point3D GetWcsPosition(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        return this.ProcessWcsPosition(context, e.GetWcsPosition(context));
      }

      public virtual IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new WW.Actions.Interactor.WinFormsDrawable();
      }

      protected virtual WW.Math.Point3D ProcessWcsPosition(
        InteractionContext context,
        WW.Math.Point3D p)
      {
        return p;
      }

      protected virtual void OnEntityChanged(EntityEventArgs e)
      {
        if (this.eventHandler_0 == null)
          return;
        this.eventHandler_0((object) this, e);
      }

      protected virtual void UpdateEntityPostAction()
      {
      }

      public class WinFormsDrawable : WW.Actions.Interactor.WinFormsDrawable
      {
        private readonly DxfEntity.Interactor interactor_0;

        public WinFormsDrawable(DxfEntity.Interactor interactor)
        {
          this.interactor_0 = interactor;
        }

        public DxfEntity.Interactor Interactor
        {
          get
          {
            return this.interactor_0;
          }
        }
      }
    }

    public class EditInteractor : DxfEntity.Interactor
    {
      private int int_1 = -1;
      private int int_2 = -1;
      private WW.Math.Point3D point3D_0;
      private int int_0;

      public EditInteractor(DxfEntity entity)
        : base(entity)
      {
      }

      public WW.Math.Point3D ControlPointValueAtFirstMouseDown
      {
        get
        {
          return this.point3D_0;
        }
      }

      public int ClickCount
      {
        get
        {
          return this.int_0;
        }
      }

      public int ControlPointIndexAtFirstMouseDown
      {
        get
        {
          return this.int_1;
        }
      }

      public int ControlPointIndexAtMousePosition
      {
        get
        {
          return this.int_2;
        }
      }

      public override void Cancel()
      {
        this.Deactivate();
      }

      public override bool ProcessMouseButtonDown(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        if (!this.IsActive)
        {
          if (this.int_0 == 0)
          {
            this.int_1 = this.int_2 = this.method_1(context, e.Position);
            if (this.int_1 >= 0)
            {
              this.Activate();
              this.point3D_0 = this.Entity.InteractionControlPoints.Get(this.int_1);
            }
          }
          else if (this.int_0 > 0)
            this.method_0(e, context);
        }
        return this.IsActive;
      }

      public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
      {
        base.ProcessMouseMove(e, context);
        this.int_2 = this.method_1(context, e.Position);
        if (this.IsActive && this.int_0 > 0)
          this.method_0(e, context);
        return this.IsActive;
      }

      public override bool ProcessMouseButtonUp(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        this.int_2 = this.method_1(context, e.Position);
        bool isActive = this.IsActive;
        if (this.IsActive)
        {
          if (this.int_0 > 0)
          {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            DxfEntity.EditInteractor.Class16 class16 = new DxfEntity.EditInteractor.Class16();
            // ISSUE: reference to a compiler-generated field
            class16.editInteractor_0 = this;
            int int1 = this.int_1;
            WW.Math.Point3D point3D0 = this.point3D_0;
            WW.Math.Point3D newOcsPoint = this.Entity.Transform.GetInverse().Transform(this.GetWcsPosition(e, context));
            // ISSUE: reference to a compiler-generated field
            class16.action_0 = this.CreateDoAction(int1, newOcsPoint);
            // ISSUE: reference to a compiler-generated field
            class16.action_1 = this.CreateUndoAction(int1, point3D0);
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.OnCommandCreated(new CommandEventArgs((ICommand) new WW.Actions.Command((object) this.Entity, new System.Action(class16.method_0), new System.Action(class16.method_1))));
            this.Deactivate();
          }
          else
            ++this.int_0;
        }
        return isActive;
      }

      protected virtual System.Action CreateDoAction(
        int controlPointIndex,
        WW.Math.Point3D newOcsPoint)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        return new System.Action(new DxfEntity.EditInteractor.Class17() { int_0 = controlPointIndex, point3D_0 = newOcsPoint, editInteractor_0 = this }.method_0);
      }

      protected virtual System.Action CreateUndoAction(
        int controlPointIndex,
        WW.Math.Point3D originalOcsPoint)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        return new System.Action(new DxfEntity.EditInteractor.Class18() { int_0 = controlPointIndex, point3D_0 = originalOcsPoint, editInteractor_0 = this }.method_0);
      }

      public override void Deactivate()
      {
        base.Deactivate();
        this.int_1 = -1;
        this.int_0 = 0;
      }

      public override string UserHint
      {
        get
        {
          return Class881.DxfEntity_EditInteractor_UserHint;
        }
      }

      public override IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new DxfEntity.EditInteractor.WinFormsDrawable(this);
      }

      private void method_0(CanonicalMouseEventArgs e, InteractionContext context)
      {
        this.Entity.InteractionControlPoints.Set(this.int_1, this.GetWcsPosition(e, context));
        this.UpdateEntityPostAction();
        this.OnEntityChanged(new EntityEventArgs(this.Entity));
      }

      private int method_1(InteractionContext context, WW.Math.Point2D mousePosition)
      {
        double tolerance = 0.5 * context.EditHandleSize;
        int num = -1;
        IControlPointCollection interactionControlPoints = this.Entity.InteractionControlPoints;
        Matrix4D matrix4D = context.ProjectionTransform * this.Entity.Transform;
        for (int index = 0; index < interactionControlPoints.Count; ++index)
        {
          if (WW.Math.Point2D.AreApproxEqual((WW.Math.Point2D) matrix4D.Transform(interactionControlPoints.Get(index)), mousePosition, tolerance))
          {
            num = index;
            break;
          }
        }
        return num;
      }

      public class WinFormsDrawable : DxfEntity.Interactor.WinFormsDrawable
      {
        public WinFormsDrawable(DxfEntity.EditInteractor interactor)
          : base((DxfEntity.Interactor) interactor)
        {
        }

        public DxfEntity.EditInteractor EditInteractor
        {
          get
          {
            return (DxfEntity.EditInteractor) this.Interactor;
          }
        }

        public override void Draw(
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context)
        {
          base.Draw(e, graphicsHelper, context);
          IControlPointCollection controlPoints = this.Interactor.ControlPoints;
          Matrix4D matrix4D1 = context.ProjectionTransform * this.Interactor.Entity.Transform;
          for (int index = 0; index < controlPoints.Count; ++index)
            graphicsHelper.DrawEditHandle(e.Graphics, graphicsHelper.DefaultPen, matrix4D1.TransformTo2D(controlPoints.Get(index)));
          DxfEntity.Interactor interactor = this.Interactor;
          if (!interactor.MouseWcsPosition.HasValue)
            return;
          Matrix4D matrix4D2 = context.ProjectionTransform * this.Interactor.Entity.Transform;
          graphicsHelper.DrawEditHandle(e.Graphics, interactor.PositionIsSnapped ? graphicsHelper.HighlightPen : graphicsHelper.DefaultPen, matrix4D2.TransformTo2D(interactor.MouseWcsPosition.Value));
        }

        public override Cursor GetCursor()
        {
          Cursor cursor = (Cursor) null;
          if (this.EditInteractor.int_1 >= 0 || this.EditInteractor.int_2 >= 0)
            cursor = Cursors.Hand;
          return cursor;
        }
      }
    }

    public abstract class CreateInteractor : DxfEntity.Interactor
    {
      public CreateInteractor(DxfEntity entity)
        : base(entity)
      {
      }

      public override IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new DxfEntity.CreateInteractor.WinFormsDrawable((DxfEntity.Interactor) this);
      }

      public class WinFormsDrawable : DxfEntity.Interactor.WinFormsDrawable
      {
        public WinFormsDrawable(DxfEntity.Interactor interactor)
          : base(interactor)
        {
        }

        public override void Draw(
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context)
        {
          base.Draw(e, graphicsHelper, context);
          IControlPointCollection controlPoints = this.Interactor.ControlPoints;
          Matrix4D matrix4D = context.ProjectionTransform * this.Interactor.Entity.Transform;
          for (int index = 0; index < controlPoints.Count; ++index)
          {
            WW.Math.Point2D position = matrix4D.TransformTo2D(controlPoints.Get(index));
            switch (controlPoints.GetDisplayType(index))
            {
              case PointDisplayType.Default:
                int x = (int) System.Math.Round(position.X);
                int y = (int) System.Math.Round(position.Y);
                Class735.smethod_3(e.Graphics, graphicsHelper.DefaultPen.Color, x, y);
                break;
              case PointDisplayType.EditHandle:
                GdiDrawUtil.DrawEditHandle(e.Graphics, graphicsHelper.DefaultPen, position, context.EditHandleSize);
                break;
              case PointDisplayType.CrossHair:
                int num1 = (int) System.Math.Round(position.X);
                int num2 = (int) System.Math.Round(position.Y);
                int x1 = (int) System.Math.Round((double) num1 - 0.5 * context.CrossHairSize);
                int y1 = (int) System.Math.Round((double) num2 - 0.5 * context.CrossHairSize);
                int x2 = (int) System.Math.Round((double) num1 + 0.5 * context.CrossHairSize);
                int y2 = (int) System.Math.Round((double) num2 + 0.5 * context.CrossHairSize);
                e.Graphics.DrawLine(graphicsHelper.DefaultPen, x1, num2, x2, num2);
                e.Graphics.DrawLine(graphicsHelper.DefaultPen, num1, y1, num1, y2);
                break;
            }
          }
        }

        public override Cursor GetCursor()
        {
          return Cursors.Cross;
        }
      }
    }

    public class DefaultCreateInteractor : DxfEntity.CreateInteractor
    {
      private IControlPointCollection icontrolPointCollection_0;
      private int int_0;
      private ITransaction itransaction_0;

      public DefaultCreateInteractor(DxfEntity entity, ITransaction transaction)
        : this(entity, transaction, entity.InteractionControlPoints)
      {
      }

      public DefaultCreateInteractor(
        DxfEntity entity,
        ITransaction transaction,
        IControlPointCollection controlPoints)
        : base(entity)
      {
        this.itransaction_0 = transaction;
        this.itransaction_0.Completed += new EventHandler(this.itransaction_0_Completed);
        this.icontrolPointCollection_0 = controlPoints;
      }

      public override IControlPointCollection ControlPoints
      {
        get
        {
          return this.icontrolPointCollection_0;
        }
      }

      public int ControlPointIndex
      {
        get
        {
          return this.int_0;
        }
      }

      public virtual IControlPoint ControlPointTemplate
      {
        get
        {
          return (IControlPoint) null;
        }
      }

      public virtual int ControlPointCommitIndex
      {
        get
        {
          return this.icontrolPointCollection_0.Count - 1;
        }
      }

      public ITransaction Transaction
      {
        get
        {
          return this.itransaction_0;
        }
      }

      public override bool TryCommit()
      {
        this.itransaction_0.Commit();
        return true;
      }

      public override void Cancel()
      {
        this.itransaction_0.Rollback();
      }

      public override void Deactivate()
      {
        if (this.itransaction_0.Status == TransactionStatus.Open)
          this.itransaction_0.Rollback();
        base.Deactivate();
      }

      public override bool ProcessMouseButtonDown(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        if (!this.IsActive)
          return false;
        if (!e.LeftButtonDown)
          return e.RightButtonDown;
        return true;
      }

      public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
      {
        base.ProcessMouseMove(e, context);
        if (this.IsActive)
        {
          WW.Math.Point3D point3D = this.Entity.Transform.GetInverse().Transform(this.GetWcsPosition(e, context));
          if (this.int_0 >= 0 && this.int_0 < this.icontrolPointCollection_0.Count)
          {
            for (int int0 = this.int_0; int0 < this.icontrolPointCollection_0.Count; ++int0)
              this.icontrolPointCollection_0.Set(int0, point3D);
            this.UpdateEntityPostAction();
            this.OnEntityChanged(new EntityEventArgs(this.Entity));
          }
        }
        return this.IsActive;
      }

      public override bool ProcessMouseButtonUp(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        bool flag;
        if (flag = this.IsActive && (e.LeftButtonDown || e.RightButtonDown))
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          DxfEntity.DefaultCreateInteractor.Class19 class19 = new DxfEntity.DefaultCreateInteractor.Class19();
          WW.Math.Point3D wcsPosition = this.GetWcsPosition(e, context);
          // ISSUE: reference to a compiler-generated field
          class19.point3D_0 = this.Entity.Transform.GetInverse().Transform(wcsPosition);
          if (this.int_0 >= 0 && this.int_0 < this.icontrolPointCollection_0.Count || !this.Entity.InteractionControlPoints.IsCountFixed)
          {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            DxfEntity.DefaultCreateInteractor.Class20 class20 = new DxfEntity.DefaultCreateInteractor.Class20();
            // ISSUE: reference to a compiler-generated field
            class20.class19_0 = class19;
            // ISSUE: reference to a compiler-generated field
            class20.defaultCreateInteractor_0 = this;
            // ISSUE: reference to a compiler-generated field
            class20.bool_0 = !this.Entity.InteractionControlPoints.IsCountFixed ? e.RightButtonDown : this.int_0 >= this.ControlPointCommitIndex;
            CommandGroup commandGroup = new CommandGroup((object) this.Entity);
            commandGroup.DoStack.Push((ICommand) new WW.Actions.Command((object) this.Entity, (System.Action) (() => ++this.int_0), (System.Action) (() => --this.int_0)));
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            WW.Actions.Command command = new WW.Actions.Command((object) this.Entity, new System.Action(class20.method_0), new System.Action(class20.method_1));
            commandGroup.DoStack.Push((ICommand) command);
            this.itransaction_0.Add((ICommand) commandGroup);
            // ISSUE: reference to a compiler-generated field
            if (class20.bool_0)
              this.itransaction_0.Commit();
          }
        }
        return flag;
      }

      public override string UserHint
      {
        get
        {
          if (this.icontrolPointCollection_0.IsCountFixed)
          {
            string str = this.int_0 < 0 || this.int_0 >= this.icontrolPointCollection_0.Count ? (string) null : this.icontrolPointCollection_0.GetDescription(this.int_0);
            if (string.IsNullOrEmpty(str))
              return base.UserHint;
            return string.Format(Class881.DxfEntity_DefaultCreateInteractor_UserHint_FixedControlPointCount, (object) str);
          }
          IControlPoint controlPointTemplate = this.ControlPointTemplate;
          if (controlPointTemplate == null)
            return base.UserHint;
          return string.Format(Class881.DxfEntity_DefaultCreateInteractor_UserHint_VariableControlPointCount, (object) controlPointTemplate.Description);
        }
      }

      public override IInteractorWinFormsDrawable CreateWinFormsDrawable(
        InteractionContext context,
        Control hostControl)
      {
        return (IInteractorWinFormsDrawable) new DxfEntity.DefaultCreateInteractor.WinFormsDrawable((DxfEntity.Interactor) this);
      }

      private void itransaction_0_Completed(object sender, EventArgs e)
      {
        if (this.IsActive)
          this.Deactivate();
        this.itransaction_0.Completed -= new EventHandler(this.itransaction_0_Completed);
      }

      public class WinFormsDrawable : DxfEntity.CreateInteractor.WinFormsDrawable
      {
        public WinFormsDrawable(DxfEntity.Interactor interactor)
          : base(interactor)
        {
        }

        public override void Draw(
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context)
        {
          base.Draw(e, graphicsHelper, context);
          DxfEntity.DefaultCreateInteractor interactor = (DxfEntity.DefaultCreateInteractor) this.Interactor;
          if (!interactor.MouseWcsPosition.HasValue)
            return;
          Matrix4D matrix4D = context.ProjectionTransform * this.Interactor.Entity.Transform;
          graphicsHelper.DrawEditHandle(e.Graphics, interactor.PositionIsSnapped ? graphicsHelper.HighlightPen : graphicsHelper.DefaultPen, matrix4D.TransformTo2D(interactor.MouseWcsPosition.Value));
        }
      }
    }

    public class DefaultEditInteractor : DxfEntity.EditInteractor
    {
      public DefaultEditInteractor(DxfEntity entity)
        : base(entity)
      {
      }
    }
  }
}
