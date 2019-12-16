// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Matrix2BI
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
  public struct Matrix2BI : IEquatable<Matrix2BI>
  {
    public static readonly Matrix2BI Zero = Matrix2BI.smethod_0(BigInteger.Zero, BigInteger.Zero, BigInteger.Zero, BigInteger.Zero);
    public static readonly Matrix2BI Identity = Matrix2BI.smethod_0(BigInteger.One, BigInteger.Zero, BigInteger.Zero, BigInteger.One);
    public BigInteger M00;
    public BigInteger M01;
    public BigInteger M10;
    public BigInteger M11;

    public Matrix2BI(BigInteger m00, BigInteger m01, BigInteger m10, BigInteger m11)
    {
      this.M00 = m00;
      this.M01 = m01;
      this.M10 = m10;
      this.M11 = m11;
    }

    public Matrix2BI(BigInteger[] elements)
    {
      this.M00 = elements[0];
      this.M01 = elements[1];
      this.M10 = elements[2];
      this.M11 = elements[3];
    }

    public Matrix2BI(IList<BigInteger> elements)
    {
      this.M00 = elements[0];
      this.M01 = elements[1];
      this.M10 = elements[2];
      this.M11 = elements[3];
    }

    public Matrix2BI(Matrix2BI m)
    {
      this.M00 = m.M00;
      this.M01 = m.M01;
      this.M10 = m.M10;
      this.M11 = m.M11;
    }

    public static Matrix2BI Add(Matrix2BI a, Matrix2BI b)
    {
      return new Matrix2BI(a.M00 + b.M00, a.M01 + b.M01, a.M10 + b.M10, a.M11 + b.M11);
    }

    public static Matrix2BI Subtract(Matrix2BI a, Matrix2BI b)
    {
      return new Matrix2BI(a.M00 - b.M00, a.M01 - b.M01, a.M10 - b.M10, a.M11 - b.M11);
    }

    public static Matrix2BI Multiply(Matrix2BI a, Matrix2BI b)
    {
      return new Matrix2BI(a.M00 * b.M00 + a.M01 * b.M10, a.M00 * b.M01 + a.M01 * b.M11, a.M10 * b.M00 + a.M11 * b.M10, a.M10 * b.M01 + a.M11 * b.M11);
    }

    public static Matrix2BI Transpose(Matrix2BI m)
    {
      Matrix2BI matrix2Bi = new Matrix2BI(m);
      matrix2Bi.Transpose();
      return matrix2Bi;
    }

    public override int GetHashCode()
    {
      return this.M00.GetHashCode() ^ this.M01.GetHashCode() ^ this.M10.GetHashCode() ^ this.M11.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Matrix2BI)
        return this.Equals((Matrix2BI) other);
      return false;
    }

    public override string ToString()
    {
      return string.Format("|{0}, {1}|\n|{2}, {3}|\n", (object) this.M00, (object) this.M01, (object) this.M10, (object) this.M11);
    }

    public BigInteger GetDeterminant()
    {
      return this.M00 * this.M11 - this.M01 * this.M10;
    }

    public Matrix2BI GetInverse()
    {
      BigInteger determinant = this.GetDeterminant();
      return new Matrix2BI(this.M11 / determinant, -this.M01 / determinant, -this.M10 / determinant, this.M00 / determinant);
    }

    public Matrix2BI GetInverse(out bool couldInvert)
    {
      BigInteger determinant = this.GetDeterminant();
      couldInvert = !determinant.IsZero;
      return new Matrix2BI(this.M11 / determinant, -this.M01 / determinant, -this.M10 / determinant, this.M00 / determinant);
    }

    public Matrix2BI GetAdjoint()
    {
      return new Matrix2BI(this.M11, -this.M01, -this.M10, this.M00);
    }

    public Matrix2BI GetTranspose()
    {
      Matrix2BI matrix2Bi = this;
      matrix2Bi.Transpose();
      return matrix2Bi;
    }

    public BigInteger GetMinor(int removeRow, int removeColumn)
    {
      int num1 = 0;
      BigInteger zero = BigInteger.Zero;
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

    public BigInteger GetTrace()
    {
      return this.M00 + this.M11;
    }

    public void Transpose()
    {
      MathUtil.Swap<BigInteger>(ref this.M01, ref this.M10);
    }

    public Matrix ToMatrix()
    {
      return new Matrix((float) (double) this.M00, (float) (double) this.M10, (float) (double) this.M01, (float) (double) this.M11, 0.0f, 0.0f);
    }

    public static bool operator ==(Matrix2BI a, Matrix2BI b)
    {
      return object.Equals((object) a, (object) b);
    }

    public static bool operator !=(Matrix2BI a, Matrix2BI b)
    {
      return !object.Equals((object) a, (object) b);
    }

    public static Matrix2BI operator +(Matrix2BI a, Matrix2BI b)
    {
      return Matrix2BI.Add(a, b);
    }

    public static Matrix2BI operator -(Matrix2BI a, Matrix2BI b)
    {
      return Matrix2BI.Subtract(a, b);
    }

    public static Matrix2BI operator *(Matrix2BI a, Matrix2BI b)
    {
      return Matrix2BI.Multiply(a, b);
    }

    public BigInteger this[int index]
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

    public BigInteger this[int row, int column]
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

    private static Matrix2BI smethod_0(
      BigInteger m00,
      BigInteger m01,
      BigInteger m10,
      BigInteger m11)
    {
      return new Matrix2BI(m00, m01, m10, m11);
    }

    public bool Equals(Matrix2BI other)
    {
      if (this.M00 == other.M00 && this.M01 == other.M01 && this.M10 == other.M10)
        return this.M11 == other.M11;
      return false;
    }
  }
}
