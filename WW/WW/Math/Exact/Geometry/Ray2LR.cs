// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Ray2LR
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;

namespace WW.Math.Exact.Geometry
{
  [Serializable]
  public struct Ray2LR
  {
    private Point2LR origin;
    private Vector2LR direction;

    public Ray2LR(Point2LR origin, Vector2LR direction)
    {
      this.origin = origin;
      this.direction = direction;
    }

    public Ray2LR(
      LongRational startX,
      LongRational startY,
      LongRational directionX,
      LongRational directionY)
    {
      this.origin = new Point2LR(startX, startY);
      this.direction = new Vector2LR(directionX, directionY);
    }

    public Vector2LR Direction
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

    public Point2LR Origin
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

    public bool Intersects(Ray2LR other, out Point2LR? intersection, out bool parallel)
    {
      if (this.direction.IsZero)
      {
        parallel = false;
        bool flag;
        if (flag = other.Contains(this.origin))
          intersection = new Point2LR?(this.origin);
        else
          intersection = new Point2LR?();
        return flag;
      }
      if (other.Direction.IsZero)
      {
        parallel = false;
        bool flag;
        if (flag = this.Contains(other.origin))
          intersection = new Point2LR?(other.origin);
        else
          intersection = new Point2LR?();
        return flag;
      }
      LongRational longRational1 = this.direction.X * other.direction.Y - this.direction.Y * other.direction.X;
      if (longRational1.IsZero)
      {
        parallel = true;
        bool flag;
        if (flag = other.Contains(this.origin))
          intersection = new Point2LR?(this.origin);
        else
          intersection = new Point2LR?();
        return flag;
      }
      parallel = false;
      Vector2LR u = other.origin - this.origin;
      LongRational longRational2 = Vector2LR.CrossProduct(u, other.direction);
      if (longRational1.IsPositive)
      {
        if (longRational2.IsNegative)
        {
          intersection = new Point2LR?();
          return false;
        }
      }
      else if (longRational2.IsPositive)
      {
        intersection = new Point2LR?();
        return false;
      }
      LongRational longRational3 = Vector2LR.CrossProduct(u, this.direction);
      if (longRational1.IsPositive)
      {
        if (longRational3.IsNegative)
        {
          intersection = new Point2LR?();
          return false;
        }
      }
      else if (longRational3.IsPositive)
      {
        intersection = new Point2LR?();
        return false;
      }
      LongRational longRational4 = longRational2 / longRational1;
      intersection = new Point2LR?(this.origin + longRational4 * this.direction);
      return true;
    }

    public static bool GetIntersectionCoefficients(
      Ray2LR a,
      Ray2LR b,
      out LongRational? p,
      out LongRational? q,
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
            p = new LongRational?(LongRational.Zero);
            q = new LongRational?(LongRational.Zero);
          }
          else
          {
            p = new LongRational?();
            q = new LongRational?();
          }
          return flag;
        }
        parallel = false;
        p = new LongRational?();
        bool flag1;
        if (flag1 = b.Contains(a.origin))
          q = new LongRational?(Vector2LR.DotProduct(a.origin - b.origin, b.direction) / b.direction.GetLengthSquared());
        else
          q = new LongRational?();
        return flag1;
      }
      if (b.Direction.IsZero)
      {
        parallel = false;
        q = new LongRational?();
        bool flag;
        if (flag = a.Contains(b.origin))
          p = new LongRational?(Vector2LR.DotProduct(b.origin - a.origin, a.direction) / a.direction.GetLengthSquared());
        else
          p = new LongRational?();
        return flag;
      }
      LongRational longRational1 = a.Direction.X * b.Direction.Y - a.Direction.Y * b.Direction.X;
      if (longRational1.IsZero)
      {
        parallel = true;
        if (!a.Contains(b.origin))
          b.Contains(a.origin);
        p = new LongRational?();
        q = new LongRational?();
        return true;
      }
      parallel = false;
      Vector2LR u = b.origin - a.origin;
      LongRational longRational2 = Vector2LR.CrossProduct(u, b.direction);
      if (longRational1.IsPositive)
      {
        if (longRational2.IsNegative)
        {
          p = new LongRational?();
          q = new LongRational?();
          return false;
        }
      }
      else if (longRational2.IsPositive)
      {
        p = new LongRational?();
        q = new LongRational?();
        return false;
      }
      LongRational longRational3 = Vector2LR.CrossProduct(u, a.direction);
      if (longRational1.IsPositive)
      {
        if (longRational3.IsNegative)
        {
          p = new LongRational?();
          q = new LongRational?();
          return false;
        }
      }
      else if (longRational3.IsPositive)
      {
        p = new LongRational?();
        q = new LongRational?();
        return false;
      }
      p = new LongRational?(longRational2 / longRational1);
      q = new LongRational?(longRational3 / longRational1);
      return true;
    }

    public static bool Intersects(Ray2LR a, Segment2LR b)
    {
      if (a.direction.IsZero)
        return b.Contains(a.origin);
      Vector2LR v = new Vector2LR(-a.Direction.Y, a.Direction.X);
      if (Vector2LR.DotProduct(b.Start - a.Origin, v).IsPositive == Vector2LR.DotProduct(b.End - a.Origin, v).IsPositive)
        return false;
      if (b.Start == b.End)
        return a.Contains(b.Start);
      Vector2LR delta = b.GetDelta();
      LongRational longRational1 = a.Direction.X * delta.Y - a.Direction.Y * delta.X;
      if (longRational1.IsZero)
        return false;
      Vector2LR u = b.Start - a.Origin;
      LongRational longRational2 = Vector2LR.CrossProduct(u, delta);
      if (longRational1.IsPositive)
      {
        if (longRational2.IsNegative)
          return false;
      }
      else if (longRational2.IsPositive)
        return false;
      LongRational longRational3 = Vector2LR.CrossProduct(u, a.Direction);
      if (longRational1.IsPositive)
      {
        if (longRational3.IsNegative || longRational3 > longRational1)
          return false;
      }
      else if (longRational3.IsPositive || longRational3 < longRational1)
        return false;
      LongRational longRational4 = longRational3 / longRational1;
      LongRational longRational5 = longRational2 / longRational1;
      return true;
    }

    public static bool GetIntersectionCoefficients(
      Ray2LR a,
      Segment2LR b,
      out LongRational? p,
      out LongRational? q,
      out bool areParallel)
    {
      if (a.direction.IsZero)
      {
        areParallel = false;
        p = new LongRational?();
        bool flag;
        if (flag = b.Contains(a.origin))
        {
          Vector2LR delta = b.GetDelta();
          q = new LongRational?(Vector2LR.DotProduct(a.origin - b.Start, delta) / delta.GetLengthSquared());
        }
        else
          q = new LongRational?();
        return flag;
      }
      Vector2LR v = new Vector2LR(-a.direction.Y, a.direction.X);
      Vector2LR u = b.Start - a.Origin;
      LongRational longRational1 = Vector2LR.DotProduct(u, v);
      LongRational longRational2 = Vector2LR.DotProduct(b.End - a.Origin, v);
      if (longRational1.IsPositive && longRational2.IsPositive || longRational1.IsNegative && longRational2.IsNegative)
      {
        p = new LongRational?();
        q = new LongRational?();
        areParallel = false;
        return false;
      }
      Vector2LR delta1 = b.GetDelta();
      if (delta1.IsZero)
      {
        areParallel = false;
        p = new LongRational?(Vector2LR.DotProduct(u, a.direction) / a.direction.GetLengthSquared());
        q = new LongRational?(LongRational.Zero);
        return true;
      }
      LongRational longRational3 = a.Direction.X * delta1.Y - a.Direction.Y * delta1.X;
      if (longRational3.IsZero)
      {
        p = new LongRational?();
        q = new LongRational?();
        areParallel = true;
        return true;
      }
      areParallel = false;
      LongRational longRational4 = Vector2LR.CrossProduct(u, delta1);
      if (longRational3.IsPositive)
      {
        if (longRational4.IsNegative)
        {
          p = new LongRational?();
          q = new LongRational?();
          return false;
        }
      }
      else if (longRational4.IsPositive)
      {
        p = new LongRational?();
        q = new LongRational?();
        return false;
      }
      LongRational longRational5 = Vector2LR.CrossProduct(u, a.Direction);
      if (longRational3.IsPositive)
      {
        if (longRational5.IsNegative || longRational5 > longRational3)
        {
          p = new LongRational?();
          q = new LongRational?();
          return false;
        }
      }
      else if (longRational5.IsPositive || longRational5 < longRational3)
      {
        p = new LongRational?();
        q = new LongRational?();
        return false;
      }
      p = new LongRational?(longRational4 / longRational3);
      q = new LongRational?(longRational5 / longRational3);
      return true;
    }

    public bool Contains(Point2LR p)
    {
      if (this.direction.IsZero)
        return p == this.origin;
      Vector2LR v = new Vector2LR(-this.direction.Y, this.direction.X);
      Vector2LR u = p - this.origin;
      if (!Vector2LR.DotProduct(u, v).IsZero)
        return false;
      return !Vector2LR.DotProduct(u, this.direction).IsNegative;
    }

    public LongRational GetDistanceSquared(Point2LR point)
    {
      if (this.direction.IsZero)
        return (point - this.origin).GetLengthSquared();
      return (Vector2LR.DotProduct(point - this.origin, this.direction) * this.direction / this.direction.GetLengthSquared() + this.origin - point).GetLengthSquared();
    }

    public Point2LR GetClosestPoint(Point2LR point)
    {
      return Vector2LR.DotProduct(point - this.origin, this.direction) / this.direction.GetLengthSquared() * this.direction + this.origin;
    }

    public static Ray2LR GetLeastSquaresFit(IList<Point2LR> points)
    {
      if (points.Count < 2)
        throw new ArgumentException("At least 2 points required for least square fit.");
      LongRational zero1 = LongRational.Zero;
      LongRational zero2 = LongRational.Zero;
      LongRational zero3 = LongRational.Zero;
      LongRational zero4 = LongRational.Zero;
      int count = points.Count;
      for (int index = 0; index < count; ++index)
      {
        Point2LR point = points[index];
        zero1 += point.X;
        zero2 += point.Y;
        zero3 += point.X * point.X;
        zero4 += point.X * point.Y;
      }
      LongRational longRational1 = (LongRational) ((double) count);
      LongRational longRational2 = zero1 / longRational1;
      LongRational longRational3 = zero2 / longRational1;
      LongRational longRational4 = zero3 - longRational1 * longRational2 * longRational2;
      LongRational y = (zero4 - longRational1 * longRational2 * longRational3) / longRational4;
      return new Ray2LR(points[0], new Vector2LR(LongRational.One, y));
    }

    public override string ToString()
    {
      return string.Format("origin: {0}, direction: {1}", (object) this.origin.ToString(), (object) this.direction.ToString());
    }
  }
}
