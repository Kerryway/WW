// Decompiled with JetBrains decompiler
// Type: ns6.Class1068
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System.IO;
using WW.Diagnostics;
using WW.IO;

namespace ns6
{
  internal class Class1068 : IDumpable, Interface2
  {
    private Stream stream_0;

    public Stream Stream
    {
      get
      {
        return this.stream_0;
      }
      set
      {
        this.stream_0 = value;
      }
    }

    public override string ToString()
    {
      return string.Format("DataRecord, length: {0}", (object) (this.stream_0 == null ? 0L : this.stream_0.Length));
    }

    public Stream imethod_0(Class741.Class742 serializer)
    {
      return this.stream_0;
    }

    public void Read(Class889 r, int dataSize)
    {
      this.stream_0 = (Stream) new PagedMemoryStream(r.Stream, (long) dataSize);
    }

    public void Write(Class889 w)
    {
      w.vmethod_11((uint) this.stream_0.Length);
      StreamUtil.Forward(this.stream_0, w.Stream);
    }

    public void Dump(DumpWriter w)
    {
      w.WriteField("bytes", this.stream_0);
    }
  }
}
