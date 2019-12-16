// Decompiled with JetBrains decompiler
// Type: WW.Math.Matrix2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Security;

namespace WW.Math
{
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public struct Matrix2D : IEquatable<Matrix2D>
  {
    public static readonly Matrix2D Zero = Matrix2D.smethod_0(0.0, 0.0, 0.0, 0.0);
    public static readonly Matrix2D Identity = Matrix2D.smethod_0(1.0, 0.0, 0.0, 1.0);
    public double M00;
    public double M01;
    public double M10;
    public double M11;

    public Matrix2D(double m00, double m01, double m10, double m11)
    {
      this.M00 = m00;
      this.M01 = m01;
      this.M10 = m10;
      this.M11 = m11;
    }

    public Matrix2D(double[] elements)
    {
      this.M00 = elements[0];
      this.M01 = elements[1];
      this.M10 = elements[2];
      this.M11 = elements[3];
    }

    public Matrix2D(IList<double> elements)
    {
      this.M00 = elements[0];
      this.M01 = elements[1];
      this.M10 = elements[2];
      this.M11 = elements[3];
    }

    public Matrix2D(Vector2D column1, Vector2D column2)
    {
      this.M00 = column1.X;
      this.M01 = column2.X;
      this.M10 = column1.Y;
      this.M11 = column2.Y;
    }

    public Matrix2D(Matrix2D m)
    {
      this.M00 = m.M00;
      this.M01 = m.M01;
      this.M10 = m.M10;
      this.M11 = m.M11;
    }

    public static Matrix2D Add(Matrix2D a, Matrix2D b)
    {
      return new Matrix2D(a.M00 + b.M00, a.M01 + b.M01, a.M10 + b.M10, a.M11 + b.M11);
    }

    public static Matrix2D Subtract(Matrix2D a, Matrix2D b)
    {
      return new Matrix2D(a.M00 - b.M00, a.M01 - b.M01, a.M10 - b.M10, a.M11 - b.M11);
    }

    public static Matrix2D Multiply(Matrix2D a, Matrix2D b)
    {
      return new Matrix2D(a.M00 * b.M00 + a.M01 * b.M10, a.M00 * b.M01 + a.M01 * b.M11, a.M10 * b.M00 + a.M11 * b.M10, a.M10 * b.M01 + a.M11 * b.M11);
    }

    public static Matrix2D Transpose(Matrix2D m)
    {
      Matrix2D matrix2D = new Matrix2D(m);
      matrix2D.Transpose();
      return matrix2D;
    }

    public override int GetHashCode()
    {
      return this.M00.GetHashCode() ^ this.M01.GetHashCode() ^ this.M10.GetHashCode() ^ this.M11.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Matrix2D)
        return this.Equals((Matrix2D) other);
      return false;
    }

    public override string ToString()
    {
      return string.Format("|{0}, {1}|\n|{2}, {3}|\n", (object) this.M00, (object) this.M01, (object) this.M10, (object) this.M11);
    }

    public Vector2D Transform(Vector2D vector)
    {
      return new Vector2D(this.M00 * vector.X + this.M01 * vector.Y, this.M10 * vector.X + this.M11 * vector.Y);
    }

    public Point2D Transform(Point2D point)
    {
      return new Point2D(this.M00 * point.X + this.M01 * point.Y, this.M10 * point.X + this.M11 * point.Y);
    }

    public double GetDeterminant()
    {
      return this.M00 * this.M11 - this.M01 * this.M10;
    }

    public Matrix2D GetInverse()
    {
      double num = 1.0 / this.GetDeterminant();
      return new Matrix2D(this.M11 * num, -this.M01 * num, -this.M10 * num, this.M00 * num);
    }

    public Matrix2D GetInverse(out bool couldInvert)
    {
      double determinant = this.GetDeterminant();
      double num = 1.0 / determinant;
      couldInvert = determinant != 0.0;
      return new Matrix2D(this.M11 * num, -this.M01 * num, -this.M10 * num, this.M00 * num);
    }

    public Matrix2D GetAdjoint()
    {
      return new Matrix2D(this.M11, -this.M01, -this.M10, this.M00);
    }

    public Matrix2D GetTranspose()
    {
      Matrix2D matrix2D = this;
      matrix2D.Transpose();
      return matrix2D;
    }

    public double GetMinor(int removeRow, int removeColumn)
    {
      int num1 = 0;
      double num2 = 0.0;
      for (int index1 = 0; index1 < 2; ++index1)
      {
        int num3 = 0;
        if (index1 != removeRow)
        {
          for (int index2 = 0; index2 < 2; ++index2)
          {
            if (index2 != removeColumn)
            {
              num2 = this[index1, index2];
              ++num3;
            }
          }
          ++num1;
        }
      }
      return num2;
    }

    public double GetTrace()
    {
      return this.M00 + this.M11;
    }

    public void Transpose()
    {
      MathUtil.Swap(ref this.M01, ref this.M10);
    }

    public Matrix ToMatrix()
    {
      return new Matrix((float) this.M00, (float) this.M10, (float) this.M01, (float) this.M11, 0.0f, 0.0f);
    }

    public static bool AreApproxEqual(Matrix2D a, Matrix2D b)
    {
      return Matrix2D.AreApproxEqual(a, b, 8.88178419700125E-16);
    }

    public static bool AreApproxEqual(Matrix2D a, Matrix2D b, double tolerance)
    {
      if (System.Math.Abs(b.M00 - a.M00) <= tolerance && System.Math.Abs(b.M01 - a.M01) <= tolerance && System.Math.Abs(b.M10 - a.M10) <= tolerance)
        return System.Math.Abs(b.M11 - a.M11) <= tolerance;
      return false;
    }

    public static bool operator ==(Matrix2D a, Matrix2D b)
    {
      return object.Equals((object) a, (object) b);
    }

    public static bool operator !=(Matrix2D a, Matrix2D b)
    {
      return !object.Equals((object) a, (object) b);
    }

    public static Matrix2D operator +(Matrix2D a, Matrix2D b)
    {
      return Matrix2D.Add(a, b);
    }

    public static Matrix2D operator -(Matrix2D a, Matrix2D b)
    {
      return Matrix2D.Subtract(a, b);
    }

    public static Matrix2D operator *(Matrix2D a, Matrix2D b)
    {
      return Matrix2D.Multiply(a, b);
    }

    public static Vector2D operator *(Matrix2D matrix, Vector2D vector)
    {
      return matrix.Transform(vector);
    }

    public static Point2D operator *(Matrix2D matrix, Point2D point)
    {
      return matrix.Transform(point);
    }

    public unsafe double this[int index]
    {
      [SecurityCritical] get
      {
        if (index < 0 || index >= 4)
          throw new IndexOutOfRangeException("Invalid matrix index!");
        fixed (double* numPtr = &this.M00)
          return numPtr[index];
      }
      [SecurityCritical] set
      {
        if (index < 0 || index >= 4)
          throw new IndexOutOfRangeException("Invalid matrix index!");
        fixed (double* numPtr = &this.M00)
          numPtr[index] = value;
      }
    }

    public double this[int row, int column]
    {
      [SecurityCritical] get
      {
        return this[(row << 1) + column];
      }
      [SecurityCritical] set
      {
        this[(row << 1) + column] = value;
      }
    }

    private static Matrix2D smethod_0(double m00, double m01, double m10, double m11)
    {
      return new Matrix2D(m00, m01, m10, m11);
    }

    public bool Equals(Matrix2D other)
    {
      if (this.M00 == other.M00 && this.M01 == other.M01 && this.M10 == other.M10)
        return this.M11 == other.M11;
      return false;
    }
  }
}
