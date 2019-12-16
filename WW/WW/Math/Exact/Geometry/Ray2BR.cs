// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Ray2BR
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;

namespace WW.Math.Exact.Geometry
{
  [Serializable]
  public struct Ray2BR
  {
    private Point2BR origin;
    private Vector2BR direction;

    public Ray2BR(Point2BR origin, Vector2BR direction)
    {
      this.origin = origin;
      this.direction = direction;
    }

    public Ray2BR(
      BigRational startX,
      BigRational startY,
      BigRational directionX,
      BigRational directionY)
    {
      this.origin = new Point2BR(startX, startY);
      this.direction = new Vector2BR(directionX, directionY);
    }

    public Vector2BR Direction
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

    public Point2BR Origin
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

    public bool Intersects(Ray2BR other, out Point2BR? intersection, out bool parallel)
    {
      if (this.direction.IsZero)
      {
        parallel = false;
        bool flag;
        if (flag = other.Contains(this.origin))
          intersection = new Point2BR?(this.origin);
        else
          intersection = new Point2BR?();
        return flag;
      }
      if (other.Direction.IsZero)
      {
        parallel = false;
        bool flag;
        if (flag = this.Contains(other.origin))
          intersection = new Point2BR?(other.origin);
        else
          intersection = new Point2BR?();
        return flag;
      }
      BigRational bigRational1 = this.direction.X * other.direction.Y - this.direction.Y * other.direction.X;
      if (bigRational1.IsZero)
      {
        parallel = true;
        bool flag;
        if (flag = other.Contains(this.origin))
          intersection = new Point2BR?(this.origin);
        else
          intersection = new Point2BR?();
        return flag;
      }
      parallel = false;
      Vector2BR u = other.origin - this.origin;
      BigRational bigRational2 = Vector2BR.CrossProduct(u, other.direction);
      if (bigRational1.IsPositive)
      {
        if (bigRational2.IsNegative)
        {
          intersection = new Point2BR?();
          return false;
        }
      }
      else if (bigRational2.IsPositive)
      {
        intersection = new Point2BR?();
        return false;
      }
      BigRational bigRational3 = Vector2BR.CrossProduct(u, this.direction);
      if (bigRational1.IsPositive)
      {
        if (bigRational3.IsNegative)
        {
          intersection = new Point2BR?();
          return false;
        }
      }
      else if (bigRational3.IsPositive)
      {
        intersection = new Point2BR?();
        return false;
      }
      BigRational bigRational4 = bigRational2 / bigRational1;
      intersection = new Point2BR?(this.origin + bigRational4 * this.direction);
      return true;
    }

    public static bool GetIntersectionCoefficients(
      Ray2BR a,
      Ray2BR b,
      out BigRational? p,
      out BigRational? q,
      out bool parallel)
    {
      if (a.direction.IsZero)
      {
        if (b.direction.IsZero)
        {
          bool flag = a.origin == b.origin;
          parallel = false;
          if (flag)
          {
            p = new BigRational?(BigRational.Zero);
            q = new BigRational?(BigRational.Zero);
          }
          else
          {
            p = new BigRational?();
            q = new BigRational?();
          }
          return flag;
        }
        parallel = false;
        p = new BigRational?();
        bool flag1;
        if (flag1 = b.Contains(a.origin))
          q = new BigRational?(Vector2BR.DotProduct(a.origin - b.origin, b.direction) / b.direction.GetLengthSquared());
        else
          q = new BigRational?();
        return flag1;
      }
      if (b.Direction.IsZero)
      {
        parallel = false;
        q = new BigRational?();
        bool flag;
        if (flag = a.Contains(b.origin))
          p = new BigRational?(Vector2BR.DotProduct(b.origin - a.origin, a.direction) / a.direction.GetLengthSquared());
        else
          p = new BigRational?();
        return flag;
      }
      BigRational bigRational1 = a.Direction.X * b.Direction.Y - a.Direction.Y * b.Direction.X;
      if (bigRational1.IsZero)
      {
        parallel = true;
        if (!a.Contains(b.origin))
          b.Contains(a.origin);
        p = new BigRational?();
        q = new BigRational?();
        return true;
      }
      parallel = false;
      Vector2BR u = b.origin - a.origin;
      BigRational bigRational2 = Vector2BR.CrossProduct(u, b.direction);
      if (bigRational1.IsPositive)
      {
        if (bigRational2.IsNegative)
        {
          p = new BigRational?();
          q = new BigRational?();
          return false;
        }
      }
      else if (bigRational2.IsPositive)
      {
        p = new BigRational?();
        q = new BigRational?();
        return false;
      }
      BigRational bigRational3 = Vector2BR.CrossProduct(u, a.direction);
      if (bigRational1.IsPositive)
      {
        if (bigRational3.IsNegative)
        {
          p = new BigRational?();
          q = new BigRational?();
          return false;
        }
      }
      else if (bigRational3.IsPositive)
      {
        p = new BigRational?();
        q = new BigRational?();
        return false;
      }
      p = new BigRational?(bigRational2 / bigRational1);
      q = new BigRational?(bigRational3 / bigRational1);
      return true;
    }

    public static bool Intersects(Ray2BR a, Segment2BR b)
    {
      if (a.direction.IsZero)
        return b.Contains(a.origin);
      Vector2BR v = new Vector2BR(-a.Direction.Y, a.Direction.X);
      if (Vector2BR.DotProduct(b.Start - a.Origin, v).IsPositive == Vector2BR.DotProduct(b.End - a.Origin, v).IsPositive)
        return false;
      if (b.Start == b.End)
        return a.Contains(b.Start);
      Vector2BR delta = b.GetDelta();
      BigRational bigRational1 = a.Direction.X * delta.Y - a.Direction.Y * delta.X;
      if (bigRational1.IsZero)
        return false;
      Vector2BR u = b.Start - a.Origin;
      BigRational bigRational2 = Vector2BR.CrossProduct(u, delta);
      if (bigRational1.IsPositive)
      {
        if (bigRational2.IsNegative)
          return false;
      }
      else if (bigRational2.IsPositive)
        return false;
      BigRational bigRational3 = Vector2BR.CrossProduct(u, a.Direction);
      if (bigRational1.IsPositive)
      {
        if (bigRational3.IsNegative || bigRational3 > bigRational1)
          return false;
      }
      else if (bigRational3.IsPositive || bigRational3 < bigRational1)
        return false;
      BigRational bigRational4 = bigRational3 / bigRational1;
      BigRational bigRational5 = bigRational2 / bigRational1;
      return true;
    }

    public static bool GetIntersectionCoefficients(
      Ray2BR a,
      Segment2BR b,
      out BigRational? p,
      out BigRational? q,
      out bool areParallel)
    {
      if (a.direction.IsZero)
      {
        areParallel = false;
        p = new BigRational?();
        bool flag;
        if (flag = b.Contains(a.origin))
        {
          Vector2BR delta = b.GetDelta();
          q = new BigRational?(Vector2BR.DotProduct(a.origin - b.Start, delta) / delta.GetLengthSquared());
        }
        else
          q = new BigRational?();
        return flag;
      }
      Vector2BR v = new Vector2BR(-a.direction.Y, a.direction.X);
      Vector2BR u = b.Start - a.Origin;
      BigRational bigRational1 = Vector2BR.DotProduct(u, v);
      BigRational bigRational2 = Vector2BR.DotProduct(b.End - a.Origin, v);
      if (bigRational1.IsPositive && bigRational2.IsPositive || bigRational1.IsNegative && bigRational2.IsNegative)
      {
        p = new BigRational?();
        q = new BigRational?();
        areParallel = false;
        return false;
      }
      Vector2BR delta1 = b.GetDelta();
      if (delta1.IsZero)
      {
        areParallel = false;
        p = new BigRational?(Vector2BR.DotProduct(u, a.direction) / a.direction.GetLengthSquared());
        q = new BigRational?(BigRational.Zero);
        return true;
      }
      BigRational bigRational3 = a.Direction.X * delta1.Y - a.Direction.Y * delta1.X;
      if (bigRational3.IsZero)
      {
        p = new BigRational?();
        q = new BigRational?();
        areParallel = true;
        return true;
      }
      areParallel = false;
      BigRational bigRational4 = Vector2BR.CrossProduct(u, delta1);
      if (bigRational3.IsPositive)
      {
        if (bigRational4.IsNegative)
        {
          p = new BigRational?();
          q = new BigRational?();
          return false;
        }
      }
      else if (bigRational4.IsPositive)
      {
        p = new BigRational?();
        q = new BigRational?();
        return false;
      }
      BigRational bigRational5 = Vector2BR.CrossProduct(u, a.Direction);
      if (bigRational3.IsPositive)
      {
        if (bigRational5.IsNegative || bigRational5 > bigRational3)
        {
          p = new BigRational?();
          q = new BigRational?();
          return false;
        }
      }
      else if (bigRational5.IsPositive || bigRational5 < bigRational3)
      {
        p = new BigRational?();
        q = new BigRational?();
        return false;
      }
      p = new BigRational?(bigRational4 / bigRational3);
      q = new BigRational?(bigRational5 / bigRational3);
      return true;
    }

    public bool Contains(Point2BR p)
    {
      if (this.direction.IsZero)
        return p == this.origin;
      Vector2BR v = new Vector2BR(-this.direction.Y, this.direction.X);
      Vector2BR u = p - this.origin;
      if (!Vector2BR.DotProduct(u, v).IsZero)
        return false;
      return !Vector2BR.DotProduct(u, this.direction).IsNegative;
    }

    public BigRational GetDistanceSquared(Point2BR point)
    {
      if (this.direction.IsZero)
        return (point - this.origin).GetLengthSquared();
      return (Vector2BR.DotProduct(point - this.origin, this.direction) * this.direction / this.direction.GetLengthSquared() + this.origin - point).GetLengthSquared();
    }

    public Point2BR GetClosestPoint(Point2BR point)
    {
      return Vector2BR.DotProduct(point - this.origin, this.direction) / this.direction.GetLengthSquared() * this.direction + this.origin;
    }

    public static Ray2BR GetLeastSquaresFit(IList<Point2BR> points)
    {
      if (points.Count < 2)
        throw new ArgumentException("At least 2 points required for least square fit.");
      BigRational zero1 = BigRational.Zero;
      BigRational zero2 = BigRational.Zero;
      BigRational zero3 = BigRational.Zero;
      BigRational zero4 = BigRational.Zero;
      int count = points.Count;
      for (int index = 0; index < count; ++index)
      {
        Point2BR point = points[index];
        zero1 += point.X;
        zero2 += point.Y;
        zero3 += point.X * point.X;
        zero4 += point.X * point.Y;
      }
      BigRational bigRational1 = (BigRational) ((double) count);
      BigRational bigRational2 = zero1 / bigRational1;
      BigRational bigRational3 = zero2 / bigRational1;
      BigRational bigRational4 = zero3 - bigRational1 * bigRational2 * bigRational2;
      BigRational y = (zero4 - bigRational1 * bigRational2 * bigRational3) / bigRational4;
      return new Ray2BR(points[0], new Vector2BR(BigRational.One, y));
    }

    public override string ToString()
    {
      return string.Format("origin: {0}, direction: {1}", (object) this.origin.ToString(), (object) this.direction.ToString());
    }
  }
}
