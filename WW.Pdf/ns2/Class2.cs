// Decompiled with JetBrains decompiler
// Type: ns2.Class2
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns3;
using System;

namespace ns2
{
  internal class Class2 : Class0
  {
    private static readonly DateTime dateTime_2 = new DateTime(1904, 1, 1, 0, 0, 0);
    internal int int_0;
    internal int int_1;
    internal uint uint_0;
    internal uint uint_1;
    internal ushort ushort_0;
    internal ushort ushort_1;
    internal DateTime dateTime_0;
    internal DateTime dateTime_1;
    internal short short_0;
    internal short short_1;
    internal short short_2;
    internal short short_3;
    internal ushort ushort_2;
    internal ushort ushort_3;
    internal short short_4;
    internal short short_5;
    internal short short_6;

    public Class2(Class41 entry)
      : base(entry)
    {
    }

    public bool IsShortFormat
    {
      get
      {
        return this.short_5 == (short) 0;
      }
    }

    protected internal override void vmethod_0(Class80 reader)
    {
      Class74 stream = reader.Stream;
      this.int_0 = stream.method_16();
      this.int_1 = stream.method_16();
      this.uint_0 = stream.method_14();
      this.uint_1 = stream.method_14();
      this.ushort_0 = stream.method_8();
      this.ushort_1 = stream.method_8();
      this.dateTime_0 = Class2.smethod_0(stream.method_18());
      this.dateTime_1 = Class2.smethod_0(stream.method_18());
      this.short_0 = stream.method_4();
      this.short_1 = stream.method_4();
      this.short_2 = stream.method_4();
      this.short_3 = stream.method_4();
      this.ushort_2 = stream.method_8();
      this.ushort_3 = stream.method_8();
      this.short_4 = stream.method_4();
      this.short_5 = stream.method_4();
      this.short_6 = stream.method_4();
    }

    private static DateTime smethod_0(long seconds)
    {
      try
      {
        return new DateTime(Class2.dateTime_2.Ticks).AddSeconds((double) seconds);
      }
      catch
      {
        return Class2.dateTime_2;
      }
    }

    protected internal override void vmethod_1(Class79 writer)
    {
      Class74 stream = writer.Stream;
      stream.method_17(this.int_0);
      stream.method_17(this.int_1);
      stream.method_15(0U);
      stream.method_15(1594834165U);
      stream.method_9((int) this.ushort_0);
      stream.method_9((int) this.ushort_1);
      stream.method_19((long) (this.dateTime_0 - Class2.dateTime_2).TotalSeconds);
      stream.method_19((long) (this.dateTime_1 - Class2.dateTime_2).TotalSeconds);
      stream.method_5((int) this.short_0);
      stream.method_5((int) this.short_1);
      stream.method_5((int) this.short_2);
      stream.method_5((int) this.short_3);
      stream.method_9((int) this.ushort_2);
      stream.method_9((int) this.ushort_3);
      stream.method_5((int) this.short_4);
      stream.method_5(1);
      stream.method_5((int) this.short_6);
    }
  }
}
