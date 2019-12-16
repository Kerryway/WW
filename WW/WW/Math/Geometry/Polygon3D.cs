// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Polygon3D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;

namespace WW.Math.Geometry
{
  [Serializable]
  public class Polygon3D : List<Point3D>
  {
    public Polygon3D()
    {
    }

    public Polygon3D(int capacity)
      : base(capacity)
    {
    }

    public Polygon3D(params Point3D[] points)
      : base((IEnumerable<Point3D>) points)
    {
    }

    public Polygon3D(IEnumerable<Point3D> points)
      : base(points)
    {
    }

    public Polygon3D(Polygon3D polyline)
      : base((IEnumerable<Point3D>) polyline)
    {
    }

    public Bounds3D GetBounds()
    {
      Bounds3D bounds3D = new Bounds3D();
      foreach (Point3D p in (List<Point3D>) this)
        bounds3D.Update(p);
      return bounds3D;
    }

    public Plane3D? GetPlane()
    {
      return Polygon3D.GetPlane((IList<Point3D>) this);
    }

    public Polygon2D GetProjection2D(Matrix4D projectionTransform)
    {
      return Polygon3D.GetProjection2D((IList<Point3D>) this, projectionTransform);
    }

    public Point3D? GetCentroid()
    {
      return Polygon3D.GetCentroid((IList<Point3D>) this);
    }

    public Point3D? GetCentroid(out Plane3D? plane)
    {
      return Polygon3D.GetCentroid((IList<Point3D>) this, out plane);
    }

    public static Plane3D? GetPlane(IList<Point3D> polygon)
    {
      int count = polygon.Count;
      if (count < 3)
        return new Plane3D?();
      Point3D point = polygon[0];
      Vector3D u = polygon[1] - point;
      for (int index = 2; index < count; ++index)
      {
        Vector3D v = polygon[index] - point;
        Vector3D vector3D = Vector3D.CrossProduct(u, v);
        if (!Vector3D.AreApproxEqual(vector3D, Vector3D.Zero))
        {
          vector3D.Normalize();
          return new Plane3D?(new Plane3D(vector3D, point));
        }
      }
      return new Plane3D?();
    }

    public static Polygon2D GetProjection2D(
      IList<Point3D> polygon,
      Matrix4D projectionTransform)
    {
      Polygon2D polygon2D = new Polygon2D(polygon.Count);
      foreach (Point3D point in (IEnumerable<Point3D>) polygon)
        polygon2D.Add(projectionTransform.TransformTo2D(point));
      return polygon2D;
    }

    public static Point3D? GetCentroid(IList<Point3D> polygon)
    {
      Plane3D? plane;
      return Polygon3D.GetCentroid(polygon, out plane);
    }

    public static Point3D? GetCentroid(IList<Point3D> polygon, out Plane3D? plane)
    {
      int count = polygon.Count;
      Point3D point3D1 = polygon[0];
      if (count < 3)
      {
        plane = new Plane3D?();
        switch (count)
        {
          case 0:
            return new Point3D?();
          case 1:
            return new Point3D?(polygon[0]);
          case 2:
            Point3D point3D2 = polygon[0];
            return new Point3D?(new Point3D(0.5 * (point3D1.X + point3D2.X), 0.5 * (point3D1.Y + point3D2.Y), 0.5 * (point3D1.Z + point3D2.Z)));
        }
      }
      plane = Polygon3D.GetPlane(polygon);
      if (!plane.HasValue)
        return new Point3D?();
      Matrix4D matrix4D = Transformation4D.Translation(point3D1.X, point3D1.Y, point3D1.Z) * Transformation4D.GetArbitraryCoordSystem(plane.Value.Normal);
      Matrix4D inverse = matrix4D.GetInverse();
      Point2D point2D = Polygon3D.GetProjection2D(polygon, inverse).GetCentroid().Value;
      return new Point3D?(matrix4D.Transform(new Point3D(point2D.X, point2D.Y, 0.0)));
    }
  }
}
