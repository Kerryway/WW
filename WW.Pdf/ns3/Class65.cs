﻿// Decompiled with JetBrains decompiler
// Type: ns3.Class65
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using WW.Pdf;

namespace ns3
{
  internal class Class65
  {
    private readonly IPdfIndirectObject ipdfIndirectObject_0;
    private readonly long long_0;

    public Class65()
    {
    }

    public Class65(IPdfIndirectObject indirectObject, long position)
    {
      this.ipdfIndirectObject_0 = indirectObject;
      this.long_0 = position;
    }

    public IPdfIndirectObject IndirectObject
    {
      get
      {
        return this.ipdfIndirectObject_0;
      }
    }

    public long Position
    {
      get
      {
        return this.long_0;
      }
    }
  }
}
