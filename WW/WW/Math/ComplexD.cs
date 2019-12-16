// Decompiled with JetBrains decompiler
// Type: WW.Math.ComplexD
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Globalization;

namespace WW.Math
{
  [Serializable]
  public struct ComplexD
  {
    public static readonly ComplexD Zero = new ComplexD(0.0, 0.0);
    public static readonly ComplexD One = new ComplexD(1.0, 0.0);
    public static readonly ComplexD ImaginaryOne = new ComplexD(0.0, 1.0);
    public static readonly ComplexD Two = new ComplexD(2.0, 0.0);
    public static readonly ComplexD Half = new ComplexD(0.5, 0.0);
    private static readonly double SqrtHalf = System.Math.Sqrt(0.5);
    public double Real;
    public double Imaginary;

    public ComplexD(double real)
    {
      this.Real = real;
      this.Imaginary = 0.0;
    }

    public ComplexD(double real, double imaginary)
    {
      this.Real = real;
      this.Imaginary = imaginary;
    }

    public ComplexD GetConjugate()
    {
      return new ComplexD(this.Real, -this.Imaginary);
    }

    public double GetAbs()
    {
      return System.Math.Sqrt(this.Real * this.Real + this.Imaginary * this.Imaginary);
    }

    public double GetModulusSquared()
    {
      return this.Real * this.Real + this.Imaginary * this.Imaginary;
    }

    public double GetModulus()
    {
      return System.Math.Sqrt(this.Real * this.Real + this.Imaginary * this.Imaginary);
    }

    public double GetArgument()
    {
      return System.Math.Atan2(this.Imaginary, this.Real);
    }

    public ComplexD GetSqrt()
    {
      if (this.Imaginary == 0.0)
        return ComplexD.Sqrt(this.Real);
      double modulus = this.GetModulus();
      return new ComplexD((double) System.Math.Sign(this.Imaginary) * System.Math.Sqrt(0.5 * (modulus + this.Real)), System.Math.Sqrt(0.5 * (modulus - this.Real)));
    }

    public static ComplexD Sqrt(double d)
    {
      if (d >= 0.0)
        return new ComplexD(System.Math.Sqrt(d), 0.0);
      return new ComplexD(0.0, System.Math.Sqrt(-d));
    }

    public static ComplexD FromModulusAndArgument(double modulus, double argument)
    {
      return new ComplexD(modulus * System.Math.Cos(argument), modulus * System.Math.Sin(argument));
    }

    public static ComplexD FromTan(double argumentTangens)
    {
      double num = 1.0 + argumentTangens * argumentTangens;
      return new ComplexD(1.0 / num, argumentTangens / num);
    }

    public static bool AreApproxEqual(ComplexD u, ComplexD v)
    {
      return ComplexD.AreApproxEqual(u, v, 8.88178419700125E-16);
    }

    public static bool AreApproxEqual(ComplexD u, ComplexD v, double tolerance)
    {
      if (System.Math.Abs(v.Real - u.Real) <= tolerance)
        return System.Math.Abs(v.Imaginary - u.Imaginary) <= tolerance;
      return false;
    }

    public static explicit operator ComplexD(double d)
    {
      return new ComplexD(d);
    }

    public static bool operator ==(ComplexD u, double v)
    {
      if (u.Real == v)
        return u.Imaginary == 0.0;
      return false;
    }

    public static bool operator !=(ComplexD u, double v)
    {
      if (u.Real == v)
        return u.Imaginary != 0.0;
      return true;
    }

    public static bool operator ==(ComplexD u, ComplexD v)
    {
      if (u.Real == v.Real)
        return u.Imaginary == v.Imaginary;
      return false;
    }

    public static bool operator !=(ComplexD u, ComplexD v)
    {
      if (u.Real == v.Real)
        return u.Imaginary != v.Imaginary;
      return true;
    }

    public static ComplexD operator -(ComplexD v)
    {
      return new ComplexD(-v.Real, -v.Imaginary);
    }

    public static ComplexD operator +(ComplexD u, ComplexD v)
    {
      return new ComplexD(u.Real + v.Real, u.Imaginary + v.Imaginary);
    }

    public static ComplexD operator -(ComplexD u, ComplexD v)
    {
      return new ComplexD(u.Real - v.Real, u.Imaginary - v.Imaginary);
    }

    public static ComplexD operator *(ComplexD u, ComplexD v)
    {
      return new ComplexD(u.Real * v.Real - u.Imaginary * v.Imaginary, u.Real * v.Imaginary + u.Imaginary * v.Real);
    }

    public static double MultiplyAndGetReal(ComplexD u, ComplexD v)
    {
      return u.Real * v.Real - u.Imaginary * v.Imaginary;
    }

    public static ComplexD operator /(ComplexD u, ComplexD v)
    {
      double num = 1.0 / v.GetModulusSquared();
      return new ComplexD(num * (u.Real * v.Real + u.Imaginary * v.Imaginary), num * (u.Imaginary * v.Real - u.Real * v.Imaginary));
    }

    public static ComplexD operator *(ComplexD v, double s)
    {
      return new ComplexD(v.Real * s, v.Imaginary * s);
    }

    public static ComplexD operator *(double s, ComplexD v)
    {
      return new ComplexD(v.Real * s, v.Imaginary * s);
    }

    public static ComplexD operator /(ComplexD v, double s)
    {
      double num = 1.0 / s;
      return new ComplexD(v.Real * num, v.Imaginary * num);
    }

    public override int GetHashCode()
    {
      return this.Real.GetHashCode() ^ this.Imaginary.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is ComplexD)
        return this.Equals((ComplexD) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}", (object) this.Real.ToString((IFormatProvider) invariantCulture), (object) this.Imaginary.ToString((IFormatProvider) invariantCulture));
    }

    public bool Equals(ComplexD other)
    {
      if (this.Real == other.Real)
        return this.Imaginary == other.Imaginary;
      return false;
    }
  }
}
