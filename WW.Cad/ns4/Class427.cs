// Decompiled with JetBrains decompiler
// Type: ns4.Class427
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model.Entities;
using WW.Math;

namespace ns4
{
  internal class Class427 : Class425
  {
    private readonly double double_0;
    private readonly LineSpacingStyle lineSpacingStyle_0;

    public Class427(double lineSpacingFactor, LineSpacingStyle lineSpacingStyle, Class596 settings)
      : base(settings)
    {
      this.double_0 = lineSpacingFactor;
      this.lineSpacingStyle_0 = lineSpacingStyle;
    }

    protected override Class425 vmethod_0(bool first)
    {
      return (Class425) new Class427(this.double_0, this.lineSpacingStyle_0, this.Settings);
    }

    public void method_1(double value)
    {
      Class427 class427 = this;
      class427.Offset = class427.Offset + new Vector2D(value, 0.0);
    }

    public override Bounds2D GetBounds(Enum24 whiteSpaceHandling, Class985 resultLayoutInfo)
    {
      Bounds2D bounds = base.GetBounds(whiteSpaceHandling, resultLayoutInfo);
      if (!bounds.Initialized)
      {
        bounds.Update(this.Offset.X, this.Offset.Y);
        bounds.Update(this.Offset.X, this.Offset.Y + this.Settings.Height);
      }
      else
      {
        bounds.Update(bounds.Min.X, this.Offset.Y);
        bounds.Update(bounds.Min.X, this.Offset.Y + this.Settings.Height);
      }
      return bounds;
    }

    public override void imethod_0(
      ref Vector2D baselinePos,
      double height,
      Enum24 whiteSpaceHandlingFlags)
    {
      base.imethod_0(ref baselinePos, height, whiteSpaceHandlingFlags);
      Vector2D vector2D = Vector2D.Zero;
      double val1_1;
      double val1_2;
      if (this.Blocks.Count > 0)
      {
        val1_1 = 0.0;
        val1_2 = 0.0;
        foreach (Interface24 block in this.Blocks)
        {
          Class596 settings = block.Settings;
          val1_1 = System.Math.Max(val1_1, settings.Font.Metrics.Ascent);
          val1_2 = System.Math.Max(val1_2, settings.Font.Metrics.Descent);
          Vector2D lineFeedAdvance = settings.Font.Metrics.LineFeedAdvance;
          if (System.Math.Abs(lineFeedAdvance.X) > System.Math.Abs(vector2D.X))
            vector2D.X = lineFeedAdvance.X;
          if (System.Math.Abs(lineFeedAdvance.Y) > System.Math.Abs(vector2D.Y))
            vector2D.Y = lineFeedAdvance.Y;
        }
      }
      else
      {
        val1_1 = this.Settings.Font.Metrics.Ascent;
        val1_2 = this.Settings.Font.Metrics.Descent;
        vector2D = this.Settings.Font.Metrics.LineFeedAdvance;
      }
      if (this.lineSpacingStyle_0 == LineSpacingStyle.AtLeast)
      {
        Bounds2D bounds = this.GetBounds(whiteSpaceHandlingFlags, (Class985) null);
        double y = val1_1 - bounds.Corner2.Y + this.Offset.Y;
        double num = val1_2 - this.Offset.Y + bounds.Corner1.Y;
        if (y < 0.0)
        {
          Class427 class427 = this;
          class427.Offset = class427.Offset + new Vector2D(0.0, y);
        }
        baselinePos = this.Offset + vector2D * this.double_0;
        if (num >= 0.0)
          return;
        baselinePos.Y += num;
      }
      else
        baselinePos = this.Offset + vector2D * this.double_0;
    }
  }
}
