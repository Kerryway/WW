// Decompiled with JetBrains decompiler
// Type: WW.Math.Bounds3D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;
using WW.Math.Geometry;

namespace WW.Math
{
  public class Bounds3D : WW.ICloneable<Bounds3D>, IInsideTester4D
  {
    private static readonly Point3D point3D_2 = new Point3D(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);
    private static readonly Point3D point3D_3 = new Point3D(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);
    private Point3D point3D_0;
    private Point3D point3D_1;

    public Bounds3D()
    {
      this.Reset();
    }

    public Bounds3D(Point3D corner1, Point3D corner2)
    {
      this.Reset();
      this.Update(corner1);
      this.Update(corner2);
    }

    public Bounds3D(
      double corner1x,
      double corner1y,
      double corner1z,
      double corner2x,
      double corner2y,
      double corner2z)
    {
      this.Reset();
      this.Update(new Point3D(corner1x, corner1y, corner1z));
      this.Update(new Point3D(corner2x, corner2y, corner2z));
    }

    public Bounds3D(Bounds3D from)
    {
      this.point3D_0 = from.point3D_0;
      this.point3D_1 = from.point3D_1;
    }

    public void Reset()
    {
      this.point3D_0 = Bounds3D.point3D_2;
      this.point3D_1 = Bounds3D.point3D_3;
    }

    public void Update(Point3D p)
    {
      if (this.point3D_0.X > p.X)
        this.point3D_0.X = p.X;
      if (this.point3D_1.X < p.X)
        this.point3D_1.X = p.X;
      if (this.point3D_0.Y > p.Y)
        this.point3D_0.Y = p.Y;
      if (this.point3D_1.Y < p.Y)
        this.point3D_1.Y = p.Y;
      if (this.point3D_0.Z > p.Z)
        this.point3D_0.Z = p.Z;
      if (this.point3D_1.Z >= p.Z)
        return;
      this.point3D_1.Z = p.Z;
    }

    public void Update(IList<Point3D> points)
    {
      foreach (Point3D point in (IEnumerable<Point3D>) points)
        this.Update(point);
    }

    public void Update(params Point3D[] points)
    {
      for (int index = 0; index < points.Length; ++index)
        this.Update(points[index]);
    }

    public void Update(Vector4D p)
    {
      this.Update(p.ToPoint3D());
    }

    public void Update(IList<Vector4D> points)
    {
      foreach (Vector4D point in (IEnumerable<Vector4D>) points)
        this.Update(point.ToPoint3D());
    }

    public void Update(IList<Vector4D> points, Matrix4D transform)
    {
      foreach (Vector4D point in (IEnumerable<Vector4D>) points)
        this.Update(transform.TransformToPoint3D(point));
    }

    public void Update(Vector4D[] points)
    {
      for (int index = 0; index < points.Length; ++index)
        this.Update(points[index]);
    }

    public void Update(Bounds3D bounds)
    {
      if (this.point3D_0.X > bounds.point3D_0.X)
        this.point3D_0.X = bounds.point3D_0.X;
      if (this.point3D_1.X < bounds.point3D_1.X)
        this.point3D_1.X = bounds.point3D_1.X;
      if (this.point3D_0.Y > bounds.point3D_0.Y)
        this.point3D_0.Y = bounds.point3D_0.Y;
      if (this.point3D_1.Y < bounds.point3D_1.Y)
        this.point3D_1.Y = bounds.point3D_1.Y;
      if (this.point3D_0.Z > bounds.point3D_0.Z)
        this.point3D_0.Z = bounds.point3D_0.Z;
      if (this.point3D_1.Z >= bounds.point3D_1.Z)
        return;
      this.point3D_1.Z = bounds.point3D_1.Z;
    }

    public void Update(double x, double y, double z)
    {
      if (this.point3D_0.X > x)
        this.point3D_0.X = x;
      if (this.point3D_1.X < x)
        this.point3D_1.X = x;
      if (this.point3D_0.Y > y)
        this.point3D_0.Y = y;
      if (this.point3D_1.Y < y)
        this.point3D_1.Y = y;
      if (this.point3D_0.Z > z)
        this.point3D_0.Z = z;
      if (this.point3D_1.Z >= z)
        return;
      this.point3D_1.Z = z;
    }

    public void Move(double deltaX, double deltaY, double deltaZ)
    {
      if (!this.Initialized)
        return;
      this.point3D_0.X += deltaX;
      this.point3D_0.Y += deltaY;
      this.point3D_0.Z += deltaZ;
      this.point3D_1.X += deltaX;
      this.point3D_1.Y += deltaY;
      this.point3D_1.Z += deltaZ;
    }

    public void Transform(Matrix4D transform)
    {
      Vector3D vector3D = this.point3D_1 - this.point3D_0;
      this.point3D_0 = transform.Transform(this.point3D_0);
      this.point3D_1 = this.point3D_0;
      this.Update(this.point3D_0 + vector3D.X * Vector3D.XAxis);
      Point3D p1 = this.point3D_0 + vector3D.Y * Vector3D.YAxis;
      Point3D p2 = this.point3D_1 + vector3D.Y * Vector3D.YAxis;
      this.Update(p1);
      this.Update(p2);
      Point3D p3 = this.point3D_0 + vector3D.Z * Vector3D.ZAxis;
      Point3D p4 = this.point3D_1 + vector3D.Z * Vector3D.ZAxis;
      this.Update(p3);
      this.Update(p4);
    }

    public Point3D Corner1
    {
      get
      {
        return this.point3D_0;
      }
      set
      {
        this.point3D_0 = value;
      }
    }

    public Point3D Corner2
    {
      get
      {
        return this.point3D_1;
      }
      set
      {
        this.point3D_1 = value;
      }
    }

    public Point3D Min
    {
      get
      {
        return this.point3D_0;
      }
      set
      {
        this.point3D_0 = value;
      }
    }

    public Point3D Max
    {
      get
      {
        return this.point3D_1;
      }
      set
      {
        this.point3D_0 = value;
      }
    }

    public Vector3D Delta
    {
      get
      {
        return this.point3D_1 - this.point3D_0;
      }
    }

    public Point3D Center
    {
      get
      {
        return new Point3D(0.5 * (this.point3D_0.X + this.point3D_1.X), 0.5 * (this.point3D_0.Y + this.point3D_1.Y), 0.5 * (this.point3D_0.Z + this.point3D_1.Z));
      }
    }

    public Point3D[] Corners
    {
      get
      {
        return new Point3D[8]{ new Point3D(this.point3D_0.X, this.point3D_0.Y, this.point3D_0.Z), new Point3D(this.point3D_1.X, this.point3D_0.Y, this.point3D_0.Z), new Point3D(this.point3D_0.X, this.point3D_1.Y, this.point3D_0.Z), new Point3D(this.point3D_1.X, this.point3D_1.Y, this.point3D_0.Z), new Point3D(this.point3D_0.X, this.point3D_0.Y, this.point3D_1.Z), new Point3D(this.point3D_1.X, this.point3D_0.Y, this.point3D_1.Z), new Point3D(this.point3D_0.X, this.point3D_1.Y, this.point3D_1.Z), new Point3D(this.point3D_1.X, this.point3D_1.Y, this.point3D_1.Z) };
      }
    }

    public bool Initialized
    {
      get
      {
        return this.point3D_0 != Bounds3D.point3D_2;
      }
    }

    public bool Intersects(Segment3D segment)
    {
      double p0;
      double p1;
      return this.GetIntersectionParameters(segment, out p0, out p1);
    }

    public bool GetIntersectionParameters(Segment3D segment, out double p0, out double p1)
    {
      p0 = 0.0;
      p1 = 1.0;
      Point3D start = segment.Start;
      Vector3D delta = segment.GetDelta();
      double num1 = 1.0 / delta.X;
      double num2 = (this.point3D_0.X - start.X) * num1;
      if (double.IsNaN(num2))
        num2 = double.NegativeInfinity;
      double num3 = (this.point3D_1.X - start.X) * num1;
      if (double.IsNaN(num3))
        num3 = double.PositiveInfinity;
      if (num3 < num2)
      {
        double num4 = num3;
        num3 = num2;
        num2 = num4;
      }
      p0 = System.Math.Max(p0, num2);
      p1 = System.Math.Min(p1, num3);
      if (p1 < p0)
        return false;
      double num5 = 1.0 / delta.Y;
      double num6 = (this.point3D_0.Y - start.Y) * num5;
      if (double.IsNaN(num6))
        num6 = double.NegativeInfinity;
      double num7 = (this.point3D_1.Y - start.Y) * num5;
      if (double.IsNaN(num7))
        num7 = double.PositiveInfinity;
      if (num7 < num6)
      {
        double num4 = num7;
        num7 = num6;
        num6 = num4;
      }
      p0 = System.Math.Max(p0, num6);
      p1 = System.Math.Min(p1, num7);
      if (p1 < p0)
        return false;
      double num8 = 1.0 / delta.Z;
      double num9 = (this.point3D_0.Z - start.Z) * num8;
      if (double.IsNaN(num9))
        num9 = double.NegativeInfinity;
      double num10 = (this.point3D_1.Z - start.Z) * num8;
      if (double.IsNaN(num10))
        num10 = double.PositiveInfinity;
      if (num10 < num9)
      {
        double num4 = num10;
        num10 = num9;
        num9 = num4;
      }
      p0 = System.Math.Max(p0, num9);
      p1 = System.Math.Min(p1, num10);
      return p1 >= p0;
    }

    public bool Overlaps(Bounds3D bounds)
    {
      if (bounds != null && this.Initialized && bounds.Initialized)
        return (this.point3D_0.X > bounds.point3D_1.X || this.point3D_1.X < bounds.point3D_0.X || (this.point3D_0.Y > bounds.point3D_1.Y || this.point3D_1.Y < bounds.point3D_0.Y) || this.point3D_0.Z > bounds.point3D_1.Z ? 1 : (this.point3D_1.Z < bounds.point3D_0.Z ? 1 : 0)) == 0;
      return false;
    }

    public override string ToString()
    {
      return string.Format("Min: {0}, max: {1}", (object) this.point3D_0, (object) this.point3D_1);
    }

    public Bounds3D Clone()
    {
      return new Bounds3D(this);
    }

    public void CopyFrom(Bounds3D from)
    {
      this.point3D_0 = from.point3D_0;
      this.point3D_1 = from.point3D_1;
    }

    public bool IsInside(Point3D p)
    {
      if (p.X >= this.point3D_0.X && p.X <= this.point3D_1.X && (p.Y >= this.point3D_0.Y && p.Y <= this.point3D_1.Y) && p.Z >= this.point3D_0.Z)
        return p.Z <= this.point3D_1.Z;
      return false;
    }

    public bool IsInside(Vector4D p)
    {
      return this.IsInside((Point3D) p);
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
          Point3D[] polyline1 = new Point3D[count];
          for (int index = 0; index < count; ++index)
          {
            Point3D point3D = (Point3D) polyline[index];
            polyline1[index] = point3D;
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
          bool flag5 = false;
          bool flag6 = false;
          Point3D point3D1 = polyline1[0];
          if (point3D1.X < this.point3D_0.X)
          {
            this.method_0(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
            flag1 = true;
          }
          else if (point3D1.X > this.point3D_1.X)
          {
            this.method_1(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
            flag2 = true;
          }
          else if (point3D1.Y < this.point3D_0.Y)
          {
            this.method_2(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
            flag3 = true;
          }
          else if (point3D1.Y > this.point3D_1.Y)
          {
            this.method_3(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
            flag4 = true;
          }
          else if (point3D1.Z < this.point3D_0.Z)
          {
            this.method_4(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
            flag5 = true;
          }
          else if (point3D1.Z > this.point3D_1.Z)
          {
            this.method_5(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
            flag6 = true;
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
          if (!flag5)
          {
            this.method_4(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
          }
          if (!flag6)
          {
            this.method_5(polyline1, closed, isSegmentOutside, ref outsideSegmentCount, ref allInside);
            if (outsideSegmentCount == length)
              return InsideTestResult.Outside;
          }
          return allInside ? InsideTestResult.Inside : InsideTestResult.None;
      }
    }

    public InsideTestResult TryIsInside(Bounds3D box)
    {
      if (box.point3D_0.X > this.point3D_1.X || box.point3D_1.X < this.point3D_0.X || (box.point3D_0.Y > this.point3D_1.Y || box.point3D_1.Y < this.point3D_0.Y) || (box.point3D_0.Z > this.point3D_1.Z || box.point3D_1.Z < this.point3D_0.Z))
        return InsideTestResult.Outside;
      return box.point3D_0.X >= this.point3D_0.X && box.point3D_1.X <= this.point3D_1.X && (box.point3D_0.Y >= this.point3D_0.Y && box.point3D_1.Y <= this.point3D_1.Y) && (box.point3D_0.Z >= this.point3D_0.Z && box.point3D_1.Z <= this.point3D_1.Z) ? InsideTestResult.Inside : InsideTestResult.BothSides;
    }

    private void method_0(
      Point3D[] polyline,
      bool closed,
      bool[] isSegmentOutside,
      ref int outsideSegmentCount,
      ref bool allInside)
    {
      double x = this.point3D_0.X;
      Point3D point3D1 = polyline[0];
      bool flag1;
      bool flag2 = flag1 = point3D1.X < x;
      int index1 = 0;
      for (int index2 = 1; index2 < polyline.Length; ++index2)
      {
        Point3D point3D2 = polyline[index2];
        bool flag3;
        if (flag3 = point3D2.X < x)
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
      Point3D[] polyline,
      bool closed,
      bool[] isSegmentOutside,
      ref int outsideSegmentCount,
      ref bool allInside)
    {
      double x = this.point3D_1.X;
      Point3D point3D1 = polyline[0];
      bool flag1;
      bool flag2 = flag1 = point3D1.X > x;
      int index1 = 0;
      for (int index2 = 1; index2 < polyline.Length; ++index2)
      {
        Point3D point3D2 = polyline[index2];
        bool flag3;
        if (flag3 = point3D2.X > x)
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
      Point3D[] polyline,
      bool closed,
      bool[] isSegmentOutside,
      ref int outsideSegmentCount,
      ref bool allInside)
    {
      double y = this.point3D_0.Y;
      Point3D point3D1 = polyline[0];
      bool flag1;
      bool flag2 = flag1 = point3D1.Y < y;
      int index1 = 0;
      for (int index2 = 1; index2 < polyline.Length; ++index2)
      {
        Point3D point3D2 = polyline[index2];
        bool flag3;
        if (flag3 = point3D2.Y < y)
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
      Point3D[] polyline,
      bool closed,
      bool[] isSegmentOutside,
      ref int outsideSegmentCount,
      ref bool allInside)
    {
      double y = this.point3D_1.Y;
      Point3D point3D1 = polyline[0];
      bool flag1;
      bool flag2 = flag1 = point3D1.Y > y;
      int index1 = 0;
      for (int index2 = 1; index2 < polyline.Length; ++index2)
      {
        Point3D point3D2 = polyline[index2];
        bool flag3;
        if (flag3 = point3D2.Y > y)
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

    private void method_4(
      Point3D[] polyline,
      bool closed,
      bool[] isSegmentOutside,
      ref int outsideSegmentCount,
      ref bool allInside)
    {
      double z = this.point3D_0.Z;
      Point3D point3D1 = polyline[0];
      bool flag1;
      bool flag2 = flag1 = point3D1.Z < z;
      int index1 = 0;
      for (int index2 = 1; index2 < polyline.Length; ++index2)
      {
        Point3D point3D2 = polyline[index2];
        bool flag3;
        if (flag3 = point3D2.Z < z)
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

    private void method_5(
      Point3D[] polyline,
      bool closed,
      bool[] isSegmentOutside,
      ref int outsideSegmentCount,
      ref bool allInside)
    {
      double z = this.point3D_1.Z;
      Point3D point3D1 = polyline[0];
      bool flag1;
      bool flag2 = flag1 = point3D1.Z > z;
      int index1 = 0;
      for (int index2 = 1; index2 < polyline.Length; ++index2)
      {
        Point3D point3D2 = polyline[index2];
        bool flag3;
        if (flag3 = point3D2.Z > z)
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
  }
}
