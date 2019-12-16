// Decompiled with JetBrains decompiler
// Type: ns7.Class33
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns1;
using ns4;
using WW.Pdf;
using WW.Pdf.Font;
using WW.Pdf.Font.Gdi;

namespace ns7
{
  internal class Class33 : WW.Pdf.Font.Font, IFontDescriptor
  {
    private Class72 class72_0 = Class72.smethod_0("WinAnsiEncoding");
    public const string string_0 = "WinAnsiEncoding";
    private Class53 class53_0;
    private Class42 class42_0;
    private GdiKerningPairs gdiKerningPairs_0;
    private int[] int_0;
    protected FontProperties fontProperties_0;

    public Class33(FontProperties properties)
    {
      this.fontProperties_0 = properties;
      this.method_0();
    }

    private void method_0()
    {
      this.class53_0 = new Class53();
      this.class42_0 = Class78.smethod_1(this.fontProperties_0.FaceName, this.fontProperties_0.IsBold, this.fontProperties_0.IsItalic, this.class53_0).method_0(this.class53_0);
    }

    public PdfArray Array
    {
      get
      {
        PdfArray pdfArray = new PdfArray();
        foreach (int width in this.Widths)
          pdfArray.Add((IPdfObject) new PdfInt(width));
        return pdfArray;
      }
    }

    public override PdfFontSubTypeEnum SubType
    {
      get
      {
        return PdfFontSubTypeEnum.TrueType;
      }
    }

    public override string FontName
    {
      get
      {
        if (this.fontProperties_0.IsBoldItalic)
          return string.Format("{0},BoldItalic", (object) this.fontProperties_0.PdfBaseName);
        if (this.fontProperties_0.IsBold)
          return string.Format("{0},Bold", (object) this.fontProperties_0.PdfBaseName);
        if (this.fontProperties_0.IsItalic)
          return string.Format("{0},Italic", (object) this.fontProperties_0.PdfBaseName);
        return this.fontProperties_0.PdfBaseName;
      }
    }

    public override PdfFontTypeEnum Type
    {
      get
      {
        return PdfFontTypeEnum.TrueType;
      }
    }

    public override string Encoding
    {
      get
      {
        return "WinAnsiEncoding";
      }
    }

    public override IFontDescriptor Descriptor
    {
      get
      {
        return (IFontDescriptor) this;
      }
    }

    public override bool MultiByteFont
    {
      get
      {
        return false;
      }
    }

    public override ushort MapCharacter(char c)
    {
      if (c > 'ÿ')
        return (ushort) this.FirstChar;
      return this.class72_0.method_0(c);
    }

    public override int Ascender
    {
      get
      {
        return this.class42_0.Ascent;
      }
    }

    public override int Descender
    {
      get
      {
        return this.class42_0.Descent;
      }
    }

    public override int CapHeight
    {
      get
      {
        return this.class42_0.CapHeight;
      }
    }

    public override int FirstChar
    {
      get
      {
        return 0;
      }
    }

    public override int LastChar
    {
      get
      {
        return (int) byte.MaxValue;
      }
    }

    public override int GetWidth(ushort charIndex)
    {
      this.method_1();
      return this.int_0[(int) charIndex];
    }

    public override int[] Widths
    {
      get
      {
        this.method_1();
        return this.int_0;
      }
    }

    private void method_1()
    {
      if (this.int_0 != null)
        return;
      this.int_0 = this.class42_0.method_4();
    }

    public int Flags
    {
      get
      {
        return this.class42_0.Flags;
      }
    }

    public int[] FontBBox
    {
      get
      {
        return this.class42_0.BoundingBox;
      }
    }

    public int ItalicAngle
    {
      get
      {
        return this.class42_0.ItalicAngle;
      }
    }

    public int StemV
    {
      get
      {
        return this.class42_0.StemV;
      }
    }

    public bool HasKerningInfo
    {
      get
      {
        if (this.gdiKerningPairs_0 == null)
          this.gdiKerningPairs_0 = this.class42_0.AnsiKerningPairs;
        return this.gdiKerningPairs_0.Count != 0;
      }
    }

    public bool IsEmbeddable
    {
      get
      {
        return false;
      }
    }

    public bool IsSubsettable
    {
      get
      {
        return false;
      }
    }

    public byte[] FontData
    {
      get
      {
        return this.class42_0.method_0();
      }
    }

    public GdiKerningPairs KerningInfo
    {
      get
      {
        if (this.gdiKerningPairs_0 == null)
          this.gdiKerningPairs_0 = this.class42_0.AnsiKerningPairs;
        return this.gdiKerningPairs_0;
      }
    }
  }
}
