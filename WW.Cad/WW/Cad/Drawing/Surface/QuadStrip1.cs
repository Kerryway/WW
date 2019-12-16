// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.QuadStrip1
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class QuadStrip1 : IPrimitive
  {
    private IList<Point3D> ilist_0;
    private IList<Point3D> ilist_1;
    private Vector3D vector3D_0;
    private bool bool_0;

    public QuadStrip1()
    {
    }

    public QuadStrip1(
      IList<Point3D> polyline1,
      IList<Point3D> polyline2,
      Vector3D normal,
      bool closed)
    {
      this.ilist_0 = polyline1;
      this.ilist_1 = polyline2;
      this.vector3D_0 = normal;
      this.bool_0 = closed;
    }

    public IList<Point3D> Polyline1
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

    public IList<Point3D> Polyline2
    {
      get
      {
        return this.ilist_1;
      }
      set
      {
        this.ilist_1 = value;
      }
    }

    public Vector3D Normal
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        this.vector3D_0 = value;
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
  }
}
