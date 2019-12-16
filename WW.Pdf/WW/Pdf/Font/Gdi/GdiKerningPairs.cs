// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Font.Gdi.GdiKerningPairs
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns10;
using ns8;

namespace WW.Pdf.Font.Gdi
{
  public class GdiKerningPairs
  {
    public static readonly GdiKerningPairs Empty = new GdiKerningPairs((Class77) null, (Class66) null);
    private readonly Class77 class77_0;
    private readonly Class66 class66_0;

    internal GdiKerningPairs(Class77 pairs, Class66 converter)
    {
      this.class77_0 = pairs;
      this.class66_0 = converter;
    }

    public int Count
    {
      get
      {
        if (this.class77_0 != null)
          return this.class77_0.Length;
        return 0;
      }
    }

    public bool HasPair(ushort left, ushort right)
    {
      if (this.class77_0 != null)
        return this.class77_0.method_0(left, right);
      return false;
    }

    public int this[ushort left, ushort right]
    {
      get
      {
        return this.class66_0.method_0(this.class77_0[left, right]);
      }
    }
  }
}
