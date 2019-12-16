// Decompiled with JetBrains decompiler
// Type: WW.Math.QuaternionD
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.ComponentModel;
using System.Globalization;

namespace WW.Math
{
  [TypeConverter(typeof (QuaternionDConverter))]
  [Serializable]
  public struct QuaternionD : IEquatable<QuaternionD>
  {
    public static readonly QuaternionD Zero = QuaternionD.smethod_0(0.0, 0.0, 0.0, 0.0);
    public static readonly QuaternionD Identity = QuaternionD.smethod_0(1.0, 0.0, 0.0, 0.0);
    public static readonly QuaternionD XAxis = QuaternionD.smethod_0(0.0, 1.0, 0.0, 0.0);
    public static readonly QuaternionD YAxis = QuaternionD.smethod_0(0.0, 0.0, 1.0, 0.0);
    public static readonly QuaternionD ZAxis = QuaternionD.smethod_0(0.0, 0.0, 0.0, 1.0);
    public static readonly QuaternionD WAxis = QuaternionD.smethod_0(1.0, 0.0, 0.0, 0.0);
    public double W;
    public double X;
    public double Y;
    public double Z;

    public QuaternionD(double w, double x, double y, double z)
    {
      this.W = w;
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    public QuaternionD(double w, Vector3D v)
    {
      this.W = w;
      this.X = v.X;
      this.Y = v.Y;
      this.Z = v.Z;
    }

    public QuaternionD(double[] coordinates)
    {
      this.W = coordinates[0];
      this.X = coordinates[1];
      this.Y = coordinates[2];
      this.Z = coordinates[3];
    }

    public QuaternionD(QuaternionD q)
    {
      this.W = q.W;
      this.X = q.X;
      this.Y = q.Y;
      this.Z = q.Z;
    }

    public QuaternionD(Matrix4D m)
    {
      double d = m[0, 0] + m[1, 1] + m[2, 2] + 1.0;
      if (d > 8.88178419700125E-16)
      {
        double num = 0.5 / System.Math.Sqrt(d);
        this.W = 0.25 / num;
        this.X = (m[2, 1] - m[1, 2]) * num;
        this.Y = (m[0, 2] - m[2, 0]) * num;
        this.Z = (m[1, 0] - m[0, 1]) * num;
      }
      else if (m[0, 0] > m[1, 1] && m[0, 0] > m[2, 2])
      {
        double num1 = 2.0 * System.Math.Sqrt(1.0 + m[0, 0] - m[1, 1] - m[2, 2]);
        double num2 = 1.0 / num1;
        this.X = 0.25 * num1;
        this.Y = (m[0, 1] + m[1, 0]) * num2;
        this.Z = (m[0, 2] + m[2, 0]) * num2;
        this.W = (m[1, 2] - m[2, 1]) * num2;
      }
      else if (m[1, 1] > m[2, 2])
      {
        double num1 = 2.0 * System.Math.Sqrt(1.0 + m[1, 1] - m[0, 0] - m[2, 2]);
        double num2 = 1.0 / num1;
        this.X = (m[0, 1] + m[1, 0]) * num2;
        this.Y = 0.25 * num1;
        this.Z = (m[1, 2] + m[2, 1]) * num2;
        this.W = (m[0, 2] - m[2, 0]) * num2;
      }
      else
      {
        double num1 = 2.0 * System.Math.Sqrt(1.0 + m[2, 2] - m[0, 0] - m[1, 1]);
        double num2 = 1.0 / num1;
        this.X = (m[0, 2] + m[2, 0]) * num2;
        this.Y = (m[1, 2] + m[2, 1]) * num2;
        this.Z = 0.25 * num1;
        this.W = (m[0, 1] - m[1, 0]) * num2;
      }
    }

    public QuaternionD(Vector3D from, Vector3D to)
    {
      from.Normalize();
      to.Normalize();
      double num = System.Math.Sqrt(0.5 * (1.0 + Vector3D.DotProduct(from, to)));
      Vector3D vector3D = Vector3D.CrossProduct(from, to) / (2.0 * num);
      this.X = vector3D.X;
      this.Y = vector3D.Y;
      this.Z = vector3D.Z;
      this.W = num;
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

    public static QuaternionD Parse(string s)
    {
      string[] strArray = s.Split(',');
      if (strArray == null || strArray.Length != 4)
        throw new ArgumentException("Illegal quaternion string.");
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      try
      {
        return new QuaternionD(double.Parse(strArray[0], (IFormatProvider) invariantCulture.NumberFormat), double.Parse(strArray[1], (IFormatProvider) invariantCulture.NumberFormat), double.Parse(strArray[2], (IFormatProvider) invariantCulture.NumberFormat), double.Parse(strArray[3], (IFormatProvider) invariantCulture.NumberFormat));
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Illegal quaternion string.", ex);
      }
    }

    public static QuaternionD Add(QuaternionD a, QuaternionD b)
    {
      return new QuaternionD(a.W + b.W, a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static void Add(QuaternionD a, QuaternionD b, ref QuaternionD result)
    {
      result.W = a.W + b.W;
      result.X = a.X + b.X;
      result.Y = a.Y + b.Y;
      result.Z = a.Z + b.Z;
    }

    public static QuaternionD Subtract(QuaternionD a, QuaternionD b)
    {
      return new QuaternionD(a.W - b.W, a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static QuaternionD Multiply(QuaternionD a, QuaternionD b)
    {
      return new QuaternionD() { W = a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z, X = a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y, Y = a.W * b.Y + a.Y * b.W + a.Z * b.X - a.X * b.Z, Z = a.W * b.Z + a.Z * b.W + a.X * b.Y - a.Y * b.X };
    }

    public static QuaternionD Multiply(QuaternionD q, double s)
    {
      QuaternionD quaternionD = new QuaternionD(q);
      quaternionD.W *= s;
      quaternionD.X *= s;
      quaternionD.Y *= s;
      quaternionD.Z *= s;
      return quaternionD;
    }

    public static QuaternionD Divide(QuaternionD q, double s)
    {
      if (s == 0.0)
        throw new DivideByZeroException("Dividing quaternion by zero");
      QuaternionD quaternionD = new QuaternionD(q);
      quaternionD.W /= s;
      quaternionD.X /= s;
      quaternionD.Y /= s;
      quaternionD.Z /= s;
      return quaternionD;
    }

    public static double DotProduct(QuaternionD a, QuaternionD b)
    {
      return a.W * b.W + a.X * b.X + a.Y * b.Y + a.Z * b.Z;
    }

    public static Matrix4D QuaternionToMatrix(QuaternionD q)
    {
      double x = q.X;
      double y = q.Y;
      double z = q.Z;
      double w = q.W;
      double num1 = x * x;
      double num2 = y * y;
      double num3 = z * z;
      double num4 = x * y;
      double num5 = x * z;
      double num6 = y * z;
      double num7 = w * x;
      double num8 = w * y;
      double num9 = w * z;
      return new Matrix4D(1.0 - 2.0 * num2 - 2.0 * num3, 2.0 * num4 - 2.0 * num9, 2.0 * num5 + 2.0 * num8, 0.0, 2.0 * num4 + 2.0 * num9, 1.0 - 2.0 * num1 - 2.0 * num3, 2.0 * num6 - 2.0 * num7, 0.0, 2.0 * num5 - 2.0 * num8, 2.0 * num6 + 2.0 * num7, 1.0 - 2.0 * num1 - 2.0 * num2, 0.0, 0.0, 0.0, 0.0, 1.0);
    }

    public static Matrix3D QuaternionToMatrix3D(QuaternionD q)
    {
      double x = q.X;
      double y = q.Y;
      double z = q.Z;
      double w = q.W;
      double num1 = x * x;
      double num2 = y * y;
      double num3 = z * z;
      double num4 = x * y;
      double num5 = x * z;
      double num6 = y * z;
      double num7 = w * x;
      double num8 = w * y;
      double num9 = w * z;
      return new Matrix3D(1.0 - 2.0 * num2 - 2.0 * num3, 2.0 * num4 - 2.0 * num9, 2.0 * num5 + 2.0 * num8, 2.0 * num4 + 2.0 * num9, 1.0 - 2.0 * num1 - 2.0 * num3, 2.0 * num6 - 2.0 * num7, 2.0 * num5 - 2.0 * num8, 2.0 * num6 + 2.0 * num7, 1.0 - 2.0 * num1 - 2.0 * num2);
    }

    public static QuaternionD FromAxisAngle(Vector3D axis, double angle)
    {
      double num1 = 0.5 * angle;
      double num2 = System.Math.Sin(num1);
      return new QuaternionD(System.Math.Cos(num1), axis.X * num2, axis.Y * num2, axis.Z * num2);
    }

    public double GetModulus()
    {
      return System.Math.Sqrt(this.W * this.W + this.X * this.X + this.Y * this.Y + this.Z * this.Z);
    }

    public double GetModulusSquared()
    {
      return this.W * this.W + this.X * this.X + this.Y * this.Y + this.Z * this.Z;
    }

    public QuaternionD GetConjugate()
    {
      return new QuaternionD(this.W, -this.X, -this.Y, -this.Z);
    }

    public void GetInverse()
    {
      double modulusSquared = this.GetModulusSquared();
      if (modulusSquared <= 0.0)
        throw new DivideByZeroException("Quaternion " + this.ToString() + " is not invertable");
      double num = 1.0 / modulusSquared;
      this.W *= num;
      this.X *= -num;
      this.Y *= -num;
      this.Z *= -num;
    }

    public void Normalize()
    {
      double modulus = this.GetModulus();
      if (modulus == 0.0)
        throw new DivideByZeroException("Trying to normalize a quaternion with modulus of zero.");
      this.W /= modulus;
      this.X /= modulus;
      this.Y /= modulus;
      this.Z /= modulus;
    }

    public override int GetHashCode()
    {
      return this.W.GetHashCode() ^ this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is QuaternionD)
        return this.Equals((QuaternionD) other);
      return false;
    }

    public override string ToString()
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}, {1}, {2}, {3}", (object) this.W, (object) this.X, (object) this.Y, (object) this.Z);
    }

    public static bool operator ==(QuaternionD a, QuaternionD b)
    {
      return object.Equals((object) a, (object) b);
    }

    public static bool operator !=(QuaternionD a, QuaternionD b)
    {
      return !object.Equals((object) a, (object) b);
    }

    public static QuaternionD operator +(QuaternionD a, QuaternionD b)
    {
      return QuaternionD.Add(a, b);
    }

    public static QuaternionD operator -(QuaternionD a, QuaternionD b)
    {
      return QuaternionD.Subtract(a, b);
    }

    public static QuaternionD operator *(QuaternionD a, QuaternionD b)
    {
      return QuaternionD.Multiply(a, b);
    }

    public static QuaternionD operator *(QuaternionD q, double s)
    {
      return QuaternionD.Multiply(q, s);
    }

    public static QuaternionD operator *(double s, QuaternionD q)
    {
      return QuaternionD.Multiply(q, s);
    }

    public static QuaternionD operator /(QuaternionD q, double s)
    {
      return QuaternionD.Divide(q, s);
    }

    public static QuaternionD operator /(double s, QuaternionD q)
    {
      return QuaternionD.Multiply(q, 1.0 / s);
    }

    public double this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return this.W;
          case 1:
            return this.X;
          case 2:
            return this.Y;
          case 3:
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
            this.W = value;
            break;
          case 1:
            this.X = value;
            break;
          case 2:
            this.Y = value;
            break;
          case 3:
            this.Z = value;
            break;
          default:
            throw new IndexOutOfRangeException();
        }
      }
    }

    public static explicit operator double[](QuaternionD q)
    {
      return new double[4]{ q.W, q.X, q.Y, q.Z };
    }

    private static QuaternionD smethod_0(double w, double x, double y, double z)
    {
      return new QuaternionD(w, x, y, z);
    }

    public bool Equals(QuaternionD other)
    {
      if (this.W == other.W && this.X == other.X && this.Y == other.Y)
        return this.Z == other.Z;
      return false;
    }
  }
}
