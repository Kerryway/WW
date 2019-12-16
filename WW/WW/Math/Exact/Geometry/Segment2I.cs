// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Segment2I
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Diagnostics;

namespace WW.Math.Exact.Geometry
{
  [Serializable]
  public struct Segment2I
  {
    private Point2I start;
    private Point2I end;

    [DebuggerStepThrough]
    public Segment2I(Point2I start, Point2I end)
    {
      this.start = start;
      this.end = end;
    }

    [DebuggerStepThrough]
    public Segment2I(int startx, int starty, int endx, int endy)
    {
      this.start = new Point2I(startx, starty);
      this.end = new Point2I(endx, endy);
    }

    public Point2I Start
    {
      get
      {
        return this.start;
      }
      set
      {
        this.start = value;
      }
    }

    public Point2I End
    {
      get
      {
        return this.end;
      }
      set
      {
        this.end = value;
      }
    }

    public Vector2I GetDelta()
    {
      return this.end - this.start;
    }

    public static bool GetIntersectionParameters(
      Segment2I a,
      Segment2I b,
      out Point2D[] intersections,
      out LongRational[] pArray,
      out LongRational[] qArray)
    {
      Vector2I delta1 = a.GetDelta();
      Vector2I delta2 = b.GetDelta();
      long denominator = (long) (delta1.X * delta2.Y - delta1.Y * delta2.X);
      if (denominator == 0L)
      {
        Segment2I.Struct2 struct2_1 = new Segment2I.Struct2(a.start, a.end, delta1);
        Segment2I.Struct2 struct2_2 = new Segment2I.Struct2(b.start, b.end, delta2);
        if ((struct2_1.long_0 > struct2_2.long_0 ? (!struct2_1.method_0(b.start) ? 0 : (struct2_1.method_0(b.End) ? 1 : 0)) : (struct2_2.long_0 == 0L || !struct2_2.method_0(a.start) ? 0 : (struct2_2.method_0(a.end) ? 1 : 0))) != 0)
        {
          if (struct2_1.method_1(b.start))
          {
            if (struct2_1.method_1(b.end))
            {
              intersections = new Point2D[2]
              {
                (Point2D) b.start,
                (Point2D) b.end
              };
              pArray = new LongRational[2]
              {
                a.GetNormalizedProjection(b.start).Value,
                a.GetNormalizedProjection(b.end).Value
              };
              qArray = new LongRational[2]
              {
                LongRational.Zero,
                LongRational.One
              };
              return true;
            }
            if (struct2_2.method_1(a.start))
            {
              intersections = new Point2D[2]
              {
                (Point2D) a.start,
                (Point2D) b.start
              };
              pArray = new LongRational[2]
              {
                LongRational.Zero,
                a.GetNormalizedProjection(b.start).Value
              };
              qArray = new LongRational[2]
              {
                b.GetNormalizedProjection(a.start).Value,
                LongRational.Zero
              };
              return true;
            }
            if (struct2_2.method_1(a.End))
            {
              intersections = new Point2D[2]
              {
                (Point2D) b.start,
                (Point2D) a.end
              };
              pArray = new LongRational[2]
              {
                a.GetNormalizedProjection(b.start).Value,
                LongRational.One
              };
              qArray = new LongRational[2]
              {
                LongRational.Zero,
                b.GetNormalizedProjection(a.end).Value
              };
              return true;
            }
          }
          else if (struct2_1.method_1(b.end))
          {
            if (struct2_2.method_1(a.start))
            {
              if (struct2_2.method_1(a.End))
              {
                intersections = new Point2D[2]
                {
                  (Point2D) a.start,
                  (Point2D) a.end
                };
                pArray = new LongRational[2]
                {
                  LongRational.Zero,
                  LongRational.One
                };
                qArray = new LongRational[2]
                {
                  b.GetNormalizedProjection(a.start).Value,
                  b.GetNormalizedProjection(a.end).Value
                };
              }
              else
              {
                intersections = new Point2D[2]
                {
                  (Point2D) a.start,
                  (Point2D) b.end
                };
                pArray = new LongRational[2]
                {
                  LongRational.Zero,
                  a.GetNormalizedProjection(b.end).Value
                };
                qArray = new LongRational[2]
                {
                  b.GetNormalizedProjection(a.start).Value,
                  LongRational.One
                };
              }
              return true;
            }
            if (struct2_2.method_1(a.End))
            {
              intersections = new Point2D[2]
              {
                (Point2D) a.end,
                (Point2D) b.end
              };
              pArray = new LongRational[2]
              {
                LongRational.One,
                a.GetNormalizedProjection(b.end).Value
              };
              qArray = new LongRational[2]
              {
                b.GetNormalizedProjection(a.end).Value,
                LongRational.One
              };
              return true;
            }
          }
          else if (struct2_2.method_1(a.start))
          {
            intersections = new Point2D[2]
            {
              (Point2D) a.start,
              (Point2D) a.end
            };
            pArray = new LongRational[2]
            {
              LongRational.Zero,
              LongRational.One
            };
            qArray = new LongRational[2]
            {
              b.GetNormalizedProjection(a.start).Value,
              b.GetNormalizedProjection(a.end).Value
            };
            return true;
          }
        }
        intersections = (Point2D[]) null;
        pArray = (LongRational[]) null;
        qArray = (LongRational[]) null;
        return false;
      }
      long numerator1 = (long) ((b.Start.X - a.Start.X) * delta2.Y - (b.Start.Y - a.Start.Y) * delta2.X);
      if (denominator > 0L)
      {
        if (numerator1 < 0L || numerator1 > denominator)
        {
          intersections = (Point2D[]) null;
          pArray = (LongRational[]) null;
          qArray = (LongRational[]) null;
          return false;
        }
      }
      else if (numerator1 > 0L || numerator1 < denominator)
      {
        intersections = (Point2D[]) null;
        pArray = (LongRational[]) null;
        qArray = (LongRational[]) null;
        return false;
      }
      long numerator2 = (long) ((b.Start.X - a.Start.X) * delta1.Y - (b.Start.Y - a.Start.Y) * delta1.X);
      if (denominator > 0L)
      {
        if (numerator2 < 0L || numerator2 > denominator)
        {
          intersections = (Point2D[]) null;
          pArray = (LongRational[]) null;
          qArray = (LongRational[]) null;
          return false;
        }
      }
      else if (numerator2 > 0L || numerator2 < denominator)
      {
        intersections = (Point2D[]) null;
        pArray = (LongRational[]) null;
        qArray = (LongRational[]) null;
        return false;
      }
      LongRational longRational1 = LongRational.Create(numerator1, denominator);
      LongRational longRational2 = LongRational.Create(numerator2, denominator);
      intersections = new Point2D[1]
      {
        new Point2D((double) a.start.X + (double) longRational1.Numerator * (double) delta1.X / (double) longRational1.Denominator, (double) a.start.Y + (double) longRational1.Numerator * (double) delta1.Y / (double) longRational1.Denominator)
      };
      pArray = new LongRational[1]{ longRational1 };
      qArray = new LongRational[1]{ longRational2 };
      return true;
    }

    public static int GetIntersections(
      Segment2I a,
      Segment2I b,
      out Point2D intersection1,
      out Point2D intersection2)
    {
      Vector2I delta1 = a.GetDelta();
      Vector2I delta2 = b.GetDelta();
      long num1 = (long) delta1.X * (long) delta2.Y - (long) delta1.Y * (long) delta2.X;
      if (num1 == 0L)
      {
        Segment2I.Struct2 struct2_1 = new Segment2I.Struct2(a.start, a.end, delta1);
        Segment2I.Struct2 struct2_2 = new Segment2I.Struct2(b.start, b.end, delta2);
        if ((struct2_1.long_0 > struct2_2.long_0 ? (!struct2_1.method_0(b.start) ? 0 : (struct2_1.method_0(b.End) ? 1 : 0)) : (struct2_2.long_0 == 0L || !struct2_2.method_0(a.start) ? 0 : (struct2_2.method_0(a.end) ? 1 : 0))) != 0)
        {
          if (struct2_1.method_1(b.start))
          {
            if (struct2_1.method_1(b.end))
            {
              intersection1 = (Point2D) b.start;
              intersection2 = (Point2D) b.end;
              return 2;
            }
            if (struct2_2.method_1(a.start))
            {
              intersection1 = (Point2D) a.start;
              intersection2 = (Point2D) b.start;
              return 2;
            }
            if (struct2_2.method_1(a.End))
            {
              intersection1 = (Point2D) b.start;
              intersection2 = (Point2D) a.end;
              return 2;
            }
          }
          else if (struct2_1.method_1(b.end))
          {
            if (struct2_2.method_1(a.start))
            {
              if (struct2_2.method_1(a.End))
              {
                intersection1 = (Point2D) a.start;
                intersection2 = (Point2D) a.end;
              }
              else
              {
                intersection1 = (Point2D) a.start;
                intersection2 = (Point2D) b.end;
              }
              return 2;
            }
            if (struct2_2.method_1(a.End))
            {
              intersection1 = (Point2D) a.end;
              intersection2 = (Point2D) b.end;
              return 2;
            }
          }
          else if (struct2_2.method_1(a.start))
          {
            intersection1 = (Point2D) a.start;
            intersection2 = (Point2D) a.end;
            return 2;
          }
        }
        intersection1 = Point2D.NaN;
        intersection2 = Point2D.NaN;
        return 0;
      }
      long num2 = ((long) b.Start.X - (long) a.Start.X) * (long) delta2.Y - ((long) b.Start.Y - (long) a.Start.Y) * (long) delta2.X;
      if (num1 > 0L)
      {
        if (num2 < 0L || num2 > num1)
        {
          intersection1 = Point2D.NaN;
          intersection2 = Point2D.NaN;
          return 0;
        }
      }
      else if (num2 > 0L || num2 < num1)
      {
        intersection1 = Point2D.NaN;
        intersection2 = Point2D.NaN;
        return 0;
      }
      long num3 = ((long) b.Start.X - (long) a.Start.X) * (long) delta1.Y - ((long) b.Start.Y - (long) a.Start.Y) * (long) delta1.X;
      if (num1 > 0L)
      {
        if (num3 < 0L || num3 > num1)
        {
          intersection1 = Point2D.NaN;
          intersection2 = Point2D.NaN;
          return 0;
        }
      }
      else if (num3 > 0L || num3 < num1)
      {
        intersection1 = Point2D.NaN;
        intersection2 = Point2D.NaN;
        return 0;
      }
      intersection1 = new Point2D((double) a.start.X + (double) num2 * (double) delta1.X / (double) num1, (double) a.start.Y + (double) num2 * (double) delta1.Y / (double) num1);
      intersection2 = Point2D.NaN;
      return 1;
    }

    public static bool Intersects(Segment2I a, Segment2I b)
    {
      Vector2I delta1 = a.GetDelta();
      Vector2I delta2 = b.GetDelta();
      long num1 = (long) (delta1.X * delta2.Y - delta1.Y * delta2.X);
      if (num1 == 0L)
      {
        Segment2I.Struct2 struct2_1 = new Segment2I.Struct2(a.start, a.end, delta1);
        Segment2I.Struct2 struct2_2 = new Segment2I.Struct2(b.start, b.end, delta2);
        if ((struct2_1.long_0 > struct2_2.long_0 ? (!struct2_1.method_0(b.start) ? 0 : (struct2_1.method_0(b.End) ? 1 : 0)) : (struct2_2.long_0 == 0L || !struct2_2.method_0(a.start) ? 0 : (struct2_2.method_0(a.end) ? 1 : 0))) != 0)
        {
          if (struct2_1.method_1(b.start))
          {
            if (struct2_1.method_1(b.end) || struct2_2.method_1(a.start) || struct2_2.method_1(a.End))
              return true;
          }
          else if (struct2_1.method_1(b.end))
          {
            if (struct2_2.method_1(a.start) || struct2_2.method_1(a.End))
              return true;
          }
          else if (struct2_2.method_1(a.start))
            return true;
        }
        return false;
      }
      long num2 = (long) ((b.Start.X - a.Start.X) * delta2.Y - (b.Start.Y - a.Start.Y) * delta2.X);
      if (num1 > 0L)
      {
        if (num2 < 0L || num2 > num1)
          return false;
      }
      else if (num2 > 0L || num2 < num1)
        return false;
      long num3 = (long) ((b.Start.X - a.Start.X) * delta1.Y - (b.Start.Y - a.Start.Y) * delta1.X);
      if (num1 > 0L)
      {
        if (num3 < 0L || num3 > num1)
          return false;
      }
      else if (num3 > 0L || num3 < num1)
        return false;
      return true;
    }

    public bool Contains(Point2I point)
    {
      if (point.X > System.Math.Max(this.start.X, this.end.X) || point.X < System.Math.Min(this.start.X, this.end.X) || (point.Y > System.Math.Max(this.start.Y, this.end.Y) || point.Y < System.Math.Min(this.start.Y, this.end.Y)))
        return false;
      if (this.start == this.end)
        return true;
      Vector2I delta = this.GetDelta();
      Vector2I u = point - this.start;
      Vector2I v = new Vector2I(-delta.Y, delta.X);
      if (Vector2I.DotProduct(u, v) != 0L)
        return false;
      long num = Vector2I.DotProduct(u, delta);
      if (num < 0L)
        return false;
      long lengthSquared = delta.GetLengthSquared();
      return num <= lengthSquared;
    }

    public LongRational? GetNormalizedProjection(Point2I point)
    {
      if (this.start == this.end)
        return new LongRational?();
      Vector2I delta = this.GetDelta();
      return new LongRational?(new LongRational(Vector2I.DotProduct(point - this.start, delta), delta.GetLengthSquared()));
    }

    public bool ContainsProjection(Point2I point)
    {
      Vector2I delta = this.GetDelta();
      long num = Vector2I.DotProduct(point - this.start, delta);
      if (num < 0L)
        return false;
      long lengthSquared = delta.GetLengthSquared();
      return num * num <= lengthSquared;
    }

    public override string ToString()
    {
      return string.Format("start: {0}, end: {1}", (object) this.start.ToString(), (object) this.end.ToString());
    }

    public override int GetHashCode()
    {
      return this.start.GetHashCode() ^ this.end.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      if (obj is Segment2I)
        return this == (Segment2I) obj;
      return false;
    }

    public static bool operator ==(Segment2I a, Segment2I b)
    {
      if (a.Start == b.Start)
        return a.End == b.End;
      return false;
    }

    public static bool operator !=(Segment2I a, Segment2I b)
    {
      if (a.Start == b.End)
        return !(a.Start == b.End);
      return true;
    }

    internal struct Struct2
    {
      public Point2I point2I_0;
      public Point2I point2I_1;
      public Vector2I vector2I_0;
      public long long_0;

      public Struct2(Point2I start, Point2I end, Vector2I delta)
      {
        this.point2I_0 = start;
        this.point2I_1 = end;
        this.vector2I_0 = delta;
        this.long_0 = this.vector2I_0.GetLengthSquared();
      }

      public bool method_0(Point2I p)
      {
        return Vector2I.DotProduct(p - this.point2I_0, new Vector2I(-this.vector2I_0.Y, this.vector2I_0.X)) == 0L;
      }

      public bool method_1(Point2I point)
      {
        long num = Vector2I.DotProduct(point - this.point2I_0, this.vector2I_0);
        if (num >= 0L)
          return num <= this.long_0;
        return false;
      }
    }
  }
}
