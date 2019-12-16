// Decompiled with JetBrains decompiler
// Type: ns3.Class1050
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class1050
  {
    private DxfTableRow dxfTableRow_0;
    private int int_0;
    private int int_1;

    public Class1050(DxfTableRow row)
    {
      this.dxfTableRow_0 = row;
    }

    public DxfTableCell method_0()
    {
      return this.dxfTableRow_0.Cells[this.int_1++];
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

    public void ResolveReferences(DxfTableContent table)
    {
      if (this.int_0 == 0 || table.TableStyle == null)
        return;
      this.dxfTableRow_0.CellStyle = table.TableStyle.CellStyles.GetById(this.int_0);
    }
  }
}
