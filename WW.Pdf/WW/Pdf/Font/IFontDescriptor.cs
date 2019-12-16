// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Font.IFontDescriptor
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using WW.Pdf.Font.Gdi;

namespace WW.Pdf.Font
{
  public interface IFontDescriptor
  {
    int Flags { get; }

    int[] FontBBox { get; }

    int ItalicAngle { get; }

    int StemV { get; }

    bool HasKerningInfo { get; }

    bool IsEmbeddable { get; }

    bool IsSubsettable { get; }

    byte[] FontData { get; }

    GdiKerningPairs KerningInfo { get; }
  }
}
