// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Polyline2DE
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public class Polyline2DE : Polyline<Point2DE>
  {
    public static IPolylineFactory<Point2DE, Polyline2DE> Factory = (IPolylineFactory<Point2DE, Polyline2DE>) new Polyline2DE.Class806();

    public Polyline2DE()
    {
    }

    public Polyline2DE(bool closed)
      : base(closed)
    {
    }

    public Polyline2DE(int capacity)
      : base(capacity)
    {
    }

    public Polyline2DE(int capacity, bool closed)
      : base(capacity, closed)
    {
    }

    public Polyline2DE(bool closed, IEnumerable<Point2DE> vertices)
      : base(closed, vertices)
    {
    }

    public Polyline2DE(bool closed, params Point2DE[] vertices)
      : base(closed, vertices)
    {
    }

    public Polyline2DE(params Point2DE[] vertices)
      : base(vertices)
    {
    }

    public Polyline2DE(IEnumerable<Point2DE> points)
      : base(points)
    {
    }

    public Polyline2DE(Polyline<Point2DE> polyline)
      : base(polyline)
    {
    }

    public double GetLength()
    {
      return Polyline2DE.GetLength((IList<Point2DE>) this, this.Closed);
    }

    public static double GetLength(IList<Point2DE> points, bool closed)
    {
      double num = 0.0;
      if (points.Count > 1)
      {
        Point2DE point2De = points[0];
        for (int index = 1; index < points.Count; ++index)
        {
          Point2DE point = points[index];
          num += (point.Position - point2De.Position).GetLength();
          point2De = point;
        }
        if (closed)
          num += (points[0].Position - point2De.Position).GetLength();
      }
      return num;
    }

    private class Class806 : IPolylineFactory<Point2DE, Polyline2DE>
    {
      public Polyline2DE Create(bool closed)
      {
        return new Polyline2DE(closed);
      }

      public Polyline2DE Create(int capacity, bool closed)
      {
        return new Polyline2DE(capacity, closed);
      }

      public Polyline2DE Create(bool closed, params Point2DE[] polyline)
      {
        return new Polyline2DE(closed, polyline);
      }

      public Polyline2DE Create(bool closed, IEnumerable<Point2DE> polyline)
      {
        return new Polyline2DE(closed, polyline);
      }

      public Polyline2DE Create()
      {
        return new Polyline2DE();
      }

      public Polyline2DE Create(int capacity)
      {
        return new Polyline2DE(capacity);
      }

      public Polyline2DE Create(params Point2DE[] points)
      {
        return new Polyline2DE(points);
      }

      public Polyline2DE Create(IEnumerable<Point2DE> points)
      {
        return new Polyline2DE(points);
      }

      public Polyline2DE Create(Polyline<Point2DE> polyline)
      {
        return new Polyline2DE(polyline);
      }
    }
  }
}
