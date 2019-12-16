// Decompiled with JetBrains decompiler
// Type: ns30.Class344
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Cad.Drawing;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace ns30
{
  internal class Class344 : Class335, Interface12
  {
    private static readonly Vector2D vector2D_0 = new Vector2D(0.5, 0.5);
    private Image image_0;
    private Polyline4D polyline4D_0;
    private Polyline4D polyline4D_1;
    private RectangleF rectangleF_0;
    private RectangleF rectangleF_1;
    private Vector4D vector4D_0;
    private Vector4D vector4D_1;
    private Vector4D vector4D_2;

    public Class344(
      Image image,
      Polyline4D clipPolygon,
      Polyline4D imageBoundary,
      Vector4D transformedOrigin,
      Vector4D transformedXAxis,
      Vector4D transformedYAxis,
      Color color,
      short lineWeight)
      : base((ArgbColor) color, lineWeight)
    {
      this.image_0 = image;
      this.polyline4D_0 = clipPolygon;
      this.polyline4D_1 = imageBoundary;
      this.rectangleF_0 = new RectangleF(-0.0f, (float) image.Height, (float) image.Width, (float) -image.Height);
      this.rectangleF_1 = new RectangleF(-0.5f, -0.5f, (float) image.Width, (float) image.Height);
      this.vector4D_0 = transformedOrigin;
      this.vector4D_1 = transformedXAxis;
      this.vector4D_2 = transformedYAxis;
    }

    public void Draw(Class385 context)
    {
      if (this.image_0 == null)
        return;
      Graphics graphics = context.Graphics;
      Matrix4D transform1 = context.Transform;
      Matrix transform2 = graphics.Transform;
      GraphicsPath path = (GraphicsPath) null;
      System.Drawing.Region region1 = (System.Drawing.Region) null;
      System.Drawing.Region region2 = (System.Drawing.Region) null;
      if (this.polyline4D_0 != null)
      {
        path = new GraphicsPath();
        PointF[] points = new PointF[this.polyline4D_0.Count];
        for (int index = 0; index < this.polyline4D_0.Count; ++index)
          points[index] = transform1.TransformToPointF(this.polyline4D_0[index]);
        path.AddPolygon(points);
        region1 = graphics.Clip;
        region2 = new System.Drawing.Region(path);
        graphics.Clip = region2;
      }
      Point3D point3D1 = transform1.TransformToPoint3D(this.vector4D_0);
      Point3D point3D2 = transform1.TransformToPoint3D(this.vector4D_1);
      Point3D point3D3 = transform1.TransformToPoint3D(this.vector4D_2);
      Vector3D vector3D1 = point3D2 - point3D1;
      Vector3D vector3D2 = point3D3 - point3D1;
      Matrix matrix = new Matrix((float) vector3D1.X, (float) vector3D1.Y, (float) vector3D2.X, (float) vector3D2.Y, (float) point3D1.X, (float) point3D1.Y);
      graphics.Transform = matrix;
      graphics.DrawImage(this.image_0, this.rectangleF_0, this.rectangleF_1, GraphicsUnit.Pixel);
      graphics.Transform = transform2;
      matrix.Dispose();
      if (this.polyline4D_1 != null && this.polyline4D_1.Count > 0 && context.GraphicsConfig.DrawImageFrame)
      {
        PointF[] points = new PointF[this.polyline4D_1.Count];
        for (int index = 0; index < this.polyline4D_1.Count; ++index)
          points[index] = transform1.TransformToPointF(this.polyline4D_1[index]);
        graphics.DrawPolygon(this.method_2(context), points);
      }
      if (region2 == null)
        return;
      graphics.Clip = region1;
      graphics.DrawPath(this.method_2(context), path);
      region2.Dispose();
      path.Dispose();
    }

    public void Draw(Class386 context)
    {
      this.Draw((Class385) context);
    }

    public void BoundingBox(Bounds3D bounds, Matrix4D transform)
    {
      if (this.polyline4D_1 == null)
        return;
      foreach (Vector4D vector in (List<Vector4D>) this.polyline4D_1)
        bounds.Update(transform.Transform(vector));
    }

    public void Transform(ITransformer4D transformer, GraphicsConfig graphicsConfig)
    {
      if (this.polyline4D_0 != null)
      {
        for (int index = this.polyline4D_0.Count - 1; index >= 0; --index)
          this.polyline4D_0[index] = transformer.Transform(this.polyline4D_0[index]);
      }
      if (this.polyline4D_1 != null)
      {
        for (int index = this.polyline4D_1.Count - 1; index >= 0; --index)
          this.polyline4D_1[index] = transformer.Transform(this.polyline4D_1[index]);
      }
      this.vector4D_0 = transformer.Transform(this.vector4D_0);
      this.vector4D_1 = transformer.Transform(this.vector4D_1);
      this.vector4D_2 = transformer.Transform(this.vector4D_2);
    }
  }
}
