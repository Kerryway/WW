// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Font.PdfFontFile
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using WW.Pdf.Filter;

namespace WW.Pdf.Font
{
  public class PdfFontFile : PdfStream
  {
    public PdfFontFile(byte[] fontData)
      : base(fontData)
    {
      this.AddFilter((IFilter) new FlateFilter());
      this.Dictionary["Length1"] = (IPdfObject) new PdfInt(fontData.Length);
    }
  }
}
