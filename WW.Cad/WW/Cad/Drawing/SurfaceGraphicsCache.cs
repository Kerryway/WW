// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.SurfaceGraphicsCache
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public class SurfaceGraphicsCache
  {
    private GraphicsConfig graphicsConfig_0 = GraphicsConfig.WhiteBackgroundCorrectForBackColor;
    private LinkedList<ISurfaceDrawable> linkedList_0 = new LinkedList<ISurfaceDrawable>();
    private CharTriangulationCache charTriangulationCache_0 = new CharTriangulationCache();
    private bool bool_0;
    private Dictionary<DxfEntity, List<SurfaceGraphicsCache.Class508>> dictionary_0;

    public SurfaceGraphicsCache(bool areDrawablesUpdateable)
    {
      this.bool_0 = areDrawablesUpdateable;
      this.linkedList_0.AddLast((ISurfaceDrawable) SurfaceGraphicsCache.Class510.class510_0);
      this.linkedList_0.AddLast((ISurfaceDrawable) SurfaceGraphicsCache.Class510.class510_0);
      if (!areDrawablesUpdateable)
        return;
      this.dictionary_0 = new Dictionary<DxfEntity, List<SurfaceGraphicsCache.Class508>>();
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

    public LinkedList<ISurfaceDrawable> Drawables
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
        return this.bool_0;
      }
    }

    public CharTriangulationCache CharTriangulationCache
    {
      get
      {
        return this.charTriangulationCache_0;
      }
      set
      {
        this.charTriangulationCache_0 = value;
      }
    }

    public void CreateDrawables(DxfModel model)
    {
      this.CreateDrawables(model, Matrix4D.Identity);
    }

    public void CreateDrawables(DxfModel model, Matrix4D modelTransform)
    {
      this.ClearDrawables();
      SurfaceGraphicsCache.Class507 class507 = new SurfaceGraphicsCache.Class507(this);
      DrawContext.Surface context = (DrawContext.Surface) new DrawContext.Surface.ModelSpace(model, this.graphicsConfig_0, modelTransform, this.charTriangulationCache_0);
      model.Draw(context, (ISurfaceGraphicsFactory) class507);
    }

    public void CreateDrawables(DxfModel model, IList<DxfEntity> entities, Matrix4D modelTransform)
    {
      this.ClearDrawables();
      this.AddDrawables(model, entities, modelTransform);
    }

    public void AddDrawables(DxfModel model, IList<DxfEntity> entities, Matrix4D modelTransform)
    {
      SurfaceGraphicsCache.Class507 class507 = new SurfaceGraphicsCache.Class507(this);
      DrawContext.Surface context = (DrawContext.Surface) new DrawContext.Surface.ModelSpace(model, this.graphicsConfig_0, modelTransform, this.charTriangulationCache_0);
      foreach (DxfEntity entity in (IEnumerable<DxfEntity>) entities)
        entity.Draw(context, (ISurfaceGraphicsFactory) class507);
    }

    public void UpdateDrawables(DxfEntity entity)
    {
      if (!this.bool_0)
        throw new Exception("Property AreDrawablesUpdateable is false.");
      SurfaceGraphicsCache.Class507 class507 = new SurfaceGraphicsCache.Class507(this);
      List<SurfaceGraphicsCache.Class508> class508List;
      if (!this.dictionary_0.TryGetValue(entity, out class508List))
        return;
      foreach (SurfaceGraphicsCache.Class508 entityDrawablesInfo in class508List.ToArray())
      {
        class507.CurrentDrawableNode = entityDrawablesInfo.FirstDrawable.Previous;
        class507.CurrentEntityDrawablesInfo = entityDrawablesInfo.Parent;
        bool flag = entityDrawablesInfo.FirstDrawable.List != null;
        this.RemoveDrawables(entityDrawablesInfo);
        if (flag)
          entity.Draw(entityDrawablesInfo.DrawContext, (ISurfaceGraphicsFactory) class507);
      }
    }

    public void RemoveDrawables(DxfEntity entity)
    {
      if (!this.bool_0)
        throw new Exception("Property AreDrawablesUpdateable is false.");
      List<SurfaceGraphicsCache.Class508> class508List;
      if (!this.dictionary_0.TryGetValue(entity, out class508List))
        return;
      foreach (SurfaceGraphicsCache.Class508 entityDrawablesInfo in class508List.ToArray())
        this.RemoveDrawables(entityDrawablesInfo);
    }

    public IList<ISurfaceDrawable> GetDrawables(
      RenderedEntityInfo renderedEntityInfo)
    {
      List<ISurfaceDrawable> result = new List<ISurfaceDrawable>();
      List<SurfaceGraphicsCache.Class508> class508List;
      if (this.dictionary_0.TryGetValue(renderedEntityInfo.Entity, out class508List))
      {
        foreach (SurfaceGraphicsCache.Class508 class508 in class508List)
        {
          DrawContext drawContext = (DrawContext) class508.DrawContext;
          if (RenderedEntityInfo.IsMatch(renderedEntityInfo, drawContext))
            class508.method_1(result);
        }
      }
      return (IList<ISurfaceDrawable>) result;
    }

    private void ClearDrawables()
    {
      this.linkedList_0.Clear();
      this.linkedList_0.AddLast((ISurfaceDrawable) SurfaceGraphicsCache.Class510.class510_0);
      this.linkedList_0.AddLast((ISurfaceDrawable) SurfaceGraphicsCache.Class510.class510_0);
      if (this.dictionary_0 == null)
        return;
      this.dictionary_0.Clear();
    }

    private void RemoveDrawables(SurfaceGraphicsCache.Class508 entityDrawablesInfo)
    {
      LinkedListNode<ISurfaceDrawable> next;
      if (entityDrawablesInfo.HasDrawables)
      {
        for (LinkedListNode<ISurfaceDrawable> node = entityDrawablesInfo.FirstDrawable; node != null; node = next)
        {
          next = node.Next;
          this.linkedList_0.Remove(node);
          if (node == entityDrawablesInfo.LastDrawable)
            break;
        }
      }
      this.method_0(entityDrawablesInfo);
    }

    private void method_0(SurfaceGraphicsCache.Class508 entityDrawablesInfo)
    {
      if (entityDrawablesInfo == null)
        return;
      List<SurfaceGraphicsCache.Class508> class508List;
      if (this.dictionary_0.TryGetValue(entityDrawablesInfo.Entity, out class508List))
      {
        class508List.Remove(entityDrawablesInfo);
        if (class508List.Count == 0)
          this.dictionary_0.Remove(entityDrawablesInfo.Entity);
      }
      if (entityDrawablesInfo.Children == null)
        return;
      foreach (SurfaceGraphicsCache.Class508 child in entityDrawablesInfo.Children)
        this.method_0(child);
    }

    private class Class507 : ISurfaceGraphicsFactory
    {
      private SurfaceGraphicsCache surfaceGraphicsCache_0;
      private LinkedListNode<ISurfaceDrawable> linkedListNode_0;
      private SurfaceGraphicsCache.Class508 class508_0;
      private Stack<SurfaceGraphicsCache.Class508> stack_0;
      private Stack<LinkedListNode<ISurfaceDrawable>> stack_1;

      public Class507(SurfaceGraphicsCache cache)
      {
        this.surfaceGraphicsCache_0 = cache;
        this.linkedListNode_0 = cache.linkedList_0.Last.Previous;
        if (cache.bool_0)
          this.stack_0 = new Stack<SurfaceGraphicsCache.Class508>();
        this.stack_1 = new Stack<LinkedListNode<ISurfaceDrawable>>();
      }

      public LinkedListNode<ISurfaceDrawable> CurrentDrawableNode
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

      public SurfaceGraphicsCache.Class508 CurrentEntityDrawablesInfo
      {
        get
        {
          return this.class508_0;
        }
        set
        {
          this.class508_0 = value;
        }
      }

      public void BeginNode(DxfEntity entity, DrawContext.Surface drawContext)
      {
        SurfaceGraphicsCache.Class509 class509 = new SurfaceGraphicsCache.Class509(entity, drawContext);
        if (this.surfaceGraphicsCache_0.bool_0)
        {
          SurfaceGraphicsCache.Class508 class5080 = this.class508_0;
          this.class508_0 = new SurfaceGraphicsCache.Class508(entity, drawContext);
          class5080?.method_0(this.class508_0);
          this.class508_0.FirstDrawable = this.linkedListNode_0;
          this.class508_0.LastDrawable = this.linkedListNode_0.Next;
          this.stack_0.Push(this.class508_0);
          List<SurfaceGraphicsCache.Class508> class508List;
          if (!this.surfaceGraphicsCache_0.dictionary_0.TryGetValue(entity, out class508List))
          {
            class508List = new List<SurfaceGraphicsCache.Class508>();
            this.surfaceGraphicsCache_0.dictionary_0.Add(entity, class508List);
          }
          class508List.Add(this.class508_0);
        }
        this.stack_1.Push(this.linkedListNode_0.List.AddAfter(this.linkedListNode_0, (ISurfaceDrawable) class509));
        this.linkedListNode_0 = class509.Drawables.First;
      }

      public void EndNode()
      {
        if (this.surfaceGraphicsCache_0.bool_0)
        {
          this.class508_0.FirstDrawable = this.class508_0.FirstDrawable.Next;
          this.class508_0.LastDrawable = this.class508_0.LastDrawable.Previous;
          this.stack_0.Pop();
          this.class508_0 = this.stack_0.Count > 0 ? this.stack_0.Peek() : (SurfaceGraphicsCache.Class508) null;
        }
        if (this.stack_1.Count > 0)
          this.linkedListNode_0 = this.stack_1.Pop();
        else
          this.linkedListNode_0 = (LinkedListNode<ISurfaceDrawable>) null;
      }

      public void SetColor(ArgbColor color)
      {
        this.linkedListNode_0 = this.linkedListNode_0.List.AddAfter(this.linkedListNode_0, (ISurfaceDrawable) new SurfaceGraphicsCache.Class511(color));
      }

      public void CreatePoint(Vector4D point)
      {
        this.linkedListNode_0 = this.linkedListNode_0.List.AddAfter(this.linkedListNode_0, (ISurfaceDrawable) new SurfaceGraphicsCache.Class512(point));
      }

      public void CreateSegment(Vector4D start, Vector4D end)
      {
        this.linkedListNode_0 = this.linkedListNode_0.List.AddAfter(this.linkedListNode_0, (ISurfaceDrawable) new SurfaceGraphicsCache.Class513(start, end));
      }

      public void CreatePolyline(IList<Vector4D> polyline, bool closed)
      {
        this.linkedListNode_0 = this.linkedListNode_0.List.AddAfter(this.linkedListNode_0, (ISurfaceDrawable) new SurfaceGraphicsCache.Class514(polyline, closed));
      }

      public void CreateTriangle(Vector4D v0, Vector4D v1, Vector4D v2, IList<bool> edgeVisible)
      {
        this.linkedListNode_0 = this.linkedListNode_0.List.AddAfter(this.linkedListNode_0, (ISurfaceDrawable) new SurfaceGraphicsCache.Class515(v0, v1, v2, edgeVisible));
      }

      public void CreateQuad(IList<Vector4D> polygon, IList<bool> edgeVisible)
      {
        this.linkedListNode_0 = this.linkedListNode_0.List.AddAfter(this.linkedListNode_0, (ISurfaceDrawable) new SurfaceGraphicsCache.Class516(polygon, edgeVisible));
      }

      public void CreateQuadStrip(
        IList<Vector4D> polyline1,
        IList<Vector4D> polyline2,
        Vector3D normal,
        bool close)
      {
        this.linkedListNode_0 = this.linkedListNode_0.List.AddAfter(this.linkedListNode_0, (ISurfaceDrawable) new SurfaceGraphicsCache.Class517(polyline1, polyline2, normal, close));
      }

      public void CreateQuadStrip(
        IList<Vector4D> polyline1,
        IList<Vector4D> polyline2,
        IList<Vector3D> normals,
        int startVertexIndex,
        int endVertexIndex)
      {
        this.linkedListNode_0 = this.linkedListNode_0.List.AddAfter(this.linkedListNode_0, (ISurfaceDrawable) new SurfaceGraphicsCache.Class518(polyline1, polyline2, normals, startVertexIndex, endVertexIndex));
      }

      public void CreatePolygonMesh(
        Vector4D[,] polygonMesh,
        bool closedInMDirection,
        bool closedInNDirection)
      {
        this.linkedListNode_0 = this.linkedListNode_0.List.AddAfter(this.linkedListNode_0, (ISurfaceDrawable) new SurfaceGraphicsCache.Class519(polygonMesh, closedInMDirection, closedInNDirection));
      }

      public void CreateTexturedTriangles(
        byte[] rgbaBytes,
        int width,
        int height,
        Vector3D normal,
        IList<Triangulator2D.Triangle> triangles,
        IList<WW.Math.Point2D> textureCoordinates,
        IList<Vector4D> points)
      {
        this.linkedListNode_0 = this.linkedListNode_0.List.AddAfter(this.linkedListNode_0, (ISurfaceDrawable) new SurfaceGraphicsCache.Class520(rgbaBytes, width, height, normal, triangles, textureCoordinates, points));
      }
    }

    private class Class508
    {
      private DxfEntity dxfEntity_0;
      private DrawContext.Surface surface_0;
      private LinkedListNode<ISurfaceDrawable> linkedListNode_0;
      private LinkedListNode<ISurfaceDrawable> linkedListNode_1;
      private SurfaceGraphicsCache.Class508 class508_0;
      private List<SurfaceGraphicsCache.Class508> list_0;

      public Class508(DxfEntity entity, DrawContext.Surface drawContext)
      {
        this.dxfEntity_0 = entity;
        this.surface_0 = drawContext;
      }

      public DxfEntity Entity
      {
        get
        {
          return this.dxfEntity_0;
        }
      }

      public DrawContext.Surface DrawContext
      {
        get
        {
          return this.surface_0;
        }
      }

      public LinkedListNode<ISurfaceDrawable> FirstDrawable
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

      public LinkedListNode<ISurfaceDrawable> LastDrawable
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

      public bool HasDrawables
      {
        get
        {
          if (this.linkedListNode_0.List != null)
            return this.linkedListNode_0.Previous != this.linkedListNode_1;
          return false;
        }
      }

      public SurfaceGraphicsCache.Class508 Parent
      {
        get
        {
          return this.class508_0;
        }
        set
        {
          this.class508_0 = value;
        }
      }

      public List<SurfaceGraphicsCache.Class508> Children
      {
        get
        {
          return this.list_0;
        }
      }

      public void method_0(SurfaceGraphicsCache.Class508 child)
      {
        if (this.list_0 == null)
          this.list_0 = new List<SurfaceGraphicsCache.Class508>();
        this.list_0.Add(child);
        child.class508_0 = this;
      }

      public void method_1(List<ISurfaceDrawable> result)
      {
        if (!this.HasDrawables)
          return;
        LinkedListNode<ISurfaceDrawable> linkedListNode = this.linkedListNode_0;
        while (true)
        {
          if (!(linkedListNode.Value is SurfaceGraphicsCache.Class510))
            goto label_4;
label_2:
          if (linkedListNode != this.linkedListNode_1)
          {
            linkedListNode = linkedListNode.Next;
            continue;
          }
          break;
label_4:
          result.Add(linkedListNode.Value);
          goto label_2;
        }
      }
    }

    private class Class509 : ISurfaceDrawable
    {
      private readonly LinkedList<ISurfaceDrawable> linkedList_0 = new LinkedList<ISurfaceDrawable>();
      private readonly DxfEntity dxfEntity_0;
      private readonly DrawContext.Surface surface_0;

      public Class509(DxfEntity entity, DrawContext.Surface drawContext)
      {
        this.dxfEntity_0 = entity;
        this.surface_0 = drawContext;
        this.linkedList_0.AddLast((ISurfaceDrawable) SurfaceGraphicsCache.Class510.class510_0);
        this.linkedList_0.AddLast((ISurfaceDrawable) SurfaceGraphicsCache.Class510.class510_0);
      }

      public LinkedList<ISurfaceDrawable> Drawables
      {
        get
        {
          return this.linkedList_0;
        }
      }

      public void Draw(ISurfaceGraphicsFactory graphicsFactory)
      {
        graphicsFactory.BeginNode(this.dxfEntity_0, this.surface_0);
        for (LinkedListNode<ISurfaceDrawable> linkedListNode = this.linkedList_0.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
          linkedListNode.Value.Draw(graphicsFactory);
        graphicsFactory.EndNode();
      }
    }

    private class Class510 : ISurfaceDrawable
    {
      public static readonly SurfaceGraphicsCache.Class510 class510_0 = new SurfaceGraphicsCache.Class510();

      private Class510()
      {
      }

      public void Draw(ISurfaceGraphicsFactory graphicsFactory)
      {
      }
    }

    private class Class511 : ISurfaceDrawable
    {
      private ArgbColor argbColor_0;

      public Class511(ArgbColor color)
      {
        this.argbColor_0 = color;
      }

      public void Draw(ISurfaceGraphicsFactory graphicsFactory)
      {
        graphicsFactory.SetColor(this.argbColor_0);
      }
    }

    private class Class512 : ISurfaceDrawable
    {
      private Vector4D vector4D_0;

      public Class512(Vector4D point)
      {
        this.vector4D_0 = point;
      }

      public void Draw(ISurfaceGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreatePoint(this.vector4D_0);
      }
    }

    private class Class513 : ISurfaceDrawable
    {
      private Vector4D vector4D_0;
      private Vector4D vector4D_1;

      public Class513(Vector4D start, Vector4D end)
      {
        this.vector4D_0 = start;
        this.vector4D_1 = end;
      }

      public void Draw(ISurfaceGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreateSegment(this.vector4D_0, this.vector4D_1);
      }
    }

    private class Class514 : ISurfaceDrawable
    {
      private IList<Vector4D> ilist_0;
      private bool bool_0;

      public Class514(IList<Vector4D> polyline, bool closed)
      {
        this.ilist_0 = polyline;
        this.bool_0 = closed;
      }

      public void Draw(ISurfaceGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreatePolyline(this.ilist_0, this.bool_0);
      }
    }

    private class Class515 : ISurfaceDrawable
    {
      private Vector4D vector4D_0;
      private Vector4D vector4D_1;
      private Vector4D vector4D_2;
      private IList<bool> ilist_0;

      public Class515(Vector4D v0, Vector4D v1, Vector4D v2, IList<bool> edgeVisible)
      {
        this.vector4D_0 = v0;
        this.vector4D_1 = v1;
        this.vector4D_2 = v2;
        this.ilist_0 = edgeVisible;
      }

      public void Draw(ISurfaceGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreateTriangle(this.vector4D_0, this.vector4D_1, this.vector4D_2, this.ilist_0);
      }
    }

    private class Class516 : ISurfaceDrawable
    {
      private IList<Vector4D> ilist_0;
      private IList<bool> ilist_1;

      public Class516(IList<Vector4D> polygon, IList<bool> edgeVisible)
      {
        this.ilist_0 = polygon;
        this.ilist_1 = edgeVisible;
      }

      public void Draw(ISurfaceGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreateQuad(this.ilist_0, this.ilist_1);
      }
    }

    private class Class517 : ISurfaceDrawable
    {
      private IList<Vector4D> ilist_0;
      private IList<Vector4D> ilist_1;
      private Vector3D vector3D_0;
      private bool bool_0;

      public Class517(
        IList<Vector4D> polyline1,
        IList<Vector4D> polyline2,
        Vector3D normal,
        bool close)
      {
        this.ilist_0 = polyline1;
        this.ilist_1 = polyline2;
        this.vector3D_0 = normal;
        this.bool_0 = close;
      }

      public void Draw(ISurfaceGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreateQuadStrip(this.ilist_0, this.ilist_1, this.vector3D_0, this.bool_0);
      }
    }

    private class Class518 : ISurfaceDrawable
    {
      private IList<Vector4D> ilist_0;
      private IList<Vector4D> ilist_1;
      private IList<Vector3D> ilist_2;
      private int int_0;
      private int int_1;

      public Class518(
        IList<Vector4D> polyline1,
        IList<Vector4D> polyline2,
        IList<Vector3D> normals,
        int startVertexIndex,
        int endVertexIndex)
      {
        this.ilist_0 = polyline1;
        this.ilist_1 = polyline2;
        this.ilist_2 = normals;
        this.int_0 = startVertexIndex;
        this.int_1 = endVertexIndex;
      }

      public void Draw(ISurfaceGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreateQuadStrip(this.ilist_0, this.ilist_1, this.ilist_2, this.int_0, this.int_1);
      }
    }

    private class Class519 : ISurfaceDrawable
    {
      private Vector4D[,] vector4D_0;
      private bool bool_0;
      private bool bool_1;

      public Class519(Vector4D[,] polygonMesh, bool closedInMDirection, bool closedInNDirection)
      {
        this.vector4D_0 = polygonMesh;
        this.bool_0 = closedInMDirection;
        this.bool_1 = closedInNDirection;
      }

      public void Draw(ISurfaceGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreatePolygonMesh(this.vector4D_0, this.bool_0, this.bool_1);
      }
    }

    private class Class520 : ISurfaceDrawable
    {
      private byte[] byte_0;
      private int int_0;
      private int int_1;
      private Vector3D vector3D_0;
      private IList<Triangulator2D.Triangle> ilist_0;
      private IList<WW.Math.Point2D> ilist_1;
      private IList<Vector4D> ilist_2;

      public Class520(
        byte[] rgbaBytes,
        int width,
        int height,
        Vector3D normal,
        IList<Triangulator2D.Triangle> triangles,
        IList<WW.Math.Point2D> textureCoordinates,
        IList<Vector4D> points)
      {
        this.byte_0 = rgbaBytes;
        this.int_0 = width;
        this.int_1 = height;
        this.vector3D_0 = normal;
        this.ilist_0 = triangles;
        this.ilist_1 = textureCoordinates;
        this.ilist_2 = points;
      }

      public void Draw(ISurfaceGraphicsFactory graphicsFactory)
      {
        graphicsFactory.CreateTexturedTriangles(this.byte_0, this.int_0, this.int_1, this.vector3D_0, this.ilist_0, this.ilist_1, this.ilist_2);
      }
    }
  }
}
