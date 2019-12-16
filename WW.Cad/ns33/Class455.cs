// Decompiled with JetBrains decompiler
// Type: ns33.Class455
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns36;
using System;
using System.Collections.Generic;
using WW.Math;
using WW.Math.Geometry;

namespace ns33
{
  internal class Class455 : AbstractClipperBase4D, WW.ICloneable<Interface32>, IClipper4D, IInsideTester4D, Interface31, Interface32
  {
    private Matrix4D matrix4D_0;
    private Matrix4D matrix4D_1;
    private readonly Class455.Class461 class461_0;

    public Class455(Matrix4D clipBoundaryTransform, Polygon2D clipPolygon, bool inverseClip)
    {
      this.matrix4D_0 = clipBoundaryTransform;
      this.class461_0 = new Class455.Class461(clipPolygon, inverseClip);
      bool couldInvert;
      this.matrix4D_1 = clipBoundaryTransform.GetInverse(out couldInvert);
      if (!couldInvert)
        throw new ArgumentException("Non-invertable clipBoundaryTransform!");
    }

    private Class455(Class455 clipper)
    {
      this.matrix4D_0 = clipper.matrix4D_0;
      this.matrix4D_1 = clipper.matrix4D_1;
      this.class461_0 = clipper.class461_0;
    }

    public Matrix4D InverseClipBoundaryTransform
    {
      get
      {
        return this.matrix4D_1;
      }
    }

    public Matrix4D ClipBoundaryTransform
    {
      get
      {
        return this.matrix4D_0;
      }
    }

    public override bool IsInside(Vector4D point)
    {
      return Class455.Contains(this.class461_0, this.matrix4D_1.TransformToPoint2D(point));
    }

    public override InsideTestResult TryIsInside(Bounds3D bounds)
    {
      if (!bounds.Initialized)
        return InsideTestResult.None;
      Bounds2D bounds2D = new Bounds2D();
      Point3D min = bounds.Min;
      Point3D max = bounds.Max;
      bounds2D.Update(this.matrix4D_1.TransformTo2D(min));
      bounds2D.Update(this.matrix4D_1.TransformTo2D(new Point3D(min.X, min.Y, max.Z)));
      bounds2D.Update(this.matrix4D_1.TransformTo2D(new Point3D(min.X, max.X, min.Z)));
      bounds2D.Update(this.matrix4D_1.TransformTo2D(new Point3D(min.X, max.X, max.Z)));
      bounds2D.Update(this.matrix4D_1.TransformTo2D(new Point3D(max.X, min.X, min.Z)));
      bounds2D.Update(this.matrix4D_1.TransformTo2D(new Point3D(max.X, min.X, max.Z)));
      bounds2D.Update(this.matrix4D_1.TransformTo2D(new Point3D(max.X, max.X, min.Z)));
      bounds2D.Update(this.matrix4D_1.TransformTo2D(max));
      if (bounds2D.Overlaps(this.class461_0.bounds2D_0))
        return InsideTestResult.BothSides;
      return !this.class461_0.bool_0 ? InsideTestResult.Outside : InsideTestResult.Inside;
    }

    public override IList<Segment4D> Clip(Segment4D segment)
    {
      Point3D point3D1 = this.matrix4D_1.TransformToPoint3D(segment.Start);
      Point3D point3D2 = this.matrix4D_1.TransformToPoint3D(segment.End);
      Point2D point = (Point2D) point3D1;
      Vector2D vector2D = (Point2D) point3D2 - point;
      bool flag = Class455.Contains(this.class461_0, point);
      if (vector2D == Vector2D.Zero)
      {
        if (!flag)
          return AbstractClipperBase4D.SegmentClippedAway;
        return (IList<Segment4D>) new Segment4D[1]{ segment };
      }
      List<Class455.Class456> class456List = this.class461_0.method_1(point3D1, point3D2);
      if (class456List.Count == 0)
      {
        if (!flag)
          return AbstractClipperBase4D.SegmentClippedAway;
        return (IList<Segment4D>) new Segment4D[1]{ segment };
      }
      class456List.Sort(new Comparison<Class455.Class456>(Class455.Class456.smethod_1));
      Vector4D delta = segment.GetDelta();
      List<Segment4D> segment4DList = new List<Segment4D>();
      double num = 0.0;
      foreach (Class455.Class456 class456 in class456List)
      {
        if (flag)
          segment4DList.Add(new Segment4D(segment.Start + num * delta, segment.Start + class456.double_1 * delta));
        else
          num = class456.double_1;
        flag = !flag;
      }
      if (flag)
        segment4DList.Add(new Segment4D(segment.Start + num * delta, segment.End));
      return (IList<Segment4D>) segment4DList;
    }

    public override IList<Polyline4D> Clip(Polyline4D polyline, bool filled)
    {
      int count = polyline.Count;
      switch (count)
      {
        case 0:
          return AbstractClipperBase4D.PolylinesClippedAway;
        case 1:
          if (!Class455.Contains(this.class461_0, this.matrix4D_1.TransformToPoint2D(polyline[0])))
            return AbstractClipperBase4D.PolylinesClippedAway;
          return (IList<Polyline4D>) new Polyline4D[1]{ polyline };
        default:
          Polyline3D polyline1 = new Polyline3D(polyline.Count, polyline.Closed);
          foreach (Vector4D vector in (List<Vector4D>) polyline)
            polyline1.Add(this.matrix4D_1.TransformToPoint3D(vector));
          Class455.Class462 polylineInfo = new Class455.Class462(polyline1);
          List<Class455.Class456> class456List = this.class461_0.method_0((Class455.Class460) polylineInfo);
          if (class456List.Count == 0)
          {
            if (polyline1.Count == 0)
              return (IList<Polyline4D>) new Polyline4D[1]{ polyline };
            foreach (Point3D point3D in (List<Point3D>) polyline1)
            {
              if (Class455.Contains(this.class461_0, (Point2D) point3D))
                return (IList<Polyline4D>) new Polyline4D[1]{ polyline };
            }
            if (!filled || polyline.Count < 3)
              return AbstractClipperBase4D.PolylinesClippedAway;
            Polygon2D polygon2D = new Polygon2D(polyline1.Count);
            foreach (Point3D point3D in (List<Point3D>) polyline1)
              polygon2D.Add((Point2D) point3D);
            bool flag = false;
            foreach (Point2D p in (List<Point2D>) this.class461_0.polygon2D_0)
            {
              if (polygon2D.IsInside(p))
              {
                flag = true;
                break;
              }
            }
            if (filled && flag)
            {
              Plane3D? plane = Polygon3D.GetPlane((IList<Point3D>) polyline1);
              if (plane.HasValue)
              {
                Plane3D plane3D = plane.Value;
                Polyline4D polyline4D = new Polyline4D(this.class461_0.polygon2D_0.Count, true);
                foreach (Point2D point2D in (List<Point2D>) this.class461_0.polygon2D_0)
                {
                  Point3D? intersection = plane3D.GetIntersection(new Ray3D(point2D.X, point2D.Y, 0.0, 0.0, 0.0, 1.0));
                  if (intersection.HasValue)
                  {
                    polyline4D.Add(this.matrix4D_0.TransformTo4D(intersection.Value));
                  }
                  else
                  {
                    intersection = plane3D.GetIntersection(new Ray3D(point2D.X, point2D.Y, 0.0, 0.0, 0.0, -1.0));
                    if (intersection.HasValue)
                      polyline4D.Add(this.matrix4D_0.TransformTo4D(intersection.Value));
                  }
                }
                return (IList<Polyline4D>) new Polyline4D[1]{ polyline4D };
              }
            }
            return AbstractClipperBase4D.PolylinesClippedAway;
          }
          bool flag1 = polylineInfo.double_0 * this.class461_0.double_0 >= 0.0;
          List<Polyline4D> polyline4DList = new List<Polyline4D>();
          int index1;
          if (!Class455.Contains(this.class461_0, (Point2D) polyline1[0]))
            index1 = 0;
          else if (polyline.Closed)
          {
            index1 = class456List.Count - 1;
          }
          else
          {
            Polyline4D result = new Polyline4D(filled);
            this.method_0(result, 0.0, class456List[0].double_1, polylineInfo);
            polyline4DList.Add(result);
            class456List.RemoveAt(0);
            index1 = 0;
            if (class456List.Count == 0)
              return (IList<Polyline4D>) polyline4DList;
          }
          if (filled)
          {
            while (class456List.Count > 0)
            {
              if (polylineInfo.bool_0)
              {
                class456List.Sort(new Comparison<Class455.Class456>(Class455.Class456.smethod_2));
              }
              else
              {
                class456List.Sort(new Comparison<Class455.Class456>(Class455.Class456.smethod_0));
                if (!flag1)
                  class456List.Reverse();
              }
              for (int index2 = 0; index2 < class456List.Count; ++index2)
              {
                Class455.Class456 class456_1 = class456List[index2];
                Class455.Class456 class456_2 = class456List[(index2 + 1) % class456List.Count];
                class456_1.class456_0 = class456_2;
                class456_2.class456_1 = class456_1;
              }
              class456List.Sort(new Comparison<Class455.Class456>(Class455.Class456.smethod_1));
              for (int index2 = 0; index2 < class456List.Count; ++index2)
              {
                Class455.Class456 class456_1 = class456List[index2];
                Class455.Class456 class456_2 = class456List[(index2 + 1) % class456List.Count];
                class456_1.class456_2 = class456_2;
                class456_2.class456_3 = class456_1;
              }
              Polyline4D result = new Polyline4D(true);
              polyline4DList.Add(result);
              Class455.Class456 class456 = class456List[index1];
              class456List.RemoveAt(index1);
              bool flag2 = index1 > 0;
              index1 = 0;
              Class455.Class456 start = class456;
              do
              {
                Class455.Class456 end = start.class456_2;
                bool flag3;
                if (flag2 || end.double_1 >= start.double_1)
                {
                  double parameter = 0.5 * (start.double_1 + end.double_1);
                  if (flag2)
                  {
                    parameter += 0.5 * (double) count;
                    flag2 = false;
                  }
                  flag3 = Class455.Contains(this.class461_0, (Point2D) Class455.smethod_1(polylineInfo.polyline3D_0, parameter));
                }
                else
                  goto label_72;
label_65:
                if (flag3)
                {
                  this.method_0(result, start.double_1, end.double_1, polylineInfo);
                }
                else
                {
                  end = start.class456_0;
                  if (polylineInfo.bool_0)
                    result.Add(this.matrix4D_0.TransformTo4D(Class455.smethod_1(polylineInfo.polyline3D_0, start.double_1)));
                  else
                    this.method_1(result, start, end, !flag1, polylineInfo);
                }
                class456List.Remove(end);
                if (end.class456_2 != end.class456_3)
                {
                  end.class456_1.class456_0 = end.class456_0;
                  end.class456_0.class456_1 = end.class456_1;
                  end.class456_3.class456_2 = end.class456_2;
                  end.class456_2.class456_3 = end.class456_3;
                  start = end;
                  continue;
                }
                break;
label_72:
                flag3 = false;
                goto label_65;
              }
              while (!object.ReferenceEquals((object) start, (object) class456));
              if (result.Count < 3)
                result.Closed = false;
            }
          }
          else
          {
            bool flag2 = Class455.Contains(this.class461_0, (Point2D) polyline1[polyline1.Count - 1]);
            class456List.Sort(new Comparison<Class455.Class456>(Class455.Class456.smethod_1));
            Class455.Class456 class456_1 = class456List[index1];
            class456List.RemoveAt(index1);
            while (class456List.Count > 0)
            {
              Class455.Class456 class456_2 = class456List[0];
              class456List.RemoveAt(0);
              double parameter = 0.5 * (class456_1.double_1 + class456_2.double_1);
              if (class456_2.double_1 < class456_1.double_1)
                parameter += 0.5 * (double) count;
              if (Class455.Contains(this.class461_0, (Point2D) Class455.smethod_1(polylineInfo.polyline3D_0, parameter)))
              {
                Polyline4D result = new Polyline4D();
                this.method_0(result, class456_1.double_1, class456_2.double_1, polylineInfo);
                polyline4DList.Add(result);
              }
              class456_1 = class456_2;
            }
            if (!polyline.Closed && flag2)
            {
              Polyline4D result = new Polyline4D();
              this.method_0(result, class456_1.double_1, (double) (polyline.Count - 1), polylineInfo);
              polyline4DList.Add(result);
            }
          }
          return (IList<Polyline4D>) polyline4DList;
      }
    }

    public void imethod_0(Matrix4D transform)
    {
      this.matrix4D_0 = transform * this.matrix4D_0;
      bool couldInvert;
      this.matrix4D_1 = this.matrix4D_0.GetInverse(out couldInvert);
      if (!couldInvert)
        throw new ArgumentException("Non-invertable clipBoundaryTransform!");
    }

    public Interface32 Clone()
    {
      return (Interface32) new Class455(this);
    }

    private void method_0(
      Polyline4D result,
      double startParam,
      double endParam,
      Class455.Class462 polylineInfo)
    {
      Polyline3D polyline3D0 = polylineInfo.polyline3D_0;
      int count = polyline3D0.Count;
      int num1 = (int) System.Math.Floor(startParam);
      double parameter1 = startParam - (double) num1;
      int num2 = (int) System.Math.Floor(endParam);
      double parameter2 = endParam - (double) num2;
      if (startParam > endParam)
        num2 += count;
      result.Add(this.matrix4D_0.TransformTo4D(Class455.smethod_0(polyline3D0[num1 % count], polyline3D0[(num1 + 1) % count], parameter1)));
      for (int index = num1 + 1; index <= num2; ++index)
        result.Add(this.matrix4D_0.TransformTo4D(polyline3D0[index % count]));
      if (parameter2 <= 0.0)
        return;
      result.Add(this.matrix4D_0.TransformTo4D(Class455.smethod_0(polyline3D0[num2 % count], polyline3D0[(num2 + 1) % count], parameter2)));
    }

    private void method_1(
      Polyline4D result,
      Class455.Class456 start,
      Class455.Class456 end,
      bool backward,
      Class455.Class462 polylineInfo)
    {
      Polyline3D polyline3D0 = polylineInfo.polyline3D_0;
      Polygon2D polygon2D0 = this.class461_0.polygon2D_0;
      int count = polygon2D0.Count;
      double double0_1 = start.double_0;
      double double0_2 = end.double_0;
      double double1_1 = start.double_1;
      double double1_2 = end.double_1;
      int num1 = (int) System.Math.Floor(double0_1) % count;
      int num2 = (int) System.Math.Floor(double0_2) % count;
      result.Add(this.matrix4D_0.TransformTo4D(Class455.smethod_1(polyline3D0, double1_1)));
      if (backward)
      {
        for (int index = num1; index != num2; index = (index + count - 1) % count)
        {
          Point2D p = polygon2D0[index];
          Point3D point = new Point3D(p.X, p.Y, polylineInfo.method_3(p));
          result.Add(this.matrix4D_0.TransformTo4D(point));
        }
      }
      else
      {
        for (int index = num1; index != num2; index = (index + 1) % count)
        {
          Point2D p = polygon2D0[index];
          Point3D point = new Point3D(p.X, p.Y, polylineInfo.method_3(p));
          result.Add(this.matrix4D_0.TransformTo4D(point));
        }
      }
      if (double0_2 == System.Math.Floor(double0_2))
        return;
      result.Add(this.matrix4D_0.TransformTo4D(Class455.smethod_1(polyline3D0, double1_2)));
    }

    private static Point3D smethod_0(Point3D start, Point3D end, double parameter)
    {
      Vector3D vector3D = end - start;
      return start + parameter * vector3D;
    }

    private static Point3D smethod_1(Polyline3D polyline, double parameter)
    {
      int num = (int) System.Math.Floor(parameter);
      return Class455.smethod_0(polyline[num % polyline.Count], polyline[(num + 1) % polyline.Count], parameter - (double) num);
    }

    private static IList<Class455.Class459> smethod_2(
      Polygon2D poly,
      out Point2D min,
      out Point2D max)
    {
      min = new Point2D(double.MaxValue, double.MaxValue);
      max = new Point2D(double.MinValue, double.MinValue);
      int count = poly.Count;
      if (count <= 0)
        return (IList<Class455.Class459>) new List<Class455.Class459>();
      List<Class455.Class459> class459List = new List<Class455.Class459>(2 * count);
      Point2D point2D1 = poly[0];
      for (int startParameter = count - 1; startParameter >= 0; --startParameter)
      {
        Point2D point2D2 = poly[startParameter];
        if (point2D2.X > max.X)
          max.X = point2D2.X;
        if (point2D2.Y > max.Y)
          max.Y = point2D2.Y;
        if (point2D2.X < min.X)
          min.X = point2D2.X;
        if (point2D2.Y < min.Y)
          min.Y = point2D2.Y;
        Class455.Class458 edge = new Class455.Class458(startParameter, (Point3D) point2D2, (Point3D) point2D1, false);
        if (edge.vector3D_0 != Vector3D.Zero)
        {
          class459List.Add(new Class455.Class459(true, edge));
          class459List.Add(new Class455.Class459(false, edge));
        }
        point2D1 = point2D2;
      }
      return (IList<Class455.Class459>) class459List;
    }

    private static IList<Class455.Class459> smethod_3(
      Polyline3D poly,
      out Point2D min,
      out Point2D max)
    {
      min = new Point2D(double.MaxValue, double.MaxValue);
      max = new Point2D(double.MinValue, double.MinValue);
      int count = poly.Count;
      if (count <= 0)
        return (IList<Class455.Class459>) new List<Class455.Class459>();
      List<Class455.Class459> class459List = new List<Class455.Class459>(2 * count);
      Point3D end;
      int num;
      if (poly.Closed)
      {
        end = poly[0];
        num = poly.Count - 1;
      }
      else
      {
        end = poly[poly.Count - 1];
        num = poly.Count - 2;
        min = max = (Point2D) end;
      }
      for (int startParameter = num; startParameter >= 0; --startParameter)
      {
        Point3D start = poly[startParameter];
        if (start.X > max.X)
          max.X = start.X;
        if (start.Y > max.Y)
          max.Y = start.Y;
        if (start.X < min.X)
          min.X = start.X;
        if (start.Y < min.Y)
          min.Y = start.Y;
        Class455.Class458 edge = new Class455.Class458(startParameter, start, end, true);
        if (edge.vector3D_0 != Vector3D.Zero)
        {
          class459List.Add(new Class455.Class459(true, edge));
          class459List.Add(new Class455.Class459(false, edge));
        }
        end = start;
      }
      return (IList<Class455.Class459>) class459List;
    }

    private static void smethod_4(
      List<Class455.Class459> edgeRefs,
      List<Class455.Class456> intersections)
    {
      edgeRefs.Sort();
      List<Class455.Class458> class458List = new List<Class455.Class458>();
      foreach (Class455.Class459 edgeRef in edgeRefs)
      {
        if (!edgeRef.Insert)
        {
          class458List.Remove(edgeRef.class458_0);
        }
        else
        {
          Class455.Class458 class4580 = edgeRef.class458_0;
          bool bool0 = class4580.bool_0;
          foreach (Class455.Class458 edge2 in class458List)
          {
            if (bool0 ^ edge2.bool_0)
              Class455.smethod_5(class4580, edge2, intersections);
          }
          class458List.Add(class4580);
        }
      }
    }

    private static void smethod_5(
      Class455.Class458 edge1,
      Class455.Class458 edge2,
      List<Class455.Class456> intersections)
    {
      Class455.Class458 class458_1;
      Class455.Class458 class458_2;
      if (edge1.bool_0)
      {
        class458_1 = edge2;
        class458_2 = edge1;
      }
      else
      {
        class458_1 = edge1;
        class458_2 = edge2;
      }
      Vector3D vector3D0_1 = class458_1.vector3D_0;
      Vector3D vector3D0_2 = class458_2.vector3D_0;
      double num1 = 1E-08 * class458_1.double_0 * class458_2.double_0;
      double num2 = vector3D0_1.X * vector3D0_2.Y - vector3D0_1.Y * vector3D0_2.X;
      if (System.Math.Abs(num2) < num1)
      {
        Vector3D vector3D = class458_1.point3D_0 - class458_2.point3D_0;
        if (System.Math.Abs(vector3D.X * vector3D0_2.Y - vector3D.Y * vector3D0_2.X) >= num1)
          return;
        double val1 = class458_2.method_0(class458_1.point3D_0.X, class458_1.point3D_0.Y);
        double val2 = class458_2.method_0(class458_1.point3D_1.X, class458_1.point3D_1.Y);
        double num3 = System.Math.Min(val1, val2);
        if (num3 > 1.0)
          return;
        double num4 = System.Math.Max(val1, val2);
        if (num4 < 0.0)
          return;
        if (num3 < 0.0)
          num3 = 0.0;
        if (num4 > 1.0)
          num4 = 1.0;
        if (num4 - num3 < 1E-08)
        {
          double num5 = 0.5 * (num3 + num4);
          Point2D point2D = class458_2.method_1(num5);
          double clipParam = class458_1.method_0(point2D.X, point2D.Y);
          if (clipParam < 0.0 || clipParam > 1.0)
            return;
          Class455.Class456 class456 = new Class455.Class456(class458_1.int_0, clipParam, class458_2.int_0, num5);
          intersections?.Add(class456);
        }
        else
        {
          if (intersections == null)
            return;
          Point2D point2D = class458_2.method_1(num3);
          double clipParam1 = class458_1.method_0(point2D.X, point2D.Y);
          if (clipParam1 < 0.0 || clipParam1 > 1.0)
            return;
          intersections.Add(new Class455.Class456(class458_1.int_0, clipParam1, class458_2.int_0, num3));
          point2D = class458_2.method_1(num4);
          double clipParam2 = class458_1.method_0(point2D.X, point2D.Y);
          intersections.Add(new Class455.Class456(class458_1.int_0, clipParam2, class458_2.int_0, num4));
        }
      }
      else
      {
        Vector3D vector3D = class458_2.point3D_0 - class458_1.point3D_0;
        double clipParam = (vector3D.X * vector3D0_2.Y - vector3D.Y * vector3D0_2.X) / num2;
        if (clipParam < 0.0 || clipParam > 1.0)
          return;
        double polygonParam = (vector3D.X * vector3D0_1.Y - vector3D.Y * vector3D0_1.X) / num2;
        if (polygonParam < 0.0 || polygonParam > 1.0)
          return;
        Class455.Class456 class456 = new Class455.Class456(class458_1.int_0, clipParam, class458_2.int_0, polygonParam);
        intersections?.Add(class456);
      }
    }

    private static bool smethod_6(Polyline4D polygon)
    {
      for (int index = polygon.Count - 1; index > 0; --index)
      {
        if (polygon[index] == polygon[index - 1])
          polygon.RemoveAt(index);
      }
      return polygon.Count > 1;
    }

    private static bool Contains(Class455.Class461 polyInfo, Point2D point)
    {
      Bounds2D bounds2D0 = polyInfo.bounds2D_0;
      Point2D min = bounds2D0.Min;
      Point2D max = bounds2D0.Max;
      if (min.X > point.X || max.X < point.X || (min.Y > point.Y || max.Y < point.Y))
        return polyInfo.bool_0;
      Polygon2D polygon2D0 = polyInfo.polygon2D_0;
      if (polyInfo.bool_0)
        return !polygon2D0.IsInside(point);
      return polygon2D0.IsInside(point);
    }

    internal class Class456
    {
      public readonly double double_0;
      public readonly double double_1;
      public Class455.Class456 class456_0;
      public Class455.Class456 class456_1;
      public Class455.Class456 class456_2;
      public Class455.Class456 class456_3;

      public Class456(int clipOffset, double clipParam, int polygonOffset, double polygonParam)
      {
        this.double_0 = (double) clipOffset + clipParam;
        this.double_1 = (double) polygonOffset + polygonParam;
      }

      public bool method_0(Class455.Class457 interval)
      {
        if (this.double_1 >= interval.double_0)
          return this.double_1 <= interval.double_1;
        return false;
      }

      public static int smethod_0(Class455.Class456 i1, Class455.Class456 i2)
      {
        return i1.double_0.CompareTo(i2.double_0);
      }

      public static int smethod_1(Class455.Class456 i1, Class455.Class456 i2)
      {
        return i1.double_1.CompareTo(i2.double_1);
      }

      public static int smethod_2(Class455.Class456 i1, Class455.Class456 i2)
      {
        if (System.Math.Abs(i1.double_0 - i2.double_0) >= 1E-08)
          return Class455.Class456.smethod_0(i1, i2);
        return Class455.Class456.smethod_1(i1, i2);
      }

      public override string ToString()
      {
        return string.Format("ClipParam = {0}, PolygonParam = {1}", (object) this.double_0.ToString("R"), (object) this.double_1.ToString("R"));
      }
    }

    internal class Class457
    {
      public readonly double double_0;
      public readonly double double_1;

      private Class457(double min, double max)
      {
        this.double_0 = min;
        this.double_1 = max;
      }

      public Class457()
        : this(0.0, 1.0)
      {
      }

      public bool method_0()
      {
        return this.double_0 < this.double_1;
      }

      public Class455.Class457 method_1(double newMin)
      {
        return new Class455.Class457(System.Math.Min(newMin, this.double_1), this.double_1);
      }

      public Class455.Class457 method_2(double newMax)
      {
        return new Class455.Class457(this.double_0, System.Math.Max(this.double_0, newMax));
      }

      public Class455.Class457 method_3(Class455.Class457 other)
      {
        if (other.double_1 < this.double_0 || other.double_0 > this.double_1)
          return (Class455.Class457) null;
        if (other.double_0 <= this.double_0 && other.double_1 >= this.double_1)
          return this;
        return new Class455.Class457(System.Math.Max(this.double_0, other.double_0), System.Math.Min(this.double_1, other.double_1));
      }
    }

    internal class Class458
    {
      public readonly int int_0;
      public readonly Point3D point3D_0;
      public readonly Point3D point3D_1;
      public readonly Vector3D vector3D_0;
      public readonly double double_0;
      public readonly bool bool_0;

      public Class458(int startParameter, Point3D start, Point3D end, bool fromPoly)
      {
        this.int_0 = startParameter;
        this.point3D_0 = start;
        this.point3D_1 = end;
        this.vector3D_0 = end - start;
        this.double_0 = System.Math.Sqrt(this.vector3D_0.X * this.vector3D_0.X + this.vector3D_0.Y * this.vector3D_0.Y);
        this.bool_0 = fromPoly;
      }

      public double method_0(double px, double py)
      {
        if (System.Math.Abs(this.vector3D_0.X) <= System.Math.Abs(this.vector3D_0.Y))
          return (py - this.point3D_0.Y) / this.vector3D_0.Y;
        return (px - this.point3D_0.X) / this.vector3D_0.X;
      }

      public Point2D method_1(double p)
      {
        return new Point2D(this.point3D_0.X + p * this.vector3D_0.X, this.point3D_0.Y + p * this.vector3D_0.Y);
      }

      public override string ToString()
      {
        return string.Format("{0}: ({1}) - ({2})", this.bool_0 ? (object) "P" : (object) "C", (object) this.point3D_0, (object) this.point3D_1);
      }
    }

    internal class Class459 : IComparable<Class455.Class459>
    {
      private readonly bool bool_0;
      public readonly Class455.Class458 class458_0;
      private readonly int int_0;

      public Class459(bool fromStart, Class455.Class458 edge)
      {
        this.bool_0 = fromStart;
        this.class458_0 = edge;
        this.int_0 = edge.point3D_0.Y.CompareTo(edge.point3D_1.Y);
        if (this.int_0 == 0)
          this.int_0 = edge.point3D_0.X.CompareTo(edge.point3D_1.X);
        if (fromStart)
          return;
        this.int_0 = -this.int_0;
      }

      private double X
      {
        get
        {
          if (!this.bool_0)
            return this.class458_0.point3D_1.X;
          return this.class458_0.point3D_0.X;
        }
      }

      private double Y
      {
        get
        {
          if (!this.bool_0)
            return this.class458_0.point3D_1.Y;
          return this.class458_0.point3D_0.Y;
        }
      }

      private double CompareAngle
      {
        get
        {
          return System.Math.Atan2(-this.class458_0.vector3D_0.Y, this.class458_0.vector3D_0.X);
        }
      }

      public bool Insert
      {
        get
        {
          return this.int_0 < 0;
        }
      }

      public int CompareTo(Class455.Class459 other)
      {
        int num = this.Y.CompareTo(other.Y);
        if (num == 0)
        {
          num = this.X.CompareTo(other.X);
          if (num == 0)
          {
            num = this.Insert ? (other.Insert ? 0 : 1) : (other.Insert ? -1 : 0);
            if (num == 0)
            {
              num = this.CompareAngle.CompareTo(other.CompareAngle);
              if (num == 0)
              {
                if (!this.class458_0.bool_0)
                  return !other.class458_0.bool_0 ? 0 : -1;
                return !other.class458_0.bool_0 ? 1 : 0;
              }
            }
          }
        }
        return num;
      }

      public override string ToString()
      {
        return string.Format("{0}, Insert: {1}", (object) this.class458_0, (object) this.Insert);
      }
    }

    internal abstract class Class460
    {
      protected IList<Class455.Class459> ilist_0;
      protected Point2D point2D_0;
      protected Point2D point2D_1;
      public double double_0;

      public List<Class455.Class456> method_0(Class455.Class460 info)
      {
        List<Class455.Class456> intersections = new List<Class455.Class456>();
        if (info.point2D_0.X < this.point2D_1.X && info.point2D_1.X > this.point2D_0.X && (info.point2D_0.Y < this.point2D_1.Y && info.point2D_1.Y > this.point2D_0.Y))
        {
          List<Class455.Class459> edgeRefs = new List<Class455.Class459>(this.ilist_0.Count + info.ilist_0.Count);
          edgeRefs.AddRange((IEnumerable<Class455.Class459>) this.ilist_0);
          edgeRefs.AddRange((IEnumerable<Class455.Class459>) info.ilist_0);
          Class455.smethod_4(edgeRefs, intersections);
        }
        return intersections;
      }

      public List<Class455.Class456> method_1(Point3D start, Point3D end)
      {
        double x1;
        double x2;
        if (start.X < end.X)
        {
          x1 = start.X;
          x2 = end.X;
        }
        else
        {
          x1 = end.X;
          x2 = start.X;
        }
        double y1;
        double y2;
        if (start.Y < end.Y)
        {
          y1 = start.Y;
          y2 = end.Y;
        }
        else
        {
          y1 = end.Y;
          y2 = start.Y;
        }
        List<Class455.Class456> intersections = new List<Class455.Class456>();
        if (x1 < this.point2D_1.X && x2 > this.point2D_0.X && (y1 < this.point2D_1.Y && y2 > this.point2D_0.Y))
        {
          List<Class455.Class459> edgeRefs = new List<Class455.Class459>(this.ilist_0.Count + 2);
          edgeRefs.AddRange((IEnumerable<Class455.Class459>) this.ilist_0);
          Class455.Class458 edge = new Class455.Class458(0, start, end, true);
          edgeRefs.Add(new Class455.Class459(true, edge));
          edgeRefs.Add(new Class455.Class459(false, edge));
          Class455.smethod_4(edgeRefs, intersections);
        }
        return intersections;
      }
    }

    private class Class461 : Class455.Class460
    {
      public readonly Polygon2D polygon2D_0;
      public readonly Bounds2D bounds2D_0;
      public readonly bool bool_0;

      public Class461(Polygon2D polygon, bool inverseClip)
      {
        this.polygon2D_0 = polygon;
        this.ilist_0 = Class455.smethod_2(polygon, out this.point2D_0, out this.point2D_1);
        this.double_0 = polygon.GetArea();
        this.bounds2D_0 = polygon.GetBounds();
        this.bool_0 = inverseClip;
      }
    }

    internal class Class462 : Class455.Class460
    {
      public readonly Polyline3D polyline3D_0;
      private readonly double double_1;
      private readonly double double_2;
      private readonly double double_3;
      public readonly bool bool_0;

      public Class462(Polyline3D polyline)
      {
        this.polyline3D_0 = polyline;
        this.ilist_0 = Class455.smethod_3(polyline, out this.point2D_0, out this.point2D_1);
        this.double_0 = 0.0;
        int count = polyline.Count;
        List<Point3D> point3DList = new List<Point3D>(3);
        if (count > 0)
        {
          Point3D point3D1 = polyline[count - 1];
          point3DList.Add(point3D1);
          if (count == 2)
          {
            Point3D point3D2 = polyline[0];
            if (point3D2.X != point3D1.X || point3D2.Y != point3D1.Y)
              point3DList.Add(point3D2);
          }
          else
          {
            Point3D point3D2 = point3D1;
            Vector2D? nullable1 = new Vector2D?();
            Vector2D? nullable2 = new Vector2D?();
            for (int index = 0; index < count; ++index)
            {
              Point3D point3D3 = polyline[index];
              this.double_0 += point3D2.X * point3D3.Y - point3D3.X * point3D2.Y;
              Vector2D vector2D = (Vector2D) (point3D3 - point3D1);
              double length = vector2D.GetLength();
              if (length > 0.0)
              {
                Vector2D v = vector2D / length;
                if (!nullable1.HasValue)
                {
                  nullable1 = new Vector2D?(v);
                  point3DList.Add(point3D3);
                }
                else if (!nullable2.HasValue && System.Math.Abs(Vector2D.CrossProduct(nullable1.Value, v)) > 1E-06)
                {
                  nullable2 = new Vector2D?(v);
                  point3DList.Add(point3D3);
                }
              }
              point3D2 = point3D3;
            }
            this.double_0 *= 0.5;
          }
          if (point3DList.Count > 2)
          {
            Vector3D vector3D1 = point3DList[1] - point3DList[0];
            Vector3D vector3D2 = point3DList[2] - point3DList[0];
            double num = vector3D2.X * vector3D1.Y - vector3D1.X * vector3D2.Y;
            this.double_1 = (vector3D2.Z * vector3D1.Y - vector3D1.Z * vector3D2.Y) / num;
            this.double_2 = (vector3D1.Z * vector3D2.X - vector3D2.Z * vector3D1.X) / num;
          }
          else if (point3DList.Count == 2)
          {
            Vector3D vector3D = point3DList[1] - point3DList[0];
            if (System.Math.Abs(vector3D.X) >= System.Math.Abs(vector3D.Y))
            {
              this.double_1 = vector3D.Z / vector3D.X;
              this.double_2 = 0.0;
            }
            else
            {
              this.double_1 = 0.0;
              this.double_2 = vector3D.Z / vector3D.Y;
            }
          }
          else
          {
            double num = 0.0;
            this.double_2 = 0.0;
            this.double_1 = num;
          }
          this.double_3 = point3D1.Z - this.double_1 * point3D1.X - this.double_2 * point3D1.Y;
        }
        else
        {
          double num1 = 0.0;
          this.double_2 = 0.0;
          double num2 = num1;
          double num3 = 0.0;
          this.double_1 = num2;
          this.double_3 = num3;
        }
        this.bool_0 = this.double_0 == 0.0;
      }

      public double method_2(double x, double y)
      {
        return this.double_1 * x + this.double_2 * y + this.double_3;
      }

      public double method_3(Point2D p)
      {
        return this.method_2(p.X, p.Y);
      }
    }
  }
}
