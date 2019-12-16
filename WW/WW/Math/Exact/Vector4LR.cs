// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Vector4LR
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
  [TypeConverter(typeof (Vector4LRConverter))]
  [Serializable]
  public struct Vector4LR : IEquatable<Vector4LR>
  {
    public static readonly Vector4LR Zero = Vector4LR.smethod_0(LongRational.Zero, LongRational.Zero, LongRational.Zero, LongRational.Zero);
    public static readonly Vector4LR XAxis = Vector4LR.smethod_0(LongRational.One, LongRational.Zero, LongRational.Zero, LongRational.Zero);
    public static readonly Vector4LR YAxis = Vector4LR.smethod_0(LongRational.Zero, LongRational.One, LongRational.Zero, LongRational.Zero);
    public static readonly Vector4LR ZAxis = Vector4LR.smethod_0(LongRational.Zero, LongRational.Zero, LongRational.One, LongRational.Zero);
    public static readonly Vector4LR WAxis = Vector4LR.smethod_0(LongRational.Zero, LongRational.Zero, LongRational.Zero, LongRational.One);
    public LongRational X;
    public LongRational Y;
    public LongRational Z;
    public LongRational W;

    [DebuggerStepThrough]
    public Vector4LR(LongRational x, LongRational y, LongRational z, LongRational w)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
      this.W = w;
    }

    [DebuggerStepThrough]
    public Vector4LR(double x, double y, double z, double w)
    {
      this.X = (LongRational) x;
      this.Y = (LongRational) y;
      this.Z = (LongRational) z;
      this.W = (LongRational) w;
    }

    [DebuggerStepThrough]
    public Vector4LR(int x, int y, int z, int w)
    {
      this.X = new LongRational(x);
      this.Y = new LongRational(y);
      this.Z = new LongRational(z);
      this.W = new LongRational(w);
    }

    [DebuggerStepThrough]
    public Vector4LR(LongRational[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
      this.W = coordinates[3];
    }

    [DebuggerStepThrough]
    public Vector4LR(IList<LongRational> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
      this.W = coordinates[3];
    }

    [DebuggerStepThrough]
    public Vector4LR(Vector4LR from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
      this.W = from.W;
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

    public static Vector4LR Add(Vector4LR u, Vector4LR v)
    {
      return new Vector4LR(u.X + v.X, u.Y + v.Y, u.Z + v.Z, u.W + v.W);
    }

    public static Vector4LR Subtract(Vector4LR u, Vector4LR v)
    {
      return new Vector4LR(u.X - v.X, u.Y - v.Y, u.Z - v.Z, u.W - v.W);
    }

    public static Vector4LR Divide(Vector4LR v, LongRational s)
    {
      LongRational longRational = s.Invert();
      return new Vector4LR(v.X * longRational, v.Y * longRational, v.Z * longRational, v.W * longRational);
    }

    public static Vector4LR Multiply(Vector4LR u, LongRational s)
    {
      return new Vector4LR(u.X * s, u.Y * s, u.Z * s, u.W * s);
    }

    public static LongRational DotProduct(Vector4LR u, Vector4LR v)
    {
      return u.X * v.X + u.Y * v.Y + u.Z * v.Z + u.W * v.W;
    }

    public static Vector4LR Negate(Vector4LR v)
    {
      return new Vector4LR(-v.X, -v.Y, -v.Z, -v.W);
    }

    public static bool AreVectorsPerpendicular(Vector4LR a, Vector4LR b)
    {
      Vector4LR u = a;
      Vector4LR v = b;
      if (!u.IsZero && !v.IsZero)
        return Vector4LR.DotProduct(u, v).IsZero;
      return true;
    }

    public static Vector4LR OrthogonalProjection(Vector4LR a, Vector4LR b)
    {
      Vector4LR v = b * Vector4LR.DotProduct(b, a) / b.GetLengthSquared();
      return Vector4LR.Subtract(a, v);
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
      if (other is Vector4LR)
        return this.Equals((Vector4LR) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture));
    }

    public static bool operator ==(Vector4LR u, Vector4LR v)
    {
      if (u.X == v.X && u.Y == v.Y)
        return u.Z == v.Z;
      return false;
    }

    public static bool operator !=(Vector4LR u, Vector4LR v)
    {
      if (u.X == v.X && u.Y == v.Y)
        return !(u.Z == v.Z);
      return true;
    }

    public static Vector4LR operator -(Vector4LR v)
    {
      return new Vector4LR(-v.X, -v.Y, -v.Z, -v.W);
    }

    public static Vector4LR operator +(Vector4LR u, Vector4LR v)
    {
      return new Vector4LR(u.X + v.X, u.Y + v.Y, u.Z + v.Z, u.W + v.W);
    }

    public static Vector4LR operator -(Vector4LR u, Vector4LR v)
    {
      return new Vector4LR(u.X - v.X, u.Y - v.Y, u.Z - v.Z, u.W - v.W);
    }

    public static Vector4LR operator *(Vector4LR v, LongRational s)
    {
      return new Vector4LR(v.X * s, v.Y * s, v.Z * s, v.W * s);
    }

    public static Vector4LR operator *(LongRational s, Vector4LR v)
    {
      return new Vector4LR(v.X * s, v.Y * s, v.Z * s, v.W * s);
    }

    public static Vector4LR operator /(Vector4LR v, LongRational s)
    {
      return new Vector4LR(v.X / s, v.Y / s, v.Z / s, v.W / s);
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

    public static explicit operator LongRational[](Vector4LR v)
    {
      return new LongRational[3]{ v.X, v.Y, v.Z };
    }

    public static explicit operator Vector4LR(Vector2LR v)
    {
      return new Vector4LR(v.X, v.Y, LongRational.Zero, LongRational.Zero);
    }

    public static explicit operator Vector4LR(Vector4D v)
    {
      return new Vector4LR(v.X, v.Y, v.Z, v.W);
    }

    public static explicit operator Vector4LR(Point3LR p)
    {
      return new Vector4LR(p.X, p.Y, p.Z, LongRational.One);
    }

    public static explicit operator Vector3F(Vector4LR v)
    {
      return new Vector3F((float) (double) v.X, (float) (double) v.Y, (float) (double) v.Z);
    }

    private static Vector4LR smethod_0(
      LongRational x,
      LongRational y,
      LongRational z,
      LongRational w)
    {
      return new Vector4LR(x, y, z, w);
    }

    public bool Equals(Vector4LR v)
    {
      if (this.X == v.X && this.Y == v.Y)
        return this.Z == v.Z;
      return false;
    }
  }
}
