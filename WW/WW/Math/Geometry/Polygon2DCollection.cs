// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Polygon2DCollection
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using WW.Math.Exact.Geometry;

namespace WW.Math.Geometry
{
  [Serializable]
  public class Polygon2DCollection : List<Polygon2D>, IShape2D
  {
    public Polygon2DCollection()
    {
    }

    public Polygon2DCollection(int capacity)
      : base(capacity)
    {
    }

    public Polygon2DCollection(IEnumerable<Polygon2D> collection)
      : base(collection)
    {
    }

    public Polygon2DCollection(params IEnumerable<Polygon2D>[] collections)
    {
      foreach (IEnumerable<Polygon2D> collection in collections)
      {
        foreach (Polygon2D polygon2D in collection)
          this.Add(polygon2D);
      }
    }

    public Polygon2DCollection(ICollection<Polygon2BR> polygons)
      : base(polygons.Count)
    {
      foreach (Polygon2BR polygon in (IEnumerable<Polygon2BR>) polygons)
        this.Add(polygon.ToPolygon2D());
    }

    public Polygon2DCollection(ICollection<Polygon2BR> polygons1, ICollection<Polygon2BR> polygons2)
      : base(polygons1.Count + polygons2.Count)
    {
      foreach (Polygon2BR polygon2Br in (IEnumerable<Polygon2BR>) polygons1)
        this.Add(polygon2Br.ToPolygon2D());
      foreach (Polygon2BR polygon2Br in (IEnumerable<Polygon2BR>) polygons2)
        this.Add(polygon2Br.ToPolygon2D());
    }

    public Polygon2DCollection(ICollection<Polygon2LR> polygons)
      : base(polygons.Count)
    {
      foreach (Polygon2LR polygon in (IEnumerable<Polygon2LR>) polygons)
        this.Add(polygon.ToPolygon2D());
    }

    public Polygon2DCollection(ICollection<Polygon2LR> polygons1, ICollection<Polygon2LR> polygons2)
      : base(polygons1.Count + polygons2.Count)
    {
      foreach (Polygon2LR polygon2Lr in (IEnumerable<Polygon2LR>) polygons1)
        this.Add(polygon2Lr.ToPolygon2D());
      foreach (Polygon2LR polygon2Lr in (IEnumerable<Polygon2LR>) polygons2)
        this.Add(polygon2Lr.ToPolygon2D());
    }

    public ISegment2DIterator CreateIterator()
    {
      return (ISegment2DIterator) Shape2DCollectionIterator.Create<Polygon2D>((IEnumerable<Polygon2D>) this, false);
    }

    public void AddToBounds(Bounds2D bounds)
    {
      foreach (Polygon2D polygon2D in (List<Polygon2D>) this)
        polygon2D.AddToBounds(bounds);
    }

    public bool HasSegments
    {
      get
      {
        foreach (Polygon2D polygon2D in (List<Polygon2D>) this)
        {
          if (polygon2D.HasSegments)
            return true;
        }
        return false;
      }
    }
  }
}
