// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Point2DE
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Drawing
{
  public class Point2DE : IExtendedPoint2D<Point2DE>, IExtendedPoint2D
  {
    private Point2D point2D_0;
    private bool bool_0;

    public Point2DE()
    {
    }

    public Point2DE(Point2D position)
    {
      this.point2D_0 = position;
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

    public override string ToString()
    {
      return this.point2D_0.ToString();
    }

    public Point2DE GetPoint(Point2DE nextVertex, double fraction)
    {
      double num = 1.0 - fraction;
      return new Point2DE(new Point2D(num * this.point2D_0.X + fraction * nextVertex.point2D_0.X, num * this.point2D_0.Y + fraction * nextVertex.point2D_0.Y));
    }

    public Point2DE GetEndPoint(Point2DE nextVertex, double fraction)
    {
      return this.GetPoint(nextVertex, fraction);
    }

    public void SetEndProperties(Point2DE previousVertex, double fraction)
    {
    }

    public Point2DE Clone()
    {
      return new Point2DE(this.point2D_0) { IsInterpolatedPoint = this.IsInterpolatedPoint };
    }
  }
}
