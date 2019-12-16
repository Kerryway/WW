// Decompiled with JetBrains decompiler
// Type: ns33.Class938
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Model.Entities;
using WW.Math;
using WW.Math.Geometry;

namespace ns33
{
  internal class Class938 : WW.ICloneable, IClippingTransformer
  {
    private DxfViewport dxfViewport_0;
    private double double_0;
    private double double_1;
    private Matrix4D matrix4D_0;
    private BlinnClipper4D blinnClipper4D_0;
    private Matrix4D matrix4D_1;
    private Matrix4D matrix4D_2;
    private Matrix3D matrix3D_0;
    private ILineTypeScaler ilineTypeScaler_0;

    public Class938(
      DxfViewport viewport,
      Matrix4D postTransform,
      double shapeFlattenEpsilon,
      double shapeFlattenEpsilonForBoundsCalculation,
      bool scaleLineTypes)
    {
      this.dxfViewport_0 = viewport;
      if (viewport == null)
        throw new ArgumentException("Viewport may not be null");
      this.double_0 = shapeFlattenEpsilon;
      this.double_1 = shapeFlattenEpsilonForBoundsCalculation;
      this.matrix4D_0 = viewport.method_14();
      this.matrix4D_1 = postTransform * viewport.method_15();
      this.matrix4D_2 = this.matrix4D_1 * this.matrix4D_0;
      this.blinnClipper4D_0 = new BlinnClipper4D(viewport.FrontClippingActive, viewport.BackClippingActive);
      if (scaleLineTypes)
      {
        this.matrix3D_0 = viewport.method_16();
        this.ilineTypeScaler_0 = Class624.Create(this.matrix3D_0);
      }
      else
      {
        this.matrix3D_0 = Matrix3D.Identity;
        this.ilineTypeScaler_0 = (ILineTypeScaler) Class624.Class626.class626_0;
      }
    }

    private Class938()
    {
    }

    public Matrix4D Matrix
    {
      get
      {
        return this.matrix4D_2;
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
      Vector4D vector4D = this.matrix4D_0.TransformTo4D(v);
      if (!this.blinnClipper4D_0.IsInside(vector4D))
        return new Vector4D?();
      return new Vector4D?(this.matrix4D_1.Transform(vector4D));
    }

    public IList<Segment4D> Transform(Segment3D segment)
    {
      Segment4D segment1 = new Segment4D(this.matrix4D_0.TransformTo4D(segment.Start), this.matrix4D_0.TransformTo4D(segment.End));
      List<Segment4D> segment4DList = new List<Segment4D>();
      foreach (Segment4D segment4D in (IEnumerable<Segment4D>) this.blinnClipper4D_0.Clip(segment1))
        segment4DList.Add(new Segment4D(this.matrix4D_1.Transform(segment4D.Start), this.matrix4D_1.Transform(segment4D.End)));
      return (IList<Segment4D>) segment4DList;
    }

    public IList<Polyline4D> Transform(Polyline3D polyline, bool filled)
    {
      return DxfUtil.GetTransformed((IEnumerable<Polyline4D>) this.blinnClipper4D_0.Clip(DxfUtil.smethod_40(polyline, this.matrix4D_0), filled), this.matrix4D_1);
    }

    public IShape4D Transform(IShape4D shape)
    {
      shape.Transform(this.matrix4D_0);
      switch (shape.CheckClipping((IInsideTester4D) this.blinnClipper4D_0))
      {
        case InsideTestResult.None:
        case InsideTestResult.Outside:
          return NullShape4D.Instance;
        case InsideTestResult.Inside:
          shape.Transform(this.matrix4D_1);
          return shape;
        default:
          IList<Polyline4D> polylines4D = shape.ToPolylines4D(this.double_0);
          List<Polyline4D> polyline4DList1 = new List<Polyline4D>(polylines4D.Count);
          int count = polylines4D.Count;
          bool flag = true;
          for (int index = 0; index < count; ++index)
          {
            Polyline4D polyline = polylines4D[index];
            IList<Polyline4D> polyline4DList2 = this.blinnClipper4D_0.Clip(polyline, shape.IsFilled);
            if (polyline4DList2.Count != 1 || polyline4DList2[0] != polyline)
              flag = false;
            polyline4DList1.AddRange((IEnumerable<Polyline4D>) DxfUtil.GetTransformed((IEnumerable<Polyline4D>) polyline4DList2, this.matrix4D_1));
          }
          if (!flag)
            return (IShape4D) new PolylineShape4D((IList<Polyline4D>) polyline4DList1, shape.IsFilled);
          shape.Transform(this.matrix4D_1);
          return shape;
      }
    }

    public void SetPreTransform(Matrix4D preTransform)
    {
      this.matrix4D_0 *= preTransform;
      this.matrix4D_2 = this.matrix4D_1 * this.matrix4D_0;
      this.matrix3D_0 *= new Matrix3D(preTransform.M00, preTransform.M01, preTransform.M02, preTransform.M10, preTransform.M11, preTransform.M12, preTransform.M20, preTransform.M21, preTransform.M22);
      this.ilineTypeScaler_0 = Class624.Create(this.matrix3D_0);
    }

    public InsideTestResult TryIsInside(Bounds3D bounds)
    {
      bounds = DxfUtil.Transform(bounds, this.matrix4D_0);
      return this.blinnClipper4D_0.TryIsInside(bounds);
    }

    public InsideTestResult IsInside(IShape4D shape, out bool transformedShape)
    {
      transformedShape = true;
      shape.Transform(this.matrix4D_0);
      InsideTestResult insideTestResult = ClipUtil.IsInside((IClipper4D) this.blinnClipper4D_0, shape, this.double_1);
      shape.Transform(this.matrix4D_1);
      return insideTestResult;
    }

    public object Clone()
    {
      return (object) new Class938() { dxfViewport_0 = this.dxfViewport_0, double_0 = this.double_0, double_1 = this.double_1, matrix4D_0 = this.matrix4D_0, blinnClipper4D_0 = this.blinnClipper4D_0, matrix4D_1 = this.matrix4D_1, matrix4D_2 = this.matrix4D_2, matrix3D_0 = this.matrix3D_0, ilineTypeScaler_0 = this.ilineTypeScaler_0 };
    }
  }
}
