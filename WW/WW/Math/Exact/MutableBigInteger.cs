// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.MutableBigInteger
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Text;

namespace WW.Math.Exact
{
  [Serializable]
  internal struct MutableBigInteger
  {
    private bool isNegative;
    private int length;
    private uint[] digits;

    public MutableBigInteger(int capacity)
    {
      this.isNegative = false;
      this.length = 0;
      this.digits = new uint[capacity];
    }

    public bool IsZero
    {
      get
      {
        return this.length == 0;
      }
    }

    public bool IsNaN
    {
      get
      {
        return this.length < 0;
      }
    }

    public static void smethod_0(BigInteger value, ref MutableBigInteger result, int shift)
    {
      int resultLength;
      BigInteger.smethod_5(value.Digits, value.Length, result.digits, shift, out resultLength);
      result.isNegative = value.IsNegative;
      result.length = resultLength;
    }

    public void method_0(int shift)
    {
      BigInteger.smethod_6(this.digits, this.length, shift, out this.length);
    }

    public static void smethod_1(BigInteger value, ref MutableBigInteger result, int shift)
    {
      int resultLength;
      BigInteger.smethod_8(value.Digits, value.Length, result.digits, shift, out resultLength);
      result.isNegative = value.IsNegative;
      result.length = resultLength;
    }

    public void method_1(int shift)
    {
      BigInteger.smethod_9(this.digits, this.length, shift, out this.length);
    }

    internal int method_2()
    {
      return BigInteger.smethod_0(this.digits, this.length);
    }

    internal static void smethod_2(
      MutableBigInteger a,
      MutableBigInteger b,
      ref MutableBigInteger result)
    {
      if (a.isNegative == b.isNegative)
      {
        int resultLength;
        BigInteger.smethod_11(a.digits, a.length, b.digits, b.length, result.digits, out resultLength);
        result.length = resultLength;
        result.isNegative = a.isNegative && result.length > 0;
      }
      else
      {
        if (a.method_3(b) < 0)
        {
          BigInteger.smethod_12(b.digits, b.length, a.digits, a.length, result.digits);
          result.isNegative = b.isNegative;
        }
        else
        {
          BigInteger.smethod_12(a.digits, a.length, b.digits, b.length, result.digits);
          result.isNegative = a.isNegative;
        }
        result.length = System.Math.Max(a.length, b.length);
        result.method_5();
      }
    }

    internal static void smethod_3(
      MutableBigInteger a,
      MutableBigInteger b,
      ref MutableBigInteger result)
    {
      if (a.isNegative != b.isNegative)
      {
        int resultLength;
        BigInteger.smethod_11(a.digits, a.length, b.digits, b.length, result.digits, out resultLength);
        result.length = resultLength;
        result.isNegative = a.isNegative && result.length > 0;
      }
      else
        MutableBigInteger.smethod_4(a, b, ref result);
    }

    internal static void smethod_4(
      MutableBigInteger a,
      MutableBigInteger b,
      ref MutableBigInteger result)
    {
      if (a.method_3(b) < 0)
      {
        BigInteger.smethod_12(b.digits, b.length, a.digits, a.length, result.digits);
        result.length = b.length;
        result.isNegative = !b.isNegative;
      }
      else
      {
        BigInteger.smethod_12(a.digits, a.length, b.digits, b.length, result.digits);
        result.length = a.length;
        result.isNegative = a.isNegative;
      }
      result.method_5();
    }

    internal static void smethod_5(
      MutableBigInteger a,
      MutableBigInteger b,
      ref MutableBigInteger result)
    {
      int num = BigInteger.smethod_14(a.digits, a.length, b.digits, b.length);
      if (num < 0)
      {
        result.length = BigInteger.smethod_13(b.digits, b.length, a.digits, a.length, result.digits);
        result.isNegative = !b.isNegative;
        result.method_5();
      }
      else if (num > 0)
      {
        result.length = BigInteger.smethod_13(a.digits, a.length, b.digits, b.length, result.digits);
        result.isNegative = a.isNegative;
        result.method_5();
      }
      else
      {
        result.length = 0;
        result.isNegative = false;
      }
    }

    public int method_3(MutableBigInteger other)
    {
      return BigInteger.smethod_14(this.digits, this.length, other.digits, other.length);
    }

    public override string ToString()
    {
      return this.method_4(10);
    }

    public string method_4(int radix)
    {
      if (radix > 16)
        throw new ArgumentException("Only radix up to 16 is supported.");
      if (this.IsNaN)
        return "NaN";
      if (this.IsZero)
        return "0";
      StringBuilder stringBuilder = new StringBuilder();
      BigInteger b = new BigInteger(radix);
      if (!this.IsZero)
      {
        BigInteger quotient = new BigInteger(this.isNegative, this.length, this.digits);
        while (!quotient.IsZero)
        {
          BigInteger remainder;
          BigInteger.smethod_4(quotient, b, out quotient, out remainder);
          stringBuilder.Insert(0, BigMath.smethod_0(remainder));
        }
      }
      if (this.IsNegative)
        stringBuilder.Insert(0, "-");
      return stringBuilder.ToString();
    }

    public bool IsNegative
    {
      get
      {
        return this.isNegative;
      }
      set
      {
        this.isNegative = value;
      }
    }

    public int Length
    {
      get
      {
        return this.length;
      }
      set
      {
        this.length = value;
      }
    }

    public uint[] Digits
    {
      get
      {
        return this.digits;
      }
      set
      {
        this.digits = value;
      }
    }

    private void method_5()
    {
      while (this.length > 0 && this.digits[this.length - 1] == 0U)
        --this.length;
      if (this.length != 0)
        return;
      this.isNegative = false;
    }
  }
}
