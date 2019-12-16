// Decompiled with JetBrains decompiler
// Type: ns28.Class991
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace ns28
{
  internal class Class991 : IComparable<Class991>
  {
    private ulong ulong_0;
    private long long_0;

    public Class991(ulong handle, long streamPosition)
    {
      this.ulong_0 = handle;
      this.long_0 = streamPosition;
    }

    public ulong Handle
    {
      get
      {
        return this.ulong_0;
      }
      set
      {
        this.ulong_0 = value;
      }
    }

    public long StreamPosition
    {
      get
      {
        return this.long_0;
      }
      set
      {
        this.long_0 = value;
      }
    }

    public override string ToString()
    {
      return this.ulong_0.ToString() + ", " + this.long_0.ToString();
    }

    public int CompareTo(Class991 other)
    {
      if (this.ulong_0 < other.ulong_0)
        return -1;
      return this.ulong_0 > other.ulong_0 ? 1 : 0;
    }
  }
}
