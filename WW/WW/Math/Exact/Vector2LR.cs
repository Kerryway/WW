// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Vector2LR
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Globalization;

namespace WW.Math.Exact
{
  [Serializable]
  public struct Vector2LR : IEquatable<Vector2LR>
  {
    public static readonly Vector2LR Zero = new Vector2LR(LongRational.Zero, LongRational.Zero);
    public static readonly Vector2LR XAxis = new Vector2LR(LongRational.One, LongRational.Zero);
    public static readonly Vector2LR YAxis = new Vector2LR(LongRational.Zero, LongRational.One);
    public LongRational X;
    public LongRational Y;

    public Vector2LR(LongRational x, LongRational y)
    {
      this.X = x;
      this.Y = y;
    }

    public Vector2LR(double x, double y)
    {
      this.X = (LongRational) x;
      this.Y = (LongRational) y;
    }

    public Vector2LR(int x, int y)
    {
      this.X = new LongRational(x);
      this.Y = new LongRational(y);
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

    public static Vector2LR Add(Vector2LR u, Vector2LR v)
    {
      return new Vector2LR(u.X + v.X, u.Y + v.Y);
    }

    public static Vector2LR Subtract(Vector2LR u, Vector2LR v)
    {
      return new Vector2LR(u.X - v.X, u.Y - v.Y);
    }

    public static Vector2LR Divide(Vector2LR v, LongRational s)
    {
      return new Vector2LR(v.X / s, v.Y / s);
    }

    public static Vector2LR Multiply(Vector2LR u, LongRational s)
    {
      return new Vector2LR(u.X * s, u.Y * s);
    }

    public static LongRational DotProduct(Vector2LR u, Vector2LR v)
    {
      return u.X * v.X + u.Y * v.Y;
    }

    public static LongRational CrossProduct(Vector2LR u, Vector2LR v)
    {
      return u.X * v.Y - u.Y * v.X;
    }

    public static Vector2LR Negate(Vector2LR v)
    {
      return new Vector2LR(-v.X, -v.Y);
    }

    public LongRational GetLengthSquared()
    {
      return this.X * this.X + this.Y * this.Y;
    }

    public static int CompareAngles(Vector2LR a, Vector2LR b)
    {
      int quadrant1 = Vector2LR.GetQuadrant(a);
      int quadrant2 = Vector2LR.GetQuadrant(b);
      if (quadrant1 < quadrant2)
        return -1;
      if (quadrant1 > quadrant2)
        return 1;
      LongRational longRational = Vector2LR.CrossProduct(a, b);
      if (longRational.IsNegative)
        return 1;
      return longRational.IsPositive ? -1 : 0;
    }

    public static int GetQuadrant(Vector2LR v)
    {
      return !v.Y.IsNegative ? (!v.X.IsNegative ? 0 : 1) : (!v.X.IsNegative ? 3 : 2);
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Vector2LR)
        return this.Equals((Vector2LR) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture));
    }

    public static bool operator ==(Vector2LR u, Vector2LR v)
    {
      if (u.X == v.X)
        return u.Y == v.Y;
      return false;
    }

    public static bool operator !=(Vector2LR u, Vector2LR v)
    {
      if (u.X == v.X)
        return !(u.Y == v.Y);
      return true;
    }

    public static Vector2LR operator -(Vector2LR v)
    {
      return new Vector2LR(-v.X, -v.Y);
    }

    public static Vector2LR operator +(Vector2LR u, Vector2LR v)
    {
      return new Vector2LR(u.X + v.X, u.Y + v.Y);
    }

    public static Vector2LR operator -(Vector2LR u, Vector2LR v)
    {
      return new Vector2LR(u.X - v.X, u.Y - v.Y);
    }

    public static Vector2LR operator *(Vector2LR v, LongRational s)
    {
      return new Vector2LR(v.X * s, v.Y * s);
    }

    public static Vector2LR operator *(LongRational s, Vector2LR v)
    {
      return new Vector2LR(v.X * s, v.Y * s);
    }

    public static Vector2LR operator /(Vector2LR v, LongRational s)
    {
      return new Vector2LR(v.X / s, v.Y / s);
    }

    public LongRational this[int index]
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

    public static explicit operator LongRational[](Vector2LR v)
    {
      return new LongRational[2]{ v.X, v.Y };
    }

    public static explicit operator Vector2LR(Point2LR p)
    {
      return new Vector2LR(p.X, p.Y);
    }

    private static Vector2LR smethod_0(LongRational x, LongRational y)
    {
      return new Vector2LR(x, y);
    }

    public bool Equals(Vector2LR other)
    {
      if (this.X == other.X)
        return this.Y == other.Y;
      return false;
    }
  }
}
