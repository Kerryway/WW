// Decompiled with JetBrains decompiler
// Type: WW.Drawing.FontUtil
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Drawing;

namespace WW.Drawing
{
  public static class FontUtil
  {
    public static bool IsBold(Font font)
    {
      return (font.Style & FontStyle.Bold) == FontStyle.Bold;
    }

    public static bool IsItalic(Font font)
    {
      return (font.Style & FontStyle.Italic) == FontStyle.Italic;
    }

    public static bool IsUnderlined(Font font)
    {
      return (font.Style & FontStyle.Underline) == FontStyle.Underline;
    }

    public static bool IsStrikedOut(Font font)
    {
      return (font.Style & FontStyle.Strikeout) == FontStyle.Strikeout;
    }
  }
}
