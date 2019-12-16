// Decompiled with JetBrains decompiler
// Type: ns11.Class64
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns3;
using System.Collections.Generic;
using System.IO;
using WW.Pdf;

namespace ns11
{
  internal class Class64 : IPdfOutput
  {
    private readonly List<Class65> list_0 = new List<Class65>();
    private readonly Stream stream_0;

    public Class64(Stream stream)
    {
      this.stream_0 = stream;
    }

    public List<Class65> ObjectPositions
    {
      get
      {
        return this.list_0;
      }
    }

    public bool UseFilters
    {
      get
      {
        return true;
      }
    }

    public void Write(byte[] data, int offset, int count)
    {
      this.stream_0.Write(data, offset, count);
    }
  }
}
