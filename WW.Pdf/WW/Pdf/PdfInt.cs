// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfInt
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System;
using System.Globalization;

namespace WW.Pdf
{
  public class PdfInt : IPdfObject
  {
    private int int_0;

    public PdfInt()
    {
    }

    public PdfInt(int value)
    {
      this.int_0 = value;
    }

    public int Value
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

    public override string ToString()
    {
      return this.int_0.ToString();
    }

    public void Write(ExtendedPdfOutput output)
    {
      output.Write(this.int_0.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    }
  }
}
