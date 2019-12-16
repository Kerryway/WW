// Decompiled with JetBrains decompiler
// Type: ns21.Class194
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;
using WW.Math.Geometry;

namespace ns21
{
  internal class Class194 : Class188
  {
    public const string string_0 = "plane";
    private Point3D point3D_0;
    private Vector3D vector3D_0;
    private Vector3D vector3D_1;
    private Class686.Class695 class695_0;

    public override string imethod_2(int version)
    {
      return "plane";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.point3D_0 = reader.imethod_18();
      this.vector3D_0 = reader.imethod_19();
      if (reader.FileFormatVersion >= Class250.int_4)
      {
        this.vector3D_1 = reader.imethod_19();
        this.class695_0 = new Class686.Class695(reader);
      }
      else
      {
        this.vector3D_1 = Vector3D.XAxis;
        this.class695_0.Value = false;
      }
      base.imethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.imethod_17(this.point3D_0);
      writer.imethod_18(this.vector3D_0);
      if (writer.FileFormatVersion >= Class250.int_4)
      {
        writer.imethod_18(this.vector3D_1);
        writer.imethod_12((Interface39) this.class695_0);
      }
      else
      {
        this.vector3D_1 = Vector3D.XAxis;
        this.class695_0.Value = false;
      }
      base.imethod_1(writer);
    }

    protected override Polyline2D vmethod_1(ns9.Class107 edge)
    {
      Point3D location1 = edge.StartVertex.Point.Location;
      Point3D location2 = edge.EndVertex.Point.Location;
      Polyline2D polyline2D = new Polyline2D(2);
      Interface26 pointParamMapper = this.PointParamMapper;
      polyline2D.Add(pointParamMapper.imethod_0(location1));
      polyline2D.Add(pointParamMapper.imethod_0(location2));
      return polyline2D;
    }

    public override Interface26 PointParamMapper
    {
      get
      {
        Vector3D vector3D1 = this.vector3D_1;
        vector3D1.Normalize();
        Vector3D vector3D0 = this.vector3D_0;
        vector3D0.Normalize();
        Vector3D vector3D = Vector3D.CrossProduct(vector3D0, vector3D1);
        vector3D.Normalize();
        if (this.class695_0.Value)
          vector3D *= -1.0;
        Matrix4D toMap = new Matrix4D(vector3D1.X, vector3D1.Y, vector3D1.Z, 0.0, vector3D.X, vector3D.Y, vector3D.Z, 0.0, vector3D0.X, vector3D0.Y, vector3D0.Z, 0.0, 0.0, 0.0, 0.0, 1.0) * Transformation4D.Translation(-this.point3D_0.X, -this.point3D_0.Y, -this.point3D_0.Z);
        return (Interface26) new Class194.Class1069(Transformation4D.Translation(this.point3D_0.X, this.point3D_0.Y, this.point3D_0.Z) * new Matrix4D(vector3D1.X, vector3D.X, vector3D0.X, 0.0, vector3D1.Y, vector3D.Y, vector3D0.Y, 0.0, vector3D1.Z, vector3D.Z, vector3D0.Z, 0.0, 0.0, 0.0, 0.0, 1.0), toMap, this.class695_0.Value);
      }
    }

    private class Class1069 : Interface26
    {
      private readonly Matrix4D matrix4D_0;
      private readonly Matrix4D matrix4D_1;
      private readonly bool bool_0;

      public Class1069(Matrix4D fromMap, Matrix4D toMap, bool reverseY)
      {
        this.matrix4D_0 = fromMap;
        this.matrix4D_1 = toMap;
        this.bool_0 = reverseY;
      }

      public Point2D imethod_0(Point3D point)
      {
        Point3D point3D = this.matrix4D_1.Transform(point);
        return new Point2D(point3D.X, point3D.Y);
      }

      public Point3D imethod_1(double u, double v)
      {
        return this.matrix4D_0.Transform(new Point3D(u, v, 0.0));
      }

      public bool IsRightHandedParametric
      {
        get
        {
          return !this.bool_0;
        }
      }
    }
  }
}
