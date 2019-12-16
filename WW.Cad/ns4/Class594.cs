// Decompiled with JetBrains decompiler
// Type: ns4.Class594
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns36;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Cad.Model.Text;
using WW.Math;
using WW.Math.Geometry;
using WW.Text;

namespace ns4
{
  internal class Class594
  {
    private static readonly FontStyle[] fontStyle_0 = new FontStyle[3]{ FontStyle.Regular, FontStyle.Bold, FontStyle.Italic };
    private static readonly Class594.Delegate14 delegate14_0 = new Class594.Delegate14(Class594.smethod_20);
    private static readonly Class594.Delegate14 delegate14_1 = new Class594.Delegate14(Class594.smethod_21);
    private static readonly Class594.Delegate14 delegate14_2 = new Class594.Delegate14(Class594.smethod_22);
    private static readonly Class594.Delegate14 delegate14_3 = new Class594.Delegate14(Class594.smethod_23);
    private const double double_0 = 1.5;
    private const char char_0 = 'Ø';
    public const char char_1 = ' ';
    internal const char char_2 = '\n';
    internal const double double_1 = 1.66666666666667;
    internal const string string_0 = "\t ,:;.-()\n";
    internal const string string_1 = ",:;.-()";
    internal const string string_2 = " ";
    internal const string string_3 = ",:;.-";
    internal const string string_4 = "";

    internal static bool smethod_0(
      string fontFilename,
      bool bold,
      bool italic,
      out FontFamily fontFamily,
      out FontStyle fontStyle)
    {
      fontFamily = (FontFamily) null;
      fontStyle = bold ? FontStyle.Bold : FontStyle.Regular;
      if (italic)
        fontStyle |= FontStyle.Italic;
      bool flag = false;
      if (!string.IsNullOrEmpty(fontFilename))
      {
        try
        {
          Class895 class895 = Class810.smethod_0(fontFilename);
          if (class895 != null)
          {
            fontFamily = new FontFamily(class895.FamilyName);
            if (class895.SubFamilyName.Contains("Italic") || class895.SubFamilyName.Contains("Oblique"))
              fontStyle |= FontStyle.Italic;
            if (class895.SubFamilyName.Contains("Bold"))
              fontStyle |= FontStyle.Bold;
            flag = fontFamily.IsStyleAvailable(fontStyle);
          }
        }
        catch (Exception ex)
        {
        }
      }
      if (!flag)
      {
        fontFamily = new FontFamily("Arial");
        fontStyle = bold ? FontStyle.Bold : FontStyle.Regular;
        if (italic)
          fontStyle |= FontStyle.Italic;
      }
      return flag;
    }

    internal static bool smethod_1(
      string fontName,
      bool bold,
      bool italic,
      out FontFamily fontFamily,
      out FontStyle fontStyle)
    {
      if (string.IsNullOrEmpty(fontName))
      {
        fontFamily = new FontFamily("Arial");
        fontStyle = bold ? FontStyle.Bold : FontStyle.Regular;
        if (italic)
          fontStyle |= FontStyle.Italic;
      }
      else
      {
        if (fontName.EndsWith(".ttf", StringComparison.InvariantCultureIgnoreCase))
          return Class594.smethod_0(fontName, bold, italic, out fontFamily, out fontStyle);
        if (!fontName.EndsWith(".shx", StringComparison.InvariantCultureIgnoreCase))
        {
          try
          {
            fontFamily = new FontFamily(fontName);
            foreach (FontStyle style in Class594.fontStyle_0)
            {
              if (fontFamily.IsStyleAvailable(style))
              {
                fontStyle = style;
                return true;
              }
            }
          }
          catch (ArgumentException ex)
          {
          }
        }
        fontFamily = new FontFamily("Arial");
        fontStyle = FontStyle.Regular;
      }
      return false;
    }

    internal static int smethod_2(string s, ref int startIndex)
    {
      bool flag;
      string s1;
      if (flag = startIndex < s.Length && s[startIndex] == '+')
      {
        ++startIndex;
        s1 = s.Substring(startIndex, 4);
      }
      else
      {
        StringBuilder stringBuilder = new StringBuilder();
        while (startIndex < s.Length)
        {
          char c = s[startIndex];
          if (char.IsDigit(c))
          {
            stringBuilder.Append(c);
            ++startIndex;
          }
          else
            break;
        }
        s1 = stringBuilder.ToString();
      }
      int num = flag ? int.Parse(s1, NumberStyles.HexNumber) : int.Parse(s1, (IFormatProvider) CultureInfo.InvariantCulture);
      startIndex += 4;
      return num;
    }

    internal static int smethod_3(string s, ref int startIndex)
    {
      StringBuilder stringBuilder = new StringBuilder();
      bool flag = startIndex < s.Length && s[startIndex] == '+';
      int num = 3;
      while (startIndex < s.Length)
      {
        char c = s[startIndex];
        if (char.IsDigit(c))
          stringBuilder.Append(c);
        else if (c != '+')
          break;
        ++startIndex;
        if (--num == 0)
          break;
      }
      return flag ? int.Parse(stringBuilder.ToString(), NumberStyles.HexNumber) : int.Parse(stringBuilder.ToString(), (IFormatProvider) CultureInfo.InvariantCulture);
    }

    internal static string smethod_4(DxfMText mtext)
    {
      string simplifiedText;
      Class594.smethod_14(mtext.Text, mtext.ReferenceRectangleWidth, mtext.Height, mtext.AttachmentPoint, mtext.LineSpacingFactor, mtext.LineSpacingStyle, mtext.Style, mtext.Style.WidthFactor, Colors.White, mtext.DrawingDirection, out simplifiedText);
      return simplifiedText;
    }

    internal static string smethod_5(DxfText text)
    {
      string simplifiedText;
      Class594.smethod_11(text.Text, text.Height, text.ObliqueAngle, text.WidthFactor, text.Style, Colors.White, out simplifiedText);
      return simplifiedText;
    }

    internal static string smethod_6(string s, int startIndex, out int lastParsedCharIndex)
    {
      string str = Class594.smethod_24(s, Class594.delegate14_2, startIndex, out lastParsedCharIndex);
      int index = lastParsedCharIndex + 1;
      if (index < s.Length && s[index] == ';')
        lastParsedCharIndex = index;
      return str;
    }

    internal static string smethod_7(string s, int startIndex, out int lastParsedCharIndex)
    {
      string str = Class594.smethod_24(s, Class594.delegate14_3, startIndex, out lastParsedCharIndex);
      int index = lastParsedCharIndex + 1;
      if (index < s.Length && s[index] == ';')
        lastParsedCharIndex = index;
      return str;
    }

    internal static int? smethod_8(string s, int startIndex, out int lastParsedCharIndex)
    {
      string s1 = Class594.smethod_24(s, Class594.delegate14_0, startIndex, out lastParsedCharIndex);
      int index = lastParsedCharIndex + 1;
      if (index < s.Length && s[index] == ';')
        lastParsedCharIndex = index;
      if (string.IsNullOrEmpty(s1))
        return new int?();
      int? nullable = new int?();
      int result1;
      if (int.TryParse(s1, NumberStyles.Integer, (IFormatProvider) CultureInfo.InvariantCulture, out result1))
      {
        nullable = new int?(result1);
      }
      else
      {
        uint result2;
        if (uint.TryParse(s1, NumberStyles.Integer, (IFormatProvider) CultureInfo.InvariantCulture, out result2))
          nullable = new int?((int) result2);
      }
      return nullable;
    }

    internal static double smethod_9(
      string s,
      int startIndex,
      out int lastParsedCharIndex,
      out bool isFactor)
    {
      string s1 = Class594.smethod_7(s, startIndex, out lastParsedCharIndex);
      isFactor = false;
      double num;
      if (!string.IsNullOrEmpty(s1))
      {
        try
        {
          if (s1.EndsWith("x", StringComparison.InvariantCultureIgnoreCase))
          {
            num = double.Parse(s1.Substring(0, s1.Length - 1), (IFormatProvider) CultureInfo.InvariantCulture);
            isFactor = true;
          }
          else
            num = double.Parse(s1, (IFormatProvider) CultureInfo.InvariantCulture);
        }
        catch (FormatException ex)
        {
          num = 0.0;
        }
      }
      else
        num = 0.0;
      return num;
    }

    internal static Class425 smethod_10(
      string s,
      double fontHeight,
      double obliqueAngle,
      double letterWidth,
      DxfTextStyle textStyle,
      WW.Cad.Model.Color color)
    {
      string simplifiedText;
      return Class594.smethod_11(s, fontHeight, obliqueAngle, letterWidth, textStyle, color, out simplifiedText);
    }

    internal static Class425 smethod_11(
      string s,
      double fontHeight,
      double obliqueAngle,
      double letterWidth,
      DxfTextStyle textStyle,
      WW.Cad.Model.Color color,
      out string simplifiedText)
    {
      Class596 settings = Class594.smethod_19(textStyle, fontHeight, color, letterWidth, DrawingDirection.ByStyle);
      settings.ObliqueAngle = obliqueAngle;
      Class425 class425 = new Class425(settings);
      StringBuilder stringBuilder1 = new StringBuilder();
      s = Class594.smethod_13(s);
      if (!string.IsNullOrEmpty(s))
      {
        StringBuilder stringBuilder2 = new StringBuilder();
        int startIndex = 0;
        while (startIndex < s.Length)
        {
          char ch = s[startIndex];
          if (ch == '%' && startIndex < s.Length - 1 && s[startIndex + 1] == '%')
          {
            startIndex += 2;
            if (startIndex < s.Length)
            {
              char lower = char.ToLower(s[startIndex], CultureInfo.InvariantCulture);
              if (!char.IsDigit(lower))
              {
                switch (lower)
                {
                  case '%':
                    stringBuilder2.Append('%');
                    stringBuilder1.Append('%');
                    ++startIndex;
                    continue;
                  case '+':
                    break;
                  case 'c':
                    stringBuilder2.Append('Ø');
                    stringBuilder1.Append('Ø');
                    ++startIndex;
                    continue;
                  case 'd':
                    stringBuilder2.Append('°');
                    stringBuilder1.Append('°');
                    ++startIndex;
                    continue;
                  case 'o':
                    if (stringBuilder2.Length > 0)
                    {
                      class425.method_0((Interface24) new Class470(stringBuilder2.ToString(), settings));
                      stringBuilder2.Length = 0;
                    }
                    settings.Overline = !settings.Overline;
                    ++startIndex;
                    continue;
                  case 'p':
                    stringBuilder2.Append('±');
                    stringBuilder1.Append('±');
                    ++startIndex;
                    continue;
                  case 'u':
                    if (stringBuilder2.Length > 0)
                    {
                      class425.method_0((Interface24) new Class470(stringBuilder2.ToString(), settings));
                      stringBuilder2.Length = 0;
                    }
                    settings.Underline = !settings.Underline;
                    ++startIndex;
                    continue;
                  default:
                    stringBuilder2.Append("%");
                    stringBuilder1.Append("%");
                    --startIndex;
                    continue;
                }
              }
              char[] chars = Encodings.Ibm437.GetChars(new byte[1]{ (byte) Class594.smethod_3(s, ref startIndex) });
              stringBuilder2.Append(chars);
              stringBuilder1.Append(chars);
            }
          }
          else
          {
            if (settings.method_0(ch))
            {
              if (stringBuilder2.Length > 0)
              {
                class425.method_0((Interface24) new Class470(stringBuilder2.ToString(), settings));
                stringBuilder2.Length = 0;
              }
              settings.UseBigFont = !settings.UseBigFont;
            }
            stringBuilder2.Append(ch);
            stringBuilder1.Append(ch);
            ++startIndex;
          }
        }
        if (stringBuilder2.Length > 0)
          class425.method_0((Interface24) new Class470(stringBuilder2.ToString(), settings));
      }
      simplifiedText = stringBuilder1.ToString();
      return class425;
    }

    internal static Class1023[] smethod_12(
      string s,
      double lineWidth,
      double fontHeight,
      AttachmentPoint attachmentPoint,
      double lineSpacingFactor,
      LineSpacingStyle lineSpacingStyle,
      DxfTextStyle textStyle,
      double widthFactor,
      WW.Cad.Model.Color color,
      DrawingDirection drawingDirection)
    {
      string simplifiedText;
      return Class594.smethod_14(s, lineWidth, fontHeight, attachmentPoint, lineSpacingFactor, lineSpacingStyle, textStyle, widthFactor, color, drawingDirection, out simplifiedText);
    }

    internal static string smethod_13(string text)
    {
      StringBuilder stringBuilder = (StringBuilder) null;
      int length = text.Length;
      bool flag = false;
      for (int index = 0; index < length; ++index)
      {
        char ch = text[index];
        if (flag)
        {
          flag = false;
          switch (ch)
          {
            case 'U':
            case 'u':
              if (index < length - 1)
              {
                int startIndex = index + 1;
                if (text[startIndex] == '+')
                  ++startIndex;
                if (startIndex <= length - 4)
                {
                  try
                  {
                    uint num = uint.Parse(text.Substring(startIndex, 4), NumberStyles.HexNumber);
                    if (stringBuilder == null)
                      stringBuilder = new StringBuilder(text.Substring(0, index - 1), length);
                    stringBuilder.Append((char) num);
                    index = startIndex + 3;
                    continue;
                  }
                  catch (FormatException ex)
                  {
                  }
                }
              }
              if (stringBuilder != null)
              {
                stringBuilder.Append('\\').Append(ch);
                continue;
              }
              continue;
            default:
              if (stringBuilder != null)
              {
                stringBuilder.Append('\\').Append(ch);
                continue;
              }
              continue;
          }
        }
        else if (ch == '\\')
          flag = true;
        else
          stringBuilder?.Append(ch);
      }
      if (flag && stringBuilder != null)
        stringBuilder.Append('\\');
      if (stringBuilder == null)
        return text;
      return stringBuilder.ToString();
    }

    internal static Class1023[] smethod_14(
      string s,
      double lineWidth,
      double fontHeight,
      AttachmentPoint attachmentPoint,
      double lineSpacingFactor,
      LineSpacingStyle lineSpacingStyle,
      DxfTextStyle textStyle,
      double widthFactor,
      WW.Cad.Model.Color color,
      DrawingDirection drawingDirection,
      out string simplifiedText)
    {
      List<Class1023> class1023List = new List<Class1023>();
      StringBuilder stringBuilder1 = new StringBuilder();
      if (!string.IsNullOrEmpty(s))
      {
        Class596 class596_1 = Class594.smethod_19(textStyle, fontHeight, color, widthFactor, drawingDirection);
        s = Class594.smethod_13(s);
        StringBuilder stringBuilder2 = new StringBuilder();
        int lastParsedCharIndex = 0;
        char ch1 = s[0];
        bool flag1 = false;
        Stack<Class596> class596Stack = new Stack<Class596>();
        Class596 class596_2 = new Class596(class596_1);
        Class1023.Class1024 class1024 = new Class1023.Class1024(lineWidth, attachmentPoint);
        Class1023 class1023 = new Class1023(class1024, lineSpacingFactor, lineSpacingStyle, class596_2);
        class1023List.Add(class1023);
        Class596 class596_3 = new Class596(class596_2);
        while (lastParsedCharIndex < s.Length)
        {
          char ch2 = ch1;
          string str1 = (string) null;
          if (ch2 == '\\' && lastParsedCharIndex + 1 < s.Length)
          {
            ch1 = s[lastParsedCharIndex + 1];
            switch (ch1)
            {
              case 'A':
                int? nullable1 = Class594.smethod_8(s, lastParsedCharIndex + 2, out lastParsedCharIndex);
                ++lastParsedCharIndex;
                if (nullable1.HasValue)
                {
                  class596_1.VerticalAlignment = (Enum46) nullable1.Value;
                  flag1 = true;
                  break;
                }
                break;
              case 'C':
                int? nullable2 = Class594.smethod_8(s, lastParsedCharIndex + 2, out lastParsedCharIndex);
                ++lastParsedCharIndex;
                if (nullable2.HasValue)
                {
                  class596_1.Color = nullable2.Value < 1 || nullable2.Value > (int) byte.MaxValue ? (nullable2.Value != 0 ? WW.Cad.Model.Color.ByLayer : WW.Cad.Model.Color.ByBlock) : WW.Cad.Model.Color.CreateFromColorIndex((short) nullable2.Value);
                  flag1 = true;
                  break;
                }
                break;
              case 'F':
              case 'f':
                string[] strArray = Class594.smethod_6(s, lastParsedCharIndex + 2, out lastParsedCharIndex).Split('|');
                string str2 = strArray[0];
                for (int index = 1; index < strArray.Length; ++index)
                {
                  string str3 = strArray[index];
                  if (str3.Length >= 2)
                  {
                    bool flag2 = str3[1] != '0';
                    switch (str3[0])
                    {
                      case 'b':
                        class596_1.Bold = flag2;
                        continue;
                      case 'i':
                        class596_1.Italic = flag2;
                        continue;
                      default:
                        continue;
                    }
                  }
                }
                ++lastParsedCharIndex;
                class596_1.FontFileName = str2;
                flag1 = true;
                break;
              case 'H':
                bool isFactor1;
                double num1 = Class594.smethod_9(s, lastParsedCharIndex + 2, out lastParsedCharIndex, out isFactor1);
                if (num1 != 0.0)
                {
                  if (isFactor1)
                    num1 = class596_1.Height * num1;
                  ++lastParsedCharIndex;
                  class596_1.Height = num1;
                  flag1 = true;
                  break;
                }
                break;
              case 'L':
                class596_1.Underline = true;
                lastParsedCharIndex += 2;
                flag1 = true;
                break;
              case 'O':
                class596_1.Overline = true;
                lastParsedCharIndex += 2;
                flag1 = true;
                break;
              case 'P':
                if (flag1)
                {
                  flag1 = false;
                  class596_3 = new Class596(class596_1);
                }
                if (stringBuilder2.Length > 0)
                {
                  class1023.method_2(stringBuilder2.ToString(), class596_3);
                  stringBuilder2.Length = 0;
                }
                class1023 = new Class1023(class1024, lineSpacingFactor, lineSpacingStyle, class596_3);
                class1023List.Add(class1023);
                stringBuilder1.Append("\r\n");
                lastParsedCharIndex += 2;
                break;
              case 'Q':
                bool isFactor2;
                double num2 = Class594.smethod_9(s, lastParsedCharIndex + 2, out lastParsedCharIndex, out isFactor2);
                class596_1.ObliqueAngle = System.Math.PI * num2 / 180.0;
                ++lastParsedCharIndex;
                flag1 = true;
                break;
              case 'S':
                int num3 = lastParsedCharIndex;
                Class594.Class595 class595 = new Class594.Class595(Class594.smethod_6(s, lastParsedCharIndex + 2, out lastParsedCharIndex), class596_1);
                if (class595.Valid)
                {
                  if (stringBuilder2.Length > 0)
                  {
                    class1023.method_2(stringBuilder2.ToString(), class596_3);
                    stringBuilder2.Length = 0;
                  }
                  class1023.method_3((Interface24) class595);
                  ++lastParsedCharIndex;
                  stringBuilder1.Append(class595.NumeratorBlock.Text);
                  stringBuilder1.Append(' ');
                  stringBuilder1.Append(class595.DenominatorBlock.Text);
                  break;
                }
                lastParsedCharIndex = num3 + 2;
                flag1 = true;
                break;
              case 'T':
                bool isFactor3;
                double num4 = Class594.smethod_9(s, lastParsedCharIndex + 2, out lastParsedCharIndex, out isFactor3);
                class596_1.LetterDistance = num4;
                ++lastParsedCharIndex;
                flag1 = true;
                break;
              case 'W':
                bool isFactor4;
                double num5 = Class594.smethod_9(s, lastParsedCharIndex + 2, out lastParsedCharIndex, out isFactor4);
                if (isFactor4)
                  num5 = class596_1.LetterWidth * num5;
                class596_1.LetterWidth = num5;
                ++lastParsedCharIndex;
                flag1 = true;
                break;
              case '\\':
              case '{':
              case '}':
                str1 = ch1.ToString();
                stringBuilder1.Append(ch1);
                lastParsedCharIndex += 2;
                break;
              case 'c':
                int? nullable3 = Class594.smethod_8(s, lastParsedCharIndex + 2, out lastParsedCharIndex);
                ++lastParsedCharIndex;
                if (nullable3.HasValue)
                {
                  class596_1.Color = WW.Cad.Model.Color.CreateFromRgb((byte) (nullable3.Value & (int) byte.MaxValue), (byte) ((nullable3.Value & 65280) >> 8), (byte) ((nullable3.Value & 16711680) >> 16));
                  flag1 = true;
                  break;
                }
                break;
              case 'l':
                class596_1.Underline = false;
                lastParsedCharIndex += 2;
                flag1 = true;
                break;
              case 'o':
                class596_1.Overline = false;
                lastParsedCharIndex += 2;
                flag1 = true;
                break;
              case 'p':
                string definition = Class594.smethod_6(s, lastParsedCharIndex + 2, out lastParsedCharIndex);
                class1024 = new Class1023.Class1024(class1024, definition, class596_3.Height);
                class1023.Format = class1024;
                ++lastParsedCharIndex;
                break;
              case '~':
                str1 = ' '.ToString();
                stringBuilder1.Append(' ');
                lastParsedCharIndex += 2;
                break;
              default:
                ++lastParsedCharIndex;
                break;
            }
          }
          else
          {
            switch (ch2)
            {
              case '{':
                class596Stack.Push(class596_3);
                if (stringBuilder2.Length > 0)
                {
                  class1023.method_2(stringBuilder2.ToString(), class596_3);
                  stringBuilder2.Length = 0;
                }
                class596_3 = new Class596(class596_1);
                flag1 = false;
                ++lastParsedCharIndex;
                break;
              case '}':
                if (class596Stack.Count > 0)
                {
                  class596_1 = class596Stack.Pop();
                  if (stringBuilder2.Length > 0)
                  {
                    class1023.method_2(stringBuilder2.ToString(), class596_3);
                    stringBuilder2.Length = 0;
                  }
                  class596_3 = new Class596(class596_1);
                  flag1 = false;
                }
                ++lastParsedCharIndex;
                break;
              default:
                if (ch2 == '%' && lastParsedCharIndex + 1 < s.Length && s[lastParsedCharIndex + 1] == '%')
                {
                  lastParsedCharIndex += 2;
                  if (lastParsedCharIndex < s.Length)
                  {
                    char lower = char.ToLower(s[lastParsedCharIndex], CultureInfo.InvariantCulture);
                    if (!char.IsDigit(lower))
                    {
                      switch (lower)
                      {
                        case '%':
                          str1 = "%";
                          stringBuilder1.Append('%');
                          ++lastParsedCharIndex;
                          goto label_81;
                        case '+':
                          break;
                        case 'c':
                          str1 = 'Ø'.ToString();
                          stringBuilder1.Append('Ø');
                          ++lastParsedCharIndex;
                          goto label_81;
                        case 'd':
                          str1 = "°";
                          stringBuilder1.Append('°');
                          ++lastParsedCharIndex;
                          goto label_81;
                        case 'o':
                          class596_1.Overline = !class596_1.Overline;
                          flag1 = true;
                          ++lastParsedCharIndex;
                          goto label_81;
                        case 'p':
                          str1 = "±";
                          stringBuilder1.Append('±');
                          ++lastParsedCharIndex;
                          goto label_81;
                        case 'u':
                          class596_1.Underline = !class596_1.Underline;
                          flag1 = true;
                          ++lastParsedCharIndex;
                          goto label_81;
                        default:
                          str1 = "%%";
                          stringBuilder1.Append("%%");
                          --lastParsedCharIndex;
                          goto label_81;
                      }
                    }
                    char[] chars = Encodings.Ibm437.GetChars(new byte[1]{ (byte) Class594.smethod_3(s, ref lastParsedCharIndex) });
                    str1 = new string(chars);
                    stringBuilder1.Append(chars);
                    break;
                  }
                  break;
                }
                if (ch2 == '^' && lastParsedCharIndex + 1 < s.Length)
                {
                  ++lastParsedCharIndex;
                  switch (s[lastParsedCharIndex])
                  {
                    case 'I':
                      if (stringBuilder2.Length > 0)
                      {
                        class1023.method_2(stringBuilder2.ToString(), class596_3);
                        stringBuilder2.Length = 0;
                      }
                      class1023.method_1(class596_3);
                      stringBuilder1.Append('\t');
                      ++lastParsedCharIndex;
                      break;
                    case 'J':
                      if (stringBuilder2.Length > 0)
                      {
                        class1023.method_2(stringBuilder2.ToString(), class596_3);
                        stringBuilder2.Length = 0;
                      }
                      class1023.method_0(class596_3);
                      stringBuilder1.Append("\r\n");
                      ++lastParsedCharIndex;
                      break;
                    case '^':
                      str1 = "^";
                      stringBuilder1.Append('^');
                      ++lastParsedCharIndex;
                      break;
                    default:
                      str1 = "^";
                      stringBuilder1.Append('^');
                      break;
                  }
                }
                else
                {
                  if (ch2 == '\t')
                  {
                    ++lastParsedCharIndex;
                    if (stringBuilder2.Length > 0)
                    {
                      class1023.method_2(stringBuilder2.ToString(), class596_3);
                      stringBuilder2.Length = 0;
                    }
                    class1023.method_1(class596_3);
                    stringBuilder1.Append('\t');
                    break;
                  }
                  str1 = ch2.ToString();
                  stringBuilder1.Append(ch2);
                  ++lastParsedCharIndex;
                  break;
                }
            }
          }
label_81:
          if (str1 != null)
          {
            if (class596_3.method_0(ch2))
            {
              class596_1.UseBigFont = !class596_1.UseBigFont;
              flag1 = true;
            }
            if (flag1)
            {
              flag1 = false;
              if (stringBuilder2.Length > 0)
              {
                class1023.method_2(stringBuilder2.ToString(), class596_3);
                stringBuilder2.Length = 0;
              }
              class596_3 = new Class596(class596_1);
            }
            stringBuilder2.Append(str1);
          }
          if (lastParsedCharIndex < s.Length)
            ch1 = s[lastParsedCharIndex];
        }
        if (stringBuilder2.Length > 0)
          class1023.method_2(stringBuilder2.ToString(), flag1 ? class596_3 : class596_1);
      }
      simplifiedText = stringBuilder1.ToString();
      return class1023List.ToArray();
    }

    internal static int smethod_15(string line, int startIndex)
    {
      int length = line.Length;
      bool flag = false;
      int index1;
      for (index1 = startIndex; index1 < length; ++index1)
      {
        if (!Class594.smethod_17(line[index1]))
        {
          flag = true;
          break;
        }
      }
      if (flag)
      {
        for (int index2 = index1 + 1; index2 < length; ++index2)
        {
          char ch = line[index2];
          if (Class594.smethod_17(ch))
            return index2;
          if (",:;.-()".IndexOf(ch) >= 0)
            return index2 + 1;
        }
      }
      return line.Length;
    }

    internal static int smethod_16(string line, int startIndex)
    {
      int length = line.Length;
      int index = startIndex;
      while (index < length && Class594.smethod_17(line[index]))
        ++index;
      return index;
    }

    public static bool smethod_17(char ch)
    {
      if (char.IsWhiteSpace(ch))
        return ch != ' ';
      return false;
    }

    internal static string smethod_18(ref string line)
    {
      int length = line.Length;
      bool flag = false;
      int index1;
      for (index1 = length - 1; index1 > 0; --index1)
      {
        if (!Class594.smethod_17(line[index1]))
        {
          flag = true;
          break;
        }
      }
      if (flag)
      {
        for (int index2 = index1 - 1; index2 > 0; --index2)
        {
          if ("\t ,:;.-()\n".IndexOf(line[index2]) >= 0)
          {
            int startIndex = index2 + 1;
            string str = line.Substring(startIndex, line.Length - startIndex);
            line = line.Substring(0, index2 + 1);
            if (str.Length == 0)
              str = (string) null;
            return str;
          }
        }
      }
      return (string) null;
    }

    private static Class596 smethod_19(
      DxfTextStyle textStyle,
      double fontHeight,
      WW.Cad.Model.Color color,
      double letterWidth,
      DrawingDirection drawingDirection)
    {
      Class596 class596 = new Class596(textStyle.Model);
      if (textStyle.TrueTypeFontDescriptor != null && !string.IsNullOrEmpty(textStyle.TrueTypeFontDescriptor.FontFilename))
      {
        class596.FontFileName = textStyle.TrueTypeFontDescriptor.FontFilename;
        class596.Bold = (textStyle.TrueTypeFontDescriptor.Flags & TrueTypeFontFlags.Bold) != TrueTypeFontFlags.None;
        class596.Italic = (textStyle.TrueTypeFontDescriptor.Flags & TrueTypeFontFlags.Italic) != TrueTypeFontFlags.None;
      }
      else
        class596.FontFileName = textStyle.FontFilename;
      class596.BigFontFilename = textStyle.BigFontFilename;
      class596.Color = color;
      class596.Height = fontHeight;
      class596.ObliqueAngle = textStyle.ObliqueAngle;
      class596.LetterWidth = letterWidth;
      switch (drawingDirection)
      {
        case DrawingDirection.LeftToRight:
        case DrawingDirection.RightToLeft:
          class596.IsVertical = false;
          break;
        case DrawingDirection.TopToBottom:
        case DrawingDirection.BottomToTop:
          class596.IsVertical = true;
          break;
        default:
          class596.IsVertical = textStyle.IsVertical;
          break;
      }
      return class596;
    }

    private static bool smethod_20(char c)
    {
      if (!char.IsDigit(c) && c != '+')
        return c != '-';
      return false;
    }

    private static bool smethod_21(char c)
    {
      if (char.IsDigit(c) || c == '+' || c >= 'a' && c <= 'f')
        return false;
      if (c >= 'A')
        return c > 'F';
      return true;
    }

    private static bool smethod_22(char c)
    {
      return c == ';';
    }

    private static bool smethod_23(char c)
    {
      if (c != ';')
        return c == '\\';
      return true;
    }

    private static string smethod_24(
      string s,
      Class594.Delegate14 charMatcher,
      int startIndex,
      out int lastParsedCharIndex)
    {
      for (int index = startIndex; index < s.Length; ++index)
      {
        if (charMatcher(s[index]))
        {
          lastParsedCharIndex = index - 1;
          return s.Substring(startIndex, index - startIndex);
        }
      }
      lastParsedCharIndex = s.Length;
      return s.Substring(startIndex);
    }

    internal enum Enum18 : ushort
    {
      const_0 = 0,
      const_3 = 35, // 0x0023
      const_1 = 47, // 0x002F
      const_2 = 94, // 0x005E
      const_4 = 126, // 0x007E
    }

    internal class Class595 : Interface24
    {
      private const double double_0 = 0.833333333333333;
      private readonly Class594.Enum18 enum18_0;
      private readonly Class470 class470_0;
      private readonly Class470 class470_1;
      private readonly char char_0;
      private readonly Class596 class596_0;
      private Vector2D vector2D_0;

      public Class595(string description, Class596 settings)
      {
        this.class596_0 = settings;
        this.enum18_0 = Class594.Enum18.const_0;
        int index;
        for (index = 0; index < description.Length && this.enum18_0 == Class594.Enum18.const_0; ++index)
        {
          Class594.Enum18 enum18 = (Class594.Enum18) description[index];
          if ((uint) enum18 <= 47U)
          {
            if (enum18 != Class594.Enum18.const_3 && enum18 != Class594.Enum18.const_1)
              continue;
          }
          else if (enum18 != Class594.Enum18.const_2 && enum18 != Class594.Enum18.const_4)
            continue;
          this.enum18_0 = (Class594.Enum18) description[index];
        }
        int length = index - 1;
        if (this.enum18_0 == Class594.Enum18.const_0)
          return;
        if (this.enum18_0 == Class594.Enum18.const_4)
        {
          if (length == description.Length - 1)
          {
            this.enum18_0 = Class594.Enum18.const_0;
            return;
          }
          this.class470_0 = new Class470(description.Substring(length + 2), settings);
          this.char_0 = description[length + 1];
        }
        else
        {
          this.class470_0 = new Class470(description.Substring(length + 1), settings);
          this.char_0 = char.MinValue;
        }
        this.class470_1 = new Class470(description.Substring(0, length), settings);
      }

      public bool Valid
      {
        get
        {
          return this.enum18_0 != Class594.Enum18.const_0;
        }
      }

      public Class594.Enum18 Type
      {
        get
        {
          return this.enum18_0;
        }
      }

      public string Denominator
      {
        get
        {
          return this.class470_0.Text;
        }
      }

      public string Numerator
      {
        get
        {
          return this.class470_1.Text;
        }
      }

      public char AlignmentChar
      {
        get
        {
          return this.char_0;
        }
      }

      public Class470 NumeratorBlock
      {
        get
        {
          return this.class470_1;
        }
      }

      public Class470 DenominatorBlock
      {
        get
        {
          return this.class470_0;
        }
      }

      public Vector2D Offset
      {
        get
        {
          return this.vector2D_0;
        }
        set
        {
          Vector2D vector2D = value - this.vector2D_0;
          this.vector2D_0 = value;
          this.class470_1.Offset += vector2D;
          this.class470_0.Offset += vector2D;
        }
      }

      public Class596 Settings
      {
        get
        {
          return this.class596_0;
        }
      }

      public Bounds2D GetBounds(Enum24 whiteSpaceHandling, Class985 resultLayoutInfo)
      {
        Bounds2D bounds2D = new Bounds2D();
        bounds2D.Update(this.class470_1.GetBounds(whiteSpaceHandling, resultLayoutInfo));
        bounds2D.Update(this.class470_0.GetBounds(whiteSpaceHandling, resultLayoutInfo));
        return bounds2D;
      }

      public void imethod_0(
        ref Vector2D baselinePos,
        double height,
        Enum24 whiteSpaceHandlingFlags)
      {
        Vector2D baselinePos1 = new Vector2D();
        Vector2D baselinePos2 = new Vector2D();
        this.class470_1.imethod_0(ref baselinePos1, height, whiteSpaceHandlingFlags);
        this.class470_0.imethod_0(ref baselinePos2, height, whiteSpaceHandlingFlags);
        Vector2D vector2D1 = this.class596_0.Font.Metrics.LineFeedAdvance * (5.0 / 6.0);
        Class594.Enum18 enum180 = this.enum18_0;
        if ((uint) enum180 <= 47U)
        {
          switch (enum180)
          {
            case Class594.Enum18.const_3:
              this.class470_0.Offset += new Vector2D(baselinePos1.X, 0.0);
              this.class470_1.Offset += new Vector2D(0.0, this.class470_0.Settings.Height);
              break;
            case Class594.Enum18.const_1:
              this.class470_1.Offset -= vector2D1;
              double x1 = this.class470_1.GetBounds(Enum24.flag_1, (Class985) null).Center.X;
              double x2 = this.class470_0.GetBounds(Enum24.flag_1, (Class985) null).Center.X;
              if (x1 > x2)
              {
                this.class470_0.Offset += new Vector2D(x1 - x2, 0.0);
                break;
              }
              this.class470_1.Offset += new Vector2D(x2 - x1, 0.0);
              break;
          }
        }
        else if (enum180 == Class594.Enum18.const_2 || enum180 == Class594.Enum18.const_4)
        {
          this.class470_1.Offset -= vector2D1;
          Vector2D? nullable1 = this.class470_0.imethod_2(this.char_0, whiteSpaceHandlingFlags);
          Vector2D? nullable2 = this.class470_1.imethod_2(this.char_0, whiteSpaceHandlingFlags);
          if (nullable1.HasValue && nullable2.HasValue)
          {
            Vector2D vector2D2 = new Vector2D((nullable2.Value.X - nullable1.Value.X) / 2.0, 0.0);
            this.class470_0.Offset += vector2D2;
            this.class470_1.Offset -= vector2D2;
          }
        }
        Bounds2D bounds1 = this.GetBounds(Enum24.flag_0, (Class985) null);
        if (bounds1.Initialized)
        {
          switch (this.Settings.VerticalAlignment)
          {
            case Enum46.const_1:
              this.Offset += new Vector2D(0.0, 0.5 * (height - (this.class470_1.Offset.Y + this.class470_1.Settings.Font.Metrics.Ascent) - 0.0));
              break;
            case Enum46.const_2:
              this.Offset += new Vector2D(0.0, height - bounds1.Corner2.Y);
              break;
          }
        }
        Bounds2D bounds2 = this.class470_1.GetBounds(Enum24.flag_1, (Class985) null);
        Bounds2D bounds3 = this.class470_0.GetBounds(Enum24.flag_1, (Class985) null);
        Vector2D vector2D3 = new Vector2D(System.Math.Max(bounds2.Initialized ? bounds2.Corner2.X : 0.0, bounds3.Initialized ? bounds3.Corner2.X : 0.0), 0.0);
        this.Offset += baselinePos;
        baselinePos += vector2D3;
      }

      public bool Breakable
      {
        get
        {
          return false;
        }
      }

      public Interface24[] Lines
      {
        get
        {
          return new Interface24[1]{ (Interface24) this };
        }
      }

      public Interface24[] imethod_1(double width, Interface25 breaker)
      {
        return Class470.interface24_0;
      }

      public Vector2D? imethod_2(char ch, Enum24 whiteSpaceHandlingFlags)
      {
        return new Vector2D?();
      }

      public void imethod_3(
        ICollection<Class908> collector,
        Matrix4D insertionTrafo,
        short lineWeight)
      {
        this.class470_1.imethod_3(collector, insertionTrafo, lineWeight);
        this.class470_0.imethod_3(collector, insertionTrafo, lineWeight);
        if (this.enum18_0 != Class594.Enum18.const_1 && this.enum18_0 != Class594.Enum18.const_3)
          return;
        Class596 settings = this.class470_0.Settings;
        Bounds2D bounds1 = this.class470_1.GetBounds(Enum24.flag_1, (Class985) null);
        Bounds2D bounds2 = this.class470_0.GetBounds(Enum24.flag_1, (Class985) null);
        if (!bounds1.Initialized || !bounds2.Initialized)
          return;
        Class908 class908 = new Class908((Interface34) new Class865("", settings.Font, settings.Color, lineWeight, (IShape2D) null, Matrix2D.Identity, Matrix2D.Identity, Vector2D.Zero), insertionTrafo);
        if (this.enum18_0 == Class594.Enum18.const_1)
        {
          double num = (bounds1.Corner1.Y + bounds2.Corner2.Y) / 2.0;
          double startX = System.Math.Min(bounds1.Corner1.X, bounds2.Corner1.X);
          double endX = System.Math.Max(bounds1.Corner2.X, bounds2.Corner2.X);
          class908.method_3(startX, num, endX, num);
        }
        else
        {
          double startY = System.Math.Min(bounds1.Corner1.Y, bounds2.Corner1.Y);
          double endY = System.Math.Max(bounds1.Corner2.Y, bounds2.Corner2.Y);
          WW.Math.Point2D point2D = new WW.Math.Point2D((bounds1.Corner2.X + bounds2.Corner1.X) / 2.0, (bounds1.Corner1.Y + bounds2.Corner2.Y) / 2.0);
          class908.method_3(point2D.X + (startY - point2D.Y) / 1.5, startY, point2D.X + (endY - point2D.Y) / 1.5, endY);
        }
        collector.Add(class908);
      }
    }

    private delegate bool Delegate14(char c);
  }
}
