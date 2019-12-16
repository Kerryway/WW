// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DefaultPlotStyle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Drawing;
using WW.Cad.Model.Entities;
using WW.Drawing;

namespace WW.Cad.Model
{
  public class DefaultPlotStyle : IPlotStyle
  {
    private readonly IPlotPropertyOwner iplotPropertyOwner_0;
    private readonly DrawContext drawContext_0;

    public DefaultPlotStyle(IPlotPropertyOwner plotPropertyOwner, DrawContext drawContext)
    {
      this.iplotPropertyOwner_0 = plotPropertyOwner;
      this.drawContext_0 = drawContext;
    }

    public virtual ArgbColor Color
    {
      get
      {
        return this.iplotPropertyOwner_0.GetColor(this.drawContext_0);
      }
    }

    public virtual short LineWeight
    {
      get
      {
        return this.iplotPropertyOwner_0.GetLineWeight(this.drawContext_0);
      }
    }
  }
}
