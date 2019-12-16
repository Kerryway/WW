// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Polyline4D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;

namespace WW.Math.Geometry
{
  [Serializable]
  public class Polyline4D : Polyline<Vector4D>
  {
    public Polyline4D(bool closed)
      : base(closed)
    {
    }

    public Polyline4D(int capacity, bool closed)
      : base(capacity, closed)
    {
    }

    public Polyline4D(bool closed, params Vector4D[] points)
      : base(closed, points)
    {
    }

    public Polyline4D(bool closed, IList<Vector4D> polyline)
      : base(closed, (IEnumerable<Vector4D>) polyline)
    {
    }

    public Polyline4D()
      : this(false)
    {
    }

    public Polyline4D(int capacity)
      : this(capacity, false)
    {
    }

    public Polyline4D(params Vector4D[] points)
      : this(false, points)
    {
    }

    public Polyline4D(IList<Vector4D> polyline)
      : this(false, polyline)
    {
    }

    public Polyline4D(Polyline4D polyline)
      : this(polyline.Closed, (IList<Vector4D>) polyline)
    {
    }

    public Polyline4D GetReverse()
    {
      Polyline4D polyline4D = new Polyline4D(this.Count, this.Closed);
      for (int index = this.Count - 1; index >= 0; --index)
        polyline4D.Add(this[index]);
      return polyline4D;
    }

    public Polyline4D GetSubPolyline(int start, int length)
    {
      return Polyline4D.GetSubPolyline((IList<Vector4D>) this, start, length);
    }

    public static Polyline4D GetSubPolyline(
      IList<Vector4D> points,
      int start,
      int length)
    {
      Polyline4D polyline4D = new Polyline4D(length);
      int num = start + length;
      for (int index = start; index < num; ++index)
        polyline4D.Add(points[index]);
      return polyline4D;
    }

    public double GetLength()
    {
      return Polyline4D.GetLength((IList<Vector4D>) this, this.Closed);
    }

    public Polyline3D ToPolyline3D()
    {
      Polyline3D polyline3D = new Polyline3D(this.Count, this.Closed);
      foreach (Vector4D vector4D in (List<Vector4D>) this)
        polyline3D.Add(vector4D.ToPoint3D());
      return polyline3D;
    }

    public Polyline2D ToPolyline2D()
    {
      Polyline2D polyline2D = new Polyline2D(this.Count, this.Closed);
      foreach (Vector4D vector4D in (List<Vector4D>) this)
        polyline2D.Add(vector4D.ToPoint2D());
      return polyline2D;
    }

    public static double GetLength(IList<Vector4D> points, bool closed)
    {
      double num = 0.0;
      if (points.Count > 1)
      {
        Vector4D vector4D = points[0];
        for (int index = 1; index < points.Count; ++index)
        {
          Vector4D point = points[index];
          num += (point - vector4D).GetLength();
          vector4D = point;
        }
        if (closed)
          num += (points[0] - vector4D).GetLength();
      }
      return num;
    }
  }
}
