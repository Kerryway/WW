// Decompiled with JetBrains decompiler
// Type: ns8.Class68
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace ns8
{
  internal class Class68
  {
    protected int int_0 = -4;
    protected string string_0;
    protected string string_1;

    public string OwnerPassword
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public string UserPassword
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public int Permissions
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

    public void method_0(bool enable)
    {
      this.method_4(4, enable);
    }

    public void method_1(bool enable)
    {
      this.method_4(8, enable);
    }

    public void method_2(bool enable)
    {
      this.method_4(16, enable);
    }

    public void method_3(bool enable)
    {
      this.method_4(32, enable);
    }

    private void method_4(int bitmask, bool on)
    {
      if (on)
        this.int_0 |= bitmask;
      else
        this.int_0 &= ~bitmask;
    }
  }
}
