// Decompiled with JetBrains decompiler
// Type: ns39.Class614
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace ns39
{
  internal abstract class Class614
  {
    private int int_0;
    private long long_0;
    private long long_1;
    private bool bool_0;

    public int PageNumber
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public long StreamOffset
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
  }
}
