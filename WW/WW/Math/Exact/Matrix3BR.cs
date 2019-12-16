// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Matrix3BR
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
  public struct Matrix3BR : IEquatable<Matrix3BR>
  {
    public static readonly Matrix3BR Zero = Matrix3BR.smethod_0(BigRational.Zero, BigRational.Zero, BigRational.Zero, BigRational.Zero, BigRational.Zero, BigRational.Zero, BigRational.Zero, BigRational.Zero, BigRational.Zero);
    public static readonly Matrix3BR Identity = Matrix3BR.smethod_0(BigRational.One, BigRational.Zero, BigRational.Zero, BigRational.Zero, BigRational.One, BigRational.Zero, BigRational.Zero, BigRational.Zero, BigRational.One);
    public BigRational M00;
    public BigRational M01;
    public BigRational M02;
    public BigRational M10;
    public BigRational M11;
    public BigRational M12;
    public BigRational M20;
    public BigRational M21;
    public BigRational M22;

    public Matrix3BR(
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
      this.M00 = (BigRational) m00;
      this.M01 = (BigRational) m01;
      this.M02 = (BigRational) m02;
      this.M10 = (BigRational) m10;
      this.M11 = (BigRational) m11;
      this.M12 = (BigRational) m12;
      this.M20 = (BigRational) m20;
      this.M21 = (BigRational) m21;
      this.M22 = (BigRational) m22;
    }

    public Matrix3BR(
      BigRational m00,
      BigRational m01,
      BigRational m02,
      BigRational m10,
      BigRational m11,
      BigRational m12,
      BigRational m20,
      BigRational m21,
      BigRational m22)
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

    public Matrix3BR(BigRational[] elements)
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

    public Matrix3BR(IList<BigRational> elements)
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

    public Matrix3BR(Vector3BR column1, Vector3BR column2, Vector3BR column3)
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

    public Matrix3BR(Matrix3BR m)
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

    public static Matrix3BR Add(Matrix3BR a, Matrix3BR b)
    {
      return new Matrix3BR(a.M00 + b.M00, a.M01 + b.M01, a.M02 + b.M02, a.M10 + b.M10, a.M11 + b.M11, a.M12 + b.M12, a.M20 + b.M20, a.M21 + b.M21, a.M22 + b.M22);
    }

    public static Matrix3BR Subtract(Matrix3BR a, Matrix3BR b)
    {
      return new Matrix3BR(a.M00 - b.M00, a.M01 - b.M01, a.M02 - b.M02, a.M10 - b.M10, a.M11 - b.M11, a.M12 - b.M12, a.M20 - b.M20, a.M21 - b.M21, a.M22 - b.M22);
    }

    public static Matrix3BR Multiply(Matrix3BR a, Matrix3BR b)
    {
      return new Matrix3BR(a.M00 * b.M00 + a.M01 * b.M10 + a.M02 * b.M20, a.M00 * b.M01 + a.M01 * b.M11 + a.M02 * b.M21, a.M00 * b.M02 + a.M01 * b.M12 + a.M02 * b.M22, a.M10 * b.M00 + a.M11 * b.M10 + a.M12 * b.M20, a.M10 * b.M01 + a.M11 * b.M11 + a.M12 * b.M21, a.M10 * b.M02 + a.M11 * b.M12 + a.M12 * b.M22, a.M20 * b.M00 + a.M21 * b.M10 + a.M22 * b.M20, a.M20 * b.M01 + a.M21 * b.M11 + a.M22 * b.M21, a.M20 * b.M02 + a.M21 * b.M12 + a.M22 * b.M22);
    }

    public static Matrix3BR Transpose(Matrix3BR m)
    {
      Matrix3BR matrix3Br = new Matrix3BR(m);
      matrix3Br.Transpose();
      return matrix3Br;
    }

    public override int GetHashCode()
    {
      return this.M00.GetHashCode() ^ this.M01.GetHashCode() ^ this.M02.GetHashCode() ^ this.M10.GetHashCode() ^ this.M11.GetHashCode() ^ this.M12.GetHashCode() ^ this.M20.GetHashCode() ^ this.M21.GetHashCode() ^ this.M22.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Matrix3BR)
        return this.Equals((Matrix3BR) other);
      return false;
    }

    public override string ToString()
    {
      return string.Format("|{0}, {1}, {2}|\n|{3}, {4}, {5}|\n|{6}, {7}, {8}|\n", (object) this.M00, (object) this.M01, (object) this.M02, (object) this.M10, (object) this.M11, (object) this.M12, (object) this.M20, (object) this.M21, (object) this.M22);
    }

    public Vector2BR Transform(Vector2BR vector)
    {
      return new Vector2BR(this.M00 * vector.X + this.M01 * vector.Y, this.M10 * vector.X + this.M11 * vector.Y);
    }

    public Point2BR Transform(Point2BR point)
    {
      return new Point2BR(this.M00 * point.X + this.M01 * point.Y + this.M02, this.M10 * point.X + this.M11 * point.Y + this.M12);
    }

    public Vector3BR Transform(Vector3BR vector)
    {
      return new Vector3BR(this.M00 * vector.X + this.M01 * vector.Y + this.M02 * vector.Z, this.M10 * vector.X + this.M11 * vector.Y + this.M12 * vector.Z, this.M20 * vector.X + this.M21 * vector.Y + this.M22 * vector.Z);
    }

    public Point3BR Transform(Point3BR point)
    {
      return new Point3BR(this.M00 * point.X + this.M01 * point.Y + this.M02 * point.Z, this.M10 * point.X + this.M11 * point.Y + this.M12 * point.Z, this.M20 * point.X + this.M21 * point.Y + this.M22 * point.Z);
    }

    public Point2BR TransformTo2BR(Point3BR point)
    {
      return new Point2BR(this.M00 * point.X + this.M01 * point.Y + this.M02 * point.Z, this.M10 * point.X + this.M11 * point.Y + this.M12 * point.Z);
    }

    public BigRational GetDeterminant()
    {
      return this.M00 * this.M11 * this.M22 + this.M01 * this.M12 * this.M20 + this.M02 * this.M10 * this.M21 - this.M02 * this.M11 * this.M20 - this.M00 * this.M12 * this.M21 - this.M01 * this.M10 * this.M22;
    }

    public Matrix3BR GetAdjoint()
    {
      return new Matrix3BR(this.M11 * this.M22 - this.M12 * this.M21, -(this.M01 * this.M22 - this.M02 * this.M21), this.M01 * this.M12 - this.M02 * this.M11, -(this.M10 * this.M22 - this.M12 * this.M20), this.M00 * this.M22 - this.M02 * this.M20, -(this.M00 * this.M12 - this.M02 * this.M10), this.M10 * this.M21 - this.M11 * this.M20, -(this.M00 * this.M21 - this.M01 * this.M20), this.M00 * this.M11 - this.M01 * this.M10);
    }

    public Matrix3BR GetInverse()
    {
      BigRational determinant = this.GetDeterminant();
      return new Matrix3BR((this.M11 * this.M22 - this.M12 * this.M21) / determinant, -(this.M01 * this.M22 - this.M02 * this.M21) / determinant, (this.M01 * this.M12 - this.M02 * this.M11) / determinant, -(this.M10 * this.M22 - this.M12 * this.M20) / determinant, (this.M00 * this.M22 - this.M02 * this.M20) / determinant, -(this.M00 * this.M12 - this.M02 * this.M10) / determinant, (this.M10 * this.M21 - this.M11 * this.M20) / determinant, -(this.M00 * this.M21 - this.M01 * this.M20) / determinant, (this.M00 * this.M11 - this.M01 * this.M10) / determinant);
    }

    public Matrix3BR GetInverse(out bool couldInvert)
    {
      BigRational determinant = this.GetDeterminant();
      couldInvert = !determinant.IsZero;
      return new Matrix3BR((this.M11 * this.M22 - this.M12 * this.M21) / determinant, -(this.M01 * this.M22 - this.M02 * this.M21) / determinant, (this.M01 * this.M12 - this.M02 * this.M11) / determinant, -(this.M10 * this.M22 - this.M12 * this.M20) / determinant, (this.M00 * this.M22 - this.M02 * this.M20) / determinant, -(this.M00 * this.M12 - this.M02 * this.M10) / determinant, (this.M10 * this.M21 - this.M11 * this.M20) / determinant, -(this.M00 * this.M21 - this.M01 * this.M20) / determinant, (this.M00 * this.M11 - this.M01 * this.M10) / determinant);
    }

    public Matrix3BR GetTranspose()
    {
      Matrix3BR matrix3Br = this;
      matrix3Br.Transpose();
      return matrix3Br;
    }

    public Matrix2BR GetMinor(int removeRow, int removeColumn)
    {
      int index1 = 0;
      Matrix2BR matrix2Br = new Matrix2BR();
      for (int index2 = 0; index2 < 3; ++index2)
      {
        int index3 = 0;
        if (index2 != removeRow)
        {
          for (int index4 = 0; index4 < 3; ++index4)
          {
            if (index4 != removeColumn)
            {
              matrix2Br[index1, index3] = this[index2, index4];
              ++index3;
            }
          }
          ++index1;
        }
      }
      return matrix2Br;
    }

    public BigRational GetTrace()
    {
      return this.M00 + this.M11 + this.M22;
    }

    public void Transpose()
    {
      MathUtil.Swap<BigRational>(ref this.M01, ref this.M10);
      MathUtil.Swap<BigRational>(ref this.M02, ref this.M20);
      MathUtil.Swap<BigRational>(ref this.M12, ref this.M21);
    }

    public static bool operator ==(Matrix3BR a, Matrix3BR b)
    {
      return object.Equals((object) a, (object) b);
    }

    public static bool operator !=(Matrix3BR a, Matrix3BR b)
    {
      return !object.Equals((object) a, (object) b);
    }

    public static Matrix3BR operator +(Matrix3BR a, Matrix3BR b)
    {
      return Matrix3BR.Add(a, b);
    }

    public static Matrix3BR operator -(Matrix3BR a, Matrix3BR b)
    {
      return Matrix3BR.Subtract(a, b);
    }

    public static Matrix3BR operator *(Matrix3BR a, Matrix3BR b)
    {
      return Matrix3BR.Multiply(a, b);
    }

    public static Vector3BR operator *(Matrix3BR matrix, Vector3BR vector)
    {
      return matrix.Transform(vector);
    }

    public static Point3BR operator *(Matrix3BR matrix, Point3BR point)
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

    public BigRational this[int row, int column]
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

    private static Matrix3BR smethod_0(
      BigRational m00,
      BigRational m01,
      BigRational m02,
      BigRational m10,
      BigRational m11,
      BigRational m12,
      BigRational m20,
      BigRational m21,
      BigRational m22)
    {
      return new Matrix3BR(m00, m01, m02, m10, m11, m12, m20, m21, m22);
    }

    public bool Equals(Matrix3BR other)
    {
      if (this.M00 == other.M00 && this.M01 == other.M01 && (this.M02 == other.M02 && this.M10 == other.M10) && (this.M11 == other.M11 && this.M12 == other.M12 && (this.M20 == other.M20 && this.M21 == other.M21)))
        return this.M22 == other.M22;
      return false;
    }
  }
}
