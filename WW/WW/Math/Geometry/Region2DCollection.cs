// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Region2DCollection
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace WW.Math.Geometry
{
  public class Region2DCollection : List<Polygon2DCollection>
  {
    public Region2DCollection()
    {
    }

    public Region2DCollection(int capacity)
      : base(capacity)
    {
    }

    public Region2DCollection(IEnumerable<Polygon2DCollection> collection)
      : base(collection)
    {
    }

    public void ReadFromTextFile(string filename)
    {
      using (StreamReader r = File.OpenText(filename))
        this.ReadFromTextFile(r);
    }

    public void ReadFromTextFile(StreamReader r)
    {
      int num = int.Parse(r.ReadLine());
      for (int index1 = 0; index1 < num; ++index1)
      {
        int capacity1 = int.Parse(r.ReadLine());
        Polygon2DCollection polygon2Dcollection = new Polygon2DCollection(capacity1);
        this.Add(polygon2Dcollection);
        for (int index2 = 0; index2 < capacity1; ++index2)
        {
          int capacity2 = int.Parse(r.ReadLine());
          Polygon2D polygon2D = new Polygon2D(capacity2);
          polygon2Dcollection.Add(polygon2D);
          for (int index3 = 0; index3 < capacity2; ++index3)
          {
            Point2D point2D = Point2D.Parse(r.ReadLine());
            polygon2D.Add(point2D);
          }
        }
      }
    }

    public void WriteToTextFile(string filename)
    {
      using (Stream stream = (Stream) File.OpenWrite(filename))
      {
        using (StreamWriter w = new StreamWriter(stream))
          this.WriteToTextFile(w);
      }
    }

    public void WriteToTextFile(StreamWriter w)
    {
      w.WriteLine(this.Count);
      foreach (Polygon2DCollection polygon2Dcollection in (List<Polygon2DCollection>) this)
      {
        w.WriteLine(polygon2Dcollection.Count);
        foreach (Polygon2D polygon2D in (List<Polygon2D>) polygon2Dcollection)
        {
          w.WriteLine(polygon2D.Count);
          foreach (Point2D point2D in (List<Point2D>) polygon2D)
            w.WriteLine("{0},{1}", (object) point2D.X.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture), (object) point2D.Y.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture));
        }
      }
    }
  }
}
