// Decompiled with JetBrains decompiler
// Type: ns9.Class183
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using ns4;
using System;

namespace ns9
{
  internal class Class183 : Interface0
  {
    public byte[] imethod_0(char value)
    {
      return BitConverter.GetBytes(value);
    }

    public byte[] imethod_1(short value)
    {
      return BitConverter.GetBytes(value);
    }

    public byte[] imethod_2(ushort value)
    {
      return BitConverter.GetBytes(value);
    }

    public byte[] imethod_3(int value)
    {
      return BitConverter.GetBytes(value);
    }

    public byte[] imethod_4(uint value)
    {
      return BitConverter.GetBytes(value);
    }

    public byte[] imethod_5(long value)
    {
      return BitConverter.GetBytes(value);
    }

    public byte[] imethod_6(ulong value)
    {
      return BitConverter.GetBytes(value);
    }

    public byte[] imethod_7(double value)
    {
      return BitConverter.GetBytes(value);
    }

    public byte[] imethod_8(float value)
    {
      return BitConverter.GetBytes(value);
    }

    public char imethod_9(byte[] bytes)
    {
      return BitConverter.ToChar(bytes, 0);
    }

    public short imethod_10(byte[] bytes)
    {
      return BitConverter.ToInt16(bytes, 0);
    }

    public ushort imethod_11(byte[] bytes)
    {
      return BitConverter.ToUInt16(bytes, 0);
    }

    public int imethod_12(byte[] bytes)
    {
      return BitConverter.ToInt32(bytes, 0);
    }

    public uint imethod_13(byte[] bytes)
    {
      return BitConverter.ToUInt32(bytes, 0);
    }

    public long imethod_14(byte[] bytes)
    {
      return BitConverter.ToInt64(bytes, 0);
    }

    public ulong imethod_15(byte[] bytes)
    {
      return BitConverter.ToUInt64(bytes, 0);
    }

    public double imethod_16(byte[] bytes)
    {
      return BitConverter.ToDouble(bytes, 0);
    }

    public float imethod_17(byte[] bytes)
    {
      return BitConverter.ToSingle(bytes, 0);
    }

    public char imethod_18(byte[] bytes, int index)
    {
      return BitConverter.ToChar(bytes, index);
    }

    public short imethod_19(byte[] bytes, int index)
    {
      return BitConverter.ToInt16(bytes, index);
    }

    public ushort imethod_20(byte[] bytes, int index)
    {
      return BitConverter.ToUInt16(bytes, index);
    }

    public int imethod_21(byte[] bytes, int index)
    {
      return BitConverter.ToInt32(bytes, index);
    }

    public uint imethod_22(byte[] bytes, int index)
    {
      return BitConverter.ToUInt32(bytes, index);
    }

    public long imethod_23(byte[] bytes, int index)
    {
      return BitConverter.ToInt64(bytes, index);
    }

    public ulong imethod_24(byte[] bytes, int index)
    {
      return BitConverter.ToUInt64(bytes, index);
    }

    public double imethod_25(byte[] bytes, int index)
    {
      return BitConverter.ToDouble(bytes, index);
    }

    public float imethod_26(byte[] bytes, int index)
    {
      return BitConverter.ToSingle(bytes, index);
    }
  }
}
