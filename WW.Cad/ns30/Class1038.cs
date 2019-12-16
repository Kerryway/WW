// Decompiled with JetBrains decompiler
// Type: ns30.Class1038
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Math.Geometry;

namespace ns30
{
  internal class Class1038
  {
    protected Graphics graphics_0;
    protected SmoothingMode? nullable_0;
    protected SmoothingMode smoothingMode_0;
    protected BlinnClipper4D blinnClipper4D_0;
    protected Interface22 interface22_0;
    protected Interface22 interface22_1;
    protected Interface22 interface22_2;

    public Graphics Graphics
    {
      get
      {
        return this.graphics_0;
      }
    }

    public SmoothingMode InitialSmoothingMode
    {
      get
      {
        return this.smoothingMode_0;
      }
    }

    public BlinnClipper4D DrawingBoundsClipper
    {
      get
      {
        return this.blinnClipper4D_0;
      }
    }

    public Interface22 ColorContext
    {
      get
      {
        return this.interface22_0;
      }
    }

    public void method_0()
    {
      if (this.nullable_0.HasValue)
        this.graphics_0.SmoothingMode = this.nullable_0.Value;
      this.interface22_0 = this.interface22_2;
    }

    public void method_1()
    {
      if (this.nullable_0.HasValue)
        this.graphics_0.SmoothingMode = this.smoothingMode_0;
      this.interface22_0 = this.interface22_1;
    }
  }
}
