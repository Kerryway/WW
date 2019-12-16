// Decompiled with JetBrains decompiler
// Type: WW.IO.MemoryPageCache
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Collections.Generic;

namespace WW.IO
{
  public class MemoryPageCache : IMemoryPageCache
  {
    private LinkedList<byte[]> linkedList_0 = new LinkedList<byte[]>();
    private int int_0;

    public MemoryPageCache()
    {
      this.int_0 = 65536;
    }

    public MemoryPageCache(int pageSize)
    {
      this.int_0 = pageSize;
    }

    public int PageSize
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public byte[] GetPage(int pageSize)
    {
      if (pageSize != this.int_0)
        throw new ArgumentException("This cache only has pages of size " + (object) this.int_0 + ".");
      byte[] numArray;
      if (this.linkedList_0.Count > 0)
      {
        numArray = this.linkedList_0.Last.Value;
        this.linkedList_0.RemoveLast();
      }
      else
        numArray = new byte[pageSize];
      return numArray;
    }

    public void ReleasePage(byte[] page)
    {
      if (page.Length != this.int_0)
        return;
      this.linkedList_0.AddLast(page);
    }
  }
}
