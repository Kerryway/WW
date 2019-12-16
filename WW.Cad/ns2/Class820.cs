// Decompiled with JetBrains decompiler
// Type: ns2.Class820
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Globalization;
using System.IO;
using System.Text;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model;

namespace ns2
{
  internal sealed class Class820
  {
    private static NumberFormatInfo numberFormatInfo_0 = CultureInfo.InvariantCulture.NumberFormat;
    private static NumberFormatInfo numberFormatInfo_1 = new NumberFormatInfo() { NumberDecimalSeparator = ",", NumberGroupSeparator = "." };
    private static readonly object[][] object_0 = new object[69][]{ new object[4]{ (object) 0, (object) 4, (object) Enum5.const_16, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 5, (object) 5, (object) Enum5.const_6, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 6, (object) 9, (object) Enum5.const_16, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 10, (object) 19, (object) Enum5.const_13, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 20, (object) 39, (object) Enum5.const_4, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 40, (object) 59, (object) Enum5.const_4, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 60, (object) 61, (object) Enum5.const_17, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 62, (object) 62, (object) Enum5.const_10, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 63, (object) 69, (object) Enum5.const_17, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 70, (object) 70, (object) Enum5.const_10, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 71, (object) 79, (object) Enum5.const_17, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 90, (object) 99, (object) Enum5.const_11, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 100, (object) 100, (object) Enum5.const_16, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 101, (object) 101, (object) Enum5.const_16, (object) DxfVersion.Dxf24 }, new object[4]{ (object) 102, (object) 102, (object) Enum5.const_16, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 105, (object) 105, (object) Enum5.const_5, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 110, (object) 119, (object) Enum5.const_13, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 120, (object) 129, (object) Enum5.const_4, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 130, (object) 139, (object) Enum5.const_4, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 140, (object) 149, (object) Enum5.const_4, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 160, (object) 169, (object) Enum5.const_12, (object) DxfVersion.Dxf24 }, new object[4]{ (object) 170, (object) 179, (object) Enum5.const_10, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 210, (object) 219, (object) Enum5.const_13, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 220, (object) 230, (object) Enum5.const_4, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 231, (object) 233, (object) Enum5.const_13, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 234, (object) 239, (object) Enum5.const_4, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 270, (object) 279, (object) Enum5.const_10, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 280, (object) 289, (object) Enum5.const_2, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 290, (object) 299, (object) Enum5.const_1, (object) DxfVersion.Dxf18 }, new object[4]{ (object) 300, (object) 309, (object) Enum5.const_16, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 310, (object) 319, (object) Enum5.const_3, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 320, (object) 329, (object) Enum5.const_7, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 330, (object) 339, (object) Enum5.const_15, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 340, (object) 349, (object) Enum5.const_8, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 350, (object) 359, (object) Enum5.const_14, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 360, (object) 369, (object) Enum5.const_9, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 370, (object) 370, (object) Enum5.const_10, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 371, (object) 379, (object) Enum5.const_10, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 380, (object) 389, (object) Enum5.const_10, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 390, (object) 399, (object) Enum5.const_7, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 400, (object) 409, (object) Enum5.const_10, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 410, (object) 419, (object) Enum5.const_16, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 420, (object) 429, (object) Enum5.const_11, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 430, (object) 439, (object) Enum5.const_16, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 440, (object) 449, (object) Enum5.const_11, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 450, (object) 459, (object) Enum5.const_11, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 460, (object) 469, (object) Enum5.const_4, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 470, (object) 479, (object) Enum5.const_16, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 999, (object) 999, (object) Enum5.const_16, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 1000, (object) 1003, (object) Enum5.const_16, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 1004, (object) 1004, (object) Enum5.const_3, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 1005, (object) 1005, (object) Enum5.const_5, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 1006, (object) 1009, (object) Enum5.const_16, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 1010, (object) 1013, (object) Enum5.const_13, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 1014, (object) 1059, (object) Enum5.const_4, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 1060, (object) 1070, (object) Enum5.const_10, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 1071, (object) 1071, (object) Enum5.const_11, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 5001, (object) 5001, (object) Enum5.const_4, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 5002, (object) 5002, (object) Enum5.const_13, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 5003, (object) 5003, (object) Enum5.const_10, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 5004, (object) 5004, (object) Enum5.const_4, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 5005, (object) 5005, (object) Enum5.const_16, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 5006, (object) 5006, (object) Enum5.const_8, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 5007, (object) 5007, (object) Enum5.const_18, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 5008, (object) 5008, (object) Enum5.const_4, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 5009, (object) 5009, (object) Enum5.const_13, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 5010, (object) 5010, (object) Enum5.const_11, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 5011, (object) 5019, (object) Enum5.const_18, (object) DxfVersion.Dxf12 }, new object[4]{ (object) 5020, (object) 5020, (object) Enum5.const_16, (object) DxfVersion.Dxf12 } };
    private static object[][] object_1 = new object[18][]{ new object[6]{ (object) Enum5.const_16, (object) new Class820.Delegate19(Class820.smethod_4), (object) new Class820.Delegate19(Class820.smethod_4), (object) new Class820.Delegate20(Class820.smethod_16), (object) new Class820.Delegate21(Class820.smethod_26), (object) new Class820.Delegate22(Class820.smethod_36) }, new object[6]{ (object) Enum5.const_6, (object) new Class820.Delegate19(Class820.smethod_4), (object) new Class820.Delegate19(Class820.smethod_4), (object) new Class820.Delegate20(Class820.smethod_24), (object) new Class820.Delegate21(Class820.smethod_26), (object) new Class820.Delegate22(Class820.smethod_44) }, new object[6]{ (object) Enum5.const_4, (object) new Class820.Delegate19(Class820.smethod_6), (object) new Class820.Delegate19(Class820.smethod_6), (object) new Class820.Delegate20(Class820.smethod_18), (object) new Class820.Delegate21(Class820.smethod_28), (object) new Class820.Delegate22(Class820.smethod_38) }, new object[6]{ (object) Enum5.const_13, (object) new Class820.Delegate19(Class820.smethod_6), (object) new Class820.Delegate19(Class820.smethod_6), (object) new Class820.Delegate20(Class820.smethod_18), (object) new Class820.Delegate21(Class820.smethod_28), (object) new Class820.Delegate22(Class820.smethod_38) }, new object[6]{ (object) Enum5.const_17, (object) new Class820.Delegate19(Class820.smethod_9), (object) new Class820.Delegate19(Class820.smethod_9), (object) new Class820.Delegate20(Class820.smethod_21), (object) new Class820.Delegate21(Class820.smethod_31), (object) new Class820.Delegate22(Class820.smethod_41) }, new object[6]{ (object) Enum5.const_10, (object) new Class820.Delegate19(Class820.smethod_10), (object) new Class820.Delegate19(Class820.smethod_10), (object) new Class820.Delegate20(Class820.smethod_20), (object) new Class820.Delegate21(Class820.smethod_30), (object) new Class820.Delegate22(Class820.smethod_40) }, new object[6]{ (object) Enum5.const_11, (object) new Class820.Delegate19(Class820.smethod_11), (object) new Class820.Delegate19(Class820.smethod_11), (object) new Class820.Delegate20(Class820.smethod_22), (object) new Class820.Delegate21(Class820.smethod_32), (object) new Class820.Delegate22(Class820.smethod_42) }, new object[6]{ (object) Enum5.const_5, (object) new Class820.Delegate19(Class820.smethod_14), (object) new Class820.Delegate19(Class820.smethod_14), (object) new Class820.Delegate20(Class820.smethod_24), (object) new Class820.Delegate21(Class820.smethod_34), (object) new Class820.Delegate22(Class820.smethod_44) }, new object[6]{ (object) Enum5.const_7, (object) new Class820.Delegate19(Class820.smethod_14), (object) new Class820.Delegate19(Class820.smethod_14), (object) new Class820.Delegate20(Class820.smethod_24), (object) new Class820.Delegate21(Class820.smethod_34), (object) new Class820.Delegate22(Class820.smethod_44) }, new object[6]{ (object) Enum5.const_15, (object) new Class820.Delegate19(Class820.smethod_14), (object) new Class820.Delegate19(Class820.smethod_15), (object) new Class820.Delegate20(Class820.smethod_24), (object) new Class820.Delegate21(Class820.smethod_34), (object) new Class820.Delegate22(Class820.smethod_44) }, new object[6]{ (object) Enum5.const_8, (object) new Class820.Delegate19(Class820.smethod_14), (object) new Class820.Delegate19(Class820.smethod_15), (object) new Class820.Delegate20(Class820.smethod_24), (object) new Class820.Delegate21(Class820.smethod_34), (object) new Class820.Delegate22(Class820.smethod_44) }, new object[6]{ (object) Enum5.const_14, (object) new Class820.Delegate19(Class820.smethod_14), (object) new Class820.Delegate19(Class820.smethod_15), (object) new Class820.Delegate20(Class820.smethod_24), (object) new Class820.Delegate21(Class820.smethod_34), (object) new Class820.Delegate22(Class820.smethod_44) }, new object[6]{ (object) Enum5.const_9, (object) new Class820.Delegate19(Class820.smethod_14), (object) new Class820.Delegate19(Class820.smethod_15), (object) new Class820.Delegate20(Class820.smethod_24), (object) new Class820.Delegate21(Class820.smethod_34), (object) new Class820.Delegate22(Class820.smethod_44) }, new object[6]{ (object) Enum5.const_12, (object) new Class820.Delegate19(Class820.smethod_12), (object) new Class820.Delegate19(Class820.smethod_12), (object) new Class820.Delegate20(Class820.smethod_23), (object) new Class820.Delegate21(Class820.smethod_33), (object) new Class820.Delegate22(Class820.smethod_43) }, new object[6]{ (object) Enum5.const_2, (object) new Class820.Delegate19(Class820.smethod_8), (object) new Class820.Delegate19(Class820.smethod_8), (object) new Class820.Delegate20(Class820.smethod_19), (object) new Class820.Delegate21(Class820.smethod_29), (object) new Class820.Delegate22(Class820.smethod_39) }, new object[6]{ (object) Enum5.const_1, (object) new Class820.Delegate19(Class820.smethod_7), (object) new Class820.Delegate19(Class820.smethod_7), (object) new Class820.Delegate20(Class820.smethod_25), (object) new Class820.Delegate21(Class820.smethod_35), (object) new Class820.Delegate22(Class820.smethod_45) }, new object[6]{ (object) Enum5.const_3, (object) new Class820.Delegate19(Class820.smethod_5), (object) new Class820.Delegate19(Class820.smethod_5), (object) new Class820.Delegate20(Class820.smethod_17), (object) new Class820.Delegate21(Class820.smethod_27), (object) new Class820.Delegate22(Class820.smethod_37) }, new object[6]{ (object) Enum5.const_18, (object) new Class820.Delegate19(Class820.smethod_4), (object) new Class820.Delegate19(Class820.smethod_4), (object) new Class820.Delegate20(Class820.smethod_16), (object) new Class820.Delegate21(Class820.smethod_26), (object) new Class820.Delegate22(Class820.smethod_36) } };
    private static Class820.Class821[] class821_0 = new Class820.Class821[5021];
    private const string string_0 = "-1.#INF";
    private const string string_1 = "1.#INF";
    private const int int_0 = 5020;

    internal static DxfVersion smethod_0(int code)
    {
      Class820.Class821 class821 = Class820.class821_0[code];
      if (class821 == null)
        return DxfVersion.Unknown;
      return class821.MinVersion;
    }

    internal static bool smethod_1(int code, out Enum5 groupValueType)
    {
      bool flag = false;
      if (code >= 0 && code < Class820.class821_0.Length)
      {
        Class820.Class821 class821 = Class820.class821_0[code];
        if (class821 != null)
        {
          groupValueType = class821.GroupValueType;
          flag = true;
        }
        else
          groupValueType = Enum5.const_0;
      }
      else
        groupValueType = Enum5.const_0;
      return flag;
    }

    internal static Enum5 smethod_2(int code)
    {
      Class820.Class821 class821 = Class820.class821_0[code];
      if (class821 == null)
        throw new ArgumentException("Unknown group " + (object) code + ".");
      return class821.GroupValueType;
    }

    internal static object GetValue(DxfReader r, int code, string valueString)
    {
      Class820.Class821 class821 = Class820.class821_0[code];
      if (class821 == null)
      {
        if (r.ThrowExceptionOnInvalidGroupCode)
          throw new ArgumentException("Unknown group " + (object) code + ".");
        r.Messages.Add(new DxfMessage(DxfStatus.InvalidGroupCode, Severity.Warning, "GroupCode", (object) code)
        {
          Parameters = {
            {
              "Position",
              (object) r.GroupReader.Position
            }
          }
        });
        return (object) valueString;
      }
      Class820.Delegate19 fromStringDelegate = class821.FromStringDelegate;
      return fromStringDelegate != null ? fromStringDelegate(r, valueString) : (object) valueString;
    }

    internal static object TryGetValue(DxfReader r, int code, string valueString)
    {
      Class820.Class821 class821 = Class820.class821_0[code];
      if (class821 == null)
      {
        if (r.ThrowExceptionOnInvalidGroupCode)
          throw new ArgumentException("Unknown group " + (object) code + ".");
        r.Messages.Add(new DxfMessage(DxfStatus.InvalidGroupCode, Severity.Warning, "GroupCode", (object) code)
        {
          Parameters = {
            {
              "Position",
              (object) r.GroupReader.Position
            }
          }
        });
        return (object) valueString;
      }
      Class820.Delegate19 fromStringDelegate = class821.TryFromStringDelegate;
      return fromStringDelegate != null ? fromStringDelegate(r, valueString) : (object) valueString;
    }

    internal static string GetValueString(int code, object value)
    {
      string str = (string) null;
      if (value != null)
      {
        Class820.Delegate20 toStringDelegate = Class820.class821_0[code].ToStringDelegate;
        str = toStringDelegate != null ? toStringDelegate(value) : value.ToString();
      }
      return str;
    }

    internal static object GetValue(int code, Class822 r)
    {
      Class820.Delegate21 fromBinDelegate = Class820.class821_0[code].FromBinDelegate;
      if (fromBinDelegate == null)
        throw new Exception("No binary read method defined for code " + (object) code);
      return fromBinDelegate(r);
    }

    internal static void smethod_3(int code, object value, Class347 w)
    {
      Class820.Delegate22 toBinDelegate = Class820.class821_0[code].ToBinDelegate;
      if (toBinDelegate == null)
        throw new Exception("No binary write method defined for code " + (object) code);
      toBinDelegate(value, w);
    }

    private static object smethod_4(DxfReader r, string s)
    {
      return (object) s.Replace("^ ", "^");
    }

    private static object smethod_5(DxfReader r, string s)
    {
      if (s == null)
        return (object) new byte[0];
      byte[] numArray = new byte[s.Length >> 1];
      for (int startIndex = 0; startIndex < s.Length; startIndex += 2)
        numArray[startIndex >> 1] = byte.Parse(s.Substring(startIndex, 2), NumberStyles.HexNumber);
      return (object) numArray;
    }

    private static object smethod_6(DxfReader r, string s)
    {
      double result;
      if (!double.TryParse(s, NumberStyles.Float, (IFormatProvider) Class820.numberFormatInfo_0, out result) && !double.TryParse(s, NumberStyles.Float, (IFormatProvider) Class820.numberFormatInfo_1, out result))
      {
        if (s.StartsWith("1.#INF"))
          return (object) double.PositiveInfinity;
        if (s.StartsWith("-1.#INF"))
          return (object) double.NegativeInfinity;
        StringBuilder stringBuilder = new StringBuilder(s.Length);
        int index;
        for (index = 0; index < s.Length; ++index)
        {
          char c = s[index];
          if (!char.IsDigit(s[index]) && ".+-".IndexOf(c) < 0)
          {
            if (!char.IsWhiteSpace(c))
              throw new FormatException("Illegal double value at " + r.GroupReader.Position);
          }
          else
            break;
        }
        for (; index < s.Length; ++index)
        {
          char c = s[index];
          if (!char.IsDigit(c) && ".eE+-".IndexOf(c) < 0)
          {
            if (!char.IsWhiteSpace(c))
              break;
          }
          else
            stringBuilder.Append(c);
        }
        try
        {
          result = double.Parse(stringBuilder.ToString(), (IFormatProvider) CultureInfo.InvariantCulture);
        }
        catch (Exception ex)
        {
          throw new FormatException("Illegal double value at " + r.GroupReader.Position);
        }
      }
      return (object) result;
    }

    private static object smethod_7(DxfReader r, string s)
    {
      return (object) (int.Parse(s, (IFormatProvider) Class820.numberFormatInfo_0) == 1);
    }

    private static object smethod_8(DxfReader r, string s)
    {
      byte result;
      if (!byte.TryParse(s, NumberStyles.Integer, (IFormatProvider) Class820.numberFormatInfo_0, out result))
        throw new FormatException("Illegal byte value at " + r.GroupReader.Position);
      return (object) result;
    }

    private static object smethod_9(DxfReader r, string s)
    {
      ushort result1;
      if (!ushort.TryParse(s, NumberStyles.Integer, (IFormatProvider) Class820.numberFormatInfo_0, out result1))
      {
        short result2;
        if (!short.TryParse(s, NumberStyles.Integer, (IFormatProvider) Class820.numberFormatInfo_0, out result2))
        {
          double result3;
          bool flag;
          if ((flag = double.TryParse(s, NumberStyles.Float, (IFormatProvider) Class820.numberFormatInfo_0, out result3)) && result3 >= (double) short.MinValue && result3 <= (double) ushort.MaxValue)
          {
            result1 = (ushort) (int) result3;
            r.Messages.Add(new DxfMessage(DxfStatus.ParseIntegralTypeErrorButCouldRoundFromFloatingPoint, Severity.Error, "Position", (object) r.GroupReader.Position));
          }
          else
          {
            r.Messages.Add(new DxfMessage(DxfStatus.ParseUInt16Error, Severity.Error, "Position", (object) r.GroupReader.Position));
            if (!flag)
              throw new FormatException("Illegal UInt16 value at " + r.GroupReader.Position);
          }
        }
        else
          result1 = (ushort) result2;
      }
      return (object) (short) result1;
    }

    private static object smethod_10(DxfReader r, string s)
    {
      short result1;
      if (!short.TryParse(s, NumberStyles.Integer, (IFormatProvider) Class820.numberFormatInfo_0, out result1))
      {
        ushort result2;
        if (!ushort.TryParse(s, NumberStyles.Integer, (IFormatProvider) Class820.numberFormatInfo_0, out result2))
        {
          double result3;
          bool flag;
          if ((flag = double.TryParse(s, NumberStyles.Float, (IFormatProvider) Class820.numberFormatInfo_0, out result3)) && result3 >= (double) short.MinValue && result3 <= (double) ushort.MaxValue)
          {
            result1 = (short) (int) result3;
            r.Messages.Add(new DxfMessage(DxfStatus.ParseIntegralTypeErrorButCouldRoundFromFloatingPoint, Severity.Error, "Position", (object) r.GroupReader.Position));
          }
          else
          {
            r.Messages.Add(new DxfMessage(DxfStatus.ParseInt16Error, Severity.Error, "Position", (object) r.GroupReader.Position));
            if (!flag)
              throw new FormatException("Illegal Int16 value at " + r.GroupReader.Position);
          }
        }
        else
          result1 = (short) result2;
      }
      return (object) result1;
    }

    private static object smethod_11(DxfReader r, string s)
    {
      int result1;
      if (!int.TryParse(s, NumberStyles.Integer, (IFormatProvider) Class820.numberFormatInfo_0, out result1))
      {
        double result2;
        bool flag;
        if (flag = double.TryParse(s, NumberStyles.Float, (IFormatProvider) Class820.numberFormatInfo_0, out result2))
        {
          result1 = (int) result2;
          r.Messages.Add(new DxfMessage(DxfStatus.ParseIntegralTypeErrorButCouldRoundFromFloatingPoint, Severity.Error, "Position", (object) r.GroupReader.Position));
        }
        else
        {
          r.Messages.Add(new DxfMessage(DxfStatus.ParseInt32Error, Severity.Error, "Position", (object) r.GroupReader.Position));
          if (!flag)
            throw new FormatException("Illegal Int32 value at " + r.GroupReader.Position);
        }
      }
      return (object) result1;
    }

    private static object smethod_12(DxfReader r, string s)
    {
      long result;
      if (!long.TryParse(s, NumberStyles.Integer, (IFormatProvider) Class820.numberFormatInfo_0, out result))
        throw new FormatException("Illegal Int64 value at " + r.GroupReader.Position);
      return (object) result;
    }

    private static object smethod_13(DxfReader r, string s)
    {
      long result;
      if (!long.TryParse(s, NumberStyles.Integer, (IFormatProvider) Class820.numberFormatInfo_0, out result))
        return (object) null;
      return (object) result;
    }

    internal static object smethod_14(DxfReader r, string s)
    {
      if (string.IsNullOrEmpty(s))
        return (object) 0UL;
      return (object) ulong.Parse(s, NumberStyles.HexNumber, (IFormatProvider) Class820.numberFormatInfo_0);
    }

    internal static object smethod_15(DxfReader r, string s)
    {
      ulong result;
      if (!ulong.TryParse(s, NumberStyles.HexNumber, (IFormatProvider) Class820.numberFormatInfo_0, out result))
        return (object) null;
      return (object) result;
    }

    private static string smethod_16(object o)
    {
      return ((string) o).Replace("^", "^ ").Replace("\n", "^J").Replace("\r", "^M");
    }

    private static string smethod_17(object o)
    {
      byte[] numArray = (byte[]) o;
      StringBuilder stringBuilder = new StringBuilder(numArray.Length << 1);
      for (int index = 0; index < numArray.Length; ++index)
        stringBuilder.Append(numArray[index].ToString("X2"));
      return stringBuilder.ToString();
    }

    private static string smethod_18(object o)
    {
      double d = (double) o;
      if (double.IsNegativeInfinity(d))
        return "-0E+99";
      if (double.IsPositiveInfinity(d))
        return "0E+99";
      return d.ToString("R", (IFormatProvider) Class820.numberFormatInfo_0);
    }

    internal static string smethod_19(object o)
    {
      return ((byte) o).ToString((IFormatProvider) Class820.numberFormatInfo_0);
    }

    internal static string smethod_20(object o)
    {
      return ((short) o).ToString((IFormatProvider) Class820.numberFormatInfo_0);
    }

    internal static string smethod_21(object o)
    {
      return ((ushort) (short) o).ToString((IFormatProvider) Class820.numberFormatInfo_0);
    }

    private static string smethod_22(object o)
    {
      return ((int) o).ToString((IFormatProvider) Class820.numberFormatInfo_0);
    }

    private static string smethod_23(object o)
    {
      return ((long) o).ToString((IFormatProvider) Class820.numberFormatInfo_0);
    }

    internal static string smethod_24(object o)
    {
      return ((ulong) o).ToString("X", (IFormatProvider) Class820.numberFormatInfo_0);
    }

    private static string smethod_25(object o)
    {
      return !(bool) o ? "0" : "1";
    }

    private static object smethod_26(Class822 r)
    {
      try
      {
        for (byte index = r.Reader.ReadByte(); index != (byte) 0; index = r.Reader.ReadByte())
          r.MemStream.WriteByte(index);
      }
      catch (EndOfStreamException ex)
      {
        return (object) null;
      }
      string str = r.Encoding.GetString(r.MemStream.GetBuffer(), 0, (int) r.MemStream.Length);
      r.MemStream.SetLength(0L);
      r.MemStream.Position = 0L;
      return (object) str;
    }

    private static object smethod_27(Class822 r)
    {
      try
      {
        byte num = r.Reader.ReadByte();
        return (object) r.Reader.ReadBytes((int) num);
      }
      catch (EndOfStreamException ex)
      {
        return (object) null;
      }
    }

    private static object smethod_28(Class822 r)
    {
      return (object) r.Reader.ReadDouble();
    }

    private static object smethod_29(Class822 r)
    {
      return (object) (byte) r.Reader.ReadInt16();
    }

    private static object smethod_30(Class822 r)
    {
      return (object) r.Reader.ReadInt16();
    }

    private static object smethod_31(Class822 r)
    {
      return (object) (short) r.Reader.ReadUInt16();
    }

    private static object smethod_32(Class822 r)
    {
      return (object) r.Reader.ReadInt32();
    }

    private static object smethod_33(Class822 r)
    {
      return (object) r.Reader.ReadInt64();
    }

    internal static object smethod_34(Class822 r)
    {
      try
      {
        for (byte index = r.Reader.ReadByte(); index != (byte) 0; index = r.Reader.ReadByte())
          r.MemStream.WriteByte(index);
      }
      catch (EndOfStreamException ex)
      {
        return (object) null;
      }
      string s = r.Encoding.GetString(r.MemStream.GetBuffer(), 0, (int) r.MemStream.Length);
      r.MemStream.SetLength(0L);
      r.MemStream.Position = 0L;
      return (object) ulong.Parse(s, NumberStyles.HexNumber, (IFormatProvider) Class820.numberFormatInfo_0);
    }

    private static object smethod_35(Class822 r)
    {
      return (object) (r.Reader.ReadByte() == (byte) 1);
    }

    internal static void smethod_36(object o, Class347 w)
    {
      if (o != null)
        w.Writer.Write(w.Encoding.GetBytes((string) o));
      w.Writer.Write((byte) 0);
    }

    private static void smethod_37(object o, Class347 w)
    {
      if (o == null)
        return;
      byte[] buffer = (byte[]) o;
      byte length = (byte) buffer.Length;
      w.binaryWriter_0.Write(length);
      w.Writer.Write(buffer);
    }

    private static void smethod_38(object o, Class347 w)
    {
      w.Writer.Write((double) o);
    }

    internal static void smethod_39(object o, Class347 w)
    {
      w.Writer.Write((short) (byte) o);
    }

    internal static void smethod_40(object o, Class347 w)
    {
      w.Writer.Write((short) o);
    }

    internal static void smethod_41(object o, Class347 w)
    {
      w.Writer.Write((ushort) (short) o);
    }

    private static void smethod_42(object o, Class347 w)
    {
      w.Writer.Write((int) o);
    }

    private static void smethod_43(object o, Class347 w)
    {
      w.Writer.Write((long) o);
    }

    internal static void smethod_44(object o, Class347 w)
    {
      string s = ((ulong) o).ToString("X", (IFormatProvider) Class820.numberFormatInfo_0);
      w.Writer.Write(w.Encoding.GetBytes(s));
      w.Writer.Write((byte) 0);
    }

    private static void smethod_45(object o, Class347 w)
    {
      w.Writer.Write((bool) o ? (byte) 1 : (byte) 0);
    }

    static Class820()
    {
      foreach (object[] objArray1 in Class820.object_0)
      {
        int num1 = (int) objArray1[0];
        int num2 = (int) objArray1[1];
        Enum5 groupValueType = (Enum5) objArray1[2];
        DxfVersion minVersion = (DxfVersion) objArray1[3];
        object[] objArray2 = (object[]) null;
        foreach (object[] objArray3 in Class820.object_1)
        {
          if ((Enum5) objArray3[0] == groupValueType)
          {
            objArray2 = objArray3;
            break;
          }
        }
        if (objArray2 == null)
          throw new Exception("No conversion methods found for group value type " + (object) groupValueType + ".");
        Class820.Delegate19 fromStringDelegate = (Class820.Delegate19) objArray2[1];
        if (fromStringDelegate != null)
        {
          Class820.Delegate19 tryFromStringDelegate = (Class820.Delegate19) objArray2[2];
          if (tryFromStringDelegate != null)
          {
            Class820.Delegate20 toStringDelegate = (Class820.Delegate20) objArray2[3];
            if (toStringDelegate != null)
            {
              Class820.Delegate21 fromBinDelegate = (Class820.Delegate21) objArray2[4];
              Class820.Delegate22 toBinDelegate = (Class820.Delegate22) objArray2[5];
              for (int index = num1; index <= num2; ++index)
                Class820.class821_0[index] = new Class820.Class821(groupValueType, minVersion, fromStringDelegate, tryFromStringDelegate, toStringDelegate, fromBinDelegate, toBinDelegate);
            }
            else
              throw new Exception("Error processing codeToTypeTable, illegal entry (no ToString method for group range " + num1.ToString() + "-" + num2.ToString() + ").");
          }
          else
            throw new Exception("Error processing codeToTypeTable, illegal entry (no try string parse method): " + num1.ToString() + "-" + num2.ToString() + ").");
        }
        else
          throw new Exception("Error processing codeToTypeTable, illegal entry (no string parse method): " + num1.ToString() + "-" + num2.ToString() + ").");
      }
    }

    private delegate object Delegate19(DxfReader r, string s);

    private delegate string Delegate20(object o);

    private delegate object Delegate21(Class822 r);

    private delegate void Delegate22(object o, Class347 w);

    private class Class821
    {
      private readonly Enum5 enum5_0;
      private DxfVersion dxfVersion_0;
      private readonly Class820.Delegate19 delegate19_0;
      private readonly Class820.Delegate19 delegate19_1;
      private readonly Class820.Delegate20 delegate20_0;
      private readonly Class820.Delegate21 delegate21_0;
      private readonly Class820.Delegate22 delegate22_0;

      public Class821(
        Enum5 groupValueType,
        DxfVersion minVersion,
        Class820.Delegate19 fromStringDelegate,
        Class820.Delegate19 tryFromStringDelegate,
        Class820.Delegate20 toStringDelegate,
        Class820.Delegate21 fromBinDelegate,
        Class820.Delegate22 toBinDelegate)
      {
        this.enum5_0 = groupValueType;
        this.dxfVersion_0 = minVersion;
        this.delegate19_0 = fromStringDelegate;
        this.delegate19_1 = tryFromStringDelegate;
        this.delegate20_0 = toStringDelegate;
        this.delegate21_0 = fromBinDelegate;
        this.delegate22_0 = toBinDelegate;
      }

      public Enum5 GroupValueType
      {
        get
        {
          return this.enum5_0;
        }
      }

      public DxfVersion MinVersion
      {
        get
        {
          return this.dxfVersion_0;
        }
        set
        {
          this.dxfVersion_0 = value;
        }
      }

      public Class820.Delegate19 FromStringDelegate
      {
        get
        {
          return this.delegate19_0;
        }
      }

      public Class820.Delegate19 TryFromStringDelegate
      {
        get
        {
          return this.delegate19_1;
        }
      }

      public Class820.Delegate20 ToStringDelegate
      {
        get
        {
          return this.delegate20_0;
        }
      }

      public Class820.Delegate21 FromBinDelegate
      {
        get
        {
          return this.delegate21_0;
        }
      }

      public Class820.Delegate22 ToBinDelegate
      {
        get
        {
          return this.delegate22_0;
        }
      }
    }
  }
}
