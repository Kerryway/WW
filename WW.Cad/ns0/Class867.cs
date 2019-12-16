// Decompiled with JetBrains decompiler
// Type: ns0.Class867
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model;

namespace ns0
{
  internal static class Class867
  {
    public static bool smethod_0(DrawingCodePage codePage)
    {
      if (codePage != DrawingCodePage.Gb2312 && codePage != DrawingCodePage.Ansi950 && (codePage != DrawingCodePage.Johab && codePage != DrawingCodePage.Ansi950) && (codePage != DrawingCodePage.Johab && codePage != DrawingCodePage.Gb2312 && codePage != DrawingCodePage.Ksc5601))
        return codePage == DrawingCodePage.Dos932;
      return true;
    }
  }
}
