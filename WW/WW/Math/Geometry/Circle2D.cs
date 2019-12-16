// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Circle2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.Globalization;

namespace WW.Math.Geometry
{
  [Serializable]
  public class Circle2D : IShape2D
  {
    private Point2D center;
    private double radius;

    public Circle2D(Point2D center, double radius)
    {
      this.center = center;
      this.radius = radius;
    }

    public Circle2D(double centerX, double centerY, double radius)
    {
      this.center = new Point2D(centerX, centerY);
      this.radius = radius;
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

    public Point2D[] GetIntersections(Line2D line)
    {
      return this.GetIntersections(line, 8.88178419700125E-16);
    }

    public Point2D[] GetIntersections(Line2D line, double precision)
    {
      return Circle2D.GetIntersections(this, line, precision);
    }

    public static Point2D[] GetIntersections(Circle2D circle, Line2D line)
    {
      return Circle2D.GetIntersections(circle, line, 8.88178419700125E-16);
    }

    public static Point2D[] GetIntersections(Circle2D circle, Line2D line, double precision)
    {
      Vector2D direction = line.Direction;
      double lengthSquared = direction.GetLengthSquared();
      Vector2D center = (Vector2D) circle.center;
      Point2D point2D1 = line.Origin - center;
      Point2D point2D2 = point2D1 + direction;
      double num1 = point2D1.X * point2D2.Y - point2D2.X * point2D1.Y;
      double num2 = circle.radius * circle.radius * lengthSquared - num1 * num1;
      Point2D[] point2DArray = (Point2D[]) null;
      if (MathUtil.AreApproxEqual(0.0, num2, precision * precision))
      {
        double num3 = num1 * direction.Y;
        double num4 = -num1 * direction.X;
        point2DArray = new Point2D[1]
        {
          new Point2D(num3 / lengthSquared, num4 / lengthSquared) + center
        };
      }
      else if (num2 > 0.0)
      {
        double num3 = direction.Y < 0.0 ? -1.0 : 1.0;
        double num4 = num1 * direction.Y;
        double num5 = -num1 * direction.X;
        double num6 = System.Math.Sqrt(num2);
        double num7 = num3 * direction.X * num6;
        double num8 = System.Math.Abs(direction.Y) * num6;
        point2DArray = new Point2D[2]
        {
          new Point2D((num4 + num7) / lengthSquared, (num5 + num8) / lengthSquared) + center,
          new Point2D((num4 - num7) / lengthSquared, (num5 - num8) / lengthSquared) + center
        };
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
        Point2D point2D3 = new Point2D(num3 * num5, num4 * num5) + center;
        if (Vector2D.DotProduct(point2D3 - ray.Origin, direction) >= 0.0)
        {
          point2DArray = new Point2D[1]{ point2D3 };
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
        Point2D point2D3 = new Point2D((num4 + num7) * num9, (num5 + num8) * num9) + center;
        if (Vector2D.DotProduct(point2D3 - ray.Origin, direction) >= 0.0)
          point2DList.Add(point2D3);
        Point2D point2D4 = new Point2D((num4 - num7) * num9, (num5 - num8) * num9) + center;
        if (Vector2D.DotProduct(point2D4 - ray.Origin, direction) >= 0.0)
          point2DList.Add(point2D4);
        if (point2DList.Count > 0)
          point2DArray = point2DList.ToArray();
      }
      return point2DArray;
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
      if (MathUtil.AreApproxEqual(0.0, num2, System.Math.Abs(num1) * precision * precision))
      {
        double num3 = num1 * delta.Y;
        double num4 = -num1 * delta.X;
        Point2D point = new Point2D(num3 / lengthSquared, num4 / lengthSquared) + center;
        if (segment.ContainsProjection(point, precision))
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
        Point2D point1 = new Point2D((num4 + num7) / lengthSquared, (num5 + num8) / lengthSquared) + center;
        if (segment.ContainsProjection(point1))
          point2DList.Add(point1);
        Point2D point2 = new Point2D((num4 - num7) / lengthSquared, (num5 - num8) / lengthSquared) + center;
        if (segment.ContainsProjection(point2))
          point2DList.Add(point2);
        if (point2DList.Count > 0)
          point2DArray = point2DList.ToArray();
      }
      return point2DArray;
    }

    public double GetAngle(Point2D point)
    {
      Vector2D vector2D = point - this.center;
      return System.Math.Atan2(vector2D.Y, vector2D.X);
    }

    public static void GetIntersections(
      Circle2D circle1,
      Circle2D circle2,
      out Point2D[] intersections,
      out bool overlap)
    {
      Circle2D.GetIntersections(circle1, circle2, 8.88178419700125E-16, out intersections, out overlap);
    }

    public static void GetIntersections(
      Circle2D circle1,
      Circle2D circle2,
      double precision,
      out Point2D[] intersections,
      out bool overlap)
    {
      intersections = (Point2D[]) null;
      overlap = false;
      Vector2D vector2D1 = circle2.center - circle1.center;
      double length = vector2D1.GetLength();
      if (System.Math.Abs(length) <= precision)
      {
        if (!MathUtil.AreApproxEqual(circle1.radius, circle2.radius, precision))
          return;
        overlap = true;
      }
      else
      {
        Vector2D vector2D2 = vector2D1 / length;
        double num1 = length;
        double num2 = num1 * num1;
        double num3 = circle1.radius * circle1.radius;
        double num4 = circle2.radius * circle2.radius;
        double num5 = num2 - num4 + num3;
        double d = (4.0 * num2 * num3 - num5 * num5) / (4.0 * num2);
        if (d < -precision)
          return;
        double num6 = num5 / (2.0 * num1);
        if (d < 0.0)
        {
          Point2D point2D = circle1.center + num6 * vector2D2;
          intersections = new Point2D[1]{ point2D };
        }
        else
        {
          double a = System.Math.Sqrt(d);
          if (MathUtil.AreApproxEqual(a, 0.0, precision))
          {
            Point2D point2D = circle1.center + num6 * vector2D2;
            intersections = new Point2D[1]{ point2D };
          }
          else
          {
            Vector2D vector2D3 = new Vector2D(vector2D2.Y, -vector2D2.X);
            Point2D point2D1 = circle1.center + num6 * vector2D2 + a * vector2D3;
            Point2D point2D2 = circle1.center + num6 * vector2D2 - a * vector2D3;
            intersections = new Point2D[2]
            {
              point2D1,
              point2D2
            };
          }
        }
      }
    }

    public double GetDistance(Point2D p)
    {
      if (p == this.center)
        return this.radius;
      Point2D[] intersections = this.GetIntersections(new Line2D(this.center, p));
      double d = double.MaxValue;
      foreach (Point2D point2D in intersections)
      {
        double lengthSquared = (point2D - p).GetLengthSquared();
        if (lengthSquared < d)
          d = lengthSquared;
      }
      return System.Math.Sqrt(d);
    }

    public override string ToString()
    {
      return string.Format("center: {0}, radius: {1}", (object) this.center.ToString(), (object) this.radius.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    }

    public ISegment2DIterator CreateIterator()
    {
      return (ISegment2DIterator) new Circle2D.Class201(this);
    }

    public void AddToBounds(Bounds2D bounds)
    {
      bounds.Update(this.center.X - this.radius, this.center.Y - this.radius);
      bounds.Update(this.center.X + this.radius, this.center.Y + this.radius);
    }

    public bool HasSegments
    {
      get
      {
        return true;
      }
    }

    private class Class201 : ISegment2DIterator
    {
      private static readonly double double_0 = 4.0 / 3.0 * (System.Math.Sqrt(2.0) - 1.0);
      private int int_0 = -1;
      private Point2D point2D_0;
      private double double_1;

      public Class201(Circle2D circle)
      {
        this.point2D_0 = circle.Center;
        this.double_1 = circle.Radius;
      }

      public bool MoveNext()
      {
        if (this.int_0 > 4)
          return false;
        ++this.int_0;
        return true;
      }

      public SegmentType CurrentType
      {
        get
        {
          switch (this.int_0)
          {
            case 0:
              return SegmentType.MoveTo;
            case 5:
              return SegmentType.Close;
            default:
              return SegmentType.CubicTo;
          }
        }
      }

      public SegmentType Current(Point2D[] points, int offset)
      {
        switch (this.int_0)
        {
          case 0:
            points[offset] = new Point2D(this.point2D_0.X + this.double_1, this.point2D_0.Y);
            return SegmentType.MoveTo;
          case 1:
            points[offset] = new Point2D(this.point2D_0.X + this.double_1, this.point2D_0.Y + Circle2D.Class201.double_0 * this.double_1);
            points[offset + 1] = new Point2D(this.point2D_0.X + Circle2D.Class201.double_0 * this.double_1, this.point2D_0.Y + this.double_1);
            points[offset + 2] = new Point2D(this.point2D_0.X, this.point2D_0.Y + this.double_1);
            return SegmentType.CubicTo;
          case 2:
            points[offset] = new Point2D(this.point2D_0.X - Circle2D.Class201.double_0 * this.double_1, this.point2D_0.Y + this.double_1);
            points[offset + 1] = new Point2D(this.point2D_0.X - this.double_1, this.point2D_0.Y + Circle2D.Class201.double_0 * this.double_1);
            points[offset + 2] = new Point2D(this.point2D_0.X - this.double_1, this.point2D_0.Y);
            return SegmentType.CubicTo;
          case 3:
            points[offset] = new Point2D(this.point2D_0.X - this.double_1, this.point2D_0.Y - Circle2D.Class201.double_0 * this.double_1);
            points[offset + 1] = new Point2D(this.point2D_0.X - Circle2D.Class201.double_0 * this.double_1, this.point2D_0.Y - this.double_1);
            points[offset + 2] = new Point2D(this.point2D_0.X, this.point2D_0.Y - this.double_1);
            return SegmentType.CubicTo;
          case 4:
            points[offset] = new Point2D(this.point2D_0.X + Circle2D.Class201.double_0 * this.double_1, this.point2D_0.Y - this.double_1);
            points[offset + 1] = new Point2D(this.point2D_0.X + this.double_1, this.point2D_0.Y - Circle2D.Class201.double_0 * this.double_1);
            points[offset + 2] = new Point2D(this.point2D_0.X + this.double_1, this.point2D_0.Y);
            return SegmentType.CubicTo;
          case 5:
            return SegmentType.Close;
          default:
            throw new Exception("Illegal segment value.");
        }
      }

      public int TotalSegmentCount
      {
        get
        {
          return 6;
        }
      }

      public int TotalPointCount
      {
        get
        {
          return 13;
        }
      }
    }
  }
}
