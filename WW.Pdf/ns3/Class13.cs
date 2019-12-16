// Decompiled with JetBrains decompiler
// Type: ns3.Class13
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns2;
using System;

namespace ns3
{
  internal class Class13 : Class0
  {
    private short[] short_0;

    public Class13(Class41 entry)
      : base(entry)
    {
    }

    public int Count
    {
      get
      {
        return this.short_0.Length;
      }
    }

    protected internal override void vmethod_0(Class80 reader)
    {
      this.short_0 = new short[this.Entry.Length / 2U];
      for (int index = 0; index < this.short_0.Length; ++index)
        this.short_0[index] = reader.Stream.method_6();
    }

    protected internal override void vmethod_1(Class79 writer)
    {
      foreach (short num in this.short_0)
        writer.Stream.method_7((int) num);
    }
  }
}
