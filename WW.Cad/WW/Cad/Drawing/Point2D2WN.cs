// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Point2D2WN
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Math;

namespace WW.Cad.Drawing
{
  public class Point2D2WN : IExtendedPoint2D<Point2D2WN>, IExtendedPoint2D
  {
    private Point2D point2D_0;
    private double double_0;
    private double double_1;
    private Vector2D vector2D_0;
    private Vector2D vector2D_1;
    private bool bool_0;

    public Point2D2WN()
    {
    }

    public Point2D2WN(Point2D position)
    {
      this.point2D_0 = position;
    }

    public Point2D2WN(Point2D position, double startWidth, double endWidth)
    {
      this.point2D_0 = position;
      this.double_0 = startWidth;
      this.double_1 = endWidth;
    }

    public Point2D2WN(
      Point2D position,
      double startWidth,
      double endWidth,
      Vector2D startNormal,
      Vector2D endNormal)
    {
      this.point2D_0 = position;
      this.double_0 = startWidth;
      this.double_1 = endWidth;
      this.vector2D_0 = startNormal;
      this.vector2D_1 = endNormal;
    }

    public override string ToString()
    {
      return this.point2D_0.ToString();
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

    public double StartWidth
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

    public double EndWidth
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
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

    public bool HasZeroWidth
    {
      get
      {
        if (this.double_0 == 0.0)
          return this.double_1 == 0.0;
        return false;
      }
    }

    public Point2D2WN GetPoint(Point2D2WN nextVertex, double fraction)
    {
      double num = 1.0 - fraction;
      return new Point2D2WN(new Point2D(num * this.point2D_0.X + fraction * nextVertex.point2D_0.X, num * this.point2D_0.Y + fraction * nextVertex.point2D_0.Y), num * this.double_0 + fraction * this.double_1, this.double_1, (num * this.vector2D_0 + fraction * this.vector2D_1).GetUnit(), this.vector2D_1);
    }

    public Point2D2WN GetEndPoint(Point2D2WN nextVertex, double fraction)
    {
      double num = 1.0 - fraction;
      return new Point2D2WN(new Point2D(num * this.point2D_0.X + fraction * nextVertex.point2D_0.X, num * this.point2D_0.Y + fraction * nextVertex.point2D_0.Y));
    }

    public void SetEndProperties(Point2D2WN previousVertex, double fraction)
    {
      double num = 1.0 - fraction;
      this.double_1 = num * previousVertex.double_0 + fraction * previousVertex.double_1;
      this.vector2D_1 = (num * previousVertex.vector2D_0 + fraction * previousVertex.vector2D_1).GetUnit();
    }

    public Point2D2WN Clone()
    {
      return new Point2D2WN(this.point2D_0, this.double_0, this.double_1, this.vector2D_0, this.vector2D_1) { IsInterpolatedPoint = this.IsInterpolatedPoint };
    }
  }
}
