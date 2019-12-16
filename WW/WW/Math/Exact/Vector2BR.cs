// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Vector2BR
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Globalization;

namespace WW.Math.Exact
{
  [Serializable]
  public struct Vector2BR : IEquatable<Vector2BR>
  {
    public static readonly Vector2BR Zero = new Vector2BR(BigRational.Zero, BigRational.Zero);
    public static readonly Vector2BR XAxis = new Vector2BR(BigRational.One, BigRational.Zero);
    public static readonly Vector2BR YAxis = new Vector2BR(BigRational.Zero, BigRational.One);
    public BigRational X;
    public BigRational Y;

    public Vector2BR(BigRational x, BigRational y)
    {
      this.X = x;
      this.Y = y;
    }

    public Vector2BR(double x, double y)
    {
      this.X = (BigRational) x;
      this.Y = (BigRational) y;
    }

    public bool IsZero
    {
      get
      {
        if (this.X.IsZero)
          return this.Y.IsZero;
        return false;
      }
    }

    public static Vector2BR Add(Vector2BR u, Vector2BR v)
    {
      return new Vector2BR(u.X + v.X, u.Y + v.Y);
    }

    public static Vector2BR Subtract(Vector2BR u, Vector2BR v)
    {
      return new Vector2BR(u.X - v.X, u.Y - v.Y);
    }

    public static Vector2BR Divide(Vector2BR v, BigRational s)
    {
      return new Vector2BR(v.X / s, v.Y / s);
    }

    public static Vector2BR Multiply(Vector2BR u, BigRational s)
    {
      return new Vector2BR(u.X * s, u.Y * s);
    }

    public static BigRational DotProduct(Vector2BR u, Vector2BR v)
    {
      return u.X * v.X + u.Y * v.Y;
    }

    public static BigRational CrossProduct(Vector2BR u, Vector2BR v)
    {
      return u.X * v.Y - u.Y * v.X;
    }

    public static Vector2BR Negate(Vector2BR v)
    {
      return new Vector2BR(-v.X, -v.Y);
    }

    public BigRational GetLengthSquared()
    {
      return this.X * this.X + this.Y * this.Y;
    }

    public static int CompareAngles(Vector2BR a, Vector2BR b)
    {
      int quadrant1 = Vector2BR.GetQuadrant(a);
      int quadrant2 = Vector2BR.GetQuadrant(b);
      if (quadrant1 < quadrant2)
        return -1;
      if (quadrant1 > quadrant2)
        return 1;
      BigRational bigRational = Vector2BR.CrossProduct(a, b);
      if (bigRational.IsNegative)
        return 1;
      return bigRational.IsPositive ? -1 : 0;
    }

    public static int GetQuadrant(Vector2BR v)
    {
      return !v.Y.IsNegative ? (!v.X.IsNegative ? 0 : 1) : (!v.X.IsNegative ? 3 : 2);
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Vector2BR)
        return this.Equals((Vector2BR) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture));
    }

    public static bool operator ==(Vector2BR u, Vector2BR v)
    {
      if (u.X == v.X)
        return u.Y == v.Y;
      return false;
    }

    public static bool operator !=(Vector2BR u, Vector2BR v)
    {
      if (u.X == v.X)
        return !(u.Y == v.Y);
      return true;
    }

    public static Vector2BR operator -(Vector2BR v)
    {
      return new Vector2BR(-v.X, -v.Y);
    }

    public static Vector2BR operator +(Vector2BR u, Vector2BR v)
    {
      return new Vector2BR(u.X + v.X, u.Y + v.Y);
    }

    public static Vector2BR operator -(Vector2BR u, Vector2BR v)
    {
      return new Vector2BR(u.X - v.X, u.Y - v.Y);
    }

    public static Vector2BR operator *(Vector2BR v, BigRational s)
    {
      return new Vector2BR(v.X * s, v.Y * s);
    }

    public static Vector2BR operator *(BigRational s, Vector2BR v)
    {
      return new Vector2BR(v.X * s, v.Y * s);
    }

    public static Vector2BR operator /(Vector2BR v, BigRational s)
    {
      return new Vector2BR(v.X / s, v.Y / s);
    }

    public BigRational this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return this.X;
          case 1:
            return this.Y;
          default:
            throw new IndexOutOfRangeException();
        }
      }
      set
      {
        switch (index)
        {
          case 0:
            this.X = value;
            break;
          case 1:
            this.Y = value;
            break;
          default:
            throw new IndexOutOfRangeException();
        }
      }
    }

    public static explicit operator BigRational[](Vector2BR v)
    {
      return new BigRational[2]{ v.X, v.Y };
    }

    public static explicit operator Vector2BR(Point2BR p)
    {
      return new Vector2BR(p.X, p.Y);
    }

    private static Vector2BR smethod_0(BigRational x, BigRational y)
    {
      return new Vector2BR(x, y);
    }

    public bool Equals(Vector2BR other)
    {
      if (this.X == other.X)
        return this.Y == other.Y;
      return false;
    }
  }
}
