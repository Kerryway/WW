// Decompiled with JetBrains decompiler
// Type: ns36.Class749
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math;
using WW.Math.Geometry;

namespace ns36
{
  internal static class Class749
  {
    internal static bool IsInside(Point2D p, Polyline3D polyline)
    {
      if (polyline == null)
        return false;
      int num1 = 0;
      Ray2D a = new Ray2D(p, Vector2D.XAxis);
      int num2 = polyline.Count + (polyline.Closed ? 1 : 0);
      int count = polyline.Count;
      Point3D point3D1 = polyline[0];
      for (int index = 1; index < num2; ++index)
      {
        Point3D point3D2 = polyline[index % count];
        Segment2D b = new Segment2D(point3D1.X, point3D1.Y, point3D2.X, point3D2.Y);
        if (Ray2D.Intersects(a, b))
          ++num1;
        point3D1 = point3D2;
      }
      return num1 % 2 == 1;
    }

    internal static bool IsInside(Point2D p, Polyline2D polyline)
    {
      if (polyline == null || polyline.Count < 1)
        return false;
      return (0 + Class749.smethod_0(new Ray2D(p, Vector2D.XAxis), polyline)) % 2 == 1;
    }

    internal static bool IsInside(Point2D p, IEnumerable<Polyline2D> polylines)
    {
      if (polylines == null)
        return false;
      int num = 0;
      Ray2D ray = new Ray2D(p, Vector2D.XAxis);
      foreach (Polyline2D polyline in polylines)
        num += Class749.smethod_0(ray, polyline);
      return num % 2 == 1;
    }

    internal static int smethod_0(Ray2D ray, Polyline2D polyline)
    {
      int num1 = 0;
      int num2 = polyline.Count + (polyline.Closed ? 1 : 0);
      int count = polyline.Count;
      Point2D start = polyline[0];
      for (int index = 1; index < num2; ++index)
      {
        Point2D end = polyline[index % count];
        Segment2D b = new Segment2D(start, end);
        if (Ray2D.Intersects(ray, b))
          ++num1;
        start = end;
      }
      return num1;
    }

    internal static bool IsInside(Point2D p, Polyline4D polyline)
    {
      if (polyline == null)
        return false;
      return (0 + Class749.smethod_1(new Ray2D(p, Vector2D.XAxis), polyline)) % 2 == 1;
    }

    internal static bool IsInside(Point2D p, IEnumerable<Polyline4D> polylines)
    {
      if (polylines == null)
        return false;
      int num = 0;
      Ray2D ray = new Ray2D(p, Vector2D.XAxis);
      foreach (Polyline4D polyline in polylines)
        num += Class749.smethod_1(ray, polyline);
      return num % 2 == 1;
    }

    internal static int smethod_1(Ray2D ray, Polyline4D polyline)
    {
      int num1 = 0;
      int num2 = polyline.Count + (polyline.Closed ? 1 : 0);
      int count = polyline.Count;
      Point2D start = (Point2D) polyline[0];
      for (int index = 1; index < num2; ++index)
      {
        Point2D end = (Point2D) polyline[index % count];
        Segment2D b = new Segment2D(start, end);
        if (Ray2D.Intersects(ray, b))
          ++num1;
        start = end;
      }
      return num1;
    }

    internal static double smethod_2(Polyline4D polyline, Point2D point)
    {
      return System.Math.Sqrt(Class749.smethod_3(polyline, point));
    }

    internal static double smethod_3(Polyline4D polyline, Point2D point)
    {
      int count = polyline.Count;
      switch (count)
      {
        case 0:
          return double.MaxValue;
        case 1:
          return ((Point2D) polyline[0] - point).GetLengthSquared();
        default:
          double num1 = double.MaxValue;
          int num2 = count + (polyline.Closed ? 1 : 0);
          int num3 = count;
          Point2D start = (Point2D) polyline[0];
          for (int index = 1; index < num2; ++index)
          {
            Point2D end = (Point2D) polyline[index % num3];
            double distanceSquared = new Segment2D(start, end).GetDistanceSquared(point);
            if (distanceSquared < num1)
              num1 = distanceSquared;
            start = end;
          }
          return num1;
      }
    }

    internal static double smethod_4(Polyline2D polyline, Point2D point)
    {
      int count = polyline.Count;
      switch (count)
      {
        case 0:
          return double.MaxValue;
        case 1:
          return (polyline[0] - point).GetLengthSquared();
        default:
          double num1 = double.MaxValue;
          int num2 = count + (polyline.Closed ? 1 : 0);
          int num3 = count;
          Point2D start = polyline[0];
          for (int index = 1; index < num2; ++index)
          {
            Point2D end = polyline[index % num3];
            double distanceSquared = new Segment2D(start, end).GetDistanceSquared(point);
            if (distanceSquared < num1)
              num1 = distanceSquared;
            start = end;
          }
          return num1;
      }
    }

    public static bool smethod_5(Matrix4D transform)
    {
      return transform.M00 * transform.M11 - transform.M01 * transform.M10 < 0.0;
    }
  }
}
