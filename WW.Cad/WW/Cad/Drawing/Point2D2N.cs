// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Point2D2N
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Drawing
{
  public class Point2D2N : IExtendedPoint2D<Point2D2N>, IExtendedPoint2D
  {
    private Point2D point2D_0;
    private Vector2D vector2D_0;
    private Vector2D vector2D_1;
    private bool bool_0;

    public Point2D2N()
    {
    }

    public Point2D2N(Point2D position)
    {
      this.point2D_0 = position;
    }

    public Point2D2N(Point2D position, Vector2D startNormal, Vector2D endNormal)
    {
      this.point2D_0 = position;
      this.vector2D_0 = startNormal;
      this.vector2D_1 = endNormal;
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

    public Vector2D StartNormal
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

    public Vector2D EndNormal
    {
      get
      {
        return this.vector2D_1;
      }
      set
      {
        this.vector2D_1 = value;
      }
    }

    public Point2D2N GetPoint(Point2D2N nextVertex, double fraction)
    {
      double num = 1.0 - fraction;
      return new Point2D2N(new Point2D(num * this.point2D_0.X + fraction * nextVertex.point2D_0.X, num * this.point2D_0.Y + fraction * nextVertex.point2D_0.Y), (num * this.vector2D_0 + fraction * this.vector2D_1).GetUnit(), this.vector2D_1);
    }

    public Point2D2N GetEndPoint(Point2D2N nextVertex, double fraction)
    {
      double num = 1.0 - fraction;
      return new Point2D2N(new Point2D(num * this.point2D_0.X + fraction * nextVertex.point2D_0.X, num * this.point2D_0.Y + fraction * nextVertex.point2D_0.Y));
    }

    public void SetEndProperties(Point2D2N previousVertex, double fraction)
    {
      this.vector2D_1 = ((1.0 - fraction) * previousVertex.vector2D_0 + fraction * previousVertex.vector2D_1).GetUnit();
    }

    public Point2D2N Clone()
    {
      return new Point2D2N(this.point2D_0, this.vector2D_0, this.vector2D_1) { IsInterpolatedPoint = this.IsInterpolatedPoint };
    }
  }
}
