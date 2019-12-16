// Decompiled with JetBrains decompiler
// Type: ns33.Class1073
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Drawing;
using WW.Math;

namespace ns33
{
  internal class Class1073
  {
    private readonly ArgbColor argbColor_0;
    private readonly bool bool_0;
    private Point2D point2D_0;
    private readonly double double_0;
    private readonly double double_1;
    private readonly double double_2;

    public Class1073(
      ArgbColor color,
      bool fill,
      Point2D position,
      double ascent,
      double descent,
      double width)
    {
      this.argbColor_0 = color;
      this.bool_0 = fill;
      this.point2D_0 = position;
      this.double_0 = ascent;
      this.double_1 = descent;
      this.double_2 = width;
    }

    public ArgbColor Color
    {
      get
      {
        return this.argbColor_0;
      }
    }

    public bool Fill
    {
      get
      {
        return this.bool_0;
      }
    }

    public Point2D Position
    {
      get
      {
        return this.point2D_0;
      }
      set
      {
        this.point2D_0 = value;
      }
    }

    public double Ascent
    {
      get
      {
        return this.double_0;
      }
    }

    public double Descent
    {
      get
      {
        return this.double_1;
      }
    }

    public double Width
    {
      get
      {
        return this.double_2;
      }
    }

    public Point2D TopLeft
    {
      get
      {
        return this.point2D_0 + new Vector2D(0.0, this.double_0);
      }
    }

    public Point2D BottomLeft
    {
      get
      {
        return this.point2D_0 - new Vector2D(0.0, this.double_1);
      }
    }

    public Point2D TopRight
    {
      get
      {
        return this.point2D_0 + new Vector2D(this.double_2, this.double_0);
      }
    }

    public void GetBounds(Bounds2D bounds)
    {
      bounds.Update(this.BottomLeft);
      bounds.Update(this.TopRight);
    }
  }
}
