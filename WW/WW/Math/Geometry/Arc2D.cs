// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Arc2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.Globalization;

namespace WW.Math.Geometry
{
  [Serializable]
  public class Arc2D : IShape2D
  {
    private Point2D center;
    private double radius;
    private double startAngle;
    private double endAngle;

    public Arc2D(Point2D center, double radius, double startAngle, double endAngle)
    {
      this.center = center;
      this.radius = radius;
      this.startAngle = startAngle;
      this.endAngle = endAngle;
    }

    public Arc2D(
      double centerX,
      double centerY,
      double radius,
      double startAngle,
      double endAngle)
    {
      this.center = new Point2D(centerX, centerY);
      this.radius = radius;
      this.startAngle = startAngle;
      this.endAngle = endAngle;
    }

    public Point2D Center
    {
      get
      {
        return this.center;
      }
      set
      {
        this.center = value;
      }
    }

    public double Radius
    {
      get
      {
        return this.radius;
      }
      set
      {
        this.radius = value;
      }
    }

    public double EndAngle
    {
      get
      {
        return this.endAngle;
      }
      set
      {
        this.endAngle = value;
      }
    }

    public double StartAngle
    {
      get
      {
        return this.startAngle;
      }
      set
      {
        this.startAngle = value;
      }
    }

    public double IncludedAngle
    {
      get
      {
        double endAngle = this.endAngle;
        while (endAngle < this.startAngle)
          endAngle += 2.0 * System.Math.PI;
        return endAngle - this.startAngle;
      }
    }

    public Point2D[] GetIntersections(Segment2D segment)
    {
      return this.GetIntersections(segment, 8.88178419700125E-16);
    }

    public Point2D[] GetIntersections(Segment2D segment, double precision)
    {
      Vector2D delta = segment.GetDelta();
      double lengthSquared = delta.GetLengthSquared();
      Vector2D center = (Vector2D) this.center;
      Point2D point2D1 = segment.Start - center;
      Point2D point2D2 = point2D1 + delta;
      double num1 = point2D1.X * point2D2.Y - point2D2.X * point2D1.Y;
      double num2 = this.radius * this.radius * lengthSquared - num1 * num1;
      Point2D[] point2DArray = (Point2D[]) null;
      if (MathUtil.AreApproxEqual(0.0, num2, precision))
      {
        double num3 = num1 * delta.Y;
        double num4 = -num1 * delta.X;
        double num5 = 1.0 / lengthSquared;
        Point2D point = new Point2D(num3 * num5, num4 * num5) + center;
        if (segment.ContainsProjection(point, precision) && this.ContainsAngleProjection(point, precision))
          point2DArray = new Point2D[1]{ point };
      }
      else if (num2 > 0.0)
      {
        double num3 = delta.Y < 0.0 ? -1.0 : 1.0;
        double num4 = num1 * delta.Y;
        double num5 = -num1 * delta.X;
        double num6 = System.Math.Sqrt(num2);
        double num7 = num3 * delta.X * num6;
        double num8 = System.Math.Abs(delta.Y) * num6;
        List<Point2D> point2DList = new List<Point2D>(2);
        double num9 = 1.0 / lengthSquared;
        Point2D point1 = new Point2D((num4 + num7) * num9, (num5 + num8) * num9) + center;
        if (segment.ContainsProjection(point1, precision) && this.ContainsAngleProjection(point1, precision))
          point2DList.Add(point1);
        Point2D point2 = new Point2D((num4 - num7) * num9, (num5 - num8) * num9) + center;
        if (segment.ContainsProjection(point2, precision) && this.ContainsAngleProjection(point2, precision))
          point2DList.Add(point2);
        if (point2DList.Count > 0)
          point2DArray = point2DList.ToArray();
      }
      return point2DArray;
    }

    public Point2D[] GetIntersections(Line2D line)
    {
      return this.GetIntersections(line, 8.88178419700125E-16);
    }

    public Point2D[] GetIntersections(Line2D line, double precision)
    {
      Vector2D direction = line.Direction;
      double lengthSquared = direction.GetLengthSquared();
      Vector2D center = (Vector2D) this.center;
      Point2D point2D1 = line.Origin - center;
      Point2D point2D2 = point2D1 + direction;
      double num1 = point2D1.X * point2D2.Y - point2D2.X * point2D1.Y;
      double num2 = this.radius * this.radius * lengthSquared - num1 * num1;
      Point2D[] point2DArray = (Point2D[]) null;
      if (MathUtil.AreApproxEqual(0.0, num2, precision))
      {
        double num3 = num1 * direction.Y;
        double num4 = -num1 * direction.X;
        double num5 = 1.0 / lengthSquared;
        Point2D point = new Point2D(num3 * num5, num4 * num5) + center;
        if (this.ContainsAngleProjection(point, precision))
          point2DArray = new Point2D[1]{ point };
      }
      else if (num2 > 0.0)
      {
        double num3 = direction.Y < 0.0 ? -1.0 : 1.0;
        double num4 = num1 * direction.Y;
        double num5 = -num1 * direction.X;
        double num6 = System.Math.Sqrt(num2);
        double num7 = num3 * direction.X * num6;
        double num8 = System.Math.Abs(direction.Y) * num6;
        List<Point2D> point2DList = new List<Point2D>(2);
        double num9 = 1.0 / lengthSquared;
        Point2D point1 = new Point2D((num4 + num7) * num9, (num5 + num8) * num9) + center;
        if (this.ContainsAngleProjection(point1, precision))
          point2DList.Add(point1);
        Point2D point2 = new Point2D((num4 - num7) * num9, (num5 - num8) * num9) + center;
        if (this.ContainsAngleProjection(point2, precision))
          point2DList.Add(point2);
        if (point2DList.Count > 0)
          point2DArray = point2DList.ToArray();
      }
      return point2DArray;
    }

    public Point2D[] GetIntersections(Ray2D ray, out bool isTangent)
    {
      return this.GetIntersections(ray, 8.88178419700125E-16, out isTangent);
    }

    public Point2D[] GetIntersections(Ray2D ray, double precision, out bool isTangent)
    {
      isTangent = false;
      Vector2D direction = ray.Direction;
      double lengthSquared = direction.GetLengthSquared();
      Vector2D center = (Vector2D) this.center;
      Point2D point2D1 = ray.Origin - center;
      Point2D point2D2 = point2D1 + direction;
      double num1 = point2D1.X * point2D2.Y - point2D2.X * point2D1.Y;
      double num2 = this.radius * this.radius * lengthSquared - num1 * num1;
      Point2D[] point2DArray = (Point2D[]) null;
      if (MathUtil.AreApproxEqual(0.0, num2, precision))
      {
        double num3 = num1 * direction.Y;
        double num4 = -num1 * direction.X;
        double num5 = 1.0 / lengthSquared;
        Point2D point = new Point2D(num3 * num5, num4 * num5) + center;
        if (Vector2D.DotProduct(point - ray.Origin, direction) >= 0.0 && this.ContainsAngleProjection(point, precision))
        {
          point2DArray = new Point2D[1]{ point };
          isTangent = true;
        }
      }
      else if (num2 > 0.0)
      {
        double num3 = direction.Y < 0.0 ? -1.0 : 1.0;
        double num4 = num1 * direction.Y;
        double num5 = -num1 * direction.X;
        double num6 = System.Math.Sqrt(num2);
        double num7 = num3 * direction.X * num6;
        double num8 = System.Math.Abs(direction.Y) * num6;
        List<Point2D> point2DList = new List<Point2D>(2);
        double num9 = 1.0 / lengthSquared;
        Point2D point1 = new Point2D((num4 + num7) * num9, (num5 + num8) * num9) + center;
        if (Vector2D.DotProduct(point1 - ray.Origin, direction) >= 0.0 && this.ContainsAngleProjection(point1, precision))
          point2DList.Add(point1);
        Point2D point2 = new Point2D((num4 - num7) * num9, (num5 - num8) * num9) + center;
        if (Vector2D.DotProduct(point2 - ray.Origin, direction) >= 0.0 && this.ContainsAngleProjection(point2, precision))
          point2DList.Add(point2);
        if (point2DList.Count > 0)
          point2DArray = point2DList.ToArray();
      }
      return point2DArray;
    }

    public static bool GetIntersections(
      Arc2D arc1,
      Arc2D arc2,
      out Point2D[] intersections,
      out Arc2D[] overlappingArcs)
    {
      return Arc2D.GetIntersections(arc1, arc2, 8.88178419700125E-16, out intersections, out overlappingArcs);
    }

    public static bool GetIntersections(
      Arc2D arc1,
      Arc2D arc2,
      double precision,
      out Point2D[] intersections,
      out Arc2D[] overlappingArcs)
    {
      intersections = (Point2D[]) null;
      overlappingArcs = (Arc2D[]) null;
      Vector2D vector2D1 = arc2.center - arc1.center;
      double length = vector2D1.GetLength();
      if (System.Math.Abs(length) <= precision)
      {
        if (MathUtil.AreApproxEqual(arc1.radius, arc2.radius, precision))
          Arc2D.smethod_0(arc1, arc2, precision, out overlappingArcs);
      }
      else
      {
        Vector2D vector2D2 = vector2D1 / length;
        double num1 = length;
        double num2 = num1 * num1;
        double num3 = arc1.radius * arc1.radius;
        double num4 = arc2.radius * arc2.radius;
        double num5 = num2 - num4 + num3;
        double d = (4.0 * num2 * num3 - num5 * num5) / (4.0 * num2);
        if (d >= -precision)
        {
          double num6 = num5 / (2.0 * num1);
          if (d <= precision)
          {
            Point2D point = arc1.center + num6 * vector2D2;
            if (arc1.ContainsAngleProjection(point) && arc2.ContainsAngleProjection(point))
              intersections = new Point2D[1]{ point };
          }
          else
          {
            double a = System.Math.Sqrt(d);
            if (MathUtil.AreApproxEqual(a, 0.0, precision))
            {
              Point2D point = arc1.center + num6 * vector2D2;
              if (arc1.ContainsAngleProjection(point) && arc2.ContainsAngleProjection(point))
                intersections = new Point2D[1]{ point };
            }
            else
            {
              Vector2D vector2D3 = new Vector2D(vector2D2.Y, -vector2D2.X);
              List<Point2D> point2DList = new List<Point2D>(2);
              Point2D point1 = arc1.center + num6 * vector2D2 + a * vector2D3;
              if (arc1.ContainsAngleProjection(point1) && arc2.ContainsAngleProjection(point1))
                point2DList.Add(point1);
              Point2D point2 = arc1.center + num6 * vector2D2 - a * vector2D3;
              if (arc1.ContainsAngleProjection(point2) && arc2.ContainsAngleProjection(point2))
                point2DList.Add(point2);
              if (point2DList.Count > 0)
                intersections = point2DList.ToArray();
            }
          }
        }
      }
      if (intersections == null)
        return overlappingArcs != null;
      return true;
    }

    public static void GetIntersections(
      Circle2D circle,
      Arc2D arc,
      out Point2D[] intersections,
      out bool overlap)
    {
      Arc2D.GetIntersections(circle, arc, 8.88178419700125E-16, out intersections, out overlap);
    }

    public static void GetIntersections(
      Circle2D circle,
      Arc2D arc,
      double precision,
      out Point2D[] intersections,
      out bool overlap)
    {
      intersections = (Point2D[]) null;
      overlap = false;
      Vector2D vector2D1 = arc.center - circle.Center;
      double length = vector2D1.GetLength();
      if (System.Math.Abs(length) <= precision)
      {
        if (!MathUtil.AreApproxEqual(circle.Radius, arc.radius, precision))
          return;
        overlap = true;
      }
      else
      {
        Vector2D vector2D2 = vector2D1 / length;
        double num1 = length;
        double num2 = num1 * num1;
        double num3 = circle.Radius * circle.Radius;
        double num4 = arc.radius * arc.radius;
        double num5 = num2 - num4 + num3;
        double d = (4.0 * num2 * num3 - num5 * num5) / (4.0 * num2);
        if (d < -precision)
          return;
        double num6 = num5 / (2.0 * num1);
        if (d <= precision)
        {
          Point2D point = circle.Center + num6 * vector2D2;
          if (!arc.ContainsAngleProjection(point))
            return;
          intersections = new Point2D[1]{ point };
        }
        else
        {
          double a = System.Math.Sqrt(d);
          if (MathUtil.AreApproxEqual(a, 0.0, precision))
          {
            Point2D point = circle.Center + num6 * vector2D2;
            if (!arc.ContainsAngleProjection(point))
              return;
            intersections = new Point2D[1]{ point };
          }
          else
          {
            Vector2D vector2D3 = new Vector2D(vector2D2.Y, -vector2D2.X);
            List<Point2D> point2DList = new List<Point2D>(2);
            Point2D point1 = circle.Center + num6 * vector2D2 + a * vector2D3;
            if (arc.ContainsAngleProjection(point1))
              point2DList.Add(point1);
            Point2D point2 = circle.Center + num6 * vector2D2 - a * vector2D3;
            if (arc.ContainsAngleProjection(point2))
              point2DList.Add(point2);
            if (point2DList.Count <= 0)
              return;
            intersections = point2DList.ToArray();
          }
        }
      }
    }

    public bool ContainsAngleProjection(Point2D point)
    {
      return this.ContainsAngleProjection(point, 8.88178419700125E-16);
    }

    public bool ContainsAngleProjection(Point2D point, double precision)
    {
      Vector2D vector2D = point - this.center;
      return this.ContainsAngle(System.Math.Atan2(vector2D.Y, vector2D.X), precision);
    }

    public bool ContainsAngle(double angle)
    {
      return this.ContainsAngle(angle, 8.88178419700125E-16);
    }

    public bool ContainsAngle(double angle, double precision)
    {
      angle = MathUtil.NormalizeAngleTwoPi(angle);
      double num1 = MathUtil.NormalizeAngleTwoPi(this.startAngle);
      double num2 = MathUtil.NormalizeAngleTwoPi(this.endAngle);
      return num1 > num2 ? angle >= 0.0 && angle <= num2 + precision || angle >= num1 - precision && angle <= 2.0 * System.Math.PI : angle >= num1 - precision && angle <= num2 + precision;
    }

    public Point2D GetPointAtAngle(double angle)
    {
      return new Point2D(this.center.X + this.radius * System.Math.Cos(angle), this.center.Y + this.radius * System.Math.Sin(angle));
    }

    public static Point2D GetPointAtAngle(Point2D center, double radius, double angle)
    {
      return new Point2D(center.X + radius * System.Math.Cos(angle), center.Y + radius * System.Math.Sin(angle));
    }

    public double GetProjection(Point2D point)
    {
      Vector2D vector2D = point - this.center;
      return System.Math.Atan2(vector2D.Y, vector2D.X);
    }

    public Point2D GetStartPoint()
    {
      return this.GetPointAtAngle(this.startAngle);
    }

    public Point2D GetEndPoint()
    {
      return this.GetPointAtAngle(this.endAngle);
    }

    public override string ToString()
    {
      return string.Format("center: {0}, radius: {1}, start angle: {2}, end angle: {3}", (object) this.center.ToString(), (object) this.radius.ToString((IFormatProvider) CultureInfo.InvariantCulture), (object) this.startAngle.ToString((IFormatProvider) CultureInfo.InvariantCulture), (object) this.endAngle.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    }

    public ISegment2DIterator CreateIterator()
    {
      return (ISegment2DIterator) new Arc2D.Class92(this);
    }

    public void AddToBounds(Bounds2D bounds)
    {
      ShapeTool.AddToBounds(bounds, this.CreateIterator());
    }

    public bool HasSegments
    {
      get
      {
        return true;
      }
    }

    private static void smethod_0(
      Arc2D arc1,
      Arc2D arc2,
      double precision,
      out Arc2D[] overlappingArcs)
    {
      overlappingArcs = (Arc2D[]) null;
      double num1 = MathUtil.NormalizeAngleTwoPi(arc1.startAngle);
      double num2 = MathUtil.NormalizeAngleTwoPi(arc1.endAngle);
      double num3 = MathUtil.NormalizeAngleTwoPi(arc2.startAngle);
      double num4 = MathUtil.NormalizeAngleTwoPi(arc2.endAngle);
      bool flag1 = false;
      if (num1 > num2)
        flag1 = true;
      bool flag2 = false;
      if (num3 > num4)
        flag2 = true;
      if (flag1)
      {
        if (flag2)
        {
          List<Arc2D> arc2DList = new List<Arc2D>(2);
          arc2DList.Add(new Arc2D(arc1.center, arc1.radius, System.Math.Max(num1, num3), System.Math.Min(num2, num4)));
          double startAngle = System.Math.Min(num1, num3);
          double endAngle = System.Math.Max(num2, num4);
          if (startAngle < endAngle - precision)
            arc2DList.Add(new Arc2D(arc1.center, arc1.radius, startAngle, endAngle));
          if (arc2DList.Count <= 0)
            return;
          overlappingArcs = arc2DList.ToArray();
        }
        else
        {
          List<Arc2D> arc2DList = new List<Arc2D>(2);
          if (num3 < num2 - precision)
            arc2DList.Add(new Arc2D(arc1.center, arc1.radius, num3, System.Math.Min(num2, num4)));
          if (num4 > num1 + precision)
            arc2DList.Add(new Arc2D(arc1.center, arc1.radius, System.Math.Max(num1, num3), num4));
          if (arc2DList.Count <= 0)
            return;
          overlappingArcs = arc2DList.ToArray();
        }
      }
      else if (flag2)
      {
        List<Arc2D> arc2DList = new List<Arc2D>(2);
        if (num1 < num4 - precision)
          arc2DList.Add(new Arc2D(arc1.center, arc1.radius, num1, System.Math.Min(num2, num4)));
        if (num2 > num3 + precision)
          arc2DList.Add(new Arc2D(arc1.center, arc1.radius, System.Math.Max(num1, num3), num2));
        if (arc2DList.Count <= 0)
          return;
        overlappingArcs = arc2DList.ToArray();
      }
      else
      {
        double startAngle = System.Math.Max(num1, num3);
        double endAngle = System.Math.Min(num2, num4);
        if (startAngle >= endAngle - precision)
          return;
        overlappingArcs = new Arc2D[1]
        {
          new Arc2D(arc1.center, arc1.radius, startAngle, endAngle)
        };
      }
    }

    private class Class92 : ISegment2DIterator
    {
      private int int_0 = -1;
      private readonly Point2D[] point2D_0;

      public Class92(Arc2D arc)
      {
        double num1 = arc.endAngle - arc.startAngle;
        if (num1 < 0.0 || num1 > 2.0 * System.Math.PI)
        {
          double num2 = System.Math.Floor(num1 / (2.0 * System.Math.PI));
          num1 -= 2.0 * num2 * System.Math.PI;
        }
        int num3 = (int) System.Math.Ceiling(2.0 * num1 / System.Math.PI) + 1;
        if (num3 >= 5)
        {
          num3 = 4;
          num1 = 2.0 * System.Math.PI;
        }
        double num4 = num1 / (double) num3;
        this.point2D_0 = new Point2D[1 + 3 * num3];
        double startAngle = arc.StartAngle;
        Vector2D u = arc.Radius * new Vector2D(System.Math.Cos(startAngle), System.Math.Sin(startAngle));
        this.point2D_0[0] = arc.Center + u;
        int num5 = 0;
        for (int index = 0; index < num3; ++index)
        {
          startAngle += num4;
          Vector2D v = arc.Radius * new Vector2D(System.Math.Cos(startAngle), System.Math.Sin(startAngle));
          this.point2D_0[num5 + 3] = arc.Center + v;
          double lengthSquared = u.GetLengthSquared();
          double num2 = lengthSquared + Vector2D.DotProduct(u, v);
          double num6 = Vector2D.CrossProduct(u, v);
          double num7 = 4.0 / 3.0 * (System.Math.Sqrt(2.0 * lengthSquared * num2) - num2) / num6;
          this.point2D_0[num5 + 1] = new Point2D(arc.Center.X + u.X - num7 * u.Y, arc.Center.Y + u.Y + num7 * u.X);
          num5 += 3;
          this.point2D_0[num5 - 1] = new Point2D(arc.Center.X + v.X - num7 * v.Y, arc.Center.Y + v.Y + num7 * v.X);
          u = v;
        }
      }

      public bool MoveNext()
      {
        if (this.int_0 > this.point2D_0.Length - 5)
          return false;
        if (this.int_0 <= 0)
          ++this.int_0;
        else
          this.int_0 += 3;
        return true;
      }

      public SegmentType CurrentType
      {
        get
        {
          return this.int_0 != 0 ? SegmentType.CubicTo : SegmentType.MoveTo;
        }
      }

      public SegmentType Current(Point2D[] points, int offset)
      {
        if (this.int_0 == 0)
        {
          points[offset] = this.point2D_0[0];
          return SegmentType.MoveTo;
        }
        Array.Copy((Array) this.point2D_0, this.int_0, (Array) points, offset, 3);
        return SegmentType.CubicTo;
      }

      public int TotalSegmentCount
      {
        get
        {
          return this.point2D_0.Length / 3 + 1;
        }
      }

      public int TotalPointCount
      {
        get
        {
          return this.point2D_0.Length;
        }
      }
    }
  }
}
