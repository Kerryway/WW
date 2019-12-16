// Decompiled with JetBrains decompiler
// Type: WW.Cad.IO.XamlExporter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns38;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.IO
{
  public class XamlExporter
  {
    private string string_2 = "0.##";
    private XmlTextWriter xmlTextWriter_0;
    private string string_0;
    private string string_1;
    private Matrix4D matrix4D_0;
    private GraphicsConfig graphicsConfig_0;
    private ArgbColor? nullable_0;
    private bool bool_0;
    private ArgbColor argbColor_0;
    private ArgbColor argbColor_1;
    private double double_0;
    private double double_1;
    private XamlExporter.Class353 class353_0;

    public XamlExporter(Stream stream)
    {
      Class809.smethod_0(Enum15.const_3);
      this.class353_0 = new XamlExporter.Class353(this);
      this.xmlTextWriter_0 = new XmlTextWriter(stream, Encoding.UTF8);
      this.xmlTextWriter_0.Formatting = Formatting.Indented;
    }

    public XamlExporter(XmlTextWriter writer)
    {
      Class809.smethod_0(Enum15.const_3);
      this.class353_0 = new XamlExporter.Class353(this);
      this.xmlTextWriter_0 = writer;
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

    public void Draw(DxfModel model, GraphicsConfig config, Matrix4D modelToXamlTransform)
    {
      this.Draw(model, config, modelToXamlTransform, (ProgressEventHandler) null);
    }

    public void Draw(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D modelToXamlTransform,
      ProgressEventHandler progressEventHandler)
    {
      this.matrix4D_0 = modelToXamlTransform;
      this.Write(model, (DxfLayout) null, (ICollection<DxfViewport>) null, config, progressEventHandler);
    }

    public void Draw(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D paperToXamlTransform)
    {
      this.Draw(model, layout, viewports, config, paperToXamlTransform, (ProgressEventHandler) null);
    }

    public void Draw(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      Matrix4D paperToXamlTransform,
      ProgressEventHandler progressEventHandler)
    {
      this.matrix4D_0 = paperToXamlTransform;
      this.Write(model, layout, viewports, config, progressEventHandler);
      this.matrix4D_0 = Matrix4D.Identity;
    }

    private void Write(
      DxfModel model,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      GraphicsConfig config,
      ProgressEventHandler progressEventHandler)
    {
      this.method_0(config);
      if (layout == null)
      {
        using (DrawContext.Wireframe.ModelSpace modelSpace = new DrawContext.Wireframe.ModelSpace(model, config, Matrix4D.Identity))
        {
          IList<DxfEntity> sortedEntities = model.ModelLayout.GetSortedEntities();
          int count = sortedEntities.Count;
          int num = 0;
          foreach (DxfEntity dxfEntity in (IEnumerable<DxfEntity>) sortedEntities)
          {
            dxfEntity.Draw((DrawContext.Wireframe) modelSpace, (IWireframeGraphicsFactory2) this.class353_0);
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
        using (DrawContext.Wireframe.PaperToPaperSpace paperToPaperSpace = new DrawContext.Wireframe.PaperToPaperSpace(model, layout, config, Matrix4D.Identity))
        {
          foreach (DxfEntity sortedEntity in (IEnumerable<DxfEntity>) layout.GetSortedEntities())
          {
            sortedEntity.Draw((DrawContext.Wireframe) paperToPaperSpace, (IWireframeGraphicsFactory2) this.class353_0);
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
            using (DrawContext.Wireframe.ModelToPaperSpace modelToPaperSpace = new DrawContext.Wireframe.ModelToPaperSpace(model, layout, config, viewport, Matrix4D.Identity))
            {
              foreach (DxfEntity dxfEntity in (IEnumerable<DxfEntity>) sortedEntities)
              {
                dxfEntity.Draw((DrawContext.Wireframe) modelToPaperSpace, (IWireframeGraphicsFactory2) this.class353_0);
                if (num2 % 100 == 0 && progressEventHandler != null)
                  progressEventHandler((object) this, new ProgressEventArgs((float) num2 / (float) num1));
                ++num2;
              }
            }
          }
        }
      }
    }

    private void method_0(GraphicsConfig config)
    {
      this.graphicsConfig_0 = config;
      this.nullable_0 = this.graphicsConfig_0.FixedForegroundColor;
      this.bool_0 = this.graphicsConfig_0.CorrectColorForBackgroundColor;
      this.argbColor_0 = this.graphicsConfig_0.BackColor;
      this.argbColor_1 = new ArgbColor((int) byte.MaxValue - this.argbColor_0.Red, (int) byte.MaxValue - this.argbColor_0.Green, (int) byte.MaxValue - this.argbColor_0.Blue);
    }

    private class Class353 : IWireframeGraphicsFactory2
    {
      private Stack<XamlExporter.Class354> stack_0 = new Stack<XamlExporter.Class354>();
      private XamlExporter xamlExporter_0;
      private double double_0;
      private double double_1;
      private string string_0;
      private string string_1;

      public Class353(XamlExporter exporter)
      {
        this.xamlExporter_0 = exporter;
        this.double_0 = exporter.double_1;
        this.double_1 = 0.5 * this.double_0;
        this.string_0 = this.double_0.ToString(exporter.string_2, (IFormatProvider) CultureInfo.InvariantCulture);
        this.string_1 = (0.5 * this.double_0).ToString(exporter.string_2, (IFormatProvider) CultureInfo.InvariantCulture);
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
        XamlExporter.Class354 class354 = new XamlExporter.Class354();
        class354.Color = color;
        class354.Fill = fill;
        class354.Stroke = stroke;
        if (stroke)
          class354.StrokeThickness = this.method_0(entity, (DrawContext) drawContext, forText);
        this.stack_0.Push(class354);
      }

      public void EndGeometry()
      {
        this.stack_0.Pop().Write(this.xamlExporter_0);
      }

      public void CreateDot(DxfEntity entity, Vector4D position)
      {
        this.method_1(position);
      }

      public void CreateLine(DxfEntity entity, Vector4D start, Vector4D end)
      {
        this.DrawLine(start, end);
      }

      public void CreateRay(DxfEntity entity, Segment4D segment)
      {
        this.method_2(segment);
      }

      public void CreateXLine(DxfEntity entity, Vector4D? startPoint, Segment4D segment)
      {
        this.method_2(segment);
      }

      public void CreatePolyline(DxfEntity entity, Polyline4D polyline)
      {
        this.method_4(polyline);
      }

      public void CreateShape(DxfEntity entity, IShape4D shape)
      {
        this.method_5(shape);
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
        if (this.xamlExporter_0.graphicsConfig_0.DisplayLineWeight)
        {
          short num2 = drawContext.GetLineWeight(entity);
          if (num2 == (short) 0)
            num2 = this.xamlExporter_0.graphicsConfig_0.DefaultLineWeight;
          num1 = this.xamlExporter_0.graphicsConfig_0.DotsPerHundredthMm * (double) num2;
        }
        else
          num1 = !forText ? this.xamlExporter_0.double_1 : this.xamlExporter_0.double_0;
        return num1;
      }

      private void method_1(Vector4D point)
      {
        WW.Math.Point2D point2D = this.method_6(point);
        string str1 = (point2D.X - this.double_1).ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture);
        string str2 = (point2D.X + this.double_1).ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture);
        string str3 = point2D.Y.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture);
        StringBuilder stringBuilder = this.stack_0.Peek().StringBuilder;
        stringBuilder.Append('M');
        stringBuilder.Append(str1);
        stringBuilder.Append(',');
        stringBuilder.Append(str3);
        stringBuilder.Append('A');
        stringBuilder.Append(this.string_1);
        stringBuilder.Append(',');
        stringBuilder.Append(this.string_1);
        stringBuilder.Append(" 180 1 1 ");
        stringBuilder.Append(str2);
        stringBuilder.Append(',');
        stringBuilder.Append(str3);
        stringBuilder.Append('A');
        stringBuilder.Append(this.string_1);
        stringBuilder.Append(',');
        stringBuilder.Append(this.string_1);
        stringBuilder.Append(" 180 1 1 ");
        stringBuilder.Append(str1);
        stringBuilder.Append(',');
        stringBuilder.Append(str3);
        stringBuilder.Append('Z');
      }

      private void DrawLine(Vector4D start, Vector4D end)
      {
        WW.Math.Point2D point2D1 = this.method_6(start);
        WW.Math.Point2D point2D2 = this.method_6(end);
        StringBuilder stringBuilder = this.stack_0.Peek().StringBuilder;
        stringBuilder.Append('M');
        stringBuilder.Append(point2D1.X.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(',');
        stringBuilder.Append(point2D1.Y.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append('L');
        stringBuilder.Append(point2D2.X.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(',');
        stringBuilder.Append(point2D2.Y.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
      }

      private void method_2(Segment4D segment)
      {
        this.method_3(this.xamlExporter_0.matrix4D_0.Transform(segment.Start), this.xamlExporter_0.matrix4D_0.Transform(segment.End));
      }

      private void method_3(Vector4D start, Vector4D end)
      {
      }

      private bool method_4(Polyline4D polyline)
      {
        if (polyline.Count < 2)
          return false;
        StringBuilder stringBuilder = this.stack_0.Peek().StringBuilder;
        WW.Math.Point2D point2D = this.method_6(polyline[0]);
        stringBuilder.Append('M');
        stringBuilder.Append(point2D.X.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(',');
        stringBuilder.Append(point2D.Y.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
        for (int index = 1; index < polyline.Count; ++index)
        {
          point2D = this.method_6(polyline[index]);
          stringBuilder.Append("L");
          stringBuilder.Append(point2D.X.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
          stringBuilder.Append(',');
          stringBuilder.Append(point2D.Y.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
        }
        if (polyline.Closed)
          stringBuilder.Append(" z");
        return true;
      }

      private bool method_5(IShape4D shape)
      {
        if (shape.IsEmpty)
          return false;
        StringBuilder stringBuilder = this.stack_0.Peek().StringBuilder;
        WW.Math.Point2D[] points = new WW.Math.Point2D[3];
        SegmentType segmentType = SegmentType.MoveTo;
        ISegment2DIterator iterator = shape.CreateIterator(this.xamlExporter_0.matrix4D_0);
        while (iterator.MoveNext())
        {
          switch (iterator.Current(points, 0))
          {
            case SegmentType.MoveTo:
              stringBuilder.Append('M');
              stringBuilder.Append(points[0].X.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(',');
              stringBuilder.Append(points[0].Y.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
              segmentType = SegmentType.MoveTo;
              break;
            case SegmentType.LineTo:
              if (segmentType != SegmentType.LineTo)
                stringBuilder.Append('L');
              stringBuilder.Append(points[0].X.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(',');
              stringBuilder.Append(points[0].Y.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
              segmentType = SegmentType.LineTo;
              break;
            case SegmentType.QuadTo:
              if (segmentType != SegmentType.QuadTo)
                stringBuilder.Append('Q');
              stringBuilder.Append(points[0].X.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(',');
              stringBuilder.Append(points[0].Y.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(' ');
              stringBuilder.Append(points[1].X.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(',');
              stringBuilder.Append(points[1].Y.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
              segmentType = SegmentType.QuadTo;
              break;
            case SegmentType.CubicTo:
              if (segmentType != SegmentType.CubicTo)
                stringBuilder.Append('C');
              stringBuilder.Append(points[0].X.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(',');
              stringBuilder.Append(points[0].Y.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(' ');
              stringBuilder.Append(points[1].X.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(',');
              stringBuilder.Append(points[1].Y.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(' ');
              stringBuilder.Append(points[2].X.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(',');
              stringBuilder.Append(points[2].Y.ToString(this.xamlExporter_0.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
              segmentType = SegmentType.CubicTo;
              break;
            case SegmentType.Close:
              stringBuilder.Append('Z');
              segmentType = SegmentType.Close;
              break;
          }
          stringBuilder.Append(' ');
        }
        return true;
      }

      private WW.Math.Point2D method_6(Vector4D point)
      {
        return this.xamlExporter_0.matrix4D_0.TransformToPoint2D(point);
      }
    }

    internal class Class354
    {
      private StringBuilder stringBuilder_0 = new StringBuilder();
      private bool bool_0;
      private double double_0;
      private bool bool_1;
      private ArgbColor argbColor_0;

      public StringBuilder StringBuilder
      {
        get
        {
          return this.stringBuilder_0;
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

      public double StrokeThickness
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

      public ArgbColor Color
      {
        get
        {
          return this.argbColor_0;
        }
        set
        {
          this.argbColor_0 = value;
        }
      }

      public void Write(XamlExporter exporter)
      {
        XmlTextWriter xmlTextWriter0 = exporter.xmlTextWriter_0;
        xmlTextWriter0.WriteStartElement("Path");
        xmlTextWriter0.WriteAttributeString("Data", this.stringBuilder_0.ToString());
        string str = XamlExporter.Class354.smethod_0(exporter, this.argbColor_0);
        if (this.bool_1)
          xmlTextWriter0.WriteAttributeString("Fill", str);
        if (this.bool_0)
        {
          xmlTextWriter0.WriteAttributeString("Stroke", str);
          xmlTextWriter0.WriteAttributeString("StrokeThickness", this.double_0.ToString(exporter.string_2, (IFormatProvider) CultureInfo.InvariantCulture));
        }
        xmlTextWriter0.WriteEndElement();
      }

      private static string smethod_0(XamlExporter exporter, ArgbColor color)
      {
        if (exporter.nullable_0.HasValue)
          color = exporter.nullable_0.Value;
        else if (exporter.bool_0 && color.Argb == exporter.argbColor_0.Argb)
          color = exporter.argbColor_1;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append('#');
        stringBuilder.Append(color.R.ToString("X2"));
        stringBuilder.Append(color.G.ToString("X2"));
        stringBuilder.Append(color.B.ToString("X2"));
        return stringBuilder.ToString();
      }
    }
  }
}
