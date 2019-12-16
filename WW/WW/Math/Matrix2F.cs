// Decompiled with JetBrains decompiler
// Type: WW.Math.Matrix2F
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
  public struct Matrix2F : IEquatable<Matrix2F>
  {
    public static readonly Matrix2F Zero = Matrix2F.smethod_0(0.0f, 0.0f, 0.0f, 0.0f);
    public static readonly Matrix2F Identity = Matrix2F.smethod_0(1f, 0.0f, 0.0f, 1f);
    private float M00;
    private float M01;
    private float M10;
    private float M11;

    public Matrix2F(float m00, float m01, float m10, float m11)
    {
      this.M00 = m00;
      this.M01 = m01;
      this.M10 = m10;
      this.M11 = m11;
    }

    public Matrix2F(float[] elements)
    {
      this.M00 = elements[0];
      this.M01 = elements[1];
      this.M10 = elements[2];
      this.M11 = elements[3];
    }

    public Matrix2F(IList<float> elements)
    {
      this.M00 = elements[0];
      this.M01 = elements[1];
      this.M10 = elements[2];
      this.M11 = elements[3];
    }

    public Matrix2F(Vector2F column1, Vector2F column2)
    {
      this.M00 = column1.X;
      this.M01 = column2.X;
      this.M10 = column1.Y;
      this.M11 = column2.Y;
    }

    public Matrix2F(Matrix2F m)
    {
      this.M00 = m.M00;
      this.M01 = m.M01;
      this.M10 = m.M10;
      this.M11 = m.M11;
    }

    public static Matrix2F Add(Matrix2F a, Matrix2F b)
    {
      return new Matrix2F(a.M00 + b.M00, a.M01 + b.M01, a.M10 + b.M10, a.M11 + b.M11);
    }

    public static Matrix2F Subtract(Matrix2F a, Matrix2F b)
    {
      return new Matrix2F(a.M00 - b.M00, a.M01 - b.M01, a.M10 - b.M10, a.M11 - b.M11);
    }

    public static Matrix2F Multiply(Matrix2F a, Matrix2F b)
    {
      return new Matrix2F((float) ((double) a.M00 * (double) b.M00 + (double) a.M01 * (double) b.M10), (float) ((double) a.M00 * (double) b.M01 + (double) a.M01 * (double) b.M11), (float) ((double) a.M10 * (double) b.M00 + (double) a.M11 * (double) b.M10), (float) ((double) a.M10 * (double) b.M01 + (double) a.M11 * (double) b.M11));
    }

    public static Matrix2F Transpose(Matrix2F m)
    {
      Matrix2F matrix2F = new Matrix2F(m);
      matrix2F.Transpose();
      return matrix2F;
    }

    public override int GetHashCode()
    {
      return this.M00.GetHashCode() ^ this.M01.GetHashCode() ^ this.M10.GetHashCode() ^ this.M11.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Matrix2F)
        return this.Equals((Matrix2F) other);
      return false;
    }

    public override string ToString()
    {
      return string.Format("|{0}, {1}|\n|{2}, {3}|\n", (object) this.M00, (object) this.M01, (object) this.M10, (object) this.M11);
    }

    public Vector2F Transform(Vector2F vector)
    {
      return new Vector2F((float) ((double) this.M00 * (double) vector.X + (double) this.M01 * (double) vector.Y), (float) ((double) this.M10 * (double) vector.X + (double) this.M11 * (double) vector.Y));
    }

    public Point2F Transform(Point2F point)
    {
      return new Point2F((float) ((double) this.M00 * (double) point.X + (double) this.M01 * (double) point.Y), (float) ((double) this.M10 * (double) point.X + (double) this.M11 * (double) point.Y));
    }

    public float GetDeterminant()
    {
      return (float) ((double) this.M00 * (double) this.M11 - (double) this.M01 * (double) this.M10);
    }

    public Matrix2F GetInverse()
    {
      float num = 1f / this.GetDeterminant();
      return new Matrix2F(this.M11 * num, -this.M01 * num, -this.M10 * num, this.M00 * num);
    }

    public Matrix2F GetInverse(out bool couldInvert)
    {
      float determinant = this.GetDeterminant();
      float num = 1f / determinant;
      couldInvert = (double) determinant != 0.0;
      return new Matrix2F(this.M11 * num, -this.M01 * num, -this.M10 * num, this.M00 * num);
    }

    public Matrix2F GetAdjoint()
    {
      return new Matrix2F(this.M11, -this.M01, -this.M10, this.M00);
    }

    public Matrix2F GetTranspose()
    {
      Matrix2F matrix2F = this;
      matrix2F.Transpose();
      return matrix2F;
    }

    public float GetMinor(int removeRow, int removeColumn)
    {
      int num1 = 0;
      float num2 = 0.0f;
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

    public float GetTrace()
    {
      return this.M00 + this.M11;
    }

    public void Transpose()
    {
      MathUtil.Swap(ref this.M01, ref this.M10);
    }

    public static bool AreApproxEqual(Matrix2F a, Matrix2F b)
    {
      return Matrix2F.AreApproxEqual(a, b, 4.768372E-07f);
    }

    public static bool AreApproxEqual(Matrix2F a, Matrix2F b, float tolerance)
    {
      if ((double) System.Math.Abs(b.M00 - a.M00) <= (double) tolerance && (double) System.Math.Abs(b.M01 - a.M01) <= (double) tolerance && (double) System.Math.Abs(b.M10 - a.M10) <= (double) tolerance)
        return (double) System.Math.Abs(b.M11 - a.M11) <= (double) tolerance;
      return false;
    }

    public static bool operator ==(Matrix2F a, Matrix2F b)
    {
      return object.Equals((object) a, (object) b);
    }

    public static bool operator !=(Matrix2F a, Matrix2F b)
    {
      return !object.Equals((object) a, (object) b);
    }

    public static Matrix2F operator +(Matrix2F a, Matrix2F b)
    {
      return Matrix2F.Add(a, b);
    }

    public static Matrix2F operator -(Matrix2F a, Matrix2F b)
    {
      return Matrix2F.Subtract(a, b);
    }

    public static Matrix2F operator *(Matrix2F a, Matrix2F b)
    {
      return Matrix2F.Multiply(a, b);
    }

    public static Vector2F operator *(Matrix2F matrix, Vector2F vector)
    {
      return matrix.Transform(vector);
    }

    public static Point2F operator *(Matrix2F matrix, Point2F point)
    {
      return matrix.Transform(point);
    }

    public unsafe float this[int index]
    {
      [SecurityCritical] get
      {
        if (index < 0 || index >= 4)
          throw new IndexOutOfRangeException("Invalid matrix index!");
        fixed (float* numPtr = &this.M00)
          return numPtr[index];
      }
      [SecurityCritical] set
      {
        if (index < 0 || index >= 4)
          throw new IndexOutOfRangeException("Invalid matrix index!");
        fixed (float* numPtr = &this.M00)
          numPtr[index] = value;
      }
    }

    public float this[int row, int column]
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

    private static Matrix2F smethod_0(float m00, float m01, float m10, float m11)
    {
      return new Matrix2F(m00, m01, m10, m11);
    }

    public bool Equals(Matrix2F other)
    {
      if ((double) this.M00 == (double) other.M00 && (double) this.M01 == (double) other.M01 && (double) this.M10 == (double) other.M10)
        return (double) this.M11 == (double) other.M11;
      return false;
    }
  }
}
