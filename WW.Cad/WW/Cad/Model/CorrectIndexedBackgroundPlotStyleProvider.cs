// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.CorrectIndexedBackgroundPlotStyleProvider
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Drawing;
using WW.Cad.Model.Entities;
using WW.Drawing;

namespace WW.Cad.Model
{
  public class CorrectIndexedBackgroundPlotStyleProvider
  {
    private readonly ArgbColor argbColor_0;
    private readonly ArgbColor argbColor_1;

    public CorrectIndexedBackgroundPlotStyleProvider(ArgbColor backgroundColor)
    {
      this.argbColor_0 = backgroundColor;
      this.argbColor_1 = ArgbColor.IsBrightColor(backgroundColor) ? ArgbColors.Black : ArgbColors.White;
    }

    public IPlotStyle GetPlotStyle(
      IPlotPropertyOwner plotPropertyOwner,
      DrawContext drawContext)
    {
      EntityColor entityColor = plotPropertyOwner.GetEntityColor(drawContext);
      if (entityColor.ColorType == ColorType.ByColorIndex && entityColor.ToArgbColor() == this.argbColor_0)
        return (IPlotStyle) new OverrideColorPlotStyle(this.argbColor_1, plotPropertyOwner, drawContext);
      return (IPlotStyle) new DefaultPlotStyle(plotPropertyOwner, drawContext);
    }
  }
}
