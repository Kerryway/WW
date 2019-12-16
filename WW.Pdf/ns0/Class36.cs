// Decompiled with JetBrains decompiler
// Type: ns0.Class36
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns7;
using WW.Pdf;
using WW.Pdf.Font;

namespace ns0
{
  internal class Class36 : PdfFont
  {
    public Class36(string fontName, string baseFont)
      : base(fontName, baseFont, "Type0")
    {
    }

    public PdfIndirectObject<PdfCMap> ToUnicode
    {
      set
      {
        this.value[nameof (ToUnicode)] = (IPdfObject) new PdfReference((IPdfIndirectObject) value);
      }
    }

    public Class35 Descendant
    {
      set
      {
        PdfArray pdfArray = new PdfArray();
        pdfArray.Add((IPdfObject) new PdfReference((IPdfIndirectObject) value));
        this.value["DescendantFonts"] = (IPdfObject) pdfArray;
      }
    }

    public new string Encoding
    {
      set
      {
        this.value[nameof (Encoding)] = (IPdfObject) new PdfName(value);
      }
    }
  }
}
