// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.IClipper4D
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;

namespace WW.Math.Geometry
{
  public interface IClipper4D : IInsideTester4D
  {
    IList<Segment4D> Clip(Segment4D segment);

    IList<Polyline4D> Clip(Polyline4D polyline, bool filled);
  }
}
