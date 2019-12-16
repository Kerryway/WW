// Decompiled with JetBrains decompiler
// Type: ns30.Class382
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;

namespace ns30
{
  internal class Class382 : Interface22
  {
    private readonly Color color_0;
    private readonly int int_0;
    private readonly Color color_1;

    internal Class382(Color backGroundColor)
    {
      this.color_0 = backGroundColor;
      this.int_0 = backGroundColor.ToArgb() & 16777215;
      this.color_1 = Color.FromArgb((int) byte.MaxValue - (int) backGroundColor.R, (int) byte.MaxValue - (int) backGroundColor.G, (int) byte.MaxValue - (int) backGroundColor.B);
    }

    internal Color BackColor
    {
      get
      {
        return this.color_0;
      }
    }

    public void imethod_0(Graphics graphics, Color color, int x, int y)
    {
      if ((color.ToArgb() & 16777215) == this.int_0)
        color = this.color_1;
      Class735.smethod_3(graphics, color, x, y);
    }

    public Color GetColor(Color color, int colorRgb)
    {
      if (colorRgb == this.int_0)
        return this.color_1;
      return color;
    }
  }
}
