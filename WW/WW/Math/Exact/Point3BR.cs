// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Point3BR
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
  [TypeConverter(typeof (Point3BRConverter))]
  [Serializable]
  public struct Point3BR : IEquatable<Point3BR>
  {
    public static readonly Point3BR Zero = Point3BR.smethod_0(BigRational.Zero, BigRational.Zero, BigRational.Zero);
    public BigRational X;
    public BigRational Y;
    public BigRational Z;

    [DebuggerStepThrough]
    public Point3BR(BigRational x, BigRational y, BigRational z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Point3BR(double x, double y, double z)
    {
      this.X = (BigRational) x;
      this.Y = (BigRational) y;
      this.Z = (BigRational) z;
    }

    [DebuggerStepThrough]
    public Point3BR(Point2BR point, BigRational z)
    {
      this.X = point.X;
      this.Y = point.Y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Point3BR(BigRational[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Point3BR(IList<BigRational> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Point3BR(Point3BR from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [DebuggerStepThrough]
    public Point3BR(Vector3BR from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [DisplayName("X")]
    [Obsolete]
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

    [Obsolete]
    [DisplayName("Y")]
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

    public static Point3BR Add(Point3BR p, Vector3BR v)
    {
      return new Point3BR(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3BR Subtract(Point3BR p, Vector3BR v)
    {
      return new Point3BR(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
    }

    public static Vector3BR Subtract(Point3BR a, Point3BR b)
    {
      return new Vector3BR(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Point3BR GetMidPoint(Point3BR a, Point3BR b)
    {
      return new Point3BR((a.X + b.X).DivideByTwo(), (a.Y + b.Y).DivideByTwo(), (a.Z + b.Z).DivideByTwo());
    }

    public void Add(BigRational x, BigRational y, BigRational z)
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
      if (other is Point3BR)
        return this.Equals((Point3BR) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture));
    }

    public static bool operator ==(Point3BR a, Point3BR b)
    {
      if (a.X == b.X && a.Y == b.Y)
        return a.Z == b.Z;
      return false;
    }

    public static bool operator !=(Point3BR a, Point3BR b)
    {
      if (a.X == b.X && a.Y == b.Y)
        return !(a.Z == b.Z);
      return true;
    }

    public static Point3BR operator +(Point3BR p, Vector3BR v)
    {
      return new Point3BR(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3BR operator +(Vector3BR v, Point3BR p)
    {
      return new Point3BR(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3BR operator -(Point3BR p, Vector3BR v)
    {
      return new Point3BR(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
    }

    public static Vector3BR operator -(Point3BR a, Point3BR b)
    {
      return new Vector3BR(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
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

    public static explicit operator BigRational[](Point3BR p)
    {
      return new BigRational[3]{ p.X, p.Y, p.Z };
    }

    public static explicit operator Point3BR(Point2BR p)
    {
      return new Point3BR(p.X, p.Y, BigRational.Zero);
    }

    public static explicit operator Point3BR(Vector4BR v)
    {
      return new Point3BR(v.X / v.W, v.Y / v.W, v.Z / v.W);
    }

    public static explicit operator Point3BR(Vector3BR v)
    {
      return new Point3BR(v);
    }

    public static explicit operator Point3F(Point3BR p)
    {
      return new Point3F((float) (double) p.X, (float) (double) p.Y, (float) (double) p.Z);
    }

    private static Point3BR smethod_0(BigRational x, BigRational y, BigRational z)
    {
      return new Point3BR(x, y, z);
    }

    public bool Equals(Point3BR other)
    {
      if (this.X == other.X && this.Y == other.Y)
        return this.Z == other.Z;
      return false;
    }
  }
}
