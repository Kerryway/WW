// Decompiled with JetBrains decompiler
// Type: WW.Math.Matrix3D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security;

namespace WW.Math
{
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public struct Matrix3D : IEquatable<Matrix3D>
  {
    public static readonly Matrix3D Zero = Matrix3D.smethod_0(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
    public static readonly Matrix3D Identity = Matrix3D.smethod_0(1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0);
    public double M00;
    public double M01;
    public double M02;
    public double M10;
    public double M11;
    public double M12;
    public double M20;
    public double M21;
    public double M22;

    public Matrix3D(
      double m00,
      double m01,
      double m02,
      double m10,
      double m11,
      double m12,
      double m20,
      double m21,
      double m22)
    {
      this.M00 = m00;
      this.M01 = m01;
      this.M02 = m02;
      this.M10 = m10;
      this.M11 = m11;
      this.M12 = m12;
      this.M20 = m20;
      this.M21 = m21;
      this.M22 = m22;
    }

    public Matrix3D(double[] elements)
    {
      this.M00 = elements[0];
      this.M01 = elements[1];
      this.M02 = elements[2];
      this.M10 = elements[3];
      this.M11 = elements[4];
      this.M12 = elements[5];
      this.M20 = elements[6];
      this.M21 = elements[7];
      this.M22 = elements[8];
    }

    public Matrix3D(IList<double> elements)
    {
      this.M00 = elements[0];
      this.M01 = elements[1];
      this.M02 = elements[2];
      this.M10 = elements[3];
      this.M11 = elements[4];
      this.M12 = elements[5];
      this.M20 = elements[6];
      this.M21 = elements[7];
      this.M22 = elements[8];
    }

    public Matrix3D(Vector3D column1, Vector3D column2, Vector3D column3)
    {
      this.M00 = column1.X;
      this.M01 = column2.X;
      this.M02 = column3.X;
      this.M10 = column1.Y;
      this.M11 = column2.Y;
      this.M12 = column3.Y;
      this.M20 = column1.Z;
      this.M21 = column2.Z;
      this.M22 = column3.Z;
    }

    public Matrix3D(Matrix3D m)
    {
      this.M00 = m.M00;
      this.M01 = m.M01;
      this.M02 = m.M02;
      this.M10 = m.M10;
      this.M11 = m.M11;
      this.M12 = m.M12;
      this.M20 = m.M20;
      this.M21 = m.M21;
      this.M22 = m.M22;
    }

    public static Matrix3D Add(Matrix3D a, Matrix3D b)
    {
      return new Matrix3D(a.M00 + b.M00, a.M01 + b.M01, a.M02 + b.M02, a.M10 + b.M10, a.M11 + b.M11, a.M12 + b.M12, a.M20 + b.M20, a.M21 + b.M21, a.M22 + b.M22);
    }

    public static Matrix3D Subtract(Matrix3D a, Matrix3D b)
    {
      return new Matrix3D(a.M00 - b.M00, a.M01 - b.M01, a.M02 - b.M02, a.M10 - b.M10, a.M11 - b.M11, a.M12 - b.M12, a.M20 - b.M20, a.M21 - b.M21, a.M22 - b.M22);
    }

    public static Matrix3D Multiply(Matrix3D a, Matrix3D b)
    {
      return new Matrix3D(a.M00 * b.M00 + a.M01 * b.M10 + a.M02 * b.M20, a.M00 * b.M01 + a.M01 * b.M11 + a.M02 * b.M21, a.M00 * b.M02 + a.M01 * b.M12 + a.M02 * b.M22, a.M10 * b.M00 + a.M11 * b.M10 + a.M12 * b.M20, a.M10 * b.M01 + a.M11 * b.M11 + a.M12 * b.M21, a.M10 * b.M02 + a.M11 * b.M12 + a.M12 * b.M22, a.M20 * b.M00 + a.M21 * b.M10 + a.M22 * b.M20, a.M20 * b.M01 + a.M21 * b.M11 + a.M22 * b.M21, a.M20 * b.M02 + a.M21 * b.M12 + a.M22 * b.M22);
    }

    public static Matrix3D Transpose(Matrix3D m)
    {
      Matrix3D matrix3D = new Matrix3D(m);
      matrix3D.Transpose();
      return matrix3D;
    }

    public override int GetHashCode()
    {
      return this.M00.GetHashCode() ^ this.M01.GetHashCode() ^ this.M02.GetHashCode() ^ this.M10.GetHashCode() ^ this.M11.GetHashCode() ^ this.M12.GetHashCode() ^ this.M20.GetHashCode() ^ this.M21.GetHashCode() ^ this.M22.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Matrix3D)
        return this.Equals((Matrix3D) other);
      return false;
    }

    public override string ToString()
    {
      return string.Format("|{0}, {1}, {2}|\n|{3}, {4}, {5}|\n|{6}, {7}, {8}|\n", (object) this.M00, (object) this.M01, (object) this.M02, (object) this.M10, (object) this.M11, (object) this.M12, (object) this.M20, (object) this.M21, (object) this.M22);
    }

    public Vector2D Transform(Vector2D vector)
    {
      return new Vector2D(this.M00 * vector.X + this.M01 * vector.Y, this.M10 * vector.X + this.M11 * vector.Y);
    }

    public Point2D Transform(Point2D point)
    {
      return new Point2D(this.M00 * point.X + this.M01 * point.Y + this.M02, this.M10 * point.X + this.M11 * point.Y + this.M12);
    }

    public Vector3D Transform(Vector3D vector)
    {
      return new Vector3D(this.M00 * vector.X + this.M01 * vector.Y + this.M02 * vector.Z, this.M10 * vector.X + this.M11 * vector.Y + this.M12 * vector.Z, this.M20 * vector.X + this.M21 * vector.Y + this.M22 * vector.Z);
    }

    public Vector2D TransformTo2D(Vector3D vector)
    {
      return new Vector2D(this.M00 * vector.X + this.M01 * vector.Y + this.M02 * vector.Z, this.M10 * vector.X + this.M11 * vector.Y + this.M12 * vector.Z);
    }

    public Point3D Transform(Point3D point)
    {
      return new Point3D(this.M00 * point.X + this.M01 * point.Y + this.M02 * point.Z, this.M10 * point.X + this.M11 * point.Y + this.M12 * point.Z, this.M20 * point.X + this.M21 * point.Y + this.M22 * point.Z);
    }

    public Point2D TransformTo2D(Point3D point)
    {
      return new Point2D(this.M00 * point.X + this.M01 * point.Y + this.M02 * point.Z, this.M10 * point.X + this.M11 * point.Y + this.M12 * point.Z);
    }

    public double GetDeterminant()
    {
      return this.M00 * this.M11 * this.M22 + this.M01 * this.M12 * this.M20 + this.M02 * this.M10 * this.M21 - this.M02 * this.M11 * this.M20 - this.M00 * this.M12 * this.M21 - this.M01 * this.M10 * this.M22;
    }

    public Matrix3D GetAdjoint()
    {
      return new Matrix3D(this.M11 * this.M22 - this.M12 * this.M21, -(this.M01 * this.M22 - this.M02 * this.M21), this.M01 * this.M12 - this.M02 * this.M11, -(this.M10 * this.M22 - this.M12 * this.M20), this.M00 * this.M22 - this.M02 * this.M20, -(this.M00 * this.M12 - this.M02 * this.M10), this.M10 * this.M21 - this.M11 * this.M20, -(this.M00 * this.M21 - this.M01 * this.M20), this.M00 * this.M11 - this.M01 * this.M10);
    }

    public Matrix3D GetInverse()
    {
      double num = 1.0 / this.GetDeterminant();
      return new Matrix3D((this.M11 * this.M22 - this.M12 * this.M21) * num, -(this.M01 * this.M22 - this.M02 * this.M21) * num, (this.M01 * this.M12 - this.M02 * this.M11) * num, -(this.M10 * this.M22 - this.M12 * this.M20) * num, (this.M00 * this.M22 - this.M02 * this.M20) * num, -(this.M00 * this.M12 - this.M02 * this.M10) * num, (this.M10 * this.M21 - this.M11 * this.M20) * num, -(this.M00 * this.M21 - this.M01 * this.M20) * num, (this.M00 * this.M11 - this.M01 * this.M10) * num);
    }

    public Matrix3D GetInverse(out bool couldInvert)
    {
      double determinant = this.GetDeterminant();
      double num = 1.0 / determinant;
      couldInvert = determinant != 0.0;
      return new Matrix3D((this.M11 * this.M22 - this.M12 * this.M21) * num, -(this.M01 * this.M22 - this.M02 * this.M21) * num, (this.M01 * this.M12 - this.M02 * this.M11) * num, -(this.M10 * this.M22 - this.M12 * this.M20) * num, (this.M00 * this.M22 - this.M02 * this.M20) * num, -(this.M00 * this.M12 - this.M02 * this.M10) * num, (this.M10 * this.M21 - this.M11 * this.M20) * num, -(this.M00 * this.M21 - this.M01 * this.M20) * num, (this.M00 * this.M11 - this.M01 * this.M10) * num);
    }

    public Matrix3D GetTranspose()
    {
      Matrix3D matrix3D = this;
      matrix3D.Transpose();
      return matrix3D;
    }

    public Matrix2D GetMinor(int removeRow, int removeColumn)
    {
      int index1 = 0;
      Matrix2D matrix2D = new Matrix2D();
      for (int index2 = 0; index2 < 3; ++index2)
      {
        int index3 = 0;
        if (index2 != removeRow)
        {
          for (int index4 = 0; index4 < 3; ++index4)
          {
            if (index4 != removeColumn)
            {
              matrix2D[index1, index3] = this[index2, index4];
              ++index3;
            }
          }
          ++index1;
        }
      }
      return matrix2D;
    }

    public double GetTrace()
    {
      return this.M00 + this.M11 + this.M22;
    }

    public void Transpose()
    {
      MathUtil.Swap(ref this.M01, ref this.M10);
      MathUtil.Swap(ref this.M02, ref this.M20);
      MathUtil.Swap(ref this.M12, ref this.M21);
    }

    public static bool AreApproxEqual(Matrix3D a, Matrix3D b)
    {
      return Matrix3D.AreApproxEqual(a, b, 8.88178419700125E-16);
    }

    public static bool AreApproxEqual(Matrix3D a, Matrix3D b, double tolerance)
    {
      if (System.Math.Abs(b.M00 - a.M00) <= tolerance && System.Math.Abs(b.M01 - a.M01) <= tolerance && (System.Math.Abs(b.M02 - a.M02) <= tolerance && System.Math.Abs(b.M10 - a.M10) <= tolerance) && (System.Math.Abs(b.M11 - a.M11) <= tolerance && System.Math.Abs(b.M12 - a.M12) <= tolerance && (System.Math.Abs(b.M20 - a.M20) <= tolerance && System.Math.Abs(b.M21 - a.M21) <= tolerance)))
        return System.Math.Abs(b.M22 - a.M22) <= tolerance;
      return false;
    }

    public static bool operator ==(Matrix3D a, Matrix3D b)
    {
      return object.Equals((object) a, (object) b);
    }

    public static bool operator !=(Matrix3D a, Matrix3D b)
    {
      return !object.Equals((object) a, (object) b);
    }

    public static Matrix3D operator +(Matrix3D a, Matrix3D b)
    {
      return Matrix3D.Add(a, b);
    }

    public static Matrix3D operator -(Matrix3D a, Matrix3D b)
    {
      return Matrix3D.Subtract(a, b);
    }

    public static Matrix3D operator *(Matrix3D a, Matrix3D b)
    {
      return Matrix3D.Multiply(a, b);
    }

    public static Vector3D operator *(Matrix3D matrix, Vector3D vector)
    {
      return matrix.Transform(vector);
    }

    public static Point3D operator *(Matrix3D matrix, Point3D point)
    {
      return matrix.Transform(point);
    }

    public unsafe double this[int index]
    {
      [SecurityCritical] get
      {
        if (index < 0 || index >= 9)
          throw new IndexOutOfRangeException("Invalid matrix index!");
        fixed (double* numPtr = &this.M00)
          return numPtr[index];
      }
      [SecurityCritical] set
      {
        if (index < 0 || index >= 9)
          throw new IndexOutOfRangeException("Invalid matrix index!");
        fixed (double* numPtr = &this.M00)
          numPtr[index] = value;
      }
    }

    public double this[int row, int column]
    {
      [SecurityCritical] get
      {
        return this[row * 3 + column];
      }
      [SecurityCritical] set
      {
        this[row * 3 + column] = value;
      }
    }

    private static Matrix3D smethod_0(
      double m00,
      double m01,
      double m02,
      double m10,
      double m11,
      double m12,
      double m20,
      double m21,
      double m22)
    {
      return new Matrix3D(m00, m01, m02, m10, m11, m12, m20, m21, m22);
    }

    public bool Equals(Matrix3D other)
    {
      if (this.M00 == other.M00 && this.M01 == other.M01 && (this.M02 == other.M02 && this.M10 == other.M10) && (this.M11 == other.M11 && this.M12 == other.M12 && (this.M20 == other.M20 && this.M21 == other.M21)))
        return this.M22 == other.M22;
      return false;
    }
  }
}
