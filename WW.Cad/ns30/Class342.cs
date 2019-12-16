// Decompiled with JetBrains decompiler
// Type: ns30.Class342
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Cad.Drawing;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace ns30
{
  internal class Class342 : Class335, Interface12
  {
    private IShape4D ishape4D_0;

    public Class342(ArgbColor color, IShape4D shape, short lineWeight)
      : base(color, lineWeight)
    {
      this.ishape4D_0 = shape;
    }

    public void Draw(Class385 context)
    {
      using (GraphicsPath graphicsPath = this.ishape4D_0.ToGraphicsPath(context.Transform))
      {
        if (this.ishape4D_0.IsFilled)
        {
          context.Graphics.FillPath((Brush) this.method_3(context), graphicsPath);
        }
        else
        {
          Pen pen = this.method_2(context);
          try
          {
            context.Graphics.DrawPath(pen, graphicsPath);
          }
          catch (OutOfMemoryException ex)
          {
            if ((double) pen.Width <= 1.0)
              return;
            pen.Width = 1f;
            context.Graphics.DrawPath(pen, graphicsPath);
          }
        }
      }
    }

    public void Draw(Class386 context)
    {
      if (this.ishape4D_0.IsFilled)
      {
        using (GraphicsPath graphicsPath = ShapeTool.ToGraphicsPath(this.ishape4D_0.ToShape2D(context.Transform)))
          context.Graphics.FillPath((Brush) this.method_3((Class385) context), graphicsPath);
      }
      else
      {
        IShape2D shape2D = this.ishape4D_0.ToShape2D(context.Transform);
        GeneralShape2D shape = shape2D as GeneralShape2D ?? new GeneralShape2D(shape2D, true);
        context.FastRasterizer.DrawShape(shape, (uint) this.Color.ToArgb());
      }
    }

    public void BoundingBox(Bounds3D bounds, Matrix4D transform)
    {
      this.ishape4D_0.UpdateBounds(bounds, transform);
    }

    public void Transform(ITransformer4D transformer, GraphicsConfig graphicsConfig)
    {
      this.ishape4D_0 = this.ishape4D_0.GetFlattened(transformer, graphicsConfig.ShapeFlattenEpsilon);
    }
  }
}
