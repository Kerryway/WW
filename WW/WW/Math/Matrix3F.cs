// Decompiled with JetBrains decompiler
// Type: WW.Math.Matrix3F
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
  public struct Matrix3F : IEquatable<Matrix3F>
  {
    public static readonly Matrix3F Zero = Matrix3F.smethod_0(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
    public static readonly Matrix3F Identity = Matrix3F.smethod_0(1f, 0.0f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 1f);
    public float M00;
    public float M01;
    public float M02;
    public float M10;
    public float M11;
    public float M12;
    public float M20;
    public float M21;
    public float M22;

    public Matrix3F(
      float m00,
      float m01,
      float m02,
      float m10,
      float m11,
      float m12,
      float m20,
      float m21,
      float m22)
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

    public Matrix3F(float[] elements)
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

    public Matrix3F(IList<float> elements)
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

    public Matrix3F(Vector3F column1, Vector3F column2, Vector3F column3)
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

    public Matrix3F(Matrix3F m)
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

    public static Matrix3F Add(Matrix3F a, Matrix3F b)
    {
      return new Matrix3F(a.M00 + b.M00, a.M01 + b.M01, a.M02 + b.M02, a.M10 + b.M10, a.M11 + b.M11, a.M12 + b.M12, a.M20 + b.M20, a.M21 + b.M21, a.M22 + b.M22);
    }

    public static Matrix3F Subtract(Matrix3F a, Matrix3F b)
    {
      return new Matrix3F(a.M00 - b.M00, a.M01 - b.M01, a.M02 - b.M02, a.M10 - b.M10, a.M11 - b.M11, a.M12 - b.M12, a.M20 - b.M20, a.M21 - b.M21, a.M22 - b.M22);
    }

    public static Matrix3F Multiply(Matrix3F a, Matrix3F b)
    {
      return new Matrix3F((float) ((double) a.M00 * (double) b.M00 + (double) a.M01 * (double) b.M10 + (double) a.M02 * (double) b.M20), (float) ((double) a.M00 * (double) b.M01 + (double) a.M01 * (double) b.M11 + (double) a.M02 * (double) b.M21), (float) ((double) a.M00 * (double) b.M02 + (double) a.M01 * (double) b.M12 + (double) a.M02 * (double) b.M22), (float) ((double) a.M10 * (double) b.M00 + (double) a.M11 * (double) b.M10 + (double) a.M12 * (double) b.M20), (float) ((double) a.M10 * (double) b.M01 + (double) a.M11 * (double) b.M11 + (double) a.M12 * (double) b.M21), (float) ((double) a.M10 * (double) b.M02 + (double) a.M11 * (double) b.M12 + (double) a.M12 * (double) b.M22), (float) ((double) a.M20 * (double) b.M00 + (double) a.M21 * (double) b.M10 + (double) a.M22 * (double) b.M20), (float) ((double) a.M20 * (double) b.M01 + (double) a.M21 * (double) b.M11 + (double) a.M22 * (double) b.M21), (float) ((double) a.M20 * (double) b.M02 + (double) a.M21 * (double) b.M12 + (double) a.M22 * (double) b.M22));
    }

    public static Matrix3F Transpose(Matrix3F m)
    {
      Matrix3F matrix3F = new Matrix3F(m);
      matrix3F.Transpose();
      return matrix3F;
    }

    public override int GetHashCode()
    {
      return this.M00.GetHashCode() ^ this.M01.GetHashCode() ^ this.M02.GetHashCode() ^ this.M10.GetHashCode() ^ this.M11.GetHashCode() ^ this.M12.GetHashCode() ^ this.M20.GetHashCode() ^ this.M21.GetHashCode() ^ this.M22.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Matrix3F)
        return this.Equals((Matrix3F) other);
      return false;
    }

    public override string ToString()
    {
      return string.Format("|{0}, {1}, {2}|\n|{3}, {4}, {5}|\n|{6}, {7}, {8}|\n", (object) this.M00, (object) this.M01, (object) this.M02, (object) this.M10, (object) this.M11, (object) this.M12, (object) this.M20, (object) this.M21, (object) this.M22);
    }

    public Vector2F Transform(Vector2F vector)
    {
      return new Vector2F((float) ((double) this.M00 * (double) vector.X + (double) this.M01 * (double) vector.Y), (float) ((double) this.M10 * (double) vector.X + (double) this.M11 * (double) vector.Y));
    }

    public Point2F Transform(Point2F point)
    {
      return new Point2F((float) ((double) this.M00 * (double) point.X + (double) this.M01 * (double) point.Y) + this.M02, (float) ((double) this.M10 * (double) point.X + (double) this.M11 * (double) point.Y) + this.M12);
    }

    public Vector3F Transform(Vector3F vector)
    {
      return new Vector3F((float) ((double) this.M00 * (double) vector.X + (double) this.M01 * (double) vector.Y + (double) this.M02 * (double) vector.Z), (float) ((double) this.M10 * (double) vector.X + (double) this.M11 * (double) vector.Y + (double) this.M12 * (double) vector.Z), (float) ((double) this.M20 * (double) vector.X + (double) this.M21 * (double) vector.Y + (double) this.M22 * (double) vector.Z));
    }

    public Point3F Transform(Point3F point)
    {
      return new Point3F((float) ((double) this.M00 * (double) point.X + (double) this.M01 * (double) point.Y + (double) this.M02 * (double) point.Z), (float) ((double) this.M10 * (double) point.X + (double) this.M11 * (double) point.Y + (double) this.M12 * (double) point.Z), (float) ((double) this.M20 * (double) point.X + (double) this.M21 * (double) point.Y + (double) this.M22 * (double) point.Z));
    }

    public Point2F TransformTo2D(Point3F point)
    {
      return new Point2F((float) ((double) this.M00 * (double) point.X + (double) this.M01 * (double) point.Y + (double) this.M02 * (double) point.Z), (float) ((double) this.M10 * (double) point.X + (double) this.M11 * (double) point.Y + (double) this.M12 * (double) point.Z));
    }

    public float GetDeterminant()
    {
      return (float) ((double) this.M00 * (double) this.M11 * (double) this.M22 + (double) this.M01 * (double) this.M12 * (double) this.M20 + (double) this.M02 * (double) this.M10 * (double) this.M21 - (double) this.M02 * (double) this.M11 * (double) this.M20 - (double) this.M00 * (double) this.M12 * (double) this.M21 - (double) this.M01 * (double) this.M10 * (double) this.M22);
    }

    public Matrix3F GetAdjoint()
    {
      return new Matrix3F((float) ((double) this.M11 * (double) this.M22 - (double) this.M12 * (double) this.M21), (float) -((double) this.M01 * (double) this.M22 - (double) this.M02 * (double) this.M21), (float) ((double) this.M01 * (double) this.M12 - (double) this.M02 * (double) this.M11), (float) -((double) this.M10 * (double) this.M22 - (double) this.M12 * (double) this.M20), (float) ((double) this.M00 * (double) this.M22 - (double) this.M02 * (double) this.M20), (float) -((double) this.M00 * (double) this.M12 - (double) this.M02 * (double) this.M10), (float) ((double) this.M10 * (double) this.M21 - (double) this.M11 * (double) this.M20), (float) -((double) this.M00 * (double) this.M21 - (double) this.M01 * (double) this.M20), (float) ((double) this.M00 * (double) this.M11 - (double) this.M01 * (double) this.M10));
    }

    public Matrix3F GetInverse()
    {
      float num = 1f / this.GetDeterminant();
      return new Matrix3F((float) ((double) this.M11 * (double) this.M22 - (double) this.M12 * (double) this.M21) * num, (float) -((double) this.M01 * (double) this.M22 - (double) this.M02 * (double) this.M21) * num, (float) ((double) this.M01 * (double) this.M12 - (double) this.M02 * (double) this.M11) * num, (float) -((double) this.M10 * (double) this.M22 - (double) this.M12 * (double) this.M20) * num, (float) ((double) this.M00 * (double) this.M22 - (double) this.M02 * (double) this.M20) * num, (float) -((double) this.M00 * (double) this.M12 - (double) this.M02 * (double) this.M10) * num, (float) ((double) this.M10 * (double) this.M21 - (double) this.M11 * (double) this.M20) * num, (float) -((double) this.M00 * (double) this.M21 - (double) this.M01 * (double) this.M20) * num, (float) ((double) this.M00 * (double) this.M11 - (double) this.M01 * (double) this.M10) * num);
    }

    public Matrix3F GetInverse(out bool couldInvert)
    {
      float determinant = this.GetDeterminant();
      float num = 1f / determinant;
      couldInvert = (double) determinant != 0.0;
      return new Matrix3F((float) ((double) this.M11 * (double) this.M22 - (double) this.M12 * (double) this.M21) * num, (float) -((double) this.M01 * (double) this.M22 - (double) this.M02 * (double) this.M21) * num, (float) ((double) this.M01 * (double) this.M12 - (double) this.M02 * (double) this.M11) * num, (float) -((double) this.M10 * (double) this.M22 - (double) this.M12 * (double) this.M20) * num, (float) ((double) this.M00 * (double) this.M22 - (double) this.M02 * (double) this.M20) * num, (float) -((double) this.M00 * (double) this.M12 - (double) this.M02 * (double) this.M10) * num, (float) ((double) this.M10 * (double) this.M21 - (double) this.M11 * (double) this.M20) * num, (float) -((double) this.M00 * (double) this.M21 - (double) this.M01 * (double) this.M20) * num, (float) ((double) this.M00 * (double) this.M11 - (double) this.M01 * (double) this.M10) * num);
    }

    public Matrix3F GetTranspose()
    {
      Matrix3F matrix3F = this;
      matrix3F.Transpose();
      return matrix3F;
    }

    public Matrix2F GetMinor(int removeRow, int removeColumn)
    {
      int index1 = 0;
      Matrix2F matrix2F = new Matrix2F();
      for (int index2 = 0; index2 < 3; ++index2)
      {
        int index3 = 0;
        if (index2 != removeRow)
        {
          for (int index4 = 0; index4 < 3; ++index4)
          {
            if (index4 != removeColumn)
            {
              matrix2F[index1, index3] = this[index2, index4];
              ++index3;
            }
          }
          ++index1;
        }
      }
      return matrix2F;
    }

    public float GetTrace()
    {
      return this.M00 + this.M11 + this.M22;
    }

    public void Transpose()
    {
      MathUtil.Swap(ref this.M01, ref this.M10);
      MathUtil.Swap(ref this.M02, ref this.M20);
      MathUtil.Swap(ref this.M12, ref this.M21);
    }

    public static bool AreApproxEqual(Matrix3F a, Matrix3F b)
    {
      return Matrix3F.AreApproxEqual(a, b, 4.768372E-07f);
    }

    public static bool AreApproxEqual(Matrix3F a, Matrix3F b, float tolerance)
    {
      if ((double) System.Math.Abs(b.M00 - a.M00) <= (double) tolerance && (double) System.Math.Abs(b.M01 - a.M01) <= (double) tolerance && ((double) System.Math.Abs(b.M02 - a.M02) <= (double) tolerance && (double) System.Math.Abs(b.M10 - a.M10) <= (double) tolerance) && ((double) System.Math.Abs(b.M11 - a.M11) <= (double) tolerance && (double) System.Math.Abs(b.M12 - a.M12) <= (double) tolerance && ((double) System.Math.Abs(b.M20 - a.M20) <= (double) tolerance && (double) System.Math.Abs(b.M21 - a.M21) <= (double) tolerance)))
        return (double) System.Math.Abs(b.M22 - a.M22) <= (double) tolerance;
      return false;
    }

    public static bool operator ==(Matrix3F a, Matrix3F b)
    {
      return object.Equals((object) a, (object) b);
    }

    public static bool operator !=(Matrix3F a, Matrix3F b)
    {
      return !object.Equals((object) a, (object) b);
    }

    public static Matrix3F operator +(Matrix3F a, Matrix3F b)
    {
      return Matrix3F.Add(a, b);
    }

    public static Matrix3F operator -(Matrix3F a, Matrix3F b)
    {
      return Matrix3F.Subtract(a, b);
    }

    public static Matrix3F operator *(Matrix3F a, Matrix3F b)
    {
      return Matrix3F.Multiply(a, b);
    }

    public static Vector3F operator *(Matrix3F matrix, Vector3F vector)
    {
      return matrix.Transform(vector);
    }

    public static Point3F operator *(Matrix3F matrix, Point3F point)
    {
      return matrix.Transform(point);
    }

    public unsafe float this[int index]
    {
      [SecurityCritical] get
      {
        if (index < 0 || index >= 9)
          throw new IndexOutOfRangeException("Invalid matrix index!");
        fixed (float* numPtr = &this.M00)
          return numPtr[index];
      }
      [SecurityCritical] set
      {
        if (index < 0 || index >= 9)
          throw new IndexOutOfRangeException("Invalid matrix index!");
        fixed (float* numPtr = &this.M00)
          numPtr[index] = value;
      }
    }

    public float this[int row, int column]
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

    private static Matrix3F smethod_0(
      float m00,
      float m01,
      float m02,
      float m10,
      float m11,
      float m12,
      float m20,
      float m21,
      float m22)
    {
      return new Matrix3F(m00, m01, m02, m10, m11, m12, m20, m21, m22);
    }

    public bool Equals(Matrix3F other)
    {
      if ((double) this.M00 == (double) other.M00 && (double) this.M01 == (double) other.M01 && ((double) this.M02 == (double) other.M02 && (double) this.M10 == (double) other.M10) && ((double) this.M11 == (double) other.M11 && (double) this.M12 == (double) other.M12 && ((double) this.M20 == (double) other.M20 && (double) this.M21 == (double) other.M21)))
        return (double) this.M22 == (double) other.M22;
      return false;
    }
  }
}
