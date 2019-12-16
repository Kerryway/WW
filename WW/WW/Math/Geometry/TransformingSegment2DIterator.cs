// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.TransformingSegment2DIterator
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math.Geometry
{
  public class TransformingSegment2DIterator : ISegment2DIterator
  {
    private readonly ISegment2DIterator isegment2DIterator_0;
    private readonly Matrix4D matrix4D_0;

    public TransformingSegment2DIterator(ISegment2DIterator iterator, Matrix4D transformation)
    {
      this.isegment2DIterator_0 = iterator;
      this.matrix4D_0 = transformation;
    }

    public bool MoveNext()
    {
      return this.isegment2DIterator_0.MoveNext();
    }

    public SegmentType CurrentType
    {
      get
      {
        return this.isegment2DIterator_0.CurrentType;
      }
    }

    public SegmentType Current(Point2D[] points, int offset)
    {
      SegmentType segmentType = this.isegment2DIterator_0.Current(points, offset);
      switch (segmentType)
      {
        case SegmentType.MoveTo:
        case SegmentType.LineTo:
          points[offset] = this.matrix4D_0.TransformTo2D(points[offset]);
          break;
        case SegmentType.QuadTo:
          points[offset] = this.matrix4D_0.TransformTo2D(points[offset]);
          ++offset;
          points[offset] = this.matrix4D_0.TransformTo2D(points[offset]);
          break;
        case SegmentType.CubicTo:
          points[offset] = this.matrix4D_0.TransformTo2D(points[offset]);
          ++offset;
          points[offset] = this.matrix4D_0.TransformTo2D(points[offset]);
          ++offset;
          points[offset] = this.matrix4D_0.TransformTo2D(points[offset]);
          break;
      }
      return segmentType;
    }

    public int TotalSegmentCount
    {
      get
      {
        return this.isegment2DIterator_0.TotalSegmentCount;
      }
    }

    public int TotalPointCount
    {
      get
      {
        return this.isegment2DIterator_0.TotalPointCount;
      }
    }
  }
}
