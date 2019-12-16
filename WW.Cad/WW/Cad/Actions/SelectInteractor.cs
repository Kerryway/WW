// Decompiled with JetBrains decompiler
// Type: WW.Cad.Actions.SelectInteractor
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns43;
using ns48;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using WW.Actions;
using WW.Cad.Actions.Windows.Forms;
using WW.Cad.Drawing;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;
using WW.Windows.Forms;

namespace WW.Cad.Actions
{
  public class SelectInteractor : WW.Actions.Interactor, IDisposable
  {
    private bool bool_1 = true;
    private readonly List<RenderedEntityInfo> list_0 = new List<RenderedEntityInfo>();
    private readonly CommandGroup commandGroup_0 = new CommandGroup();
    private DxfModel dxfModel_0;
    private DxfLayout dxfLayout_0;
    private DxfEntityCollection dxfEntityCollection_0;
    private bool bool_0;
    private WireframeGraphicsCache wireframeGraphicsCache_0;
    private readonly GraphicsConfig graphicsConfig_0;
    private Matrix4D matrix4D_0;
    private Bounds3D bounds3D_0;
    private WW.Math.Point2D point2D_0;
    private WW.Math.Point2D point2D_1;
    private CommandInvoker commandInvoker_0;

    public event EventHandler<SelectInteractor.TransformEventArgs> SelectionTransformed;

    public event EventHandler SelectionChanged;

    public SelectInteractor(
      WireframeGraphicsCache wireframeGraphicsCache,
      GraphicsConfig graphicsConfig,
      CommandInvoker commandInvoker)
      : this(wireframeGraphicsCache, graphicsConfig, (DxfModel) null, (DxfLayout) null, (DxfEntityCollection) null, commandInvoker)
    {
    }

    public SelectInteractor(
      WireframeGraphicsCache wireframeGraphicsCache,
      GraphicsConfig graphicsConfig,
      DxfModel model,
      DxfEntityCollection entities,
      CommandInvoker commandInvoker)
      : this(wireframeGraphicsCache, graphicsConfig, model, (DxfLayout) null, entities, commandInvoker)
    {
    }

    public SelectInteractor(
      WireframeGraphicsCache wireframeGraphicsCache,
      GraphicsConfig graphicsConfig,
      DxfModel model,
      DxfLayout layout,
      DxfEntityCollection entities,
      CommandInvoker commandInvoker)
    {
      this.wireframeGraphicsCache_0 = wireframeGraphicsCache;
      this.graphicsConfig_0 = graphicsConfig;
      this.dxfModel_0 = model;
      if (model != null && layout != model.ModelLayout)
        this.dxfLayout_0 = layout;
      this.dxfEntityCollection_0 = entities;
      this.commandInvoker_0 = commandInvoker;
      wireframeGraphicsCache.Changed += new EventHandler(this.method_0);
    }

    public List<RenderedEntityInfo> SelectedEntities
    {
      get
      {
        return this.list_0;
      }
    }

    public bool YAxisPointsDown
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

    public Matrix4D ProjectionTransform
    {
      get
      {
        return this.matrix4D_0;
      }
      set
      {
        this.matrix4D_0 = value;
        this.bounds3D_0 = (Bounds3D) null;
      }
    }

    public Bounds3D SelectionBounds
    {
      get
      {
        this.method_2();
        return this.bounds3D_0;
      }
    }

    public void SetLayout(DxfModel model, DxfLayout layout, DxfEntityCollection entities)
    {
      this.dxfModel_0 = model;
      this.dxfLayout_0 = layout;
      this.dxfEntityCollection_0 = entities;
      this.bool_0 = true;
      int count = this.list_0.Count;
      this.list_0.Clear();
      this.OnSelectionChanged(EventArgs.Empty);
    }

    public override bool ProcessMouseButtonDown(
      CanonicalMouseEventArgs e,
      InteractionContext context)
    {
      if (e.LeftButtonDown)
      {
        this.point2D_1 = context.InverseProjectionTransform.Transform(e.Position);
        this.point2D_0 = this.point2D_1;
        this.Activate();
      }
      return this.IsActive;
    }

    public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (this.IsActive)
        this.point2D_0 = context.InverseProjectionTransform.Transform(e.Position);
      return this.IsActive;
    }

    public override bool ProcessMouseButtonUp(CanonicalMouseEventArgs e, InteractionContext context)
    {
      if (!this.IsActive)
        return false;
      this.point2D_0 = context.InverseProjectionTransform.Transform(e.Position);
      this.method_3(e, context);
      this.Deactivate();
      return true;
    }

    public void Transform(
      Matrix4D transform,
      WW.Math.Vector3D scaling,
      WW.Math.Vector3D translation,
      bool isIntermediateTransform)
    {
      CommandGroup undoGroup = new CommandGroup();
      this.commandGroup_0.DoStack.Clear();
      this.commandGroup_0.UndoStack.Push((WW.Actions.ICommand) undoGroup);
      foreach (RenderedEntityInfo renderedEntityInfo in this.list_0)
      {
        try
        {
          renderedEntityInfo.Entity.TransformMe((TransformConfig) this.graphicsConfig_0, transform, undoGroup);
        }
        catch (Exception ex)
        {
        }
      }
      this.bool_0 = true;
      this.OnSelectionTransformed(new SelectInteractor.TransformEventArgs(transform, scaling, translation, (WW.Actions.ICommand) undoGroup, isIntermediateTransform));
    }

    public void Select(List<DxfEntity> entities, Matrix4D projectionTransform)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      SelectInteractor.Class395 class395 = new SelectInteractor.Class395();
      this.list_0.Clear();
      this.UpdateGraphicsCache();
      // ISSUE: reference to a compiler-generated field
      class395.hashSet_0 = new HashSet<DxfEntity>((IEnumerable<DxfEntity>) entities);
      // ISSUE: reference to a compiler-generated method
      EntityFilterDelegate filterDelegate = new EntityFilterDelegate(class395.method_0);
      IList<RenderedEntityInfo> unprocessedSelection = this.dxfLayout_0 == null || !this.dxfLayout_0.PaperSpace ? EntitySelector.GetFilteredEntities(this.dxfModel_0, (IEnumerable<DxfEntity>) entities, this.graphicsConfig_0, projectionTransform, filterDelegate) : SelectInteractor.GetEntitiesInFilter(this.dxfModel_0, this.dxfLayout_0, (IEnumerable<DxfEntity>) entities, this.graphicsConfig_0, projectionTransform, filterDelegate);
      this.method_4(unprocessedSelection);
      this.list_0.AddRange((IEnumerable<RenderedEntityInfo>) unprocessedSelection);
      this.bool_0 = true;
      this.OnSelectionChanged(EventArgs.Empty);
    }

    protected virtual void OnSelectionTransformed(SelectInteractor.TransformEventArgs e)
    {
      this.bounds3D_0 = (Bounds3D) null;
      if (this.eventHandler_0 == null)
        return;
      this.eventHandler_0((object) this, e);
    }

    protected virtual void OnSelectionChanged(EventArgs e)
    {
      this.bounds3D_0 = (Bounds3D) null;
      if (this.eventHandler_1 == null)
        return;
      this.eventHandler_1((object) this, e);
    }

    private void method_0(object sender, EventArgs e)
    {
      this.bounds3D_0 = (Bounds3D) null;
    }

    private void method_1()
    {
      this.commandGroup_0.Clear();
    }

    private void method_2()
    {
      if (this.bounds3D_0 != null)
        return;
      this.UpdateGraphicsCache();
      BoundsCalculator boundsCalculator = new BoundsCalculator();
      IWireframeGraphicsFactory transformingGraphicsFactory = boundsCalculator.CreateTransformingGraphicsFactory(this.matrix4D_0);
      foreach (RenderedEntityInfo renderedEntityInfo in this.list_0)
      {
        foreach (IWireframeDrawable drawable in (IEnumerable<IWireframeDrawable>) this.wireframeGraphicsCache_0.GetDrawables(renderedEntityInfo))
          drawable.Draw(transformingGraphicsFactory);
      }
      this.bounds3D_0 = boundsCalculator.Bounds;
    }

    private static OrientedRectangle2D smethod_0(
      Matrix4D transform,
      OrientedBox3D box)
    {
      OrientedRectangle2D orientedRectangle2D = new OrientedRectangle2D(transform.TransformTo2D(box.Origin), transform.TransformTo2D(box.XAxis), transform.TransformTo2D(box.YAxis));
      if (box.XAxis.X < 0.0)
      {
        orientedRectangle2D.Origin += orientedRectangle2D.XAxis;
        orientedRectangle2D.XAxis = -orientedRectangle2D.XAxis;
      }
      if (box.YAxis.Y < 0.0)
      {
        orientedRectangle2D.Origin += orientedRectangle2D.YAxis;
        orientedRectangle2D.YAxis = -orientedRectangle2D.YAxis;
      }
      return orientedRectangle2D;
    }

    private static int smethod_1(WW.Math.Point2D position, WW.Math.Point2D[] editHandlePositions, double margin)
    {
      int num = -1;
      for (int index = 1; index < editHandlePositions.Length; index += 2)
      {
        if (WW.Math.Point2D.AreApproxEqual(editHandlePositions[index], position, margin))
        {
          num = index;
          break;
        }
      }
      if (num < 0)
      {
        for (int index = 0; index < editHandlePositions.Length; index += 2)
        {
          if (WW.Math.Point2D.AreApproxEqual(editHandlePositions[index], position, margin))
          {
            num = index;
            break;
          }
        }
      }
      return num;
    }

    private void method_3(CanonicalMouseEventArgs e, InteractionContext context)
    {
      this.UpdateGraphicsCache();
      WW.Math.Point2D a = context.ProjectionTransform.Transform(this.point2D_1);
      WW.Math.Point2D b = context.ProjectionTransform.Transform(this.point2D_0);
      bool flag;
      IList<RenderedEntityInfo> renderedEntityInfoList;
      if (WW.Math.Point2D.AreApproxEqual(a, b, this.graphicsConfig_0.NodeSize))
      {
        flag = false;
        renderedEntityInfoList = this.dxfLayout_0 == null || !this.dxfLayout_0.PaperSpace ? EntitySelector.GetEntitiesCloseToPoint(this.dxfModel_0, (IEnumerable<DxfEntity>) this.dxfEntityCollection_0, this.graphicsConfig_0, context.ProjectionTransform, e.Position, this.graphicsConfig_0.NodeSize, (EntityFilterDelegate) null) : SelectInteractor.GetEntitiesCloseToPoint(this.dxfModel_0, this.dxfLayout_0, (IEnumerable<DxfEntity>) this.dxfEntityCollection_0, this.graphicsConfig_0, context.ProjectionTransform, e.Position, this.graphicsConfig_0.NodeSize, (EntityFilterDelegate) null);
      }
      else
      {
        flag = true;
        renderedEntityInfoList = this.dxfLayout_0 == null || !this.dxfLayout_0.PaperSpace ? EntitySelector.GetEntitiesInRectangle(this.dxfModel_0, (IEnumerable<DxfEntity>) this.dxfEntityCollection_0, this.graphicsConfig_0, context.ProjectionTransform, new Rectangle2D(new WW.Math.Point2D(System.Math.Min(a.X, b.X), System.Math.Min(a.Y, b.Y)), new WW.Math.Point2D(System.Math.Max(a.X, b.X), System.Math.Max(a.Y, b.Y))), (EntityFilterDelegate) null) : SelectInteractor.GetEntitiesInRectangle(this.dxfModel_0, this.dxfLayout_0, (IEnumerable<DxfEntity>) this.dxfEntityCollection_0, this.graphicsConfig_0, context.ProjectionTransform, new Rectangle2D(new WW.Math.Point2D(System.Math.Min(a.X, b.X), System.Math.Min(a.Y, b.Y)), new WW.Math.Point2D(System.Math.Max(a.X, b.X), System.Math.Max(a.Y, b.Y))), (EntityFilterDelegate) null);
      }
      this.method_4(renderedEntityInfoList);
      if (Keyboard.Modifiers == ModifierKeys.Control)
      {
        for (int index1 = this.list_0.Count - 1; index1 >= 0; --index1)
        {
          int index2 = SelectInteractor.smethod_2(this.list_0[index1], renderedEntityInfoList);
          if (index2 >= 0)
          {
            this.list_0.RemoveAt(index1);
            renderedEntityInfoList.RemoveAt(index2);
          }
        }
      }
      else
      {
        if (WW.Math.Point2D.AreApproxEqual(context.ProjectionTransform.Transform(this.point2D_1), e.Position, this.graphicsConfig_0.NodeSize) && !flag && (this.list_0.Count > 0 && renderedEntityInfoList.Count > 1))
        {
          int num = SelectInteractor.smethod_2(this.list_0[0], renderedEntityInfoList);
          if (num >= 0)
          {
            RenderedEntityInfo renderedEntityInfo = renderedEntityInfoList[(num + 1) % renderedEntityInfoList.Count];
            renderedEntityInfoList.Clear();
            renderedEntityInfoList.Add(renderedEntityInfo);
          }
        }
        if (!flag)
        {
          while (renderedEntityInfoList.Count > 1)
            renderedEntityInfoList.RemoveAt(renderedEntityInfoList.Count - 1);
        }
        this.list_0.Clear();
      }
      this.list_0.AddRange((IEnumerable<RenderedEntityInfo>) renderedEntityInfoList);
      this.bool_0 = true;
      this.OnSelectionChanged(EventArgs.Empty);
    }

    private void method_4(IList<RenderedEntityInfo> unprocessedSelection)
    {
      HashSet<DxfEntity> dxfEntitySet = new HashSet<DxfEntity>();
      for (int index = unprocessedSelection.Count - 1; index >= 0; --index)
      {
        RenderedEntityInfo renderedEntityInfo = unprocessedSelection[index];
        if (renderedEntityInfo.Parent == null)
          dxfEntitySet.Add(renderedEntityInfo.Entity);
      }
      for (int index = unprocessedSelection.Count - 1; index >= 0; --index)
      {
        RenderedEntityInfo renderedEntityInfo = unprocessedSelection[index];
        if (renderedEntityInfo.Parent != null)
        {
          RenderedEntityInfo root = renderedEntityInfo.GetRoot();
          if (this.graphicsConfig_0.TreatAttributesAsPartOfInsert || !(renderedEntityInfo.Entity is DxfAttribute) || root != renderedEntityInfo.Parent)
          {
            if (!dxfEntitySet.Contains(root.Entity))
            {
              dxfEntitySet.Add(root.Entity);
              unprocessedSelection[index] = root;
            }
            else
              unprocessedSelection.RemoveAt(index);
          }
        }
      }
      if (this.graphicsConfig_0.TreatAttributesAsPartOfInsert)
        return;
      for (int index = unprocessedSelection.Count - 1; index >= 0; --index)
      {
        RenderedEntityInfo renderedEntityInfo = unprocessedSelection[index];
        if (renderedEntityInfo.Parent != null)
        {
          RenderedEntityInfo root = renderedEntityInfo.GetRoot();
          if (renderedEntityInfo.Entity is DxfAttribute && root == renderedEntityInfo.Parent)
          {
            if (!dxfEntitySet.Contains(renderedEntityInfo.Entity) && !dxfEntitySet.Contains(root.Entity))
              dxfEntitySet.Add(renderedEntityInfo.Entity);
            else
              unprocessedSelection.RemoveAt(index);
          }
        }
      }
    }

    public static IList<RenderedEntityInfo> GetEntitiesCloseToPoint(
      DxfModel model,
      DxfLayout layout,
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
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.PaperToPaperSpace(model, layout, config, transformation))
        layout.Draw(context, (IWireframeGraphicsFactory) class584);
      return (IList<RenderedEntityInfo>) class584.Entities;
    }

    public static IList<RenderedEntityInfo> GetEntitiesInRectangle(
      DxfModel model,
      DxfLayout layout,
      IEnumerable<DxfEntity> entities,
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
      return (IList<RenderedEntityInfo>) class583.Entities;
    }

    public static IList<RenderedEntityInfo> GetEntitiesInFilter(
      DxfModel model,
      DxfLayout layout,
      IEnumerable<DxfEntity> entities,
      GraphicsConfig config,
      Matrix4D transformation,
      EntityFilterDelegate filterDelegate)
    {
      if (filterDelegate == null)
        filterDelegate = new EntityFilterDelegate(EntitySelector.AlwaysTrueEntityFilter);
      EntitySelector.Class586 class586 = new EntitySelector.Class586(filterDelegate);
      using (DrawContext.Wireframe context = (DrawContext.Wireframe) new DrawContext.Wireframe.PaperToPaperSpace(model, layout, config, transformation))
        layout.Draw(context, (IWireframeGraphicsFactory) class586);
      return (IList<RenderedEntityInfo>) class586.Entities;
    }

    private static int smethod_2(RenderedEntityInfo entity, IList<RenderedEntityInfo> entities)
    {
      int num = -1;
      for (int index = 0; index < entities.Count; ++index)
      {
        if (entity.method_0(entities[index]))
        {
          num = index;
          break;
        }
      }
      return num;
    }

    private void method_5()
    {
      this.commandInvoker_0.Undo((WW.Actions.ICommand) this.commandGroup_0);
      this.bool_0 = true;
      this.bounds3D_0 = (Bounds3D) null;
    }

    public void UpdateGraphicsCache()
    {
      if (!this.bool_0)
        return;
      this.wireframeGraphicsCache_0.SuspendChangeNotification();
      try
      {
        foreach (RenderedEntityInfo renderedEntityInfo in this.list_0)
          this.wireframeGraphicsCache_0.UpdateDrawables(renderedEntityInfo.Entity);
        this.bool_0 = false;
      }
      finally
      {
        this.wireframeGraphicsCache_0.ResumeChangeNotification();
      }
    }

    private static double smethod_3(double numerator, double denominator)
    {
      if (MathUtil.AreApproxEqual(denominator, 0.0))
        return 1.0;
      return numerator / denominator;
    }

    private static OrientedRectangle2D? smethod_4(Bounds3D bounds)
    {
      if (!bounds.Initialized)
        return new OrientedRectangle2D?();
      return new OrientedRectangle2D?(new OrientedRectangle2D((WW.Math.Point2D) bounds.Corner1, new Vector2D(bounds.Delta.X, 0.0), new Vector2D(0.0, bounds.Delta.Y)));
    }

    private WW.Math.Point2D[] method_6(OrientedRectangle2D rectangle)
    {
      if (!this.bool_1)
        return new WW.Math.Point2D[8]{ rectangle.Origin, WW.Math.Point2D.GetMidPoint(rectangle.Origin, rectangle.BottomRight), rectangle.BottomRight, WW.Math.Point2D.GetMidPoint(rectangle.BottomRight, rectangle.TopRight), rectangle.TopRight, WW.Math.Point2D.GetMidPoint(rectangle.TopRight, rectangle.TopLeft), rectangle.TopLeft, WW.Math.Point2D.GetMidPoint(rectangle.TopLeft, rectangle.Origin) };
      return new WW.Math.Point2D[8]{ rectangle.TopLeft, WW.Math.Point2D.GetMidPoint(rectangle.TopRight, rectangle.TopLeft), rectangle.TopRight, WW.Math.Point2D.GetMidPoint(rectangle.BottomRight, rectangle.TopRight), rectangle.BottomRight, WW.Math.Point2D.GetMidPoint(rectangle.Origin, rectangle.BottomRight), rectangle.Origin, WW.Math.Point2D.GetMidPoint(rectangle.TopLeft, rectangle.Origin) };
    }

    public void Dispose()
    {
      if (this.wireframeGraphicsCache_0 == null)
        return;
      this.wireframeGraphicsCache_0.Changed -= new EventHandler(this.method_0);
      this.wireframeGraphicsCache_0 = (WireframeGraphicsCache) null;
    }

    public class TransformInteractor : WW.Actions.Interactor
    {
      private readonly SelectInteractor selectInteractor_0;

      public TransformInteractor(SelectInteractor selectInteractor)
      {
        this.selectInteractor_0 = selectInteractor;
      }

      public SelectInteractor SelectInteractor
      {
        get
        {
          return this.selectInteractor_0;
        }
      }

      protected override void OnActivated(EventArgs e)
      {
        this.selectInteractor_0.method_1();
        base.OnActivated(e);
      }
    }

    public class MoveInteractor : SelectInteractor.TransformInteractor
    {
      private bool bool_3 = true;
      private WW.Math.Point2D? nullable_0;
      private bool bool_0;
      private bool bool_1;
      private bool bool_2;
      private SelectInteractor.SelectionRectangleArea selectionRectangleArea_0;
      private Vector2D? nullable_1;

      public event EventHandler Changed;

      public event EventHandler<InteractorMouseEventArgs> MouseMoveProcessed;

      public event EventHandler StartWcsPositionSet;

      public MoveInteractor(SelectInteractor selectInteractor)
        : base(selectInteractor)
      {
      }

      public SelectInteractor.SelectionRectangleArea MoveSelectionWhenMouseDownAtArea
      {
        get
        {
          return this.selectionRectangleArea_0;
        }
        set
        {
          this.selectionRectangleArea_0 = value;
        }
      }

      public bool StartInteractionOnMouseDownAtSelectionRectangle
      {
        get
        {
          return this.bool_3;
        }
        set
        {
          this.bool_3 = value;
        }
      }

      public override bool ProcessMouseButtonDown(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        bool flag = this.IsActive;
        this.bool_1 = false;
        if (e.LeftButtonDown && !this.bool_0 && this.SelectInteractor.list_0.Count > 0)
        {
          bool isMouseInside;
          this.bool_1 = this.method_0(context, e, out isMouseInside);
          if (this.bool_1 || !this.bool_3)
          {
            this.nullable_0 = new WW.Math.Point2D?((WW.Math.Point2D) e.GetWcsPosition(context));
            this.OnStartWcsPositionSet(EventArgs.Empty);
            flag = true;
          }
        }
        return flag;
      }

      public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
      {
        if (e.LeftButtonDown && this.nullable_0.HasValue && !this.IsActive)
          this.Activate();
        if (this.IsActive && this.nullable_0.HasValue && this.SelectInteractor.SelectedEntities.Count > 0)
        {
          this.nullable_1 = new Vector2D?();
          this.method_1(context, e, true);
          this.OnChanged(EventArgs.Empty);
          this.OnMouseMoveProcessed(new InteractorMouseEventArgs(e, context));
        }
        else
        {
          bool isMouseInside;
          this.bool_2 = this.method_0(context, e, out isMouseInside);
        }
        return this.IsActive;
      }

      public override bool ProcessMouseButtonUp(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        bool flag = this.IsActive;
        if (this.SelectInteractor.SelectedEntities.Count > 0 && this.nullable_0.HasValue)
        {
          if (this.IsActive && (this.bool_0 || this.nullable_0.Value != (WW.Math.Point2D) e.GetWcsPosition(context)))
          {
            this.method_1(context, e, false);
            this.Deactivate();
          }
          else
          {
            this.bool_0 = true;
            if (!this.IsActive)
              this.Activate();
            flag = true;
          }
        }
        this.bool_1 = false;
        return flag;
      }

      public override string UserHint
      {
        get
        {
          if (this.bool_0)
            return Class1040.SelectInteractor_MoveInteractor_PickTargetPoint;
          return Class1040.SelectInteractor_MoveInteractor_PickBasePoint;
        }
      }

      public void Cancel()
      {
        this.SelectInteractor.method_5();
        this.Deactivate();
      }

      protected virtual void OnStartWcsPositionSet(EventArgs e)
      {
        if (this.eventHandler_2 == null)
          return;
        this.eventHandler_2((object) this, e);
      }

      protected virtual void OnChanged(EventArgs e)
      {
        if (this.eventHandler_0 == null)
          return;
        this.eventHandler_0((object) this, e);
      }

      protected virtual void OnMouseMoveProcessed(InteractorMouseEventArgs e)
      {
        if (this.eventHandler_1 == null)
          return;
        this.eventHandler_1((object) this, e);
      }

      protected override void OnDeactivated(EventArgs e)
      {
        this.nullable_0 = new WW.Math.Point2D?();
        this.bool_0 = false;
        this.bool_1 = false;
        this.bool_2 = false;
        base.OnDeactivated(e);
      }

      private bool method_0(
        InteractionContext context,
        CanonicalMouseEventArgs e,
        out bool isMouseInside)
      {
        bool flag = false;
        isMouseInside = false;
        if (this.SelectInteractor.SelectedEntities.Count > 0 && this.SelectInteractor.SelectionBounds.Initialized)
        {
          double editHandleSize = context.EditHandleSize;
          OrientedRectangle2D? nullable = SelectInteractor.smethod_4(this.SelectInteractor.SelectionBounds);
          if (nullable.HasValue)
          {
            this.SelectInteractor.method_6(nullable.Value);
            flag = nullable.Value.BorderContains(e.Position, 0.5 * context.EditHandleSize);
            isMouseInside = nullable.Value.Contains(e.Position);
            if (this.selectionRectangleArea_0 == SelectInteractor.SelectionRectangleArea.InsideSelectionRectangle)
              flag |= isMouseInside;
          }
        }
        return flag;
      }

      private void method_1(
        InteractionContext context,
        CanonicalMouseEventArgs e,
        bool isIntermediateTransform)
      {
        this.SelectInteractor.method_5();
        WW.Math.Point2D wcsPosition = (WW.Math.Point2D) e.GetWcsPosition(context);
        WW.Math.Vector3D vector3D1;
        if (!this.nullable_1.HasValue)
        {
          WW.Math.Point2D point2D = wcsPosition;
          WW.Math.Point2D? nullable0 = this.nullable_0;
          vector3D1 = (WW.Math.Vector3D) (nullable0.HasValue ? new Vector2D?(point2D - nullable0.GetValueOrDefault()) : new Vector2D?()).Value;
        }
        else
          vector3D1 = (WW.Math.Vector3D) this.nullable_1.Value;
        WW.Math.Vector3D vector3D2 = vector3D1;
        this.SelectInteractor.Transform(Transformation4D.Translation(vector3D2), new WW.Math.Vector3D(1.0, 1.0, 1.0), vector3D2, isIntermediateTransform);
      }

      private void method_2(InteractionContext context, bool isIntermediateTransform)
      {
        if (!this.nullable_1.HasValue)
          return;
        this.SelectInteractor.method_5();
        WW.Math.Vector3D vector3D = (WW.Math.Vector3D) this.nullable_1.Value;
        this.SelectInteractor.Transform(Transformation4D.Translation(vector3D), new WW.Math.Vector3D(1.0, 1.0, 1.0), vector3D, isIntermediateTransform);
      }

      public class WinFormsDrawable : WW.Actions.Interactor.WinFormsDrawable
      {
        private readonly SelectInteractor.MoveInteractor moveInteractor_0;
        private InteractionContext interactionContext_0;
        private Control control_0;
        private FloatingForm floatingForm_0;
        private Point2DTextBoxesControl point2DTextBoxesControl_0;
        private bool bool_0;

        public WinFormsDrawable(
          SelectInteractor.MoveInteractor interactor,
          InteractionContext context,
          Control hostControl)
        {
          if (context == null)
            throw new ArgumentNullException(nameof (context));
          this.moveInteractor_0 = interactor;
          this.interactionContext_0 = context;
          this.control_0 = hostControl;
          interactor.Deactivated += new EventHandler(this.method_1);
          interactor.StartWcsPositionSet += new EventHandler(this.method_0);
          this.floatingForm_0 = new FloatingForm();
          this.point2DTextBoxesControl_0 = new Point2DTextBoxesControl();
          this.point2DTextBoxesControl_0.Closed += new EventHandler(this.point2DTextBoxesControl_0_Closed);
        }

        public override System.Windows.Forms.Cursor GetCursor()
        {
          return !this.moveInteractor_0.IsActive || !this.moveInteractor_0.nullable_0.HasValue ? SelectInteractor.MoveInteractor.WinFormsDrawable.GetCursor(this.moveInteractor_0.bool_2) : SelectInteractor.MoveInteractor.WinFormsDrawable.GetCursor(this.moveInteractor_0.bool_1);
        }

        private static System.Windows.Forms.Cursor GetCursor(bool mouseAtSelectionRectangle)
        {
          System.Windows.Forms.Cursor cursor = (System.Windows.Forms.Cursor) null;
          if (mouseAtSelectionRectangle)
            cursor = System.Windows.Forms.Cursors.Hand;
          return cursor;
        }

        private void method_0(object sender, EventArgs e)
        {
          this.moveInteractor_0.Changed += new EventHandler(this.moveInteractor_0_Changed);
          this.moveInteractor_0.MouseMoveProcessed += new EventHandler<InteractorMouseEventArgs>(this.method_2);
          this.point2DTextBoxesControl_0.SetPoint(WW.Math.Point2D.Zero, this.interactionContext_0);
          this.point2DTextBoxesControl_0.PointChanged += new EventHandler(this.point2DTextBoxesControl_0_PointChanged);
          this.floatingForm_0.Size = this.point2DTextBoxesControl_0.Size;
          this.floatingForm_0.Controls.Add((Control) this.point2DTextBoxesControl_0);
          this.floatingForm_0.Show();
        }

        private void method_1(object sender, EventArgs e)
        {
          this.point2DTextBoxesControl_0.PointChanged -= new EventHandler(this.point2DTextBoxesControl_0_PointChanged);
          this.moveInteractor_0.Changed -= new EventHandler(this.moveInteractor_0_Changed);
          this.moveInteractor_0.MouseMoveProcessed -= new EventHandler<InteractorMouseEventArgs>(this.method_2);
          this.floatingForm_0.Hide();
        }

        private void method_2(object sender, InteractorMouseEventArgs e)
        {
          this.floatingForm_0.Location = this.control_0.PointToScreen(new System.Drawing.Point((int) e.MouseEventArgs.Position.X + 5, (int) e.MouseEventArgs.Position.Y - 5 - this.point2DTextBoxesControl_0.Height));
          WW.Math.Vector3D vector3D = e.MouseEventArgs.GetWcsPosition(e.InteractionContext) - (WW.Math.Point3D) this.moveInteractor_0.nullable_0.Value;
          this.bool_0 = true;
          try
          {
            this.point2DTextBoxesControl_0.SetPoint(new WW.Math.Point2D(vector3D.X, vector3D.Y), this.interactionContext_0);
          }
          finally
          {
            this.bool_0 = false;
          }
        }

        private void moveInteractor_0_Changed(object sender, EventArgs e)
        {
          if (!this.moveInteractor_0.nullable_1.HasValue)
            return;
          this.bool_0 = true;
          try
          {
            this.point2DTextBoxesControl_0.SetPoint((WW.Math.Point2D) this.moveInteractor_0.nullable_1.Value, this.interactionContext_0);
          }
          finally
          {
            this.bool_0 = false;
          }
        }

        private void point2DTextBoxesControl_0_PointChanged(object sender, EventArgs e)
        {
          if (this.bool_0)
            return;
          this.moveInteractor_0.nullable_1 = new Vector2D?((Vector2D) this.point2DTextBoxesControl_0.Point);
          this.moveInteractor_0.method_2(this.interactionContext_0, true);
        }

        private void point2DTextBoxesControl_0_Closed(object sender, EventArgs e)
        {
          switch (this.point2DTextBoxesControl_0.DialogResult)
          {
            case DialogResult.OK:
              this.moveInteractor_0.method_2(this.interactionContext_0, false);
              this.moveInteractor_0.Deactivate();
              break;
            case DialogResult.Cancel:
              this.moveInteractor_0.SelectInteractor.method_5();
              this.moveInteractor_0.Cancel();
              break;
          }
        }
      }
    }

    public class WinFormsDrawable : WW.Actions.Interactor.WinFormsDrawable
    {
      private readonly SelectInteractor selectInteractor_0;

      public WinFormsDrawable(SelectInteractor interactor)
      {
        this.selectInteractor_0 = interactor;
      }

      public override void Draw(
        PaintEventArgs e,
        GraphicsHelper graphicsHelper,
        InteractionContext context)
      {
        if (this.selectInteractor_0.list_0.Count > 0)
        {
          BlinnClipper2D blinnClipper2D = new BlinnClipper2D(context.CanvasRectangle.X1, context.CanvasRectangle.X2, context.CanvasRectangle.Y1, context.CanvasRectangle.Y2);
          Bounds3D bounds = new Bounds3D();
          foreach (RenderedEntityInfo renderedEntityInfo in this.selectInteractor_0.list_0)
          {
            BoundsCalculator boundsCalculator = new BoundsCalculator();
            IWireframeGraphicsFactory transformingGraphicsFactory = boundsCalculator.CreateTransformingGraphicsFactory(context.ProjectionTransform);
            foreach (IWireframeDrawable drawable in (IEnumerable<IWireframeDrawable>) this.selectInteractor_0.wireframeGraphicsCache_0.GetDrawables(renderedEntityInfo))
              drawable.Draw(transformingGraphicsFactory);
            if (boundsCalculator.Bounds.Initialized)
            {
              PointF corner1 = (PointF) (WW.Math.Point2D) boundsCalculator.Bounds.Corner1;
              PointF pointF1 = (PointF) ((WW.Math.Point2D) boundsCalculator.Bounds.Corner1 + new Vector2D(boundsCalculator.Bounds.Delta.X, 0.0));
              PointF corner2 = (PointF) (WW.Math.Point2D) boundsCalculator.Bounds.Corner2;
              PointF pointF2 = (PointF) ((WW.Math.Point2D) boundsCalculator.Bounds.Corner1 + new Vector2D(0.0, boundsCalculator.Bounds.Delta.Y));
              bool flag1 = context.CanvasRectangle.IsInside((WW.Math.Point2D) corner1);
              bool flag2 = context.CanvasRectangle.IsInside((WW.Math.Point2D) pointF1);
              bool flag3 = context.CanvasRectangle.IsInside((WW.Math.Point2D) corner2);
              bool flag4 = context.CanvasRectangle.IsInside((WW.Math.Point2D) pointF2);
              if ((!flag1 || !flag2 || !flag3 ? 0 : (flag4 ? 1 : 0)) != 0)
              {
                e.Graphics.DrawPolygon(graphicsHelper.DottedPen, new PointF[4]
                {
                  corner1,
                  pointF1,
                  corner2,
                  pointF2
                });
              }
              else
              {
                PointF[] pointFArray = new PointF[4]{ corner1, pointF1, corner2, pointF2 };
                for (int index = 0; index < pointFArray.Length; ++index)
                {
                  Segment2D? nullable = blinnClipper2D.Clip(new Segment2D((WW.Math.Point2D) pointFArray[index], (WW.Math.Point2D) pointFArray[(index + 1) % pointFArray.Length]));
                  if (nullable.HasValue)
                    e.Graphics.DrawLine(graphicsHelper.DottedPen, (PointF) nullable.Value.Start, (PointF) nullable.Value.End);
                }
              }
            }
            bounds.Update(boundsCalculator.Bounds);
          }
          if (bounds.Initialized)
          {
            WW.Math.Point2D[] point2DArray = this.selectInteractor_0.method_6(SelectInteractor.smethod_4(bounds).Value);
            if (point2DArray != null && point2DArray.Length > 0)
              e.Graphics.DrawPolygon(graphicsHelper.DefaultPen, new PointF[4]
              {
                (PointF) point2DArray[0],
                (PointF) point2DArray[2],
                (PointF) point2DArray[4],
                (PointF) point2DArray[6]
              });
          }
        }
        if (!this.selectInteractor_0.IsActive || WW.Math.Point2D.AreApproxEqual(context.ProjectionTransform.Transform(this.selectInteractor_0.point2D_1), context.ProjectionTransform.Transform(this.selectInteractor_0.point2D_0), context.EditHandleSize))
          return;
        WW.Math.Point2D point2D1 = context.ProjectionTransform.Transform(this.selectInteractor_0.point2D_1);
        WW.Math.Point2D point2D2 = context.ProjectionTransform.Transform(this.selectInteractor_0.point2D_0);
        WW.Math.Point2D point2D3 = new WW.Math.Point2D(System.Math.Min(point2D1.X, point2D2.X), System.Math.Min(point2D1.Y, point2D2.Y));
        WW.Math.Point2D point2D4 = new WW.Math.Point2D(System.Math.Max(point2D1.X, point2D2.X), System.Math.Max(point2D1.Y, point2D2.Y));
        System.Drawing.Point point1 = (System.Drawing.Point) point2D3;
        System.Drawing.Point point2 = (System.Drawing.Point) point2D4;
        e.Graphics.DrawRectangle(graphicsHelper.DefaultPen, point1.X, point1.Y, point2.X - point1.X, point2.Y - point1.Y);
      }
    }

    public class TransformEventArgs : EventArgs
    {
      private Matrix4D matrix4D_0;
      private WW.Math.Vector3D vector3D_0;
      private WW.Math.Vector3D vector3D_1;
      private WW.Actions.ICommand icommand_0;
      private bool bool_0;

      public TransformEventArgs(
        Matrix4D transform,
        WW.Math.Vector3D scaling,
        WW.Math.Vector3D translation,
        WW.Actions.ICommand command,
        bool isIntermediateTransform)
      {
        this.matrix4D_0 = transform;
        this.vector3D_0 = scaling;
        this.vector3D_1 = translation;
        this.icommand_0 = command;
        this.bool_0 = isIntermediateTransform;
      }

      public Matrix4D Transform
      {
        get
        {
          return this.matrix4D_0;
        }
      }

      public WW.Math.Vector3D Scaling
      {
        get
        {
          return this.vector3D_0;
        }
      }

      public WW.Math.Vector3D Translation
      {
        get
        {
          return this.vector3D_1;
        }
      }

      public WW.Actions.ICommand Command
      {
        get
        {
          return this.icommand_0;
        }
      }

      public bool IsIntermediateTransform
      {
        get
        {
          return this.bool_0;
        }
      }
    }

    public enum SelectionRectangleArea
    {
      SelectionRectangle,
      InsideSelectionRectangle,
    }

    public class ScaleFromBasePointInteractor : SelectInteractor.TransformInteractor
    {
      private WW.Math.Point3D? nullable_0;
      private WW.Math.Point3D? nullable_1;
      private WW.Math.Point3D? nullable_2;
      private double? nullable_3;
      private ITransaction itransaction_0;

      public event EventHandler Changed;

      public event EventHandler<InteractorMouseEventArgs> MouseMoveProcessed;

      public ScaleFromBasePointInteractor(
        SelectInteractor selectInteractor,
        ITransaction transaction)
        : base(selectInteractor)
      {
        this.itransaction_0 = transaction;
        transaction.Completed += new EventHandler(this.method_2);
        transaction.RolledBack += new EventHandler(this.method_3);
      }

      public override bool ProcessMouseButtonDown(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        return this.IsActive;
      }

      public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
      {
        if (this.IsActive && this.SelectInteractor.SelectedEntities.Count > 0 && (this.nullable_0.HasValue && this.nullable_1.HasValue))
        {
          this.nullable_2 = new WW.Math.Point3D?(e.GetWcsPosition(context));
          this.nullable_3 = new double?();
          this.method_0(context, e, true);
          this.OnChanged(EventArgs.Empty);
        }
        this.OnMouseMoveProcessed(new InteractorMouseEventArgs(e, context));
        return this.IsActive;
      }

      public override bool ProcessMouseButtonUp(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        SelectInteractor.ScaleFromBasePointInteractor.Class387 class387 = new SelectInteractor.ScaleFromBasePointInteractor.Class387();
        // ISSUE: reference to a compiler-generated field
        class387.canonicalMouseEventArgs_0 = e;
        // ISSUE: reference to a compiler-generated field
        class387.interactionContext_0 = context;
        // ISSUE: reference to a compiler-generated field
        class387.scaleFromBasePointInteractor_0 = this;
        if (!this.IsActive || this.SelectInteractor.SelectedEntities.Count <= 0)
          return false;
        if (this.nullable_0.HasValue)
        {
          if (this.nullable_1.HasValue)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.nullable_2 = new WW.Math.Point3D?(class387.canonicalMouseEventArgs_0.GetWcsPosition(class387.interactionContext_0));
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.method_0(class387.interactionContext_0, class387.canonicalMouseEventArgs_0, false);
            this.itransaction_0.Commit();
          }
          else
          {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            SelectInteractor.ScaleFromBasePointInteractor.Class388 class388 = new SelectInteractor.ScaleFromBasePointInteractor.Class388();
            // ISSUE: reference to a compiler-generated field
            class388.class387_0 = class387;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            class387.canonicalMouseEventArgs_0.GetWcsPosition(class387.interactionContext_0);
            // ISSUE: reference to a compiler-generated field
            class388.nullable_0 = this.nullable_1;
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.itransaction_0.Add((WW.Actions.ICommand) new WW.Actions.Command(new System.Action(class387.method_0), new System.Action(class388.method_0)));
          }
        }
        else
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          SelectInteractor.ScaleFromBasePointInteractor.Class389 class389 = new SelectInteractor.ScaleFromBasePointInteractor.Class389();
          // ISSUE: reference to a compiler-generated field
          class389.class387_0 = class387;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          class387.canonicalMouseEventArgs_0.GetWcsPosition(class387.interactionContext_0);
          // ISSUE: reference to a compiler-generated field
          class389.nullable_0 = this.nullable_0;
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          this.itransaction_0.Add((WW.Actions.ICommand) new WW.Actions.Command(new System.Action(class387.method_1), new System.Action(class389.method_0)));
        }
        this.OnChanged(EventArgs.Empty);
        return true;
      }

      protected override void OnDeactivated(EventArgs e)
      {
        this.nullable_0 = new WW.Math.Point3D?();
        this.nullable_1 = new WW.Math.Point3D?();
        this.nullable_2 = new WW.Math.Point3D?();
        this.nullable_3 = new double?();
        base.OnDeactivated(e);
      }

      protected virtual void OnChanged(EventArgs e)
      {
        if (this.eventHandler_0 == null)
          return;
        this.eventHandler_0((object) this, e);
      }

      protected virtual void OnMouseMoveProcessed(InteractorMouseEventArgs e)
      {
        if (this.eventHandler_1 == null)
          return;
        this.eventHandler_1((object) this, e);
      }

      public override string UserHint
      {
        get
        {
          if (this.nullable_1.HasValue)
            return Class1040.SelectInteractor_ScaleFromBasePointInteractor_PickTargetPoint;
          if (this.nullable_0.HasValue)
            return Class1040.SelectInteractor_ScaleFromBasePointInteractor_PickRefeferencePoint;
          return Class1040.SelectInteractor_ScaleFromBasePointInteractor_PickBasePoint;
        }
      }

      private void method_0(
        InteractionContext context,
        CanonicalMouseEventArgs e,
        bool isIntermediateTransform)
      {
        if (this.SelectInteractor.SelectedEntities.Count <= 0 || !this.nullable_0.HasValue || (!this.nullable_1.HasValue || !this.nullable_2.HasValue) && (!this.nullable_3.HasValue || this.nullable_3.Value == 0.0))
          return;
        this.SelectInteractor.method_5();
        WW.Math.Point2D point = context.ProjectionTransform.TransformTo2D(this.nullable_0.Value);
        double num;
        if (this.nullable_3.HasValue && this.nullable_3.Value != 0.0)
        {
          num = this.nullable_3.Value;
        }
        else
        {
          WW.Math.Point2D point2D = context.ProjectionTransform.TransformTo2D(this.nullable_2.Value);
          double length = (context.ProjectionTransform.TransformTo2D(this.nullable_1.Value) - point).GetLength();
          num = SelectInteractor.smethod_3((point2D - point).GetLength(), length);
        }
        double z = 1.0;
        WW.Math.Point2D point2D1 = context.InverseProjectionTransform.Transform(point);
        this.SelectInteractor.Transform(Transformation4D.Translation(point2D1.X, point2D1.Y, 0.0) * Transformation4D.Scaling(num, num, z) * Transformation4D.Translation(-point2D1.X, -point2D1.Y, 0.0), new WW.Math.Vector3D(num, num, z), WW.Math.Vector3D.Zero, isIntermediateTransform);
      }

      private void method_1(InteractionContext context, bool isIntermediateTransform)
      {
        if (this.SelectInteractor.SelectedEntities.Count <= 0 || !this.nullable_0.HasValue || (!this.nullable_3.HasValue || this.nullable_3.Value == 0.0))
          return;
        this.SelectInteractor.method_5();
        WW.Math.Point2D point = context.ProjectionTransform.TransformTo2D(this.nullable_0.Value);
        double num = this.nullable_3.Value;
        double z = 1.0;
        WW.Math.Point2D point2D = context.ProjectionTransform.GetInverse().Transform(point);
        this.SelectInteractor.Transform(Transformation4D.Translation(point2D.X, point2D.Y, 0.0) * Transformation4D.Scaling(num, num, z) * Transformation4D.Translation(-point2D.X, -point2D.Y, 0.0), new WW.Math.Vector3D(this.nullable_3.Value, this.nullable_3.Value, z), WW.Math.Vector3D.Zero, isIntermediateTransform);
      }

      private void method_2(object sender, EventArgs e)
      {
        if (this.IsActive)
          this.Deactivate();
        this.itransaction_0.Completed -= new EventHandler(this.method_2);
        this.itransaction_0.RolledBack -= new EventHandler(this.method_3);
      }

      private void method_3(object sender, EventArgs e)
      {
        this.SelectInteractor.method_5();
      }

      public class WinFormsDrawable : WW.Actions.Interactor.WinFormsDrawable
      {
        private SelectInteractor.ScaleFromBasePointInteractor scaleFromBasePointInteractor_0;
        private FloatingForm floatingForm_0;
        private System.Windows.Forms.Label label_0;
        private TextBox textBox_0;
        private InteractionContext interactionContext_0;
        private Control control_0;
        private bool bool_0;

        public WinFormsDrawable(
          SelectInteractor.ScaleFromBasePointInteractor interactor,
          InteractionContext context,
          Control hostControl)
        {
          this.scaleFromBasePointInteractor_0 = interactor;
          this.interactionContext_0 = context;
          this.control_0 = hostControl;
          interactor.Activated += new EventHandler(this.method_1);
          interactor.Deactivated += new EventHandler(this.method_3);
          this.floatingForm_0 = new FloatingForm();
          this.label_0 = FormsUtil.CreateAutoSizeLabel();
          this.label_0.Text = Class675.ScaleFactor;
          this.label_0.Location = new System.Drawing.Point(3, 3);
          this.floatingForm_0.Controls.Add((Control) this.label_0);
          this.textBox_0 = FormsUtil.CreateTextBoxThatAcceptsTab();
          this.textBox_0.Location = new System.Drawing.Point(this.label_0.Right + 3, 3);
          this.floatingForm_0.Controls.Add((Control) this.textBox_0);
          this.floatingForm_0.Width = this.textBox_0.Right + 3;
          this.floatingForm_0.Height = this.textBox_0.Height + 6;
          this.textBox_0.KeyPress += new KeyPressEventHandler(this.textBox_0_KeyPress);
          if (!interactor.IsActive)
            return;
          this.method_2();
        }

        public override void Draw(
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context)
        {
          base.Draw(e, graphicsHelper, context);
          if (this.scaleFromBasePointInteractor_0.nullable_0.HasValue)
            graphicsHelper.DrawEditHandle(e.Graphics, graphicsHelper.HighlightPen, context.ProjectionTransform.TransformTo2D(this.scaleFromBasePointInteractor_0.nullable_0.Value));
          if (!this.scaleFromBasePointInteractor_0.nullable_1.HasValue)
            return;
          graphicsHelper.DrawEditHandle(e.Graphics, graphicsHelper.DefaultPen, context.ProjectionTransform.TransformTo2D(this.scaleFromBasePointInteractor_0.nullable_1.Value));
        }

        private void textBox_0_KeyPress(object sender, KeyPressEventArgs e)
        {
          if (this.scaleFromBasePointInteractor_0.nullable_3.HasValue && (e.KeyChar == '\r' || e.KeyChar == '\t'))
          {
            this.scaleFromBasePointInteractor_0.method_1(this.interactionContext_0, false);
            this.scaleFromBasePointInteractor_0.itransaction_0.Commit();
          }
          else
          {
            if (e.KeyChar != '\x001B')
              return;
            this.scaleFromBasePointInteractor_0.itransaction_0.Rollback();
          }
        }

        private void method_0(object sender, InteractorMouseEventArgs e)
        {
          this.floatingForm_0.Location = this.control_0.PointToScreen(new System.Drawing.Point((int) e.MouseEventArgs.Position.X + 5, (int) e.MouseEventArgs.Position.Y - 5 - this.floatingForm_0.Height));
          if (!this.scaleFromBasePointInteractor_0.nullable_2.HasValue)
            return;
          double length1 = (this.scaleFromBasePointInteractor_0.nullable_2.Value - this.scaleFromBasePointInteractor_0.nullable_0.Value).GetLength();
          double length2 = (this.scaleFromBasePointInteractor_0.nullable_1.Value - this.scaleFromBasePointInteractor_0.nullable_0.Value).GetLength();
          if (length2 == 0.0)
            return;
          this.bool_0 = true;
          try
          {
            this.textBox_0.Text = SelectInteractor.smethod_3(length1, length2).ToString();
            this.textBox_0.SelectAll();
            this.textBox_0.Focus();
          }
          finally
          {
            this.bool_0 = false;
          }
        }

        private void scaleFromBasePointInteractor_0_Changed(object sender, EventArgs e)
        {
          if (this.scaleFromBasePointInteractor_0.nullable_3.HasValue)
          {
            this.bool_0 = true;
            try
            {
              this.textBox_0.Text = this.scaleFromBasePointInteractor_0.nullable_3.ToString();
              this.textBox_0.SelectAll();
            }
            finally
            {
              this.bool_0 = false;
            }
          }
          bool visible = this.floatingForm_0.Visible;
          if (this.scaleFromBasePointInteractor_0.nullable_0.HasValue)
          {
            if (!this.floatingForm_0.Visible)
              this.floatingForm_0.Show();
          }
          else if (this.floatingForm_0.Visible)
            this.floatingForm_0.Hide();
          if (visible || !this.floatingForm_0.Visible)
            return;
          this.textBox_0.Focus();
        }

        private void method_1(object sender, EventArgs e)
        {
          this.method_2();
        }

        private void method_2()
        {
          this.scaleFromBasePointInteractor_0.Changed += new EventHandler(this.scaleFromBasePointInteractor_0_Changed);
          this.scaleFromBasePointInteractor_0.MouseMoveProcessed += new EventHandler<InteractorMouseEventArgs>(this.method_0);
          this.textBox_0.Text = "1";
          this.textBox_0.SelectAll();
          this.textBox_0.TextChanged += new EventHandler(this.textBox_0_TextChanged);
        }

        private void method_3(object sender, EventArgs e)
        {
          this.textBox_0.TextChanged -= new EventHandler(this.textBox_0_TextChanged);
          this.scaleFromBasePointInteractor_0.Changed -= new EventHandler(this.scaleFromBasePointInteractor_0_Changed);
          this.scaleFromBasePointInteractor_0.MouseMoveProcessed -= new EventHandler<InteractorMouseEventArgs>(this.method_0);
          this.floatingForm_0.Hide();
        }

        private void textBox_0_TextChanged(object sender, EventArgs e)
        {
          double result;
          if (this.bool_0 || !double.TryParse(this.textBox_0.Text, out result))
            return;
          this.scaleFromBasePointInteractor_0.nullable_3 = new double?(result);
          this.scaleFromBasePointInteractor_0.method_1(this.interactionContext_0, true);
        }
      }
    }

    public class MirrorInteractor : SelectInteractor.TransformInteractor
    {
      private WW.Math.Point3D? nullable_0;
      private WW.Math.Point3D? nullable_1;
      private ITransaction itransaction_0;

      public event EventHandler Changed;

      public event EventHandler<InteractorMouseEventArgs> MouseMoveProcessed;

      public MirrorInteractor(SelectInteractor selectInteractor, ITransaction transaction)
        : base(selectInteractor)
      {
        this.itransaction_0 = transaction;
        transaction.Completed += new EventHandler(this.method_1);
        transaction.RolledBack += new EventHandler(this.method_2);
      }

      public override bool ProcessMouseButtonDown(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        return this.IsActive;
      }

      public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
      {
        if (this.IsActive && this.SelectInteractor.SelectedEntities.Count > 0 && this.nullable_0.HasValue)
        {
          this.nullable_1 = new WW.Math.Point3D?(e.GetWcsPosition(context));
          this.method_0(context, e, true);
          this.OnChanged(EventArgs.Empty);
        }
        this.OnMouseMoveProcessed(new InteractorMouseEventArgs(e, context));
        return this.IsActive;
      }

      public override bool ProcessMouseButtonUp(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        SelectInteractor.MirrorInteractor.Class390 class390 = new SelectInteractor.MirrorInteractor.Class390();
        // ISSUE: reference to a compiler-generated field
        class390.canonicalMouseEventArgs_0 = e;
        // ISSUE: reference to a compiler-generated field
        class390.interactionContext_0 = context;
        // ISSUE: reference to a compiler-generated field
        class390.mirrorInteractor_0 = this;
        if (!this.IsActive || this.SelectInteractor.SelectedEntities.Count <= 0)
          return false;
        if (this.nullable_0.HasValue)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.nullable_1 = new WW.Math.Point3D?(class390.canonicalMouseEventArgs_0.GetWcsPosition(class390.interactionContext_0));
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.method_0(class390.interactionContext_0, class390.canonicalMouseEventArgs_0, false);
          this.itransaction_0.Commit();
        }
        else
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          SelectInteractor.MirrorInteractor.Class391 class391 = new SelectInteractor.MirrorInteractor.Class391();
          // ISSUE: reference to a compiler-generated field
          class391.class390_0 = class390;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          class390.canonicalMouseEventArgs_0.GetWcsPosition(class390.interactionContext_0);
          // ISSUE: reference to a compiler-generated field
          class391.nullable_0 = this.nullable_0;
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          this.itransaction_0.Add((WW.Actions.ICommand) new WW.Actions.Command(new System.Action(class390.method_0), new System.Action(class391.method_0)));
        }
        this.OnChanged(EventArgs.Empty);
        return true;
      }

      protected override void OnDeactivated(EventArgs e)
      {
        this.nullable_0 = new WW.Math.Point3D?();
        this.nullable_1 = new WW.Math.Point3D?();
        base.OnDeactivated(e);
      }

      protected virtual void OnChanged(EventArgs e)
      {
        if (this.eventHandler_0 == null)
          return;
        this.eventHandler_0((object) this, e);
      }

      protected virtual void OnMouseMoveProcessed(InteractorMouseEventArgs e)
      {
        if (this.eventHandler_1 == null)
          return;
        this.eventHandler_1((object) this, e);
      }

      public override string UserHint
      {
        get
        {
          if (this.nullable_0.HasValue)
            return Class1040.SelectInteractor_MirrorInteractor_PickPoint2;
          return Class1040.SelectInteractor_MirrorInteractor_PickPoint1;
        }
      }

      private void method_0(
        InteractionContext context,
        CanonicalMouseEventArgs e,
        bool isIntermediateTransform)
      {
        if (this.SelectInteractor.SelectedEntities.Count <= 0 || !this.nullable_0.HasValue || (!this.nullable_1.HasValue || WW.Math.Point3D.AreApproxEqual(this.nullable_0.Value, this.nullable_1.Value)))
          return;
        this.SelectInteractor.method_5();
        WW.Math.Point2D point = context.ProjectionTransform.TransformTo2D(this.nullable_0.Value);
        WW.Math.Point2D point2D = context.InverseProjectionTransform.Transform(point);
        double angle = Vector2D.GetAngle(Vector2D.XAxis, (Vector2D) (this.nullable_1.Value - this.nullable_0.Value));
        this.SelectInteractor.Transform(Transformation4D.Translation(point2D.X, point2D.Y, 0.0) * Transformation4D.RotateZ(angle) * Transformation4D.Scaling(1.0, -1.0, 1.0) * Transformation4D.RotateZ(-angle) * Transformation4D.Translation(-point2D.X, -point2D.Y, 0.0), new WW.Math.Vector3D(1.0, 1.0, 1.0), WW.Math.Vector3D.Zero, isIntermediateTransform);
      }

      private void method_1(object sender, EventArgs e)
      {
        if (this.IsActive)
          this.Deactivate();
        this.itransaction_0.Completed -= new EventHandler(this.method_1);
        this.itransaction_0.RolledBack -= new EventHandler(this.method_2);
      }

      private void method_2(object sender, EventArgs e)
      {
        this.SelectInteractor.method_5();
      }

      public class WinFormsDrawable : WW.Actions.Interactor.WinFormsDrawable
      {
        private SelectInteractor.MirrorInteractor mirrorInteractor_0;
        private InteractionContext interactionContext_0;
        private Control control_0;
        private bool bool_0;

        public WinFormsDrawable(
          SelectInteractor.MirrorInteractor interactor,
          InteractionContext context,
          Control hostControl)
        {
          this.mirrorInteractor_0 = interactor;
          this.interactionContext_0 = context;
          this.control_0 = hostControl;
          interactor.Activated += new EventHandler(this.method_0);
          interactor.Deactivated += new EventHandler(this.method_2);
          if (!interactor.IsActive)
            return;
          this.method_1();
        }

        public override void Draw(
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context)
        {
          base.Draw(e, graphicsHelper, context);
          if (this.mirrorInteractor_0.nullable_0.HasValue)
            graphicsHelper.DrawEditHandle(e.Graphics, graphicsHelper.HighlightPen, context.ProjectionTransform.TransformTo2D(this.mirrorInteractor_0.nullable_0.Value));
          if (!this.mirrorInteractor_0.nullable_1.HasValue)
            return;
          graphicsHelper.DrawEditHandle(e.Graphics, graphicsHelper.DefaultPen, context.ProjectionTransform.TransformTo2D(this.mirrorInteractor_0.nullable_1.Value));
        }

        private void method_0(object sender, EventArgs e)
        {
          this.method_1();
        }

        private void method_1()
        {
        }

        private void method_2(object sender, EventArgs e)
        {
        }
      }
    }

    public class RotateInteractor : SelectInteractor.TransformInteractor
    {
      private double double_0 = 5.0;
      private WW.Math.Point3D? nullable_0;
      private WW.Math.Point3D? nullable_1;
      private WW.Math.Point3D? nullable_2;
      private double? nullable_3;
      private ITransaction itransaction_0;

      public event EventHandler Changed;

      public event EventHandler<InteractorMouseEventArgs> MouseMoveProcessed;

      public RotateInteractor(SelectInteractor selectInteractor, ITransaction transaction)
        : base(selectInteractor)
      {
        this.itransaction_0 = transaction;
        transaction.Completed += new EventHandler(this.method_2);
        transaction.RolledBack += new EventHandler(this.method_3);
      }

      public double DegreeRounding
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

      public override bool ProcessMouseButtonDown(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        return this.IsActive;
      }

      public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
      {
        if (this.IsActive && this.SelectInteractor.SelectedEntities.Count > 0 && (this.nullable_0.HasValue && this.nullable_1.HasValue))
        {
          this.nullable_2 = new WW.Math.Point3D?(e.GetWcsPosition(context));
          this.nullable_3 = new double?();
          this.method_0(context, e, true);
          this.OnChanged(EventArgs.Empty);
        }
        this.OnMouseMoveProcessed(new InteractorMouseEventArgs(e, context));
        return this.IsActive;
      }

      public override bool ProcessMouseButtonUp(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        SelectInteractor.RotateInteractor.Class392 class392 = new SelectInteractor.RotateInteractor.Class392();
        // ISSUE: reference to a compiler-generated field
        class392.canonicalMouseEventArgs_0 = e;
        // ISSUE: reference to a compiler-generated field
        class392.interactionContext_0 = context;
        // ISSUE: reference to a compiler-generated field
        class392.rotateInteractor_0 = this;
        if (!this.IsActive || this.SelectInteractor.SelectedEntities.Count <= 0)
          return false;
        if (this.nullable_0.HasValue)
        {
          if (this.nullable_1.HasValue)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.nullable_2 = new WW.Math.Point3D?(class392.canonicalMouseEventArgs_0.GetWcsPosition(class392.interactionContext_0));
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.method_0(class392.interactionContext_0, class392.canonicalMouseEventArgs_0, false);
            this.itransaction_0.Commit();
          }
          else
          {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            SelectInteractor.RotateInteractor.Class393 class393 = new SelectInteractor.RotateInteractor.Class393();
            // ISSUE: reference to a compiler-generated field
            class393.class392_0 = class392;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            class392.canonicalMouseEventArgs_0.GetWcsPosition(class392.interactionContext_0);
            // ISSUE: reference to a compiler-generated field
            class393.nullable_0 = this.nullable_1;
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.itransaction_0.Add((WW.Actions.ICommand) new WW.Actions.Command(new System.Action(class392.method_0), new System.Action(class393.method_0)));
          }
        }
        else
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          SelectInteractor.RotateInteractor.Class394 class394 = new SelectInteractor.RotateInteractor.Class394();
          // ISSUE: reference to a compiler-generated field
          class394.class392_0 = class392;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          class392.canonicalMouseEventArgs_0.GetWcsPosition(class392.interactionContext_0);
          // ISSUE: reference to a compiler-generated field
          class394.nullable_0 = this.nullable_0;
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          this.itransaction_0.Add((WW.Actions.ICommand) new WW.Actions.Command(new System.Action(class392.method_1), new System.Action(class394.method_0)));
        }
        this.OnChanged(EventArgs.Empty);
        return true;
      }

      protected override void OnDeactivated(EventArgs e)
      {
        this.nullable_0 = new WW.Math.Point3D?();
        this.nullable_1 = new WW.Math.Point3D?();
        this.nullable_2 = new WW.Math.Point3D?();
        this.nullable_3 = new double?();
        base.OnDeactivated(e);
      }

      protected virtual void OnChanged(EventArgs e)
      {
        if (this.eventHandler_0 == null)
          return;
        this.eventHandler_0((object) this, e);
      }

      protected virtual void OnMouseMoveProcessed(InteractorMouseEventArgs e)
      {
        if (this.eventHandler_1 == null)
          return;
        this.eventHandler_1((object) this, e);
      }

      public override string UserHint
      {
        get
        {
          if (this.nullable_1.HasValue)
            return Class1040.SelectInteractor_RotateInteractor_PickTargetPoint;
          if (this.nullable_0.HasValue)
            return Class1040.SelectInteractor_RotateInteractor_PickRefeferencePoint;
          return Class1040.SelectInteractor_RotateInteractor_PickBasePoint;
        }
      }

      private void method_0(
        InteractionContext context,
        CanonicalMouseEventArgs e,
        bool isIntermediateTransform)
      {
        if (this.SelectInteractor.SelectedEntities.Count <= 0 || !this.nullable_0.HasValue || (!this.nullable_1.HasValue || !this.nullable_2.HasValue) && (!this.nullable_3.HasValue || this.nullable_3.Value == 0.0))
          return;
        this.SelectInteractor.method_5();
        WW.Math.Point2D point = context.ProjectionTransform.TransformTo2D(this.nullable_0.Value);
        double num;
        if (this.nullable_3.HasValue && this.nullable_3.Value != 0.0)
        {
          num = this.nullable_3.Value;
        }
        else
        {
          WW.Math.Point2D point2D1 = context.ProjectionTransform.TransformTo2D(this.nullable_0.Value);
          WW.Math.Point2D point2D2 = context.ProjectionTransform.TransformTo2D(this.nullable_2.Value);
          num = System.Math.Round(180.0 / System.Math.PI * Vector2D.GetAngle(context.ProjectionTransform.TransformTo2D(this.nullable_1.Value) - point2D1, point2D2 - point2D1) * (context.ProjectionFlipsOrientation ? -1.0 : 1.0) / this.double_0) * this.double_0;
        }
        WW.Math.Point2D point2D = context.InverseProjectionTransform.Transform(point);
        double angle = num * (System.Math.PI / 180.0);
        this.SelectInteractor.Transform(Transformation4D.Translation(point2D.X, point2D.Y, 0.0) * Transformation4D.RotateZ(angle) * Transformation4D.Translation(-point2D.X, -point2D.Y, 0.0), new WW.Math.Vector3D(1.0, 1.0, 1.0), WW.Math.Vector3D.Zero, isIntermediateTransform);
      }

      private void method_1(InteractionContext context, bool isIntermediateTransform)
      {
        if (this.SelectInteractor.SelectedEntities.Count <= 0 || !this.nullable_0.HasValue || (!this.nullable_3.HasValue || this.nullable_3.Value == 0.0))
          return;
        this.SelectInteractor.method_5();
        WW.Math.Point2D point = context.ProjectionTransform.TransformTo2D(this.nullable_0.Value);
        double angle = this.nullable_3.Value * (System.Math.PI / 180.0);
        WW.Math.Point2D point2D = context.ProjectionTransform.GetInverse().Transform(point);
        this.SelectInteractor.Transform(Transformation4D.Translation(point2D.X, point2D.Y, 0.0) * Transformation4D.RotateZ(angle) * Transformation4D.Translation(-point2D.X, -point2D.Y, 0.0), new WW.Math.Vector3D(1.0, 1.0, 1.0), WW.Math.Vector3D.Zero, isIntermediateTransform);
      }

      private void method_2(object sender, EventArgs e)
      {
        if (this.IsActive)
          this.Deactivate();
        this.itransaction_0.Completed -= new EventHandler(this.method_2);
        this.itransaction_0.RolledBack -= new EventHandler(this.method_3);
      }

      private void method_3(object sender, EventArgs e)
      {
        this.SelectInteractor.method_5();
      }

      public class WinFormsDrawable : WW.Actions.Interactor.WinFormsDrawable
      {
        private SelectInteractor.RotateInteractor rotateInteractor_0;
        private FloatingForm floatingForm_0;
        private System.Windows.Forms.Label label_0;
        private TextBox textBox_0;
        private InteractionContext interactionContext_0;
        private Control control_0;
        private bool bool_0;

        public WinFormsDrawable(
          SelectInteractor.RotateInteractor interactor,
          InteractionContext context,
          Control hostControl)
        {
          this.rotateInteractor_0 = interactor;
          this.interactionContext_0 = context;
          this.control_0 = hostControl;
          interactor.Activated += new EventHandler(this.method_1);
          interactor.Deactivated += new EventHandler(this.method_3);
          this.floatingForm_0 = new FloatingForm();
          this.label_0 = FormsUtil.CreateAutoSizeLabel();
          this.label_0.Text = Class675.Rotation + " (" + Class675.Degrees + ")";
          this.label_0.Location = new System.Drawing.Point(3, 3);
          this.floatingForm_0.Controls.Add((Control) this.label_0);
          this.textBox_0 = FormsUtil.CreateTextBoxThatAcceptsTab();
          this.textBox_0.Location = new System.Drawing.Point(this.label_0.Right + 3, 3);
          this.floatingForm_0.Controls.Add((Control) this.textBox_0);
          this.floatingForm_0.Width = this.textBox_0.Right + 3;
          this.floatingForm_0.Height = this.textBox_0.Height + 6;
          this.textBox_0.KeyPress += new KeyPressEventHandler(this.textBox_0_KeyPress);
          if (!interactor.IsActive)
            return;
          this.method_2();
        }

        public override void Draw(
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context)
        {
          base.Draw(e, graphicsHelper, context);
          if (this.rotateInteractor_0.nullable_0.HasValue)
            graphicsHelper.DrawEditHandle(e.Graphics, graphicsHelper.HighlightPen, context.ProjectionTransform.TransformTo2D(this.rotateInteractor_0.nullable_0.Value));
          if (!this.rotateInteractor_0.nullable_1.HasValue)
            return;
          graphicsHelper.DrawEditHandle(e.Graphics, graphicsHelper.DefaultPen, context.ProjectionTransform.TransformTo2D(this.rotateInteractor_0.nullable_1.Value));
        }

        private void textBox_0_KeyPress(object sender, KeyPressEventArgs e)
        {
          if (this.rotateInteractor_0.nullable_3.HasValue && (e.KeyChar == '\r' || e.KeyChar == '\t'))
          {
            this.rotateInteractor_0.method_1(this.interactionContext_0, false);
            this.rotateInteractor_0.itransaction_0.Commit();
          }
          else
          {
            if (e.KeyChar != '\x001B')
              return;
            this.rotateInteractor_0.itransaction_0.Rollback();
          }
        }

        private void method_0(object sender, InteractorMouseEventArgs e)
        {
          this.floatingForm_0.Location = this.control_0.PointToScreen(new System.Drawing.Point((int) e.MouseEventArgs.Position.X + 5, (int) e.MouseEventArgs.Position.Y - 5 - this.floatingForm_0.Height));
          if (!this.rotateInteractor_0.nullable_2.HasValue)
            return;
          WW.Math.Vector3D vector1 = this.rotateInteractor_0.nullable_1.Value - this.rotateInteractor_0.nullable_0.Value;
          WW.Math.Vector3D vector2 = this.rotateInteractor_0.nullable_2.Value - this.rotateInteractor_0.nullable_0.Value;
          double num = System.Math.Round(180.0 / System.Math.PI * (Vector2D.GetAngle(e.InteractionContext.ProjectionTransform.TransformTo2D(vector1), e.InteractionContext.ProjectionTransform.TransformTo2D(vector2)) * (e.InteractionContext.ProjectionFlipsOrientation ? -1.0 : 1.0)) / this.rotateInteractor_0.double_0) * this.rotateInteractor_0.double_0;
          this.bool_0 = true;
          try
          {
            this.textBox_0.Text = num.ToString(e.InteractionContext.AngleFormatString);
            this.textBox_0.SelectAll();
            this.textBox_0.Focus();
          }
          finally
          {
            this.bool_0 = false;
          }
        }

        private void rotateInteractor_0_Changed(object sender, EventArgs e)
        {
          if (this.rotateInteractor_0.nullable_3.HasValue)
          {
            this.bool_0 = true;
            try
            {
              this.textBox_0.Text = this.rotateInteractor_0.nullable_3.ToString();
              this.textBox_0.SelectAll();
            }
            finally
            {
              this.bool_0 = false;
            }
          }
          bool visible = this.floatingForm_0.Visible;
          if (this.rotateInteractor_0.nullable_0.HasValue)
          {
            if (!this.floatingForm_0.Visible)
              this.floatingForm_0.Show();
          }
          else if (this.floatingForm_0.Visible)
            this.floatingForm_0.Hide();
          if (visible || !this.floatingForm_0.Visible)
            return;
          this.textBox_0.Focus();
        }

        private void method_1(object sender, EventArgs e)
        {
          this.method_2();
        }

        private void method_2()
        {
          this.rotateInteractor_0.Changed += new EventHandler(this.rotateInteractor_0_Changed);
          this.rotateInteractor_0.MouseMoveProcessed += new EventHandler<InteractorMouseEventArgs>(this.method_0);
          this.textBox_0.Text = "0";
          this.textBox_0.SelectAll();
          this.textBox_0.TextChanged += new EventHandler(this.textBox_0_TextChanged);
        }

        private void method_3(object sender, EventArgs e)
        {
          this.textBox_0.TextChanged -= new EventHandler(this.textBox_0_TextChanged);
          this.rotateInteractor_0.Changed -= new EventHandler(this.rotateInteractor_0_Changed);
          this.rotateInteractor_0.MouseMoveProcessed -= new EventHandler<InteractorMouseEventArgs>(this.method_0);
          this.floatingForm_0.Hide();
        }

        private void textBox_0_TextChanged(object sender, EventArgs e)
        {
          double result;
          if (this.bool_0 || !double.TryParse(this.textBox_0.Text, out result))
            return;
          this.rotateInteractor_0.nullable_3 = new double?(result);
          this.rotateInteractor_0.method_1(this.interactionContext_0, true);
        }
      }
    }

    public class ScaleInteractor : SelectInteractor.TransformInteractor
    {
      private bool bool_0 = true;
      private int int_0;
      private int int_1;
      private bool bool_1;

      public ScaleInteractor(SelectInteractor selectInteractor)
        : base(selectInteractor)
      {
      }

      public bool KeepAspectRatioDiagonal
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

      public bool KeepAspectRatioNonDiagonal
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

      public override bool ProcessMouseButtonDown(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        base.ProcessMouseButtonDown(e, context);
        if (e.LeftButtonDown)
        {
          this.method_0(context, e, out this.int_0);
          if (this.int_0 >= 0)
            this.Activate();
        }
        return this.IsActive;
      }

      public override bool ProcessMouseMove(CanonicalMouseEventArgs e, InteractionContext context)
      {
        base.ProcessMouseMove(e, context);
        if (this.IsActive)
        {
          if (this.SelectInteractor.SelectedEntities.Count > 0)
            this.method_1(context, e, true);
        }
        else
          this.method_0(context, e, out this.int_1);
        return this.IsActive;
      }

      public override bool ProcessMouseButtonUp(
        CanonicalMouseEventArgs e,
        InteractionContext context)
      {
        base.ProcessMouseButtonUp(e, context);
        if (!this.IsActive || this.SelectInteractor.SelectedEntities.Count <= 0)
          return false;
        this.method_1(context, e, false);
        this.Deactivate();
        return true;
      }

      private void method_0(
        InteractionContext context,
        CanonicalMouseEventArgs e,
        out int editHandleIndex)
      {
        editHandleIndex = -1;
        if (this.SelectInteractor.SelectedEntities.Count <= 0)
          return;
        double margin = 0.5 * context.EditHandleSize;
        OrientedRectangle2D? nullable = SelectInteractor.smethod_4(this.SelectInteractor.SelectionBounds);
        if (!nullable.HasValue)
          return;
        WW.Math.Point2D[] editHandlePositions = this.SelectInteractor.method_6(nullable.Value);
        editHandleIndex = SelectInteractor.smethod_1(e.Position, editHandlePositions, margin);
      }

      private void method_1(
        InteractionContext context,
        CanonicalMouseEventArgs e,
        bool isIntermediateTransform)
      {
        if (this.SelectInteractor.SelectedEntities.Count <= 0)
          return;
        this.SelectInteractor.method_5();
        OrientedRectangle2D? nullable = SelectInteractor.smethod_4(this.SelectInteractor.SelectionBounds);
        if (!nullable.HasValue)
          return;
        WW.Math.Point2D[] point2DArray = this.SelectInteractor.method_6(nullable.Value);
        WW.Math.Point2D point2D1 = point2DArray[this.int_0];
        WW.Math.Point2D point = point2DArray[(this.int_0 + 4) % point2DArray.Length];
        WW.Math.Point2D point2D2 = context.ProjectionTransform.TransformTo2D(e.GetWcsPosition(context));
        double x = SelectInteractor.smethod_3(point2D2.X - point.X, point2D1.X - point.X);
        double y = SelectInteractor.smethod_3(point2D2.Y - point.Y, point2D1.Y - point.Y);
        double z = 1.0;
        if (this.bool_0 && this.int_0 % 2 == 0)
        {
          if (x == 0.0)
            x = y;
          else if (y == 0.0)
            y = x;
          else if (System.Math.Abs(x) < System.Math.Abs(y))
            y = (double) System.Math.Sign(y) * System.Math.Abs(x);
          else
            x = (double) System.Math.Sign(x) * System.Math.Abs(y);
          z = x;
        }
        if (this.bool_1 && this.int_0 % 2 == 1)
        {
          if (this.int_0 != 1 && this.int_0 != 5)
            y = x;
          else
            x = y;
          z = x;
        }
        WW.Math.Point2D point2D3 = context.InverseProjectionTransform.Transform(point);
        this.SelectInteractor.Transform(Transformation4D.Translation(point2D3.X, point2D3.Y, 0.0) * Transformation4D.Scaling(x, y, z) * Transformation4D.Translation(-point2D3.X, -point2D3.Y, 0.0), new WW.Math.Vector3D(x, y, z), WW.Math.Vector3D.Zero, isIntermediateTransform);
      }

      public class WinFormsDrawable : WW.Actions.Interactor.WinFormsDrawable
      {
        private readonly SelectInteractor.ScaleInteractor scaleInteractor_0;

        public WinFormsDrawable(SelectInteractor.ScaleInteractor interactor)
        {
          this.scaleInteractor_0 = interactor;
        }

        public override void Draw(
          PaintEventArgs e,
          GraphicsHelper graphicsHelper,
          InteractionContext context)
        {
          if (this.scaleInteractor_0.SelectInteractor.SelectedEntities.Count <= 0 || !this.scaleInteractor_0.IsEnabled || !this.scaleInteractor_0.SelectInteractor.SelectionBounds.Initialized)
            return;
          OrientedRectangle2D? nullable = SelectInteractor.smethod_4(this.scaleInteractor_0.SelectInteractor.SelectionBounds);
          if (!nullable.HasValue)
            return;
          WW.Math.Point2D[] point2DArray = this.scaleInteractor_0.SelectInteractor.method_6(nullable.Value);
          if (point2DArray == null || point2DArray.Length <= 0)
            return;
          foreach (WW.Math.Point2D position in point2DArray)
            graphicsHelper.DrawEditHandle(e.Graphics, graphicsHelper.DefaultPen, position);
        }

        public override System.Windows.Forms.Cursor GetCursor()
        {
          if (!this.scaleInteractor_0.IsEnabled)
            return (System.Windows.Forms.Cursor) null;
          return !this.scaleInteractor_0.IsActive ? SelectInteractor.ScaleInteractor.WinFormsDrawable.GetCursor(this.scaleInteractor_0.int_1) : SelectInteractor.ScaleInteractor.WinFormsDrawable.GetCursor(this.scaleInteractor_0.int_0);
        }

        private static System.Windows.Forms.Cursor GetCursor(int editHandleIndex)
        {
          System.Windows.Forms.Cursor cursor = (System.Windows.Forms.Cursor) null;
          switch (editHandleIndex)
          {
            case 0:
              cursor = System.Windows.Forms.Cursors.SizeNESW;
              break;
            case 1:
              cursor = System.Windows.Forms.Cursors.SizeNS;
              break;
            case 2:
              cursor = System.Windows.Forms.Cursors.SizeNWSE;
              break;
            case 3:
              cursor = System.Windows.Forms.Cursors.SizeWE;
              break;
            case 4:
              cursor = System.Windows.Forms.Cursors.SizeNESW;
              break;
            case 5:
              cursor = System.Windows.Forms.Cursors.SizeNS;
              break;
            case 6:
              cursor = System.Windows.Forms.Cursors.SizeNWSE;
              break;
            case 7:
              cursor = System.Windows.Forms.Cursors.SizeWE;
              break;
          }
          return cursor;
        }
      }
    }
  }
}
