// Decompiled with JetBrains decompiler
// Type: ns9.Class38
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns8;
using WW.Pdf;
using WW.Pdf.Font;

namespace ns9
{
  internal class Class38 : PdfFont
  {
    public Class38(string fontName, string baseFont)
      : base(fontName, baseFont, "TrueType")
    {
      this.value[nameof (FirstChar)] = (IPdfObject) new PdfInt(0);
      this.value[nameof (LastChar)] = (IPdfObject) new PdfInt((int) byte.MaxValue);
    }

    public PdfIndirectObject<Class40> Descriptor
    {
      set
      {
        this.value["FontDescriptor"] = (IPdfObject) new PdfReference((IPdfIndirectObject) value);
      }
    }

    public int FirstChar
    {
      set
      {
        this.value[nameof (FirstChar)] = (IPdfObject) new PdfInt(value);
      }
    }

    public int LastChar
    {
      set
      {
        this.value[nameof (LastChar)] = (IPdfObject) new PdfInt(value);
      }
    }

    public PdfArray Widths
    {
      set
      {
        this.value[nameof (Widths)] = (IPdfObject) value;
      }
    }
  }
}
