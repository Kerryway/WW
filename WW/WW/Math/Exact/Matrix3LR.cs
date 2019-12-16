// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Matrix3LR
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
  public struct Matrix3LR : IEquatable<Matrix3LR>
  {
    public static readonly Matrix3LR Zero = Matrix3LR.smethod_0(LongRational.Zero, LongRational.Zero, LongRational.Zero, LongRational.Zero, LongRational.Zero, LongRational.Zero, LongRational.Zero, LongRational.Zero, LongRational.Zero);
    public static readonly Matrix3LR Identity = Matrix3LR.smethod_0(LongRational.One, LongRational.Zero, LongRational.Zero, LongRational.Zero, LongRational.One, LongRational.Zero, LongRational.Zero, LongRational.Zero, LongRational.One);
    public LongRational M00;
    public LongRational M01;
    public LongRational M02;
    public LongRational M10;
    public LongRational M11;
    public LongRational M12;
    public LongRational M20;
    public LongRational M21;
    public LongRational M22;

    public Matrix3LR(
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
      this.M00 = (LongRational) m00;
      this.M01 = (LongRational) m01;
      this.M02 = (LongRational) m02;
      this.M10 = (LongRational) m10;
      this.M11 = (LongRational) m11;
      this.M12 = (LongRational) m12;
      this.M20 = (LongRational) m20;
      this.M21 = (LongRational) m21;
      this.M22 = (LongRational) m22;
    }

    public Matrix3LR(
      LongRational m00,
      LongRational m01,
      LongRational m02,
      LongRational m10,
      LongRational m11,
      LongRational m12,
      LongRational m20,
      LongRational m21,
      LongRational m22)
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

    public Matrix3LR(LongRational[] elements)
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

    public Matrix3LR(IList<LongRational> elements)
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

    public Matrix3LR(Vector3LR column1, Vector3LR column2, Vector3LR column3)
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

    public Matrix3LR(Matrix3LR m)
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

    public static Matrix3LR Add(Matrix3LR a, Matrix3LR b)
    {
      return new Matrix3LR(a.M00 + b.M00, a.M01 + b.M01, a.M02 + b.M02, a.M10 + b.M10, a.M11 + b.M11, a.M12 + b.M12, a.M20 + b.M20, a.M21 + b.M21, a.M22 + b.M22);
    }

    public static Matrix3LR Subtract(Matrix3LR a, Matrix3LR b)
    {
      return new Matrix3LR(a.M00 - b.M00, a.M01 - b.M01, a.M02 - b.M02, a.M10 - b.M10, a.M11 - b.M11, a.M12 - b.M12, a.M20 - b.M20, a.M21 - b.M21, a.M22 - b.M22);
    }

    public static Matrix3LR Multiply(Matrix3LR a, Matrix3LR b)
    {
      return new Matrix3LR(a.M00 * b.M00 + a.M01 * b.M10 + a.M02 * b.M20, a.M00 * b.M01 + a.M01 * b.M11 + a.M02 * b.M21, a.M00 * b.M02 + a.M01 * b.M12 + a.M02 * b.M22, a.M10 * b.M00 + a.M11 * b.M10 + a.M12 * b.M20, a.M10 * b.M01 + a.M11 * b.M11 + a.M12 * b.M21, a.M10 * b.M02 + a.M11 * b.M12 + a.M12 * b.M22, a.M20 * b.M00 + a.M21 * b.M10 + a.M22 * b.M20, a.M20 * b.M01 + a.M21 * b.M11 + a.M22 * b.M21, a.M20 * b.M02 + a.M21 * b.M12 + a.M22 * b.M22);
    }

    public static Matrix3LR Transpose(Matrix3LR m)
    {
      Matrix3LR matrix3Lr = new Matrix3LR(m);
      matrix3Lr.Transpose();
      return matrix3Lr;
    }

    public override int GetHashCode()
    {
      return this.M00.GetHashCode() ^ this.M01.GetHashCode() ^ this.M02.GetHashCode() ^ this.M10.GetHashCode() ^ this.M11.GetHashCode() ^ this.M12.GetHashCode() ^ this.M20.GetHashCode() ^ this.M21.GetHashCode() ^ this.M22.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Matrix3LR)
        return this.Equals((Matrix3LR) other);
      return false;
    }

    public override string ToString()
    {
      return string.Format("|{0}, {1}, {2}|\n|{3}, {4}, {5}|\n|{6}, {7}, {8}|\n", (object) this.M00, (object) this.M01, (object) this.M02, (object) this.M10, (object) this.M11, (object) this.M12, (object) this.M20, (object) this.M21, (object) this.M22);
    }

    public Vector2LR Transform(Vector2LR vector)
    {
      return new Vector2LR(this.M00 * vector.X + this.M01 * vector.Y, this.M10 * vector.X + this.M11 * vector.Y);
    }

    public Point2LR Transform(Point2LR point)
    {
      return new Point2LR(this.M00 * point.X + this.M01 * point.Y + this.M02, this.M10 * point.X + this.M11 * point.Y + this.M12);
    }

    public Vector3LR Transform(Vector3LR vector)
    {
      return new Vector3LR(this.M00 * vector.X + this.M01 * vector.Y + this.M02 * vector.Z, this.M10 * vector.X + this.M11 * vector.Y + this.M12 * vector.Z, this.M20 * vector.X + this.M21 * vector.Y + this.M22 * vector.Z);
    }

    public Point3LR Transform(Point3LR point)
    {
      return new Point3LR(this.M00 * point.X + this.M01 * point.Y + this.M02 * point.Z, this.M10 * point.X + this.M11 * point.Y + this.M12 * point.Z, this.M20 * point.X + this.M21 * point.Y + this.M22 * point.Z);
    }

    public Point2LR TransformTo2LR(Point3LR point)
    {
      return new Point2LR(this.M00 * point.X + this.M01 * point.Y + this.M02 * point.Z, this.M10 * point.X + this.M11 * point.Y + this.M12 * point.Z);
    }

    public LongRational GetDeterminant()
    {
      return this.M00 * this.M11 * this.M22 + this.M01 * this.M12 * this.M20 + this.M02 * this.M10 * this.M21 - this.M02 * this.M11 * this.M20 - this.M00 * this.M12 * this.M21 - this.M01 * this.M10 * this.M22;
    }

    public Matrix3LR GetAdjoint()
    {
      return new Matrix3LR(this.M11 * this.M22 - this.M12 * this.M21, -(this.M01 * this.M22 - this.M02 * this.M21), this.M01 * this.M12 - this.M02 * this.M11, -(this.M10 * this.M22 - this.M12 * this.M20), this.M00 * this.M22 - this.M02 * this.M20, -(this.M00 * this.M12 - this.M02 * this.M10), this.M10 * this.M21 - this.M11 * this.M20, -(this.M00 * this.M21 - this.M01 * this.M20), this.M00 * this.M11 - this.M01 * this.M10);
    }

    public Matrix3LR GetInverse()
    {
      LongRational determinant = this.GetDeterminant();
      return new Matrix3LR((this.M11 * this.M22 - this.M12 * this.M21) / determinant, -(this.M01 * this.M22 - this.M02 * this.M21) / determinant, (this.M01 * this.M12 - this.M02 * this.M11) / determinant, -(this.M10 * this.M22 - this.M12 * this.M20) / determinant, (this.M00 * this.M22 - this.M02 * this.M20) / determinant, -(this.M00 * this.M12 - this.M02 * this.M10) / determinant, (this.M10 * this.M21 - this.M11 * this.M20) / determinant, -(this.M00 * this.M21 - this.M01 * this.M20) / determinant, (this.M00 * this.M11 - this.M01 * this.M10) / determinant);
    }

    public Matrix3LR GetInverse(out bool couldInvert)
    {
      LongRational determinant = this.GetDeterminant();
      couldInvert = !determinant.IsZero;
      return new Matrix3LR((this.M11 * this.M22 - this.M12 * this.M21) / determinant, -(this.M01 * this.M22 - this.M02 * this.M21) / determinant, (this.M01 * this.M12 - this.M02 * this.M11) / determinant, -(this.M10 * this.M22 - this.M12 * this.M20) / determinant, (this.M00 * this.M22 - this.M02 * this.M20) / determinant, -(this.M00 * this.M12 - this.M02 * this.M10) / determinant, (this.M10 * this.M21 - this.M11 * this.M20) / determinant, -(this.M00 * this.M21 - this.M01 * this.M20) / determinant, (this.M00 * this.M11 - this.M01 * this.M10) / determinant);
    }

    public Matrix3LR GetTranspose()
    {
      Matrix3LR matrix3Lr = this;
      matrix3Lr.Transpose();
      return matrix3Lr;
    }

    public Matrix2LR GetMinor(int removeRow, int removeColumn)
    {
      int index1 = 0;
      Matrix2LR matrix2Lr = new Matrix2LR();
      for (int index2 = 0; index2 < 3; ++index2)
      {
        int index3 = 0;
        if (index2 != removeRow)
        {
          for (int index4 = 0; index4 < 3; ++index4)
          {
            if (index4 != removeColumn)
            {
              matrix2Lr[index1, index3] = this[index2, index4];
              ++index3;
            }
          }
          ++index1;
        }
      }
      return matrix2Lr;
    }

    public LongRational GetTrace()
    {
      return this.M00 + this.M11 + this.M22;
    }

    public void Transpose()
    {
      MathUtil.Swap<LongRational>(ref this.M01, ref this.M10);
      MathUtil.Swap<LongRational>(ref this.M02, ref this.M20);
      MathUtil.Swap<LongRational>(ref this.M12, ref this.M21);
    }

    public static bool operator ==(Matrix3LR a, Matrix3LR b)
    {
      return object.Equals((object) a, (object) b);
    }

    public static bool operator !=(Matrix3LR a, Matrix3LR b)
    {
      return !object.Equals((object) a, (object) b);
    }

    public static Matrix3LR operator +(Matrix3LR a, Matrix3LR b)
    {
      return Matrix3LR.Add(a, b);
    }

    public static Matrix3LR operator -(Matrix3LR a, Matrix3LR b)
    {
      return Matrix3LR.Subtract(a, b);
    }

    public static Matrix3LR operator *(Matrix3LR a, Matrix3LR b)
    {
      return Matrix3LR.Multiply(a, b);
    }

    public static Vector3LR operator *(Matrix3LR matrix, Vector3LR vector)
    {
      return matrix.Transform(vector);
    }

    public static Point3LR operator *(Matrix3LR matrix, Point3LR point)
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

    public LongRational this[int row, int column]
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

    private static Matrix3LR smethod_0(
      LongRational m00,
      LongRational m01,
      LongRational m02,
      LongRational m10,
      LongRational m11,
      LongRational m12,
      LongRational m20,
      LongRational m21,
      LongRational m22)
    {
      return new Matrix3LR(m00, m01, m02, m10, m11, m12, m20, m21, m22);
    }

    public bool Equals(Matrix3LR other)
    {
      if (this.M00 == other.M00 && this.M01 == other.M01 && (this.M02 == other.M02 && this.M10 == other.M10) && (this.M11 == other.M11 && this.M12 == other.M12 && (this.M20 == other.M20 && this.M21 == other.M21)))
        return this.M22 == other.M22;
      return false;
    }
  }
}
