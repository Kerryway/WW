// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.OrientedRectangle2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;

namespace WW.Math.Geometry
{
  [Serializable]
  public struct OrientedRectangle2D
  {
    public static readonly OrientedRectangle2D Empty = new OrientedRectangle2D(Point2D.Zero, Vector2D.Zero, Vector2D.Zero);
    public Point2D Origin;
    public Vector2D XAxis;
    public Vector2D YAxis;

    public OrientedRectangle2D(Point2D origin, Vector2D xaxis, Vector2D yaxis)
    {
      this.Origin = origin;
      this.XAxis = xaxis;
      this.YAxis = yaxis;
    }

    public Point2D TopLeft
    {
      get
      {
        return this.Origin + this.YAxis;
      }
    }

    public Point2D BottomRight
    {
      get
      {
        return this.Origin + this.XAxis;
      }
    }

    public Point2D TopRight
    {
      get
      {
        return this.Origin + this.XAxis + this.YAxis;
      }
    }

    public Polygon2D ToPolygon2D()
    {
      return new Polygon2D(new Point2D[4]{ this.Origin, this.BottomRight, this.TopRight, this.TopLeft });
    }

    public bool Contains(Point2D point)
    {
      Point2D origin = this.Origin;
      Point2D bottomRight = this.BottomRight;
      if (new Line2D(origin, bottomRight).IsRight(point))
        return false;
      Point2D topRight = this.TopRight;
      if (new Line2D(bottomRight, topRight).IsRight(point))
        return false;
      Point2D topLeft = this.TopLeft;
      return !new Line2D(topRight, topLeft).IsRight(point) && !new Line2D(topLeft, origin).IsRight(point);
    }

    public bool BorderContains(Point2D point, double precision)
    {
      Point2D origin = this.Origin;
      Point2D bottomRight = this.BottomRight;
      if (new Segment2D(origin, bottomRight).Contains(point, precision))
        return true;
      Point2D topRight = this.TopRight;
      if (new Segment2D(bottomRight, topRight).Contains(point, precision))
        return true;
      Point2D topLeft = this.TopLeft;
      if (!new Segment2D(topRight, topLeft).Contains(point, precision))
        return new Segment2D(topLeft, origin).Contains(point, precision);
      return true;
    }
  }
}
