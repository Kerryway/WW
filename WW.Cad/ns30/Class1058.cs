// Decompiled with JetBrains decompiler
// Type: ns30.Class1058
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Drawing;
using WW.Math;

namespace ns30
{
  internal class Class1058 : Interface23
  {
    private Vector4D vector4D_0;

    public Class1058(Vector4D point)
    {
      this.vector4D_0 = point;
    }

    public void Draw(
      Graphics graphics,
      Class335 coloredPath,
      bool fill,
      Matrix4D transform,
      Class385 context)
    {
      PointF pointF = transform.TransformToPointF(this.vector4D_0);
      context.ColorContext.imethod_0(graphics, coloredPath.Color, (int) pointF.X, (int) pointF.Y);
    }

    public void Draw(
      Graphics graphics,
      Rasterizer2D fastRasterizer,
      Class335 coloredPath,
      bool fill,
      Matrix4D transform,
      Class385 context)
    {
      Point2D point2D = transform.TransformTo2D(this.vector4D_0);
      fastRasterizer.DrawPoint(point2D.X, point2D.Y, (uint) coloredPath.Color.ToArgb());
    }

    public void Draw(GraphicsPath graphicsPath, bool fill, Matrix4D transform)
    {
    }

    public void BoundingBox(Bounds3D bounds, Matrix4D transform)
    {
      Vector4D p = transform.Transform(this.vector4D_0);
      bounds.Update(p);
    }

    public void Transform(ITransformer4D transformer)
    {
      this.vector4D_0 = transformer.Transform(this.vector4D_0);
    }
  }
}
