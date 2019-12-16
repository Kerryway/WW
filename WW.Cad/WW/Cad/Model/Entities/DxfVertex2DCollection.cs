// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfVertex2DCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;

namespace WW.Cad.Model.Entities
{
  public class DxfVertex2DCollection : DxfHandledObjectCollection<DxfVertex2D>, IVertex2DCollection
  {
    public DxfVertex2DCollection()
    {
    }

    public DxfVertex2DCollection(IEnumerable<DxfVertex2D> vertices)
      : base(vertices)
    {
    }

    public DxfVertex2DCollection(int capacity)
      : base(capacity)
    {
    }

    public DxfVertex2DCollection(IEnumerable<WW.Math.Point2D> vertices)
    {
      foreach (WW.Math.Point2D vertex in vertices)
        this.Add(new DxfVertex2D(vertex));
    }

    public DxfVertex2DCollection(IList<WW.Math.Point2D> vertices)
      : base(vertices.Count)
    {
      foreach (WW.Math.Point2D vertex in (IEnumerable<WW.Math.Point2D>) vertices)
        this.Add(new DxfVertex2D(vertex));
    }

    public DxfVertex2DCollection(params WW.Math.Point2D[] vertices)
      : base(vertices.Length)
    {
      foreach (WW.Math.Point2D vertex in vertices)
        this.Add(new DxfVertex2D(vertex));
    }

    public void Add(WW.Math.Point2D vertex)
    {
      this.Add(new DxfVertex2D(vertex));
    }

    public void Add(double x, double y)
    {
      this.Add(new DxfVertex2D(x, y));
    }

    public void AddRange(IEnumerable<WW.Math.Point2D> vertices)
    {
      foreach (WW.Math.Point2D vertex in vertices)
        this.Add(new DxfVertex2D(vertex));
    }

    public void AddRange(params WW.Math.Point2D[] vertices)
    {
      foreach (WW.Math.Point2D vertex in vertices)
        this.Add(new DxfVertex2D(vertex));
    }

    public IVertex2D GetIVertex2D(int index)
    {
      return (IVertex2D) this[index];
    }
  }
}
