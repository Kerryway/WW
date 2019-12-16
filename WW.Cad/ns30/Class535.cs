// Decompiled with JetBrains decompiler
// Type: ns30.Class535
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace ns30
{
  internal class Class535 : Interface23
  {
    private Vector4D[] vector4D_0;
    private bool bool_0;
    private PointF[] pointF_0;

    public Class535(Vector4D[] points)
      : this(false, points)
    {
    }

    public Class535(IList<Vector4D> points)
      : this(false, points)
    {
    }

    public Class535(bool closed, Vector4D[] points)
    {
      this.bool_0 = closed;
      this.vector4D_0 = points;
    }

    public Class535(bool closed, IList<Vector4D> points)
    {
      this.bool_0 = closed;
      this.vector4D_0 = new Vector4D[points.Count];
      for (int index = 0; index < points.Count; ++index)
        this.vector4D_0[index] = points[index];
    }

    public Class535(Polyline4D polyline)
      : this(polyline.Closed, (IList<Vector4D>) polyline)
    {
    }

    public void Draw(
      Graphics graphics,
      Class335 coloredPath,
      bool fill,
      Matrix4D transform,
      Class385 context)
    {
      this.method_0(transform);
      if (fill && this.bool_0)
        graphics.FillPolygon((Brush) coloredPath.method_3(context), this.pointF_0);
      if (this.bool_0)
        graphics.DrawPolygon(coloredPath.method_0(context, fill && this.bool_0), this.pointF_0);
      else
        graphics.DrawLines(coloredPath.method_0(context, fill && this.bool_0), this.pointF_0);
    }

    public void Draw(
      Graphics graphics,
      Rasterizer2D fastRasterizer,
      Class335 coloredPath,
      bool fill,
      Matrix4D transform,
      Class385 context)
    {
      this.method_0(transform);
      if (fill && this.bool_0)
        graphics.FillPolygon((Brush) coloredPath.method_3(context), this.pointF_0);
      Point2D p1 = (Point2D) (this.bool_0 ? this.pointF_0[this.pointF_0.Length - 1] : this.pointF_0[0]);
      uint argb = (uint) coloredPath.Color.ToArgb();
      for (int index = this.bool_0 ? 0 : 1; index < this.pointF_0.Length; ++index)
      {
        Point2D p2 = (Point2D) this.pointF_0[index];
        fastRasterizer.DrawLineSegment(p1, p2, argb);
        p1 = p2;
      }
    }

    public void Draw(GraphicsPath graphicsPath, bool fill, Matrix4D transform)
    {
      this.method_0(transform);
      graphicsPath.StartFigure();
      if (!fill && !this.bool_0)
        graphicsPath.AddLines(this.pointF_0);
      else
        graphicsPath.AddPolygon(this.pointF_0);
    }

    public unsafe void BoundingBox(Bounds3D bounds, Matrix4D transform)
    {
      int length = this.vector4D_0.Length;
      fixed (Vector4D* vector4DPtr1 = this.vector4D_0)
      {
        Vector4D* vector4DPtr2 = vector4DPtr1;
        for (Vector4D* vector4DPtr3 = vector4DPtr2 + length; vector4DPtr2 < vector4DPtr3; ++vector4DPtr2)
        {
          Vector4D p = transform.Transform(*vector4DPtr2);
          bounds.Update(p);
        }
      }
    }

    public void Transform(ITransformer4D transformer)
    {
      if (this.vector4D_0 == null)
        return;
      for (int index = 0; index < this.vector4D_0.Length; ++index)
        this.vector4D_0[index] = transformer.Transform(this.vector4D_0[index]);
    }

    private unsafe void method_0(Matrix4D transform)
    {
      int length = this.vector4D_0.Length;
      if (this.pointF_0 == null || this.pointF_0.Length != length)
        this.pointF_0 = new PointF[length];
      fixed (Vector4D* vector4DPtr1 = this.vector4D_0)
        fixed (PointF* pointFPtr1 = this.pointF_0)
        {
          Vector4D* vector4DPtr2 = vector4DPtr1;
          PointF* pointFPtr2 = pointFPtr1;
          for (int index = 0; index < length; ++index)
          {
            *pointFPtr2 = transform.TransformToPointF(*vector4DPtr2);
            ++vector4DPtr2;
            ++pointFPtr2;
          }
        }
    }
  }
}
