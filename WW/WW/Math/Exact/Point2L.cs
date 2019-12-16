// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Point2L
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;

namespace WW.Math.Exact
{
  [TypeConverter(typeof (Point2LConverter))]
  [Serializable]
  public struct Point2L : IEquatable<Point2L>
  {
    public static readonly Point2L Zero = Point2L.smethod_0(0L, 0L);
    public long X;
    public long Y;

    [Obsolete]
    [DisplayName("X")]
    public long _XProperty
    {
      get
      {
        return this.X;
      }
      set
      {
        this.X = value;
      }
    }

    [DisplayName("Y")]
    [Obsolete]
    public long _YProperty
    {
      get
      {
        return this.Y;
      }
      set
      {
        this.Y = value;
      }
    }

    [DebuggerStepThrough]
    public Point2L(long x, long y)
    {
      this.X = x;
      this.Y = y;
    }

    [DebuggerStepThrough]
    public Point2L(long[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Point2L(IList<long> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Point2L(Point2L from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    [DebuggerStepThrough]
    public Point2L(Vector2L from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    [DebuggerStepThrough]
    public Point2L(Point2D from)
    {
      this.X = (long) MathUtil.RoundHalfUp(from.X);
      this.Y = (long) MathUtil.RoundHalfUp(from.Y);
    }

    public static Point2L Add(Point2L p, Vector2L v)
    {
      return new Point2L(p.X + v.X, p.Y + v.Y);
    }

    public static Point2L Subtract(Point2L p, Vector2L v)
    {
      return new Point2L(p.X - v.X, p.Y - v.Y);
    }

    public static Vector2L Subtract(Point2L a, Point2L b)
    {
      return new Vector2L(a.X - b.X, a.Y - b.Y);
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
      if (other is Point2L)
        return this.Equals((Point2L) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture));
    }

    public static Point2L Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 2)
        throw new ArgumentException("Illegal point string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Point2L(long.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), long.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Point2L a, Point2L b)
    {
      if (a.X == b.X)
        return a.Y == b.Y;
      return false;
    }

    public static bool operator !=(Point2L a, Point2L b)
    {
      if (a.X == b.X)
        return a.Y != b.Y;
      return true;
    }

    public static Point2L operator +(Point2L p, Vector2L v)
    {
      return new Point2L(p.X + v.X, p.Y + v.Y);
    }

    public static Point2L operator +(Vector2L v, Point2L p)
    {
      return new Point2L(p.X + v.X, p.Y + v.Y);
    }

    public static Point2L operator -(Point2L p, Vector2L v)
    {
      return new Point2L(p.X - v.X, p.Y - v.Y);
    }

    public static Vector2L operator -(Point2L a, Point2L b)
    {
      return new Vector2L(a.X - b.X, a.Y - b.Y);
    }

    public long this[int index]
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

    public static explicit operator long[](Point2L p)
    {
      return new long[2]{ p.X, p.Y };
    }

    public static explicit operator Point2L(Point3L p)
    {
      return new Point2L(p.X, p.Y);
    }

    public static explicit operator Point2L(Vector2L v)
    {
      return new Point2L(v);
    }

    public static explicit operator Point2D(Point2L p)
    {
      return new Point2D((double) p.X, (double) p.Y);
    }

    public static explicit operator System.Windows.Point(Point2L p)
    {
      return new System.Windows.Point((double) p.X, (double) p.Y);
    }

    public static explicit operator System.Drawing.Point(Point2L p)
    {
      return new System.Drawing.Point((int) p.X, (int) p.Y);
    }

    public static explicit operator PointF(Point2L p)
    {
      return new PointF((float) p.X, (float) p.Y);
    }

    public static explicit operator Point2L(PointF p)
    {
      return new Point2L((long) System.Math.Round((double) p.X), (long) System.Math.Round((double) p.Y));
    }

    private static Point2L smethod_0(long x, long y)
    {
      return new Point2L(x, y);
    }

    public bool Equals(Point2L other)
    {
      if (this.X == other.X)
        return this.Y == other.Y;
      return false;
    }
  }
}
