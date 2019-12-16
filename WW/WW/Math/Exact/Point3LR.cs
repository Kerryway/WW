// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Point3LR
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
  [TypeConverter(typeof (Point3LRConverter))]
  [Serializable]
  public struct Point3LR : IEquatable<Point3LR>
  {
    public static readonly Point3LR Zero = Point3LR.smethod_0(LongRational.Zero, LongRational.Zero, LongRational.Zero);
    public LongRational X;
    public LongRational Y;
    public LongRational Z;

    [DebuggerStepThrough]
    public Point3LR(LongRational x, LongRational y, LongRational z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Point3LR(double x, double y, double z)
    {
      this.X = (LongRational) x;
      this.Y = (LongRational) y;
      this.Z = (LongRational) z;
    }

    [DebuggerStepThrough]
    public Point3LR(int x, int y, int z)
    {
      this.X = new LongRational(x);
      this.Y = new LongRational(y);
      this.Z = new LongRational(z);
    }

    [DebuggerStepThrough]
    public Point3LR(Point2LR point, LongRational z)
    {
      this.X = point.X;
      this.Y = point.Y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Point3LR(LongRational[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Point3LR(IList<LongRational> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Point3LR(Point3LR from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [DebuggerStepThrough]
    public Point3LR(Vector3LR from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
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

    [DisplayName("Z")]
    [Obsolete]
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

    public static Point3LR Add(Point3LR p, Vector3LR v)
    {
      return new Point3LR(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3LR Subtract(Point3LR p, Vector3LR v)
    {
      return new Point3LR(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
    }

    public static Vector3LR Subtract(Point3LR a, Point3LR b)
    {
      return new Vector3LR(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Point3LR GetMidPoint(Point3LR a, Point3LR b)
    {
      return new Point3LR((a.X + b.X).DivideByTwo(), (a.Y + b.Y).DivideByTwo(), (a.Z + b.Z).DivideByTwo());
    }

    public void Add(LongRational x, LongRational y, LongRational z)
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
      if (other is Point3LR)
        return this.Equals((Point3LR) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture));
    }

    public static bool operator ==(Point3LR a, Point3LR b)
    {
      if (a.X == b.X && a.Y == b.Y)
        return a.Z == b.Z;
      return false;
    }

    public static bool operator !=(Point3LR a, Point3LR b)
    {
      if (a.X == b.X && a.Y == b.Y)
        return !(a.Z == b.Z);
      return true;
    }

    public static Point3LR operator +(Point3LR p, Vector3LR v)
    {
      return new Point3LR(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3LR operator +(Vector3LR v, Point3LR p)
    {
      return new Point3LR(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3LR operator -(Point3LR p, Vector3LR v)
    {
      return new Point3LR(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
    }

    public static Vector3LR operator -(Point3LR a, Point3LR b)
    {
      return new Vector3LR(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
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

    public static explicit operator LongRational[](Point3LR p)
    {
      return new LongRational[3]{ p.X, p.Y, p.Z };
    }

    public static explicit operator Point3LR(Point2LR p)
    {
      return new Point3LR(p.X, p.Y, LongRational.Zero);
    }

    public static explicit operator Point3LR(Vector4LR v)
    {
      return new Point3LR(v.X / v.W, v.Y / v.W, v.Z / v.W);
    }

    public static explicit operator Point3LR(Vector3LR v)
    {
      return new Point3LR(v);
    }

    public static explicit operator Point3F(Point3LR p)
    {
      return new Point3F((float) (double) p.X, (float) (double) p.Y, (float) (double) p.Z);
    }

    private static Point3LR smethod_0(LongRational x, LongRational y, LongRational z)
    {
      return new Point3LR(x, y, z);
    }

    public bool Equals(Point3LR other)
    {
      if (this.X == other.X && this.Y == other.Y)
        return this.Z == other.Z;
      return false;
    }
  }
}
