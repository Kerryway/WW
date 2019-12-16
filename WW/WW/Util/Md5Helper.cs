// Decompiled with JetBrains decompiler
// Type: WW.Util.Md5Helper
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Security.Cryptography;

namespace WW.Util
{
  public static class Md5Helper
  {
    private static readonly int[] int_0 = new int[64]{ 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 5, 9, 14, 20, 5, 9, 14, 20, 5, 9, 14, 20, 5, 9, 14, 20, 4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23, 6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21 };
    private static readonly uint[] uint_4 = new uint[64];
    private const uint uint_0 = 1732584193;
    private const uint uint_1 = 4023233417;
    private const uint uint_2 = 2562383102;
    private const uint uint_3 = 271733878;

    static Md5Helper()
    {
      double num = System.Math.Pow(2.0, 32.0);
      for (int index = 0; index < 64; ++index)
        Md5Helper.uint_4[index] = (uint)System.Math.Floor(System.Math.Abs(System.Math.Sin((double) (index + 1))) * num);
    }

    public static byte[] ComputeHash(byte[] bytes)
    {
      return MD5.Create().ComputeHash(bytes);
    }

    public static byte[] ComputeHash(byte[] bytes, int start, int length)
    {
      return MD5.Create().ComputeHash(bytes, start, length);
    }

    public static byte[] GetHash(byte[] bytes)
    {
      return Md5Helper.GetHash(bytes, 0L, (long) bytes.Length);
    }

    public static byte[] GetHash(byte[] bytes, long start, long length)
    {
      uint[] w = new uint[16];
      long num1 = 8L * length;
      long num2 = 0;
      uint[] h = new uint[4]{ 1732584193U, 4023233417U, 2562383102U, 271733878U };
      long num3;
      for (num3 = length & -64L; num2 < num3; num2 += 64L)
        Md5Helper.smethod_0(bytes, num2 + start, h, w);
      byte[] bytes1 = new byte[64];
      long index1;
      for (index1 = 0L; index1 < length - num3; ++index1)
        bytes1[index1] = bytes[num2 + start + index1];
      if (index1 == 64L)
      {
        Md5Helper.smethod_0(bytes1, 0L, h, w);
        index1 = 0L;
      }
      byte[] numArray1 = bytes1;
      long num4 = index1;
      long num5 = num4 + 1L;
      long num6 = num4;
      numArray1[ num6] = (byte) 128;
      if (num5 > 56L)
      {
        while (num5 < 64L)
          bytes1[ num5++] = (byte) 0;
        Md5Helper.smethod_0(bytes1, 0L, h, w);
        num5 = 0L;
      }
      while (num5 < 56L)
        bytes1[ num5++] = (byte) 0;
      byte[] numArray2 = bytes1;
      long num7 = num5;
      long num8 = num7 + 1L;
      long num9 = num7;
      int num10 = (int) (byte) (num1 & (long) byte.MaxValue);
      numArray2[ num9] = (byte) num10;
      byte[] numArray3 = bytes1;
      long num11 = num8;
      long num12 = num11 + 1L;
      long num13 = num11;
      int num14 = (int) (byte) (num1 >> 8 & (long) byte.MaxValue);
      numArray3[ num13] = (byte) num14;
      byte[] numArray4 = bytes1;
      long num15 = num12;
      long num16 = num15 + 1L;
      long num17 = num15;
      int num18 = (int) (byte) (num1 >> 16 & (long) byte.MaxValue);
      numArray4[ num17] = (byte) num18;
      byte[] numArray5 = bytes1;
      long num19 = num16;
      long num20 = num19 + 1L;
      long num21 = num19;
      int num22 = (int) (byte) (num1 >> 24 & (long) byte.MaxValue);
      numArray5[ num21] = (byte) num22;
      byte[] numArray6 = bytes1;
      long num23 = num20;
      long num24 = num23 + 1L;
      long num25 = num23;
      int num26 = (int) (byte) (num1 >> 32 & (long) byte.MaxValue);
      numArray6[ num25] = (byte) num26;
      byte[] numArray7 = bytes1;
      long num27 = num24;
      long num28 = num27 + 1L;
      long num29 = num27;
      int num30 = (int) (byte) (num1 >> 40 & (long) byte.MaxValue);
      numArray7[ num29] = (byte) num30;
      byte[] numArray8 = bytes1;
      long num31 = num28;
      long num32 = num31 + 1L;
      long num33 = num31;
      int num34 = (int) (byte) (num1 >> 48 & (long) byte.MaxValue);
      numArray8[ num33] = (byte) num34;
      byte[] numArray9 = bytes1;
      long num35 = num32;
      long num36 = num35 + 1L;
      long num37 = num35;
      int num38 = (int) (byte) (num1 >> 56 & (long) byte.MaxValue);
      numArray9[ num37] = (byte) num38;
      Md5Helper.smethod_0(bytes1, 0L, h, w);
      byte[] numArray10 = new byte[16];
      for (int index2 = 0; index2 < 4; ++index2)
      {
        int index3 = 4 * index2;
        numArray10[index3] = (byte) (h[index2] & (uint) byte.MaxValue);
        numArray10[index3 + 1] = (byte) (h[index2] >> 8 & (uint) byte.MaxValue);
        numArray10[index3 + 2] = (byte) (h[index2] >> 16 & (uint) byte.MaxValue);
        numArray10[index3 + 3] = (byte) (h[index2] >> 24 & (uint) byte.MaxValue);
      }
      return numArray10;
    }

    private static void smethod_0(byte[] bytes, long pos, uint[] h, uint[] w)
    {
      uint num1 = h[0];
      uint num2 = h[1];
      uint num3 = h[2];
      uint num4 = h[3];
      for (int index1 = 0; index1 < 16; ++index1)
      {
        long index2 = pos + (long) (4 * index1);
        w[index1] = (uint) ((int) bytes[index2] | (int) bytes[index2 + 1L] << 8 | (int) bytes[index2 + 2L] << 16 | (int) bytes[index2 + 3L] << 24);
      }
      for (uint index = 0; index < 64U; ++index)
      {
        uint num5;
        uint num6;
        if (index < 16U)
        {
          num5 = num4 ^ num2 & (num3 ^ num4);
          num6 = index;
        }
        else if (index < 32U)
        {
          num5 = num3 ^ num4 & (num2 ^ num3);
          num6 = (uint) (5 * (int) index + 1) % 16U;
        }
        else if (index < 48U)
        {
          num5 = num2 ^ num3 ^ num4;
          num6 = (uint) (3 * (int) index + 5) % 16U;
        }
        else
        {
          num5 = num3 ^ (num2 | ~num4);
          num6 = 7U * index % 16U;
        }
        uint num7 = num4;
        num4 = num3;
        num3 = num2;
        num2 = Md5Helper.smethod_1(num1 + num5 + Md5Helper.uint_4[ index] + w[ num6], Md5Helper.int_0[ index]) + num2;
        num1 = num7;
      }
      h[0] += num1;
      h[1] += num2;
      h[2] += num3;
      h[3] += num4;
    }

    private static uint smethod_1(uint v, int r)
    {
      return v << r | v >> 32 - r;
    }
  }
}
