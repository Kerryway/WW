// Decompiled with JetBrains decompiler
// Type: WW.Math.Vector4D
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
  [TypeConverter(typeof (Vector4DConverter))]
  [Serializable]
  public struct Vector4D : IEquatable<Vector4D>
  {
    public static readonly Vector4D Zero = Vector4D.smethod_0(0.0, 0.0, 0.0, 0.0);
    public static readonly Vector4D XAxis = Vector4D.smethod_0(1.0, 0.0, 0.0, 0.0);
    public static readonly Vector4D YAxis = Vector4D.smethod_0(0.0, 1.0, 0.0, 0.0);
    public static readonly Vector4D ZAxis = Vector4D.smethod_0(0.0, 0.0, 1.0, 0.0);
    public static readonly Vector4D WAxis = Vector4D.smethod_0(0.0, 0.0, 0.0, 1.0);
    public double X;
    public double Y;
    public double Z;
    public double W;

    [DebuggerStepThrough]
    public Vector4D(double x, double y, double z, double w)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
      this.W = w;
    }

    [DebuggerStepThrough]
    public Vector4D(double[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
      this.W = coordinates[3];
    }

    [DebuggerStepThrough]
    public Vector4D(IList<double> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
      this.W = coordinates[3];
    }

    [DebuggerStepThrough]
    public Vector4D(IEnumerable<double> coordinates)
    {
      using (IEnumerator<double> enumerator = coordinates.GetEnumerator())
      {
        this.X = enumerator.Current;
        enumerator.MoveNext();
        this.Y = enumerator.Current;
        enumerator.MoveNext();
        this.Z = enumerator.Current;
        enumerator.MoveNext();
        this.W = enumerator.Current;
      }
    }

    [DebuggerStepThrough]
    public Vector4D(Vector4D from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
      this.W = from.W;
    }

    [DebuggerStepThrough]
    public Vector4D(Point3D from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
      this.W = 1.0;
    }

    [DebuggerStepThrough]
    public Vector4D(Vector3D from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
      this.W = 0.0;
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

    [DisplayName("Y")]
    [Obsolete]
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

    [DisplayName("Z")]
    [Obsolete]
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

    [DisplayName("W")]
    [Obsolete]
    public double _WProperty
    {
      get
      {
        return this.W;
      }
      set
      {
        this.W = value;
      }
    }

    public static Vector4D Add(Vector4D u, Vector4D v)
    {
      return new Vector4D(u.X + v.X, u.Y + v.Y, u.Z + v.Z, u.W + v.W);
    }

    public static Vector4D Subtract(Vector4D u, Vector4D v)
    {
      return new Vector4D(u.X - v.X, u.Y - v.Y, u.Z - v.Z, u.W - v.W);
    }

    public static Vector4D Divide(Vector4D v, double s)
    {
      double num = 1.0 / s;
      return new Vector4D(v.X * num, v.Y * num, v.Z * num, v.W * num);
    }

    public static Vector4D Multiply(Vector4D u, double s)
    {
      return new Vector4D(u.X * s, u.Y * s, u.Z * s, u.W * s);
    }

    public static double DotProduct(Vector4D u, Vector4D v)
    {
      return u.X * v.X + u.Y * v.Y + u.Z * v.Z + u.W * v.W;
    }

    public static Vector4D Negate(Vector4D v)
    {
      return new Vector4D(-v.X, -v.Y, -v.Z, -v.W);
    }

    public static bool AreApproxEqual(Vector4D u, Vector4D v)
    {
      return Vector4D.AreApproxEqual(u, v, 8.88178419700125E-16);
    }

    public static bool AreApproxEqual(Vector4D u, Vector4D v, double tolerance)
    {
      if (System.Math.Abs(v.X - u.X) <= tolerance && System.Math.Abs(v.Y - u.Y) <= tolerance && System.Math.Abs(v.Z - u.Z) <= tolerance)
        return System.Math.Abs(v.W - u.W) <= tolerance;
      return false;
    }

    public void Normalize()
    {
      double lengthSquared = this.GetLengthSquared();
      if (lengthSquared == 1.0)
        return;
      double num = 1.0 / System.Math.Sqrt(lengthSquared);
      this.X *= num;
      this.Y *= num;
      this.Z *= num;
      this.W *= num;
    }

    public Vector4D GetUnit()
    {
      double lengthSquared = this.GetLengthSquared();
      if (lengthSquared == 1.0)
        return this;
      double num = 1.0 / System.Math.Sqrt(lengthSquared);
      return new Vector4D(this.X * num, this.Y * num, this.Z * num, this.W * num);
    }

    public double GetLength()
    {
      return System.Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W);
    }

    public double GetLengthSquared()
    {
      return this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W;
    }

    public static Vector4D FromWeightedEuclidean(Point3D p, double w)
    {
      return new Vector4D(p.X * w, p.Y * w, p.Z * w, w);
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode() ^ this.W.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Vector4D)
        return this.Equals((Vector4D) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}, {3}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture), (object) this.W.ToString((IFormatProvider) invariantCulture));
    }

    public string ToString(string doubleFormatString)
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}, {3}", (object) this.X.ToString(doubleFormatString, (IFormatProvider) invariantCulture), (object) this.Y.ToString(doubleFormatString, (IFormatProvider) invariantCulture), (object) this.Z.ToString(doubleFormatString, (IFormatProvider) invariantCulture), (object) this.W.ToString(doubleFormatString, (IFormatProvider) invariantCulture));
    }

    public static Vector4D Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 4)
        throw new ArgumentException("Illegal vector string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Vector4D(double.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), double.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat), double.Parse(strArray[2], (IFormatProvider) invariantCulture.NumberFormat), double.Parse(strArray[3], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Vector4D u, Vector4D v)
    {
      if (u.X == v.X && u.Y == v.Y && u.Z == v.Z)
        return u.W == v.W;
      return false;
    }

    public static bool operator !=(Vector4D u, Vector4D v)
    {
      if (u.X == v.X && u.Y == v.Y && u.Z == v.Z)
        return u.W != v.W;
      return true;
    }

    public static Vector4D operator -(Vector4D v)
    {
      return new Vector4D(-v.X, -v.Y, -v.Z, -v.W);
    }

    public static Vector4D operator +(Vector4D u, Vector4D v)
    {
      return new Vector4D(u.X + v.X, u.Y + v.Y, u.Z + v.Z, u.W + v.W);
    }

    public static Vector4D operator +(Vector4D u, Vector3D v)
    {
      return new Vector4D(u.X + v.X, u.Y + v.Y, u.Z + v.Z, u.W);
    }

    public static Vector4D operator -(Vector4D u, Vector4D v)
    {
      return new Vector4D(u.X - v.X, u.Y - v.Y, u.Z - v.Z, u.W - v.W);
    }

    public static Vector4D operator -(Vector4D u, Vector3D v)
    {
      return new Vector4D(u.X - v.X, u.Y - v.Y, u.Z - v.Z, u.W);
    }

    public static Vector4D operator *(Vector4D v, double s)
    {
      return new Vector4D(v.X * s, v.Y * s, v.Z * s, v.W * s);
    }

    public static Vector4D operator *(double s, Vector4D v)
    {
      return new Vector4D(v.X * s, v.Y * s, v.Z * s, v.W * s);
    }

    public static Vector4D operator /(Vector4D v, double s)
    {
      double num = 1.0 / s;
      return new Vector4D(v.X * num, v.Y * num, v.Z * num, v.W * num);
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
          case 3:
            return this.W;
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
          case 3:
            this.W = value;
            break;
          default:
            throw new IndexOutOfRangeException();
        }
      }
    }

    public static explicit operator double[](Vector4D v)
    {
      return new double[4]{ v.X, v.Y, v.Z, v.W };
    }

    public static explicit operator Vector4D(Vector2D v)
    {
      return new Vector4D(v.X, v.Y, 0.0, 0.0);
    }

    public static explicit operator Vector4D(Point2D p)
    {
      return new Vector4D(p.X, p.Y, 0.0, 1.0);
    }

    public static explicit operator Vector4D(Vector3D v)
    {
      return new Vector4D(v.X, v.Y, v.Z, 0.0);
    }

    public static explicit operator Vector4D(Point3D p)
    {
      return new Vector4D(p.X, p.Y, p.Z, 1.0);
    }

    public static explicit operator System.Windows.Point(Vector4D v)
    {
      double num = 1.0 / v.W;
      return new System.Windows.Point(v.X * num, v.Y * num);
    }

    public static explicit operator Point3F(Vector4D v)
    {
      double num = 1.0 / v.W;
      return new Point3F((float) (v.X * num), (float) (v.Y * num), (float) (v.Z * num));
    }

    public Point2D ToPoint2D()
    {
      double num = 1.0 / this.W;
      return new Point2D(this.X * num, this.Y * num);
    }

    public Point3D ToPoint3D()
    {
      double num = 1.0 / this.W;
      return new Point3D(this.X * num, this.Y * num, this.Z * num);
    }

    public static explicit operator System.Drawing.Point(Vector4D p)
    {
      double num = 1.0 / p.W;
      return new System.Drawing.Point((int) System.Math.Round(p.X * num), (int) System.Math.Round(p.Y * num));
    }

    public static explicit operator PointF(Vector4D p)
    {
      double num = 1.0 / p.W;
      return new PointF((float) (p.X * num), (float) (p.Y * num));
    }

    public static explicit operator Vector4D(PointF p)
    {
      return new Vector4D((double) p.X, (double) p.Y, 0.0, 1.0);
    }

    private static Vector4D smethod_0(double x, double y, double z, double w)
    {
      return new Vector4D(x, y, z, w);
    }

    public bool Equals(Vector4D other)
    {
      if (this.X == other.X && this.Y == other.Y && this.Z == other.Z)
        return this.W == other.W;
      return false;
    }
  }
}
