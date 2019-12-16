// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Surface.Geometry
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math;

namespace WW.Cad.Drawing.Surface
{
  public class Geometry : List<IPrimitive>
  {
    private bool bool_0;
    private Vector3D vector3D_0;

    public Geometry()
    {
    }

    public Geometry(int capacity)
      : base(capacity)
    {
    }

    public Geometry(IEnumerable<IPrimitive> collection)
      : base(collection)
    {
    }

    public Geometry(IPrimitive primitive)
      : base(1)
    {
      this.Add(primitive);
    }

    public Geometry(IPrimitive primitive1, IPrimitive primitive2)
      : base(2)
    {
      this.Add(primitive1);
      this.Add(primitive2);
    }

    public Geometry(IPrimitive primitive1, IPrimitive primitive2, IPrimitive primitive3)
      : base(3)
    {
      this.Add(primitive1);
      this.Add(primitive2);
      this.Add(primitive3);
    }

    public Geometry(
      IPrimitive primitive1,
      IPrimitive primitive2,
      IPrimitive primitive3,
      IPrimitive primitive4)
      : base(4)
    {
      this.Add(primitive1);
      this.Add(primitive2);
      this.Add(primitive3);
      this.Add(primitive4);
    }

    public Geometry(
      IPrimitive primitive1,
      IPrimitive primitive2,
      IPrimitive primitive3,
      IPrimitive primitive4,
      IPrimitive primitive5)
      : base(5)
    {
      this.Add(primitive1);
      this.Add(primitive2);
      this.Add(primitive3);
      this.Add(primitive4);
      this.Add(primitive5);
    }

    public bool HasExtrusion
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

    public Vector3D Extrusion
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        this.vector3D_0 = value;
        this.bool_0 = true;
      }
    }
  }
}
