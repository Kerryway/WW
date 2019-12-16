// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfDataColumn
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using ns3;
using System;
using System.Collections.Generic;
using WW.Cad.IO;

namespace WW.Cad.Model.Objects
{
  public class DxfDataColumn
  {
    private List<DxfDataCell> list_0 = new List<DxfDataCell>();
    private string string_0 = string.Empty;
    private DataCellType dataCellType_0;

    public DxfDataColumn()
    {
    }

    public DxfDataColumn(DataCellType cellType)
    {
      this.dataCellType_0 = cellType;
    }

    public DxfDataColumn(DataCellType cellType, string name)
    {
      this.dataCellType_0 = cellType;
      this.Name = name;
    }

    public DataCellType CellType
    {
      get
      {
        return this.dataCellType_0;
      }
      set
      {
        this.dataCellType_0 = value;
      }
    }

    public IList<DxfDataCell> Cells
    {
      get
      {
        return (IList<DxfDataCell>) this.list_0;
      }
    }

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

    public DxfDataColumn Clone(CloneContext context)
    {
      DxfDataColumn dxfDataColumn = new DxfDataColumn();
      dxfDataColumn.dataCellType_0 = this.dataCellType_0;
      foreach (DxfDataCell dxfDataCell in this.list_0)
        dxfDataColumn.list_0.Add(dxfDataCell.Clone(context));
      dxfDataColumn.string_0 = this.string_0;
      return dxfDataColumn;
    }

    public override string ToString()
    {
      return this.string_0;
    }

    internal void Read(Interface30 r, DxfDataTable.Class273 tableBuilder, int columnIndex)
    {
      this.dataCellType_0 = (DataCellType) r.imethod_11();
      this.string_0 = r.ReadString();
      foreach (DxfDataCell dxfDataCell in this.list_0)
      {
        switch (this.dataCellType_0)
        {
          case DataCellType.Unknown:
            dxfDataCell.Value = (DxfDataCellValue) DxfDataCellValue.Unknown.Instance;
            continue;
          case DataCellType.Int32:
            dxfDataCell.Value = (DxfDataCellValue) new DxfDataCellValue.Int32(r.imethod_11());
            continue;
          case DataCellType.Double:
            dxfDataCell.Value = (DxfDataCellValue) new DxfDataCellValue.Double(r.imethod_8());
            continue;
          case DataCellType.String:
            dxfDataCell.Value = (DxfDataCellValue) new DxfDataCellValue.String(r.ReadString());
            continue;
          case DataCellType.Point3D:
            dxfDataCell.Value = (DxfDataCellValue) new DxfDataCellValue.Point3D(r.imethod_39());
            continue;
          case DataCellType.ObjectId:
            DxfDataCellValue.ObjectIdBase o1 = (DxfDataCellValue.ObjectIdBase) new DxfDataCellValue.ObjectId();
            tableBuilder.Add((Interface10) new DxfDataCellValue.ObjectIdBase.Class554(o1, r.imethod_32(true)));
            dxfDataCell.Value = (DxfDataCellValue) o1;
            continue;
          case DataCellType.HardOwnerId:
            DxfDataCellValue.OwnerIdBase o2 = (DxfDataCellValue.OwnerIdBase) new DxfDataCellValue.HardOwnerId();
            tableBuilder.Add((Interface10) new DxfDataCellValue.OwnerIdBase.Class555(o2, r.imethod_32(true)));
            dxfDataCell.Value = (DxfDataCellValue) o2;
            continue;
          case DataCellType.SoftOwnerId:
            DxfDataCellValue.OwnerIdBase o3 = (DxfDataCellValue.OwnerIdBase) new DxfDataCellValue.SoftOwnerId();
            tableBuilder.Add((Interface10) new DxfDataCellValue.OwnerIdBase.Class555(o3, r.imethod_32(true)));
            dxfDataCell.Value = (DxfDataCellValue) o3;
            continue;
          case DataCellType.HardPointerId:
            DxfDataCellValue.ObjectIdBase o4 = (DxfDataCellValue.ObjectIdBase) new DxfDataCellValue.HardPointerId();
            tableBuilder.Add((Interface10) new DxfDataCellValue.ObjectIdBase.Class554(o4, r.imethod_32(true)));
            dxfDataCell.Value = (DxfDataCellValue) o4;
            continue;
          case DataCellType.SoftPointerId:
            DxfDataCellValue.ObjectIdBase o5 = (DxfDataCellValue.ObjectIdBase) new DxfDataCellValue.SoftPointerId();
            tableBuilder.Add((Interface10) new DxfDataCellValue.ObjectIdBase.Class554(o5, r.imethod_32(true)));
            dxfDataCell.Value = (DxfDataCellValue) o5;
            continue;
          case DataCellType.Bool:
            dxfDataCell.Value = (DxfDataCellValue) new DxfDataCellValue.Bool(r.imethod_6());
            continue;
          case DataCellType.Vector3D:
            dxfDataCell.Value = (DxfDataCellValue) new DxfDataCellValue.Vector3D(r.imethod_51());
            continue;
          default:
            throw new Exception("DataCellType " + (object) this.dataCellType_0 + " is not supported.");
        }
      }
    }

    internal void Write(Class432 ow, Interface29 w, DxfDataTable table, int columnIndex)
    {
      w.imethod_33((int) this.dataCellType_0);
      w.imethod_4(this.string_0);
      this.method_0(table, columnIndex);
      DxfDataCellValue.Class556 class556 = new DxfDataCellValue.Class556(ow, w);
      for (int rowIndex = 0; rowIndex < table.RowCount; ++rowIndex)
      {
        DxfDataCell cell = this.list_0[rowIndex];
        this.method_1(columnIndex, rowIndex, cell);
        cell.Value.Accept((IDataCellValueVisitor) class556);
      }
    }

    internal void Write(DxfWriter w, DxfDataTable table, int columnIndex)
    {
      w.Write(92, (object) (int) this.dataCellType_0);
      w.Write(2, (object) this.string_0);
      this.method_0(table, columnIndex);
      DxfDataCellValue.Class557 class557 = new DxfDataCellValue.Class557(w);
      for (int rowIndex = 0; rowIndex < table.RowCount; ++rowIndex)
      {
        DxfDataCell cell = this.list_0[rowIndex];
        this.method_1(columnIndex, rowIndex, cell);
        cell.Value.Accept((IDataCellValueVisitor) class557);
      }
    }

    private void method_0(DxfDataTable table, int columnIndex)
    {
      if (this.list_0.Count != table.RowCount)
        throw new Exception("Number of cells " + (object) this.list_0.Count + " at column " + (object) columnIndex + " is not equal to the row count " + (object) table.RowCount + ".");
    }

    private void method_1(int columnIndex, int rowIndex, DxfDataCell cell)
    {
      if (cell.Value == null)
        throw new Exception("Cell at index " + (object) rowIndex + " of column at index " + (object) columnIndex + " has no value.");
      if (cell.Value.CellType != this.dataCellType_0)
        throw new Exception("Cell at index " + (object) rowIndex + " of column at index " + (object) columnIndex + " has a different cell type " + (object) cell.Value.CellType + " than the column cell type " + (object) this.dataCellType_0 + ".");
    }
  }
}
