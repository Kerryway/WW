// Decompiled with JetBrains decompiler
// Type: ns30.Class338
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;
using WW.Cad.Drawing;
using WW.Drawing;
using WW.Math;

namespace ns30
{
  internal class Class338 : Class335, Interface12
  {
    private Vector4D vector4D_0;
    private Vector4D vector4D_1;

    public Class338(Vector4D start, Vector4D end, ArgbColor color, short lineWeight)
      : base(color, lineWeight)
    {
      this.vector4D_0 = start;
      this.vector4D_1 = end;
    }

    public void Draw(Class385 context)
    {
      PointF pointF1 = context.Transform.TransformToPointF(this.vector4D_0);
      PointF pointF2 = context.Transform.TransformToPointF(this.vector4D_1);
      context.Graphics.DrawLine(this.method_2(context), pointF1.X, pointF1.Y, pointF2.X, pointF2.Y);
    }

    public void Draw(Class386 context)
    {
      Point2D p1 = context.Transform.TransformTo2D(this.vector4D_0);
      Point2D p2 = context.Transform.TransformTo2D(this.vector4D_1);
      context.FastRasterizer.DrawLineSegment(p1, p2, (uint) this.Color.ToArgb());
    }

    public void BoundingBox(Bounds3D bounds, Matrix4D transform)
    {
      Vector4D p1 = transform.Transform(this.vector4D_0);
      bounds.Update(p1);
      Vector4D p2 = transform.Transform(this.vector4D_1);
      bounds.Update(p2);
    }

    public void Transform(ITransformer4D transformer, GraphicsConfig graphicsConfig)
    {
      this.vector4D_0 = transformer.Transform(this.vector4D_0);
      this.vector4D_1 = transformer.Transform(this.vector4D_1);
    }
  }
}
