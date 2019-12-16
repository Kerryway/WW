// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.FlatShape4D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace WW.Math.Geometry
{
  public class FlatShape4D : IShape4D
  {
    private readonly FillableShape2D fillableShape2D_0;
    private Matrix4D matrix4D_0;
    private readonly Point2D[] point2D_0;

    public FlatShape4D(IShape2D shape, bool filled)
      : this(shape, Matrix4D.Identity, filled)
    {
    }

    public FlatShape4D(IShape2D shape, Matrix4D transform, bool filled)
      : this(FillableShape2D.ToFillableShape(shape, filled), transform)
    {
    }

    public FlatShape4D(FillableShape2D shape, Matrix4D transform)
    {
      this.fillableShape2D_0 = shape;
      this.matrix4D_0 = transform;
      Bounds2D bounds = ShapeTool.GetBounds((IShape2D) shape);
      if (bounds.Initialized)
        this.point2D_0 = new Point2D[4]
        {
          bounds.Corner1,
          new Point2D(bounds.Corner2.X, bounds.Corner1.Y),
          bounds.Corner2,
          new Point2D(bounds.Corner1.X, bounds.Corner2.Y)
        };
      else
        this.point2D_0 = (Point2D[]) null;
    }

    public FlatShape4D(FillableShape2D shape)
      : this(shape, Matrix4D.Identity)
    {
    }

    public bool IsFilled
    {
      get
      {
        return this.fillableShape2D_0.Filled;
      }
    }

    public bool IsEmpty
    {
      get
      {
        return this.point2D_0 == null;
      }
    }

    public InsideTestResult CheckClipping(IInsideTester4D region)
    {
      if (this.point2D_0 == null)
        return InsideTestResult.Outside;
      Bounds3D box = new Bounds3D();
      foreach (Point2D point in this.point2D_0)
        box.Update(this.matrix4D_0.TransformTo3D(point));
      return region.TryIsInside(box);
    }

    public void Transform(Matrix4D matrix)
    {
      this.matrix4D_0 = matrix * this.matrix4D_0;
    }

    public void UpdateBounds(Bounds3D bounds, Matrix4D modelTransform)
    {
      if (this.point2D_0 == null)
        return;
      Matrix4D matrix4D = modelTransform * this.matrix4D_0;
      foreach (Point2D point in this.point2D_0)
        bounds.Update(matrix4D.TransformTo4D(point));
    }

    public IList<Polyline4D> ToPolylines4D(double epsilon)
    {
      return (IList<Polyline4D>) ShapeTool.GetFlattened((ITransformer4D) this.matrix4D_0, (IShape2D) this.fillableShape2D_0, epsilon);
    }

    public IShape4D GetFlattened(ITransformer4D transformer, double shapeFlattenEpsilon)
    {
      Transformer4DList transformer4Dlist = new Transformer4DList(2);
      transformer4Dlist.Add((ITransformer4D) this.matrix4D_0);
      transformer4Dlist.Add(transformer);
      return (IShape4D) new PolylineShape4D((IList<Polyline4D>) ShapeTool.GetFlattened((ITransformer4D) transformer4Dlist, (IShape2D) this.fillableShape2D_0, shapeFlattenEpsilon), this.fillableShape2D_0.Filled);
    }

    public IShape2D ToShape2D(Matrix4D matrix)
    {
      return (IShape2D) new GeneralShape2D((IShape2D) this.fillableShape2D_0, matrix * this.matrix4D_0, true);
    }

    public GraphicsPath ToGraphicsPath(Matrix4D matrix)
    {
      Matrix4D transform = matrix * this.matrix4D_0;
      return (this.fillableShape2D_0.Shape as GeneralShape2D ?? new GeneralShape2D(this.fillableShape2D_0.Shape, true)).ToGraphicsPath(transform);
    }

    public ISegment2DIterator CreateIterator(Matrix4D matrix)
    {
      return (ISegment2DIterator) new TransformingSegment2DIterator(this.fillableShape2D_0.CreateIterator(), matrix * this.matrix4D_0);
    }

    public FlatShape4D ToFlatShape()
    {
      return this;
    }

    public IShape2D FlatShape
    {
      get
      {
        return (IShape2D) this.fillableShape2D_0;
      }
    }

    public Matrix4D Transformation
    {
      get
      {
        return this.matrix4D_0;
      }
    }
  }
}
