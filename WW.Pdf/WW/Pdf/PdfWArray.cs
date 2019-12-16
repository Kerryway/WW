// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfWArray
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System;
using System.Globalization;
using WW.Collections.Generic;

namespace WW.Pdf
{
  public class PdfWArray : IPdfObject
  {
    private readonly PdfArray pdfArray_0 = new PdfArray();
    private readonly int int_0;

    public PdfWArray(int startCID)
    {
      this.int_0 = startCID;
    }

    public void AddEntry(int[] widths)
    {
      foreach (int width in widths)
        this.pdfArray_0.Add((IPdfObject) new PdfInt(width));
    }

    public void Write(ExtendedPdfOutput output)
    {
      output.Write("[");
      output.Write(this.StartCID.ToString((IFormatProvider) CultureInfo.InvariantCulture));
      output.Write(" [");
      foreach (IPdfObject pdfObject in (ActiveList<IPdfObject>) this.Array)
      {
        output.Write(" ");
        output.Write(pdfObject);
      }
      output.Write(" ]]");
    }

    public int StartCID
    {
      get
      {
        return this.int_0;
      }
    }

    public PdfArray Array
    {
      get
      {
        return this.pdfArray_0;
      }
    }
  }
}
