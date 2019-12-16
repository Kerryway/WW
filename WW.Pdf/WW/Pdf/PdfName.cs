// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfName
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace WW.Pdf
{
  public class PdfName : IPdfObject
  {
    private string string_0 = string.Empty;

    public PdfName()
    {
    }

    public PdfName(string name)
    {
      this.string_0 = name;
    }

    public string Name
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

    public void Write(ExtendedPdfOutput output)
    {
      output.Write("/").Write(this.string_0);
    }
  }
}
