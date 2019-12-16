// Decompiled with JetBrains decompiler
// Type: ns2.Class3
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns3;
using System;

namespace ns2
{
  internal class Class3 : Class0
  {
    private byte[] byte_0;

    public Class3(Class41 entry)
      : base(entry)
    {
    }

    protected internal override void vmethod_0(Class80 reader)
    {
      this.byte_0 = new byte[this.Entry.Length];
      reader.Stream.method_24(this.byte_0, 0, this.byte_0.Length);
    }

    protected internal override void vmethod_1(Class79 writer)
    {
      writer.Stream.method_23(this.byte_0, 0, this.byte_0.Length);
    }
  }
}
