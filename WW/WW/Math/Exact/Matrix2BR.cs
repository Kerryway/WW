// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Matrix2BR
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
  public struct Matrix2BR : IEquatable<Matrix2BR>
  {
    public static readonly Matrix2BR Zero = Matrix2BR.smethod_0(BigRational.Zero, BigRational.Zero, BigRational.Zero, BigRational.Zero);
    public static readonly Matrix2BR Identity = Matrix2BR.smethod_0(BigRational.One, BigRational.Zero, BigRational.Zero, BigRational.One);
    public BigRational M00;
    public BigRational M01;
    public BigRational M10;
    public BigRational M11;

    public Matrix2BR(BigRational m00, BigRational m01, BigRational m10, BigRational m11)
    {
      this.M00 = m00;
      this.M01 = m01;
      this.M10 = m10;
      this.M11 = m11;
    }

    public Matrix2BR(BigRational[] elements)
    {
      this.M00 = elements[0];
      this.M01 = elements[1];
      this.M10 = elements[2];
      this.M11 = elements[3];
    }

    public Matrix2BR(IList<BigRational> elements)
    {
      this.M00 = elements[0];
      this.M01 = elements[1];
      this.M10 = elements[2];
      this.M11 = elements[3];
    }

    public Matrix2BR(Vector2BR column1, Vector2BR column2)
    {
      this.M00 = column1.X;
      this.M01 = column2.X;
      this.M10 = column1.Y;
      this.M11 = column2.Y;
    }

    public Matrix2BR(Matrix2BR m)
    {
      this.M00 = m.M00;
      this.M01 = m.M01;
      this.M10 = m.M10;
      this.M11 = m.M11;
    }

    public static Matrix2BR Add(Matrix2BR a, Matrix2BR b)
    {
      return new Matrix2BR(a.M00 + b.M00, a.M01 + b.M01, a.M10 + b.M10, a.M11 + b.M11);
    }

    public static Matrix2BR Subtract(Matrix2BR a, Matrix2BR b)
    {
      return new Matrix2BR(a.M00 - b.M00, a.M01 - b.M01, a.M10 - b.M10, a.M11 - b.M11);
    }

    public static Matrix2BR Multiply(Matrix2BR a, Matrix2BR b)
    {
      return new Matrix2BR(a.M00 * b.M00 + a.M01 * b.M10, a.M00 * b.M01 + a.M01 * b.M11, a.M10 * b.M00 + a.M11 * b.M10, a.M10 * b.M01 + a.M11 * b.M11);
    }

    public static Matrix2BR Transpose(Matrix2BR m)
    {
      Matrix2BR matrix2Br = new Matrix2BR(m);
      matrix2Br.Transpose();
      return matrix2Br;
    }

    public override int GetHashCode()
    {
      return this.M00.GetHashCode() ^ this.M01.GetHashCode() ^ this.M10.GetHashCode() ^ this.M11.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Matrix2BR)
        return this.Equals((Matrix2BR) other);
      return false;
    }

    public override string ToString()
    {
      return string.Format("|{0}, {1}|\n|{2}, {3}|\n", (object) this.M00, (object) this.M01, (object) this.M10, (object) this.M11);
    }

    public Vector2BR Transform(Vector2BR vector)
    {
      return new Vector2BR(this.M00 * vector.X + this.M01 * vector.Y, this.M10 * vector.X + this.M11 * vector.Y);
    }

    public Point2BR Transform(Point2BR point)
    {
      return new Point2BR(this.M00 * point.X + this.M01 * point.Y, this.M10 * point.X + this.M11 * point.Y);
    }

    public BigRational GetDeterminant()
    {
      return this.M00 * this.M11 - this.M01 * this.M10;
    }

    public Matrix2BR GetInverse()
    {
      BigRational determinant = this.GetDeterminant();
      return new Matrix2BR(this.M11 / determinant, -this.M01 / determinant, -this.M10 / determinant, this.M00 / determinant);
    }

    public Matrix2BR GetInverse(out bool couldInvert)
    {
      BigRational determinant = this.GetDeterminant();
      couldInvert = !determinant.IsZero;
      return new Matrix2BR(this.M11 / determinant, -this.M01 / determinant, -this.M10 / determinant, this.M00 / determinant);
    }

    public Matrix2BR GetAdjoint()
    {
      return new Matrix2BR(this.M11, -this.M01, -this.M10, this.M00);
    }

    public Matrix2BR GetTranspose()
    {
      Matrix2BR matrix2Br = this;
      matrix2Br.Transpose();
      return matrix2Br;
    }

    public BigRational GetMinor(int removeRow, int removeColumn)
    {
      int num1 = 0;
      BigRational zero = BigRational.Zero;
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

    public BigRational GetTrace()
    {
      return this.M00 + this.M11;
    }

    public void Transpose()
    {
      MathUtil.Swap<BigRational>(ref this.M01, ref this.M10);
    }

    public Matrix ToMatrix()
    {
      return new Matrix((float) (double) this.M00, (float) (double) this.M10, (float) (double) this.M01, (float) (double) this.M11, 0.0f, 0.0f);
    }

    public static bool operator ==(Matrix2BR a, Matrix2BR b)
    {
      return object.Equals((object) a, (object) b);
    }

    public static bool operator !=(Matrix2BR a, Matrix2BR b)
    {
      return !object.Equals((object) a, (object) b);
    }

    public static Matrix2BR operator +(Matrix2BR a, Matrix2BR b)
    {
      return Matrix2BR.Add(a, b);
    }

    public static Matrix2BR operator -(Matrix2BR a, Matrix2BR b)
    {
      return Matrix2BR.Subtract(a, b);
    }

    public static Matrix2BR operator *(Matrix2BR a, Matrix2BR b)
    {
      return Matrix2BR.Multiply(a, b);
    }

    public static Vector2BR operator *(Matrix2BR matrix, Vector2BR vector)
    {
      return matrix.Transform(vector);
    }

    public static Point2BR operator *(Matrix2BR matrix, Point2BR point)
    {
      return matrix.Transform(point);
    }

    public BigRational this[int index]
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

    public BigRational this[int row, int column]
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

    private static Matrix2BR smethod_0(
      BigRational m00,
      BigRational m01,
      BigRational m10,
      BigRational m11)
    {
      return new Matrix2BR(m00, m01, m10, m11);
    }

    public bool Equals(Matrix2BR other)
    {
      if (this.M00 == other.M00 && this.M01 == other.M01 && this.M10 == other.M10)
        return this.M11 == other.M11;
      return false;
    }
  }
}
