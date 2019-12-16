// Decompiled with JetBrains decompiler
// Type: ns30.Class1035
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;

namespace ns30
{
  internal class Class1035 : Interface22
  {
    private readonly Color color_0;

    internal Class1035(Color foregroundColor)
    {
      this.color_0 = foregroundColor;
    }

    public void imethod_0(Graphics graphics, Color color, int x, int y)
    {
      Class735.smethod_3(graphics, this.color_0, x, y);
    }

    public Color GetColor(Color color, int colorRgb)
    {
      return this.color_0;
    }
  }
}
