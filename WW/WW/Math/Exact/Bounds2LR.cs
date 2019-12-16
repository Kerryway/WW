// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Bounds2LR
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;

namespace WW.Math.Exact
{
  public class Bounds2LR : ICloneable<Bounds2LR>
  {
    private static readonly Point2LR point2LR_2 = new Point2LR(LongRational.PositiveInfinity, LongRational.PositiveInfinity);
    private static readonly Point2LR point2LR_3 = new Point2LR(LongRational.NegativeInfinity, LongRational.NegativeInfinity);
    private Point2LR point2LR_0;
    private Point2LR point2LR_1;

    public Bounds2LR()
    {
      this.Reset();
    }

    public Bounds2LR(Point2LR corner1, Point2LR corner2)
    {
      this.Reset();
      this.Update(corner1);
      this.Update(corner2);
    }

    public Bounds2LR(Bounds2LR from)
    {
      this.point2LR_0 = from.point2LR_0;
      this.point2LR_1 = from.point2LR_1;
    }

    public void Reset()
    {
      this.point2LR_0 = Bounds2LR.point2LR_2;
      this.point2LR_1 = Bounds2LR.point2LR_3;
    }

    public void Update(Point2LR p)
    {
      if (this.point2LR_0.X > p.X)
        this.point2LR_0.X = p.X;
      if (this.point2LR_1.X < p.X)
        this.point2LR_1.X = p.X;
      if (this.point2LR_0.Y > p.Y)
        this.point2LR_0.Y = p.Y;
      if (!(this.point2LR_1.Y < p.Y))
        return;
      this.point2LR_1.Y = p.Y;
    }

    public void Update(IList<Point2LR> points)
    {
      foreach (Point2LR point in (IEnumerable<Point2LR>) points)
        this.Update(point);
    }

    public void Update(params Point2LR[] points)
    {
      for (int index = 0; index < points.Length; ++index)
        this.Update(points[index]);
    }

    public void Update(Bounds2LR bounds)
    {
      if (this.point2LR_0.X > bounds.point2LR_0.X)
        this.point2LR_0.X = bounds.point2LR_0.X;
      if (this.point2LR_1.X < bounds.point2LR_1.X)
        this.point2LR_1.X = bounds.point2LR_1.X;
      if (this.point2LR_0.Y > bounds.point2LR_0.Y)
        this.point2LR_0.Y = bounds.point2LR_0.Y;
      if (!(this.point2LR_1.Y < bounds.point2LR_1.Y))
        return;
      this.point2LR_1.Y = bounds.point2LR_1.Y;
    }

    public void Update(LongRational x, LongRational y)
    {
      if (this.point2LR_0.X > x)
        this.point2LR_0.X = x;
      if (this.point2LR_1.X < x)
        this.point2LR_1.X = x;
      if (this.point2LR_0.Y > y)
        this.point2LR_0.Y = y;
      if (!(this.point2LR_1.Y < y))
        return;
      this.point2LR_1.Y = y;
    }

    public void Move(LongRational deltaX, LongRational deltaY)
    {
      if (!this.Initialized)
        return;
      this.point2LR_0.X += deltaX;
      this.point2LR_0.Y += deltaY;
      this.point2LR_1.X += deltaX;
      this.point2LR_1.Y += deltaY;
    }

    public Point2LR Corner1
    {
      get
      {
        return this.point2LR_0;
      }
    }

    public Point2LR Corner2
    {
      get
      {
        return this.point2LR_1;
      }
    }

    public Point2LR Min
    {
      get
      {
        return this.point2LR_0;
      }
    }

    public Point2LR Max
    {
      get
      {
        return this.point2LR_1;
      }
    }

    public Vector2LR Delta
    {
      get
      {
        return this.point2LR_1 - this.point2LR_0;
      }
    }

    public Point2LR Center
    {
      get
      {
        return Point2LR.GetMidPoint(this.point2LR_0, this.point2LR_1);
      }
    }

    public Point2LR[] Corners
    {
      get
      {
        return new Point2LR[4]{ new Point2LR(this.point2LR_0.X, this.point2LR_0.Y), new Point2LR(this.point2LR_1.X, this.point2LR_0.Y), new Point2LR(this.point2LR_0.X, this.point2LR_1.Y), new Point2LR(this.point2LR_1.X, this.point2LR_1.Y) };
      }
    }

    public bool Initialized
    {
      get
      {
        return this.point2LR_0 != Bounds2LR.point2LR_2;
      }
    }

    public bool Overlaps(Bounds2LR bounds)
    {
      if (bounds == null || !this.Initialized || !bounds.Initialized)
        return false;
      Point2LR min = bounds.Min;
      Point2LR max = bounds.Max;
      return (min.X > this.point2LR_1.X || max.X < this.point2LR_0.X || min.Y > this.point2LR_1.Y ? 1 : (max.Y < this.point2LR_0.Y ? 1 : 0)) == 0;
    }

    public Bounds2LR Clone()
    {
      return new Bounds2LR(this);
    }
  }
}
