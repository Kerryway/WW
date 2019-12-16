// Decompiled with JetBrains decompiler
// Type: ns35.Class996
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace ns35
{
  internal static class Class996
  {
    public const int int_0 = 8;
    public const int int_1 = 32;
    public const int int_2 = 255;

    public static ulong smethod_0(ulong pageSize)
    {
      return 31UL - (ulong) ((long) pageSize + 32L - 1L) % 32UL;
    }

    public static ulong smethod_1(ulong pageSize)
    {
      return (ulong) ((long) pageSize + 32L - 1L & -32L);
    }

    public static ulong smethod_2(ulong dataSize)
    {
      ulong num = (ulong) ((long) dataSize + 8L - 1L & -8L);
      uint k = Class746.class746_0.K;
      ulong pageSize = (ulong) ((long) num * 2L + (long) k - 1L) / (ulong) k * (ulong) byte.MaxValue;
      return pageSize >= 1024UL ? Class996.smethod_1(pageSize) : 1024UL;
    }

    public static unsafe uint smethod_3(ulong seed, byte[] data, uint start, uint length)
    {
      seed = (ulong) (((long) seed + (long) length) * 214013L + 2531011L);
      uint sum1 = (uint) (seed & (ulong) ushort.MaxValue);
      uint sum2 = (uint) (seed >> 16 & (ulong) ushort.MaxValue);
      fixed (byte* numPtr = data)
      {
        byte* p = numPtr + (int) start;
        while (length != 0U)
        {
          uint num1 = Math.Min(5552U, length);
          length -= num1;
          uint num2 = num1 >> 3;
          while (num2-- > 0U)
          {
            Class996.smethod_5(p + 6, ref sum1, ref sum2);
            Class996.smethod_5(p + 4, ref sum1, ref sum2);
            Class996.smethod_5(p + 2, ref sum1, ref sum2);
            Class996.smethod_5(p, ref sum1, ref sum2);
            p += 8;
          }
          uint num3 = num1 & 7U;
          if (num3 > 0U)
          {
            switch (num3)
            {
              case 1:
                Class996.smethod_4(p, ref sum1, ref sum2);
                break;
              case 2:
                Class996.smethod_5(p, ref sum1, ref sum2);
                break;
              case 3:
                Class996.smethod_5(p, ref sum1, ref sum2);
                Class996.smethod_4(p + 2, ref sum1, ref sum2);
                break;
              case 4:
                Class996.smethod_5(p + 2, ref sum1, ref sum2);
                Class996.smethod_5(p, ref sum1, ref sum2);
                break;
              case 5:
                Class996.smethod_5(p + 2, ref sum1, ref sum2);
                Class996.smethod_5(p, ref sum1, ref sum2);
                Class996.smethod_4(p + 4, ref sum1, ref sum2);
                break;
              case 6:
                Class996.smethod_5(p + 2, ref sum1, ref sum2);
                Class996.smethod_5(p, ref sum1, ref sum2);
                Class996.smethod_5(p + 4, ref sum1, ref sum2);
                break;
              case 7:
                Class996.smethod_5(p + 2, ref sum1, ref sum2);
                Class996.smethod_5(p, ref sum1, ref sum2);
                Class996.smethod_5(p + 4, ref sum1, ref sum2);
                Class996.smethod_4(p + 6, ref sum1, ref sum2);
                break;
            }
            p += (int) num3;
          }
          sum1 %= 65521U;
          sum2 %= 65521U;
        }
      }
      return (uint) ((int) sum2 << 16 | (int) sum1 & (int) ushort.MaxValue);
    }

    private static unsafe void smethod_4(byte* p, ref uint sum1, ref uint sum2)
    {
      sum1 += (uint) *p;
      sum2 += sum1;
    }

    private static unsafe void smethod_5(byte* p, ref uint sum1, ref uint sum2)
    {
      sum1 += (uint) *p;
      sum2 += sum1;
      sum1 += (uint) p[1];
      sum2 += sum1;
    }
  }
}
