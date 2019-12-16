// Decompiled with JetBrains decompiler
// Type: ns28.Class952
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Text;
using WW.Cad.Model;
using WW.Text;

namespace ns28
{
  internal static class Class952
  {
    private static Class952.Class953[] class953_0 = new Class952.Class953[45]{ new Class952.Class953((ushort) 0, DrawingCodePage.Unknown), new Class952.Class953((ushort) 1, DrawingCodePage.Ascii), new Class952.Class953((ushort) 2, DrawingCodePage.Iso8859_1), new Class952.Class953((ushort) 3, DrawingCodePage.Iso8859_2), new Class952.Class953((ushort) 4, DrawingCodePage.Iso8859_3), new Class952.Class953((ushort) 5, DrawingCodePage.Iso8859_4), new Class952.Class953((ushort) 6, DrawingCodePage.Iso8859_5), new Class952.Class953((ushort) 7, DrawingCodePage.Iso8859_6), new Class952.Class953((ushort) 8, DrawingCodePage.Iso8859_7), new Class952.Class953((ushort) 9, DrawingCodePage.Iso8859_8), new Class952.Class953((ushort) 10, DrawingCodePage.Iso8859_9), new Class952.Class953((ushort) 11, DrawingCodePage.Dos437), new Class952.Class953((ushort) 12, DrawingCodePage.Dos850), new Class952.Class953((ushort) 13, DrawingCodePage.Dos852), new Class952.Class953((ushort) 14, DrawingCodePage.Dos855), new Class952.Class953((ushort) 15, DrawingCodePage.Dos857), new Class952.Class953((ushort) 16, DrawingCodePage.Dos860), new Class952.Class953((ushort) 17, DrawingCodePage.Dos861), new Class952.Class953((ushort) 18, DrawingCodePage.Dos863), new Class952.Class953((ushort) 19, DrawingCodePage.Dos864), new Class952.Class953((ushort) 20, DrawingCodePage.Dos865), new Class952.Class953((ushort) 21, DrawingCodePage.Dos869), new Class952.Class953((ushort) 22, DrawingCodePage.Dos932), new Class952.Class953((ushort) 23, DrawingCodePage.MacRoman), new Class952.Class953((ushort) 24, DrawingCodePage.Ansi950), new Class952.Class953((ushort) 25, DrawingCodePage.Ksc5601), new Class952.Class953((ushort) 26, DrawingCodePage.Johab), new Class952.Class953((ushort) 27, DrawingCodePage.Dos866), new Class952.Class953((ushort) 28, DrawingCodePage.Ansi1250), new Class952.Class953((ushort) 29, DrawingCodePage.Ansi1251), new Class952.Class953((ushort) 30, DrawingCodePage.Ansi1252), new Class952.Class953((ushort) 31, DrawingCodePage.Gb2312), new Class952.Class953((ushort) 32, DrawingCodePage.Ansi1253), new Class952.Class953((ushort) 33, DrawingCodePage.Ansi1254), new Class952.Class953((ushort) 34, DrawingCodePage.Ansi1255), new Class952.Class953((ushort) 35, DrawingCodePage.Ansi1256), new Class952.Class953((ushort) 36, DrawingCodePage.Ansi1257), new Class952.Class953((ushort) 37, DrawingCodePage.Windows874), new Class952.Class953((ushort) 38, DrawingCodePage.Dos932), new Class952.Class953((ushort) 39, DrawingCodePage.Gb2312), new Class952.Class953((ushort) 40, DrawingCodePage.Ksc5601), new Class952.Class953((ushort) 41, DrawingCodePage.Ansi950), new Class952.Class953((ushort) 42, DrawingCodePage.Johab), new Class952.Class953((ushort) 43, DrawingCodePage.Utf16), new Class952.Class953((ushort) 44, DrawingCodePage.Ansi1258) };
    public const int int_0 = 0;
    public const int int_1 = 1;
    public const int int_2 = 2;
    public const int int_3 = 3;
    public const int int_4 = 4;
    public const int int_5 = 5;
    public const int int_6 = 6;
    public const int int_7 = 7;
    public const int int_8 = 8;
    public const int int_9 = 9;
    public const int int_10 = 10;
    public const int int_11 = 11;
    public const int int_12 = 12;
    public const int int_13 = 13;
    public const int int_14 = 14;
    public const int int_15 = 15;
    public const int int_16 = 16;
    public const int int_17 = 17;
    public const int int_18 = 18;
    public const int int_19 = 19;
    public const int int_20 = 20;
    public const int int_21 = 21;
    public const int int_22 = 22;
    public const int int_23 = 23;
    public const int int_24 = 24;
    public const int int_25 = 25;
    public const int int_26 = 26;
    public const int int_27 = 27;
    public const int int_28 = 28;
    public const int int_29 = 29;
    public const int int_30 = 30;
    public const int int_31 = 31;
    public const int int_32 = 32;
    public const int int_33 = 33;
    public const int int_34 = 34;
    public const int int_35 = 35;
    public const int int_36 = 36;
    public const int int_37 = 37;
    public const int int_38 = 38;
    public const int int_39 = 39;
    public const int int_40 = 40;
    public const int int_41 = 41;
    public const int int_42 = 42;
    public const int int_43 = 43;
    public const int int_44 = 44;

    public static DrawingCodePage GetDrawingCodePage(int dwgCodePage)
    {
      if (dwgCodePage < Class952.class953_0.Length)
        return Class952.class953_0[dwgCodePage].DrawingCodePage;
      return DrawingCodePage.Unknown;
    }

    public static Encoding smethod_0(int dwgCodePage)
    {
      if (dwgCodePage < Class952.class953_0.Length)
        return Class952.class953_0[dwgCodePage].Encoding;
      return Encodings.Default;
    }

    public static ushort smethod_1(DrawingCodePage drawingCodePage)
    {
      foreach (Class952.Class953 class953 in Class952.class953_0)
      {
        if (class953.DrawingCodePage == drawingCodePage)
          return class953.DwgCodePage;
      }
      return 0;
    }

    private class Class953
    {
      private ushort ushort_0;
      private DrawingCodePage drawingCodePage_0;
      private Encoding encoding_0;

      public Class953(ushort dwgCodePage, DrawingCodePage drawingCodePage)
      {
        this.ushort_0 = dwgCodePage;
        this.drawingCodePage_0 = drawingCodePage;
        this.encoding_0 = Encodings.GetEncoding((int) drawingCodePage);
      }

      public ushort DwgCodePage
      {
        get
        {
          return this.ushort_0;
        }
      }

      public DrawingCodePage DrawingCodePage
      {
        get
        {
          return this.drawingCodePage_0;
        }
      }

      public Encoding Encoding
      {
        get
        {
          return this.encoding_0;
        }
      }
    }
  }
}
