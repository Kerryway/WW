// Decompiled with JetBrains decompiler
// Type: ns3.Class568
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model.Entities;

namespace ns3
{
  internal class Class568 : Interface10
  {
    private readonly DxfTableCellContent dxfTableCellContent_0;
    private ulong ulong_0;
    private List<Class331> list_0;

    public Class568(DxfTableCellContent content)
    {
      this.dxfTableCellContent_0 = content;
    }

    public ulong ValueObjectHandle
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

    public void method_0(Class331 attributeBuilder)
    {
      if (this.list_0 == null)
        this.list_0 = new List<Class331>();
      this.list_0.Add(attributeBuilder);
    }

    public void ResolveReferences(Class374 modelBuilder)
    {
      if (this.ulong_0 != 0UL)
        this.dxfTableCellContent_0.ValueObject = modelBuilder.method_3(this.ulong_0);
      if (this.list_0 == null)
        return;
      foreach (Class331 class331 in this.list_0)
        class331.ResolveReferences(modelBuilder);
    }
  }
}
