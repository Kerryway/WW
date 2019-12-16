// Decompiled with JetBrains decompiler
// Type: ns30.Class1036
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns4;
using System.Drawing;
using System.Drawing.Drawing2D;
using WW.Cad.Drawing;
using WW.Cad.Model;
using WW.Math;
using WW.Math.Geometry;

namespace ns30
{
  internal class Class1036 : Interface12
  {
    private Class908 class908_0;
    private System.Drawing.Color color_0;
    private short short_0;

    public Class1036(Class908 chunk, System.Drawing.Color color, short lineWeight)
    {
      this.class908_0 = chunk;
      this.color_0 = color;
      this.short_0 = lineWeight;
    }

    public void Draw(Class385 context)
    {
      Font systemFont = this.class908_0.Font.SystemFont;
      Graphics graphics = context.Graphics;
      Matrix4D transform1 = context.Transform;
      if (systemFont != null)
      {
        double fontHeight = this.class908_0.Font.Metrics.FontHeight;
        ns4.Class26 metrics = (ns4.Class26) this.class908_0.Font.Metrics;
        double num = metrics.CanonicalScaling * fontHeight;
        Matrix4D matrix4D = transform1 * this.class908_0.Transformation * Transformation4D.Scaling(num, -num, num);
        Matrix transform2 = graphics.Transform;
        using (Matrix matrix = new Matrix((float) matrix4D.M00, (float) matrix4D.M10, (float) matrix4D.M01, (float) matrix4D.M11, (float) matrix4D.M03, (float) matrix4D.M13))
        {
          graphics.Transform = matrix;
          context.solidBrush_0.Color = this.color_0;
          graphics.DrawString(this.class908_0.Text.Text, systemFont, (Brush) context.solidBrush_0, metrics.BaseLineOffset.X, metrics.BaseLineOffset.Y, StringFormat.GenericTypographic);
        }
        graphics.Transform = transform2;
        if (this.class908_0.Linings.Length <= 0)
          return;
        context.pen_0.Color = this.color_0;
        context.method_3(this.short_0);
        this.class908_0.method_1((IPathDrawer) new Class1036.Class1037(graphics, context.pen_0), transform1, 0.0);
      }
      else
      {
        context.pen_0.Color = this.color_0;
        context.method_3(this.short_0);
        IPathDrawer drawer = (IPathDrawer) new Class1036.Class1037(graphics, context.pen_0);
        this.class908_0.method_0(drawer, transform1, 0.0);
        if (this.class908_0.Linings.Length <= 0)
          return;
        this.class908_0.method_1(drawer, transform1, 0.0);
      }
    }

    public void Draw(Class386 context)
    {
      this.Draw((Class385) context);
    }

    public void BoundingBox(Bounds3D bounds, Matrix4D transform)
    {
      Matrix4D matrix4D = transform * this.class908_0.Transformation;
      Bounds2D bounds1 = this.class908_0.Text.Font.Metrics.GetBounds(this.class908_0.Text.Text, Enum24.flag_0);
      bounds.Update(matrix4D.TransformTo4D(bounds1.Corner1));
      bounds.Update(matrix4D.TransformTo4D(bounds1.Corner2));
      bounds.Update(matrix4D.TransformTo4D(new WW.Math.Point2D(bounds1.Corner2.X, bounds1.Corner1.Y)));
      bounds.Update(matrix4D.TransformTo4D(new WW.Math.Point2D(bounds1.Corner1.X, bounds1.Corner2.Y)));
    }

    public void Transform(ITransformer4D transformer, GraphicsConfig graphicsConfig)
    {
      this.class908_0.Transform(transformer);
    }

    private class Class1037 : IPathDrawer
    {
      private Graphics graphics_0;
      private Pen pen_0;

      public Class1037(Graphics graphics, Pen pen)
      {
        this.graphics_0 = graphics;
        this.pen_0 = pen;
      }

      public void DrawPath(IShape4D path, WW.Cad.Model.Color color, short lineWeight)
      {
        FlatShape4D flatShape = path.ToFlatShape();
        this.DrawPath(flatShape.FlatShape, flatShape.Transformation, color, lineWeight, flatShape.IsFilled, false, 0.0);
      }

      public void DrawPath(
        IShape2D shape,
        Matrix4D transform,
        WW.Cad.Model.Color color,
        short lineWeight,
        bool filled,
        bool forText,
        double extrusion)
      {
        Matrix transform1 = this.graphics_0.Transform;
        using (Matrix matrix = new Matrix((float) transform.M00, (float) transform.M10, (float) transform.M01, (float) transform.M11, (float) transform.M03, (float) transform.M13))
        {
          this.graphics_0.Transform = matrix;
          using (GraphicsPath graphicsPath = ShapeTool.ToGraphicsPath(shape))
            this.graphics_0.DrawPath(this.pen_0, graphicsPath);
        }
        this.graphics_0.Transform = transform1;
      }

      public void DrawCharPath(
        IShape2D path,
        Matrix4D transform,
        WW.Cad.Model.Color color,
        short lineWeight,
        bool filled,
        double extrusion)
      {
        this.DrawPath(path, transform, color, lineWeight, filled, true, extrusion);
      }

      public bool IsSeparateCharDrawingPreferred()
      {
        return false;
      }
    }
  }
}
