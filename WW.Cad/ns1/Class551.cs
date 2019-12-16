// Decompiled with JetBrains decompiler
// Type: ns1.Class551
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;
using WW.Collections.Generic;

namespace ns1
{
  internal class Class551 : IGraphCloneable
  {
    private WW.Math.Vector3D vector3D_0 = WW.Math.Vector3D.XAxis;
    private Class429 class429_0 = new Class429();
    private Class912 class912_0 = new Class912();
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private TableFlowDirection? nullable_0 = new TableFlowDirection?(TableFlowDirection.Down);
    private Class984 class984_0 = new Class984();
    private Class984 class984_1 = new Class984();
    private Class984 class984_2 = new Class984();
    private DxfTableBorderOverrides dxfTableBorderOverrides_0 = new DxfTableBorderOverrides();
    private DxfTableBorderOverrides dxfTableBorderOverrides_1 = new DxfTableBorderOverrides();
    private DxfTableBorderOverrides dxfTableBorderOverrides_2 = new DxfTableBorderOverrides();
    private DxfTableBorderOverrides dxfTableBorderOverrides_3 = new DxfTableBorderOverrides();
    private DxfTableBorderOverrides dxfTableBorderOverrides_4 = new DxfTableBorderOverrides();
    private DxfTableBorderOverrides dxfTableBorderOverrides_5 = new DxfTableBorderOverrides();
    private int int_0 = 22;
    private double? nullable_1;
    private double? nullable_2;
    private bool? nullable_3;
    private bool? nullable_4;
    private bool bool_0;

    public Class551(DxfTableStyle tableStyle)
      : this()
    {
      if (tableStyle == null)
        throw new ArgumentNullException(nameof (tableStyle));
      this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) tableStyle);
    }

    internal Class551()
    {
      this.class429_0.Added += new ItemEventHandler<Class430>(this.method_19);
      this.class429_0.Removed += new ItemEventHandler<Class430>(this.method_17);
      this.class429_0.Set += new ItemSetEventHandler<Class430>(this.method_18);
      this.class912_0.Added += new ItemEventHandler<Class736>(this.method_14);
      this.class912_0.Removed += new ItemEventHandler<Class736>(this.method_13);
      this.class912_0.Set += new ItemSetEventHandler<Class736>(this.method_16);
    }

    public WW.Math.Vector3D HorizontalDirection
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        this.vector3D_0 = value;
      }
    }

    public Class429 Rows
    {
      get
      {
        return this.class429_0;
      }
    }

    public int RowCount
    {
      get
      {
        return this.class429_0.Count;
      }
      set
      {
        this.method_7(value, true);
      }
    }

    public Class912 Columns
    {
      get
      {
        return this.class912_0;
      }
    }

    public int ColumnCount
    {
      get
      {
        return this.class912_0.Count;
      }
      set
      {
        this.method_8(value, true);
      }
    }

    public DxfTableStyle TableStyle
    {
      get
      {
        return (DxfTableStyle) this.dxfObjectReference_0.Value;
      }
      set
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public TableFlowDirection? FlowDirection
    {
      get
      {
        return this.nullable_0;
      }
      set
      {
        this.nullable_0 = value;
        TableFlowDirection tableFlowDirection = this.TableStyle != null ? this.TableStyle.FlowDirection : TableFlowDirection.Down;
        if (this.nullable_0.HasValue)
          tableFlowDirection = this.nullable_0.Value;
        if (tableFlowDirection == TableFlowDirection.Up)
          this.int_0 &= -17;
        else
          this.int_0 |= 16;
      }
    }

    public double? HorizontalCellMargin
    {
      get
      {
        return this.nullable_1;
      }
      set
      {
        this.nullable_1 = value;
      }
    }

    public double? VerticalCellMargin
    {
      get
      {
        return this.nullable_2;
      }
      set
      {
        this.nullable_2 = value;
      }
    }

    public bool? SuppressTitle
    {
      get
      {
        return this.nullable_3;
      }
      set
      {
        this.nullable_3 = value;
        if (!this.nullable_3.HasValue ? this.TableStyle != null && this.TableStyle.SuppressTitle : this.nullable_3.Value)
          this.int_0 |= 32;
        else
          this.int_0 &= -33;
      }
    }

    public bool? SuppressHeaderRow
    {
      get
      {
        return this.nullable_4;
      }
      set
      {
        this.nullable_4 = value;
      }
    }

    public Class984 TitleRowCellStyle
    {
      get
      {
        return this.class984_0;
      }
    }

    public Class984 HeaderRowCellStyle
    {
      get
      {
        return this.class984_1;
      }
    }

    public Class984 DataRowCellStyle
    {
      get
      {
        return this.class984_2;
      }
    }

    public DxfTableBorderOverrides BorderInsideHorizontal
    {
      get
      {
        return this.dxfTableBorderOverrides_0;
      }
      set
      {
        this.dxfTableBorderOverrides_0 = value;
      }
    }

    public DxfTableBorderOverrides BorderInsideVertical
    {
      get
      {
        return this.dxfTableBorderOverrides_1;
      }
      set
      {
        this.dxfTableBorderOverrides_1 = value;
      }
    }

    public DxfTableBorderOverrides BorderTop
    {
      get
      {
        return this.dxfTableBorderOverrides_2;
      }
      set
      {
        this.dxfTableBorderOverrides_2 = value;
      }
    }

    public DxfTableBorderOverrides BorderRight
    {
      get
      {
        return this.dxfTableBorderOverrides_3;
      }
      set
      {
        this.dxfTableBorderOverrides_3 = value;
      }
    }

    public DxfTableBorderOverrides BorderBottom
    {
      get
      {
        return this.dxfTableBorderOverrides_4;
      }
      set
      {
        this.dxfTableBorderOverrides_4 = value;
      }
    }

    public DxfTableBorderOverrides BorderLeft
    {
      get
      {
        return this.dxfTableBorderOverrides_5;
      }
      set
      {
        this.dxfTableBorderOverrides_5 = value;
      }
    }

    public void method_0(DxfTable table, DxfTableContent tableContent)
    {
      this.vector3D_0 = table.HorizontalDirection;
      int num = tableContent.RowCount;
      if (table.BreakData != null && table.BreakData.OptionFlags != TableBreakOptionFlags.None && table.BreakData.RowRanges.Count > 0)
        num = table.BreakData.RowRanges[0].EndRowIndex + 1;
      this.method_7(num, false);
      this.method_8(tableContent.ColumnCount, false);
      if (tableContent.TableStyle == null)
        throw new ArgumentException("Table style is not set on table content.");
      this.TableStyle = tableContent.TableStyle;
      this.FlowDirection = tableContent.FlowDirection;
      this.SuppressTitle = tableContent.SuppressTitle == this.TableStyle.SuppressTitle ? new bool?() : new bool?(tableContent.SuppressTitle);
      this.SuppressHeaderRow = tableContent.SuppressHeaderRow == this.TableStyle.SuppressHeaderRow ? new bool?() : new bool?(tableContent.SuppressHeaderRow);
      this.VerticalCellMargin = !tableContent.CellStyleOverrides.OverrideVerticalMargin ? new double?() : new double?(tableContent.CellStyleOverrides.VerticalMargin);
      this.HorizontalCellMargin = !tableContent.CellStyleOverrides.OverrideHorizontalMargin ? new double?() : new double?(tableContent.CellStyleOverrides.HorizontalMargin);
      for (int rowIndex = 0; rowIndex < this.RowCount; ++rowIndex)
      {
        Class430 class430 = this.class429_0[rowIndex];
        DxfTableRow row = tableContent.Rows[rowIndex];
        class430.Height = row.Height;
        for (int columnIndex = 0; columnIndex < this.ColumnCount; ++columnIndex)
        {
          Class1026 cell1 = class430.Cells[columnIndex];
          DxfTableCell cell2 = row.Cells[columnIndex];
          TableCellContentType tableCellContentType1 = TableCellContentType.Value;
          DxfTableCellContent tableCellContent = (DxfTableCellContent) null;
          DxfTableCellStyle cellStyle = this.GetCellStyle(rowIndex, columnIndex);
          TableCellContentType tableCellContentType2;
          if (cell2.Contents.Count > 0)
          {
            tableCellContentType1 = TableCellContentType.Value;
            tableCellContentType1 = TableCellContentType.Value;
            tableCellContent = cell2.Contents[0];
            tableCellContentType2 = tableCellContent.ContentType;
            switch (tableCellContentType2)
            {
              case TableCellContentType.Value:
              case TableCellContentType.Field:
                break;
              case TableCellContentType.Block:
                cell1.CellType = Enum47.const_2;
                cell1.Value.method_0(DxfValueFormat.GeneralInstance);
                cell1.Value.method_1((object) null);
                cell1.Value.method_2((string) null);
                cell1.AutoFit = table.GetAutoScale(rowIndex, columnIndex, -1);
                cell1.BlockScale = table.GetBlockScale(rowIndex, columnIndex, -1);
                cell1.Rotation = table.GetRotation(rowIndex, columnIndex, -1);
                if (tableCellContent != null)
                {
                  cell1.BlockOrField = (DxfHandledObject) (tableCellContent.ValueObject as DxfBlock);
                  cell1.AutoFit = table.GetAutoScale(rowIndex, columnIndex, 0);
                  cell1.BlockScale = table.GetBlockScale(rowIndex, columnIndex, 0);
                  cell1.Rotation = table.GetRotation(rowIndex, columnIndex, 0);
                  goto label_16;
                }
                else
                  goto label_16;
              default:
                goto label_16;
            }
          }
          else
          {
            tableCellContentType1 = TableCellContentType.Value;
            tableCellContentType2 = TableCellContentType.Value;
          }
          cell1.CellType = Enum47.const_1;
          if (tableCellContent != null)
          {
            cell1.BlockOrField = tableCellContentType2 != TableCellContentType.Field ? (DxfHandledObject) null : tableCellContent.ValueObject;
            cell1.Value.CopyFromShallow(tableCellContent.Value);
            double? rotationOverride = table.GetRotationOverride(rowIndex, columnIndex, 0, cellStyle);
            cell1.Rotation = rotationOverride.HasValue ? rotationOverride.Value : 0.0;
            cell1.TextStyle = table.GetTextStyleOverride(rowIndex, columnIndex, 0, cellStyle);
            cell1.TextHeight = table.GetTextHeightOverride(rowIndex, columnIndex, 0, cellStyle);
          }
          else
          {
            cell1.BlockOrField = (DxfHandledObject) null;
            if (cell2.Contents.Count > 0)
              cell1.Value.CopyFromShallow(cell2.Contents[0].Value);
            double? rotationOverride = table.GetRotationOverride(rowIndex, columnIndex, -1, cellStyle);
            cell1.Rotation = rotationOverride.HasValue ? rotationOverride.Value : 0.0;
            cell1.TextStyle = table.GetTextStyleOverride(rowIndex, columnIndex, -1, cellStyle);
            cell1.TextHeight = table.GetTextHeightOverride(rowIndex, columnIndex, -1, cellStyle);
          }
label_16:
          cell1.CellAlignment = table.GetCellAlignmentOverride(rowIndex, columnIndex, -1, cellStyle);
          Color? contentColorOverride = table.GetContentColorOverride(rowIndex, columnIndex, -1, cellStyle);
          cell1.ContentColor = contentColorOverride.HasValue ? new Color?(contentColorOverride.Value) : new Color?();
          Color? backColor = table.GetBackColor(rowIndex, columnIndex);
          if (backColor.HasValue)
          {
            cell1.BackColor = new Color?(backColor.Value);
            cell1.IsBackColorEnabled = new bool?(true);
          }
          else
          {
            cell1.BackColor = new Color?();
            cell1.IsBackColorEnabled = new bool?();
          }
          for (int borderIndex = 0; borderIndex < 4; ++borderIndex)
          {
            DxfTableBorder dxfTableBorder = cell2.CellStyleOverrides.method_21(borderIndex + 2);
            DxfTableBorderOverrides tableBorderOverrides = cell1.method_6(borderIndex);
            tableBorderOverrides.Color = !dxfTableBorder.OverrideColor ? new Color?() : new Color?(dxfTableBorder.Color);
            tableBorderOverrides.LineWeight = !dxfTableBorder.OverrideLineWeight ? new short?() : new short?(dxfTableBorder.LineWeight);
            tableBorderOverrides.Visible = !dxfTableBorder.OverrideVisibility ? new bool?() : new bool?(dxfTableBorder.Visible);
          }
        }
      }
      for (int index = 0; index < this.ColumnCount; ++index)
        this.class912_0[index].Width = tableContent.Columns[index].Width;
      foreach (DxfTableCellRange mergedCellRange in (List<DxfTableCellRange>) tableContent.MergedCellRanges)
      {
        if ((mergedCellRange.TopRowIndex != mergedCellRange.BottomRowIndex || mergedCellRange.LeftColumnIndex != mergedCellRange.RightColumnIndex) && (mergedCellRange.TopRowIndex < this.RowCount && mergedCellRange.LeftColumnIndex < this.ColumnCount))
        {
          Class1026 cell = this.class429_0[mergedCellRange.TopRowIndex].Cells[mergedCellRange.LeftColumnIndex];
          cell.MergedCellCountHorizontal = mergedCellRange.RightColumnIndex - mergedCellRange.LeftColumnIndex + 1;
          cell.MergedCellCountVertical = mergedCellRange.BottomRowIndex - mergedCellRange.TopRowIndex + 1;
        }
      }
    }

    public bool method_1(int rowIndex1, int columnIndex1, int rowIndex2, int columnIndex2)
    {
      int mergedCellBlockTopRowIndex1;
      int mergedCellBlockLeftColumnIndex1;
      bool flag1 = this.method_3(rowIndex1, columnIndex1, out mergedCellBlockTopRowIndex1, out mergedCellBlockLeftColumnIndex1);
      int mergedCellBlockTopRowIndex2;
      int mergedCellBlockLeftColumnIndex2;
      bool flag2 = this.method_3(rowIndex2, columnIndex2, out mergedCellBlockTopRowIndex2, out mergedCellBlockLeftColumnIndex2);
      if (flag1 && flag2 && mergedCellBlockTopRowIndex1 == mergedCellBlockTopRowIndex2)
        return mergedCellBlockLeftColumnIndex1 == mergedCellBlockLeftColumnIndex2;
      return false;
    }

    public bool method_2(int rowIndex, int columnIndex)
    {
      int mergedCellBlockTopRowIndex;
      int mergedCellBlockLeftColumnIndex;
      return this.method_3(rowIndex, columnIndex, out mergedCellBlockTopRowIndex, out mergedCellBlockLeftColumnIndex);
    }

    public bool method_3(
      int rowIndex,
      int columnIndex,
      out int mergedCellBlockTopRowIndex,
      out int mergedCellBlockLeftColumnIndex)
    {
      bool flag = false;
      mergedCellBlockTopRowIndex = -1;
      mergedCellBlockLeftColumnIndex = -1;
      for (int index1 = 0; index1 <= rowIndex; ++index1)
      {
        for (int index2 = 0; index2 <= columnIndex; ++index2)
        {
          Class1026 cell = this.class429_0[index1].Cells[index2];
          if ((cell.MergedCellCountHorizontal != 1 || cell.MergedCellCountVertical != 1) && (rowIndex >= index1 && rowIndex <= index1 + cell.MergedCellCountVertical - 1) && (columnIndex >= index2 && columnIndex <= index2 + cell.MergedCellCountHorizontal - 1))
          {
            flag = true;
            mergedCellBlockTopRowIndex = index1;
            mergedCellBlockLeftColumnIndex = index2;
            break;
          }
        }
      }
      return flag;
    }

    public DxfTableCellStyle GetCellStyle(int rowIndex, int columnIndex)
    {
      DxfTableCellStyle dxfTableCellStyle = (DxfTableCellStyle) null;
      if (rowIndex == 0)
        dxfTableCellStyle = !this.method_4() ? this.TableStyle.TitleCellStyle : (!this.method_5() ? this.TableStyle.HeaderCellStyle : this.TableStyle.DataCellStyle);
      else if (rowIndex == 1)
        dxfTableCellStyle = !this.method_4() ? (!this.method_5() ? this.TableStyle.HeaderCellStyle : this.TableStyle.DataCellStyle) : this.TableStyle.DataCellStyle;
      else if (rowIndex > 1)
        dxfTableCellStyle = this.TableStyle.DataCellStyle;
      return dxfTableCellStyle;
    }

    public bool method_4()
    {
      if (this.nullable_3.HasValue)
        return this.nullable_3.Value;
      return this.TableStyle.SuppressTitle;
    }

    public bool method_5()
    {
      if (this.nullable_4.HasValue)
        return this.nullable_4.Value;
      return this.TableStyle.SuppressHeaderRow;
    }

    public TableFlowDirection method_6()
    {
      if (this.nullable_0.HasValue)
        return this.nullable_0.Value;
      return this.TableStyle.FlowDirection;
    }

    public IGraphCloneable Clone(CloneContext cloneContext)
    {
      Class551 class551 = (Class551) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (class551 == null)
      {
        class551 = new Class551();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) class551);
        class551.CopyFrom(this, cloneContext);
      }
      return (IGraphCloneable) class551;
    }

    public void CopyFrom(Class551 from, CloneContext cloneContext)
    {
      this.bool_0 = true;
      this.vector3D_0 = from.vector3D_0;
      this.TableStyle = from.TableStyle != null ? Class906.smethod_4(cloneContext, from.TableStyle) : (DxfTableStyle) null;
      this.nullable_0 = from.nullable_0;
      this.nullable_1 = from.nullable_1;
      this.nullable_2 = from.nullable_2;
      this.nullable_3 = from.nullable_3;
      this.nullable_4 = from.nullable_4;
      this.class984_0.CopyFrom(from.class984_0, cloneContext);
      this.class984_1.CopyFrom(from.class984_1, cloneContext);
      this.class984_2.CopyFrom(from.class984_2, cloneContext);
      this.dxfTableBorderOverrides_0.CopyFrom(from.dxfTableBorderOverrides_0, cloneContext);
      this.dxfTableBorderOverrides_1.CopyFrom(from.dxfTableBorderOverrides_1, cloneContext);
      this.dxfTableBorderOverrides_2.CopyFrom(from.dxfTableBorderOverrides_2, cloneContext);
      this.dxfTableBorderOverrides_3.CopyFrom(from.dxfTableBorderOverrides_3, cloneContext);
      this.dxfTableBorderOverrides_4.CopyFrom(from.dxfTableBorderOverrides_4, cloneContext);
      this.dxfTableBorderOverrides_5.CopyFrom(from.dxfTableBorderOverrides_5, cloneContext);
      this.int_0 = from.int_0;
      foreach (Class430 class430 in (ActiveList<Class430>) from.class429_0)
        this.class429_0.Add(class430.Clone(cloneContext));
      foreach (Class736 column in (ActiveList<Class736>) from.Columns)
        this.class912_0.Add(column.Clone(cloneContext));
      this.bool_0 = false;
    }

    public bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      bool flag = true;
      for (int rowIndex = 0; rowIndex < this.RowCount; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < this.ColumnCount; ++columnIndex)
        {
          Class1026 cell = this.class429_0[rowIndex].Cells[columnIndex];
          if (rowIndex > 0 && cell.BorderTop.method_0(DxfVersion.Dxf27) && this.class429_0[rowIndex - 1].Cells[columnIndex].BorderBottom.method_0(DxfVersion.Dxf27))
          {
            DxfMessage dxfMessage = this.method_20(rowIndex, columnIndex, cell, cell.BorderTop, TableCellEdgeFlags.Top);
            messages.Add(dxfMessage);
            flag = false;
          }
          if (rowIndex < this.RowCount - 1 && cell.BorderBottom.method_0(DxfVersion.Dxf27) && this.class429_0[rowIndex + 1].Cells[columnIndex].BorderTop.method_0(DxfVersion.Dxf27))
          {
            DxfMessage dxfMessage = this.method_20(rowIndex, columnIndex, cell, cell.BorderBottom, TableCellEdgeFlags.Bottom);
            messages.Add(dxfMessage);
            flag = false;
          }
          if (columnIndex > 0 && cell.BorderLeft.method_0(DxfVersion.Dxf27) && this.class429_0[rowIndex].Cells[columnIndex - 1].BorderRight.method_0(DxfVersion.Dxf27))
          {
            DxfMessage dxfMessage = this.method_20(rowIndex, columnIndex, cell, cell.BorderLeft, TableCellEdgeFlags.Left);
            messages.Add(dxfMessage);
            flag = false;
          }
          if (columnIndex < this.ColumnCount - 1 && cell.BorderRight.method_0(DxfVersion.Dxf27) && this.class429_0[rowIndex].Cells[columnIndex + 1].BorderLeft.method_0(DxfVersion.Dxf27))
          {
            DxfMessage dxfMessage = this.method_20(rowIndex, columnIndex, cell, cell.BorderRight, TableCellEdgeFlags.Right);
            messages.Add(dxfMessage);
            flag = false;
          }
        }
      }
      return flag;
    }

    internal int TableFlags
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

    internal void method_7(int value, bool mergeTitleRowCells)
    {
      int count = this.class912_0.Count;
      if (value > this.class429_0.Count)
      {
        this.bool_0 = true;
        int num = value - this.class429_0.Count;
        for (int index1 = 0; index1 < num; ++index1)
        {
          Class430 class430 = new Class430();
          for (int index2 = 0; index2 < count; ++index2)
            class430.Cells.Add(new Class1026());
          this.class429_0.Add(class430);
          if (mergeTitleRowCells && this.class429_0.Count == 1 && (count > 1 && !this.method_4()))
            class430.Cells[0].MergedCellCountHorizontal = (int) (short) count;
        }
        this.bool_0 = false;
      }
      else
      {
        if (value >= this.class429_0.Count)
          return;
        this.bool_0 = true;
        int num = this.class429_0.Count - value;
        for (int index = 0; index < num; ++index)
          this.class429_0.RemoveAt(value);
        this.bool_0 = false;
      }
    }

    internal void method_8(int value, bool mergeTitleRowCells)
    {
      if (value > this.class912_0.Count)
      {
        this.bool_0 = true;
        int num1 = value - this.class912_0.Count;
        for (int index = 0; index < num1; ++index)
          this.class912_0.Add(new Class736());
        int num2 = 0;
        foreach (Class430 class430 in (ActiveList<Class430>) this.class429_0)
        {
          for (int index = 0; index < num1; ++index)
            class430.Cells.Add(new Class1026());
          if (mergeTitleRowCells && num2 == 0 && !this.method_4())
            class430.Cells[0].MergedCellCountHorizontal = (int) (short) this.class912_0.Count;
          ++num2;
        }
        this.bool_0 = false;
      }
      else
      {
        if (value >= this.class912_0.Count)
          return;
        this.bool_0 = true;
        int num = this.class912_0.Count - value;
        for (int index = 0; index < num; ++index)
          this.class912_0.RemoveAt(value);
        foreach (Class430 class430 in (ActiveList<Class430>) this.class429_0)
        {
          for (int index = 0; index < num; ++index)
            class430.Cells.RemoveAt(value);
        }
        this.bool_0 = false;
      }
    }

    internal void method_9(
      DxfVersion version,
      Class1026 cell,
      int rowIndex,
      int columnIndex,
      DxfXRecord cellRoundTripData,
      out double checksum,
      out int overrideFlags,
      out int extendedFlags)
    {
      checksum = this.method_10(cell.Value.Format._FormatString);
      byte edgeFlags;
      byte virtualEdgeFlags;
      int borderTopFlags;
      int borderRightFlags;
      int borderBottomFlags;
      int borderLeftFlags;
      this.method_11(version, cell, rowIndex, columnIndex, out edgeFlags, out virtualEdgeFlags, out overrideFlags, out borderTopFlags, out borderRightFlags, out borderBottomFlags, out borderLeftFlags);
      extendedFlags = cell.ExtendedFlags;
      cell.Value.Write(cellRoundTripData);
    }

    private double method_10(string s)
    {
      double num = 0.0;
      for (int index = 0; index < s.Length; ++index)
        num += (double) ((int) s[index] * (index + 1));
      return num;
    }

    internal void method_11(
      DxfVersion version,
      Class1026 cell,
      int rowIndex,
      int columnIndex,
      out byte edgeFlags,
      out byte virtualEdgeFlags,
      out int overrideFlags,
      out int borderTopFlags,
      out int borderRightFlags,
      out int borderBottomFlags,
      out int borderLeftFlags)
    {
      edgeFlags = (byte) 0;
      virtualEdgeFlags = (byte) 0;
      borderTopFlags = this.method_12(version, cell.BorderTop);
      if (borderTopFlags != 0)
        edgeFlags |= (byte) 1;
      else if (rowIndex > 0 && this.Rows[rowIndex - 1].Cells[columnIndex].BorderBottom.method_0(version))
      {
        edgeFlags |= (byte) 1;
        virtualEdgeFlags |= (byte) 1;
      }
      borderRightFlags = this.method_12(version, cell.BorderRight);
      if (borderRightFlags != 0)
        edgeFlags |= (byte) 2;
      else if (columnIndex < this.ColumnCount - 1 && this.Rows[rowIndex].Cells[columnIndex + 1].BorderLeft.method_0(version))
      {
        edgeFlags |= (byte) 2;
        virtualEdgeFlags |= (byte) 2;
      }
      borderBottomFlags = this.method_12(version, cell.BorderBottom);
      if (borderBottomFlags != 0)
        edgeFlags |= (byte) 4;
      else if (rowIndex < this.RowCount - 1 && this.Rows[rowIndex + 1].Cells[columnIndex].BorderTop.method_0(version))
      {
        edgeFlags |= (byte) 4;
        virtualEdgeFlags |= (byte) 4;
      }
      borderLeftFlags = this.method_12(version, cell.BorderLeft);
      if (borderLeftFlags != 0)
        edgeFlags |= (byte) 8;
      else if (columnIndex > 0 && this.Rows[rowIndex].Cells[columnIndex - 1].BorderRight.method_0(version))
      {
        edgeFlags |= (byte) 8;
        virtualEdgeFlags |= (byte) 8;
      }
      overrideFlags = borderTopFlags << 6 | borderRightFlags << 7 | borderBottomFlags << 8 | borderLeftFlags << 9;
      if (cell.CellAlignment.HasValue)
        overrideFlags |= 1;
      if (cell.IsBackColorEnabled.HasValue)
        overrideFlags |= 2;
      if (cell.BackColor.HasValue)
        overrideFlags |= 4;
      if (cell.ContentColor.HasValue)
        overrideFlags |= 8;
      if (cell.TextStyle != null)
        overrideFlags |= 16;
      if (!cell.TextHeight.HasValue)
        return;
      overrideFlags |= 32;
    }

    private int method_12(DxfVersion version, DxfTableBorderOverrides overrides)
    {
      int num = 0;
      if (overrides.Color.HasValue)
        num |= 1;
      if (overrides.LineWeight.HasValue)
        num |= 16;
      if (overrides.Visible.HasValue)
        num |= 256;
      return num;
    }

    private void method_13(object sender, int index, Class736 item)
    {
      if (this.bool_0)
        return;
      foreach (Class430 class430 in (ActiveList<Class430>) this.class429_0)
        class430.Cells.RemoveAt(index);
    }

    private void method_14(object sender, int index, Class736 item)
    {
      this.method_15(index);
    }

    private void method_15(int index)
    {
      if (this.bool_0)
        return;
      foreach (Class430 class430 in (ActiveList<Class430>) this.class429_0)
        class430.Cells.Insert(index, new Class1026());
    }

    private void method_16(object sender, int index, Class736 oldItem, Class736 newItem)
    {
      this.method_15(index);
    }

    private void method_17(object sender, int index, Class430 item)
    {
      item.method_0((Class551) null);
    }

    private void method_18(object sender, int index, Class430 oldItem, Class430 newItem)
    {
      oldItem.method_0((Class551) null);
      this.InitRowCells(index, newItem);
    }

    private void method_19(object sender, int index, Class430 item)
    {
      this.InitRowCells(index, item);
    }

    private void InitRowCells(int index, Class430 item)
    {
      if (!this.bool_0)
      {
        int count = this.class912_0.Count;
        if (item.Cells.Count < count)
        {
          int num = count - item.Cells.Count;
          for (int index1 = 0; index1 < num; ++index1)
            item.Cells.Add(new Class1026());
        }
        else if (item.Cells.Count > count)
          throw new ArgumentException("More cells in row than ColumnCount.");
        if (index == 0 && !this.method_4() && count > 1)
          item.Cells[0].MergedCellCountHorizontal = (int) (short) count;
      }
      item.method_0(this);
    }

    private DxfMessage method_20(
      int rowIndex,
      int columnIndex,
      Class1026 cell,
      DxfTableBorderOverrides border,
      TableCellEdgeFlags edgeFlags)
    {
      return new DxfMessage(DxfStatus.TableSharedBorderOverrideConflict, Severity.Error, nameof (cell), (object) cell) { Parameters = { { nameof (border), (object) border }, { "top", (object) edgeFlags }, { "row", (object) rowIndex }, { "column", (object) columnIndex } } };
    }
  }
}
