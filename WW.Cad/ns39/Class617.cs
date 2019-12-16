// Decompiled with JetBrains decompiler
// Type: ns39.Class617
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;

namespace ns39
{
  internal class Class617
  {
    private int int_1 = 29696;
    private int int_2 = 2;
    private List<Class616> list_0 = new List<Class616>();
    private string string_0;
    private ulong ulong_0;
    private int int_0;
    private int int_3;
    private int int_4;

    public Class617()
    {
    }

    public Class617(string name)
    {
      this.string_0 = name;
    }

    public string Name
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

    public ulong SectionSize
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

    public int PageCount
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

    public int MaxDecompressedPageSize
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

    public int Compressed
    {
      get
      {
        return this.int_2;
      }
      set
      {
        if (value != 1 && value != 2)
          throw new Exception("Illegal section compression type.");
        this.int_2 = value;
      }
    }

    public int SectionId
    {
      get
      {
        return this.int_3;
      }
      set
      {
        this.int_3 = value;
      }
    }

    public int Encrypted
    {
      get
      {
        return this.int_4;
      }
      set
      {
        this.int_4 = value;
      }
    }

    public List<Class616> Pages
    {
      get
      {
        return this.list_0;
      }
    }
  }
}
