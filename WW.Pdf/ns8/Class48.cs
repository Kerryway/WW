// Decompiled with JetBrains decompiler
// Type: ns8.Class48
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System.Collections.Generic;

namespace ns8
{
  internal class Class48
  {
    private readonly IDictionary<int, int> idictionary_0;
    private readonly IDictionary<int, int> idictionary_1;

    public Class48()
    {
      this.idictionary_0 = (IDictionary<int, int>) new Dictionary<int, int>();
      this.idictionary_1 = (IDictionary<int, int>) new Dictionary<int, int>();
    }

    public int Count
    {
      get
      {
        return this.idictionary_0.Count;
      }
    }

    public bool method_0(int glyphIndex)
    {
      return this.idictionary_0.ContainsKey(glyphIndex);
    }

    public int method_1(int glyphIndex)
    {
      int count;
      if (this.idictionary_0.ContainsKey(glyphIndex))
      {
        count = this.idictionary_0[glyphIndex];
      }
      else
      {
        count = this.idictionary_0.Count;
        this.idictionary_0.Add(glyphIndex, count);
        this.idictionary_1.Add(count, glyphIndex);
      }
      return count;
    }

    public void method_2(params int[] glyphIndices)
    {
      foreach (int glyphIndex in glyphIndices)
        this.method_1(glyphIndex);
    }

    public int method_3(int glyphIndex)
    {
      if (this.idictionary_0.ContainsKey(glyphIndex))
        return this.idictionary_0[glyphIndex];
      return -1;
    }

    public int method_4(int subsetIndex)
    {
      if (this.idictionary_1.ContainsKey(subsetIndex))
        return this.idictionary_1[subsetIndex];
      return -1;
    }

    public IEnumerable<int> GlyphIndices
    {
      get
      {
        List<int> intList = new List<int>((IEnumerable<int>) this.idictionary_0.Keys);
        intList.Sort();
        return (IEnumerable<int>) intList;
      }
    }

    public IEnumerable<int> SubsetIndices
    {
      get
      {
        List<int> intList = new List<int>((IEnumerable<int>) this.idictionary_1.Keys);
        intList.Sort();
        return (IEnumerable<int>) intList;
      }
    }
  }
}
