// Decompiled with JetBrains decompiler
// Type: ns6.Class882
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.IO;
using WW.Diagnostics;

namespace ns6
{
  internal class Class882 : IDumpable
  {
    private Stream stream_0;
    private int int_0;
    private int int_1;

    public Class882(Stream stream, int offset, int length)
    {
      this.stream_0 = stream;
      this.int_0 = offset;
      this.int_1 = length;
    }

    public Stream Stream
    {
      get
      {
        return this.stream_0;
      }
    }

    public int Offset
    {
      get
      {
        return this.int_0;
      }
    }

    public int Length
    {
      get
      {
        return this.int_1;
      }
    }

    public void Dump(DumpWriter w)
    {
      w.WriteField("offset", this.int_0);
      w.WriteField("length", this.int_1);
      w.WriteField("stream", this.stream_0, this.int_0, this.int_1);
    }

    public override string ToString()
    {
      return string.Format("Offset: {0}, length: {1}", (object) this.int_0, (object) this.int_1);
    }
  }
}
