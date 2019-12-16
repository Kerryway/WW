// Decompiled with JetBrains decompiler
// Type: ns6.Class10
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns2;
using ns3;
using System;

namespace ns6
{
  internal class Class10 : Class0
  {
    private int int_0;
    private float float_0;
    private short short_0;
    private short short_1;
    private uint uint_0;
    private uint uint_1;
    private uint uint_2;
    private uint uint_3;
    private uint uint_4;

    public Class10(Class41 entry)
      : base(entry)
    {
    }

    public bool IsFixedPitch
    {
      get
      {
        return this.uint_0 == 1U;
      }
    }

    public float ItalicAngle
    {
      get
      {
        return this.float_0;
      }
    }

    protected internal override void vmethod_0(Class80 reader)
    {
      ns2.Class74 stream = reader.Stream;
      this.int_0 = stream.method_16();
      this.float_0 = (float) stream.method_16() / 65536f;
      this.short_0 = stream.method_6();
      this.short_1 = stream.method_6();
      this.uint_0 = stream.method_14();
      this.uint_1 = stream.method_14();
      this.uint_2 = stream.method_14();
      this.uint_3 = stream.method_14();
      this.uint_4 = stream.method_14();
    }

    protected internal override void vmethod_1(ns3.Class79 writer)
    {
      throw new NotImplementedException("Write is not implemented.");
    }
  }
}
