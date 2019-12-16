// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Point3L
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace WW.Math.Exact
{
  [TypeConverter(typeof (Point3LConverter))]
  [Serializable]
  public struct Point3L : IEquatable<Point3L>
  {
    public static readonly Point3L Zero = Point3L.smethod_0(0L, 0L, 0L);
    public long X;
    public long Y;
    public long Z;

    [DebuggerStepThrough]
    public Point3L(long x, long y, long z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Point3L(Point2L point, long z)
    {
      this.X = point.X;
      this.Y = point.Y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Point3L(long[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Point3L(IList<long> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Point3L(Point3L from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [DebuggerStepThrough]
    public Point3L(Vector3L from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

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

    [Obsolete]
    [DisplayName("Z")]
    public long _ZProperty
    {
      get
      {
        return this.Z;
      }
      set
      {
        this.Z = value;
      }
    }

    public static Point3L Add(Point3L p, Vector3L v)
    {
      return new Point3L(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3L Subtract(Point3L p, Vector3L v)
    {
      return new Point3L(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
    }

    public static Vector3L Subtract(Point3L a, Point3L b)
    {
      return new Vector3L(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public void Add(long x, long y, long z)
    {
      this.X += x;
      this.Y += y;
      this.Z += z;
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Point3L)
        return this.Equals((Point3L) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture));
    }

    public static Point3L Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 3)
        throw new ArgumentException("Illegal vector string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Point3L(long.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), long.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat), long.Parse(strArray[2], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Point3L a, Point3L b)
    {
      if (a.X == b.X && a.Y == b.Y)
        return a.Z == b.Z;
      return false;
    }

    public static bool operator !=(Point3L a, Point3L b)
    {
      if (a.X == b.X && a.Y == b.Y)
        return a.Z != b.Z;
      return true;
    }

    public static Point3L operator +(Point3L p, Vector3L v)
    {
      return new Point3L(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3L operator +(Vector3L v, Point3L p)
    {
      return new Point3L(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3L operator -(Point3L p, Vector3L v)
    {
      return new Point3L(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
    }

    public static Vector3L operator -(Point3L a, Point3L b)
    {
      return new Vector3L(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
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
          case 2:
            return this.Z;
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
          case 2:
            this.Z = value;
            break;
          default:
            throw new IndexOutOfRangeException();
        }
      }
    }

    public static explicit operator long[](Point3L p)
    {
      return new long[3]{ p.X, p.Y, p.Z };
    }

    public static explicit operator Point3L(Point2L p)
    {
      return new Point3L(p.X, p.Y, 0L);
    }

    public static explicit operator Point3L(Vector3L v)
    {
      return new Point3L(v);
    }

    public static explicit operator Point3F(Point3L p)
    {
      return new Point3F((float) p.X, (float) p.Y, (float) p.Z);
    }

    private static Point3L smethod_0(long x, long y, long z)
    {
      return new Point3L(x, y, z);
    }

    public bool Equals(Point3L other)
    {
      if (this.X == other.X && this.Y == other.Y)
        return this.Z == other.Z;
      return false;
    }
  }
}
