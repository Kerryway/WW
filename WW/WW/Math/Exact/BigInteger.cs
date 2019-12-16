// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.BigInteger
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Diagnostics;
using System.Text;

namespace WW.Math.Exact
{
  [Serializable]
  public struct BigInteger : IComparable<BigInteger>
  {
    private static uint[] zeroDigits = new uint[0];
    private static uint[] oneDigits = new uint[1]{ 1U };
    private static uint[] twoDigits = new uint[1]{ 2U };
    private static uint[] threeDigits = new uint[1]{ 3U };
    public static readonly BigInteger Zero = new BigInteger(false, 0, BigInteger.zeroDigits);
    public static readonly BigInteger One = new BigInteger(false, 1, BigInteger.oneDigits);
    public static readonly BigInteger MinusOne = new BigInteger(true, 1, BigInteger.oneDigits);
    public static readonly BigInteger Two = new BigInteger(false, 1, BigInteger.twoDigits);
    public static readonly BigInteger MinusTwo = new BigInteger(true, 1, BigInteger.twoDigits);
    public static readonly BigInteger Three = new BigInteger(false, 1, BigInteger.threeDigits);
    public static readonly BigInteger MinusThree = new BigInteger(true, 1, BigInteger.threeDigits);
    public static readonly BigInteger NaN = new BigInteger(false, -1, (uint[]) null);
    internal static readonly byte[] byteToLsOneBit = new byte[256];
    internal static readonly byte[] byteToMsOneBit = new byte[256];
    internal const uint AllocationChunkSize = 8;
    internal const ulong Radix = 4294967296;
    internal const int LgRadix = 32;
    internal const int LgLgRadix = 5;
    internal const int ShiftMask = 31;
    internal const ulong ULongMask = 4294967295;
    internal const long LongMask = 4294967295;
    internal const uint MsbMask = 2147483648;
    internal const uint ByteMask = 255;
    private int length;
    private uint[] digits;
    private bool isNegative;

    public BigInteger(bool isNegative, uint value)
    {
      this.isNegative = isNegative;
      if (value == 0U)
      {
        this.length = 0;
        this.digits = BigInteger.zeroDigits;
      }
      else
      {
        this.digits = new uint[1];
        this.length = 1;
        this.digits[0] = value;
      }
    }

    public BigInteger(int value)
    {
      if (value == 0)
      {
        this.isNegative = false;
        this.length = 0;
        this.digits = BigInteger.zeroDigits;
      }
      else
      {
        this.digits = new uint[1];
        this.length = 1;
        this.isNegative = value < 0;
        if (this.isNegative)
          this.digits[0] = (uint) -value;
        else
          this.digits[0] = (uint) value;
      }
    }

    public BigInteger(bool isNegative, ulong value)
    {
      this.isNegative = isNegative;
      if (value == 0UL)
      {
        this.length = 0;
        this.digits = BigInteger.zeroDigits;
      }
      else
      {
        this.digits = new uint[2];
        this.length = 2;
        this.digits[0] = (uint) (value & (ulong) uint.MaxValue);
        this.digits[1] = (uint) (value >> 32 & (ulong) uint.MaxValue);
        this.method_2();
      }
    }

    public BigInteger(long value)
    {
      if (value == 0L)
      {
        this.isNegative = false;
        this.length = 0;
        this.digits = BigInteger.zeroDigits;
      }
      else
      {
        this.digits = new uint[2];
        this.length = 2;
        this.isNegative = value < 0L;
        ulong num = this.isNegative ? (ulong) -value : (ulong) value;
        this.digits[0] = (uint) (num & (ulong) uint.MaxValue);
        this.digits[1] = (uint) (num >> 32 & (ulong) uint.MaxValue);
        this.method_2();
      }
    }

    [DebuggerStepThrough]
    internal unsafe BigInteger(bool isNegative, int length, uint[] digits)
    {
       this = new BigInteger();
      this.isNegative = isNegative;
      this.length = length;
      this.digits = digits;
    }

    static BigInteger()
    {
      for (int index1 = 0; index1 < 256; ++index1)
      {
        byte num1 = byte.MaxValue;
        byte num2 = byte.MaxValue;
        for (byte index2 = 0; index2 < (byte) 8; ++index2)
        {
          if ((index1 >> (int) index2 & 1) != 0)
          {
            num1 = index2;
            break;
          }
        }
        for (byte index2 = 7; index2 <= (byte) 7; --index2)
        {
          if ((index1 >> (int) index2 & 1) != 0)
          {
            num2 = index2;
            break;
          }
        }
        BigInteger.byteToLsOneBit[index1] = num1;
        BigInteger.byteToMsOneBit[index1] = num2;
      }
    }

    public bool IsNegative
    {
      get
      {
        return this.isNegative;
      }
    }

    public bool IsPositive
    {
      get
      {
        if (!this.isNegative)
          return this.length > 0;
        return false;
      }
    }

    public int Sign
    {
      get
      {
        if (this.isNegative)
          return -1;
        return this.length == 0 ? 0 : 1;
      }
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

    public bool IsEven
    {
      get
      {
        if (this.length <= 0)
          return true;
        return ((int) this.digits[0] & 1) == 0;
      }
    }

    public bool IsOdd
    {
      get
      {
        if (this.length <= 0)
          return false;
        return ((int) this.digits[0] & 1) != 0;
      }
    }

    public BigInteger Abs()
    {
      if (this.IsNaN)
        return BigInteger.NaN;
      return new BigInteger(false, this.length, this.digits);
    }

    public static BigInteger operator +(BigInteger a, BigInteger b)
    {
      if (a.IsNaN || b.IsNaN)
        return BigInteger.NaN;
      BigInteger bigInteger;
      if (a.isNegative == b.isNegative)
      {
        bigInteger = a.method_3(b);
        bigInteger.isNegative = a.isNegative && bigInteger.length > 0;
      }
      else if (a.CompareMagnitude(b) < 0)
      {
        bigInteger = b.method_4(a);
        bigInteger.isNegative = b.isNegative && bigInteger.length > 0;
      }
      else
      {
        bigInteger = a.method_4(b);
        bigInteger.isNegative = a.isNegative && bigInteger.length > 0;
      }
      return bigInteger;
    }

    public static BigInteger operator *(BigInteger a, BigInteger b)
    {
      if (a.IsNaN || b.IsNaN)
        return BigInteger.NaN;
      BigInteger result = new BigInteger(a.isNegative ^ b.isNegative, 0, new uint[a.length + b.length]);
      BigInteger.smethod_3(a, b, ref result);
      return result;
    }

    public static BigInteger operator /(BigInteger a, BigInteger b)
    {
      if (a.IsNaN || b.IsNaN || b.length == 0)
        return BigInteger.NaN;
      BigInteger quotient;
      BigInteger remainder;
      BigInteger.smethod_4(a, b, out quotient, out remainder);
      return quotient;
    }

    public static BigInteger operator -(BigInteger a, BigInteger b)
    {
      if (a.IsNaN || b.IsNaN)
        return BigInteger.NaN;
      BigInteger bigInteger;
      if (a.isNegative != b.isNegative)
      {
        bigInteger = a.method_3(b);
        bigInteger.isNegative = a.isNegative && bigInteger.length > 0;
      }
      else if (a.CompareMagnitude(b) < 0)
      {
        bigInteger = b.method_4(a);
        bigInteger.isNegative = !b.isNegative && bigInteger.length > 0;
      }
      else
      {
        bigInteger = a.method_4(b);
        bigInteger.isNegative = a.isNegative && bigInteger.length > 0;
      }
      return bigInteger;
    }

    public static BigInteger operator -(BigInteger value)
    {
      if (value.IsNaN)
        return BigInteger.NaN;
      return new BigInteger(value.length != 0 && !value.isNegative, value.length, value.digits);
    }

    public BigInteger LeftShift()
    {
      if (this.IsNaN)
        return BigInteger.NaN;
      if (this.length == 0)
        return this;
      uint[] digits = new uint[this.length + 1];
      uint num1 = 0;
      int num2 = 0;
      int index1 = 0;
      for (uint index2 = 0; (long) index2 != (long) this.length; ++index2)
      {
        uint digit = this.digits[num2++];
        uint num3 = digit << 1 | num1;
        digits[index1++] = num3;
        num1 = digit >> 31;
      }
      digits[index1] = num1;
      return new BigInteger(this.isNegative, num1 == 0U ? this.length : this.length + 1, digits);
    }

    public BigInteger LeftShift(int shift)
    {
      if (this.IsNaN)
        return BigInteger.NaN;
      if (this.length == 0)
        return this;
      int shift1 = shift >> 5;
      byte num1 = (byte) (shift & 31);
      if (num1 == (byte) 0)
        return this.LeftShiftDigits(shift1);
      byte num2 = (byte) (32U - (uint) num1);
      int num3 = this.length + shift1;
      int length1 = num3 + 1;
      uint[] digits1 = new uint[length1];
      int num4 = this.length - 1;
      int num5 = num3;
      uint[] digits2 = this.digits;
      int index1 = num4;
      int num6 = index1 - 1;
      uint num7 = digits2[index1];
      uint num8 = num7 >> (int) num2;
      uint[] numArray1 = digits1;
      int index2 = num5;
      int index3 = index2 - 1;
      int num9 = (int) num8;
      numArray1[index2] = (uint) num9;
      int length2 = num8 == 0U ? num3 : length1;
      for (; index3 > shift1; --index3)
      {
        uint digit = this.digits[num6--];
        uint num10 = num7 << (int) num1 | digit >> (int) num2;
        digits1[index3] = num10;
        num7 = digit;
      }
      uint num11 = num7 << (int) num1;
      uint[] numArray2 = digits1;
      int index4 = index3;
      int index5 = index4 - 1;
      int num12 = (int) num11;
      numArray2[index4] = (uint) num12;
      for (; index5 >= 0; --index5)
        digits1[index5] = 0U;
      return new BigInteger(this.isNegative, length2, digits1);
    }

    public BigInteger RightShift()
    {
      if (this.IsNaN)
        return BigInteger.NaN;
      if (this.length == 0)
        return this;
      int length = this.length;
      uint[] digits1 = new uint[length];
      int num1 = this.length - 1;
      int num2 = this.length - 1;
      uint num3 = 1;
      uint[] digits2 = this.digits;
      int index1 = num1;
      int num4 = index1 - 1;
      uint num5 = digits2[index1];
      uint num6 = num5 >> 1;
      if (num6 == 0U)
        --length;
      uint[] numArray = digits1;
      int index2 = num2;
      int num7 = index2 - 1;
      int num8 = (int) num6;
      numArray[index2] = (uint) num8;
      uint num9 = num5;
      for (; (long) num3 != (long) this.length; ++num3)
      {
        uint digit = this.digits[num4--];
        uint num10 = num9 << 31 | digit >> 1;
        digits1[num7--] = num10;
        num9 = digit;
      }
      return new BigInteger(this.isNegative && length > 0, length, digits1);
    }

    public BigInteger RightShift(int shift)
    {
      if (this.IsNaN)
        return BigInteger.NaN;
      if (this.length == 0)
        return this;
      int shift1 = shift >> 5;
      if (shift1 >= this.length)
        return BigInteger.Zero;
      int num1 = shift & 31;
      if (num1 == 0)
        return this.RightShiftDigits(shift1);
      int num2 = 32 - num1;
      int index1 = shift1;
      int length1 = this.length - shift1;
      uint[] digits = new uint[length1];
      uint num3 = this.digits[index1];
      int length2 = this.length;
      int index2 = 0;
      int index3 = index1 + 1;
      while (index3 < length2)
      {
        uint digit = this.digits[index3];
        uint num4 = num3 >> num1 | digit << num2;
        digits[index2] = num4;
        num3 = digit;
        ++index3;
        ++index2;
      }
      uint num5 = num3 >> num1;
      digits[index2] = num5;
      int length3 = digits[length1 - 1] == 0U ? length1 - 1 : length1;
      return new BigInteger(this.isNegative && length3 > 0, length3, digits);
    }

    public BigInteger RightShiftRemainder(int shift)
    {
      if (this.IsNaN)
        return BigInteger.NaN;
      if (this.length == 0 || shift == 0)
        return BigInteger.Zero;
      int num1 = shift >> 5;
      if (num1 >= this.length)
        return this;
      int num2 = shift & 31;
      int length = num1 + (num2 != 0 ? 1 : 0);
      uint[] digits = new uint[length];
      int index1 = 0;
      uint num3 = 0;
      for (uint index2 = 0; (long) index2 != (long) num1; ++index2)
        digits[ num3++] = this.digits[index1++];
      if (num2 != 0)
        digits[num3] = this.digits[index1] & uint.MaxValue >> (int) (byte) (32 - num2);
      BigInteger bigInteger = new BigInteger(this.isNegative, length, digits);
      bigInteger.method_2();
      return bigInteger;
    }

    public BigInteger LeftShiftDigits(int shift)
    {
      if (this.IsNaN)
        return BigInteger.NaN;
      if (shift == 0)
        return this;
      int length = this.length + shift;
      uint[] digits = new uint[length];
      int num1 = this.length - 1;
      int num2 = length - 1;
      while (num2 >= shift)
        digits[num2--] = this.digits[num1--];
      while (num2 >= 0)
        digits[num2--] = 0U;
      return new BigInteger(this.isNegative, length, digits);
    }

    public BigInteger RightShiftDigits(int shift)
    {
      if (this.IsNaN)
        return BigInteger.NaN;
      if (shift == 0)
        return this;
      if (shift >= this.length)
        return BigInteger.Zero;
      int length = this.length - shift;
      uint[] digits = new uint[length];
      int num1 = shift;
      int num2 = 0;
      for (uint index = 0; (long) index != (long) length; ++index)
        digits[num2++] = this.digits[num1++];
      return new BigInteger(this.isNegative && length > 0, length, digits);
    }

    public int GetLsOneBitIndex()
    {
      if (this.IsNaN)
        return -1;
      return BigInteger.smethod_0(this.digits, this.length);
    }

    public static BigInteger GetGcd(BigInteger a, BigInteger b)
    {
      return BigInteger.GetGcdBinary(a, b);
    }

    public static BigInteger GetGcdBinaryOriginal(BigInteger a, BigInteger b)
    {
      if (a.IsNaN || b.IsNaN)
        return BigInteger.NaN;
      if (a.length == 0 && b.length == 0)
        return BigInteger.Zero;
      if (a.length == 0)
      {
        b.isNegative = false;
        return b;
      }
      if (b.length == 0)
      {
        a.isNegative = false;
        return a;
      }
      int lsOneBitIndex1 = a.GetLsOneBitIndex();
      int lsOneBitIndex2 = b.GetLsOneBitIndex();
      int shift1 = System.Math.Min(lsOneBitIndex1, lsOneBitIndex2);
      int capacity = System.Math.Max(a.length, b.length);
      MutableBigInteger a1 = new MutableBigInteger(capacity);
      MutableBigInteger.smethod_1(a, ref a1, lsOneBitIndex1);
      a1.IsNegative = false;
      MutableBigInteger b1 = new MutableBigInteger(capacity);
      MutableBigInteger.smethod_1(b, ref b1, lsOneBitIndex2);
      b1.IsNegative = false;
      MutableBigInteger mutableBigInteger = new MutableBigInteger(capacity);
      while (true)
      {
        MutableBigInteger.smethod_4(a1, b1, ref mutableBigInteger);
        if (mutableBigInteger.Length != 0)
        {
          int shift2 = mutableBigInteger.method_2();
          mutableBigInteger.method_1(shift2);
          if (mutableBigInteger.IsNegative)
          {
            mutableBigInteger.IsNegative = false;
            MathUtil.Swap<MutableBigInteger>(ref b1, ref mutableBigInteger);
          }
          else
            MathUtil.Swap<MutableBigInteger>(ref a1, ref mutableBigInteger);
        }
        else
          break;
      }
      a1.method_0(shift1);
      return new BigInteger(false, a1.Length, a1.Digits);
    }

    public static BigInteger GetGcdBinary(BigInteger a, BigInteger b)
    {
      if (a.IsNaN || b.IsNaN)
        return BigInteger.NaN;
      if (a.length == 0 && b.length == 0)
        return BigInteger.Zero;
      if (a.length == 0)
        return b;
      if (b.length == 0)
        return a;
      int lsOneBitIndex1 = a.GetLsOneBitIndex();
      int lsOneBitIndex2 = b.GetLsOneBitIndex();
      int shift = System.Math.Min(lsOneBitIndex1, lsOneBitIndex2);
      int capacity = System.Math.Max(a.length, b.length);
      MutableBigInteger a1 = new MutableBigInteger(capacity);
      MutableBigInteger.smethod_1(a, ref a1, lsOneBitIndex1);
      a1.IsNegative = false;
      MutableBigInteger b1 = new MutableBigInteger(capacity);
      MutableBigInteger.smethod_1(b, ref b1, lsOneBitIndex2);
      b1.IsNegative = false;
      MutableBigInteger mutableBigInteger = new MutableBigInteger(capacity);
      MutableBigInteger.smethod_5(a1, b1, ref mutableBigInteger);
      while (mutableBigInteger.Length > 0)
      {
        if (mutableBigInteger.IsNegative)
        {
          mutableBigInteger.IsNegative = false;
          MathUtil.Swap<MutableBigInteger>(ref b1, ref mutableBigInteger);
        }
        else
          MathUtil.Swap<MutableBigInteger>(ref a1, ref mutableBigInteger);
        MutableBigInteger.smethod_5(a1, b1, ref mutableBigInteger);
      }
      a1.method_0(shift);
      return new BigInteger(false, a1.Length, a1.Digits);
    }

    public static BigInteger GetGcdEuclidian(BigInteger a, BigInteger b)
    {
      if (a.IsNaN || b.IsNaN)
        return BigInteger.NaN;
      a.isNegative = false;
      b.isNegative = false;
      BigInteger remainder;
      for (; b.length != 0; b = remainder)
      {
        BigInteger quotient;
        BigInteger.smethod_4(a, b, out quotient, out remainder);
        a = b;
      }
      return a;
    }

    public static BigInteger GetGcdLehmer(BigInteger a, BigInteger b)
    {
      if (a.IsNaN || b.IsNaN)
        return BigInteger.NaN;
      if (a.length == 0 && b.length == 0)
        return BigInteger.Zero;
      if (a.length == 0)
        return b;
      if (b.length == 0)
        return a;
      a.isNegative = false;
      b.isNegative = false;
      if (a < b)
        MathUtil.Swap<BigInteger>(ref a, ref b);
      while (b.length >= 2)
      {
        BigInteger remainder1;
        for (; a.length > b.length && b.length != 0; b = remainder1)
        {
          BigInteger quotient;
          BigInteger.smethod_4(a, b, out quotient, out remainder1);
          a = b;
        }
        if (b.length == 0)
          return a;
        long num1 = (long) a.digits[a.length - 1];
        long num2 = (long) b.digits[b.length - 1];
        long num3 = 1;
        long num4 = 0;
        long num5 = 0;
        long num6 = 1;
        long num7 = (num1 + 1L) / (num2 + 0L);
        long num8;
        for (long index = (num1 + 0L) / (num2 + 1L); num7 == index; index = (num1 + num4) / num8)
        {
          long num9 = num3 - num7 * num5;
          num3 = num5;
          num5 = num9;
          long num10 = num4 - num7 * num6;
          num4 = num6;
          num6 = num10;
          long num11 = num1 - num7 * num2;
          num1 = num2;
          num2 = num11;
          long num12 = num2 + num5;
          if (num12 != 0L)
          {
            num8 = num2 + num6;
            if (num8 != 0L)
              num7 = (num1 + num3) / num12;
            else
              break;
          }
          else
            break;
        }
        if (num4 == 0L)
        {
          BigInteger quotient;
          BigInteger remainder2;
          BigInteger.smethod_4(a, b, out quotient, out remainder2);
          a = b;
          b = remainder2;
        }
        else
        {
          BigInteger bigInteger1 = new BigInteger(num3) * a + new BigInteger(num4) * b;
          BigInteger bigInteger2 = new BigInteger(num5) * a + new BigInteger(num6) * b;
          a = bigInteger1;
          b = bigInteger2;
        }
      }
      BigInteger remainder;
      for (; b.length != 0; b = remainder)
      {
        BigInteger quotient;
        BigInteger.smethod_4(a, b, out quotient, out remainder);
        a = b;
      }
      return a;
    }

    public static bool operator ==(BigInteger a, BigInteger b)
    {
      bool isNaN1 = a.IsNaN;
      bool isNaN2 = b.IsNaN;
      if (isNaN1 && isNaN2)
        return true;
      if (isNaN1 || isNaN2)
        return false;
      bool flag = false;
      if (a.isNegative == b.isNegative && a.length == b.length)
      {
        flag = true;
        int index1 = 0;
        int index2 = 0;
        for (uint index3 = 0; (long) index3 != (long) a.length; ++index3)
        {
          if ((int) a.digits[index1] == (int) b.digits[index2])
          {
            ++index1;
            ++index2;
          }
          else
          {
            flag = false;
            break;
          }
        }
      }
      return flag;
    }

    public static bool operator !=(BigInteger a, BigInteger b)
    {
      return !(a == b);
    }

    public static bool operator >(BigInteger a, BigInteger b)
    {
      return a.CompareTo(b) > 0;
    }

    public static bool operator <(BigInteger a, BigInteger b)
    {
      return a.CompareTo(b) < 0;
    }

    public static bool operator >=(BigInteger a, BigInteger b)
    {
      return a.CompareTo(b) >= 0;
    }

    public static bool operator <=(BigInteger a, BigInteger b)
    {
      return a.CompareTo(b) <= 0;
    }

    public static explicit operator double(BigInteger value)
    {
      if (value.length == 0)
        return 0.0;
      if (value.IsNaN)
        return double.NaN;
      return value.method_1();
    }

    public static explicit operator BigInteger(long value)
    {
      return new BigInteger(value);
    }

    public override bool Equals(object obj)
    {
      if (!(obj is BigInteger))
        return false;
      return this == (BigInteger) obj;
    }

    public override int GetHashCode()
    {
      return (this.length >= 0 ? (this.length != 0 ? this.digits[0] : 0U) : 3233857728U).GetHashCode();
    }

    public override string ToString()
    {
      return this.ToString(10);
    }

    public string ToString(int radix)
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
        BigInteger quotient = this;
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

    internal uint[] Digits
    {
      get
      {
        return this.digits;
      }
    }

    internal int Length
    {
      get
      {
        return this.length;
      }
    }

    internal static int smethod_0(uint[] digits, int length)
    {
      if (length == 0)
        return -1;
      int num1 = -1;
      for (int index = 0; index < length; ++index)
      {
        uint digit = digits[index];
        if (digit != 0U)
        {
          byte num2 = BigInteger.byteToLsOneBit[ (digit & (uint) byte.MaxValue)];
          if (num2 >= byte.MaxValue)
          {
            byte num3 = BigInteger.byteToLsOneBit[ (digit >> 8 & (uint) byte.MaxValue)];
            if (num3 >= byte.MaxValue)
            {
              byte num4 = BigInteger.byteToLsOneBit[ (digit >> 16 & (uint) byte.MaxValue)];
              if (num4 >= byte.MaxValue)
              {
                byte num5 = BigInteger.byteToLsOneBit[ (digit >> 24 & (uint) byte.MaxValue)];
                if (num5 < byte.MaxValue)
                {
                  num1 = (index << 5) + (int) num5 + 24;
                  break;
                }
              }
              else
              {
                num1 = (index << 5) + (int) num4 + 16;
                break;
              }
            }
            else
            {
              num1 = (index << 5) + (int) num3 + 8;
              break;
            }
          }
          else
          {
            num1 = (index << 5) + (int) num2;
            break;
          }
        }
      }
      return num1;
    }

    internal int method_0()
    {
      if (this.IsNaN)
        return -1;
      return BigInteger.smethod_1(this.digits, this.length);
    }

    internal static int smethod_1(uint[] digits, int length)
    {
      if (length == 0)
        return -1;
      uint digit = digits[length - 1];
      byte num1 = BigInteger.byteToMsOneBit[ (digit >> 24 & (uint) byte.MaxValue)];
      int num2;
      if (num1 < byte.MaxValue)
      {
        num2 = (int) num1 + 24;
      }
      else
      {
        byte num3 = BigInteger.byteToMsOneBit[ (digit >> 16 & (uint) byte.MaxValue)];
        if (num3 < byte.MaxValue)
        {
          num2 = (int) num3 + 16;
        }
        else
        {
          byte num4 = BigInteger.byteToMsOneBit[( digit >> 8 & (uint) byte.MaxValue)];
          num2 = num4 >= byte.MaxValue ? (int) BigInteger.byteToMsOneBit[ (digit & (uint) byte.MaxValue)] : (int) num4 + 8;
        }
      }
      return num2;
    }

    internal static BigInteger smethod_2(
      BigInteger a,
      BigInteger b,
      bool resultIsNegative)
    {
      BigInteger result = new BigInteger(resultIsNegative, 0, new uint[a.length + b.length]);
      BigInteger.smethod_3(a, b, ref result);
      return result;
    }

    internal static void smethod_3(BigInteger a, BigInteger b, ref BigInteger result)
    {
      if (a.length != 0 && b.length != 0)
      {
        for (int index1 = 0; index1 != a.length; ++index1)
        {
          int index2 = index1;
          uint digit = a.digits[index2];
          if (digit != 0U)
          {
            uint num1 = 0;
            int index3 = index1;
            int num2 = 0;
            for (uint index4 = 0; (long) index4 != (long) b.length; ++index4)
            {
              ulong num3 = (ulong) result.digits[index3] + (ulong) digit * (ulong) b.digits[num2++] + (ulong) num1;
              result.digits[index3++] = (uint) (num3 & (ulong) uint.MaxValue);
              num1 = (uint) (num3 >> 32);
            }
            result.digits[index3] = num1;
          }
        }
        result.length = a.length + b.length;
        result.method_2();
      }
      else
      {
        result.length = 0;
        result.isNegative = false;
      }
    }

    internal static void smethod_4(
      BigInteger a,
      BigInteger b,
      out BigInteger quotient,
      out BigInteger remainder)
    {
      if (a.length != 0 && a.length >= b.length)
      {
        if (b.length == 0)
        {
          quotient = BigInteger.NaN;
          remainder = BigInteger.NaN;
        }
        else
        {
          int length1 = b.length;
          int length2 = a.length - b.length + 1;
          quotient = new BigInteger(a.isNegative ^ b.isNegative, length2, new uint[length2]);
          int num1 = 0;
          uint digit = b.digits[b.length - 1];
          if (digit == 0U)
            throw new Exception("b.length is incorrect.");
          while (((int) digit & int.MinValue) == 0)
          {
            digit <<= 1;
            ++num1;
          }
          int num2 = 32 - num1;
          ulong num3 = (ulong) (digit | (b.length <= 1 || num2 >= 32 ? 0U : b.digits[b.length - 2] >> num2));
          ulong num4 = (ulong) (uint) ((b.length > 1 ? (int) b.digits[b.length - 2] << num1 : 0) | (b.length <= 2 || num2 >= 32 ? 0 : (int) (b.digits[b.length - 3] >> num2)));
          int num5 = a.length - b.length;
          int length3 = a.length + 1;
          uint[] digits = new uint[length3];
          int index1 = 0;
          int index2 = 0;
          while (index1 < a.length)
          {
            digits[index1] = a.digits[index2];
            ++index1;
            ++index2;
          }
          BigInteger bigInteger = new BigInteger(a.isNegative, length3, digits);
          for (int index3 = num5; index3 >= 0; --index3)
          {
            int index4 = index3 + length1;
            int index5 = index4 - 1;
            int index6 = index5 - 1;
            int index7 = index6 - 1;
            ulong num6;
            ulong num7;
            if (num2 < 32)
            {
              num6 = (ulong) ((long) bigInteger.digits[index4] << num1 + 32 | (long) bigInteger.digits[index5] << num1 | (index6 >= 0 ? (long) ((ulong) bigInteger.digits[index6] >> num2) : 0L));
              num7 = (ulong) (((index6 >= 0 ? (long) bigInteger.digits[index6] << num1 : 0L) | (index7 >= 0 ? (long) ((ulong) bigInteger.digits[index7] >> num2) : 0L)) & (long) uint.MaxValue);
            }
            else
            {
              num6 = (ulong) bigInteger.digits[index4] << 32 | (ulong) bigInteger.digits[index5];
              num7 = index6 >= 0 ? (ulong) bigInteger.digits[index6] : 0UL;
            }
            ulong num8 = num6 / num3;
            ulong num9 = num6 % num3;
            if (num8 >= 4294967296UL || num8 * num4 > (num9 << 32 | num7))
            {
              --num8;
              ulong num10 = num9 + num3;
              if (num10 < 4294967296UL && (num8 >= 4294967296UL || num8 * num4 > (num10 << 32 | num7)))
                --num8;
            }
            ulong num11 = 0;
            long num12 = 0;
            for (uint index8 = 0; (long) index8 < (long) length1; ++index8)
            {
              ulong num10 = num8 * (ulong) b.digits[index8] + num11;
              ulong num13 = num10 & (ulong) uint.MaxValue;
              long num14 = (long) bigInteger.digits[(long) index3 + (long) index8] - (long) num13 - num12;
              bigInteger.digits[(long) index3 + (long) index8] = (uint) num14;
              num12 = (long) ((ulong) num14 >> 63);
              num11 = num10 >> 32;
            }
            int num15 = length1;
            ulong num16 = num11 & (ulong) uint.MaxValue;
            long num17 = (long) bigInteger.digits[index3 + num15] - (long) num16 - num12;
            bigInteger.digits[index3 + num15] = (uint) num17;
            if ((ulong) num17 >> 63 != 0UL)
            {
              --num8;
              ulong num10 = 0;
              for (uint index8 = 0; (long) index8 < (long) length1; ++index8)
              {
                ulong num13 = (ulong) bigInteger.digits[(long) index3 + (long) index8] + (ulong) b.digits[ index8] + num10;
                bigInteger.digits[(long) index3 + (long) index8] = (uint) num13;
                num10 = num13 >> 32;
              }
              int num14 = length1;
              ulong num18 = (ulong) bigInteger.digits[index3 + num14] + num10;
              bigInteger.digits[index3 + num14] = (uint) num18;
            }
            quotient.digits[index3] = (uint) num8;
          }
          quotient.method_2();
          bigInteger.length = b.length;
          bigInteger.method_2();
          remainder = bigInteger;
        }
      }
      else
      {
        quotient = BigInteger.Zero;
        remainder = a;
      }
    }

    internal static void smethod_5(
      uint[] digits,
      int length,
      uint[] resultDigits,
      int shift,
      out int resultLength)
    {
      if (length == 0)
      {
        resultLength = 0;
      }
      else
      {
        int shift1 = shift >> 5;
        byte num1 = (byte) (shift & 31);
        if (num1 == (byte) 0)
        {
          BigInteger.smethod_7(digits, length, resultDigits, shift1);
          resultLength = length + shift1;
        }
        else
        {
          byte num2 = (byte) (32U - (uint) num1);
          int num3 = length + shift1;
          int num4 = num3 + 1;
          int num5 = length - 1;
          int num6 = num3;
          uint[] numArray1 = digits;
          int index1 = num5;
          int num7 = index1 - 1;
          uint num8 = numArray1[index1];
          uint num9 = num8 >> (int) num2;
          uint[] numArray2 = resultDigits;
          int index2 = num6;
          int index3 = index2 - 1;
          int num10 = (int) num9;
          numArray2[index2] = (uint) num10;
          resultLength = num9 == 0U ? num3 : num4;
          for (; index3 > shift1; --index3)
          {
            uint digit = digits[num7--];
            uint num11 = num8 << (int) num1 | digit >> (int) num2;
            resultDigits[index3] = num11;
            num8 = digit;
          }
          uint num12 = num8 << (int) num1;
          uint[] numArray3 = resultDigits;
          int index4 = index3;
          int index5 = index4 - 1;
          int num13 = (int) num12;
          numArray3[index4] = (uint) num13;
          for (; index5 >= 0; --index5)
            resultDigits[index5] = 0U;
        }
      }
    }

    internal static void smethod_6(uint[] digits, int length, int shift, out int resultLength)
    {
      if (length == 0)
      {
        resultLength = 0;
      }
      else
      {
        int shift1 = shift >> 5;
        byte num1 = (byte) (shift & 31);
        if (num1 == (byte) 0)
        {
          BigInteger.smethod_7(digits, length, digits, shift1);
          resultLength = length + shift1;
        }
        else
        {
          byte num2 = (byte) (32U - (uint) num1);
          int num3 = length + shift1;
          int num4 = num3 + 1;
          int num5 = length - 1;
          int index1 = num3;
          uint[] numArray1 = digits;
          int index2 = num5;
          int num6 = index2 - 1;
          uint num7 = numArray1[index2];
          uint num8 = num7 >> (int) num2;
          if (num8 == 0U)
          {
            resultLength = num3;
          }
          else
          {
            digits[index1] = num8;
            resultLength = num4;
          }
          int index3;
          for (index3 = index1 - 1; index3 > shift1; --index3)
          {
            uint digit = digits[num6--];
            uint num9 = num7 << (int) num1 | digit >> (int) num2;
            digits[index3] = num9;
            num7 = digit;
          }
          uint num10 = num7 << (int) num1;
          uint[] numArray2 = digits;
          int index4 = index3;
          int index5 = index4 - 1;
          int num11 = (int) num10;
          numArray2[index4] = (uint) num11;
          for (; index5 >= 0; --index5)
            digits[index5] = 0U;
        }
      }
    }

    internal static void smethod_7(uint[] digits, int length, uint[] resultDigits, int shift)
    {
      int num1 = length + shift;
      int num2 = length - 1;
      int num3 = num1 - 1;
      while (num3 >= shift)
        resultDigits[num3--] = digits[num2--];
      while (num3 >= 0)
        resultDigits[num3--] = 0U;
    }

    internal static void smethod_8(
      uint[] digits,
      int length,
      uint[] resultDigits,
      int shift,
      out int resultLength)
    {
      int shift1 = shift >> 5;
      if (shift1 >= length)
      {
        resultLength = 0;
      }
      else
      {
        int num1 = shift & 31;
        if (num1 == 0)
        {
          if (shift1 > length)
          {
            resultLength = 0;
          }
          else
          {
            BigInteger.smethod_10(digits, length, resultDigits, shift1);
            resultLength = length - shift1;
          }
        }
        else
        {
          int num2 = 32 - num1;
          int index1 = shift1;
          uint num3 = digits[index1];
          int index2 = 0;
          int index3 = index1 + 1;
          while (index3 < length)
          {
            uint digit = digits[index3];
            uint num4 = num3 >> num1 | digit << num2;
            resultDigits[index2] = num4;
            num3 = digit;
            ++index3;
            ++index2;
          }
          uint num5 = num3 >> num1;
          resultDigits[index2] = num5;
          resultLength = length - shift1;
          if (resultDigits[resultLength - 1] != 0U)
            return;
          --resultLength;
        }
      }
    }

    internal static void smethod_9(uint[] digits, int length, int shift, out int resultLength)
    {
      int shift1 = shift >> 5;
      if (shift1 >= length)
      {
        resultLength = 0;
      }
      else
      {
        int num1 = shift & 31;
        if (num1 == 0)
        {
          if (shift1 > length)
          {
            resultLength = 0;
          }
          else
          {
            BigInteger.smethod_10(digits, length, digits, shift1);
            resultLength = length - shift1;
          }
        }
        else
        {
          int num2 = 32 - num1;
          int index1 = shift1;
          uint num3 = digits[index1];
          int index2 = 0;
          int index3 = index1 + 1;
          while (index3 < length)
          {
            uint digit = digits[index3];
            uint num4 = num3 >> num1 | digit << num2;
            digits[index2] = num4;
            num3 = digit;
            ++index3;
            ++index2;
          }
          uint num5 = num3 >> num1;
          digits[index2] = num5;
          resultLength = length - shift1;
          if (digits[resultLength - 1] != 0U)
            return;
          --resultLength;
        }
      }
    }

    internal static void smethod_10(uint[] digits, int length, uint[] resultDigits, int shift)
    {
      if (shift >= length)
        return;
      int num1 = length - shift;
      int num2 = shift;
      int num3 = 0;
      for (uint index = 0; (long) index != (long) num1; ++index)
        resultDigits[num3++] = digits[num2++];
    }

    internal static void smethod_11(
      uint[] aDigits,
      int aLength,
      uint[] bDigits,
      int bLength,
      uint[] resultDigits,
      out int resultLength)
    {
      int num1 = 0;
      int num2 = 0;
      int num3;
      uint[] numArray1;
      int num4;
      uint[] numArray2;
      if (aLength < bLength)
      {
        num3 = aLength;
        numArray1 = aDigits;
        num4 = bLength;
        numArray2 = bDigits;
      }
      else
      {
        num3 = bLength;
        numArray1 = bDigits;
        num4 = aLength;
        numArray2 = aDigits;
      }
      uint num5 = 0;
      uint num6 = 0;
      uint num7;
      for (num7 = 0U; (long) num7 != (long) num3; ++num7)
      {
        ulong num8 = (ulong) numArray1[num1++] + (ulong) numArray2[num2++] + (ulong) num5;
        resultDigits[ num6++] = (uint) (num8 & (ulong) uint.MaxValue);
        num5 = (uint) (num8 >> 32);
      }
      if (num3 != num4)
      {
        for (; (long) num7 != (long) num4; ++num7)
        {
          ulong num8 = (ulong) numArray2[num2++] + (ulong) num5;
          resultDigits[ num6++] = (uint) (num8 & (ulong) uint.MaxValue);
          num5 = (uint) (num8 >> 32);
        }
      }
      resultDigits[ num6] = num5;
      resultLength = num5 == 0U ? num4 : num4 + 1;
    }

    internal static void smethod_12(
      uint[] aDigits,
      int aLength,
      uint[] bDigits,
      int bLength,
      uint[] resultDigits)
    {
      int num1 = bLength;
      int num2 = aLength;
      long num3 = 0;
      int num4 = 0;
      int num5 = 0;
      int num6 = 0;
      uint num7;
      for (num7 = 0U; (long) num7 != (long) num1; ++num7)
      {
        long num8 = (long) aDigits[num4++] - (long) bDigits[num5++] - num3;
        resultDigits[num6++] = (uint) num8;
        num3 = (long) ((ulong) num8 >> 63);
      }
      for (; (long) num7 != (long) num2; ++num7)
      {
        long num8 = (long) aDigits[num4++] - num3;
        resultDigits[num6++] = (uint) num8;
        num3 = (long) ((ulong) num8 >> 63);
      }
    }

    internal static int smethod_13(
      uint[] aDigits,
      int aLength,
      uint[] bDigits,
      int bLength,
      uint[] resultDigits)
    {
      int num1 = bLength;
      int num2 = aLength;
      long num3 = 0;
      int num4 = 0;
      int num5 = 0;
      int num6 = 0;
      uint num7 = 0;
      int num8 = 0;
      uint num9 = 0;
      for (; (long) num7 != (long) num1; ++num7)
      {
        long num10 = (long) aDigits[num4++] - (long) bDigits[num5++] - num3;
        num3 = (long) ((ulong) num10 >> 63);
        num9 = (uint) num10;
        if (num9 != 0U)
        {
          byte num11 = BigInteger.byteToLsOneBit[ (num9 & (uint) byte.MaxValue)];
          if (num11 < byte.MaxValue)
          {
            num8 = ((int) num7 << 5) + (int) num11;
          }
          else
          {
            byte num12 = BigInteger.byteToLsOneBit[ (num9 >> 8 & (uint) byte.MaxValue)];
            if (num12 < byte.MaxValue)
            {
              num8 = ((int) num7 << 5) + (int) num12 + 8;
            }
            else
            {
              byte num13 = BigInteger.byteToLsOneBit[ (num9 >> 16 & (uint) byte.MaxValue)];
              if (num13 < byte.MaxValue)
              {
                num8 = ((int) num7 << 5) + (int) num13 + 16;
              }
              else
              {
                byte num14 = BigInteger.byteToLsOneBit[(num9 >> 24 & (uint) byte.MaxValue)];
                if (num14 < byte.MaxValue)
                  num8 = ((int) num7 << 5) + (int) num14 + 24;
              }
            }
          }
          ++num7;
          break;
        }
      }
      int num15 = num8 & 31;
      if (num15 == 0)
      {
        if ((long) (num7 - 1U) != (long) num1)
        {
          resultDigits[num6++] = num9;
          for (; (long) num7 != (long) num1; ++num7)
          {
            long num10 = (long) aDigits[num4++] - (long) bDigits[num5++] - num3;
            uint num11 = (uint) num10;
            resultDigits[num6++] = num11;
            num3 = (long) ((ulong) num10 >> 63);
          }
          for (; (long) num7 != (long) num2; ++num7)
          {
            long num10 = (long) aDigits[num4++] - num3;
            uint num11 = (uint) num10;
            resultDigits[num6++] = num11;
            num3 = (long) ((ulong) num10 >> 63);
          }
        }
      }
      else
      {
        int num10 = 32 - num15;
        uint num11 = num9;
        for (; (long) num7 != (long) num1; ++num7)
        {
          long num12 = (long) aDigits[num4++] - (long) bDigits[num5++] - num3;
          uint num13 = (uint) num12;
          uint num14 = num11 >> num15 | num13 << num10;
          resultDigits[num6++] = num14;
          num3 = (long) ((ulong) num12 >> 63);
          num11 = num13;
        }
        for (; (long) num7 != (long) num2; ++num7)
        {
          long num12 = (long) aDigits[num4++] - num3;
          uint num13 = (uint) num12;
          uint num14 = num11 >> num15 | num13 << num10;
          resultDigits[num6++] = num14;
          num3 = (long) ((ulong) num12 >> 63);
          num11 = num13;
        }
        if (num11 != 0U)
        {
          uint num12 = num11 >> num15;
          resultDigits[num6++] = num12;
        }
      }
      return num6;
    }

    internal double method_1()
    {
      if (this.length > 2)
      {
        int num1 = this.method_0() + 1;
        int num2 = 32 - num1;
        ulong num3 = (num2 != 0 ? (ulong) ((long) this.digits[this.length - 1] << num2 + 32 | (long) this.digits[this.length - 2] << num2) | (ulong) this.digits[this.length - 3] >> num1 : (ulong) this.digits[this.length - 1] << 32 | (ulong) this.digits[this.length - 2]) >> 11 & 4503599627370495UL;
        if (this.isNegative)
          num3 |= 9223372036854775808UL;
        ulong num4 = (ulong) (((long) this.length << 5) - 1L - (long) num2 + 1023L & 2047L);
        return BitConverter.ToDouble(BitConverter.GetBytes(num3 | num4 << 52), 0);
      }
      if (this.length > 1)
      {
        ulong num = (ulong) this.digits[0] | (ulong) this.digits[1] << 32;
        if (!this.isNegative)
          return (double) num;
        return -(double) num;
      }
      ulong digit = (ulong) this.digits[0];
      if (!this.isNegative)
        return (double) digit;
      return -(double) digit;
    }

    internal void method_2()
    {
      while (this.length > 0 && this.digits[this.length - 1] == 0U)
        --this.length;
      if (this.length != 0)
        return;
      this.isNegative = false;
    }

    private BigInteger method_3(BigInteger value)
    {
      uint[] numArray = new uint[System.Math.Max(this.length, value.length) + 1];
      int resultLength;
      BigInteger.smethod_11(this.digits, this.length, value.digits, value.length, numArray, out resultLength);
      return new BigInteger(false, resultLength, numArray);
    }

    private BigInteger method_4(BigInteger value)
    {
      uint[] numArray = new uint[System.Math.Max(this.length, value.length)];
      BigInteger.smethod_12(this.digits, this.length, value.digits, value.length, numArray);
      BigInteger bigInteger = new BigInteger(false, numArray.Length, numArray);
      bigInteger.method_2();
      return bigInteger;
    }

    private void method_5(uint capacity)
    {
      if (this.digits == null)
      {
        capacity += 16U - capacity % 8U;
        this.digits = new uint[ capacity];
      }
      else
      {
        if ((long) this.digits.Length >= (long) capacity)
          return;
        capacity += 16U - capacity % 8U;
        uint[] numArray = new uint[ capacity];
        for (uint index = 0; (long) index != (long) this.length; ++index)
          numArray[index] = this.digits[ index];
        this.digits = numArray;
      }
    }

    private void method_6(BigInteger from)
    {
      this.length = from.length;
      this.isNegative = from.isNegative;
      this.digits = from.digits;
    }

    private void method_7()
    {
      for (uint index = 0; (long) index < (long) this.length; ++index)
        this.digits[index] = 0U;
      this.length = 0;
      this.isNegative = false;
    }

    private void method_8(uint digit)
    {
      this.method_5(1U);
      this.digits[0] = digit;
      this.length = digit == 0U ? 0 : 1;
      this.isNegative = false;
    }

    public int CompareTo(BigInteger other)
    {
      return this.isNegative == other.isNegative ? (!this.isNegative ? this.CompareMagnitude(other) : -this.CompareMagnitude(other)) : (this.isNegative ? -1 : 1);
    }

    public int CompareMagnitude(BigInteger other)
    {
      return BigInteger.smethod_14(this.digits, this.length, other.digits, other.length);
    }

    internal static int smethod_14(uint[] aDigits, int aLength, uint[] bDigits, int bLength)
    {
      int num;
      if (aLength < bLength)
        num = -1;
      else if (aLength > bLength)
        num = 1;
      else if (aLength == 0)
      {
        num = 0;
      }
      else
      {
        num = 0;
        for (int index = aLength - 1; index >= 0; --index)
        {
          uint aDigit = aDigits[index];
          uint bDigit = bDigits[index];
          if (aDigit >= bDigit)
          {
            if (aDigit > bDigit)
            {
              num = 1;
              break;
            }
          }
          else
          {
            num = -1;
            break;
          }
        }
      }
      return num;
    }
  }
}
