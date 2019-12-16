// Decompiled with JetBrains decompiler
// Type: ns39.Class998
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace ns39
{
  internal class Class998
  {
    public static readonly byte[] byte_0 = new byte[256];
    public const int int_0 = 128;
    public const int int_1 = 108;
    public const int int_2 = 128;
    public const int int_3 = 32;
    public const int int_4 = 32;
    public const int int_5 = 256;
    public const int int_6 = 1097010747;
    public const int int_7 = 1097007163;
    public const int int_8 = 1097008187;
    public const int int_9 = 1097093995;

    static Class998()
    {
      int num = 1;
      for (int index = 0; index < 256; ++index)
      {
        num = num * 214013 + 2531011;
        Class998.byte_0[index] = (byte) (num >> 16);
      }
    }

    public static int smethod_0(int pageSize)
    {
      return 31 - (pageSize + 32 - 1) % 32;
    }

    public static unsafe uint smethod_1(uint seed, byte[] data, int start, int length)
    {
      uint num1 = seed & (uint) ushort.MaxValue;
      uint num2 = seed >> 16;
      fixed (byte* numPtr1 = data)
      {
        byte* numPtr2 = numPtr1 + start;
        while (length != 0)
        {
          int num3 = Math.Min(5552, length);
          length -= num3;
          for (int index = 0; index < num3; ++index)
          {
            num1 += (uint) *numPtr2;
            num2 += num1;
            ++numPtr2;
          }
          num1 %= 65521U;
          num2 %= 65521U;
        }
      }
      return (uint) ((int) num2 << 16 | (int) num1 & (int) ushort.MaxValue);
    }
  }
}
