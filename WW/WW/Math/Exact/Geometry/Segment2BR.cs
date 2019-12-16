// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Segment2BR
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Diagnostics;

namespace WW.Math.Exact.Geometry
{
  public struct Segment2BR
  {
    private Point2BR point2BR_0;
    private Point2BR point2BR_1;

    [DebuggerStepThrough]
    public Segment2BR(Point2BR start, Point2BR end)
    {
      this.point2BR_0 = start;
      this.point2BR_1 = end;
    }

    [DebuggerStepThrough]
    public Segment2BR(BigRational startx, BigRational starty, BigRational endx, BigRational endy)
    {
      this.point2BR_0 = new Point2BR(startx, starty);
      this.point2BR_1 = new Point2BR(endx, endy);
    }

    [DebuggerStepThrough]
    public Segment2BR(double startx, double starty, double endx, double endy)
    {
      this.point2BR_0 = new Point2BR(startx, starty);
      this.point2BR_1 = new Point2BR(endx, endy);
    }

    public Point2BR Start
    {
      get
      {
        return this.point2BR_0;
      }
      set
      {
        this.point2BR_0 = value;
      }
    }

    public Point2BR End
    {
      get
      {
        return this.point2BR_1;
      }
      set
      {
        this.point2BR_1 = value;
      }
    }

    public Point2BR GetCenter()
    {
      return Point2BR.GetMidPoint(this.point2BR_0, this.point2BR_1);
    }

    public Vector2BR GetDelta()
    {
      return this.point2BR_1 - this.point2BR_0;
    }

    public static bool GetIntersectionParameters(
      Segment2BR a,
      Segment2BR b,
      out BigRational[] pArray,
      out BigRational[] qArray)
    {
      Vector2BR delta1 = a.GetDelta();
      Vector2BR delta2 = b.GetDelta();
      BigRational bigRational1 = delta1.X * delta2.Y - delta1.Y * delta2.X;
      if (bigRational1.IsZero)
      {
        Segment2BR.Struct6 struct6_1 = new Segment2BR.Struct6(a.point2BR_0, a.point2BR_1, delta1);
        Segment2BR.Struct6 struct6_2 = new Segment2BR.Struct6(b.point2BR_0, b.point2BR_1, delta2);
        if ((struct6_1.bigRational_0 > struct6_2.bigRational_0 ? (!struct6_1.method_0(b.point2BR_0) ? 0 : (struct6_1.method_0(b.End) ? 1 : 0)) : (struct6_2.bigRational_0.IsZero || !struct6_2.method_0(a.point2BR_0) ? 0 : (struct6_2.method_0(a.point2BR_1) ? 1 : 0))) != 0)
        {
          if (struct6_1.method_1(b.point2BR_0))
          {
            if (struct6_1.method_1(b.point2BR_1))
            {
              pArray = new BigRational[2]
              {
                a.GetNormalizedProjection(b.point2BR_0),
                a.GetNormalizedProjection(b.point2BR_1)
              };
              qArray = new BigRational[2]
              {
                BigRational.Zero,
                BigRational.One
              };
              return true;
            }
            if (struct6_2.method_1(a.point2BR_0))
            {
              pArray = new BigRational[2]
              {
                BigRational.Zero,
                a.GetNormalizedProjection(b.point2BR_0)
              };
              qArray = new BigRational[2]
              {
                b.GetNormalizedProjection(a.point2BR_0),
                BigRational.Zero
              };
              return true;
            }
            if (struct6_2.method_1(a.End))
            {
              pArray = new BigRational[2]
              {
                a.GetNormalizedProjection(b.point2BR_0),
                BigRational.One
              };
              qArray = new BigRational[2]
              {
                BigRational.Zero,
                b.GetNormalizedProjection(a.point2BR_1)
              };
              return true;
            }
          }
          else if (struct6_1.method_1(b.point2BR_1))
          {
            if (struct6_2.method_1(a.point2BR_0))
            {
              if (struct6_2.method_1(a.End))
              {
                pArray = new BigRational[2]
                {
                  BigRational.Zero,
                  BigRational.One
                };
                qArray = new BigRational[2]
                {
                  b.GetNormalizedProjection(a.point2BR_0),
                  b.GetNormalizedProjection(a.point2BR_1)
                };
              }
              else
              {
                pArray = new BigRational[2]
                {
                  BigRational.Zero,
                  a.GetNormalizedProjection(b.point2BR_1)
                };
                qArray = new BigRational[2]
                {
                  b.GetNormalizedProjection(a.point2BR_0),
                  BigRational.One
                };
              }
              return true;
            }
            if (struct6_2.method_1(a.End))
            {
              pArray = new BigRational[2]
              {
                BigRational.One,
                a.GetNormalizedProjection(b.point2BR_1)
              };
              qArray = new BigRational[2]
              {
                b.GetNormalizedProjection(a.point2BR_1),
                BigRational.One
              };
              return true;
            }
          }
          else if (struct6_2.method_1(a.point2BR_0))
          {
            pArray = new BigRational[2]
            {
              BigRational.Zero,
              BigRational.One
            };
            qArray = new BigRational[2]
            {
              b.GetNormalizedProjection(a.point2BR_0),
              b.GetNormalizedProjection(a.point2BR_1)
            };
            return true;
          }
        }
        pArray = (BigRational[]) null;
        qArray = (BigRational[]) null;
        return false;
      }
      BigRational bigRational2 = (b.Start.X - a.Start.X) * delta2.Y - (b.Start.Y - a.Start.Y) * delta2.X;
      if (bigRational1.IsPositive)
      {
        if (bigRational2.IsNegative || bigRational2 > bigRational1)
        {
          pArray = (BigRational[]) null;
          qArray = (BigRational[]) null;
          return false;
        }
      }
      else if (bigRational2.IsPositive || bigRational2 < bigRational1)
      {
        pArray = (BigRational[]) null;
        qArray = (BigRational[]) null;
        return false;
      }
      BigRational bigRational3 = (b.Start.X - a.Start.X) * delta1.Y - (b.Start.Y - a.Start.Y) * delta1.X;
      if (bigRational1.IsPositive)
      {
        if (bigRational3.IsNegative || bigRational3 > bigRational1)
        {
          pArray = (BigRational[]) null;
          qArray = (BigRational[]) null;
          return false;
        }
      }
      else if (bigRational3.IsPositive || bigRational3 < bigRational1)
      {
        pArray = (BigRational[]) null;
        qArray = (BigRational[]) null;
        return false;
      }
      BigRational bigRational4 = bigRational2 / bigRational1;
      BigRational bigRational5 = bigRational3 / bigRational1;
      pArray = new BigRational[1]{ bigRational4 };
      qArray = new BigRational[1]{ bigRational5 };
      return true;
    }

    public static bool Intersects(Segment2BR segment1, Segment2BR segment2)
    {
      if (segment1.point2BR_0 == segment1.point2BR_1)
        return segment2.Contains(segment1.point2BR_0);
      Vector2BR v1 = segment1.point2BR_1 - segment1.point2BR_0;
      Vector2BR u1 = segment2.Start - segment1.point2BR_0;
      Vector2BR u2 = segment2.End - segment1.point2BR_0;
      Vector2BR v2 = new Vector2BR(-v1.Y, v1.X);
      BigRational bigRational1 = Vector2BR.DotProduct(u1, v2);
      BigRational bigRational2 = Vector2BR.DotProduct(u2, v2);
      if (bigRational1.IsPositive && bigRational2.IsPositive || bigRational1.IsNegative && bigRational2.IsNegative)
        return false;
      BigRational a = Vector2BR.DotProduct(u1, v1);
      BigRational b = Vector2BR.DotProduct(u2, v1);
      BigRational bigRational3 = b - a;
      if (bigRational3.IsZero)
      {
        BigRational bigRational4 = a;
        if (bigRational4.IsNegative)
          return false;
        return bigRational4.Square() <= v1.GetLengthSquared();
      }
      BigRational bigRational5 = bigRational2 - bigRational1;
      if (bigRational5.IsZero)
      {
        if (BigMath.Max(a, b).IsNegative)
          return false;
        return BigMath.Min(a, b).Square() <= v1.GetLengthSquared();
      }
      BigRational bigRational6 = bigRational3 / bigRational5;
      BigRational bigRational7 = a - bigRational1 * bigRational6;
      if (bigRational7.IsNegative)
        return false;
      return bigRational7.Square() < v1.GetLengthSquared();
    }

    public bool Contains(Point2BR point)
    {
      if (point.X > BigMath.Max(this.point2BR_0.X, this.point2BR_1.X) || point.X < BigMath.Min(this.point2BR_0.X, this.point2BR_1.X) || (point.Y > BigMath.Max(this.point2BR_0.Y, this.point2BR_1.Y) || point.Y < BigMath.Min(this.point2BR_0.Y, this.point2BR_1.Y)))
        return false;
      if (this.point2BR_0 == this.point2BR_1)
        return true;
      Vector2BR delta = this.GetDelta();
      Vector2BR u = point - this.point2BR_0;
      Vector2BR v = new Vector2BR(-delta.Y, delta.X);
      if (!Vector2BR.DotProduct(u, v).IsZero)
        return false;
      BigRational bigRational = Vector2BR.DotProduct(u, delta);
      if (bigRational.IsNegative)
        return false;
      BigRational lengthSquared = delta.GetLengthSquared();
      return !(bigRational > lengthSquared);
    }

    public BigRational GetDistanceSquared(Point2BR point)
    {
      Vector2BR u = point - this.point2BR_0;
      Vector2BR v = this.point2BR_1 - this.point2BR_0;
      BigRational lengthSquared = v.GetLengthSquared();
      BigRational bigRational = Vector2BR.DotProduct(u, v);
      return bigRational.IsNegative || !(bigRational <= lengthSquared) ? (!bigRational.IsNegative ? (this.point2BR_1 - point).GetLengthSquared() : (this.point2BR_0 - point).GetLengthSquared()) : (bigRational / lengthSquared * v + this.point2BR_0 - point).GetLengthSquared();
    }

    public Point2BR GetClosestPoint(Point2BR point)
    {
      Vector2BR u = point - this.point2BR_0;
      Vector2BR v = this.point2BR_1 - this.point2BR_0;
      BigRational lengthSquared = v.GetLengthSquared();
      BigRational bigRational = Vector2BR.DotProduct(u, v);
      return bigRational.IsNegative || !(bigRational <= lengthSquared) ? (bigRational.IsNegative ? this.point2BR_0 : this.point2BR_1) : bigRational / lengthSquared * v + this.point2BR_0;
    }

    public BigRational GetNormalizedProjection(Point2BR point)
    {
      if (this.point2BR_0 == this.point2BR_1)
        return BigRational.NaN;
      Vector2BR delta = this.GetDelta();
      return Vector2BR.DotProduct(point - this.point2BR_0, delta) / delta.GetLengthSquared();
    }

    public bool ContainsProjection(Point2BR point)
    {
      Vector2BR delta = this.GetDelta();
      BigRational bigRational = Vector2BR.DotProduct(point - this.point2BR_0, delta);
      if (bigRational.IsNegative)
        return false;
      BigRational lengthSquared = delta.GetLengthSquared();
      return !(bigRational.Square() > lengthSquared);
    }

    public override string ToString()
    {
      return string.Format("start: {0}, end: {1}", (object) this.point2BR_0.ToString(), (object) this.point2BR_1.ToString());
    }

    public override int GetHashCode()
    {
      return this.point2BR_0.GetHashCode() ^ this.point2BR_1.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      if (obj is Segment2BR)
        return this == (Segment2BR) obj;
      return false;
    }

    public static bool operator ==(Segment2BR a, Segment2BR b)
    {
      if (a.Start == b.Start)
        return a.End == b.End;
      return false;
    }

    public static bool operator !=(Segment2BR a, Segment2BR b)
    {
      if (a.Start == b.End)
        return !(a.Start == b.End);
      return true;
    }

    internal struct Struct6
    {
      public Point2BR point2BR_0;
      public Point2BR point2BR_1;
      public Vector2BR vector2BR_0;
      public BigRational bigRational_0;

      public Struct6(Point2BR start, Point2BR end, Vector2BR delta)
      {
        this.point2BR_0 = start;
        this.point2BR_1 = end;
        this.vector2BR_0 = delta;
        this.bigRational_0 = this.vector2BR_0.GetLengthSquared();
      }

      public bool method_0(Point2BR p)
      {
        return Vector2BR.DotProduct(p - this.point2BR_0, new Vector2BR(-this.vector2BR_0.Y, this.vector2BR_0.X)).IsZero;
      }

      public bool method_1(Point2BR point)
      {
        BigRational bigRational = Vector2BR.DotProduct(point - this.point2BR_0, this.vector2BR_0);
        if (!bigRational.IsNegative)
          return bigRational <= this.bigRational_0;
        return false;
      }
    }
  }
}
