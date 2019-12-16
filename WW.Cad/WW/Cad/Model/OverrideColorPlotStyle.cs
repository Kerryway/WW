// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.OverrideColorPlotStyle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Drawing;
using WW.Cad.Model.Entities;
using WW.Drawing;

namespace WW.Cad.Model
{
  public class OverrideColorPlotStyle : DefaultPlotStyle
  {
    private readonly ArgbColor argbColor_0;

    public OverrideColorPlotStyle(
      ArgbColor color,
      IPlotPropertyOwner plotPropertyOwner,
      DrawContext drawContext)
      : base(plotPropertyOwner, drawContext)
    {
      this.argbColor_0 = color;
    }

    public override ArgbColor Color
    {
      get
      {
        return this.argbColor_0;
      }
    }
  }
}
