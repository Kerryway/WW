// Decompiled with JetBrains decompiler
// Type: ns33.Class1051
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math;

namespace ns33
{
  internal class Class1051
  {
    private readonly List<Class1073> list_0 = new List<Class1073>();

    public List<Class1073> Sections
    {
      get
      {
        return this.list_0;
      }
    }

    public double Top
    {
      get
      {
        double val1 = 0.0;
        foreach (Class1073 class1073 in this.list_0)
          val1 = System.Math.Max(val1, class1073.TopLeft.Y);
        return val1;
      }
    }

    public double Bottom
    {
      get
      {
        double val1 = 0.0;
        foreach (Class1073 class1073 in this.list_0)
          val1 = System.Math.Min(val1, class1073.BottomLeft.Y);
        return val1;
      }
    }

    public void GetBounds(Bounds2D bounds)
    {
      foreach (Class1073 class1073 in this.list_0)
        class1073.GetBounds(bounds);
    }

    public Bounds2D GetBounds()
    {
      Bounds2D bounds = new Bounds2D();
      this.GetBounds(bounds);
      return bounds;
    }

    public void method_0(Vector2D translation)
    {
      foreach (Class1073 class1073 in this.list_0)
        class1073.Position += translation;
    }
  }
}
