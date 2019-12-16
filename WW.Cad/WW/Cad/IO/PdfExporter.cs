// Decompiled with JetBrains decompiler
// Type: WW.Cad.IO.PdfExporter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns38;
using ns4;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;
using WW.Pdf;
using WW.Pdf.Components;
using WW.Pdf.Filter;
using WW.Pdf.Font;

namespace WW.Cad.IO
{
  public class PdfExporter
  {
    private string string_1 = string.Empty;
    private string string_2 = string.Empty;
    private bool bool_0 = true;
    private float float_4 = 0.02834646f;
    private double double_0 = 2.0;
    private bool bool_3 = true;
    private string string_3 = "Page {0}";
    private const string string_0 = "0.##";
    public const float CmToInch = 0.3937008f;
    public const float InchToPixel = 72f;
    public const float CmToPixel = 28.34646f;
    private Stream stream_0;
    private float float_0;
    private float float_1;
    private float float_2;
    private float float_3;
    private bool bool_1;
    private bool bool_2;
    private PdfDocument pdfDocument_0;
    private PdfBody pdfBody_0;
    private bool bool_4;
    private PdfExporter.Class32 class32_0;
    private IComparer<DxfLayer> icomparer_0;
    private Func<DxfLayer, bool> func_0;

    public PdfExporter(Stream stream)
    {
      Class809.smethod_0(Enum15.const_2);
      this.LineWidth = 0.1f;
      this.DotSize = 0.1f;
      this.TextLineWidth = 0.1f;
      this.stream_0 = stream;
    }

    public bool AutoCloseStream
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

    public string Author
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

    public float LineWidth
    {
      get
      {
        return this.float_0;
      }
      set
      {
        this.float_0 = value;
      }
    }

    public float DotSize
    {
      get
      {
        return this.float_2;
      }
      set
      {
        this.float_2 = value;
        this.float_3 = 0.5f * value;
      }
    }

    public float TextLineWidth
    {
      get
      {
        return this.float_1;
      }
      set
      {
        this.float_1 = value;
      }
    }

    public PdfDocument Document
    {
      get
      {
        return this.pdfDocument_0;
      }
    }

    public PdfBody Body
    {
      get
      {
        return this.pdfBody_0;
      }
    }

    public float ModelSpaceLineWeightToPdfPixels
    {
      get
      {
        return this.float_4;
      }
      set
      {
        this.float_4 = value;
      }
    }

    public double ScalableImagePixelsPerPdfPixel
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

    [Obsolete("This setting will be removed in the future.")]
    public bool UseMultipleLayers
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

    public bool ExportLayers
    {
      get
      {
        return this.bool_4;
      }
      set
      {
        this.bool_4 = value;
      }
    }

    public string PageFormatString
    {
      get
      {
        return this.string_3;
      }
      set
      {
        this.string_3 = value;
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

    public Func<DxfLayer, bool> IsPdfLayerEnabledFunction
    {
      get
      {
        return this.func_0;
      }
      set
      {
        this.func_0 = value;
      }
    }

    public bool EmbedFonts
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

    public bool PackContent
    {
      get
      {
        return this.bool_3;
      }
      set
      {
        this.bool_3 = value;
      }
    }

    public void EndDocument()
    {
      if (this.pdfBody_0 == null)
        this.method_2();
      new PdfWriter(this.pdfDocument_0, this.stream_0, 15).Write(this.bool_0);
      this.pdfDocument_0.Dispose();
      this.pdfDocument_0 = (PdfDocument) null;
      this.pdfBody_0 = (PdfBody) null;
      this.stream_0 = (Stream) null;
    }

    public void DrawPage(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D modelToPdfTransform,
      PaperSize paperSize)
    {
      this.DrawPage(model, config, modelToPdfTransform, paperSize, (ProgressEventHandler) null);
    }

    public void DrawPage(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D modelToPdfTransform,
      PaperSize paperSize,
      ProgressEventHandler progressEventHandler)
    {
      this.method_0(new PdfPageConfiguration(model, config, modelToPdfTransform, paperSize), progressEventHandler);
    }

    public void DrawPage(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D paperToPdfTransform,
      double paperToPdfScaleFactor,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      PaperSize paperSize)
    {
      this.DrawPage(model, config, paperToPdfTransform, paperToPdfScaleFactor, layout, viewports, paperSize, (ProgressEventHandler) null);
    }

    public void DrawPage(
      DxfModel model,
      GraphicsConfig config,
      Matrix4D paperToPdfTransform,
      double paperToPdfScaleFactor,
      DxfLayout layout,
      ICollection<DxfViewport> viewports,
      PaperSize paperSize,
      ProgressEventHandler progressEventHandler)
    {
      this.method_0(new PdfPageConfiguration(model, config, paperToPdfTransform, paperSize)
      {
        DrawingUnitsToPdfUnits = paperToPdfScaleFactor,
        Layout = layout,
        Viewports = viewports
      }, progressEventHandler);
    }

    public void DrawPage(PdfPageConfiguration pageConfiguration)
    {
      if (pageConfiguration == null)
        throw new ArgumentNullException(nameof (pageConfiguration));
      this.method_0(pageConfiguration, (ProgressEventHandler) null);
    }

    public void DrawPage(
      PdfPageConfiguration pageConfiguration,
      ProgressEventHandler progressEventHandler)
    {
      if (pageConfiguration == null)
        throw new ArgumentNullException(nameof (pageConfiguration));
      this.method_0(pageConfiguration, progressEventHandler);
    }

    private PdfExporter.Class32 ExportLayerHelper
    {
      get
      {
        return this.class32_0;
      }
    }

    private void method_0(
      PdfPageConfiguration pageConfiguration,
      ProgressEventHandler progressEventHandler)
    {
      if (this.pdfBody_0 == null)
        this.method_2();
      PdfPage pdfPage = new PdfPage(this.pdfBody_0.Pages);
      this.pdfBody_0.IndirectObjects.Add((IPdfIndirectObject) pdfPage);
      this.pdfBody_0.Pages.Kids.Add((IPdfObject) new PdfReference((IPdfIndirectObject) pdfPage));
      pdfPage.MediaBox.Add((IPdfObject) new PdfInt(0));
      pdfPage.MediaBox.Add((IPdfObject) new PdfInt(0));
      pdfPage.MediaBox.Add((IPdfObject) new PdfReal((double) pageConfiguration.PaperSize.Width * 0.72));
      pdfPage.MediaBox.Add((IPdfObject) new PdfReal((double) pageConfiguration.PaperSize.Height * 0.72));
      pdfPage.Resources.Add("ProcSet", (IPdfObject) new PdfReference((IPdfIndirectObject) this.pdfBody_0.ProcedureSetArray));
      float lineWeightToPdfPixels = pageConfiguration.Layout == null || !pageConfiguration.Layout.PaperSpace ? this.float_4 : (float) (pageConfiguration.Layout.GetLineWeightUnitsToPaperUnits() * pageConfiguration.DrawingUnitsToPdfUnits);
      PdfContentStream pdfContentStream = new PdfContentStream();
      if (this.bool_3)
        pdfContentStream.AddFilter((WW.Pdf.IFilter) new FlateFilter());
      PdfContents pdfContents = new PdfContents(pdfContentStream);
      this.pdfBody_0.IndirectObjects.Add((IPdfIndirectObject) pdfContents);
      pdfPage.Contents = pdfContents;
      PdfExporter.Class33 streamWriter = new PdfExporter.Class33(this, pdfPage, pageConfiguration.PaperSize, lineWeightToPdfPixels, pageConfiguration.GraphicsConfig, this.bool_1);
      if (pageConfiguration.GraphicsConfig.BackColor != ArgbColors.White && pageConfiguration.GraphicsConfig.BackColor.A != (byte) 0)
        streamWriter.method_3(pageConfiguration.GraphicsConfig.BackColor);
      if (this.bool_4)
        this.class32_0 = new PdfExporter.Class32(this, pageConfiguration.Model, streamWriter, pdfPage, this.pdfBody_0.Catalog, this.pdfBody_0, this.pdfBody_0.Pages.Kids.Count);
      if (pageConfiguration.Layout != null && pageConfiguration.Layout.PaperSpace)
      {
        if (pageConfiguration.Viewports == null)
          pageConfiguration.Viewports = (ICollection<DxfViewport>) pageConfiguration.Layout.Viewports;
        int count = pageConfiguration.Layout.Entities.Count;
        foreach (DxfViewport viewport in (IEnumerable<DxfViewport>) pageConfiguration.Viewports)
        {
          if (viewport.ModelSpaceVisible)
            count += pageConfiguration.Model.Entities.Count;
        }
        bool flag = (pageConfiguration.Layout.PlotLayoutFlags & PlotLayoutFlags.DrawViewportsFirst) != PlotLayoutFlags.None;
        int i = 0;
        using (DrawContext.Wireframe.PaperToPaperSpace paperSpaceContext = new DrawContext.Wireframe.PaperToPaperSpace(pageConfiguration.Model, pageConfiguration.Layout, pageConfiguration.GraphicsConfig, pageConfiguration.Transform))
        {
          if (flag)
            this.method_1(paperSpaceContext, pageConfiguration, progressEventHandler, streamWriter, ref i, count);
          foreach (DxfEntity sortedEntity in (IEnumerable<DxfEntity>) pageConfiguration.Layout.GetSortedEntities())
          {
            if (this.bool_4)
              this.class32_0.CurrentLayer = sortedEntity.GetLayer((DrawContext) paperSpaceContext);
            sortedEntity.Draw((DrawContext.Wireframe) paperSpaceContext, (IWireframeGraphicsFactory) streamWriter);
            if (i % 100 == 0 && progressEventHandler != null)
              progressEventHandler((object) this, new ProgressEventArgs((float) i / (float) count));
            ++i;
          }
          if (this.bool_4)
            this.class32_0.CurrentLayer = pageConfiguration.Model.ZeroLayer;
          pageConfiguration.Layout.DrawFrame((DrawContext.Wireframe) paperSpaceContext, (IWireframeGraphicsFactory) streamWriter);
          if (!flag)
            this.method_1(paperSpaceContext, pageConfiguration, progressEventHandler, streamWriter, ref i, count);
        }
        if (this.bool_4)
          this.class32_0.method_3();
      }
      else
      {
        using (DrawContext.Wireframe.ModelSpace modelSpace = new DrawContext.Wireframe.ModelSpace(pageConfiguration.Model, pageConfiguration.GraphicsConfig, pageConfiguration.Transform))
        {
          IList<DxfEntity> sortedEntities = pageConfiguration.Model.ModelLayout.GetSortedEntities();
          int count = sortedEntities.Count;
          int num = 0;
          foreach (DxfEntity dxfEntity in (IEnumerable<DxfEntity>) sortedEntities)
          {
            dxfEntity.Draw((DrawContext.Wireframe) modelSpace, (IWireframeGraphicsFactory) streamWriter);
            if (num % 100 == 0 && progressEventHandler != null)
              progressEventHandler((object) this, new ProgressEventArgs((float) num / (float) count));
            ++num;
          }
          if (this.bool_4)
            this.class32_0.method_3();
        }
      }
      if (pageConfiguration.ClipRectangle.HasValue)
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append((pageConfiguration.ClipRectangle.Value.X1 * 0.72).ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(' ');
        stringBuilder.Append((pageConfiguration.ClipRectangle.Value.Y1 * 0.72).ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(' ');
        stringBuilder.Append((pageConfiguration.ClipRectangle.Value.Width * 0.72).ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(' ');
        stringBuilder.Append((pageConfiguration.ClipRectangle.Value.Height * 0.72).ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(" re");
        pdfContentStream.XOut.WriteLine(stringBuilder.ToString());
        pdfContentStream.XOut.WriteLine("W n");
      }
      streamWriter.Write(this, pdfContentStream);
    }

    private void method_1(
      DrawContext.Wireframe.PaperToPaperSpace paperSpaceContext,
      PdfPageConfiguration pageConfiguration,
      ProgressEventHandler progressEventHandler,
      PdfExporter.Class33 streamWriter,
      ref int i,
      int n)
    {
      IList<DxfEntity> sortedEntities = pageConfiguration.Model.ModelLayout.GetSortedEntities();
      foreach (DxfViewport viewport in (IEnumerable<DxfViewport>) pageConfiguration.Viewports)
      {
        if (viewport.ModelSpaceVisible)
        {
          using (DrawContext.Wireframe.ModelToPaperSpace modelToPaperSpace = new DrawContext.Wireframe.ModelToPaperSpace(pageConfiguration.Model, pageConfiguration.Layout, pageConfiguration.GraphicsConfig, viewport, pageConfiguration.Transform))
          {
            streamWriter.method_16(paperSpaceContext, viewport);
            foreach (DxfEntity dxfEntity in (IEnumerable<DxfEntity>) sortedEntities)
            {
              if (this.bool_4)
                this.class32_0.CurrentLayer = dxfEntity.GetLayer((DrawContext) modelToPaperSpace);
              dxfEntity.Draw((DrawContext.Wireframe) modelToPaperSpace, (IWireframeGraphicsFactory) streamWriter);
              if (i % 100 == 0 && progressEventHandler != null)
                progressEventHandler((object) this, new ProgressEventArgs((float) i / (float) n));
              ++i;
            }
            streamWriter.method_18(paperSpaceContext, viewport);
          }
        }
      }
    }

    private void method_2()
    {
      this.pdfDocument_0 = new PdfDocument();
      this.pdfBody_0 = new PdfBody(this.bool_2 ? FontType.Subset : FontType.Link);
      this.pdfDocument_0.Bodies.Add(this.pdfBody_0);
      PdfDocumentInformation documentInformation = new PdfDocumentInformation();
      this.pdfBody_0.DocumentInformation = documentInformation;
      documentInformation.Title = this.string_1;
      documentInformation.Author = this.string_2;
      Assembly entryAssembly = Assembly.GetEntryAssembly();
      if (entryAssembly != (Assembly) null)
      {
        AssemblyName name = entryAssembly.GetName();
        documentInformation.Creator = name.Name + " " + (object) name.Version;
      }
      AssemblyName name1 = Assembly.GetExecutingAssembly().GetName();
      documentInformation.Producer = "www.woutware.com " + name1.Name + " " + (object) name1.Version;
      documentInformation.CreationDate = DateTime.Now.ToString((IFormatProvider) CultureInfo.InvariantCulture);
    }

    private class Class32
    {
      private readonly List<DxfLayer> list_0 = new List<DxfLayer>();
      private readonly Dictionary<DxfLayer, PdfOptionalContentGroup> dictionary_0 = new Dictionary<DxfLayer, PdfOptionalContentGroup>();
      private readonly List<PdfOptionalContentGroup> list_1 = new List<PdfOptionalContentGroup>();
      private int int_1 = -1;
      private readonly PdfExporter pdfExporter_0;
      private readonly DxfModel dxfModel_0;
      private readonly PdfExporter.Class33 class33_0;
      private readonly PdfPage pdfPage_0;
      private readonly PdfCatalog pdfCatalog_0;
      private readonly PdfBody pdfBody_0;
      private readonly int int_0;

      public Class32(
        PdfExporter pdfExporter,
        DxfModel model,
        PdfExporter.Class33 streamWriter,
        PdfPage currentPage,
        PdfCatalog catalog,
        PdfBody body,
        int pageNumber)
      {
        this.pdfExporter_0 = pdfExporter;
        this.dxfModel_0 = model;
        this.class33_0 = streamWriter;
        this.pdfPage_0 = currentPage;
        this.pdfCatalog_0 = catalog;
        this.pdfBody_0 = body;
        this.int_0 = pageNumber;
      }

      private void method_0()
      {
        string str = "oc" + this.int_1.ToString();
        this.class33_0.method_1(str);
        if (this.pdfPage_0.Resources.Properties == null)
        {
          this.pdfPage_0.Resources.Properties = new PdfPropertiesDictionary();
          this.pdfBody_0.IndirectObjects.Add((IPdfIndirectObject) this.pdfPage_0.Resources.Properties);
        }
        if (((Dictionary<string, IPdfObject>) this.pdfPage_0.Resources.Properties.Value).ContainsKey(str))
          return;
        PdfOptionalContentGroup ocg = new PdfOptionalContentGroup();
        this.pdfBody_0.IndirectObjects.Add((IPdfIndirectObject) ocg);
        ocg.Name.Value = this.CurrentLayer.Name;
        this.list_1.Add(ocg);
        this.dictionary_0.Add(this.CurrentLayer, ocg);
        this.pdfPage_0.Resources.Properties.AddProperty(str, new PdfReference((IPdfIndirectObject) ocg));
        this.method_1();
        this.pdfCatalog_0.OptionalContentProperties.Register(ocg, true);
      }

      private void method_1()
      {
        if (this.pdfCatalog_0.OptionalContentProperties != null)
          return;
        this.pdfCatalog_0.OptionalContentProperties = new PdfOptionalContentPropertiesDictionary();
        this.pdfBody_0.IndirectObjects.Add((IPdfIndirectObject) this.pdfCatalog_0.OptionalContentProperties);
        this.pdfCatalog_0.OptionalContentProperties.Dictionary = new PdfOptionalContentConfigurationDictionary();
        this.pdfBody_0.IndirectObjects.Add((IPdfIndirectObject) this.pdfCatalog_0.OptionalContentProperties.Dictionary);
      }

      private void method_2()
      {
        this.class33_0.method_2();
      }

      public void method_3()
      {
        if (this.int_1 != -1)
          this.method_2();
        this.method_1();
        PdfArray order = this.pdfCatalog_0.OptionalContentProperties.Dictionary.Order;
        PdfArray pdfArray = new PdfArray();
        order.Add((IPdfObject) pdfArray);
        pdfArray.Add((IPdfObject) new PdfLiteralString(string.Format(this.pdfExporter_0.string_3, (object) this.int_0)));
        List<DxfLayer> dxfLayerList;
        if (this.pdfExporter_0.icomparer_0 != null)
        {
          dxfLayerList = new List<DxfLayer>((IEnumerable<DxfLayer>) this.list_0);
          dxfLayerList.Sort(this.pdfExporter_0.icomparer_0);
        }
        else
        {
          dxfLayerList = new List<DxfLayer>(this.list_0.Count);
          foreach (DxfLayer layer in (KeyedDxfHandledObjectCollection<string, DxfLayer>) this.dxfModel_0.Layers)
          {
            if (this.list_0.Contains(layer))
              dxfLayerList.Add(layer);
          }
        }
        foreach (DxfLayer index in dxfLayerList)
        {
          PdfOptionalContentGroup optionalContentGroup = this.dictionary_0[index];
          pdfArray.Add((IPdfObject) new PdfReference((IPdfIndirectObject) optionalContentGroup));
          PdfReference pdfReference = new PdfReference((IPdfIndirectObject) optionalContentGroup);
          if (!(this.pdfExporter_0.func_0 == null ? index.Enabled && !index.Frozen : this.pdfExporter_0.func_0(index)))
            this.pdfCatalog_0.OptionalContentProperties.Dictionary.Off.Add((IPdfObject) pdfReference);
        }
      }

      public DxfLayer CurrentLayer
      {
        get
        {
          return this.list_0[this.int_1];
        }
        set
        {
          if (this.int_1 < 0)
          {
            this.list_0.Add(value);
            this.int_1 = this.list_0.Count - 1;
            this.method_0();
          }
          else
          {
            if (value == this.list_0[this.int_1])
              return;
            this.method_2();
            this.int_1 = this.list_0.IndexOf(value);
            if (this.int_1 == -1)
            {
              this.list_0.Add(value);
              this.int_1 = this.list_0.Count - 1;
            }
            this.method_0();
          }
        }
      }
    }

    private class Class33 : IWireframeGraphicsFactory
    {
      private ArgbColor argbColor_2 = ArgbColor.Empty;
      private ArgbColor argbColor_3 = ArgbColor.Empty;
      private ArgbColor argbColor_4 = ArgbColor.Empty;
      private ArgbColor argbColor_5 = ArgbColor.Empty;
      private ArgbColor argbColor_6 = ArgbColor.Empty;
      private ArgbColor argbColor_7 = ArgbColor.Empty;
      private readonly PdfExporter pdfExporter_0;
      private readonly PdfPage pdfPage_0;
      private PaperSize paperSize_0;
      private readonly PdfExporter.Interface1 interface1_0;
      private BlinnClipper4D blinnClipper4D_0;
      private readonly GraphicsConfig graphicsConfig_0;
      private readonly float float_0;
      private ArgbColor? nullable_0;
      private readonly bool bool_0;
      private readonly ArgbColor argbColor_0;
      private readonly ArgbColor argbColor_1;
      private readonly bool bool_1;

      public Class33(
        PdfExporter context,
        PdfPage page,
        PaperSize paperSize,
        float lineWeightToPdfPixels,
        GraphicsConfig graphicsConfig,
        bool useMultipleElementLayers)
      {
        this.pdfExporter_0 = context;
        this.pdfPage_0 = page;
        this.PaperSize = paperSize;
        this.graphicsConfig_0 = graphicsConfig;
        this.float_0 = lineWeightToPdfPixels;
        this.interface1_0 = !useMultipleElementLayers ? (PdfExporter.Interface1) new PdfExporter.Class36() : (PdfExporter.Interface1) new PdfExporter.Class35();
        this.nullable_0 = graphicsConfig.FixedForegroundColor;
        this.bool_0 = graphicsConfig.CorrectColorForBackgroundColor;
        this.argbColor_0 = graphicsConfig.BackColor;
        this.argbColor_1 = new ArgbColor((int) byte.MaxValue - (int) this.argbColor_0.R, (int) byte.MaxValue - (int) this.argbColor_0.G, (int) byte.MaxValue - (int) this.argbColor_0.B);
        this.bool_1 = !useMultipleElementLayers;
      }

      private void method_0()
      {
        this.argbColor_2 = this.argbColor_4 = this.argbColor_3 = this.argbColor_5 = this.argbColor_6 = this.argbColor_7 = ArgbColor.Empty;
        this.interface1_0.BottomElements.CurrentLineWidth = -1f;
        if (this.interface1_0.TopElements != this.interface1_0.BottomElements)
          this.interface1_0.BottomElements.CurrentLineWidth = -1f;
        if (this.interface1_0.TextElements == this.interface1_0.BottomElements || this.interface1_0.TextElements == this.interface1_0.TopElements)
          return;
        this.interface1_0.TextElements.CurrentLineWidth = -1f;
      }

      private ArgbColor CurrentTopStrokeColor
      {
        get
        {
          return this.argbColor_2;
        }
        set
        {
          this.argbColor_2 = value;
        }
      }

      private ArgbColor CurrentTopFillColor
      {
        get
        {
          return this.argbColor_3;
        }
        set
        {
          this.argbColor_3 = value;
        }
      }

      private ArgbColor CurrentBottomStrokeColor
      {
        get
        {
          if (!this.bool_1)
            return this.argbColor_4;
          return this.argbColor_2;
        }
        set
        {
          if (this.bool_1)
            this.argbColor_2 = value;
          else
            this.argbColor_4 = value;
        }
      }

      private ArgbColor CurrentBottomFillColor
      {
        get
        {
          if (!this.bool_1)
            return this.argbColor_5;
          return this.argbColor_3;
        }
        set
        {
          if (this.bool_1)
            this.argbColor_3 = value;
          else
            this.argbColor_5 = value;
        }
      }

      private ArgbColor CurrentTextStrokeColor
      {
        get
        {
          if (!this.bool_1)
            return this.argbColor_6;
          return this.argbColor_2;
        }
        set
        {
          if (this.bool_1)
            this.argbColor_2 = value;
          else
            this.argbColor_6 = value;
        }
      }

      private ArgbColor CurrentTextFillColor
      {
        get
        {
          if (!this.bool_1)
            return this.argbColor_7;
          return this.argbColor_3;
        }
        set
        {
          if (this.bool_1)
            this.argbColor_3 = value;
          else
            this.argbColor_7 = value;
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

      public void method_1(string optionalContent)
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("/OC /" + optionalContent + " BDC");
        this.interface1_0.TopElements.Add(stringBuilder.ToString());
        if (this.bool_1)
          return;
        this.interface1_0.BottomElements.Add(stringBuilder.ToString());
        this.interface1_0.TextElements.Add(stringBuilder.ToString());
      }

      public void method_2()
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("EMC");
        this.interface1_0.TopElements.Add(stringBuilder.ToString());
        if (this.bool_1)
          return;
        this.interface1_0.BottomElements.Add(stringBuilder.ToString());
        this.interface1_0.TextElements.Add(stringBuilder.ToString());
      }

      public void method_3(ArgbColor color)
      {
        StringBuilder sb = new StringBuilder();
        PdfExporter.Class33.smethod_3(color, sb);
        sb.Append(" rg");
        this.interface1_0.BottomElements.Add(sb.ToString());
        StringBuilder stringBuilder1 = new StringBuilder();
        WW.Math.Point2D point2D1 = new WW.Math.Point2D(0.0, 0.0);
        stringBuilder1.Append(point2D1.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder1.Append(' ');
        stringBuilder1.Append(point2D1.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder1.Append(" m");
        this.interface1_0.BottomElements.Add(stringBuilder1.ToString());
        StringBuilder stringBuilder2 = new StringBuilder();
        WW.Math.Point2D point2D2 = new WW.Math.Point2D((double) this.paperSize_0.Width, 0.0);
        stringBuilder2.Append(point2D2.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder2.Append(' ');
        stringBuilder2.Append(point2D2.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder2.Append(" l");
        this.interface1_0.BottomElements.Add(stringBuilder2.ToString());
        StringBuilder stringBuilder3 = new StringBuilder();
        WW.Math.Point2D point2D3 = new WW.Math.Point2D((double) this.paperSize_0.Width, (double) this.paperSize_0.Height);
        stringBuilder3.Append(point2D3.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder3.Append(' ');
        stringBuilder3.Append(point2D3.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder3.Append(" l");
        this.interface1_0.BottomElements.Add(stringBuilder3.ToString());
        StringBuilder stringBuilder4 = new StringBuilder();
        WW.Math.Point2D point2D4 = new WW.Math.Point2D(0.0, (double) this.paperSize_0.Height);
        stringBuilder4.Append(point2D4.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder4.Append(' ');
        stringBuilder4.Append(point2D4.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder4.Append(" l");
        this.interface1_0.BottomElements.Add(stringBuilder4.ToString());
        this.interface1_0.BottomElements.Add("F");
      }

      public void Write(PdfExporter exporter, PdfContentStream pdfStream)
      {
        this.interface1_0.TopElements.Add("S");
        pdfStream.XOut.WriteLine("1 j");
        pdfStream.XOut.WriteLine("1 J");
        this.interface1_0.imethod_0(pdfStream);
      }

      public void BeginEntity(DxfEntity entity, DrawContext.Wireframe drawContext)
      {
        if (!this.pdfExporter_0.ExportLayers)
          return;
        this.pdfExporter_0.ExportLayerHelper.CurrentLayer = drawContext.GetEffectiveLayer(entity.Layer);
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
        this.method_22(color, false, true);
        this.method_11(position);
      }

      public void CreateLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        Vector4D start,
        Vector4D end)
      {
        this.DrawLine(entity, (DrawContext) drawContext, start, end, color);
      }

      public void CreateRay(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Segment4D segment)
      {
        this.method_13(entity, (DrawContext) drawContext, segment, color);
      }

      public void CreateXLine(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        Vector4D? startPoint,
        Segment4D segment)
      {
        this.method_13(entity, (DrawContext) drawContext, segment, color);
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
        bool top;
        PdfExporter.Class37 elements = (top = !fill || forText) ? this.interface1_0.TopElements : this.interface1_0.BottomElements;
        this.method_9(entity, (DrawContext) drawContext, forText, elements);
        this.method_23(color, true, top, correctForBackgroundColor);
        if (fill)
          this.method_23(color, false, top, correctForBackgroundColor);
        foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polylines)
        {
          if (polyline.Count > 1)
            this.method_4(polyline, fill, elements);
          else if (!fill && polyline.Count == 1)
            this.method_12(polyline[0], elements);
        }
      }

      private void method_4(Polyline4D polyline, bool fill, PdfExporter.Class37 elements)
      {
        if (!this.method_15(polyline, elements))
          return;
        elements.Add(!fill || !polyline.Closed ? "S" : "F");
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
        bool top;
        PdfExporter.Class37 elements = (top = !fill || forText) ? this.interface1_0.TopElements : this.interface1_0.BottomElements;
        this.method_9(entity, (DrawContext) drawContext, forText, elements);
        this.method_23(color, !fill, top, correctForBackgroundColor);
        bool flag = false;
        foreach (Polyline4D polyline in (IEnumerable<Polyline4D>) polylines)
        {
          if (this.method_15(polyline, elements))
            flag = true;
        }
        if (!flag)
          return;
        elements.Add(fill ? "f*" : "S");
      }

      public void CreateShape(
        DxfEntity entity,
        DrawContext.Wireframe drawContext,
        ArgbColor color,
        bool forText,
        IShape4D shape)
      {
        if (shape.IsEmpty)
          return;
        bool isFilled;
        bool top;
        PdfExporter.Class37 elements = (top = !(isFilled = shape.IsFilled) || forText) ? this.interface1_0.TopElements : this.interface1_0.BottomElements;
        this.method_9(entity, (DrawContext) drawContext, forText, elements);
        this.method_22(color, !isFilled, top);
        StringBuilder stringBuilder = new StringBuilder();
        WW.Math.Point2D[] points = new WW.Math.Point2D[3];
        WW.Math.Point2D point2D = new WW.Math.Point2D();
        WW.Math.Point2D p0 = new WW.Math.Point2D();
        ISegment2DIterator iterator = shape.CreateIterator(Matrix4D.Identity);
        while (iterator.MoveNext())
        {
          switch (iterator.Current(points, 0))
          {
            case SegmentType.MoveTo:
              stringBuilder.Append(points[0].X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(' ');
              stringBuilder.Append(points[0].Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(" m");
              elements.Add(stringBuilder.ToString());
              stringBuilder.Length = 0;
              point2D = p0 = points[0];
              continue;
            case SegmentType.LineTo:
              stringBuilder.Append(points[0].X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(' ');
              stringBuilder.Append(points[0].Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(" l");
              elements.Add(stringBuilder.ToString());
              stringBuilder.Length = 0;
              p0 = points[0];
              continue;
            case SegmentType.QuadTo:
              Pair<WW.Math.Point2D, WW.Math.Point2D> cubicBezier = ShapeTool.QuadToCubicBezier(p0, points[0], points[1]);
              stringBuilder.Append(cubicBezier.First.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(' ');
              stringBuilder.Append(cubicBezier.First.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(' ');
              stringBuilder.Append(cubicBezier.Second.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(' ');
              stringBuilder.Append(cubicBezier.Second.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(' ');
              stringBuilder.Append(points[1].X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(' ');
              stringBuilder.Append(points[1].Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(" c");
              elements.Add(stringBuilder.ToString());
              stringBuilder.Length = 0;
              p0 = points[1];
              continue;
            case SegmentType.CubicTo:
              stringBuilder.Append(points[0].X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(' ');
              stringBuilder.Append(points[0].Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(' ');
              stringBuilder.Append(points[1].X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(' ');
              stringBuilder.Append(points[1].Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(' ');
              stringBuilder.Append(points[2].X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(' ');
              stringBuilder.Append(points[2].Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
              stringBuilder.Append(" c");
              elements.Add(stringBuilder.ToString());
              stringBuilder.Length = 0;
              p0 = points[2];
              continue;
            case SegmentType.Close:
              elements.Add("h");
              p0 = point2D;
              continue;
            default:
              continue;
          }
        }
        elements.Add(isFilled ? "F" : "S");
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
        if (text.Text == null || text.Text.Trim() == string.Empty)
          return;
        this.interface1_0.TextElements.method_0();
        this.method_9((DxfEntity) text, (DrawContext) drawContext, true, this.interface1_0.TextElements);
        this.method_8((IEnumerable<Class908>) Class666.smethod_5(text, text.Color.ToColor(), drawContext.GetLineWeight((DxfEntity) text), text.Transform, (Bounds2D) null), (DxfEntity) text, drawContext);
        this.interface1_0.TextElements.method_1();
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
        if (!this.graphicsConfig_0.DrawImages)
          return;
        IBitmap bitmap = rasterImage.ImageDef == null ? (IBitmap) null : rasterImage.ImageDef.Bitmap;
        if (bitmap == null || !bitmap.IsValid)
          return;
        WW.Math.Point2D zero = WW.Math.Point2D.Zero;
        WW.Math.Point2D point2D = new WW.Math.Point2D((double) bitmap.Width, (double) bitmap.Height);
        WW.Math.Point2D imageCorner1 = zero + DxfRasterImage.PixelOffset;
        WW.Math.Point2D imageCorner2 = point2D - DxfRasterImage.PixelOffset;
        WW.Math.Point2D origin = (WW.Math.Point2D) transformedOrigin;
        Vector2D xScale = ((WW.Math.Point2D) transformedXAxis - origin) * (double) bitmap.Width;
        Vector2D yScale = ((WW.Math.Point2D) transformedYAxis - origin) * (double) bitmap.Height;
        this.method_5(bitmap, false, origin, xScale, yScale, imageCorner1, imageCorner2);
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
        if (!this.graphicsConfig_0.DrawImages)
          return;
        WW.Math.Point3D point3D1 = (WW.Math.Point3D) transformedOrigin;
        WW.Math.Point3D point3D2 = (WW.Math.Point3D) transformedXAxis;
        WW.Math.Point3D point3D3 = (WW.Math.Point3D) transformedYAxis;
        WW.Math.Vector3D vector3D1 = point3D2 - point3D1;
        WW.Math.Vector3D vector3D2 = point3D3 - point3D1;
        double num = this.pdfExporter_0.double_0 * System.Math.Max(vector3D1.GetLength(), vector3D2.GetLength());
        if (bitmapProvider == null || num <= 0.0)
          return;
        int width = (int) System.Math.Round(displaySize.X * num);
        int height = (int) System.Math.Round(displaySize.Y * num);
        WW.Math.Point2D zero = WW.Math.Point2D.Zero;
        WW.Math.Point2D point2D = new WW.Math.Point2D((double) width, (double) height);
        WW.Math.Point2D imageCorner1 = zero + DxfRasterImage.PixelOffset;
        WW.Math.Point2D imageCorner2 = point2D - DxfRasterImage.PixelOffset;
        Bitmap bitmap = bitmapProvider.CreateBitmap(new Size(width, height));
        if (bitmap == null)
          return;
        this.method_5((IBitmap) new GdiBitmap(bitmap), true, (WW.Math.Point2D) point3D1, (Vector2D) vector3D1 * displaySize.X, (Vector2D) vector3D2 * displaySize.Y, imageCorner1, imageCorner2);
      }

      private void method_5(
        IBitmap bitmap,
        bool ownsBitmap,
        WW.Math.Point2D origin,
        Vector2D xScale,
        Vector2D yScale,
        WW.Math.Point2D imageCorner1,
        WW.Math.Point2D imageCorner2)
      {
        int width = bitmap.Width;
        int height = bitmap.Height;
        PdfImage.ClipRect clipMask = new PdfImage.ClipRect((int) imageCorner1.X, (int) imageCorner1.Y, (int) (imageCorner2.X - imageCorner1.X) + 1, (int) (imageCorner2.Y - imageCorner1.Y) + 1);
        string baseName = "Img" + this.pdfExporter_0.pdfDocument_0.GetNextImageIndex().ToString();
        string pdfName = PdfImage.GetPdfName(baseName, clipMask);
        this.pdfExporter_0.Body.ProcedureSetArray.AddProcedure(new PdfName("ImageC"));
        IPdfObject pdfObject;
        PdfDictionary pdfDictionary;
        if (this.pdfPage_0.Resources.TryGetValue("XObject", out pdfObject))
        {
          pdfDictionary = (PdfDictionary) pdfObject;
        }
        else
        {
          pdfDictionary = new PdfDictionary();
          this.pdfPage_0.Resources.Add("XObject", (IPdfObject) pdfDictionary);
        }
        if (!pdfDictionary.ContainsKey(pdfName))
        {
          PdfImage pdfImage = new PdfImage(baseName, bitmap, ownsBitmap, clipMask);
          PdfIndirectObject pdfIndirectObject = new PdfIndirectObject((IPdfObject) pdfImage);
          this.pdfExporter_0.Body.IndirectObjects.Add((IPdfIndirectObject) pdfIndirectObject);
          pdfImage.AddSoftMask(this.pdfExporter_0.Body);
          PdfReference pdfReference = new PdfReference((IPdfIndirectObject) pdfIndirectObject);
          pdfDictionary.Add(pdfName, (IPdfObject) pdfReference);
        }
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("q\n");
        stringBuilder.Append(xScale.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(' ');
        stringBuilder.Append(xScale.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(' ');
        stringBuilder.Append(yScale.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(' ');
        stringBuilder.Append(yScale.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(' ');
        stringBuilder.Append(origin.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(' ');
        stringBuilder.Append(origin.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(" cm\n");
        stringBuilder.Append("/").Append(pdfName).Append(" Do").Append('\n');
        stringBuilder.Append("Q");
        this.interface1_0.BottomElements.Add(stringBuilder.ToString());
      }

      private string method_6(System.Drawing.Font systemFont)
      {
        PdfFontInfo.FontKey key = new PdfFontInfo.FontKey(systemFont);
        string nextAvailableName;
        if (!this.pdfExporter_0.pdfBody_0.FontInfo.FontKeyToName.TryGetValue(key, out nextAvailableName))
        {
          nextAvailableName = this.pdfExporter_0.pdfBody_0.FontSetup.GetNextAvailableName();
          this.pdfExporter_0.pdfBody_0.FontInfo.FontKeyToName.Add(key, nextAvailableName);
          IFontMetric proxyFont = (IFontMetric) WW.Pdf.Font.Font.CreateProxyFont(new FontProperties(systemFont.FontFamily.Name, FontUtil.IsBold(systemFont), FontUtil.IsItalic(systemFont)), FontType.Link);
          this.pdfExporter_0.pdfBody_0.FontInfo.AddMetrics(nextAvailableName, proxyFont);
          this.pdfExporter_0.pdfBody_0.FontInfo.UsedNameToFontMetric.Add(nextAvailableName, proxyFont);
        }
        else
          this.pdfExporter_0.pdfBody_0.FontInfo.UsedNameToFontMetric[nextAvailableName] = this.pdfExporter_0.pdfBody_0.FontInfo.NameToFontMetric[nextAvailableName];
        return nextAvailableName;
      }

      private FontState method_7(System.Drawing.Font systemFont, double fontSize)
      {
        return new FontState(this.pdfExporter_0.pdfBody_0.FontInfo, systemFont.FontFamily.Name, systemFont.Italic ? "italic" : "normal", systemFont.Bold ? "bold" : "normal", (int) fontSize);
      }

      public void CreateMText(DxfMText text, DrawContext.Wireframe drawContext)
      {
        if (text.Text == null || text.Text.Trim() == string.Empty)
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
        this.interface1_0.TextElements.method_0();
        BackgroundFillFlags backgroundFillFlags = text.BackgroundFillFlags;
        BackgroundFillInfo backgroundFillInfo = text.BackgroundFillInfo;
        if (backgroundFillFlags == BackgroundFillFlags.UseBackgroundFillColor && backgroundFillInfo != null)
        {
          double num = text.Height * (backgroundFillInfo.BorderOffsetFactor - 1.0);
          WW.Math.Point2D zero = WW.Math.Point2D.Zero;
          double width = text.Width;
          double y = collectBounds.Delta.Y;
          switch (text.AttachmentPoint)
          {
            case AttachmentPoint.TopLeft:
              zero.X = collectBounds.Corner1.X + 0.5 * width;
              zero.Y = collectBounds.Corner2.Y - 0.5 * y;
              break;
            case AttachmentPoint.TopCenter:
              zero.X = collectBounds.Center.X;
              zero.Y = collectBounds.Corner2.Y - 0.5 * y;
              break;
            case AttachmentPoint.TopRight:
              zero.X = collectBounds.Corner2.X - 0.5 * width;
              zero.Y = collectBounds.Corner2.Y - 0.5 * y;
              break;
            case AttachmentPoint.MiddleLeft:
              zero.X = collectBounds.Corner1.X + 0.5 * width;
              zero.Y = collectBounds.Center.Y;
              break;
            case AttachmentPoint.MiddleCenter:
              zero.X = collectBounds.Center.X;
              zero.Y = collectBounds.Center.Y;
              break;
            case AttachmentPoint.MiddleRight:
              zero.X = collectBounds.Corner2.X - 0.5 * width;
              zero.Y = collectBounds.Center.Y;
              break;
            case AttachmentPoint.BottomLeft:
              zero.X = collectBounds.Corner1.X + 0.5 * width;
              zero.Y = collectBounds.Corner1.Y + 0.5 * y;
              break;
            case AttachmentPoint.BottomCenter:
              zero.X = collectBounds.Center.X;
              zero.Y = collectBounds.Corner1.Y + 0.5 * y;
              break;
            case AttachmentPoint.BottomRight:
              zero.X = collectBounds.Corner2.X - 0.5 * width;
              zero.Y = collectBounds.Corner1.Y + 0.5 * y;
              break;
            default:
              zero.X = collectBounds.Center.X;
              zero.Y = collectBounds.Center.Y;
              break;
          }
          Vector2D vector2D = new Vector2D(0.5 * width + num, 0.5 * y + num);
          new PdfExporter.Class33.Class34((DrawContext) drawContext, this, (DxfEntity) text).DrawPath((IShape2D) new Rectangle2D(zero - vector2D, zero + vector2D), drawContext.GetTransformer().Matrix * text.Transform, backgroundFillInfo.Color, lineWeight, true, false, 0.0);
        }
        this.method_8((IEnumerable<Class908>) class908List, (DxfEntity) text, drawContext);
        this.interface1_0.TextElements.method_1();
      }

      private static string smethod_0(double val)
      {
        string str = val.ToString("G", (IFormatProvider) CultureInfo.InvariantCulture);
        if (str.Contains("E"))
          str = val.ToString("F", (IFormatProvider) CultureInfo.InvariantCulture);
        return str;
      }

      private void method_8(
        IEnumerable<Class908> chunks,
        DxfEntity entity,
        DrawContext.Wireframe drawContext)
      {
        this.method_9(entity, (DrawContext) drawContext, true, this.interface1_0.TextElements);
        IClippingTransformer transformer = drawContext.GetTransformer();
        Matrix4D matrix = transformer.Matrix;
        foreach (Class908 chunk in chunks)
        {
          System.Drawing.Font systemFont = chunk.Font.SystemFont;
          bool flag;
          if (!(flag = systemFont == null))
          {
            bool transformedShape;
            switch (transformer.IsInside((IShape4D) new FlatShape4D(chunk.FontPath, chunk.Transformation, true), out transformedShape))
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
                  if (this.pdfExporter_0.bool_2)
                  {
                    FontState fontState = this.method_7(systemFont, chunk.Font.Metrics.SystemFontHeight);
                    bool multiByteFont = ((WW.Pdf.Font.Font) fontState.FontInfo.GetFontByPdfName(fontState.FontName)).MultiByteFont;
                    this.method_20(drawContext.GetPlotColor(entity, chunk.Color), false);
                    Matrix2D charTransformation = chunk.Font.Metrics.CharTransformation;
                    Matrix4D matrix4D = matrix * chunk.Transformation * new Matrix4D(num * charTransformation.M00, -num * charTransformation.M01, 0.0, 0.0, num * charTransformation.M10, -num * charTransformation.M11, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
                    this.interface1_0.TextElements.Add("/" + fontState.FontName + " " + PdfExporter.Class33.smethod_0(systemFontHeight) + " Tf");
                    this.interface1_0.TextElements.Add(PdfExporter.Class33.smethod_0(matrix4D.M00) + " " + PdfExporter.Class33.smethod_0(matrix4D.M10) + " " + PdfExporter.Class33.smethod_0(matrix4D.M01) + " " + PdfExporter.Class33.smethod_0(matrix4D.M11) + " " + PdfExporter.Class33.smethod_0(matrix4D.M03) + " " + PdfExporter.Class33.smethod_0(matrix4D.M13) + " Tm");
                    string str1 = multiByteFont ? "[ <" : "(";
                    string str2 = multiByteFont ? "> ] " : ") ";
                    string text = chunk.Text.Text;
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (char c1 in text)
                    {
                      ushort c2 = fontState.MapCharacter(c1);
                      if (!multiByteFont)
                      {
                        if (c2 > (ushort) sbyte.MaxValue)
                        {
                          stringBuilder.Append("\\");
                          stringBuilder.Append(Convert.ToString((int) c2, 8));
                        }
                        else
                        {
                          switch (c2)
                          {
                            case 40:
                            case 41:
                            case 92:
                              stringBuilder.Append("\\");
                              break;
                          }
                          stringBuilder.Append((char) c2);
                        }
                      }
                      else
                      {
                        if (c2 == (ushort) 0 && (c1 == '⌀' || c1 == '∅'))
                          c2 = fontState.MapCharacter('ø');
                        stringBuilder.Append(PdfExporter.Class33.smethod_2(c2));
                      }
                    }
                    this.interface1_0.TextElements.Add(str1 + (object) stringBuilder + str2 + (multiByteFont ? (object) " TJ" : (object) " Tj"));
                    break;
                  }
                  string str = this.method_6(systemFont);
                  this.method_20(drawContext.GetPlotColor(entity, chunk.Color), false);
                  Matrix2D charTransformation1 = chunk.Font.Metrics.CharTransformation;
                  Matrix4D matrix4D1 = matrix * chunk.Transformation * new Matrix4D(num * charTransformation1.M00, -num * charTransformation1.M01, 0.0, 0.0, num * charTransformation1.M10, -num * charTransformation1.M11, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
                  this.interface1_0.TextElements.Add("/" + str + " " + PdfExporter.Class33.smethod_0(systemFontHeight) + " Tf");
                  this.interface1_0.TextElements.Add(PdfExporter.Class33.smethod_0(matrix4D1.M00) + " " + PdfExporter.Class33.smethod_0(matrix4D1.M10) + " " + PdfExporter.Class33.smethod_0(matrix4D1.M01) + " " + PdfExporter.Class33.smethod_0(matrix4D1.M11) + " " + PdfExporter.Class33.smethod_0(matrix4D1.M03) + " " + PdfExporter.Class33.smethod_0(matrix4D1.M13) + " Tm");
                  this.interface1_0.TextElements.Add(PdfExporter.Class33.smethod_1(chunk.Text.Text));
                  break;
                }
                continue;
            }
          }
          PdfExporter.Class33.Class34 class34 = new PdfExporter.Class33.Class34((DrawContext) drawContext, this, entity);
          if (flag)
          {
            this.interface1_0.TextElements.method_1();
            chunk.method_0((IPathDrawer) new ClippingPathDrawerWrapper(transformer, (IPathDrawer) class34), Matrix4D.Identity, 0.0);
            this.interface1_0.TextElements.method_0();
          }
          if (chunk.Linings.Length > 0)
          {
            this.interface1_0.TextElements.method_1();
            this.method_9(entity, (DrawContext) drawContext, false, this.interface1_0.TextElements);
            chunk.method_1((IPathDrawer) new ClippingPathDrawerWrapper(transformer, (IPathDrawer) class34), Matrix4D.Identity, 0.0);
            this.interface1_0.TextElements.method_0();
          }
        }
      }

      private static byte[] smethod_1(string text)
      {
        List<byte> byteList = new List<byte>(4 * text.Length);
        byteList.Add((byte) 40);
        foreach (char ch in text)
        {
          if (ch > '\x007F')
          {
            if (ch < 'Ȁ')
            {
              byteList.Add((byte) 92);
              byteList.AddRange((IEnumerable<byte>) PdfWriter.StandardEncoding.GetBytes(Convert.ToString((int) ch, 8)));
            }
            else
            {
              switch (ch)
              {
                case '∅':
                case '⌀':
                  byteList.Add((byte) 92);
                  byteList.AddRange((IEnumerable<byte>) PdfWriter.StandardEncoding.GetBytes(Convert.ToString(248, 8)));
                  continue;
                default:
                  byteList.Add((byte) 63);
                  continue;
              }
            }
          }
          else
          {
            switch (ch)
            {
              case '(':
              case ')':
              case '\\':
                byteList.Add((byte) 92);
                break;
            }
            byteList.Add((byte) ch);
          }
        }
        byteList.AddRange((IEnumerable<byte>) PdfWriter.StandardEncoding.GetBytes(") Tj"));
        return byteList.ToArray();
      }

      private static string smethod_2(ushort c)
      {
        StringBuilder stringBuilder = new StringBuilder(4);
        Encoding bigEndianUnicode = Encoding.BigEndianUnicode;
        char[] chars = new char[1]{ (char) c };
        foreach (byte num in bigEndianUnicode.GetBytes(chars))
        {
          string str = Convert.ToString(num, 16);
          if (str.Length == 1)
            stringBuilder.Append("0");
          stringBuilder.Append(str);
        }
        return stringBuilder.ToString();
      }

      private void method_9(
        DxfEntity entity,
        DrawContext drawContext,
        bool forText,
        PdfExporter.Class37 elements)
      {
        this.method_10(drawContext.GetLineWeight(entity), forText, elements);
      }

      private void method_10(short lineWeight, bool forText, PdfExporter.Class37 elements)
      {
        float num = !this.graphicsConfig_0.DisplayLineWeight ? (!forText ? this.pdfExporter_0.LineWidth : this.pdfExporter_0.TextLineWidth) : (float) lineWeight * this.float_0;
        if ((double) elements.CurrentLineWidth == (double) num)
          return;
        elements.CurrentLineWidth = num;
        elements.Add(num.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture) + " w");
      }

      private void method_11(Vector4D point)
      {
        this.method_12(point, this.interface1_0.TopElements);
      }

      private void method_12(Vector4D point, PdfExporter.Class37 elements)
      {
        if ((double) this.pdfExporter_0.float_2 <= 0.0)
          return;
        WW.Math.Point2D point2D = (WW.Math.Point2D) point;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append((point2D.X - (double) this.pdfExporter_0.float_3).ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(' ');
        stringBuilder.Append((point2D.Y - (double) this.pdfExporter_0.float_3).ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(' ');
        stringBuilder.Append(this.pdfExporter_0.float_2.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(' ');
        stringBuilder.Append(this.pdfExporter_0.float_2.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(" re");
        this.interface1_0.TopElements.Add(stringBuilder.ToString());
        elements.Add("F");
      }

      private void DrawLine(
        DxfEntity entity,
        DrawContext drawContext,
        Vector4D start,
        Vector4D end,
        ArgbColor color)
      {
        this.method_9(entity, drawContext, false, this.interface1_0.TopElements);
        WW.Math.Point2D point2D1 = (WW.Math.Point2D) start;
        WW.Math.Point2D point2D2 = (WW.Math.Point2D) end;
        this.method_22(color, true, true);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(point2D1.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(' ');
        stringBuilder.Append(point2D1.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(" m");
        this.interface1_0.TopElements.Add(stringBuilder.ToString());
        stringBuilder.Length = 0;
        stringBuilder.Append(point2D2.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(' ');
        stringBuilder.Append(point2D2.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(" l");
        this.interface1_0.TopElements.Add(stringBuilder.ToString());
        this.interface1_0.TopElements.Add("S");
      }

      private void method_13(
        DxfEntity entity,
        DrawContext drawContext,
        Segment4D segment,
        ArgbColor color)
      {
        this.method_9(entity, drawContext, false, this.interface1_0.TopElements);
        this.method_14(segment.Start, segment.End, color);
      }

      private void method_14(Vector4D start, Vector4D end, ArgbColor color)
      {
        foreach (Segment4D segment4D in (IEnumerable<Segment4D>) this.blinnClipper4D_0.Clip(new Segment4D(start, end)))
        {
          start = segment4D.Start;
          end = segment4D.End;
          this.method_22(color, true, true);
          StringBuilder stringBuilder1 = new StringBuilder();
          stringBuilder1.Append(start.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
          stringBuilder1.Append(' ');
          stringBuilder1.Append(start.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
          stringBuilder1.Append(" m");
          this.interface1_0.TopElements.Add(stringBuilder1.ToString());
          StringBuilder stringBuilder2 = new StringBuilder();
          stringBuilder2.Append(end.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
          stringBuilder2.Append(' ');
          stringBuilder2.Append(end.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
          stringBuilder2.Append(" l");
          this.interface1_0.TopElements.Add(stringBuilder2.ToString());
          this.interface1_0.TopElements.Add("S");
        }
      }

      private bool method_15(Polyline4D polyline, PdfExporter.Class37 elements)
      {
        if (polyline.Count < 2)
          return false;
        StringBuilder stringBuilder = new StringBuilder();
        WW.Math.Point2D point2D = (WW.Math.Point2D) polyline[0];
        stringBuilder.Append(point2D.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(' ');
        stringBuilder.Append(point2D.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        stringBuilder.Append(" m");
        elements.Add(stringBuilder.ToString());
        for (int index = 1; index < polyline.Count; ++index)
        {
          stringBuilder.Length = 0;
          point2D = (WW.Math.Point2D) polyline[index];
          stringBuilder.Append(point2D.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
          stringBuilder.Append(' ');
          stringBuilder.Append(point2D.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
          stringBuilder.Append(" l");
          elements.Add(stringBuilder.ToString());
        }
        if (polyline.Closed && polyline.Count > 2)
        {
          stringBuilder.Length = 0;
          stringBuilder.Append("h");
          elements.Add(stringBuilder.ToString());
        }
        return true;
      }

      internal void method_16(
        DrawContext.Wireframe.PaperToPaperSpace drawContext,
        DxfViewport viewport)
      {
        if (viewport == null || !viewport.ModelSpaceVisible)
          return;
        this.method_17(drawContext, viewport, this.interface1_0.BottomElements);
        if (this.interface1_0.TopElements != this.interface1_0.BottomElements)
          this.method_17(drawContext, viewport, this.interface1_0.TopElements);
        if (this.interface1_0.TextElements == this.interface1_0.BottomElements || this.interface1_0.TextElements == this.interface1_0.TopElements)
          return;
        this.method_17(drawContext, viewport, this.interface1_0.TextElements);
      }

      private void method_17(
        DrawContext.Wireframe.PaperToPaperSpace drawContext,
        DxfViewport viewport,
        PdfExporter.Class37 elements)
      {
        elements.Add("q");
        IClipBoundaryProvider clippingBoundaryEntity = viewport.ClippingBoundaryEntity as IClipBoundaryProvider;
        IClippingTransformer transformer = drawContext.GetTransformer();
        if (viewport.UseNonRectangularClipBoundary && clippingBoundaryEntity != null)
        {
          foreach (IEnumerable<WW.Math.Point2D> polyline in (IEnumerable<Polygon2D>) clippingBoundaryEntity.GetClipBoundary(this.graphicsConfig_0))
            this.method_15(DxfUtil.smethod_40(new Polyline3D(new Polyline2D(true, polyline)), transformer.Matrix), elements);
          elements.Add("W n");
        }
        else
        {
          this.method_15(DxfUtil.smethod_40(new Polyline3D(true, new WW.Math.Point3D[4]
          {
            new WW.Math.Point3D(viewport.Left, viewport.Bottom, 0.0),
            new WW.Math.Point3D(viewport.Right, viewport.Bottom, 0.0),
            new WW.Math.Point3D(viewport.Right, viewport.Top, 0.0),
            new WW.Math.Point3D(viewport.Left, viewport.Top, 0.0)
          }), transformer.Matrix), elements);
          elements.Add("W n");
        }
      }

      internal void method_18(
        DrawContext.Wireframe.PaperToPaperSpace drawContext,
        DxfViewport viewport)
      {
        if (viewport == null || !viewport.ModelSpaceVisible)
          return;
        this.method_19(this.interface1_0.BottomElements);
        if (this.interface1_0.TopElements != this.interface1_0.BottomElements)
          this.method_19(this.interface1_0.TopElements);
        if (this.interface1_0.TextElements == this.interface1_0.BottomElements || this.interface1_0.TextElements == this.interface1_0.TopElements)
          return;
        this.method_19(this.interface1_0.TextElements);
      }

      private void method_19(PdfExporter.Class37 elements)
      {
        elements.Add("Q");
        this.method_0();
      }

      private static void smethod_3(ArgbColor color, StringBuilder sb)
      {
        float num1 = (float) color.R / (float) byte.MaxValue;
        sb.Append(num1.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        sb.Append(' ');
        float num2 = (float) color.G / (float) byte.MaxValue;
        sb.Append(num2.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
        sb.Append(' ');
        float num3 = (float) color.B / (float) byte.MaxValue;
        sb.Append(num3.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture));
      }

      private void method_20(ArgbColor color, bool stroke)
      {
        color = this.method_21(color);
        if (stroke && color != this.CurrentTextStrokeColor)
        {
          this.CurrentTextStrokeColor = color;
          StringBuilder sb = new StringBuilder();
          PdfExporter.Class33.smethod_3(color, sb);
          sb.Append(" RG");
          this.interface1_0.TextElements.Add(sb.ToString());
        }
        else
        {
          if (stroke || !(color != this.CurrentTextFillColor))
            return;
          this.CurrentTextFillColor = color;
          StringBuilder sb = new StringBuilder();
          PdfExporter.Class33.smethod_3(color, sb);
          sb.Append(" rg");
          this.interface1_0.TextElements.Add(sb.ToString());
        }
      }

      private ArgbColor method_21(ArgbColor color)
      {
        if (this.nullable_0.HasValue)
          color = this.nullable_0.Value;
        else if (this.bool_0 && color == this.argbColor_0)
          color = this.argbColor_1;
        return color;
      }

      private void method_22(ArgbColor color, bool strokeColor, bool top)
      {
        this.method_23(color, strokeColor, top, true);
      }

      private void method_23(ArgbColor color, bool strokeColor, bool top, bool correctColor)
      {
        if (correctColor)
          color = this.method_21(color);
        if (top)
        {
          if (strokeColor && color != this.CurrentTopStrokeColor)
          {
            this.CurrentTopStrokeColor = color;
            StringBuilder sb = new StringBuilder();
            PdfExporter.Class33.smethod_3(color, sb);
            sb.Append(" RG");
            this.interface1_0.TopElements.Add(sb.ToString());
          }
          else
          {
            if (strokeColor || !(color != this.CurrentTopFillColor))
              return;
            this.CurrentTopFillColor = color;
            StringBuilder sb = new StringBuilder();
            PdfExporter.Class33.smethod_3(color, sb);
            sb.Append(" rg");
            this.interface1_0.TopElements.Add(sb.ToString());
          }
        }
        else if (strokeColor && color != this.CurrentBottomStrokeColor)
        {
          this.CurrentBottomStrokeColor = color;
          StringBuilder sb = new StringBuilder();
          PdfExporter.Class33.smethod_3(color, sb);
          sb.Append(" RG");
          this.interface1_0.BottomElements.Add(sb.ToString());
        }
        else
        {
          if (strokeColor || !(color != this.CurrentBottomFillColor))
            return;
          this.CurrentBottomFillColor = color;
          StringBuilder sb = new StringBuilder();
          PdfExporter.Class33.smethod_3(color, sb);
          sb.Append(" rg");
          this.interface1_0.BottomElements.Add(sb.ToString());
        }
      }

      private class Class34 : IPathDrawer
      {
        private readonly StringBuilder stringBuilder_0 = new StringBuilder();
        private readonly DrawContext drawContext_0;
        private readonly PdfExporter.Class33 class33_0;
        private readonly DxfEntity dxfEntity_0;

        public Class34(DrawContext drawContext, PdfExporter.Class33 outer, DxfEntity entity)
        {
          this.drawContext_0 = drawContext;
          this.class33_0 = outer;
          this.dxfEntity_0 = entity;
        }

        private WW.Math.Point2D method_0(Matrix4D transform, WW.Math.Point2D point)
        {
          return transform.TransformTo2D(new WW.Math.Point2D(point.X, point.Y));
        }

        private static void smethod_0(StringBuilder buffer, WW.Math.Point2D point)
        {
          buffer.Append(point.X.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture)).Append(' ').Append(point.Y.ToString("0.##", (IFormatProvider) CultureInfo.InvariantCulture)).Append(' ');
        }

        private static void smethod_1(StringBuilder buffer, WW.Math.Point2D point, char command)
        {
          PdfExporter.Class33.Class34.smethod_0(buffer, point);
          buffer.Append(command).Append('\n');
        }

        private WW.Math.Point2D method_1(
          StringBuilder buffer,
          Matrix4D transform,
          WW.Math.Point2D point)
        {
          WW.Math.Point2D point1 = this.method_0(transform, point);
          PdfExporter.Class33.Class34.smethod_0(buffer, point1);
          return point1;
        }

        private WW.Math.Point2D method_2(
          StringBuilder buffer,
          Matrix4D transform,
          WW.Math.Point2D point,
          char command)
        {
          WW.Math.Point2D point2D = this.method_1(buffer, transform, point);
          buffer.Append(command).Append('\n');
          return point2D;
        }

        public void DrawPath(IShape4D path, WW.Cad.Model.Color color, short lineWeight)
        {
          if (path.IsEmpty)
            return;
          PdfExporter.Class37 topElements = this.class33_0.interface1_0.TopElements;
          this.class33_0.method_10(lineWeight, false, topElements);
          this.stringBuilder_0.Length = 0;
          this.class33_0.method_22(this.drawContext_0.GetPlotColor(this.dxfEntity_0, color), !path.IsFilled, true);
          topElements.Add(this.stringBuilder_0.ToString());
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
                PdfExporter.Class33.Class34.smethod_1(this.stringBuilder_0, points[0], 'm');
                point2D = p0 = points[0];
                continue;
              case SegmentType.LineTo:
                PdfExporter.Class33.Class34.smethod_1(this.stringBuilder_0, points[0], 'l');
                p0 = points[0];
                continue;
              case SegmentType.QuadTo:
                Pair<WW.Math.Point2D, WW.Math.Point2D> cubicBezier = ShapeTool.QuadToCubicBezier(p0, points[0], points[1]);
                PdfExporter.Class33.Class34.smethod_0(this.stringBuilder_0, cubicBezier.First);
                PdfExporter.Class33.Class34.smethod_0(this.stringBuilder_0, cubicBezier.Second);
                PdfExporter.Class33.Class34.smethod_1(this.stringBuilder_0, points[1], 'c');
                p0 = points[1];
                continue;
              case SegmentType.CubicTo:
                PdfExporter.Class33.Class34.smethod_0(this.stringBuilder_0, points[0]);
                PdfExporter.Class33.Class34.smethod_0(this.stringBuilder_0, points[1]);
                PdfExporter.Class33.Class34.smethod_1(this.stringBuilder_0, points[2], 'c');
                p0 = points[2];
                continue;
              case SegmentType.Close:
                this.stringBuilder_0.Append("h\n");
                p0 = point2D;
                continue;
              default:
                continue;
            }
          }
          this.stringBuilder_0.Append(path.IsFilled ? 'f' : 'S');
          topElements.Add(this.stringBuilder_0.ToString());
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
          PdfExporter.Class37 elements = forText ? this.class33_0.interface1_0.TextElements : this.class33_0.interface1_0.TopElements;
          this.class33_0.method_10(lineWeight, forText, elements);
          this.stringBuilder_0.Length = 0;
          if (forText)
            this.class33_0.method_20(this.drawContext_0.GetPlotColor(this.dxfEntity_0, color), !filled);
          else
            this.class33_0.method_22(this.drawContext_0.GetPlotColor(this.dxfEntity_0, color), !filled, true);
          elements.Add(this.stringBuilder_0.ToString());
          this.stringBuilder_0.Length = 0;
          WW.Math.Point2D[] points = new WW.Math.Point2D[3];
          WW.Math.Point2D point2D = new WW.Math.Point2D();
          WW.Math.Point2D point = new WW.Math.Point2D();
          ISegment2DIterator iterator = path.CreateIterator();
          while (iterator.MoveNext())
          {
            switch (iterator.Current(points, 0))
            {
              case SegmentType.MoveTo:
                this.method_2(this.stringBuilder_0, transform, points[0], 'm');
                point2D = point = points[0];
                continue;
              case SegmentType.LineTo:
                this.method_2(this.stringBuilder_0, transform, points[0], 'l');
                point = points[0];
                continue;
              case SegmentType.QuadTo:
                Pair<WW.Math.Point2D, WW.Math.Point2D> cubicBezier = ShapeTool.QuadToCubicBezier(this.method_0(transform, point), points[0], points[1]);
                this.method_1(this.stringBuilder_0, transform, cubicBezier.First);
                this.method_1(this.stringBuilder_0, transform, cubicBezier.Second);
                this.method_2(this.stringBuilder_0, transform, points[1], 'c');
                point = points[1];
                continue;
              case SegmentType.CubicTo:
                this.method_1(this.stringBuilder_0, transform, points[0]);
                this.method_1(this.stringBuilder_0, transform, points[1]);
                this.method_2(this.stringBuilder_0, transform, points[2], 'c');
                point = points[2];
                continue;
              case SegmentType.Close:
                this.stringBuilder_0.Append("h\n");
                point = point2D;
                continue;
              default:
                continue;
            }
          }
          this.stringBuilder_0.Append(filled ? 'f' : 'S');
          elements.Add(this.stringBuilder_0.ToString());
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

    private interface Interface1
    {
      PdfExporter.Class37 BottomElements { get; }

      PdfExporter.Class37 TopElements { get; }

      PdfExporter.Class37 TextElements { get; }

      void imethod_0(PdfContentStream pdfStream);
    }

    private class Class35 : PdfExporter.Interface1
    {
      private readonly PdfExporter.Class37 class37_0 = new PdfExporter.Class37();
      private readonly PdfExporter.Class37 class37_1 = new PdfExporter.Class37();
      private readonly PdfExporter.Class37 class37_2 = new PdfExporter.Class37();

      public PdfExporter.Class37 BottomElements
      {
        get
        {
          return this.class37_0;
        }
      }

      public PdfExporter.Class37 TopElements
      {
        get
        {
          return this.class37_1;
        }
      }

      public PdfExporter.Class37 TextElements
      {
        get
        {
          return this.class37_2;
        }
      }

      public void imethod_0(PdfContentStream pdfStream)
      {
        this.class37_0.method_2(pdfStream);
        this.class37_1.method_2(pdfStream);
        this.class37_2.method_2(pdfStream);
      }
    }

    private class Class36 : PdfExporter.Interface1
    {
      private readonly PdfExporter.Class37 class37_0 = new PdfExporter.Class37();

      public PdfExporter.Class37 BottomElements
      {
        get
        {
          return this.class37_0;
        }
      }

      public PdfExporter.Class37 TopElements
      {
        get
        {
          return this.class37_0;
        }
      }

      public PdfExporter.Class37 TextElements
      {
        get
        {
          return this.class37_0;
        }
      }

      public void imethod_0(PdfContentStream pdfStream)
      {
        this.class37_0.method_2(pdfStream);
      }
    }

    private class Class37
    {
      private static readonly byte[] byte_0 = PdfWriter.StandardEncoding.GetBytes("BT");
      private static readonly byte[] byte_1 = PdfWriter.StandardEncoding.GetBytes("ET");
      private List<byte[]> list_0 = new List<byte[]>();
      private float float_0 = -1f;
      private bool bool_0;
      private bool bool_1;

      public float CurrentLineWidth
      {
        get
        {
          return this.float_0;
        }
        set
        {
          this.float_0 = value;
        }
      }

      public void Add(string element)
      {
        this.Add(PdfWriter.StandardEncoding.GetBytes(element));
      }

      public void Add(byte[] element)
      {
        if (this.bool_1 && !this.bool_0)
          this.list_0.Add(PdfExporter.Class37.byte_0);
        else if (!this.bool_1 && this.bool_0)
          this.list_0.Add(PdfExporter.Class37.byte_1);
        this.list_0.Add(element);
        this.bool_0 = this.bool_1;
      }

      public void method_0()
      {
        this.bool_1 = true;
      }

      public void method_1()
      {
        this.bool_1 = false;
      }

      public void method_2(PdfContentStream pdfStream)
      {
        this.method_3();
        foreach (byte[] data in this.list_0)
          pdfStream.XOut.WriteLine(data);
        this.list_0 = (List<byte[]>) null;
      }

      private void method_3()
      {
        if (!this.bool_0)
          return;
        this.list_0.Add(PdfExporter.Class37.byte_1);
      }
    }
  }
}
