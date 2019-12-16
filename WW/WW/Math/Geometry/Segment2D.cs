// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Segment2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Diagnostics;

namespace WW.Math.Geometry
{
  [Serializable]
  public struct Segment2D : IShape2D
  {
    private Point2D start;
    private Point2D end;

    [DebuggerStepThrough]
    public Segment2D(Point2D start, Point2D end)
    {
      this.start = start;
      this.end = end;
    }

    [DebuggerStepThrough]
    public Segment2D(double startx, double starty, double endx, double endy)
    {
      this.start = new Point2D(startx, starty);
      this.end = new Point2D(endx, endy);
    }

    public Point2D Start
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

    public Point2D End
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

    public Point2D GetCenter()
    {
      return new Point2D(0.5 * (this.start.X + this.end.X), 0.5 * (this.start.Y + this.end.Y));
    }

    public Vector2D GetDelta()
    {
      return this.end - this.start;
    }

    public double GetLength()
    {
      return (this.end - this.start).GetLength();
    }

    public static bool GetIntersectionParameters(
      Segment2D a,
      Segment2D b,
      out double[] pArray,
      out double[] qArray)
    {
      return Segment2D.GetIntersectionParameters(a, b, out pArray, out qArray, 8.88178419700125E-16);
    }

    public static bool GetIntersectionParameters(
      Segment2D a,
      Segment2D b,
      out double[] pArray,
      out double[] qArray,
      double precision)
    {
      Segment2D.Struct10 struct10_1 = new Segment2D.Struct10(a.start, a.end, precision);
      Segment2D.Struct10 struct10_2 = new Segment2D.Struct10(b.start, b.end, precision);
      if ((struct10_1.double_0 > struct10_2.double_0 ? (!struct10_1.method_0(b.start) ? 0 : (struct10_1.method_0(b.End) ? 1 : 0)) : (struct10_2.double_0 == 0.0 || !struct10_2.method_0(a.start) ? 0 : (struct10_2.method_0(a.end) ? 1 : 0))) != 0)
      {
        struct10_1.method_1();
        struct10_2.method_1();
        if (struct10_1.method_2(b.start))
        {
          if (struct10_1.method_2(b.end))
          {
            pArray = new double[2]
            {
              a.GetNormalizedProjection(b.start),
              a.GetNormalizedProjection(b.end)
            };
            qArray = new double[2]{ 0.0, 1.0 };
            return true;
          }
          if (struct10_2.method_2(a.start))
          {
            if (struct10_2.method_2(a.end))
            {
              pArray = new double[2]{ 0.0, 1.0 };
              qArray = new double[2]
              {
                0.0,
                b.GetNormalizedProjection(a.end)
              };
            }
            else
            {
              pArray = new double[2]
              {
                0.0,
                a.GetNormalizedProjection(b.start)
              };
              qArray = new double[2]
              {
                b.GetNormalizedProjection(a.start),
                0.0
              };
            }
            return true;
          }
          if (struct10_2.method_2(a.End))
          {
            pArray = new double[2]
            {
              a.GetNormalizedProjection(b.start),
              1.0
            };
            qArray = new double[2]
            {
              0.0,
              b.GetNormalizedProjection(a.end)
            };
            return true;
          }
        }
        else if (struct10_1.method_2(b.end))
        {
          if (struct10_2.method_2(a.start))
          {
            if (struct10_2.method_2(a.End))
            {
              pArray = new double[2]{ 0.0, 1.0 };
              qArray = new double[2]
              {
                b.GetNormalizedProjection(a.start),
                b.GetNormalizedProjection(a.end)
              };
            }
            else
            {
              pArray = new double[2]
              {
                0.0,
                a.GetNormalizedProjection(b.end)
              };
              qArray = new double[2]
              {
                b.GetNormalizedProjection(a.start),
                1.0
              };
            }
            return true;
          }
          if (struct10_2.method_2(a.End))
          {
            pArray = new double[2]
            {
              1.0,
              a.GetNormalizedProjection(b.end)
            };
            qArray = new double[2]
            {
              b.GetNormalizedProjection(a.end),
              1.0
            };
            return true;
          }
        }
        else if (struct10_2.method_2(a.start))
        {
          pArray = new double[2]{ 0.0, 1.0 };
          qArray = new double[2]
          {
            b.GetNormalizedProjection(a.start),
            b.GetNormalizedProjection(a.end)
          };
          return true;
        }
      }
      Vector2D vector2D0_1 = struct10_1.vector2D_0;
      Vector2D vector2D0_2 = struct10_2.vector2D_0;
      double num1 = vector2D0_1.X * vector2D0_2.Y - vector2D0_1.Y * vector2D0_2.X;
      double num2 = precision * precision;
      if (System.Math.Abs(num1) < num2)
      {
        pArray = (double[]) null;
        qArray = (double[]) null;
        return false;
      }
      bool flag;
      double num3 = (flag = num1 < 0.0) ? -num1 : num1;
      double num4 = (b.Start.X - a.Start.X) * vector2D0_2.Y - (b.Start.Y - a.Start.Y) * vector2D0_2.X;
      if (flag)
        num4 = -num4;
      if (num4 >= -num2 && num4 - num3 <= num2)
      {
        double num5 = (b.Start.X - a.Start.X) * vector2D0_1.Y - (b.Start.Y - a.Start.Y) * vector2D0_1.X;
        if (flag)
          num5 = -num5;
        if (num5 >= -num2 && num5 - num3 <= num2)
        {
          double num6 = 1.0 / num3;
          double num7 = num4 * num6;
          double num8 = 1.0 + precision;
          if (num7 >= -precision && num7 <= num8)
          {
            double num9 = num5 * num6;
            if (num9 >= -precision && num9 <= num8)
            {
              pArray = new double[1]{ num7 };
              qArray = new double[1]{ num9 };
              return true;
            }
            pArray = (double[]) null;
            qArray = (double[]) null;
            return false;
          }
          pArray = (double[]) null;
          qArray = (double[]) null;
          return false;
        }
        pArray = (double[]) null;
        qArray = (double[]) null;
        return false;
      }
      pArray = (double[]) null;
      qArray = (double[]) null;
      return false;
    }

    public static bool Intersects(Segment2D segment1, Segment2D segment2)
    {
      bool areOverlapping;
      return Segment2D.Intersects(segment1, segment2, out areOverlapping);
    }

    public static bool Intersects(Segment2D segment1, Segment2D segment2, out bool areOverlapping)
    {
      Vector2D v1 = segment1.end - segment1.start;
      Vector2D u1 = segment2.Start - segment1.start;
      Vector2D u2 = segment2.End - segment1.start;
      Vector2D v2 = new Vector2D(-v1.Y, v1.X);
      double num1 = Vector2D.DotProduct(u1, v2);
      double num2 = Vector2D.DotProduct(u2, v2);
      if (num1 > 0.0 && num2 > 0.0 || num1 < 0.0 && num2 < 0.0)
      {
        areOverlapping = false;
        return false;
      }
      double val1 = Vector2D.DotProduct(u1, v1);
      double val2 = Vector2D.DotProduct(u2, v1);
      double num3 = val2 - val1;
      if (num3 == 0.0)
      {
        areOverlapping = false;
        if (num1 == 0.0 || num2 == 0.0)
          return false;
        double num4 = val1;
        if (num4 > 0.0)
          return num4 < v1.GetLengthSquared();
        return false;
      }
      double num5 = num2 - num1;
      if (num5 == 0.0)
      {
        areOverlapping = true;
        double num4 = System.Math.Min(val1, val2);
        if (System.Math.Max(val1, val2) > 0.0)
          return num4 < v1.GetLengthSquared();
        return false;
      }
      areOverlapping = false;
      if (num1 == 0.0 || num2 == 0.0)
        return false;
      double num6 = val1 * num5 - num1 * num3;
      if (num5 > 0.0)
      {
        if (num6 > 0.0)
          return num6 < num5 * v1.GetLengthSquared();
        return false;
      }
      if (num6 < 0.0)
        return num6 > num5 * v1.GetLengthSquared();
      return false;
    }

    public static bool IntersectsInclusive(Segment2D segment1, Segment2D segment2)
    {
      bool areOverlapping;
      return Segment2D.IntersectsInclusive(segment1, segment2, out areOverlapping);
    }

    public static bool IntersectsInclusive(
      Segment2D segment1,
      Segment2D segment2,
      out bool areOverlapping)
    {
      Vector2D v1 = segment1.end - segment1.start;
      Vector2D u1 = segment2.Start - segment1.start;
      Vector2D u2 = segment2.End - segment1.start;
      Vector2D v2 = new Vector2D(-v1.Y, v1.X);
      double num1 = Vector2D.DotProduct(u1, v2);
      double num2 = Vector2D.DotProduct(u2, v2);
      if (num1 > 0.0 && num2 > 0.0 || num1 < 0.0 && num2 < 0.0)
      {
        areOverlapping = false;
        return false;
      }
      double val1 = Vector2D.DotProduct(u1, v1);
      double val2 = Vector2D.DotProduct(u2, v1);
      double num3 = val2 - val1;
      if (num3 == 0.0)
      {
        double num4 = val1;
        areOverlapping = false;
        if (num4 >= 0.0)
          return num4 <= v1.GetLengthSquared();
        return false;
      }
      double num5 = num2 - num1;
      if (num5 == 0.0)
      {
        areOverlapping = true;
        double num4 = System.Math.Min(val1, val2);
        if (System.Math.Max(val1, val2) >= 0.0)
          return num4 <= v1.GetLengthSquared();
        return false;
      }
      areOverlapping = false;
      double num6 = val1 * num5 - num1 * num3;
      if (num5 > 0.0)
      {
        if (num6 >= 0.0)
          return num6 <= num5 * v1.GetLengthSquared();
        return false;
      }
      if (num6 <= 0.0)
        return num6 >= num5 * v1.GetLengthSquared();
      return false;
    }

    public bool Contains(Point2D point)
    {
      return this.Contains(point, 8.88178419700125E-16);
    }

    public bool Contains(Point2D point, double precision)
    {
      if (point.X > System.Math.Max(this.start.X, this.end.X) + precision || point.X < System.Math.Min(this.start.X, this.end.X) - precision || (point.Y > System.Math.Max(this.start.Y, this.end.Y) + precision || point.Y < System.Math.Min(this.start.Y, this.end.Y) - precision))
        return false;
      if (Point2D.AreApproxEqual(this.start, this.end, precision))
        return true;
      Vector2D delta = this.GetDelta();
      double lengthSquared = delta.GetLengthSquared();
      double num1 = precision * precision * lengthSquared;
      Vector2D u = point - this.start;
      Vector2D v = new Vector2D(-delta.Y, delta.X);
      double num2 = Vector2D.DotProduct(u, v);
      if (num2 * num2 > num1)
        return false;
      double num3 = Vector2D.DotProduct(u, delta);
      if (num3 < 0.0 && num3 * num3 > num1)
        return false;
      double num4 = System.Math.Abs(num3);
      if (num4 > lengthSquared)
      {
        double num5 = System.Math.Sqrt(lengthSquared);
        if (num4 > num5 * (num5 + precision))
          return false;
      }
      return true;
    }

    public double GetDistance(Point2D point)
    {
      return System.Math.Sqrt(this.GetDistanceSquared(point));
    }

    public double GetDistanceSquared(Point2D point)
    {
      Vector2D u = point - this.start;
      Vector2D v = this.end - this.start;
      double lengthSquared = v.GetLengthSquared();
      double num = Vector2D.DotProduct(u, v);
      return num <= 0.0 || num >= lengthSquared ? (num > 0.0 ? (this.end - point).GetLengthSquared() : (this.start - point).GetLengthSquared()) : (num / lengthSquared * v + this.start - point).GetLengthSquared();
    }

    public Point2D GetClosestPoint(Point2D point)
    {
      Vector2D u = point - this.start;
      Vector2D v = this.end - this.start;
      double lengthSquared = v.GetLengthSquared();
      double num = Vector2D.DotProduct(u, v);
      return num <= 0.0 || num >= lengthSquared ? (num <= 0.0 ? this.start : this.end) : num / lengthSquared * v + this.start;
    }

    public double GetNormalizedProjection(Point2D point)
    {
      if (this.start == this.end)
        return double.NaN;
      Vector2D delta = this.GetDelta();
      return Vector2D.DotProduct(point - this.start, delta) / delta.GetLengthSquared();
    }

    public double GetProjection(Point2D point)
    {
      Vector2D unit = this.GetDelta().GetUnit();
      return Vector2D.DotProduct(point - this.start, unit);
    }

    public bool ContainsProjection(Point2D point)
    {
      return this.ContainsProjection(point, 8.88178419700125E-16);
    }

    public bool ContainsProjection(Point2D point, double precision)
    {
      Vector2D delta = this.GetDelta();
      double num = Vector2D.DotProduct(point - this.start, delta);
      double length = delta.GetLength();
      if (num >= -(precision * length))
        return num <= (length + precision) * length;
      return false;
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
      if (obj is Segment2D)
        return this == (Segment2D) obj;
      return false;
    }

    public ISegment2DIterator CreateIterator()
    {
      return (ISegment2DIterator) new Segment2D.Class185(this);
    }

    public void AddToBounds(Bounds2D bounds)
    {
      bounds.Update(this.start);
      bounds.Update(this.end);
    }

    public bool HasSegments
    {
      get
      {
        return true;
      }
    }

    public static bool operator ==(Segment2D a, Segment2D b)
    {
      if (a.Start == b.Start)
        return a.End == b.End;
      return false;
    }

    public static bool operator !=(Segment2D a, Segment2D b)
    {
      if (a.Start == b.End)
        return !(a.Start == b.End);
      return true;
    }

    internal struct Struct10
    {
      public Point2D point2D_0;
      public Point2D point2D_1;
      public Vector2D vector2D_0;
      public double double_0;
      public double double_1;
      public double double_2;
      public double double_3;
      public double double_4;

      public Struct10(Point2D start, Point2D end, double precision)
      {
        this.point2D_0 = start;
        this.point2D_1 = end;
        this.vector2D_0 = end - start;
        this.double_0 = this.vector2D_0.GetLengthSquared();
        this.double_1 = precision;
        this.double_2 = precision * precision * this.double_0;
        this.double_3 = 0.0;
        this.double_4 = 0.0;
      }

      public bool method_0(Point2D p)
      {
        double num = Vector2D.DotProduct(p - this.point2D_0, new Vector2D(-this.vector2D_0.Y, this.vector2D_0.X));
        return num * num <= this.double_2;
      }

      public void method_1()
      {
        this.double_3 = System.Math.Sqrt(this.double_0);
        this.double_4 = this.double_1 * this.double_3;
      }

      public bool method_2(Point2D point)
      {
        double num = Vector2D.DotProduct(point - this.point2D_0, this.vector2D_0);
        if (num >= -this.double_4)
          return num <= this.double_0 + this.double_4;
        return false;
      }
    }

    private class Class185 : ISegment2DIterator
    {
      private static readonly SegmentType[] segmentType_0 = new SegmentType[2]{ SegmentType.MoveTo, SegmentType.LineTo };
      private int int_0 = -1;
      private readonly Point2D[] point2D_0;

      public Class185(Segment2D segment)
      {
        this.point2D_0 = new Point2D[2]
        {
          segment.Start,
          segment.End
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
          return Segment2D.Class185.segmentType_0[this.int_0];
        }
      }

      public SegmentType Current(Point2D[] points, int offset)
      {
        points[offset] = this.point2D_0[this.int_0];
        return Segment2D.Class185.segmentType_0[this.int_0];
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
