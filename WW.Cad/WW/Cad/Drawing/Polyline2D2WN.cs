// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Polyline2D2WN
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using System.Diagnostics;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public class Polyline2D2WN : Polyline<Point2D2WN>
  {
    public static IPolylineFactory<Point2D2WN, Polyline2D2WN> Factory = (IPolylineFactory<Point2D2WN, Polyline2D2WN>) new Polyline2D2WN.Class1052();

    [DebuggerStepThrough]
    public Polyline2D2WN(bool closed)
      : base(closed)
    {
    }

    [DebuggerStepThrough]
    public Polyline2D2WN(int capacity, bool closed)
      : base(capacity, closed)
    {
    }

    [DebuggerStepThrough]
    public Polyline2D2WN(bool closed, params Point2D2WN[] polyline)
      : base(closed, polyline)
    {
    }

    [DebuggerStepThrough]
    public Polyline2D2WN(bool closed, IEnumerable<Point2D2WN> polyline)
      : base(closed, polyline)
    {
    }

    [DebuggerStepThrough]
    public Polyline2D2WN()
    {
    }

    [DebuggerStepThrough]
    public Polyline2D2WN(int capacity)
      : base(capacity)
    {
    }

    [DebuggerStepThrough]
    public Polyline2D2WN(params Point2D2WN[] points)
      : base(points)
    {
    }

    [DebuggerStepThrough]
    public Polyline2D2WN(IEnumerable<Point2D2WN> points)
      : base(points)
    {
    }

    [DebuggerStepThrough]
    public Polyline2D2WN(Polyline<Point2D2WN> polyline)
      : base(polyline)
    {
    }

    public double GetLength()
    {
      return Polyline2D2WN.GetLength((IList<Point2D2WN>) this, this.Closed);
    }

    public static double GetLength(IList<Point2D2WN> points, bool closed)
    {
      double num = 0.0;
      if (points.Count > 1)
      {
        Point2D2WN point2D2Wn = points[0];
        for (int index = 1; index < points.Count; ++index)
        {
          Point2D2WN point = points[index];
          num += (point.Position - point2D2Wn.Position).GetLength();
          point2D2Wn = point;
        }
        if (closed)
          num += (points[0].Position - point2D2Wn.Position).GetLength();
      }
      return num;
    }

    private class Class1052 : IPolylineFactory<Point2D2WN, Polyline2D2WN>
    {
      public Polyline2D2WN Create(bool closed)
      {
        return new Polyline2D2WN(closed);
      }

      public Polyline2D2WN Create(int capacity, bool closed)
      {
        return new Polyline2D2WN(capacity, closed);
      }

      public Polyline2D2WN Create(bool closed, params Point2D2WN[] polyline)
      {
        return new Polyline2D2WN(closed, polyline);
      }

      public Polyline2D2WN Create(bool closed, IEnumerable<Point2D2WN> polyline)
      {
        return new Polyline2D2WN(closed, polyline);
      }

      public Polyline2D2WN Create()
      {
        return new Polyline2D2WN();
      }

      public Polyline2D2WN Create(int capacity)
      {
        return new Polyline2D2WN(capacity);
      }

      public Polyline2D2WN Create(params Point2D2WN[] points)
      {
        return new Polyline2D2WN(points);
      }

      public Polyline2D2WN Create(IEnumerable<Point2D2WN> points)
      {
        return new Polyline2D2WN(points);
      }

      public Polyline2D2WN Create(Polyline<Point2D2WN> polyline)
      {
        return new Polyline2D2WN(polyline);
      }
    }
  }
}
