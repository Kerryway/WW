// Decompiled with JetBrains decompiler
// Type: WW.Math.Point2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using WW.Math.Geometry;

namespace WW.Math
{
  [TypeConverter(typeof (Point2DConverter))]
  [Serializable]
  public struct Point2D : IShape2D, IEquatable<Point2D>
  {
    public static readonly Point2D Zero = Point2D.smethod_0(0.0, 0.0);
    public static readonly Point2D NaN = Point2D.smethod_0(double.NaN, double.NaN);
    public double X;
    public double Y;

    [DisplayName("X")]
    [Obsolete]
    public double _XProperty
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
    public double _YProperty
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
    public Point2D(double x, double y)
    {
      this.X = x;
      this.Y = y;
    }

    [DebuggerStepThrough]
    public Point2D(double[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Point2D(IList<double> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Point2D(Point2D from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    [DebuggerStepThrough]
    public Point2D(Vector2D from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    public static Point2D Add(Point2D p, Vector2D v)
    {
      return new Point2D(p.X + v.X, p.Y + v.Y);
    }

    public static Point2D Subtract(Point2D p, Vector2D v)
    {
      return new Point2D(p.X - v.X, p.Y - v.Y);
    }

    public static Vector2D Subtract(Point2D a, Point2D b)
    {
      return new Vector2D(a.X - b.X, a.Y - b.Y);
    }

    public static bool AreApproxEqual(Point2D a, Point2D b)
    {
      return Point2D.AreApproxEqual(a, b, 8.88178419700125E-16);
    }

    public static bool AreApproxEqual(Point2D a, Point2D b, double tolerance)
    {
      if (System.Math.Abs(b.X - a.X) <= tolerance)
        return System.Math.Abs(b.Y - a.Y) <= tolerance;
      return false;
    }

    public static Point2D GetMidPoint(Point2D a, Point2D b)
    {
      return new Point2D(0.5 * (a.X + b.X), 0.5 * (a.Y + b.Y));
    }

    public ISegment2DIterator CreateIterator()
    {
      return (ISegment2DIterator) new Point2D.Class36(this);
    }

    public void AddToBounds(Bounds2D bounds)
    {
      bounds.Update(this);
    }

    public bool HasSegments
    {
      get
      {
        return true;
      }
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Point2D)
        return this.Equals((Point2D) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture));
    }

    public static Point2D Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 2)
        throw new ArgumentException("Illegal point string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Point2D(double.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), double.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal point string.", ex);
      }
    }

    public static bool operator ==(Point2D a, Point2D b)
    {
      if (a.X == b.X)
        return a.Y == b.Y;
      return false;
    }

    public static bool operator !=(Point2D a, Point2D b)
    {
      if (a.X == b.X)
        return a.Y != b.Y;
      return true;
    }

    public static Point2D operator +(Point2D p, Vector2D v)
    {
      return new Point2D(p.X + v.X, p.Y + v.Y);
    }

    public static Point2D operator +(Vector2D v, Point2D p)
    {
      return new Point2D(p.X + v.X, p.Y + v.Y);
    }

    public static Point2D operator -(Point2D p, Vector2D v)
    {
      return new Point2D(p.X - v.X, p.Y - v.Y);
    }

    public static Vector2D operator -(Point2D a, Point2D b)
    {
      return new Vector2D(a.X - b.X, a.Y - b.Y);
    }

    public double this[int index]
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

    public static explicit operator double[](Point2D p)
    {
      return new double[2]{ p.X, p.Y };
    }

    public static explicit operator Point2D(Point3D p)
    {
      return new Point2D(p.X, p.Y);
    }

    public static explicit operator Point2D(Vector4D v)
    {
      double num = 1.0 / v.W;
      return new Point2D(v.X * num, v.Y * num);
    }

    public static explicit operator Point2D(Vector2D v)
    {
      return new Point2D(v);
    }

    public static explicit operator System.Windows.Point(Point2D p)
    {
      return new System.Windows.Point(p.X, p.Y);
    }

    public static explicit operator System.Drawing.Point(Point2D p)
    {
      return new System.Drawing.Point((int) System.Math.Round(p.X), (int) System.Math.Round(p.Y));
    }

    public static explicit operator PointF(Point2D p)
    {
      return new PointF((float) p.X, (float) p.Y);
    }

    public static explicit operator Point2D(PointF p)
    {
      return new Point2D((double) p.X, (double) p.Y);
    }

    private static Point2D smethod_0(double x, double y)
    {
      return new Point2D(x, y);
    }

    public bool Equals(Point2D other)
    {
      if (this.X == other.X)
        return this.Y == other.Y;
      return false;
    }

    private class Class36 : ISegment2DIterator
    {
      private static readonly SegmentType[] segmentType_0 = new SegmentType[2]{ SegmentType.MoveTo, SegmentType.LineTo };
      private int int_0 = -1;
      private readonly Point2D point2D_0;

      public Class36(Point2D point)
      {
        this.point2D_0 = point;
      }

      public bool MoveNext()
      {
        if (this.int_0 > 0)
          return false;
        ++this.int_0;
        return true;
      }

      public SegmentType CurrentType
      {
        get
        {
          return Point2D.Class36.segmentType_0[this.int_0];
        }
      }

      public SegmentType Current(Point2D[] points, int offset)
      {
        points[offset] = this.point2D_0;
        return Point2D.Class36.segmentType_0[this.int_0];
      }

      public int TotalSegmentCount
      {
        get
        {
          return 2;
        }
      }

      public int TotalPointCount
      {
        get
        {
          return 2;
        }
      }
    }
  }
}
