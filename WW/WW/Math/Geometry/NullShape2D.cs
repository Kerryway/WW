// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.NullShape2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math.Geometry
{
  public class NullShape2D : IShape2D
  {
    public static readonly NullShape2D Instance = new NullShape2D();

    private NullShape2D()
    {
    }

    public ISegment2DIterator CreateIterator()
    {
      return (ISegment2DIterator) NullSegment2DIterator.Instance;
    }

    public void AddToBounds(Bounds2D bounds)
    {
    }

    public bool HasSegments
    {
      get
      {
        return false;
      }
    }
  }
}
