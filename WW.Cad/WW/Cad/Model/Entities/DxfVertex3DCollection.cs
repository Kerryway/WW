// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfVertex3DCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;

namespace WW.Cad.Model.Entities
{
  public class DxfVertex3DCollection : DxfHandledObjectCollection<DxfVertex3D>
  {
    public DxfVertex3DCollection()
    {
    }

    public DxfVertex3DCollection(IEnumerable<DxfVertex3D> vertices)
      : base(vertices)
    {
    }

    public DxfVertex3DCollection(int capacity)
      : base(capacity)
    {
    }

    public DxfVertex3DCollection(IEnumerable<WW.Math.Point3D> vertices)
    {
      foreach (WW.Math.Point3D vertex in vertices)
        this.Add(new DxfVertex3D(vertex));
    }

    public DxfVertex3DCollection(IList<WW.Math.Point3D> vertices)
      : base(vertices.Count)
    {
      foreach (WW.Math.Point3D vertex in (IEnumerable<WW.Math.Point3D>) vertices)
        this.Add(new DxfVertex3D(vertex));
    }

    public DxfVertex3DCollection(params WW.Math.Point3D[] vertices)
      : base(vertices.Length)
    {
      foreach (WW.Math.Point3D vertex in vertices)
        this.Add(new DxfVertex3D(vertex));
    }

    public void Add(WW.Math.Point3D vertex)
    {
      this.Add(new DxfVertex3D(vertex));
    }

    public void Add(double x, double y, double z)
    {
      this.Add(new DxfVertex3D(x, y, z));
    }

    public void AddRange(IEnumerable<WW.Math.Point3D> vertices)
    {
      foreach (WW.Math.Point3D vertex in vertices)
        this.Add(new DxfVertex3D(vertex));
    }

    public void AddRange(params WW.Math.Point3D[] vertices)
    {
      foreach (WW.Math.Point3D vertex in vertices)
        this.Add(new DxfVertex3D(vertex));
    }
  }
}
