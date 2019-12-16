// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Vector3L
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
  [TypeConverter(typeof (Vector3LConverter))]
  [Serializable]
  public struct Vector3L : IEquatable<Vector3L>
  {
    public static readonly Vector3L Zero = Vector3L.smethod_0(0L, 0L, 0L);
    public static readonly Vector3L XAxis = Vector3L.smethod_0(1L, 0L, 0L);
    public static readonly Vector3L YAxis = Vector3L.smethod_0(0L, 1L, 0L);
    public static readonly Vector3L ZAxis = Vector3L.smethod_0(0L, 0L, 1L);
    public long X;
    public long Y;
    public long Z;

    [DebuggerStepThrough]
    public Vector3L(long x, long y, long z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Vector3L(Vector2L vector, long z)
    {
      this.X = vector.X;
      this.Y = vector.Y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Vector3L(long[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Vector3L(IList<long> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Vector3L(Vector3L from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [DebuggerStepThrough]
    public Vector3L(Point3L from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
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

    public static Vector3L Add(Vector3L u, Vector3L v)
    {
      return new Vector3L(u.X + v.X, u.Y + v.Y, u.Z + v.Z);
    }

    public static Vector3L Subtract(Vector3L u, Vector3L v)
    {
      return new Vector3L(u.X - v.X, u.Y - v.Y, u.Z - v.Z);
    }

    public static Vector3L Divide(Vector3L v, long s)
    {
      long num = 1L / s;
      return new Vector3L(v.X * num, v.Y * num, v.Z * num);
    }

    public static Vector3L Multiply(Vector3L u, long s)
    {
      return new Vector3L(u.X * s, u.Y * s, u.Z * s);
    }

    public static long DotProduct(Vector3L u, Vector3L v)
    {
      return u.X * v.X + u.Y * v.Y + u.Z * v.Z;
    }

    public static Vector3L CrossProduct(Vector3L u, Vector3L v)
    {
      return new Vector3L(u.Y * v.Z - u.Z * v.Y, u.Z * v.X - u.X * v.Z, u.X * v.Y - u.Y * v.X);
    }

    public static Vector3L Negate(Vector3L v)
    {
      return new Vector3L(-v.X, -v.Y, -v.Z);
    }

    public static bool AreVectorsPerpendicular(Vector3L a, Vector3L b)
    {
      Vector3L u = a;
      Vector3L v = b;
      if (u.GetLengthSquared() != 0L && v.GetLengthSquared() != 0L)
        return System.Math.Abs(Vector3L.DotProduct(u, v)) == 0L;
      return true;
    }

    public static double GetAngle(Vector3L a, Vector3L b)
    {
      double num1 = (double) Vector3L.DotProduct(a, b);
      double num2 = System.Math.Sqrt((double) (a.GetLengthSquared() * b.GetLengthSquared()));
      if (num2 <= 0.0)
        return 0.0;
      double d = num1 / num2;
      if (d > 1.0)
        return 0.0;
      if (d < -1.0)
        return System.Math.PI;
      return System.Math.Acos(d);
    }

    public double GetLength()
    {
      return System.Math.Sqrt((double) (this.X * this.X + this.Y * this.Y + this.Z * this.Z));
    }

    public long GetLengthSquared()
    {
      return this.X * this.X + this.Y * this.Y + this.Z * this.Z;
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Vector3L)
        return this.Equals((Vector3L) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture));
    }

    public static Vector3L Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 3)
        throw new ArgumentException("Illegal vector string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Vector3L(long.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), long.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat), long.Parse(strArray[2], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Vector3L u, Vector3L v)
    {
      if (u.X == v.X && u.Y == v.Y)
        return u.Z == v.Z;
      return false;
    }

    public static bool operator !=(Vector3L u, Vector3L v)
    {
      if (u.X == v.X && u.Y == v.Y)
        return u.Z != v.Z;
      return true;
    }

    public static Vector3L operator -(Vector3L v)
    {
      return new Vector3L(-v.X, -v.Y, -v.Z);
    }

    public static Vector3L operator +(Vector3L u, Vector3L v)
    {
      return new Vector3L(u.X + v.X, u.Y + v.Y, u.Z + v.Z);
    }

    public static Vector3L operator -(Vector3L u, Vector3L v)
    {
      return new Vector3L(u.X - v.X, u.Y - v.Y, u.Z - v.Z);
    }

    public static Vector3L operator *(Vector3L v, long s)
    {
      return new Vector3L(v.X * s, v.Y * s, v.Z * s);
    }

    public static Vector3L operator *(long s, Vector3L v)
    {
      return new Vector3L(v.X * s, v.Y * s, v.Z * s);
    }

    public static Vector3L operator /(Vector3L v, long s)
    {
      return new Vector3L(v.X / s, v.Y / s, v.Z / s);
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

    public static explicit operator long[](Vector3L v)
    {
      return new long[3]{ v.X, v.Y, v.Z };
    }

    public static explicit operator Vector3L(Vector2L v)
    {
      return new Vector3L(v.X, v.Y, 0L);
    }

    public static explicit operator Vector3L(Point3L p)
    {
      return new Vector3L(p);
    }

    public static explicit operator Vector3F(Vector3L v)
    {
      return new Vector3F((float) v.X, (float) v.Y, (float) v.Z);
    }

    private static Vector3L smethod_0(long x, long y, long z)
    {
      return new Vector3L(x, y, z);
    }

    public bool Equals(Vector3L v)
    {
      if (this.X == v.X && this.Y == v.Y)
        return this.Z == v.Z;
      return false;
    }
  }
}
