// Decompiled with JetBrains decompiler
// Type: ns26.Class247
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using ns9;
using WW.Math;

namespace ns26
{
  internal class Class247 : Class242
  {
    public const string string_0 = "ellipse";
    public const int int_0 = 16;
    private Point3D point3D_0;
    private Vector3D vector3D_0;
    private Vector3D vector3D_1;
    private double double_0;

    public override void vmethod_0(Interface8 reader)
    {
      this.point3D_0 = reader.imethod_18();
      this.vector3D_0 = reader.imethod_19();
      this.vector3D_1 = reader.imethod_19();
      this.double_0 = reader.imethod_8();
      base.vmethod_0(reader);
    }

    public override void vmethod_1(Interface9 writer)
    {
      writer.imethod_17(this.point3D_0);
      writer.imethod_18(this.vector3D_0);
      writer.imethod_18(this.vector3D_1);
      writer.imethod_7(this.double_0);
      base.vmethod_1(writer);
    }

    public override void imethod_3(
      Class95 loop,
      Class88 curve,
      Class107 coedge,
      Class917 approximation,
      Class258 accuracy)
    {
      Matrix4D canonicalTransformation = this.FromCanonicalTransformation;
      Interface27 interval = this.Interval;
      bool directionReversed = coedge.DirectionReversed;
      Class102 startVertex = coedge.StartVertex;
      Class102 endVertex = coedge.EndVertex;
      Interface27 nterface27;
      if (startVertex != endVertex)
      {
        Matrix4D inverse = canonicalTransformation.GetInverse();
        Class105 point1 = startVertex.Point;
        Class105 point2 = endVertex.Point;
        Point3D point3D1 = point1.method_4(inverse);
        Point3D point3D2 = point2.method_4(inverse);
        nterface27 = (Interface27) new Class437(System.Math.Atan2(point3D1.Y, point3D1.X), System.Math.Atan2(point3D2.Y, point3D2.X));
      }
      else
      {
        Matrix4D inverse = canonicalTransformation.GetInverse();
        Point3D point3D = startVertex.Point.method_4(inverse);
        double start = System.Math.Atan2(point3D.Y, point3D.X);
        double end = directionReversed ? start - 2.0 * System.Math.PI : start + 2.0 * System.Math.PI;
        nterface27 = (Interface27) new Class437(start, end);
      }
      int num1 = Class247.smethod_7(this.vector3D_1.GetLength(), accuracy);
      double start1 = nterface27.Start;
      double end1 = nterface27.End;
      if (directionReversed)
      {
        if (start1 < end1)
          end1 -= 2.0 * System.Math.PI;
      }
      else if (start1 > end1)
        end1 += 2.0 * System.Math.PI;
      double num2 = (end1 - start1) / (double) num1;
      approximation.method_0(coedge.StartLocation);
      for (int index = 1; index < num1; ++index)
      {
        double num3 = (double) index * num2 + start1;
        double x = System.Math.Cos(num3);
        double y = System.Math.Sin(num3);
        Point3D point = canonicalTransformation.Transform(new Point3D(x, y, 0.0));
        approximation.method_0(point);
      }
      approximation.method_0(coedge.EndLocation);
    }

    public Point3D Position
    {
      get
      {
        return this.point3D_0;
      }
    }

    public Vector3D Normal
    {
      get
      {
        return this.vector3D_0;
      }
    }

    public Vector3D MajorAxis
    {
      get
      {
        return this.vector3D_1;
      }
    }

    public double AspectRatio
    {
      get
      {
        return this.double_0;
      }
    }

    public Matrix4D FromCanonicalTransformation
    {
      get
      {
        Vector3D majorAxis = this.MajorAxis;
        double length = majorAxis.GetLength();
        Vector3D v = majorAxis * (1.0 / length);
        Vector3D normal = this.Normal;
        normal.Normalize();
        Vector3D vector3D = Vector3D.CrossProduct(normal, v);
        vector3D.Normalize();
        return Transformation4D.Translation(this.point3D_0.X, this.point3D_0.Y, this.point3D_0.Z) * new Matrix4D(v.X, vector3D.X, normal.X, 0.0, v.Y, vector3D.Y, normal.Y, 0.0, v.Z, vector3D.Z, normal.Z, 0.0, 0.0, 0.0, 0.0, 1.0) * Transformation4D.Scaling(length, this.AspectRatio * length, 1.0);
      }
    }

    public override string imethod_2(int version)
    {
      return "ellipse";
    }

    public static int smethod_7(double radius, Class258 accuracy)
    {
      return Class247.smethod_8(radius, accuracy, 16);
    }

    public static int smethod_8(double radius, Class258 accuracy, int minimalSegments)
    {
      double num = accuracy.method_0(radius);
      return 4 * ((System.Math.Max((int) System.Math.Ceiling(System.Math.PI / System.Math.Acos((radius - num) / radius)), minimalSegments) + 3) / 4);
    }
  }
}
