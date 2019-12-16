// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Vector2L
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
  [TypeConverter(typeof (Vector2LConverter))]
  [Serializable]
  public struct Vector2L : IEquatable<Vector2L>
  {
    public static readonly Vector2L Zero = Vector2L.smethod_0(0L, 0L);
    public static readonly Vector2L XAxis = Vector2L.smethod_0(1L, 0L);
    public static readonly Vector2L YAxis = Vector2L.smethod_0(0L, 1L);
    public long X;
    public long Y;

    [DebuggerStepThrough]
    public Vector2L(long x, long y)
    {
      this.X = x;
      this.Y = y;
    }

    [DebuggerStepThrough]
    public Vector2L(long[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Vector2L(IList<long> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Vector2L(Vector2L from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    [DebuggerStepThrough]
    public Vector2L(Point2L from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    [DisplayName("X")]
    [Obsolete]
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

    [Obsolete]
    [DisplayName("Y")]
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

    public static Vector2L Add(Vector2L u, Vector2L v)
    {
      return new Vector2L(u.X + v.X, u.Y + v.Y);
    }

    public static Vector2L Subtract(Vector2L u, Vector2L v)
    {
      return new Vector2L(u.X - v.X, u.Y - v.Y);
    }

    public static Vector2L Divide(Vector2L v, long s)
    {
      return new Vector2L(v.X / s, v.Y / s);
    }

    public static Vector2L Multiply(Vector2L u, long s)
    {
      return new Vector2L(u.X * s, u.Y * s);
    }

    public static long DotProduct(Vector2L u, Vector2L v)
    {
      return u.X * v.X + u.Y * v.Y;
    }

    public static long CrossProduct(Vector2L u, Vector2L v)
    {
      return u.X * v.Y - u.Y * v.X;
    }

    public static Vector2L Negate(Vector2L v)
    {
      return new Vector2L(-v.X, -v.Y);
    }

    public static double GetAngle(Vector2L a, Vector2L b)
    {
      Vector2L u1 = a;
      Vector2L u2 = new Vector2L(-u1.Y, u1.X);
      long num = Vector2L.DotProduct(u1, b);
      return System.Math.Atan2((double) Vector2L.DotProduct(u2, b), (double) num);
    }

    public double GetLength()
    {
      return System.Math.Sqrt((double) (this.X * this.X + this.Y * this.Y));
    }

    public long GetLengthSquared()
    {
      return this.X * this.X + this.Y * this.Y;
    }

    public double GetAngle()
    {
      return System.Math.Atan2((double) this.Y, (double) this.X);
    }

    public static int CompareAngles(Vector2L a, Vector2L b)
    {
      int quadrant1 = Vector2L.GetQuadrant(a);
      int quadrant2 = Vector2L.GetQuadrant(b);
      if (quadrant1 < quadrant2)
        return -1;
      if (quadrant1 > quadrant2)
        return 1;
      long num = Vector2L.CrossProduct(a, b);
      if (num < 0L)
        return 1;
      return num > 0L ? -1 : 0;
    }

    public static int GetQuadrant(Vector2L v)
    {
      return v.Y >= 0L ? (v.X >= 0L ? 0 : 1) : (v.X >= 0L ? 3 : 2);
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Vector2L)
        return this.Equals((Vector2L) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture));
    }

    public static Vector2L Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 2)
        throw new ArgumentException("Illegal vector string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Vector2L(long.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), long.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Vector2L u, Vector2L v)
    {
      if (u.X == v.X)
        return u.Y == v.Y;
      return false;
    }

    public static bool operator !=(Vector2L u, Vector2L v)
    {
      if (u.X == v.X)
        return u.Y != v.Y;
      return true;
    }

    public static Vector2L operator -(Vector2L v)
    {
      return new Vector2L(-v.X, -v.Y);
    }

    public static Vector2L operator +(Vector2L u, Vector2L v)
    {
      return new Vector2L(u.X + v.X, u.Y + v.Y);
    }

    public static Vector2L operator -(Vector2L u, Vector2L v)
    {
      return new Vector2L(u.X - v.X, u.Y - v.Y);
    }

    public static Vector2L operator *(Vector2L v, long s)
    {
      return new Vector2L(v.X * s, v.Y * s);
    }

    public static Vector2L operator *(long s, Vector2L v)
    {
      return new Vector2L(v.X * s, v.Y * s);
    }

    public static Vector2L operator /(Vector2L v, long s)
    {
      return new Vector2L(v.X / s, v.Y / s);
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

    public static explicit operator Vector2L(Vector2I p)
    {
      return new Vector2L((long) p.X, (long) p.Y);
    }

    public static explicit operator Vector2L(Vector3L p)
    {
      return new Vector2L(p.X, p.Y);
    }

    public static explicit operator long[](Vector2L v)
    {
      return new long[2]{ v.X, v.Y };
    }

    public static explicit operator Vector2L(Point2L p)
    {
      return new Vector2L(p);
    }

    private static Vector2L smethod_0(long x, long y)
    {
      return new Vector2L(x, y);
    }

    public bool Equals(Vector2L other)
    {
      if (this.X == other.X)
        return this.Y == other.Y;
      return false;
    }
  }
}
