// Decompiled with JetBrains decompiler
// Type: ns33.Class454
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace ns33
{
  internal class Class454
  {
    private readonly List<Triangulator2D.Triangle> list_0 = new List<Triangulator2D.Triangle>();
    private readonly List<Point2D> list_1 = new List<Point2D>();

    internal Class454(IShape2D shape, GraphicsConfig config)
    {
      IList<Polyline2D> flattened = (IList<Polyline2D>) ShapeTool.GetFlattened(shape, config.ShapeFlattenEpsilon);
      if (flattened != null)
      {
        IList<Polygon2D> input1 = (IList<Polygon2D>) new List<Polygon2D>(flattened.Count);
        IList<Polygon2D> polygon2DList = (IList<Polygon2D>) new List<Polygon2D>();
        for (int index = 0; index < flattened.Count; ++index)
        {
          Polygon2D polygon2D = new Polygon2D((IEnumerable<Point2D>) flattened[index]);
          if (polygon2D.IsClockwise())
            polygon2DList.Add(polygon2D);
          else if (input1.Count == 0)
            input1.Add(polygon2D);
          else
            input1 = (IList<Polygon2D>) Polygon2D.GetUnion(input1, (IList<Polygon2D>) new Polygon2D[1]
            {
              polygon2D
            });
        }
        List<IList<Point2D>> point2DListList = new List<IList<Point2D>>(input1.Count + polygon2DList.Count);
        point2DListList.AddRange((IEnumerable<IList<Point2D>>) input1);
        point2DListList.AddRange((IEnumerable<IList<Point2D>>) polygon2DList);
        Triangulator2D.Triangulate((IList<IList<Point2D>>) point2DListList, (IList<Triangulator2D.Triangle>) this.list_0, (IList<Point2D>) this.list_1);
      }
      else
      {
        this.list_0 = (List<Triangulator2D.Triangle>) null;
        this.list_1 = (List<Point2D>) null;
      }
    }

    public List<Triangulator2D.Triangle> Triangles
    {
      get
      {
        return this.list_0;
      }
    }

    public List<Point2D> Points
    {
      get
      {
        return this.list_1;
      }
    }
  }
}
