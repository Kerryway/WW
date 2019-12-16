// Decompiled with JetBrains decompiler
// Type: ns30.Class343
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;
using WW.Cad.Drawing;
using WW.Drawing;
using WW.Math;

namespace ns30
{
  internal class Class343 : Class335, Interface12
  {
    private Vector4D vector4D_0;

    public Class343(Vector4D point, ArgbColor color, short lineWeight)
      : base(color, lineWeight)
    {
      this.vector4D_0 = point;
    }

    public void Draw(Class385 context)
    {
      PointF pointF = context.Transform.TransformToPointF(this.vector4D_0);
      context.ColorContext.imethod_0(context.Graphics, this.Color, (int) pointF.X, (int) pointF.Y);
    }

    public void Draw(Class386 context)
    {
      Point2D point2D = context.Transform.TransformTo2D(this.vector4D_0);
      context.FastRasterizer.DrawPoint(point2D.X, point2D.Y, (uint) this.Color.ToArgb());
    }

    public void BoundingBox(Bounds3D bounds, Matrix4D transform)
    {
      Vector4D p = transform.Transform(this.vector4D_0);
      bounds.Update(p);
    }

    public void Transform(ITransformer4D transformer, GraphicsConfig graphicsConfig)
    {
      this.vector4D_0 = transformer.Transform(this.vector4D_0);
    }
  }
}
