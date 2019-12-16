// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Point2DN
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Drawing
{
  public class Point2DN : IExtendedPoint2D<Point2DN>, IExtendedPoint2D
  {
    private Point2D point2D_0;
    private Vector2D vector2D_0;
    private bool bool_0;

    public Point2DN()
    {
    }

    public Point2DN(Point2D position)
    {
      this.point2D_0 = position;
    }

    public Point2DN(Point2D position, Vector2D normal)
    {
      this.point2D_0 = position;
      this.vector2D_0 = normal;
    }

    public Point2D Position
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

    public bool IsInterpolatedPoint
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public Vector2D Normal
    {
      get
      {
        return this.vector2D_0;
      }
      set
      {
        this.vector2D_0 = value;
      }
    }

    public override string ToString()
    {
      return this.point2D_0.ToString();
    }

    public Point2DN GetPoint(Point2DN nextVertex, double fraction)
    {
      double num = 1.0 - fraction;
      return new Point2DN(new Point2D(num * this.point2D_0.X + fraction * nextVertex.point2D_0.X, num * this.point2D_0.Y + fraction * nextVertex.point2D_0.Y), (num * this.vector2D_0 + fraction * nextVertex.vector2D_0).GetUnit());
    }

    public Point2DN GetEndPoint(Point2DN nextVertex, double fraction)
    {
      return this.GetPoint(nextVertex, fraction);
    }

    public void SetEndProperties(Point2DN previousVertex, double fraction)
    {
    }

    public Point2DN Clone()
    {
      return new Point2DN(this.point2D_0, this.vector2D_0) { IsInterpolatedPoint = this.IsInterpolatedPoint };
    }
  }
}
