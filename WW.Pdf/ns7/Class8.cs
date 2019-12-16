// Decompiled with JetBrains decompiler
// Type: ns7.Class8
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns2;
using ns3;
using System;

namespace ns7
{
  internal class Class8 : Class0
  {
    internal int int_0;
    internal short short_0;
    internal short short_1;
    internal short short_2;
    internal ushort ushort_0;
    internal short short_3;
    internal short short_4;
    internal short short_5;
    internal short short_6;
    internal short short_7;
    internal short short_8;
    internal short short_9;
    internal ushort ushort_1;

    public Class8(Class41 entry)
      : base(entry)
    {
    }

    public int HMetricCount
    {
      get
      {
        return (int) this.ushort_1;
      }
      set
      {
        this.ushort_1 = Convert.ToUInt16(value);
      }
    }

    protected internal override void vmethod_0(Class80 reader)
    {
      Class74 stream = reader.Stream;
      this.int_0 = stream.method_16();
      this.short_0 = stream.method_6();
      this.short_1 = stream.method_6();
      this.short_2 = stream.method_6();
      this.ushort_0 = stream.method_10();
      this.short_3 = stream.method_6();
      this.short_4 = stream.method_6();
      this.short_5 = stream.method_6();
      this.short_6 = stream.method_4();
      this.short_7 = stream.method_4();
      this.short_8 = stream.method_4();
      int num1 = (int) stream.method_4();
      int num2 = (int) stream.method_4();
      int num3 = (int) stream.method_4();
      int num4 = (int) stream.method_4();
      this.short_9 = stream.method_4();
      this.ushort_1 = stream.method_8();
    }

    protected internal override void vmethod_1(Class79 writer)
    {
      Class74 stream = writer.Stream;
      stream.method_17(this.int_0);
      stream.method_7((int) this.short_0);
      stream.method_7((int) this.short_1);
      stream.method_7((int) this.short_2);
      stream.method_11((int) this.ushort_0);
      stream.method_7((int) this.short_3);
      stream.method_7((int) this.short_4);
      stream.method_7((int) this.short_5);
      stream.method_5((int) this.short_6);
      stream.method_5((int) this.short_7);
      stream.method_5((int) this.short_8);
      stream.method_5(0);
      stream.method_5(0);
      stream.method_5(0);
      stream.method_5(0);
      stream.method_5((int) this.short_9);
      stream.method_9((int) this.ushort_1);
    }
  }
}
