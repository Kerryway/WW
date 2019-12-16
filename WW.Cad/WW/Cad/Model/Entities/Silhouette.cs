// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.Silhouette
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math;

namespace WW.Cad.Model.Entities
{
  public class Silhouette
  {
    private Vector3D vector3D_1 = Vector3D.YAxis;
    private List<Wire> list_0 = new List<Wire>();
    private long long_0;
    private WW.Math.Point3D point3D_0;
    private Vector3D vector3D_0;
    private bool bool_0;

    public long ViewportId
    {
      get
      {
        return this.long_0;
      }
      set
      {
        this.long_0 = value;
      }
    }

    public WW.Math.Point3D ViewportTarget
    {
      get
      {
        return this.point3D_0;
      }
      set
      {
        this.point3D_0 = value;
      }
    }

    public Vector3D ViewportDirectionFromTarget
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

    public Vector3D ViewportUpDirection
    {
      get
      {
        return this.vector3D_1;
      }
      set
      {
        this.vector3D_1 = value;
      }
    }

    public bool ViewportPerspectiveMode
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

    public List<Wire> Wires
    {
      get
      {
        return this.list_0;
      }
    }
  }
}
