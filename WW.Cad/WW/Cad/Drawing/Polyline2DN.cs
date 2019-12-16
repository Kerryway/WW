// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.Polyline2DN
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public class Polyline2DN : Polyline<Point2DN>
  {
    public Polyline2DN()
    {
    }

    public Polyline2DN(bool closed)
      : base(closed)
    {
    }

    public Polyline2DN(int capacity, bool closed)
      : base(capacity, closed)
    {
    }

    public Polyline2DN(bool closed, IEnumerable<Point2DN> vertices)
      : base(closed, vertices)
    {
    }

    public Polyline2DN(bool closed, params Point2DN[] vertices)
      : base(closed, vertices)
    {
    }

    public Polyline2DN(params Point2DN[] vertices)
      : base(vertices)
    {
    }
  }
}
