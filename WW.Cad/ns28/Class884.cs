// Decompiled with JetBrains decompiler
// Type: ns28.Class884
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace ns28
{
  internal class Class884
  {
    private int int_0;
    private int int_1;
    private int int_2;

    public Class884()
    {
    }

    public Class884(int index, int position, int size)
    {
      this.int_0 = index;
      this.int_1 = position;
      this.int_2 = size;
    }

    public int Index
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

    public int Position
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public int Size
    {
      get
      {
        return this.int_2;
      }
      set
      {
        this.int_2 = value;
      }
    }

    public bool method_0(int address)
    {
      if (address >= this.int_1)
        return address < this.int_1 + this.int_2;
      return false;
    }

    public override string ToString()
    {
      return string.Format("Index: {0}, position: {1}, size: {2}", (object) this.int_0, (object) this.int_1, (object) this.int_2);
    }
  }
}
