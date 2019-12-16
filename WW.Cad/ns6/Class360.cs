// Decompiled with JetBrains decompiler
// Type: ns6.Class360
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System;
using WW.Cad.IO;
using WW.Diagnostics;

namespace ns6
{
  internal class Class360 : IDumpable
  {
    private int int_0 = -1;
    private string string_0 = string.Empty;
    private int int_1;
    private Class496 class496_0;

    public int Id
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

    public string IdName
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

    public int Index
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

    public Class496 Item
    {
      get
      {
        return this.class496_0;
      }
      set
      {
        this.class496_0 = value;
      }
    }

    public void Read(DxfReader r)
    {
      if (r.CurrentGroup.Code != 101 || (string) r.CurrentGroup.Value != "ACDSRECORD")
        throw new Exception();
      r.method_85();
      while (r.CurrentGroup.Code != 0 && (r.CurrentGroup.Code != 2 && (r.CurrentGroup.Code != 101 && r.CurrentGroup != Struct18.struct18_0)))
      {
        switch (r.CurrentGroup.Code)
        {
          case 1:
            this.string_0 = (string) r.CurrentGroup.Value;
            break;
          case 95:
            this.int_0 = (int) r.CurrentGroup.Value;
            break;
        }
        r.method_85();
      }
    }

    public void Write(DxfWriter w)
    {
      w.Write(101, (object) "ACDSRECORD");
      if (this.int_0 != -1)
        w.Write(95, (object) this.int_0);
      else
        w.Write(1, (object) this.string_0);
      w.Write(90, (object) this.int_1);
      this.class496_0.Write(w);
    }

    public override string ToString()
    {
      return string.Format("Id: {0}, name: {1}", (object) this.int_0, (object) this.string_0);
    }

    public void Dump(DumpWriter w)
    {
      w.WriteField("id", this.int_0);
      w.WriteField("idName", this.string_0);
      w.WriteField("index", this.int_1);
      w.WriteField("item", (IDumpable) this.class496_0);
    }
  }
}
