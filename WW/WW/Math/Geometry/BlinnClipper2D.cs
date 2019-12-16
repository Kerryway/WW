// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.BlinnClipper2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math.Geometry
{
  public class BlinnClipper2D
  {
    private readonly BlinnClipper2D.IInsideTester[] iinsideTester_0;

    public BlinnClipper2D(Rectangle2D rectangle)
    {
      this.iinsideTester_0 = new BlinnClipper2D.IInsideTester[4];
      this.iinsideTester_0[0] = (BlinnClipper2D.IInsideTester) new BlinnClipper2D.Generic.LeftOf(rectangle.Corner2.X);
      this.iinsideTester_0[1] = (BlinnClipper2D.IInsideTester) new BlinnClipper2D.Generic.RightOf(rectangle.Corner1.X);
      this.iinsideTester_0[2] = (BlinnClipper2D.IInsideTester) new BlinnClipper2D.Generic.Above(rectangle.Corner1.Y);
      this.iinsideTester_0[3] = (BlinnClipper2D.IInsideTester) new BlinnClipper2D.Generic.Under(rectangle.Corner2.Y);
    }

    public BlinnClipper2D(double left, double right, double bottom, double top)
    {
      this.iinsideTester_0 = new BlinnClipper2D.IInsideTester[4];
      this.iinsideTester_0[0] = (BlinnClipper2D.IInsideTester) new BlinnClipper2D.Generic.LeftOf(right);
      this.iinsideTester_0[1] = (BlinnClipper2D.IInsideTester) new BlinnClipper2D.Generic.RightOf(left);
      this.iinsideTester_0[2] = (BlinnClipper2D.IInsideTester) new BlinnClipper2D.Generic.Above(bottom);
      this.iinsideTester_0[3] = (BlinnClipper2D.IInsideTester) new BlinnClipper2D.Generic.Under(top);
    }

    public BlinnClipper2D(
      params BlinnClipper2D.IInsideTester[] insideTesters)
    {
      this.iinsideTester_0 = new BlinnClipper2D.IInsideTester[insideTesters.Length];
      int num = 0;
      foreach (BlinnClipper2D.IInsideTester insideTester in insideTesters)
        this.iinsideTester_0[num++] = insideTester;
    }

    public bool IsInside(Point2D point)
    {
      for (int index = 0; index < this.iinsideTester_0.Length; ++index)
      {
        if (!this.iinsideTester_0[index].IsInside(point))
          return false;
      }
      return true;
    }

    public Segment2D? Clip(Segment2D segment)
    {
      Segment2D? nullable = new Segment2D?(segment);
      for (int index = 0; index < this.iinsideTester_0.Length; ++index)
      {
        nullable = BlinnClipper2D.smethod_0(nullable.Value, this.iinsideTester_0[index]);
        if (!nullable.HasValue)
          break;
      }
      return nullable;
    }

    private static Segment2D? smethod_0(
      Segment2D segment,
      BlinnClipper2D.IInsideTester insideTester)
    {
      bool flag1 = insideTester.IsInside(segment.Start);
      bool flag2 = insideTester.IsInside(segment.End);
      if (flag1)
      {
        if (flag2)
          return new Segment2D?(segment);
        return new Segment2D?(new Segment2D(segment.Start, insideTester.GetIntersection(segment.Start, segment.End)));
      }
      if (flag2)
        return new Segment2D?(new Segment2D(insideTester.GetIntersection(segment.End, segment.Start), segment.End));
      return new Segment2D?();
    }

    public interface IInsideTester
    {
      bool IsInside(Point2D p);

      Point2D GetIntersection(Point2D p1, Point2D p2);
    }

    public sealed class Generic
    {
      public sealed class Under : BlinnClipper2D.IInsideTester
      {
        private readonly double double_0;

        public Under(double top)
        {
          this.double_0 = top;
        }

        public bool IsInside(Point2D p)
        {
          return p.Y <= this.double_0;
        }

        public Point2D GetIntersection(Point2D p1, Point2D p2)
        {
          double num1 = this.double_0 - p1.Y;
          double num2 = this.double_0 - p2.Y;
          double num3 = num1 - num2;
          double num4 = num3 != 0.0 ? num1 / num3 : 0.5;
          return new Point2D((1.0 - num4) * p1.X + num4 * p2.X, (1.0 - num4) * p1.Y + num4 * p2.Y);
        }
      }

      public sealed class Above : BlinnClipper2D.IInsideTester
      {
        private readonly double double_0;

        public Above(double bottom)
        {
          this.double_0 = bottom;
        }

        public bool IsInside(Point2D p)
        {
          return p.Y >= this.double_0;
        }

        public Point2D GetIntersection(Point2D p1, Point2D p2)
        {
          double num1 = this.double_0 - p1.Y;
          double num2 = this.double_0 - p2.Y;
          double num3 = num1 - num2;
          double num4 = num3 != 0.0 ? num1 / num3 : 0.5;
          return new Point2D((1.0 - num4) * p1.X + num4 * p2.X, (1.0 - num4) * p1.Y + num4 * p2.Y);
        }
      }

      public sealed class LeftOf : BlinnClipper2D.IInsideTester
      {
        private readonly double double_0;

        public LeftOf(double right)
        {
          this.double_0 = right;
        }

        public bool IsInside(Point2D p)
        {
          return p.X <= this.double_0;
        }

        public Point2D GetIntersection(Point2D p1, Point2D p2)
        {
          double num1 = this.double_0 - p1.X;
          double num2 = this.double_0 - p2.X;
          double num3 = num1 - num2;
          double num4 = num3 != 0.0 ? num1 / num3 : 0.5;
          return new Point2D((1.0 - num4) * p1.X + num4 * p2.X, (1.0 - num4) * p1.Y + num4 * p2.Y);
        }
      }

      public sealed class RightOf : BlinnClipper2D.IInsideTester
      {
        private readonly double double_0;

        public RightOf(double left)
        {
          this.double_0 = left;
        }

        public bool IsInside(Point2D p)
        {
          return p.X >= this.double_0;
        }

        public Point2D GetIntersection(Point2D p1, Point2D p2)
        {
          double num1 = this.double_0 - p1.X;
          double num2 = this.double_0 - p2.X;
          double num3 = num1 - num2;
          double num4 = num3 != 0.0 ? num1 / num3 : 0.5;
          return new Point2D((1.0 - num4) * p1.X + num4 * p2.X, (1.0 - num4) * p1.Y + num4 * p2.Y);
        }
      }
    }

    public sealed class Fixed
    {
      public sealed class Under : BlinnClipper2D.IInsideTester
      {
        public static readonly BlinnClipper2D.IInsideTester Instance = (BlinnClipper2D.IInsideTester) new BlinnClipper2D.Fixed.Under();

        public bool IsInside(Point2D p)
        {
          return p.Y <= 1.0;
        }

        public Point2D GetIntersection(Point2D p1, Point2D p2)
        {
          double num1 = 1.0 - p1.Y;
          double num2 = 1.0 - p2.Y;
          double num3 = num1 - num2;
          double num4 = num3 != 0.0 ? num1 / num3 : 0.5;
          return new Point2D((1.0 - num4) * p1.X + num4 * p2.X, (1.0 - num4) * p1.Y + num4 * p2.Y);
        }
      }

      public sealed class Above : BlinnClipper2D.IInsideTester
      {
        public static readonly BlinnClipper2D.IInsideTester Instance = (BlinnClipper2D.IInsideTester) new BlinnClipper2D.Fixed.Above();

        public bool IsInside(Point2D p)
        {
          return p.Y >= 0.0;
        }

        public Point2D GetIntersection(Point2D p1, Point2D p2)
        {
          double y1 = p1.Y;
          double y2 = p2.Y;
          double num1 = y1 - y2;
          double num2 = System.Math.Abs(num1) >= 8.88178419700125E-16 ? y1 / num1 : 0.5;
          return new Point2D((1.0 - num2) * p1.X + num2 * p2.X, (1.0 - num2) * p1.Y + num2 * p2.Y);
        }
      }

      public sealed class LeftOf : BlinnClipper2D.IInsideTester
      {
        public static readonly BlinnClipper2D.IInsideTester Instance = (BlinnClipper2D.IInsideTester) new BlinnClipper2D.Fixed.LeftOf();

        public bool IsInside(Point2D p)
        {
          return p.X <= 1.0;
        }

        public Point2D GetIntersection(Point2D p1, Point2D p2)
        {
          double num1 = 1.0 - p1.X;
          double num2 = 1.0 - p2.X;
          double num3 = num1 - num2;
          double num4 = System.Math.Abs(num3) >= 8.88178419700125E-16 ? num1 / num3 : 0.5;
          return new Point2D((1.0 - num4) * p1.X + num4 * p2.X, (1.0 - num4) * p1.Y + num4 * p2.Y);
        }
      }

      public sealed class RightOf : BlinnClipper2D.IInsideTester
      {
        public static readonly BlinnClipper2D.IInsideTester Instance = (BlinnClipper2D.IInsideTester) new BlinnClipper2D.Fixed.RightOf();

        public bool IsInside(Point2D p)
        {
          return p.X >= 0.0;
        }

        public Point2D GetIntersection(Point2D p1, Point2D p2)
        {
          double x1 = p1.X;
          double x2 = p2.X;
          double num1 = x1 - x2;
          double num2 = System.Math.Abs(num1) >= 8.88178419700125E-16 ? x1 / num1 : 0.5;
          return new Point2D((1.0 - num2) * p1.X + num2 * p2.X, (1.0 - num2) * p1.Y + num2 * p2.Y);
        }
      }
    }
  }
}
