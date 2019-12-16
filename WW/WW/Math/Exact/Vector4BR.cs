// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Vector4BR
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
  [TypeConverter(typeof (Vector4BRConverter))]
  [Serializable]
  public struct Vector4BR : IEquatable<Vector4BR>
  {
    public static readonly Vector4BR Zero = Vector4BR.smethod_0(BigRational.Zero, BigRational.Zero, BigRational.Zero, BigRational.Zero);
    public static readonly Vector4BR XAxis = Vector4BR.smethod_0(BigRational.One, BigRational.Zero, BigRational.Zero, BigRational.Zero);
    public static readonly Vector4BR YAxis = Vector4BR.smethod_0(BigRational.Zero, BigRational.One, BigRational.Zero, BigRational.Zero);
    public static readonly Vector4BR ZAxis = Vector4BR.smethod_0(BigRational.Zero, BigRational.Zero, BigRational.One, BigRational.Zero);
    public static readonly Vector4BR WAxis = Vector4BR.smethod_0(BigRational.Zero, BigRational.Zero, BigRational.Zero, BigRational.One);
    public BigRational X;
    public BigRational Y;
    public BigRational Z;
    public BigRational W;

    [DebuggerStepThrough]
    public Vector4BR(BigRational x, BigRational y, BigRational z, BigRational w)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
      this.W = w;
    }

    [DebuggerStepThrough]
    public Vector4BR(double x, double y, double z, double w)
    {
      this.X = (BigRational) x;
      this.Y = (BigRational) y;
      this.Z = (BigRational) z;
      this.W = (BigRational) w;
    }

    [DebuggerStepThrough]
    public Vector4BR(BigRational[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
      this.W = coordinates[3];
    }

    [DebuggerStepThrough]
    public Vector4BR(IList<BigRational> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
      this.W = coordinates[3];
    }

    [DebuggerStepThrough]
    public Vector4BR(Vector4BR from)
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
    public BigRational _XProperty
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
    public BigRational _YProperty
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
    public BigRational _ZProperty
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

    public static Vector4BR Add(Vector4BR u, Vector4BR v)
    {
      return new Vector4BR(u.X + v.X, u.Y + v.Y, u.Z + v.Z, u.W + v.W);
    }

    public static Vector4BR Subtract(Vector4BR u, Vector4BR v)
    {
      return new Vector4BR(u.X - v.X, u.Y - v.Y, u.Z - v.Z, u.W - v.W);
    }

    public static Vector4BR Divide(Vector4BR v, BigRational s)
    {
      BigRational bigRational = s.Invert();
      return new Vector4BR(v.X * bigRational, v.Y * bigRational, v.Z * bigRational, v.W * bigRational);
    }

    public static Vector4BR Multiply(Vector4BR u, BigRational s)
    {
      return new Vector4BR(u.X * s, u.Y * s, u.Z * s, u.W * s);
    }

    public static BigRational DotProduct(Vector4BR u, Vector4BR v)
    {
      return u.X * v.X + u.Y * v.Y + u.Z * v.Z + u.W * v.W;
    }

    public static Vector4BR Negate(Vector4BR v)
    {
      return new Vector4BR(-v.X, -v.Y, -v.Z, -v.W);
    }

    public static bool AreVectorsPerpendicular(Vector4BR a, Vector4BR b)
    {
      Vector4BR u = a;
      Vector4BR v = b;
      if (!u.IsZero && !v.IsZero)
        return Vector4BR.DotProduct(u, v).IsZero;
      return true;
    }

    public static Vector4BR OrthogonalProjection(Vector4BR a, Vector4BR b)
    {
      Vector4BR v = b * Vector4BR.DotProduct(b, a) / b.GetLengthSquared();
      return Vector4BR.Subtract(a, v);
    }

    public BigRational GetLengthSquared()
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
      if (other is Vector4BR)
        return this.Equals((Vector4BR) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture));
    }

    public static bool operator ==(Vector4BR u, Vector4BR v)
    {
      if (u.X == v.X && u.Y == v.Y)
        return u.Z == v.Z;
      return false;
    }

    public static bool operator !=(Vector4BR u, Vector4BR v)
    {
      if (u.X == v.X && u.Y == v.Y)
        return !(u.Z == v.Z);
      return true;
    }

    public static Vector4BR operator -(Vector4BR v)
    {
      return new Vector4BR(-v.X, -v.Y, -v.Z, -v.W);
    }

    public static Vector4BR operator +(Vector4BR u, Vector4BR v)
    {
      return new Vector4BR(u.X + v.X, u.Y + v.Y, u.Z + v.Z, u.W + v.W);
    }

    public static Vector4BR operator -(Vector4BR u, Vector4BR v)
    {
      return new Vector4BR(u.X - v.X, u.Y - v.Y, u.Z - v.Z, u.W - v.W);
    }

    public static Vector4BR operator *(Vector4BR v, BigRational s)
    {
      return new Vector4BR(v.X * s, v.Y * s, v.Z * s, v.W * s);
    }

    public static Vector4BR operator *(BigRational s, Vector4BR v)
    {
      return new Vector4BR(v.X * s, v.Y * s, v.Z * s, v.W * s);
    }

    public static Vector4BR operator /(Vector4BR v, BigRational s)
    {
      return new Vector4BR(v.X / s, v.Y / s, v.Z / s, v.W / s);
    }

    public BigRational this[int index]
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

    public static explicit operator BigRational[](Vector4BR v)
    {
      return new BigRational[3]{ v.X, v.Y, v.Z };
    }

    public static explicit operator Vector4BR(Vector2BR v)
    {
      return new Vector4BR(v.X, v.Y, BigRational.Zero, BigRational.Zero);
    }

    public static explicit operator Vector4BR(Vector4D v)
    {
      return new Vector4BR(v.X, v.Y, v.Z, v.W);
    }

    public static explicit operator Vector4BR(Point3BR p)
    {
      return new Vector4BR(p.X, p.Y, p.Z, BigRational.One);
    }

    public static explicit operator Vector3F(Vector4BR v)
    {
      return new Vector3F((float) (double) v.X, (float) (double) v.Y, (float) (double) v.Z);
    }

    private static Vector4BR smethod_0(
      BigRational x,
      BigRational y,
      BigRational z,
      BigRational w)
    {
      return new Vector4BR(x, y, z, w);
    }

    public bool Equals(Vector4BR v)
    {
      if (this.X == v.X && this.Y == v.Y)
        return this.Z == v.Z;
      return false;
    }
  }
}
