// Decompiled with JetBrains decompiler
// Type: WW.Cad.IO.PsExporter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns38;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;
using WW.Text;

namespace WW.Cad.IO
{
  public class PsExporter : IWireframeGraphicsFactory
  {
    private const string string_0 = "0.##";
    private const float float_0 = 0.1f;
    public const float CmToInch = 0.3937008f;
    public const float InchToPoint = 72f;
    public const float CmToPoint = 28.34646f;
    private TextWriter textWriter_0;
    private float float_1;
    private float float_2;
    private float float_3;
    private string string_1;
    private GraphicsConfig graphicsConfig_0;
    private ArgbColor? nullable_0;
    private bool bool_0;
    private ArgbColor argbColor_0;
    private ArgbColor argbColor_1;
    private BlinnClipper4D blinnClipper4D_0;
    private PaperSize paperSize_0;

    public PsExporter(Stream stream)
      : this(stream, PaperKind.Letter)
    {
    }

    public PsExporter(Stream stream, PaperKind paperKind)
      : this(stream, PaperSizes.GetPaperSize(paperKind))
    {
    }

    public PsExporter(Stream stream, PaperSize paperSize)
    {
      Class809.smethod_0(Enum15.const_2);
      this.PaperSize = paperSize;
      this.LineWidth = 0.1f;
      this.textWriter_0 = (TextWriter) new StreamWriter(stream, Encodings.Ascii);
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
        this.blinnClipper4D_0 = new BlinnClipper4D(0.0, (double) this.paperSize_0.Width, 0.0, (double) this.paperSize_0.Height, 0.0, 8.88178419700125E-16, false, true);
      }
    }

    public string Title
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

    public void Draw(DxfModel model, GraphicsConfig config, Matrix4D modelToPsTransform)
    {
      this.Draw(model, config, modelToPsTransform, (ProgressEventHandler) null);
    }

    public void Draw(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D modelToPsTransform,
      ProgressEventHandler progressEventHandler)
    {
      this.Write(model, (DxfLayout) null, (ICollection<DxfViewport>) null, config, modelToPsTransform, progressEventHandler);
    }

    public void Draw(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D paperToPsTransform)
    {
      this.Draw(model, layout, viewports, config, paperToPsTransform, (ProgressEventHandler) null);
    }

    public void Draw(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D paperToPsTransform,
      ProgressEventHandler progressEventHandler)
    {
      this.Write(model, layout, viewports, config, paperToPsTransform, progressEventHandler);
    }

    public void BeginEntity(DxfEntity entity, DrawContext.Wireframe drawContext)
    {
    }

    public void EndEntity()
    {
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
      this.method_3(position, color);
    }

    public void CreateLine(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      Vector4D start,
      Vector4D end)
    {
      this.DrawLine(start, end, color);
    }

    public void CreateRay(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      Segment4D segment)
    {
      this.method_4(segment, color);
    }

    public void CreateXLine(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      Vector4D? startPoint,
      Segment4D segment)
    {
      this.method_4(segment, color);
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
      foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polylines)
        this.method_6(polyline, color, fill, correctForBackgroundColor);
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
      this.method_7(polylines, color, fill, correctForBackgroundColor);
    }

    public void CreateShape(
      DxfEntity entity,
      DrawContext.Wireframe drawContext,
      ArgbColor color,
      bool forText,
      IShape4D shape)
    {
      WW.Math.Point2D[] points = new WW.Math.Point2D[3];
      if (shape.IsEmpty)
        return;
      this.textWriter_0.WriteLine("newpath");
      WW.Math.Point2D point2D = new WW.Math.Point2D();
      WW.Math.Point2D p0 = new WW.Math.Point2D();
      ISegment2DIterator iterator = shape.ToShape2D(Matrix4D.Identity).CreateIterator();
      while (iterator.MoveNext())
      {
        switch (iterator.Current(points, 0))
        {
          case SegmentType.MoveTo:
            WW.Math.Point2D p;
            p0 = p = points[0];
            point2D = p;
            this.method_8(p);
            continue;
          case SegmentType.LineTo:
            this.method_9(p0 = points[0]);
            continue;
          case SegmentType.QuadTo:
            Pair<WW.Math.Point2D, WW.Math.Point2D> cubicBezier = ShapeTool.QuadToCubicBezier(p0, points[0], points[1]);
            this.method_10(cubicBezier.First, cubicBezier.Second, p0 = points[1]);
            continue;
          case SegmentType.CubicTo:
            this.method_10(points[0], points[1], p0 = points[2]);
            continue;
          case SegmentType.Close:
            this.textWriter_0.WriteLine("closepath");
            p0 = point2D;
            continue;
          default:
            continue;
        }
      }
      if (shape.IsFilled)
        this.textWriter_0.WriteLine("fill");
      this.textWriter_0.WriteLine("stroke");
    }

    public bool SupportsText
    {
      get
      {
        return false;
      }
    }

    public void CreateText(DxfText text, DrawContext.Wireframe drawContext, ArgbColor color)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public void CreateMText(DxfMText text, DrawContext.Wireframe drawContext)
    {
      throw new Exception("The method or operation is not implemented.");
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

    private void Write(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D postTransform,
      ProgressEventHandler progressEventHandler)
    {
      this.method_0(config);
      this.method_1(model);
      if (layout == null)
      {
        using (DrawContext.Wireframe.ModelSpace modelSpace = new DrawContext.Wireframe.ModelSpace(model, config, postTransform))
        {
          IList<DxfEntity> sortedEntities = model.ModelLayout.GetSortedEntities();
          int count = sortedEntities.Count;
          int num = 0;
          foreach (DxfEntity dxfEntity in (IEnumerable<DxfEntity>) sortedEntities)
          {
            dxfEntity.Draw((DrawContext.Wireframe) modelSpace, (IWireframeGraphicsFactory) this);
            if (num % 100 == 0 && progressEventHandler != null)
              progressEventHandler((object) this, new ProgressEventArgs((float) num / (float) count));
            ++num;
          }
        }
      }
      else
      {
        if (viewports == null)
          viewports = (ICollection<DxfViewport>) layout.Viewports;
        int num1 = model.Entities.Count * viewports.Count + layout.Entities.Count;
        int num2 = 0;
        using (DrawContext.Wireframe.PaperToPaperSpace paperToPaperSpace = new DrawContext.Wireframe.PaperToPaperSpace(model, layout, config, postTransform))
        {
          foreach (DxfEntity sortedEntity in (IEnumerable<DxfEntity>) layout.GetSortedEntities())
          {
            sortedEntity.Draw((DrawContext.Wireframe) paperToPaperSpace, (IWireframeGraphicsFactory) this);
            if (num2 % 100 == 0 && progressEventHandler != null)
              progressEventHandler((object) this, new ProgressEventArgs((float) num2 / (float) num1));
            ++num2;
          }
        }
        IList<DxfEntity> sortedEntities = model.ModelLayout.GetSortedEntities();
        foreach (DxfViewport viewport in (IEnumerable<DxfViewport>) viewports)
        {
          if (viewport.ModelSpaceVisible)
          {
            using (DrawContext.Wireframe.ModelToPaperSpace modelToPaperSpace = new DrawContext.Wireframe.ModelToPaperSpace(model, layout, config, viewport, postTransform))
            {
              foreach (DxfEntity dxfEntity in (IEnumerable<DxfEntity>) sortedEntities)
              {
                dxfEntity.Draw((DrawContext.Wireframe) modelToPaperSpace, (IWireframeGraphicsFactory) this);
                if (num2 % 100 == 0 && progressEventHandler != null)
                  progressEventHandler((object) this, new ProgressEventArgs((float) num2 / (float) num1));
                ++num2;
              }
            }
          }
        }
      }
      this.method_2();
      this.textWriter_0.Close();
    }

    private void method_0(GraphicsConfig config)
    {
      this.graphicsConfig_0 = config;
      this.nullable_0 = this.graphicsConfig_0.FixedForegroundColor;
      this.bool_0 = this.graphicsConfig_0.CorrectColorForBackgroundColor;
      this.argbColor_0 = this.graphicsConfig_0.BackColor;
      this.argbColor_1 = new ArgbColor((int) byte.MaxValue - (int) this.argbColor_0.R, (int) byte.MaxValue - (int) this.argbColor_0.G, (int) byte.MaxValue - (int) this.argbColor_0.B);
    }

    private void method_1(DxfModel model)
    {
      this.textWriter_0.WriteLine("%!PS-Adobe-3.0");
      Assembly entryAssembly = Assembly.GetEntryAssembly();
      if (entryAssembly != (Assembly) null)
      {
        AssemblyName name = entryAssembly.GetName();
        this.textWriter_0.WriteLine("%%Creator: " + name.Name + " " + (object) name.Version);
      }
      AssemblyName name1 = Assembly.GetExecutingAssembly().GetName();
      this.textWriter_0.WriteLine("%%CreationDate: " + DateTime.Now.ToString((IFormatProvider) CultureInfo.InvariantCulture));
      if (this.string_1 != null)
        this.textWriter_0.WriteLine("%%Title: ", (object) this.string_1);
      this.textWriter_0.WriteLine("%%Pages: 1");
      this.textWriter_0.WriteLine("%%Page: 1 1");
      this.textWriter_0.WriteLine("%");
      this.textWriter_0.WriteLine("% Written by library: www.woutware.com " + name1.Name + " " + (object) name1.Version);
      this.textWriter_0.WriteLine("%");
      this.textWriter_0.WriteLine("{0} setlinewidth", (object) this.float_1.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    }

    private void method_2()
    {
      this.textWriter_0.WriteLine("%%EOF");
    }

    private void method_3(Vector4D point, ArgbColor color)
    {
      WW.Math.Point2D point2D = (WW.Math.Point2D) point;
      this.textWriter_0.WriteLine("{0} {1} {2} {3} rectfill", (object) (point2D.X - (double) this.float_3).ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture), (object) (point2D.Y - (double) this.float_3).ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture), (object) this.float_2.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture), (object) this.float_2.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
      this.method_11(color, true);
    }

    private void DrawLine(Vector4D start, Vector4D end, ArgbColor color)
    {
      WW.Math.Point2D p1 = (WW.Math.Point2D) start;
      WW.Math.Point2D p2 = (WW.Math.Point2D) end;
      this.textWriter_0.WriteLine("newpath");
      this.method_8(p1);
      this.method_9(p2);
      this.textWriter_0.WriteLine("stroke");
    }

    private void method_4(Segment4D segment, ArgbColor color)
    {
      this.method_5(segment.Start, segment.End, color);
    }

    private void method_5(Vector4D start, Vector4D end, ArgbColor color)
    {
      foreach (Segment4D segment4D in (IEnumerable<Segment4D>) this.blinnClipper4D_0.Clip(new Segment4D(start, end)))
      {
        start = segment4D.Start;
        end = segment4D.End;
        this.textWriter_0.WriteLine("newpath");
        this.method_8(new WW.Math.Point2D(start.X, start.Y));
        this.method_9(new WW.Math.Point2D(end.X, end.Y));
        this.textWriter_0.WriteLine("stroke");
      }
    }

    private bool method_6(
      Polyline4D polyline,
      ArgbColor color,
      bool fill,
      bool correctForBackgroundColor)
    {
      if (polyline.Count < 2)
        return false;
      WW.Math.Point2D p = (WW.Math.Point2D) polyline[0];
      this.textWriter_0.WriteLine("newpath");
      this.method_8(p);
      for (int index = 1; index < polyline.Count; ++index)
        this.method_9((WW.Math.Point2D) polyline[index]);
      if (polyline.Closed)
        this.textWriter_0.WriteLine("closepath");
      this.method_11(color, correctForBackgroundColor);
      if (fill)
        this.textWriter_0.WriteLine(nameof (fill));
      this.textWriter_0.WriteLine("stroke");
      return true;
    }

    private bool method_7(
      IList<Polyline4D> polylines,
      ArgbColor color,
      bool fill,
      bool correctForBackgroundColor)
    {
      this.textWriter_0.WriteLine("newpath");
      foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polylines)
      {
        if (polyline.Count >= 2)
        {
          this.method_8((WW.Math.Point2D) polyline[0]);
          for (int index = 1; index < polyline.Count; ++index)
            this.method_9((WW.Math.Point2D) polyline[index]);
          if (polyline.Closed)
            this.textWriter_0.WriteLine("closepath");
        }
      }
      this.method_11(color, correctForBackgroundColor);
      if (fill)
        this.textWriter_0.WriteLine(nameof (fill));
      this.textWriter_0.WriteLine("stroke");
      return true;
    }

    private void method_8(WW.Math.Point2D p)
    {
      this.textWriter_0.WriteLine("{0} {1} moveto", (object) p.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture), (object) p.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
    }

    private void method_9(WW.Math.Point2D p)
    {
      this.textWriter_0.WriteLine("{0} {1} lineto", (object) p.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture), (object) p.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
    }

    private void method_10(WW.Math.Point2D p1, WW.Math.Point2D p2, WW.Math.Point2D p3)
    {
      this.textWriter_0.WriteLine("{0} {1} {2} {3} {4} {5} curveto", (object) p1.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture), (object) p1.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture), (object) p2.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture), (object) p2.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture), (object) p3.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture), (object) p3.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
    }

    private string method_11(ArgbColor color, bool correctForBackgroundColor)
    {
      if (this.nullable_0.HasValue)
        color = this.nullable_0.Value;
      else if (correctForBackgroundColor && this.bool_0 && color == this.argbColor_0)
        color = this.argbColor_1;
      return string.Format("{0} {1} {2} setrgbcolor", (object) (float) ((double) color.R / (double) byte.MaxValue), (object) (float) ((double) color.G / (double) byte.MaxValue), (object) (float) ((double) color.B / (double) byte.MaxValue));
    }
  }
}
