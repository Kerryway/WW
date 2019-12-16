// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.IPolylineFactory`2
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System.Collections.Generic;

namespace WW.Math.Geometry
{
  public interface IPolylineFactory<T, TPolyline> where TPolyline : Polyline<T>
  {
    TPolyline Create(bool closed);

    TPolyline Create(int capacity, bool closed);

    TPolyline Create(bool closed, params T[] polyline);

    TPolyline Create(bool closed, IEnumerable<T> polyline);

    TPolyline Create();

    TPolyline Create(int capacity);

    TPolyline Create(params T[] points);

    TPolyline Create(IEnumerable<T> points);

    TPolyline Create(Polyline<T> polyline);
  }
}
