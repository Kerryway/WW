// Decompiled with JetBrains decompiler
// Type: ns35.Class443
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace ns35
{
  internal class Class443 : Class441
  {
    private ulong ulong_1;
    private ulong ulong_2;
    private ulong ulong_3;
    private ulong ulong_4;
    private ulong ulong_5;
    private ulong ulong_6;

    public ulong PageSize
    {
      get
      {
        return this.ulong_1;
      }
      set
      {
        this.ulong_1 = value;
      }
    }

    public ulong DataOffset
    {
      get
      {
        return this.ulong_2;
      }
      set
      {
        this.ulong_2 = value;
      }
    }

    public ulong DecompressedSize
    {
      get
      {
        return this.ulong_3;
      }
      set
      {
        this.ulong_3 = value;
      }
    }

    public ulong CompressedSize
    {
      get
      {
        return this.ulong_4;
      }
      set
      {
        this.ulong_4 = value;
      }
    }

    public ulong CheckSum
    {
      get
      {
        return this.ulong_5;
      }
      set
      {
        this.ulong_5 = value;
      }
    }

    public ulong Crc
    {
      get
      {
        return this.ulong_6;
      }
      set
      {
        this.ulong_6 = value;
      }
    }

    public override object Clone()
    {
      Class443 class443 = new Class443();
      class443.CopyFrom(this);
      return (object) class443;
    }

    public void CopyFrom(Class443 from)
    {
      this.CopyFrom((Class441) from);
      this.ulong_1 = from.ulong_1;
      this.ulong_2 = from.ulong_2;
      this.ulong_3 = from.ulong_3;
      this.ulong_4 = from.ulong_4;
      this.ulong_5 = from.ulong_5;
      this.ulong_6 = from.ulong_6;
    }
  }
}
