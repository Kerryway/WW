// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Polyline2DCollection
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;

namespace WW.Math.Geometry
{
  [Serializable]
  public class Polyline2DCollection : List<Polyline2D>, IShape2D
  {
    public Polyline2DCollection()
    {
    }

    public Polyline2DCollection(int capacity)
      : base(capacity)
    {
    }

    public Polyline2DCollection(IEnumerable<Polyline2D> collection)
      : base(collection)
    {
    }

    public ISegment2DIterator CreateIterator()
    {
      return (ISegment2DIterator) Shape2DCollectionIterator.Create<Polyline2D>((IEnumerable<Polyline2D>) this, false);
    }

    public void AddToBounds(Bounds2D bounds)
    {
      foreach (Polyline2D polyline2D in (List<Polyline2D>) this)
        polyline2D.AddToBounds(bounds);
    }

    public bool HasSegments
    {
      get
      {
        foreach (Polyline2D polyline2D in (List<Polyline2D>) this)
        {
          if (polyline2D.HasSegments)
            return true;
        }
        return false;
      }
    }
  }
}
