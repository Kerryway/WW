// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.GDI.GDIGraphics3D
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns30;
using ns33;
using ns38;
using ns4;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Collections.Generic;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing.GDI
{
  public class GDIGraphics3D
  {
    private double double_0 = 1.0;
    private float float_0 = 1f;
    private float float_1 = 1f;
    private DxfLayout dxfLayout_0;
    private GraphicsConfig graphicsConfig_0;
    private Matrix4D matrix4D_0;
    private LinkedList<Interface12> linkedList_0;
    private LinkedList<Interface12> linkedList_1;
    private SmoothingMode? nullable_0;
    private bool bool_0;
    private NodeCollection nodeCollection_0;
    private bool bool_1;
    private Dictionary<DxfEntity, List<GDIGraphics3D.Class941>> dictionary_0;

    public GDIGraphics3D()
      : this(GraphicsConfig.BlackBackgroundCorrectForBackColor)
    {
    }

    public GDIGraphics3D(GraphicsConfig config)
      : this(config, Matrix4D.Identity)
    {
    }

    public GDIGraphics3D(GraphicsConfig config, Matrix4D to2DTransform)
    {
      this.method_1(config, to2DTransform);
    }

    public DxfLayout Layout
    {
      get
      {
        return this.dxfLayout_0;
      }
      set
      {
        this.dxfLayout_0 = value;
        this.method_4();
      }
    }

    public Matrix4D To2DTransform
    {
      get
      {
        return this.matrix4D_0;
      }
      set
      {
        this.matrix4D_0 = value;
        this.method_4();
        this.OnTransformChanged();
      }
    }

    public GraphicsConfig Config
    {
      get
      {
        return this.graphicsConfig_0;
      }
      set
      {
        this.graphicsConfig_0 = value;
      }
    }

    public float NonTextPenWidth
    {
      get
      {
        return this.float_1;
      }
      set
      {
        this.float_1 = value;
      }
    }

    public SmoothingMode? TextSmoothingMode
    {
      get
      {
        return this.nullable_0;
      }
      set
      {
        this.nullable_0 = value;
      }
    }

    public bool DrawTextOnTop
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

    public float TextPenWidth
    {
      get
      {
        return this.float_0;
      }
      set
      {
        this.float_0 = value;
      }
    }

    public bool AreDrawablesUpdateable
    {
      get
      {
        return this.bool_1;
      }
    }

    public void Clear()
    {
      this.linkedList_0.Clear();
      this.linkedList_1.Clear();
      if (this.nodeCollection_0 != null)
        this.nodeCollection_0.Clear();
      if (!this.bool_1)
        return;
      this.dictionary_0.Clear();
    }

    public void EnableDrawablesUpdate()
    {
      if (this.bool_1)
        return;
      this.bool_1 = true;
      this.dictionary_0 = new Dictionary<DxfEntity, List<GDIGraphics3D.Class941>>();
    }

    public void UpdateDrawables(DxfEntity entity)
    {
      this.UpdateDrawables(entity, new System.Action<DrawContext.Wireframe, IWireframeGraphicsFactory>(entity.Draw), (Func<IWireframeGraphicsFactory, IWireframeGraphicsFactory>) null);
    }

    public void UpdateDrawables(
      RenderedEntityInfo renderedEntityInfo,
      System.Action updateDrawables,
      System.Action<IWireframeGraphicsFactory> graphicsFactoryWrapper)
    {
      if (!this.bool_1)
        throw new Exception("Property AreDrawablesUpdateable is false.");
      List<GDIGraphics3D.Class941> class941List;
      if (!this.dictionary_0.TryGetValue(renderedEntityInfo.Entity, out class941List))
        return;
      GDIGraphics3D.Class941[] array = class941List.ToArray();
      GDIGraphics3D.Class942 graphicsFactory = (GDIGraphics3D.Class942) this.CreateGraphicsFactory();
      if (graphicsFactoryWrapper != null)
        graphicsFactoryWrapper((IWireframeGraphicsFactory) graphicsFactory);
      foreach (GDIGraphics3D.Class941 entityDrawablesInfo in array)
      {
        if (entityDrawablesInfo.Matches(renderedEntityInfo))
        {
          graphicsFactory.CurrentlyInTextMode = new bool?();
          this.RemoveDrawables(entityDrawablesInfo, true);
          graphicsFactory.CurrentColoredDrawableNode = new LinkedListNodeRef<Interface12>(entityDrawablesInfo.EntityDrawableNode.List, entityDrawablesInfo.EntityDrawableNode);
          graphicsFactory.CurrentTextColoredDrawableNode = new LinkedListNodeRef<Interface12>(entityDrawablesInfo.TextEntityDrawableNode.List, entityDrawablesInfo.TextEntityDrawableNode);
          graphicsFactory.CurrentEntityDrawablesInfo = entityDrawablesInfo.Parent;
          graphicsFactory.ExistingEntityDrawablesInfo = entityDrawablesInfo;
          updateDrawables();
        }
      }
    }

    public void UpdateDrawables(
      DxfEntity entity,
      System.Action<DrawContext.Wireframe, IWireframeGraphicsFactory> updateDrawables,
      Func<IWireframeGraphicsFactory, IWireframeGraphicsFactory> graphicsFactoryWrapper)
    {
      if (!this.bool_1)
        throw new Exception("Property AreDrawablesUpdateable is false.");
      List<GDIGraphics3D.Class941> class941List;
      if (!this.dictionary_0.TryGetValue(entity, out class941List))
        return;
      GDIGraphics3D.Class941[] array = class941List.ToArray();
      GDIGraphics3D.Class942 graphicsFactory = (GDIGraphics3D.Class942) this.CreateGraphicsFactory();
      IWireframeGraphicsFactory wireframeGraphicsFactory = (IWireframeGraphicsFactory) graphicsFactory;
      if (graphicsFactoryWrapper != null)
        wireframeGraphicsFactory = graphicsFactoryWrapper((IWireframeGraphicsFactory) graphicsFactory);
      foreach (GDIGraphics3D.Class941 entityDrawablesInfo in array)
      {
        graphicsFactory.CurrentlyInTextMode = new bool?();
        this.RemoveDrawables(entityDrawablesInfo, true);
        graphicsFactory.CurrentColoredDrawableNode = new LinkedListNodeRef<Interface12>(entityDrawablesInfo.EntityDrawableNode.List, entityDrawablesInfo.EntityDrawableNode);
        graphicsFactory.CurrentTextColoredDrawableNode = new LinkedListNodeRef<Interface12>(entityDrawablesInfo.TextEntityDrawableNode.List, entityDrawablesInfo.TextEntityDrawableNode);
        graphicsFactory.CurrentEntityDrawablesInfo = entityDrawablesInfo.Parent;
        graphicsFactory.ExistingEntityDrawablesInfo = entityDrawablesInfo;
        updateDrawables(entityDrawablesInfo.DrawContext, wireframeGraphicsFactory);
      }
    }

    public void RemoveDrawables(DxfEntity entity)
    {
      if (!this.bool_1)
        throw new Exception("Property AreDrawablesUpdateable is false.");
      List<GDIGraphics3D.Class941> class941List;
      if (!this.dictionary_0.TryGetValue(entity, out class941List))
        return;
      foreach (GDIGraphics3D.Class941 entityDrawablesInfo in class941List.ToArray())
        this.RemoveDrawables(entityDrawablesInfo, false);
    }

    public void CreateDrawables(DxfModel model)
    {
      this.CreateDrawables(model, Matrix4D.Identity);
    }

    public void AddDrawables(DxfModel model)
    {
      this.AddDrawables(model, Matrix4D.Identity);
    }

    public void CreateDrawables(DxfModel model, Matrix4D modelTransform)
    {
      GDIGraphics3D.smethod_0();
      this.Clear();
      WireframeGraphicsFactoryUtil.CreateDrawables((IWireframeGraphicsFactory) new GDIGraphics3D.Class942(this), this.graphicsConfig_0, model, modelTransform);
    }

    public void AddDrawables(DxfModel model, Matrix4D modelTransform)
    {
      GDIGraphics3D.smethod_0();
      WireframeGraphicsFactoryUtil.CreateDrawables((IWireframeGraphicsFactory) new GDIGraphics3D.Class942(this), this.graphicsConfig_0, model, modelTransform);
    }

    public void CreateDrawables(
      DxfModel model,
      IList<DxfEntity> modelSpaceEntities,
      Matrix4D modelTransform)
    {
      GDIGraphics3D.smethod_0();
      this.Clear();
      WireframeGraphicsFactoryUtil.CreateDrawables((IWireframeGraphicsFactory) new GDIGraphics3D.Class942(this), this.graphicsConfig_0, model, modelSpaceEntities, modelTransform);
    }

    public void CreateDrawables(
      DxfModel model,
      DxfLayout layout,
      IList<DxfEntity> entities,
      Matrix4D modelTransform)
    {
      GDIGraphics3D.smethod_0();
      this.Clear();
      WireframeGraphicsFactoryUtil.CreateDrawables((IWireframeGraphicsFactory) new GDIGraphics3D.Class942(this), this.graphicsConfig_0, model, layout, entities, modelTransform);
      if (this.dxfLayout_0 != null)
        return;
      this.dxfLayout_0 = this.Layout;
    }

    public void AddDrawables(
      DxfModel model,
      IList<DxfEntity> modelSpaceEntities,
      Matrix4D modelTransform)
    {
      GDIGraphics3D.smethod_0();
      WireframeGraphicsFactoryUtil.CreateDrawables((IWireframeGraphicsFactory) new GDIGraphics3D.Class942(this), this.graphicsConfig_0, model, modelSpaceEntities, modelTransform);
    }

    public void CreateDrawables(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports)
    {
      GDIGraphics3D.smethod_0();
      this.Clear();
      WireframeGraphicsFactoryUtil.CreateDrawables((IWireframeGraphicsFactory) new GDIGraphics3D.Class942(this), this.graphicsConfig_0, model, layout, viewports);
      if (this.dxfLayout_0 != null)
        return;
      this.dxfLayout_0 = this.Layout;
    }

    public void AddDrawables(DxfModel model, DxfLayout layout, ICollection<DxfViewport> viewports)
    {
      GDIGraphics3D.smethod_0();
      WireframeGraphicsFactoryUtil.CreateDrawables((IWireframeGraphicsFactory) new GDIGraphics3D.Class942(this), this.graphicsConfig_0, model, layout, viewports);
      if (this.dxfLayout_0 != null)
        return;
      this.dxfLayout_0 = this.Layout;
    }

    public void Draw(Graphics graphics, Rectangle drawingBounds)
    {
      this.Draw(graphics, drawingBounds, this.matrix4D_0);
    }

    public void Draw(Graphics graphics, Rectangle drawingBounds, Matrix4D transform)
    {
      this.Draw(graphics, drawingBounds, transform, (System.Drawing.Color) this.graphicsConfig_0.BackColor);
    }

    public void Draw(
      Graphics graphics,
      Rectangle drawingBounds,
      Matrix4D transform,
      System.Drawing.Color backColor)
    {
      GDIGraphics3D.smethod_0();
      GraphicsConfig config = (GraphicsConfig) this.graphicsConfig_0.Clone();
      config.BackColor = (ArgbColor) backColor;
      BlinnClipper4D drawingBoundsClipper = new BlinnClipper4D((double) drawingBounds.Left, (double) drawingBounds.Right, (double) drawingBounds.Top, (double) drawingBounds.Bottom, 0.0, 0.0, false, true);
      using (Class385 context = new Class385(this.graphicsConfig_0, graphics, this.nullable_0, drawingBoundsClipper, transform, this.method_5(), this.method_6(), this.float_0, this.float_1, Class1002.Create(config, this.float_1), Class1002.Create(config, this.float_0)))
      {
        foreach (Interface12 nterface12 in this.linkedList_0)
          nterface12.Draw(context);
        foreach (Interface12 nterface12 in this.linkedList_1)
          nterface12.Draw(context);
      }
      if (this.nodeCollection_0 == null || this.nodeCollection_0.Count <= 0)
        return;
      foreach (WW.Cad.Drawing.Node node in (List<WW.Cad.Drawing.Node>) this.nodeCollection_0)
      {
        using (Pen pen = new Pen((System.Drawing.Color) this.graphicsConfig_0.NodeColor, node.HighLighted ? 2f : 1f))
        {
          WW.Math.Point2D position = this.matrix4D_0.TransformTo2D(node.Position);
          GdiDrawUtil.DrawEditHandle(graphics, pen, position, this.graphicsConfig_0.NodeSize);
        }
      }
    }

    internal void Draw(
      Graphics graphics,
      Rasterizer2D fastRasterizer,
      Rectangle drawingBounds,
      System.Drawing.Color backColor)
    {
      GDIGraphics3D.smethod_0();
      GraphicsConfig config = (GraphicsConfig) this.graphicsConfig_0.Clone();
      config.BackColor = (ArgbColor) backColor;
      BlinnClipper4D drawingBoundsClipper = new BlinnClipper4D((double) drawingBounds.Left, (double) drawingBounds.Right, (double) drawingBounds.Top, (double) drawingBounds.Bottom, 0.0, 0.0, false, true);
      using (Class386 context = new Class386(this.graphicsConfig_0, graphics, fastRasterizer, this.nullable_0, drawingBoundsClipper, this.matrix4D_0, this.method_5(), this.method_6(), this.float_0, this.float_1, Class1002.Create(config, this.float_1), Class1002.Create(config, this.float_0)))
      {
        foreach (Interface12 nterface12 in this.linkedList_0)
          nterface12.Draw(context);
        foreach (Interface12 nterface12 in this.linkedList_1)
          nterface12.Draw(context);
      }
      if (this.nodeCollection_0 == null || this.nodeCollection_0.Count <= 0)
        return;
      foreach (WW.Cad.Drawing.Node node in (List<WW.Cad.Drawing.Node>) this.nodeCollection_0)
      {
        using (Pen pen = new Pen((System.Drawing.Color) this.graphicsConfig_0.NodeColor, node.HighLighted ? 2f : 1f))
        {
          WW.Math.Point2D position = this.matrix4D_0.TransformTo2D(node.Position);
          GdiDrawUtil.DrawEditHandle(graphics, pen, position, this.graphicsConfig_0.NodeSize);
        }
      }
    }

    public IWireframeGraphicsFactory CreateGraphicsFactory()
    {
      GDIGraphics3D.smethod_0();
      return (IWireframeGraphicsFactory) new GDIGraphics3D.Class942(this);
    }

    private static void smethod_0()
    {
      Class735.smethod_0();
    }

    public void BoundingBox(Bounds3D bounds, Matrix4D transform)
    {
      foreach (Interface12 nterface12 in this.linkedList_0)
        nterface12.BoundingBox(bounds, transform);
      foreach (Interface12 nterface12 in this.linkedList_1)
        nterface12.BoundingBox(bounds, transform);
    }

    public void BoundingBox(Bounds3D bounds)
    {
      this.BoundingBox(bounds, Matrix4D.Identity);
    }

    public void TransformDrawables(ITransformer4D transformer)
    {
      if (this.linkedList_0 != null)
      {
        foreach (Interface12 nterface12 in this.linkedList_0)
          nterface12.Transform(transformer, this.graphicsConfig_0);
      }
      if (this.linkedList_1 == null)
        return;
      foreach (Interface12 nterface12 in this.linkedList_1)
        nterface12.Transform(transformer, this.graphicsConfig_0);
    }

    public object Clone()
    {
      GDIGraphics3D gdiGraphics3D = new GDIGraphics3D(this.graphicsConfig_0, this.matrix4D_0);
      gdiGraphics3D.method_0(this);
      return (object) gdiGraphics3D;
    }

    private void method_0(GDIGraphics3D from)
    {
      this.dxfLayout_0 = from.dxfLayout_0;
    }

    private void method_1(GraphicsConfig config, Matrix4D to2DTransform)
    {
      Class809.smethod_0(Enum15.const_2);
      this.graphicsConfig_0 = config;
      this.To2DTransform = to2DTransform;
      this.linkedList_0 = new LinkedList<Interface12>();
      this.linkedList_1 = new LinkedList<Interface12>();
    }

    private void RemoveDrawables(GDIGraphics3D.Class941 entityDrawablesInfo, bool eraseOnly)
    {
      if (entityDrawablesInfo.Children != null)
      {
        foreach (GDIGraphics3D.Class941 child in entityDrawablesInfo.Children)
          this.method_2(child);
      }
      entityDrawablesInfo.EraseDrawables();
      if (eraseOnly)
        return;
      this.method_3(entityDrawablesInfo);
    }

    private void method_2(GDIGraphics3D.Class941 entityDrawablesInfo)
    {
      if (entityDrawablesInfo == null)
        return;
      this.method_3(entityDrawablesInfo);
      if (entityDrawablesInfo.Children == null)
        return;
      foreach (GDIGraphics3D.Class941 child in entityDrawablesInfo.Children)
        this.method_2(child);
    }

    private void method_3(GDIGraphics3D.Class941 entityDrawablesInfo)
    {
      List<GDIGraphics3D.Class941> class941List;
      if (!this.dictionary_0.TryGetValue(entityDrawablesInfo.Entity, out class941List))
        return;
      class941List.Remove(entityDrawablesInfo);
      if (class941List.Count != 0)
        return;
      this.dictionary_0.Remove(entityDrawablesInfo.Entity);
    }

    private void method_4()
    {
      if (this.dxfLayout_0 != null && this.dxfLayout_0.PaperSpace)
        this.double_0 = this.matrix4D_0.Transform(WW.Math.Vector3D.XAxis).GetLength() * this.dxfLayout_0.GetLineWeightUnitsToPaperUnits();
      else
        this.double_0 = this.graphicsConfig_0.DotsPerHundredthMm;
    }

    private Interface38 method_5()
    {
      if (!this.graphicsConfig_0.DisplayLineWeight)
        return (Interface38) new Class661.Class663((double) this.float_0);
      return (Interface38) new Class661.Class662(this.double_0);
    }

    private Interface38 method_6()
    {
      if (!this.graphicsConfig_0.DisplayLineWeight)
        return (Interface38) new Class661.Class663((double) this.float_1);
      return (Interface38) new Class661.Class662(this.double_0);
    }

    public Matrix4D Transform
    {
      get
      {
        return this.matrix4D_0;
      }
      set
      {
        this.To2DTransform = value;
      }
    }

    public event EventHandler TransformChanged;

    protected virtual void OnTransformChanged()
    {
      if (this.eventHandler_0 == null)
        return;
      this.eventHandler_0((object) this, (EventArgs) null);
    }

    public GraphicsConfig GraphicsConfig
    {
      get
      {
        return this.graphicsConfig_0;
      }
      set
      {
        this.graphicsConfig_0 = value;
      }
    }

    public NodeCollection Nodes
    {
      get
      {
        if (this.nodeCollection_0 == null)
          this.nodeCollection_0 = new NodeCollection();
        return this.nodeCollection_0;
      }
    }

    private class Class941
    {
      private readonly DxfEntity dxfEntity_0;
      private DrawContext.Wireframe wireframe_0;
      private LinkedListNode<Interface12> linkedListNode_0;
      private Class664 class664_0;
      private LinkedListNode<Interface12> linkedListNode_1;
      private Class664 class664_1;
      private GDIGraphics3D.Class941 class941_0;
      private List<GDIGraphics3D.Class941> list_0;

      public Class941(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
        this.dxfEntity_0 = entity;
        this.wireframe_0 = drawContext;
      }

      public DxfEntity Entity
      {
        get
        {
          return this.dxfEntity_0;
        }
      }

      public DrawContext.Wireframe DrawContext
      {
        get
        {
          return this.wireframe_0;
        }
        set
        {
          this.wireframe_0 = value;
        }
      }

      public LinkedListNode<Interface12> EntityDrawableNode
      {
        get
        {
          return this.linkedListNode_0;
        }
        set
        {
          this.linkedListNode_0 = value;
        }
      }

      public Class664 EntityDrawable
      {
        get
        {
          return this.class664_0;
        }
        set
        {
          this.class664_0 = value;
        }
      }

      public LinkedListNode<Interface12> TextEntityDrawableNode
      {
        get
        {
          return this.linkedListNode_1;
        }
        set
        {
          this.linkedListNode_1 = value;
        }
      }

      public Class664 TextEntityDrawable
      {
        get
        {
          return this.class664_1;
        }
        set
        {
          this.class664_1 = value;
        }
      }

      public GDIGraphics3D.Class941 Parent
      {
        get
        {
          return this.class941_0;
        }
        set
        {
          this.class941_0 = value;
        }
      }

      public List<GDIGraphics3D.Class941> Children
      {
        get
        {
          return this.list_0;
        }
      }

      public void method_0(GDIGraphics3D.Class941 child)
      {
        if (this.list_0 == null)
          this.list_0 = new List<GDIGraphics3D.Class941>();
        this.list_0.Add(child);
        child.class941_0 = this;
      }

      public void EraseDrawables()
      {
        if (this.class664_0 != null)
          this.class664_0.method_0();
        if (this.list_0 != null)
          this.list_0.Clear();
        if (this.class664_1 == null)
          return;
        this.class664_1.method_0();
      }

      public bool Matches(RenderedEntityInfo renderedEntityInfo)
      {
        if (renderedEntityInfo.Entity != this.dxfEntity_0)
          return false;
        if (this.class941_0 == null && renderedEntityInfo.Parent == null)
          return true;
        if (this.class941_0 != null && renderedEntityInfo.Parent != null)
          return this.class941_0.Matches(renderedEntityInfo.Parent);
        return false;
      }
    }

    private class Class942 : IWireframeGraphicsFactory
    {
      private float float_0 = 1f;
      private float float_1 = 1f;
      private const short short_0 = 0;
      private GraphicsConfig graphicsConfig_0;
      private LinkedListNodeRef<Interface12> linkedListNodeRef_0;
      private LinkedListNodeRef<Interface12> linkedListNodeRef_1;
      private bool bool_0;
      private bool? nullable_0;
      private bool bool_1;
      private Dictionary<DxfEntity, List<GDIGraphics3D.Class941>> dictionary_0;
      private GDIGraphics3D.Class941 class941_0;
      private GDIGraphics3D.Class941 class941_1;
      private Stack<GDIGraphics3D.Class941> stack_0;

      public Class942(GDIGraphics3D graphics)
      {
        this.graphicsConfig_0 = graphics.graphicsConfig_0;
        this.linkedListNodeRef_0 = new LinkedListNodeRef<Interface12>(graphics.linkedList_0, graphics.linkedList_0.Last);
        this.linkedListNodeRef_1 = new LinkedListNodeRef<Interface12>(graphics.linkedList_1, graphics.linkedList_1.Last);
        this.float_0 = graphics.float_0;
        this.float_1 = graphics.float_1;
        this.bool_0 = graphics.bool_0;
        this.bool_1 = graphics.bool_1;
        this.dictionary_0 = graphics.dictionary_0;
        if (!graphics.bool_1)
          return;
        this.stack_0 = new Stack<GDIGraphics3D.Class941>();
      }

      public bool? CurrentlyInTextMode
      {
        get
        {
          return this.nullable_0;
        }
        set
        {
          this.nullable_0 = value;
        }
      }

      public LinkedListNodeRef<Interface12> CurrentColoredDrawableNode
      {
        get
        {
          return this.linkedListNodeRef_0;
        }
        set
        {
          this.linkedListNodeRef_0 = value;
        }
      }

      public LinkedListNodeRef<Interface12> CurrentTextColoredDrawableNode
      {
        get
        {
          return this.linkedListNodeRef_1;
        }
        set
        {
          this.linkedListNodeRef_1 = value;
        }
      }

      public GDIGraphics3D.Class941 CurrentEntityDrawablesInfo
      {
        get
        {
          return this.class941_0;
        }
        set
        {
          this.class941_0 = value;
        }
      }

      public GDIGraphics3D.Class941 ExistingEntityDrawablesInfo
      {
        get
        {
          return this.class941_1;
        }
        set
        {
          this.class941_1 = value;
        }
      }

      public void BeginEntity(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
        if (!this.bool_1)
          return;
        GDIGraphics3D.Class941 class9410 = this.class941_0;
        if (this.class941_1 != null && this.class941_1.Entity == entity)
        {
          this.class941_0 = this.class941_1;
        }
        else
        {
          this.class941_0 = new GDIGraphics3D.Class941(entity, drawContext);
          this.class941_0.EntityDrawable = new Class664();
          this.class941_0.TextEntityDrawable = new Class664();
          class9410?.method_0(this.class941_0);
          this.class941_0.EntityDrawableNode = this.linkedListNodeRef_0.Insert((Interface12) this.class941_0.EntityDrawable);
          this.class941_0.TextEntityDrawableNode = this.linkedListNodeRef_1.Insert((Interface12) this.class941_0.TextEntityDrawable);
        }
        this.linkedListNodeRef_0.Initialize(this.class941_0.EntityDrawable.Drawables);
        this.linkedListNodeRef_1.Initialize(this.class941_0.TextEntityDrawable.Drawables);
        this.stack_0.Push(this.class941_0);
      }

      public void EndEntity()
      {
        if (!this.bool_1)
          return;
        List<GDIGraphics3D.Class941> class941List;
        if (!this.dictionary_0.TryGetValue(this.class941_0.Entity, out class941List))
        {
          class941List = new List<GDIGraphics3D.Class941>();
          this.dictionary_0.Add(this.class941_0.Entity, class941List);
        }
        if (this.class941_0 != this.class941_1)
          class941List.Add(this.class941_0);
        this.class941_0.EntityDrawable.Drawables = this.linkedListNodeRef_0.LinkedList;
        this.class941_0.TextEntityDrawable.Drawables = this.linkedListNodeRef_1.LinkedList;
        this.linkedListNodeRef_0.Initialize(this.class941_0.EntityDrawableNode.List, this.class941_0.EntityDrawableNode);
        this.linkedListNodeRef_1.Initialize(this.class941_0.TextEntityDrawableNode.List, this.class941_0.TextEntityDrawableNode);
        this.stack_0.Pop();
        if (this.stack_0.Count > 0)
          this.class941_0 = this.stack_0.Peek();
        else
          this.class941_0 = (GDIGraphics3D.Class941) null;
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
        Interface12 drawable = (Interface12) new Class343(position, this.GetColor(color), drawContext.GetLineWeight(entity));
        this.method_4(forText, drawable);
      }

      private ArgbColor GetColor(ArgbColor color)
      {
        if (!this.graphicsConfig_0.FixedForegroundColor.HasValue)
          return color;
        return this.graphicsConfig_0.FixedForegroundColor.Value;
      }

      public void CreateLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D start,
        Vector4D end)
      {
        Interface12 drawable = (Interface12) new Class338(start, end, this.GetColor(color), drawContext.GetLineWeight(entity));
        this.method_4(forText, drawable);
      }

      public void CreateRay(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Segment4D segment)
      {
        this.method_4(false, (Interface12) new Class345(new Vector4D?(segment.Start), segment, this.GetColor(color), drawContext.GetLineWeight(entity)));
      }

      public void CreateXLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Vector4D? startPoint,
        Segment4D segment)
      {
        this.method_4(false, (Interface12) new Class345(startPoint, segment, this.GetColor(color), drawContext.GetLineWeight(entity)));
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
        if (polylines.Count <= 0)
          return;
        Interface23[] drawables = this.GetDrawables(polylines);
        Interface12 drawable = !correctForBackgroundColor ? (drawables.Length != 1 ? (Interface12) new Class346(this.GetColor(color), drawables, fill, drawContext.GetLineWeight(entity)) : (Interface12) new Class337(this.GetColor(color), drawables[0], fill, drawContext.GetLineWeight(entity))) : (drawables.Length != 1 ? (Interface12) new Class340(this.GetColor(color), drawables, fill, drawContext.GetLineWeight(entity)) : (Interface12) new Class341(this.GetColor(color), drawables[0], fill, drawContext.GetLineWeight(entity)));
        this.method_4(forText, drawable);
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
        if (polylines.Count <= 0)
          return;
        Interface23[] drawables = this.GetDrawables(polylines);
        Interface12 drawable = !correctForBackgroundColor ? (drawables.Length != 1 ? (Interface12) new Class339(this.GetColor(color), drawables, fill, fill ? (short) 0 : drawContext.GetLineWeight(entity)) : (Interface12) new Class337(this.GetColor(color), drawables[0], fill, fill ? (short) 0 : drawContext.GetLineWeight(entity))) : (drawables.Length != 1 ? (Interface12) new Class336(this.GetColor(color), drawables, fill, fill ? (short) 0 : drawContext.GetLineWeight(entity)) : (Interface12) new Class341(this.GetColor(color), drawables[0], fill, fill ? (short) 0 : drawContext.GetLineWeight(entity)));
        this.method_4(forText, drawable);
      }

      public void CreateShape(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IShape4D shape)
      {
        Interface12 drawable = (Interface12) new Class342(this.GetColor(color), shape, shape.IsFilled ? (short) 0 : drawContext.GetLineWeight(entity));
        this.method_4(forText, drawable);
      }

      public bool SupportsText
      {
        get
        {
          return true;
        }
      }

      public void CreateText(DxfText text, DrawContext.Wireframe drawContext, ArgbColor color)
      {
        if (text.Text == null || text.Text.Trim() == string.Empty)
          return;
        this.method_3(Class666.smethod_5(text, text.Color.ToColor(), drawContext.GetLineWeight((DxfEntity) text), drawContext.GetTransformer().Matrix * text.Transform, (Bounds2D) null), (DxfEntity) text, drawContext);
      }

      public void CreateMText(DxfMText text, DrawContext.Wireframe drawContext)
      {
        if (text.Text == null || text.Text.Trim() == string.Empty)
          return;
        Bounds2D collectBounds = new Bounds2D();
        IList<Class908> chunks = Class666.smethod_4(text, text.Color.ToColor(), drawContext.GetLineWeight((DxfEntity) text), drawContext.GetTransformer().Matrix, collectBounds);
        BackgroundFillFlags backgroundFillFlags = text.BackgroundFillFlags;
        BackgroundFillInfo backgroundFillInfo = text.BackgroundFillInfo;
        if (backgroundFillFlags == BackgroundFillFlags.UseBackgroundFillColor && backgroundFillInfo != null)
        {
          System.Drawing.Color color = (System.Drawing.Color) DxfEntity.GetColor(this.graphicsConfig_0.IndexedColors, backgroundFillInfo.Color, drawContext.ByBlockColor, drawContext.ByBlockDxfColor, text.GetLayer((DrawContext) drawContext));
          double num1 = text.Height * (backgroundFillInfo.BorderOffsetFactor - 1.0);
          double x1 = collectBounds.Center.X;
          double y1 = collectBounds.Center.Y;
          double width = text.Width;
          double y2 = collectBounds.Delta.Y;
          double num2;
          double num3;
          switch (text.AttachmentPoint)
          {
            case AttachmentPoint.TopLeft:
              num2 = collectBounds.Corner1.X + 0.5 * width;
              num3 = collectBounds.Corner2.Y - 0.5 * y2;
              break;
            case AttachmentPoint.TopCenter:
              num2 = collectBounds.Center.X;
              num3 = collectBounds.Corner2.Y - 0.5 * y2;
              break;
            case AttachmentPoint.TopRight:
              num2 = collectBounds.Corner2.X - 0.5 * width;
              num3 = collectBounds.Corner2.Y - 0.5 * y2;
              break;
            case AttachmentPoint.MiddleLeft:
              num2 = collectBounds.Corner1.X + 0.5 * width;
              num3 = collectBounds.Center.Y;
              break;
            case AttachmentPoint.MiddleCenter:
              num2 = collectBounds.Center.X;
              num3 = collectBounds.Center.Y;
              break;
            case AttachmentPoint.MiddleRight:
              num2 = collectBounds.Corner2.X - 0.5 * width;
              num3 = collectBounds.Center.Y;
              break;
            case AttachmentPoint.BottomLeft:
              num2 = collectBounds.Corner1.X + 0.5 * width;
              num3 = collectBounds.Corner1.Y + 0.5 * y2;
              break;
            case AttachmentPoint.BottomCenter:
              num2 = collectBounds.Center.X;
              num3 = collectBounds.Corner1.Y + 0.5 * y2;
              break;
            case AttachmentPoint.BottomRight:
              num2 = collectBounds.Corner2.X - 0.5 * width;
              num3 = collectBounds.Corner1.Y + 0.5 * y2;
              break;
            default:
              num2 = collectBounds.Center.X;
              num3 = collectBounds.Center.Y;
              break;
          }
          short lineWeight = drawContext.GetLineWeight((DxfEntity) text);
          Matrix4D matrix4D = drawContext.GetTransformer().Matrix * text.Transform;
          WW.Math.Point2D point = new WW.Math.Point2D(num2 - 0.5 * width - num1, num3 - 0.5 * y2 - num1);
          double x2 = width + 2.0 * num1;
          double y3 = y2 + 2.0 * num1;
          this.method_4(false, (Interface12) new Class341((ArgbColor) color, (Interface23) new Class535(true, new Vector4D[4]
          {
            matrix4D.TransformTo4D(point),
            matrix4D.TransformTo4D(point + new Vector2D(x2, 0.0)),
            matrix4D.TransformTo4D(point + new Vector2D(x2, y3)),
            matrix4D.TransformTo4D(point + new Vector2D(0.0, y3))
          }), true, lineWeight));
        }
        this.method_3(chunks, (DxfEntity) text, drawContext);
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
        if (!this.graphicsConfig_0.DrawImages || rasterImage.ImageDef == null || !rasterImage.ImageDef.Bitmap.IsValid)
          return;
        this.method_4(false, (Interface12) new Class344((Image) rasterImage.ImageDef.Bitmap.Image, clipPolygon, imageBoundary, transformedOrigin, transformedXAxis, transformedYAxis, (System.Drawing.Color) drawContext.GetPlotColor((DxfEntity) rasterImage), drawContext.GetLineWeight((DxfEntity) rasterImage)));
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
        if (!this.graphicsConfig_0.DrawImages || bitmapProvider == null)
          return;
        this.method_4(false, (Interface12) new Class463(bitmapProvider, clipPolygon, displaySize, transformedOrigin, transformedXAxis, transformedYAxis));
      }

      private Interface23[] GetDrawables(IList<Polyline4D> polylines)
      {
        List<Interface23> nterface23List = new List<Interface23>(polylines.Count);
        foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polylines)
        {
          if (polyline.Count != 0)
          {
            if (polyline.Count == 1)
              nterface23List.Add((Interface23) new Class1058(polyline[0]));
            else if (polyline.Count == 2)
              nterface23List.Add((Interface23) new Class418(polyline[0], polyline[1]));
            else
              nterface23List.Add((Interface23) new Class535(polyline));
          }
        }
        return nterface23List.ToArray();
      }

      private float method_0(DxfEntity entity, DrawContext drawContext, bool forText)
      {
        if (this.graphicsConfig_0.DisplayLineWeight)
          return (float) this.graphicsConfig_0.DotsPerHundredthMm * (float) drawContext.GetLineWeight(entity);
        if (forText)
          return this.float_0;
        return this.float_1;
      }

      private float method_1(DxfEntity entity, DrawContext drawContext, bool forText, bool fill)
      {
        if (!fill && this.graphicsConfig_0.DisplayLineWeight)
          return (float) this.graphicsConfig_0.DotsPerHundredthMm * (float) drawContext.GetLineWeight(entity);
        if (forText)
          return this.float_0;
        return this.float_1;
      }

      private bool method_2(Vector4D v)
      {
        if (System.Math.Abs(v.X) <= 10000000000.0 && System.Math.Abs(v.Y) <= 10000000000.0 && System.Math.Abs(v.Z) <= 10000000000.0)
          return System.Math.Abs(v.W) < 1E-10;
        return true;
      }

      private void method_3(
        IList<Class908> chunks,
        DxfEntity entity,
        DrawContext.Wireframe drawContext)
      {
        LinkedListNodeRef<Interface12> linkedListNodeRef = !this.bool_0 ? this.linkedListNodeRef_0 : this.linkedListNodeRef_1;
        bool? nullable0 = this.nullable_0;
        if ((!nullable0.GetValueOrDefault() ? 1 : (!nullable0.HasValue ? 1 : 0)) != 0)
        {
          linkedListNodeRef.Insert((Interface12) new Class807());
          this.nullable_0 = new bool?(true);
        }
        System.Drawing.Color color = (System.Drawing.Color) this.GetColor(drawContext.GetPlotColor(entity));
        short lineWeight = drawContext.GetLineWeight(entity);
        foreach (Class908 chunk in (IEnumerable<Class908>) chunks)
        {
          Class1036 class1036 = new Class1036(chunk, color, lineWeight);
          linkedListNodeRef.Insert((Interface12) class1036);
        }
      }

      private void method_4(bool forText, Interface12 drawable)
      {
        LinkedListNodeRef<Interface12> linkedListNodeRef = !forText || !this.bool_0 ? this.linkedListNodeRef_0 : this.linkedListNodeRef_1;
        if (forText)
        {
          bool? nullable0 = this.nullable_0;
          if ((!nullable0.GetValueOrDefault() ? 1 : (!nullable0.HasValue ? 1 : 0)) != 0)
          {
            linkedListNodeRef.Insert((Interface12) new Class807());
            this.nullable_0 = new bool?(true);
          }
        }
        else
        {
          bool? nullable0 = this.nullable_0;
          if ((nullable0.GetValueOrDefault() ? 1 : (!nullable0.HasValue ? 1 : 0)) != 0)
          {
            linkedListNodeRef.Insert((Interface12) new Class748());
            this.nullable_0 = new bool?(false);
          }
        }
        linkedListNodeRef.Insert(drawable);
      }
    }
  }
}
