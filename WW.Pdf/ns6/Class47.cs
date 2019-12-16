// Decompiled with JetBrains decompiler
// Type: ns6.Class47
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System.Collections.Generic;

namespace ns6
{
  internal class Class47
  {
    private readonly int int_0;
    private byte[] byte_0;
    private readonly IList<int> ilist_0;

    public Class47(int glyphIndex)
    {
      this.int_0 = glyphIndex;
      this.ilist_0 = (IList<int>) new List<int>();
    }

    public void method_0(byte[] glyphData)
    {
      this.byte_0 = glyphData;
    }

    public int Index
    {
      get
      {
        return this.int_0;
      }
    }

    public uint Length
    {
      get
      {
        if (this.byte_0 == null)
          return 0;
        return (uint) this.byte_0.Length;
      }
    }

    public void method_1(int glyphIndex)
    {
      this.ilist_0.Add(glyphIndex);
    }

    public IList<int> Children
    {
      get
      {
        return this.ilist_0;
      }
    }

    public bool IsComposite
    {
      get
      {
        return this.ilist_0.Count != 0;
      }
    }

    public void method_2(ns2.Class74 stream)
    {
      if (this.byte_0 == null || this.byte_0.Length <= 0)
        return;
      stream.method_23(this.byte_0, 0, this.byte_0.Length);
    }
  }
}
