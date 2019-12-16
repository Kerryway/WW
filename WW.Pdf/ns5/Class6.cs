// Decompiled with JetBrains decompiler
// Type: ns5.Class6
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns2;
using ns3;
using System.Collections.Generic;

namespace ns5
{
  internal class Class6 : Class0
  {
    public IList<Class57> ilist_0;

    public Class6(Class41 entry)
      : base(entry)
    {
    }

    public Class6(Class41 entry, int numMetrics)
      : base(entry)
    {
      this.ilist_0 = (IList<Class57>) new List<Class57>(numMetrics);
    }

    public int Count
    {
      get
      {
        return this.ilist_0.Count;
      }
    }

    public Class57 this[int index]
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

    protected internal override void vmethod_0(Class80 reader)
    {
      Class74 stream = reader.Stream;
      int hmetricCount = reader.method_5().HMetricCount;
      int glyphCount = reader.method_4().GlyphCount;
      int capacity = glyphCount > hmetricCount ? glyphCount : hmetricCount;
      this.ilist_0 = (IList<Class57>) new List<Class57>(capacity);
      for (int index = 0; index < hmetricCount; ++index)
        this.ilist_0.Add(new Class57(stream.method_8(), stream.method_4()));
      if (hmetricCount >= capacity)
        return;
      Class57 class57 = this.ilist_0[this.ilist_0.Count - 1];
      for (int index = hmetricCount; index < glyphCount; ++index)
        this.ilist_0.Add(new Class57(class57.AdvanceWidth, stream.method_4()));
    }

    protected internal override void vmethod_1(Class79 writer)
    {
      Class74 stream = writer.Stream;
      foreach (Class57 class57 in (IEnumerable<Class57>) this.ilist_0)
      {
        stream.method_9((int) class57.AdvanceWidth);
        stream.method_5((int) class57.LeftSideBearing);
      }
    }
  }
}
