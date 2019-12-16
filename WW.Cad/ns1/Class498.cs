// Decompiled with JetBrains decompiler
// Type: ns1.Class498
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Drawing;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Drawing;

namespace ns1
{
  internal class Class498 : IPlotPropertyOwner
  {
    private readonly IPlotPropertyOwner iplotPropertyOwner_0;
    private readonly short short_0;

    public Class498(IPlotPropertyOwner baseOwner, short replaceLineWeight)
    {
      this.iplotPropertyOwner_0 = baseOwner;
      this.short_0 = replaceLineWeight;
    }

    public ArgbColor GetColor(DrawContext context)
    {
      return this.iplotPropertyOwner_0.GetColor(context);
    }

    public EntityColor GetEntityColor(DrawContext context)
    {
      return this.iplotPropertyOwner_0.GetEntityColor(context);
    }

    public byte GetAlpha(DrawContext context)
    {
      return this.iplotPropertyOwner_0.GetAlpha(context);
    }

    public DxfLineType GetLineType(DrawContext context)
    {
      return this.iplotPropertyOwner_0.GetLineType(context);
    }

    public short GetLineWeight(DrawContext context)
    {
      return this.short_0;
    }

    public DxfLayer GetLayer(DrawContext context)
    {
      return this.iplotPropertyOwner_0.GetLayer(context);
    }
  }
}
