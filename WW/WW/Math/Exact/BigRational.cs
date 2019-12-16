// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.BigRational
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Globalization;
using System.Text;

namespace WW.Math.Exact
{
  [Serializable]
  public struct BigRational : IComparable<BigRational>
  {
    public static readonly BigRational Zero = new BigRational(BigInteger.Zero, BigInteger.One, false);
    public static readonly BigRational One = new BigRational(BigInteger.One, BigInteger.One, false);
    public static readonly BigRational MinusOne = new BigRational(BigInteger.MinusOne, BigInteger.One, false);
    public static readonly BigRational Two = new BigRational(BigInteger.Two, BigInteger.One, false);
    public static readonly BigRational MinusTwo = new BigRational(BigInteger.MinusTwo, BigInteger.One, false);
    public static readonly BigRational Three = new BigRational(BigInteger.Three, BigInteger.One, false);
    public static readonly BigRational MinusThree = new BigRational(BigInteger.MinusThree, BigInteger.One, false);
    public static readonly BigRational Half = new BigRational(BigInteger.One, BigInteger.Two, false);
    public static readonly BigRational NaN = new BigRational(BigInteger.NaN, BigInteger.One, false);
    public static readonly BigRational PositiveInfinity = new BigRational(BigInteger.One, BigInteger.Zero, false);
    public static readonly BigRational NegativeInfinity = new BigRational(BigInteger.MinusOne, BigInteger.Zero, false);
    private readonly BigInteger numerator;
    private readonly BigInteger denominator;

    public BigRational(int value)
    {
      this.numerator = new BigInteger(value);
      this.denominator = BigInteger.One;
    }

    public BigRational(uint value)
    {
      this.numerator = new BigInteger((long) value);
      this.denominator = BigInteger.One;
    }

    public BigRational(BigInteger numerator, BigInteger denominator)
    {
      this = new BigRational(numerator, denominator, true);
    }

    internal unsafe BigRational(BigInteger numerator, BigInteger denominator, bool normalize)
    {
      this = new BigRational();
      if (denominator.IsNegative)
        throw new ArgumentException("The denominator may not be negative.");
      if (normalize)
      {
        if (numerator.IsZero)
        {
          this.denominator = BigInteger.One;
        }
        else
        {
          BigInteger gcd = BigInteger.GetGcd(numerator, denominator);
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

    public BigInteger Numerator
    {
      get
      {
        return this.numerator;
      }
    }

    public BigInteger Denominator
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
        return this.numerator.IsNaN;
      }
    }

    public bool IsNegative
    {
      get
      {
        return this.numerator.IsNegative;
      }
    }

    public bool IsPositive
    {
      get
      {
        return this.numerator.IsPositive;
      }
    }

    public int Sign
    {
      get
      {
        return this.numerator.Sign;
      }
    }

    public bool IsZero
    {
      get
      {
        return this.numerator.IsZero;
      }
    }

    public static BigRational operator *(BigRational a, BigRational b)
    {
      if (a.IsNaN || b.IsNaN)
        return BigRational.NaN;
      if (a.numerator.Length == 0 || b.numerator.Length == 0)
        return BigRational.Zero;
      if (a.denominator.Length != 0 && b.denominator.Length != 0)
      {
        BigInteger gcd1 = BigInteger.GetGcd(a.numerator, b.denominator);
        BigInteger gcd2 = BigInteger.GetGcd(a.denominator, b.numerator);
        return new BigRational(a.numerator / gcd1 * (b.numerator / gcd2), a.denominator / gcd2 * (b.denominator / gcd1), false);
      }
      if (!(a.denominator.IsNegative ^ b.denominator.IsNegative))
        return BigRational.PositiveInfinity;
      return BigRational.NegativeInfinity;
    }

    public static BigRational operator /(BigRational a, BigRational b)
    {
      if (a.IsNaN || b.IsNaN || b.numerator.Length == 0)
        return BigRational.NaN;
      if (a.numerator.Length == 0)
        return BigRational.Zero;
      if (a.denominator.Length == 0)
      {
        if (b.denominator.IsZero)
          return BigRational.NaN;
        return BigRational.PositiveInfinity;
      }
      if (b.denominator.Length == 0)
        return BigRational.Zero;
      BigInteger gcd1 = BigInteger.GetGcd(a.numerator, b.numerator);
      BigInteger gcd2 = BigInteger.GetGcd(a.denominator, b.denominator);
      return new BigRational(BigInteger.smethod_2(a.numerator / gcd1, b.denominator / gcd2, a.numerator.IsNegative ^ b.numerator.IsNegative), BigInteger.smethod_2(a.denominator / gcd2, b.numerator / gcd1, false), false);
    }

    public static BigRational operator +(BigRational a, BigRational b)
    {
      if (a.IsNaN || b.IsNaN)
        return BigRational.NaN;
      if (a.numerator.Length == 0)
        return b;
      if (b.numerator.Length == 0)
        return a;
      if (a.denominator.IsZero)
      {
        if (b.denominator.IsZero)
          return BigRational.NaN;
        return a;
      }
      if (b.denominator.IsZero)
        return b;
      BigInteger gcd1 = BigInteger.GetGcd(a.denominator, b.denominator);
      if (gcd1 == BigInteger.One)
        return new BigRational(a.numerator * b.denominator + a.denominator * b.numerator, a.denominator * b.denominator, true);
      BigInteger bigInteger = a.denominator / gcd1;
      BigInteger a1 = a.numerator * (b.denominator / gcd1) + b.numerator * bigInteger;
      BigInteger gcd2 = BigInteger.GetGcd(a1, gcd1);
      return new BigRational(a1 / gcd2, bigInteger * (b.denominator / gcd2), false);
    }

    public static BigRational operator -(BigRational a, BigRational b)
    {
      if (a.IsNaN || b.IsNaN)
        return BigRational.NaN;
      if (a.numerator.Length == 0)
        return -b;
      if (b.numerator.Length == 0)
        return a;
      if (a.denominator.IsZero)
      {
        if (b.denominator.IsZero)
          return BigRational.NaN;
        return a;
      }
      if (b.denominator.IsZero)
        return -b;
      BigInteger gcd1 = BigInteger.GetGcd(a.denominator, b.denominator);
      if (gcd1 == BigInteger.One)
        return new BigRational(a.numerator * b.denominator - a.denominator * b.numerator, a.denominator * b.denominator, true);
      BigInteger bigInteger = a.denominator / gcd1;
      BigInteger a1 = a.numerator * (b.denominator / gcd1) - b.numerator * bigInteger;
      if (a1.IsZero)
        return BigRational.Zero;
      BigInteger gcd2 = BigInteger.GetGcd(a1, gcd1);
      return new BigRational(a1 / gcd2, bigInteger * (b.denominator / gcd2), false);
    }

    public static BigRational operator -(BigRational value)
    {
      if (value.IsNaN)
        return BigRational.NaN;
      return new BigRational(-value.numerator, value.denominator, false);
    }

    public static bool operator ==(BigRational a, BigRational b)
    {
      if (a.numerator == b.numerator)
        return a.denominator == b.denominator;
      return false;
    }

    public static bool operator !=(BigRational a, BigRational b)
    {
      return !(a == b);
    }

    public static bool operator >(BigRational a, BigRational b)
    {
      return a.CompareTo(b) > 0;
    }

    public static bool operator <(BigRational a, BigRational b)
    {
      return a.CompareTo(b) < 0;
    }

    public static bool operator >=(BigRational a, BigRational b)
    {
      return a.CompareTo(b) >= 0;
    }

    public static bool operator <=(BigRational a, BigRational b)
    {
      return a.CompareTo(b) <= 0;
    }

    public static explicit operator BigRational(double d)
    {
      if (double.IsNegativeInfinity(d))
        return BigRational.NegativeInfinity;
      if (double.IsPositiveInfinity(d))
        return BigRational.PositiveInfinity;
      if (double.IsNaN(d))
        return BigRational.NaN;
      ulong uint64 = BitConverter.ToUInt64(BitConverter.GetBytes(d), 0);
      bool isNegative = ((long) uint64 & long.MinValue) != 0L;
      ulong digit = uint64 & 4503599627370495UL;
      int num1 = (int) ((long) (uint64 >> 52) & 2047L);
      BigRational bigRational;
      if (num1 == 0 && digit == 0UL)
      {
        bigRational = BigRational.Zero;
      }
      else
      {
        int shift1 = num1 - 1075;
        if (shift1 >= 0)
        {
          ulong num2 = digit | 4503599627370496UL;
          bigRational = new BigRational(new BigInteger(isNegative, num2).LeftShift(shift1), BigInteger.One, false);
        }
        else
        {
          ulong num2;
          int shift2;
          if (digit == 0UL)
          {
            num2 = 1UL;
            shift2 = num1 - 1023;
          }
          else
          {
            int num3 = BigRational.smethod_0(digit);
            num2 = (digit | 4503599627370496UL) >> num3;
            shift2 = shift1 + num3;
          }
          bigRational = shift2 < 0 ? new BigRational(new BigInteger(isNegative, num2), BigInteger.One.LeftShift(-shift2), false) : new BigRational(new BigInteger(isNegative, num2).LeftShift(shift2), BigInteger.One, false);
        }
      }
      return bigRational;
    }

    public static explicit operator double(BigRational value)
    {
      if (value.IsNaN)
        return double.NaN;
      if (value.numerator.IsZero)
        return 0.0;
      if (!value.denominator.IsZero)
        return value.numerator.method_1() / value.denominator.method_1();
      return !value.IsNegative ? double.PositiveInfinity : double.NegativeInfinity;
    }

    public BigRational DivideByTwo()
    {
      if (this.numerator.IsNaN)
        return BigRational.NaN;
      if (this.denominator.IsZero)
        return this;
      if (this.numerator.IsEven)
        return new BigRational(this.numerator.RightShift(), this.denominator, false);
      return new BigRational(this.numerator, this.denominator.LeftShift(), false);
    }

    public BigRational MultiplyByTwo()
    {
      if (this.numerator.IsNaN)
        return BigRational.NaN;
      if (this.denominator.IsZero)
        return this;
      if (this.denominator.IsEven)
        return new BigRational(this.numerator, this.denominator.RightShift(), false);
      return new BigRational(this.numerator.LeftShift(), this.denominator, false);
    }

    public BigRational Square()
    {
      if (this.IsNaN)
        return BigRational.NaN;
      if (this.denominator.IsZero)
        return this;
      return new BigRational(this.numerator * this.numerator, this.denominator * this.denominator, true);
    }

    public BigRational Abs()
    {
      if (this.numerator.IsNegative)
        return new BigRational(this.numerator.Abs(), this.denominator, false);
      return this;
    }

    public BigRational Invert()
    {
      return new BigRational(new BigInteger(this.denominator.IsNegative, this.denominator.Length, this.denominator.Digits), new BigInteger(false, this.numerator.Length, this.numerator.Digits));
    }

    public BigRational Pow(int power)
    {
      if (power == 0)
        return BigRational.One;
      BigRational bigRational1 = this;
      if (power < 0)
      {
        if (this == BigRational.Zero)
          return BigRational.NaN;
        bigRational1 = bigRational1.Invert();
        power = -power;
      }
      BigRational bigRational2 = bigRational1;
      for (int index = 1; index < power; ++index)
        bigRational2 *= bigRational1;
      return bigRational2;
    }

    public override string ToString()
    {
      if (this.IsNaN)
        return "NaN";
      return this.ToString((IFormatProvider) CultureInfo.InvariantCulture);
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
      BigInteger quotient1;
      BigInteger remainder1;
      BigInteger.smethod_4(this.numerator, this.denominator, out quotient1, out remainder1);
      StringBuilder stringBuilder = new StringBuilder();
      BigInteger b = new BigInteger(radix);
      if (!quotient1.IsZero)
      {
        BigInteger quotient2 = quotient1;
        while (!quotient2.IsZero)
        {
          BigInteger remainder2;
          BigInteger.smethod_4(quotient2, b, out quotient2, out remainder2);
          stringBuilder.Insert(0, BigMath.smethod_0(remainder2));
        }
      }
      if (this.IsNegative)
        stringBuilder.Insert(0, "-");
      if (!remainder1.IsZero)
      {
        if (quotient1.IsZero)
        {
          BigInteger numerator = b * remainder1;
          BigRational bigRational = new BigRational(numerator, this.denominator);
          BigInteger quotient2;
          BigInteger.smethod_4(bigRational.numerator, bigRational.denominator, out quotient2, out remainder1);
          int num = 0;
          while (quotient2.IsZero)
          {
            ++num;
            numerator *= b;
            bigRational = new BigRational(numerator, this.denominator);
            BigInteger.smethod_4(bigRational.numerator, bigRational.denominator, out quotient2, out remainder1);
          }
          if (num == 0)
            stringBuilder.Append("0.");
          stringBuilder.Append(BigMath.smethod_0(quotient2));
          for (int index = 0; index < precision; ++index)
          {
            bigRational = new BigRational(b * remainder1, bigRational.denominator);
            BigInteger.smethod_4(bigRational.numerator, bigRational.denominator, out quotient2, out remainder1);
            if (index == 0 && num > 0)
              stringBuilder.Append('.');
            if (index == precision - 1 && remainder1 * BigInteger.Two >= bigRational.denominator)
              quotient2 += BigInteger.One;
            stringBuilder.Append(BigMath.smethod_0(quotient2));
          }
          if (num > 0)
          {
            stringBuilder.Append("E-");
            stringBuilder.Append((num + 1).ToString());
          }
        }
        else
        {
          stringBuilder.Append('.');
          BigRational bigRational = new BigRational(remainder1, this.denominator, false);
          for (int index = 0; index < precision; ++index)
          {
            bigRational = new BigRational(b * remainder1, bigRational.denominator);
            BigInteger quotient2;
            BigInteger.smethod_4(bigRational.numerator, bigRational.denominator, out quotient2, out remainder1);
            if (index == precision - 1 && remainder1 * BigInteger.Two >= bigRational.denominator)
              quotient2 += BigInteger.One;
            stringBuilder.Append(BigMath.smethod_0(quotient2));
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
      if (!(obj is BigRational))
        return false;
      return this == (BigRational) obj;
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

    public int CompareTo(BigRational other)
    {
      return this.numerator.IsNegative == other.numerator.IsNegative ? (!this.numerator.IsNegative ? this.CompareMagnitude(other) : -this.CompareMagnitude(other)) : (this.numerator.IsNegative ? -1 : 1);
    }

    public int CompareMagnitude(BigRational other)
    {
      bool isZero1 = this.denominator.IsZero;
      bool isZero2 = other.denominator.IsZero;
      if (isZero1)
        return isZero2 ? 0 : 1;
      if (isZero2)
        return -1;
      return (this.numerator * other.denominator).CompareMagnitude(this.denominator * other.numerator);
    }
  }
}
