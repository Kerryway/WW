// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfBool
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace WW.Pdf
{
  public class PdfBool : IPdfObject
  {
    private bool bool_0;

    public bool Value
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

    public void Write(ExtendedPdfOutput output)
    {
      output.WriteLine(this.bool_0 ? "true" : "false");
    }
  }
}
