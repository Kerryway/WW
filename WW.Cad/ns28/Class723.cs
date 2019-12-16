// Decompiled with JetBrains decompiler
// Type: ns28.Class723
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.IO;

namespace ns28
{
  internal class Class723 : IComparable<Class723>
  {
    private int? nullable_0;
    private int int_0;
    private MemoryStream memoryStream_0;

    public Class723(int? sectionId, int position, MemoryStream stream)
    {
      this.nullable_0 = sectionId;
      this.int_0 = position;
      this.memoryStream_0 = stream;
      if (stream != null)
        return;
      this.int_0 = 0;
    }

    public int? SectionId
    {
      get
      {
        return this.nullable_0;
      }
    }

    public int Position
    {
      get
      {
        return this.int_0;
      }
    }

    public MemoryStream Stream
    {
      get
      {
        return this.memoryStream_0;
      }
      set
      {
        this.memoryStream_0 = value;
      }
    }

    public long Size
    {
      get
      {
        long num = 0;
        if (this.memoryStream_0 != null)
          num = this.memoryStream_0.Length;
        return num;
      }
    }

    public int CompareTo(Class723 other)
    {
      return !this.nullable_0.HasValue ? (!other.nullable_0.HasValue ? 0 : -1) : (!other.nullable_0.HasValue ? 1 : (this.nullable_0.Value >= other.nullable_0.Value ? (this.nullable_0.Value <= other.nullable_0.Value ? 0 : 1) : -1));
    }
  }
}
