// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.IShape4D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace WW.Math.Geometry
{
  public interface IShape4D
  {
    bool IsFilled { get; }

    bool IsEmpty { get; }

    InsideTestResult CheckClipping(IInsideTester4D region);

    void Transform(Matrix4D transform);

    void UpdateBounds(Bounds3D bounds, Matrix4D modelTransform);

    IList<Polyline4D> ToPolylines4D(double shapeFlattenEpsilon);

    IShape2D ToShape2D(Matrix4D transform);

    GraphicsPath ToGraphicsPath(Matrix4D transform);

    IShape4D GetFlattened(ITransformer4D transformer, double shapeFlattenEpsilon);

    ISegment2DIterator CreateIterator(Matrix4D transform);

    FlatShape4D ToFlatShape();
  }
}
