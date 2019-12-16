// Decompiled with JetBrains decompiler
// Type: ns21.Class190
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;
using WW.Math;
using WW.Math.Geometry;

namespace ns21
{
  internal class Class190 : Class188
  {
    public const string string_0 = "cone";
    private Class247 class247_0;
    private double double_0;
    private double double_1;
    private double double_2;
    private double double_3;
    private Class686.Class690 class690_0;

    public override string imethod_2(int version)
    {
      return "cone";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.class247_0 = new Class247();
      this.class247_0.imethod_0(reader);
      this.double_0 = reader.imethod_8();
      this.double_1 = reader.imethod_8();
      this.double_2 = System.Math.Atan2(this.double_0, this.double_1);
      this.double_3 = reader.FileFormatVersion < Class250.int_41 ? new Vector3D(this.class247_0.MajorAxis).GetLength() : reader.imethod_8();
      this.class690_0 = reader.FileFormatVersion < Class250.int_4 ? new Class686.Class690(false) : new Class686.Class690(reader);
      base.imethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      this.class247_0.imethod_1(writer);
      writer.imethod_7(this.double_0);
      writer.imethod_7(this.double_1);
      if (writer.FileFormatVersion >= Class250.int_41)
        writer.imethod_7(this.double_3);
      if (writer.FileFormatVersion >= Class250.int_4)
        writer.imethod_12((Interface39) this.class690_0);
      base.imethod_1(writer);
    }

    private Point3D method_0(Point3D border1)
    {
      Vector3D v = new Vector3D(this.class247_0.Normal);
      Point3D point3D = new Point3D(this.class247_0.Position);
      return point3D + v * Vector3D.DotProduct(border1 - point3D, v);
    }

    protected override Interface28 ExtendedIntervalU
    {
      get
      {
        return (Interface28) new Class438(this.IntervalU);
      }
    }

    protected override Interface28 ExtendedIntervalV
    {
      get
      {
        return (Interface28) new Class438(this.IntervalV, 2.0 * System.Math.PI);
      }
    }

    protected override void vmethod_0(Class608 wires, Polygon2D[] paramShape, Interface26 mapper)
    {
    }

    protected override Polyline2D vmethod_1(ns9.Class107 edge)
    {
      Point3D location1 = edge.StartVertex.Point.Location;
      Point3D location2 = edge.EndVertex.Point.Location;
      Polyline2D polyline2D = new Polyline2D(2);
      if (location1 == location2 && this.double_2 != 0.0)
      {
        Point3D point3D1 = new Point3D(this.class247_0.Position);
        double length = this.class247_0.MajorAxis.GetLength();
        Vector3D normal = this.class247_0.Normal;
        normal.Normalize();
        Point3D point3D2 = point3D1 - normal * (length / System.Math.Tan(this.double_2));
        if ((point3D2 - location1).GetLength() < 0.0001 * length)
        {
          double x1 = Vector3D.DotProduct(point3D2 - point3D1, normal) / System.Math.Cos(this.double_2);
          if (this.class690_0.Value)
          {
            double x2 = -x1;
            polyline2D.Add(new Point2D(x2, 2.0 * System.Math.PI));
            polyline2D.Add(new Point2D(x2, 4.0 * System.Math.PI / 3.0));
            polyline2D.Add(new Point2D(x2, 2.0 * System.Math.PI / 3.0));
            polyline2D.Add(new Point2D(x2, 0.0));
          }
          else
          {
            polyline2D.Add(new Point2D(x1, 0.0));
            polyline2D.Add(new Point2D(x1, 2.0 * System.Math.PI / 3.0));
            polyline2D.Add(new Point2D(x1, 4.0 * System.Math.PI / 3.0));
            polyline2D.Add(new Point2D(x1, 2.0 * System.Math.PI));
          }
          return polyline2D;
        }
      }
      Interface26 pointParamMapper = this.PointParamMapper;
      polyline2D.Add(pointParamMapper.imethod_0(location1));
      polyline2D.Add(pointParamMapper.imethod_0(location2));
      return polyline2D;
    }

    public override Interface26 PointParamMapper
    {
      get
      {
        return (Interface26) new Class190.Class436(this.double_2, this.class247_0.FromCanonicalTransformation, this);
      }
    }

    private class Class436 : Interface26
    {
      private readonly double double_0;
      private readonly double double_1;
      private readonly Matrix4D matrix4D_0;
      private readonly Matrix4D matrix4D_1;
      private readonly Class190 class190_0;

      public Class436(double angle, Matrix4D fromCanonical, Class190 outer)
      {
        this.double_0 = System.Math.Sin(angle);
        this.double_1 = System.Math.Cos(angle);
        this.matrix4D_0 = fromCanonical;
        this.matrix4D_1 = fromCanonical.GetInverse();
        this.class190_0 = outer;
      }

      public Point2D imethod_0(Point3D point)
      {
        Point3D point3D = this.matrix4D_1.Transform(point);
        double y = System.Math.Atan2(point3D.Y, point3D.X);
        double x = point3D.Z / this.double_1;
        if (this.class190_0.class690_0.Value)
          x = -x;
        return new Point2D(x, y);
      }

      public Point3D imethod_1(double u, double v)
      {
        if (this.class190_0.class690_0.Value)
          u = -u;
        double num = 1.0 + u / this.class190_0.double_3 * this.double_0;
        return this.matrix4D_0.Transform(new Point3D(num * System.Math.Cos(v), num * System.Math.Sin(v), u * this.double_1));
      }

      public bool IsRightHandedParametric
      {
        get
        {
          return !this.class190_0.class690_0.Value;
        }
      }
    }
  }
}
