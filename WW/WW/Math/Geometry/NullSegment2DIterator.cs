// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.NullSegment2DIterator
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math.Geometry
{
  public class NullSegment2DIterator : ISegment2DIterator
  {
    public static readonly NullSegment2DIterator Instance = new NullSegment2DIterator();

    private NullSegment2DIterator()
    {
    }

    public bool MoveNext()
    {
      return false;
    }

    public SegmentType CurrentType
    {
      get
      {
        throw new NoMoreSegmentsException();
      }
    }

    public SegmentType Current(Point2D[] points, int offset)
    {
      throw new NoMoreSegmentsException();
    }

    public int TotalSegmentCount
    {
      get
      {
        return 0;
      }
    }

    public int TotalPointCount
    {
      get
      {
        return 0;
      }
    }
  }
}
