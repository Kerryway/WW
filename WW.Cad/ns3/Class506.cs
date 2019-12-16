// Decompiled with JetBrains decompiler
// Type: ns3.Class506
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class506
  {
    private List<Interface10> list_0 = new List<Interface10>();
    private DxfTableCell dxfTableCell_0;
    private ulong ulong_0;
    private int int_0;

    public Class506(DxfTableCell cell)
    {
      this.dxfTableCell_0 = cell;
    }

    public ulong UnknownObjectHandle
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

    public int CellStyleId
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

    public List<Interface10> ChildBuilders
    {
      get
      {
        return this.list_0;
      }
    }

    public void ResolveReferences(Class374 modelBuilder, DxfTableContent table)
    {
      if (this.ulong_0 != 0UL)
        this.dxfTableCell_0.UnknownObject = modelBuilder.method_3(this.ulong_0);
      if (this.int_0 != 0 && table.TableStyle != null)
        this.dxfTableCell_0.CellStyle = table.TableStyle.CellStyles.GetById(this.int_0);
      foreach (Interface10 nterface10 in this.list_0)
        nterface10.ResolveReferences(modelBuilder);
    }
  }
}
