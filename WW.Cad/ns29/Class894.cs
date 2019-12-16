// Decompiled with JetBrains decompiler
// Type: ns29.Class894
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Windows.Media;
using WW.Drawing;

namespace ns29
{
  internal class Class894 : Interface11
  {
    private readonly ArgbColor argbColor_0;
    private readonly Brush brush_0;

    internal Class894(ArgbColor foregroundColor)
    {
      this.argbColor_0 = foregroundColor;
      this.brush_0 = Class1072.smethod_1(foregroundColor);
    }

    public Brush imethod_0(ArgbColor color)
    {
      return this.brush_0;
    }

    public Pen imethod_1(ArgbColor color, double penThickness)
    {
      return Class1072.smethod_0(new PenInfo(this.argbColor_0, penThickness));
    }
  }
}
