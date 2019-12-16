// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Wpf.WpfWireframeGraphics3D
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns29;
using ns36;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Collections.Generic;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing.Wpf
{
  public class WpfWireframeGraphics3D
  {
    private GraphicsConfig graphicsConfig_0 = GraphicsConfig.AcadLikeWithWhiteBackground;
    private readonly LinkedList<Interface37> linkedList_0 = new LinkedList<Interface37>();
    private Matrix4D matrix4D_0 = Matrix4D.Identity;
    private double double_0 = 1.0;
    private double double_1 = 1.0;
    private CadGraphicsHelper.ObjectTaggerDelegate objectTaggerDelegate_0 = new CadGraphicsHelper.ObjectTaggerDelegate(CadGraphicsHelper.EntityObjectTagger);
    private WpfWireframeGraphics3D.PathStrokePreparerDelegate pathStrokePreparerDelegate_0;
    private bool bool_0;
    private Dictionary<DxfEntity, List<WpfWireframeGraphics3D.Class451>> dictionary_0;

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

    public Matrix4D To2DTransform
    {
      get
      {
        return this.matrix4D_0;
      }
      set
      {
        this.matrix4D_0 = value;
      }
    }

    public double NonTextPenWidth
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    public CadGraphicsHelper.ObjectTaggerDelegate FrameworkElementTagger
    {
      get
      {
        return this.objectTaggerDelegate_0;
      }
      set
      {
        this.objectTaggerDelegate_0 = value ?? new CadGraphicsHelper.ObjectTaggerDelegate(CadGraphicsHelper.NullObjectTagger);
      }
    }

    public WpfWireframeGraphics3D.PathStrokePreparerDelegate PathStrokePreparer
    {
      get
      {
        return this.pathStrokePreparerDelegate_0;
      }
      set
      {
        this.pathStrokePreparerDelegate_0 = value;
      }
    }

    public double TextPenWidth
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

    public bool AreDrawablesUpdateable
    {
      get
      {
        return this.bool_0;
      }
    }

    public void Clear()
    {
      this.linkedList_0.Clear();
      if (!this.bool_0)
        return;
      this.dictionary_0.Clear();
    }

    public void EnableDrawablesUpdate()
    {
      if (this.bool_0)
        return;
      this.bool_0 = true;
      this.dictionary_0 = new Dictionary<DxfEntity, List<WpfWireframeGraphics3D.Class451>>();
    }

    public void UpdateDrawables(DxfEntity entity)
    {
      this.UpdateDrawables(entity, new System.Action<DrawContext.Wireframe, IWireframeGraphicsFactory2>(entity.Draw), (Func<IWireframeGraphicsFactory2, IWireframeGraphicsFactory2>) null);
    }

    public void UpdateDrawables(
      RenderedEntityInfo renderedEntityInfo,
      System.Action updateDrawables,
      System.Action<IWireframeGraphicsFactory2> graphicsFactoryWrapper)
    {
      if (!this.bool_0)
        throw new Exception("Property AreDrawablesUpdateable is false.");
      List<WpfWireframeGraphics3D.Class451> class451List;
      if (!this.dictionary_0.TryGetValue(renderedEntityInfo.Entity, out class451List))
        return;
      WpfWireframeGraphics3D.Class451[] array = class451List.ToArray();
      WpfWireframeGraphics3D.Class452 graphicsFactory = (WpfWireframeGraphics3D.Class452) this.CreateGraphicsFactory();
      if (graphicsFactoryWrapper != null)
        graphicsFactoryWrapper((IWireframeGraphicsFactory2) graphicsFactory);
      foreach (WpfWireframeGraphics3D.Class451 entityDrawablesInfo in array)
      {
        if (entityDrawablesInfo.Matches(renderedEntityInfo))
        {
          this.RemoveDrawables(entityDrawablesInfo, true);
          graphicsFactory.CurrentColoredDrawableNode = new LinkedListNodeRef<Interface37>(entityDrawablesInfo.EntityDrawableNode.List, entityDrawablesInfo.EntityDrawableNode);
          graphicsFactory.CurrentEntityDrawablesInfo = entityDrawablesInfo.Parent;
          graphicsFactory.ExistingEntityDrawablesInfo = entityDrawablesInfo;
          updateDrawables();
        }
      }
    }

    public void UpdateDrawables(
      DxfEntity entity,
      System.Action<DrawContext.Wireframe, IWireframeGraphicsFactory2> updateDrawables,
      Func<IWireframeGraphicsFactory2, IWireframeGraphicsFactory2> graphicsFactoryWrapper)
    {
      if (!this.bool_0)
        throw new Exception("Property AreDrawablesUpdateable is false.");
      List<WpfWireframeGraphics3D.Class451> class451List;
      if (!this.dictionary_0.TryGetValue(entity, out class451List))
        return;
      WpfWireframeGraphics3D.Class451[] array = class451List.ToArray();
      WpfWireframeGraphics3D.Class452 graphicsFactory = (WpfWireframeGraphics3D.Class452) this.CreateGraphicsFactory();
      IWireframeGraphicsFactory2 graphicsFactory2 = (IWireframeGraphicsFactory2) graphicsFactory;
      if (graphicsFactoryWrapper != null)
        graphicsFactory2 = graphicsFactoryWrapper((IWireframeGraphicsFactory2) graphicsFactory);
      foreach (WpfWireframeGraphics3D.Class451 entityDrawablesInfo in array)
      {
        this.RemoveDrawables(entityDrawablesInfo, true);
        graphicsFactory.CurrentColoredDrawableNode = new LinkedListNodeRef<Interface37>(entityDrawablesInfo.EntityDrawableNode.List, entityDrawablesInfo.EntityDrawableNode);
        graphicsFactory.CurrentEntityDrawablesInfo = entityDrawablesInfo.Parent;
        graphicsFactory.ExistingEntityDrawablesInfo = entityDrawablesInfo;
        updateDrawables(entityDrawablesInfo.DrawContext, graphicsFactory2);
      }
    }

    public void RemoveDrawables(DxfEntity entity)
    {
      if (!this.bool_0)
        throw new Exception("Property AreDrawablesUpdateable is false.");
      List<WpfWireframeGraphics3D.Class451> class451List;
      if (!this.dictionary_0.TryGetValue(entity, out class451List))
        return;
      foreach (WpfWireframeGraphics3D.Class451 entityDrawablesInfo in class451List.ToArray())
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
      this.Clear();
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WpfWireframeGraphics3D.Class452(this), this.graphicsConfig_0, model, modelTransform);
    }

    public void AddDrawables(DxfModel model, Matrix4D modelTransform)
    {
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WpfWireframeGraphics3D.Class452(this), this.graphicsConfig_0, model, modelTransform);
    }

    public void CreateDrawables(DxfModel model, IList<DxfEntity> entities, Matrix4D modelTransform)
    {
      this.Clear();
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WpfWireframeGraphics3D.Class452(this), this.graphicsConfig_0, model, entities, modelTransform);
    }

    public void AddDrawables(DxfModel model, IList<DxfEntity> entities, Matrix4D modelTransform)
    {
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WpfWireframeGraphics3D.Class452(this), this.graphicsConfig_0, model, entities, modelTransform);
    }

    public void CreateDrawables(DxfModel model, DxfLayout layout)
    {
      this.CreateDrawables(model, layout, (ICollection<DxfViewport>) null);
    }

    public void AddDrawables(DxfModel model, DxfLayout layout)
    {
      this.AddDrawables(model, layout, (ICollection<DxfViewport>) null);
    }

    public void CreateDrawables(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports)
    {
      this.Clear();
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WpfWireframeGraphics3D.Class452(this), this.graphicsConfig_0, model, layout, viewports);
    }

    public void AddDrawables(DxfModel model, DxfLayout layout, ICollection<DxfViewport> viewports)
    {
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WpfWireframeGraphics3D.Class452(this), this.graphicsConfig_0, model, layout, viewports);
    }

    public void CreateDrawables(
      DxfModel model,
      IList<DxfEntity> modelSpaceEntities,
      IList<DxfEntity> paperSpaceEntities,
      DxfLayout layout,
      ICollection<DxfViewport> viewports)
    {
      this.Clear();
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WpfWireframeGraphics3D.Class452(this), this.graphicsConfig_0, model, modelSpaceEntities, paperSpaceEntities, layout, viewports);
    }

    public void AddDrawables(
      DxfModel model,
      IList<DxfEntity> modelSpaceEntities,
      IList<DxfEntity> paperSpaceEntities,
      DxfLayout layout,
      ICollection<DxfViewport> viewports)
    {
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WpfWireframeGraphics3D.Class452(this), this.graphicsConfig_0, model, modelSpaceEntities, paperSpaceEntities, layout, viewports);
    }

    public IWireframeGraphicsFactory2 CreateGraphicsFactory()
    {
      return (IWireframeGraphicsFactory2) new WpfWireframeGraphics3D.Class452(this);
    }

    public void Draw(ICollection<FrameworkElement> result)
    {
      foreach (Interface37 nterface37 in this.linkedList_0)
        nterface37.Draw(result);
    }

    public void Draw(UIElementCollection result)
    {
      foreach (Interface37 nterface37 in this.linkedList_0)
        nterface37.Draw(result);
    }

    private void RemoveDrawables(
      WpfWireframeGraphics3D.Class451 entityDrawablesInfo,
      bool eraseOnly)
    {
      if (entityDrawablesInfo.Children != null)
      {
        foreach (WpfWireframeGraphics3D.Class451 child in entityDrawablesInfo.Children)
          this.method_0(child);
      }
      entityDrawablesInfo.EraseDrawables();
      if (eraseOnly)
        return;
      this.method_1(entityDrawablesInfo);
    }

    private void method_0(
      WpfWireframeGraphics3D.Class451 entityDrawablesInfo)
    {
      if (entityDrawablesInfo == null)
        return;
      this.method_1(entityDrawablesInfo);
      if (entityDrawablesInfo.Children == null)
        return;
      foreach (WpfWireframeGraphics3D.Class451 child in entityDrawablesInfo.Children)
        this.method_0(child);
    }

    private void method_1(
      WpfWireframeGraphics3D.Class451 entityDrawablesInfo)
    {
      List<WpfWireframeGraphics3D.Class451> class451List;
      if (!this.dictionary_0.TryGetValue(entityDrawablesInfo.Entity, out class451List))
        return;
      class451List.Remove(entityDrawablesInfo);
      if (class451List.Count != 0)
        return;
      this.dictionary_0.Remove(entityDrawablesInfo.Entity);
    }

    private class Class451
    {
      private readonly DxfEntity dxfEntity_0;
      private DrawContext.Wireframe wireframe_0;
      private LinkedListNode<Interface37> linkedListNode_0;
      private Class620 class620_0;
      private WpfWireframeGraphics3D.Class451 class451_0;
      private List<WpfWireframeGraphics3D.Class451> list_0;

      public Class451(DxfEntity entity, DrawContext.Wireframe drawContext)
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

      public LinkedListNode<Interface37> EntityDrawableNode
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

      public Class620 EntityDrawable
      {
        get
        {
          return this.class620_0;
        }
        set
        {
          this.class620_0 = value;
        }
      }

      public WpfWireframeGraphics3D.Class451 Parent
      {
        get
        {
          return this.class451_0;
        }
        set
        {
          this.class451_0 = value;
        }
      }

      public List<WpfWireframeGraphics3D.Class451> Children
      {
        get
        {
          return this.list_0;
        }
      }

      public void method_0(WpfWireframeGraphics3D.Class451 child)
      {
        if (this.list_0 == null)
          this.list_0 = new List<WpfWireframeGraphics3D.Class451>();
        this.list_0.Add(child);
        child.class451_0 = this;
      }

      public void EraseDrawables()
      {
        if (this.class620_0 != null)
          this.class620_0.method_0();
        if (this.list_0 == null)
          return;
        this.list_0.Clear();
      }

      public bool Matches(RenderedEntityInfo renderedEntityInfo)
      {
        if (renderedEntityInfo.Entity != this.dxfEntity_0)
          return false;
        if (this.class451_0 == null && renderedEntityInfo.Parent == null)
          return true;
        if (this.class451_0 != null && renderedEntityInfo.Parent != null)
          return this.class451_0.Matches(renderedEntityInfo.Parent);
        return false;
      }
    }

    private class Class452 : IWireframeGraphicsFactory2
    {
      private readonly Interface11 interface11_1 = (Interface11) new Class622();
      private WpfWireframeGraphics3D wpfWireframeGraphics3D_0;
      private readonly Interface11 interface11_0;
      private WpfWireframeGraphics3D.Class452.Class453 class453_0;
      private readonly GraphicsConfig graphicsConfig_0;
      private LinkedListNodeRef<Interface37> linkedListNodeRef_0;
      private Matrix4D matrix4D_0;
      private readonly double double_0;
      private readonly double double_1;
      private readonly CadGraphicsHelper.ObjectTaggerDelegate objectTaggerDelegate_0;
      private readonly bool bool_0;
      private readonly Dictionary<DxfEntity, List<WpfWireframeGraphics3D.Class451>> dictionary_0;
      private WpfWireframeGraphics3D.Class451 class451_0;
      private WpfWireframeGraphics3D.Class451 class451_1;
      private readonly Stack<WpfWireframeGraphics3D.Class451> stack_0;

      public Class452(WpfWireframeGraphics3D graphics)
      {
        this.wpfWireframeGraphics3D_0 = graphics;
        this.interface11_0 = Class622.Create(graphics.Config);
        this.graphicsConfig_0 = graphics.graphicsConfig_0;
        this.linkedListNodeRef_0 = new LinkedListNodeRef<Interface37>(graphics.linkedList_0);
        this.matrix4D_0 = graphics.matrix4D_0;
        this.double_0 = graphics.double_0;
        this.double_1 = graphics.double_1;
        this.objectTaggerDelegate_0 = graphics.FrameworkElementTagger;
        this.bool_0 = graphics.bool_0;
        this.dictionary_0 = graphics.dictionary_0;
        if (!graphics.bool_0)
          return;
        this.stack_0 = new Stack<WpfWireframeGraphics3D.Class451>();
      }

      public LinkedListNodeRef<Interface37> CurrentColoredDrawableNode
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

      public WpfWireframeGraphics3D.Class451 CurrentEntityDrawablesInfo
      {
        get
        {
          return this.class451_0;
        }
        set
        {
          this.class451_0 = value;
        }
      }

      public WpfWireframeGraphics3D.Class451 ExistingEntityDrawablesInfo
      {
        get
        {
          return this.class451_1;
        }
        set
        {
          this.class451_1 = value;
        }
      }

      public void BeginEntity(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
        if (!this.bool_0)
          return;
        WpfWireframeGraphics3D.Class451 class4510 = this.class451_0;
        if (this.class451_1 != null && this.class451_1.Entity == entity)
        {
          this.class451_0 = this.class451_1;
        }
        else
        {
          this.class451_0 = new WpfWireframeGraphics3D.Class451(entity, drawContext);
          this.class451_0.EntityDrawable = new Class620();
          class4510?.method_0(this.class451_0);
          this.class451_0.EntityDrawableNode = this.linkedListNodeRef_0.Insert((Interface37) this.class451_0.EntityDrawable);
        }
        this.linkedListNodeRef_0.Initialize(this.class451_0.EntityDrawable.Drawables);
        this.stack_0.Push(this.class451_0);
      }

      public void EndEntity()
      {
        if (!this.bool_0)
          return;
        List<WpfWireframeGraphics3D.Class451> class451List;
        if (!this.dictionary_0.TryGetValue(this.class451_0.Entity, out class451List))
        {
          class451List = new List<WpfWireframeGraphics3D.Class451>();
          this.dictionary_0.Add(this.class451_0.Entity, class451List);
        }
        if (this.class451_0 != this.class451_1)
          class451List.Add(this.class451_0);
        this.class451_0.EntityDrawable.Drawables = this.linkedListNodeRef_0.LinkedList;
        this.linkedListNodeRef_0.Initialize(this.class451_0.EntityDrawableNode.List, this.class451_0.EntityDrawableNode);
        this.stack_0.Pop();
        if (this.stack_0.Count > 0)
          this.class451_0 = this.stack_0.Peek();
        else
          this.class451_0 = (WpfWireframeGraphics3D.Class451) null;
      }

      public void BeginInsert(DxfInsert insert)
      {
      }

      public void EndInsert()
      {
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
        if (this.class453_0 != null)
          throw new InvalidOperationException("BeginGeometry calls may not be nested.");
        this.class453_0 = new WpfWireframeGraphics3D.Class452.Class453(this.objectTaggerDelegate_0(entity, (DrawContext) drawContext));
        Brush brush = (correctForBackgroundColor ? this.interface11_0 : this.interface11_1).imethod_0(color);
        this.class453_0.Path.Fill = brush;
        if (fill)
          this.class453_0.Fill = true;
        if (stroke)
        {
          this.class453_0.Stroke = true;
          this.class453_0.Path.Stroke = brush;
          this.class453_0.Path.StrokeThickness = this.method_0(entity, (DrawContext) drawContext, forText);
          this.class453_0.Path.StrokeMiterLimit = 2.0;
          if (this.wpfWireframeGraphics3D_0.pathStrokePreparerDelegate_0 != null)
            this.wpfWireframeGraphics3D_0.pathStrokePreparerDelegate_0(this.class453_0.Path, entity, (DrawContext) drawContext, forText);
        }
        this.linkedListNodeRef_0.Insert((Interface37) new Class747((FrameworkElement) this.class453_0.Path));
      }

      public void EndGeometry()
      {
        if (this.class453_0 == null)
          throw new InvalidOperationException("There is no current geometry.");
        this.class453_0.method_0();
        this.class453_0 = (WpfWireframeGraphics3D.Class452.Class453) null;
      }

      public void CreateDot(DxfEntity entity, Vector4D position)
      {
        double num = 0.5 * this.class453_0.Path.StrokeThickness;
        WW.Math.Point2D point2D = this.matrix4D_0.TransformToPoint2D(position);
        System.Windows.Point point1 = new System.Windows.Point(point2D.X - num, point2D.Y);
        System.Windows.Point point2 = new System.Windows.Point(point2D.X + num, point2D.Y);
        Size size = new Size(num, num);
        this.class453_0.method_1(point1, true, true);
        this.class453_0.method_2(point2, size, 180.0);
        this.class453_0.method_2(point1, size, 180.0);
      }

      public void CreateLine(DxfEntity entity, Vector4D start, Vector4D end)
      {
        System.Windows.Point windowsPoint1 = this.matrix4D_0.TransformToWindowsPoint(start);
        System.Windows.Point windowsPoint2 = this.matrix4D_0.TransformToWindowsPoint(end);
        this.class453_0.method_1(windowsPoint1, false, false);
        this.class453_0.method_3(windowsPoint2, true);
      }

      public void CreateRay(DxfEntity entity, Segment4D segment)
      {
        System.Windows.Point windowsPoint1 = this.matrix4D_0.TransformToWindowsPoint(segment.Start);
        System.Windows.Point windowsPoint2 = this.matrix4D_0.TransformToWindowsPoint(segment.End);
        this.class453_0.method_1(windowsPoint1, false, false);
        this.class453_0.method_3(windowsPoint2, true);
      }

      public void CreateXLine(DxfEntity entity, Vector4D? startPoint, Segment4D segment)
      {
        System.Windows.Point windowsPoint1 = this.matrix4D_0.TransformToWindowsPoint(segment.Start);
        System.Windows.Point windowsPoint2 = this.matrix4D_0.TransformToWindowsPoint(segment.End);
        this.class453_0.method_1(windowsPoint1, false, false);
        this.class453_0.method_3(windowsPoint2, true);
      }

      public void CreatePolyline(DxfEntity entity, Polyline4D polyline)
      {
        if (polyline.Count <= 0)
          return;
        if (polyline.Count == 1)
        {
          this.CreateDot(entity, polyline[0]);
        }
        else
        {
          this.class453_0.method_1(this.matrix4D_0.TransformToWindowsPoint(polyline[0]), this.class453_0.Fill, polyline.Closed);
          for (int index = 1; index < polyline.Count; ++index)
            this.class453_0.method_4(this.matrix4D_0.TransformToWindowsPoint(polyline[index]));
        }
      }

      public void CreateShape(DxfEntity entity, IShape4D shape)
      {
        if (shape.IsEmpty)
          return;
        WW.Math.Point2D[] points = new WW.Math.Point2D[3];
        List<bool> boolList = new List<bool>();
        ISegment2DIterator iterator1 = shape.CreateIterator(this.matrix4D_0);
        while (iterator1.MoveNext())
        {
          switch (iterator1.CurrentType)
          {
            case SegmentType.MoveTo:
              boolList.Add(false);
              continue;
            case SegmentType.Close:
              boolList[boolList.Count - 1] = true;
              continue;
            default:
              continue;
          }
        }
        int num = 0;
        List<System.Windows.Point> pointList = new List<System.Windows.Point>();
        ISegment2DIterator iterator2 = shape.CreateIterator(this.matrix4D_0);
        while (iterator2.MoveNext())
        {
          switch (iterator2.Current(points, 0))
          {
            case SegmentType.MoveTo:
              this.class453_0.method_1((System.Windows.Point) points[0], this.class453_0.Fill, boolList[num++]);
              continue;
            case SegmentType.LineTo:
              this.class453_0.method_4((System.Windows.Point) points[0]);
              continue;
            case SegmentType.QuadTo:
              pointList.Clear();
              pointList.Add((System.Windows.Point) points[0]);
              pointList.Add((System.Windows.Point) points[1]);
              this.class453_0.method_6((IList<System.Windows.Point>) pointList);
              continue;
            case SegmentType.CubicTo:
              pointList.Clear();
              pointList.Add((System.Windows.Point) points[0]);
              pointList.Add((System.Windows.Point) points[1]);
              pointList.Add((System.Windows.Point) points[2]);
              this.class453_0.method_8((IList<System.Windows.Point>) pointList);
              continue;
            default:
              continue;
          }
        }
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
        IBitmap bitmap = rasterImage.ImageDef == null ? (IBitmap) null : rasterImage.ImageDef.Bitmap;
        if (bitmap == null || !bitmap.IsValid)
          return;
        imageCorner1 += DxfRasterImage.PixelOffset;
        imageCorner2 -= DxfRasterImage.PixelOffset;
        double width = (double) bitmap.Width;
        double height = (double) bitmap.Height;
        imageCorner1.X = IntervalD.GetRestrictedValue(imageCorner1.X, 0.0, width - 1.0);
        imageCorner1.Y = IntervalD.GetRestrictedValue(imageCorner1.Y, 0.0, height - 1.0);
        imageCorner2.X = IntervalD.GetRestrictedValue(imageCorner2.X, 0.0, width - 1.0);
        imageCorner2.Y = IntervalD.GetRestrictedValue(imageCorner2.Y, 0.0, height - 1.0);
        bool flag = imageCorner1.X != 0.0 || imageCorner1.Y != 0.0 || imageCorner2.X != width - 1.0 || imageCorner2.Y != height - 1.0;
        IntPtr hbitmap = bitmap.Image.GetHbitmap();
        try
        {
          BitmapSource source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
          if (flag)
            source = (BitmapSource) new CroppedBitmap(source, new Int32Rect((int) imageCorner1.X, (int) imageCorner1.Y, (int) (imageCorner2.X - imageCorner1.X), (int) (imageCorner2.Y - imageCorner1.Y)));
          WW.Math.Point2D point2D1 = this.matrix4D_0.TransformToPoint2D(transformedOrigin);
          WW.Math.Point2D point2D2 = this.matrix4D_0.TransformToPoint2D(transformedXAxis);
          WW.Math.Point2D point2D3 = this.matrix4D_0.TransformToPoint2D(transformedYAxis);
          Vector2D vector2D1 = point2D2 - point2D1;
          Vector2D vector2D2 = point2D3 - point2D1;
          Image image = new Image();
          image.BeginInit();
          image.Source = (ImageSource) source;
          image.RenderTransform = (Transform) new MatrixTransform(new Matrix(1.0, 0.0, 0.0, -1.0, 0.0, source.Height) * new Matrix(vector2D1.X, vector2D1.Y, vector2D2.X, vector2D2.Y, point2D1.X, point2D1.Y));
          image.Stretch = Stretch.None;
          image.Tag = this.objectTaggerDelegate_0((DxfEntity) rasterImage, (DrawContext) drawContext);
          image.EndInit();
          this.linkedListNodeRef_0.Insert((Interface37) new Class747((FrameworkElement) image));
        }
        finally
        {
          Class975.DeleteObject(hbitmap);
        }
      }

      public bool SupportsText
      {
        get
        {
          return false;
        }
      }

      public void CreateText(DxfText text)
      {
        throw new NotImplementedException();
      }

      public void CreateMText(DxfMText text)
      {
        throw new NotImplementedException();
      }

      private double method_0(DxfEntity entity, DrawContext drawContext, bool forText)
      {
        double num1;
        if (this.graphicsConfig_0.DisplayLineWeight)
        {
          short num2 = drawContext.GetLineWeight(entity);
          if (num2 == (short) 0)
            num2 = this.graphicsConfig_0.DefaultLineWeight;
          num1 = this.graphicsConfig_0.DotsPerHundredthMm * (double) num2;
        }
        else
          num1 = !forText ? this.double_1 : this.double_0;
        return num1;
      }

      private class Class453
      {
        private readonly Path path_0 = new Path();
        private readonly StreamGeometry streamGeometry_0 = new StreamGeometry();
        private readonly StreamGeometryContext streamGeometryContext_0;
        private bool bool_0;
        private bool bool_1;

        public Class453(object pathTag)
        {
          this.streamGeometryContext_0 = this.streamGeometry_0.Open();
          this.path_0.Data = (System.Windows.Media.Geometry) this.streamGeometry_0;
          this.path_0.Tag = pathTag;
        }

        public Path Path
        {
          get
          {
            return this.path_0;
          }
        }

        public bool Stroke
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

        public bool Fill
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

        public void method_0()
        {
          this.streamGeometryContext_0.Close();
          this.streamGeometry_0.Freeze();
        }

        public void method_1(System.Windows.Point startPoint, bool isFilled, bool isClosed)
        {
          this.streamGeometryContext_0.BeginFigure(startPoint, isFilled, isClosed);
        }

        public void method_2(System.Windows.Point point, Size size, double rotationAngle)
        {
          this.streamGeometryContext_0.ArcTo(point, size, rotationAngle, false, SweepDirection.Clockwise, false, false);
        }

        public void method_3(System.Windows.Point point, bool isStroked)
        {
          this.streamGeometryContext_0.LineTo(point, isStroked, false);
        }

        public void method_4(System.Windows.Point point)
        {
          this.method_3(point, this.bool_0);
        }

        public void method_5(IList<System.Windows.Point> points, bool isStroked)
        {
          this.streamGeometryContext_0.PolyQuadraticBezierTo(points, isStroked, false);
        }

        public void method_6(IList<System.Windows.Point> points)
        {
          this.method_5(points, this.bool_0);
        }

        public void method_7(IList<System.Windows.Point> points, bool isStroked)
        {
          this.streamGeometryContext_0.PolyBezierTo(points, isStroked, false);
        }

        public void method_8(IList<System.Windows.Point> points)
        {
          this.method_7(points, this.bool_0);
        }
      }
    }

    public delegate void PathStrokePreparerDelegate(
      Path path,
      DxfEntity entity,
      DrawContext context,
      bool forText);
  }
}
