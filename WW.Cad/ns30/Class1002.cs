// Decompiled with JetBrains decompiler
// Type: ns30.Class1002
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;
using WW.Cad.Drawing;

namespace ns30
{
  internal class Class1002 : Interface22
  {
    public void imethod_0(Graphics graphics, Color color, int x, int y)
    {
      Class735.smethod_3(graphics, color, x, y);
    }

    public Color GetColor(Color color, int colorRgb)
    {
      return color;
    }

    public static Interface22 Create(GraphicsConfig config, float penWidth)
    {
      return !config.FixedForegroundColor.HasValue ? (!config.CorrectColorForBackgroundColor ? (Interface22) new Class1002() : (Interface22) new Class382((Color) config.BackColor)) : (Interface22) new Class1035((Color) config.FixedForegroundColor.Value);
    }
  }
}
