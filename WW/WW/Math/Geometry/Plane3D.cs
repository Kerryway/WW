// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Plane3D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Math.Geometry
{
  [Serializable]
  public struct Plane3D
  {
    private Vector3D normal;
    private double distance;

    public Plane3D(Vector3D normal, double distance)
    {
      this.normal = normal;
      this.distance = distance;
    }

    public Plane3D(Vector3D normal, Point3D point)
    {
      this.normal = normal;
      this.distance = Vector3D.DotProduct(normal, (Vector3D) point);
    }

    public Vector3D Normal
    {
      get
      {
        return this.normal;
      }
      set
      {
        this.normal = value;
      }
    }

    public double Distance
    {
      get
      {
        return this.distance;
      }
      set
      {
        this.distance = value;
      }
    }

    public Point3D? GetIntersection(Segment3D segment)
    {
      double u;
      return this.GetIntersection(segment, out u);
    }

    public Point3D? GetIntersection(Segment3D segment, out double u)
    {
      Vector3D delta = segment.GetDelta();
      double num1 = Vector3D.DotProduct(this.normal, delta);
      if (System.Math.Abs(num1) < 8.88178419700125E-16)
      {
        if (System.Math.Abs(Vector3D.DotProduct(this.normal, (Vector3D) segment.Start) - this.distance) < 8.88178419700125E-16)
        {
          u = 0.5;
          return new Point3D?(segment.GetCenter());
        }
        u = 0.0;
        return new Point3D?();
      }
      double num2 = this.distance - Vector3D.DotProduct(this.normal, (Vector3D) segment.Start);
      u = num2 / num1;
      if (u >= 0.0 && u <= 1.0)
        return new Point3D?(segment.Start + u * delta);
      return new Point3D?();
    }

    public double? GetIntersectionCoefficient(Segment3D segment)
    {
      double num1 = Vector3D.DotProduct(this.normal, segment.GetDelta());
      if (System.Math.Abs(num1) < 8.88178419700125E-16)
      {
        if (System.Math.Abs(Vector3D.DotProduct(this.normal, (Vector3D) segment.Start) - this.distance) < 8.88178419700125E-16)
          return new double?(0.5);
        return new double?();
      }
      double num2 = (this.distance - Vector3D.DotProduct(this.normal, (Vector3D) segment.Start)) / num1;
      if (num2 >= 0.0 && num2 <= 1.0)
        return new double?(num2);
      return new double?();
    }

    public Point3D? GetIntersection(Ray3D ray)
    {
      double u;
      return this.GetIntersection(ray, out u);
    }

    public Point3D? GetIntersection(Ray3D ray, out double u)
    {
      double num1 = Vector3D.DotProduct(this.normal, ray.Direction);
      if (System.Math.Abs(num1) < 8.88178419700125E-16)
      {
        if (System.Math.Abs(Vector3D.DotProduct(this.normal, (Vector3D) ray.Origin) - this.distance) < 8.88178419700125E-16)
        {
          u = 0.0;
          return new Point3D?(ray.Origin);
        }
        u = 0.0;
        return new Point3D?();
      }
      double num2 = this.distance - Vector3D.DotProduct(this.normal, (Vector3D) ray.Origin);
      u = num2 / num1;
      if (u < 0.0)
        return new Point3D?();
      return new Point3D?(ray.Origin + u * ray.Direction);
    }

    public double? GetIntersectionCoefficient(Ray3D ray)
    {
      double num1 = Vector3D.DotProduct(this.normal, ray.Direction);
      if (System.Math.Abs(num1) < 8.88178419700125E-16)
      {
        if (System.Math.Abs(Vector3D.DotProduct(this.normal, (Vector3D) ray.Origin) - this.distance) < 8.88178419700125E-16)
          return new double?(0.0);
        return new double?();
      }
      double num2 = (this.distance - Vector3D.DotProduct(this.normal, (Vector3D) ray.Origin)) / num1;
      if (num2 < 0.0)
        return new double?();
      return new double?(num2);
    }

    public Point3D? GetIntersection(Line3D line)
    {
      double u;
      return this.GetIntersection(line, out u);
    }

    public Point3D? GetIntersection(Line3D line, out double u)
    {
      double num1 = Vector3D.DotProduct(this.normal, line.Direction);
      if (System.Math.Abs(num1) < 8.88178419700125E-16)
      {
        if (System.Math.Abs(Vector3D.DotProduct(this.normal, (Vector3D) line.Origin) - this.distance) < 8.88178419700125E-16)
        {
          u = 0.0;
          return new Point3D?(line.Origin);
        }
        u = 0.0;
        return new Point3D?();
      }
      double num2 = this.distance - Vector3D.DotProduct(this.normal, (Vector3D) line.Origin);
      u = num2 / num1;
      return new Point3D?(line.Origin + u * line.Direction);
    }

    public double? GetIntersectionCoefficient(Line3D line)
    {
      double num = Vector3D.DotProduct(this.normal, line.Direction);
      if (System.Math.Abs(num) >= 8.88178419700125E-16)
        return new double?((this.distance - Vector3D.DotProduct(this.normal, (Vector3D) line.Origin)) / num);
      if (System.Math.Abs(Vector3D.DotProduct(this.normal, (Vector3D) line.Origin) - this.distance) < 8.88178419700125E-16)
        return new double?(0.0);
      return new double?();
    }
  }
}
