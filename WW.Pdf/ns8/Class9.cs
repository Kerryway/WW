// Decompiled with JetBrains decompiler
// Type: ns8.Class9
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns2;
using ns3;
using ns6;
using System.Collections.Generic;

namespace ns8
{
  internal class Class9 : Class0
  {
    private readonly IDictionary<int, Class47> idictionary_0;

    public Class9(Class41 entry)
      : base(entry)
    {
      this.idictionary_0 = (IDictionary<int, Class47>) new Dictionary<int, Class47>();
    }

    public Class47 this[int glyphIndex]
    {
      get
      {
        Class47 class47;
        this.idictionary_0.TryGetValue(glyphIndex, out class47);
        return class47;
      }
      set
      {
        this.idictionary_0[glyphIndex] = value;
      }
    }

    public int Count
    {
      get
      {
        return this.idictionary_0.Count;
      }
    }

    protected internal override void vmethod_0(Class80 reader)
    {
      ns1.Class73 class73 = new ns1.Class73(reader);
      foreach (int glyphIndex1 in reader.IndexMappings.GlyphIndices)
      {
        Class47 class47 = class73.method_0(glyphIndex1);
        this.idictionary_0[class47.Index] = class47;
        if (class47.IsComposite)
        {
          foreach (int child in (IEnumerable<int>) class47.Children)
          {
            if (this[child] == null)
            {
              int glyphIndex2 = reader.IndexMappings.method_4(child);
              this[child] = class73.method_0(glyphIndex2);
            }
          }
        }
      }
    }

    protected internal override void vmethod_1(ns3.Class79 writer)
    {
      ns2.Class74 stream = writer.Stream;
      foreach (int orderedIndex in this.OrderedIndexes)
        this[orderedIndex].method_2(stream);
    }

    private IEnumerable<int> OrderedIndexes
    {
      get
      {
        List<int> intList = new List<int>((IEnumerable<int>) this.idictionary_0.Keys);
        intList.Sort();
        return (IEnumerable<int>) intList;
      }
    }
  }
}
