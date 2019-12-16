// Decompiled with JetBrains decompiler
// Type: ns4.Class426
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Math;

namespace ns4
{
  internal class Class426 : Class425
  {
    private readonly Class1023.Class1024 class1024_0;
    private double double_0;
    private Class471 class471_0;
    private readonly double double_1;

    public Class426(Class1023.Class1024 paragraphFormat, Class596 settings)
      : base(settings)
    {
      this.class1024_0 = paragraphFormat;
      this.double_1 = 4.0 * settings.Height;
    }

    protected override Class425 vmethod_0(bool first)
    {
      if (!first)
        return base.vmethod_0(first);
      return (Class425) new Class426(this.class1024_0, this.Settings);
    }

    public override Bounds2D GetBounds(Enum24 whiteSpaceHandling, Class985 resultLayoutInfo)
    {
      Bounds2D bounds = base.GetBounds(whiteSpaceHandling, resultLayoutInfo);
      bounds.Update((Point2D) this.Offset);
      return bounds;
    }

    public override void imethod_0(
      ref Vector2D baselinePos,
      double height,
      Enum24 whiteSpaceHandlingFlags)
    {
      this.class471_0 = this.method_1(baselinePos, whiteSpaceHandlingFlags);
      baselinePos.X += this.double_0;
      base.imethod_0(ref baselinePos, height, whiteSpaceHandlingFlags);
    }

    private Class471 method_1(Vector2D baselinePos, Enum24 whiteSpaceHandlingFlags)
    {
      this.double_0 = 0.0;
      double x = baselinePos.X;
      Class471[] tabulators = this.class1024_0.Tabulators;
      try
      {
        Bounds2D bounds = this.GetBounds(Enum24.flag_0, (Class985) null);
        int index = 0;
        double num1 = 1E-06 * this.Settings.Height;
        while ((index < tabulators.Length ? tabulators[index].Position : (double) (index + 1) * this.double_1) <= x + num1)
          ++index;
        Class471 class471 = index < tabulators.Length ? tabulators[index] : new Class471((double) (index + 1) * this.double_1);
        switch (class471.Type)
        {
          case Class471.Enum13.const_3:
            Vector2D? nullable = this.imethod_2(class471.DecimalPointChar, whiteSpaceHandlingFlags);
            this.double_0 = nullable.HasValue ? class471.Position - nullable.Value.X - x : class471.Position - x;
            break;
          case Class471.Enum13.const_1:
            double num2 = bounds.Initialized ? bounds.Center.X : 0.0;
            this.double_0 = class471.Position - x - num2;
            break;
          case Class471.Enum13.const_2:
            double num3 = bounds.Initialized ? bounds.Corner2.X : 0.0;
            this.double_0 = class471.Position - x - num3;
            break;
          case Class471.Enum13.const_0:
            this.double_0 = class471.Position - x;
            break;
          default:
            this.double_0 = 0.0;
            break;
        }
        if (this.double_0 < 0.0)
          this.double_0 = 0.0;
        return class471;
      }
      catch (IndexOutOfRangeException ex)
      {
      }
      return (Class471) null;
    }
  }
}
