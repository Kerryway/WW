// Decompiled with JetBrains decompiler
// Type: WW.Text.StringUtil
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace WW.Text
{
  public static class StringUtil
  {
    private const byte byte_0 = 48;
    private const byte byte_1 = 65;

    public static byte[] FromHexString(string s)
    {
      s = s.Trim();
      List<byte> byteList = new List<byte>();
      int num1 = 0;
      while (num1 < s.Length)
      {
        char c1 = s[num1++];
        while (char.IsWhiteSpace(c1) && num1 < s.Length)
          c1 = s[num1++];
        if (StringUtil.smethod_1(c1))
        {
          char c2;
          if (num1 < s.Length)
          {
            c2 = s[num1++];
            if (char.IsWhiteSpace(c2))
            {
              c2 = c1;
              c1 = '0';
            }
            else if (!StringUtil.smethod_1(c2))
              throw new ArgumentException("Illegal char " + (object) c2 + " at position " + (object) num1);
          }
          else
          {
            c2 = c1;
            c1 = '0';
          }
          byte num2 = (byte) ((uint) StringUtil.smethod_0(c1) * 16U + (uint) StringUtil.smethod_0(c2));
          byteList.Add(num2);
        }
        else
          throw new ArgumentException("Illegal char " + (object) c1 + " at position " + (object) num1);
      }
      return byteList.ToArray();
    }

    public static string ToHexString(byte[] bytes, int offset, int length, bool useSpaceSeparator)
    {
      if (bytes == null || bytes.Length == 0)
        return string.Empty;
      StringBuilder stringBuilder = new StringBuilder(bytes.Length * 3 - 1);
      stringBuilder.Append(bytes[offset].ToString("x2"));
      for (int index = 1; index < length; ++index)
      {
        if (useSpaceSeparator)
          stringBuilder.Append(' ');
        stringBuilder.Append(bytes[offset + index].ToString("x2"));
      }
      return stringBuilder.ToString();
    }

    public static string RemoveLeadingZeroes(string s)
    {
      if (!string.IsNullOrEmpty(s))
      {
        int startIndex = -1;
        for (int index = 0; index < s.Length; ++index)
        {
          char c = s[index];
          if (!char.IsWhiteSpace(c) && c != '0')
          {
            startIndex = index;
            break;
          }
        }
        if (startIndex >= 0)
          s = s.Substring(startIndex);
      }
      return s;
    }

    public static string GetEnumDescription(Enum value)
    {
      Type type = value.GetType();
      string name = value.ToString();
      FieldInfo field = type.GetField(name);
      string str;
      if (field == (FieldInfo) null)
      {
        str = name;
      }
      else
      {
        object[] customAttributes = field.GetCustomAttributes(typeof (DescriptionAttribute), false);
        str = customAttributes.Length <= 0 ? name : ((DescriptionAttribute) customAttributes[0]).Description;
      }
      return str;
    }

    public static bool GetNextTag(string s, ref int startIndex, out string tag)
    {
      tag = string.Empty;
      while (startIndex < s.Length && (char.IsWhiteSpace(s[startIndex]) || s[startIndex] == ','))
        ++startIndex;
      while (startIndex < s.Length && s[startIndex] != ':')
      {
        tag += (string) (object) s[startIndex];
        ++startIndex;
      }
      if (startIndex >= s.Length || s[startIndex] != ':')
        return false;
      ++startIndex;
      return true;
    }

    public static bool GetNextValue(string s, ref int startIndex, out string value)
    {
      value = string.Empty;
      while (startIndex < s.Length && char.IsWhiteSpace(s[startIndex]))
        ++startIndex;
      if (s[startIndex] == '"')
      {
        ++startIndex;
        while (startIndex < s.Length && s[startIndex] != '"')
        {
          if (s[startIndex] == '\\')
          {
            ++startIndex;
            if (startIndex >= s.Length)
              return false;
          }
          value += (string) (object) s[startIndex];
          ++startIndex;
        }
        if (startIndex >= s.Length || s[startIndex] != '"')
          return false;
        ++startIndex;
        return true;
      }
      while (startIndex < s.Length && s[startIndex] != ',')
      {
        value += (string) (object) s[startIndex];
        ++startIndex;
      }
      return true;
    }

    public static Dictionary<string, string> GetProperties(string s)
    {
      int startIndex = 0;
      return StringUtil.GetProperties(s, ref startIndex);
    }

    public static Dictionary<string, string> GetProperties(string s, ref int startIndex)
    {
      Dictionary<string, string> dictionary = new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.InvariantCultureIgnoreCase);
      string str;
      string tag;
      while (StringUtil.GetNextTag(s, ref startIndex, out tag) && StringUtil.GetNextValue(s, ref startIndex, out str))
        dictionary.Add(tag, str);
      return dictionary;
    }

    private static byte smethod_0(char c)
    {
      c = char.ToUpperInvariant(c);
      if (c >= '0' && c <= '9')
        return (byte) ((uint) (byte) c - 48U);
      if (c >= 'A' && c <= 'F')
        return (byte) ((int) (byte) c - 65 + 10);
      throw new ArgumentException("Illegal hex char " + (object) c + ".");
    }

    private static bool smethod_1(char c)
    {
      c = char.ToUpperInvariant(c);
      if (char.IsDigit(c))
        return true;
      if (c >= 'A')
        return c <= 'F';
      return false;
    }
  }
}
