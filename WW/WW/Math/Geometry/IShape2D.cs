﻿// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.IShape2D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math.Geometry
{
  public interface IShape2D
  {
    ISegment2DIterator CreateIterator();

    void AddToBounds(Bounds2D bounds);

    bool HasSegments { get; }
  }
}
