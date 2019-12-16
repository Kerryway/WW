// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfDataTable
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using ns3;
using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Collections.Generic;

namespace WW.Cad.Model.Objects
{
  public class DxfDataTable : DxfObject
  {
    private DxfDataColumnCollection dxfDataColumnCollection_0 = new DxfDataColumnCollection();
    private short short_0 = 2;
    private string string_0 = string.Empty;
    private int int_0;
    private bool bool_0;

    public DxfDataTable()
    {
      this.dxfDataColumnCollection_0.Added += new ItemEventHandler<DxfDataColumn>(this.method_10);
      this.dxfDataColumnCollection_0.Set += new ItemSetEventHandler<DxfDataColumn>(this.method_11);
    }

    public DxfDataColumnCollection Columns
    {
      get
      {
        return this.dxfDataColumnCollection_0;
      }
    }

    public int ColumnCount
    {
      get
      {
        return this.dxfDataColumnCollection_0.Count;
      }
      set
      {
        this.method_9(value);
      }
    }

    public int RowCount
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.method_8(value);
      }
    }

    public short Version
    {
      get
      {
        return this.short_0;
      }
      set
      {
        this.short_0 = value;
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

    public override string ObjectType
    {
      get
      {
        return "DATATABLE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbDataTable";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfDataTable dxfDataTable = (DxfDataTable) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfDataTable == null)
      {
        dxfDataTable = new DxfDataTable();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfDataTable);
        dxfDataTable.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfDataTable;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      this.bool_0 = true;
      DxfDataTable dxfDataTable = (DxfDataTable) from;
      this.dxfDataColumnCollection_0.Clear();
      foreach (DxfDataColumn dxfDataColumn1 in (ActiveList<DxfDataColumn>) dxfDataTable.dxfDataColumnCollection_0)
      {
        DxfDataColumn dxfDataColumn2 = dxfDataColumn1.Clone(cloneContext);
        this.dxfDataColumnCollection_0.Add(dxfDataColumn2);
        if (dxfDataColumn2.CellType == DataCellType.HardOwnerId || dxfDataColumn2.CellType == DataCellType.SoftOwnerId)
        {
          foreach (DxfDataCell cell in (IEnumerable<DxfDataCell>) dxfDataColumn2.Cells)
            (cell.Value as DxfDataCellValue.OwnerIdBase)?.Value.vmethod_2((IDxfHandledObject) this);
        }
      }
      this.int_0 = dxfDataTable.int_0;
      this.short_0 = dxfDataTable.short_0;
      this.string_0 = dxfDataTable.string_0;
      this.bool_0 = false;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf15OrHigher;
    }

    protected internal override void ExecuteDeepHelper(
      WW.Cad.Model.Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      foreach (DxfDataColumn dxfDataColumn in (ActiveList<DxfDataColumn>) this.dxfDataColumnCollection_0)
      {
        if (dxfDataColumn.CellType == DataCellType.HardOwnerId || dxfDataColumn.CellType == DataCellType.SoftOwnerId)
        {
          foreach (DxfDataCell cell in (IEnumerable<DxfDataCell>) dxfDataColumn.Cells)
          {
            DxfDataCellValue.OwnerIdBase ownerIdBase = cell.Value as DxfDataCellValue.OwnerIdBase;
            if (ownerIdBase != null)
              action((DxfHandledObject) ownerIdBase.Value);
          }
        }
      }
    }

    internal static DxfClass smethod_2(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "DATATABLE");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1015;
        dxfClass.MaintenanceVersion = (short) 20;
        dxfClass.ProxyFlags = ProxyFlags.None;
        dxfClass.CPlusPlusClassName = "AcDbDataTable";
        dxfClass.DxfName = "DATATABLE";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    private void method_8(int value)
    {
      int count = this.Columns.Count;
      if (value > this.int_0)
      {
        this.bool_0 = true;
        int num = value - this.int_0;
        foreach (DxfDataColumn dxfDataColumn in (ActiveList<DxfDataColumn>) this.dxfDataColumnCollection_0)
        {
          for (int index = 0; index < num; ++index)
            dxfDataColumn.Cells.Add(new DxfDataCell());
        }
        this.bool_0 = false;
      }
      else if (value < this.int_0)
      {
        this.bool_0 = true;
        int num = this.int_0 - value;
        foreach (DxfDataColumn dxfDataColumn in (ActiveList<DxfDataColumn>) this.dxfDataColumnCollection_0)
        {
          int index1 = this.int_0 - 1;
          for (int index2 = 0; index2 < num; ++index2)
          {
            dxfDataColumn.Cells.RemoveAt(index1);
            --index1;
          }
        }
        this.bool_0 = false;
      }
      this.int_0 = value;
    }

    private void method_9(int value)
    {
      int count = this.Columns.Count;
      if (value > count)
      {
        this.bool_0 = true;
        int num = value - this.Columns.Count;
        for (int index1 = 0; index1 < num; ++index1)
        {
          DxfDataColumn dxfDataColumn = new DxfDataColumn();
          this.Columns.Add(dxfDataColumn);
          for (int index2 = 0; index2 < this.int_0; ++index2)
            dxfDataColumn.Cells.Add(new DxfDataCell());
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
        this.bool_0 = false;
      }
    }

    private void method_10(object sender, int index, DxfDataColumn item)
    {
      this.method_12(item);
    }

    private void method_11(object sender, int index, DxfDataColumn oldItem, DxfDataColumn newItem)
    {
      this.method_12(newItem);
    }

    private void method_12(DxfDataColumn column)
    {
      if (this.bool_0)
        return;
      if (this.int_0 > column.Cells.Count)
      {
        int num = this.int_0 - column.Cells.Count;
        for (int index = 0; index < num; ++index)
          column.Cells.Add(new DxfDataCell());
      }
      else
      {
        if (this.int_0 >= column.Cells.Count)
          return;
        int num = column.Cells.Count - this.int_0;
        int index1 = column.Cells.Count - 1;
        for (int index2 = 0; index2 < num; ++index2)
        {
          column.Cells.RemoveAt(index1);
          --index1;
        }
      }
    }

    internal override Class259 vmethod_9(FileFormat fileFormat)
    {
      return (Class259) new DxfDataTable.Class273(this);
    }

    internal override void Read(Class434 or, Class259 builder)
    {
      base.Read(or, builder);
      Interface30 objectBitStream = or.ObjectBitStream;
      this.short_0 = objectBitStream.imethod_14();
      this.ColumnCount = objectBitStream.imethod_11();
      this.RowCount = objectBitStream.imethod_11();
      this.string_0 = objectBitStream.ReadString();
      int num = 0;
      foreach (DxfDataColumn dxfDataColumn in (ActiveList<DxfDataColumn>) this.dxfDataColumnCollection_0)
        dxfDataColumn.Read(objectBitStream, (DxfDataTable.Class273) builder, num++);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_1.ClassNumber;
    }

    internal override void Write(Class432 ow)
    {
      base.Write(ow);
      Interface29 objectWriter = ow.ObjectWriter;
      objectWriter.imethod_32(this.short_0);
      objectWriter.imethod_33(this.dxfDataColumnCollection_0.Count);
      objectWriter.imethod_33(this.int_0);
      objectWriter.imethod_4(this.string_0);
      int num = 0;
      foreach (DxfDataColumn dxfDataColumn in (ActiveList<DxfDataColumn>) this.dxfDataColumnCollection_0)
        dxfDataColumn.Write(ow, objectWriter, this, num++);
      ow.method_82((DxfHandledObject) this);
    }

    internal override void Read(DxfReader r, Class259 builder)
    {
      base.Read(r, builder);
      while (r.CurrentGroup.Code != 0)
      {
        if (r.CurrentGroup.Code != 100)
          throw new DxfException("Expected subclass marker.");
        switch ((string) r.CurrentGroup.Value)
        {
          case "ACDBDATATABLE":
          case "AcDbDataTable":
            this.method_13(r, (DxfDataTable.Class273) builder);
            continue;
          default:
            r.method_85();
            continue;
        }
      }
    }

    private void method_13(DxfReader r, DxfDataTable.Class273 objectBuilder)
    {
      r.method_91("AcDbField");
      r.method_85();
      DxfDataColumn currentColumn = (DxfDataColumn) null;
      int columnIndex = -1;
      int rowIndex = -1;
      while (!r.method_92("AcDbField"))
      {
        if (!this.method_14(r, objectBuilder, ref currentColumn, ref columnIndex, ref rowIndex))
          r.method_85();
      }
    }

    private bool method_14(
      DxfReader r,
      DxfDataTable.Class273 objectBuilder,
      ref DxfDataColumn currentColumn,
      ref int columnIndex,
      ref int rowIndex)
    {
      switch (r.CurrentGroup.Code)
      {
        case 1:
          this.Name = (string) r.CurrentGroup.Value;
          break;
        case 2:
          currentColumn.Name = (string) r.CurrentGroup.Value;
          break;
        case 3:
          this.method_15(ref rowIndex);
          currentColumn.Cells[rowIndex].Value = (DxfDataCellValue) new DxfDataCellValue.String((string) r.CurrentGroup.Value);
          break;
        case 10:
          this.method_15(ref rowIndex);
          currentColumn.Cells[rowIndex].Value = (DxfDataCellValue) new DxfDataCellValue.Point3D((WW.Math.Point3D) r.CurrentGroup.Value);
          break;
        case 11:
          this.method_15(ref rowIndex);
          currentColumn.Cells[rowIndex].Value = (DxfDataCellValue) new DxfDataCellValue.Vector3D((WW.Math.Vector3D) ((WW.Math.Point3D) r.CurrentGroup.Value));
          break;
        case 40:
          this.method_15(ref rowIndex);
          currentColumn.Cells[rowIndex].Value = (DxfDataCellValue) new DxfDataCellValue.Double((double) r.CurrentGroup.Value);
          break;
        case 70:
          this.short_0 = (short) r.CurrentGroup.Value;
          break;
        case 71:
          this.method_15(ref rowIndex);
          currentColumn.Cells[rowIndex].Value = (DxfDataCellValue) new DxfDataCellValue.Bool((bool) r.CurrentGroup.Value);
          break;
        case 90:
          this.ColumnCount = (int) r.CurrentGroup.Value;
          break;
        case 91:
          this.RowCount = (int) r.CurrentGroup.Value;
          break;
        case 92:
          ++columnIndex;
          rowIndex = -1;
          if (columnIndex >= this.ColumnCount)
            throw new Exception("Column index " + (object) columnIndex + " too large for column count " + (object) this.ColumnCount + ".");
          currentColumn = this.dxfDataColumnCollection_0[columnIndex];
          currentColumn.CellType = (DataCellType) r.CurrentGroup.Value;
          break;
        case 93:
          this.method_15(ref rowIndex);
          currentColumn.Cells[rowIndex].Value = (DxfDataCellValue) new DxfDataCellValue.Int32((int) r.CurrentGroup.Value);
          break;
        case 330:
          this.method_15(ref rowIndex);
          DxfDataCellValue.ObjectIdBase o1 = (DxfDataCellValue.ObjectIdBase) new DxfDataCellValue.SoftPointerId();
          objectBuilder.Add((Interface10) new DxfDataCellValue.ObjectIdBase.Class554(o1, (ulong) r.CurrentGroup.Value));
          currentColumn.Cells[rowIndex].Value = (DxfDataCellValue) o1;
          break;
        case 331:
          this.method_15(ref rowIndex);
          DxfDataCellValue.ObjectIdBase o2 = (DxfDataCellValue.ObjectIdBase) new DxfDataCellValue.ObjectId();
          objectBuilder.Add((Interface10) new DxfDataCellValue.ObjectIdBase.Class554(o2, (ulong) r.CurrentGroup.Value));
          currentColumn.Cells[rowIndex].Value = (DxfDataCellValue) o2;
          break;
        case 340:
          this.method_15(ref rowIndex);
          DxfDataCellValue.ObjectIdBase o3 = (DxfDataCellValue.ObjectIdBase) new DxfDataCellValue.HardPointerId();
          objectBuilder.Add((Interface10) new DxfDataCellValue.ObjectIdBase.Class554(o3, (ulong) r.CurrentGroup.Value));
          currentColumn.Cells[rowIndex].Value = (DxfDataCellValue) o3;
          break;
        case 350:
          this.method_15(ref rowIndex);
          DxfDataCellValue.OwnerIdBase o4 = (DxfDataCellValue.OwnerIdBase) new DxfDataCellValue.SoftOwnerId();
          objectBuilder.Add((Interface10) new DxfDataCellValue.OwnerIdBase.Class555(o4, (ulong) r.CurrentGroup.Value));
          currentColumn.Cells[rowIndex].Value = (DxfDataCellValue) o4;
          break;
        case 360:
          this.method_15(ref rowIndex);
          DxfDataCellValue.OwnerIdBase o5 = (DxfDataCellValue.OwnerIdBase) new DxfDataCellValue.HardOwnerId();
          objectBuilder.Add((Interface10) new DxfDataCellValue.OwnerIdBase.Class555(o5, (ulong) r.CurrentGroup.Value));
          currentColumn.Cells[rowIndex].Value = (DxfDataCellValue) o5;
          break;
        default:
          return this.method_6(r, (Class259) objectBuilder);
      }
      r.method_85();
      return true;
    }

    private void method_15(ref int rowIndex)
    {
      ++rowIndex;
      if (rowIndex >= this.int_0)
        throw new Exception("Row index " + (object) rowIndex + " too large for row count " + (object) this.int_0 + ".");
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      if (w.Model.Header.AcadVersion <= DxfVersion.Dxf15)
        w.Write(100, (object) "ACDBDATATABLE");
      else
        w.Write(100, (object) "AcDbDataTable");
      w.Write(70, (object) this.short_0);
      w.Write(90, (object) this.ColumnCount);
      w.Write(91, (object) this.int_0);
      w.Write(1, (object) this.string_0);
      int num = 0;
      foreach (DxfDataColumn dxfDataColumn in (ActiveList<DxfDataColumn>) this.dxfDataColumnCollection_0)
        dxfDataColumn.Write(w, this, num++);
    }

    internal class Class273 : Class260
    {
      private LinkedList<Interface10> linkedList_1 = new LinkedList<Interface10>();

      public Class273(DxfDataTable obj)
        : base((DxfObject) obj)
      {
      }

      public void Add(Interface10 objectBuilder)
      {
        this.linkedList_1.AddLast(objectBuilder);
      }

      public override void ResolveReferences(Class374 modelBuilder)
      {
        base.ResolveReferences(modelBuilder);
        foreach (Interface10 nterface10 in this.linkedList_1)
          nterface10.ResolveReferences(modelBuilder);
      }
    }
  }
}
