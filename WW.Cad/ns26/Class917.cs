// Decompiled with JetBrains decompiler
// Type: ns26.Class917
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections;
using System.Collections.Generic;
using WW.Math;

namespace ns26
{
  internal class Class917 : IEnumerable, IEnumerable<Point3D>
  {
    private readonly List<Point3D> list_0 = new List<Point3D>();

    public void method_0(Point3D point)
    {
      this.list_0.Add(point);
    }

    public void method_1(params Point3D[] addPoints)
    {
      foreach (Point3D addPoint in addPoints)
        this.method_0(addPoint);
    }

    public void method_2(IEnumerable<Point3D> addPoints)
    {
      foreach (Point3D addPoint in addPoints)
        this.method_0(addPoint);
    }

    public void method_3(params Point3D[] addPoints)
    {
      for (int index = addPoints.Length - 1; index >= 0; --index)
        this.method_0(this.list_0[index]);
    }

    public void method_4(IEnumerable<Point3D> addPoints)
    {
      int count = this.list_0.Count;
      foreach (Point3D addPoint in addPoints)
        this.list_0.Insert(count, addPoint);
    }

    public void method_5(IEnumerable<Point3D> addPoints, bool reversed)
    {
      if (reversed)
        this.method_4(addPoints);
      else
        this.method_2(addPoints);
    }

    public Point3D[] Points
    {
      get
      {
        return this.list_0.ToArray();
      }
    }

    public Point3D this[int index]
    {
      get
      {
        return this.list_0[index];
      }
    }

    public int Count
    {
      get
      {
        return this.list_0.Count;
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.GetEnumerator();
    }

    public IEnumerator<Point3D> GetEnumerator()
    {
      return (IEnumerator<Point3D>) this.list_0.GetEnumerator();
    }
  }
}
