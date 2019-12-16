// Decompiled with JetBrains decompiler
// Type: WW.Math.Point3D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;

namespace WW.Math
{
  [TypeConverter(typeof (Point3DConverter))]
  [Serializable]
  public struct Point3D : IEquatable<Point3D>
  {
    public static readonly Point3D Zero = Point3D.smethod_0(0.0, 0.0, 0.0);
    public double X;
    public double Y;
    public double Z;

    [DebuggerStepThrough]
    public Point3D(double x, double y, double z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Point3D(Point2D point, double z)
    {
      this.X = point.X;
      this.Y = point.Y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Point3D(double[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Point3D(IList<double> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Point3D(Point3D from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [DebuggerStepThrough]
    public Point3D(Vector3D from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [DisplayName("X")]
    [Obsolete]
    public double _XProperty
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
    public double _YProperty
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
    public double _ZProperty
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

    public static Point3D Add(Point3D p, Vector3D v)
    {
      return new Point3D(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3D Subtract(Point3D p, Vector3D v)
    {
      return new Point3D(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
    }

    public static Vector3D Subtract(Point3D a, Point3D b)
    {
      return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static bool AreApproxEqual(Point3D a, Point3D b)
    {
      return Point3D.AreApproxEqual(a, b, 8.88178419700125E-16);
    }

    public static bool AreApproxEqual(Point3D a, Point3D b, double tolerance)
    {
      if (System.Math.Abs(b.X - a.X) <= tolerance && System.Math.Abs(b.Y - a.Y) <= tolerance)
        return System.Math.Abs(b.Z - a.Z) <= tolerance;
      return false;
    }

    public static Point3D GetMidPoint(Point3D a, Point3D b)
    {
      return new Point3D(0.5 * (a.X + b.X), 0.5 * (a.Y + b.Y), 0.5 * (a.Z + b.Z));
    }

    public void Add(double x, double y, double z)
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
      if (other is Point3D)
        return this.Equals((Point3D) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture));
    }

    public string ToString(string doubleFormatString)
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}", (object) this.X.ToString(doubleFormatString, (IFormatProvider) invariantCulture), (object) this.Y.ToString(doubleFormatString, (IFormatProvider) invariantCulture), (object) this.Z.ToString(doubleFormatString, (IFormatProvider) invariantCulture));
    }

    public static Point3D Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 3)
        throw new ArgumentException("Illegal vector string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Point3D(double.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), double.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat), double.Parse(strArray[2], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Point3D a, Point3D b)
    {
      if (a.X == b.X && a.Y == b.Y)
        return a.Z == b.Z;
      return false;
    }

    public static bool operator !=(Point3D a, Point3D b)
    {
      if (a.X == b.X && a.Y == b.Y)
        return a.Z != b.Z;
      return true;
    }

    public static Point3D operator +(Point3D p, Vector3D v)
    {
      return new Point3D(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3D operator +(Vector3D v, Point3D p)
    {
      return new Point3D(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3D operator -(Point3D p, Vector3D v)
    {
      return new Point3D(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
    }

    public static Vector3D operator -(Point3D a, Point3D b)
    {
      return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public double this[int index]
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

    public static explicit operator double[](Point3D p)
    {
      return new double[3]{ p.X, p.Y, p.Z };
    }

    public static explicit operator Point3D(Point2D p)
    {
      return new Point3D(p.X, p.Y, 0.0);
    }

    public static explicit operator Point3D(Vector4D v)
    {
      double num = 1.0 / v.W;
      return new Point3D(v.X * num, v.Y * num, v.Z * num);
    }

    public static explicit operator Point3D(Vector3D v)
    {
      return new Point3D(v);
    }

    public static explicit operator Point3F(Point3D p)
    {
      return new Point3F((float) p.X, (float) p.Y, (float) p.Z);
    }

    public static explicit operator Point(Point3D p)
    {
      return new Point((int) System.Math.Round(p.X), (int) System.Math.Round(p.Y));
    }

    public static explicit operator PointF(Point3D p)
    {
      return new PointF((float) p.X, (float) p.Y);
    }

    public static explicit operator Point3D(PointF p)
    {
      return new Point3D((double) p.X, (double) p.Y, 0.0);
    }

    private static Point3D smethod_0(double x, double y, double z)
    {
      return new Point3D(x, y, z);
    }

    public bool Equals(Point3D other)
    {
      if (this.X == other.X && this.Y == other.Y)
        return this.Z == other.Z;
      return false;
    }
  }
}
