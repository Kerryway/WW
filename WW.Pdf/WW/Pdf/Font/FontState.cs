// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Font.FontState
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using WW.Pdf.Font.Gdi;

namespace WW.Pdf.Font
{
  public class FontState
  {
    private readonly PdfFontInfo pdfFontInfo_0;
    private readonly string string_0;
    private readonly int int_0;
    private readonly string string_1;
    private readonly string string_2;
    private readonly string string_3;
    private readonly int int_1;
    private readonly IFontMetric ifontMetric_0;
    private readonly int int_2;

    public FontState(
      PdfFontInfo fontInfo,
      string fontFamily,
      string fontStyle,
      string fontWeight,
      int fontSize)
    {
      this.pdfFontInfo_0 = fontInfo;
      this.string_1 = fontFamily;
      this.string_2 = fontStyle;
      this.string_3 = fontWeight;
      this.int_0 = fontSize;
      this.string_0 = fontInfo.FontLookup(fontFamily, fontStyle, fontWeight);
      this.ifontMetric_0 = fontInfo.GetMetricsFor(this.string_0);
      this.int_1 = 52;
      this.int_2 = 0;
    }

    public FontState(
      PdfFontInfo fontInfo,
      string fontFamily,
      string fontStyle,
      string fontWeight,
      int fontSize,
      int letterSpacing)
      : this(fontInfo, fontFamily, fontStyle, fontWeight, fontSize)
    {
      this.int_2 = letterSpacing;
    }

    public int Ascender
    {
      get
      {
        return this.ifontMetric_0.Ascender * this.int_0 / 1000;
      }
    }

    public int LetterSpacing
    {
      get
      {
        return this.int_2;
      }
    }

    public int CapHeight
    {
      get
      {
        return this.ifontMetric_0.CapHeight * this.int_0 / 1000;
      }
    }

    public int Descender
    {
      get
      {
        return this.ifontMetric_0.Descender * this.int_0 / 1000;
      }
    }

    public string FontName
    {
      get
      {
        return this.string_0;
      }
    }

    public int FontSize
    {
      get
      {
        return this.int_0;
      }
    }

    public string FontWeight
    {
      get
      {
        return this.string_3;
      }
    }

    public string FontFamily
    {
      get
      {
        return this.string_1;
      }
    }

    public string FontStyle
    {
      get
      {
        return this.string_2;
      }
    }

    public int FontVariant
    {
      get
      {
        return this.int_1;
      }
    }

    public PdfFontInfo FontInfo
    {
      get
      {
        return this.pdfFontInfo_0;
      }
    }

    internal GdiKerningPairs Kerning
    {
      get
      {
        IFontDescriptor descriptor = this.ifontMetric_0.Descriptor;
        if (descriptor != null && descriptor.HasKerningInfo)
          return descriptor.KerningInfo;
        return GdiKerningPairs.Empty;
      }
    }

    public int GetWidth(ushort charId)
    {
      return this.int_2 + this.ifontMetric_0.GetWidth(charId) * this.int_0 / 1000;
    }

    public ushort MapCharacter(char c)
    {
      if (this.ifontMetric_0 is WW.Pdf.Font.Font)
        return ((WW.Pdf.Font.Font) this.ifontMetric_0).MapCharacter(c);
      ushort num = Class72.smethod_0("WinAnsiEncoding").method_0(c);
      if (num == (ushort) 0)
        return 35;
      return num;
    }
  }
}
