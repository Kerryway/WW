// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Segment2LR
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Diagnostics;

namespace WW.Math.Exact.Geometry
{
  [Serializable]
  public struct Segment2LR
  {
    private Point2LR start;
    private Point2LR end;

    [DebuggerStepThrough]
    public Segment2LR(Point2LR start, Point2LR end)
    {
      this.start = start;
      this.end = end;
    }

    [DebuggerStepThrough]
    public Segment2LR(
      LongRational startx,
      LongRational starty,
      LongRational endx,
      LongRational endy)
    {
      this.start = new Point2LR(startx, starty);
      this.end = new Point2LR(endx, endy);
    }

    [DebuggerStepThrough]
    public Segment2LR(double startx, double starty, double endx, double endy)
    {
      this.start = new Point2LR(startx, starty);
      this.end = new Point2LR(endx, endy);
    }

    public Point2LR Start
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

    public Point2LR End
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

    public Point2LR GetCenter()
    {
      return Point2LR.GetMidPoint(this.start, this.end);
    }

    public Vector2LR GetDelta()
    {
      return this.end - this.start;
    }

    public static bool GetIntersectionParameters(
      Segment2LR a,
      Segment2LR b,
      out LongRational[] pArray,
      out LongRational[] qArray)
    {
      Vector2LR delta1 = a.GetDelta();
      Vector2LR delta2 = b.GetDelta();
      LongRational longRational1 = delta1.X * delta2.Y - delta1.Y * delta2.X;
      if (longRational1.IsZero)
      {
        Segment2LR.Struct9 struct9_1 = new Segment2LR.Struct9(a.start, a.end, delta1);
        Segment2LR.Struct9 struct9_2 = new Segment2LR.Struct9(b.start, b.end, delta2);
        if ((struct9_1.longRational_0 > struct9_2.longRational_0 ? (!struct9_1.method_0(b.start) ? 0 : (struct9_1.method_0(b.End) ? 1 : 0)) : (struct9_2.longRational_0.IsZero || !struct9_2.method_0(a.start) ? 0 : (struct9_2.method_0(a.end) ? 1 : 0))) != 0)
        {
          if (struct9_1.method_1(b.start))
          {
            if (struct9_1.method_1(b.end))
            {
              pArray = new LongRational[2]
              {
                a.GetNormalizedProjection(b.start),
                a.GetNormalizedProjection(b.end)
              };
              qArray = new LongRational[2]
              {
                LongRational.Zero,
                LongRational.One
              };
              return true;
            }
            if (struct9_2.method_1(a.start))
            {
              pArray = new LongRational[2]
              {
                LongRational.Zero,
                a.GetNormalizedProjection(b.start)
              };
              qArray = new LongRational[2]
              {
                b.GetNormalizedProjection(a.start),
                LongRational.Zero
              };
              return true;
            }
            if (struct9_2.method_1(a.End))
            {
              pArray = new LongRational[2]
              {
                a.GetNormalizedProjection(b.start),
                LongRational.One
              };
              qArray = new LongRational[2]
              {
                LongRational.Zero,
                b.GetNormalizedProjection(a.end)
              };
              return true;
            }
          }
          else if (struct9_1.method_1(b.end))
          {
            if (struct9_2.method_1(a.start))
            {
              if (struct9_2.method_1(a.End))
              {
                pArray = new LongRational[2]
                {
                  LongRational.Zero,
                  LongRational.One
                };
                qArray = new LongRational[2]
                {
                  b.GetNormalizedProjection(a.start),
                  b.GetNormalizedProjection(a.end)
                };
              }
              else
              {
                pArray = new LongRational[2]
                {
                  LongRational.Zero,
                  a.GetNormalizedProjection(b.end)
                };
                qArray = new LongRational[2]
                {
                  b.GetNormalizedProjection(a.start),
                  LongRational.One
                };
              }
              return true;
            }
            if (struct9_2.method_1(a.End))
            {
              pArray = new LongRational[2]
              {
                LongRational.One,
                a.GetNormalizedProjection(b.end)
              };
              qArray = new LongRational[2]
              {
                b.GetNormalizedProjection(a.end),
                LongRational.One
              };
              return true;
            }
          }
          else if (struct9_2.method_1(a.start))
          {
            pArray = new LongRational[2]
            {
              LongRational.Zero,
              LongRational.One
            };
            qArray = new LongRational[2]
            {
              b.GetNormalizedProjection(a.start),
              b.GetNormalizedProjection(a.end)
            };
            return true;
          }
        }
        pArray = (LongRational[]) null;
        qArray = (LongRational[]) null;
        return false;
      }
      LongRational longRational2 = (b.Start.X - a.Start.X) * delta2.Y - (b.Start.Y - a.Start.Y) * delta2.X;
      if (longRational1.IsPositive)
      {
        if (longRational2.IsNegative || longRational2 > longRational1)
        {
          pArray = (LongRational[]) null;
          qArray = (LongRational[]) null;
          return false;
        }
      }
      else if (longRational2.IsPositive || longRational2 < longRational1)
      {
        pArray = (LongRational[]) null;
        qArray = (LongRational[]) null;
        return false;
      }
      LongRational longRational3 = (b.Start.X - a.Start.X) * delta1.Y - (b.Start.Y - a.Start.Y) * delta1.X;
      if (longRational1.IsPositive)
      {
        if (longRational3.IsNegative || longRational3 > longRational1)
        {
          pArray = (LongRational[]) null;
          qArray = (LongRational[]) null;
          return false;
        }
      }
      else if (longRational3.IsPositive || longRational3 < longRational1)
      {
        pArray = (LongRational[]) null;
        qArray = (LongRational[]) null;
        return false;
      }
      LongRational longRational4 = longRational2 / longRational1;
      LongRational longRational5 = longRational3 / longRational1;
      pArray = new LongRational[1]{ longRational4 };
      qArray = new LongRational[1]{ longRational5 };
      return true;
    }

    public static bool Intersects(Segment2LR a, Segment2LR b)
    {
      Vector2LR delta1 = a.GetDelta();
      Vector2LR delta2 = b.GetDelta();
      LongRational longRational1 = delta1.X * delta2.Y - delta1.Y * delta2.X;
      if (longRational1.IsZero)
      {
        Segment2LR.Struct9 struct9_1 = new Segment2LR.Struct9(a.start, a.end, delta1);
        Segment2LR.Struct9 struct9_2 = new Segment2LR.Struct9(b.start, b.end, delta2);
        if ((struct9_1.longRational_0 > struct9_2.longRational_0 ? (!struct9_1.method_0(b.start) ? 0 : (struct9_1.method_0(b.End) ? 1 : 0)) : (struct9_2.longRational_0.IsZero || !struct9_2.method_0(a.start) ? 0 : (struct9_2.method_0(a.end) ? 1 : 0))) != 0)
        {
          if (struct9_1.method_1(b.start))
          {
            if (struct9_1.method_1(b.end) || struct9_2.method_1(a.start) || struct9_2.method_1(a.End))
              return true;
          }
          else if (struct9_1.method_1(b.end))
          {
            if (struct9_2.method_1(a.start) || struct9_2.method_1(a.End))
              return true;
          }
          else if (struct9_2.method_1(a.start))
            return true;
        }
        return false;
      }
      LongRational longRational2 = (b.Start.X - a.Start.X) * delta2.Y - (b.Start.Y - a.Start.Y) * delta2.X;
      if (longRational1.IsPositive)
      {
        if (longRational2.IsNegative || longRational2 > longRational1)
          return false;
      }
      else if (longRational2.IsPositive || longRational2 < longRational1)
        return false;
      LongRational longRational3 = (b.Start.X - a.Start.X) * delta1.Y - (b.Start.Y - a.Start.Y) * delta1.X;
      if (longRational1.IsPositive)
      {
        if (longRational3.IsNegative || longRational3 > longRational1)
          return false;
      }
      else if (longRational3.IsPositive || longRational3 < longRational1)
        return false;
      return true;
    }

    public bool Contains(Point2LR point)
    {
      if (point.X > LongRational.Max(this.start.X, this.end.X) || point.X < LongRational.Min(this.start.X, this.end.X) || (point.Y > LongRational.Max(this.start.Y, this.end.Y) || point.Y < LongRational.Min(this.start.Y, this.end.Y)))
        return false;
      if (this.start == this.end)
        return true;
      Vector2LR delta = this.GetDelta();
      Vector2LR u = point - this.start;
      Vector2LR v = new Vector2LR(-delta.Y, delta.X);
      if (!Vector2LR.DotProduct(u, v).IsZero)
        return false;
      LongRational longRational = Vector2LR.DotProduct(u, delta);
      if (longRational.IsNegative)
        return false;
      LongRational lengthSquared = delta.GetLengthSquared();
      return !(longRational > lengthSquared);
    }

    public LongRational GetDistanceSquared(Point2LR point)
    {
      Vector2LR u = point - this.start;
      Vector2LR v = this.end - this.start;
      LongRational lengthSquared = v.GetLengthSquared();
      LongRational longRational = Vector2LR.DotProduct(u, v);
      return longRational.IsNegative || !(longRational <= lengthSquared) ? (!longRational.IsNegative ? (this.end - point).GetLengthSquared() : (this.start - point).GetLengthSquared()) : (longRational / lengthSquared * v + this.start - point).GetLengthSquared();
    }

    public Point2LR GetClosestPoint(Point2LR point)
    {
      Vector2LR u = point - this.start;
      Vector2LR v = this.end - this.start;
      LongRational lengthSquared = v.GetLengthSquared();
      LongRational longRational = Vector2LR.DotProduct(u, v);
      return longRational.IsNegative || !(longRational <= lengthSquared) ? (longRational.IsNegative ? this.start : this.end) : longRational / lengthSquared * v + this.start;
    }

    public LongRational GetNormalizedProjection(Point2LR point)
    {
      if (this.start == this.end)
        return LongRational.NaN;
      Vector2LR delta = this.GetDelta();
      return Vector2LR.DotProduct(point - this.start, delta) / delta.GetLengthSquared();
    }

    public bool ContainsProjection(Point2LR point)
    {
      Vector2LR delta = this.GetDelta();
      LongRational longRational = Vector2LR.DotProduct(point - this.start, delta);
      if (longRational.IsNegative)
        return false;
      LongRational lengthSquared = delta.GetLengthSquared();
      return !(longRational.Square() > lengthSquared);
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
      if (obj is Segment2LR)
        return this == (Segment2LR) obj;
      return false;
    }

    public static bool operator ==(Segment2LR a, Segment2LR b)
    {
      if (a.Start == b.Start)
        return a.End == b.End;
      return false;
    }

    public static bool operator !=(Segment2LR a, Segment2LR b)
    {
      if (a.Start == b.End)
        return !(a.Start == b.End);
      return true;
    }

    internal struct Struct9
    {
      public Point2LR point2LR_0;
      public Point2LR point2LR_1;
      public Vector2LR vector2LR_0;
      public LongRational longRational_0;

      public Struct9(Point2LR start, Point2LR end, Vector2LR delta)
      {
        this.point2LR_0 = start;
        this.point2LR_1 = end;
        this.vector2LR_0 = delta;
        this.longRational_0 = this.vector2LR_0.GetLengthSquared();
      }

      public bool method_0(Point2LR p)
      {
        return Vector2LR.DotProduct(p - this.point2LR_0, new Vector2LR(-this.vector2LR_0.Y, this.vector2LR_0.X)).IsZero;
      }

      public bool method_1(Point2LR point)
      {
        LongRational longRational = Vector2LR.DotProduct(point - this.point2LR_0, this.vector2LR_0);
        if (!longRational.IsNegative)
          return longRational <= this.longRational_0;
        return false;
      }
    }
  }
}
