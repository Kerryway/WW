// Decompiled with JetBrains decompiler
// Type: WW.Math.Geometry.Polyline`1
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WW.Math.Geometry
{
  [Serializable]
  public class Polyline<T> : List<T>
  {
    private bool closed;

    [DebuggerStepThrough]
    public Polyline(bool closed)
    {
      this.closed = closed;
    }

    [DebuggerStepThrough]
    public Polyline(int capacity, bool closed)
      : base(capacity)
    {
      this.closed = closed;
    }

    [DebuggerStepThrough]
    public Polyline(bool closed, params T[] polyline)
      : base((IEnumerable<T>) polyline)
    {
      this.closed = closed;
    }

    [DebuggerStepThrough]
    public Polyline(bool closed, IEnumerable<T> polyline)
      : base(polyline)
    {
      this.closed = closed;
    }

    [DebuggerStepThrough]
    public Polyline()
      : this(false)
    {
    }

    [DebuggerStepThrough]
    public Polyline(int capacity)
      : this(capacity, false)
    {
    }

    [DebuggerStepThrough]
    public Polyline(params T[] points)
      : this(false, points)
    {
    }

    [DebuggerStepThrough]
    public Polyline(IEnumerable<T> points)
      : this(false, points)
    {
    }

    [DebuggerStepThrough]
    public Polyline(Polyline<T> polyline)
      : this(polyline.Closed, (IEnumerable<T>) polyline)
    {
    }

    public bool Closed
    {
      get
      {
        return this.closed;
      }
      set
      {
        this.closed = value;
      }
    }
  }
}
