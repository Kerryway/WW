// Decompiled with JetBrains decompiler
// Type: ns8.Class81
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns2;
using System.Collections;
using System.Collections.Generic;

namespace ns8
{
  internal class Class81 : IEnumerable<Class43>, IEnumerable
  {
    private readonly IList<Class43> ilist_0 = (IList<Class43>) new List<Class43>();

    public void Add(Class43 entry)
    {
      this.ilist_0.Add(entry);
    }

    public Class43 this[int index]
    {
      get
      {
        return this.ilist_0[index];
      }
    }

    public int Count
    {
      get
      {
        return this.ilist_0.Count;
      }
    }

    public int NumRanges
    {
      get
      {
        int num = 0;
        foreach (Class43 class43 in (IEnumerable<Class43>) this.ilist_0)
        {
          if (class43.IsRange)
            ++num;
        }
        return num;
      }
    }

    public Class43[] Ranges
    {
      get
      {
        List<Class43> class43List = new List<Class43>(this.NumRanges);
        foreach (Class43 class43 in this)
        {
          if (class43.IsRange)
            class43List.Add(class43);
        }
        return class43List.ToArray();
      }
    }

    public int NumChars
    {
      get
      {
        return this.ilist_0.Count - this.NumRanges;
      }
    }

    public Class43[] Chars
    {
      get
      {
        List<Class43> class43List = new List<Class43>(this.NumChars);
        foreach (Class43 class43 in this)
        {
          if (class43.IsChar)
            class43List.Add(class43);
        }
        return class43List.ToArray();
      }
    }

    public IEnumerator<Class43> GetEnumerator()
    {
      return this.ilist_0.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.GetEnumerator();
    }
  }
}
