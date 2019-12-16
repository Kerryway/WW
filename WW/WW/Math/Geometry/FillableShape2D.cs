// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.FillableShape2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math.Geometry
{
  public class FillableShape2D : IShape2D
  {
    private readonly IShape2D ishape2D_0;
    private readonly bool bool_0;

    public FillableShape2D(IShape2D shape, bool filled)
    {
      this.ishape2D_0 = shape;
      this.bool_0 = filled;
    }

    public IShape2D Shape
    {
      get
      {
        return this.ishape2D_0;
      }
    }

    public bool Filled
    {
      get
      {
        return this.bool_0;
      }
    }

    public ISegment2DIterator CreateIterator()
    {
      return this.ishape2D_0.CreateIterator();
    }

    public void AddToBounds(Bounds2D bounds)
    {
      this.ishape2D_0.AddToBounds(bounds);
    }

    public bool HasSegments
    {
      get
      {
        return this.ishape2D_0.HasSegments;
      }
    }

    public static FillableShape2D ToFillableShape(IShape2D shape, bool filled)
    {
      FillableShape2D fillableShape2D = shape as FillableShape2D;
      if (fillableShape2D == null)
        return new FillableShape2D(shape, filled);
      if (fillableShape2D.Filled != filled)
        return new FillableShape2D(fillableShape2D.ishape2D_0, filled);
      return fillableShape2D;
    }
  }
}
