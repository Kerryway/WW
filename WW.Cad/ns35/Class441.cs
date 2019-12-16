// Decompiled with JetBrains decompiler
// Type: ns35.Class441
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW;

namespace ns35
{
  internal abstract class Class441 : ICloneable
  {
    private long long_0;
    private ulong ulong_0;
    private long long_1;
    private bool bool_0;

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

    public ulong StreamOffset
    {
      get
      {
        return this.ulong_0;
      }
      set
      {
        this.ulong_0 = value;
      }
    }

    public long Length
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

    public bool ContainsOnlyZeroes
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public override string ToString()
    {
      return string.Format("Id: {0}, offset: {1}, length: {2}", (object) this.long_0, (object) this.ulong_0, (object) this.long_1);
    }

    public abstract object Clone();

    public void CopyFrom(Class441 from)
    {
      this.long_0 = from.long_0;
      this.ulong_0 = from.ulong_0;
      this.long_1 = from.long_1;
      this.bool_0 = from.bool_0;
    }
  }
}
