// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.ISegment2DIterator
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math.Geometry
{
  public interface ISegment2DIterator
  {
    bool MoveNext();

    SegmentType CurrentType { get; }

    SegmentType Current(Point2D[] points, int offset);

    int TotalSegmentCount { get; }

    int TotalPointCount { get; }
  }
}
