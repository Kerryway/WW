// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfFormattedTableData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns42;
using System.Collections.Generic;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects
{
  public class DxfFormattedTableData : DxfLinkedTableData
  {
    private DxfTableCellStyle dxfTableCellStyle_0 = new DxfTableCellStyle() { TableCellStyleType = Enum22.const_4 };
    private DxfTableCellRangeCollection dxfTableCellRangeCollection_0 = new DxfTableCellRangeCollection();

    public DxfTableCellStyle CellStyleOverrides
    {
      get
      {
        return this.dxfTableCellStyle_0;
      }
    }

    public DxfTableCellRangeCollection MergedCellRanges
    {
      get
      {
        return this.dxfTableCellRangeCollection_0;
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfFormattedTableData formattedTableData = (DxfFormattedTableData) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (formattedTableData == null)
      {
        formattedTableData = new DxfFormattedTableData();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) formattedTableData);
        formattedTableData.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) formattedTableData;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfFormattedTableData formattedTableData = (DxfFormattedTableData) from;
      this.dxfTableCellStyle_0 = (DxfTableCellStyle) cloneContext.Clone((IGraphCloneable) formattedTableData.dxfTableCellStyle_0);
      foreach (DxfTableCellRange dxfTableCellRange in (List<DxfTableCellRange>) formattedTableData.dxfTableCellRangeCollection_0)
        this.dxfTableCellRangeCollection_0.Add(dxfTableCellRange.Clone());
    }

    public override string AcClass
    {
      get
      {
        return "AcDbFormattedTableData";
      }
    }

    public override string ObjectType
    {
      get
      {
        return "";
      }
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.Write(100, (object) "AcDbFormattedTableData");
      w.Write(300, (object) "TABLEFORMAT");
      this.dxfTableCellStyle_0.method_22(w);
      w.Write(90, (object) this.dxfTableCellRangeCollection_0.Count);
      foreach (DxfTableCellRange dxfTableCellRange in (List<DxfTableCellRange>) this.dxfTableCellRangeCollection_0)
        dxfTableCellRange.Write(w);
    }
  }
}
