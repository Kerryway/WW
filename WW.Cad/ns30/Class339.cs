// Decompiled with JetBrains decompiler
// Type: ns30.Class339
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Cad.Drawing;
using WW.Drawing;
using WW.Math;

namespace ns30
{
  internal class Class339 : Class335, Interface12
  {
    private readonly Interface23[] interface23_0;
    private readonly bool bool_0;

    public Class339(ArgbColor color, Interface23[] drawables, bool fill, short lineWeight)
      : base(color, lineWeight)
    {
      this.interface23_0 = drawables;
      this.bool_0 = fill;
    }

    public void Draw(Class385 context)
    {
      using (GraphicsPath graphicsPath = new GraphicsPath())
      {
        this.method_1(context);
        for (int index = 0; index < this.interface23_0.Length; ++index)
          this.interface23_0[index].Draw(graphicsPath, this.bool_0, context.Transform);
        if (this.bool_0)
        {
          context.solidBrush_0.Color = this.Color;
          context.Graphics.FillPath((Brush) context.solidBrush_0, graphicsPath);
        }
        else
        {
          context.pen_0.Color = this.Color;
          context.Graphics.DrawPath(context.pen_0, graphicsPath);
        }
      }
    }

    public void Draw(Class386 context)
    {
      if (this.bool_0)
      {
        using (GraphicsPath graphicsPath = new GraphicsPath())
        {
          for (int index = 0; index < this.interface23_0.Length; ++index)
            this.interface23_0[index].Draw(graphicsPath, this.bool_0, context.Transform);
          context.solidBrush_0.Color = this.Color;
          context.Graphics.FillPath((Brush) context.solidBrush_0, graphicsPath);
        }
      }
      else
      {
        for (int index = 0; index < this.interface23_0.Length; ++index)
          this.interface23_0[index].Draw(context.Graphics, context.FastRasterizer, (Class335) this, this.bool_0, context.Transform, (Class385) context);
      }
    }

    public void BoundingBox(Bounds3D bounds, Matrix4D transform)
    {
      for (int index = 0; index < this.interface23_0.Length; ++index)
        this.interface23_0[index].BoundingBox(bounds, transform);
    }

    public void Transform(ITransformer4D transformer, GraphicsConfig graphicsConfig)
    {
      for (int index = 0; index < this.interface23_0.Length; ++index)
        this.interface23_0[index].Transform(transformer);
    }
  }
}
