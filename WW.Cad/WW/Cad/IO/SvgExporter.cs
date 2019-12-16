// Decompiled with JetBrains decompiler
// Type: WW.Cad.IO.SvgExporter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns33;
using ns36;
using ns38;
using ns4;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.IO
{
  public class SvgExporter
  {
    private string string_2 = "0.##";
    private bool bool_1 = true;
    private bool bool_2 = true;
    private const float float_0 = 0.1f;
    private const double double_0 = 0.0254;
    private XmlTextWriter xmlTextWriter_0;
    private float float_1;
    private float float_2;
    private float float_3;
    private string string_0;
    private string string_1;
    private Matrix4D matrix4D_0;
    private BlinnClipper4D blinnClipper4D_0;
    private PaperSize paperSize_0;
    private Size? nullable_0;
    private Rectangle2D? nullable_1;
    private BlinnClipper4D blinnClipper4D_1;
    private bool bool_0;
    private IComparer<DxfLayer> icomparer_0;
    private EntityFilterDelegate entityFilterDelegate_0;
    private XmlWriteDelegate xmlWriteDelegate_0;

    public SvgExporter(Stream stream)
      : this(stream, PaperKind.Letter)
    {
    }

    public SvgExporter(Stream stream, PaperKind paperKind)
      : this(stream, PaperSizes.GetPaperSize(paperKind))
    {
    }

    public SvgExporter(Stream stream, PaperSize paperSize)
    {
      Class809.smethod_0(Enum15.const_2);
      this.PaperSize = paperSize;
      this.LineWidth = 0.1f;
      this.xmlTextWriter_0 = new XmlTextWriter(stream, (Encoding) null);
      this.xmlTextWriter_0.Formatting = Formatting.Indented;
    }

    public SvgExporter(Stream stream, int width, int height)
      : this(stream, new Size(width, height))
    {
    }

    public SvgExporter(Stream stream, Size size)
    {
      Class809.smethod_0(Enum15.const_2);
      this.PixelSize = size;
      this.LineWidth = 1f;
      this.xmlTextWriter_0 = new XmlTextWriter(stream, (Encoding) null);
      this.xmlTextWriter_0.Formatting = Formatting.Indented;
    }

    public SvgExporter(XmlTextWriter w)
      : this(w, PaperKind.Letter)
    {
    }

    public SvgExporter(XmlTextWriter w, PaperKind paperKind)
      : this(w, PaperSizes.GetPaperSize(paperKind))
    {
    }

    public SvgExporter(XmlTextWriter w, PaperSize paperSize)
    {
      Class809.smethod_0(Enum15.const_2);
      this.PaperSize = paperSize;
      this.LineWidth = 0.1f;
      this.xmlTextWriter_0 = w;
    }

    public SvgExporter(XmlTextWriter w, int width, int height)
      : this(w, new Size(width, height))
    {
    }

    public SvgExporter(XmlTextWriter w, Size size)
    {
      Class809.smethod_0(Enum15.const_2);
      this.PixelSize = size;
      this.LineWidth = 1f;
      this.xmlTextWriter_0 = w;
    }

    public float LineWidth
    {
      get
      {
        return this.float_1;
      }
      set
      {
        this.float_1 = value;
        this.float_2 = this.float_1;
        if ((double) this.float_2 == 0.0)
          this.float_2 = 0.1f;
        this.float_3 = 0.5f * this.float_2;
      }
    }

    public PaperSize PaperSize
    {
      get
      {
        return this.paperSize_0;
      }
      set
      {
        this.paperSize_0 = value;
        this.blinnClipper4D_0 = new BlinnClipper4D(0.0, (double) this.paperSize_0.Width * 0.0254 * 100.0, 0.0, (double) this.paperSize_0.Height * 0.0254 * 100.0, 0.0, 0.0, false, false);
        this.nullable_0 = new Size?();
      }
    }

    public Size PixelSize
    {
      get
      {
        return this.nullable_0 ?? new Size(-1, -1);
      }
      set
      {
        this.nullable_0 = new Size?(value);
        this.blinnClipper4D_0 = new BlinnClipper4D(0.0, (double) (value.Width - 1), 0.0, (double) (value.Height - 1), 0.0, 8.88178419700125E-16, false, true);
        this.paperSize_0 = (PaperSize) null;
      }
    }

    public Rectangle2D? ClipRectangle
    {
      get
      {
        return this.nullable_1;
      }
      set
      {
        this.nullable_1 = value;
        if (this.nullable_1.HasValue)
        {
          Rectangle2D rectangle2D = this.nullable_1.Value;
          this.blinnClipper4D_1 = new BlinnClipper4D(rectangle2D.Corner1.X, rectangle2D.Corner2.X, rectangle2D.Corner1.Y, rectangle2D.Corner2.Y, 0.0, 0.0, false, false);
        }
        else
          this.blinnClipper4D_1 = (BlinnClipper4D) null;
      }
    }

    public bool ExportCadLayersAsSvgGroups
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

    public IComparer<DxfLayer> LayerComparer
    {
      get
      {
        return this.icomparer_0;
      }
      set
      {
        this.icomparer_0 = value;
      }
    }

    public EntityFilterDelegate EntityDrawFilter
    {
      get
      {
        return this.entityFilterDelegate_0;
      }
      set
      {
        this.entityFilterDelegate_0 = value;
      }
    }

    public string Description
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public string Title
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public string CoordinateFormat
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value;
      }
    }

    public XmlWriteDelegate WriteSvgXmlElementAttributes
    {
      get
      {
        return this.xmlWriteDelegate_0;
      }
      set
      {
        this.xmlWriteDelegate_0 = value;
      }
    }

    public bool WriteBackgroundRectangle
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

    public bool EmbedImages
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

    public void Draw(DxfModel model, GraphicsConfig config, Matrix4D modelToSvgTransform)
    {
      this.Draw(model, config, modelToSvgTransform, (ProgressEventHandler) null);
    }

    public void Draw(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D modelToSvgTransform,
      ProgressEventHandler progressEventHandler)
    {
      this.matrix4D_0 = modelToSvgTransform;
      new SvgExporter.Class669(this, config).Write(model, (DxfLayout) null, (ICollection<DxfViewport>) null, config, progressEventHandler);
    }

    public void Draw(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D paperToSvgTransform)
    {
      this.Draw(model, layout, viewports, config, paperToSvgTransform, (ProgressEventHandler) null);
    }

    public void Draw(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D paperToSvgTransform,
      ProgressEventHandler progressEventHandler)
    {
      this.matrix4D_0 = paperToSvgTransform;
      new SvgExporter.Class669(this, config).Write(model, layout, viewports, config, progressEventHandler);
      this.matrix4D_0 = Matrix4D.Identity;
    }

    private class Class669 : IWireframeGraphicsFactory
    {
      private const int int_0 = 50;
      private SvgExporter svgExporter_0;
      private XmlTextWriter xmlTextWriter_0;
      private float float_0;
      private float float_1;
      private float float_2;
      private Matrix4D matrix4D_0;
      private GraphicsConfig graphicsConfig_0;
      private BlinnClipper4D blinnClipper4D_0;
      private string string_0;
      private BlinnClipper4D blinnClipper4D_1;
      private EntityFilterDelegate entityFilterDelegate_0;
      private bool bool_0;
      private XmlWriteDelegate xmlWriteDelegate_0;
      private ArgbColor? nullable_0;
      private ArgbColor argbColor_0;
      private bool bool_1;
      private ArgbColor argbColor_1;

      public Class669(SvgExporter svgExporter, GraphicsConfig graphicsConfig)
      {
        this.svgExporter_0 = svgExporter;
        this.xmlTextWriter_0 = svgExporter.xmlTextWriter_0;
        this.float_0 = svgExporter.float_1;
        this.float_1 = svgExporter.float_2;
        this.float_2 = svgExporter.float_3;
        this.matrix4D_0 = svgExporter.matrix4D_0;
        this.graphicsConfig_0 = graphicsConfig;
        this.blinnClipper4D_0 = svgExporter.blinnClipper4D_0;
        this.blinnClipper4D_1 = svgExporter.blinnClipper4D_1;
        this.string_0 = svgExporter.string_2;
        this.entityFilterDelegate_0 = svgExporter.entityFilterDelegate_0;
        this.xmlWriteDelegate_0 = svgExporter.xmlWriteDelegate_0;
        this.nullable_0 = graphicsConfig.FixedForegroundColor;
        this.bool_1 = graphicsConfig.CorrectColorForBackgroundColor;
        this.argbColor_1 = graphicsConfig.BackColor;
      }

      public void BeginEntity(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
        this.bool_0 = this.entityFilterDelegate_0((DrawContext) drawContext, entity);
      }

      public void EndEntity()
      {
        this.bool_0 = false;
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
        if (!this.bool_0)
          return;
        this.method_11(entity, position, color);
      }

      public void CreateLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D start,
        Vector4D end)
      {
        if (!this.bool_0)
          return;
        this.DrawLine(entity, start, end, color);
      }

      public void CreateRay(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Segment4D segment)
      {
        if (!this.bool_0)
          return;
        this.method_12(entity, segment, color);
      }

      public void CreateXLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Vector4D? startPoint,
        Segment4D segment)
      {
        if (!this.bool_0)
          return;
        this.method_12(entity, segment, color);
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
        if (!this.bool_0 || polylines.Count <= 0)
          return;
        foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polylines)
          this.method_14(entity, polyline, color, fill, correctForBackgroundColor);
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
        if (!this.bool_0 || polylines.Count <= 0)
          return;
        this.method_16(entity, polylines, color, fill, correctForBackgroundColor);
      }

      public void CreateShape(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IShape4D shape)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        SvgExporter.Class669.Class671 class671 = new SvgExporter.Class669.Class671();
        // ISSUE: reference to a compiler-generated field
        class671.dxfEntity_0 = entity;
        // ISSUE: reference to a compiler-generated field
        class671.argbColor_0 = color;
        // ISSUE: reference to a compiler-generated field
        class671.class669_0 = this;
        if (!this.bool_0)
          return;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        SvgExporter.Class669.Class672 class672 = new SvgExporter.Class669.Class672();
        // ISSUE: reference to a compiler-generated field
        class672.class671_0 = class671;
        if (shape.IsEmpty)
          return;
        shape.Transform(this.matrix4D_0);
        BlinnClipper4D clipper = this.Clipper;
        InsideTestResult insideTestResult = shape.CheckClipping((IInsideTester4D) clipper);
        if (insideTestResult == InsideTestResult.Outside)
          return;
        // ISSUE: reference to a compiler-generated field
        class672.stringBuilder_0 = new StringBuilder();
        if (insideTestResult == InsideTestResult.BothSides)
        {
          foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) shape.ToPolylines4D(this.graphicsConfig_0.ShapeFlattenEpsilon))
          {
            // ISSUE: reference to a compiler-generated method
            clipper.Clip(polyline, shape.IsFilled, new System.Action<Polyline4D>(class672.method_0));
          }
        }
        else
        {
          IShape2D shape2D = shape.ToShape2D(Matrix4D.Identity);
          if (!shape2D.HasSegments)
            return;
          WW.Math.Point2D[] points = new WW.Math.Point2D[3];
          ISegment2DIterator iterator = shape2D.CreateIterator();
          while (iterator.MoveNext())
          {
            switch (iterator.Current(points, 0))
            {
              case SegmentType.MoveTo:
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append('M');
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(points[0].X.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(' ');
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(points[0].Y.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
                continue;
              case SegmentType.LineTo:
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append('L');
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(points[0].X.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(' ');
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(points[0].Y.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
                continue;
              case SegmentType.QuadTo:
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append('Q');
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(points[0].X.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(' ');
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(points[0].Y.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(' ');
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(points[1].X.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(' ');
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(points[1].Y.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
                continue;
              case SegmentType.CubicTo:
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append('C');
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(points[0].X.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(' ');
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(points[0].Y.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(' ');
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(points[1].X.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(' ');
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(points[1].Y.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(' ');
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(points[2].X.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(' ');
                // ISSUE: reference to a compiler-generated field
                class672.stringBuilder_0.Append(points[2].Y.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
                continue;
              default:
                continue;
            }
          }
        }
        // ISSUE: reference to a compiler-generated field
        if (class672.stringBuilder_0.Length <= 0)
          return;
        this.xmlTextWriter_0.WriteStartElement("path");
        if (this.xmlWriteDelegate_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.xmlWriteDelegate_0(this.xmlTextWriter_0, class671.dxfEntity_0);
        }
        // ISSUE: reference to a compiler-generated field
        this.xmlTextWriter_0.WriteAttributeString("d", class672.stringBuilder_0.ToString());
        // ISSUE: reference to a compiler-generated field
        string str = this.method_17(class671.argbColor_0, true);
        if (shape.IsFilled)
        {
          this.xmlTextWriter_0.WriteAttributeString("fill", str);
        }
        else
        {
          this.xmlTextWriter_0.WriteAttributeString("fill", "none");
          this.xmlTextWriter_0.WriteAttributeString("stroke", str);
        }
        this.xmlTextWriter_0.WriteEndElement();
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
        if (!this.bool_0 || text.Text == null || text.Text.Trim() == string.Empty)
          return;
        this.method_0((IEnumerable<Class908>) Class666.smethod_5(text, text.Color.ToColor(), drawContext.GetLineWeight((DxfEntity) text), text.Transform, (Bounds2D) null), (DxfEntity) text, drawContext);
      }

      public void CreateMText(DxfMText text, DrawContext.Wireframe drawContext)
      {
        if (!this.bool_0 || text.Text == null || text.Text.Trim() == string.Empty)
          return;
        Bounds2D collectBounds = new Bounds2D();
        short lineWeight = drawContext.GetLineWeight((DxfEntity) text);
        IList<Class908> class908List = Class666.smethod_4(text, text.Color.ToColor(), lineWeight, Matrix4D.Identity, collectBounds);
        Bounds3D bounds = new Bounds3D();
        WW.Math.Point2D min = collectBounds.Min;
        WW.Math.Point2D max = collectBounds.Max;
        bounds.Update(text.Transform.TransformTo3D(min));
        bounds.Update(text.Transform.TransformTo3D(max));
        bounds.Update(text.Transform.TransformTo3D(new WW.Math.Point2D(min.X, max.Y)));
        bounds.Update(text.Transform.TransformTo3D(new WW.Math.Point2D(max.X, min.Y)));
        if (drawContext.GetTransformer().TryIsInside(bounds) == InsideTestResult.Outside)
          return;
        BackgroundFillFlags backgroundFillFlags = text.BackgroundFillFlags;
        BackgroundFillInfo backgroundFillInfo = text.BackgroundFillInfo;
        if (backgroundFillFlags == BackgroundFillFlags.UseBackgroundFillColor && backgroundFillInfo != null)
        {
          double num1 = text.Height * (backgroundFillInfo.BorderOffsetFactor - 1.0);
          WW.Math.Point2D zero = WW.Math.Point2D.Zero;
          double num2 = text.ReferenceRectangleWidth == 0.0 ? collectBounds.Delta.X : text.ReferenceRectangleWidth;
          double y = collectBounds.Delta.Y;
          switch (text.AttachmentPoint)
          {
            case AttachmentPoint.TopLeft:
              zero.X = collectBounds.Corner1.X + 0.5 * num2;
              zero.Y = collectBounds.Corner2.Y - 0.5 * y;
              break;
            case AttachmentPoint.TopCenter:
              zero.X = collectBounds.Center.X;
              zero.Y = collectBounds.Corner2.Y - 0.5 * y;
              break;
            case AttachmentPoint.TopRight:
              zero.X = collectBounds.Corner2.X - 0.5 * num2;
              zero.Y = collectBounds.Corner2.Y - 0.5 * y;
              break;
            case AttachmentPoint.MiddleLeft:
              zero.X = collectBounds.Corner1.X + 0.5 * num2;
              zero.Y = collectBounds.Center.Y;
              break;
            case AttachmentPoint.MiddleCenter:
              zero.X = collectBounds.Center.X;
              zero.Y = collectBounds.Center.Y;
              break;
            case AttachmentPoint.MiddleRight:
              zero.X = collectBounds.Corner2.X - 0.5 * num2;
              zero.Y = collectBounds.Center.Y;
              break;
            case AttachmentPoint.BottomLeft:
              zero.X = collectBounds.Corner1.X + 0.5 * num2;
              zero.Y = collectBounds.Corner1.Y + 0.5 * y;
              break;
            case AttachmentPoint.BottomCenter:
              zero.X = collectBounds.Center.X;
              zero.Y = collectBounds.Corner1.Y + 0.5 * y;
              break;
            case AttachmentPoint.BottomRight:
              zero.X = collectBounds.Corner2.X - 0.5 * num2;
              zero.Y = collectBounds.Corner1.Y + 0.5 * y;
              break;
            default:
              zero.X = collectBounds.Center.X;
              zero.Y = collectBounds.Center.Y;
              break;
          }
          Vector2D vector2D = new Vector2D(0.5 * num2 + num1, 0.5 * y + num1);
          IPathDrawer wrapped = (IPathDrawer) new SvgExporter.Class669.Class670((DrawContext) drawContext, this, (DxfEntity) text);
          new ClippingPathDrawerWrapper((IClippingTransformer) this.method_1(drawContext.GetTransformer()), wrapped).DrawPath((IShape2D) new Rectangle2D(zero - vector2D, zero + vector2D), text.Transform, backgroundFillInfo.Color, lineWeight, true, false, 0.0);
        }
        this.method_0((IEnumerable<Class908>) class908List, (DxfEntity) text, drawContext);
      }

      private static string smethod_0(double val)
      {
        return val.ToString("G", (IFormatProvider) CultureInfo.InvariantCulture);
      }

      private void method_0(
        IEnumerable<Class908> chunks,
        DxfEntity entity,
        DrawContext.Wireframe drawContext)
      {
        IClippingTransformer transformer = (IClippingTransformer) this.method_1(drawContext.GetTransformer());
        Matrix4D matrix = transformer.Matrix;
        foreach (Class908 chunk in chunks)
        {
          Font systemFont = chunk.Font.SystemFont;
          bool flag;
          if (!(flag = systemFont == null))
          {
            FlatShape4D flatShape4D = new FlatShape4D(chunk.FontPath, chunk.Transformation, true);
            bool transformedShape;
            switch (transformer.IsInside((IShape4D) flatShape4D, out transformedShape))
            {
              case InsideTestResult.Outside:
                continue;
              case InsideTestResult.BothSides:
                flag = true;
                break;
              default:
                double systemFontHeight = chunk.Font.Metrics.SystemFontHeight;
                double num = 1.0 / chunk.Font.Metrics.FontHeight;
                if (DxfUtil.IsSaneNotZero(systemFontHeight) && DxfUtil.IsSaneNotZero(num))
                {
                  Matrix2D charTransformation = chunk.Font.Metrics.CharTransformation;
                  Matrix4D matrix4D = matrix * chunk.Transformation * new Matrix4D(num * charTransformation.M00, num * charTransformation.M01, 0.0, 0.0, num * charTransformation.M10, num * charTransformation.M11, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
                  this.xmlTextWriter_0.WriteStartElement("g");
                  this.xmlTextWriter_0.WriteAttributeString("transform", string.Format("matrix({0},{1},{2},{3},{4},{5})", (object) SvgExporter.Class669.smethod_0(matrix4D.M00), (object) SvgExporter.Class669.smethod_0(matrix4D.M10), (object) SvgExporter.Class669.smethod_0(matrix4D.M01), (object) SvgExporter.Class669.smethod_0(matrix4D.M11), (object) SvgExporter.Class669.smethod_0(matrix4D.M03), (object) SvgExporter.Class669.smethod_0(matrix4D.M13)));
                  this.xmlTextWriter_0.WriteStartElement("text");
                  if (this.xmlWriteDelegate_0 != null)
                    this.xmlWriteDelegate_0(this.xmlTextWriter_0, entity);
                  this.xmlTextWriter_0.WriteAttributeString("font-family", systemFont.FontFamily.Name);
                  this.xmlTextWriter_0.WriteAttributeString("font-size", systemFontHeight.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
                  if (systemFont.Italic)
                    this.xmlTextWriter_0.WriteAttributeString("font-style", "italic");
                  if (systemFont.Bold)
                    this.xmlTextWriter_0.WriteAttributeString("font-weight", "bold");
                  this.xmlTextWriter_0.WriteAttributeString("fill", this.method_17(drawContext.GetPlotColor(entity, chunk.Color), this.bool_1));
                  this.xmlTextWriter_0.WriteValue(chunk.Text.Text);
                  this.xmlTextWriter_0.WriteEndElement();
                  this.xmlTextWriter_0.WriteEndElement();
                  break;
                }
                continue;
            }
          }
          IPathDrawer wrapped = (IPathDrawer) null;
          if (flag)
          {
            wrapped = (IPathDrawer) new SvgExporter.Class669.Class670((DrawContext) drawContext, this, entity);
            chunk.method_0((IPathDrawer) new ClippingPathDrawerWrapper(transformer, wrapped), Matrix4D.Identity, 0.0);
          }
          if (chunk.Linings.Length > 0)
          {
            if (wrapped == null)
              wrapped = (IPathDrawer) new SvgExporter.Class669.Class670((DrawContext) drawContext, this, entity);
            chunk.method_1((IPathDrawer) new ClippingPathDrawerWrapper(transformer, wrapped), Matrix4D.Identity, 0.0);
          }
        }
      }

      private ClippingTransformerChain method_1(
        IClippingTransformer clippingTransformer)
      {
        ClippingTransformerChain transformerChain = new ClippingTransformerChain();
        List<BlinnClipper4D.ClipPlane> clipPlaneList = new List<BlinnClipper4D.ClipPlane>();
        foreach (BlinnClipper4D.IInsideTester insideTester in this.Clipper.InsideTesters)
          clipPlaneList.Add(new BlinnClipper4D.ClipPlane(insideTester.Normal, insideTester.Distance));
        Class808 class808 = new Class808((ICollection<BlinnClipper4D.ClipPlane>) clipPlaneList);
        transformerChain.Push((IClippingTransformer) new ModelSpaceClippingTransformer(Matrix4D.Identity, (Interface32) class808, this.graphicsConfig_0.ShapeFlattenEpsilon, this.graphicsConfig_0.ShapeFlattenEpsilonForBoundsCalculation));
        transformerChain.Push((IClippingTransformer) new Class383(this.matrix4D_0));
        transformerChain.Push(clippingTransformer);
        return transformerChain;
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
        if (rasterImage.ImageDef == null || rasterImage.ImageDef.Bitmap == null && this.svgExporter_0.bool_2)
          return;
        Bitmap bitmap = (Bitmap) null;
        if (rasterImage.ImageDef != null && rasterImage.ImageDef.Bitmap != null)
          bitmap = rasterImage.ImageDef.Bitmap.Image;
        if (bitmap == null && this.svgExporter_0.bool_2)
          return;
        Size2D size2D = bitmap == null ? rasterImage.Size : new Size2D((double) bitmap.Width, (double) bitmap.Height);
        Matrix4D matrix4D = this.matrix4D_0 * rasterImage.method_15() * Transformation4D.Scaling(1.0, -1.0, 1.0) * Transformation4D.Translation(0.0, -size2D.Y, 0.0);
        WW.Math.Point3D zero = WW.Math.Point3D.Zero;
        WW.Math.Point3D point1 = new WW.Math.Point3D(0.5 * size2D.X, 0.5 * size2D.Y, 0.0);
        WW.Math.Point3D point2 = new WW.Math.Point3D(0.0, point1.Y, 0.0);
        WW.Math.Point3D point3 = new WW.Math.Point3D(size2D.X, point1.Y, 0.0);
        WW.Math.Point3D point4 = new WW.Math.Point3D(point1.X, 0.0, 0.0);
        WW.Math.Point3D point5 = new WW.Math.Point3D(point1.X, size2D.Y, 0.0);
        WW.Math.Point3D point3D1 = matrix4D.Transform(zero);
        matrix4D.Transform(point1);
        WW.Math.Point3D point3D2 = matrix4D.Transform(point2);
        WW.Math.Point3D point3D3 = matrix4D.Transform(point3);
        WW.Math.Point3D point3D4 = matrix4D.Transform(point4);
        WW.Math.Point3D point3D5 = matrix4D.Transform(point5);
        WW.Math.Vector3D vector3D1 = (point3D3 - point3D2) * (1.0 / size2D.X);
        WW.Math.Vector3D vector3D2 = (point3D5 - point3D4) * (1.0 / size2D.Y);
        this.xmlTextWriter_0.WriteStartElement("g");
        this.xmlTextWriter_0.WriteAttributeString("transform", string.Format("matrix({0},{1},{2},{3},{4},{5})", (object) vector3D1.X.ToString((IFormatProvider) CultureInfo.InvariantCulture), (object) vector3D1.Y.ToString((IFormatProvider) CultureInfo.InvariantCulture), (object) vector3D2.X.ToString((IFormatProvider) CultureInfo.InvariantCulture), (object) vector3D2.Y.ToString((IFormatProvider) CultureInfo.InvariantCulture), (object) point3D1.X.ToString((IFormatProvider) CultureInfo.InvariantCulture), (object) point3D1.Y.ToString((IFormatProvider) CultureInfo.InvariantCulture)));
        this.xmlTextWriter_0.WriteStartElement("image");
        if (this.xmlWriteDelegate_0 != null)
          this.xmlWriteDelegate_0(this.xmlTextWriter_0, (DxfEntity) rasterImage);
        this.xmlTextWriter_0.WriteAttributeString("width", size2D.X.ToString((IFormatProvider) CultureInfo.InvariantCulture));
        this.xmlTextWriter_0.WriteAttributeString("height", size2D.Y.ToString((IFormatProvider) CultureInfo.InvariantCulture));
        if (this.svgExporter_0.bool_2 && bitmap != null)
        {
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.Append("data:image/png;base64,");
          using (MemoryStream memoryStream = new MemoryStream())
          {
            bitmap.Save((Stream) memoryStream, ImageFormat.Png);
            stringBuilder.Append(Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int) memoryStream.Length));
          }
          this.xmlTextWriter_0.WriteAttributeString("xlink:href", stringBuilder.ToString());
        }
        else
          this.xmlTextWriter_0.WriteAttributeString("xlink:href", rasterImage.ImageDef.Filename);
        this.xmlTextWriter_0.WriteEndElement();
        this.xmlTextWriter_0.WriteEndElement();
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
      }

      public void Write(
        DxfModel model,
        DxfLayout layout,
        ICollection<DxfViewport> viewports,
        GraphicsConfig config,
        ProgressEventHandler progressEventHandler)
      {
        this.method_8(config);
        Rectangle2D rectangle2D = this.method_9();
        if (this.svgExporter_0.bool_1)
        {
          this.xmlTextWriter_0.WriteStartElement("rect");
          this.xmlTextWriter_0.WriteAttributeString("x", rectangle2D.X1.ToString((IFormatProvider) CultureInfo.InvariantCulture));
          this.xmlTextWriter_0.WriteAttributeString("y", rectangle2D.Y1.ToString((IFormatProvider) CultureInfo.InvariantCulture));
          this.xmlTextWriter_0.WriteAttributeString("width", rectangle2D.Width.ToString((IFormatProvider) CultureInfo.InvariantCulture));
          this.xmlTextWriter_0.WriteAttributeString("height", rectangle2D.Height.ToString((IFormatProvider) CultureInfo.InvariantCulture));
          this.xmlTextWriter_0.WriteAttributeString("fill", "#" + this.argbColor_1.Rgb.ToString("X6"));
          if (this.argbColor_1.Alpha < (int) byte.MaxValue)
            this.xmlTextWriter_0.WriteAttributeString("fill-opacity", ((double) this.argbColor_1.Alpha / (double) byte.MaxValue).ToString((IFormatProvider) CultureInfo.InvariantCulture));
          this.xmlTextWriter_0.WriteAttributeString("stroke", "none");
          this.xmlTextWriter_0.WriteEndElement();
        }
        if (layout == null)
        {
          using (DrawContext.Wireframe.ModelSpace context = new DrawContext.Wireframe.ModelSpace(model, config, Matrix4D.Identity))
          {
            IList<DxfEntity> sortedEntities = model.ModelLayout.GetSortedEntities();
            int i = 0;
            if (this.svgExporter_0.bool_0)
            {
              WireframeGraphicsCache wireframeGraphicsCache = new WireframeGraphicsCache(this.SupportsText, false);
              wireframeGraphicsCache.Config = this.graphicsConfig_0;
              wireframeGraphicsCache.CreateDrawables(model);
              IList<DxfLayer> dxfLayerList = this.method_5(model);
              float num1 = (float) (dxfLayerList.Count * wireframeGraphicsCache.Drawables.Count);
              int num2 = 0;
              foreach (DxfLayer layer in (IEnumerable<DxfLayer>) dxfLayerList)
              {
                this.entityFilterDelegate_0 = this.method_3(layer);
                this.method_4(layer.Name);
                foreach (IWireframeDrawable drawable in wireframeGraphicsCache.Drawables)
                {
                  drawable.Draw((IWireframeGraphicsFactory) this);
                  if (progressEventHandler != null && num2 % 50 == 0)
                    progressEventHandler((object) this, new ProgressEventArgs((float) num2 / num1));
                  ++num2;
                }
                this.xmlTextWriter_0.WriteEndElement();
              }
            }
            else
            {
              this.entityFilterDelegate_0 = this.method_2();
              this.method_4((string) null);
              this.method_6(sortedEntities, context, ref i, progressEventHandler);
              this.xmlTextWriter_0.WriteEndElement();
            }
          }
        }
        else
        {
          if (viewports == null)
            viewports = (ICollection<DxfViewport>) layout.Viewports;
          int n = model.Entities.Count * viewports.Count + layout.Entities.Count;
          IList<DxfEntity> sortedEntities = layout.GetSortedEntities();
          int i = 0;
          if (this.svgExporter_0.bool_0)
          {
            WireframeGraphicsCache wireframeGraphicsCache = new WireframeGraphicsCache(this.SupportsText, false);
            wireframeGraphicsCache.CreateDrawables(model, layout, viewports);
            IList<DxfLayer> dxfLayerList = this.method_5(model);
            float num1 = (float) (dxfLayerList.Count * wireframeGraphicsCache.Drawables.Count);
            int num2 = 0;
            foreach (DxfLayer layer in (IEnumerable<DxfLayer>) dxfLayerList)
            {
              this.entityFilterDelegate_0 = this.method_3(layer);
              this.method_4(layer.Name);
              foreach (IWireframeDrawable drawable in wireframeGraphicsCache.Drawables)
              {
                drawable.Draw((IWireframeGraphicsFactory) this);
                if (progressEventHandler != null && num2 % 50 == 0)
                  progressEventHandler((object) this, new ProgressEventArgs((float) num2 / num1));
                ++num2;
              }
              this.xmlTextWriter_0.WriteEndElement();
            }
          }
          else
          {
            this.entityFilterDelegate_0 = this.method_2();
            this.method_4((string) null);
            this.method_7(config, model, layout, viewports, sortedEntities, ref i, n, progressEventHandler);
            this.xmlTextWriter_0.WriteEndElement();
          }
        }
        this.method_10();
        this.xmlTextWriter_0.Close();
      }

      private EntityFilterDelegate method_2()
      {
        return this.svgExporter_0.entityFilterDelegate_0 != null ? (EntityFilterDelegate) ((drawContext, entity) => this.svgExporter_0.entityFilterDelegate_0(drawContext, entity)) : (EntityFilterDelegate) ((drawContext, entity) => true);
      }

      private EntityFilterDelegate method_3(DxfLayer layer)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        SvgExporter.Class669.Class673 class673 = new SvgExporter.Class669.Class673();
        // ISSUE: reference to a compiler-generated field
        class673.dxfLayer_0 = layer;
        // ISSUE: reference to a compiler-generated field
        class673.class669_0 = this;
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        return this.svgExporter_0.entityFilterDelegate_0 != null ? new EntityFilterDelegate(class673.method_1) : new EntityFilterDelegate(class673.method_0);
      }

      private void method_4(string id)
      {
        this.xmlTextWriter_0.WriteStartElement("g");
        if (!string.IsNullOrEmpty(id))
          this.xmlTextWriter_0.WriteAttributeString(nameof (id), id);
        this.xmlTextWriter_0.WriteAttributeString("stroke-width", this.float_0.ToString((IFormatProvider) CultureInfo.InvariantCulture));
      }

      private IList<DxfLayer> method_5(DxfModel model)
      {
        IList<DxfLayer> dxfLayerList;
        if (this.svgExporter_0.icomparer_0 == null)
        {
          dxfLayerList = (IList<DxfLayer>) model.Layers;
        }
        else
        {
          dxfLayerList = (IList<DxfLayer>) new List<DxfLayer>((IEnumerable<DxfLayer>) model.Layers);
          ((List<DxfLayer>) dxfLayerList).Sort(this.svgExporter_0.icomparer_0);
        }
        return dxfLayerList;
      }

      private void method_6(
        IList<DxfEntity> entities,
        DrawContext.Wireframe.ModelSpace context,
        ref int i,
        ProgressEventHandler progressEventHandler)
      {
        int count = entities.Count;
        foreach (DxfEntity entity in (IEnumerable<DxfEntity>) entities)
        {
          entity.Draw((DrawContext.Wireframe) context, (IWireframeGraphicsFactory) this);
          if (i % 100 == 0 && progressEventHandler != null)
            progressEventHandler((object) this, new ProgressEventArgs((float) i / (float) count));
          ++i;
        }
      }

      private void method_7(
        GraphicsConfig config,
        DxfModel model,
        DxfLayout layout,
        ICollection<DxfViewport> viewports,
        IList<DxfEntity> entities,
        ref int i,
        int n,
        ProgressEventHandler progressEventHandler)
      {
        using (DrawContext.Wireframe.PaperToPaperSpace paperToPaperSpace = new DrawContext.Wireframe.PaperToPaperSpace(model, layout, config, Matrix4D.Identity))
        {
          foreach (DxfEntity entity in (IEnumerable<DxfEntity>) entities)
          {
            entity.Draw((DrawContext.Wireframe) paperToPaperSpace, (IWireframeGraphicsFactory) this);
            if (i % 100 == 0 && progressEventHandler != null)
              progressEventHandler((object) this, new ProgressEventArgs((float) i / (float) n));
            ++i;
          }
        }
        IList<DxfEntity> sortedEntities = model.ModelLayout.GetSortedEntities();
        foreach (DxfViewport viewport in (IEnumerable<DxfViewport>) viewports)
        {
          if (viewport.ModelSpaceVisible)
          {
            using (DrawContext.Wireframe.ModelToPaperSpace modelToPaperSpace = new DrawContext.Wireframe.ModelToPaperSpace(model, layout, config, viewport, Matrix4D.Identity))
            {
              foreach (DxfEntity dxfEntity in (IEnumerable<DxfEntity>) sortedEntities)
              {
                dxfEntity.Draw((DrawContext.Wireframe) modelToPaperSpace, (IWireframeGraphicsFactory) this);
                if (i % 100 == 0 && progressEventHandler != null)
                  progressEventHandler((object) this, new ProgressEventArgs((float) i / (float) n));
                ++i;
              }
            }
          }
        }
      }

      private void method_8(GraphicsConfig config)
      {
        this.graphicsConfig_0 = config;
        this.nullable_0 = this.graphicsConfig_0.FixedForegroundColor;
        this.bool_1 = this.graphicsConfig_0.CorrectColorForBackgroundColor;
        this.argbColor_1 = this.graphicsConfig_0.BackColor;
        this.argbColor_0 = new ArgbColor((int) byte.MaxValue - (int) this.argbColor_1.R, (int) byte.MaxValue - (int) this.argbColor_1.G, (int) byte.MaxValue - (int) this.argbColor_1.B);
      }

      private Rectangle2D method_9()
      {
        this.xmlTextWriter_0.WriteStartDocument();
        this.xmlTextWriter_0.WriteDocType("svg", "-//W3C//DTD SVG 1.1//EN", "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd", (string) null);
        Assembly entryAssembly = Assembly.GetEntryAssembly();
        if (entryAssembly != (Assembly) null)
        {
          AssemblyName name = entryAssembly.GetName();
          this.xmlTextWriter_0.WriteComment("Produced by application: " + name.Name + " " + (object) name.Version);
        }
        AssemblyName name1 = Assembly.GetExecutingAssembly().GetName();
        this.xmlTextWriter_0.WriteComment("Library: www.woutware.com " + name1.Name + " " + (object) name1.Version);
        this.xmlTextWriter_0.WriteComment("Creation date: " + DateTime.Now.ToString((IFormatProvider) CultureInfo.InvariantCulture));
        this.xmlTextWriter_0.WriteStartElement("svg");
        this.xmlTextWriter_0.WriteAttributeString("xmlns", "http://www.w3.org/2000/svg");
        this.xmlTextWriter_0.WriteAttributeString("xmlns", "xlink", (string) null, "http://www.w3.org/1999/xlink");
        Rectangle2D rectangle2D;
        if (this.svgExporter_0.nullable_0.HasValue)
        {
          int width = this.svgExporter_0.nullable_0.Value.Width;
          this.xmlTextWriter_0.WriteAttributeString("width", width.ToString((IFormatProvider) CultureInfo.InvariantCulture) + "px");
          int height = this.svgExporter_0.nullable_0.Value.Height;
          this.xmlTextWriter_0.WriteAttributeString("height", height.ToString((IFormatProvider) CultureInfo.InvariantCulture) + "px");
          this.xmlTextWriter_0.WriteAttributeString("viewBox", "0 0 " + width.ToString((IFormatProvider) CultureInfo.InvariantCulture) + " " + height.ToString((IFormatProvider) CultureInfo.InvariantCulture));
          rectangle2D = new Rectangle2D(0.0, 0.0, (double) width, (double) height);
        }
        else
        {
          double num1 = (double) this.svgExporter_0.paperSize_0.Width * 0.0254;
          this.xmlTextWriter_0.WriteAttributeString("width", num1.ToString("0.#", (IFormatProvider) CultureInfo.InvariantCulture) + "cm");
          double num2 = (double) this.svgExporter_0.paperSize_0.Height * 0.0254;
          this.xmlTextWriter_0.WriteAttributeString("height", num2.ToString("0.#", (IFormatProvider) CultureInfo.InvariantCulture) + "cm");
          this.xmlTextWriter_0.WriteAttributeString("viewBox", "0 0 " + (num1 * 100.0).ToString("0.#", (IFormatProvider) CultureInfo.InvariantCulture) + " " + (num2 * 100.0).ToString("0.#", (IFormatProvider) CultureInfo.InvariantCulture));
          rectangle2D = new Rectangle2D(0.0, 0.0, num1 * 100.0, num2 * 100.0);
        }
        this.xmlTextWriter_0.WriteAttributeString("version", "1.1");
        if (this.svgExporter_0.string_0 != null)
          this.xmlTextWriter_0.WriteElementString("title", this.svgExporter_0.string_0);
        if (this.svgExporter_0.string_1 != null)
          this.xmlTextWriter_0.WriteElementString("description", this.svgExporter_0.string_1);
        return rectangle2D;
      }

      private void method_10()
      {
        this.xmlTextWriter_0.WriteEndElement();
      }

      private void method_11(DxfEntity entity, Vector4D point, ArgbColor color)
      {
        WW.Math.Point2D point2D = (WW.Math.Point2D) point;
        this.xmlTextWriter_0.WriteStartElement("rect");
        if (this.xmlWriteDelegate_0 != null)
          this.xmlWriteDelegate_0(this.xmlTextWriter_0, entity);
        this.xmlTextWriter_0.WriteAttributeString("x", (point2D.X - (double) this.float_2).ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
        this.xmlTextWriter_0.WriteAttributeString("y", (point2D.Y - (double) this.float_2).ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
        this.xmlTextWriter_0.WriteAttributeString("width", this.float_1.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
        this.xmlTextWriter_0.WriteAttributeString("height", this.float_1.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
        string str = this.method_17(color, true);
        this.xmlTextWriter_0.WriteAttributeString("fill", str);
        this.xmlTextWriter_0.WriteAttributeString("stroke", str);
        this.xmlTextWriter_0.WriteEndElement();
      }

      private void DrawLine(DxfEntity entity, Vector4D start, Vector4D end, ArgbColor color)
      {
        start = this.matrix4D_0.Transform(start);
        end = this.matrix4D_0.Transform(end);
        Segment4D? nullable = this.Clipper.ClipConvex(new Segment4D(start, end));
        if (!nullable.HasValue)
          return;
        WW.Math.Point2D start1 = (WW.Math.Point2D) nullable.Value.Start;
        WW.Math.Point2D end1 = (WW.Math.Point2D) nullable.Value.End;
        if (start1 == end1)
        {
          this.method_11(entity, start, color);
        }
        else
        {
          this.xmlTextWriter_0.WriteStartElement("line");
          if (this.xmlWriteDelegate_0 != null)
            this.xmlWriteDelegate_0(this.xmlTextWriter_0, entity);
          this.xmlTextWriter_0.WriteAttributeString("x1", start1.X.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
          this.xmlTextWriter_0.WriteAttributeString("y1", start1.Y.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
          this.xmlTextWriter_0.WriteAttributeString("x2", end1.X.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
          this.xmlTextWriter_0.WriteAttributeString("y2", end1.Y.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
          this.xmlTextWriter_0.WriteAttributeString("stroke", this.method_17(color, true));
          this.xmlTextWriter_0.WriteEndElement();
        }
      }

      private void method_12(DxfEntity entity, Segment4D segment, ArgbColor color)
      {
        Vector4D start = this.matrix4D_0.Transform(segment.Start);
        Vector4D end = this.matrix4D_0.Transform(segment.End);
        this.method_13(entity, start, end, color);
      }

      private void method_13(DxfEntity entity, Vector4D start, Vector4D end, ArgbColor color)
      {
        Segment4D? nullable = this.Clipper.ClipConvex(new Segment4D(start, end));
        if (!nullable.HasValue)
          return;
        Segment4D segment4D = nullable.Value;
        start = segment4D.Start;
        end = segment4D.End;
        this.xmlTextWriter_0.WriteStartElement("line");
        if (this.xmlWriteDelegate_0 != null)
          this.xmlWriteDelegate_0(this.xmlTextWriter_0, entity);
        this.xmlTextWriter_0.WriteAttributeString("x1", start.X.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
        this.xmlTextWriter_0.WriteAttributeString("y1", start.Y.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
        this.xmlTextWriter_0.WriteAttributeString("x2", end.X.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
        this.xmlTextWriter_0.WriteAttributeString("y2", end.Y.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
        this.xmlTextWriter_0.WriteAttributeString("stroke", this.method_17(color, true));
        this.xmlTextWriter_0.WriteEndElement();
      }

      private bool method_14(
        DxfEntity entity,
        Polyline4D polyline,
        ArgbColor color,
        bool fill,
        bool correctForBackgroundColor)
      {
        if (polyline.Count == 0)
          return false;
        IList<Polyline4D> polyline4DList = this.Clipper.Clip(DxfUtil.Transform(polyline, this.matrix4D_0), fill);
        bool flag = false;
        foreach (Polyline4D polyline1 in (IEnumerable<Polyline4D>) polyline4DList)
        {
          if (this.method_15(entity, polyline1, color, fill, correctForBackgroundColor))
            flag = true;
        }
        return flag;
      }

      private bool method_15(
        DxfEntity entity,
        Polyline4D polyline,
        ArgbColor color,
        bool fill,
        bool correctForBackgroundColor)
      {
        if (polyline.Count == 0)
          return false;
        if (polyline.Count == 1)
        {
          this.method_11(entity, polyline[0], color);
          return true;
        }
        StringBuilder stringBuilder = new StringBuilder();
        WW.Math.Point2D point2D1 = (WW.Math.Point2D) polyline[0];
        stringBuilder.Append("M");
        stringBuilder.Append(point2D1.X.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(' ');
        stringBuilder.Append(point2D1.Y.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
        for (int index = 1; index < polyline.Count; ++index)
        {
          WW.Math.Point2D point2D2 = (WW.Math.Point2D) polyline[index];
          stringBuilder.Append("L");
          stringBuilder.Append(point2D2.X.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
          stringBuilder.Append(' ');
          stringBuilder.Append(point2D2.Y.ToString(this.string_0, (IFormatProvider) CultureInfo.InvariantCulture));
        }
        if (polyline.Closed)
          stringBuilder.Append(" Z");
        this.xmlTextWriter_0.WriteStartElement("path");
        if (this.xmlWriteDelegate_0 != null)
          this.xmlWriteDelegate_0(this.xmlTextWriter_0, entity);
        this.xmlTextWriter_0.WriteAttributeString("d", stringBuilder.ToString());
        string str = this.method_17(color, correctForBackgroundColor);
        if (fill)
          this.xmlTextWriter_0.WriteAttributeString(nameof (fill), str);
        else
          this.xmlTextWriter_0.WriteAttributeString(nameof (fill), "none");
        this.xmlTextWriter_0.WriteAttributeString("stroke", str);
        this.xmlTextWriter_0.WriteEndElement();
        return true;
      }

      private bool method_16(
        DxfEntity entity,
        IList<Polyline4D> polylines,
        ArgbColor color,
        bool fill,
        bool correctForBackgroundColor)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        SvgExporter.Class669.Class674 class674 = new SvgExporter.Class669.Class674();
        // ISSUE: reference to a compiler-generated field
        class674.class669_0 = this;
        BlinnClipper4D clipper = this.Clipper;
        // ISSUE: reference to a compiler-generated field
        class674.stringBuilder_0 = new StringBuilder();
        foreach (Polyline4D polyline1 in (IEnumerable<Polyline4D>) polylines)
        {
          Polyline4D polyline2 = DxfUtil.Transform(polyline1, this.matrix4D_0);
          // ISSUE: reference to a compiler-generated method
          clipper.Clip(polyline2, fill, new System.Action<Polyline4D>(class674.method_0));
        }
        this.xmlTextWriter_0.WriteStartElement("path");
        if (this.xmlWriteDelegate_0 != null)
          this.xmlWriteDelegate_0(this.xmlTextWriter_0, entity);
        // ISSUE: reference to a compiler-generated field
        this.xmlTextWriter_0.WriteAttributeString("d", class674.stringBuilder_0.ToString());
        string str = this.method_17(color, correctForBackgroundColor);
        if (fill)
        {
          this.xmlTextWriter_0.WriteAttributeString(nameof (fill), str);
          this.xmlTextWriter_0.WriteAttributeString("fill-rule", "evenodd");
        }
        else
        {
          this.xmlTextWriter_0.WriteAttributeString(nameof (fill), "none");
          this.xmlTextWriter_0.WriteAttributeString("stroke", str);
        }
        this.xmlTextWriter_0.WriteEndElement();
        return true;
      }

      private string method_17(ArgbColor color, bool correctForBackgroundColor)
      {
        if (this.nullable_0.HasValue)
          color = this.nullable_0.Value;
        else if (correctForBackgroundColor && this.bool_1 && color == this.argbColor_1)
          color = this.argbColor_0;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append('#');
        stringBuilder.Append(color.R.ToString("X2"));
        stringBuilder.Append(color.G.ToString("X2"));
        stringBuilder.Append(color.B.ToString("X2"));
        return stringBuilder.ToString();
      }

      private WW.Math.Point2D method_18(Vector4D point)
      {
        return this.matrix4D_0.TransformToPoint2D(point);
      }

      private WW.Math.Point2D method_19(PointF point)
      {
        return this.matrix4D_0.TransformTo2D(new WW.Math.Point2D((double) point.X, (double) point.Y));
      }

      private WW.Math.Point2D method_20(WW.Math.Point2D point)
      {
        return this.matrix4D_0.TransformTo2D(new WW.Math.Point2D(point.X, point.Y));
      }

      private BlinnClipper4D Clipper
      {
        get
        {
          return this.blinnClipper4D_1 ?? this.blinnClipper4D_0;
        }
      }

      private class Class670 : IPathDrawer
      {
        private readonly StringBuilder stringBuilder_0 = new StringBuilder();
        private readonly SvgExporter.Class669 class669_0;
        private readonly DrawContext drawContext_0;
        private DxfEntity dxfEntity_0;

        public Class670(DrawContext context, SvgExporter.Class669 outer, DxfEntity entity)
        {
          this.drawContext_0 = context;
          this.class669_0 = outer;
          this.dxfEntity_0 = entity;
        }

        private string CoordinateFormat
        {
          get
          {
            return this.class669_0.string_0;
          }
        }

        private WW.Math.Point2D method_0(Matrix4D transform, WW.Math.Point2D point)
        {
          return transform.TransformTo2D(new WW.Math.Point2D(point.X, point.Y));
        }

        private void method_1(StringBuilder buffer, WW.Math.Point2D point)
        {
          if (buffer.Length > 0 && char.IsDigit(buffer[buffer.Length - 1]))
            buffer.Append(' ');
          buffer.Append(point.X.ToString(this.CoordinateFormat, (IFormatProvider) CultureInfo.InvariantCulture)).Append(' ').Append(point.Y.ToString(this.CoordinateFormat, (IFormatProvider) CultureInfo.InvariantCulture));
        }

        private void method_2(StringBuilder buffer, WW.Math.Point2D point, char command)
        {
          if (buffer.Length > 0)
            buffer.Append(' ');
          buffer.Append(command);
          this.method_1(buffer, point);
        }

        private WW.Math.Point2D method_3(
          StringBuilder buffer,
          Matrix4D transform,
          WW.Math.Point2D point)
        {
          WW.Math.Point2D point1 = this.method_0(transform, point);
          this.method_1(buffer, point1);
          return point1;
        }

        private WW.Math.Point2D method_4(
          StringBuilder buffer,
          Matrix4D transform,
          WW.Math.Point2D point,
          char command)
        {
          if (buffer.Length > 0)
            buffer.Append(' ');
          buffer.Append(command);
          return this.method_3(buffer, transform, point);
        }

        public void DrawPath(IShape4D path, WW.Cad.Model.Color color, short lineWeight)
        {
          if (path.IsEmpty)
            return;
          this.stringBuilder_0.Length = 0;
          WW.Math.Point2D[] points = new WW.Math.Point2D[3];
          WW.Math.Point2D point2D = new WW.Math.Point2D();
          WW.Math.Point2D p0 = new WW.Math.Point2D();
          ISegment2DIterator iterator = path.CreateIterator(Matrix4D.Identity);
          while (iterator.MoveNext())
          {
            switch (iterator.Current(points, 0))
            {
              case SegmentType.MoveTo:
                this.method_2(this.stringBuilder_0, points[0], 'M');
                point2D = p0 = points[0];
                continue;
              case SegmentType.LineTo:
                this.method_2(this.stringBuilder_0, points[0], 'L');
                p0 = points[0];
                continue;
              case SegmentType.QuadTo:
                Pair<WW.Math.Point2D, WW.Math.Point2D> cubicBezier = ShapeTool.QuadToCubicBezier(p0, points[0], points[1]);
                this.method_2(this.stringBuilder_0, cubicBezier.First, 'C');
                this.method_1(this.stringBuilder_0, cubicBezier.Second);
                this.method_1(this.stringBuilder_0, points[1]);
                p0 = points[1];
                continue;
              case SegmentType.CubicTo:
                this.method_2(this.stringBuilder_0, points[0], 'C');
                this.method_1(this.stringBuilder_0, points[1]);
                this.method_1(this.stringBuilder_0, points[2]);
                p0 = points[2];
                continue;
              case SegmentType.Close:
                this.stringBuilder_0.Append(" Z");
                p0 = point2D;
                continue;
              default:
                continue;
            }
          }
          this.class669_0.xmlTextWriter_0.WriteStartElement(nameof (path));
          if (this.class669_0.xmlWriteDelegate_0 != null)
            this.class669_0.xmlWriteDelegate_0(this.class669_0.xmlTextWriter_0, this.dxfEntity_0);
          this.class669_0.xmlTextWriter_0.WriteAttributeString("d", this.stringBuilder_0.ToString());
          string str = this.class669_0.method_17(this.drawContext_0.GetPlotColor(this.dxfEntity_0, color), this.class669_0.bool_1);
          if (path.IsFilled)
          {
            this.class669_0.xmlTextWriter_0.WriteAttributeString("fill", str);
          }
          else
          {
            this.class669_0.xmlTextWriter_0.WriteAttributeString("fill", "none");
            this.class669_0.xmlTextWriter_0.WriteAttributeString("stroke", str);
          }
          this.class669_0.xmlTextWriter_0.WriteEndElement();
        }

        public void DrawPath(
          IShape2D path,
          Matrix4D transform,
          WW.Cad.Model.Color color,
          short lineWeight,
          bool filled,
          bool forText,
          double extrusion)
        {
          if (!path.HasSegments)
            return;
          this.stringBuilder_0.Length = 0;
          WW.Math.Point2D[] points = new WW.Math.Point2D[3];
          WW.Math.Point2D point2D = new WW.Math.Point2D();
          WW.Math.Point2D p0 = new WW.Math.Point2D();
          ISegment2DIterator iterator = path.CreateIterator();
          Matrix4D transform1 = transform;
          while (iterator.MoveNext())
          {
            switch (iterator.Current(points, 0))
            {
              case SegmentType.MoveTo:
                this.method_4(this.stringBuilder_0, transform1, points[0], 'M');
                point2D = p0 = points[0];
                continue;
              case SegmentType.LineTo:
                this.method_4(this.stringBuilder_0, transform1, points[0], 'L');
                p0 = points[0];
                continue;
              case SegmentType.QuadTo:
                Pair<WW.Math.Point2D, WW.Math.Point2D> cubicBezier = ShapeTool.QuadToCubicBezier(p0, points[0], points[1]);
                this.method_4(this.stringBuilder_0, transform1, cubicBezier.First, 'C');
                this.method_3(this.stringBuilder_0, transform1, cubicBezier.Second);
                this.method_3(this.stringBuilder_0, transform1, points[1]);
                p0 = points[1];
                continue;
              case SegmentType.CubicTo:
                this.method_4(this.stringBuilder_0, transform1, points[0], 'C');
                this.method_3(this.stringBuilder_0, transform1, points[1]);
                this.method_3(this.stringBuilder_0, transform1, points[2]);
                p0 = points[2];
                continue;
              case SegmentType.Close:
                this.stringBuilder_0.Append(" Z");
                p0 = point2D;
                continue;
              default:
                continue;
            }
          }
          this.class669_0.xmlTextWriter_0.WriteStartElement(nameof (path));
          if (this.class669_0.xmlWriteDelegate_0 != null)
            this.class669_0.xmlWriteDelegate_0(this.class669_0.xmlTextWriter_0, this.dxfEntity_0);
          this.class669_0.xmlTextWriter_0.WriteAttributeString("d", this.stringBuilder_0.ToString());
          string str = this.class669_0.method_17(this.drawContext_0.GetPlotColor(this.dxfEntity_0, color), this.class669_0.bool_1);
          if (filled)
          {
            this.class669_0.xmlTextWriter_0.WriteAttributeString("fill", str);
          }
          else
          {
            this.class669_0.xmlTextWriter_0.WriteAttributeString("fill", "none");
            this.class669_0.xmlTextWriter_0.WriteAttributeString("stroke", str);
          }
          this.class669_0.xmlTextWriter_0.WriteEndElement();
        }

        public void DrawCharPath(
          IShape2D path,
          Matrix4D transform,
          WW.Cad.Model.Color color,
          short lineWeight,
          bool filled,
          double extrusion)
        {
          this.DrawPath(path, transform, color, lineWeight, filled, true, extrusion);
        }

        public bool IsSeparateCharDrawingPreferred()
        {
          return true;
        }
      }
    }
  }
}
