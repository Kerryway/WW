// Decompiled with JetBrains decompiler
// Type: WW.Math.Matrix4D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Security;

namespace WW.Math
{
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public struct Matrix4D : ITransformer4D, IEquatable<Matrix4D>
  {
    public static readonly Matrix4D Zero = Matrix4D.smethod_0(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
    public static readonly Matrix4D Identity = Matrix4D.smethod_0(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
    public double M00;
    public double M10;
    public double M20;
    public double M30;
    public double M01;
    public double M11;
    public double M21;
    public double M31;
    public double M02;
    public double M12;
    public double M22;
    public double M32;
    public double M03;
    public double M13;
    public double M23;
    public double M33;

    public Matrix4D(
      double m00,
      double m01,
      double m02,
      double m03,
      double m10,
      double m11,
      double m12,
      double m13,
      double m20,
      double m21,
      double m22,
      double m23,
      double m30,
      double m31,
      double m32,
      double m33)
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

    public Matrix4D(double[] elements)
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

    public Matrix4D(IList<double> elements)
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

    public Matrix4D(Vector4D column1, Vector4D column2, Vector4D column3, Vector4D column4)
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

    public Matrix4D(Matrix4D m)
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

    public Matrix4D(Matrix3D m)
    {
      this.M00 = m.M00;
      this.M01 = m.M01;
      this.M02 = m.M02;
      this.M03 = 0.0;
      this.M10 = m.M10;
      this.M11 = m.M11;
      this.M12 = m.M12;
      this.M13 = 0.0;
      this.M20 = m.M20;
      this.M21 = m.M21;
      this.M22 = m.M22;
      this.M23 = 0.0;
      this.M30 = 0.0;
      this.M31 = 0.0;
      this.M32 = 0.0;
      this.M33 = 1.0;
    }

    public static Matrix4D Add(Matrix4D a, Matrix4D b)
    {
      return new Matrix4D(a.M00 + b.M00, a.M01 + b.M01, a.M02 + b.M02, a.M03 + b.M03, a.M10 + b.M10, a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13, a.M20 + b.M20, a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23, a.M30 + b.M30, a.M31 + b.M31, a.M32 + b.M32, a.M33 + b.M33);
    }

    public static Matrix4D Subtract(Matrix4D a, Matrix4D b)
    {
      return new Matrix4D(a.M00 - b.M00, a.M01 - b.M01, a.M02 - b.M02, a.M03 - b.M03, a.M10 - b.M10, a.M11 - b.M11, a.M12 - b.M12, a.M13 - b.M13, a.M20 - b.M20, a.M21 - b.M21, a.M22 - b.M22, a.M23 - b.M23, a.M30 - b.M30, a.M31 - b.M31, a.M32 - b.M32, a.M33 - b.M33);
    }

    public static Matrix4D Multiply(Matrix4D a, Matrix4D b)
    {
      return new Matrix4D(a.M00 * b.M00 + a.M01 * b.M10 + a.M02 * b.M20 + a.M03 * b.M30, a.M00 * b.M01 + a.M01 * b.M11 + a.M02 * b.M21 + a.M03 * b.M31, a.M00 * b.M02 + a.M01 * b.M12 + a.M02 * b.M22 + a.M03 * b.M32, a.M00 * b.M03 + a.M01 * b.M13 + a.M02 * b.M23 + a.M03 * b.M33, a.M10 * b.M00 + a.M11 * b.M10 + a.M12 * b.M20 + a.M13 * b.M30, a.M10 * b.M01 + a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31, a.M10 * b.M02 + a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32, a.M10 * b.M03 + a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33, a.M20 * b.M00 + a.M21 * b.M10 + a.M22 * b.M20 + a.M23 * b.M30, a.M20 * b.M01 + a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31, a.M20 * b.M02 + a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32, a.M20 * b.M03 + a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33, a.M30 * b.M00 + a.M31 * b.M10 + a.M32 * b.M20 + a.M33 * b.M30, a.M30 * b.M01 + a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31, a.M30 * b.M02 + a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32, a.M30 * b.M03 + a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33);
    }

    public static Matrix4D Multiply(Matrix4D a, Matrix2D b)
    {
      return new Matrix4D(a.M00 * b.M00 + a.M01 * b.M10, a.M00 * b.M01 + a.M01 * b.M11, a.M02, a.M03, a.M10 * b.M00 + a.M11 * b.M10, a.M10 * b.M01 + a.M11 * b.M11, a.M12, a.M13, a.M20 * b.M00 + a.M21 * b.M10, a.M20 * b.M01 + a.M21 * b.M11, a.M22, a.M23, a.M30 * b.M00 + a.M31 * b.M10, a.M30 * b.M01 + a.M31 * b.M11, a.M32, a.M33);
    }

    public static Matrix4D Transpose(Matrix4D m)
    {
      Matrix4D matrix4D = new Matrix4D(m);
      matrix4D.Transpose();
      return matrix4D;
    }

    public override int GetHashCode()
    {
      return this.M00.GetHashCode() ^ this.M01.GetHashCode() ^ this.M02.GetHashCode() ^ this.M03.GetHashCode() ^ this.M10.GetHashCode() ^ this.M11.GetHashCode() ^ this.M12.GetHashCode() ^ this.M13.GetHashCode() ^ this.M20.GetHashCode() ^ this.M21.GetHashCode() ^ this.M22.GetHashCode() ^ this.M23.GetHashCode() ^ this.M30.GetHashCode() ^ this.M31.GetHashCode() ^ this.M32.GetHashCode() ^ this.M33.GetHashCode();
    }

    public override bool Equals(object other)
    {
      if (other is Matrix4D)
        return this.Equals((Matrix4D) other);
      return false;
    }

    public override string ToString()
    {
      return string.Format("|{0}, {1}, {2}, {3}|\n|{4}, {5}, {6}, {7}|\n|{8}, {9}, {10}, {11}|\n|{12}, {13}, {14}, {15}|\n", (object) this.M00, (object) this.M01, (object) this.M02, (object) this.M03, (object) this.M10, (object) this.M11, (object) this.M12, (object) this.M13, (object) this.M20, (object) this.M21, (object) this.M22, (object) this.M23, (object) this.M30, (object) this.M31, (object) this.M32, (object) this.M33);
    }

    public Vector4D Transform(Vector4D vector)
    {
      return new Vector4D(this.M00 * vector.X + this.M01 * vector.Y + this.M02 * vector.Z + this.M03 * vector.W, this.M10 * vector.X + this.M11 * vector.Y + this.M12 * vector.Z + this.M13 * vector.W, this.M20 * vector.X + this.M21 * vector.Y + this.M22 * vector.Z + this.M23 * vector.W, this.M30 * vector.X + this.M31 * vector.Y + this.M32 * vector.Z + this.M33 * vector.W);
    }

    public Vector3D Transform(Vector3D vector)
    {
      return new Vector3D(this.M00 * vector.X + this.M01 * vector.Y + this.M02 * vector.Z, this.M10 * vector.X + this.M11 * vector.Y + this.M12 * vector.Z, this.M20 * vector.X + this.M21 * vector.Y + this.M22 * vector.Z);
    }

    public Vector2D TransformTo2D(Vector3D vector)
    {
      return new Vector2D(this.M00 * vector.X + this.M01 * vector.Y + this.M02 * vector.Z, this.M10 * vector.X + this.M11 * vector.Y + this.M12 * vector.Z);
    }

    public Vector2D Transform(Vector2D vector)
    {
      return new Vector2D(this.M00 * vector.X + this.M01 * vector.Y, this.M10 * vector.X + this.M11 * vector.Y);
    }

    public Point3D Transform(Point3D point)
    {
      double num = 1.0 / (this.M30 * point.X + this.M31 * point.Y + this.M32 * point.Z + this.M33);
      return new Point3D((this.M00 * point.X + this.M01 * point.Y + this.M02 * point.Z + this.M03) * num, (this.M10 * point.X + this.M11 * point.Y + this.M12 * point.Z + this.M13) * num, (this.M20 * point.X + this.M21 * point.Y + this.M22 * point.Z + this.M23) * num);
    }

    public Point3D Transform4x3(Point3D point)
    {
      return new Point3D(this.M00 * point.X + this.M01 * point.Y + this.M02 * point.Z + this.M03, this.M10 * point.X + this.M11 * point.Y + this.M12 * point.Z + this.M13, this.M20 * point.X + this.M21 * point.Y + this.M22 * point.Z + this.M23);
    }

    public Point2D Transform(Point2D point)
    {
      double num = 1.0 / (this.M30 * point.X + this.M31 * point.Y + this.M33);
      return new Point2D((this.M00 * point.X + this.M01 * point.Y + this.M03) * num, (this.M10 * point.X + this.M11 * point.Y + this.M13) * num);
    }

    public Point3D TransformTo3D(Point2D point)
    {
      double num = 1.0 / (this.M30 * point.X + this.M31 * point.Y + this.M33);
      return new Point3D((this.M00 * point.X + this.M01 * point.Y + this.M03) * num, (this.M10 * point.X + this.M11 * point.Y + this.M13) * num, (this.M20 * point.X + this.M21 * point.Y + this.M23) * num);
    }

    public Point3D TransformTo3D4x3(Point2D point)
    {
      return new Point3D(this.M00 * point.X + this.M01 * point.Y + this.M03, this.M10 * point.X + this.M11 * point.Y + this.M13, this.M20 * point.X + this.M21 * point.Y + this.M23);
    }

    public Vector3D TransformTo3D(Vector2D v)
    {
      return new Vector3D(this.M00 * v.X + this.M01 * v.Y, this.M10 * v.X + this.M11 * v.Y, this.M20 * v.X + this.M21 * v.Y);
    }

    public Point3D TransformToPoint3D(Vector4D vector)
    {
      double num = 1.0 / (this.M30 * vector.X + this.M31 * vector.Y + this.M32 * vector.Z + this.M33 * vector.W);
      return new Point3D((this.M00 * vector.X + this.M01 * vector.Y + this.M02 * vector.Z + this.M03 * vector.W) * num, (this.M10 * vector.X + this.M11 * vector.Y + this.M12 * vector.Z + this.M13 * vector.W) * num, (this.M20 * vector.X + this.M21 * vector.Y + this.M22 * vector.Z + this.M23 * vector.W) * num);
    }

    public Point2D TransformToPoint2D(Vector4D vector)
    {
      double num = 1.0 / (this.M30 * vector.X + this.M31 * vector.Y + this.M32 * vector.Z + this.M33 * vector.W);
      return new Point2D((this.M00 * vector.X + this.M01 * vector.Y + this.M02 * vector.Z + this.M03 * vector.W) * num, (this.M10 * vector.X + this.M11 * vector.Y + this.M12 * vector.Z + this.M13 * vector.W) * num);
    }

    public PointF TransformToPointF(Vector4D vector)
    {
      double num = 1.0 / (this.M30 * vector.X + this.M31 * vector.Y + this.M32 * vector.Z + this.M33 * vector.W);
      return new PointF((float) ((this.M00 * vector.X + this.M01 * vector.Y + this.M02 * vector.Z + this.M03 * vector.W) * num), (float) ((this.M10 * vector.X + this.M11 * vector.Y + this.M12 * vector.Z + this.M13 * vector.W) * num));
    }

    public PointF TransformToPointF(Point2D point)
    {
      double num = 1.0 / (this.M30 * point.X + this.M31 * point.Y + this.M33);
      return new PointF((float) ((this.M00 * point.X + this.M01 * point.Y + this.M03) * num), (float) ((this.M10 * point.X + this.M11 * point.Y + this.M13) * num));
    }

    public PointF TransformToPointF(Point3D point)
    {
      double num = 1.0 / (this.M30 * point.X + this.M31 * point.Y + this.M32 * point.Z + this.M33);
      return new PointF((float) ((this.M00 * point.X + this.M01 * point.Y + this.M02 * point.Z + this.M03) * num), (float) ((this.M10 * point.X + this.M11 * point.Y + this.M12 * point.Z + this.M13) * num));
    }

    public System.Windows.Point TransformToWindowsPoint(Vector4D vector)
    {
      double num = 1.0 / (this.M30 * vector.X + this.M31 * vector.Y + this.M32 * vector.Z + this.M33 * vector.W);
      return new System.Windows.Point((this.M00 * vector.X + this.M01 * vector.Y + this.M02 * vector.Z + this.M03 * vector.W) * num, (this.M10 * vector.X + this.M11 * vector.Y + this.M12 * vector.Z + this.M13 * vector.W) * num);
    }

    public Point2D TransformTo2D(Point3D point)
    {
      double num = 1.0 / (this.M30 * point.X + this.M31 * point.Y + this.M32 * point.Z + this.M33);
      return new Point2D((this.M00 * point.X + this.M01 * point.Y + this.M02 * point.Z + this.M03) * num, (this.M10 * point.X + this.M11 * point.Y + this.M12 * point.Z + this.M13) * num);
    }

    public Point2D TransformTo2D(Point2D point)
    {
      double num = 1.0 / (this.M30 * point.X + this.M31 * point.Y + this.M33);
      return new Point2D((this.M00 * point.X + this.M01 * point.Y + this.M03) * num, (this.M10 * point.X + this.M11 * point.Y + this.M13) * num);
    }

    public Point2D TransformTo2D(Vector4D point)
    {
      double num = 1.0 / (this.M30 * point.X + this.M31 * point.Y + this.M32 * point.Z + this.M33 * point.W);
      return new Point2D((this.M00 * point.X + this.M01 * point.Y + this.M02 * point.Z + this.M03 * point.W) * num, (this.M10 * point.X + this.M11 * point.Y + this.M12 * point.Z + this.M13 * point.W) * num);
    }

    public Point3D TransformTo3D(Vector4D point)
    {
      double num = 1.0 / (this.M30 * point.X + this.M31 * point.Y + this.M32 * point.Z + this.M33 * point.W);
      return new Point3D((this.M00 * point.X + this.M01 * point.Y + this.M02 * point.Z + this.M03 * point.W) * num, (this.M10 * point.X + this.M11 * point.Y + this.M12 * point.Z + this.M13 * point.W) * num, (this.M20 * point.X + this.M21 * point.Y + this.M22 * point.Z + this.M23 * point.W) * num);
    }

    public PointF TransformTo2D(PointF point)
    {
      double num = 1.0 / (this.M30 * (double) point.X + this.M31 * (double) point.Y + this.M33);
      return new PointF((float) ((this.M00 * (double) point.X + this.M01 * (double) point.Y + this.M03) * num), (float) ((this.M10 * (double) point.X + this.M11 * (double) point.Y + this.M13) * num));
    }

    public Vector4D TransformTo4D(Point2D point)
    {
      return new Vector4D(this.M00 * point.X + this.M01 * point.Y + this.M03, this.M10 * point.X + this.M11 * point.Y + this.M13, this.M20 * point.X + this.M21 * point.Y + this.M23, this.M30 * point.X + this.M31 * point.Y + this.M33);
    }

    public Vector4D TransformTo4D(Point3D point)
    {
      return new Vector4D(this.M00 * point.X + this.M01 * point.Y + this.M02 * point.Z + this.M03, this.M10 * point.X + this.M11 * point.Y + this.M12 * point.Z + this.M13, this.M20 * point.X + this.M21 * point.Y + this.M22 * point.Z + this.M23, this.M30 * point.X + this.M31 * point.Y + this.M32 * point.Z + this.M33);
    }

    public Vector4D TransformTo4D(Vector3D vector)
    {
      return new Vector4D(this.M00 * vector.X + this.M01 * vector.Y + this.M02 * vector.Z, this.M10 * vector.X + this.M11 * vector.Y + this.M12 * vector.Z, this.M20 * vector.X + this.M21 * vector.Y + this.M22 * vector.Z, this.M30 * vector.X + this.M31 * vector.Y + this.M32 * vector.Z);
    }

    public double TransformAngle(double angle)
    {
      Vector2D vector2D = this.Transform(new Vector2D(System.Math.Cos(angle), System.Math.Sin(angle)));
      return System.Math.Atan2(vector2D.Y, vector2D.X);
    }

    public double GetDeterminant()
    {
      return this.M00 * (this.M11 * (this.M22 * this.M33 - this.M23 * this.M32) - this.M12 * (this.M21 * this.M33 - this.M23 * this.M31) + this.M13 * (this.M21 * this.M32 - this.M22 * this.M31)) - this.M01 * (this.M10 * (this.M22 * this.M33 - this.M23 * this.M32) - this.M12 * (this.M20 * this.M33 - this.M23 * this.M30) + this.M13 * (this.M20 * this.M32 - this.M22 * this.M30)) + this.M02 * (this.M10 * (this.M21 * this.M33 - this.M23 * this.M31) - this.M11 * (this.M20 * this.M33 - this.M23 * this.M30) + this.M13 * (this.M20 * this.M31 - this.M21 * this.M30)) - this.M03 * (this.M10 * (this.M21 * this.M32 - this.M22 * this.M31) - this.M11 * (this.M20 * this.M32 - this.M22 * this.M30) + this.M12 * (this.M20 * this.M31 - this.M21 * this.M30));
    }

    public Matrix4D GetAdjoint()
    {
      return new Matrix4D(this.M11 * (this.M22 * this.M33 - this.M23 * this.M32) - this.M12 * (this.M21 * this.M33 - this.M23 * this.M31) + this.M13 * (this.M21 * this.M32 - this.M22 * this.M31), -(this.M01 * (this.M22 * this.M33 - this.M23 * this.M32) - this.M02 * (this.M21 * this.M33 - this.M23 * this.M31) + this.M03 * (this.M21 * this.M32 - this.M22 * this.M31)), this.M01 * (this.M12 * this.M33 - this.M13 * this.M32) - this.M02 * (this.M11 * this.M33 - this.M13 * this.M31) + this.M03 * (this.M11 * this.M32 - this.M12 * this.M31), -(this.M01 * (this.M12 * this.M23 - this.M13 * this.M22) - this.M02 * (this.M11 * this.M23 - this.M13 * this.M21) + this.M03 * (this.M11 * this.M22 - this.M12 * this.M21)), -(this.M10 * (this.M22 * this.M33 - this.M23 * this.M32) - this.M12 * (this.M20 * this.M33 - this.M23 * this.M30) + this.M13 * (this.M20 * this.M32 - this.M22 * this.M30)), this.M00 * (this.M22 * this.M33 - this.M23 * this.M32) - this.M02 * (this.M20 * this.M33 - this.M23 * this.M30) + this.M03 * (this.M20 * this.M32 - this.M22 * this.M30), -(this.M00 * (this.M12 * this.M33 - this.M13 * this.M32) - this.M02 * (this.M10 * this.M33 - this.M13 * this.M30) + this.M03 * (this.M10 * this.M32 - this.M12 * this.M30)), this.M00 * (this.M12 * this.M23 - this.M13 * this.M22) - this.M02 * (this.M10 * this.M23 - this.M13 * this.M20) + this.M03 * (this.M10 * this.M22 - this.M12 * this.M20), this.M10 * (this.M21 * this.M33 - this.M23 * this.M31) - this.M11 * (this.M20 * this.M33 - this.M23 * this.M30) + this.M13 * (this.M20 * this.M31 - this.M21 * this.M30), -(this.M00 * (this.M21 * this.M33 - this.M23 * this.M31) - this.M01 * (this.M20 * this.M33 - this.M23 * this.M30) + this.M03 * (this.M20 * this.M31 - this.M21 * this.M30)), this.M00 * (this.M11 * this.M33 - this.M13 * this.M31) - this.M01 * (this.M10 * this.M33 - this.M13 * this.M30) + this.M03 * (this.M10 * this.M31 - this.M11 * this.M30), -(this.M00 * (this.M11 * this.M23 - this.M13 * this.M21) - this.M01 * (this.M10 * this.M23 - this.M13 * this.M20) + this.M03 * (this.M10 * this.M21 - this.M11 * this.M20)), -(this.M10 * (this.M21 * this.M32 - this.M22 * this.M31) - this.M11 * (this.M20 * this.M32 - this.M22 * this.M30) + this.M12 * (this.M20 * this.M31 - this.M21 * this.M30)), this.M00 * (this.M21 * this.M32 - this.M22 * this.M31) - this.M01 * (this.M20 * this.M32 - this.M22 * this.M30) + this.M02 * (this.M20 * this.M31 - this.M21 * this.M30), -(this.M00 * (this.M11 * this.M32 - this.M12 * this.M31) - this.M01 * (this.M10 * this.M32 - this.M12 * this.M30) + this.M02 * (this.M10 * this.M31 - this.M11 * this.M30)), this.M00 * (this.M11 * this.M22 - this.M12 * this.M21) - this.M01 * (this.M10 * this.M22 - this.M12 * this.M20) + this.M02 * (this.M10 * this.M21 - this.M11 * this.M20));
    }

    public Matrix4D GetInverse()
    {
      double num = 1.0 / this.GetDeterminant();
      return new Matrix4D((this.M11 * (this.M22 * this.M33 - this.M23 * this.M32) - this.M12 * (this.M21 * this.M33 - this.M23 * this.M31) + this.M13 * (this.M21 * this.M32 - this.M22 * this.M31)) * num, -(this.M01 * (this.M22 * this.M33 - this.M23 * this.M32) - this.M02 * (this.M21 * this.M33 - this.M23 * this.M31) + this.M03 * (this.M21 * this.M32 - this.M22 * this.M31)) * num, (this.M01 * (this.M12 * this.M33 - this.M13 * this.M32) - this.M02 * (this.M11 * this.M33 - this.M13 * this.M31) + this.M03 * (this.M11 * this.M32 - this.M12 * this.M31)) * num, -(this.M01 * (this.M12 * this.M23 - this.M13 * this.M22) - this.M02 * (this.M11 * this.M23 - this.M13 * this.M21) + this.M03 * (this.M11 * this.M22 - this.M12 * this.M21)) * num, -(this.M10 * (this.M22 * this.M33 - this.M23 * this.M32) - this.M12 * (this.M20 * this.M33 - this.M23 * this.M30) + this.M13 * (this.M20 * this.M32 - this.M22 * this.M30)) * num, (this.M00 * (this.M22 * this.M33 - this.M23 * this.M32) - this.M02 * (this.M20 * this.M33 - this.M23 * this.M30) + this.M03 * (this.M20 * this.M32 - this.M22 * this.M30)) * num, -(this.M00 * (this.M12 * this.M33 - this.M13 * this.M32) - this.M02 * (this.M10 * this.M33 - this.M13 * this.M30) + this.M03 * (this.M10 * this.M32 - this.M12 * this.M30)) * num, (this.M00 * (this.M12 * this.M23 - this.M13 * this.M22) - this.M02 * (this.M10 * this.M23 - this.M13 * this.M20) + this.M03 * (this.M10 * this.M22 - this.M12 * this.M20)) * num, (this.M10 * (this.M21 * this.M33 - this.M23 * this.M31) - this.M11 * (this.M20 * this.M33 - this.M23 * this.M30) + this.M13 * (this.M20 * this.M31 - this.M21 * this.M30)) * num, -(this.M00 * (this.M21 * this.M33 - this.M23 * this.M31) - this.M01 * (this.M20 * this.M33 - this.M23 * this.M30) + this.M03 * (this.M20 * this.M31 - this.M21 * this.M30)) * num, (this.M00 * (this.M11 * this.M33 - this.M13 * this.M31) - this.M01 * (this.M10 * this.M33 - this.M13 * this.M30) + this.M03 * (this.M10 * this.M31 - this.M11 * this.M30)) * num, -(this.M00 * (this.M11 * this.M23 - this.M13 * this.M21) - this.M01 * (this.M10 * this.M23 - this.M13 * this.M20) + this.M03 * (this.M10 * this.M21 - this.M11 * this.M20)) * num, -(this.M10 * (this.M21 * this.M32 - this.M22 * this.M31) - this.M11 * (this.M20 * this.M32 - this.M22 * this.M30) + this.M12 * (this.M20 * this.M31 - this.M21 * this.M30)) * num, (this.M00 * (this.M21 * this.M32 - this.M22 * this.M31) - this.M01 * (this.M20 * this.M32 - this.M22 * this.M30) + this.M02 * (this.M20 * this.M31 - this.M21 * this.M30)) * num, -(this.M00 * (this.M11 * this.M32 - this.M12 * this.M31) - this.M01 * (this.M10 * this.M32 - this.M12 * this.M30) + this.M02 * (this.M10 * this.M31 - this.M11 * this.M30)) * num, (this.M00 * (this.M11 * this.M22 - this.M12 * this.M21) - this.M01 * (this.M10 * this.M22 - this.M12 * this.M20) + this.M02 * (this.M10 * this.M21 - this.M11 * this.M20)) * num);
    }

    public Matrix4D GetInverse(out bool couldInvert)
    {
      double determinant = this.GetDeterminant();
      double num = 1.0 / determinant;
      couldInvert = determinant != 0.0;
      return new Matrix4D((this.M11 * (this.M22 * this.M33 - this.M23 * this.M32) - this.M12 * (this.M21 * this.M33 - this.M23 * this.M31) + this.M13 * (this.M21 * this.M32 - this.M22 * this.M31)) * num, -(this.M01 * (this.M22 * this.M33 - this.M23 * this.M32) - this.M02 * (this.M21 * this.M33 - this.M23 * this.M31) + this.M03 * (this.M21 * this.M32 - this.M22 * this.M31)) * num, (this.M01 * (this.M12 * this.M33 - this.M13 * this.M32) - this.M02 * (this.M11 * this.M33 - this.M13 * this.M31) + this.M03 * (this.M11 * this.M32 - this.M12 * this.M31)) * num, -(this.M01 * (this.M12 * this.M23 - this.M13 * this.M22) - this.M02 * (this.M11 * this.M23 - this.M13 * this.M21) + this.M03 * (this.M11 * this.M22 - this.M12 * this.M21)) * num, -(this.M10 * (this.M22 * this.M33 - this.M23 * this.M32) - this.M12 * (this.M20 * this.M33 - this.M23 * this.M30) + this.M13 * (this.M20 * this.M32 - this.M22 * this.M30)) * num, (this.M00 * (this.M22 * this.M33 - this.M23 * this.M32) - this.M02 * (this.M20 * this.M33 - this.M23 * this.M30) + this.M03 * (this.M20 * this.M32 - this.M22 * this.M30)) * num, -(this.M00 * (this.M12 * this.M33 - this.M13 * this.M32) - this.M02 * (this.M10 * this.M33 - this.M13 * this.M30) + this.M03 * (this.M10 * this.M32 - this.M12 * this.M30)) * num, (this.M00 * (this.M12 * this.M23 - this.M13 * this.M22) - this.M02 * (this.M10 * this.M23 - this.M13 * this.M20) + this.M03 * (this.M10 * this.M22 - this.M12 * this.M20)) * num, (this.M10 * (this.M21 * this.M33 - this.M23 * this.M31) - this.M11 * (this.M20 * this.M33 - this.M23 * this.M30) + this.M13 * (this.M20 * this.M31 - this.M21 * this.M30)) * num, -(this.M00 * (this.M21 * this.M33 - this.M23 * this.M31) - this.M01 * (this.M20 * this.M33 - this.M23 * this.M30) + this.M03 * (this.M20 * this.M31 - this.M21 * this.M30)) * num, (this.M00 * (this.M11 * this.M33 - this.M13 * this.M31) - this.M01 * (this.M10 * this.M33 - this.M13 * this.M30) + this.M03 * (this.M10 * this.M31 - this.M11 * this.M30)) * num, -(this.M00 * (this.M11 * this.M23 - this.M13 * this.M21) - this.M01 * (this.M10 * this.M23 - this.M13 * this.M20) + this.M03 * (this.M10 * this.M21 - this.M11 * this.M20)) * num, -(this.M10 * (this.M21 * this.M32 - this.M22 * this.M31) - this.M11 * (this.M20 * this.M32 - this.M22 * this.M30) + this.M12 * (this.M20 * this.M31 - this.M21 * this.M30)) * num, (this.M00 * (this.M21 * this.M32 - this.M22 * this.M31) - this.M01 * (this.M20 * this.M32 - this.M22 * this.M30) + this.M02 * (this.M20 * this.M31 - this.M21 * this.M30)) * num, -(this.M00 * (this.M11 * this.M32 - this.M12 * this.M31) - this.M01 * (this.M10 * this.M32 - this.M12 * this.M30) + this.M02 * (this.M10 * this.M31 - this.M11 * this.M30)) * num, (this.M00 * (this.M11 * this.M22 - this.M12 * this.M21) - this.M01 * (this.M10 * this.M22 - this.M12 * this.M20) + this.M02 * (this.M10 * this.M21 - this.M11 * this.M20)) * num);
    }

    public Matrix4D GetTranspose()
    {
      Matrix4D matrix4D = this;
      matrix4D.Transpose();
      return matrix4D;
    }

    [SecurityCritical]
    public Matrix3D GetMinor(int removeRow, int removeColumn)
    {
      int index1 = 0;
      Matrix3D matrix3D = new Matrix3D();
      for (int index2 = 0; index2 < 4; ++index2)
      {
        int index3 = 0;
        if (index2 != removeRow)
        {
          for (int index4 = 0; index4 < 4; ++index4)
          {
            if (index4 != removeColumn)
            {
              matrix3D[index1, index3] = this[index2, index4];
              ++index3;
            }
          }
          ++index1;
        }
      }
      return matrix3D;
    }

    public double GetTrace()
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

    public Vector3D GetTranslation()
    {
      return new Vector3D(this.M03, this.M13, this.M23);
    }

    public static bool AreApproxEqual(Matrix4D a, Matrix4D b)
    {
      return Matrix4D.AreApproxEqual(a, b, 8.88178419700125E-16);
    }

    public static bool AreApproxEqual(Matrix4D a, Matrix4D b, double tolerance)
    {
      if (System.Math.Abs(b.M00 - a.M00) <= tolerance && System.Math.Abs(b.M01 - a.M01) <= tolerance && (System.Math.Abs(b.M02 - a.M02) <= tolerance && System.Math.Abs(b.M03 - a.M03) <= tolerance) && (System.Math.Abs(b.M10 - a.M10) <= tolerance && System.Math.Abs(b.M11 - a.M11) <= tolerance && (System.Math.Abs(b.M12 - a.M12) <= tolerance && System.Math.Abs(b.M13 - a.M13) <= tolerance)) && (System.Math.Abs(b.M20 - a.M20) <= tolerance && System.Math.Abs(b.M21 - a.M21) <= tolerance && (System.Math.Abs(b.M22 - a.M22) <= tolerance && System.Math.Abs(b.M23 - a.M23) <= tolerance) && (System.Math.Abs(b.M30 - a.M30) <= tolerance && System.Math.Abs(b.M31 - a.M31) <= tolerance && System.Math.Abs(b.M32 - a.M32) <= tolerance)))
        return System.Math.Abs(b.M33 - a.M33) <= tolerance;
      return false;
    }

    public static bool operator ==(Matrix4D a, Matrix4D b)
    {
      return object.Equals((object) a, (object) b);
    }

    public static bool operator !=(Matrix4D a, Matrix4D b)
    {
      return !object.Equals((object) a, (object) b);
    }

    public static Matrix4D operator +(Matrix4D a, Matrix4D b)
    {
      return Matrix4D.Add(a, b);
    }

    public static Matrix4D operator -(Matrix4D a, Matrix4D b)
    {
      return Matrix4D.Subtract(a, b);
    }

    public static Matrix4D operator *(Matrix4D a, Matrix4D b)
    {
      return Matrix4D.Multiply(a, b);
    }

    public static Vector4D operator *(Matrix4D matrix, Vector4D vector)
    {
      return matrix.Transform(vector);
    }

    public static Vector3D operator *(Matrix4D matrix, Vector3D vector)
    {
      return matrix.Transform(vector);
    }

    public static Point3D operator *(Matrix4D matrix, Point3D point)
    {
      return matrix.Transform(point);
    }

    public static Point3D operator *(Matrix4D matrix, Point2D point)
    {
      return matrix.TransformTo3D(point);
    }

    public unsafe double this[int index]
    {
      [SecurityCritical] get
      {
        if (index < 0 || index >= 16)
          throw new IndexOutOfRangeException("Invalid matrix index!");
        fixed (double* numPtr = &this.M00)
          return numPtr[index];
      }
      [SecurityCritical] set
      {
        if (index < 0 || index >= 16)
          throw new IndexOutOfRangeException("Invalid matrix index!");
        fixed (double* numPtr = &this.M00)
          numPtr[index] = value;
      }
    }

    public double this[int row, int column]
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

    public static explicit operator Matrix4F(Matrix4D matrix)
    {
      return new Matrix4F((float) matrix.M00, (float) matrix.M01, (float) matrix.M02, (float) matrix.M03, (float) matrix.M10, (float) matrix.M11, (float) matrix.M12, (float) matrix.M13, (float) matrix.M20, (float) matrix.M21, (float) matrix.M22, (float) matrix.M23, (float) matrix.M30, (float) matrix.M31, (float) matrix.M32, (float) matrix.M33);
    }

    public static explicit operator Matrix4D(Matrix4F matrix)
    {
      return new Matrix4D((double) matrix.M00, (double) matrix.M01, (double) matrix.M02, (double) matrix.M03, (double) matrix.M10, (double) matrix.M11, (double) matrix.M12, (double) matrix.M13, (double) matrix.M20, (double) matrix.M21, (double) matrix.M22, (double) matrix.M23, (double) matrix.M30, (double) matrix.M31, (double) matrix.M32, (double) matrix.M33);
    }

    private static Matrix4D smethod_0(
      double m00,
      double m01,
      double m02,
      double m03,
      double m10,
      double m11,
      double m12,
      double m13,
      double m20,
      double m21,
      double m22,
      double m23,
      double m30,
      double m31,
      double m32,
      double m33)
    {
      return new Matrix4D(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33);
    }

    public bool Equals(Matrix4D other)
    {
      if (this.M00 == other.M00 && this.M01 == other.M01 && (this.M02 == other.M02 && this.M03 == other.M03) && (this.M10 == other.M10 && this.M11 == other.M11 && (this.M12 == other.M12 && this.M13 == other.M13)) && (this.M20 == other.M20 && this.M21 == other.M21 && (this.M22 == other.M22 && this.M23 == other.M23) && (this.M30 == other.M30 && this.M31 == other.M31 && this.M32 == other.M32)))
        return this.M33 == other.M33;
      return false;
    }

    public string DebugString
    {
      get
      {
        return this.M00.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture) + ", " + this.M01.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture) + ", " + this.M02.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture) + ", " + this.M03.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture) + ", " + this.M10.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture) + ", " + this.M11.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture) + ", " + this.M12.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture) + ", " + this.M13.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture) + ", " + this.M20.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture) + ", " + this.M21.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture) + ", " + this.M22.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture) + ", " + this.M23.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture) + ", " + this.M30.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture) + ", " + this.M31.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture) + ", " + this.M32.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture) + ", " + this.M33.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture);
      }
    }
  }
}
