// Decompiled with JetBrains decompiler
// Type: WW.Math.Vector2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace WW.Math
{
  [TypeConverter(typeof (Vector2DConverter))]
  [Serializable]
  public struct Vector2D : IEquatable<Vector2D>
  {
    public static readonly Vector2D Zero = Vector2D.smethod_0(0.0, 0.0);
    public static readonly Vector2D XAxis = Vector2D.smethod_0(1.0, 0.0);
    public static readonly Vector2D YAxis = Vector2D.smethod_0(0.0, 1.0);
    public double X;
    public double Y;

    [DebuggerStepThrough]
    public Vector2D(double x, double y)
    {
      this.X = x;
      this.Y = y;
    }

    [DebuggerStepThrough]
    public Vector2D(double[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Vector2D(IList<double> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Vector2D(Vector2D from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    [DebuggerStepThrough]
    public Vector2D(Point2D from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    [Obsolete]
    [DisplayName("X")]
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

    public static Vector2D Add(Vector2D u, Vector2D v)
    {
      return new Vector2D(u.X + v.X, u.Y + v.Y);
    }

    public static Vector2D Subtract(Vector2D u, Vector2D v)
    {
      return new Vector2D(u.X - v.X, u.Y - v.Y);
    }

    public static Vector2D Divide(Vector2D v, double s)
    {
      double num = 1.0 / s;
      return new Vector2D(v.X * num, v.Y * num);
    }

    public static Vector2D Multiply(Vector2D u, double s)
    {
      return new Vector2D(u.X * s, u.Y * s);
    }

    public static double DotProduct(Vector2D u, Vector2D v)
    {
      return u.X * v.X + u.Y * v.Y;
    }

    public static double CrossProduct(Vector2D u, Vector2D v)
    {
      return u.X * v.Y - u.Y * v.X;
    }

    public static Vector2D Negate(Vector2D v)
    {
      return new Vector2D(-v.X, -v.Y);
    }

    public static bool AreApproxEqual(Vector2D u, Vector2D v)
    {
      return Vector2D.AreApproxEqual(u, v, 8.88178419700125E-16);
    }

    public static bool AreApproxEqual(Vector2D u, Vector2D v, double tolerance)
    {
      if (System.Math.Abs(v.X - u.X) <= tolerance)
        return System.Math.Abs(v.Y - u.Y) <= tolerance;
      return false;
    }

    public static double GetAngle(Vector2D a, Vector2D b)
    {
      Vector2D u1 = a;
      Vector2D u2 = new Vector2D(-u1.Y, u1.X);
      double x = Vector2D.DotProduct(u1, b);
      return System.Math.Atan2(Vector2D.DotProduct(u2, b), x);
    }

    public void Normalize()
    {
      double lengthSquared = this.GetLengthSquared();
      if (lengthSquared == 1.0)
        return;
      double num = 1.0 / System.Math.Sqrt(lengthSquared);
      this.X *= num;
      this.Y *= num;
    }

    public Vector2D GetUnit()
    {
      double lengthSquared = this.GetLengthSquared();
      if (lengthSquared == 1.0)
        return this;
      double num = 1.0 / System.Math.Sqrt(lengthSquared);
      return new Vector2D(this.X * num, this.Y * num);
    }

    public double GetLength()
    {
      return System.Math.Sqrt(this.X * this.X + this.Y * this.Y);
    }

    public double GetLengthSquared()
    {
      return this.X * this.X + this.Y * this.Y;
    }

    public static Vector2D FromAngle(double angle)
    {
      return new Vector2D(System.Math.Cos(angle), System.Math.Sin(angle));
    }

    public double GetAngle()
    {
      return System.Math.Atan2(this.Y, this.X);
    }

    public static int CompareAngles(Vector2D a, Vector2D b)
    {
      int quadrant1 = Vector2D.GetQuadrant(a);
      int quadrant2 = Vector2D.GetQuadrant(b);
      if (quadrant1 < quadrant2)
        return -1;
      if (quadrant1 > quadrant2)
        return 1;
      double num = Vector2D.CrossProduct(a, b);
      if (num < 0.0)
        return 1;
      return num > 0.0 ? -1 : 0;
    }

    public static int GetQuadrant(Vector2D v)
    {
      return v.Y >= 0.0 ? (v.X >= 0.0 ? 0 : 1) : (v.X >= 0.0 ? 3 : 2);
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Vector2D)
        return this.Equals((Vector2D) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture));
    }

    public static Vector2D Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 2)
        throw new ArgumentException("Illegal vector string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Vector2D(double.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), double.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Vector2D u, Vector2D v)
    {
      if (u.X == v.X)
        return u.Y == v.Y;
      return false;
    }

    public static bool operator !=(Vector2D u, Vector2D v)
    {
      if (u.X == v.X)
        return u.Y != v.Y;
      return true;
    }

    public static Vector2D operator -(Vector2D v)
    {
      return new Vector2D(-v.X, -v.Y);
    }

    public static Vector2D operator +(Vector2D u, Vector2D v)
    {
      return new Vector2D(u.X + v.X, u.Y + v.Y);
    }

    public static Vector2D operator -(Vector2D u, Vector2D v)
    {
      return new Vector2D(u.X - v.X, u.Y - v.Y);
    }

    public static Vector2D operator *(Vector2D v, double s)
    {
      return new Vector2D(v.X * s, v.Y * s);
    }

    public static Vector2D operator *(double s, Vector2D v)
    {
      return new Vector2D(v.X * s, v.Y * s);
    }

    public static Vector2D operator /(Vector2D v, double s)
    {
      double num = 1.0 / s;
      return new Vector2D(v.X * num, v.Y * num);
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

    public static explicit operator Vector2D(Vector3D p)
    {
      return new Vector2D(p.X, p.Y);
    }

    public static explicit operator double[](Vector2D v)
    {
      return new double[2]{ v.X, v.Y };
    }

    public static explicit operator Vector2D(Point2D p)
    {
      return new Vector2D(p);
    }

    private static Vector2D smethod_0(double x, double y)
    {
      return new Vector2D(x, y);
    }

    public bool Equals(Vector2D other)
    {
      if (this.X == other.X)
        return this.Y == other.Y;
      return false;
    }
  }
}
