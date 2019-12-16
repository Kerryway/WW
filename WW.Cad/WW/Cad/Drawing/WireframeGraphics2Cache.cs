// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.WireframeGraphics2Cache
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Collections.Generic;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public class WireframeGraphics2Cache : ICadDrawer
  {
    private GraphicsConfig graphicsConfig_0 = GraphicsConfig.WhiteBackgroundCorrectForBackColor;
    private LinkedList<IWireframeDrawable2> linkedList_0 = new LinkedList<IWireframeDrawable2>();
    private bool bool_2 = true;
    private bool bool_0;
    private bool bool_1;
    private Dictionary<DxfEntity, List<WireframeGraphics2Cache.Class923>> dictionary_0;
    private bool bool_3;

    public event EventHandler Changed;

    public WireframeGraphics2Cache(bool supportsText, bool areDrawablesUpdateable)
    {
      this.bool_0 = supportsText;
      this.bool_1 = areDrawablesUpdateable;
      if (!areDrawablesUpdateable)
        return;
      this.dictionary_0 = new Dictionary<DxfEntity, List<WireframeGraphics2Cache.Class923>>();
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

    public LinkedList<IWireframeDrawable2> Drawables
    {
      get
      {
        return this.linkedList_0;
      }
    }

    public bool AreDrawablesUpdateable
    {
      get
      {
        return this.bool_1;
      }
    }

    public bool SupportsText
    {
      get
      {
        return this.bool_0;
      }
    }

    public void CreateDrawables(DxfModel model)
    {
      this.CreateDrawables(model, Matrix4D.Identity);
    }

    public void CreateDrawables(DxfModel model, Matrix4D modelTransform)
    {
      this.ClearDrawables();
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WireframeGraphics2Cache.Class922(this), this.graphicsConfig_0, model, modelTransform);
    }

    public void CreateDrawables(DxfModel model, IList<DxfEntity> entities, Matrix4D modelTransform)
    {
      this.ClearDrawables();
      this.AddDrawables(model, entities, modelTransform);
    }

    public void AddDrawables(DxfModel model, IList<DxfEntity> entities, Matrix4D modelTransform)
    {
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WireframeGraphics2Cache.Class922(this), this.graphicsConfig_0, model, entities, modelTransform);
    }

    public void CreateDrawables(DxfModel model, DxfLayout layout)
    {
      this.CreateDrawables(model, layout, (ICollection<DxfViewport>) null);
    }

    public void CreateDrawables(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports)
    {
      this.ClearDrawables();
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WireframeGraphics2Cache.Class922(this), this.graphicsConfig_0, model, layout, viewports);
    }

    public void CreateDrawables(
      DxfModel model,
      IList<DxfEntity> modelSpaceEntities,
      IList<DxfEntity> paperSpaceEntities,
      DxfLayout layout,
      ICollection<DxfViewport> viewports)
    {
      this.ClearDrawables();
      this.AddDrawables(model, modelSpaceEntities, paperSpaceEntities, layout, viewports);
    }

    public void AddDrawables(
      DxfModel model,
      IList<DxfEntity> modelSpaceEntities,
      IList<DxfEntity> paperSpaceEntities,
      DxfLayout layout,
      ICollection<DxfViewport> viewports)
    {
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WireframeGraphics2Cache.Class922(this), this.graphicsConfig_0, model, modelSpaceEntities, paperSpaceEntities, layout, viewports);
      this.method_0();
    }

    public void UpdateDrawables(DxfEntity entity)
    {
      if (!this.bool_1)
        throw new Exception("Property AreDrawablesUpdateable is false.");
      WireframeGraphics2Cache.Class922 class922 = new WireframeGraphics2Cache.Class922(this);
      List<WireframeGraphics2Cache.Class923> class923List;
      if (!this.dictionary_0.TryGetValue(entity, out class923List))
        return;
      foreach (WireframeGraphics2Cache.Class923 entityDrawablesInfo in class923List.ToArray())
      {
        this.RemoveDrawables(entityDrawablesInfo, true);
        class922.CurrentDrawableNode = new LinkedListNodeRef<IWireframeDrawable2>(entityDrawablesInfo.EntityDrawable.Drawables, entityDrawablesInfo.EntityDrawable.Drawables.Last);
        class922.CurrentEntityDrawablesInfo = entityDrawablesInfo.Parent;
        class922.ExistingEntityDrawablesInfo = entityDrawablesInfo;
        entity.Draw(entityDrawablesInfo.DrawContext, (IWireframeGraphicsFactory2) class922);
      }
      this.method_0();
    }

    public void EraseDrawables(DxfEntity entity)
    {
      if (!this.bool_1)
        throw new Exception("Property AreDrawablesUpdateable is false.");
      List<WireframeGraphics2Cache.Class923> class923List;
      if (!this.dictionary_0.TryGetValue(entity, out class923List))
        return;
      foreach (WireframeGraphics2Cache.Class923 entityDrawablesInfo in class923List.ToArray())
        this.RemoveDrawables(entityDrawablesInfo, true);
      this.method_0();
    }

    public void RemoveDrawables(DxfEntity entity)
    {
      if (!this.bool_1)
        throw new Exception("Property AreDrawablesUpdateable is false.");
      List<WireframeGraphics2Cache.Class923> class923List;
      if (!this.dictionary_0.TryGetValue(entity, out class923List))
        return;
      foreach (WireframeGraphics2Cache.Class923 entityDrawablesInfo in class923List.ToArray())
        this.RemoveDrawables(entityDrawablesInfo, false);
    }

    public IList<IWireframeDrawable2> GetDrawables(
      RenderedEntityInfo renderedEntityInfo)
    {
      List<IWireframeDrawable2> wireframeDrawable2List = new List<IWireframeDrawable2>();
      List<WireframeGraphics2Cache.Class923> class923List;
      if (this.dictionary_0.TryGetValue(renderedEntityInfo.Entity, out class923List))
      {
        foreach (WireframeGraphics2Cache.Class923 class923 in class923List)
        {
          DrawContext drawContext = (DrawContext) class923.DrawContext;
          if (RenderedEntityInfo.IsMatch(renderedEntityInfo, drawContext))
            wireframeDrawable2List.Add((IWireframeDrawable2) class923.EntityDrawable);
        }
      }
      return (IList<IWireframeDrawable2>) wireframeDrawable2List;
    }

    public WireframeGraphics2Cache.UpdateEntityDrawablesHelper GetUpdateEntityDrawablesHelper(
      DxfEntity entity)
    {
      WireframeGraphics2Cache.UpdateEntityDrawablesHelper entityDrawablesHelper = (WireframeGraphics2Cache.UpdateEntityDrawablesHelper) null;
      List<WireframeGraphics2Cache.Class923> entityDrawablesInfoList;
      if (this.dictionary_0.TryGetValue(entity, out entityDrawablesInfoList))
        entityDrawablesHelper = new WireframeGraphics2Cache.UpdateEntityDrawablesHelper(entityDrawablesInfoList);
      return entityDrawablesHelper;
    }

    public void SuspendChangeNotification()
    {
      this.bool_2 = false;
    }

    public void ResumeChangeNotification()
    {
      this.bool_2 = true;
      if (!this.bool_3)
        return;
      this.OnChanged(EventArgs.Empty);
      this.bool_3 = false;
    }

    public void Clear()
    {
      this.ClearDrawables();
    }

    public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
    {
      foreach (IWireframeDrawable2 wireframeDrawable2 in this.linkedList_0)
        wireframeDrawable2.Draw(graphicsFactory);
    }

    protected virtual void OnChanged(EventArgs e)
    {
      if (this.eventHandler_0 == null)
        return;
      this.eventHandler_0((object) this, e);
    }

    private void method_0()
    {
      if (this.bool_2)
        this.OnChanged(EventArgs.Empty);
      else
        this.bool_3 = true;
    }

    private void ClearDrawables()
    {
      this.linkedList_0.Clear();
      if (this.dictionary_0 == null)
        return;
      this.dictionary_0.Clear();
    }

    private void RemoveDrawables(
      WireframeGraphics2Cache.Class923 entityDrawablesInfo,
      bool eraseOnly)
    {
      if (entityDrawablesInfo.Children != null)
      {
        foreach (WireframeGraphics2Cache.Class923 child in entityDrawablesInfo.Children)
          this.method_1(child);
      }
      entityDrawablesInfo.EraseDrawables();
      if (eraseOnly)
        return;
      this.method_2(entityDrawablesInfo);
    }

    private void method_1(
      WireframeGraphics2Cache.Class923 entityDrawablesInfo)
    {
      if (entityDrawablesInfo == null)
        return;
      this.method_2(entityDrawablesInfo);
      if (entityDrawablesInfo.Children == null)
        return;
      foreach (WireframeGraphics2Cache.Class923 child in entityDrawablesInfo.Children)
        this.method_1(child);
    }

    private void method_2(
      WireframeGraphics2Cache.Class923 entityDrawablesInfo)
    {
      List<WireframeGraphics2Cache.Class923> class923List;
      if (!this.dictionary_0.TryGetValue(entityDrawablesInfo.Entity, out class923List))
        return;
      class923List.Remove(entityDrawablesInfo);
      if (class923List.Count != 0)
        return;
      this.dictionary_0.Remove(entityDrawablesInfo.Entity);
    }

    private class Class922 : IWireframeGraphicsFactory2
    {
      private WireframeGraphics2Cache wireframeGraphics2Cache_0;
      private WireframeGraphics2Cache.Class925 class925_0;
      private LinkedListNodeRef<IWireframeDrawable2> linkedListNodeRef_0;
      private WireframeGraphics2Cache.Class923 class923_0;
      private WireframeGraphics2Cache.Class923 class923_1;
      private Stack<WireframeGraphics2Cache.Class923> stack_0;
      private Stack<LinkedListNodeRef<IWireframeDrawable2>> stack_1;

      public Class922(WireframeGraphics2Cache cache)
      {
        this.wireframeGraphics2Cache_0 = cache;
        this.linkedListNodeRef_0 = new LinkedListNodeRef<IWireframeDrawable2>(cache.linkedList_0, cache.linkedList_0.Last);
        if (cache.bool_1)
          this.stack_0 = new Stack<WireframeGraphics2Cache.Class923>();
        this.stack_1 = new Stack<LinkedListNodeRef<IWireframeDrawable2>>();
      }

      public LinkedListNodeRef<IWireframeDrawable2> CurrentDrawableNode
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

      public WireframeGraphics2Cache.Class923 ExistingEntityDrawablesInfo
      {
        get
        {
          return this.class923_1;
        }
        set
        {
          this.class923_1 = value;
        }
      }

      public WireframeGraphics2Cache.Class923 CurrentEntityDrawablesInfo
      {
        get
        {
          return this.class923_0;
        }
        set
        {
          this.class923_0 = value;
        }
      }

      public void BeginEntity(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
        WireframeGraphics2Cache.Class924 class924;
        LinkedListNode<IWireframeDrawable2> currentNode;
        if (this.class923_1 != null && this.class923_1.Entity == entity)
        {
          class924 = this.class923_1.EntityDrawable;
          currentNode = this.class923_1.EntityGeometryNode;
        }
        else
        {
          class924 = new WireframeGraphics2Cache.Class924(entity, drawContext);
          currentNode = this.linkedListNodeRef_0.Insert((IWireframeDrawable2) class924);
        }
        this.stack_1.Push(new LinkedListNodeRef<IWireframeDrawable2>(this.linkedListNodeRef_0.LinkedList, currentNode));
        if (this.wireframeGraphics2Cache_0.bool_1)
        {
          WireframeGraphics2Cache.Class923 class9230 = this.class923_0;
          if (this.class923_1 != null && this.class923_1.Entity == entity)
          {
            this.class923_0 = this.class923_1;
          }
          else
          {
            this.class923_0 = new WireframeGraphics2Cache.Class923(entity, drawContext);
            this.class923_0.EntityGeometryNode = currentNode;
            this.class923_0.EntityDrawable = class924;
            class9230?.method_0(this.class923_0);
            List<WireframeGraphics2Cache.Class923> class923List;
            if (!this.wireframeGraphics2Cache_0.dictionary_0.TryGetValue(entity, out class923List))
            {
              class923List = new List<WireframeGraphics2Cache.Class923>();
              this.wireframeGraphics2Cache_0.dictionary_0.Add(entity, class923List);
            }
            class923List.Add(this.class923_0);
          }
          this.stack_0.Push(this.class923_0);
        }
        this.linkedListNodeRef_0.Initialize(class924.Drawables);
      }

      public void EndEntity()
      {
        if (this.wireframeGraphics2Cache_0.bool_1)
        {
          this.stack_0.Pop();
          this.class923_0 = this.stack_0.Count > 0 ? this.stack_0.Peek() : (WireframeGraphics2Cache.Class923) null;
        }
        if (this.stack_1.Count > 0)
        {
          LinkedList<IWireframeDrawable2> linkedList = this.linkedListNodeRef_0.LinkedList;
          this.linkedListNodeRef_0 = this.stack_1.Pop();
          ((WireframeGraphics2Cache.Class924) this.linkedListNodeRef_0.CurrentNode.Value).Drawables = linkedList;
        }
        else
          this.linkedListNodeRef_0 = (LinkedListNodeRef<IWireframeDrawable2>) null;
      }

      public void BeginInsert(DxfInsert insert)
      {
        this.linkedListNodeRef_0.Insert((IWireframeDrawable2) new WireframeGraphics2Cache.Class927(insert));
      }

      public void EndInsert()
      {
        this.linkedListNodeRef_0.Insert((IWireframeDrawable2) WireframeGraphics2Cache.Class928.class928_0);
      }

      public void BeginGeometry(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        bool fill,
        bool stroke,
        bool correctForBackgroundColor)
      {
        if (this.class925_0 != null)
          throw new InvalidOperationException("BeginGeometry calls may not be nested.");
        this.class925_0 = new WireframeGraphics2Cache.Class925(entity, drawContext, color, forText, fill, stroke, correctForBackgroundColor);
        this.linkedListNodeRef_0.Insert((IWireframeDrawable2) this.class925_0);
      }

      public void EndGeometry()
      {
        if (this.class925_0 == null)
          throw new InvalidOperationException("There is no current geometry.");
        this.class925_0 = (WireframeGraphics2Cache.Class925) null;
      }

      public void CreateDot(DxfEntity entity, Vector4D position)
      {
        this.class925_0.Add((IWireframeDrawable2) new WireframeGraphics2Cache.Class929(entity, position));
      }

      public void CreateLine(DxfEntity entity, Vector4D start, Vector4D end)
      {
        this.class925_0.Add((IWireframeDrawable2) new WireframeGraphics2Cache.Class930(entity, start, end));
      }

      public void CreateRay(DxfEntity entity, Segment4D segment)
      {
        this.class925_0.Add((IWireframeDrawable2) new WireframeGraphics2Cache.Class931(entity, segment));
      }

      public void CreateXLine(DxfEntity entity, Vector4D? startPoint, Segment4D segment)
      {
        this.class925_0.Add((IWireframeDrawable2) new WireframeGraphics2Cache.Class932(entity, startPoint, segment));
      }

      public void CreatePolyline(DxfEntity entity, Polyline4D polyline)
      {
        this.class925_0.Add((IWireframeDrawable2) new WireframeGraphics2Cache.Class933(entity, polyline));
      }

      public void CreateShape(DxfEntity entity, IShape4D shape)
      {
        this.class925_0.Add((IWireframeDrawable2) new WireframeGraphics2Cache.Class934(entity, shape));
      }

      public void CreateImage(
        DxfRasterImage rasterImage,
        WW.Math.Point2D imageCorner1,
        WW.Math.Point2D imageCorner2,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis,
        DrawContext.Wireframe drawContext)
      {
        this.class925_0.Add((IWireframeDrawable2) new WireframeGraphics2Cache.Class935(rasterImage, imageCorner1, imageCorner2, transformedOrigin, transformedXAxis, transformedYAxis, drawContext));
      }

      public bool SupportsText
      {
        get
        {
          return this.wireframeGraphics2Cache_0.bool_0;
        }
      }

      public void CreateText(DxfText text)
      {
        this.class925_0.Add((IWireframeDrawable2) new WireframeGraphics2Cache.Class936(text));
      }

      public void CreateMText(DxfMText text)
      {
        this.class925_0.Add((IWireframeDrawable2) new WireframeGraphics2Cache.Class937(text));
      }
    }

    internal class Class923
    {
      private DxfEntity dxfEntity_0;
      private DrawContext.Wireframe wireframe_0;
      private LinkedListNode<IWireframeDrawable2> linkedListNode_0;
      private WireframeGraphics2Cache.Class924 class924_0;
      private WireframeGraphics2Cache.Class923 class923_0;
      private List<WireframeGraphics2Cache.Class923> list_0;

      public Class923(DxfEntity entity, DrawContext.Wireframe drawContext)
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
      }

      public LinkedListNode<IWireframeDrawable2> EntityGeometryNode
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

      public WireframeGraphics2Cache.Class924 EntityDrawable
      {
        get
        {
          return this.class924_0;
        }
        set
        {
          this.class924_0 = value;
        }
      }

      public WireframeGraphics2Cache.Class923 Parent
      {
        get
        {
          return this.class923_0;
        }
        set
        {
          this.class923_0 = value;
        }
      }

      public List<WireframeGraphics2Cache.Class923> Children
      {
        get
        {
          return this.list_0;
        }
      }

      public void method_0(WireframeGraphics2Cache.Class923 child)
      {
        if (this.list_0 == null)
          this.list_0 = new List<WireframeGraphics2Cache.Class923>();
        this.list_0.Add(child);
        child.class923_0 = this;
      }

      public void method_1(List<IWireframeDrawable2> result)
      {
        this.class924_0.method_0(result);
      }

      public void EraseDrawables()
      {
        if (this.class924_0 != null)
          this.class924_0.EraseDrawables();
        if (this.list_0 == null)
          return;
        this.list_0.Clear();
      }
    }

    internal class Class924 : IWireframeDrawable2
    {
      private DxfEntity dxfEntity_0;
      private DrawContext.Wireframe wireframe_0;
      private LinkedList<IWireframeDrawable2> linkedList_0;

      public Class924(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
        this.dxfEntity_0 = entity;
        this.wireframe_0 = drawContext;
      }

      public LinkedList<IWireframeDrawable2> Drawables
      {
        get
        {
          return this.linkedList_0;
        }
        set
        {
          this.linkedList_0 = value;
        }
      }

      public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
      {
        graphicsFactory.BeginEntity(this.dxfEntity_0, this.wireframe_0);
        if (this.linkedList_0 != null)
        {
          for (LinkedListNode<IWireframeDrawable2> linkedListNode = this.linkedList_0.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
            linkedListNode.Value.Draw(graphicsFactory);
        }
        graphicsFactory.EndEntity();
      }

      public void Add(IWireframeDrawable2 value)
      {
        if (this.linkedList_0 == null)
          this.linkedList_0 = new LinkedList<IWireframeDrawable2>();
        this.linkedList_0.AddLast(value);
      }

      internal void method_0(List<IWireframeDrawable2> result)
      {
        if (this.linkedList_0 == null)
          return;
        for (LinkedListNode<IWireframeDrawable2> linkedListNode = this.linkedList_0.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        {
          if (!(linkedListNode.Value is WireframeGraphics2Cache.Class926))
            result.Add(linkedListNode.Value);
        }
      }

      internal void EraseDrawables()
      {
        this.linkedList_0.Clear();
      }
    }

    internal class Class925 : IWireframeDrawable2
    {
      private DxfEntity dxfEntity_0;
      private DrawContext.Wireframe wireframe_0;
      private ArgbColor argbColor_0;
      private bool bool_0;
      private bool bool_1;
      private bool bool_2;
      private bool bool_3;
      private LinkedList<IWireframeDrawable2> linkedList_0;

      public Class925(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        bool fill,
        bool stroke,
        bool correctForBackgroundColor)
      {
        this.dxfEntity_0 = entity;
        this.wireframe_0 = drawContext;
        this.argbColor_0 = color;
        this.bool_0 = forText;
        this.bool_1 = fill;
        this.bool_2 = stroke;
        this.bool_3 = correctForBackgroundColor;
      }

      public LinkedList<IWireframeDrawable2> Drawables
      {
        get
        {
          return this.linkedList_0;
        }
        set
        {
          this.linkedList_0 = value;
        }
      }

      public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
      {
        if (this.linkedList_0 == null)
          return;
        graphicsFactory.BeginGeometry(this.dxfEntity_0, this.wireframe_0, this.argbColor_0, this.bool_0, this.bool_1, this.bool_2, this.bool_3);
        for (LinkedListNode<IWireframeDrawable2> linkedListNode = this.linkedList_0.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
          linkedListNode.Value.Draw(graphicsFactory);
        graphicsFactory.EndGeometry();
      }

      public void Add(IWireframeDrawable2 value)
      {
        if (this.linkedList_0 == null)
          this.linkedList_0 = new LinkedList<IWireframeDrawable2>();
        this.linkedList_0.AddLast(value);
      }
    }

    private class Class926 : IWireframeDrawable2
    {
      public static readonly WireframeGraphics2Cache.Class926 class926_0 = new WireframeGraphics2Cache.Class926();

      private Class926()
      {
      }

      public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
      {
      }
    }

    private class Class927 : IWireframeDrawable2
    {
      private DxfInsert dxfInsert_0;

      public Class927(DxfInsert insert)
      {
        this.dxfInsert_0 = insert;
      }

      public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
      {
        graphicsFactory.BeginInsert(this.dxfInsert_0);
      }
    }

    private class Class928 : IWireframeDrawable2
    {
      public static readonly WireframeGraphics2Cache.Class928 class928_0 = new WireframeGraphics2Cache.Class928();

      private Class928()
      {
      }

      public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
      {
        graphicsFactory.EndInsert();
      }
    }

    private class Class929 : IWireframeDrawable2
    {
      private DxfEntity dxfEntity_0;
      private Vector4D vector4D_0;

      public Class929(DxfEntity entity, Vector4D position)
      {
        this.dxfEntity_0 = entity;
        this.vector4D_0 = position;
      }

      public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
      {
        graphicsFactory.CreateDot(this.dxfEntity_0, this.vector4D_0);
      }
    }

    private class Class930 : IWireframeDrawable2
    {
      private DxfEntity dxfEntity_0;
      private Vector4D vector4D_0;
      private Vector4D vector4D_1;

      public Class930(DxfEntity entity, Vector4D start, Vector4D end)
      {
        this.dxfEntity_0 = entity;
        this.vector4D_0 = start;
        this.vector4D_1 = end;
      }

      public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
      {
        graphicsFactory.CreateLine(this.dxfEntity_0, this.vector4D_0, this.vector4D_1);
      }
    }

    private class Class931 : IWireframeDrawable2
    {
      private DxfEntity dxfEntity_0;
      private Segment4D segment4D_0;

      public Class931(DxfEntity entity, Segment4D segment)
      {
        this.dxfEntity_0 = entity;
        this.segment4D_0 = segment;
      }

      public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
      {
        graphicsFactory.CreateRay(this.dxfEntity_0, this.segment4D_0);
      }
    }

    private class Class932 : IWireframeDrawable2
    {
      private DxfEntity dxfEntity_0;
      private Vector4D? nullable_0;
      private Segment4D segment4D_0;

      public Class932(DxfEntity entity, Vector4D? startPoint, Segment4D segment)
      {
        this.dxfEntity_0 = entity;
        this.nullable_0 = startPoint;
        this.segment4D_0 = segment;
      }

      public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
      {
        graphicsFactory.CreateXLine(this.dxfEntity_0, this.nullable_0, this.segment4D_0);
      }
    }

    private class Class933 : IWireframeDrawable2
    {
      private DxfEntity dxfEntity_0;
      private Polyline4D polyline4D_0;

      public Class933(DxfEntity entity, Polyline4D polyline)
      {
        this.dxfEntity_0 = entity;
        this.polyline4D_0 = polyline;
      }

      public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
      {
        graphicsFactory.CreatePolyline(this.dxfEntity_0, this.polyline4D_0);
      }
    }

    private class Class934 : IWireframeDrawable2
    {
      private DxfEntity dxfEntity_0;
      private IShape4D ishape4D_0;

      public Class934(DxfEntity entity, IShape4D shape)
      {
        this.dxfEntity_0 = entity;
        this.ishape4D_0 = shape;
      }

      public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
      {
        graphicsFactory.CreateShape(this.dxfEntity_0, this.ishape4D_0);
      }
    }

    private class Class935 : IWireframeDrawable2
    {
      private readonly DxfRasterImage dxfRasterImage_0;
      private readonly WW.Math.Point2D point2D_0;
      private readonly WW.Math.Point2D point2D_1;
      private readonly Vector4D vector4D_0;
      private readonly Vector4D vector4D_1;
      private readonly Vector4D vector4D_2;
      private readonly DrawContext.Wireframe wireframe_0;

      public Class935(
        DxfRasterImage rasterImage,
        WW.Math.Point2D imageCorner1,
        WW.Math.Point2D imageCorner2,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis,
        DrawContext.Wireframe drawContext)
      {
        this.dxfRasterImage_0 = rasterImage;
        this.point2D_0 = imageCorner1;
        this.point2D_1 = imageCorner2;
        this.vector4D_0 = transformedOrigin;
        this.vector4D_1 = transformedXAxis;
        this.vector4D_2 = transformedYAxis;
        this.wireframe_0 = drawContext;
      }

      public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
      {
        graphicsFactory.CreateImage(this.dxfRasterImage_0, this.point2D_0, this.point2D_1, this.vector4D_0, this.vector4D_1, this.vector4D_2, this.wireframe_0);
      }
    }

    private class Class936 : IWireframeDrawable2
    {
      private DxfText dxfText_0;

      public Class936(DxfText text)
      {
        this.dxfText_0 = text;
      }

      public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
      {
        graphicsFactory.CreateText(this.dxfText_0);
      }
    }

    private class Class937 : IWireframeDrawable2
    {
      private DxfMText dxfMText_0;

      public Class937(DxfMText text)
      {
        this.dxfMText_0 = text;
      }

      public void Draw(IWireframeGraphicsFactory2 graphicsFactory)
      {
        graphicsFactory.CreateMText(this.dxfMText_0);
      }
    }

    public class UpdateEntityDrawablesHelper
    {
      private List<WireframeGraphics2Cache.Class923> list_0;

      internal UpdateEntityDrawablesHelper(
        List<WireframeGraphics2Cache.Class923> entityDrawablesInfoList)
      {
        this.list_0 = entityDrawablesInfoList;
      }

      public void Draw(DrawContext drawContext, IWireframeGraphicsFactory2 graphicsFactory)
      {
        foreach (WireframeGraphics2Cache.Class923 class923 in this.list_0)
        {
          if (drawContext.HaveSameBlockContextChain((DrawContext) class923.DrawContext) && class923.EntityDrawable != null)
            class923.EntityDrawable.Draw(graphicsFactory);
        }
      }
    }
  }
}
