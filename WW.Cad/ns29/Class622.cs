// Decompiled with JetBrains decompiler
// Type: ns29.Class622
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Windows.Media;
using WW.Cad.Drawing;
using WW.Drawing;

namespace ns29
{
  internal class Class622 : Interface11
  {
    public static Interface11 Create(GraphicsConfig config)
    {
      return !config.FixedForegroundColor.HasValue ? (!config.CorrectColorForBackgroundColor ? (Interface11) new Class622() : (Interface11) new Class621(config.BackColor)) : (Interface11) new Class894(config.FixedForegroundColor.Value);
    }

    public Brush imethod_0(ArgbColor color)
    {
      return Class1072.smethod_1(color);
    }

    public Pen imethod_1(ArgbColor color, double penThickness)
    {
      return Class1072.smethod_0(new PenInfo(color, penThickness));
    }
  }
}
