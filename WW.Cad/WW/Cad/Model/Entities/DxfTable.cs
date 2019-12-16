// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTable
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns1;
using ns2;
using ns28;
using System;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.Surface;
using WW.Cad.IO;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;
using WW.Collections.Generic;
using WW.Math;

namespace WW.Cad.Model.Entities
{
  public class DxfTable : DxfInsertBase
  {
    private DxfObjectReference dxfObjectReference_8 = DxfObjectReference.Null;
    private WW.Math.Vector3D vector3D_1 = WW.Math.Vector3D.XAxis;
    private readonly DxfTableBreakData dxfTableBreakData_0 = new DxfTableBreakData();
    private DxfObjectReference dxfObjectReference_9 = DxfObjectReference.Null;
    private bool bool_2 = true;
    private short short_1 = 6;
    private Class551 class551_0;
    private byte byte_0;
    private int int_0;
    private int int_1;
    private bool bool_3;

    public DxfTable(DxfTableStyle tableStyle)
      : this()
    {
      if (tableStyle == null)
        throw new ArgumentNullException(nameof (tableStyle));
      this.Content = new DxfTableContent();
      this.TableStyle = tableStyle;
    }

    internal DxfTable()
    {
    }

    public WW.Math.Vector3D HorizontalDirection
    {
      get
      {
        return this.vector3D_1;
      }
      set
      {
        this.vector3D_1 = value;
      }
    }

    public DxfTableRowCollection Rows
    {
      get
      {
        return this.Content.Rows;
      }
    }

    public int RowCount
    {
      get
      {
        return this.Content.Rows.Count;
      }
      set
      {
        this.Content.RowCount = value;
      }
    }

    public DxfTableColumnCollection Columns
    {
      get
      {
        return this.Content.Columns;
      }
    }

    public int ColumnCount
    {
      get
      {
        return this.Content.Columns.Count;
      }
      set
      {
        this.Content.ColumnCount = value;
      }
    }

    public DxfTableStyle TableStyle
    {
      get
      {
        return this.Content.TableStyle;
      }
      set
      {
        this.Content.TableStyle = value;
      }
    }

    public DxfTableBreakData BreakData
    {
      get
      {
        return this.dxfTableBreakData_0;
      }
    }

    public DxfTableCellStyle CellStyleOverrides
    {
      get
      {
        return this.Content.CellStyleOverrides;
      }
    }

    public DxfTableCellRangeCollection MergedCellRanges
    {
      get
      {
        return this.Content.MergedCellRanges;
      }
    }

    public TableFlowDirection? FlowDirection
    {
      get
      {
        return this.Content.FlowDirection;
      }
      set
      {
        this.Content.FlowDirection = value;
      }
    }

    public void GenerateBlock()
    {
      DxfModel model = this.Model;
      if (model == null)
        throw new DxfException("Cannot generate table block when table is not part of a DxfModel.");
      if (this.Block == null)
      {
        this.Block = new DxfBlock();
        model.method_100(this.Block, (IList<DxfMessage>) null);
        model.AnonymousBlocks.Add(this.Block);
        this.Block.Flags = BlockFlags.Anonymous;
      }
      else
        this.Block.Entities.Clear();
      Matrix4D coordSystem = Transformation4D.GetCoordSystem(this.vector3D_1, new WW.Math.Vector3D(-this.vector3D_1.Y, this.vector3D_1.X, 0.0).GetUnit(), WW.Math.Vector3D.ZAxis);
      DxfTable.Class478 tableLayout = new DxfTable.Class478();
      this.method_23(tableLayout, coordSystem);
      this.method_26(model, tableLayout, coordSystem);
    }

    public DxfTableCellStyle GetCellStyle(int rowIndex, int columnIndex)
    {
      return this.Content.GetCellStyle(rowIndex, columnIndex);
    }

    public DxfTableCellContent GetCellContent(
      int rowIndex,
      int columnIndex,
      int cellContentIndex)
    {
      return this.Content.GetCellContent(rowIndex, columnIndex, cellContentIndex);
    }

    public Color? GetBackColor(int rowIndex, int columnIndex)
    {
      return this.Content.GetBackColor(rowIndex, columnIndex);
    }

    public double GetTextHeight(int rowIndex, int columnIndex, int cellContentIndex)
    {
      return this.Content.GetTextHeight(rowIndex, columnIndex, cellContentIndex);
    }

    internal double? GetTextHeightOverride(
      int rowIndex,
      int columnIndex,
      int cellContentIndex,
      DxfTableCellStyle baseCellStyle)
    {
      return this.Content.GetTextHeightOverride(rowIndex, columnIndex, cellContentIndex, baseCellStyle);
    }

    public DxfTextStyle GetTextStyle(
      int rowIndex,
      int columnIndex,
      int cellContentIndex)
    {
      return this.Content.GetTextStyle(rowIndex, columnIndex, cellContentIndex);
    }

    internal DxfTextStyle GetTextStyleOverride(
      int rowIndex,
      int columnIndex,
      int cellContentIndex,
      DxfTableCellStyle baseCellStyle)
    {
      return this.Content.GetTextStyleOverride(rowIndex, columnIndex, cellContentIndex, baseCellStyle);
    }

    public Color GetContentColor(int rowIndex, int columnIndex, int cellContentIndex)
    {
      return this.Content.GetContentColor(rowIndex, columnIndex, cellContentIndex);
    }

    internal Color? GetContentColorOverride(
      int rowIndex,
      int columnIndex,
      int cellContentIndex,
      DxfTableCellStyle baseCellStyle)
    {
      return this.Content.GetContentColorOverride(rowIndex, columnIndex, cellContentIndex, baseCellStyle);
    }

    public bool GetAutoScale(int rowIndex, int columnIndex, int cellContentIndex)
    {
      return this.Content.GetAutoScale(rowIndex, columnIndex, cellContentIndex);
    }

    public double GetBlockScale(int rowIndex, int columnIndex, int cellContentIndex)
    {
      return this.Content.GetBlockScale(rowIndex, columnIndex, cellContentIndex);
    }

    public CellAlignment GetCellAlignment(
      int rowIndex,
      int columnIndex,
      int cellContentIndex)
    {
      return this.Content.GetCellAlignment(rowIndex, columnIndex, cellContentIndex);
    }

    internal CellAlignment? GetCellAlignmentOverride(
      int rowIndex,
      int columnIndex,
      int cellContentIndex,
      DxfTableCellStyle baseCellStyle)
    {
      return this.Content.GetCellAlignmentOverride(rowIndex, columnIndex, cellContentIndex, baseCellStyle);
    }

    private DxfValueFormat GetValueFormat(
      int rowIndex,
      int columnIndex,
      int cellContentIndex)
    {
      return this.Content.GetValueFormat(rowIndex, columnIndex, cellContentIndex);
    }

    public double GetRotation(int rowIndex, int columnIndex, int cellContentIndex)
    {
      return this.Content.GetRotation(rowIndex, columnIndex, cellContentIndex);
    }

    internal double? GetRotationOverride(
      int rowIndex,
      int columnIndex,
      int cellContentIndex,
      DxfTableCellStyle baseCellStyle)
    {
      return this.Content.GetRotationOverride(rowIndex, columnIndex, cellContentIndex, baseCellStyle);
    }

    public override string EntityType
    {
      get
      {
        return "ACAD_TABLE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbTable";
      }
    }

    public override void TransformMe(TransformConfig config, Matrix4D matrix)
    {
      this.TransformMe(config, matrix, (CommandGroup) null);
    }

    public override void TransformMe(
      TransformConfig config,
      Matrix4D matrix,
      CommandGroup undoGroup)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfTable.Class482 class482 = new DxfTable.Class482();
      // ISSUE: reference to a compiler-generated field
      class482.dxfTable_0 = this;
      CommandGroup undoGroup1 = (CommandGroup) null;
      if (undoGroup != null)
      {
        undoGroup1 = new CommandGroup((object) this);
        undoGroup.UndoStack.Push((ICommand) undoGroup1);
      }
      // ISSUE: reference to a compiler-generated field
      class482.vector3D_0 = this.ZAxis;
      // ISSUE: reference to a compiler-generated field
      class482.point3D_0 = this.InsertionPoint;
      // ISSUE: reference to a compiler-generated field
      class482.vector3D_1 = this.vector3D_1;
      this.ZAxis = matrix.Transform(this.ZAxis).GetUnit();
      this.InsertionPoint = matrix.Transform(this.InsertionPoint);
      this.vector3D_1 = matrix.Transform(this.vector3D_1);
      double length = this.vector3D_1.GetLength();
      this.vector3D_1.Normalize();
      for (int index = this.RowCount - 1; index >= 0; --index)
        this.Rows[index].ScaleMe(length, undoGroup1);
      for (int index = this.ColumnCount - 1; index >= 0; --index)
        this.Columns[index].ScaleMe(length, undoGroup1);
      this.Content.CellStyleOverrides.ScaleMe(this.GetCellStyle(-1, -1), length, undoGroup1);
      undoGroup1?.UndoStack.Push((ICommand) new Command((object) this, (System.Action) (() => this.GenerateBlock()), Command.EmptyAction));
      if (undoGroup1 != null)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup1.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfTable.Class483()
        {
          class482_0 = class482,
          vector3D_0 = this.ZAxis,
          point3D_0 = this.InsertionPoint,
          vector3D_1 = this.vector3D_1
        }.method_0), new System.Action(class482.method_0)));
      }
      this.bool_3 = true;
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory graphicsFactory)
    {
      this.DrawInternal((DxfInsert.Interface46) new DxfInsert.Class1019((DxfEntity) this, context, graphicsFactory));
    }

    public override void DrawInternal(
      DrawContext.Wireframe context,
      IWireframeGraphicsFactory2 graphicsFactory)
    {
      this.DrawInternal((DxfInsert.Interface46) new DxfInsert.Class1020((DxfEntity) this, context, graphicsFactory));
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      ISurfaceGraphicsFactory graphicsFactory)
    {
      this.DrawInternal((DxfInsert.Interface46) new DxfInsert.Class1021((DxfEntity) this, context, graphicsFactory));
    }

    public override void DrawInternal(
      DrawContext.Surface context,
      Graphics graphics,
      IGraphicElementBlock parentGraphicElementBlock)
    {
      DrawContext.Surface childContext = context.CreateChildContext((DxfEntity) this, Matrix4D.Identity);
      GraphicElementInsert graphicElement;
      if (!graphics.GetGraphicElementInsert(parentGraphicElementBlock, (DxfEntity) this, childContext.Layer, childContext.ByBlockColor, childContext.ByBlockLineType, out graphicElement))
        return;
      this.DrawInternal((DxfInsert.Interface46) new DxfInsert.Class1022((DxfEntity) this, context, graphics, parentGraphicElementBlock, graphicElement));
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfTable dxfTable = (DxfTable) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfTable == null)
      {
        dxfTable = new DxfTable();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfTable);
        dxfTable.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfTable;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      DxfTable dxfTable = (DxfTable) from;
      base.CopyFrom((DxfHandledObject) dxfTable, cloneContext);
      this.vector3D_1 = dxfTable.vector3D_1;
      this.Content = dxfTable.Content == null ? (DxfTableContent) null : (DxfTableContent) dxfTable.Content.Clone(cloneContext);
      this.class551_0 = dxfTable.class551_0 == null ? (Class551) null : (Class551) dxfTable.class551_0.Clone(cloneContext);
      this.byte_0 = dxfTable.byte_0;
      this.Unknown1 = dxfTable.Unknown1 == null ? (DxfHandledObject) null : (DxfHandledObject) dxfTable.Unknown1.Clone(cloneContext);
      this.int_0 = dxfTable.int_0;
      this.bool_2 = dxfTable.bool_2;
      this.short_1 = dxfTable.short_1;
      this.int_1 = dxfTable.int_1;
    }

    public override void Accept(IEntityVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      if (this.Block == null)
        this.GenerateBlock();
      if (this.dxfTableBreakData_0.RowRanges.Count == 0)
        this.dxfTableBreakData_0.RowRanges.Add(new DxfTableBreakRowRange());
      if (this.dxfTableBreakData_0.RowRanges.Count == 1)
      {
        DxfTableBreakRowRange rowRange = this.dxfTableBreakData_0.RowRanges[0];
        rowRange.StartRowIndex = 0;
        rowRange.EndRowIndex = this.RowCount - 1;
      }
      if (this.class551_0 == null)
        this.class551_0 = new Class551();
      this.class551_0.method_0(this, this.Content);
      bool flag1 = false;
      if (this.ExtensionDictionary != null)
      {
        bool flag2 = true;
        for (int index = 0; index < this.ExtensionDictionary.Entries.Count; ++index)
        {
          IDictionaryEntry entry = this.ExtensionDictionary.Entries[index];
          if (entry.Name == "ACAD_XREC_ROUNDTRIP")
          {
            DxfXRecord dxfXrecord = entry.Value as DxfXRecord;
            if (dxfXrecord != null)
            {
              dxfXrecord.Values.Clear();
              if (!flag2)
                this.ExtensionDictionary.Entries.RemoveAt(index);
              flag2 = false;
            }
          }
        }
      }
      if (this.Model.Header.AcadVersion > DxfVersion.Dxf15 || context.FileFormat == FileFormat.Dwg)
      {
        if (context.FileFormat == FileFormat.Dxf && this.Model.Header.AcadVersion > DxfVersion.Dxf18 || context.FileFormat == FileFormat.Dwg && this.Model.Header.AcadVersion > DxfVersion.Dxf18)
        {
          flag1 = true;
          this.method_16();
        }
        if (context.Version < DxfVersion.Dxf21)
        {
          flag1 = true;
          this.method_17(context);
        }
      }
      if (flag1)
      {
        this.Model.method_30((DxfEntity) this);
      }
      else
      {
        if (this.ExtensionDictionary == null)
          return;
        this.ExtensionDictionary.Entries.RemoveAll("ACAD_XREC_ROUNDTRIP");
        if (this.ExtensionDictionary.Entries.Count != 0)
          return;
        this.ExtensionDictionary = (DxfDictionary) null;
      }
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      bool flag = base.Validate(model, messages);
      if (this.TableStyle == null)
      {
        flag = false;
        messages.Add(new DxfMessage(DxfStatus.TableMissesTableStyle, Severity.Error, "target", (object) this));
      }
      return flag;
    }

    protected internal override void ExecuteDeepHelper(
      WW.Cad.Model.Action action,
      Stack<DxfHandledObject> callerStack)
    {
      base.ExecuteDeepHelper(action, callerStack);
      if (this.Content == null)
        return;
      this.Content.vmethod_0(action, callerStack);
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return DxfTable.smethod_2(model);
    }

    internal static bool smethod_2(DxfModel model)
    {
      return model.Header.AcadVersion >= DxfVersion.Dxf15;
    }

    private void method_16()
    {
      DxfXRecord xdicObject = this.GetOrCreateXDicObject<DxfXRecord>("ACAD_XREC_ROUNDTRIP");
      xdicObject.Values.Add((short) 102, (object) "ACAD_ROUNDTRIP_2008_TABLE_ENTITY");
      xdicObject.Values.Add((short) 360, (object) this.Content);
      this.Content.vmethod_2((IDxfHandledObject) xdicObject);
      if (this.dxfTableBreakData_0.HasData)
      {
        xdicObject.Values.Add((short) 70, (object) (short) 1);
        xdicObject.Values.Add((short) 90, (object) this.dxfTableBreakData_0.Flags);
        xdicObject.Values.Add((short) 90, (object) (int) this.dxfTableBreakData_0.FlowDirection);
        xdicObject.Values.Add((short) 40, (object) this.dxfTableBreakData_0.BreakSpacing);
        xdicObject.Values.Add((short) 90, (object) this.dxfTableBreakData_0.UnknownFlags1);
        xdicObject.Values.Add((short) 90, (object) this.dxfTableBreakData_0.UnknownFlags2);
        xdicObject.Values.Add((short) 90, (object) this.dxfTableBreakData_0.BreakHeights.Count);
        foreach (DxfTableBreakHeight breakHeight in (IEnumerable<DxfTableBreakHeight>) this.dxfTableBreakData_0.BreakHeights)
        {
          xdicObject.Values.Add((short) 10, (object) breakHeight.Position);
          xdicObject.Values.Add((short) 40, (object) breakHeight.Height);
          xdicObject.Values.Add((short) 90, (object) breakHeight.Flags);
        }
        xdicObject.Values.Add((short) 90, (object) this.dxfTableBreakData_0.RowRanges.Count);
        foreach (DxfTableBreakRowRange rowRange in (IEnumerable<DxfTableBreakRowRange>) this.dxfTableBreakData_0.RowRanges)
        {
          xdicObject.Values.Add((short) 10, (object) rowRange.Position);
          xdicObject.Values.Add((short) 90, (object) rowRange.StartRowIndex);
          xdicObject.Values.Add((short) 90, (object) rowRange.EndRowIndex);
        }
        xdicObject.Values.Add((short) 90, (object) this.dxfTableBreakData_0.SubTables.Count);
        foreach (DxfTable subTable in (IEnumerable<DxfTable>) this.dxfTableBreakData_0.SubTables)
          xdicObject.Values.Add((short) 330, (object) subTable);
      }
      else
      {
        xdicObject.Values.Add((short) 70, (object) (short) 2);
        xdicObject.Values.Add((short) 90, (object) 1);
        xdicObject.Values.Add((short) 10, (object) WW.Math.Point3D.Zero);
        xdicObject.Values.Add((short) 90, (object) 0);
        xdicObject.Values.Add((short) 90, (object) (this.RowCount - 1));
      }
      xdicObject.Values.Add((short) 361, (object) null);
    }

    private void method_17(Class1070 context)
    {
      DxfXRecord xdicObject = this.GetOrCreateXDicObject<DxfXRecord>("ACAD_XREC_ROUNDTRIP");
      xdicObject.Values.Add((short) 102, (object) "ACAD_ROUNDTRIP_PRE2007_TABLE");
      xdicObject.Values.Add((short) 90, (object) this.RowCount);
      xdicObject.Values.Add((short) 91, (object) this.ColumnCount);
      if (this.class551_0.TitleRowCellStyle.CellFormat != null)
      {
        xdicObject.Values.Add((short) 92, (object) (int) this.class551_0.TitleRowCellStyle.CellFormat.DataType);
        xdicObject.Values.Add((short) 93, (object) (int) this.class551_0.TitleRowCellStyle.CellFormat.UnitType);
        xdicObject.Values.Add((short) 1, (object) this.class551_0.TitleRowCellStyle.CellFormat._FormatString);
      }
      if (this.class551_0.HeaderRowCellStyle.CellFormat != null)
      {
        xdicObject.Values.Add((short) 94, (object) (int) this.class551_0.HeaderRowCellStyle.CellFormat.DataType);
        xdicObject.Values.Add((short) 95, (object) (int) this.class551_0.HeaderRowCellStyle.CellFormat.UnitType);
        xdicObject.Values.Add((short) 2, (object) this.class551_0.HeaderRowCellStyle.CellFormat._FormatString);
      }
      if (this.class551_0.DataRowCellStyle.CellFormat != null)
      {
        xdicObject.Values.Add((short) 96, (object) (int) this.class551_0.DataRowCellStyle.CellFormat.DataType);
        xdicObject.Values.Add((short) 97, (object) (int) this.class551_0.DataRowCellStyle.CellFormat.UnitType);
        xdicObject.Values.Add((short) 3, (object) this.class551_0.DataRowCellStyle.CellFormat._FormatString);
      }
      xdicObject.Values.Add((short) 102, (object) "ACAD_ROUNDTRIP_PRE2007_TABLECELL");
      DxfDataTable dxfDataTable = new DxfDataTable();
      dxfDataTable.vmethod_2((IDxfHandledObject) xdicObject);
      xdicObject.Values.Add((short) 360, (object) dxfDataTable);
      DxfDataColumn dxfDataColumn1;
      dxfDataTable.Columns.Add(dxfDataColumn1 = new DxfDataColumn(DataCellType.Double));
      DxfDataColumn dxfDataColumn2;
      dxfDataTable.Columns.Add(dxfDataColumn2 = new DxfDataColumn(DataCellType.Int32));
      DxfDataColumn dxfDataColumn3;
      dxfDataTable.Columns.Add(dxfDataColumn3 = new DxfDataColumn(DataCellType.Int32));
      DxfDataColumn dxfDataColumn4;
      dxfDataTable.Columns.Add(dxfDataColumn4 = new DxfDataColumn(DataCellType.HardOwnerId));
      dxfDataTable.RowCount = this.RowCount * this.ColumnCount;
      int index = 0;
      int rowIndex = 0;
      foreach (Class430 row in (ActiveList<Class430>) this.class551_0.Rows)
      {
        int columnIndex = 0;
        foreach (Class1026 cell in (ActiveList<Class1026>) row.Cells)
        {
          DxfXRecord cellRoundTripData = new DxfXRecord();
          cellRoundTripData.vmethod_2((IDxfHandledObject) dxfDataTable);
          double checksum;
          int overrideFlags;
          int extendedFlags;
          this.class551_0.method_9(context.Version, cell, rowIndex, columnIndex, cellRoundTripData, out checksum, out overrideFlags, out extendedFlags);
          dxfDataColumn1.Cells[index].Value = (DxfDataCellValue) new DxfDataCellValue.Double(checksum);
          dxfDataColumn2.Cells[index].Value = (DxfDataCellValue) new DxfDataCellValue.Int32(overrideFlags);
          dxfDataColumn3.Cells[index].Value = (DxfDataCellValue) new DxfDataCellValue.Int32(extendedFlags);
          dxfDataColumn4.Cells[index].Value = (DxfDataCellValue) new DxfDataCellValue.HardOwnerId((DxfObject) cellRoundTripData);
          ++index;
          ++columnIndex;
        }
        ++rowIndex;
      }
    }

    internal DxfTableContent Content
    {
      get
      {
        return (DxfTableContent) this.dxfObjectReference_8.Value;
      }
      set
      {
        this.dxfObjectReference_8 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal Class551 Table2005
    {
      get
      {
        return this.class551_0;
      }
      set
      {
        this.class551_0 = value;
      }
    }

    internal byte Unknown0
    {
      get
      {
        return this.byte_0;
      }
      set
      {
        this.byte_0 = value;
      }
    }

    internal DxfHandledObject Unknown1
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_9.Value;
      }
      set
      {
        this.dxfObjectReference_9 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal int Unknown2
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

    internal bool Unknown3
    {
      get
      {
        return this.bool_2;
      }
      set
      {
        this.bool_2 = value;
      }
    }

    internal short Unknown4
    {
      get
      {
        return this.short_1;
      }
      set
      {
        this.short_1 = value;
      }
    }

    internal int Unknown5
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    internal void method_18()
    {
      if (this.class551_0 == null)
        return;
      this.vector3D_1 = this.class551_0.HorizontalDirection;
      this.Content.method_18(this.class551_0);
    }

    internal void method_19()
    {
      if (this.class551_0 == null)
        return;
      this.Content.method_21(this.class551_0);
    }

    internal override void vmethod_10(DxfModel model)
    {
      base.vmethod_10(model);
      if (this.ExtensionDictionary != null && this.Content == null)
      {
        IDictionaryEntry first = this.ExtensionDictionary.Entries.GetFirst("ACAD_XREC_ROUNDTRIP");
        if (first != null)
        {
          DxfXRecord dxfXrecord = first.Value as DxfXRecord;
          if (dxfXrecord != null)
          {
            List<DxfXRecordValue>.Enumerator enumerator = dxfXrecord.Values.GetEnumerator();
            while (enumerator.MoveNext())
            {
              if (enumerator.Current.Code == (short) 102)
              {
                if (!((string) enumerator.Current.Value == "ACAD_ROUNDTRIP_2008_TABLE_ENTITY"))
                {
                  if ((string) enumerator.Current.Value == "ACAD_ROUNDTRIP_PRE2007_TABLE")
                    this.method_21(enumerator);
                }
                else
                {
                  this.method_20(enumerator);
                  break;
                }
              }
            }
          }
        }
        this.ExtensionDictionary.Entries.RemoveAll("ACAD_XREC_ROUNDTRIP");
        if (this.ExtensionDictionary.Entries.Count == 0)
          this.ExtensionDictionary = (DxfDictionary) null;
      }
      if (this.class551_0 != null && this.Content == null)
      {
        this.Content = new DxfTableContent();
        this.method_18();
      }
      else if (this.class551_0 != null && this.Content != null)
      {
        this.method_19();
      }
      else
      {
        if (this.Content != null)
          return;
        this.Content = new DxfTableContent();
      }
    }

    private void method_20(List<DxfXRecordValue>.Enumerator enumerator)
    {
      int num1 = 0;
      while (enumerator.MoveNext())
      {
        bool flag = false;
        switch (enumerator.Current.Code)
        {
          case 40:
            this.BreakData.BreakSpacing = (double) enumerator.Current.Value;
            if (enumerator.MoveNext())
            {
              if (enumerator.Current.Code == (short) 90)
                this.BreakData.UnknownFlags1 = (int) enumerator.Current.Value;
              if (enumerator.MoveNext())
              {
                if (enumerator.Current.Code == (short) 90)
                  this.BreakData.UnknownFlags2 = (int) enumerator.Current.Value;
                if (enumerator.MoveNext())
                {
                  int num2 = 0;
                  if (enumerator.Current.Code == (short) 90)
                    num2 = (int) enumerator.Current.Value;
                  for (int index = 0; index < num2; ++index)
                  {
                    if (enumerator.MoveNext())
                    {
                      DxfTableBreakHeight tableBreakHeight = new DxfTableBreakHeight();
                      if (enumerator.Current.Code == (short) 10)
                        tableBreakHeight.Position = (WW.Math.Point3D) enumerator.Current.Value;
                      if (enumerator.MoveNext())
                      {
                        if (enumerator.Current.Code == (short) 40)
                          tableBreakHeight.Height = (double) enumerator.Current.Value;
                        if (enumerator.MoveNext())
                        {
                          if (enumerator.Current.Code == (short) 90)
                            tableBreakHeight.Flags = (int) enumerator.Current.Value;
                          this.BreakData.BreakHeights.Add(tableBreakHeight);
                        }
                        else
                        {
                          flag = true;
                          break;
                        }
                      }
                      else
                      {
                        flag = true;
                        break;
                      }
                    }
                    else
                    {
                      flag = true;
                      break;
                    }
                  }
                  break;
                }
                break;
              }
              break;
            }
            break;
          case 70:
            this.BreakData.Flags = (int) (short) enumerator.Current.Value;
            if (this.BreakData.Flags == 2)
            {
              this.BreakData.Flags = 0;
              break;
            }
            break;
          case 90:
            if (this.BreakData.Flags != 0)
            {
              switch (num1)
              {
                case 0:
                  this.BreakData.OptionFlags = (TableBreakOptionFlags) enumerator.Current.Value;
                  goto label_22;
                case 1:
                  this.BreakData.FlowDirection = (TableBreakFlowDirection) enumerator.Current.Value;
                  goto label_22;
                case 2:
                  break;
                default:
                  int num3 = (int) enumerator.Current.Value;
                  goto label_22;
              }
            }
            int num4 = (int) enumerator.Current.Value;
            for (int index = 0; index < num4; ++index)
            {
              if (enumerator.MoveNext())
              {
                DxfTableBreakRowRange tableBreakRowRange = new DxfTableBreakRowRange();
                if (enumerator.Current.Code == (short) 10)
                  tableBreakRowRange.Position = (WW.Math.Point3D) enumerator.Current.Value;
                if (enumerator.MoveNext())
                {
                  if (enumerator.Current.Code == (short) 90)
                    tableBreakRowRange.StartRowIndex = (int) enumerator.Current.Value;
                  if (enumerator.MoveNext())
                  {
                    if (enumerator.Current.Code == (short) 90)
                      tableBreakRowRange.EndRowIndex = (int) enumerator.Current.Value;
                    this.BreakData.RowRanges.Add(tableBreakRowRange);
                  }
                  else
                  {
                    flag = true;
                    break;
                  }
                }
                else
                {
                  flag = true;
                  break;
                }
              }
              else
              {
                flag = true;
                break;
              }
            }
label_22:
            ++num1;
            break;
          case 102:
            return;
          case 330:
            DxfTable dxfTable = enumerator.Current.Value as DxfTable;
            if (dxfTable != null)
            {
              this.BreakData.SubTables.Add(dxfTable);
              break;
            }
            break;
          case 360:
            if (enumerator.Current.Value != null)
            {
              DxfTableContent dxfTableContent = (DxfHandledObject) enumerator.Current.Value as DxfTableContent;
              if (dxfTableContent != null)
              {
                this.Content = dxfTableContent;
                break;
              }
              break;
            }
            break;
        }
        if (flag)
          break;
      }
    }

    private void method_21(List<DxfXRecordValue>.Enumerator enumerator)
    {
      if (this.class551_0 == null)
        return;
      ValueDataType? dataType1 = new ValueDataType?();
      ValueUnitType? unitType1 = new ValueUnitType?();
      string formatString1 = (string) null;
      ValueDataType? dataType2 = new ValueDataType?();
      ValueUnitType? unitType2 = new ValueUnitType?();
      string formatString2 = (string) null;
      ValueDataType? dataType3 = new ValueDataType?();
      ValueUnitType? unitType3 = new ValueUnitType?();
      string formatString3 = (string) null;
      while (enumerator.MoveNext())
      {
        switch (enumerator.Current.Code)
        {
          case 1:
            formatString1 = (string) enumerator.Current.Value;
            continue;
          case 2:
            formatString2 = (string) enumerator.Current.Value;
            continue;
          case 3:
            formatString3 = (string) enumerator.Current.Value;
            continue;
          case 90:
            this.class551_0.RowCount = (int) enumerator.Current.Value;
            continue;
          case 91:
            this.class551_0.ColumnCount = (int) enumerator.Current.Value;
            continue;
          case 92:
            dataType1 = new ValueDataType?((ValueDataType) enumerator.Current.Value);
            continue;
          case 93:
            unitType1 = new ValueUnitType?((ValueUnitType) enumerator.Current.Value);
            continue;
          case 94:
            dataType2 = new ValueDataType?((ValueDataType) enumerator.Current.Value);
            continue;
          case 95:
            unitType2 = new ValueUnitType?((ValueUnitType) enumerator.Current.Value);
            continue;
          case 96:
            dataType3 = new ValueDataType?((ValueDataType) enumerator.Current.Value);
            continue;
          case 97:
            unitType3 = new ValueUnitType?((ValueUnitType) enumerator.Current.Value);
            continue;
          case 102:
            if ((string) enumerator.Current.Value == "ACAD_ROUNDTRIP_PRE2007_TABLECELL")
            {
              this.method_22(enumerator);
              continue;
            }
            continue;
          default:
            continue;
        }
      }
      if (dataType1.HasValue && unitType1.HasValue)
        this.class551_0.TitleRowCellStyle.CellFormat = DxfValueFormat.Create(dataType1, unitType1, formatString1);
      if (dataType2.HasValue && unitType2.HasValue)
        this.class551_0.HeaderRowCellStyle.CellFormat = DxfValueFormat.Create(dataType2, unitType2, formatString2);
      if (!dataType3.HasValue || !unitType3.HasValue)
        return;
      this.class551_0.DataRowCellStyle.CellFormat = DxfValueFormat.Create(dataType3, unitType3, formatString3);
    }

    private void method_22(List<DxfXRecordValue>.Enumerator enumerator)
    {
      if (!enumerator.MoveNext() || enumerator.Current.Code != (short) 360)
        return;
      DxfDataTable dxfDataTable = (DxfDataTable) enumerator.Current.Value;
      if (dxfDataTable == null || dxfDataTable.ColumnCount != 4 || dxfDataTable.RowCount != this.class551_0.RowCount * this.class551_0.ColumnCount)
        return;
      DxfDataColumn column1 = dxfDataTable.Columns[0];
      DxfDataColumn column2 = dxfDataTable.Columns[1];
      DxfDataColumn column3 = dxfDataTable.Columns[2];
      DxfDataColumn column4 = dxfDataTable.Columns[3];
      int index = 0;
      foreach (Class430 row in (ActiveList<Class430>) this.class551_0.Rows)
      {
        foreach (Class1026 cell in (ActiveList<Class1026>) row.Cells)
        {
          DxfXRecord xrecord = (DxfXRecord) ((DxfDataCellValue.OwnerIdBase) column4.Cells[index].Value).Value;
          cell.Value.Read(xrecord);
          cell.ExtendedFlags = ((DxfDataCellValue.Int32) column3.Cells[index].Value).Value;
          ++index;
        }
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_16.ClassNumber;
    }

    private void method_23(DxfTable.Class478 tableLayout, Matrix4D transformation)
    {
      double num1 = this.TableStyle.FlowDirection == TableFlowDirection.Down ? -1.0 : 1.0;
      for (int rowIndex = 0; rowIndex < this.Rows.Count; ++rowIndex)
      {
        DxfTable.Class479 class479 = new DxfTable.Class479(this.Rows[rowIndex]);
        tableLayout.RowLayouts.Add(class479);
        for (int columnIndex = 0; columnIndex < this.Columns.Count; ++columnIndex)
        {
          DxfTable.Class480 class480 = new DxfTable.Class480();
          class479.CellLayouts.Add(class480);
          DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
          Size2D size2D = this.method_24(rowIndex, columnIndex);
          double horizontalMargin = this.Content.GetHorizontalMargin(rowIndex, columnIndex);
          double verticalMargin = this.Content.GetVerticalMargin(rowIndex, columnIndex);
          int cellContentIndex = 0;
          foreach (DxfTableCellContent content in (List<DxfTableCellContent>) cell.Contents)
          {
            DxfTable.Class481 class481 = new DxfTable.Class481();
            class480.CellContentLayouts.Add(class481);
            DxfBlock valueObject = content.ValueObject as DxfBlock;
            if (content.ContentType == TableCellContentType.Block && valueObject != null && !this.GetAutoScale(rowIndex, columnIndex, cellContentIndex))
            {
              DxfInsert dxfInsert = new DxfInsert(valueObject);
              double blockScale = this.GetBlockScale(rowIndex, columnIndex, cellContentIndex);
              dxfInsert.ScaleFactor = new WW.Math.Vector3D(blockScale, blockScale, blockScale);
              this.Block.Entities.Add((DxfEntity) dxfInsert);
              BoundsCalculator boundsCalculator = new BoundsCalculator();
              boundsCalculator.GetBounds(this.Model, (DxfEntity) dxfInsert, Matrix4D.Identity);
              class481.Insert = dxfInsert;
              class481.InsertBounds = boundsCalculator.Bounds;
              double num2 = boundsCalculator.Bounds.Delta.Y + 2.0 * verticalMargin;
              if (num2 > size2D.Y)
              {
                double num3 = size2D.Y - this.Rows[rowIndex].Height;
                this.Rows[rowIndex].Height = num2 - num3;
                size2D.Y = num2;
              }
              double num4 = boundsCalculator.Bounds.Delta.X + 2.0 * horizontalMargin;
              if (num4 > size2D.X)
              {
                double num3 = size2D.X - this.Columns[columnIndex].Width;
                this.Columns[columnIndex].Width = num4 - num3;
                size2D.X = num4;
              }
            }
            ++cellContentIndex;
          }
        }
      }
      for (int rowIndex = 0; rowIndex < this.Rows.Count; ++rowIndex)
      {
        DxfTable.Class479 rowLayout = tableLayout.RowLayouts[rowIndex];
        for (int columnIndex = 0; columnIndex < this.Columns.Count; ++columnIndex)
        {
          DxfTable.Class480 cellLayout = rowLayout.CellLayouts[columnIndex];
          DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
          AttachmentPoint attachmentPoint = AttachmentPoint.MiddleCenter;
          DxfTableCellRange first = this.Content.MergedCellRanges.FindFirst(rowIndex, columnIndex);
          Size2D size2D = this.method_25(rowIndex, columnIndex, first);
          double horizontalMargin = this.Content.GetHorizontalMargin(rowIndex, columnIndex);
          double verticalMargin = this.Content.GetVerticalMargin(rowIndex, columnIndex);
          int cellContentIndex = 0;
          if ((first == null ? 1 : (first.IsTopLeftCell(rowIndex, columnIndex) ? 1 : 0)) != 0)
          {
            Color? backColor = this.GetBackColor(rowIndex, columnIndex);
            if (backColor.HasValue)
            {
              DxfSolid dxfSolid1 = new DxfSolid();
              dxfSolid1.Color = EntityColor.CreateFrom(backColor.Value);
              DxfSolid dxfSolid2 = dxfSolid1;
              this.Block.Entities.Add((DxfEntity) dxfSolid2);
              cellLayout.BackgroundEntity = dxfSolid2;
            }
          }
          foreach (DxfTableCellContent content in (List<DxfTableCellContent>) cell.Contents)
          {
            DxfTable.Class481 cellContentLayout = cellLayout.CellContentLayouts[cellContentIndex];
            if (content.Value != null)
            {
              string valueString = content.Value.GetValueString(this.GetValueFormat(rowIndex, columnIndex, cellContentIndex));
              if (!string.IsNullOrEmpty(valueString))
              {
                double textHeight = this.GetTextHeight(rowIndex, columnIndex, cellContentIndex);
                DxfMText dxfMtext = new DxfMText(valueString, WW.Math.Point3D.Zero, textHeight);
                dxfMtext.ReferenceRectangleWidth = size2D.X - 2.0 * horizontalMargin;
                dxfMtext.Style = this.GetTextStyle(rowIndex, columnIndex, cellContentIndex);
                Color contentColor = this.GetContentColor(rowIndex, columnIndex, cellContentIndex);
                dxfMtext.Color = EntityColor.CreateFrom(contentColor);
                if (dxfMtext.Color == EntityColor.None)
                  dxfMtext.Color = this.Color;
                dxfMtext.AttachmentPoint = attachmentPoint;
                dxfMtext.XAxis = this.vector3D_1;
                this.Block.Entities.Add((DxfEntity) dxfMtext);
                cellContentLayout.Text = dxfMtext;
                double num2 = dxfMtext.BoxHeight + 2.0 * verticalMargin;
                if (num2 > size2D.Y)
                {
                  double num3 = size2D.Y - this.Rows[rowIndex].Height;
                  this.Rows[rowIndex].Height = num2 - num3;
                  size2D.Y = num2;
                }
              }
            }
            DxfBlock valueObject = content.ValueObject as DxfBlock;
            if (content.ContentType == TableCellContentType.Block && valueObject != null && this.GetAutoScale(rowIndex, columnIndex, cellContentIndex))
            {
              DxfInsert dxfInsert = new DxfInsert(valueObject);
              this.Block.Entities.Add((DxfEntity) dxfInsert);
              BoundsCalculator boundsCalculator = new BoundsCalculator();
              boundsCalculator.GetBounds(this.Model, (DxfEntity) dxfInsert, Matrix4D.Identity);
              cellContentLayout.Insert = dxfInsert;
              cellContentLayout.InsertBounds = boundsCalculator.Bounds;
            }
            ++cellContentIndex;
          }
        }
      }
      List<double> doubleList1 = new List<double>(this.Columns.Count + 1);
      doubleList1.Add(0.0);
      double num5 = 0.0;
      for (int index = 0; index < this.Columns.Count; ++index)
      {
        num5 += this.Columns[index].Width;
        doubleList1.Add(num5);
      }
      List<double> doubleList2 = new List<double>(this.Rows.Count + 1);
      doubleList2.Add(0.0);
      double num6 = 0.0;
      for (int index = 0; index < this.Rows.Count; ++index)
      {
        double height = this.Rows[index].Height;
        num6 += num1 * height;
        doubleList2.Add(num6);
      }
      for (int rowIndex = 0; rowIndex < this.Rows.Count; ++rowIndex)
      {
        DxfTable.Class479 rowLayout = tableLayout.RowLayouts[rowIndex];
        for (int columnIndex = 0; columnIndex < this.Columns.Count; ++columnIndex)
        {
          DxfTable.Class480 cellLayout = rowLayout.CellLayouts[columnIndex];
          DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
          AttachmentPoint attachmentPoint = AttachmentPoint.MiddleCenter;
          WW.Math.Point3D point1 = WW.Math.Point3D.Zero;
          WW.Math.Point3D point2 = WW.Math.Point3D.Zero;
          DxfTableCellRange first = this.Content.MergedCellRanges.FindFirst(rowIndex, columnIndex);
          WW.Math.Point2D point2D1;
          WW.Math.Point2D point2D2;
          if (first != null)
          {
            double val1 = doubleList2[first.TopRowIndex];
            double val2 = doubleList2[first.BottomRowIndex + 1];
            point2D1 = new WW.Math.Point2D(doubleList1[first.LeftColumnIndex], System.Math.Max(val1, val2));
            point2D2 = new WW.Math.Point2D(doubleList1[first.RightColumnIndex + 1], System.Math.Min(val1, val2));
          }
          else
          {
            double val1 = doubleList2[rowIndex];
            double val2 = doubleList2[rowIndex + 1];
            point2D1 = new WW.Math.Point2D(doubleList1[columnIndex], System.Math.Max(val1, val2));
            point2D2 = new WW.Math.Point2D(doubleList1[columnIndex + 1], System.Math.Min(val1, val2));
          }
          if (cellLayout.BackgroundEntity != null)
          {
            cellLayout.BackgroundEntity.Points.Add(transformation.Transform(new WW.Math.Point3D(point2D1.X, point2D2.Y, 0.0)));
            cellLayout.BackgroundEntity.Points.Add(transformation.Transform(new WW.Math.Point3D(point2D2.X, point2D2.Y, 0.0)));
            cellLayout.BackgroundEntity.Points.Add(transformation.Transform(new WW.Math.Point3D(point2D1.X, point2D1.Y, 0.0)));
            cellLayout.BackgroundEntity.Points.Add(transformation.Transform(new WW.Math.Point3D(point2D2.X, point2D1.Y, 0.0)));
          }
          double horizontalMargin = this.Content.GetHorizontalMargin(rowIndex, columnIndex);
          double verticalMargin = this.Content.GetVerticalMargin(rowIndex, columnIndex);
          Vector2D vector2D = point2D2 - point2D1;
          if (vector2D.X > 2.0 * horizontalMargin)
          {
            point2D1.X += horizontalMargin;
            point2D2.X -= horizontalMargin;
          }
          if (-vector2D.Y > 2.0 * verticalMargin)
          {
            point2D1.Y -= verticalMargin;
            point2D2.Y += verticalMargin;
          }
          int cellContentIndex = 0;
          foreach (DxfTableCellContent content in (List<DxfTableCellContent>) cell.Contents)
          {
            DxfTable.Class481 cellContentLayout = cellLayout.CellContentLayouts[cellContentIndex];
            DxfMText text = cellContentLayout.Text;
            DxfInsert insert = cellContentLayout.Insert;
            Bounds3D bounds3D = (Bounds3D) null;
            if (insert != null)
            {
              bounds3D = cellContentLayout.InsertBounds;
              if (this.GetAutoScale(rowIndex, columnIndex, cellContentIndex))
              {
                vector2D = point2D2 - point2D1;
                double num2 = System.Math.Min(System.Math.Abs(vector2D.X / bounds3D.Delta.X), System.Math.Abs(vector2D.Y / bounds3D.Delta.Y));
                insert.ScaleFactor = new WW.Math.Vector3D(num2, num2, num2);
                bounds3D = new Bounds3D(num2 * bounds3D.Corner1.X, num2 * bounds3D.Corner1.Y, num2 * bounds3D.Corner1.Z, num2 * bounds3D.Corner2.X, num2 * bounds3D.Corner2.Y, num2 * bounds3D.Corner2.Z);
              }
            }
            if (text != null)
            {
              switch (this.GetCellAlignment(rowIndex, columnIndex, cellContentIndex))
              {
                case CellAlignment.TopLeft:
                  attachmentPoint = AttachmentPoint.TopLeft;
                  point1 = new WW.Math.Point3D(point2D1.X, point2D1.Y, 0.0);
                  break;
                case CellAlignment.TopCenter:
                  attachmentPoint = AttachmentPoint.TopCenter;
                  point1 = new WW.Math.Point3D(0.5 * (point2D1.X + point2D2.X), point2D1.Y, 0.0);
                  break;
                case CellAlignment.TopRight:
                  attachmentPoint = AttachmentPoint.TopRight;
                  point1 = new WW.Math.Point3D(point2D2.X, point2D1.Y, 0.0);
                  break;
                case CellAlignment.MiddleLeft:
                  attachmentPoint = AttachmentPoint.MiddleLeft;
                  point1 = new WW.Math.Point3D(point2D1.X, 0.5 * (point2D2.Y + point2D1.Y), 0.0);
                  break;
                case CellAlignment.MiddleCenter:
                  attachmentPoint = AttachmentPoint.MiddleCenter;
                  point1 = new WW.Math.Point3D(0.5 * (point2D1.X + point2D2.X), 0.5 * (point2D2.Y + point2D1.Y), 0.0);
                  break;
                case CellAlignment.MiddleRight:
                  attachmentPoint = AttachmentPoint.MiddleRight;
                  point1 = new WW.Math.Point3D(point2D2.X, 0.5 * (point2D2.Y + point2D1.Y), 0.0);
                  break;
                case CellAlignment.BottomLeft:
                  attachmentPoint = AttachmentPoint.BottomLeft;
                  point1 = new WW.Math.Point3D(point2D1.X, point2D2.Y, 0.0);
                  break;
                case CellAlignment.BottomCenter:
                  attachmentPoint = AttachmentPoint.BottomCenter;
                  point1 = new WW.Math.Point3D(0.5 * (point2D1.X + point2D2.X), point2D2.Y, 0.0);
                  break;
                case CellAlignment.BottomRight:
                  attachmentPoint = AttachmentPoint.BottomRight;
                  point1 = new WW.Math.Point3D(point2D2.X, point2D2.Y, 0.0);
                  break;
              }
              text.InsertionPoint = transformation.Transform(point1);
              text.AttachmentPoint = attachmentPoint;
            }
            if (insert != null)
            {
              switch (this.GetCellAlignment(rowIndex, columnIndex, cellContentIndex))
              {
                case CellAlignment.TopLeft:
                  attachmentPoint = AttachmentPoint.TopLeft;
                  point2 = new WW.Math.Point3D(point2D1.X - bounds3D.Corner1.X, point2D1.Y - bounds3D.Corner2.Y, 0.0);
                  break;
                case CellAlignment.TopCenter:
                  attachmentPoint = AttachmentPoint.TopCenter;
                  point2 = new WW.Math.Point3D(0.5 * (point2D1.X + point2D2.X) - bounds3D.Center.X, point2D1.Y - bounds3D.Corner2.Y, 0.0);
                  break;
                case CellAlignment.TopRight:
                  attachmentPoint = AttachmentPoint.TopRight;
                  point2 = new WW.Math.Point3D(point2D2.X - bounds3D.Corner2.X, point2D1.Y - bounds3D.Corner2.Y, 0.0);
                  break;
                case CellAlignment.MiddleLeft:
                  attachmentPoint = AttachmentPoint.MiddleLeft;
                  point2 = new WW.Math.Point3D(point2D1.X - bounds3D.Corner1.X, 0.5 * (point2D2.Y + point2D1.Y) - bounds3D.Center.Y, 0.0);
                  break;
                case CellAlignment.MiddleCenter:
                  attachmentPoint = AttachmentPoint.MiddleCenter;
                  point2 = new WW.Math.Point3D(0.5 * (point2D1.X + point2D2.X) - bounds3D.Center.X, 0.5 * (point2D2.Y + point2D1.Y) - bounds3D.Center.Y, 0.0);
                  break;
                case CellAlignment.MiddleRight:
                  attachmentPoint = AttachmentPoint.MiddleRight;
                  point2 = new WW.Math.Point3D(point2D2.X - bounds3D.Corner2.X, 0.5 * (point2D2.Y + point2D1.Y) - bounds3D.Center.Y, 0.0);
                  break;
                case CellAlignment.BottomLeft:
                  attachmentPoint = AttachmentPoint.BottomLeft;
                  point2 = new WW.Math.Point3D(point2D1.X - bounds3D.Corner1.X, point2D2.Y - bounds3D.Corner1.Y, 0.0);
                  break;
                case CellAlignment.BottomCenter:
                  attachmentPoint = AttachmentPoint.BottomCenter;
                  point2 = new WW.Math.Point3D(0.5 * (point2D1.X + point2D2.X) - bounds3D.Center.X, point2D2.Y - bounds3D.Corner1.Y, 0.0);
                  break;
                case CellAlignment.BottomRight:
                  attachmentPoint = AttachmentPoint.BottomRight;
                  point2 = new WW.Math.Point3D(point2D2.X - bounds3D.Corner2.X, point2D2.Y - bounds3D.Corner1.Y, 0.0);
                  break;
              }
              insert.InsertionPoint = transformation.Transform(point2);
            }
            ++cellContentIndex;
          }
        }
      }
    }

    private Size2D method_24(int rowIndex, int columnIndex)
    {
      DxfTableCellRange first = this.Content.MergedCellRanges.FindFirst(rowIndex, columnIndex);
      return this.method_25(rowIndex, columnIndex, first);
    }

    private Size2D method_25(
      int rowIndex,
      int columnIndex,
      DxfTableCellRange mergedCellRange)
    {
      double width = this.Columns[columnIndex].Width;
      double height = this.Rows[rowIndex].Height;
      if (mergedCellRange != null)
      {
        width = 0.0;
        for (int leftColumnIndex = mergedCellRange.LeftColumnIndex; leftColumnIndex <= mergedCellRange.RightColumnIndex; ++leftColumnIndex)
          width += this.Columns[leftColumnIndex].Width;
        height = 0.0;
        for (int topRowIndex = mergedCellRange.TopRowIndex; topRowIndex <= mergedCellRange.BottomRowIndex; ++topRowIndex)
          height += this.Rows[rowIndex].Height;
      }
      return new Size2D(width, height);
    }

    private void method_26(DxfModel model, DxfTable.Class478 tableLayout, Matrix4D transformation)
    {
      int count1 = this.Rows.Count;
      int count2 = this.Columns.Count;
      List<List<DxfTableBorder>> horizontalBorderListList = new List<List<DxfTableBorder>>();
      if (count2 > 0)
      {
        for (int index1 = 0; index1 < count1; ++index1)
        {
          List<DxfTableBorder> dxfTableBorderList = new List<DxfTableBorder>();
          horizontalBorderListList.Add(dxfTableBorderList);
          for (int index2 = 0; index2 < count2; ++index2)
          {
            bool flag = false;
            if (index1 != 0)
              flag = this.MergedCellRanges.AreInSameCellRange(index1, index2, index1 - 1, index2);
            DxfTableBorder dxfTableBorder = (DxfTableBorder) null;
            if (!flag)
              dxfTableBorder = this.Content.GetEffectiveBorderTop(index1, index2);
            dxfTableBorderList.Add(dxfTableBorder);
          }
        }
        List<DxfTableBorder> dxfTableBorderList1 = new List<DxfTableBorder>();
        horizontalBorderListList.Add(dxfTableBorderList1);
        int rowIndex = count1 - 1;
        for (int columnIndex = 0; columnIndex < count2; ++columnIndex)
        {
          DxfTableBorder effectiveBorderBottom = this.Content.GetEffectiveBorderBottom(rowIndex, columnIndex);
          dxfTableBorderList1.Add(effectiveBorderBottom);
        }
      }
      List<List<DxfTableBorder>> verticalBorderListList = new List<List<DxfTableBorder>>();
      if (count2 > 0)
      {
        for (int index1 = 0; index1 < count2; ++index1)
        {
          List<DxfTableBorder> dxfTableBorderList = new List<DxfTableBorder>();
          verticalBorderListList.Add(dxfTableBorderList);
          for (int index2 = 0; index2 < count1; ++index2)
          {
            this.GetCellStyle(index2, index1);
            bool flag = false;
            if (index1 != 0)
              flag = this.MergedCellRanges.AreInSameCellRange(index2, index1, index2, index1 - 1);
            DxfTableBorder dxfTableBorder = (DxfTableBorder) null;
            if (!flag)
              dxfTableBorder = this.Content.GetEffectiveBorderLeft(index2, index1);
            dxfTableBorderList.Add(dxfTableBorder);
          }
        }
        int columnIndex = count2 - 1;
        List<DxfTableBorder> dxfTableBorderList1 = new List<DxfTableBorder>();
        verticalBorderListList.Add(dxfTableBorderList1);
        for (int rowIndex = 0; rowIndex < count1; ++rowIndex)
        {
          this.GetCellStyle(rowIndex, columnIndex);
          DxfTableBorder effectiveBorderRight = this.Content.GetEffectiveBorderRight(rowIndex, columnIndex);
          dxfTableBorderList1.Add(effectiveBorderRight);
        }
      }
      this.method_27(model, tableLayout, transformation, horizontalBorderListList, verticalBorderListList);
    }

    private void method_27(
      DxfModel model,
      DxfTable.Class478 tableLayout,
      Matrix4D transformation,
      List<List<DxfTableBorder>> horizontalBorderListList,
      List<List<DxfTableBorder>> verticalBorderListList)
    {
      if (this.Rows.Count > 0)
      {
        this.method_28(model, tableLayout, transformation, horizontalBorderListList, verticalBorderListList);
        this.method_29(model, tableLayout, transformation, horizontalBorderListList, verticalBorderListList);
        this.method_30(model, tableLayout, transformation, horizontalBorderListList, verticalBorderListList);
      }
      if (this.Columns.Count <= 0)
        return;
      this.method_31(model, tableLayout, transformation, horizontalBorderListList, verticalBorderListList);
      this.method_32(model, tableLayout, transformation, horizontalBorderListList, verticalBorderListList);
      this.method_33(model, tableLayout, transformation, horizontalBorderListList, verticalBorderListList);
    }

    private void method_28(
      DxfModel model,
      DxfTable.Class478 tableLayout,
      Matrix4D transformation,
      List<List<DxfTableBorder>> horizontalBorderListList,
      List<List<DxfTableBorder>> verticalBorderListList)
    {
      double num1 = 0.0;
      double num2 = this.TableStyle.FlowDirection == TableFlowDirection.Down ? -1.0 : 1.0;
      for (int index1 = 0; index1 <= this.Rows.Count; ++index1)
      {
        int index2 = 0;
        double num3 = 0.0;
        double num4 = this.Columns.Count > 0 ? this.Columns[0].Width : 0.0;
        List<DxfTableBorder> horizontalBorderList = horizontalBorderListList[index1];
        DxfTableBorder dxfTableBorder = horizontalBorderList[0];
        for (int index3 = 1; index3 <= this.Columns.Count; ++index3)
        {
          DxfTableBorder border1 = index1 - 1 < 0 ? (DxfTableBorder) null : verticalBorderListList[index2][index1 - 1];
          DxfTableBorder b = index3 >= this.Columns.Count ? (DxfTableBorder) null : horizontalBorderList[index3];
          DxfTableBorder border2 = index1 - 1 < 0 ? (DxfTableBorder) null : verticalBorderListList[index3][index1 - 1];
          if (!DxfTableBorder.smethod_0(dxfTableBorder, b) || DxfTableBorder.smethod_2(border2))
          {
            int num5 = index3 - 1;
            DxfTableBorder border3 = border2;
            if (dxfTableBorder != null && DxfTableBorder.smethod_2(dxfTableBorder))
            {
              DxfTableBorder border4 = index2 - 1 < 0 ? (DxfTableBorder) null : horizontalBorderList[index2 - 1];
              DxfTableBorder border5 = index1 >= this.Rows.Count ? (DxfTableBorder) null : verticalBorderListList[index2][index1];
              double left = DxfTableBorder.smethod_2(border1) || DxfTableBorder.smethod_2(border4) || !DxfTableBorder.smethod_2(border5) ? num3 + 0.5 * DxfTableBorder.smethod_1(border1) : num3 - 0.5 * DxfTableBorder.smethod_1(border5);
              DxfTableBorder border6 = num5 + 1 >= this.Columns.Count ? (DxfTableBorder) null : horizontalBorderList[num5 + 1];
              DxfTableBorder border7 = index1 >= this.Rows.Count ? (DxfTableBorder) null : verticalBorderListList[num5 + 1][index1];
              double right = DxfTableBorder.smethod_2(border3) || DxfTableBorder.smethod_2(border6) || !DxfTableBorder.smethod_2(border7) ? num4 - 0.5 * DxfTableBorder.smethod_1(border3) : num4 + 0.5 * DxfTableBorder.smethod_1(border7);
              this.method_34(model, transformation, dxfTableBorder, num1 - num2 * 0.5 * dxfTableBorder.DoubleLineSpacing, left, right);
            }
            index2 = index3;
            num3 = num4;
            dxfTableBorder = b;
          }
          if (index3 < this.Columns.Count)
            num4 += this.Columns[index3].Width;
        }
        if (index1 < this.Rows.Count)
          num1 += num2 * this.Rows[index1].Height;
      }
    }

    private void method_29(
      DxfModel model,
      DxfTable.Class478 tableLayout,
      Matrix4D transformation,
      List<List<DxfTableBorder>> horizontalBorderListList,
      List<List<DxfTableBorder>> verticalBorderListList)
    {
      double num1 = 0.0;
      double num2 = this.TableStyle.FlowDirection == TableFlowDirection.Down ? -1.0 : 1.0;
      for (int index1 = 0; index1 <= this.Rows.Count; ++index1)
      {
        int index2 = 0;
        double num3 = 0.0;
        double num4 = this.Columns.Count > 0 ? this.Columns[0].Width : 0.0;
        List<DxfTableBorder> horizontalBorderList = horizontalBorderListList[index1];
        DxfTableBorder dxfTableBorder = horizontalBorderList[0];
        for (int index3 = 1; index3 <= this.Columns.Count; ++index3)
        {
          DxfTableBorder b = index3 >= this.Columns.Count ? (DxfTableBorder) null : horizontalBorderList[index3];
          DxfTableBorder border1 = index1 >= this.Rows.Count ? (DxfTableBorder) null : verticalBorderListList[index2][index1];
          DxfTableBorder border2 = index1 >= this.Rows.Count ? (DxfTableBorder) null : verticalBorderListList[index3][index1];
          if (!DxfTableBorder.smethod_0(dxfTableBorder, b) || DxfTableBorder.smethod_2(border2))
          {
            int num5 = index3 - 1;
            DxfTableBorder border3 = border2;
            if (dxfTableBorder != null && DxfTableBorder.smethod_2(dxfTableBorder))
            {
              DxfTableBorder border4 = index2 - 1 < 0 ? (DxfTableBorder) null : horizontalBorderList[index2 - 1];
              DxfTableBorder border5 = index1 - 1 < 0 ? (DxfTableBorder) null : verticalBorderListList[index2][index1 - 1];
              double left = !DxfTableBorder.smethod_2(border5) || DxfTableBorder.smethod_2(border4) || DxfTableBorder.smethod_2(border1) ? num3 + 0.5 * DxfTableBorder.smethod_1(border1) : num3 - 0.5 * DxfTableBorder.smethod_1(border5);
              DxfTableBorder border6 = num5 + 1 >= this.Columns.Count ? (DxfTableBorder) null : horizontalBorderList[num5 + 1];
              DxfTableBorder border7 = index1 - 1 < 0 ? (DxfTableBorder) null : verticalBorderListList[num5 + 1][index1 - 1];
              double right = !DxfTableBorder.smethod_2(border7) || DxfTableBorder.smethod_2(border6) || DxfTableBorder.smethod_2(border3) ? num4 - 0.5 * DxfTableBorder.smethod_1(border3) : num4 + 0.5 * DxfTableBorder.smethod_1(border7);
              if (dxfTableBorder.Visible)
                this.method_34(model, transformation, dxfTableBorder, num1 + num2 * 0.5 * dxfTableBorder.DoubleLineSpacing, left, right);
            }
            index2 = index3;
            num3 = num4;
            dxfTableBorder = b;
          }
          if (index3 < this.Columns.Count)
            num4 += this.Columns[index3].Width;
        }
        if (index1 < this.Rows.Count)
          num1 += num2 * this.Rows[index1].Height;
      }
    }

    private void method_30(
      DxfModel model,
      DxfTable.Class478 tableLayout,
      Matrix4D transformation,
      List<List<DxfTableBorder>> horizontalBorderListList,
      List<List<DxfTableBorder>> verticalBorderListList)
    {
      double y = 0.0;
      double num1 = this.TableStyle.FlowDirection == TableFlowDirection.Down ? -1.0 : 1.0;
      for (int index1 = 0; index1 <= this.Rows.Count; ++index1)
      {
        int index2 = 0;
        double num2 = 0.0;
        double num3 = this.Columns.Count > 0 ? this.Columns[0].Width : 0.0;
        List<DxfTableBorder> horizontalBorderList = horizontalBorderListList[index1];
        DxfTableBorder dxfTableBorder = horizontalBorderList[0];
        for (int index3 = 1; index3 <= this.Columns.Count; ++index3)
        {
          DxfTableBorder border1 = index1 - 1 < 0 ? (DxfTableBorder) null : verticalBorderListList[index2][index1 - 1];
          DxfTableBorder border2 = index1 >= this.Rows.Count ? (DxfTableBorder) null : verticalBorderListList[index2][index1];
          DxfTableBorder b = index3 >= this.Columns.Count ? (DxfTableBorder) null : horizontalBorderList[index3];
          DxfTableBorder border3 = index1 - 1 < 0 ? (DxfTableBorder) null : verticalBorderListList[index3][index1 - 1];
          DxfTableBorder border4 = index1 >= this.Rows.Count ? (DxfTableBorder) null : verticalBorderListList[index3][index1];
          if (!DxfTableBorder.smethod_0(dxfTableBorder, b))
          {
            double num4 = System.Math.Max(DxfTableBorder.smethod_1(border1), DxfTableBorder.smethod_1(border2));
            double num5 = System.Math.Max(DxfTableBorder.smethod_1(border3), DxfTableBorder.smethod_1(border4));
            if (dxfTableBorder != null && dxfTableBorder.Visible && !DxfTableBorder.smethod_2(dxfTableBorder))
              this.method_34(model, transformation, dxfTableBorder, y, num2 - 0.5 * num4, num3 + 0.5 * num5);
            index2 = index3;
            num2 = num3;
            dxfTableBorder = b;
          }
          if (index3 < this.Columns.Count)
            num3 += this.Columns[index3].Width;
        }
        if (index1 < this.Rows.Count)
          y += num1 * this.Rows[index1].Height;
      }
    }

    private void method_31(
      DxfModel model,
      DxfTable.Class478 tableLayout,
      Matrix4D transformation,
      List<List<DxfTableBorder>> horizontalBorderListList,
      List<List<DxfTableBorder>> verticalBorderListList)
    {
      double num1 = 0.0;
      double num2 = this.TableStyle.FlowDirection == TableFlowDirection.Down ? -1.0 : 1.0;
      for (int index1 = 0; index1 <= this.Columns.Count; ++index1)
      {
        int index2 = 0;
        double num3 = 0.0;
        double num4 = this.Rows.Count > 0 ? num2 * this.Rows[0].Height : 0.0;
        List<DxfTableBorder> verticalBorderList = verticalBorderListList[index1];
        DxfTableBorder dxfTableBorder = verticalBorderList[0];
        for (int index3 = 1; index3 <= this.Rows.Count; ++index3)
        {
          DxfTableBorder border1 = index1 - 1 < 0 ? (DxfTableBorder) null : horizontalBorderListList[index2][index1 - 1];
          DxfTableBorder b = index3 >= this.Rows.Count ? (DxfTableBorder) null : verticalBorderList[index3];
          DxfTableBorder border2 = index1 - 1 < 0 ? (DxfTableBorder) null : horizontalBorderListList[index3][index1 - 1];
          if (!DxfTableBorder.smethod_0(dxfTableBorder, b) || DxfTableBorder.smethod_2(border2))
          {
            int num5 = index3 - 1;
            DxfTableBorder border3 = border2;
            if (dxfTableBorder != null && DxfTableBorder.smethod_2(dxfTableBorder))
            {
              DxfTableBorder border4 = index2 - 1 < 0 ? (DxfTableBorder) null : verticalBorderList[index2 - 1];
              DxfTableBorder border5 = index1 >= this.Columns.Count ? (DxfTableBorder) null : horizontalBorderListList[index2][index1];
              double top = DxfTableBorder.smethod_2(border4) || DxfTableBorder.smethod_2(border1) || !DxfTableBorder.smethod_2(border5) ? num3 + 0.5 * num2 * DxfTableBorder.smethod_1(border1) : num3 - 0.5 * num2 * DxfTableBorder.smethod_1(border5);
              DxfTableBorder border6 = num5 + 1 >= this.Rows.Count ? (DxfTableBorder) null : verticalBorderList[num5 + 1];
              DxfTableBorder border7 = index1 >= this.Columns.Count ? (DxfTableBorder) null : horizontalBorderListList[num5 + 1][index1];
              double bottom = DxfTableBorder.smethod_2(border6) || DxfTableBorder.smethod_2(border3) || !DxfTableBorder.smethod_2(border7) ? num4 - 0.5 * num2 * DxfTableBorder.smethod_1(border3) : num4 + 0.5 * num2 * DxfTableBorder.smethod_1(border7);
              if (dxfTableBorder.Visible)
                this.method_35(model, transformation, dxfTableBorder, num1 - 0.5 * dxfTableBorder.DoubleLineSpacing, top, bottom);
            }
            index2 = index3;
            num3 = num4;
            dxfTableBorder = b;
          }
          if (index3 < this.Rows.Count)
            num4 += num2 * this.Rows[index3].Height;
        }
        if (index1 < this.Columns.Count)
          num1 += this.Columns[index1].Width;
      }
    }

    private void method_32(
      DxfModel model,
      DxfTable.Class478 tableLayout,
      Matrix4D transformation,
      List<List<DxfTableBorder>> horizontalBorderListList,
      List<List<DxfTableBorder>> verticalBorderListList)
    {
      double num1 = 0.0;
      double num2 = this.TableStyle.FlowDirection == TableFlowDirection.Down ? -1.0 : 1.0;
      for (int index1 = 0; index1 <= this.Columns.Count; ++index1)
      {
        int index2 = 0;
        double num3 = 0.0;
        double num4 = this.Rows.Count > 0 ? num2 * this.Rows[0].Height : 0.0;
        List<DxfTableBorder> verticalBorderList = verticalBorderListList[index1];
        DxfTableBorder dxfTableBorder = verticalBorderList[0];
        for (int index3 = 1; index3 <= this.Rows.Count; ++index3)
        {
          DxfTableBorder border1 = index1 >= this.Columns.Count ? (DxfTableBorder) null : horizontalBorderListList[index2][index1];
          DxfTableBorder b = index3 >= this.Rows.Count ? (DxfTableBorder) null : verticalBorderList[index3];
          DxfTableBorder border2 = index1 >= this.Columns.Count ? (DxfTableBorder) null : horizontalBorderListList[index3][index1];
          if (!DxfTableBorder.smethod_0(dxfTableBorder, b) || DxfTableBorder.smethod_2(border2))
          {
            int num5 = index3 - 1;
            DxfTableBorder border3 = border2;
            if (dxfTableBorder != null && DxfTableBorder.smethod_2(dxfTableBorder))
            {
              DxfTableBorder border4 = index2 - 1 < 0 ? (DxfTableBorder) null : verticalBorderList[index2 - 1];
              DxfTableBorder border5 = index1 - 1 < 0 ? (DxfTableBorder) null : horizontalBorderListList[index2][index1 - 1];
              double top = DxfTableBorder.smethod_2(border4) || !DxfTableBorder.smethod_2(border5) || DxfTableBorder.smethod_2(border1) ? num3 + 0.5 * num2 * DxfTableBorder.smethod_1(border1) : num3 - 0.5 * num2 * DxfTableBorder.smethod_1(border5);
              DxfTableBorder border6 = num5 + 1 >= this.Rows.Count ? (DxfTableBorder) null : verticalBorderList[num5 + 1];
              DxfTableBorder border7 = index1 - 1 < 0 ? (DxfTableBorder) null : horizontalBorderListList[num5 + 1][index1 - 1];
              double bottom = DxfTableBorder.smethod_2(border6) || !DxfTableBorder.smethod_2(border7) || DxfTableBorder.smethod_2(border3) ? num4 - 0.5 * num2 * DxfTableBorder.smethod_1(border3) : num4 + 0.5 * num2 * DxfTableBorder.smethod_1(border7);
              if (dxfTableBorder.Visible)
                this.method_35(model, transformation, dxfTableBorder, num1 + 0.5 * dxfTableBorder.DoubleLineSpacing, top, bottom);
            }
            index2 = index3;
            num3 = num4;
            dxfTableBorder = b;
          }
          if (index3 < this.Rows.Count)
            num4 += num2 * this.Rows[index3].Height;
        }
        if (index1 < this.Columns.Count)
          num1 += this.Columns[index1].Width;
      }
    }

    private void method_33(
      DxfModel model,
      DxfTable.Class478 tableLayout,
      Matrix4D transformation,
      List<List<DxfTableBorder>> horizontalBorderListList,
      List<List<DxfTableBorder>> verticalBorderListList)
    {
      double x = 0.0;
      double num1 = this.TableStyle.FlowDirection == TableFlowDirection.Down ? -1.0 : 1.0;
      for (int index1 = 0; index1 <= this.Columns.Count; ++index1)
      {
        int index2 = 0;
        double num2 = 0.0;
        double num3 = this.Rows.Count > 0 ? num1 * this.Rows[0].Height : 0.0;
        List<DxfTableBorder> verticalBorderList = verticalBorderListList[index1];
        DxfTableBorder dxfTableBorder = verticalBorderList[0];
        for (int index3 = 1; index3 <= this.Rows.Count; ++index3)
        {
          DxfTableBorder border1 = index1 - 1 < 0 ? (DxfTableBorder) null : horizontalBorderListList[index2][index1 - 1];
          DxfTableBorder border2 = index1 >= this.Columns.Count ? (DxfTableBorder) null : horizontalBorderListList[index2][index1];
          DxfTableBorder b = index3 >= this.Rows.Count ? (DxfTableBorder) null : verticalBorderList[index3];
          DxfTableBorder border3 = index1 - 1 < 0 ? (DxfTableBorder) null : horizontalBorderListList[index3][index1 - 1];
          DxfTableBorder border4 = index1 >= this.Columns.Count ? (DxfTableBorder) null : horizontalBorderListList[index3][index1];
          if (!DxfTableBorder.smethod_0(dxfTableBorder, b))
          {
            double num4 = System.Math.Max(DxfTableBorder.smethod_1(border1), DxfTableBorder.smethod_1(border2));
            double num5 = System.Math.Max(DxfTableBorder.smethod_1(border3), DxfTableBorder.smethod_1(border4));
            if (dxfTableBorder != null && dxfTableBorder.Visible && !DxfTableBorder.smethod_2(dxfTableBorder))
              this.method_35(model, transformation, dxfTableBorder, x, num2 + 0.5 * num1 * num4, num3 - 0.5 * num1 * num5);
            index2 = index3;
            num2 = num3;
            dxfTableBorder = b;
          }
          if (index3 < this.Rows.Count)
            num3 += num1 * this.Rows[index3].Height;
        }
        if (index1 < this.Columns.Count)
          x += this.Columns[index1].Width;
      }
    }

    private void method_34(
      DxfModel model,
      Matrix4D transformation,
      DxfTableBorder border,
      double y,
      double left,
      double right)
    {
      this.method_36(model, transformation, border, new WW.Math.Point2D(left, y), new WW.Math.Point2D(right, y));
    }

    private void method_35(
      DxfModel model,
      Matrix4D transformation,
      DxfTableBorder border,
      double x,
      double top,
      double bottom)
    {
      this.method_36(model, transformation, border, new WW.Math.Point2D(x, top), new WW.Math.Point2D(x, bottom));
    }

    private void method_36(
      DxfModel model,
      Matrix4D transformation,
      DxfTableBorder border,
      WW.Math.Point2D p1,
      WW.Math.Point2D p2)
    {
      DxfLine dxfLine = new DxfLine(transformation.TransformTo2D(p1), transformation.TransformTo2D(p2));
      if (border.LineType == null)
        dxfLine.LineType = model.ContinuousLineType;
      else
        dxfLine.LineType = border.LineType;
      dxfLine.LineWeight = border.LineWeight;
      dxfLine.Color = EntityColor.CreateFrom(border.Color);
      if (dxfLine.Color == EntityColor.None)
        dxfLine.Color = this.Color;
      if (!border.Visible)
        dxfLine.Layer = model.method_14();
      this.Block.Entities.Add((DxfEntity) dxfLine);
    }

    private void DrawInternal(DxfInsert.Interface46 drawHandler)
    {
      if (this.Block == null || this.bool_3)
        this.GenerateBlock();
      if (this.Block == null)
        return;
      Matrix4D instanceTransform = Transformation4D.Translation((WW.Math.Vector3D) this.InsertionPoint);
      drawHandler.imethod_0(0, 0, instanceTransform);
      drawHandler.Draw(this.Block, true);
    }

    private class Class478
    {
      private List<DxfTable.Class479> list_0 = new List<DxfTable.Class479>();

      public List<DxfTable.Class479> RowLayouts
      {
        get
        {
          return this.list_0;
        }
      }
    }

    private class Class479
    {
      private List<DxfTable.Class480> list_0 = new List<DxfTable.Class480>();

      public Class479(DxfTableRow row)
      {
      }

      public List<DxfTable.Class480> CellLayouts
      {
        get
        {
          return this.list_0;
        }
      }
    }

    private class Class480
    {
      private List<DxfTable.Class481> list_0 = new List<DxfTable.Class481>();
      private DxfSolid dxfSolid_0;

      public DxfSolid BackgroundEntity
      {
        get
        {
          return this.dxfSolid_0;
        }
        set
        {
          this.dxfSolid_0 = value;
        }
      }

      public List<DxfTable.Class481> CellContentLayouts
      {
        get
        {
          return this.list_0;
        }
      }
    }

    private class Class481
    {
      private double double_0;
      private DxfMText dxfMText_0;
      private DxfInsert dxfInsert_0;
      private Bounds3D bounds3D_0;

      public double Height
      {
        get
        {
          return this.double_0;
        }
        set
        {
          this.double_0 = value;
        }
      }

      public DxfMText Text
      {
        get
        {
          return this.dxfMText_0;
        }
        set
        {
          this.dxfMText_0 = value;
        }
      }

      public DxfInsert Insert
      {
        get
        {
          return this.dxfInsert_0;
        }
        set
        {
          this.dxfInsert_0 = value;
        }
      }

      public Bounds3D InsertBounds
      {
        get
        {
          return this.bounds3D_0;
        }
        set
        {
          this.bounds3D_0 = value;
        }
      }
    }
  }
}
