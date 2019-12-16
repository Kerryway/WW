// Decompiled with JetBrains decompiler
// Type: WW.BigEndianBitConverter
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using ns4;
using ns7;
using ns9;
using System;

namespace WW
{
  public static class BigEndianBitConverter
  {
    private static readonly Interface0 interface0_0;

    static BigEndianBitConverter()
    {
      if (BitConverter.IsLittleEndian)
        BigEndianBitConverter.interface0_0 = (Interface0) new Class81();
      else
        BigEndianBitConverter.interface0_0 = (Interface0) new Class183();
    }

    public static byte[] GetBytes(char value)
    {
      return BigEndianBitConverter.interface0_0.imethod_0(value);
    }

    public static byte[] GetBytes(short value)
    {
      return BigEndianBitConverter.interface0_0.imethod_1(value);
    }

    public static byte[] GetBytes(ushort value)
    {
      return BigEndianBitConverter.interface0_0.imethod_2(value);
    }

    public static byte[] GetBytes(int value)
    {
      return BigEndianBitConverter.interface0_0.imethod_3(value);
    }

    public static byte[] GetBytes(uint value)
    {
      return BigEndianBitConverter.interface0_0.imethod_4(value);
    }

    public static byte[] GetBytes(long value)
    {
      return BigEndianBitConverter.interface0_0.imethod_5(value);
    }

    public static byte[] GetBytes(ulong value)
    {
      return BigEndianBitConverter.interface0_0.imethod_6(value);
    }

    public static byte[] GetBytes(double value)
    {
      return BigEndianBitConverter.interface0_0.imethod_7(value);
    }

    public static byte[] GetBytes(float value)
    {
      return BigEndianBitConverter.interface0_0.imethod_8(value);
    }

    public static char ToChar(byte[] bytes)
    {
      return BigEndianBitConverter.interface0_0.imethod_9(bytes);
    }

    public static short ToInt16(byte[] bytes)
    {
      return BigEndianBitConverter.interface0_0.imethod_10(bytes);
    }

    public static ushort ToUInt16(byte[] bytes)
    {
      return BigEndianBitConverter.interface0_0.imethod_11(bytes);
    }

    public static int ToInt32(byte[] bytes)
    {
      return BigEndianBitConverter.interface0_0.imethod_12(bytes);
    }

    public static uint ToUInt32(byte[] bytes)
    {
      return BigEndianBitConverter.interface0_0.imethod_13(bytes);
    }

    public static long ToInt64(byte[] bytes)
    {
      return BigEndianBitConverter.interface0_0.imethod_14(bytes);
    }

    public static ulong ToUInt64(byte[] bytes)
    {
      return BigEndianBitConverter.interface0_0.imethod_15(bytes);
    }

    public static double ToDouble(byte[] bytes)
    {
      return BigEndianBitConverter.interface0_0.imethod_16(bytes);
    }

    public static float ToSingle(byte[] bytes)
    {
      return BigEndianBitConverter.interface0_0.imethod_17(bytes);
    }

    public static char ToChar(byte[] bytes, int index)
    {
      return BigEndianBitConverter.interface0_0.imethod_18(bytes, index);
    }

    public static short ToInt16(byte[] bytes, int index)
    {
      return BigEndianBitConverter.interface0_0.imethod_19(bytes, index);
    }

    public static ushort ToUInt16(byte[] bytes, int index)
    {
      return BigEndianBitConverter.interface0_0.imethod_20(bytes, index);
    }

    public static int ToInt32(byte[] bytes, int index)
    {
      return BigEndianBitConverter.interface0_0.imethod_21(bytes, index);
    }

    public static uint ToUInt32(byte[] bytes, int index)
    {
      return BigEndianBitConverter.interface0_0.imethod_22(bytes, index);
    }

    public static long ToInt64(byte[] bytes, int index)
    {
      return BigEndianBitConverter.interface0_0.imethod_23(bytes, index);
    }

    public static ulong ToUInt64(byte[] bytes, int index)
    {
      return BigEndianBitConverter.interface0_0.imethod_24(bytes, index);
    }

    public static double ToDouble(byte[] bytes, int index)
    {
      return BigEndianBitConverter.interface0_0.imethod_25(bytes, index);
    }

    public static float ToSingle(byte[] bytes, int index)
    {
      return BigEndianBitConverter.interface0_0.imethod_26(bytes, index);
    }
  }
}
