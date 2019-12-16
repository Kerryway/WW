// Decompiled with JetBrains decompiler
// Type: ns2.Class43
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace ns2
{
  internal class Class43
  {
    private readonly ushort ushort_0;
    private ushort ushort_1;
    private readonly ushort ushort_2;

    public Class43(ushort startIndex, ushort unicodeValue)
    {
      this.ushort_0 = startIndex;
      this.ushort_1 = startIndex;
      this.ushort_2 = unicodeValue;
    }

    public void method_0()
    {
      ++this.ushort_1;
    }

    public ushort StartGlyphIndex
    {
      get
      {
        return this.ushort_0;
      }
    }

    public ushort EndGlyphIndex
    {
      get
      {
        return this.ushort_1;
      }
    }

    public ushort UnicodeValue
    {
      get
      {
        return this.ushort_2;
      }
    }

    public bool IsRange
    {
      get
      {
        return (int) this.ushort_0 != (int) this.ushort_1;
      }
    }

    public bool IsChar
    {
      get
      {
        return !this.IsRange;
      }
    }
  }
}
