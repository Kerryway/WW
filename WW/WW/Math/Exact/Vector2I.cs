// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Vector2I
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
  [TypeConverter(typeof (Vector2IConverter))]
  [Serializable]
  public struct Vector2I : IEquatable<Vector2I>
  {
    public static readonly Vector2I Zero = Vector2I.smethod_0(0, 0);
    public static readonly Vector2I XAxis = Vector2I.smethod_0(1, 0);
    public static readonly Vector2I YAxis = Vector2I.smethod_0(0, 1);
    public int X;
    public int Y;

    [DebuggerStepThrough]
    public Vector2I(int x, int y)
    {
      this.X = x;
      this.Y = y;
    }

    [DebuggerStepThrough]
    public Vector2I(int[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Vector2I(IList<int> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Vector2I(Vector2I from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    [DebuggerStepThrough]
    public Vector2I(Point2I from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    [DisplayName("X")]
    [Obsolete]
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

    public static Vector2I Add(Vector2I u, Vector2I v)
    {
      return new Vector2I(u.X + v.X, u.Y + v.Y);
    }

    public static Vector2I Subtract(Vector2I u, Vector2I v)
    {
      return new Vector2I(u.X - v.X, u.Y - v.Y);
    }

    public static Vector2I Divide(Vector2I v, int s)
    {
      return new Vector2I(v.X / s, v.Y / s);
    }

    public static Vector2I Multiply(Vector2I u, int s)
    {
      return new Vector2I(u.X * s, u.Y * s);
    }

    public static long DotProduct(Vector2I u, Vector2I v)
    {
      return (long) u.X * (long) v.X + (long) u.Y * (long) v.Y;
    }

    public static long CrossProduct(Vector2I u, Vector2I v)
    {
      return (long) u.X * (long) v.Y - (long) u.Y * (long) v.X;
    }

    public static Vector2I Negate(Vector2I v)
    {
      return new Vector2I(-v.X, -v.Y);
    }

    public static double GetAngle(Vector2I a, Vector2I b)
    {
      Vector2I u1 = a;
      Vector2I u2 = new Vector2I(-u1.Y, u1.X);
      long num = Vector2I.DotProduct(u1, b);
      return System.Math.Atan2((double) Vector2I.DotProduct(u2, b), (double) num);
    }

    public double GetLength()
    {
      return System.Math.Sqrt((double) (this.X * this.X + this.Y * this.Y));
    }

    public long GetLengthSquared()
    {
      return (long) this.X * (long) this.X + (long) this.Y * (long) this.Y;
    }

    public double GetAngle()
    {
      return System.Math.Atan2((double) this.Y, (double) this.X);
    }

    public static int CompareAngles(Vector2I a, Vector2I b)
    {
      int quadrant1 = Vector2I.GetQuadrant(a);
      int quadrant2 = Vector2I.GetQuadrant(b);
      if (quadrant1 < quadrant2)
        return -1;
      if (quadrant1 > quadrant2)
        return 1;
      long num = Vector2I.CrossProduct(a, b);
      if (num < 0L)
        return 1;
      return num > 0L ? -1 : 0;
    }

    public static int GetQuadrant(Vector2I v)
    {
      return v.Y >= 0 ? (v.X >= 0 ? 0 : 1) : (v.X >= 0 ? 3 : 2);
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Vector2I)
        return this.Equals((Vector2I) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture));
    }

    public static Vector2I Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 2)
        throw new ArgumentException("Illegal vector string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Vector2I(int.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), int.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Vector2I u, Vector2I v)
    {
      if (u.X == v.X)
        return u.Y == v.Y;
      return false;
    }

    public static bool operator !=(Vector2I u, Vector2I v)
    {
      if (u.X == v.X)
        return u.Y != v.Y;
      return true;
    }

    public static Vector2I operator -(Vector2I v)
    {
      return new Vector2I(-v.X, -v.Y);
    }

    public static Vector2I operator +(Vector2I u, Vector2I v)
    {
      return new Vector2I(u.X + v.X, u.Y + v.Y);
    }

    public static Vector2I operator -(Vector2I u, Vector2I v)
    {
      return new Vector2I(u.X - v.X, u.Y - v.Y);
    }

    public static Vector2I operator *(Vector2I v, int s)
    {
      return new Vector2I(v.X * s, v.Y * s);
    }

    public static Vector2I operator *(int s, Vector2I v)
    {
      return new Vector2I(v.X * s, v.Y * s);
    }

    public static Vector2I operator /(Vector2I v, int s)
    {
      return new Vector2I(v.X / s, v.Y / s);
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

    public static explicit operator Vector2I(Vector3I p)
    {
      return new Vector2I(p.X, p.Y);
    }

    public static explicit operator int[](Vector2I v)
    {
      return new int[2]{ v.X, v.Y };
    }

    public static explicit operator Vector2I(Point2I p)
    {
      return new Vector2I(p);
    }

    public static explicit operator Vector2D(Vector2I v)
    {
      return new Vector2D((double) v.X, (double) v.Y);
    }

    public Vector2D ToVector2D()
    {
      return new Vector2D((double) this.X, (double) this.Y);
    }

    private static Vector2I smethod_0(int x, int y)
    {
      return new Vector2I(x, y);
    }

    public bool Equals(Vector2I other)
    {
      if (this.X == other.X)
        return this.Y == other.Y;
      return false;
    }
  }
}
