// Decompiled with JetBrains decompiler
// Type: WW.Math.Point2DC
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace WW.Math
{
  public class Point2DC
  {
    public double X;
    public double Y;

    [DebuggerStepThrough]
    public Point2DC(double x, double y)
    {
      this.X = x;
      this.Y = y;
    }

    [DebuggerStepThrough]
    public Point2DC(double[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Point2DC(IList<double> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Point2DC(Point2D from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    [DebuggerStepThrough]
    public Point2DC(Vector2D from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    public static Point2DC Add(Point2DC p, Vector2D v)
    {
      return new Point2DC(p.X + v.X, p.Y + v.Y);
    }

    public static Point2DC Subtract(Point2DC p, Vector2D v)
    {
      return new Point2DC(p.X - v.X, p.Y - v.Y);
    }

    public static Vector2D Subtract(Point2DC a, Point2DC b)
    {
      return new Vector2D(a.X - b.X, a.Y - b.Y);
    }

    public static bool AreApproxEqual(Point2DC a, Point2DC b)
    {
      return Point2DC.AreApproxEqual(a, b, 8.88178419700125E-16);
    }

    public static bool AreApproxEqual(Point2DC a, Point2DC b, double tolerance)
    {
      if (System.Math.Abs(b.X - a.X) <= tolerance)
        return System.Math.Abs(b.Y - a.Y) <= tolerance;
      return false;
    }

    public void Add(Vector2D v)
    {
      this.X += v.X;
      this.Y += v.Y;
    }

    public void Subtract(Vector2D v)
    {
      this.X -= v.X;
      this.Y -= v.Y;
    }

    public Point2D ToPoint2D()
    {
      return new Point2D(this.X, this.Y);
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if ((object) (other as Point2DC) != null)
        return this.Equals((Point2DC) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture));
    }

    public static Point2DC Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 2)
        throw new ArgumentException("Illegal point string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Point2DC(double.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), double.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Point2DC a, Point2DC b)
    {
      if (a.X == b.X)
        return a.Y == b.Y;
      return false;
    }

    public static bool operator !=(Point2DC a, Point2DC b)
    {
      if (a.X == b.X)
        return a.Y != b.Y;
      return true;
    }

    public static Point2DC operator +(Point2DC p, Vector2D v)
    {
      return Point2DC.Add(p, v);
    }

    public static Point2DC operator +(Vector2D v, Point2DC p)
    {
      return Point2DC.Add(p, v);
    }

    public static Point2DC operator -(Point2DC p, Vector2D v)
    {
      return Point2DC.Subtract(p, v);
    }

    public static Vector2D operator -(Point2DC a, Point2DC b)
    {
      return Point2DC.Subtract(a, b);
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

    public static explicit operator double[](Point2DC p)
    {
      return new double[3]{ p.X, p.Y, 0.0 };
    }

    public static explicit operator Point2DC(Point3D p)
    {
      return new Point2DC(p.X, p.Y);
    }

    public static explicit operator Point2DC(Vector4D v)
    {
      double num = 1.0 / v.W;
      return new Point2DC(v.X * num, v.Y * num);
    }

    public static explicit operator Point2DC(Vector2D v)
    {
      return new Point2DC(v);
    }

    private static Point2DC smethod_0(double x, double y)
    {
      return new Point2DC(x, y);
    }

    public bool Equals(Point2DC other)
    {
      if (this.X == other.X)
        return this.Y == other.Y;
      return false;
    }
  }
}
