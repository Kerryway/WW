// Decompiled with JetBrains decompiler
// Type: ns35.Class504
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using System.IO;

namespace ns35
{
  internal class Class504
  {
    private string string_0 = string.Empty;
    private List<Class443> list_0 = new List<Class443>();
    private ulong ulong_0;
    private ulong ulong_1;
    private ulong ulong_2;
    private ulong ulong_3;
    private ulong ulong_4;
    private ulong ulong_5;
    private bool bool_0;
    private ulong ulong_6;
    private MemoryStream memoryStream_0;

    public Class504()
    {
    }

    public Class504(string name)
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

    public ulong DataSize
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

    public ulong MaxDecompressedPageSize
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

    public ulong Encrypted
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

    public ulong HashCode
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

    public ulong Unknown
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

    public ulong Encoding
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

    public bool Compressed
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

    public ulong PageCount
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

    public List<Class443> Pages
    {
      get
      {
        return this.list_0;
      }
    }

    public MemoryStream Stream
    {
      get
      {
        return this.memoryStream_0;
      }
      set
      {
        this.memoryStream_0 = value;
      }
    }

    public static Class504 smethod_0(string name)
    {
      return new Class504(name) { memoryStream_0 = new MemoryStream() };
    }

    public void method_0()
    {
      if (this.memoryStream_0 == null)
        throw new Exception("Stream was not set.");
      this.ulong_6 = (ulong) (this.memoryStream_0.Length + (long) this.ulong_1 - 1L) / this.ulong_1;
    }

    public override string ToString()
    {
      return this.string_0;
    }
  }
}
