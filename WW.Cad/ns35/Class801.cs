// Decompiled with JetBrains decompiler
// Type: ns35.Class801
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace ns35
{
  internal class Class801
  {
    private long long_0;
    private long long_1;
    private long long_2;

    public Class801(long id, long position, long size)
    {
      this.long_0 = id;
      this.long_1 = position;
      this.long_2 = size;
    }

    public long Id
    {
      get
      {
        return this.long_0;
      }
      set
      {
        this.long_0 = value;
      }
    }

    public long Position
    {
      get
      {
        return this.long_1;
      }
      set
      {
        this.long_1 = value;
      }
    }

    public long Size
    {
      get
      {
        return this.long_2;
      }
      set
      {
        this.long_2 = value;
      }
    }

    public override string ToString()
    {
      return string.Format("Id: {0}, position: {1}, size: {2}", (object) this.long_0, (object) this.long_1, (object) this.long_2);
    }
  }
}
