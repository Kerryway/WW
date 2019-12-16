// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Polyline3DT
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  [Serializable]
  public class Polyline3DT : Polyline<Point3DT>
  {
    public Polyline3DT(bool closed)
      : base(closed)
    {
    }

    public Polyline3DT(int capacity, bool closed)
      : base(capacity, closed)
    {
    }

    public Polyline3DT(bool closed, params Point3DT[] points)
      : base(closed, points)
    {
    }

    public Polyline3DT(bool closed, IList<Point3DT> polyline)
      : base(closed, (IEnumerable<Point3DT>) polyline)
    {
    }

    public Polyline3DT()
      : this(false)
    {
    }

    public Polyline3DT(int capacity)
      : this(capacity, false)
    {
    }

    public Polyline3DT(params Point3DT[] points)
      : this(false, points)
    {
    }

    public Polyline3DT(IList<Point3DT> polyline)
      : this(false, polyline)
    {
    }

    public Polyline3DT(Polyline3DT polyline)
      : this(polyline.Closed, (IList<Point3DT>) polyline)
    {
    }

    public Polyline3DT GetReverse()
    {
      Polyline3DT polyline3Dt = new Polyline3DT(this.Count, this.Closed);
      for (int index = this.Count - 1; index >= 0; --index)
        polyline3Dt.Add(this[index]);
      return polyline3Dt;
    }

    public Polyline3DT GetSubPolyline(int start, int length)
    {
      return Polyline3DT.GetSubPolyline((IList<Point3DT>) this, start, length);
    }

    public static Polyline3DT GetSubPolyline(
      IList<Point3DT> points,
      int start,
      int length)
    {
      Polyline3DT polyline3Dt = new Polyline3DT(length);
      int num = start + length;
      for (int index = start; index < num; ++index)
        polyline3Dt.Add(points[index]);
      return polyline3Dt;
    }

    public double GetLength()
    {
      return Polyline3DT.GetLength((IList<Point3DT>) this, this.Closed);
    }

    public static double GetLength(IList<Point3DT> points, bool closed)
    {
      double num = 0.0;
      if (points.Count > 1)
      {
        Point3DT point3Dt = points[0];
        for (int index = 1; index < points.Count; ++index)
        {
          Point3DT point = points[index];
          num += (point.Position - point3Dt.Position).GetLength();
          point3Dt = point;
        }
        if (closed)
          num += (points[0].Position - point3Dt.Position).GetLength();
      }
      return num;
    }

    public Polyline3D ToPolyline3D()
    {
      Polyline3D polyline3D = new Polyline3D(this.Count, this.Closed);
      for (int index = 0; index < this.Count; ++index)
        polyline3D.Add(this[index].Position);
      return polyline3D;
    }
  }
}
