// Decompiled with JetBrains decompiler
// Type: ns0.Class29
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns10;
using ns4;
using ns7;
using ns9;
using System;
using WW.Pdf.Font;
using WW.Pdf.Font.Gdi;

namespace ns0
{
  internal class Class29 : WW.Pdf.Font.Font, IFontDescriptor
  {
    private bool bool_0;
    private readonly FontProperties fontProperties_0;
    private WW.Pdf.Font.Font font_0;
    private readonly FontType fontType_0;

    public Class29(FontProperties properties, FontType fontType)
    {
      this.fontProperties_0 = properties;
      this.fontType_0 = fontType;
    }

    private void method_0()
    {
      if (this.bool_0)
        return;
      switch (this.fontType_0)
      {
        case FontType.Link:
          this.font_0 = (WW.Pdf.Font.Font) new Class33(this.fontProperties_0);
          break;
        case FontType.Embed:
        case FontType.Subset:
          this.font_0 = this.method_1();
          break;
        default:
          throw new Exception("Unknown font type: " + (object) this.fontType_0);
      }
      this.bool_0 = true;
    }

    private WW.Pdf.Font.Font method_1()
    {
      switch (this.fontType_0)
      {
        case FontType.Embed:
          this.font_0 = (WW.Pdf.Font.Font) new Class31(this.fontProperties_0);
          break;
        case FontType.Subset:
          this.font_0 = (WW.Pdf.Font.Font) new Class32(this.fontProperties_0);
          break;
      }
      bool flag = false;
      IFontDescriptor descriptor = this.font_0.Descriptor;
      if (!descriptor.IsEmbeddable)
        flag = true;
      if (this.font_0 is Class32 && !descriptor.IsSubsettable)
        flag = true;
      if (flag)
        this.font_0 = !this.fontProperties_0.IsBoldItalic ? (!this.fontProperties_0.IsBold ? (!this.fontProperties_0.IsItalic ? Class14.font_4 : Class14.font_6) : Class14.font_5) : Class14.font_7;
      return this.font_0;
    }

    public WW.Pdf.Font.Font RealFont
    {
      get
      {
        this.method_0();
        return this.font_0;
      }
    }

    public override PdfFontSubTypeEnum SubType
    {
      get
      {
        this.method_0();
        return this.font_0.SubType;
      }
    }

    public override string FontName
    {
      get
      {
        this.method_0();
        return this.font_0.FontName;
      }
    }

    public override PdfFontTypeEnum Type
    {
      get
      {
        this.method_0();
        return this.font_0.Type;
      }
    }

    public override string Encoding
    {
      get
      {
        this.method_0();
        return this.font_0.Encoding;
      }
    }

    public override IFontDescriptor Descriptor
    {
      get
      {
        this.method_0();
        return this.font_0.Descriptor;
      }
    }

    public override bool MultiByteFont
    {
      get
      {
        this.method_0();
        return this.font_0.MultiByteFont;
      }
    }

    public override ushort MapCharacter(char c)
    {
      this.method_0();
      return this.font_0.MapCharacter(c);
    }

    public override int Ascender
    {
      get
      {
        this.method_0();
        return this.font_0.Ascender;
      }
    }

    public override int Descender
    {
      get
      {
        this.method_0();
        return this.font_0.Descender;
      }
    }

    public override int CapHeight
    {
      get
      {
        this.method_0();
        return this.font_0.CapHeight;
      }
    }

    public override int FirstChar
    {
      get
      {
        this.method_0();
        return this.font_0.FirstChar;
      }
    }

    public override int LastChar
    {
      get
      {
        this.method_0();
        return this.font_0.LastChar;
      }
    }

    public override int GetWidth(ushort charIndex)
    {
      this.method_0();
      return this.font_0.GetWidth(charIndex);
    }

    public override int[] Widths
    {
      get
      {
        this.method_0();
        return this.font_0.Widths;
      }
    }

    public int Flags
    {
      get
      {
        this.method_0();
        return this.font_0.Descriptor.Flags;
      }
    }

    public int[] FontBBox
    {
      get
      {
        this.method_0();
        return this.font_0.Descriptor.FontBBox;
      }
    }

    public int ItalicAngle
    {
      get
      {
        this.method_0();
        return this.font_0.Descriptor.ItalicAngle;
      }
    }

    public int StemV
    {
      get
      {
        this.method_0();
        return this.font_0.Descriptor.StemV;
      }
    }

    public bool HasKerningInfo
    {
      get
      {
        this.method_0();
        return this.font_0.Descriptor.HasKerningInfo;
      }
    }

    public bool IsEmbeddable
    {
      get
      {
        this.method_0();
        return this.font_0.Descriptor.IsEmbeddable;
      }
    }

    public bool IsSubsettable
    {
      get
      {
        this.method_0();
        return this.font_0.Descriptor.IsSubsettable;
      }
    }

    public byte[] FontData
    {
      get
      {
        this.method_0();
        return this.font_0.Descriptor.FontData;
      }
    }

    public GdiKerningPairs KerningInfo
    {
      get
      {
        this.method_0();
        return this.font_0.Descriptor.KerningInfo;
      }
    }
  }
}
