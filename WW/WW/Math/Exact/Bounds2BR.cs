// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Bounds2BR
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;

namespace WW.Math.Exact
{
  public class Bounds2BR : ICloneable<Bounds2BR>
  {
    private static readonly Point2BR point2BR_2 = new Point2BR(BigRational.PositiveInfinity, BigRational.PositiveInfinity);
    private static readonly Point2BR point2BR_3 = new Point2BR(BigRational.NegativeInfinity, BigRational.NegativeInfinity);
    private Point2BR point2BR_0;
    private Point2BR point2BR_1;

    public Bounds2BR()
    {
      this.Reset();
    }

    public Bounds2BR(Point2BR corner1, Point2BR corner2)
    {
      this.Reset();
      this.Update(corner1);
      this.Update(corner2);
    }

    public Bounds2BR(Bounds2BR from)
    {
      this.point2BR_0 = from.point2BR_0;
      this.point2BR_1 = from.point2BR_1;
    }

    public void Reset()
    {
      this.point2BR_0 = Bounds2BR.point2BR_2;
      this.point2BR_1 = Bounds2BR.point2BR_3;
    }

    public void Update(Point2BR p)
    {
      if (this.point2BR_0.X > p.X)
        this.point2BR_0.X = p.X;
      if (this.point2BR_1.X < p.X)
        this.point2BR_1.X = p.X;
      if (this.point2BR_0.Y > p.Y)
        this.point2BR_0.Y = p.Y;
      if (!(this.point2BR_1.Y < p.Y))
        return;
      this.point2BR_1.Y = p.Y;
    }

    public void Update(IList<Point2BR> points)
    {
      foreach (Point2BR point in (IEnumerable<Point2BR>) points)
        this.Update(point);
    }

    public void Update(params Point2BR[] points)
    {
      for (int index = 0; index < points.Length; ++index)
        this.Update(points[index]);
    }

    public void Update(Bounds2BR bounds)
    {
      if (this.point2BR_0.X > bounds.point2BR_0.X)
        this.point2BR_0.X = bounds.point2BR_0.X;
      if (this.point2BR_1.X < bounds.point2BR_1.X)
        this.point2BR_1.X = bounds.point2BR_1.X;
      if (this.point2BR_0.Y > bounds.point2BR_0.Y)
        this.point2BR_0.Y = bounds.point2BR_0.Y;
      if (!(this.point2BR_1.Y < bounds.point2BR_1.Y))
        return;
      this.point2BR_1.Y = bounds.point2BR_1.Y;
    }

    public void Update(BigRational x, BigRational y)
    {
      if (this.point2BR_0.X > x)
        this.point2BR_0.X = x;
      if (this.point2BR_1.X < x)
        this.point2BR_1.X = x;
      if (this.point2BR_0.Y > y)
        this.point2BR_0.Y = y;
      if (!(this.point2BR_1.Y < y))
        return;
      this.point2BR_1.Y = y;
    }

    public void Move(BigRational deltaX, BigRational deltaY)
    {
      if (!this.Initialized)
        return;
      this.point2BR_0.X += deltaX;
      this.point2BR_0.Y += deltaY;
      this.point2BR_1.X += deltaX;
      this.point2BR_1.Y += deltaY;
    }

    public Point2BR Corner1
    {
      get
      {
        return this.point2BR_0;
      }
    }

    public Point2BR Corner2
    {
      get
      {
        return this.point2BR_1;
      }
    }

    public Point2BR Min
    {
      get
      {
        return this.point2BR_0;
      }
    }

    public Point2BR Max
    {
      get
      {
        return this.point2BR_1;
      }
    }

    public Vector2BR Delta
    {
      get
      {
        return this.point2BR_1 - this.point2BR_0;
      }
    }

    public Point2BR Center
    {
      get
      {
        return Point2BR.GetMidPoint(this.point2BR_0, this.point2BR_1);
      }
    }

    public Point2BR[] Corners
    {
      get
      {
        return new Point2BR[4]{ new Point2BR(this.point2BR_0.X, this.point2BR_0.Y), new Point2BR(this.point2BR_1.X, this.point2BR_0.Y), new Point2BR(this.point2BR_0.X, this.point2BR_1.Y), new Point2BR(this.point2BR_1.X, this.point2BR_1.Y) };
      }
    }

    public bool Initialized
    {
      get
      {
        return this.point2BR_0 != Bounds2BR.point2BR_2;
      }
    }

    public bool Overlaps(Bounds2BR bounds)
    {
      if (bounds == null || !this.Initialized || !bounds.Initialized)
        return false;
      Point2BR min = bounds.Min;
      Point2BR max = bounds.Max;
      return (min.X > this.point2BR_1.X || max.X < this.point2BR_0.X || min.Y > this.point2BR_1.Y ? 1 : (max.Y < this.point2BR_0.Y ? 1 : 0)) == 0;
    }

    public Bounds2BR Clone()
    {
      return new Bounds2BR(this);
    }
  }
}
