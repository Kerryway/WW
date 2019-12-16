// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Point2BR
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Drawing;
using System.Globalization;

namespace WW.Math.Exact
{
  [Serializable]
  public struct Point2BR : IEquatable<Point2BR>
  {
    public static readonly Point2BR Zero = new Point2BR(BigRational.Zero, BigRational.Zero);
    public BigRational X;
    public BigRational Y;

    public Point2BR(BigRational x, BigRational y)
    {
      this.X = x;
      this.Y = y;
    }

    public Point2BR(double x, double y)
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

    public static Point2BR Add(Point2BR p, Vector2BR v)
    {
      return new Point2BR(p.X + v.X, p.Y + v.Y);
    }

    public static Point2BR Subtract(Point2BR p, Vector2BR v)
    {
      return new Point2BR(p.X - v.X, p.Y - v.Y);
    }

    public static Vector2BR Subtract(Point2BR a, Point2BR b)
    {
      return new Vector2BR(a.X - b.X, a.Y - b.Y);
    }

    public static Point2BR GetMidPoint(Point2BR a, Point2BR b)
    {
      return new Point2BR((a.X + b.X).DivideByTwo(), (a.Y + b.Y).DivideByTwo());
    }

    public Point2D ToPoint2D()
    {
      return new Point2D((double) this.X, (double) this.Y);
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Point2BR)
        return this.Equals((Point2BR) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture));
    }

    public static bool operator ==(Point2BR a, Point2BR b)
    {
      if (a.X == b.X)
        return a.Y == b.Y;
      return false;
    }

    public static bool operator !=(Point2BR a, Point2BR b)
    {
      if (a.X == b.X)
        return !(a.Y == b.Y);
      return true;
    }

    public static Point2BR operator +(Point2BR p, Vector2BR v)
    {
      return new Point2BR(p.X + v.X, p.Y + v.Y);
    }

    public static Point2BR operator +(Vector2BR v, Point2BR p)
    {
      return new Point2BR(p.X + v.X, p.Y + v.Y);
    }

    public static Point2BR operator -(Point2BR p, Vector2BR v)
    {
      return new Point2BR(p.X - v.X, p.Y - v.Y);
    }

    public static Vector2BR operator -(Point2BR a, Point2BR b)
    {
      return new Vector2BR(a.X - b.X, a.Y - b.Y);
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

    public static explicit operator BigRational[](Point2BR p)
    {
      return new BigRational[2]{ p.X, p.Y };
    }

    public static explicit operator Point2BR(Point3BR p)
    {
      return new Point2BR(p.X, p.Y);
    }

    public static explicit operator Point2BR(Vector4BR v)
    {
      BigRational bigRational = v.W.Invert();
      return new Point2BR(v.X * bigRational, v.Y * bigRational);
    }

    public static explicit operator Point2BR(Vector2BR v)
    {
      return new Point2BR(v.X, v.Y);
    }

    public static explicit operator System.Windows.Point(Point2BR p)
    {
      return new System.Windows.Point((double) p.X, (double) p.Y);
    }

    public static explicit operator System.Drawing.Point(Point2BR p)
    {
      return new System.Drawing.Point((int) System.Math.Round((double) p.X), (int) System.Math.Round((double) p.Y));
    }

    public static explicit operator PointF(Point2BR p)
    {
      return new PointF((float) (double) p.X, (float) (double) p.Y);
    }

    public static explicit operator Point2BR(PointF p)
    {
      return new Point2BR((double) p.X, (double) p.Y);
    }

    public bool Equals(Point2BR other)
    {
      if (this.X == other.X)
        return this.Y == other.Y;
      return false;
    }
  }
}
