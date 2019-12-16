// Decompiled with JetBrains decompiler
// Type: WW.Math.Transformer4DList
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;

namespace WW.Math
{
  public class Transformer4DList : List<ITransformer4D>, ITransformer4D
  {
    public Transformer4DList()
    {
    }

    public Transformer4DList(int capacity)
      : base(capacity)
    {
    }

    public Transformer4DList(IEnumerable<ITransformer4D> collection)
      : base(collection)
    {
    }

    public Vector4D Transform(Vector4D p)
    {
      for (int index = 0; index < this.Count; ++index)
        p = this[index].Transform(p);
      return p;
    }

    public Point2D TransformToPoint2D(Vector4D p)
    {
      for (int index = 0; index < this.Count; ++index)
        p = this[index].Transform(p);
      return p.ToPoint2D();
    }

    public Point3D TransformToPoint3D(Vector4D p)
    {
      for (int index = 0; index < this.Count; ++index)
        p = this[index].Transform(p);
      return p.ToPoint3D();
    }

    public Vector4D TransformTo4D(Point2D p)
    {
      Vector4D p1 = new Vector4D(p.X, p.Y, 0.0, 1.0);
      for (int index = 0; index < this.Count; ++index)
        p1 = this[index].Transform(p1);
      return p1;
    }
  }
}
