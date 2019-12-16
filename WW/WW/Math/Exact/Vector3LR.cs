// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Vector3LR
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
  [TypeConverter(typeof (Vector3LRConverter))]
  [Serializable]
  public struct Vector3LR : IEquatable<Vector3LR>
  {
    public static readonly Vector3LR Zero = Vector3LR.smethod_0(LongRational.Zero, LongRational.Zero, LongRational.Zero);
    public static readonly Vector3LR XAxis = Vector3LR.smethod_0(LongRational.One, LongRational.Zero, LongRational.Zero);
    public static readonly Vector3LR YAxis = Vector3LR.smethod_0(LongRational.Zero, LongRational.One, LongRational.Zero);
    public static readonly Vector3LR ZAxis = Vector3LR.smethod_0(LongRational.Zero, LongRational.Zero, LongRational.One);
    public LongRational X;
    public LongRational Y;
    public LongRational Z;

    [DebuggerStepThrough]
    public Vector3LR(LongRational x, LongRational y, LongRational z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Vector3LR(double x, double y, double z)
    {
      this.X = (LongRational) x;
      this.Y = (LongRational) y;
      this.Z = (LongRational) z;
    }

    [DebuggerStepThrough]
    public Vector3LR(int x, int y, int z)
    {
      this.X = new LongRational(x);
      this.Y = new LongRational(y);
      this.Z = new LongRational(z);
    }

    [DebuggerStepThrough]
    public Vector3LR(Vector2LR vector, LongRational z)
    {
      this.X = vector.X;
      this.Y = vector.Y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Vector3LR(LongRational[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Vector3LR(IList<LongRational> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Vector3LR(Vector3LR from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [DebuggerStepThrough]
    public Vector3LR(Point3LR from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    public bool IsZero
    {
      get
      {
        if (this.X.IsZero && this.Y.IsZero)
          return this.Z.IsZero;
        return false;
      }
    }

    [Obsolete]
    [DisplayName("X")]
    public LongRational _XProperty
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
    public LongRational _YProperty
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
    public LongRational _ZProperty
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

    public static Vector3LR Add(Vector3LR u, Vector3LR v)
    {
      return new Vector3LR(u.X + v.X, u.Y + v.Y, u.Z + v.Z);
    }

    public static Vector3LR Subtract(Vector3LR u, Vector3LR v)
    {
      return new Vector3LR(u.X - v.X, u.Y - v.Y, u.Z - v.Z);
    }

    public static Vector3LR Divide(Vector3LR v, LongRational s)
    {
      LongRational longRational = s.Invert();
      return new Vector3LR(v.X * longRational, v.Y * longRational, v.Z * longRational);
    }

    public static Vector3LR Multiply(Vector3LR u, LongRational s)
    {
      return new Vector3LR(u.X * s, u.Y * s, u.Z * s);
    }

    public static LongRational DotProduct(Vector3LR u, Vector3LR v)
    {
      return u.X * v.X + u.Y * v.Y + u.Z * v.Z;
    }

    public static Vector3LR CrossProduct(Vector3LR u, Vector3LR v)
    {
      return new Vector3LR(u.Y * v.Z - u.Z * v.Y, u.Z * v.X - u.X * v.Z, u.X * v.Y - u.Y * v.X);
    }

    public static Vector3LR Negate(Vector3LR v)
    {
      return new Vector3LR(-v.X, -v.Y, -v.Z);
    }

    public static bool AreVectorsPerpendicular(Vector3LR a, Vector3LR b)
    {
      Vector3LR u = a;
      Vector3LR v = b;
      if (!u.IsZero && !v.IsZero)
        return Vector3LR.DotProduct(u, v).IsZero;
      return true;
    }

    public static Vector3LR OrthogonalProjection(Vector3LR a, Vector3LR b)
    {
      Vector3LR v = b * Vector3LR.DotProduct(b, a) / b.GetLengthSquared();
      return Vector3LR.Subtract(a, v);
    }

    public LongRational GetLengthSquared()
    {
      return this.X.Square() + this.Y.Square() + this.Z.Square();
    }

    public bool ContainsNaN()
    {
      if (!this.X.IsNaN && !this.Y.IsNaN)
        return this.Z.IsNaN;
      return true;
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Vector3LR)
        return this.Equals((Vector3LR) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture));
    }

    public static bool operator ==(Vector3LR u, Vector3LR v)
    {
      if (u.X == v.X && u.Y == v.Y)
        return u.Z == v.Z;
      return false;
    }

    public static bool operator !=(Vector3LR u, Vector3LR v)
    {
      if (u.X == v.X && u.Y == v.Y)
        return !(u.Z == v.Z);
      return true;
    }

    public static Vector3LR operator -(Vector3LR v)
    {
      return new Vector3LR(-v.X, -v.Y, -v.Z);
    }

    public static Vector3LR operator +(Vector3LR u, Vector3LR v)
    {
      return new Vector3LR(u.X + v.X, u.Y + v.Y, u.Z + v.Z);
    }

    public static Vector3LR operator -(Vector3LR u, Vector3LR v)
    {
      return new Vector3LR(u.X - v.X, u.Y - v.Y, u.Z - v.Z);
    }

    public static Vector3LR operator *(Vector3LR v, LongRational s)
    {
      return new Vector3LR(v.X * s, v.Y * s, v.Z * s);
    }

    public static Vector3LR operator *(LongRational s, Vector3LR v)
    {
      return new Vector3LR(v.X * s, v.Y * s, v.Z * s);
    }

    public static Vector3LR operator /(Vector3LR v, LongRational s)
    {
      return new Vector3LR(v.X / s, v.Y / s, v.Z / s);
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

    public static explicit operator LongRational[](Vector3LR v)
    {
      return new LongRational[3]{ v.X, v.Y, v.Z };
    }

    public static explicit operator Vector3LR(Vector2LR v)
    {
      return new Vector3LR(v.X, v.Y, LongRational.Zero);
    }

    public static explicit operator Vector3LR(Vector4D v)
    {
      return new Vector3LR(v.X, v.Y, v.Z);
    }

    public static explicit operator Vector3LR(Point3LR p)
    {
      return new Vector3LR(p);
    }

    public static explicit operator Vector3F(Vector3LR v)
    {
      return new Vector3F((float) (double) v.X, (float) (double) v.Y, (float) (double) v.Z);
    }

    private static Vector3LR smethod_0(LongRational x, LongRational y, LongRational z)
    {
      return new Vector3LR(x, y, z);
    }

    public bool Equals(Vector3LR v)
    {
      if (this.X == v.X && this.Y == v.Y)
        return this.Z == v.Z;
      return false;
    }
  }
}
