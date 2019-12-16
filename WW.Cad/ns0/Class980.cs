// Decompiled with JetBrains decompiler
// Type: ns0.Class980
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;

namespace ns0
{
  internal class Class980
  {
    private string string_0;
    private List<Struct18> list_0;

    public Class980(string name, List<Struct18> valueGroups)
    {
      this.string_0 = name;
      this.list_0 = valueGroups;
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

    public List<Struct18> ValueGroups
    {
      get
      {
        return this.list_0;
      }
      set
      {
        this.list_0 = value;
      }
    }
  }
}
