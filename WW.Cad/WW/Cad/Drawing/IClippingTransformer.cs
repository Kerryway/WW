// Decompiled with JetBrains decompiler
// Type: WW.Cad.Drawing.IClippingTransformer
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Math;
using WW.Math.Geometry;

namespace WW.Cad.Drawing
{
  public interface IClippingTransformer : ICloneable
  {
    Matrix4D Matrix { get; }

    Matrix3D Matrix3D { get; }

    ILineTypeScaler LineTypeScaler { get; }

    Vector4D? Transform(Point3D v);

    IList<Segment4D> Transform(Segment3D segment);

    IList<Polyline4D> Transform(Polyline3D polyline, bool filled);

    IShape4D Transform(IShape4D shape);

    void SetPreTransform(Matrix4D preTransform);

    InsideTestResult TryIsInside(Bounds3D bounds);

    InsideTestResult IsInside(IShape4D shape, out bool transformedShape);
  }
}
