// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Polyline2D2N
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public class Polyline2D2N : Polyline<Point2D2N>
  {
    public static IPolylineFactory<Point2D2N, Polyline2D2N> Factory = (IPolylineFactory<Point2D2N, Polyline2D2N>) new Polyline2D2N.Class623();

    public Polyline2D2N()
    {
    }

    public Polyline2D2N(bool closed)
      : base(closed)
    {
    }

    public Polyline2D2N(int capacity)
      : base(capacity)
    {
    }

    public Polyline2D2N(int capacity, bool closed)
      : base(capacity, closed)
    {
    }

    public Polyline2D2N(bool closed, IEnumerable<Point2D2N> vertices)
      : base(closed, vertices)
    {
    }

    public Polyline2D2N(bool closed, params Point2D2N[] vertices)
      : base(closed, vertices)
    {
    }

    public Polyline2D2N(params Point2D2N[] vertices)
      : base(vertices)
    {
    }

    public Polyline2D2N(IEnumerable<Point2D2N> points)
      : base(points)
    {
    }

    public Polyline2D2N(Polyline<Point2D2N> polyline)
      : base(polyline)
    {
    }

    public double GetLength()
    {
      return Polyline2D2N.GetLength((IList<Point2D2N>) this, this.Closed);
    }

    public static double GetLength(IList<Point2D2N> points, bool closed)
    {
      double num = 0.0;
      if (points.Count > 1)
      {
        Point2D2N point2D2N = points[0];
        for (int index = 1; index < points.Count; ++index)
        {
          Point2D2N point = points[index];
          num += (point.Position - point2D2N.Position).GetLength();
          point2D2N = point;
        }
        if (closed)
          num += (points[0].Position - point2D2N.Position).GetLength();
      }
      return num;
    }

    private class Class623 : IPolylineFactory<Point2D2N, Polyline2D2N>
    {
      public Polyline2D2N Create(bool closed)
      {
        return new Polyline2D2N(closed);
      }

      public Polyline2D2N Create(int capacity, bool closed)
      {
        return new Polyline2D2N(capacity, closed);
      }

      public Polyline2D2N Create(bool closed, params Point2D2N[] polyline)
      {
        return new Polyline2D2N(closed, polyline);
      }

      public Polyline2D2N Create(bool closed, IEnumerable<Point2D2N> polyline)
      {
        return new Polyline2D2N(closed, polyline);
      }

      public Polyline2D2N Create()
      {
        return new Polyline2D2N();
      }

      public Polyline2D2N Create(int capacity)
      {
        return new Polyline2D2N(capacity);
      }

      public Polyline2D2N Create(params Point2D2N[] points)
      {
        return new Polyline2D2N(points);
      }

      public Polyline2D2N Create(IEnumerable<Point2D2N> points)
      {
        return new Polyline2D2N(points);
      }

      public Polyline2D2N Create(Polyline<Point2D2N> polyline)
      {
        return new Polyline2D2N(polyline);
      }
    }
  }
}
