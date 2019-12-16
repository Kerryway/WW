// Decompiled with JetBrains decompiler
// Type: ns30.Class463
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Cad.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace ns30
{
  internal class Class463 : Interface12
  {
    private static readonly Vector2D vector2D_0 = new Vector2D(0.5, 0.5);
    private IBitmapProvider ibitmapProvider_0;
    private Polyline4D polyline4D_0;
    private Size2D size2D_0;
    private Vector4D vector4D_0;
    private Vector4D vector4D_1;
    private Vector4D vector4D_2;

    public Class463(
      IBitmapProvider bitmapProvider,
      Polyline4D clipPolygon,
      Size2D displaySize,
      Vector4D transformedOrigin,
      Vector4D transformedXAxis,
      Vector4D transformedYAxis)
    {
      this.ibitmapProvider_0 = bitmapProvider;
      this.polyline4D_0 = clipPolygon;
      this.size2D_0 = displaySize;
      this.vector4D_0 = transformedOrigin;
      this.vector4D_1 = transformedXAxis;
      this.vector4D_2 = transformedYAxis;
    }

    public void Draw(Class385 context)
    {
      if (this.ibitmapProvider_0 == null)
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
      using (Matrix matrix = new Matrix((float) vector3D1.X, (float) vector3D2.X, (float) vector3D1.Y, (float) vector3D2.Y, (float) point3D1.X, (float) point3D1.Y))
      {
        graphics.Transform = matrix;
        double num = System.Math.Max(vector3D1.GetLength(), vector3D2.GetLength());
        if (num > 0.0)
        {
          RectangleF destRect = new RectangleF(0.0f, (float) this.size2D_0.Y, (float) this.size2D_0.X, -(float) this.size2D_0.Y);
          int width = (int) System.Math.Round(this.size2D_0.X * num);
          int height = (int) System.Math.Round(this.size2D_0.Y * num);
          if (width >= height)
          {
            if (width > context.GraphicsConfig.MaxScalableImageSize)
            {
              height = (int) System.Math.Round((double) height * (double) context.GraphicsConfig.MaxScalableImageSize / (double) width);
              width = context.GraphicsConfig.MaxScalableImageSize;
            }
          }
          else if (height > context.GraphicsConfig.MaxScalableImageSize)
          {
            width = (int) System.Math.Round((double) width * (double) context.GraphicsConfig.MaxScalableImageSize / (double) height);
            height = context.GraphicsConfig.MaxScalableImageSize;
          }
          RectangleF srcRect = new RectangleF(-0.5f, -0.5f, (float) width, (float) height);
          using (Bitmap bitmap = this.ibitmapProvider_0.CreateBitmap(new Size(width, height)))
          {
            if (bitmap != null)
              graphics.DrawImage((Image) bitmap, destRect, srcRect, GraphicsUnit.Pixel);
          }
          graphics.Transform = transform2;
        }
      }
      if (region2 == null)
        return;
      graphics.Clip = region1;
      region2.Dispose();
      path.Dispose();
    }

    public void Draw(Class386 context)
    {
    }

    public void BoundingBox(Bounds3D bounds, Matrix4D transform)
    {
      Vector4D vector4D1 = this.vector4D_1 * this.size2D_0.X;
      Vector4D vector4D2 = this.vector4D_2 * this.size2D_0.Y;
      bounds.Update(transform.TransformTo3D(this.vector4D_0));
      bounds.Update(transform.TransformTo3D(this.vector4D_0 + vector4D1));
      bounds.Update(transform.TransformTo3D(this.vector4D_0 + vector4D2));
      bounds.Update(transform.TransformTo3D(this.vector4D_0 + vector4D1 + vector4D2));
    }

    public void Transform(ITransformer4D transformer, GraphicsConfig graphicsConfig)
    {
      this.vector4D_0 = transformer.Transform(this.vector4D_0);
      this.vector4D_1 = transformer.Transform(this.vector4D_1);
      this.vector4D_2 = transformer.Transform(this.vector4D_2);
    }
  }
}
