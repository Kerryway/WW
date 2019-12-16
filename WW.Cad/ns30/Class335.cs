// Decompiled with JetBrains decompiler
// Type: ns30.Class335
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;
using WW.Drawing;

namespace ns30
{
  internal abstract class Class335
  {
    private readonly Color color_0;
    private readonly int int_0;
    private readonly short short_0;

    internal Class335(ArgbColor color, short lineWeight)
    {
      this.color_0 = (Color) color;
      this.int_0 = color.Argb & 16777215;
      this.short_0 = lineWeight;
    }

    internal Color Color
    {
      get
      {
        return this.color_0;
      }
    }

    internal float LineWeight
    {
      get
      {
        return (float) this.short_0;
      }
    }

    internal Pen method_0(Class385 context, bool forFilledPath)
    {
      Pen pen0 = context.pen_0;
      context.method_3(forFilledPath ? (short) 0 : this.short_0);
      return pen0;
    }

    internal Pen method_1(Class385 context)
    {
      Pen pen0 = context.pen_0;
      pen0.Color = context.ColorContext.GetColor(this.color_0, this.int_0);
      return pen0;
    }

    internal Pen method_2(Class385 context)
    {
      Pen pen0 = context.pen_0;
      pen0.Color = context.ColorContext.GetColor(this.color_0, this.int_0);
      context.method_3(this.short_0);
      return pen0;
    }

    internal SolidBrush method_3(Class385 context)
    {
      SolidBrush solidBrush0 = context.solidBrush_0;
      solidBrush0.Color = context.ColorContext.GetColor(this.color_0, this.int_0);
      return solidBrush0;
    }
  }
}
