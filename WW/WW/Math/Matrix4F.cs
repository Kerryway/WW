// Decompiled with JetBrains decompiler
// Type: WW.Math.Matrix4F
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Security;

namespace WW.Math
{
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public struct Matrix4F : IEquatable<Matrix4F>
  {
    public static readonly Matrix4F Zero = Matrix4F.smethod_0(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
    public static readonly Matrix4F Identity = Matrix4F.smethod_0(1f, 0.0f, 0.0f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 0.0f, 1f);
    public float M00;
    public float M10;
    public float M20;
    public float M30;
    public float M01;
    public float M11;
    public float M21;
    public float M31;
    public float M02;
    public float M12;
    public float M22;
    public float M32;
    public float M03;
    public float M13;
    public float M23;
    public float M33;

    public Matrix4F(
      float m00,
      float m01,
      float m02,
      float m03,
      float m10,
      float m11,
      float m12,
      float m13,
      float m20,
      float m21,
      float m22,
      float m23,
      float m30,
      float m31,
      float m32,
      float m33)
    {
      this.M00 = m00;
      this.M01 = m01;
      this.M02 = m02;
      this.M03 = m03;
      this.M10 = m10;
      this.M11 = m11;
      this.M12 = m12;
      this.M13 = m13;
      this.M20 = m20;
      this.M21 = m21;
      this.M22 = m22;
      this.M23 = m23;
      this.M30 = m30;
      this.M31 = m31;
      this.M32 = m32;
      this.M33 = m33;
    }

    public Matrix4F(float[] elements)
    {
      this.M00 = elements[0];
      this.M01 = elements[1];
      this.M02 = elements[2];
      this.M03 = elements[3];
      this.M10 = elements[4];
      this.M11 = elements[5];
      this.M12 = elements[6];
      this.M13 = elements[7];
      this.M20 = elements[8];
      this.M21 = elements[9];
      this.M22 = elements[10];
      this.M23 = elements[11];
      this.M30 = elements[12];
      this.M31 = elements[13];
      this.M32 = elements[14];
      this.M33 = elements[15];
    }

    public Matrix4F(IList<float> elements)
    {
      this.M00 = elements[0];
      this.M01 = elements[1];
      this.M02 = elements[2];
      this.M03 = elements[3];
      this.M10 = elements[4];
      this.M11 = elements[5];
      this.M12 = elements[6];
      this.M13 = elements[7];
      this.M20 = elements[8];
      this.M21 = elements[9];
      this.M22 = elements[10];
      this.M23 = elements[11];
      this.M30 = elements[12];
      this.M31 = elements[13];
      this.M32 = elements[14];
      this.M33 = elements[15];
    }

    public Matrix4F(Vector4F column1, Vector4F column2, Vector4F column3, Vector4F column4)
    {
      this.M00 = column1.X;
      this.M01 = column2.X;
      this.M02 = column3.X;
      this.M03 = column4.X;
      this.M10 = column1.Y;
      this.M11 = column2.Y;
      this.M12 = column3.Y;
      this.M13 = column4.Y;
      this.M20 = column1.Z;
      this.M21 = column2.Z;
      this.M22 = column3.Z;
      this.M23 = column4.Z;
      this.M30 = column1.W;
      this.M31 = column2.W;
      this.M32 = column3.W;
      this.M33 = column4.W;
    }

    public Matrix4F(Matrix4F m)
    {
      this.M00 = m.M00;
      this.M01 = m.M01;
      this.M02 = m.M02;
      this.M03 = m.M03;
      this.M10 = m.M10;
      this.M11 = m.M11;
      this.M12 = m.M12;
      this.M13 = m.M13;
      this.M20 = m.M20;
      this.M21 = m.M21;
      this.M22 = m.M22;
      this.M23 = m.M23;
      this.M30 = m.M30;
      this.M31 = m.M31;
      this.M32 = m.M32;
      this.M33 = m.M33;
    }

    public Matrix4F(Matrix3F m)
    {
      this.M00 = m.M00;
      this.M01 = m.M01;
      this.M02 = m.M02;
      this.M03 = 0.0f;
      this.M10 = m.M10;
      this.M11 = m.M11;
      this.M12 = m.M12;
      this.M13 = 0.0f;
      this.M20 = m.M20;
      this.M21 = m.M21;
      this.M22 = m.M22;
      this.M23 = 0.0f;
      this.M30 = 0.0f;
      this.M31 = 0.0f;
      this.M32 = 0.0f;
      this.M33 = 1f;
    }

    public static Matrix4F Add(Matrix4F a, Matrix4F b)
    {
      return new Matrix4F(a.M00 + b.M00, a.M01 + b.M01, a.M02 + b.M02, a.M03 + b.M03, a.M10 + b.M10, a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13, a.M20 + b.M20, a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23, a.M30 + b.M30, a.M31 + b.M31, a.M32 + b.M32, a.M33 + b.M33);
    }

    public static Matrix4F Subtract(Matrix4F a, Matrix4F b)
    {
      return new Matrix4F(a.M00 - b.M00, a.M01 - b.M01, a.M02 - b.M02, a.M03 - b.M03, a.M10 - b.M10, a.M11 - b.M11, a.M12 - b.M12, a.M13 - b.M13, a.M20 - b.M20, a.M21 - b.M21, a.M22 - b.M22, a.M23 - b.M23, a.M30 - b.M30, a.M31 - b.M31, a.M32 - b.M32, a.M33 - b.M33);
    }

    public static Matrix4F Multiply(Matrix4F a, Matrix4F b)
    {
      return new Matrix4F((float) ((double) a.M00 * (double) b.M00 + (double) a.M01 * (double) b.M10 + (double) a.M02 * (double) b.M20 + (double) a.M03 * (double) b.M30), (float) ((double) a.M00 * (double) b.M01 + (double) a.M01 * (double) b.M11 + (double) a.M02 * (double) b.M21 + (double) a.M03 * (double) b.M31), (float) ((double) a.M00 * (double) b.M02 + (double) a.M01 * (double) b.M12 + (double) a.M02 * (double) b.M22 + (double) a.M03 * (double) b.M32), (float) ((double) a.M00 * (double) b.M03 + (double) a.M01 * (double) b.M13 + (double) a.M02 * (double) b.M23 + (double) a.M03 * (double) b.M33), (float) ((double) a.M10 * (double) b.M00 + (double) a.M11 * (double) b.M10 + (double) a.M12 * (double) b.M20 + (double) a.M13 * (double) b.M30), (float) ((double) a.M10 * (double) b.M01 + (double) a.M11 * (double) b.M11 + (double) a.M12 * (double) b.M21 + (double) a.M13 * (double) b.M31), (float) ((double) a.M10 * (double) b.M02 + (double) a.M11 * (double) b.M12 + (double) a.M12 * (double) b.M22 + (double) a.M13 * (double) b.M32), (float) ((double) a.M10 * (double) b.M03 + (double) a.M11 * (double) b.M13 + (double) a.M12 * (double) b.M23 + (double) a.M13 * (double) b.M33), (float) ((double) a.M20 * (double) b.M00 + (double) a.M21 * (double) b.M10 + (double) a.M22 * (double) b.M20 + (double) a.M23 * (double) b.M30), (float) ((double) a.M20 * (double) b.M01 + (double) a.M21 * (double) b.M11 + (double) a.M22 * (double) b.M21 + (double) a.M23 * (double) b.M31), (float) ((double) a.M20 * (double) b.M02 + (double) a.M21 * (double) b.M12 + (double) a.M22 * (double) b.M22 + (double) a.M23 * (double) b.M32), (float) ((double) a.M20 * (double) b.M03 + (double) a.M21 * (double) b.M13 + (double) a.M22 * (double) b.M23 + (double) a.M23 * (double) b.M33), (float) ((double) a.M30 * (double) b.M00 + (double) a.M31 * (double) b.M10 + (double) a.M32 * (double) b.M20 + (double) a.M33 * (double) b.M30), (float) ((double) a.M30 * (double) b.M01 + (double) a.M31 * (double) b.M11 + (double) a.M32 * (double) b.M21 + (double) a.M33 * (double) b.M31), (float) ((double) a.M30 * (double) b.M02 + (double) a.M31 * (double) b.M12 + (double) a.M32 * (double) b.M22 + (double) a.M33 * (double) b.M32), (float) ((double) a.M30 * (double) b.M03 + (double) a.M31 * (double) b.M13 + (double) a.M32 * (double) b.M23 + (double) a.M33 * (double) b.M33));
    }

    public static Matrix4F Transpose(Matrix4F m)
    {
      Matrix4F matrix4F = new Matrix4F(m);
      matrix4F.Transpose();
      return matrix4F;
    }

    public override int GetHashCode()
    {
      return this.M00.GetHashCode() ^ this.M01.GetHashCode() ^ this.M02.GetHashCode() ^ this.M03.GetHashCode() ^ this.M10.GetHashCode() ^ this.M11.GetHashCode() ^ this.M12.GetHashCode() ^ this.M13.GetHashCode() ^ this.M20.GetHashCode() ^ this.M21.GetHashCode() ^ this.M22.GetHashCode() ^ this.M23.GetHashCode() ^ this.M30.GetHashCode() ^ this.M31.GetHashCode() ^ this.M32.GetHashCode() ^ this.M33.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Matrix4F)
        return this.Equals((Matrix4F) other);
      return false;
    }

    public override string ToString()
    {
      return string.Format("|{0}, {1}, {2}, {3}|\n|{4}, {5}, {6}, {7}|\n|{8}, {9}, {10}, {11}|\n|{12}, {13}, {14}, {15}|\n", (object) this.M00, (object) this.M01, (object) this.M02, (object) this.M03, (object) this.M10, (object) this.M11, (object) this.M12, (object) this.M13, (object) this.M20, (object) this.M21, (object) this.M22, (object) this.M23, (object) this.M30, (object) this.M31, (object) this.M32, (object) this.M33);
    }

    public Vector4F Transform(Vector4F vector)
    {
      return new Vector4F((float) ((double) this.M00 * (double) vector.X + (double) this.M01 * (double) vector.Y + (double) this.M02 * (double) vector.Z + (double) this.M03 * (double) vector.W), (float) ((double) this.M10 * (double) vector.X + (double) this.M11 * (double) vector.Y + (double) this.M12 * (double) vector.Z + (double) this.M13 * (double) vector.W), (float) ((double) this.M20 * (double) vector.X + (double) this.M21 * (double) vector.Y + (double) this.M22 * (double) vector.Z + (double) this.M23 * (double) vector.W), (float) ((double) this.M30 * (double) vector.X + (double) this.M31 * (double) vector.Y + (double) this.M32 * (double) vector.Z + (double) this.M33 * (double) vector.W));
    }

    public Vector3F Transform(Vector3F vector)
    {
      return new Vector3F((float) ((double) this.M00 * (double) vector.X + (double) this.M01 * (double) vector.Y + (double) this.M02 * (double) vector.Z), (float) ((double) this.M10 * (double) vector.X + (double) this.M11 * (double) vector.Y + (double) this.M12 * (double) vector.Z), (float) ((double) this.M20 * (double) vector.X + (double) this.M21 * (double) vector.Y + (double) this.M22 * (double) vector.Z));
    }

    public Vector2F TransformTo2D(Vector3F vector)
    {
      return new Vector2F((float) ((double) this.M00 * (double) vector.X + (double) this.M01 * (double) vector.Y + (double) this.M02 * (double) vector.Z), (float) ((double) this.M10 * (double) vector.X + (double) this.M11 * (double) vector.Y + (double) this.M12 * (double) vector.Z));
    }

    public Vector2F Transform(Vector2F vector)
    {
      return new Vector2F((float) ((double) this.M00 * (double) vector.X + (double) this.M01 * (double) vector.Y), (float) ((double) this.M10 * (double) vector.X + (double) this.M11 * (double) vector.Y));
    }

    public Point3F Transform(Point3F point)
    {
      float num = (float) (1.0 / ((double) this.M30 * (double) point.X + (double) this.M31 * (double) point.Y + (double) this.M32 * (double) point.Z + (double) this.M33));
      return new Point3F(((float) ((double) this.M00 * (double) point.X + (double) this.M01 * (double) point.Y + (double) this.M02 * (double) point.Z) + this.M03) * num, ((float) ((double) this.M10 * (double) point.X + (double) this.M11 * (double) point.Y + (double) this.M12 * (double) point.Z) + this.M13) * num, ((float) ((double) this.M20 * (double) point.X + (double) this.M21 * (double) point.Y + (double) this.M22 * (double) point.Z) + this.M23) * num);
    }

    public Point3F TransformTo3D(Point2F point)
    {
      float num = (float) (1.0 / ((double) this.M30 * (double) point.X + (double) this.M31 * (double) point.Y + (double) this.M33));
      return new Point3F(((float) ((double) this.M00 * (double) point.X + (double) this.M01 * (double) point.Y) + this.M03) * num, ((float) ((double) this.M10 * (double) point.X + (double) this.M11 * (double) point.Y) + this.M13) * num, ((float) ((double) this.M20 * (double) point.X + (double) this.M21 * (double) point.Y) + this.M23) * num);
    }

    public Point3F TransformToPoint3F(Vector4F vector)
    {
      float num = (float) (1.0 / ((double) this.M30 * (double) vector.X + (double) this.M31 * (double) vector.Y + (double) this.M32 * (double) vector.Z + (double) this.M33 * (double) vector.W));
      return new Point3F((float) ((double) this.M00 * (double) vector.X + (double) this.M01 * (double) vector.Y + (double) this.M02 * (double) vector.Z + (double) this.M03 * (double) vector.W) * num, (float) ((double) this.M10 * (double) vector.X + (double) this.M11 * (double) vector.Y + (double) this.M12 * (double) vector.Z + (double) this.M13 * (double) vector.W) * num, (float) ((double) this.M20 * (double) vector.X + (double) this.M21 * (double) vector.Y + (double) this.M22 * (double) vector.Z + (double) this.M23 * (double) vector.W) * num);
    }

    public Point2F TransformToPoint2F(Vector4F vector)
    {
      float num = (float) (1.0 / ((double) this.M30 * (double) vector.X + (double) this.M31 * (double) vector.Y + (double) this.M32 * (double) vector.Z + (double) this.M33 * (double) vector.W));
      return new Point2F((float) ((double) this.M00 * (double) vector.X + (double) this.M01 * (double) vector.Y + (double) this.M02 * (double) vector.Z + (double) this.M03 * (double) vector.W) * num, (float) ((double) this.M10 * (double) vector.X + (double) this.M11 * (double) vector.Y + (double) this.M12 * (double) vector.Z + (double) this.M13 * (double) vector.W) * num);
    }

    public Point2F TransformTo2D(Point3F point)
    {
      float num = (float) (1.0 / ((double) this.M30 * (double) point.X + (double) this.M31 * (double) point.Y + (double) this.M32 * (double) point.Z + (double) this.M33));
      return new Point2F(((float) ((double) this.M00 * (double) point.X + (double) this.M01 * (double) point.Y + (double) this.M02 * (double) point.Z) + this.M03) * num, ((float) ((double) this.M10 * (double) point.X + (double) this.M11 * (double) point.Y + (double) this.M12 * (double) point.Z) + this.M13) * num);
    }

    public Point2F TransformTo2D(Point2F point)
    {
      float num = (float) (1.0 / ((double) this.M30 * (double) point.X + (double) this.M31 * (double) point.Y + (double) this.M33));
      return new Point2F(((float) ((double) this.M00 * (double) point.X + (double) this.M01 * (double) point.Y) + this.M03) * num, ((float) ((double) this.M10 * (double) point.X + (double) this.M11 * (double) point.Y) + this.M13) * num);
    }

    public PointF TransformTo2D(PointF point)
    {
      float num = (float) (1.0 / ((double) this.M30 * (double) point.X + (double) this.M31 * (double) point.Y + (double) this.M33));
      return new PointF(((float) ((double) this.M00 * (double) point.X + (double) this.M01 * (double) point.Y) + this.M03) * num, ((float) ((double) this.M10 * (double) point.X + (double) this.M11 * (double) point.Y) + this.M13) * num);
    }

    public Vector4F TransformTo4D(Point2F point)
    {
      return new Vector4F((float) ((double) this.M00 * (double) point.X + (double) this.M01 * (double) point.Y) + this.M03, (float) ((double) this.M10 * (double) point.X + (double) this.M11 * (double) point.Y) + this.M13, (float) ((double) this.M20 * (double) point.X + (double) this.M21 * (double) point.Y) + this.M23, (float) ((double) this.M30 * (double) point.X + (double) this.M31 * (double) point.Y) + this.M33);
    }

    public Vector4F TransformTo4D(Point3F point)
    {
      return new Vector4F((float) ((double) this.M00 * (double) point.X + (double) this.M01 * (double) point.Y + (double) this.M02 * (double) point.Z) + this.M03, (float) ((double) this.M10 * (double) point.X + (double) this.M11 * (double) point.Y + (double) this.M12 * (double) point.Z) + this.M13, (float) ((double) this.M20 * (double) point.X + (double) this.M21 * (double) point.Y + (double) this.M22 * (double) point.Z) + this.M23, (float) ((double) this.M30 * (double) point.X + (double) this.M31 * (double) point.Y + (double) this.M32 * (double) point.Z) + this.M33);
    }

    public Vector4F TransformTo4D(Vector3F vector)
    {
      return new Vector4F((float) ((double) this.M00 * (double) vector.X + (double) this.M01 * (double) vector.Y + (double) this.M02 * (double) vector.Z), (float) ((double) this.M10 * (double) vector.X + (double) this.M11 * (double) vector.Y + (double) this.M12 * (double) vector.Z), (float) ((double) this.M20 * (double) vector.X + (double) this.M21 * (double) vector.Y + (double) this.M22 * (double) vector.Z), (float) ((double) this.M30 * (double) vector.X + (double) this.M31 * (double) vector.Y + (double) this.M32 * (double) vector.Z));
    }

    public float GetDeterminant()
    {
      return (float) ((double) this.M00 * ((double) this.M11 * ((double) this.M22 * (double) this.M33 - (double) this.M23 * (double) this.M32) - (double) this.M12 * ((double) this.M21 * (double) this.M33 - (double) this.M23 * (double) this.M31) + (double) this.M13 * ((double) this.M21 * (double) this.M32 - (double) this.M22 * (double) this.M31)) - (double) this.M01 * ((double) this.M10 * ((double) this.M22 * (double) this.M33 - (double) this.M23 * (double) this.M32) - (double) this.M12 * ((double) this.M20 * (double) this.M33 - (double) this.M23 * (double) this.M30) + (double) this.M13 * ((double) this.M20 * (double) this.M32 - (double) this.M22 * (double) this.M30)) + (double) this.M02 * ((double) this.M10 * ((double) this.M21 * (double) this.M33 - (double) this.M23 * (double) this.M31) - (double) this.M11 * ((double) this.M20 * (double) this.M33 - (double) this.M23 * (double) this.M30) + (double) this.M13 * ((double) this.M20 * (double) this.M31 - (double) this.M21 * (double) this.M30)) - (double) this.M03 * ((double) this.M10 * ((double) this.M21 * (double) this.M32 - (double) this.M22 * (double) this.M31) - (double) this.M11 * ((double) this.M20 * (double) this.M32 - (double) this.M22 * (double) this.M30) + (double) this.M12 * ((double) this.M20 * (double) this.M31 - (double) this.M21 * (double) this.M30)));
    }

    public Matrix4F GetAdjoint()
    {
      return new Matrix4F((float) ((double) this.M11 * ((double) this.M22 * (double) this.M33 - (double) this.M23 * (double) this.M32) - (double) this.M12 * ((double) this.M21 * (double) this.M33 - (double) this.M23 * (double) this.M31) + (double) this.M13 * ((double) this.M21 * (double) this.M32 - (double) this.M22 * (double) this.M31)), (float) -((double) this.M01 * ((double) this.M22 * (double) this.M33 - (double) this.M23 * (double) this.M32) - (double) this.M02 * ((double) this.M21 * (double) this.M33 - (double) this.M23 * (double) this.M31) + (double) this.M03 * ((double) this.M21 * (double) this.M32 - (double) this.M22 * (double) this.M31)), (float) ((double) this.M01 * ((double) this.M12 * (double) this.M33 - (double) this.M13 * (double) this.M32) - (double) this.M02 * ((double) this.M11 * (double) this.M33 - (double) this.M13 * (double) this.M31) + (double) this.M03 * ((double) this.M11 * (double) this.M32 - (double) this.M12 * (double) this.M31)), (float) -((double) this.M01 * ((double) this.M12 * (double) this.M23 - (double) this.M13 * (double) this.M22) - (double) this.M02 * ((double) this.M11 * (double) this.M23 - (double) this.M13 * (double) this.M21) + (double) this.M03 * ((double) this.M11 * (double) this.M22 - (double) this.M12 * (double) this.M21)), (float) -((double) this.M10 * ((double) this.M22 * (double) this.M33 - (double) this.M23 * (double) this.M32) - (double) this.M12 * ((double) this.M20 * (double) this.M33 - (double) this.M23 * (double) this.M30) + (double) this.M13 * ((double) this.M20 * (double) this.M32 - (double) this.M22 * (double) this.M30)), (float) ((double) this.M00 * ((double) this.M22 * (double) this.M33 - (double) this.M23 * (double) this.M32) - (double) this.M02 * ((double) this.M20 * (double) this.M33 - (double) this.M23 * (double) this.M30) + (double) this.M03 * ((double) this.M20 * (double) this.M32 - (double) this.M22 * (double) this.M30)), (float) -((double) this.M00 * ((double) this.M12 * (double) this.M33 - (double) this.M13 * (double) this.M32) - (double) this.M02 * ((double) this.M10 * (double) this.M33 - (double) this.M13 * (double) this.M30) + (double) this.M03 * ((double) this.M10 * (double) this.M32 - (double) this.M12 * (double) this.M30)), (float) ((double) this.M00 * ((double) this.M12 * (double) this.M23 - (double) this.M13 * (double) this.M22) - (double) this.M02 * ((double) this.M10 * (double) this.M23 - (double) this.M13 * (double) this.M20) + (double) this.M03 * ((double) this.M10 * (double) this.M22 - (double) this.M12 * (double) this.M20)), (float) ((double) this.M10 * ((double) this.M21 * (double) this.M33 - (double) this.M23 * (double) this.M31) - (double) this.M11 * ((double) this.M20 * (double) this.M33 - (double) this.M23 * (double) this.M30) + (double) this.M13 * ((double) this.M20 * (double) this.M31 - (double) this.M21 * (double) this.M30)), (float) -((double) this.M00 * ((double) this.M21 * (double) this.M33 - (double) this.M23 * (double) this.M31) - (double) this.M01 * ((double) this.M20 * (double) this.M33 - (double) this.M23 * (double) this.M30) + (double) this.M03 * ((double) this.M20 * (double) this.M31 - (double) this.M21 * (double) this.M30)), (float) ((double) this.M00 * ((double) this.M11 * (double) this.M33 - (double) this.M13 * (double) this.M31) - (double) this.M01 * ((double) this.M10 * (double) this.M33 - (double) this.M13 * (double) this.M30) + (double) this.M03 * ((double) this.M10 * (double) this.M31 - (double) this.M11 * (double) this.M30)), (float) -((double) this.M00 * ((double) this.M11 * (double) this.M23 - (double) this.M13 * (double) this.M21) - (double) this.M01 * ((double) this.M10 * (double) this.M23 - (double) this.M13 * (double) this.M20) + (double) this.M03 * ((double) this.M10 * (double) this.M21 - (double) this.M11 * (double) this.M20)), (float) -((double) this.M10 * ((double) this.M21 * (double) this.M32 - (double) this.M22 * (double) this.M31) - (double) this.M11 * ((double) this.M20 * (double) this.M32 - (double) this.M22 * (double) this.M30) + (double) this.M12 * ((double) this.M20 * (double) this.M31 - (double) this.M21 * (double) this.M30)), (float) ((double) this.M00 * ((double) this.M21 * (double) this.M32 - (double) this.M22 * (double) this.M31) - (double) this.M01 * ((double) this.M20 * (double) this.M32 - (double) this.M22 * (double) this.M30) + (double) this.M02 * ((double) this.M20 * (double) this.M31 - (double) this.M21 * (double) this.M30)), (float) -((double) this.M00 * ((double) this.M11 * (double) this.M32 - (double) this.M12 * (double) this.M31) - (double) this.M01 * ((double) this.M10 * (double) this.M32 - (double) this.M12 * (double) this.M30) + (double) this.M02 * ((double) this.M10 * (double) this.M31 - (double) this.M11 * (double) this.M30)), (float) ((double) this.M00 * ((double) this.M11 * (double) this.M22 - (double) this.M12 * (double) this.M21) - (double) this.M01 * ((double) this.M10 * (double) this.M22 - (double) this.M12 * (double) this.M20) + (double) this.M02 * ((double) this.M10 * (double) this.M21 - (double) this.M11 * (double) this.M20)));
    }

    public Matrix4F GetInverse()
    {
      float num = 1f / this.GetDeterminant();
      return new Matrix4F((float) ((double) this.M11 * ((double) this.M22 * (double) this.M33 - (double) this.M23 * (double) this.M32) - (double) this.M12 * ((double) this.M21 * (double) this.M33 - (double) this.M23 * (double) this.M31) + (double) this.M13 * ((double) this.M21 * (double) this.M32 - (double) this.M22 * (double) this.M31)) * num, (float) -((double) this.M01 * ((double) this.M22 * (double) this.M33 - (double) this.M23 * (double) this.M32) - (double) this.M02 * ((double) this.M21 * (double) this.M33 - (double) this.M23 * (double) this.M31) + (double) this.M03 * ((double) this.M21 * (double) this.M32 - (double) this.M22 * (double) this.M31)) * num, (float) ((double) this.M01 * ((double) this.M12 * (double) this.M33 - (double) this.M13 * (double) this.M32) - (double) this.M02 * ((double) this.M11 * (double) this.M33 - (double) this.M13 * (double) this.M31) + (double) this.M03 * ((double) this.M11 * (double) this.M32 - (double) this.M12 * (double) this.M31)) * num, (float) -((double) this.M01 * ((double) this.M12 * (double) this.M23 - (double) this.M13 * (double) this.M22) - (double) this.M02 * ((double) this.M11 * (double) this.M23 - (double) this.M13 * (double) this.M21) + (double) this.M03 * ((double) this.M11 * (double) this.M22 - (double) this.M12 * (double) this.M21)) * num, (float) -((double) this.M10 * ((double) this.M22 * (double) this.M33 - (double) this.M23 * (double) this.M32) - (double) this.M12 * ((double) this.M20 * (double) this.M33 - (double) this.M23 * (double) this.M30) + (double) this.M13 * ((double) this.M20 * (double) this.M32 - (double) this.M22 * (double) this.M30)) * num, (float) ((double) this.M00 * ((double) this.M22 * (double) this.M33 - (double) this.M23 * (double) this.M32) - (double) this.M02 * ((double) this.M20 * (double) this.M33 - (double) this.M23 * (double) this.M30) + (double) this.M03 * ((double) this.M20 * (double) this.M32 - (double) this.M22 * (double) this.M30)) * num, (float) -((double) this.M00 * ((double) this.M12 * (double) this.M33 - (double) this.M13 * (double) this.M32) - (double) this.M02 * ((double) this.M10 * (double) this.M33 - (double) this.M13 * (double) this.M30) + (double) this.M03 * ((double) this.M10 * (double) this.M32 - (double) this.M12 * (double) this.M30)) * num, (float) ((double) this.M00 * ((double) this.M12 * (double) this.M23 - (double) this.M13 * (double) this.M22) - (double) this.M02 * ((double) this.M10 * (double) this.M23 - (double) this.M13 * (double) this.M20) + (double) this.M03 * ((double) this.M10 * (double) this.M22 - (double) this.M12 * (double) this.M20)) * num, (float) ((double) this.M10 * ((double) this.M21 * (double) this.M33 - (double) this.M23 * (double) this.M31) - (double) this.M11 * ((double) this.M20 * (double) this.M33 - (double) this.M23 * (double) this.M30) + (double) this.M13 * ((double) this.M20 * (double) this.M31 - (double) this.M21 * (double) this.M30)) * num, (float) -((double) this.M00 * ((double) this.M21 * (double) this.M33 - (double) this.M23 * (double) this.M31) - (double) this.M01 * ((double) this.M20 * (double) this.M33 - (double) this.M23 * (double) this.M30) + (double) this.M03 * ((double) this.M20 * (double) this.M31 - (double) this.M21 * (double) this.M30)) * num, (float) ((double) this.M00 * ((double) this.M11 * (double) this.M33 - (double) this.M13 * (double) this.M31) - (double) this.M01 * ((double) this.M10 * (double) this.M33 - (double) this.M13 * (double) this.M30) + (double) this.M03 * ((double) this.M10 * (double) this.M31 - (double) this.M11 * (double) this.M30)) * num, (float) -((double) this.M00 * ((double) this.M11 * (double) this.M23 - (double) this.M13 * (double) this.M21) - (double) this.M01 * ((double) this.M10 * (double) this.M23 - (double) this.M13 * (double) this.M20) + (double) this.M03 * ((double) this.M10 * (double) this.M21 - (double) this.M11 * (double) this.M20)) * num, (float) -((double) this.M10 * ((double) this.M21 * (double) this.M32 - (double) this.M22 * (double) this.M31) - (double) this.M11 * ((double) this.M20 * (double) this.M32 - (double) this.M22 * (double) this.M30) + (double) this.M12 * ((double) this.M20 * (double) this.M31 - (double) this.M21 * (double) this.M30)) * num, (float) ((double) this.M00 * ((double) this.M21 * (double) this.M32 - (double) this.M22 * (double) this.M31) - (double) this.M01 * ((double) this.M20 * (double) this.M32 - (double) this.M22 * (double) this.M30) + (double) this.M02 * ((double) this.M20 * (double) this.M31 - (double) this.M21 * (double) this.M30)) * num, (float) -((double) this.M00 * ((double) this.M11 * (double) this.M32 - (double) this.M12 * (double) this.M31) - (double) this.M01 * ((double) this.M10 * (double) this.M32 - (double) this.M12 * (double) this.M30) + (double) this.M02 * ((double) this.M10 * (double) this.M31 - (double) this.M11 * (double) this.M30)) * num, (float) ((double) this.M00 * ((double) this.M11 * (double) this.M22 - (double) this.M12 * (double) this.M21) - (double) this.M01 * ((double) this.M10 * (double) this.M22 - (double) this.M12 * (double) this.M20) + (double) this.M02 * ((double) this.M10 * (double) this.M21 - (double) this.M11 * (double) this.M20)) * num);
    }

    public Matrix4F GetInverse(out bool couldInvert)
    {
      float determinant = this.GetDeterminant();
      float num = 1f / determinant;
      couldInvert = (double) determinant != 0.0;
      return new Matrix4F((float) ((double) this.M11 * ((double) this.M22 * (double) this.M33 - (double) this.M23 * (double) this.M32) - (double) this.M12 * ((double) this.M21 * (double) this.M33 - (double) this.M23 * (double) this.M31) + (double) this.M13 * ((double) this.M21 * (double) this.M32 - (double) this.M22 * (double) this.M31)) * num, (float) -((double) this.M01 * ((double) this.M22 * (double) this.M33 - (double) this.M23 * (double) this.M32) - (double) this.M02 * ((double) this.M21 * (double) this.M33 - (double) this.M23 * (double) this.M31) + (double) this.M03 * ((double) this.M21 * (double) this.M32 - (double) this.M22 * (double) this.M31)) * num, (float) ((double) this.M01 * ((double) this.M12 * (double) this.M33 - (double) this.M13 * (double) this.M32) - (double) this.M02 * ((double) this.M11 * (double) this.M33 - (double) this.M13 * (double) this.M31) + (double) this.M03 * ((double) this.M11 * (double) this.M32 - (double) this.M12 * (double) this.M31)) * num, (float) -((double) this.M01 * ((double) this.M12 * (double) this.M23 - (double) this.M13 * (double) this.M22) - (double) this.M02 * ((double) this.M11 * (double) this.M23 - (double) this.M13 * (double) this.M21) + (double) this.M03 * ((double) this.M11 * (double) this.M22 - (double) this.M12 * (double) this.M21)) * num, (float) -((double) this.M10 * ((double) this.M22 * (double) this.M33 - (double) this.M23 * (double) this.M32) - (double) this.M12 * ((double) this.M20 * (double) this.M33 - (double) this.M23 * (double) this.M30) + (double) this.M13 * ((double) this.M20 * (double) this.M32 - (double) this.M22 * (double) this.M30)) * num, (float) ((double) this.M00 * ((double) this.M22 * (double) this.M33 - (double) this.M23 * (double) this.M32) - (double) this.M02 * ((double) this.M20 * (double) this.M33 - (double) this.M23 * (double) this.M30) + (double) this.M03 * ((double) this.M20 * (double) this.M32 - (double) this.M22 * (double) this.M30)) * num, (float) -((double) this.M00 * ((double) this.M12 * (double) this.M33 - (double) this.M13 * (double) this.M32) - (double) this.M02 * ((double) this.M10 * (double) this.M33 - (double) this.M13 * (double) this.M30) + (double) this.M03 * ((double) this.M10 * (double) this.M32 - (double) this.M12 * (double) this.M30)) * num, (float) ((double) this.M00 * ((double) this.M12 * (double) this.M23 - (double) this.M13 * (double) this.M22) - (double) this.M02 * ((double) this.M10 * (double) this.M23 - (double) this.M13 * (double) this.M20) + (double) this.M03 * ((double) this.M10 * (double) this.M22 - (double) this.M12 * (double) this.M20)) * num, (float) ((double) this.M10 * ((double) this.M21 * (double) this.M33 - (double) this.M23 * (double) this.M31) - (double) this.M11 * ((double) this.M20 * (double) this.M33 - (double) this.M23 * (double) this.M30) + (double) this.M13 * ((double) this.M20 * (double) this.M31 - (double) this.M21 * (double) this.M30)) * num, (float) -((double) this.M00 * ((double) this.M21 * (double) this.M33 - (double) this.M23 * (double) this.M31) - (double) this.M01 * ((double) this.M20 * (double) this.M33 - (double) this.M23 * (double) this.M30) + (double) this.M03 * ((double) this.M20 * (double) this.M31 - (double) this.M21 * (double) this.M30)) * num, (float) ((double) this.M00 * ((double) this.M11 * (double) this.M33 - (double) this.M13 * (double) this.M31) - (double) this.M01 * ((double) this.M10 * (double) this.M33 - (double) this.M13 * (double) this.M30) + (double) this.M03 * ((double) this.M10 * (double) this.M31 - (double) this.M11 * (double) this.M30)) * num, (float) -((double) this.M00 * ((double) this.M11 * (double) this.M23 - (double) this.M13 * (double) this.M21) - (double) this.M01 * ((double) this.M10 * (double) this.M23 - (double) this.M13 * (double) this.M20) + (double) this.M03 * ((double) this.M10 * (double) this.M21 - (double) this.M11 * (double) this.M20)) * num, (float) -((double) this.M10 * ((double) this.M21 * (double) this.M32 - (double) this.M22 * (double) this.M31) - (double) this.M11 * ((double) this.M20 * (double) this.M32 - (double) this.M22 * (double) this.M30) + (double) this.M12 * ((double) this.M20 * (double) this.M31 - (double) this.M21 * (double) this.M30)) * num, (float) ((double) this.M00 * ((double) this.M21 * (double) this.M32 - (double) this.M22 * (double) this.M31) - (double) this.M01 * ((double) this.M20 * (double) this.M32 - (double) this.M22 * (double) this.M30) + (double) this.M02 * ((double) this.M20 * (double) this.M31 - (double) this.M21 * (double) this.M30)) * num, (float) -((double) this.M00 * ((double) this.M11 * (double) this.M32 - (double) this.M12 * (double) this.M31) - (double) this.M01 * ((double) this.M10 * (double) this.M32 - (double) this.M12 * (double) this.M30) + (double) this.M02 * ((double) this.M10 * (double) this.M31 - (double) this.M11 * (double) this.M30)) * num, (float) ((double) this.M00 * ((double) this.M11 * (double) this.M22 - (double) this.M12 * (double) this.M21) - (double) this.M01 * ((double) this.M10 * (double) this.M22 - (double) this.M12 * (double) this.M20) + (double) this.M02 * ((double) this.M10 * (double) this.M21 - (double) this.M11 * (double) this.M20)) * num);
    }

    public Matrix4F GetTranspose()
    {
      Matrix4F matrix4F = this;
      matrix4F.Transpose();
      return matrix4F;
    }

    [SecurityCritical]
    public Matrix3F GetMinor(int removeRow, int removeColumn)
    {
      int index1 = 0;
      Matrix3F matrix3F = new Matrix3F();
      for (int index2 = 0; index2 < 4; ++index2)
      {
        int index3 = 0;
        if (index2 != removeRow)
        {
          for (int index4 = 0; index4 < 4; ++index4)
          {
            if (index4 != removeColumn)
            {
              matrix3F[index1, index3] = this[index2, index4];
              ++index3;
            }
          }
          ++index1;
        }
      }
      return matrix3F;
    }

    public float GetTrace()
    {
      return this.M00 + this.M11 + this.M22 + this.M33;
    }

    public void Transpose()
    {
      MathUtil.Swap(ref this.M01, ref this.M10);
      MathUtil.Swap(ref this.M02, ref this.M20);
      MathUtil.Swap(ref this.M03, ref this.M30);
      MathUtil.Swap(ref this.M12, ref this.M21);
      MathUtil.Swap(ref this.M13, ref this.M31);
      MathUtil.Swap(ref this.M23, ref this.M32);
    }

    public static bool AreApproxEqual(Matrix4F a, Matrix4F b)
    {
      return Matrix4F.AreApproxEqual(a, b, 4.768372E-07f);
    }

    public static bool AreApproxEqual(Matrix4F a, Matrix4F b, float tolerance)
    {
      if ((double) System.Math.Abs(b.M00 - a.M00) <= (double) tolerance && (double) System.Math.Abs(b.M01 - a.M01) <= (double) tolerance && ((double) System.Math.Abs(b.M02 - a.M02) <= (double) tolerance && (double) System.Math.Abs(b.M03 - a.M03) <= (double) tolerance) && ((double) System.Math.Abs(b.M10 - a.M10) <= (double) tolerance && (double) System.Math.Abs(b.M11 - a.M11) <= (double) tolerance && ((double) System.Math.Abs(b.M12 - a.M12) <= (double) tolerance && (double) System.Math.Abs(b.M13 - a.M13) <= (double) tolerance)) && ((double) System.Math.Abs(b.M20 - a.M20) <= (double) tolerance && (double) System.Math.Abs(b.M21 - a.M21) <= (double) tolerance && ((double) System.Math.Abs(b.M22 - a.M22) <= (double) tolerance && (double) System.Math.Abs(b.M23 - a.M23) <= (double) tolerance) && ((double) System.Math.Abs(b.M30 - a.M30) <= (double) tolerance && (double) System.Math.Abs(b.M31 - a.M31) <= (double) tolerance && (double) System.Math.Abs(b.M32 - a.M32) <= (double) tolerance)))
        return (double) System.Math.Abs(b.M33 - a.M33) <= (double) tolerance;
      return false;
    }

    public static bool operator ==(Matrix4F a, Matrix4F b)
    {
      return object.Equals((object) a, (object) b);
    }

    public static bool operator !=(Matrix4F a, Matrix4F b)
    {
      return !object.Equals((object) a, (object) b);
    }

    public static Matrix4F operator +(Matrix4F a, Matrix4F b)
    {
      return Matrix4F.Add(a, b);
    }

    public static Matrix4F operator -(Matrix4F a, Matrix4F b)
    {
      return Matrix4F.Subtract(a, b);
    }

    public static Matrix4F operator *(Matrix4F a, Matrix4F b)
    {
      return Matrix4F.Multiply(a, b);
    }

    public static Vector4F operator *(Matrix4F matrix, Vector4F vector)
    {
      return matrix.Transform(vector);
    }

    public static Vector3F operator *(Matrix4F matrix, Vector3F vector)
    {
      return matrix.Transform(vector);
    }

    public static Point3F operator *(Matrix4F matrix, Point3F point)
    {
      return matrix.Transform(point);
    }

    public unsafe float this[int index]
    {
      [SecurityCritical] get
      {
        if (index < 0 || index >= 16)
          throw new IndexOutOfRangeException("Invalid matrix index!");
        fixed (float* numPtr = &this.M00)
          return numPtr[index];
      }
      [SecurityCritical] set
      {
        if (index < 0 || index >= 16)
          throw new IndexOutOfRangeException("Invalid matrix index!");
        fixed (float* numPtr = &this.M00)
          numPtr[index] = value;
      }
    }

    public float this[int row, int column]
    {
      [SecurityCritical] get
      {
        return this[(column << 2) + row];
      }
      [SecurityCritical] set
      {
        this[(column << 2) + row] = value;
      }
    }

    private static Matrix4F smethod_0(
      float m00,
      float m01,
      float m02,
      float m03,
      float m10,
      float m11,
      float m12,
      float m13,
      float m20,
      float m21,
      float m22,
      float m23,
      float m30,
      float m31,
      float m32,
      float m33)
    {
      return new Matrix4F(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33);
    }

    public bool Equals(Matrix4F other)
    {
      if ((double) this.M00 == (double) other.M00 && (double) this.M01 == (double) other.M01 && ((double) this.M02 == (double) other.M02 && (double) this.M03 == (double) other.M03) && ((double) this.M10 == (double) other.M10 && (double) this.M11 == (double) other.M11 && ((double) this.M12 == (double) other.M12 && (double) this.M13 == (double) other.M13)) && ((double) this.M20 == (double) other.M20 && (double) this.M21 == (double) other.M21 && ((double) this.M22 == (double) other.M22 && (double) this.M23 == (double) other.M23) && ((double) this.M30 == (double) other.M30 && (double) this.M31 == (double) other.M31 && (double) this.M32 == (double) other.M32)))
        return (double) this.M33 == (double) other.M33;
      return false;
    }
  }
}
