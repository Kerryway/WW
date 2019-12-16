// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.QuadStrip2
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class QuadStrip2 : IPrimitive
  {
    private IList<Point3D> ilist_0;
    private IList<Point3D> ilist_1;
    private IList<Vector3D> ilist_2;
    private int int_0;
    private int int_1;

    public QuadStrip2()
    {
    }

    public QuadStrip2(
      IList<Point3D> polyline1,
      IList<Point3D> polyline2,
      IList<Vector3D> normals,
      int startVertexIndex,
      int endVertexIndex)
    {
      this.ilist_0 = polyline1;
      this.ilist_1 = polyline2;
      this.ilist_2 = normals;
      this.int_0 = startVertexIndex;
      this.int_1 = endVertexIndex;
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

    public IList<Vector3D> Normals
    {
      get
      {
        return this.ilist_2;
      }
      set
      {
        this.ilist_2 = value;
      }
    }

    public int StartVertexIndex
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public int EndVertexIndex
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public void Accept(IPrimitiveVisitor visitor)
    {
      visitor.Visit(this);
    }
  }
}
