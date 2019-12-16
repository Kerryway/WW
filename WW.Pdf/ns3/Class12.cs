// Decompiled with JetBrains decompiler
// Type: ns3.Class12
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns2;
using ns8;
using System;

namespace ns3
{
  internal class Class12 : Class0
  {
    private const int int_0 = 1;
    private const int int_1 = 2;
    private bool bool_0;
    private Class77 class77_0;

    public Class12(Class41 entry)
      : base(entry)
    {
    }

    public bool HasKerningInfo
    {
      get
      {
        return this.bool_0;
      }
    }

    public Class77 KerningPairs
    {
      get
      {
        return this.class77_0;
      }
    }

    protected internal override void vmethod_0(Class80 reader)
    {
      Class74 stream = reader.Stream;
      stream.method_25(2L);
      int num1 = (int) stream.method_8();
      for (int index1 = 0; index1 < num1; ++index1)
      {
        stream.method_25(2L);
        ushort num2 = stream.method_8();
        ushort num3 = stream.method_8();
        if (((int) num3 & 1) == 1 && ((int) num3 & 2) == 0 && (int) num3 >> 8 == 0)
        {
          int numPairs = (int) stream.method_8();
          this.bool_0 = true;
          this.class77_0 = new Class77(numPairs);
          stream.method_25(6L);
          for (int index2 = 0; index2 < numPairs; ++index2)
            this.class77_0.method_1(stream.method_8(), stream.method_8(), (int) stream.method_6());
        }
        else
          stream.method_25((long) ((int) num2 - 6));
      }
    }

    protected internal override void vmethod_1(Class79 writer)
    {
      throw new InvalidOperationException("Write not supported.");
    }
  }
}
