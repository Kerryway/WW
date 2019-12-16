// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Ray2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Math.Geometry
{
  [Serializable]
  public struct Ray2D
  {
    private Point2D origin;
    private Vector2D direction;

    public Ray2D(Point2D origin, Vector2D direction)
    {
      this.origin = origin;
      this.direction = direction;
    }

    public Ray2D(double startX, double startY, double directionX, double directionY)
    {
      this.origin = new Point2D(startX, startY);
      this.direction = new Vector2D(directionX, directionY);
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

    public static bool Intersects(Ray2D a, Segment2D b)
    {
      Vector2D v = new Vector2D(-a.Direction.Y, a.Direction.X);
      Vector2D u = b.Start - a.Origin;
      if (Vector2D.DotProduct(u, v) >= 0.0 == Vector2D.DotProduct(b.End - a.Origin, v) >= 0.0)
        return false;
      Vector2D delta = b.GetDelta();
      double num1 = a.Direction.X * delta.Y - a.Direction.Y * delta.X;
      if (System.Math.Abs(num1) < 8.88178419700125E-16)
        return false;
      double num2 = 1.0 / num1;
      if ((u.X * delta.Y - u.Y * delta.X) * num2 < 0.0)
        return false;
      double num3 = (u.X * a.Direction.Y - u.Y * a.direction.X) * num2;
      if (num3 >= 0.0)
        return num3 <= 1.0;
      return false;
    }

    public static Point2D? GetIntersection(Ray2D a, Segment2D b)
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
      if (num3 < 0.0)
        return new Point2D?();
      double num4 = (vector2D.X * a.Direction.Y - vector2D.Y * a.direction.X) * num2;
      if ((num4 < 0.0 ? 0 : (num4 <= 1.0 ? 1 : 0)) == 0)
        return new Point2D?();
      return new Point2D?(num3 * a.direction + a.origin);
    }

    public static Point2D? GetIntersection(Ray2D a, Ray2D b)
    {
      bool parallel;
      return Ray2D.GetIntersection(a, b, out parallel);
    }

    public static Point2D? GetIntersection(Ray2D a, Ray2D b, out bool parallel)
    {
      return Ray2D.GetIntersection(a, b, 8.88178419700125E-16, out parallel);
    }

    public static Point2D? GetIntersection(
      Ray2D a,
      Ray2D b,
      double precision,
      out bool parallel)
    {
      double num1 = a.Direction.X * b.Direction.Y - a.Direction.Y * b.Direction.X;
      if (System.Math.Abs(num1) < precision)
      {
        parallel = true;
        Vector2D v = new Vector2D(-a.direction.Y, a.direction.X);
        Vector2D u = b.origin - a.origin;
        if (System.Math.Abs(Vector2D.DotProduct(u, v)) > 1E-10)
          return new Point2D?();
        if (Vector2D.DotProduct(a.direction, b.direction) < 0.0 && Vector2D.DotProduct(u, a.direction) < 0.0)
          return new Point2D?();
        return new Point2D?(Point2D.GetMidPoint(a.origin, b.origin));
      }
      parallel = false;
      double num2 = 1.0 / num1;
      double num3 = ((b.Origin.X - a.Origin.X) * b.Direction.Y - (b.Origin.Y - a.Origin.Y) * b.direction.X) * num2;
      if (num3 < 0.0)
        return new Point2D?();
      double num4 = ((b.Origin.X - a.Origin.X) * a.Direction.Y - (b.Origin.Y - a.Origin.Y) * a.direction.X) * num2;
      if (num4 < 0.0)
        return new Point2D?();
      return new Point2D?(Point2D.GetMidPoint(a.Origin + num3 * a.Direction, b.Origin + num4 * b.Direction));
    }

    public static bool GetIntersectionCoefficients(
      Ray2D a,
      Segment2D b,
      out double p,
      out double q,
      out bool areParallel)
    {
      return Ray2D.GetIntersectionCoefficients(a, b, out p, out q, out areParallel, 8.88178419700125E-16);
    }

    public static bool GetIntersectionCoefficients(
      Ray2D a,
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
          if (p < 0.0)
          {
            p = double.NaN;
            q = double.NaN;
            return false;
          }
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
        areParallel = false;
        double num2 = 1.0 / num1;
        p = (u.X * vector2D.Y - u.Y * vector2D.X) * num2 / length1;
        if (p < 0.0)
        {
          p = double.NaN;
          q = double.NaN;
          return false;
        }
        q = (u.X * v1.Y - u.Y * v1.X) * num2 / length2;
        bool flag;
        if (!(flag = q >= -precision && q <= 1.0 + precision))
        {
          p = double.NaN;
          q = double.NaN;
        }
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
      double num = Vector2D.DotProduct(point - this.origin, this.direction);
      double lengthSquared1;
      if (num > 0.0)
      {
        double lengthSquared2 = this.direction.GetLengthSquared();
        lengthSquared1 = (num * this.direction / lengthSquared2 + this.origin - point).GetLengthSquared();
      }
      else
        lengthSquared1 = (this.origin - point).GetLengthSquared();
      return lengthSquared1;
    }

    public Point2D GetClosestPoint(Point2D point)
    {
      Vector2D u = point - this.origin;
      double lengthSquared = this.direction.GetLengthSquared();
      double num = Vector2D.DotProduct(u, this.direction);
      return num <= 0.0 ? this.origin : num / lengthSquared * this.direction + this.origin;
    }

    public bool Contains(Point2D point)
    {
      return this.Contains(point, 8.88178419700125E-16);
    }

    public bool Contains(Point2D point, double precision)
    {
      double lengthSquared = this.direction.GetLengthSquared();
      double num1 = precision * precision * lengthSquared;
      Vector2D u = point - this.origin;
      Vector2D v = new Vector2D(-this.direction.Y, this.direction.X);
      double num2 = Vector2D.DotProduct(u, v);
      if (num2 * num2 > num1)
        return false;
      double num3 = Vector2D.DotProduct(u, this.direction);
      return num3 >= 0.0 || num3 * num3 <= num1;
    }

    public override string ToString()
    {
      return string.Format("origin: {0}, direction: {1}", (object) this.origin.ToString(), (object) this.direction.ToString());
    }
  }
}
