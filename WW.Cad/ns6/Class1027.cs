// Decompiled with JetBrains decompiler
// Type: ns6.Class1027
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System;
using System.Collections;
using System.Collections.Generic;
using WW.Cad.IO;
using WW.Diagnostics;

namespace ns6
{
  internal class Class1027 : IDumpable
  {
    private readonly List<Class496> list_0 = new List<Class496>();
    private uint uint_0;

    public uint SchemaIndex
    {
      get
      {
        return this.uint_0;
      }
      set
      {
        this.uint_0 = value;
      }
    }

    public List<Class496> Columns
    {
      get
      {
        return this.list_0;
      }
    }

    public void Read(DxfReader r)
    {
      if (r.CurrentGroup.Code != 0)
        throw new Exception("Unexpected group code " + (object) r.CurrentGroup.Code + ".");
      if (r.CurrentGroup.Value as string != "ACDSRECORD")
        throw new Exception("Unexpected group value " + r.CurrentGroup.Value + ".");
      r.method_85();
      while (r.CurrentGroup.Code != 0 && (r.CurrentGroup.Code != 101 && r.CurrentGroup != Struct18.struct18_0))
      {
        switch (r.CurrentGroup.Code)
        {
          case 2:
            Class496 class496 = new Class496();
            class496.Read(r);
            this.list_0.Add(class496);
            continue;
          case 90:
            this.uint_0 = (uint) (int) r.CurrentGroup.Value;
            r.method_85();
            continue;
          default:
            r.method_85();
            continue;
        }
      }
    }

    public void Write(DxfWriter w)
    {
      w.Write(0, (object) "ACDSRECORD");
      w.Write(90, (object) (int) this.uint_0);
      foreach (Class495 class495 in this.list_0)
        class495.Write(w);
    }

    public void Dump(DumpWriter w)
    {
      w.WriteField("schemaIndex", this.uint_0);
      w.WriteField("columns", (ICollection) this.list_0);
    }
  }
}
