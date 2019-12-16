// Decompiled with JetBrains decompiler
// Type: ns6.Class495
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System;
using WW.Cad.IO;
using WW.Diagnostics;

namespace ns6
{
  internal class Class495 : IDumpable
  {
    private string string_0 = string.Empty;
    private Enum26 enum26_0;
    private Struct18 struct18_0;

    public string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value ?? string.Empty;
      }
    }

    public Enum26 DataType
    {
      get
      {
        return this.enum26_0;
      }
      set
      {
        this.enum26_0 = value;
      }
    }

    internal Struct18 Data
    {
      get
      {
        return this.struct18_0;
      }
      set
      {
        this.struct18_0 = value;
      }
    }

    public void Read(DxfReader r)
    {
      if (r.CurrentGroup.Code != 2)
        throw new Exception("Expected group code 2.");
      if (!this.vmethod_0(r))
        r.method_85();
      while (r.CurrentGroup.Code != 0 && (r.CurrentGroup.Code != 2 && (r.CurrentGroup.Code != 101 && r.CurrentGroup != Struct18.struct18_0)))
      {
        if (!this.vmethod_0(r))
          r.method_85();
      }
    }

    protected virtual bool vmethod_0(DxfReader r)
    {
      Struct18 currentGroup = r.CurrentGroup;
      bool flag = true;
      switch (currentGroup.Code)
      {
        case 2:
          this.string_0 = (string) currentGroup.Value;
          break;
        case 280:
          this.enum26_0 = (Enum26) currentGroup.Value;
          break;
        default:
          flag = false;
          break;
      }
      if (flag)
        r.method_85();
      return flag;
    }

    public virtual void Write(DxfWriter w)
    {
      w.Write(2, (object) this.string_0);
      w.Write(280, (object) (byte) this.enum26_0);
    }

    public void Dump(DumpWriter w)
    {
      w.WriteField("name", this.string_0);
      w.WriteField("dataType", (byte) this.enum26_0);
      w.WriteField("data", (IDumpable) this.struct18_0);
    }
  }
}
