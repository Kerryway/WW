// Decompiled with JetBrains decompiler
// Type: WW.Math.Vector3D
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
  [TypeConverter(typeof (Vector3DConverter))]
  [Serializable]
  public struct Vector3D : IEquatable<Vector3D>
  {
    public static readonly Vector3D Zero = Vector3D.smethod_0(0.0, 0.0, 0.0);
    public static readonly Vector3D XAxis = Vector3D.smethod_0(1.0, 0.0, 0.0);
    public static readonly Vector3D YAxis = Vector3D.smethod_0(0.0, 1.0, 0.0);
    public static readonly Vector3D ZAxis = Vector3D.smethod_0(0.0, 0.0, 1.0);
    public double X;
    public double Y;
    public double Z;

    [DebuggerStepThrough]
    public Vector3D(double x, double y, double z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Vector3D(Vector2D vector, double z)
    {
      this.X = vector.X;
      this.Y = vector.Y;
      this.Z = z;
    }

    [DebuggerStepThrough]
    public Vector3D(double[] coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Vector3D(IList<double> coordinates)
    {
      this.X = coordinates[0];
      this.Y = coordinates[1];
      this.Z = coordinates[2];
    }

    [DebuggerStepThrough]
    public Vector3D(Vector3D from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
    }

    [DebuggerStepThrough]
    public Vector3D(Point3D from)
    {
      this.X = from.X;
      this.Y = from.Y;
      this.Z = from.Z;
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

    public static Vector3D Add(Vector3D u, Vector3D v)
    {
      return new Vector3D(u.X + v.X, u.Y + v.Y, u.Z + v.Z);
    }

    public static Vector3D Subtract(Vector3D u, Vector3D v)
    {
      return new Vector3D(u.X - v.X, u.Y - v.Y, u.Z - v.Z);
    }

    public static Vector3D Divide(Vector3D v, double s)
    {
      double num = 1.0 / s;
      return new Vector3D(v.X * num, v.Y * num, v.Z * num);
    }

    public static Vector3D Multiply(Vector3D u, double s)
    {
      return new Vector3D(u.X * s, u.Y * s, u.Z * s);
    }

    public static double DotProduct(Vector3D u, Vector3D v)
    {
      return u.X * v.X + u.Y * v.Y + u.Z * v.Z;
    }

    public static Vector3D CrossProduct(Vector3D u, Vector3D v)
    {
      return new Vector3D(u.Y * v.Z - u.Z * v.Y, u.Z * v.X - u.X * v.Z, u.X * v.Y - u.Y * v.X);
    }

    public static Vector3D Negate(Vector3D v)
    {
      return new Vector3D(-v.X, -v.Y, -v.Z);
    }

    public static bool AreApproxEqual(Vector3D u, Vector3D v)
    {
      return Vector3D.AreApproxEqual(u, v, 8.88178419700125E-16);
    }

    public static bool AreApproxEqual(Vector3D u, Vector3D v, double tolerance)
    {
      if (System.Math.Abs(v.X - u.X) <= tolerance && System.Math.Abs(v.Y - u.Y) <= tolerance)
        return System.Math.Abs(v.Z - u.Z) <= tolerance;
      return false;
    }

    public static bool AreVectorsPerpendicular(Vector3D a, Vector3D b, double tolerance)
    {
      Vector3D u = a;
      Vector3D v = b;
      if (u.GetLength() >= tolerance && v.GetLength() >= tolerance)
        return System.Math.Abs(Vector3D.DotProduct(u, v)) <= tolerance;
      return true;
    }

    public static Vector3D OrthogonalProjection(Vector3D a, Vector3D b)
    {
      Vector3D u = b;
      u.Normalize();
      Vector3D v = u * Vector3D.DotProduct(u, a);
      return Vector3D.Subtract(a, v);
    }

    public static double GetAngle(Vector3D a, Vector3D b)
    {
      double num1 = Vector3D.DotProduct(a, b);
      double num2 = System.Math.Sqrt(a.GetLengthSquared() * b.GetLengthSquared());
      if (num2 <= 0.0)
        return 0.0;
      double d = num1 / num2;
      if (d > 1.0)
        return 0.0;
      if (d < -1.0)
        return System.Math.PI;
      return System.Math.Acos(d);
    }

    public static double GetAngle(Vector3D a, Vector3D b, Vector3D axis)
    {
      Vector3D v = Vector3D.CrossProduct(a, b);
      v.Normalize();
      axis.Normalize();
      double num = Vector3D.DotProduct(axis, v);
      double angle = Vector3D.GetAngle(a, b);
      if (num < -1E-10)
        return 2.0 * System.Math.PI - angle;
      return angle;
    }

    public static double GetAngleAroundAxis(Vector3D a, Vector3D b, Vector3D axis)
    {
      axis.Normalize();
      if (Vector3D.AreApproxEqual(Vector3D.Zero, axis))
        return 0.0;
      Matrix3D transpose = Transformation3D.GetArbitraryCoordSystem(axis).GetTranspose();
      Vector3D vector3D1 = transpose.Transform(a);
      Vector3D vector3D2 = transpose.Transform(b);
      double num = System.Math.Atan2(vector3D2.Y, vector3D2.X) - System.Math.Atan2(vector3D1.Y, vector3D1.X);
      if (num < 0.0)
        num += 2.0 * System.Math.PI;
      return num;
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
    }

    public Vector3D GetUnit()
    {
      double lengthSquared = this.GetLengthSquared();
      if (lengthSquared == 1.0)
        return this;
      double num = 1.0 / System.Math.Sqrt(lengthSquared);
      return new Vector3D(this.X * num, this.Y * num, this.Z * num);
    }

    public double GetLength()
    {
      return System.Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
    }

    public double GetLengthSquared()
    {
      return this.X * this.X + this.Y * this.Y + this.Z * this.Z;
    }

    public bool ContainsNaN()
    {
      if (!double.IsNaN(this.X) && !double.IsNaN(this.Y))
        return double.IsNaN(this.Z);
      return true;
    }

    public static Vector3D FromAngle(double angle)
    {
      return new Vector3D(System.Math.Cos(angle), System.Math.Sin(angle), 0.0);
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Vector3D)
        return this.Equals((Vector3D) other);
      return false;
    }

    public override string ToString()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      return string.Format("{0}, {1}, {2}", (object) this.X.ToString((IFormatProvider) invariantCulture), (object) this.Y.ToString((IFormatProvider) invariantCulture), (object) this.Z.ToString((IFormatProvider) invariantCulture));
    }

    public static Vector3D Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 3)
        throw new ArgumentException("Illegal vector string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new Vector3D(double.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), double.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat), double.Parse(strArray[2], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal vector string.", ex);
      }
    }

    public static bool operator ==(Vector3D u, Vector3D v)
    {
      if (u.X == v.X && u.Y == v.Y)
        return u.Z == v.Z;
      return false;
    }

    public static bool operator !=(Vector3D u, Vector3D v)
    {
      if (u.X == v.X && u.Y == v.Y)
        return u.Z != v.Z;
      return true;
    }

    public static Vector3D operator -(Vector3D v)
    {
      return new Vector3D(-v.X, -v.Y, -v.Z);
    }

    public static Vector3D operator +(Vector3D u, Vector3D v)
    {
      return new Vector3D(u.X + v.X, u.Y + v.Y, u.Z + v.Z);
    }

    public static Vector3D operator -(Vector3D u, Vector3D v)
    {
      return new Vector3D(u.X - v.X, u.Y - v.Y, u.Z - v.Z);
    }

    public static Vector3D operator *(Vector3D v, double s)
    {
      return new Vector3D(v.X * s, v.Y * s, v.Z * s);
    }

    public static Vector3D operator *(double s, Vector3D v)
    {
      return new Vector3D(v.X * s, v.Y * s, v.Z * s);
    }

    public static Vector3D operator /(Vector3D v, double s)
    {
      double num = 1.0 / s;
      return new Vector3D(v.X * num, v.Y * num, v.Z * num);
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

    public static explicit operator double[](Vector3D v)
    {
      return new double[3]{ v.X, v.Y, v.Z };
    }

    public static explicit operator Vector3D(Vector2D v)
    {
      return new Vector3D(v.X, v.Y, 0.0);
    }

    public static explicit operator Vector3D(Vector4D v)
    {
      return new Vector3D(v.X, v.Y, v.Z);
    }

    public static explicit operator Vector3D(Point3D p)
    {
      return new Vector3D(p);
    }

    public static explicit operator Vector3F(Vector3D v)
    {
      return new Vector3F((float) v.X, (float) v.Y, (float) v.Z);
    }

    private static Vector3D smethod_0(double x, double y, double z)
    {
      return new Vector3D(x, y, z);
    }

    public bool Equals(Vector3D v)
    {
      if (this.X == v.X && this.Y == v.Y)
        return this.Z == v.Z;
      return false;
    }
  }
}
