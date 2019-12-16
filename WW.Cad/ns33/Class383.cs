// Decompiled with JetBrains decompiler
// Type: ns33.Class383
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW;
using WW.Cad.Drawing;
using WW.Math;
using WW.Math.Geometry;

namespace ns33
{
  internal class Class383 : ICloneable, IClippingTransformer
  {
    private Matrix4D matrix4D_0;
    private Matrix3D matrix3D_0;
    private ILineTypeScaler ilineTypeScaler_0;

    public Class383(Matrix4D transform, Matrix3D matrix3D, ILineTypeScaler lineTypeScaler)
    {
      this.matrix4D_0 = transform;
      this.matrix3D_0 = matrix3D;
      this.ilineTypeScaler_0 = lineTypeScaler;
    }

    public Class383(Matrix4D transform, Matrix3D matrix3D)
    {
      this.matrix4D_0 = transform;
      this.matrix3D_0 = matrix3D;
      this.ilineTypeScaler_0 = Class624.Create(matrix3D);
    }

    public Class383(Matrix4D transform)
      : this(transform, new Matrix3D(transform.M00, transform.M01, transform.M02, transform.M10, transform.M11, transform.M12, transform.M20, transform.M21, transform.M22))
    {
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
      return new Vector4D?(this.matrix4D_0.TransformTo4D(v));
    }

    public IList<Segment4D> Transform(Segment3D segment)
    {
      return (IList<Segment4D>) new Segment4D[1]{ new Segment4D(this.matrix4D_0.TransformTo4D(segment.Start), this.matrix4D_0.TransformTo4D(segment.End)) };
    }

    public IList<Polyline4D> Transform(Polyline3D polyline, bool filled)
    {
      Polyline4D polyline4D = new Polyline4D(polyline.Count, polyline.Closed);
      for (int index = 0; index < polyline.Count; ++index)
        polyline4D.Add(this.matrix4D_0.TransformTo4D(polyline[index]));
      return (IList<Polyline4D>) new Polyline4D[1]{ polyline4D };
    }

    public IShape4D Transform(IShape4D shape)
    {
      shape.Transform(this.matrix4D_0);
      return shape;
    }

    public void SetPreTransform(Matrix4D preTransform)
    {
      this.matrix4D_0 *= preTransform;
      this.matrix3D_0 *= new Matrix3D(preTransform.M00, preTransform.M01, preTransform.M02, preTransform.M10, preTransform.M11, preTransform.M12, preTransform.M20, preTransform.M21, preTransform.M22);
      this.ilineTypeScaler_0 = Class624.Create(this.matrix3D_0);
    }

    public InsideTestResult TryIsInside(Bounds3D bounds)
    {
      return InsideTestResult.Inside;
    }

    public InsideTestResult IsInside(IShape4D shape, out bool transformed)
    {
      transformed = false;
      return InsideTestResult.Inside;
    }

    public object Clone()
    {
      return (object) new Class383(this.matrix4D_0, this.matrix3D_0, this.ilineTypeScaler_0);
    }
  }
}
