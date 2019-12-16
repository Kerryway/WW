// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Point2I
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
  [TypeConverter(typeof (Point2IConverter))]
  [Serializable]
  public struct Point2I : IEquatable<Point2I>
  {
    public static readonly Point2I Zero = Point2I.smethod_0(0, 0);
    public int X;
    public int Y;

    [Obsolete]
    [DisplayName("X")]
    public int _XProperty
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
    public int _YProperty
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
    public Point2I(int x, int y)
    {
      this.X = x;
      this.Y = y;
    }

    [DebuggerStepThrough]
    public Point2I(int[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Point2I(IList<int> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Point2I(Point2I from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    [DebuggerStepThrough]
    public Point2I(Vector2I from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    [DebuggerStepThrough]
    public Point2I(Point2D from)
    {
      this.X = (int) MathUtil.RoundHalfUp(from.X);
      this.Y = (int) MathUtil.RoundHalfUp(from.Y);
    }

    public static Point2I Add(Point2I p, Vector2I v)
    {
      return new Point2I(p.X + v.X, p.Y + v.Y);
    }

    public static Point2I Subtract(Point2I p, Vector2I v)
    {
      return new Point2I(p.X - v.X, p.Y - v.Y);
    }

    public static Vector2I Subtract(Point2I a, Point2I b)
    {
      return new Vector2I(a.X - b.X, a.Y - b.Y);
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
      if (other is Point2I)
        return this.Equals((Point2I) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture));
    }

    public static Point2I Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 2)
        throw new ArgumentException("Illegal point string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Point2I(int.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), int.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Point2I a, Point2I b)
    {
      if (a.X == b.X)
        return a.Y == b.Y;
      return false;
    }

    public static bool operator !=(Point2I a, Point2I b)
    {
      if (a.X == b.X)
        return a.Y != b.Y;
      return true;
    }

    public static Point2I operator +(Point2I p, Vector2I v)
    {
      return new Point2I(p.X + v.X, p.Y + v.Y);
    }

    public static Point2I operator +(Vector2I v, Point2I p)
    {
      return new Point2I(p.X + v.X, p.Y + v.Y);
    }

    public static Point2I operator -(Point2I p, Vector2I v)
    {
      return new Point2I(p.X - v.X, p.Y - v.Y);
    }

    public static Vector2I operator -(Point2I a, Point2I b)
    {
      return new Vector2I(a.X - b.X, a.Y - b.Y);
    }

    public int this[int index]
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

    public static explicit operator int[](Point2I p)
    {
      return new int[2]{ p.X, p.Y };
    }

    public static explicit operator Point2I(Point3I p)
    {
      return new Point2I(p.X, p.Y);
    }

    public static explicit operator Point2I(Vector2I v)
    {
      return new Point2I(v);
    }

    public static explicit operator Point2D(Point2I p)
    {
      return new Point2D((double) p.X, (double) p.Y);
    }

    public static explicit operator System.Windows.Point(Point2I p)
    {
      return new System.Windows.Point((double) p.X, (double) p.Y);
    }

    public static explicit operator System.Drawing.Point(Point2I p)
    {
      return new System.Drawing.Point(p.X, p.Y);
    }

    public static explicit operator PointF(Point2I p)
    {
      return new PointF((float) p.X, (float) p.Y);
    }

    public static explicit operator Point2I(PointF p)
    {
      return new Point2I((int) System.Math.Round((double) p.X), (int) System.Math.Round((double) p.Y));
    }

    private static Point2I smethod_0(int x, int y)
    {
      return new Point2I(x, y);
    }

    public bool Equals(Point2I other)
    {
      if (this.X == other.X)
        return this.Y == other.Y;
      return false;
    }
  }
}
