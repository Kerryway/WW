// Decompiled with JetBrains decompiler
// Type: WW.Math.Point2F
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
  [TypeConverter(typeof (Point2FConverter))]
  [Serializable]
  public struct Point2F : IEquatable<Point2F>
  {
    public static readonly Point2F Zero = Point2F.smethod_0(0.0f, 0.0f);
    public float X;
    public float Y;

    [DebuggerStepThrough]
    public Point2F(float x, float y)
    {
      this.X = x;
      this.Y = y;
    }

    [DebuggerStepThrough]
    public Point2F(float[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Point2F(IList<float> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
    }

    [DebuggerStepThrough]
    public Point2F(Point2F from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    [DebuggerStepThrough]
    public Point2F(Vector2F from)
    {
      this.X = from.X;
      this.Y = from.Y;
    }

    [Obsolete]
    [DisplayName("X")]
    public float _XProperty
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
    public float _YProperty
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

    public static Point2F Add(Point2F p, Vector2F v)
    {
      return new Point2F(p.X + v.X, p.Y + v.Y);
    }

    public static Point2F Subtract(Point2F p, Vector2F v)
    {
      return new Point2F(p.X - v.X, p.Y - v.Y);
    }

    public static Vector2F Subtract(Point2F a, Point2F b)
    {
      return new Vector2F(a.X - b.X, a.Y - b.Y);
    }

    public static bool AreApproxEqual(Point2F a, Point2F b)
    {
      return Point2F.AreApproxEqual(a, b, 4.768372E-07f);
    }

    public static bool AreApproxEqual(Point2F a, Point2F b, float tolerance)
    {
      if ((double) System.Math.Abs(b.X - a.X) <= (double) tolerance)
        return (double) System.Math.Abs(b.Y - a.Y) <= (double) tolerance;
      return false;
    }

    public static Point2F GetMidPoint(Point2F a, Point2F b)
    {
      return new Point2F((float) (0.5 * ((double) a.X + (double) b.X)), (float) (0.5 * ((double) a.Y + (double) b.Y)));
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Point2F)
        return this.Equals((Point2F) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture));
    }

    public static Point2F Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 2)
        throw new ArgumentException("Illegal point string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Point2F(float.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), float.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Point2F a, Point2F b)
    {
      if ((double) a.X == (double) b.X)
        return (double) a.Y == (double) b.Y;
      return false;
    }

    public static bool operator !=(Point2F a, Point2F b)
    {
      if ((double) a.X == (double) b.X)
        return (double) a.Y != (double) b.Y;
      return true;
    }

    public static Point2F operator +(Point2F p, Vector2F v)
    {
      return Point2F.Add(p, v);
    }

    public static Point2F operator +(Vector2F v, Point2F p)
    {
      return Point2F.Add(p, v);
    }

    public static Point2F operator -(Point2F p, Vector2F v)
    {
      return Point2F.Subtract(p, v);
    }

    public static Vector2F operator -(Point2F a, Point2F b)
    {
      return Point2F.Subtract(a, b);
    }

    public float this[int index]
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

    public static explicit operator float[](Point2F p)
    {
      return new float[2]{ p.X, p.Y };
    }

    public static explicit operator Point2F(Point3F p)
    {
      return new Point2F(p.X, p.Y);
    }

    public static explicit operator Point2F(Vector4F v)
    {
      float num = 1f / v.W;
      return new Point2F(v.X * num, v.Y * num);
    }

    public static explicit operator Point2F(Vector2F v)
    {
      return new Point2F(v);
    }

    private static Point2F smethod_0(float x, float y)
    {
      return new Point2F(x, y);
    }

    public bool Equals(Point2F other)
    {
      if ((double) this.X == (double) other.X)
        return (double) this.Y == (double) other.Y;
      return false;
    }
  }
}
