// Decompiled with JetBrains decompiler
// Type: ns6.Class558
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using WW.Diagnostics;

namespace ns6
{
  internal class Class558 : IDumpable
  {
    private uint uint_0;
    private uint uint_1;

    public uint DataSize
    {
      get
      {
        return this.uint_0;
      }
      set
      {
        this.uint_0 = value;
      }
    }

    public uint UnknownFlags
    {
      get
      {
        return this.uint_1;
      }
      set
      {
        this.uint_1 = value;
      }
    }

    internal void Read(Class889 r)
    {
      this.uint_0 = r.vmethod_10();
      this.uint_1 = r.vmethod_10();
    }

    internal void Write(Class889 w)
    {
      w.vmethod_11(this.uint_0);
      w.vmethod_11(this.uint_1);
    }

    public void Dump(DumpWriter w)
    {
      w.WriteField("dataSize", this.uint_0);
      w.WriteField("unknownFlags", this.uint_1);
    }
  }
}
