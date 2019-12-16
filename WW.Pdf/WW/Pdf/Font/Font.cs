// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Font.Font
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;

namespace WW.Pdf.Font
{
  public abstract class Font : IFontMetric
  {
    public abstract string Encoding { get; }

    public abstract string FontName { get; }

    public abstract PdfFontTypeEnum Type { get; }

    public abstract PdfFontSubTypeEnum SubType { get; }

    public abstract IFontDescriptor Descriptor { get; }

    public abstract bool MultiByteFont { get; }

    public abstract ushort MapCharacter(char c);

    public abstract int Ascender { get; }

    public abstract int Descender { get; }

    public abstract int CapHeight { get; }

    public abstract int FirstChar { get; }

    public abstract int LastChar { get; }

    public abstract int GetWidth(ushort charIndex);

    public abstract int[] Widths { get; }

    public static WW.Pdf.Font.Font CreateProxyFont(
      FontProperties fontProperties,
      FontType fontType)
    {
      return (WW.Pdf.Font.Font) new Class29(fontProperties, fontType);
    }
  }
}
