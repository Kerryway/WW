// Decompiled with JetBrains decompiler
// Type: ns4.Class5
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns2;
using ns3;
using System.Collections.Generic;

namespace ns4
{
  internal class Class5 : Class0
  {
    private IList<uint> ilist_0;

    public Class5(Class41 entry)
      : base(entry)
    {
    }

    public Class5(Class41 entry, int numOffsets)
      : base(entry)
    {
      this.ilist_0 = (IList<uint>) new List<uint>(numOffsets);
    }

    protected internal override void vmethod_0(Class80 reader)
    {
      Class74 stream = reader.Stream;
      bool isShortFormat = reader.method_3().IsShortFormat;
      int capacity = reader.method_4().GlyphCount + 1;
      this.ilist_0 = (IList<uint>) new List<uint>(capacity);
      for (int index = 0; index < capacity; ++index)
        this.ilist_0.Insert(index, isShortFormat ? (uint) stream.method_8() << 1 : stream.method_14());
    }

    protected internal override void vmethod_1(Class79 writer)
    {
      foreach (uint num in (IEnumerable<uint>) this.ilist_0)
        writer.Stream.method_15(num);
    }

    public void method_0()
    {
      this.ilist_0.Clear();
    }

    public void method_1(uint offset)
    {
      this.ilist_0.Add(offset);
    }

    public int Count
    {
      get
      {
        return this.ilist_0.Count;
      }
    }

    public uint this[int index]
    {
      get
      {
        return this.ilist_0[index];
      }
      set
      {
        this.ilist_0.Insert(index, value);
      }
    }
  }
}
