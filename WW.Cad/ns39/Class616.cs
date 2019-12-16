// Decompiled with JetBrains decompiler
// Type: ns39.Class616
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace ns39
{
  internal class Class616 : Class614, IComparable<Class616>
  {
    private int int_1;
    private int int_2;
    private int int_3;
    private ulong ulong_0;
    private uint uint_0;
    private uint uint_1;

    public int CompressedSize
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public int DecompressedSize
    {
      get
      {
        return this.int_2;
      }
      set
      {
        this.int_2 = value;
      }
    }

    public int PageSize
    {
      get
      {
        return this.int_3;
      }
      set
      {
        this.int_3 = value;
      }
    }

    public ulong StartOffset
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

    public uint DataChecksum
    {
      get
      {
        return this.uint_0;
      }
      set
      {
        this.uint_0 = value;
      }
    }

    public uint HeaderChecksum
    {
      get
      {
        return this.uint_1;
      }
      set
      {
        this.uint_1 = value;
      }
    }

    public int CompareTo(Class616 other)
    {
      if (this.ulong_0 < other.ulong_0)
        return -1;
      return this.ulong_0 > other.ulong_0 ? 1 : 0;
    }
  }
}
