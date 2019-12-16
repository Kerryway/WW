// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfOle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns28;
using ns33;
using System;
using System.Collections.Generic;
using System.Drawing;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Model.Objects;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model.Entities
{
  public class DxfOle : DxfEntity, IBitmapProvider
  {
    private int int_0 = 2;
    private byte byte_0 = 128;
    private byte byte_1 = 85;
    private int int_2 = 256;
    private DxfOle.Aspect aspect_0 = DxfOle.Aspect.Content;
    private DxfOle.Aspect aspect_1 = DxfOle.Aspect.Icon;
    private DxfOle.QualityType qualityType_0;
    private int int_1;
    private WW.Math.Point3D point3D_0;
    private WW.Math.Point3D point3D_1;
    private WW.Math.Point3D point3D_2;
    private WW.Math.Point3D point3D_3;
    private short short_1;
    private short short_2;
    private byte[] byte_2;
    private int int_3;
    private bool bool_2;
    private string string_0;
    private string string_1;
    private DxfOle.Type type_0;
    private DxfOle.Type type_1;
    private string string_2;
    private DxfOleXData dxfOleXData_0;

    public DxfOle()
    {
      this.dxfOleXData_0 = new DxfOleXData(this);
    }

    private void method_13()
    {
      int width;
      int height;
      OleHelper.OleHiMetrics(this, out width, out height);
      this.short_1 = (short) width;
      this.short_2 = (short) height;
    }

    private void GetPolylines4D(
      DrawContext context,
      IClippingTransformer transformer,
      out IList<Polyline4D> polylines4D,
      out IList<IShape4D> shapes)
    {
      IList<Polyline3D> polylines;
      IList<FlatShape4D> flatShapes;
      this.GetPolylines(context, transformer.LineTypeScaler, out polylines, out flatShapes);
      polylines4D = DxfUtil.smethod_36(polylines, false, transformer);
      shapes = DxfUtil.smethod_37((ICollection<FlatShape4D>) flatShapes, transformer);
    }

    private void GetPolylines(
      DrawContext context,
      ILineTypeScaler lineTypeScaler,
      out IList<Polyline3D> polylines,
      out IList<FlatShape4D> flatShapes)
    {
      Polyline3D polyline = this.method_14();
      polylines = (IList<Polyline3D>) new List<Polyline3D>();
      if (polyline != null)
      {
        DxfHeader header = context.Model.Header;
        GraphicsConfig config = context.Config;
        WW.Math.Vector3D upward = WW.Math.Vector3D.CrossProduct(this.point3D_0 - this.point3D_3, this.point3D_2 - this.point3D_3);
        upward.Normalize();
        if (config.ApplyLineType)
        {
          flatShapes = (IList<FlatShape4D>) new List<FlatShape4D>();
          DxfUtil.smethod_3(context.Config, polylines, flatShapes, polyline, this.GetLineType(context), upward, context.TotalLineTypeScale * this.LineTypeScale, lineTypeScaler, true);
        }
        else
        {
          polylines.Add(polyline);
          flatShapes = (IList<FlatShape4D>) null;
        }
      }
      else
        flatShapes = (IList<FlatShape4D>) null;
    }

    private Polyline3D method_14()
    {
      Polyline3D polyline3D = new Polyline3D(true);
      polyline3D.Add(this.point3D_3);
      polyline3D.Add(this.point3D_0);
      polyline3D.Add(this.point3D_1);
      polyline3D.Add(this.point3D_2);
      return polyline3D;
    }

    public int OleDataVersion
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

    public int OleItemVersion
    {
      get
      {
        return this.int_2;
      }
      set
      {
        this.int_2 = value;
      }
    }

    public int ItemId
    {
      get
      {
        return this.int_3;
      }
      set
      {
        this.int_3 = value;
        if (this.Model == null)
          return;
        this.Model.UpdateOleItemCounter((uint) this.int_3);
      }
    }

    public DxfOle.Aspect AdviseType
    {
      get
      {
        return this.aspect_0;
      }
      set
      {
        this.aspect_0 = value;
      }
    }

    public DxfOle.Aspect DrawAspect
    {
      get
      {
        return this.aspect_1;
      }
      set
      {
        this.aspect_1 = value;
      }
    }

    public string UserType
    {
      get
      {
        if (this.string_1 == null)
          return this.string_0;
        return this.string_1;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public bool Moniker
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

    public byte[] OleData
    {
      get
      {
        return this.byte_2;
      }
      set
      {
        this.byte_2 = value;
        this.type_1 = OleHelper.OleItemType(this);
        this.string_1 = OleHelper.OleUserType(this);
        this.string_2 = OleHelper.OleLinkPath(this);
        OleHelper.FinishCreate(this);
        if (this.int_3 != 0 || this.Model == null)
          return;
        this.int_3 = (int) this.Model.UniqueOleItemCounter();
      }
    }

    public short HimetricWidth
    {
      get
      {
        return this.short_1;
      }
      set
      {
        this.short_1 = value;
      }
    }

    public short HimetricHeight
    {
      get
      {
        return this.short_2;
      }
      set
      {
        this.short_2 = value;
      }
    }

    public WW.Math.Point3D UpperLeft
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

    public WW.Math.Point3D UpperRight
    {
      get
      {
        return this.point3D_1;
      }
      set
      {
        this.point3D_1 = value;
      }
    }

    public WW.Math.Point3D LowerRight
    {
      get
      {
        return this.point3D_2;
      }
      set
      {
        this.point3D_2 = value;
      }
    }

    public WW.Math.Point3D LowerLeft
    {
      get
      {
        return this.point3D_3;
      }
      set
      {
        this.point3D_3 = value;
      }
    }

    public int UnknownLong
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

    public DxfOle.Type OleObjectType
    {
      get
      {
        if (this.type_1 == DxfOle.Type.Unknown)
          return this.type_0;
        return this.type_1;
      }
      set
      {
        this.type_0 = value;
      }
    }

    public string LinkPath
    {
      get
      {
        if (this.OleObjectType != DxfOle.Type.Link)
          throw new Exception("Ole item type must be Link.");
        return this.string_2;
      }
    }

    public byte UnknownByte1
    {
      get
      {
        return this.byte_0;
      }
      set
      {
        this.byte_0 = value;
      }
    }

    public byte UnknownByte2
    {
      get
      {
        return this.byte_1;
      }
      set
      {
        this.byte_1 = value;
      }
    }

    public DxfOle.QualityType Quality
    {
      get
      {
        return this.qualityType_0;
      }
      set
      {
        this.qualityType_0 = value;
      }
    }

    public DxfOleXData OleXData
    {
      get
      {
        return this.dxfOleXData_0;
      }
      set
      {
        this.dxfOleXData_0 = value;
      }
    }

    public Bitmap Preview(int width, int heigth)
    {
      return OleHelper.Preview(this, width, heigth);
    }

    public override string EntityType
    {
      get
      {
        return "OLE2FRAME";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbOle2Frame";
      }
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
      DxfOle.Class1066 class1066 = new DxfOle.Class1066();
      // ISSUE: reference to a compiler-generated field
      class1066.dxfOle_0 = this;
      // ISSUE: reference to a compiler-generated field
      class1066.point3D_0 = this.point3D_0;
      // ISSUE: reference to a compiler-generated field
      class1066.point3D_1 = this.point3D_1;
      // ISSUE: reference to a compiler-generated field
      class1066.point3D_2 = this.point3D_2;
      // ISSUE: reference to a compiler-generated field
      class1066.point3D_3 = this.point3D_3;
      this.point3D_0 = matrix.Transform(this.point3D_0);
      this.point3D_1 = matrix.Transform(this.point3D_1);
      this.point3D_2 = matrix.Transform(this.point3D_2);
      this.point3D_3 = matrix.Transform(this.point3D_3);
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfOle.Class1067()
      {
        class1066_0 = class1066,
        point3D_0 = this.point3D_0,
        point3D_1 = this.point3D_1,
        point3D_2 = this.point3D_2,
        point3D_3 = this.point3D_3
      }.method_0), new System.Action(class1066.method_0)));
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfOle dxfOle = (DxfOle) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfOle == null)
      {
        dxfOle = new DxfOle();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfOle);
        dxfOle.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfOle;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override short vmethod_6(Class432 w)
    {
      return 74;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfOle dxfOle = (DxfOle) from;
      this.qualityType_0 = dxfOle.Quality;
      this.int_0 = dxfOle.OleDataVersion;
      this.int_1 = dxfOle.UnknownLong;
      this.byte_0 = dxfOle.UnknownByte1;
      this.byte_1 = dxfOle.UnknownByte2;
      this.point3D_0 = dxfOle.UpperLeft;
      this.point3D_1 = dxfOle.UpperRight;
      this.point3D_2 = dxfOle.LowerRight;
      this.point3D_3 = dxfOle.LowerLeft;
      this.short_1 = dxfOle.HimetricWidth;
      this.short_2 = dxfOle.HimetricHeight;
      this.int_2 = dxfOle.OleItemVersion;
      this.int_3 = (int) dxfOle.Model.UniqueOleItemCounter();
      this.aspect_0 = dxfOle.AdviseType;
      this.bool_2 = dxfOle.Moniker;
      this.aspect_1 = dxfOle.DrawAspect;
      this.string_0 = dxfOle.UserType;
      this.type_0 = dxfOle.OleObjectType;
      this.dxfOleXData_0 = dxfOle.dxfOleXData_0;
      this.byte_2 = dxfOle.OleData;
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      IList<Polyline4D> polyline4DList = context.GetTransformer().Transform(this.method_14(), true);
      if (polyline4DList == null || polyline4DList.Count <= 0)
        return;
      IList<Polyline4D> polylines4D;
      IList<IShape4D> shapes;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out polylines4D, out shapes);
      IClippingTransformer clippingTransformer = (IClippingTransformer) context.GetTransformer().Clone();
      Matrix4D preTransform = Transformation4D.Translation((WW.Math.Vector3D) this.point3D_3);
      clippingTransformer.SetPreTransform(preTransform);
      Matrix4D matrix = clippingTransformer.Matrix;
      WW.Math.Point3D zero = WW.Math.Point3D.Zero;
      Vector4D transformedOrigin = matrix.TransformTo4D(zero);
      Vector4D transformedXAxis = matrix.TransformTo4D(zero + WW.Math.Vector3D.XAxis);
      Vector4D transformedYAxis = matrix.TransformTo4D(zero + WW.Math.Vector3D.YAxis);
      graphicsFactory.CreateScalableImage((DxfEntity) this, context, (IBitmapProvider) this, polyline4DList[0], new Size2D((this.point3D_2 - this.point3D_3).GetLength(), (this.point3D_0 - this.point3D_3).GetLength()), transformedOrigin, transformedXAxis, transformedYAxis);
      if (polylines4D.Count > 0)
        graphicsFactory.CreatePath((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, polylines4D, false, true);
      if (shapes == null)
        return;
      Class940.smethod_23((IPathDrawer) new ns0.Class0((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      IList<Polyline4D> polyline4DList = context.GetTransformer().Transform(this.method_14(), true);
      if (polyline4DList == null || polyline4DList.Count <= 0)
        return;
      IList<Polyline4D> polylines4D;
      IList<IShape4D> shapes;
      this.GetPolylines4D((DrawContext) context, context.GetTransformer(), out polylines4D, out shapes);
      Bitmap bitmap = this.Preview(context.Config.OleImageSize, context.Config.OleImageSize);
      if (bitmap != null)
      {
        DxfRasterImage rasterImage;
        Vector4D transformedOrigin;
        Vector4D transformedXAxis;
        Vector4D transformedYAxis;
        this.method_15(context, bitmap, out rasterImage, out transformedOrigin, out transformedXAxis, out transformedYAxis);
        graphicsFactory.BeginGeometry((DxfEntity) this, context, context.GetPlotColor((DxfEntity) this), false, false, true, true);
        graphicsFactory.CreateImage(rasterImage, new WW.Math.Point2D(0.0, 0.0), new WW.Math.Point2D((double) (bitmap.Width - 1), (double) (bitmap.Height - 1)), transformedOrigin, transformedXAxis, transformedYAxis, context);
        graphicsFactory.EndGeometry();
      }
      if (polylines4D.Count > 0)
        Class940.smethod_3((DxfEntity) this, context, graphicsFactory, context.GetPlotColor((DxfEntity) this), false, false, true, polylines4D);
      if (shapes == null)
        return;
      Class940.smethod_23((IPathDrawer) new Class396((DxfEntity) this, context, graphicsFactory), (IEnumerable<IShape4D>) shapes, this.Color.ToColor(), context.GetLineWeight((DxfEntity) this));
    }

    private void method_15(
      DrawContext.Wireframe context,
      Bitmap bitmap,
      out DxfRasterImage rasterImage,
      out Vector4D transformedOrigin,
      out Vector4D transformedXAxis,
      out Vector4D transformedYAxis)
    {
      GdiBitmap gdiBitmap = new GdiBitmap(bitmap);
      rasterImage = (DxfRasterImage) new DxfImage();
      DxfImageDef imageDef = new DxfImageDef(context.Model);
      imageDef.SetBitmap((IBitmap) gdiBitmap);
      rasterImage.SetImageDef(imageDef, true);
      IClippingTransformer clippingTransformer = (IClippingTransformer) context.GetTransformer().Clone();
      Matrix4D preTransform1 = Transformation4D.Translation((WW.Math.Vector3D) this.point3D_3);
      clippingTransformer.SetPreTransform(preTransform1);
      Matrix4D preTransform2 = Transformation4D.Scaling((this.point3D_2 - this.point3D_3).GetLength() / (double) bitmap.Width, (this.point3D_0 - this.point3D_3).GetLength() / (double) bitmap.Height, 1.0);
      clippingTransformer.SetPreTransform(preTransform2);
      Matrix4D matrix = clippingTransformer.Matrix;
      WW.Math.Point3D zero = WW.Math.Point3D.Zero;
      transformedOrigin = matrix.TransformTo4D(zero);
      transformedXAxis = matrix.TransformTo4D(zero + WW.Math.Vector3D.XAxis);
      transformedYAxis = matrix.TransformTo4D(zero + WW.Math.Vector3D.YAxis);
    }

    public Bitmap CreateBitmap(Size size)
    {
      return this.Preview(size.Width, size.Height);
    }

    public enum Aspect
    {
      Content = 1,
      Thumbnail = 2,
      Icon = 4,
      DocPrint = 8,
    }

    public enum Type
    {
      Unknown,
      Link,
      Embedded,
      Static,
      ToolPalette,
    }

    public enum QualityType
    {
      Monochrome,
      Low,
      High,
    }
  }
}
