// Decompiled with JetBrains decompiler
// Type: ns29.Class621
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Windows.Media;
using WW.Drawing;

namespace ns29
{
  internal class Class621 : Interface11
  {
    private readonly ArgbColor argbColor_0;
    private readonly int int_0;
    private readonly ArgbColor argbColor_1;
    private readonly Brush brush_0;

    internal Class621(ArgbColor backGroundColor)
    {
      this.argbColor_0 = backGroundColor;
      this.int_0 = backGroundColor.Argb & 16777215;
      this.argbColor_1 = new ArgbColor((int) byte.MaxValue - (int) backGroundColor.R, (int) byte.MaxValue - (int) backGroundColor.G, (int) byte.MaxValue - (int) backGroundColor.B);
      this.brush_0 = Class1072.smethod_1(this.argbColor_1);
    }

    internal ArgbColor BackColor
    {
      get
      {
        return this.argbColor_0;
      }
    }

    public Pen imethod_1(ArgbColor color, double penThickness)
    {
      if ((color.Argb & 16777215) == this.int_0)
        return Class1072.smethod_0(new PenInfo(this.argbColor_1, penThickness));
      return Class1072.smethod_0(new PenInfo(color, penThickness));
    }

    public Brush imethod_0(ArgbColor color)
    {
      if ((color.Argb & 16777215) == this.int_0)
        return Class1072.smethod_1(this.argbColor_1);
      return Class1072.smethod_1(color);
    }
  }
}
