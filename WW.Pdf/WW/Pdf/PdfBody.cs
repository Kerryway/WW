// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfBody
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System;
using System.Collections.Generic;
using WW.Pdf.Components;
using WW.Pdf.Font;

namespace WW.Pdf
{
  public class PdfBody : IDisposable
  {
    private readonly PdfIndirectObjectCollection pdfIndirectObjectCollection_0 = new PdfIndirectObjectCollection();
    private readonly PdfFontCollection pdfFontCollection_0 = new PdfFontCollection();
    private readonly PdfFontInfo pdfFontInfo_0 = new PdfFontInfo();
    private PdfDocumentInformation pdfDocumentInformation_0;
    private readonly PdfCatalog pdfCatalog_0;
    private readonly PdfOutlines pdfOutlines_0;
    private readonly PdfPages pdfPages_0;
    private readonly PdfProcedureSetArray pdfProcedureSetArray_0;
    private readonly FontSetup fontSetup_0;

    public PdfBody(FontType fontType)
    {
      this.pdfCatalog_0 = new PdfCatalog();
      this.pdfOutlines_0 = new PdfOutlines();
      this.pdfCatalog_0.Outlines = this.pdfOutlines_0;
      this.pdfPages_0 = new PdfPages();
      this.pdfCatalog_0.Pages = this.pdfPages_0;
      this.pdfProcedureSetArray_0 = new PdfProcedureSetArray();
      this.fontSetup_0 = new FontSetup(this.pdfFontInfo_0, fontType);
    }

    public PdfDocumentInformation DocumentInformation
    {
      get
      {
        return this.pdfDocumentInformation_0;
      }
      set
      {
        this.pdfDocumentInformation_0 = value;
      }
    }

    public PdfCatalog Catalog
    {
      get
      {
        return this.pdfCatalog_0;
      }
    }

    public PdfOutlines Outlines
    {
      get
      {
        return this.pdfOutlines_0;
      }
    }

    public PdfPages Pages
    {
      get
      {
        return this.pdfPages_0;
      }
    }

    public PdfProcedureSetArray ProcedureSetArray
    {
      get
      {
        return this.pdfProcedureSetArray_0;
      }
    }

    public PdfIndirectObjectCollection IndirectObjects
    {
      get
      {
        return this.pdfIndirectObjectCollection_0;
      }
    }

    public PdfFontCollection Fonts
    {
      get
      {
        return this.pdfFontCollection_0;
      }
    }

    public PdfFontInfo FontInfo
    {
      get
      {
        return this.pdfFontInfo_0;
      }
    }

    public FontSetup FontSetup
    {
      get
      {
        return this.fontSetup_0;
      }
    }

    public void EmbedFonts()
    {
      this.fontSetup_0.method_2(this);
    }

    public void Dispose()
    {
      foreach (IPdfIndirectObject pdfIndirectObject in (List<IPdfIndirectObject>) this.pdfIndirectObjectCollection_0)
        (pdfIndirectObject as IDisposable)?.Dispose();
      this.pdfIndirectObjectCollection_0.Clear();
    }
  }
}
