// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfReal
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System;
using System.Globalization;

namespace WW.Pdf
{
  public class PdfReal : IPdfObject
  {
    private double double_0;

    public PdfReal()
    {
    }

    public PdfReal(double value)
    {
      this.double_0 = value;
    }

    public double Value
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

    public void Write(ExtendedPdfOutput output)
    {
      output.Write(this.double_0.ToString("f", (IFormatProvider) CultureInfo.InvariantCulture));
    }
  }
}
