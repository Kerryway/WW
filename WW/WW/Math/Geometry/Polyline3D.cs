// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Polyline3D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;

namespace WW.Math.Geometry
{
  [Serializable]
  public class Polyline3D : Polyline<Point3D>
  {
    public Polyline3D(bool closed)
      : base(closed)
    {
    }

    public Polyline3D(int capacity, bool closed)
      : base(capacity, closed)
    {
    }

    public Polyline3D(bool closed, params Point3D[] points)
      : base(closed, points)
    {
    }

    public Polyline3D(bool closed, IList<Point3D> polyline)
      : base(closed, (IEnumerable<Point3D>) polyline)
    {
    }

    public Polyline3D()
      : this(false)
    {
    }

    public Polyline3D(int capacity)
      : this(capacity, false)
    {
    }

    public Polyline3D(params Point3D[] points)
      : this(false, points)
    {
    }

    public Polyline3D(IList<Point3D> polyline)
      : this(false, polyline)
    {
    }

    public Polyline3D(Polyline2D polyline)
      : this(polyline.Count, polyline.Closed)
    {
      for (int index = 0; index < polyline.Count; ++index)
        this.Add((Point3D) polyline[index]);
    }

    public Polyline3D(Polyline3D polyline)
      : this(polyline.Closed, (IList<Point3D>) polyline)
    {
    }

    public Polyline3D GetReverse()
    {
      Polyline3D polyline3D = new Polyline3D(this.Count, this.Closed);
      for (int index = this.Count - 1; index >= 0; --index)
        polyline3D.Add(this[index]);
      return polyline3D;
    }

    public Polyline3D GetSubPolyline(int start, int length)
    {
      return Polyline3D.GetSubPolyline((IList<Point3D>) this, start, length);
    }

    public static Polyline3D GetSubPolyline(IList<Point3D> points, int start, int length)
    {
      Polyline3D polyline3D = new Polyline3D(length);
      int num = start + length;
      for (int index = start; index < num; ++index)
        polyline3D.Add(points[index]);
      return polyline3D;
    }

    public double GetLength()
    {
      return Polyline3D.GetLength((IList<Point3D>) this, this.Closed);
    }

    public static double GetLength(IList<Point3D> points, bool closed)
    {
      double num = 0.0;
      if (points.Count > 1)
      {
        Point3D point3D = points[0];
        for (int index = 1; index < points.Count; ++index)
        {
          Point3D point = points[index];
          num += (point - point3D).GetLength();
          point3D = point;
        }
        if (closed)
          num += (points[0] - point3D).GetLength();
      }
      return num;
    }
  }
}
