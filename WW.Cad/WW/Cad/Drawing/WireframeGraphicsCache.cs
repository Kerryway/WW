// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.WireframeGraphicsCache
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
  public class WireframeGraphicsCache : ICadDrawer
  {
    private GraphicsConfig graphicsConfig_0 = GraphicsConfig.WhiteBackgroundCorrectForBackColor;
    private readonly LinkedList<IWireframeDrawable> linkedList_0 = new LinkedList<IWireframeDrawable>();
    private bool bool_2 = true;
    private readonly bool bool_0;
    private readonly bool bool_1;
    private readonly Dictionary<DxfEntity, List<WireframeGraphicsCache.Class958>> dictionary_0;
    private bool bool_3;

    public event EventHandler Changed;

    public WireframeGraphicsCache(bool supportsText, bool areDrawablesUpdateable)
    {
      this.bool_0 = supportsText;
      this.bool_1 = areDrawablesUpdateable;
      if (!areDrawablesUpdateable)
        return;
      this.dictionary_0 = new Dictionary<DxfEntity, List<WireframeGraphicsCache.Class958>>();
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

    public LinkedList<IWireframeDrawable> Drawables
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
      WireframeGraphicsFactoryUtil.CreateDrawables((IWireframeGraphicsFactory) new WireframeGraphicsCache.Class957(this), this.graphicsConfig_0, model, modelTransform);
    }

    public void CreateDrawables(DxfModel model, IList<DxfEntity> entities, Matrix4D modelTransform)
    {
      this.ClearDrawables();
      this.AddDrawables(model, entities, modelTransform);
    }

    public void AddDrawables(DxfModel model, IList<DxfEntity> entities, Matrix4D modelTransform)
    {
      WireframeGraphicsFactoryUtil.CreateDrawables((IWireframeGraphicsFactory) new WireframeGraphicsCache.Class957(this), this.graphicsConfig_0, model, entities, modelTransform);
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
      WireframeGraphicsFactoryUtil.CreateDrawables((IWireframeGraphicsFactory) new WireframeGraphicsCache.Class957(this), this.graphicsConfig_0, model, layout, viewports);
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
      WireframeGraphicsFactoryUtil.CreateDrawables((IWireframeGraphicsFactory) new WireframeGraphicsCache.Class957(this), this.graphicsConfig_0, model, modelSpaceEntities, paperSpaceEntities, layout, viewports);
      this.method_0();
    }

    public void UpdateDrawables(DxfEntity entity)
    {
      if (!this.bool_1)
        throw new Exception("Property AreDrawablesUpdateable is false.");
      WireframeGraphicsCache.Class957 class957 = new WireframeGraphicsCache.Class957(this);
      List<WireframeGraphicsCache.Class958> class958List;
      if (!this.dictionary_0.TryGetValue(entity, out class958List))
        return;
      foreach (WireframeGraphicsCache.Class958 entityDrawablesInfo in class958List.ToArray())
      {
        this.RemoveDrawables(entityDrawablesInfo, true);
        class957.CurrentDrawableNode = new LinkedListNodeRef<IWireframeDrawable>(entityDrawablesInfo.EntityDrawable.Drawables, entityDrawablesInfo.EntityDrawable.Drawables.Last);
        class957.CurrentEntityDrawablesInfo = entityDrawablesInfo.Parent;
        class957.ExistingEntityDrawablesInfo = entityDrawablesInfo;
        entity.Draw(entityDrawablesInfo.DrawContext, (IWireframeGraphicsFactory) class957);
      }
      this.method_0();
    }

    public void EraseDrawables(DxfEntity entity)
    {
      if (!this.bool_1)
        throw new Exception("Property AreDrawablesUpdateable is false.");
      List<WireframeGraphicsCache.Class958> class958List;
      if (!this.dictionary_0.TryGetValue(entity, out class958List))
        return;
      foreach (WireframeGraphicsCache.Class958 entityDrawablesInfo in class958List.ToArray())
        this.RemoveDrawables(entityDrawablesInfo, true);
      this.method_0();
    }

    public void RemoveDrawables(DxfEntity entity)
    {
      if (!this.bool_1)
        throw new Exception("Property AreDrawablesUpdateable is false.");
      List<WireframeGraphicsCache.Class958> class958List;
      if (!this.dictionary_0.TryGetValue(entity, out class958List))
        return;
      foreach (WireframeGraphicsCache.Class958 entityDrawablesInfo in class958List.ToArray())
        this.RemoveDrawables(entityDrawablesInfo, false);
    }

    public IList<IWireframeDrawable> GetDrawables(
      RenderedEntityInfo renderedEntityInfo)
    {
      List<IWireframeDrawable> wireframeDrawableList = new List<IWireframeDrawable>();
      List<WireframeGraphicsCache.Class958> class958List;
      if (this.dictionary_0.TryGetValue(renderedEntityInfo.Entity, out class958List))
      {
        foreach (WireframeGraphicsCache.Class958 class958 in class958List)
        {
          DrawContext drawContext = (DrawContext) class958.DrawContext;
          if (RenderedEntityInfo.IsMatch(renderedEntityInfo, drawContext))
            wireframeDrawableList.Add((IWireframeDrawable) class958.EntityDrawable);
        }
      }
      return (IList<IWireframeDrawable>) wireframeDrawableList;
    }

    public WireframeGraphicsCache.UpdateEntityDrawablesHelper GetUpdateEntityDrawablesHelper(
      DxfEntity entity)
    {
      WireframeGraphicsCache.UpdateEntityDrawablesHelper entityDrawablesHelper = (WireframeGraphicsCache.UpdateEntityDrawablesHelper) null;
      List<WireframeGraphicsCache.Class958> entityDrawablesInfoList;
      if (this.dictionary_0.TryGetValue(entity, out entityDrawablesInfoList))
        entityDrawablesHelper = new WireframeGraphicsCache.UpdateEntityDrawablesHelper(entityDrawablesInfoList);
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

    public void Draw(IWireframeGraphicsFactory graphicsFactory)
    {
      foreach (IWireframeDrawable wireframeDrawable in this.linkedList_0)
        wireframeDrawable.Draw(graphicsFactory);
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
      WireframeGraphicsCache.Class958 entityDrawablesInfo,
      bool eraseOnly)
    {
      if (entityDrawablesInfo.Children != null)
      {
        foreach (WireframeGraphicsCache.Class958 child in entityDrawablesInfo.Children)
          this.method_1(child);
      }
      entityDrawablesInfo.EraseDrawables();
      if (eraseOnly)
        return;
      this.method_2(entityDrawablesInfo);
    }

    private void method_1(
      WireframeGraphicsCache.Class958 entityDrawablesInfo)
    {
      if (entityDrawablesInfo == null)
        return;
      this.method_2(entityDrawablesInfo);
      if (entityDrawablesInfo.Children == null)
        return;
      foreach (WireframeGraphicsCache.Class958 child in entityDrawablesInfo.Children)
        this.method_1(child);
    }

    private void method_2(
      WireframeGraphicsCache.Class958 entityDrawablesInfo)
    {
      List<WireframeGraphicsCache.Class958> class958List;
      if (!this.dictionary_0.TryGetValue(entityDrawablesInfo.Entity, out class958List))
        return;
      class958List.Remove(entityDrawablesInfo);
      if (class958List.Count != 0)
        return;
      this.dictionary_0.Remove(entityDrawablesInfo.Entity);
    }

    private class Class957 : IWireframeGraphicsFactory
    {
      private WireframeGraphicsCache wireframeGraphicsCache_0;
      private LinkedListNodeRef<IWireframeDrawable> linkedListNodeRef_0;
      private WireframeGraphicsCache.Class958 class958_0;
      private WireframeGraphicsCache.Class958 class958_1;
      private Stack<WireframeGraphicsCache.Class958> stack_0;
      private Stack<LinkedListNodeRef<IWireframeDrawable>> stack_1;

      public Class957(WireframeGraphicsCache cache)
      {
        this.wireframeGraphicsCache_0 = cache;
        this.linkedListNodeRef_0 = new LinkedListNodeRef<IWireframeDrawable>(cache.linkedList_0, cache.linkedList_0.Last);
        if (cache.bool_1)
          this.stack_0 = new Stack<WireframeGraphicsCache.Class958>();
        this.stack_1 = new Stack<LinkedListNodeRef<IWireframeDrawable>>();
      }

      public LinkedListNodeRef<IWireframeDrawable> CurrentDrawableNode
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

      public WireframeGraphicsCache.Class958 ExistingEntityDrawablesInfo
      {
        get
        {
          return this.class958_1;
        }
        set
        {
          this.class958_1 = value;
        }
      }

      public WireframeGraphicsCache.Class958 CurrentEntityDrawablesInfo
      {
        get
        {
          return this.class958_0;
        }
        set
        {
          this.class958_0 = value;
        }
      }

      public bool SupportsText
      {
        get
        {
          return this.wireframeGraphicsCache_0.bool_0;
        }
      }

      public void BeginEntity(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
        WireframeGraphicsCache.Class959 class959;
        LinkedListNode<IWireframeDrawable> currentNode;
        if (this.class958_1 != null && this.class958_1.Entity == entity)
        {
          class959 = this.class958_1.EntityDrawable;
          currentNode = this.class958_1.EntityGeometryNode;
        }
        else
        {
          class959 = new WireframeGraphicsCache.Class959(entity, drawContext);
          currentNode = this.linkedListNodeRef_0.Insert((IWireframeDrawable) class959);
        }
        this.stack_1.Push(new LinkedListNodeRef<IWireframeDrawable>(this.linkedListNodeRef_0.LinkedList, currentNode));
        if (this.wireframeGraphicsCache_0.bool_1)
        {
          WireframeGraphicsCache.Class958 class9580 = this.class958_0;
          if (this.class958_1 != null && this.class958_1.Entity == entity)
          {
            this.class958_0 = this.class958_1;
          }
          else
          {
            this.class958_0 = new WireframeGraphicsCache.Class958(entity, drawContext);
            this.class958_0.EntityGeometryNode = currentNode;
            this.class958_0.EntityDrawable = class959;
            class9580?.method_0(this.class958_0);
            List<WireframeGraphicsCache.Class958> class958List;
            if (!this.wireframeGraphicsCache_0.dictionary_0.TryGetValue(entity, out class958List))
            {
              class958List = new List<WireframeGraphicsCache.Class958>();
              this.wireframeGraphicsCache_0.dictionary_0.Add(entity, class958List);
            }
            class958List.Add(this.class958_0);
          }
          this.stack_0.Push(this.class958_0);
        }
        this.linkedListNodeRef_0.Initialize(class959.Drawables, class959.Drawables.Last);
      }

      public void EndEntity()
      {
        if (this.wireframeGraphicsCache_0.bool_1)
        {
          this.stack_0.Pop();
          this.class958_0 = this.stack_0.Count > 0 ? this.stack_0.Peek() : (WireframeGraphicsCache.Class958) null;
        }
        if (this.stack_1.Count > 0)
          this.linkedListNodeRef_0 = this.stack_1.Pop();
        else
          this.linkedListNodeRef_0 = (LinkedListNodeRef<IWireframeDrawable>) null;
      }

      public void BeginInsert(DxfInsert insert)
      {
        this.linkedListNodeRef_0.Insert((IWireframeDrawable) new WireframeGraphicsCache.Class961(insert));
      }

      public void EndInsert()
      {
        this.linkedListNodeRef_0.Insert((IWireframeDrawable) WireframeGraphicsCache.Class962.class962_0);
      }

      public void CreateDot(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D position)
      {
        this.linkedListNodeRef_0.Insert((IWireframeDrawable) new WireframeGraphicsCache.Class963(entity, drawContext, color, forText, position));
      }

      public void CreateLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D start,
        Vector4D end)
      {
        this.linkedListNodeRef_0.Insert((IWireframeDrawable) new WireframeGraphicsCache.Class964(entity, drawContext, color, forText, start, end));
      }

      public void CreateRay(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Segment4D segment)
      {
        this.linkedListNodeRef_0.Insert((IWireframeDrawable) new WireframeGraphicsCache.Class965(entity, drawContext, color, segment));
      }

      public void CreateXLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Vector4D? startPoint,
        Segment4D segment)
      {
        this.linkedListNodeRef_0.Insert((IWireframeDrawable) new WireframeGraphicsCache.Class966(entity, drawContext, color, startPoint, segment));
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
        this.linkedListNodeRef_0.Insert((IWireframeDrawable) new WireframeGraphicsCache.Class967(entity, drawContext, color, forText, polylines, fill, correctForBackgroundColor));
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
        this.linkedListNodeRef_0.Insert((IWireframeDrawable) new WireframeGraphicsCache.Class968(entity, drawContext, color, forText, polylines, fill, correctForBackgroundColor));
      }

      public void CreateShape(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IShape4D shape)
      {
        this.linkedListNodeRef_0.Insert((IWireframeDrawable) new WireframeGraphicsCache.Class969(entity, drawContext, color, forText, shape));
      }

      public void CreateText(DxfText text, DrawContext.Wireframe drawContext, ArgbColor color)
      {
        this.linkedListNodeRef_0.Insert((IWireframeDrawable) new WireframeGraphicsCache.Class970(text, drawContext, color));
      }

      public void CreateMText(DxfMText text, DrawContext.Wireframe drawContext)
      {
        this.linkedListNodeRef_0.Insert((IWireframeDrawable) new WireframeGraphicsCache.Class971(text, drawContext));
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
        this.linkedListNodeRef_0.Insert((IWireframeDrawable) new WireframeGraphicsCache.Class972(rasterImage, drawContext, clipPolygon, imageBoundary, transformedOrigin, transformedXAxis, transformedYAxis));
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
        this.linkedListNodeRef_0.Insert((IWireframeDrawable) new WireframeGraphicsCache.Class973(entity, drawContext, bitmapProvider, clipPolygon, displaySize, transformedOrigin, transformedXAxis, transformedYAxis));
      }
    }

    internal class Class958
    {
      private DxfEntity dxfEntity_0;
      private DrawContext.Wireframe wireframe_0;
      private LinkedListNode<IWireframeDrawable> linkedListNode_0;
      private WireframeGraphicsCache.Class959 class959_0;
      private WireframeGraphicsCache.Class958 class958_0;
      private List<WireframeGraphicsCache.Class958> list_0;

      public Class958(DxfEntity entity, DrawContext.Wireframe drawContext)
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

      public LinkedListNode<IWireframeDrawable> EntityGeometryNode
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

      public WireframeGraphicsCache.Class959 EntityDrawable
      {
        get
        {
          return this.class959_0;
        }
        set
        {
          this.class959_0 = value;
        }
      }

      public WireframeGraphicsCache.Class958 Parent
      {
        get
        {
          return this.class958_0;
        }
        set
        {
          this.class958_0 = value;
        }
      }

      public List<WireframeGraphicsCache.Class958> Children
      {
        get
        {
          return this.list_0;
        }
      }

      public void method_0(WireframeGraphicsCache.Class958 child)
      {
        if (this.list_0 == null)
          this.list_0 = new List<WireframeGraphicsCache.Class958>();
        this.list_0.Add(child);
        child.class958_0 = this;
      }

      public void method_1(List<IWireframeDrawable> result)
      {
        this.class959_0.method_0(result);
      }

      public void EraseDrawables()
      {
        if (this.class959_0 != null)
          this.class959_0.EraseDrawables();
        if (this.list_0 == null)
          return;
        this.list_0.Clear();
      }
    }

    internal class Class959 : IWireframeDrawable
    {
      private LinkedList<IWireframeDrawable> linkedList_0 = new LinkedList<IWireframeDrawable>();
      private DxfEntity dxfEntity_0;
      private DrawContext.Wireframe wireframe_0;

      public Class959(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
        this.dxfEntity_0 = entity;
        this.wireframe_0 = drawContext;
      }

      public LinkedList<IWireframeDrawable> Drawables
      {
        get
        {
          return this.linkedList_0;
        }
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
        graphicsFactory.BeginEntity(this.dxfEntity_0, this.wireframe_0);
        for (LinkedListNode<IWireframeDrawable> linkedListNode = this.linkedList_0.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
          linkedListNode.Value.Draw(graphicsFactory);
        graphicsFactory.EndEntity();
      }

      internal void method_0(List<IWireframeDrawable> result)
      {
        if (this.linkedList_0.First == null)
          return;
        for (LinkedListNode<IWireframeDrawable> linkedListNode = this.linkedList_0.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        {
          if (!(linkedListNode.Value is WireframeGraphicsCache.Class960))
            result.Add(linkedListNode.Value);
        }
      }

      internal void EraseDrawables()
      {
        this.linkedList_0.Clear();
      }
    }

    private class Class960 : IWireframeDrawable
    {
      public static readonly WireframeGraphicsCache.Class960 class960_0 = new WireframeGraphicsCache.Class960();

      private Class960()
      {
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
      }
    }

    private class Class961 : IWireframeDrawable
    {
      private DxfInsert dxfInsert_0;

      public Class961(DxfInsert insert)
      {
        this.dxfInsert_0 = insert;
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
        graphicsFactory.BeginInsert(this.dxfInsert_0);
      }
    }

    private class Class962 : IWireframeDrawable
    {
      public static readonly WireframeGraphicsCache.Class962 class962_0 = new WireframeGraphicsCache.Class962();

      private Class962()
      {
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
        graphicsFactory.EndInsert();
      }
    }

    public class BaseDrawable
    {
      protected DxfEntity entity;
      protected DrawContext.Wireframe drawContext;
      protected ArgbColor color;

      public BaseDrawable(DxfEntity entity, DrawContext.Wireframe drawContext, ArgbColor color)
      {
        this.entity = entity;
        this.drawContext = drawContext;
        this.color = color;
      }
    }

    private class Class963 : WireframeGraphicsCache.BaseDrawable, IWireframeDrawable
    {
      private bool bool_0;
      private Vector4D vector4D_0;

      public Class963(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D position)
        : base(entity, drawContext, color)
      {
        this.bool_0 = forText;
        this.vector4D_0 = position;
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreateDot(this.entity, this.drawContext, this.color, this.bool_0, this.vector4D_0);
      }
    }

    private class Class964 : WireframeGraphicsCache.BaseDrawable, IWireframeDrawable
    {
      private bool bool_0;
      private Vector4D vector4D_0;
      private Vector4D vector4D_1;

      public Class964(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D start,
        Vector4D end)
        : base(entity, drawContext, color)
      {
        this.bool_0 = forText;
        this.vector4D_0 = start;
        this.vector4D_1 = end;
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreateLine(this.entity, this.drawContext, this.color, this.bool_0, this.vector4D_0, this.vector4D_1);
      }
    }

    private class Class965 : WireframeGraphicsCache.BaseDrawable, IWireframeDrawable
    {
      private Segment4D segment4D_0;

      public Class965(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Segment4D segment)
        : base(entity, drawContext, color)
      {
        this.color = color;
        this.segment4D_0 = segment;
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreateRay(this.entity, this.drawContext, this.color, this.segment4D_0);
      }
    }

    private class Class966 : WireframeGraphicsCache.BaseDrawable, IWireframeDrawable
    {
      private Vector4D? nullable_0;
      private Segment4D segment4D_0;

      public Class966(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Vector4D? startPoint,
        Segment4D segment)
        : base(entity, drawContext, color)
      {
        this.nullable_0 = startPoint;
        this.segment4D_0 = segment;
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreateXLine(this.entity, this.drawContext, this.color, this.nullable_0, this.segment4D_0);
      }
    }

    private class Class967 : WireframeGraphicsCache.BaseDrawable, IWireframeDrawable
    {
      private bool bool_0;
      private IList<Polyline4D> ilist_0;
      private bool bool_1;
      private bool bool_2;

      public Class967(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IList<Polyline4D> polylines,
        bool fill,
        bool correctForBackgroundColor)
        : base(entity, drawContext, color)
      {
        this.bool_0 = forText;
        this.ilist_0 = polylines;
        this.bool_1 = fill;
        this.bool_2 = correctForBackgroundColor;
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreatePath(this.entity, this.drawContext, this.color, this.bool_0, this.ilist_0, this.bool_1, this.bool_2);
      }
    }

    private class Class968 : WireframeGraphicsCache.BaseDrawable, IWireframeDrawable
    {
      private bool bool_0;
      private IList<Polyline4D> ilist_0;
      private bool bool_1;
      private bool bool_2;

      public Class968(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IList<Polyline4D> polylines,
        bool fill,
        bool correctForBackgroundColor)
        : base(entity, drawContext, color)
      {
        this.bool_0 = forText;
        this.ilist_0 = polylines;
        this.bool_1 = fill;
        this.bool_2 = correctForBackgroundColor;
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreatePathAsOne(this.entity, this.drawContext, this.color, this.bool_0, this.ilist_0, this.bool_1, this.bool_2);
      }
    }

    private class Class969 : WireframeGraphicsCache.BaseDrawable, IWireframeDrawable
    {
      private bool bool_0;
      private IShape4D ishape4D_0;

      public Class969(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IShape4D shape)
        : base(entity, drawContext, color)
      {
        this.bool_0 = forText;
        this.ishape4D_0 = shape;
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreateShape(this.entity, this.drawContext, this.color, this.bool_0, this.ishape4D_0);
      }
    }

    private class Class970 : IWireframeDrawable
    {
      private DxfText dxfText_0;
      private DrawContext.Wireframe wireframe_0;
      private ArgbColor argbColor_0;

      public Class970(DxfText text, DrawContext.Wireframe drawContext, ArgbColor color)
      {
        this.dxfText_0 = text;
        this.wireframe_0 = drawContext;
        this.argbColor_0 = color;
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreateText(this.dxfText_0, this.wireframe_0, this.argbColor_0);
      }
    }

    private class Class971 : IWireframeDrawable
    {
      private readonly DxfMText dxfMText_0;
      private readonly DrawContext.Wireframe wireframe_0;

      public Class971(DxfMText text, DrawContext.Wireframe drawContext)
      {
        this.dxfMText_0 = text;
        this.wireframe_0 = drawContext;
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreateMText(this.dxfMText_0, this.wireframe_0);
      }
    }

    private class Class972 : IWireframeDrawable
    {
      private DxfRasterImage dxfRasterImage_0;
      private DrawContext.Wireframe wireframe_0;
      private Polyline4D polyline4D_0;
      private Polyline4D polyline4D_1;
      private Vector4D vector4D_0;
      private Vector4D vector4D_1;
      private Vector4D vector4D_2;

      public Class972(
        DxfRasterImage rasterImage,
        DrawContext.Wireframe drawContext,
        Polyline4D clipPolygon,
        Polyline4D imageBoundary,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis)
      {
        this.dxfRasterImage_0 = rasterImage;
        this.wireframe_0 = drawContext;
        this.polyline4D_0 = clipPolygon;
        this.polyline4D_1 = imageBoundary;
        this.vector4D_0 = transformedOrigin;
        this.vector4D_1 = transformedXAxis;
        this.vector4D_2 = transformedYAxis;
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreateImage(this.dxfRasterImage_0, this.wireframe_0, this.polyline4D_0, this.polyline4D_1, this.vector4D_0, this.vector4D_1, this.vector4D_2);
      }
    }

    private class Class973 : IWireframeDrawable
    {
      private DxfEntity dxfEntity_0;
      private DrawContext.Wireframe wireframe_0;
      private IBitmapProvider ibitmapProvider_0;
      private Polyline4D polyline4D_0;
      private Size2D size2D_0;
      private Vector4D vector4D_0;
      private Vector4D vector4D_1;
      private Vector4D vector4D_2;

      public Class973(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        IBitmapProvider bitmapProvider,
        Polyline4D clipPolygon,
        Size2D displaySize,
        Vector4D transformedOrigin,
        Vector4D transformedXAxis,
        Vector4D transformedYAxis)
      {
        this.dxfEntity_0 = entity;
        this.wireframe_0 = drawContext;
        this.ibitmapProvider_0 = bitmapProvider;
        this.polyline4D_0 = clipPolygon;
        this.size2D_0 = displaySize;
        this.vector4D_0 = transformedOrigin;
        this.vector4D_1 = transformedXAxis;
        this.vector4D_2 = transformedYAxis;
      }

      public void Draw(IWireframeGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreateScalableImage(this.dxfEntity_0, this.wireframe_0, this.ibitmapProvider_0, this.polyline4D_0, this.size2D_0, this.vector4D_0, this.vector4D_1, this.vector4D_2);
      }
    }

    public class UpdateEntityDrawablesHelper
    {
      private List<WireframeGraphicsCache.Class958> list_0;

      internal UpdateEntityDrawablesHelper(
        List<WireframeGraphicsCache.Class958> entityDrawablesInfoList)
      {
        this.list_0 = entityDrawablesInfoList;
      }

      public void Draw(DrawContext drawContext, IWireframeGraphicsFactory graphicsFactory)
      {
        foreach (WireframeGraphicsCache.Class958 class958 in this.list_0)
        {
          if (drawContext.HaveSameBlockContextChain((DrawContext) class958.DrawContext) && class958.EntityDrawable != null)
            class958.EntityDrawable.Draw(graphicsFactory);
        }
      }
    }
  }
}
