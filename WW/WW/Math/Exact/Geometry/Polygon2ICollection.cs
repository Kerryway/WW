// Decompiled with JetBrains decompiler
// Type: WW.Math.Exact.Geometry.Polygon2ICollection
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;

namespace WW.Math.Exact.Geometry
{
  [Serializable]
  public class Polygon2ICollection : List<Polygon2I>
  {
    public Polygon2ICollection()
    {
    }

    public Polygon2ICollection(int capacity)
      : base(capacity)
    {
    }

    public Polygon2ICollection(IEnumerable<Polygon2I> collection)
      : base(collection)
    {
    }

    public Polygon2ICollection(params IEnumerable<Polygon2I>[] collections)
    {
      foreach (IEnumerable<Polygon2I> collection in collections)
      {
        foreach (Polygon2I polygon2I in collection)
          this.Add(polygon2I);
      }
    }
  }
}
