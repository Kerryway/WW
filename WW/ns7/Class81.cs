// Decompiled with JetBrains decompiler
// Type: ns7.Class81
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using ns4;
using System;

namespace ns7
{
  internal class Class81 : Interface0
  {
    public byte[] imethod_0(char value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      Class81.smethod_0(bytes);
      return bytes;
    }

    public byte[] imethod_1(short value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      Class81.smethod_0(bytes);
      return bytes;
    }

    public byte[] imethod_2(ushort value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      Class81.smethod_0(bytes);
      return bytes;
    }

    public byte[] imethod_3(int value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      Class81.smethod_1(bytes);
      return bytes;
    }

    public byte[] imethod_4(uint value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      Class81.smethod_1(bytes);
      return bytes;
    }

    public byte[] imethod_5(long value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      Class81.smethod_2(bytes);
      return bytes;
    }

    public byte[] imethod_6(ulong value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      Class81.smethod_2(bytes);
      return bytes;
    }

    public byte[] imethod_7(double value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      Class81.smethod_2(bytes);
      return bytes;
    }

    public byte[] imethod_8(float value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      Class81.smethod_2(bytes);
      return bytes;
    }

    public char imethod_9(byte[] bytes)
    {
      return BitConverter.ToChar(Class81.smethod_3(bytes), 0);
    }

    public short imethod_10(byte[] bytes)
    {
      return BitConverter.ToInt16(Class81.smethod_3(bytes), 0);
    }

    public ushort imethod_11(byte[] bytes)
    {
      return BitConverter.ToUInt16(Class81.smethod_3(bytes), 0);
    }

    public int imethod_12(byte[] bytes)
    {
      return BitConverter.ToInt32(Class81.smethod_4(bytes), 0);
    }

    public uint imethod_13(byte[] bytes)
    {
      return BitConverter.ToUInt32(Class81.smethod_4(bytes), 0);
    }

    public long imethod_14(byte[] bytes)
    {
      return BitConverter.ToInt64(Class81.smethod_5(bytes), 0);
    }

    public ulong imethod_15(byte[] bytes)
    {
      return BitConverter.ToUInt64(Class81.smethod_5(bytes), 0);
    }

    public double imethod_16(byte[] bytes)
    {
      return BitConverter.ToDouble(Class81.smethod_5(bytes), 0);
    }

    public float imethod_17(byte[] bytes)
    {
      return BitConverter.ToSingle(Class81.smethod_4(bytes), 0);
    }

    public char imethod_18(byte[] bytes, int index)
    {
      return BitConverter.ToChar(Class81.smethod_3(bytes), index);
    }

    public short imethod_19(byte[] bytes, int index)
    {
      return BitConverter.ToInt16(Class81.smethod_6(bytes, index), 0);
    }

    public ushort imethod_20(byte[] bytes, int index)
    {
      return BitConverter.ToUInt16(Class81.smethod_6(bytes, index), 0);
    }

    public int imethod_21(byte[] bytes, int index)
    {
      return BitConverter.ToInt32(Class81.smethod_7(bytes, index), 0);
    }

    public uint imethod_22(byte[] bytes, int index)
    {
      return BitConverter.ToUInt32(Class81.smethod_7(bytes, index), 0);
    }

    public long imethod_23(byte[] bytes, int index)
    {
      return BitConverter.ToInt64(Class81.smethod_8(bytes, index), 0);
    }

    public ulong imethod_24(byte[] bytes, int index)
    {
      return BitConverter.ToUInt64(Class81.smethod_8(bytes, index), 0);
    }

    public double imethod_25(byte[] bytes, int index)
    {
      return BitConverter.ToDouble(Class81.smethod_8(bytes, index), 0);
    }

    public float imethod_26(byte[] bytes, int index)
    {
      return BitConverter.ToSingle(Class81.smethod_7(bytes, index), 0);
    }

    private static void smethod_0(byte[] bytes)
    {
      byte num = bytes[0];
      bytes[0] = bytes[1];
      bytes[1] = num;
    }

    private static void smethod_1(byte[] bytes)
    {
      byte num1 = bytes[0];
      bytes[0] = bytes[3];
      bytes[3] = num1;
      byte num2 = bytes[1];
      bytes[1] = bytes[2];
      bytes[2] = num2;
    }

    private static void smethod_2(byte[] bytes)
    {
      byte num1 = bytes[0];
      bytes[0] = bytes[7];
      bytes[7] = num1;
      byte num2 = bytes[1];
      bytes[1] = bytes[6];
      bytes[6] = num2;
      byte num3 = bytes[2];
      bytes[2] = bytes[5];
      bytes[5] = num3;
      byte num4 = bytes[3];
      bytes[3] = bytes[4];
      bytes[4] = num4;
    }

    private static byte[] smethod_3(byte[] bytes)
    {
      return new byte[2]{ bytes[1], bytes[0] };
    }

    private static byte[] smethod_4(byte[] bytes)
    {
      return new byte[4]{ bytes[3], bytes[2], bytes[1], bytes[0] };
    }

    private static byte[] smethod_5(byte[] bytes)
    {
      return new byte[8]{ bytes[7], bytes[6], bytes[5], bytes[4], bytes[3], bytes[2], bytes[1], bytes[0] };
    }

    private static byte[] smethod_6(byte[] bytes, int index)
    {
      return new byte[2]{ bytes[1 + index], bytes[index] };
    }

    private static byte[] smethod_7(byte[] bytes, int index)
    {
      return new byte[4]{ bytes[3 + index], bytes[2 + index], bytes[1 + index], bytes[index] };
    }

    private static byte[] smethod_8(byte[] bytes, int index)
    {
      return new byte[8]{ bytes[7 + index], bytes[6 + index], bytes[5 + index], bytes[4 + index], bytes[3 + index], bytes[2 + index], bytes[1 + index], bytes[index] };
    }
  }
}
