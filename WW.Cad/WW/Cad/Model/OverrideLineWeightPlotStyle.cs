// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.OverrideLineWeightPlotStyle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Drawing;
using WW.Cad.Model.Entities;

namespace WW.Cad.Model
{
  public class OverrideLineWeightPlotStyle : DefaultPlotStyle
  {
    private readonly short short_0;

    public OverrideLineWeightPlotStyle(
      short lineWeight,
      IPlotPropertyOwner plotPropertyOwner,
      DrawContext drawContext)
      : base(plotPropertyOwner, drawContext)
    {
      this.short_0 = lineWeight;
    }

    public override short LineWeight
    {
      get
      {
        return this.short_0;
      }
    }
  }
}
