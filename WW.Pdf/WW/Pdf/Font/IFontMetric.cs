// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Font.IFontMetric
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace WW.Pdf.Font
{
  public interface IFontMetric
  {
    int Ascender { get; }

    int Descender { get; }

    int CapHeight { get; }

    int FirstChar { get; }

    int LastChar { get; }

    IFontDescriptor Descriptor { get; }

    int GetWidth(ushort charIndex);

    int[] Widths { get; }
  }
}
