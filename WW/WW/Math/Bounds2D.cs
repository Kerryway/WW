// Decompiled with JetBrains decompiler
// Type: WW.Math.Bounds2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;
using System.Windows;

namespace WW.Math
{
  public class Bounds2D : ICloneable<Bounds2D>
  {
    private static readonly Point2D point2D_2 = new Point2D(double.PositiveInfinity, double.PositiveInfinity);
    private static readonly Point2D point2D_3 = new Point2D(double.NegativeInfinity, double.NegativeInfinity);
    private Point2D point2D_0;
    private Point2D point2D_1;

    public Bounds2D()
    {
      this.Reset();
    }

    public Bounds2D(Point2D corner1, Point2D corner2)
    {
      this.Reset();
      this.Update(corner1);
      this.Update(corner2);
    }

    public Bounds2D(Bounds2D from)
    {
      this.point2D_0 = from.point2D_0;
      this.point2D_1 = from.point2D_1;
    }

    public void Reset()
    {
      this.point2D_0 = Bounds2D.point2D_2;
      this.point2D_1 = Bounds2D.point2D_3;
    }

    public void Update(Point2D p)
    {
      if (this.point2D_0.X > p.X)
        this.point2D_0.X = p.X;
      if (this.point2D_1.X < p.X)
        this.point2D_1.X = p.X;
      if (this.point2D_0.Y > p.Y)
        this.point2D_0.Y = p.Y;
      if (this.point2D_1.Y >= p.Y)
        return;
      this.point2D_1.Y = p.Y;
    }

    public void Update(Point p)
    {
      if (this.point2D_0.X > p.X)
        this.point2D_0.X = p.X;
      if (this.point2D_1.X < p.X)
        this.point2D_1.X = p.X;
      if (this.point2D_0.Y > p.Y)
        this.point2D_0.Y = p.Y;
      if (this.point2D_1.Y >= p.Y)
        return;
      this.point2D_1.Y = p.Y;
    }

    public void Update(IList<Point2D> points)
    {
      foreach (Point2D point in (IEnumerable<Point2D>) points)
        this.Update(point);
    }

    public void Update(params Point2D[] points)
    {
      for (int index = 0; index < points.Length; ++index)
        this.Update(points[index]);
    }

    public void Update(Bounds2D bounds)
    {
      if (this.point2D_0.X > bounds.point2D_0.X)
        this.point2D_0.X = bounds.point2D_0.X;
      if (this.point2D_1.X < bounds.point2D_1.X)
        this.point2D_1.X = bounds.point2D_1.X;
      if (this.point2D_0.Y > bounds.point2D_0.Y)
        this.point2D_0.Y = bounds.point2D_0.Y;
      if (this.point2D_1.Y >= bounds.point2D_1.Y)
        return;
      this.point2D_1.Y = bounds.point2D_1.Y;
    }

    public void Update(double x, double y)
    {
      if (this.point2D_0.X > x)
        this.point2D_0.X = x;
      if (this.point2D_1.X < x)
        this.point2D_1.X = x;
      if (this.point2D_0.Y > y)
        this.point2D_0.Y = y;
      if (this.point2D_1.Y >= y)
        return;
      this.point2D_1.Y = y;
    }

    public void Move(double deltaX, double deltaY)
    {
      if (!this.Initialized)
        return;
      this.point2D_0.X += deltaX;
      this.point2D_0.Y += deltaY;
      this.point2D_1.X += deltaX;
      this.point2D_1.Y += deltaY;
    }

    public Point2D Corner1
    {
      get
      {
        return this.point2D_0;
      }
    }

    public Point2D Corner2
    {
      get
      {
        return this.point2D_1;
      }
    }

    public Point2D Min
    {
      get
      {
        return this.point2D_0;
      }
      set
      {
        this.point2D_0 = value;
      }
    }

    public Point2D Max
    {
      get
      {
        return this.point2D_1;
      }
      set
      {
        this.point2D_1 = value;
      }
    }

    public Vector2D Delta
    {
      get
      {
        return this.point2D_1 - this.point2D_0;
      }
    }

    public Point2D Center
    {
      get
      {
        return new Point2D(0.5 * (this.point2D_0.X + this.point2D_1.X), 0.5 * (this.point2D_0.Y + this.point2D_1.Y));
      }
    }

    public Point2D[] Corners
    {
      get
      {
        return new Point2D[4]{ new Point2D(this.point2D_0.X, this.point2D_0.Y), new Point2D(this.point2D_1.X, this.point2D_0.Y), new Point2D(this.point2D_0.X, this.point2D_1.Y), new Point2D(this.point2D_1.X, this.point2D_1.Y) };
      }
    }

    public bool Initialized
    {
      get
      {
        return this.point2D_0 != Bounds2D.point2D_2;
      }
    }

    public bool Overlaps(Bounds2D bounds)
    {
      if (bounds != null && this.Initialized && bounds.Initialized)
        return (this.point2D_0.X > bounds.point2D_1.X || this.point2D_1.X < bounds.point2D_0.X || this.point2D_0.Y > bounds.point2D_1.Y ? 1 : (this.point2D_1.Y < bounds.point2D_0.Y ? 1 : 0)) == 0;
      return false;
    }

    public override string ToString()
    {
      return string.Format("Min: {0}, max: {1}", (object) this.point2D_0, (object) this.point2D_1);
    }

    public Bounds2D Clone()
    {
      return new Bounds2D(this);
    }

    public void CopyFrom(Bounds2D from)
    {
      this.point2D_0 = from.point2D_0;
      this.point2D_1 = from.point2D_1;
    }
  }
}
