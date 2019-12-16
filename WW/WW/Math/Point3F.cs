// Decompiled with JetBrains decompiler
// Type: WW.Math.Point3F
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
  [TypeConverter(typeof (Point3FConverter))]
  [Serializable]
  public struct Point3F : IEquatable<Point3F>
  {
    public static readonly Point3F Zero = new Point3F(0.0f, 0.0f, 0.0f);
    public float X;
    public float Y;
    public float Z;

    [DebuggerStepThrough]
    public Point3F(float x, float y, float z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Point3F(Point2F point, float z)
    {
      this.X = point.X;
      this.Y = point.Y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Point3F(float[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Point3F(IList<float> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Point3F(Point3F from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [DebuggerStepThrough]
    public Point3F(Vector3F from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
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

    [DisplayName("Z")]
    [Obsolete]
    public float _ZProperty
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

    public static Point3F Add(Point3F p, Vector3F v)
    {
      return new Point3F(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }

    public static Point3F Subtract(Point3F p, Vector3F v)
    {
      return new Point3F(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
    }

    public static Vector3F Subtract(Point3F a, Point3F b)
    {
      return new Vector3F(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static bool AreApproxEqual(Point3F a, Point3F b)
    {
      return Point3F.AreApproxEqual(a, b, 4.768372E-07f);
    }

    public static bool AreApproxEqual(Point3F a, Point3F b, float tolerance)
    {
      if ((double) System.Math.Abs(b.X - a.X) <= (double) tolerance && (double) System.Math.Abs(b.Y - a.Y) <= (double) tolerance)
        return (double) System.Math.Abs(b.Z - a.Z) <= (double) tolerance;
      return false;
    }

    public static Point3F GetMidPoint(Point3F a, Point3F b)
    {
      return new Point3F((float) (0.5 * ((double) a.X + (double) b.X)), (float) (0.5 * ((double) a.Y + (double) b.Y)), (float) (0.5 * ((double) a.Z + (double) b.Z)));
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      if (obj is Point3F)
        return this.Equals((Point3F) obj);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture));
    }

    public static Point3F Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 3)
        throw new ArgumentException("Illegal vector string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Point3F(float.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), float.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat), float.Parse(strArray[2], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Point3F a, Point3F b)
    {
      if ((double) a.X == (double) b.X && (double) a.Y == (double) b.Y)
        return (double) a.Z == (double) b.Z;
      return false;
    }

    public static bool operator !=(Point3F a, Point3F b)
    {
      if ((double) a.X == (double) b.X && (double) a.Y == (double) b.Y)
        return (double) a.Z != (double) b.Z;
      return true;
    }

    public static Point3F operator +(Point3F p, Vector3F v)
    {
      return Point3F.Add(p, v);
    }

    public static Point3F operator +(Vector3F v, Point3F p)
    {
      return Point3F.Add(p, v);
    }

    public static Point3F operator -(Point3F p, Vector3F v)
    {
      return Point3F.Subtract(p, v);
    }

    public static Vector3F operator -(Point3F a, Point3F b)
    {
      return Point3F.Subtract(a, b);
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

    public static explicit operator float[](Point3F p)
    {
      return new float[3]{ p.X, p.Y, p.Z };
    }

    public static explicit operator Point3F(Point2F p)
    {
      return new Point3F(p.X, p.Y, 0.0f);
    }

    public static explicit operator Point3F(Vector4F v)
    {
      float num = 1f / v.W;
      return new Point3F(v.X * num, v.Y * num, v.Z * num);
    }

    public static explicit operator Point3F(Vector3F v)
    {
      return new Point3F(v);
    }

    public bool Equals(Point3F other)
    {
      if ((double) this.X == (double) other.X && (double) this.Y == (double) other.Y)
        return (double) this.Z == (double) other.Z;
      return false;
    }
  }
}
