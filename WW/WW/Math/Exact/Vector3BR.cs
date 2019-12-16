// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Vector3BR
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
  [TypeConverter(typeof (Vector3BRConverter))]
  [Serializable]
  public struct Vector3BR : IEquatable<Vector3BR>
  {
    public static readonly Vector3BR Zero = Vector3BR.smethod_0(BigRational.Zero, BigRational.Zero, BigRational.Zero);
    public static readonly Vector3BR XAxis = Vector3BR.smethod_0(BigRational.One, BigRational.Zero, BigRational.Zero);
    public static readonly Vector3BR YAxis = Vector3BR.smethod_0(BigRational.Zero, BigRational.One, BigRational.Zero);
    public static readonly Vector3BR ZAxis = Vector3BR.smethod_0(BigRational.Zero, BigRational.Zero, BigRational.One);
    public BigRational X;
    public BigRational Y;
    public BigRational Z;

    [DebuggerStepThrough]
    public Vector3BR(BigRational x, BigRational y, BigRational z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Vector3BR(double x, double y, double z)
    {
      this.X = (BigRational) x;
      this.Y = (BigRational) y;
      this.Z = (BigRational) z;
    }

    [DebuggerStepThrough]
    public Vector3BR(Vector2BR vector, BigRational z)
    {
      this.X = vector.X;
      this.Y = vector.Y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Vector3BR(BigRational[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Vector3BR(IList<BigRational> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Vector3BR(Vector3BR from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [DebuggerStepThrough]
    public Vector3BR(Point3BR from)
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

    [DisplayName("Z")]
    [Obsolete]
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

    public static Vector3BR Add(Vector3BR u, Vector3BR v)
    {
      return new Vector3BR(u.X + v.X, u.Y + v.Y, u.Z + v.Z);
    }

    public static Vector3BR Subtract(Vector3BR u, Vector3BR v)
    {
      return new Vector3BR(u.X - v.X, u.Y - v.Y, u.Z - v.Z);
    }

    public static Vector3BR Divide(Vector3BR v, BigRational s)
    {
      BigRational bigRational = s.Invert();
      return new Vector3BR(v.X * bigRational, v.Y * bigRational, v.Z * bigRational);
    }

    public static Vector3BR Multiply(Vector3BR u, BigRational s)
    {
      return new Vector3BR(u.X * s, u.Y * s, u.Z * s);
    }

    public static BigRational DotProduct(Vector3BR u, Vector3BR v)
    {
      return u.X * v.X + u.Y * v.Y + u.Z * v.Z;
    }

    public static Vector3BR CrossProduct(Vector3BR u, Vector3BR v)
    {
      return new Vector3BR(u.Y * v.Z - u.Z * v.Y, u.Z * v.X - u.X * v.Z, u.X * v.Y - u.Y * v.X);
    }

    public static Vector3BR Negate(Vector3BR v)
    {
      return new Vector3BR(-v.X, -v.Y, -v.Z);
    }

    public static bool AreVectorsPerpendicular(Vector3BR a, Vector3BR b)
    {
      Vector3BR u = a;
      Vector3BR v = b;
      if (!u.IsZero && !v.IsZero)
        return Vector3BR.DotProduct(u, v).IsZero;
      return true;
    }

    public static Vector3BR OrthogonalProjection(Vector3BR a, Vector3BR b)
    {
      Vector3BR v = b * Vector3BR.DotProduct(b, a) / b.GetLengthSquared();
      return Vector3BR.Subtract(a, v);
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
      if (other is Vector3BR)
        return this.Equals((Vector3BR) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture));
    }

    public static bool operator ==(Vector3BR u, Vector3BR v)
    {
      if (u.X == v.X && u.Y == v.Y)
        return u.Z == v.Z;
      return false;
    }

    public static bool operator !=(Vector3BR u, Vector3BR v)
    {
      if (u.X == v.X && u.Y == v.Y)
        return !(u.Z == v.Z);
      return true;
    }

    public static Vector3BR operator -(Vector3BR v)
    {
      return new Vector3BR(-v.X, -v.Y, -v.Z);
    }

    public static Vector3BR operator +(Vector3BR u, Vector3BR v)
    {
      return new Vector3BR(u.X + v.X, u.Y + v.Y, u.Z + v.Z);
    }

    public static Vector3BR operator -(Vector3BR u, Vector3BR v)
    {
      return new Vector3BR(u.X - v.X, u.Y - v.Y, u.Z - v.Z);
    }

    public static Vector3BR operator *(Vector3BR v, BigRational s)
    {
      return new Vector3BR(v.X * s, v.Y * s, v.Z * s);
    }

    public static Vector3BR operator *(BigRational s, Vector3BR v)
    {
      return new Vector3BR(v.X * s, v.Y * s, v.Z * s);
    }

    public static Vector3BR operator /(Vector3BR v, BigRational s)
    {
      return new Vector3BR(v.X / s, v.Y / s, v.Z / s);
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

    public static explicit operator BigRational[](Vector3BR v)
    {
      return new BigRational[3]{ v.X, v.Y, v.Z };
    }

    public static explicit operator Vector3BR(Vector2BR v)
    {
      return new Vector3BR(v.X, v.Y, BigRational.Zero);
    }

    public static explicit operator Vector3BR(Vector4D v)
    {
      return new Vector3BR(v.X, v.Y, v.Z);
    }

    public static explicit operator Vector3BR(Point3BR p)
    {
      return new Vector3BR(p);
    }

    public static explicit operator Vector3F(Vector3BR v)
    {
      return new Vector3F((float) (double) v.X, (float) (double) v.Y, (float) (double) v.Z);
    }

    private static Vector3BR smethod_0(BigRational x, BigRational y, BigRational z)
    {
      return new Vector3BR(x, y, z);
    }

    public bool Equals(Vector3BR v)
    {
      if (this.X == v.X && this.Y == v.Y)
        return this.Z == v.Z;
      return false;
    }
  }
}
