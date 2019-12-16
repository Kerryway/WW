// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.Polyline3D
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class Polyline3D : IPrimitive
  {
    private IList<Point3D> ilist_0;
    private bool bool_0;

    private Polyline3D()
    {
    }

    private Polyline3D(IList<Point3D> points, bool closed)
    {
      this.ilist_0 = points;
      this.bool_0 = closed;
    }

    private Polyline3D(WW.Math.Geometry.Polyline3D polyline)
    {
      this.ilist_0 = (IList<Point3D>) polyline;
      this.bool_0 = polyline.Closed;
    }

    public IList<Point3D> Points
    {
      get
      {
        return this.ilist_0;
      }
      set
      {
        this.ilist_0 = value;
      }
    }

    public bool Closed
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

    public void Accept(IPrimitiveVisitor visitor)
    {
      visitor.Visit(this);
    }

    public static IPrimitive CreatePrimitive(WW.Math.Geometry.Polyline3D polyline)
    {
      if (polyline == null)
        throw new ArgumentNullException();
      if (polyline.Count > 2)
        return (IPrimitive) new Polyline3D(polyline);
      if (polyline.Count == 1)
        return (IPrimitive) new Point(polyline[0]);
      return (IPrimitive) new Segment(polyline[0], polyline[1]);
    }

    public static IPrimitive CreatePrimitive(IList<Point3D> polyline, bool closed)
    {
      if (polyline == null)
        throw new ArgumentNullException();
      if (polyline.Count > 2)
        return (IPrimitive) new Polyline3D(polyline, closed);
      if (polyline.Count == 1)
        return (IPrimitive) new Point(polyline[0]);
      return (IPrimitive) new Segment(polyline[0], polyline[1]);
    }
  }
}
