// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.ModelSpaceClippingTransformer
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns33;
using System.Collections.Generic;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public class ModelSpaceClippingTransformer : ICloneable, IClippingTransformer
  {
    private Matrix4D matrix4D_0;
    private Matrix3D matrix3D_0;
    private ILineTypeScaler ilineTypeScaler_0;
    private readonly Interface32 interface32_0;
    private double double_0;
    private double double_1;

    internal ModelSpaceClippingTransformer(
      Matrix4D transform,
      Matrix3D matrix3D,
      Interface32 clipper,
      double shapeFlattenEpsilon,
      double shapeFlattenEpsilonForBoundsCalculation)
    {
      this.matrix4D_0 = transform;
      this.matrix3D_0 = matrix3D;
      this.ilineTypeScaler_0 = Class624.Create(matrix3D);
      this.interface32_0 = clipper;
      this.double_0 = shapeFlattenEpsilon;
      this.double_1 = shapeFlattenEpsilonForBoundsCalculation;
    }

    internal ModelSpaceClippingTransformer(
      Matrix4D transform,
      Interface32 clipper,
      double shapeFlattenEpsilon,
      double shapeFlattenEpsilonForClipTesting)
      : this(transform, new Matrix3D(transform.M00, transform.M01, transform.M02, transform.M10, transform.M11, transform.M12, transform.M20, transform.M21, transform.M22), clipper, shapeFlattenEpsilon, shapeFlattenEpsilonForClipTesting)
    {
    }

    private ModelSpaceClippingTransformer(
      Matrix4D transform,
      Matrix3D matrix3D,
      ILineTypeScaler lineTypeScaler,
      Interface32 clipper,
      double shapeFlattenEpsilon,
      double shapeFlattenEpsilonForBoundsCalculation)
    {
      this.matrix4D_0 = transform;
      this.matrix3D_0 = matrix3D;
      this.ilineTypeScaler_0 = lineTypeScaler;
      this.interface32_0 = clipper;
      this.double_0 = shapeFlattenEpsilon;
      this.double_1 = shapeFlattenEpsilonForBoundsCalculation;
    }

    public object Clone()
    {
      return (object) new ModelSpaceClippingTransformer(this.matrix4D_0, this.matrix3D_0, this.ilineTypeScaler_0, this.interface32_0.Clone(), this.double_0, this.double_1);
    }

    public Matrix4D Matrix
    {
      get
      {
        return this.matrix4D_0;
      }
    }

    public Matrix3D Matrix3D
    {
      get
      {
        return this.matrix3D_0;
      }
    }

    public ILineTypeScaler LineTypeScaler
    {
      get
      {
        return this.ilineTypeScaler_0;
      }
    }

    public Vector4D? Transform(Point3D v)
    {
      Vector4D vector4D = (Vector4D) v;
      if (!this.interface32_0.IsInside(vector4D))
        return new Vector4D?();
      return new Vector4D?(this.matrix4D_0.Transform(vector4D));
    }

    public IList<Segment4D> Transform(Segment3D segment)
    {
      Segment4D segment1 = new Segment4D((Vector4D) segment.Start, (Vector4D) segment.End);
      IList<Segment4D> segment4DList = (IList<Segment4D>) new List<Segment4D>();
      foreach (Segment4D segment4D in (IEnumerable<Segment4D>) this.interface32_0.Clip(segment1))
        segment4DList.Add(new Segment4D(this.matrix4D_0.Transform(segment4D.Start), this.matrix4D_0.Transform(segment4D.End)));
      return segment4DList;
    }

    public IList<Polyline4D> Transform(Polyline3D polyline, bool filled)
    {
      Polyline4D polyline1 = new Polyline4D(polyline.Count, polyline.Closed);
      foreach (Point3D point3D in (List<Point3D>) polyline)
        polyline1.Add((Vector4D) point3D);
      return ModelSpaceClippingTransformer.GetTransformed(this.interface32_0.Clip(polyline1, filled), this.matrix4D_0);
    }

    internal static IList<Polyline4D> GetTransformed(
      IList<Polyline4D> polygons,
      Matrix4D transform)
    {
      List<Polyline4D> polyline4DList = new List<Polyline4D>(polygons.Count);
      foreach (Polyline4D polygon in (IEnumerable<Polyline4D>) polygons)
      {
        for (int index = polygon.Count - 1; index >= 0; --index)
          polygon[index] = transform.Transform(polygon[index]);
        polyline4DList.Add(polygon);
      }
      return (IList<Polyline4D>) polyline4DList;
    }

    public IShape4D Transform(IShape4D shape)
    {
      switch (shape.CheckClipping((IInsideTester4D) this.interface32_0))
      {
        case InsideTestResult.None:
        case InsideTestResult.Outside:
          return NullShape4D.Instance;
        case InsideTestResult.Inside:
          shape.Transform(this.matrix4D_0);
          return shape;
        default:
          IList<Polyline4D> polylines4D = shape.ToPolylines4D(this.double_0);
          List<Polyline4D> polyline4DList = new List<Polyline4D>(polylines4D.Count);
          int count = polylines4D.Count;
          for (int index = 0; index < count; ++index)
            polyline4DList.AddRange((IEnumerable<Polyline4D>) this.interface32_0.Clip(polylines4D[index], shape.IsFilled));
          IShape4D shape4D = (IShape4D) new PolylineShape4D((IList<Polyline4D>) polyline4DList, shape.IsFilled);
          shape4D.Transform(this.matrix4D_0);
          return shape4D;
      }
    }

    public void SetPreTransform(Matrix4D preTransform)
    {
      this.matrix4D_0 *= preTransform;
      this.interface32_0.imethod_0(preTransform.GetInverse());
      this.matrix3D_0 *= new Matrix3D(preTransform.M00, preTransform.M01, preTransform.M02, preTransform.M10, preTransform.M11, preTransform.M12, preTransform.M20, preTransform.M21, preTransform.M22);
      this.ilineTypeScaler_0 = Class624.Create(this.matrix3D_0);
    }

    public InsideTestResult TryIsInside(Bounds3D bounds)
    {
      return this.interface32_0.TryIsInside(bounds);
    }

    public InsideTestResult IsInside(IShape4D shape, out bool transformedShape)
    {
      transformedShape = false;
      return ClipUtil.IsInside((IClipper4D) this.interface32_0, shape, this.double_1);
    }
  }
}
