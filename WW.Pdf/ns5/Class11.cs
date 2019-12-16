// Decompiled with JetBrains decompiler
// Type: ns5.Class11
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns2;
using ns3;
using System;

namespace ns5
{
  internal class Class11 : Class0
  {
    internal int int_0;
    internal ushort ushort_0;
    internal ushort ushort_1;
    internal ushort ushort_2;
    internal ushort ushort_3;
    internal ushort ushort_4;
    internal ushort ushort_5;
    internal ushort ushort_6;
    internal ushort ushort_7;
    internal ushort ushort_8;
    internal ushort ushort_9;
    internal ushort ushort_10;
    internal ushort ushort_11;
    internal ushort ushort_12;
    internal ushort ushort_13;

    public Class11(Class41 entry)
      : base(entry)
    {
    }

    public int GlyphCount
    {
      get
      {
        return (int) this.ushort_0;
      }
      set
      {
        this.ushort_0 = Convert.ToUInt16(value);
      }
    }

    protected internal override void vmethod_0(Class80 reader)
    {
      Class74 stream = reader.Stream;
      this.int_0 = stream.method_16();
      this.ushort_0 = stream.method_8();
      if (this.int_0 != 65536)
        return;
      this.ushort_1 = stream.method_8();
      this.ushort_2 = stream.method_8();
      this.ushort_3 = stream.method_8();
      this.ushort_4 = stream.method_8();
      this.ushort_5 = stream.method_8();
      this.ushort_6 = stream.method_8();
      this.ushort_7 = stream.method_8();
      this.ushort_8 = stream.method_8();
      this.ushort_9 = stream.method_8();
      this.ushort_10 = stream.method_8();
      this.ushort_11 = stream.method_8();
      this.ushort_12 = stream.method_8();
      this.ushort_13 = stream.method_8();
    }

    protected internal override void vmethod_1(Class79 writer)
    {
      Class74 stream = writer.Stream;
      stream.method_17(this.int_0);
      stream.method_9((int) this.ushort_0);
      if (this.int_0 != 65536)
        return;
      stream.method_9((int) this.ushort_1);
      stream.method_9((int) this.ushort_2);
      stream.method_9((int) this.ushort_3);
      stream.method_9((int) this.ushort_4);
      stream.method_9((int) this.ushort_5);
      stream.method_9((int) this.ushort_6);
      stream.method_9((int) this.ushort_7);
      stream.method_9((int) this.ushort_8);
      stream.method_9((int) this.ushort_9);
      stream.method_9((int) this.ushort_10);
      stream.method_9((int) this.ushort_11);
      stream.method_9((int) this.ushort_12);
      stream.method_9((int) this.ushort_13);
    }
  }
}
