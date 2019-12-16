// Decompiled with JetBrains decompiler
// Type: ns4.Class14
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns1;
using ns10;
using ns11;
using ns5;
using ns6;
using ns8;
using ns9;
using System;
using WW.Pdf.Font;

namespace ns4
{
  internal abstract class Class14 : WW.Pdf.Font.Font
  {
    public static readonly WW.Pdf.Font.Font font_0 = (WW.Pdf.Font.Font) new Class23();
    public static readonly WW.Pdf.Font.Font font_1 = (WW.Pdf.Font.Font) new ns9.Class25();
    public static readonly WW.Pdf.Font.Font font_2 = (WW.Pdf.Font.Font) new Class27();
    public static readonly WW.Pdf.Font.Font font_3 = (WW.Pdf.Font.Font) new Class21();
    public static readonly WW.Pdf.Font.Font font_4 = (WW.Pdf.Font.Font) new Class28();
    public static readonly WW.Pdf.Font.Font font_5 = (WW.Pdf.Font.Font) new Class26();
    public static readonly WW.Pdf.Font.Font font_6 = (WW.Pdf.Font.Font) new Class24();
    public static readonly WW.Pdf.Font.Font font_7 = (WW.Pdf.Font.Font) new Class16();
    public static readonly WW.Pdf.Font.Font font_8 = (WW.Pdf.Font.Font) new Class19();
    public static readonly WW.Pdf.Font.Font font_9 = (WW.Pdf.Font.Font) new Class15();
    public static readonly WW.Pdf.Font.Font font_10 = (WW.Pdf.Font.Font) new Class20();
    public static readonly WW.Pdf.Font.Font font_11 = (WW.Pdf.Font.Font) new Class22();
    public static readonly WW.Pdf.Font.Font font_12 = (WW.Pdf.Font.Font) new Class18();
    public static readonly WW.Pdf.Font.Font font_13 = (WW.Pdf.Font.Font) new Class17();
    private readonly string string_0;
    private readonly int int_0;
    private readonly int int_1;
    private readonly int int_2;
    private readonly int int_3;
    private readonly int int_4;
    private readonly int[] int_5;
    private readonly ns0.Class72 class72_0;

    protected Class14(
      string fontName,
      int capHeight,
      int ascender,
      int descender,
      int firstChar,
      int lastChar,
      int[] widths,
      ns0.Class72 mapping)
    {
      this.string_0 = fontName;
      this.int_0 = capHeight;
      this.int_1 = ascender;
      this.int_2 = descender;
      this.int_3 = firstChar;
      this.int_4 = lastChar;
      this.int_5 = widths;
      this.class72_0 = mapping;
    }

    public override string Encoding
    {
      get
      {
        return this.class72_0.Name;
      }
    }

    public override string FontName
    {
      get
      {
        return this.string_0;
      }
    }

    public override PdfFontTypeEnum Type
    {
      get
      {
        return PdfFontTypeEnum.Type1;
      }
    }

    public override PdfFontSubTypeEnum SubType
    {
      get
      {
        return PdfFontSubTypeEnum.Type1;
      }
    }

    public override IFontDescriptor Descriptor
    {
      get
      {
        return (IFontDescriptor) null;
      }
    }

    public override bool MultiByteFont
    {
      get
      {
        return false;
      }
    }

    public override int Ascender
    {
      get
      {
        return this.int_1;
      }
    }

    public override int Descender
    {
      get
      {
        return this.int_2;
      }
    }

    public override int CapHeight
    {
      get
      {
        return this.int_0;
      }
    }

    public override int FirstChar
    {
      get
      {
        return this.int_3;
      }
    }

    public override int LastChar
    {
      get
      {
        return this.int_4;
      }
    }

    public override int GetWidth(ushort charIndex)
    {
      return this.int_5[(int) charIndex];
    }

    public override int[] Widths
    {
      get
      {
        int[] numArray = new int[this.LastChar - this.FirstChar + 1];
        Array.Copy((Array) this.int_5, this.FirstChar, (Array) numArray, 0, this.LastChar - this.FirstChar + 1);
        return numArray;
      }
    }

    public override ushort MapCharacter(char c)
    {
      ushort num = this.class72_0.method_0(c);
      if (num == (ushort) 0)
        return Convert.ToUInt16('?');
      return num;
    }
  }
}
