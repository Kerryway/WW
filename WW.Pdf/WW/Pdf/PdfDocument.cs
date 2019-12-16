// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfDocument
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System;
using System.Collections.Generic;

namespace WW.Pdf
{
  public class PdfDocument : IDisposable
  {
    private readonly PdfBodyCollection pdfBodyCollection_0 = new PdfBodyCollection();
    private int int_0;

    public PdfBodyCollection Bodies
    {
      get
      {
        return this.pdfBodyCollection_0;
      }
    }

    public int GetNextImageIndex()
    {
      return this.int_0++;
    }

    public void Dispose()
    {
      foreach (PdfBody pdfBody in (List<PdfBody>) this.pdfBodyCollection_0)
        pdfBody.Dispose();
      this.pdfBodyCollection_0.Clear();
    }
  }
}
