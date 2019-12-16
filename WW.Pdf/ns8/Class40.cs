// Decompiled with JetBrains decompiler
// Type: ns8.Class40
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using WW.Pdf;
using WW.Pdf.Font;

namespace ns8
{
  internal class Class40 : PdfDictionary
  {
    public Class40(string fontName)
    {
      this["Type"] = (IPdfObject) new PdfName("Font");
      this["FontName"] = (IPdfObject) new PdfName(fontName);
    }

    public int Flags
    {
      set
      {
        this[nameof (Flags)] = (IPdfObject) new PdfInt(value);
      }
    }

    public PdfArray FontBBox
    {
      set
      {
        this[nameof (FontBBox)] = (IPdfObject) value;
      }
    }

    public int ItalicAngle
    {
      set
      {
        this[nameof (ItalicAngle)] = (IPdfObject) new PdfInt(value);
      }
    }

    public int Ascent
    {
      set
      {
        this[nameof (Ascent)] = (IPdfObject) new PdfInt(value);
      }
    }

    public int Descent
    {
      set
      {
        this[nameof (Descent)] = (IPdfObject) new PdfInt(value);
      }
    }

    public int CapHeight
    {
      set
      {
        this[nameof (CapHeight)] = (IPdfObject) new PdfInt(value);
      }
    }

    public int StemV
    {
      set
      {
        this[nameof (StemV)] = (IPdfObject) new PdfInt(value);
      }
    }

    public PdfIndirectObject<PdfFontFile> FontFile2
    {
      set
      {
        this[nameof (FontFile2)] = (IPdfObject) new PdfReference((IPdfIndirectObject) value);
      }
    }
  }
}
