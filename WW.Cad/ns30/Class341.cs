// Decompiled with JetBrains decompiler
// Type: ns30.Class341
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Drawing;
using WW.Drawing;
using WW.Math;

namespace ns30
{
  internal class Class341 : Class335, Interface12
  {
    private readonly Interface23 interface23_0;
    private readonly bool bool_0;

    public Class341(ArgbColor color, Interface23 drawable, bool fill, short lineWeight)
      : base(color, lineWeight)
    {
      this.interface23_0 = drawable;
      this.bool_0 = fill;
    }

    public void Draw(Class385 context)
    {
      this.method_1(context);
      this.interface23_0.Draw(context.Graphics, (Class335) this, this.bool_0, context.Transform, context);
    }

    public void Draw(Class386 context)
    {
      this.interface23_0.Draw(context.Graphics, context.FastRasterizer, (Class335) this, this.bool_0, context.Transform, (Class385) context);
    }

    public void BoundingBox(Bounds3D bounds, Matrix4D transform)
    {
      this.interface23_0.BoundingBox(bounds, transform);
    }

    public void Transform(ITransformer4D transformer, GraphicsConfig graphicsConfig)
    {
      this.interface23_0.Transform(transformer);
    }
  }
}
