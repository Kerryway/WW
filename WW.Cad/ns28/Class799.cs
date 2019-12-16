// Decompiled with JetBrains decompiler
// Type: ns28.Class799
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns3;

namespace ns28
{
  internal class Class799
  {
    private ulong ulong_0;
    private long long_0;
    private Class450 class450_0;

    public Class799(ulong handle, long streamPosition)
    {
      this.ulong_0 = handle;
      this.long_0 = streamPosition;
    }

    public ulong Handle
    {
      get
      {
        return this.ulong_0;
      }
    }

    public long StreamPosition
    {
      get
      {
        return this.long_0;
      }
    }

    public Class450 HandledObjectInfo
    {
      get
      {
        return this.class450_0;
      }
      set
      {
        this.class450_0 = value;
      }
    }

    public override string ToString()
    {
      return this.ulong_0.ToString() + ", " + this.long_0.ToString();
    }
  }
}
