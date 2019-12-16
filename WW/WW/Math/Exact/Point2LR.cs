// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Point2LR
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Drawing;
using System.Globalization;

namespace WW.Math.Exact
{
  [Serializable]
  public struct Point2LR : IEquatable<Point2LR>
  {
    public static readonly Point2LR Zero = new Point2LR(LongRational.Zero, LongRational.Zero);
    public LongRational X;
    public LongRational Y;

    public Point2LR(LongRational x, LongRational y)
    {
      this.X = x;
      this.Y = y;
    }

    public Point2LR(double x, double y)
    {
      this.X = (LongRational) x;
      this.Y = (LongRational) y;
    }

    public Point2LR(int x, int y)
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

    public static Point2LR Add(Point2LR p, Vector2LR v)
    {
      return new Point2LR(p.X + v.X, p.Y + v.Y);
    }

    public static Point2LR Subtract(Point2LR p, Vector2LR v)
    {
      return new Point2LR(p.X - v.X, p.Y - v.Y);
    }

    public static Vector2LR Subtract(Point2LR a, Point2LR b)
    {
      return new Vector2LR(a.X - b.X, a.Y - b.Y);
    }

    public static Point2LR GetMidPoint(Point2LR a, Point2LR b)
    {
      return new Point2LR((a.X + b.X).DivideByTwo(), (a.Y + b.Y).DivideByTwo());
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
      if (other is Point2LR)
        return this.Equals((Point2LR) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture));
    }

    public static bool operator ==(Point2LR a, Point2LR b)
    {
      if (a.X == b.X)
        return a.Y == b.Y;
      return false;
    }

    public static bool operator !=(Point2LR a, Point2LR b)
    {
      if (a.X == b.X)
        return !(a.Y == b.Y);
      return true;
    }

    public static Point2LR operator +(Point2LR p, Vector2LR v)
    {
      return new Point2LR(p.X + v.X, p.Y + v.Y);
    }

    public static Point2LR operator +(Vector2LR v, Point2LR p)
    {
      return new Point2LR(p.X + v.X, p.Y + v.Y);
    }

    public static Point2LR operator -(Point2LR p, Vector2LR v)
    {
      return new Point2LR(p.X - v.X, p.Y - v.Y);
    }

    public static Vector2LR operator -(Point2LR a, Point2LR b)
    {
      return new Vector2LR(a.X - b.X, a.Y - b.Y);
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

    public static explicit operator LongRational[](Point2LR p)
    {
      return new LongRational[2]{ p.X, p.Y };
    }

    public static explicit operator Point2LR(Point3LR p)
    {
      return new Point2LR(p.X, p.Y);
    }

    public static explicit operator Point2LR(Vector4LR v)
    {
      LongRational longRational = v.W.Invert();
      return new Point2LR(v.X * longRational, v.Y * longRational);
    }

    public static explicit operator Point2LR(Vector2LR v)
    {
      return new Point2LR(v.X, v.Y);
    }

    public static explicit operator System.Windows.Point(Point2LR p)
    {
      return new System.Windows.Point((double) p.X, (double) p.Y);
    }

    public static explicit operator System.Drawing.Point(Point2LR p)
    {
      return new System.Drawing.Point((int) System.Math.Round((double) p.X), (int) System.Math.Round((double) p.Y));
    }

    public static explicit operator PointF(Point2LR p)
    {
      return new PointF((float) (double) p.X, (float) (double) p.Y);
    }

    public static explicit operator Point2LR(PointF p)
    {
      return new Point2LR((double) p.X, (double) p.Y);
    }

    public bool Equals(Point2LR other)
    {
      if (this.X == other.X)
        return this.Y == other.Y;
      return false;
    }
  }
}
