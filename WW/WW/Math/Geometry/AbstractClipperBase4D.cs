// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.AbstractClipperBase4D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;

namespace WW.Math.Geometry
{
  public abstract class AbstractClipperBase4D : IInsideTester4D, IClipper4D
  {
    protected static readonly IList<Segment4D> SegmentClippedAway = (IList<Segment4D>) new Segment4D[0];
    protected static readonly IList<Polyline4D> PolylinesClippedAway = (IList<Polyline4D>) new Polyline4D[0];

    public abstract bool IsInside(Vector4D point);

    public abstract InsideTestResult TryIsInside(Bounds3D bounds);

    public abstract IList<Segment4D> Clip(Segment4D segment);

    public abstract IList<Polyline4D> Clip(Polyline4D polyline, bool filled);
  }
}
