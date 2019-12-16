// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.CachedBoundsShape2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math.Geometry
{
  public class CachedBoundsShape2D : IShape2D
  {
    private readonly IShape2D ishape2D_0;
    private readonly Bounds2D bounds2D_0;

    public CachedBoundsShape2D(IShape2D wrappedShape)
    {
      this.ishape2D_0 = wrappedShape;
      this.bounds2D_0 = new Bounds2D();
      wrappedShape.AddToBounds(this.bounds2D_0);
      if (this.bounds2D_0.Initialized)
        return;
      this.bounds2D_0 = (Bounds2D) null;
    }

    public ISegment2DIterator CreateIterator()
    {
      return this.ishape2D_0.CreateIterator();
    }

    public void AddToBounds(Bounds2D bounds)
    {
      if (this.bounds2D_0 == null)
        return;
      bounds.Update(this.bounds2D_0);
    }

    public bool HasSegments
    {
      get
      {
        return this.ishape2D_0.HasSegments;
      }
    }

    internal IShape2D WrappedShape
    {
      get
      {
        return this.ishape2D_0;
      }
    }
  }
}
