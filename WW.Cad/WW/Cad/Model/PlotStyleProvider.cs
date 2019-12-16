// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.PlotStyleProvider
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Drawing;
using WW.Cad.Model.Entities;

namespace WW.Cad.Model
{
  public delegate IPlotStyle PlotStyleProvider(
    IPlotPropertyOwner plotPropertyOwner,
    DrawContext drawContext);
}
