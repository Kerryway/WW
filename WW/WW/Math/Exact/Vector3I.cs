// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Vector3I
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
  [TypeConverter(typeof (Vector3IConverter))]
  [Serializable]
  public struct Vector3I : IEquatable<Vector3I>
  {
    public static readonly Vector3I Zero = Vector3I.smethod_0(0, 0, 0);
    public static readonly Vector3I XAxis = Vector3I.smethod_0(1, 0, 0);
    public static readonly Vector3I YAxis = Vector3I.smethod_0(0, 1, 0);
    public static readonly Vector3I ZAxis = Vector3I.smethod_0(0, 0, 1);
    public int X;
    public int Y;
    public int Z;

    [DebuggerStepThrough]
    public Vector3I(int x, int y, int z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Vector3I(Vector2I vector, int z)
    {
      this.X = vector.X;
      this.Y = vector.Y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Vector3I(int[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Vector3I(IList<int> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Vector3I(Vector3I from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [DebuggerStepThrough]
    public Vector3I(Point3I from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

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

    [Obsolete]
    [DisplayName("Z")]
    public int _ZProperty
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

    public static Vector3I Add(Vector3I u, Vector3I v)
    {
      return new Vector3I(u.X + v.X, u.Y + v.Y, u.Z + v.Z);
    }

    public static Vector3I Subtract(Vector3I u, Vector3I v)
    {
      return new Vector3I(u.X - v.X, u.Y - v.Y, u.Z - v.Z);
    }

    public static Vector3I Divide(Vector3I v, int s)
    {
      int num = 1 / s;
      return new Vector3I(v.X * num, v.Y * num, v.Z * num);
    }

    public static Vector3I Multiply(Vector3I u, int s)
    {
      return new Vector3I(u.X * s, u.Y * s, u.Z * s);
    }

    public static long DotProduct(Vector3I u, Vector3I v)
    {
      return (long) u.X * (long) v.X + (long) u.Y * (long) v.Y + (long) u.Z * (long) v.Z;
    }

    public static Vector3I CrossProduct(Vector3I u, Vector3I v)
    {
      return new Vector3I(u.Y * v.Z - u.Z * v.Y, u.Z * v.X - u.X * v.Z, u.X * v.Y - u.Y * v.X);
    }

    public static Vector3I Negate(Vector3I v)
    {
      return new Vector3I(-v.X, -v.Y, -v.Z);
    }

    public static bool AreVectorsPerpendicular(Vector3I a, Vector3I b)
    {
      Vector3I u = a;
      Vector3I v = b;
      if (u.GetLengthSquared() != 0 && v.GetLengthSquared() != 0)
        return System.Math.Abs(Vector3I.DotProduct(u, v)) == 0L;
      return true;
    }

    public static double GetAngle(Vector3I a, Vector3I b)
    {
      double num = System.Math.Sqrt((double) (a.GetLengthSquared() * b.GetLengthSquared()));
      if (num <= 0.0)
        return 0.0;
      double d = (double) Vector3I.DotProduct(a, b) / num;
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

    public int GetLengthSquared()
    {
      return this.X * this.X + this.Y * this.Y + this.Z * this.Z;
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Vector3I)
        return this.Equals((Vector3I) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture));
    }

    public static Vector3I Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 3)
        throw new ArgumentException("Illegal vector string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Vector3I(int.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), int.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat), int.Parse(strArray[2], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Vector3I u, Vector3I v)
    {
      if (u.X == v.X && u.Y == v.Y)
        return u.Z == v.Z;
      return false;
    }

    public static bool operator !=(Vector3I u, Vector3I v)
    {
      if (u.X == v.X && u.Y == v.Y)
        return u.Z != v.Z;
      return true;
    }

    public static Vector3I operator -(Vector3I v)
    {
      return new Vector3I(-v.X, -v.Y, -v.Z);
    }

    public static Vector3I operator +(Vector3I u, Vector3I v)
    {
      return new Vector3I(u.X + v.X, u.Y + v.Y, u.Z + v.Z);
    }

    public static Vector3I operator -(Vector3I u, Vector3I v)
    {
      return new Vector3I(u.X - v.X, u.Y - v.Y, u.Z - v.Z);
    }

    public static Vector3I operator *(Vector3I v, int s)
    {
      return new Vector3I(v.X * s, v.Y * s, v.Z * s);
    }

    public static Vector3I operator *(int s, Vector3I v)
    {
      return new Vector3I(v.X * s, v.Y * s, v.Z * s);
    }

    public static Vector3I operator /(Vector3I v, int s)
    {
      return new Vector3I(v.X / s, v.Y / s, v.Z / s);
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

    public static explicit operator int[](Vector3I v)
    {
      return new int[3]{ v.X, v.Y, v.Z };
    }

    public static explicit operator Vector3I(Vector2I v)
    {
      return new Vector3I(v.X, v.Y, 0);
    }

    public static explicit operator Vector3I(Point3I p)
    {
      return new Vector3I(p);
    }

    public static explicit operator Vector3F(Vector3I v)
    {
      return new Vector3F((float) v.X, (float) v.Y, (float) v.Z);
    }

    private static Vector3I smethod_0(int x, int y, int z)
    {
      return new Vector3I(x, y, z);
    }

    public bool Equals(Vector3I v)
    {
      if (this.X == v.X && this.Y == v.Y)
        return this.Z == v.Z;
      return false;
    }
  }
}
