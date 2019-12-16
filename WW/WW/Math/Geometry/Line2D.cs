// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Line2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;

namespace WW.Math.Geometry
{
  [Serializable]
  public struct Line2D : IShape2D
  {
    private Point2D origin;
    private Vector2D direction;

    public Line2D(Point2D origin, Vector2D direction)
    {
      this.origin = origin;
      this.direction = direction;
    }

    public Line2D(double startX, double startY, double directionX, double directionY)
    {
      this.origin = new Point2D(startX, startY);
      this.direction = new Vector2D(directionX, directionY);
    }

    public Line2D(Point2D start, Point2D end)
    {
      this = new Line2D(start, end - start);
    }

    public Vector2D Direction
    {
      get
      {
        return this.direction;
      }
      set
      {
        this.direction = value;
      }
    }

    public Point2D Origin
    {
      get
      {
        return this.origin;
      }
      set
      {
        this.origin = value;
      }
    }

    public Point2D Start
    {
      get
      {
        return this.origin;
      }
    }

    public Point2D End
    {
      get
      {
        return this.origin + this.direction;
      }
    }

    public bool Intersects(Line2D other, out Point2D intersection, out bool parallel)
    {
      return this.Intersects(other, 8.88178419700125E-16, out intersection, out parallel);
    }

    public bool Intersects(
      Line2D other,
      double relativePrecision,
      out Point2D intersection,
      out bool parallel)
    {
      Vector2D u = other.Origin - this.origin;
      Vector2D direction = this.direction;
      if (this.direction == Vector2D.Zero)
      {
        intersection = Point2D.Zero;
        parallel = false;
        return false;
      }
      direction.Normalize();
      Vector2D v = new Vector2D(-direction.Y, direction.X);
      double num1 = Vector2D.DotProduct(other.direction, direction);
      double num2 = Vector2D.DotProduct(other.direction, v);
      double num3;
      bool flag1;
      if (System.Math.Abs(num1) <= System.Math.Abs(relativePrecision * num2))
      {
        num3 = Vector2D.DotProduct(u, direction);
        flag1 = true;
      }
      else
      {
        if (System.Math.Abs(num2) <= System.Math.Abs(relativePrecision * num1))
        {
          bool flag2 = System.Math.Abs(Vector2D.DotProduct(u, v)) < relativePrecision;
          intersection = Point2D.Zero;
          parallel = true;
          return flag2;
        }
        num3 = Vector2D.DotProduct(u, direction) - Vector2D.DotProduct(u, v) * num1 / num2;
        flag1 = true;
      }
      intersection = !flag1 ? Point2D.Zero : num3 * direction + this.origin;
      parallel = false;
      return flag1;
    }

    public static bool GetIntersectionCoefficients(Line2D a, Line2D b, out double p, out double q)
    {
      return Line2D.GetIntersectionCoefficients(a, b, out p, out q, 8.88178419700125E-16);
    }

    public static bool GetIntersectionCoefficients(
      Line2D a,
      Line2D b,
      out double p,
      out double q,
      double precision)
    {
      bool parallel;
      return Line2D.GetIntersectionCoefficients(a, b, out p, out q, out parallel, precision);
    }

    public static bool GetIntersectionCoefficients(
      Line2D a,
      Line2D b,
      out double p,
      out double q,
      out bool parallel)
    {
      return Line2D.GetIntersectionCoefficients(a, b, out p, out q, out parallel, 8.88178419700125E-16);
    }

    public static bool GetIntersectionCoefficients(
      Line2D a,
      Line2D b,
      out double p,
      out double q,
      out bool parallel,
      double precision)
    {
      double num1 = a.Direction.X * b.Direction.Y - a.Direction.Y * b.Direction.X;
      if (System.Math.Abs(num1) < precision)
      {
        parallel = true;
        Vector2D v = new Vector2D(-a.Direction.Y, a.Direction.X);
        if (System.Math.Abs(Vector2D.DotProduct(b.origin - a.origin, v)) > precision)
        {
          p = double.NaN;
          q = double.NaN;
          return false;
        }
        p = 0.5;
        q = 0.5;
        return true;
      }
      parallel = false;
      double num2 = 1.0 / num1;
      p = ((b.Origin.X - a.Origin.X) * b.Direction.Y - (b.Origin.Y - a.Origin.Y) * b.direction.X) * num2;
      q = ((b.Origin.X - a.Origin.X) * a.Direction.Y - (b.Origin.Y - a.Origin.Y) * a.direction.X) * num2;
      return true;
    }

    public static Point2D? GetIntersection(Line2D a, Line2D b)
    {
      double num1 = a.Direction.X * b.Direction.Y - a.Direction.Y * b.Direction.X;
      if (System.Math.Abs(num1) < 8.88178419700125E-16)
      {
        Vector2D v = new Vector2D(-a.direction.Y, a.direction.X);
        if (System.Math.Abs(Vector2D.DotProduct(b.origin - a.origin, v)) > 1E-10)
          return new Point2D?();
        return new Point2D?(Point2D.GetMidPoint(a.origin, b.origin));
      }
      double num2 = 1.0 / num1;
      double num3 = ((b.Origin.X - a.Origin.X) * b.Direction.Y - (b.Origin.Y - a.Origin.Y) * b.direction.X) * num2;
      double num4 = ((b.Origin.X - a.Origin.X) * a.Direction.Y - (b.Origin.Y - a.Origin.Y) * a.direction.X) * num2;
      return new Point2D?(Point2D.GetMidPoint(a.Origin + num3 * a.Direction, b.Origin + num4 * b.Direction));
    }

    public static bool Intersects(Line2D a, Segment2D b)
    {
      Vector2D v = new Vector2D(-a.Direction.Y, a.Direction.X);
      if (Vector2D.DotProduct(b.Start - a.Origin, v) >= 0.0 == Vector2D.DotProduct(b.End - a.Origin, v) >= 0.0)
        return false;
      Vector2D delta = b.GetDelta();
      double num1 = a.Direction.X * delta.Y - a.Direction.Y * delta.X;
      if (System.Math.Abs(num1) < 8.88178419700125E-16)
        return false;
      Vector2D vector2D = b.Start - a.Origin;
      double num2 = 1.0 / num1;
      double num3 = (vector2D.X * a.Direction.Y - vector2D.Y * a.direction.X) * num2;
      if (num3 >= 0.0)
        return num3 <= 1.0;
      return false;
    }

    public static Point2D? GetIntersection(Line2D a, Segment2D b)
    {
      Vector2D v = new Vector2D(-a.Direction.Y, a.Direction.X);
      if (Vector2D.DotProduct(b.Start - a.Origin, v) >= 0.0 == Vector2D.DotProduct(b.End - a.Origin, v) >= 0.0)
        return new Point2D?();
      Vector2D delta = b.GetDelta();
      double num1 = a.Direction.X * delta.Y - a.Direction.Y * delta.X;
      if (System.Math.Abs(num1) < 8.88178419700125E-16)
        return new Point2D?();
      Vector2D vector2D = b.Start - a.Origin;
      double num2 = 1.0 / num1;
      double num3 = (vector2D.X * delta.Y - vector2D.Y * delta.X) * num2;
      double num4 = (vector2D.X * a.Direction.Y - vector2D.Y * a.direction.X) * num2;
      if ((num4 < 0.0 ? 0 : (num4 <= 1.0 ? 1 : 0)) == 0)
        return new Point2D?();
      return new Point2D?(num3 * a.direction + a.origin);
    }

    public static bool GetIntersectionCoefficients(
      Line2D a,
      Segment2D b,
      out double p,
      out double q,
      out bool areParallel)
    {
      return Line2D.GetIntersectionCoefficients(a, b, out p, out q, out areParallel, 8.88178419700125E-16);
    }

    public static bool GetIntersectionCoefficients(
      Line2D a,
      Segment2D b,
      out double p,
      out double q,
      out bool areParallel,
      double precision)
    {
      double length1 = a.Direction.GetLength();
      Vector2D v1 = a.Direction / length1;
      Vector2D v2 = new Vector2D(-v1.Y, v1.X);
      Vector2D u = b.Start - a.Origin;
      double a1 = Vector2D.DotProduct(u, v2);
      double b1 = Vector2D.DotProduct(b.End - a.Origin, v2);
      if (a1 > b1)
        MathUtil.Swap(ref a1, ref b1);
      if (a1 < precision && b1 > -precision)
      {
        Vector2D delta = b.GetDelta();
        if (delta == Vector2D.Zero)
        {
          areParallel = false;
          p = Vector2D.DotProduct(u, v1) / length1;
          q = 0.0;
          return true;
        }
        double length2 = delta.GetLength();
        Vector2D vector2D = delta / length2;
        double num1 = v1.X * vector2D.Y - v1.Y * vector2D.X;
        if (System.Math.Abs(num1) < precision)
        {
          p = double.NaN;
          q = double.NaN;
          areParallel = true;
          return true;
        }
        double num2 = 1.0 / num1;
        q = (u.X * v1.Y - u.Y * v1.X) * num2 / length2;
        bool flag;
        if (!(flag = q >= -precision && q <= 1.0 + precision))
        {
          p = double.NaN;
          q = double.NaN;
        }
        p = (u.X * vector2D.Y - u.Y * vector2D.X) * num2 / length1;
        areParallel = false;
        return flag;
      }
      p = double.NaN;
      q = double.NaN;
      areParallel = false;
      return false;
    }

    public double GetDistance(Point2D point)
    {
      return System.Math.Sqrt(this.GetDistanceSquared(point));
    }

    public double GetDistanceSquared(Point2D point)
    {
      if (this.direction == Vector2D.Zero)
        return (point - this.origin).GetLengthSquared();
      return (Vector2D.DotProduct(point - this.origin, this.direction) * this.direction / this.direction.GetLengthSquared() + this.origin - point).GetLengthSquared();
    }

    public Point2D GetClosestPoint(Point2D point)
    {
      return Vector2D.DotProduct(point - this.origin, this.direction) / this.direction.GetLengthSquared() * this.direction + this.origin;
    }

    public static Line2D GetLeastSquaresFit(IList<Point2D> points)
    {
      if (points.Count < 2)
        throw new ArgumentException("At least 2 points required for least square fit.");
      double num1 = 0.0;
      double num2 = 0.0;
      double num3 = 0.0;
      double num4 = 0.0;
      int count = points.Count;
      for (int index = 0; index < count; ++index)
      {
        Point2D point = points[index];
        num1 += point.X;
        num2 += point.Y;
        num3 += point.X * point.X;
        num4 += point.X * point.Y;
      }
      double num5 = (double) count;
      double num6 = num1 / num5;
      double num7 = num2 / num5;
      double num8 = num3 - num5 * num6 * num6;
      double y = (num4 - num5 * num6 * num7) / num8;
      return new Line2D(points[0], new Vector2D(1.0, y));
    }

    public bool IsLeft(Point2D p)
    {
      if (this.direction == Vector2D.Zero)
        return false;
      return Vector2D.DotProduct(new Vector2D(-this.direction.Y, this.direction.X), p - this.origin) > 0.0;
    }

    public bool IsRight(Point2D p)
    {
      if (this.direction == Vector2D.Zero)
        return false;
      return Vector2D.DotProduct(new Vector2D(-this.direction.Y, this.direction.X), p - this.origin) < 0.0;
    }

    public bool Contains(Point2D point)
    {
      return this.Contains(point, 8.88178419700125E-16);
    }

    public bool Contains(Point2D point, double precision)
    {
      double lengthSquared = this.direction.GetLengthSquared();
      double num1 = precision * precision * lengthSquared;
      double num2 = Vector2D.DotProduct(point - this.origin, new Vector2D(-this.direction.Y, this.direction.X));
      return num2 * num2 <= num1;
    }

    public override string ToString()
    {
      return string.Format("origin: {0}, direction: {1}", (object) this.origin.ToString(), (object) this.direction.ToString());
    }

    public ISegment2DIterator CreateIterator()
    {
      return (ISegment2DIterator) new Line2D.Class202(this);
    }

    public void AddToBounds(Bounds2D bounds)
    {
      bounds.Update(this.origin);
      bounds.Update(this.origin + this.direction);
    }

    public bool HasSegments
    {
      get
      {
        return true;
      }
    }

    private class Class202 : ISegment2DIterator
    {
      private static readonly SegmentType[] segmentType_0 = new SegmentType[2]{ SegmentType.MoveTo, SegmentType.LineTo };
      private int int_0 = -1;
      private readonly Point2D[] point2D_0;

      public Class202(Line2D line)
      {
        this.point2D_0 = new Point2D[2]
        {
          line.Origin,
          line.Origin + line.Direction
        };
      }

      public bool MoveNext()
      {
        if (this.int_0 > 0)
          return false;
        ++this.int_0;
        return true;
      }

      public SegmentType CurrentType
      {
        get
        {
          return Line2D.Class202.segmentType_0[this.int_0];
        }
      }

      public SegmentType Current(Point2D[] points, int offset)
      {
        points[offset] = this.point2D_0[this.int_0];
        return Line2D.Class202.segmentType_0[this.int_0];
      }

      public int TotalSegmentCount
      {
        get
        {
          return 2;
        }
      }

      public int TotalPointCount
      {
        get
        {
          return 2;
        }
      }
    }
  }
}
