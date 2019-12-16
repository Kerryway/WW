// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.ClippingPathDrawerWrapper
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Model
{
  public class ClippingPathDrawerWrapper : IPathDrawer
  {
    private readonly IClippingTransformer iclippingTransformer_0;
    private readonly IPathDrawer ipathDrawer_0;

    public ClippingPathDrawerWrapper(IClippingTransformer transformer, IPathDrawer wrapped)
    {
      this.iclippingTransformer_0 = transformer;
      this.ipathDrawer_0 = wrapped;
    }

    public void DrawPath(IShape4D shape, Color color, short lineWeight)
    {
      shape = this.iclippingTransformer_0.Transform(shape);
      this.ipathDrawer_0.DrawPath(shape, color, lineWeight);
    }

    public void DrawPath(
      IShape2D path,
      Matrix4D transform,
      Color color,
      short lineWeight,
      bool filled,
      bool forText,
      double extrusion)
    {
      IShape4D shape = (IShape4D) new FlatShape4D(path, filled);
      shape.Transform(transform);
      this.ipathDrawer_0.DrawPath(this.iclippingTransformer_0.Transform(shape).ToShape2D(Matrix4D.Identity), Matrix4D.Identity, color, lineWeight, filled, forText, extrusion);
    }

    public void DrawCharPath(
      IShape2D path,
      Matrix4D transform,
      Color color,
      short lineWeight,
      bool filled,
      double extrusion)
    {
      IShape4D shape = (IShape4D) new FlatShape4D(path, filled);
      shape.Transform(transform);
      this.ipathDrawer_0.DrawCharPath(this.iclippingTransformer_0.Transform(shape).ToShape2D(Matrix4D.Identity), Matrix4D.Identity, color, lineWeight, filled, extrusion);
    }

    public bool IsSeparateCharDrawingPreferred()
    {
      return this.ipathDrawer_0.IsSeparateCharDrawingPreferred();
    }
  }
}
