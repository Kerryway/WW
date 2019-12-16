// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Matrix2LR
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WW.Math.Exact
{
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public struct Matrix2LR : IEquatable<Matrix2LR>
  {
    public static readonly Matrix2LR Zero = Matrix2LR.smethod_0(LongRational.Zero, LongRational.Zero, LongRational.Zero, LongRational.Zero);
    public static readonly Matrix2LR Identity = Matrix2LR.smethod_0(LongRational.One, LongRational.Zero, LongRational.Zero, LongRational.One);
    public LongRational M00;
    public LongRational M01;
    public LongRational M10;
    public LongRational M11;

    public Matrix2LR(LongRational m00, LongRational m01, LongRational m10, LongRational m11)
    {
      this.M00 = m00;
      this.M01 = m01;
      this.M10 = m10;
      this.M11 = m11;
    }

    public Matrix2LR(LongRational[] elements)
    {
      this.M00 = elements[0];
      this.M01 = elements[1];
      this.M10 = elements[2];
      this.M11 = elements[3];
    }

    public Matrix2LR(IList<LongRational> elements)
    {
      this.M00 = elements[0];
      this.M01 = elements[1];
      this.M10 = elements[2];
      this.M11 = elements[3];
    }

    public Matrix2LR(Vector2LR column1, Vector2LR column2)
    {
      this.M00 = column1.X;
      this.M01 = column2.X;
      this.M10 = column1.Y;
      this.M11 = column2.Y;
    }

    public Matrix2LR(Matrix2LR m)
    {
      this.M00 = m.M00;
      this.M01 = m.M01;
      this.M10 = m.M10;
      this.M11 = m.M11;
    }

    public static Matrix2LR Add(Matrix2LR a, Matrix2LR b)
    {
      return new Matrix2LR(a.M00 + b.M00, a.M01 + b.M01, a.M10 + b.M10, a.M11 + b.M11);
    }

    public static Matrix2LR Subtract(Matrix2LR a, Matrix2LR b)
    {
      return new Matrix2LR(a.M00 - b.M00, a.M01 - b.M01, a.M10 - b.M10, a.M11 - b.M11);
    }

    public static Matrix2LR Multiply(Matrix2LR a, Matrix2LR b)
    {
      return new Matrix2LR(a.M00 * b.M00 + a.M01 * b.M10, a.M00 * b.M01 + a.M01 * b.M11, a.M10 * b.M00 + a.M11 * b.M10, a.M10 * b.M01 + a.M11 * b.M11);
    }

    public static Matrix2LR Transpose(Matrix2LR m)
    {
      Matrix2LR matrix2Lr = new Matrix2LR(m);
      matrix2Lr.Transpose();
      return matrix2Lr;
    }

    public override int GetHashCode()
    {
      return this.M00.GetHashCode() ^ this.M01.GetHashCode() ^ this.M10.GetHashCode() ^ this.M11.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Matrix2LR)
        return this.Equals((Matrix2LR) other);
      return false;
    }

    public override string ToString()
    {
      return string.Format("|{0}, {1}|\n|{2}, {3}|\n", (object) this.M00, (object) this.M01, (object) this.M10, (object) this.M11);
    }

    public Vector2LR Transform(Vector2LR vector)
    {
      return new Vector2LR(this.M00 * vector.X + this.M01 * vector.Y, this.M10 * vector.X + this.M11 * vector.Y);
    }

    public Point2LR Transform(Point2LR point)
    {
      return new Point2LR(this.M00 * point.X + this.M01 * point.Y, this.M10 * point.X + this.M11 * point.Y);
    }

    public LongRational GetDeterminant()
    {
      return this.M00 * this.M11 - this.M01 * this.M10;
    }

    public Matrix2LR GetInverse()
    {
      LongRational determinant = this.GetDeterminant();
      return new Matrix2LR(this.M11 / determinant, -this.M01 / determinant, -this.M10 / determinant, this.M00 / determinant);
    }

    public Matrix2LR GetInverse(out bool couldInvert)
    {
      LongRational determinant = this.GetDeterminant();
      couldInvert = !determinant.IsZero;
      return new Matrix2LR(this.M11 / determinant, -this.M01 / determinant, -this.M10 / determinant, this.M00 / determinant);
    }

    public Matrix2LR GetAdjoint()
    {
      return new Matrix2LR(this.M11, -this.M01, -this.M10, this.M00);
    }

    public Matrix2LR GetTranspose()
    {
      Matrix2LR matrix2Lr = this;
      matrix2Lr.Transpose();
      return matrix2Lr;
    }

    public LongRational GetMinor(int removeRow, int removeColumn)
    {
      int num1 = 0;
      LongRational zero = LongRational.Zero;
      for (int index1 = 0; index1 < 2; ++index1)
      {
        int num2 = 0;
        if (index1 != removeRow)
        {
          for (int index2 = 0; index2 < 2; ++index2)
          {
            if (index2 != removeColumn)
            {
              zero = this[index1, index2];
              ++num2;
            }
          }
          ++num1;
        }
      }
      return zero;
    }

    public LongRational GetTrace()
    {
      return this.M00 + this.M11;
    }

    public void Transpose()
    {
      MathUtil.Swap<LongRational>(ref this.M01, ref this.M10);
    }

    public Matrix ToMatrix()
    {
      return new Matrix((float) (double) this.M00, (float) (double) this.M10, (float) (double) this.M01, (float) (double) this.M11, 0.0f, 0.0f);
    }

    public static bool operator ==(Matrix2LR a, Matrix2LR b)
    {
      return object.Equals((object) a, (object) b);
    }

    public static bool operator !=(Matrix2LR a, Matrix2LR b)
    {
      return !object.Equals((object) a, (object) b);
    }

    public static Matrix2LR operator +(Matrix2LR a, Matrix2LR b)
    {
      return Matrix2LR.Add(a, b);
    }

    public static Matrix2LR operator -(Matrix2LR a, Matrix2LR b)
    {
      return Matrix2LR.Subtract(a, b);
    }

    public static Matrix2LR operator *(Matrix2LR a, Matrix2LR b)
    {
      return Matrix2LR.Multiply(a, b);
    }

    public static Vector2LR operator *(Matrix2LR matrix, Vector2LR vector)
    {
      return matrix.Transform(vector);
    }

    public static Point2LR operator *(Matrix2LR matrix, Point2LR point)
    {
      return matrix.Transform(point);
    }

    public LongRational this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return this.M00;
          case 1:
            return this.M01;
          case 2:
            return this.M10;
          case 3:
            return this.M11;
          default:
            throw new IndexOutOfRangeException("Invalid matrix index!");
        }
      }
      set
      {
        switch (index)
        {
          case 0:
            this.M00 = value;
            break;
          case 1:
            this.M01 = value;
            break;
          case 2:
            this.M10 = value;
            break;
          case 3:
            this.M11 = value;
            break;
          default:
            throw new IndexOutOfRangeException("Invalid matrix index!");
        }
      }
    }

    public LongRational this[int row, int column]
    {
      get
      {
        return this[(row << 1) + column];
      }
      set
      {
        this[(row << 1) + column] = value;
      }
    }

    private static Matrix2LR smethod_0(
      LongRational m00,
      LongRational m01,
      LongRational m10,
      LongRational m11)
    {
      return new Matrix2LR(m00, m01, m10, m11);
    }

    public bool Equals(Matrix2LR other)
    {
      if (this.M00 == other.M00 && this.M01 == other.M01 && this.M10 == other.M10)
        return this.M11 == other.M11;
      return false;
    }
  }
}
