// Decompiled with JetBrains decompiler
// Type: ns30.Class345
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using System.Drawing;
using WW.Cad.Drawing;
using WW.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace ns30
{
  internal class Class345 : Class335, Interface12
  {
    private Vector4D? nullable_0;
    private Segment4D segment4D_0;

    public Class345(Vector4D? startPoint, Segment4D segment, ArgbColor color, short lineWeight)
      : base(color, lineWeight)
    {
      this.nullable_0 = startPoint;
      this.segment4D_0 = segment;
    }

    public void Draw(Class385 context)
    {
      Vector4D t1 = context.Transform.Transform(this.segment4D_0.Start);
      Vector4D t2 = context.Transform.Transform(this.segment4D_0.End);
      this.method_4(context.Graphics, context.DrawingBoundsClipper, context, t1, t2);
    }

    public void Draw(Class386 context)
    {
      Point2D p1 = context.Transform.TransformTo2D(this.segment4D_0.Start);
      Point2D p2 = context.Transform.TransformTo2D(this.segment4D_0.End);
      context.FastRasterizer.DrawLineSegment(p1, p2, (uint) this.Color.ToArgb());
    }

    private void method_4(
      Graphics graphics,
      BlinnClipper4D drawingBoundsClipper,
      Class385 context,
      Vector4D t1,
      Vector4D t2)
    {
      IList<Segment4D> segment4DList = drawingBoundsClipper.Clip(new Segment4D(t1, t2));
      if (segment4DList.Count <= 0)
        return;
      Pen pen = this.method_2(context);
      foreach (Segment4D segment4D in (IEnumerable<Segment4D>) segment4DList)
      {
        Point3D start = (Point3D) segment4D.Start;
        Point3D end = (Point3D) segment4D.End;
        graphics.DrawLine(pen, (float) start.X, (float) start.Y, (float) end.X, (float) end.Y);
      }
    }

    public void BoundingBox(Bounds3D bounds, Matrix4D transform)
    {
    }

    public void Transform(ITransformer4D transformer, GraphicsConfig graphicsConfig)
    {
      if (this.nullable_0.HasValue)
        this.nullable_0 = new Vector4D?(transformer.Transform(this.nullable_0.Value));
      this.segment4D_0.Start = transformer.Transform(this.segment4D_0.Start);
      this.segment4D_0.End = transformer.Transform(this.segment4D_0.End);
    }
  }
}
