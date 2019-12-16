// Decompiled with JetBrains decompiler
// Type: ns28.Class992
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.IO;

namespace ns28
{
  internal static class Class992
  {
    private const byte byte_0 = 127;
    private const byte byte_1 = 128;

    public static void smethod_0(Stream stream, int value)
    {
      if (value < 0)
      {
        for (value = -value; value >= 64; value >>= 7)
          stream.WriteByte((byte) (value & (int) sbyte.MaxValue | 128));
        stream.WriteByte((byte) (value | 64));
      }
      else
      {
        for (; value >= 64; value >>= 7)
          stream.WriteByte((byte) (value & (int) sbyte.MaxValue | 128));
        stream.WriteByte((byte) value);
      }
    }

    public static void smethod_1(Stream stream, uint value)
    {
      for (; value >= 128U; value >>= 7)
        stream.WriteByte((byte) ((int) value & (int) sbyte.MaxValue | 128));
      stream.WriteByte((byte) value);
    }

    public static void smethod_2(Stream stream, uint value)
    {
      if (value >= 32768U)
      {
        stream.WriteByte((byte) (value & (uint) byte.MaxValue));
        stream.WriteByte((byte) ((int) (value >> 8) & (int) sbyte.MaxValue | 128));
        stream.WriteByte((byte) (value >> 15 & (uint) byte.MaxValue));
        stream.WriteByte((byte) (value >> 23 & (uint) byte.MaxValue));
      }
      else
      {
        stream.WriteByte((byte) (value & (uint) byte.MaxValue));
        stream.WriteByte((byte) (value >> 8 & (uint) byte.MaxValue));
      }
    }

    public static void smethod_3(Stream stream, ulong value)
    {
      if (value == 0UL)
      {
        stream.WriteByte((byte) 0);
      }
      else
      {
        ulong num1 = value >> 7;
        while (value != 0UL)
        {
          byte num2 = (byte) (value & (ulong) sbyte.MaxValue);
          if (num1 != 0UL)
            num2 |= (byte) 128;
          stream.WriteByte(num2);
          value = num1;
          num1 = value >> 7;
        }
      }
    }

    public static int smethod_4(Stream stream)
    {
      int num1 = 15;
      byte num2 = Class1045.smethod_2(stream);
      byte num3 = Class1045.smethod_2(stream);
      bool flag = ((int) num3 & 128) == 0;
      int num4 = (int) num2 | ((int) num3 & (int) sbyte.MaxValue) << 8;
      while (!flag)
      {
        byte num5 = Class1045.smethod_2(stream);
        byte num6 = Class1045.smethod_2(stream);
        flag = ((int) num6 & 128) == 0;
        int num7 = num4 | (int) num5 << num1;
        int num8 = num1 + 8;
        num4 = num7 | ((int) num6 & (int) sbyte.MaxValue) << num8;
        num1 = num8 + 7;
      }
      return num4;
    }

    public static ulong smethod_5(Stream stream)
    {
      int num1 = 0;
      byte num2 = Class1045.smethod_2(stream);
      ulong num3 = (ulong) ((int) num2 & (int) sbyte.MaxValue);
      if (((int) num2 & 128) != 0)
      {
        byte num4;
        do
        {
          num1 += 7;
          num4 = Class1045.smethod_2(stream);
          num3 |= (ulong) ((int) num4 & (int) sbyte.MaxValue) << num1;
        }
        while (((int) num4 & 128) != 0);
      }
      return num3;
    }
  }
}
