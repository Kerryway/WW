// Decompiled with JetBrains decompiler
// Type: WW.Text.Encodings
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Text;

namespace WW.Text
{
  public static class Encodings
  {
    private static Encoding encoding_0;
    private static Encoding encoding_1;
    private static Encoding encoding_2;
    private static Encoding encoding_3;
    private static Encoding encoding_4;
    private static Encoding encoding_5;
    private static Encoding encoding_6;
    private static Encoding encoding_7;
    private static Encoding encoding_8;
    private static Encoding encoding_9;
    private static Encoding encoding_10;
    private static Encoding encoding_11;
    private static Encoding encoding_12;
    private static Encoding encoding_13;
    private static Encoding encoding_14;
    private static Encoding encoding_15;
    private static Encoding encoding_16;
    private static Encoding encoding_17;
    private static Encoding encoding_18;
    private static Encoding encoding_19;
    private static Encoding encoding_20;
    private static Encoding encoding_21;
    private static Encoding encoding_22;
    private static Encoding encoding_23;
    private static Encoding encoding_24;
    private static Encoding encoding_25;
    private static Encoding encoding_26;
    private static Encoding encoding_27;
    private static Encoding encoding_28;
    private static Encoding encoding_29;
    private static Encoding encoding_30;
    private static Encoding encoding_31;
    private static Encoding encoding_32;
    private static Encoding encoding_33;
    private static Encoding encoding_34;
    private static Encoding encoding_35;
    private static Encoding encoding_36;
    private static Encoding encoding_37;
    private static Encoding encoding_38;
    private static Encoding encoding_39;
    private static Encoding encoding_40;
    private static Encoding encoding_41;
    private static Encoding encoding_42;
    private static Encoding encoding_43;
    private static Encoding encoding_44;

    public static Encoding Johab
    {
      get
      {
        if (Encodings.encoding_31 == null)
          Encodings.encoding_31 = Encoding.GetEncoding(1361);
        return Encodings.encoding_31;
      }
    }

    public static Encoding Ksc5601
    {
      get
      {
        if (Encodings.encoding_20 == null)
          Encodings.encoding_20 = Encoding.GetEncoding(949);
        return Encodings.encoding_20;
      }
    }

    public static Encoding Ansi950
    {
      get
      {
        if (Encodings.encoding_21 == null)
          Encodings.encoding_21 = Encoding.GetEncoding(950);
        return Encodings.encoding_21;
      }
    }

    public static Encoding GetEncoding(int codePage)
    {
      Encoding encoding;
      switch (codePage)
      {
        case 0:
          encoding = Encodings.Default;
          break;
        case 437:
          encoding = Encodings.Ibm437;
          break;
        case 720:
          encoding = Encodings.Dos720;
          break;
        case 737:
          encoding = Encodings.Dos737;
          break;
        case 775:
          encoding = Encodings.Dos775;
          break;
        case 850:
          encoding = Encodings.Dos850;
          break;
        case 852:
          encoding = Encodings.Dos852;
          break;
        case 855:
          encoding = Encodings.Dos855;
          break;
        case 857:
          encoding = Encodings.Dos857;
          break;
        case 860:
          encoding = Encodings.Dos860;
          break;
        case 861:
          encoding = Encodings.Dos861;
          break;
        case 862:
          encoding = Encodings.Dos862;
          break;
        case 863:
          encoding = Encodings.Dos863;
          break;
        case 864:
          encoding = Encodings.Dos864;
          break;
        case 865:
          encoding = Encodings.Dos865;
          break;
        case 866:
          encoding = Encodings.Dos866;
          break;
        case 869:
          encoding = Encodings.Dos869;
          break;
        case 874:
          encoding = Encodings.Windows874;
          break;
        case 932:
          encoding = Encodings.Dos932;
          break;
        case 936:
          encoding = Encodings.Gb2312;
          break;
        case 949:
          encoding = Encodings.Ksc5601;
          break;
        case 950:
          encoding = Encodings.Ansi950;
          break;
        case 1200:
          encoding = Encodings.Utf16;
          break;
        case 1201:
          encoding = Encoding.BigEndianUnicode;
          break;
        case 1250:
          encoding = Encodings.Ansi1250;
          break;
        case 1251:
          encoding = Encodings.Ansi1251;
          break;
        case 1252:
          encoding = Encodings.Ansi1252;
          break;
        case 1253:
          encoding = Encodings.Ansi1253;
          break;
        case 1254:
          encoding = Encodings.Ansi1254;
          break;
        case 1255:
          encoding = Encodings.Ansi1255;
          break;
        case 1256:
          encoding = Encodings.Ansi1256;
          break;
        case 1257:
          encoding = Encodings.Ansi1257;
          break;
        case 1258:
          encoding = Encodings.Ansi1258;
          break;
        case 1361:
          encoding = Encodings.Johab;
          break;
        case 2860:
          encoding = Encodings.Iso8859_15;
          break;
        case 10000:
          encoding = Encodings.MacRoman;
          break;
        case 20127:
          encoding = Encodings.Ascii;
          break;
        case 28591:
          encoding = Encodings.Iso8859_1;
          break;
        case 28592:
          encoding = Encodings.Iso8859_2;
          break;
        case 28593:
          encoding = Encodings.Iso8859_3;
          break;
        case 28594:
          encoding = Encodings.Iso8859_4;
          break;
        case 28595:
          encoding = Encodings.Iso8859_5;
          break;
        case 28596:
          encoding = Encodings.Iso8859_6;
          break;
        case 28597:
          encoding = Encodings.Iso8859_7;
          break;
        case 28598:
          encoding = Encodings.Iso8859_8;
          break;
        case 28599:
          encoding = Encodings.Iso8859_9;
          break;
        case 28603:
          encoding = Encodings.Iso8859_13;
          break;
        case 65001:
          encoding = Encoding.UTF8;
          break;
        default:
          throw new ArgumentException("Unsupported codepage.");
      }
      return encoding;
    }

    public static int GetCodePage(Encoding encoding)
    {
      return encoding.CodePage;
    }

    public static Encoding Default
    {
      get
      {
        return Encoding.Default;
      }
    }

    public static Encoding Ascii
    {
      get
      {
        if (Encodings.encoding_0 == null)
          Encodings.encoding_0 = Encoding.ASCII;
        return Encodings.encoding_0;
      }
    }

    public static Encoding Ibm437
    {
      get
      {
        if (Encodings.encoding_1 == null)
          Encodings.encoding_1 = Encoding.GetEncoding(437);
        return Encodings.encoding_1;
      }
    }

    public static Encoding Dos850
    {
      get
      {
        if (Encodings.encoding_2 == null)
          Encodings.encoding_2 = Encoding.GetEncoding(850);
        return Encodings.encoding_2;
      }
    }

    public static Encoding Dos852
    {
      get
      {
        if (Encodings.encoding_3 == null)
          Encodings.encoding_3 = Encoding.GetEncoding(852);
        return Encodings.encoding_3;
      }
    }

    public static Encoding Dos855
    {
      get
      {
        if (Encodings.encoding_4 == null)
          Encodings.encoding_4 = Encoding.GetEncoding(855);
        return Encodings.encoding_4;
      }
    }

    public static Encoding Dos857
    {
      get
      {
        if (Encodings.encoding_5 == null)
          Encodings.encoding_5 = Encoding.GetEncoding(857);
        return Encodings.encoding_5;
      }
    }

    public static Encoding Dos860
    {
      get
      {
        if (Encodings.encoding_6 == null)
          Encodings.encoding_6 = Encoding.GetEncoding(860);
        return Encodings.encoding_6;
      }
    }

    public static Encoding Dos861
    {
      get
      {
        if (Encodings.encoding_7 == null)
          Encodings.encoding_7 = Encoding.GetEncoding(861);
        return Encodings.encoding_7;
      }
    }

    public static Encoding Dos862
    {
      get
      {
        if (Encodings.encoding_8 == null)
          Encodings.encoding_8 = Encoding.GetEncoding(862);
        return Encodings.encoding_8;
      }
    }

    public static Encoding Dos863
    {
      get
      {
        if (Encodings.encoding_9 == null)
          Encodings.encoding_9 = Encoding.GetEncoding(863);
        return Encodings.encoding_9;
      }
    }

    public static Encoding Dos864
    {
      get
      {
        if (Encodings.encoding_10 == null)
          Encodings.encoding_10 = Encoding.GetEncoding(864);
        return Encodings.encoding_10;
      }
    }

    public static Encoding Dos865
    {
      get
      {
        if (Encodings.encoding_11 == null)
          Encodings.encoding_11 = Encoding.GetEncoding(865);
        return Encodings.encoding_11;
      }
    }

    public static Encoding Dos866
    {
      get
      {
        if (Encodings.encoding_12 == null)
          Encodings.encoding_12 = Encoding.GetEncoding(866);
        return Encodings.encoding_12;
      }
    }

    public static Encoding Dos869
    {
      get
      {
        if (Encodings.encoding_13 == null)
          Encodings.encoding_13 = Encoding.GetEncoding(869);
        return Encodings.encoding_13;
      }
    }

    public static Encoding Dos720
    {
      get
      {
        if (Encodings.encoding_14 == null)
          Encodings.encoding_14 = Encoding.GetEncoding(720);
        return Encodings.encoding_14;
      }
    }

    public static Encoding Dos737
    {
      get
      {
        if (Encodings.encoding_15 == null)
          Encodings.encoding_15 = Encoding.GetEncoding(737);
        return Encodings.encoding_15;
      }
    }

    public static Encoding Dos775
    {
      get
      {
        if (Encodings.encoding_16 == null)
          Encodings.encoding_16 = Encoding.GetEncoding(775);
        return Encodings.encoding_16;
      }
    }

    public static Encoding Windows874
    {
      get
      {
        if (Encodings.encoding_17 == null)
          Encodings.encoding_17 = Encoding.GetEncoding(874);
        return Encodings.encoding_17;
      }
    }

    public static Encoding Utf16
    {
      get
      {
        return Encoding.Unicode;
      }
    }

    public static Encoding Ansi1250
    {
      get
      {
        if (Encodings.encoding_22 == null)
          Encodings.encoding_22 = Encoding.GetEncoding(1250);
        return Encodings.encoding_22;
      }
    }

    public static Encoding Ansi1251
    {
      get
      {
        if (Encodings.encoding_23 == null)
          Encodings.encoding_23 = Encoding.GetEncoding(1251);
        return Encodings.encoding_23;
      }
    }

    public static Encoding Ansi1252
    {
      get
      {
        if (Encodings.encoding_24 == null)
          Encodings.encoding_24 = Encoding.GetEncoding(1252);
        return Encodings.encoding_24;
      }
    }

    public static Encoding Ansi1253
    {
      get
      {
        if (Encodings.encoding_25 == null)
          Encodings.encoding_25 = Encoding.GetEncoding(1253);
        return Encodings.encoding_25;
      }
    }

    public static Encoding Ansi1254
    {
      get
      {
        if (Encodings.encoding_26 == null)
          Encodings.encoding_26 = Encoding.GetEncoding(1254);
        return Encodings.encoding_26;
      }
    }

    public static Encoding Ansi1255
    {
      get
      {
        if (Encodings.encoding_27 == null)
          Encodings.encoding_27 = Encoding.GetEncoding(1255);
        return Encodings.encoding_27;
      }
    }

    public static Encoding Ansi1256
    {
      get
      {
        if (Encodings.encoding_28 == null)
          Encodings.encoding_28 = Encoding.GetEncoding(1256);
        return Encodings.encoding_28;
      }
    }

    public static Encoding Ansi1257
    {
      get
      {
        if (Encodings.encoding_29 == null)
          Encodings.encoding_29 = Encoding.GetEncoding(1257);
        return Encodings.encoding_29;
      }
    }

    public static Encoding Ansi1258
    {
      get
      {
        if (Encodings.encoding_30 == null)
          Encodings.encoding_30 = Encoding.GetEncoding(1258);
        return Encodings.encoding_30;
      }
    }

    public static Encoding MacRoman
    {
      get
      {
        if (Encodings.encoding_32 == null)
          Encodings.encoding_32 = Encoding.GetEncoding(10000);
        return Encodings.encoding_32;
      }
    }

    public static Encoding Iso8859_1
    {
      get
      {
        if (Encodings.encoding_33 == null)
          Encodings.encoding_33 = Encoding.GetEncoding(28591);
        return Encodings.encoding_33;
      }
    }

    public static Encoding Iso8859_2
    {
      get
      {
        if (Encodings.encoding_34 == null)
          Encodings.encoding_34 = Encoding.GetEncoding(28592);
        return Encodings.encoding_34;
      }
    }

    public static Encoding Iso8859_3
    {
      get
      {
        if (Encodings.encoding_35 == null)
          Encodings.encoding_35 = Encoding.GetEncoding(28593);
        return Encodings.encoding_35;
      }
    }

    public static Encoding Iso8859_4
    {
      get
      {
        if (Encodings.encoding_36 == null)
          Encodings.encoding_36 = Encoding.GetEncoding(28594);
        return Encodings.encoding_36;
      }
    }

    public static Encoding Iso8859_5
    {
      get
      {
        if (Encodings.encoding_37 == null)
          Encodings.encoding_37 = Encoding.GetEncoding(28595);
        return Encodings.encoding_37;
      }
    }

    public static Encoding Iso8859_6
    {
      get
      {
        if (Encodings.encoding_38 == null)
          Encodings.encoding_38 = Encoding.GetEncoding(28596);
        return Encodings.encoding_38;
      }
    }

    public static Encoding Iso8859_7
    {
      get
      {
        if (Encodings.encoding_39 == null)
          Encodings.encoding_39 = Encoding.GetEncoding(28597);
        return Encodings.encoding_39;
      }
    }

    public static Encoding Iso8859_8
    {
      get
      {
        if (Encodings.encoding_40 == null)
          Encodings.encoding_40 = Encoding.GetEncoding(28598);
        return Encodings.encoding_40;
      }
    }

    public static Encoding Iso8859_9
    {
      get
      {
        if (Encodings.encoding_41 == null)
          Encodings.encoding_41 = Encoding.GetEncoding(28599);
        return Encodings.encoding_41;
      }
    }

    public static Encoding Iso8859_13
    {
      get
      {
        if (Encodings.encoding_43 == null)
          Encodings.encoding_43 = Encoding.GetEncoding(28603);
        return Encodings.encoding_43;
      }
    }

    public static Encoding Iso8859_15
    {
      get
      {
        if (Encodings.encoding_44 == null)
          Encodings.encoding_44 = Encoding.GetEncoding(28605);
        return Encodings.encoding_44;
      }
    }

    public static Encoding Dos932
    {
      get
      {
        if (Encodings.encoding_18 == null)
          Encodings.encoding_18 = Encoding.GetEncoding(932);
        return Encodings.encoding_18;
      }
    }

    public static Encoding Gb2312
    {
      get
      {
        if (Encodings.encoding_19 == null)
          Encodings.encoding_19 = Encoding.GetEncoding(936);
        return Encodings.encoding_19;
      }
    }
  }
}
