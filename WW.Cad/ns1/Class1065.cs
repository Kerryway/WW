// Decompiled with JetBrains decompiler
// Type: ns1.Class1065
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Drawing;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Drawing;

namespace ns1
{
  internal class Class1065 : IPlotPropertyOwner
  {
    private readonly IPlotPropertyOwner iplotPropertyOwner_0;
    private readonly EntityColor entityColor_0;
    private readonly byte byte_0;

    public Class1065(IPlotPropertyOwner baseOwner, EntityColor replaceColor, byte replaceAlpha)
    {
      this.iplotPropertyOwner_0 = baseOwner;
      this.entityColor_0 = replaceColor;
      this.byte_0 = replaceAlpha;
    }

    public Class1065(IPlotPropertyOwner baseOwner, EntityColor replaceColor)
      : this(baseOwner, replaceColor, byte.MaxValue)
    {
    }

    public Class1065(IPlotPropertyOwner baseOwner, Color replaceColor, byte replaceAlpha)
      : this(baseOwner, EntityColor.CreateFrom(replaceColor), replaceAlpha)
    {
    }

    public Class1065(IPlotPropertyOwner baseOwner, Color replaceColor)
      : this(baseOwner, replaceColor, byte.MaxValue)
    {
    }

    public ArgbColor GetColor(DrawContext context)
    {
      ArgbColor argbColor = this.entityColor_0.ToArgbColor(context.Config.IndexedColors);
      return new ArgbColor((int) this.byte_0, (int) argbColor.R, (int) argbColor.G, (int) argbColor.B);
    }

    public EntityColor GetEntityColor(DrawContext context)
    {
      return this.entityColor_0;
    }

    public byte GetAlpha(DrawContext context)
    {
      return this.byte_0;
    }

    public DxfLineType GetLineType(DrawContext context)
    {
      return this.iplotPropertyOwner_0.GetLineType(context);
    }

    public short GetLineWeight(DrawContext context)
    {
      return this.iplotPropertyOwner_0.GetLineWeight(context);
    }

    public DxfLayer GetLayer(DrawContext context)
    {
      return this.iplotPropertyOwner_0.GetLayer(context);
    }
  }
}
