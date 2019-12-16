// Decompiled with JetBrains decompiler
// Type: ns7.Class35
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns1;
using ns8;
using WW.Pdf;
using WW.Pdf.Font;

namespace ns7
{
  internal class Class35 : PdfFont
  {
    public Class35(PdfFontSubTypeEnum subType, string baseFont)
      : base(baseFont, subType.ToString())
    {
      this.value["DW"] = (IPdfObject) new PdfInt(1000);
      this.value["CIDToGIDMap"] = (IPdfObject) new PdfName("Identity");
    }

    public Class39 SystemInfo
    {
      set
      {
        this.value["CIDSystemInfo"] = (IPdfObject) value;
      }
    }

    public PdfIndirectObject<Class40> Descriptor
    {
      set
      {
        this.value["FontDescriptor"] = (IPdfObject) new PdfReference((IPdfIndirectObject) value);
      }
    }

    public int DefaultWidth
    {
      set
      {
        this.value["DW"] = (IPdfObject) new PdfInt(value);
      }
    }

    public PdfWArray Widths
    {
      set
      {
        this.value["W"] = (IPdfObject) value;
      }
    }
  }
}
