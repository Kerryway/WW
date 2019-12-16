// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Bounds2I
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;

namespace WW.Math.Exact
{
  public class Bounds2I : ICloneable<Bounds2I>
  {
    private static readonly Point2I point2I_2 = new Point2I(int.MaxValue, int.MaxValue);
    private static readonly Point2I point2I_3 = new Point2I(int.MinValue, int.MinValue);
    private Point2I point2I_0;
    private Point2I point2I_1;

    public Bounds2I()
    {
      this.Reset();
    }

    public Bounds2I(Point2I corner1, Point2I corner2)
    {
      this.Reset();
      this.Update(corner1);
      this.Update(corner2);
    }

    public Bounds2I(Bounds2I from)
    {
      this.point2I_0 = from.point2I_0;
      this.point2I_1 = from.point2I_1;
    }

    public void Reset()
    {
      this.point2I_0 = Bounds2I.point2I_2;
      this.point2I_1 = Bounds2I.point2I_3;
    }

    public void Update(Point2I p)
    {
      if (this.point2I_0.X > p.X)
        this.point2I_0.X = p.X;
      if (this.point2I_1.X < p.X)
        this.point2I_1.X = p.X;
      if (this.point2I_0.Y > p.Y)
        this.point2I_0.Y = p.Y;
      if (this.point2I_1.Y >= p.Y)
        return;
      this.point2I_1.Y = p.Y;
    }

    public void Update(IList<Point2I> points)
    {
      foreach (Point2I point in (IEnumerable<Point2I>) points)
        this.Update(point);
    }

    public void Update(params Point2I[] points)
    {
      for (int index = 0; index < points.Length; ++index)
        this.Update(points[index]);
    }

    public void Update(Bounds2I bounds)
    {
      if (this.point2I_0.X > bounds.point2I_0.X)
        this.point2I_0.X = bounds.point2I_0.X;
      if (this.point2I_1.X < bounds.point2I_1.X)
        this.point2I_1.X = bounds.point2I_1.X;
      if (this.point2I_0.Y > bounds.point2I_0.Y)
        this.point2I_0.Y = bounds.point2I_0.Y;
      if (this.point2I_1.Y >= bounds.point2I_1.Y)
        return;
      this.point2I_1.Y = bounds.point2I_1.Y;
    }

    public void Update(int x, int y)
    {
      if (this.point2I_0.X > x)
        this.point2I_0.X = x;
      if (this.point2I_1.X < x)
        this.point2I_1.X = x;
      if (this.point2I_0.Y > y)
        this.point2I_0.Y = y;
      if (this.point2I_1.Y >= y)
        return;
      this.point2I_1.Y = y;
    }

    public void Move(int deltaX, int deltaY)
    {
      if (!this.Initialized)
        return;
      this.point2I_0.X += deltaX;
      this.point2I_0.Y += deltaY;
      this.point2I_1.X += deltaX;
      this.point2I_1.Y += deltaY;
    }

    public Point2I Corner1
    {
      get
      {
        return this.point2I_0;
      }
    }

    public Point2I Corner2
    {
      get
      {
        return this.point2I_1;
      }
    }

    public Point2I Min
    {
      get
      {
        return this.point2I_0;
      }
    }

    public Point2I Max
    {
      get
      {
        return this.point2I_1;
      }
    }

    public Vector2I Delta
    {
      get
      {
        return this.point2I_1 - this.point2I_0;
      }
    }

    public Point2I[] Corners
    {
      get
      {
        return new Point2I[4]{ new Point2I(this.point2I_0.X, this.point2I_0.Y), new Point2I(this.point2I_1.X, this.point2I_0.Y), new Point2I(this.point2I_0.X, this.point2I_1.Y), new Point2I(this.point2I_1.X, this.point2I_1.Y) };
      }
    }

    public bool Initialized
    {
      get
      {
        return this.point2I_0 != Bounds2I.point2I_2;
      }
    }

    public bool Overlaps(Bounds2I bounds)
    {
      if (bounds == null || !this.Initialized || !bounds.Initialized)
        return false;
      Point2I min = bounds.Min;
      Point2I max = bounds.Max;
      return (min.X > this.point2I_1.X || max.X < this.point2I_0.X || min.Y > this.point2I_1.Y ? 1 : (max.Y < this.point2I_0.Y ? 1 : 0)) == 0;
    }

    public Bounds2I Clone()
    {
      return new Bounds2I(this);
    }
  }
}
