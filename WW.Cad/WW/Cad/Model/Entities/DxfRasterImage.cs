// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfRasterImage
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns33;
using System;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.Model.Objects;
using WW.Drawing;
using WW.Math;
using WW.Math.Exact;
using WW.Math.Exact.Geometry;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public abstract class DxfRasterImage : DxfEntity
  {
    public static readonly Vector2D PixelOffset = new Vector2D(0.5, 0.5);
    private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.XAxis;
    private WW.Math.Vector3D vector3D_1 = WW.Math.Vector3D.YAxis;
    private Size2D size2D_0 = Size2D.Zero;
    private DxfObjectReference dxfObjectReference_6 = DxfObjectReference.Null;
    private byte byte_0 = 50;
    private byte byte_1 = 50;
    private readonly List<WW.Math.Point2D> list_0 = new List<WW.Math.Point2D>();
    private WW.Math.Point3D point3D_0;
    private ImageDisplayFlags imageDisplayFlags_0;
    private bool bool_2;
    private byte byte_2;
    private bool bool_3;
    private int int_0;

    protected DxfRasterImage()
    {
    }

    protected DxfRasterImage(DxfImageDef imageDef)
    {
      this.ImageDef = imageDef;
    }

    public WW.Math.Point3D InsertionPoint
    {
      get
      {
        return this.point3D_0;
      }
      set
      {
        this.point3D_0 = value;
      }
    }

    public WW.Math.Vector3D XAxis
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        this.vector3D_0 = value;
      }
    }

    public WW.Math.Vector3D YAxis
    {
      get
      {
        return this.vector3D_1;
      }
      set
      {
        this.vector3D_1 = value;
      }
    }

    public Size2D Size
    {
      get
      {
        return this.size2D_0;
      }
      set
      {
        this.size2D_0 = value;
      }
    }

    public DxfImageDef ImageDef
    {
      get
      {
        return (DxfImageDef) this.dxfObjectReference_6.Value;
      }
      set
      {
        this.SetImageDef(value, true);
      }
    }

    public ImageDisplayFlags ImageDisplayFlags
    {
      get
      {
        return this.imageDisplayFlags_0;
      }
      set
      {
        this.imageDisplayFlags_0 = value;
      }
    }

    public bool ClippingEnabled
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }

    public byte Brightness
    {
      get
      {
        return this.byte_0;
      }
      set
      {
        if (value < (byte) 0 || value > (byte) 100)
          throw new ArgumentException("Value should be in range 0-100.");
        this.byte_0 = value;
      }
    }

    public byte Contrast
    {
      get
      {
        return this.byte_1;
      }
      set
      {
        if (value < (byte) 0 || value > (byte) 100)
          throw new ArgumentException("Value should be in range 0-100.");
        this.byte_1 = value;
      }
    }

    public byte Fade
    {
      get
      {
        return this.byte_2;
      }
      set
      {
        if (value < (byte) 0 || value > (byte) 100)
          throw new ArgumentException("Value should be in range 0-100.");
        this.byte_2 = value;
      }
    }

    public List<WW.Math.Point2D> BoundaryVertices
    {
      get
      {
        return this.list_0;
      }
    }

    public ClipMode ClipMode
    {
      get
      {
        return !this.bool_3 ? ClipMode.Outside : ClipMode.Inside;
      }
      set
      {
        switch (value)
        {
          case ClipMode.Outside:
            this.bool_3 = false;
            break;
          case ClipMode.Inside:
            this.bool_3 = true;
            break;
          default:
            throw new ArgumentException();
        }
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbRasterImage";
      }
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      if (this.list_0.Count <= 0)
        return;
      Polygon2D clipBoundary = this.GetClipBoundary((DrawContext) context);
      if (clipBoundary == null)
        return;
      Matrix4D preTransform = this.method_15();
      IClippingTransformer clippingTransformer = (IClippingTransformer) context.GetTransformer().Clone();
      clippingTransformer.SetPreTransform(preTransform);
      Matrix4D matrix = clippingTransformer.Matrix;
      WW.Math.Point3D point = new WW.Math.Point3D(-0.5, -0.5, 0.0);
      Vector4D transformedOrigin = matrix.TransformTo4D(point);
      Vector4D transformedXAxis = matrix.TransformTo4D(point + WW.Math.Vector3D.XAxis);
      Vector4D transformedYAxis = matrix.TransformTo4D(point + WW.Math.Vector3D.YAxis);
      WW.Math.Geometry.Polyline3D polyline = new WW.Math.Geometry.Polyline3D(true);
      foreach (WW.Math.Point2D point2D in (List<WW.Math.Point2D>) clipBoundary)
        polyline.Add((WW.Math.Point3D) point2D);
      IList<Polyline4D> polyline4DList = clippingTransformer.Transform(polyline, true);
      if (polyline4DList.Count <= 0)
        return;
      Polyline4D imageBoundary = polyline4DList[0];
      graphicsFactory.CreateImage(this, context, this.bool_2 ? imageBoundary : (Polyline4D) null, imageBoundary, transformedOrigin, transformedXAxis, transformedYAxis);
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      if (this.list_0.Count > 0)
      {
        Bounds2D bounds2D = this.method_14((DrawContext) context);
        Matrix4D preTransform = this.method_15();
        IClippingTransformer clippingTransformer = (IClippingTransformer) context.GetTransformer().Clone();
        clippingTransformer.SetPreTransform(preTransform);
        Vector4D? nullable1 = clippingTransformer.Transform(WW.Math.Point3D.Zero);
        Vector4D? nullable2 = clippingTransformer.Transform(WW.Math.Point3D.Zero + WW.Math.Vector3D.XAxis);
        Vector4D? nullable3 = clippingTransformer.Transform(WW.Math.Point3D.Zero + WW.Math.Vector3D.YAxis);
        if (this.ImageDef != null && nullable1.HasValue && (nullable2.HasValue && nullable3.HasValue))
        {
          graphicsFactory.BeginGeometry((DxfEntity) this, context, ArgbColor.Empty, false, false, false, true);
          graphicsFactory.CreateImage(this, bounds2D.Corner1, bounds2D.Corner2, nullable1.Value, nullable2.Value, nullable3.Value, context);
          graphicsFactory.EndGeometry();
        }
      }
      if (this.ImageDef != null && !context.Config.DrawImageFrame)
        return;
      Polygon2D clipBoundary = this.GetClipBoundary((DrawContext) context);
      if (clipBoundary == null)
        return;
      Matrix4D preTransform1 = this.method_15();
      IClippingTransformer clippingTransformer1 = (IClippingTransformer) context.GetTransformer().Clone();
      clippingTransformer1.SetPreTransform(preTransform1);
      WW.Math.Geometry.Polyline3D polyline1 = new WW.Math.Geometry.Polyline3D(true);
      foreach (WW.Math.Point2D point2D in (List<WW.Math.Point2D>) clipBoundary)
        polyline1.Add((WW.Math.Point3D) point2D);
      List<Polyline4D> polyline4DList = new List<Polyline4D>((IEnumerable<Polyline4D>) clippingTransformer1.Transform(polyline1, true));
      if (this.ImageDef == null)
      {
        graphicsFactory.BeginGeometry((DxfEntity) this, context, context.Config.BackColor, false, true, false, false);
        foreach (Polyline4D polyline2 in polyline4DList)
          graphicsFactory.CreatePolyline((DxfEntity) this, polyline2);
        graphicsFactory.EndGeometry();
      }
      if (this.ImageDef != null && !context.Config.DrawImageFrame)
        return;
      graphicsFactory.BeginGeometry((DxfEntity) this, context, this.GetColor((DrawContext) context), false, false, true, true);
      foreach (Polyline4D polyline2 in polyline4DList)
        graphicsFactory.CreatePolyline((DxfEntity) this, polyline2);
      graphicsFactory.EndGeometry();
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      DxfImageDef imageDef = this.ImageDef;
      if (imageDef == null || !imageDef.Bitmap.IsValid)
        return;
      List<WW.Math.Point2D> clipBoundary = (List<WW.Math.Point2D>) this.GetClipBoundary((DrawContext) context);
      if (clipBoundary == null || clipBoundary.Count <= 0)
        return;
      List<Triangulator2D.Triangle> triangleList = new List<Triangulator2D.Triangle>();
      List<WW.Math.Point2D> point2DList = new List<WW.Math.Point2D>();
      Triangulator2D.Triangulate((IList<IList<WW.Math.Point2D>>) new List<WW.Math.Point2D>[1]
      {
        clipBoundary
      }, (IList<Triangulator2D.Triangle>) triangleList, (IList<WW.Math.Point2D>) point2DList);
      Interface41 nterface41 = (Interface41) context.GetTransformer().Clone();
      Matrix4D preTransform = this.method_15();
      nterface41.SetPreTransform(preTransform);
      WW.Math.Point2D[] point2DArray = new WW.Math.Point2D[point2DList.Count];
      Vector4D[] vector4DArray = new Vector4D[point2DList.Count];
      Size2D referencedImageSize = this.ReferencedImageSize;
      double num1 = 1.0 / referencedImageSize.X;
      double num2 = 1.0 / referencedImageSize.Y;
      Vector2D vector2D = new Vector2D(0.5, 0.5);
      for (int index = point2DList.Count - 1; index >= 0; --index)
      {
        WW.Math.Point2D point2D = point2DList[index] + vector2D;
        point2DArray[index] = new WW.Math.Point2D(num1 * point2D.X, 1.0 - num2 * point2D.Y);
        vector4DArray[index] = nterface41.Transform(new WW.Math.Point3D(point2D.X, point2D.Y, 0.0));
      }
      byte[] rgbaBytes = imageDef.Bitmap.GetRgbaBytes();
      graphicsFactory.CreateTexturedTriangles(rgbaBytes, imageDef.Bitmap.Width, imageDef.Bitmap.Height, preTransform.Transform(WW.Math.Vector3D.ZAxis), (IList<Triangulator2D.Triangle>) triangleList, (IList<WW.Math.Point2D>) point2DArray, (IList<Vector4D>) vector4DArray);
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      DxfImageDef imageDef = this.ImageDef;
      if (imageDef == null || !imageDef.Bitmap.IsValid)
        return;
      List<WW.Math.Point2D> clipBoundary = (List<WW.Math.Point2D>) this.GetClipBoundary((DrawContext) context);
      if (clipBoundary == null || clipBoundary.Count <= 0 || !graphics.AddExistingGraphicElement1(parentGraphicElementBlock, (DxfEntity) this, ArgbColor.Empty))
        return;
      List<Triangulator2D.Triangle> triangleList = new List<Triangulator2D.Triangle>();
      List<WW.Math.Point2D> point2DList = new List<WW.Math.Point2D>();
      Triangulator2D.Triangulate((IList<IList<WW.Math.Point2D>>) new List<WW.Math.Point2D>[1]
      {
        clipBoundary
      }, (IList<Triangulator2D.Triangle>) triangleList, (IList<WW.Math.Point2D>) point2DList);
      Matrix4D matrix4D = this.method_15();
      WW.Math.Point2D[] point2DArray = new WW.Math.Point2D[point2DList.Count];
      WW.Math.Point3D[] point3DArray = new WW.Math.Point3D[point2DList.Count];
      Size2D referencedImageSize = this.ReferencedImageSize;
      double num1 = 1.0 / referencedImageSize.X;
      double num2 = 1.0 / referencedImageSize.Y;
      Vector2D vector2D = new Vector2D(0.5, 0.5);
      for (int index = point2DList.Count - 1; index >= 0; --index)
      {
        WW.Math.Point2D point = point2DList[index] + vector2D;
        point2DArray[index] = new WW.Math.Point2D(num1 * point.X, 1.0 - num2 * point.Y);
        point3DArray[index] = matrix4D.TransformTo3D(point);
      }
      GraphicElement1 graphicElement = new GraphicElement1(ArgbColor.Empty);
      graphics.AddNewGraphicElement((DxfEntity) this, parentGraphicElementBlock, graphicElement);
      TexturedTriangleList texturedTriangleList = new TexturedTriangleList();
      graphicElement.Geometry.Add((IPrimitive) texturedTriangleList);
      texturedTriangleList.RgbaBytes = imageDef.Bitmap.GetRgbaBytes();
      texturedTriangleList.Width = imageDef.Bitmap.Width;
      texturedTriangleList.Height = imageDef.Bitmap.Height;
      texturedTriangleList.Normal = matrix4D.Transform(WW.Math.Vector3D.ZAxis);
      texturedTriangleList.Triangles = (IList<Triangulator2D.Triangle>) triangleList;
      texturedTriangleList.TextureCoordinates = (IList<WW.Math.Point2D>) point2DArray;
      texturedTriangleList.Points = (IList<WW.Math.Point3D>) point3DArray;
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      bool flag = base.Validate(model, messages);
      if (this.list_0.Count < 2)
      {
        messages.Add(new DxfMessage(DxfStatus.ImageNotEnoughBoundaryVertices, Severity.Error, "target", (object) this));
        flag = false;
      }
      return flag;
    }

    public void SetImageDef(DxfImageDef imageDef, bool updateAxes)
    {
      this.dxfObjectReference_6 = DxfObjectReference.GetReference((IDxfHandledObject) imageDef);
      if (!updateAxes || imageDef == null)
        return;
      this.vector3D_0 = new WW.Math.Vector3D(imageDef.DefaultPixelSize.X, 0.0, 0.0);
      this.vector3D_1 = new WW.Math.Vector3D(0.0, imageDef.DefaultPixelSize.Y, 0.0);
      this.size2D_0 = imageDef.Size;
    }

    public override void TransformMe(TransformConfig config, Matrix4D matrix)
    {
      this.TransformMe(config, matrix, (CommandGroup) null);
    }

    public override void TransformMe(
      TransformConfig config,
      Matrix4D matrix,
      CommandGroup undoGroup)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfRasterImage.Class738 class738 = new DxfRasterImage.Class738();
      // ISSUE: reference to a compiler-generated field
      class738.dxfRasterImage_0 = this;
      // ISSUE: reference to a compiler-generated field
      class738.point3D_0 = this.point3D_0;
      // ISSUE: reference to a compiler-generated field
      class738.vector3D_0 = this.vector3D_0;
      // ISSUE: reference to a compiler-generated field
      class738.vector3D_1 = this.vector3D_1;
      // ISSUE: reference to a compiler-generated field
      class738.point3D_1 = matrix.Transform(this.point3D_0);
      // ISSUE: reference to a compiler-generated field
      class738.vector3D_2 = matrix.Transform(this.vector3D_0);
      // ISSUE: reference to a compiler-generated field
      class738.vector3D_3 = matrix.Transform(this.vector3D_1);
      // ISSUE: reference to a compiler-generated field
      this.point3D_0 = class738.point3D_1;
      // ISSUE: reference to a compiler-generated field
      this.vector3D_0 = class738.vector3D_2;
      // ISSUE: reference to a compiler-generated field
      this.vector3D_1 = class738.vector3D_3;
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup?.UndoStack.Push((ICommand) new Command((object) this, new System.Action(class738.method_0), new System.Action(class738.method_1)));
    }

    public void SetDefaultBoundaryVertices()
    {
      this.list_0.Clear();
      this.method_13((IList<WW.Math.Point2D>) this.list_0);
    }

    private void method_13(IList<WW.Math.Point2D> boundary)
    {
      boundary.Add(new WW.Math.Point2D(-0.5, -0.5));
      double num1 = this.size2D_0.X;
      if (num1 == 0.0)
        num1 = (double) this.ImageDef.Bitmap.Width;
      double num2 = this.size2D_0.Y;
      if (num2 == 0.0)
        num2 = (double) this.ImageDef.Bitmap.Height;
      boundary.Add(new WW.Math.Point2D(num1 - 0.5, num2 - 0.5));
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfRasterImage dxfRasterImage = (DxfRasterImage) from;
      this.InsertionPoint = dxfRasterImage.InsertionPoint;
      this.XAxis = dxfRasterImage.XAxis;
      this.YAxis = dxfRasterImage.YAxis;
      this.Size = dxfRasterImage.Size;
      if (dxfRasterImage.ImageDef == null)
        this.SetImageDef((DxfImageDef) null, false);
      else if (cloneContext.SourceModel == cloneContext.TargetModel)
        this.SetImageDef(dxfRasterImage.ImageDef, false);
      else
        this.SetImageDef((DxfImageDef) dxfRasterImage.ImageDef.Clone(cloneContext), false);
      this.ImageDisplayFlags = dxfRasterImage.ImageDisplayFlags;
      this.ClippingEnabled = dxfRasterImage.ClippingEnabled;
      this.Brightness = dxfRasterImage.Brightness;
      this.Contrast = dxfRasterImage.Contrast;
      this.Fade = dxfRasterImage.Fade;
      this.BoundaryVertices.Clear();
      this.BoundaryVertices.AddRange((IEnumerable<WW.Math.Point2D>) dxfRasterImage.BoundaryVertices);
      this.bool_3 = dxfRasterImage.bool_3;
    }

    internal int ClassVersion
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

    internal Size2D ReferencedImageSize
    {
      get
      {
        DxfImageDef imageDef = this.ImageDef;
        if (imageDef != null)
        {
          IBitmap bitmap = imageDef.Bitmap;
          if (bitmap.IsValid)
            return new Size2D((double) bitmap.Width, (double) bitmap.Height);
        }
        return new Size2D(1.0, 1.0);
      }
    }

    internal Polygon2D GetClipBoundary(DrawContext context)
    {
      object obj;
      DxfRasterImage.Class737 class737;
      if (context.EntityToRenderCache.TryGetValue((DxfEntity) this, out obj))
      {
        class737 = (DxfRasterImage.Class737) obj;
      }
      else
      {
        class737 = new DxfRasterImage.Class737()
        {
          ClipBoundary = this.ClipBoundary
        };
        context.EntityToRenderCache.Add((DxfEntity) this, (object) class737);
      }
      return class737.ClipBoundary;
    }

    internal Polygon2D ClipBoundary
    {
      get
      {
        Size2D referencedImageSize = this.ReferencedImageSize;
        List<WW.Math.Point2D> boundaryVertices = this.BoundaryVertices;
        Polygon2D polygon2D1 = new Polygon2D(boundaryVertices.Count == 2 ? 4 : boundaryVertices.Count);
        double num = referencedImageSize.Y - 1.0;
        bool flag = false;
        if (boundaryVertices.Count == 2)
        {
          if (boundaryVertices[0] == boundaryVertices[1])
          {
            boundaryVertices.Clear();
            this.method_13((IList<WW.Math.Point2D>) boundaryVertices);
            if (boundaryVertices[0] == boundaryVertices[1])
              return (Polygon2D) null;
          }
          polygon2D1.Add(new WW.Math.Point2D(boundaryVertices[0].X, num - boundaryVertices[0].Y));
          polygon2D1.Add(new WW.Math.Point2D(boundaryVertices[0].X, num - boundaryVertices[1].Y));
          polygon2D1.Add(new WW.Math.Point2D(boundaryVertices[1].X, num - boundaryVertices[1].Y));
          polygon2D1.Add(new WW.Math.Point2D(boundaryVertices[1].X, num - boundaryVertices[0].Y));
        }
        else
        {
          foreach (WW.Math.Point2D point2D in boundaryVertices)
            polygon2D1.Add(new WW.Math.Point2D(point2D.X, num - point2D.Y));
          while (polygon2D1.Count > 1 && WW.Math.Point2D.AreApproxEqual(polygon2D1[0], polygon2D1[polygon2D1.Count - 1], 8.88178419700125E-16))
            polygon2D1.RemoveAt(polygon2D1.Count - 1);
          flag = polygon2D1.Count > 3;
        }
        if (polygon2D1.IsClockwise())
          polygon2D1.Reverse();
        if (this.ImageDef == null)
          return polygon2D1;
        Bounds2D bounds = new Bounds2D();
        Polygon2D polygon2D2 = new Polygon2D(4);
        polygon2D2.Add(new WW.Math.Point2D(-0.5, -0.5));
        polygon2D2.Add(new WW.Math.Point2D(referencedImageSize.X - 0.5, -0.5));
        polygon2D2.Add(new WW.Math.Point2D(referencedImageSize.X - 0.5, referencedImageSize.Y - 0.5));
        polygon2D2.Add(new WW.Math.Point2D(-0.5, referencedImageSize.Y - 0.5));
        Polygon2D polygon2D3 = polygon2D2;
        bounds.Update((IList<WW.Math.Point2D>) polygon2D3);
        bounds.Update((IList<WW.Math.Point2D>) polygon2D1);
        Matrix4D scaleTransform;
        Matrix4D inverseScaleTransform;
        Polygon2I.BooleanOperations20Bits.GetScaleToIntegralTransforms(bounds, out scaleTransform, out inverseScaleTransform);
        Polygon2I polygon2I1 = new Polygon2I(scaleTransform, (ICollection<WW.Math.Point2D>) polygon2D3);
        Polygon2I polygon2I2 = new Polygon2I(scaleTransform, (ICollection<WW.Math.Point2D>) polygon2D1);
        Polygon2I.BooleanOperations20Bits.Context context = new Polygon2I.BooleanOperations20Bits.Context();
        Polygon2I.BooleanOperations20Bits.Region region1 = Polygon2I.BooleanOperations20Bits.GetRegion((IList<Polygon2I>) new Polygon2I[1]{ polygon2I2 }, context);
        if (flag)
        {
          Polygon2I.BooleanOperations20Bits.Region region2 = region1.Subdivide(context);
          List<Triangulator2I.Triangle> triangleList = new List<Triangulator2I.Triangle>();
          List<Point2I> points = new List<Point2I>();
          Triangulator2I.Triangulate((IList<IList<Point2I>>) region2.ToPoint2IListList(), (IList<Triangulator2I.Triangle>) triangleList, (IList<Point2I>) points);
          region1 = Polygon2I.BooleanOperations20Bits.GetRegion((IList<Polygon2I>) Triangulator2I.GetPolygons((ICollection<Triangulator2I.Triangle>) triangleList, points), context);
        }
        Polygon2I.BooleanOperations20Bits.Region intersection = Polygon2I.BooleanOperations20Bits.GetIntersection(context, Polygon2I.BooleanOperations20Bits.GetRegion((IList<Polygon2I>) new Polygon2I[1]{ polygon2I1 }, context), region1);
        if (intersection.Count <= 0)
          return new Polygon2D();
        return intersection[0].ToPolygon2D(inverseScaleTransform);
      }
    }

    internal Bounds2D method_14(DrawContext context)
    {
      Bounds2D bounds2D = new Bounds2D();
      bounds2D.Update((IList<WW.Math.Point2D>) this.GetClipBoundary(context));
      return bounds2D;
    }

    internal Matrix4D method_15()
    {
      WW.Math.Vector3D unit = WW.Math.Vector3D.CrossProduct(this.vector3D_0, this.vector3D_1).GetUnit();
      return Transformation4D.Translation((WW.Math.Vector3D) this.point3D_0) * new Matrix4D(this.vector3D_0.X, this.vector3D_1.X, unit.X, 0.0, this.vector3D_0.Y, this.vector3D_1.Y, unit.Y, 0.0, this.vector3D_0.Z, this.vector3D_1.Z, unit.Z, 0.0, 0.0, 0.0, 0.0, 1.0) * Transformation4D.Translation(0.5, 0.5, 0.0);
    }

    internal class Class737
    {
      public Polygon2D ClipBoundary { get; set; }
    }
  }
}
