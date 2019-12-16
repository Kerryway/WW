// Decompiled with JetBrains decompiler
// Type: ns3.Class296
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model.Entities;

namespace ns3
{
  internal class Class296 : Class294
  {
    private List<Interface10> list_2 = new List<Interface10>();
    private DxfTable dxfTable_0;
    private ulong ulong_10;

    public Class296(DxfTable table)
      : base((DxfInsertBase) table)
    {
      this.dxfTable_0 = table;
    }

    public ulong Unknown1Handle
    {
      get
      {
        return this.ulong_10;
      }
      set
      {
        this.ulong_10 = value;
      }
    }

    public List<Interface10> PrerequisiteBuilders
    {
      get
      {
        return this.list_2;
      }
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      foreach (Interface10 nterface10 in this.list_2)
        nterface10.ResolveReferences(modelBuilder);
      if (this.ulong_10 == 0UL)
        return;
      this.dxfTable_0.Unknown1 = modelBuilder.method_3(this.ulong_10);
    }
  }
}
