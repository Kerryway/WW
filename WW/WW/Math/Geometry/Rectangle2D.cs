// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Rectangle2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;

namespace WW.Math.Geometry
{
  [Serializable]
  public struct Rectangle2D : IShape2D, IEquatable<Rectangle2D>, IInsideTester4D
  {
    public static readonly Rectangle2D Empty = new Rectangle2D();
    private Point2D corner1;
    private Point2D corner2;

    public Rectangle2D(Point2D corner1, Point2D corner2)
    {
      this.corner1 = corner1;
      this.corner2 = corner2;
    }

    public Rectangle2D(double x1, double y1, double x2, double y2)
    {
      this.corner1 = new Point2D(x1, y1);
      this.corner2 = new Point2D(x2, y2);
    }

    public double X1
    {
      get
      {
        return this.corner1.X;
      }
      set
      {
        this.corner1.X = value;
      }
    }

    public double X2
    {
      get
      {
        return this.corner2.X;
      }
      set
      {
        this.corner2.X = value;
      }
    }

    public double Y1
    {
      get
      {
        return this.corner1.Y;
      }
      set
      {
        this.corner1.Y = value;
      }
    }

    public double Y2
    {
      get
      {
        return this.corner2.Y;
      }
      set
      {
        this.corner2.Y = value;
      }
    }

    public Point2D Corner1
    {
      get
      {
        return this.corner1;
      }
      set
      {
        this.corner1 = value;
      }
    }

    public Point2D Corner2
    {
      get
      {
        return this.corner2;
      }
      set
      {
        this.corner2 = value;
      }
    }

    public double Width
    {
      get
      {
        return this.corner2.X - this.corner1.X;
      }
    }

    public double Height
    {
      get
      {
        return this.corner2.Y - this.corner1.Y;
      }
    }

    public Point2D Center
    {
      get
      {
        return new Point2D(0.5 * (this.corner1.X + this.corner2.X), 0.5 * (this.corner1.Y + this.corner2.Y));
      }
    }

    public Size2D Size
    {
      get
      {
        return new Size2D(this.Width, this.Height);
      }
    }

    public void Canonize()
    {
      Point2D point2D1 = new Point2D(System.Math.Min(this.corner1.X, this.corner2.X), System.Math.Min(this.corner1.Y, this.corner2.Y));
      Point2D point2D2 = new Point2D(System.Math.Max(this.corner1.X, this.corner2.X), System.Math.Max(this.corner1.Y, this.corner2.Y));
      this.corner1 = point2D1;
      this.corner2 = point2D2;
    }

    public bool IsInside(Point2D point)
    {
      if (point.X >= this.corner1.X && point.X <= this.corner2.X && point.Y >= this.corner1.Y)
        return point.Y <= this.corner2.Y;
      return false;
    }

    public bool IsInside(Point3D point)
    {
      if (point.X >= this.corner1.X && point.X <= this.corner2.X && point.Y >= this.corner1.Y)
        return point.Y <= this.corner2.Y;
      return false;
    }

    public bool IsInside(Vector4D point)
    {
      return this.IsInside((Point3D) point);
    }

    public bool Equals(Rectangle2D other)
    {
      if (other.corner1.Equals(this.corner1))
        return other.corner2.Equals(this.corner2);
      return false;
    }

    public override bool Equals(object obj)
    {
      if (object.ReferenceEquals((object) null, obj) || obj.GetType() != typeof (Rectangle2D))
        return false;
      return this.Equals((Rectangle2D) obj);
    }

    public override int GetHashCode()
    {
      return this.corner1.GetHashCode() * 397 ^ this.corner2.GetHashCode();
    }

    public static bool operator ==(Rectangle2D left, Rectangle2D right)
    {
      return left.Equals(right);
    }

    public static bool operator !=(Rectangle2D left, Rectangle2D right)
    {
      return !left.Equals(right);
    }

    public override string ToString()
    {
      return "(" + this.corner1.ToString() + ") -> (" + this.corner2.ToString() + ")";
    }

    public static Rectangle2D CreateCanonized(Point2D p1, Point2D p2)
    {
      Rectangle2D rectangle2D = new Rectangle2D(p1, p2);
      rectangle2D.Canonize();
      return rectangle2D;
    }

    public static Rectangle2D CreateCanonized(
      double x1,
      double y1,
      double x2,
      double y2)
    {
      Rectangle2D rectangle2D = new Rectangle2D(x1, y1, x2, y2);
      rectangle2D.Canonize();
      return rectangle2D;
    }

    public ISegment2DIterator CreateIterator()
    {
      return (ISegment2DIterator) new Rectangle2D.Class51(this);
    }

    public void AddToBounds(Bounds2D bounds)
    {
      bounds.Update(this.corner1);
      bounds.Update(this.corner2);
    }

    public bool HasSegments
    {
      get
      {
        return true;
      }
    }

    public InsideTestResult TryIsInside(IList<Vector4D> polyline, bool closed)
    {
      int count = polyline.Count;
      switch (count)
      {
        case 0:
          return InsideTestResult.None;
        case 1:
          return !this.IsInside(polyline[0]) ? InsideTestResult.Outside : InsideTestResult.Inside;
        default:
          Point2D[] polyline1 = new Point2D[count];
          for (int index = 0; index < count; ++index)
          {
            Point2D point2D = (Point2D) polyline[index];
            polyline1[index] = point2D;
          }
          int outsideSegmentCount = 0;
          bool allInside = true;
          if (polyline.Count < 3)
            closed = false;
          int length = closed ? count : count - 1;
          bool[] isSegmentOutside = new bool[length];
          bool flag1 = false;
          bool flag2 = false;
          bool flag3 = false;
          bool flag4 = false;
          Point2D point2D1 = polyline1[0];
          if (point2D1.X < this.corner1.X)
          {
            this.method_0(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
            flag1 = true;
          }
          else if (point2D1.X > this.corner2.X)
          {
            this.method_1(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
            flag2 = true;
          }
          else if (point2D1.Y < this.corner1.Y)
          {
            this.method_2(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
            flag3 = true;
          }
          else if (point2D1.Y > this.corner2.Y)
          {
            this.method_3(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
            flag4 = true;
          }
          if (!flag1)
          {
            this.method_0(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
          }
          if (!flag2)
          {
            this.method_1(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
          }
          if (!flag3)
          {
            this.method_2(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
          }
          if (!flag4)
          {
            this.method_3(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
          }
          return allInside ? InsideTestResult.Inside : InsideTestResult.None;
      }
    }

    public InsideTestResult TryIsInside(Bounds3D box)
    {
      if (box.Min.X > this.corner2.X || box.Max.X < this.corner1.X || (box.Min.Y > this.corner2.Y || box.Max.Y < this.corner1.Y))
        return InsideTestResult.Outside;
      return box.Min.X >= this.corner1.X && box.Max.X <= this.corner2.X && (box.Min.Y >= this.corner1.Y && box.Max.Y <= this.corner2.Y) ? InsideTestResult.Inside : InsideTestResult.BothSides;
    }

    private void method_0(
      Point2D[] polyline,
      bool closed,
      bool[] isSegmentOutside,
      ref int outsideSegmentCount,
      ref bool allInside)
    {
      double x = this.corner1.X;
      Point2D point2D1 = polyline[0];
      bool flag1;
      bool flag2 = flag1 = point2D1.X < x;
      int index1 = 0;
      for (int index2 = 1; index2 < polyline.Length; ++index2)
      {
        Point2D point2D2 = polyline[index2];
        bool flag3;
        if (flag3 = point2D2.X < x)
        {
          if (flag2 && !isSegmentOutside[index1])
          {
            isSegmentOutside[index1] = true;
            ++outsideSegmentCount;
          }
          allInside = false;
        }
        flag2 = flag3;
        index1 = index2;
      }
      if (!closed || !flag1 || (!flag2 || isSegmentOutside[index1]))
        return;
      isSegmentOutside[index1] = true;
      ++outsideSegmentCount;
    }

    private void method_1(
      Point2D[] polyline,
      bool closed,
      bool[] isSegmentOutside,
      ref int outsideSegmentCount,
      ref bool allInside)
    {
      double x = this.corner2.X;
      Point2D point2D1 = polyline[0];
      bool flag1;
      bool flag2 = flag1 = point2D1.X > x;
      int index1 = 0;
      for (int index2 = 1; index2 < polyline.Length; ++index2)
      {
        Point2D point2D2 = polyline[index2];
        bool flag3;
        if (flag3 = point2D2.X > x)
        {
          if (flag2 && !isSegmentOutside[index1])
          {
            isSegmentOutside[index1] = true;
            ++outsideSegmentCount;
          }
          allInside = false;
        }
        flag2 = flag3;
        index1 = index2;
      }
      if (!closed || !flag1 || (!flag2 || isSegmentOutside[index1]))
        return;
      isSegmentOutside[index1] = true;
      ++outsideSegmentCount;
    }

    private void method_2(
      Point2D[] polyline,
      bool closed,
      bool[] isSegmentOutside,
      ref int outsideSegmentCount,
      ref bool allInside)
    {
      double y = this.corner1.Y;
      Point2D point2D1 = polyline[0];
      bool flag1;
      bool flag2 = flag1 = point2D1.Y < y;
      int index1 = 0;
      for (int index2 = 1; index2 < polyline.Length; ++index2)
      {
        Point2D point2D2 = polyline[index2];
        bool flag3;
        if (flag3 = point2D2.Y < y)
        {
          if (flag2 && !isSegmentOutside[index1])
          {
            isSegmentOutside[index1] = true;
            ++outsideSegmentCount;
          }
          allInside = false;
        }
        flag2 = flag3;
        index1 = index2;
      }
      if (!closed || !flag1 || (!flag2 || isSegmentOutside[index1]))
        return;
      isSegmentOutside[index1] = true;
      ++outsideSegmentCount;
    }

    private void method_3(
      Point2D[] polyline,
      bool closed,
      bool[] isSegmentOutside,
      ref int outsideSegmentCount,
      ref bool allInside)
    {
      double y = this.corner2.Y;
      Point2D point2D1 = polyline[0];
      bool flag1;
      bool flag2 = flag1 = point2D1.Y > y;
      int index1 = 0;
      for (int index2 = 1; index2 < polyline.Length; ++index2)
      {
        Point2D point2D2 = polyline[index2];
        bool flag3;
        if (flag3 = point2D2.Y > y)
        {
          if (flag2 && !isSegmentOutside[index1])
          {
            isSegmentOutside[index1] = true;
            ++outsideSegmentCount;
          }
          allInside = false;
        }
        flag2 = flag3;
        index1 = index2;
      }
      if (!closed || !flag1 || (!flag2 || isSegmentOutside[index1]))
        return;
      isSegmentOutside[index1] = true;
      ++outsideSegmentCount;
    }

    private class Class51 : ISegment2DIterator
    {
      private int int_0 = -1;
      private readonly Point2D point2D_0;
      private readonly Point2D point2D_1;

      public Class51(Rectangle2D rect)
      {
        this.point2D_0 = rect.Corner1;
        this.point2D_1 = rect.Corner2;
      }

      public bool MoveNext()
      {
        if (this.int_0 > 3)
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
            case 4:
              return SegmentType.Close;
            default:
              return SegmentType.LineTo;
          }
        }
      }

      public SegmentType Current(Point2D[] points, int offset)
      {
        switch (this.int_0)
        {
          case 0:
            points[offset] = this.point2D_0;
            return SegmentType.MoveTo;
          case 1:
            points[offset] = new Point2D(this.point2D_1.X, this.point2D_0.Y);
            return SegmentType.LineTo;
          case 2:
            points[offset] = this.point2D_1;
            return SegmentType.LineTo;
          case 3:
            points[offset] = new Point2D(this.point2D_0.X, this.point2D_1.Y);
            return SegmentType.LineTo;
          default:
            return SegmentType.Close;
        }
      }

      public int TotalSegmentCount
      {
        get
        {
          return 5;
        }
      }

      public int TotalPointCount
      {
        get
        {
          return 4;
        }
      }
    }
  }
}
