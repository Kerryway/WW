// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Wpf.WpfWireframeGraphics3DUsingDrawingVisual
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
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing.Wpf
{
  public class WpfWireframeGraphics3DUsingDrawingVisual
  {
    private GraphicsConfig graphicsConfig_0 = GraphicsConfig.WhiteBackgroundCorrectForBackColor;
    private Matrix4D matrix4D_0 = Matrix4D.Identity;
    private double double_0 = 1.0;
    private double double_1 = 1.0;
    private CadGraphicsHelper.ObjectTaggerDelegate objectTaggerDelegate_0 = new CadGraphicsHelper.ObjectTaggerDelegate(CadGraphicsHelper.EntityObjectTagger);
    private WpfWireframeGraphics3DUsingDrawingVisual.VisualContainer visualContainer_0;
    private readonly VisualCollection visualCollection_0;

    public WpfWireframeGraphics3DUsingDrawingVisual()
    {
      this.visualContainer_0 = new WpfWireframeGraphics3DUsingDrawingVisual.VisualContainer();
      this.visualCollection_0 = this.visualContainer_0.Visuals;
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

    public WpfWireframeGraphics3DUsingDrawingVisual.VisualContainer Canvas
    {
      get
      {
        return this.visualContainer_0;
      }
    }

    public VisualCollection DrawingVisuals
    {
      get
      {
        return this.visualCollection_0;
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

    public CadGraphicsHelper.ObjectTaggerDelegate DrawingVisualTagger
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

    public void CreateDrawables(DxfModel model)
    {
      this.CreateDrawables(model, Matrix4D.Identity);
    }

    public void CreateDrawables(DxfModel model, Matrix4D modelTransform)
    {
      this.visualCollection_0.Clear();
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WpfWireframeGraphics3DUsingDrawingVisual.Class380(this), this.graphicsConfig_0, model, modelTransform);
    }

    public void CreateDrawables(DxfModel model, IList<DxfEntity> entities, Matrix4D modelTransform)
    {
      this.visualCollection_0.Clear();
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WpfWireframeGraphics3DUsingDrawingVisual.Class380(this), this.graphicsConfig_0, model, entities, modelTransform);
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
      this.visualCollection_0.Clear();
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WpfWireframeGraphics3DUsingDrawingVisual.Class380(this), this.graphicsConfig_0, model, layout, viewports);
    }

    public void CreateDrawables(
      DxfModel model,
      IList<DxfEntity> modelSpaceEntities,
      IList<DxfEntity> paperSpaceEntities,
      DxfLayout layout,
      ICollection<DxfViewport> viewports)
    {
      this.visualCollection_0.Clear();
      WireframeGraphicsFactory2Util.CreateDrawables((IWireframeGraphicsFactory2) new WpfWireframeGraphics3DUsingDrawingVisual.Class380(this), this.graphicsConfig_0, model, modelSpaceEntities, paperSpaceEntities, layout, viewports);
    }

    public IWireframeGraphicsFactory2 CreateGraphicsFactory()
    {
      return (IWireframeGraphicsFactory2) new WpfWireframeGraphics3DUsingDrawingVisual.Class380(this);
    }

    public void Draw(UIElementCollection result)
    {
      result.Add((UIElement) this.visualContainer_0);
    }

    private class Class380 : IWireframeGraphicsFactory2
    {
      private readonly Interface11 interface11_1 = (Interface11) new Class622();
      private readonly Stack<WpfWireframeGraphics3DUsingDrawingVisual.Class380.Class381> stack_0 = new Stack<WpfWireframeGraphics3DUsingDrawingVisual.Class380.Class381>();
      private WpfWireframeGraphics3DUsingDrawingVisual wpfWireframeGraphics3DUsingDrawingVisual_0;
      private readonly Interface11 interface11_0;
      private readonly GraphicsConfig graphicsConfig_0;
      private readonly VisualCollection visualCollection_0;
      private Matrix4D matrix4D_0;
      private readonly double double_0;
      private readonly double double_1;
      private CadGraphicsHelper.ObjectTaggerDelegate objectTaggerDelegate_0;

      public Class380(
        WpfWireframeGraphics3DUsingDrawingVisual wpfWireframeGraphics3D)
      {
        this.wpfWireframeGraphics3DUsingDrawingVisual_0 = wpfWireframeGraphics3D;
        this.interface11_0 = Class622.Create(wpfWireframeGraphics3D.Config);
        this.graphicsConfig_0 = wpfWireframeGraphics3D.graphicsConfig_0;
        this.visualCollection_0 = wpfWireframeGraphics3D.visualCollection_0;
        this.matrix4D_0 = wpfWireframeGraphics3D.matrix4D_0;
        this.double_0 = wpfWireframeGraphics3D.double_0;
        this.double_1 = wpfWireframeGraphics3D.double_1;
        this.objectTaggerDelegate_0 = wpfWireframeGraphics3D.DrawingVisualTagger;
      }

      public void BeginEntity(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
      }

      public void BeginInsert(DxfInsert insert)
      {
      }

      public void EndInsert()
      {
      }

      public void EndEntity()
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
        WpfWireframeGraphics3DUsingDrawingVisual.Class380.Class381 class381 = new WpfWireframeGraphics3DUsingDrawingVisual.Class380.Class381(entity);
        class381.Visual.Tag = this.objectTaggerDelegate_0(entity, (DrawContext) drawContext);
        class381.Fill = fill;
        Interface11 nterface11 = correctForBackgroundColor ? this.interface11_0 : this.interface11_1;
        class381.Brush = nterface11.imethod_0(color);
        class381.PenThickness = this.method_0(entity, (DrawContext) drawContext, forText);
        if (stroke)
          class381.Pen = nterface11.imethod_1(color, class381.PenThickness);
        this.stack_0.Push(class381);
        this.visualCollection_0.Add((Visual) class381.Visual);
      }

      public void EndGeometry()
      {
        this.stack_0.Pop().method_0();
      }

      public void CreateDot(DxfEntity entity, Vector4D position)
      {
        WpfWireframeGraphics3DUsingDrawingVisual.Class380.Class381 class381 = this.stack_0.Peek();
        double num = 0.5 * class381.PenThickness;
        WW.Math.Point2D point2D = this.matrix4D_0.TransformToPoint2D(position);
        System.Windows.Point point1 = new System.Windows.Point(point2D.X - num, point2D.Y);
        System.Windows.Point point2 = new System.Windows.Point(point2D.X + num, point2D.Y);
        Size size = new Size(num, num);
        class381.method_1(point1, true, true);
        class381.method_2(point2, size, 180.0);
        class381.method_2(point1, size, 180.0);
      }

      public void CreateLine(DxfEntity entity, Vector4D start, Vector4D end)
      {
        WpfWireframeGraphics3DUsingDrawingVisual.Class380.Class381 class381 = this.stack_0.Peek();
        System.Windows.Point windowsPoint1 = this.matrix4D_0.TransformToWindowsPoint(start);
        System.Windows.Point windowsPoint2 = this.matrix4D_0.TransformToWindowsPoint(end);
        class381.method_1(windowsPoint1, false, false);
        class381.method_3(windowsPoint2, false);
      }

      public void CreateRay(DxfEntity entity, Segment4D segment)
      {
        WpfWireframeGraphics3DUsingDrawingVisual.Class380.Class381 class381 = this.stack_0.Peek();
        System.Windows.Point windowsPoint1 = this.matrix4D_0.TransformToWindowsPoint(segment.Start);
        System.Windows.Point windowsPoint2 = this.matrix4D_0.TransformToWindowsPoint(segment.End);
        class381.method_1(windowsPoint1, false, false);
        class381.method_3(windowsPoint2, false);
      }

      public void CreateXLine(DxfEntity entity, Vector4D? startPoint, Segment4D segment)
      {
        WpfWireframeGraphics3DUsingDrawingVisual.Class380.Class381 class381 = this.stack_0.Peek();
        System.Windows.Point windowsPoint1 = this.matrix4D_0.TransformToWindowsPoint(segment.Start);
        System.Windows.Point windowsPoint2 = this.matrix4D_0.TransformToWindowsPoint(segment.End);
        class381.method_1(windowsPoint1, false, false);
        class381.method_3(windowsPoint2, false);
      }

      public void CreatePolyline(DxfEntity entity, Polyline4D polyline)
      {
        WpfWireframeGraphics3DUsingDrawingVisual.Class380.Class381 class381 = this.stack_0.Peek();
        if (polyline.Count <= 0)
          return;
        if (polyline.Count == 1)
        {
          this.CreateDot(entity, polyline[0]);
        }
        else
        {
          System.Windows.Point windowsPoint1 = this.matrix4D_0.TransformToWindowsPoint(polyline[0]);
          class381.method_1(windowsPoint1, class381.Fill, polyline.Closed);
          for (int index = 1; index < polyline.Count; ++index)
          {
            System.Windows.Point windowsPoint2 = this.matrix4D_0.TransformToWindowsPoint(polyline[index]);
            class381.method_4(windowsPoint2);
          }
        }
      }

      public void CreateShape(DxfEntity entity, IShape4D shape)
      {
        if (shape.IsEmpty)
          return;
        WW.Math.Point2D[] points = new WW.Math.Point2D[3];
        WpfWireframeGraphics3DUsingDrawingVisual.Class380.Class381 class381 = this.stack_0.Peek();
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
              class381.method_1((System.Windows.Point) points[0], class381.Fill, boolList[num++]);
              continue;
            case SegmentType.LineTo:
              class381.method_4((System.Windows.Point) points[0]);
              continue;
            case SegmentType.QuadTo:
              pointList.Clear();
              pointList.Add((System.Windows.Point) points[0]);
              pointList.Add((System.Windows.Point) points[1]);
              class381.method_6((IList<System.Windows.Point>) pointList);
              continue;
            case SegmentType.CubicTo:
              pointList.Clear();
              pointList.Add((System.Windows.Point) points[0]);
              pointList.Add((System.Windows.Point) points[1]);
              pointList.Add((System.Windows.Point) points[2]);
              class381.method_8((IList<System.Windows.Point>) pointList);
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
        IBitmap bitmap = rasterImage.ImageDef.Bitmap;
        if (!bitmap.IsValid)
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
          TransformedBitmap transformedBitmap = new TransformedBitmap();
          transformedBitmap.BeginInit();
          transformedBitmap.Source = source;
          transformedBitmap.Transform = (Transform) new MatrixTransform(new Matrix(1.0, 0.0, 0.0, 1.0, 0.0, point2D1.Y) * new Matrix(1.0, 0.0, 0.0, -1.0, 0.0, 0.0) * new Matrix(1.0, 0.0, 0.0, 1.0, 0.0, -point2D1.Y) * new Matrix(vector2D1.X, vector2D2.X, vector2D1.Y, vector2D2.Y, 0.0, 0.0));
          transformedBitmap.EndInit();
          Image image = new Image();
          image.BeginInit();
          image.Source = (ImageSource) transformedBitmap;
          image.RenderTransform = (Transform) new TranslateTransform(point2D1.X, point2D1.Y);
          image.Stretch = Stretch.None;
          image.EndInit();
          this.visualCollection_0.Add((Visual) image);
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

      private class Class381
      {
        private readonly DrawingVisualWithTag drawingVisualWithTag_0 = new DrawingVisualWithTag();
        private StreamGeometry streamGeometry_0 = new StreamGeometry();
        private StreamGeometryContext streamGeometryContext_0;
        private bool bool_0;
        private Brush brush_0;
        private Pen pen_0;
        private double double_0;

        public Class381(DxfEntity entity)
        {
          this.streamGeometryContext_0 = this.streamGeometry_0.Open();
        }

        public DrawingVisualWithTag Visual
        {
          get
          {
            return this.drawingVisualWithTag_0;
          }
        }

        public bool Fill
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

        public Brush Brush
        {
          get
          {
            return this.brush_0;
          }
          set
          {
            this.brush_0 = value;
          }
        }

        public Pen Pen
        {
          get
          {
            return this.pen_0;
          }
          set
          {
            this.pen_0 = value;
          }
        }

        public double PenThickness
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

        public void method_0()
        {
          this.streamGeometryContext_0.Close();
          this.streamGeometry_0.Freeze();
          DrawingContext drawingContext = this.drawingVisualWithTag_0.RenderOpen();
          drawingContext.DrawGeometry(this.brush_0, this.pen_0, (System.Windows.Media.Geometry) this.streamGeometry_0);
          drawingContext.Close();
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
          this.method_3(point, this.pen_0 != null);
        }

        public void method_5(IList<System.Windows.Point> points, bool isStroked)
        {
          this.streamGeometryContext_0.PolyQuadraticBezierTo(points, isStroked, false);
        }

        public void method_6(IList<System.Windows.Point> points)
        {
          this.method_5(points, this.pen_0 != null);
        }

        public void method_7(IList<System.Windows.Point> points, bool isStroked)
        {
          this.streamGeometryContext_0.PolyBezierTo(points, isStroked, false);
        }

        public void method_8(IList<System.Windows.Point> points)
        {
          this.method_7(points, this.pen_0 != null);
        }
      }
    }

    public class VisualContainer : FrameworkElement
    {
      private readonly VisualCollection visualCollection_0;

      public VisualContainer()
      {
        this.visualCollection_0 = new VisualCollection((Visual) this);
      }

      public VisualCollection Visuals
      {
        get
        {
          return this.visualCollection_0;
        }
      }

      protected override int VisualChildrenCount
      {
        get
        {
          return this.visualCollection_0.Count;
        }
      }

      protected override Visual GetVisualChild(int index)
      {
        return this.visualCollection_0[index];
      }
    }
  }
}
