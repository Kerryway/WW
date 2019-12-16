// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Matrix3BI
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WW.Math.Exact
{
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public struct Matrix3BI : IEquatable<Matrix3BI>
  {
    public static readonly Matrix3BI Zero = Matrix3BI.smethod_0(BigInteger.Zero, BigInteger.Zero, BigInteger.Zero, BigInteger.Zero, BigInteger.Zero, BigInteger.Zero, BigInteger.Zero, BigInteger.Zero, BigInteger.Zero);
    public static readonly Matrix3BI Identity = Matrix3BI.smethod_0(BigInteger.One, BigInteger.Zero, BigInteger.Zero, BigInteger.Zero, BigInteger.One, BigInteger.Zero, BigInteger.Zero, BigInteger.Zero, BigInteger.One);
    public BigInteger M00;
    public BigInteger M01;
    public BigInteger M02;
    public BigInteger M10;
    public BigInteger M11;
    public BigInteger M12;
    public BigInteger M20;
    public BigInteger M21;
    public BigInteger M22;

    public Matrix3BI(
      long m00,
      long m01,
      long m02,
      long m10,
      long m11,
      long m12,
      long m20,
      long m21,
      long m22)
    {
      this.M00 = (BigInteger) m00;
      this.M01 = (BigInteger) m01;
      this.M02 = (BigInteger) m02;
      this.M10 = (BigInteger) m10;
      this.M11 = (BigInteger) m11;
      this.M12 = (BigInteger) m12;
      this.M20 = (BigInteger) m20;
      this.M21 = (BigInteger) m21;
      this.M22 = (BigInteger) m22;
    }

    public Matrix3BI(
      BigInteger m00,
      BigInteger m01,
      BigInteger m02,
      BigInteger m10,
      BigInteger m11,
      BigInteger m12,
      BigInteger m20,
      BigInteger m21,
      BigInteger m22)
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

    public Matrix3BI(BigInteger[] elements)
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

    public Matrix3BI(IList<BigInteger> elements)
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

    public Matrix3BI(Matrix3BI m)
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

    public static Matrix3BI Add(Matrix3BI a, Matrix3BI b)
    {
      return new Matrix3BI(a.M00 + b.M00, a.M01 + b.M01, a.M02 + b.M02, a.M10 + b.M10, a.M11 + b.M11, a.M12 + b.M12, a.M20 + b.M20, a.M21 + b.M21, a.M22 + b.M22);
    }

    public static Matrix3BI Subtract(Matrix3BI a, Matrix3BI b)
    {
      return new Matrix3BI(a.M00 - b.M00, a.M01 - b.M01, a.M02 - b.M02, a.M10 - b.M10, a.M11 - b.M11, a.M12 - b.M12, a.M20 - b.M20, a.M21 - b.M21, a.M22 - b.M22);
    }

    public static Matrix3BI Multiply(Matrix3BI a, Matrix3BI b)
    {
      return new Matrix3BI(a.M00 * b.M00 + a.M01 * b.M10 + a.M02 * b.M20, a.M00 * b.M01 + a.M01 * b.M11 + a.M02 * b.M21, a.M00 * b.M02 + a.M01 * b.M12 + a.M02 * b.M22, a.M10 * b.M00 + a.M11 * b.M10 + a.M12 * b.M20, a.M10 * b.M01 + a.M11 * b.M11 + a.M12 * b.M21, a.M10 * b.M02 + a.M11 * b.M12 + a.M12 * b.M22, a.M20 * b.M00 + a.M21 * b.M10 + a.M22 * b.M20, a.M20 * b.M01 + a.M21 * b.M11 + a.M22 * b.M21, a.M20 * b.M02 + a.M21 * b.M12 + a.M22 * b.M22);
    }

    public static Matrix3BI Transpose(Matrix3BI m)
    {
      Matrix3BI matrix3Bi = new Matrix3BI(m);
      matrix3Bi.Transpose();
      return matrix3Bi;
    }

    public override int GetHashCode()
    {
      return this.M00.GetHashCode() ^ this.M01.GetHashCode() ^ this.M02.GetHashCode() ^ this.M10.GetHashCode() ^ this.M11.GetHashCode() ^ this.M12.GetHashCode() ^ this.M20.GetHashCode() ^ this.M21.GetHashCode() ^ this.M22.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Matrix3BI)
        return this.Equals((Matrix3BI) other);
      return false;
    }

    public override string ToString()
    {
      return string.Format("|{0}, {1}, {2}|\n|{3}, {4}, {5}|\n|{6}, {7}, {8}|\n", (object) this.M00, (object) this.M01, (object) this.M02, (object) this.M10, (object) this.M11, (object) this.M12, (object) this.M20, (object) this.M21, (object) this.M22);
    }

    public BigInteger GetDeterminant()
    {
      return this.M00 * this.M11 * this.M22 + this.M01 * this.M12 * this.M20 + this.M02 * this.M10 * this.M21 - this.M02 * this.M11 * this.M20 - this.M00 * this.M12 * this.M21 - this.M01 * this.M10 * this.M22;
    }

    public Matrix3BI GetAdjoint()
    {
      return new Matrix3BI(this.M11 * this.M22 - this.M12 * this.M21, -(this.M01 * this.M22 - this.M02 * this.M21), this.M01 * this.M12 - this.M02 * this.M11, -(this.M10 * this.M22 - this.M12 * this.M20), this.M00 * this.M22 - this.M02 * this.M20, -(this.M00 * this.M12 - this.M02 * this.M10), this.M10 * this.M21 - this.M11 * this.M20, -(this.M00 * this.M21 - this.M01 * this.M20), this.M00 * this.M11 - this.M01 * this.M10);
    }

    public Matrix3BI GetInverse()
    {
      BigInteger determinant = this.GetDeterminant();
      return new Matrix3BI((this.M11 * this.M22 - this.M12 * this.M21) / determinant, -(this.M01 * this.M22 - this.M02 * this.M21) / determinant, (this.M01 * this.M12 - this.M02 * this.M11) / determinant, -(this.M10 * this.M22 - this.M12 * this.M20) / determinant, (this.M00 * this.M22 - this.M02 * this.M20) / determinant, -(this.M00 * this.M12 - this.M02 * this.M10) / determinant, (this.M10 * this.M21 - this.M11 * this.M20) / determinant, -(this.M00 * this.M21 - this.M01 * this.M20) / determinant, (this.M00 * this.M11 - this.M01 * this.M10) / determinant);
    }

    public Matrix3BI GetInverse(out bool couldInvert)
    {
      BigInteger determinant = this.GetDeterminant();
      couldInvert = !determinant.IsZero;
      return new Matrix3BI((this.M11 * this.M22 - this.M12 * this.M21) / determinant, -(this.M01 * this.M22 - this.M02 * this.M21) / determinant, (this.M01 * this.M12 - this.M02 * this.M11) / determinant, -(this.M10 * this.M22 - this.M12 * this.M20) / determinant, (this.M00 * this.M22 - this.M02 * this.M20) / determinant, -(this.M00 * this.M12 - this.M02 * this.M10) / determinant, (this.M10 * this.M21 - this.M11 * this.M20) / determinant, -(this.M00 * this.M21 - this.M01 * this.M20) / determinant, (this.M00 * this.M11 - this.M01 * this.M10) / determinant);
    }

    public Matrix3BI GetTranspose()
    {
      Matrix3BI matrix3Bi = this;
      matrix3Bi.Transpose();
      return matrix3Bi;
    }

    public Matrix2BI GetMinor(int removeRow, int removeColumn)
    {
      int index1 = 0;
      Matrix2BI matrix2Bi = new Matrix2BI();
      for (int index2 = 0; index2 < 3; ++index2)
      {
        int index3 = 0;
        if (index2 != removeRow)
        {
          for (int index4 = 0; index4 < 3; ++index4)
          {
            if (index4 != removeColumn)
            {
              matrix2Bi[index1, index3] = this[index2, index4];
              ++index3;
            }
          }
          ++index1;
        }
      }
      return matrix2Bi;
    }

    public BigInteger GetTrace()
    {
      return this.M00 + this.M11 + this.M22;
    }

    public void Transpose()
    {
      MathUtil.Swap<BigInteger>(ref this.M01, ref this.M10);
      MathUtil.Swap<BigInteger>(ref this.M02, ref this.M20);
      MathUtil.Swap<BigInteger>(ref this.M12, ref this.M21);
    }

    public static bool operator ==(Matrix3BI a, Matrix3BI b)
    {
      return object.Equals((object) a, (object) b);
    }

    public static bool operator !=(Matrix3BI a, Matrix3BI b)
    {
      return !object.Equals((object) a, (object) b);
    }

    public static Matrix3BI operator +(Matrix3BI a, Matrix3BI b)
    {
      return Matrix3BI.Add(a, b);
    }

    public static Matrix3BI operator -(Matrix3BI a, Matrix3BI b)
    {
      return Matrix3BI.Subtract(a, b);
    }

    public static Matrix3BI operator *(Matrix3BI a, Matrix3BI b)
    {
      return Matrix3BI.Multiply(a, b);
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
            return this.M02;
          case 3:
            return this.M10;
          case 4:
            return this.M11;
          case 5:
            return this.M12;
          case 6:
            return this.M20;
          case 7:
            return this.M21;
          case 8:
            return this.M22;
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
            this.M02 = value;
            break;
          case 3:
            this.M10 = value;
            break;
          case 4:
            this.M11 = value;
            break;
          case 5:
            this.M12 = value;
            break;
          case 6:
            this.M20 = value;
            break;
          case 7:
            this.M21 = value;
            break;
          case 8:
            this.M22 = value;
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
        return this[row * 3 + column];
      }
      set
      {
        this[row * 3 + column] = value;
      }
    }

    private static Matrix3BI smethod_0(
      BigInteger m00,
      BigInteger m01,
      BigInteger m02,
      BigInteger m10,
      BigInteger m11,
      BigInteger m12,
      BigInteger m20,
      BigInteger m21,
      BigInteger m22)
    {
      return new Matrix3BI(m00, m01, m02, m10, m11, m12, m20, m21, m22);
    }

    public bool Equals(Matrix3BI other)
    {
      if (this.M00 == other.M00 && this.M01 == other.M01 && (this.M02 == other.M02 && this.M10 == other.M10) && (this.M11 == other.M11 && this.M12 == other.M12 && (this.M20 == other.M20 && this.M21 == other.M21)))
        return this.M22 == other.M22;
      return false;
    }
  }
}
