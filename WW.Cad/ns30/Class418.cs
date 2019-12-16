// Decompiled with JetBrains decompiler
// Type: ns30.Class418
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Drawing;
using WW.Math;

namespace ns30
{
  internal class Class418 : Interface23
  {
    private Vector4D vector4D_0;
    private Vector4D vector4D_1;

    public Class418(Vector4D start, Vector4D end)
    {
      this.vector4D_0 = start;
      this.vector4D_1 = end;
    }

    public void Draw(
      Graphics graphics,
      Class335 coloredPath,
      bool fill,
      Matrix4D transform,
      Class385 context)
    {
      PointF pointF1 = transform.TransformToPointF(this.vector4D_0);
      PointF pointF2 = transform.TransformToPointF(this.vector4D_1);
      graphics.DrawLine(coloredPath.method_0(context, false), pointF1.X, pointF1.Y, pointF2.X, pointF2.Y);
    }

    public void Draw(
      Graphics graphics,
      Rasterizer2D fastRasterizer,
      Class335 coloredPath,
      bool fill,
      Matrix4D transform,
      Class385 context)
    {
      Point2D p1 = transform.TransformTo2D(this.vector4D_0);
      Point2D p2 = transform.TransformTo2D(this.vector4D_1);
      fastRasterizer.DrawLineSegment(p1, p2, (uint) coloredPath.Color.ToArgb());
    }

    public void Draw(GraphicsPath graphicsPath, bool fill, Matrix4D transform)
    {
      graphicsPath.StartFigure();
      PointF pointF1 = transform.TransformToPointF(this.vector4D_0);
      PointF pointF2 = transform.TransformToPointF(this.vector4D_1);
      graphicsPath.AddLine(pointF1.X, pointF1.Y, pointF2.X, pointF2.Y);
    }

    public void BoundingBox(Bounds3D bounds, Matrix4D transform)
    {
      Vector4D p1 = transform.Transform(this.vector4D_0);
      bounds.Update(p1);
      Vector4D p2 = transform.Transform(this.vector4D_1);
      bounds.Update(p2);
    }

    public void Transform(ITransformer4D transformer)
    {
      this.vector4D_0 = transformer.Transform(this.vector4D_0);
      this.vector4D_1 = transformer.Transform(this.vector4D_1);
    }
  }
}
