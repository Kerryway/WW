// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfLinkedTableData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Cad.IO;
using WW.Cad.Model.Entities;
using WW.Collections.Generic;

namespace WW.Cad.Model.Objects
{
  public class DxfLinkedTableData : DxfLinkedData
  {
    private DxfTableRowCollection dxfTableRowCollection_0 = new DxfTableRowCollection();
    private DxfTableColumnCollection dxfTableColumnCollection_0 = new DxfTableColumnCollection();
    private bool bool_0;

    public DxfLinkedTableData()
    {
      this.Rows.Added += new ItemEventHandler<DxfTableRow>(this.method_17);
      this.Rows.Set += new ItemSetEventHandler<DxfTableRow>(this.method_16);
      this.Columns.Added += new ItemEventHandler<DxfTableColumn>(this.method_13);
      this.Columns.Removed += new ItemEventHandler<DxfTableColumn>(this.method_12);
      this.Columns.Set += new ItemSetEventHandler<DxfTableColumn>(this.method_15);
    }

    public DxfTableRowCollection Rows
    {
      get
      {
        return this.dxfTableRowCollection_0;
      }
    }

    public int RowCount
    {
      get
      {
        return this.dxfTableRowCollection_0.Count;
      }
      set
      {
        this.method_10(value);
      }
    }

    public DxfTableColumnCollection Columns
    {
      get
      {
        return this.dxfTableColumnCollection_0;
      }
    }

    public int ColumnCount
    {
      get
      {
        return this.dxfTableColumnCollection_0.Count;
      }
      set
      {
        this.method_11(value);
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfLinkedTableData dxfLinkedTableData = (DxfLinkedTableData) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfLinkedTableData == null)
      {
        dxfLinkedTableData = new DxfLinkedTableData();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfLinkedTableData);
        dxfLinkedTableData.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfLinkedTableData;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfLinkedTableData dxfLinkedTableData = (DxfLinkedTableData) from;
      this.bool_0 = true;
      foreach (DxfTableRow dxfTableRow in (ActiveList<DxfTableRow>) dxfLinkedTableData.dxfTableRowCollection_0)
        this.dxfTableRowCollection_0.Add(dxfTableRow.Clone(cloneContext));
      foreach (DxfTableColumn dxfTableColumn in (ActiveList<DxfTableColumn>) dxfLinkedTableData.dxfTableColumnCollection_0)
        this.dxfTableColumnCollection_0.Add(dxfTableColumn);
      this.bool_0 = false;
    }

    public override string AcClass
    {
      get
      {
        return "AcDbLinkedTableData";
      }
    }

    public override string ObjectType
    {
      get
      {
        return "";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal void method_8(DxfTableRow row)
    {
      this.bool_0 = true;
      this.dxfTableRowCollection_0.Add(row);
      this.bool_0 = false;
    }

    internal void method_9(DxfTableColumn column)
    {
      this.bool_0 = true;
      this.dxfTableColumnCollection_0.Add(column);
      this.bool_0 = false;
    }

    private void method_10(int value)
    {
      int count = this.Columns.Count;
      if (value > this.Rows.Count)
      {
        this.bool_0 = true;
        int num = value - this.Rows.Count;
        for (int index1 = 0; index1 < num; ++index1)
        {
          DxfTableRow dxfTableRow = new DxfTableRow();
          for (int index2 = 0; index2 < count; ++index2)
            dxfTableRow.Cells.Add(new DxfTableCell());
          this.Rows.Add(dxfTableRow);
        }
        this.bool_0 = false;
      }
      else
      {
        if (value >= this.Rows.Count)
          return;
        this.bool_0 = true;
        int num = this.Rows.Count - value;
        for (int index = 0; index < num; ++index)
          this.Rows.RemoveAt(value);
        this.bool_0 = false;
      }
    }

    private void method_11(int value)
    {
      int count = this.Columns.Count;
      if (value > count)
      {
        this.bool_0 = true;
        int num1 = value - this.Columns.Count;
        for (int index = 0; index < num1; ++index)
          this.Columns.Add(new DxfTableColumn());
        int num2 = 0;
        foreach (DxfTableRow row in (ActiveList<DxfTableRow>) this.Rows)
        {
          for (int index = 0; index < num1; ++index)
            row.Cells.Add(new DxfTableCell());
          ++num2;
        }
        this.bool_0 = false;
      }
      else
      {
        if (value >= this.Columns.Count)
          return;
        this.bool_0 = true;
        int num = this.Columns.Count - value;
        int index1 = count - 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          this.Columns.RemoveAt(index1);
          --index1;
        }
        foreach (DxfTableRow row in (ActiveList<DxfTableRow>) this.Rows)
        {
          int index2 = count - 1;
          for (int index3 = 0; index3 < num; ++index3)
          {
            row.Cells.RemoveAt(index2);
            --index2;
          }
        }
        this.bool_0 = false;
      }
    }

    private void method_12(object sender, int index, DxfTableColumn item)
    {
      if (this.bool_0)
        return;
      foreach (DxfTableRow row in (ActiveList<DxfTableRow>) this.Rows)
        row.Cells.RemoveAt(index);
    }

    private void method_13(object sender, int index, DxfTableColumn item)
    {
      this.method_14(index);
    }

    private void method_14(int index)
    {
      if (this.bool_0)
        return;
      foreach (DxfTableRow row in (ActiveList<DxfTableRow>) this.Rows)
        row.Cells.Insert(index, new DxfTableCell());
    }

    private void method_15(
      object sender,
      int index,
      DxfTableColumn oldItem,
      DxfTableColumn newItem)
    {
      this.method_14(index);
    }

    private void method_16(object sender, int index, DxfTableRow oldItem, DxfTableRow newItem)
    {
      this.InitRowCells(index, newItem);
    }

    private void method_17(object sender, int index, DxfTableRow item)
    {
      this.InitRowCells(index, item);
    }

    protected virtual void InitRowCells(int index, DxfTableRow item)
    {
      if (this.bool_0)
        return;
      int count = this.Columns.Count;
      if (item.Cells.Count < count)
      {
        int num = count - item.Cells.Count;
        for (int index1 = 0; index1 < num; ++index1)
          item.Cells.Add(new DxfTableCell());
      }
      else if (item.Cells.Count > count)
        throw new ArgumentException("More cells in row than ColumnCount.");
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.Write(100, (object) "AcDbLinkedTableData");
      w.Write(90, (object) this.dxfTableColumnCollection_0.Count);
      foreach (DxfTableColumn dxfTableColumn in (ActiveList<DxfTableColumn>) this.dxfTableColumnCollection_0)
        dxfTableColumn.Write(w);
      w.Write(91, (object) this.dxfTableRowCollection_0.Count);
      foreach (DxfTableRow dxfTableRow in (ActiveList<DxfTableRow>) this.dxfTableRowCollection_0)
        dxfTableRow.Write(w);
    }
  }
}
