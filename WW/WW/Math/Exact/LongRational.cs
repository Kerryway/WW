// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.LongRational
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Globalization;
using System.Text;

namespace WW.Math.Exact
{
  [Serializable]
  public struct LongRational : IComparable<LongRational>
  {
    public static readonly LongRational Zero = new LongRational(0L, 1L, false);
    public static readonly LongRational One = new LongRational(1L, 1L, false);
    public static readonly LongRational MinusOne = new LongRational(-1L, 1L, false);
    public static readonly LongRational Two = new LongRational(2L, 1L, false);
    public static readonly LongRational MinusTwo = new LongRational(-2L, 1L, false);
    public static readonly LongRational Three = new LongRational(3L, 1L, false);
    public static readonly LongRational MinusThree = new LongRational(-3L, 1L, false);
    public static readonly LongRational Half = new LongRational(1L, 2L, false);
    public static readonly LongRational NaN = new LongRational(0L, 0L, false);
    public static readonly LongRational PositiveInfinity = new LongRational(1L, 0L, false);
    public static readonly LongRational NegativeInfinity = new LongRational(-1L, 0L, false);
    private readonly long numerator;
    private readonly long denominator;

    public LongRational(int value)
    {
      this.numerator = (long) value;
      this.denominator = 1L;
    }

    public LongRational(uint value)
    {
      this.numerator = (long) value;
      this.denominator = 1L;
    }

    public LongRational(long numerator, long denominator)
    {
      this = new LongRational(numerator, denominator, true);
    }

    internal unsafe LongRational(long numerator, long denominator, bool normalize)
    {
      this = new LongRational();
      if (denominator < 0L)
        throw new ArgumentException("The denominator may not be negative.");
      if (normalize)
      {
        if (numerator == 0L)
        {
          this.denominator = 1L;
        }
        else
        {
          long gcd = LongRational.GetGcd(numerator, denominator);
          this.numerator = numerator / gcd;
          this.denominator = denominator / gcd;
        }
      }
      else
      {
        this.numerator = numerator;
        this.denominator = denominator;
      }
    }

    public long Numerator
    {
      get
      {
        return this.numerator;
      }
    }

    public long Denominator
    {
      get
      {
        return this.denominator;
      }
    }

    public bool IsNaN
    {
      get
      {
        return this == LongRational.NaN;
      }
    }

    public bool IsNegative
    {
      get
      {
        return this.numerator < 0L;
      }
    }

    public bool IsPositive
    {
      get
      {
        return this.numerator > 0L;
      }
    }

    public int Sign
    {
      get
      {
        return System.Math.Sign(this.numerator);
      }
    }

    public bool IsZero
    {
      get
      {
        return this.numerator == 0L;
      }
    }

    public static LongRational operator *(LongRational a, LongRational b)
    {
      if (a.IsNaN || b.IsNaN)
        return LongRational.NaN;
      if (a.numerator == 0L || b.numerator == 0L)
        return LongRational.Zero;
      if (a.denominator != 0L && b.denominator != 0L)
      {
        long gcd1 = LongRational.GetGcd(a.numerator, b.denominator);
        long gcd2 = LongRational.GetGcd(a.denominator, b.numerator);
        return new LongRational(a.numerator / gcd1 * (b.numerator / gcd2), a.denominator / gcd2 * (b.denominator / gcd1), false);
      }
      if (!(a.denominator < 0L ^ b.denominator < 0L))
        return LongRational.PositiveInfinity;
      return LongRational.NegativeInfinity;
    }

    public static LongRational operator /(LongRational a, LongRational b)
    {
      if (a.IsNaN || b.IsNaN || b.numerator == 0L)
        return LongRational.NaN;
      if (a.numerator == 0L)
        return LongRational.Zero;
      if (a.denominator == 0L)
      {
        if (b.denominator == 0L)
          return LongRational.NaN;
        return LongRational.PositiveInfinity;
      }
      if (b.denominator == 0L)
        return LongRational.Zero;
      long gcd1 = LongRational.GetGcd(a.numerator, b.numerator);
      long gcd2 = LongRational.GetGcd(a.denominator, b.denominator);
      return new LongRational(a.numerator / gcd1 * (b.denominator / gcd2) * (b.numerator < 0L ? -1L : 1L), System.Math.Abs(a.denominator / gcd2 * (b.numerator / gcd1)), false);
    }

    public static LongRational operator +(LongRational a, LongRational b)
    {
      if (a.IsNaN || b.IsNaN)
        return LongRational.NaN;
      if (a.numerator == 0L)
        return b;
      if (b.numerator == 0L)
        return a;
      if (a.denominator == 0L)
      {
        if (b.denominator == 0L)
          return LongRational.NaN;
        return a;
      }
      if (b.denominator == 0L)
        return b;
      long gcd1 = LongRational.GetGcd(a.denominator, b.denominator);
      if (gcd1 == 1L)
        return new LongRational(a.numerator * b.denominator + a.denominator * b.numerator, a.denominator * b.denominator, true);
      long num = a.denominator / gcd1;
      long a1 = a.numerator * (b.denominator / gcd1) + b.numerator * num;
      long gcd2 = LongRational.GetGcd(a1, gcd1);
      return new LongRational(a1 / gcd2, num * (b.denominator / gcd2), false);
    }

    public static LongRational operator -(LongRational a, LongRational b)
    {
      if (a.IsNaN || b.IsNaN)
        return LongRational.NaN;
      if (a.numerator == 0L)
        return -b;
      if (b.numerator == 0L)
        return a;
      if (a.denominator == 0L)
      {
        if (b.denominator == 0L)
          return LongRational.NaN;
        return a;
      }
      if (b.denominator == 0L)
        return -b;
      long gcd1 = LongRational.GetGcd(a.denominator, b.denominator);
      if (gcd1 == 1L)
        return new LongRational(a.numerator * b.denominator - a.denominator * b.numerator, a.denominator * b.denominator, true);
      long num = a.denominator / gcd1;
      long a1 = a.numerator * (b.denominator / gcd1) - b.numerator * num;
      if (a1 == 0L)
        return LongRational.Zero;
      long gcd2 = LongRational.GetGcd(a1, gcd1);
      return new LongRational(a1 / gcd2, num * (b.denominator / gcd2), false);
    }

    public static LongRational operator -(LongRational value)
    {
      if (value.IsNaN)
        return LongRational.NaN;
      return new LongRational(-value.numerator, value.denominator, false);
    }

    public static bool operator ==(LongRational a, LongRational b)
    {
      if (a.numerator == b.numerator)
        return a.denominator == b.denominator;
      return false;
    }

    public static bool operator !=(LongRational a, LongRational b)
    {
      return !(a == b);
    }

    public static bool operator >(LongRational a, LongRational b)
    {
      return a.CompareTo(b) > 0;
    }

    public static bool operator <(LongRational a, LongRational b)
    {
      return a.CompareTo(b) < 0;
    }

    public static bool operator >=(LongRational a, LongRational b)
    {
      return a.CompareTo(b) >= 0;
    }

    public static bool operator <=(LongRational a, LongRational b)
    {
      return a.CompareTo(b) <= 0;
    }

    public static explicit operator LongRational(double d)
    {
      if (double.IsNegativeInfinity(d))
        return LongRational.NegativeInfinity;
      if (double.IsPositiveInfinity(d))
        return LongRational.PositiveInfinity;
      if (double.IsNaN(d))
        return LongRational.NaN;
      if (System.Math.Abs(d) > 134217727.0)
        throw new ArgumentOutOfRangeException(nameof (d), "Number too large to represent as LongRational.");
      ulong uint64 = BitConverter.ToUInt64(BitConverter.GetBytes(d), 0);
      bool flag = ((long) uint64 & long.MinValue) != 0L;
      ulong digit1 = uint64 & 4503599627370495UL;
      int num1 = (int) ((long) (uint64 >> 52) & 2047L);
      LongRational longRational;
      if (num1 == 0 && digit1 == 0UL)
      {
        longRational = LongRational.Zero;
      }
      else
      {
        int num2 = num1 - 1075;
        long num3;
        if (num2 >= 0)
        {
          ulong num4 = (digit1 | 4503599627370496UL) << num2;
          long numerator = flag ? -(long) num4 : (long) num4;
          num3 = 1L;
          longRational = new LongRational(numerator, 1L, false);
        }
        else
        {
          ulong digit2;
          int num4;
          if (digit1 == 0UL)
          {
            digit2 = 1UL;
            num4 = num1 - 1023;
          }
          else
          {
            int num5 = LongRational.smethod_0(digit1);
            digit2 = (digit1 | 4503599627370496UL) >> num5;
            num4 = num2 + num5;
          }
          if (num4 >= 0)
          {
            ulong num5 = digit2 << num4;
            long numerator = flag ? -(long) num5 : (long) num5;
            num3 = 1L;
            longRational = new LongRational(numerator, 1L, false);
          }
          else
          {
            int num5 = LongRational.smethod_1(digit2);
            bool normalize = false;
            if (num5 > 30 || num4 < -30)
            {
              int num6 = System.Math.Max(num5 - 30, -num4 - 30);
              digit2 >>= num6;
              num4 += num6;
              if (num4 > 0)
                throw new ArgumentOutOfRangeException(nameof (d), "Number too large to represent as LongRational.");
              normalize = true;
            }
            if (num4 < -30)
              throw new ArgumentOutOfRangeException(nameof (d), "Number too small to represent as LongRational.");
            longRational = new LongRational(flag ? -(long) digit2 : (long) digit2, 1L << -num4, normalize);
          }
        }
      }
      return longRational;
    }

    public static explicit operator double(LongRational value)
    {
      if (value.IsNaN)
        return double.NaN;
      if (value.numerator == 0L)
        return 0.0;
      if (value.denominator != 0L)
        return (double) value.numerator / (double) value.denominator;
      return !value.IsNegative ? double.PositiveInfinity : double.NegativeInfinity;
    }

    public LongRational DivideByTwo()
    {
      if (this.IsNaN)
        return LongRational.NaN;
      if (this.denominator == 0L)
        return this;
      if ((this.numerator & 1L) == 0L)
        return new LongRational(this.numerator >> 1, this.denominator, false);
      return new LongRational(this.numerator, this.denominator << 1, false);
    }

    public LongRational MultiplyByTwo()
    {
      if (this.IsNaN)
        return LongRational.NaN;
      if (this.denominator == 0L)
        return this;
      if ((this.denominator & 1L) == 0L)
        return new LongRational(this.numerator, this.denominator >> 1, false);
      return new LongRational(this.numerator << 1, this.denominator, false);
    }

    public LongRational Square()
    {
      if (this.IsNaN)
        return LongRational.NaN;
      if (this.denominator == 0L)
        return this;
      return new LongRational(this.numerator * this.numerator, this.denominator * this.denominator, true);
    }

    public LongRational Abs()
    {
      if (this.numerator < 0L)
        return new LongRational(System.Math.Abs(this.numerator), this.denominator, false);
      return this;
    }

    public LongRational Invert()
    {
      return new LongRational((long) System.Math.Sign(this.numerator) * this.denominator, System.Math.Abs(this.numerator));
    }

    public LongRational Pow(int power)
    {
      if (power == 0)
        return LongRational.One;
      LongRational longRational1 = this;
      if (power < 0)
      {
        if (this == LongRational.Zero)
          return LongRational.NaN;
        longRational1 = longRational1.Invert();
        power = -power;
      }
      LongRational longRational2 = longRational1;
      for (int index = 1; index < power; ++index)
        longRational2 *= longRational1;
      return longRational2;
    }

    public static LongRational Create(long numerator, long denominator)
    {
      if (denominator < 0L)
        return new LongRational(-numerator, -denominator);
      return new LongRational(numerator, denominator);
    }

    public override string ToString()
    {
      if (this.IsNaN)
        return "NaN";
      return  this.ToString((IFormatProvider) CultureInfo.InvariantCulture);
    }

    public string ToString(IFormatProvider provider)
    {
      return  this.ToString(provider);
    }

    public string ToString(int radix, int precision)
    {
      if (radix > 16)
        throw new ArgumentException("Only radix up to 16 is supported.");
      if (this.IsNaN)
        return "NaN";
      if (this.IsZero)
        return "0";
      long result1;
      long num1 = System.Math.DivRem(this.numerator, this.denominator, out result1);
      StringBuilder stringBuilder = new StringBuilder();
      long b = (long) radix;
      if (num1 != 0L)
      {
        long a = num1;
        while (a != 0L)
        {
          long result2;
          a = System.Math.DivRem(a, b, out result2);
          stringBuilder.Insert(0, (char) (48L + result2));
        }
      }
      if (this.IsNegative)
        stringBuilder.Insert(0, "-");
      if (result1 != 0L)
      {
        if (num1 == 0L)
        {
          long numerator = b * result1;
          LongRational longRational = new LongRational(numerator, this.denominator);
          long digit1 = System.Math.DivRem(longRational.numerator, longRational.denominator, out result1);
          int num2 = 0;
          for (; digit1 == 0L; digit1 = System.Math.DivRem(longRational.numerator, longRational.denominator, out result1))
          {
            ++num2;
            numerator *= b;
            longRational = new LongRational(numerator, this.denominator);
          }
          if (num2 == 0)
            stringBuilder.Append("0.");
          stringBuilder.Append(LongRational.smethod_2(digit1));
          for (int index = 0; index < precision; ++index)
          {
            longRational = new LongRational(b * result1, longRational.denominator);
            long digit2 = System.Math.DivRem(longRational.numerator, longRational.denominator, out result1);
            if (index == 0 && num2 > 0)
              stringBuilder.Append('.');
            if (index == precision - 1 && result1 * 2L >= longRational.denominator)
              ++digit2;
            stringBuilder.Append(LongRational.smethod_2(digit2));
          }
          if (num2 > 0)
          {
            stringBuilder.Append("E-");
            stringBuilder.Append((num2 + 1).ToString());
          }
        }
        else
        {
          stringBuilder.Append('.');
          LongRational longRational = new LongRational(result1, this.denominator, false);
          for (int index = 0; index < precision; ++index)
          {
            longRational = new LongRational(b * result1, longRational.denominator);
            long digit = System.Math.DivRem(longRational.numerator, longRational.denominator, out result1);
            if (index == precision - 1 && result1 * 2L >= longRational.denominator)
              ++digit;
            stringBuilder.Append(LongRational.smethod_2(digit));
          }
        }
      }
      return stringBuilder.ToString();
    }

    public override int GetHashCode()
    {
      return this.numerator.GetHashCode() ^ this.denominator.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      if (!(obj is LongRational))
        return false;
      return this == (LongRational) obj;
    }

    private static int smethod_0(ulong digit)
    {
      if (digit == 0UL)
        return -1;
      int num1;
      if (((long) digit & 16777215L) != 0L)
      {
        byte num2 = BigInteger.byteToLsOneBit[checked ((ulong) (unchecked ((long) digit) & (long) byte.MaxValue))];
        if (num2 < byte.MaxValue)
        {
          num1 = (int) num2;
        }
        else
        {
          byte num3 = BigInteger.byteToLsOneBit[checked ((ulong) (unchecked ((long) (digit >> 8)) & (long) byte.MaxValue))];
          num1 = num3 >= byte.MaxValue ? (int) BigInteger.byteToLsOneBit[checked ((ulong) (unchecked ((long) (digit >> 16)) & (long) byte.MaxValue))] + 16 : (int) num3 + 8;
        }
      }
      else if (((long) digit & 1099494850560L) != 0L)
      {
        byte num2 = BigInteger.byteToLsOneBit[checked ((ulong) (unchecked ((long) (digit >> 24)) & (long) byte.MaxValue))];
        num1 = num2 >= byte.MaxValue ? (int) BigInteger.byteToLsOneBit[checked ((ulong) (unchecked ((long) (digit >> 32)) & (long) byte.MaxValue))] + 32 : (int) num2 + 24;
      }
      else
      {
        byte num2 = BigInteger.byteToLsOneBit[checked ((ulong) (unchecked ((long) (digit >> 40)) & (long) byte.MaxValue))];
        if (num2 < byte.MaxValue)
        {
          num1 = (int) num2 + 40;
        }
        else
        {
          byte num3 = BigInteger.byteToLsOneBit[checked ((ulong) (unchecked ((long) (digit >> 48)) & (long) byte.MaxValue))];
          num1 = num3 >= byte.MaxValue ? (int) BigInteger.byteToLsOneBit[checked ((ulong) (unchecked ((long) (digit >> 56)) & (long) byte.MaxValue))] + 56 : (int) num3 + 48;
        }
      }
      return num1;
    }

    internal static int smethod_1(ulong digit)
    {
      if (digit == 0UL)
        return -1;
      int num1;
      if (((long) digit & -1099511627776L) != 0L)
      {
        byte num2 = BigInteger.byteToMsOneBit[checked ((ulong) (unchecked ((long) (digit >> 56)) & (long) byte.MaxValue))];
        if (num2 < byte.MaxValue)
        {
          num1 = (int) num2 + 56;
        }
        else
        {
          byte num3 = BigInteger.byteToMsOneBit[checked ((ulong) (unchecked ((long) (digit >> 48)) & (long) byte.MaxValue))];
          num1 = num3 >= byte.MaxValue ? (int) BigInteger.byteToMsOneBit[checked ((ulong) (unchecked ((long) (digit >> 40)) & (long) byte.MaxValue))] + 40 : (int) num3 + 48;
        }
      }
      else if (((long) digit & 1099511562240L) != 0L)
      {
        byte num2 = BigInteger.byteToMsOneBit[checked ((ulong) (unchecked ((long) (digit >> 32)) & (long) byte.MaxValue))];
        if (num2 < byte.MaxValue)
        {
          num1 = (int) num2 + 32;
        }
        else
        {
          byte num3 = BigInteger.byteToMsOneBit[checked ((ulong) (unchecked ((long) (digit >> 24)) & (long) byte.MaxValue))];
          num1 = num3 >= byte.MaxValue ? (int) BigInteger.byteToMsOneBit[checked ((ulong) (unchecked ((long) (digit >> 16)) & (long) byte.MaxValue))] + 16 : (int) num3 + 24;
        }
      }
      else
      {
        byte num2 = BigInteger.byteToMsOneBit[checked ((ulong) (unchecked ((long) (digit >> 8)) & (long) byte.MaxValue))];
        num1 = num2 >= byte.MaxValue ? (int) BigInteger.byteToMsOneBit[checked ((ulong) (unchecked ((long) digit) & (long) byte.MaxValue))] : (int) num2 + 8;
      }
      return num1;
    }

    public int CompareTo(LongRational other)
    {
      return this.numerator < 0L == other.numerator < 0L ? (this.numerator >= 0L ? this.CompareMagnitude(other) : -this.CompareMagnitude(other)) : (this.numerator < 0L ? -1 : 1);
    }

    public int CompareMagnitude(LongRational other)
    {
      bool flag1 = this.denominator == 0L;
      bool flag2 = other.denominator == 0L;
      if (flag1)
        return flag2 ? 0 : 1;
      if (flag2)
        return -1;
      ulong num1 = (ulong) System.Math.Abs(this.numerator);
      ulong num2 = num1 >> 32;
      ulong num3 = num1 & (ulong) uint.MaxValue;
      ulong denominator1 = (ulong) this.denominator;
      ulong num4 = denominator1 >> 32;
      ulong num5 = denominator1 & (ulong) uint.MaxValue;
      ulong num6 = (ulong) System.Math.Abs(other.numerator);
      ulong num7 = num6 >> 32;
      ulong num8 = num6 & (ulong) uint.MaxValue;
      ulong denominator2 = (ulong) other.denominator;
      ulong num9 = denominator2 >> 32;
      ulong num10 = denominator2 & (ulong) uint.MaxValue;
      ulong num11 = num3 * num10;
      ulong num12 = num5 * num8;
      ulong num13 = (ulong) ((long) num2 * (long) num10 + (long) num3 * (long) num9);
      ulong num14 = (ulong) ((long) num4 * (long) num8 + (long) num5 * (long) num7);
      ulong num15 = num2 * num9 + (num13 + (num11 >> 32) >> 32);
      ulong num16 = num4 * num7 + (num14 + (num12 >> 32) >> 32);
      if (num15 < num16)
        return -1;
      if (num15 > num16)
        return 1;
      ulong num17 = num11 + (num13 << 32);
      ulong num18 = num12 + (num14 << 32);
      if (num17 < num18)
        return -1;
      return num17 > num18 ? 1 : 0;
    }

    internal static char smethod_2(long digit)
    {
      return (char) (48L + digit);
    }

    public static long GetGcd(long a, long b)
    {
      return LongRational.smethod_3(a, b);
    }

    private static long smethod_3(long a, long b)
    {
      if (a == 0L && b == 0L)
        return 0;
      if (a == 0L)
        return b;
      if (b == 0L)
        return a;
      a = System.Math.Abs(a);
      long result;
      for (b = System.Math.Abs(b); b != 0L; b = result)
      {
        System.Math.DivRem(a, b, out result);
        a = b;
      }
      return a;
    }

    public static LongRational Max(LongRational a, LongRational b)
    {
      if (a > b)
        return a;
      return b;
    }

    public static LongRational Min(LongRational a, LongRational b)
    {
      if (a < b)
        return a;
      return b;
    }
  }
}
