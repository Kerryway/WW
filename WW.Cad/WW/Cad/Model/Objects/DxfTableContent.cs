// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfTableContent
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using ns1;
using ns28;
using System;
using System.Collections.Generic;
using WW.Cad.IO;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model.Objects
{
  public class DxfTableContent : DxfFormattedTableData
  {
    private DxfObjectReference dxfObjectReference_3 = DxfObjectReference.Null;

    public DxfTableStyle TableStyle
    {
      get
      {
        return (DxfTableStyle) this.dxfObjectReference_3.Value;
      }
      set
      {
        this.dxfObjectReference_3 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public bool SuppressTitle
    {
      get
      {
        if (this.Rows.Count == 0)
          return false;
        DxfTableCellStyle cellStyle = this.Rows[0].CellStyle;
        if (cellStyle != null)
          return cellStyle.Name != "_TITLE";
        return true;
      }
      set
      {
        if (value == this.SuppressTitle || this.Rows.Count <= 0)
          return;
        if (value)
        {
          for (int index = 0; index < Math.Min(1, this.Rows.Count - 1); ++index)
            this.Rows[index].CellStyle = this.Rows[index + 1].CellStyle;
        }
        else
        {
          for (int index = Math.Min(1, this.Rows.Count - 1); index > 0; --index)
            this.Rows[index].CellStyle = this.Rows[index - 1].CellStyle;
          this.Rows[0].CellStyle = this.TableStyle.TitleCellStyle;
        }
      }
    }

    public bool SuppressHeaderRow
    {
      get
      {
        if (this.Rows.Count == 0)
          return false;
        bool flag = false;
        if (this.SuppressTitle)
        {
          DxfTableCellStyle cellStyle = this.Rows[0].CellStyle;
          flag = cellStyle == null || cellStyle.Name != "_HEADER";
        }
        else if (this.Rows.Count > 1)
        {
          DxfTableCellStyle cellStyle = this.Rows[1].CellStyle;
          flag = cellStyle == null || cellStyle.Name != "_HEADER";
        }
        return flag;
      }
      set
      {
        if (value == this.SuppressHeaderRow || this.Rows.Count <= 0)
          return;
        int index = this.SuppressTitle ? 0 : 1;
        if (this.Rows.Count <= index)
          return;
        if (value)
          this.Rows[index].CellStyle = this.TableStyle.HeaderCellStyle;
        else
          this.Rows[index].CellStyle = this.Rows.Count > index + 1 ? this.Rows[index + 1].CellStyle : this.TableStyle.DataCellStyle;
      }
    }

    public TableFlowDirection? FlowDirection
    {
      get
      {
        if ((this.CellStyleOverrides.CellStylePropertyOverrideFlags & TableCellStylePropertyFlags.FlowDirectionBottomToTop) == TableCellStylePropertyFlags.None)
          return new TableFlowDirection?();
        return new TableFlowDirection?(this.CellStyleOverrides.FlowDirection);
      }
      set
      {
        if (value.HasValue)
        {
          this.CellStyleOverrides.CellStylePropertyOverrideFlags |= TableCellStylePropertyFlags.FlowDirectionBottomToTop;
          this.CellStyleOverrides.FlowDirection = value.Value;
        }
        else
        {
          this.CellStyleOverrides.CellStylePropertyOverrideFlags &= ~TableCellStylePropertyFlags.FlowDirectionBottomToTop;
          this.CellStyleOverrides.FlowDirection = TableFlowDirection.Down;
        }
      }
    }

    public DxfTableCellStyle GetCellStyle(int rowIndex, int columnIndex)
    {
      DxfTableCellStyle dxfTableCellStyle = (DxfTableCellStyle) null;
      if (rowIndex == -1 && columnIndex != -1)
      {
        if (columnIndex < this.Columns.Count)
          dxfTableCellStyle = this.Columns[columnIndex].CellStyle;
      }
      else if (rowIndex != -1 && columnIndex == -1)
      {
        if (rowIndex < this.Rows.Count)
          dxfTableCellStyle = this.Rows[rowIndex].CellStyle;
      }
      else if (rowIndex != -1 && columnIndex != -1)
        dxfTableCellStyle = this.Rows[rowIndex].Cells[columnIndex].CellStyle ?? this.GetCellStyle(rowIndex, -1);
      if (dxfTableCellStyle == null)
        dxfTableCellStyle = this.TableStyle.TableCellStyle;
      return dxfTableCellStyle;
    }

    public DxfTableCellContent GetCellContent(
      int rowIndex,
      int columnIndex,
      int cellContentIndex)
    {
      if (cellContentIndex < 0)
        return (DxfTableCellContent) null;
      DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
      DxfTableCellContent tableCellContent = (DxfTableCellContent) null;
      if (cellContentIndex < cell.Contents.Count)
        tableCellContent = cell.Contents[cellContentIndex];
      return tableCellContent;
    }

    public bool GetAutoScale(int rowIndex, int columnIndex, int cellContentIndex)
    {
      bool? nullable = new bool?();
      if (rowIndex >= 0 && columnIndex >= 0 && cellContentIndex >= 0)
      {
        DxfTableCellContent cellContent = this.GetCellContent(rowIndex, columnIndex, cellContentIndex);
        if (cellContent != null && cellContent.Format.OverrideAutoScale)
          nullable = new bool?(cellContent.Format.AutoScale);
      }
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyleOverrides.OverrideAutoScale)
          nullable = new bool?(cell.CellStyleOverrides.AutoScale);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyleOverrides.OverrideAutoScale)
          nullable = new bool?(column.CellStyleOverrides.AutoScale);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyleOverrides.OverrideAutoScale)
          nullable = new bool?(row.CellStyleOverrides.AutoScale);
      }
      if (!nullable.HasValue && this.CellStyleOverrides.OverrideAutoScale)
        nullable = new bool?(this.CellStyleOverrides.AutoScale);
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyle != null && cell.CellStyle.OverrideAutoScale)
          nullable = new bool?(cell.CellStyle.AutoScale);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null && column.CellStyle.OverrideAutoScale)
          nullable = new bool?(column.CellStyle.AutoScale);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null && row.CellStyle.OverrideAutoScale)
          nullable = new bool?(row.CellStyle.AutoScale);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null)
          nullable = new bool?(column.CellStyle.AutoScale);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null)
          nullable = new bool?(row.CellStyle.AutoScale);
      }
      if (!nullable.HasValue)
        nullable = new bool?(this.TableStyle.TableCellStyle.AutoScale);
      return nullable.Value;
    }

    public double GetBlockScale(int rowIndex, int columnIndex, int cellContentIndex)
    {
      double? nullable = new double?();
      if (rowIndex >= 0 && columnIndex >= 0 && cellContentIndex >= 0)
      {
        DxfTableCellContent cellContent = this.GetCellContent(rowIndex, columnIndex, cellContentIndex);
        if (cellContent != null && cellContent.Format.OverrideBlockScale)
          nullable = new double?(cellContent.Format.BlockScale);
      }
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyleOverrides.OverrideBlockScale)
          nullable = new double?(cell.CellStyleOverrides.BlockScale);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyleOverrides.OverrideBlockScale)
          nullable = new double?(column.CellStyleOverrides.BlockScale);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyleOverrides.OverrideBlockScale)
          nullable = new double?(row.CellStyleOverrides.BlockScale);
      }
      if (!nullable.HasValue && this.CellStyleOverrides.OverrideBlockScale)
        nullable = new double?(this.CellStyleOverrides.BlockScale);
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyle != null && cell.CellStyle.OverrideBlockScale)
          nullable = new double?(cell.CellStyle.BlockScale);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null && column.CellStyle.OverrideBlockScale)
          nullable = new double?(column.CellStyle.BlockScale);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null && row.CellStyle.OverrideBlockScale)
          nullable = new double?(row.CellStyle.BlockScale);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null)
          nullable = new double?(column.CellStyle.BlockScale);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null)
          nullable = new double?(row.CellStyle.BlockScale);
      }
      if (!nullable.HasValue)
        nullable = new double?(this.TableStyle.TableCellStyle.BlockScale);
      return nullable.Value;
    }

    public CellAlignment GetCellAlignment(
      int rowIndex,
      int columnIndex,
      int cellContentIndex)
    {
      CellAlignment? nullable = this.GetCellAlignmentOverride(rowIndex, columnIndex, cellContentIndex, (DxfTableCellStyle) null);
      if (!nullable.HasValue)
        nullable = new CellAlignment?(this.TableStyle.TableCellStyle.CellAlignment);
      return nullable.Value;
    }

    public CellAlignment? GetCellAlignmentOverride(
      int rowIndex,
      int columnIndex,
      int cellContentIndex,
      DxfTableCellStyle baseCellStyle)
    {
      CellAlignment? nullable = new CellAlignment?();
      if (rowIndex >= 0 && columnIndex >= 0 && cellContentIndex >= 0)
      {
        DxfTableCellContent cellContent = this.GetCellContent(rowIndex, columnIndex, cellContentIndex);
        if (cellContent != null && cellContent.Format.OverrideCellAlignment)
          nullable = new CellAlignment?(cellContent.Format.CellAlignment);
      }
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyleOverrides.OverrideCellAlignment)
          nullable = new CellAlignment?(cell.CellStyleOverrides.CellAlignment);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyleOverrides.OverrideCellAlignment)
          nullable = new CellAlignment?(column.CellStyleOverrides.CellAlignment);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyleOverrides.OverrideCellAlignment)
          nullable = new CellAlignment?(row.CellStyleOverrides.CellAlignment);
      }
      if (!nullable.HasValue && this.CellStyleOverrides.OverrideCellAlignment)
        nullable = new CellAlignment?(this.CellStyleOverrides.CellAlignment);
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyle != null && cell.CellStyle.OverrideCellAlignment)
          nullable = new CellAlignment?(cell.CellStyle.CellAlignment);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null && column.CellStyle.OverrideCellAlignment)
          nullable = new CellAlignment?(column.CellStyle.CellAlignment);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null && row.CellStyle.OverrideCellAlignment)
          nullable = new CellAlignment?(row.CellStyle.CellAlignment);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null && column.CellStyle != baseCellStyle)
          nullable = new CellAlignment?(column.CellStyle.CellAlignment);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null && row.CellStyle != baseCellStyle)
          nullable = new CellAlignment?(row.CellStyle.CellAlignment);
      }
      return nullable;
    }

    public Color? GetBackColor(int rowIndex, int columnIndex)
    {
      Color? nullable = new Color?();
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyleOverrides.OverrideBackColor && cell.CellStyleOverrides.IsBackColorEnabled)
          nullable = new Color?(cell.CellStyleOverrides.BackColor);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyleOverrides.OverrideBackColor && column.CellStyleOverrides.IsBackColorEnabled)
          nullable = new Color?(column.CellStyleOverrides.BackColor);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyleOverrides.OverrideBackColor && row.CellStyleOverrides.IsBackColorEnabled)
          nullable = new Color?(row.CellStyleOverrides.BackColor);
      }
      if (!nullable.HasValue && this.CellStyleOverrides.OverrideBackColor && this.CellStyleOverrides.IsBackColorEnabled)
        nullable = new Color?(this.CellStyleOverrides.BackColor);
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyle != null && cell.CellStyle.OverrideBackColor && cell.CellStyle.IsBackColorEnabled)
          nullable = new Color?(cell.CellStyle.BackColor);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null && column.CellStyle.OverrideBackColor && column.CellStyle.IsBackColorEnabled)
          nullable = new Color?(column.CellStyle.BackColor);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null && row.CellStyle.OverrideBackColor && row.CellStyle.IsBackColorEnabled)
          nullable = new Color?(row.CellStyle.BackColor);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null && column.CellStyle.IsBackColorEnabled)
          nullable = new Color?(column.CellStyle.BackColor);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null && row.CellStyle.IsBackColorEnabled)
          nullable = new Color?(row.CellStyle.BackColor);
      }
      if (!nullable.HasValue && this.TableStyle.TableCellStyle.OverrideBackColor && this.TableStyle.TableCellStyle.IsBackColorEnabled)
        nullable = new Color?(this.TableStyle.TableCellStyle.BackColor);
      return nullable;
    }

    public double GetTextHeight(int rowIndex, int columnIndex, int cellContentIndex)
    {
      double? nullable = this.GetTextHeightOverride(rowIndex, columnIndex, cellContentIndex, (DxfTableCellStyle) null);
      if (!nullable.HasValue)
        nullable = new double?(this.TableStyle.TableCellStyle.GetTextHeight());
      return nullable.Value;
    }

    public double? GetTextHeightOverride(
      int rowIndex,
      int columnIndex,
      int cellContentIndex,
      DxfTableCellStyle baseCellStyle)
    {
      double? nullable = new double?();
      if (rowIndex >= 0 && columnIndex >= 0 && cellContentIndex >= 0)
      {
        DxfTableCellContent cellContent = this.GetCellContent(rowIndex, columnIndex, cellContentIndex);
        if (cellContent != null)
          nullable = cellContent.Format.GetTextHeightIfOverridden();
      }
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
        nullable = this.Rows[rowIndex].Cells[columnIndex].CellStyleOverrides.GetTextHeightIfOverridden();
      if (!nullable.HasValue && columnIndex >= 0)
        nullable = this.Columns[columnIndex].CellStyleOverrides.GetTextHeightIfOverridden();
      if (!nullable.HasValue && rowIndex >= 0)
        nullable = this.Rows[rowIndex].CellStyleOverrides.GetTextHeightIfOverridden();
      if (!nullable.HasValue)
        nullable = this.CellStyleOverrides.GetTextHeightIfOverridden();
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyle != null)
          nullable = cell.CellStyle.GetTextHeightIfOverridden();
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null)
          nullable = column.CellStyle.GetTextHeightIfOverridden();
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null)
          nullable = row.CellStyle.GetTextHeightIfOverridden();
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null && column.CellStyle != baseCellStyle)
          nullable = new double?(column.CellStyle.GetTextHeight());
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null && row.CellStyle != baseCellStyle)
          nullable = new double?(row.CellStyle.GetTextHeight());
      }
      return nullable;
    }

    public DxfTextStyle GetTextStyle(
      int rowIndex,
      int columnIndex,
      int cellContentIndex)
    {
      return this.GetTextStyleOverride(rowIndex, columnIndex, cellContentIndex, (DxfTableCellStyle) null) ?? this.TableStyle.TableCellStyle.TextStyle;
    }

    public DxfTextStyle GetTextStyleOverride(
      int rowIndex,
      int columnIndex,
      int cellContentIndex,
      DxfTableCellStyle baseCellStyle)
    {
      DxfTextStyle dxfTextStyle = (DxfTextStyle) null;
      if (rowIndex >= 0 && columnIndex >= 0 && cellContentIndex >= 0)
      {
        DxfTableCellContent cellContent = this.GetCellContent(rowIndex, columnIndex, cellContentIndex);
        if (cellContent != null && cellContent.Format.OverrideTextStyle)
          dxfTextStyle = cellContent.Format.TextStyle;
      }
      if (dxfTextStyle == null && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyleOverrides.OverrideTextStyle)
          dxfTextStyle = cell.CellStyleOverrides.TextStyle;
      }
      if (dxfTextStyle == null && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyleOverrides.OverrideTextStyle)
          dxfTextStyle = column.CellStyleOverrides.TextStyle;
      }
      if (dxfTextStyle == null && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyleOverrides.OverrideTextStyle)
          dxfTextStyle = row.CellStyleOverrides.TextStyle;
      }
      if (dxfTextStyle == null && this.CellStyleOverrides.OverrideTextStyle)
        dxfTextStyle = this.CellStyleOverrides.TextStyle;
      if (dxfTextStyle == null && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyle != null && cell.CellStyle.OverrideTextStyle)
          dxfTextStyle = cell.CellStyle.TextStyle;
      }
      if (dxfTextStyle == null && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null && column.CellStyle.OverrideTextStyle)
          dxfTextStyle = column.CellStyle.TextStyle;
      }
      if (dxfTextStyle == null && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null && row.CellStyle.OverrideTextStyle)
          dxfTextStyle = row.CellStyle.TextStyle;
      }
      if (dxfTextStyle == null && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null && column.CellStyle != baseCellStyle && column.CellStyle.TextStyle != null)
          dxfTextStyle = column.CellStyle.TextStyle;
      }
      if (dxfTextStyle == null && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null && row.CellStyle != baseCellStyle && row.CellStyle.TextStyle != null)
          dxfTextStyle = row.CellStyle.TextStyle;
      }
      return dxfTextStyle;
    }

    public Color GetContentColor(int rowIndex, int columnIndex, int cellContentIndex)
    {
      Color? nullable = this.GetContentColorOverride(rowIndex, columnIndex, cellContentIndex, (DxfTableCellStyle) null);
      if (!nullable.HasValue)
        nullable = new Color?(this.TableStyle.TableCellStyle.ContentColor);
      return nullable.Value;
    }

    public Color? GetContentColorOverride(
      int rowIndex,
      int columnIndex,
      int cellContentIndex,
      DxfTableCellStyle baseCellStyle)
    {
      Color? nullable = new Color?();
      if (rowIndex >= 0 && columnIndex >= 0 && cellContentIndex >= 0)
      {
        DxfTableCellContent cellContent = this.GetCellContent(rowIndex, columnIndex, cellContentIndex);
        if (cellContent != null && cellContent.Format.OverrideContentColor)
          nullable = new Color?(cellContent.Format.ContentColor);
      }
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyleOverrides.OverrideContentColor)
          nullable = new Color?(cell.CellStyleOverrides.ContentColor);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyleOverrides.OverrideContentColor)
          nullable = new Color?(column.CellStyleOverrides.ContentColor);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyleOverrides.OverrideContentColor)
          nullable = new Color?(row.CellStyleOverrides.ContentColor);
      }
      if (!nullable.HasValue && this.CellStyleOverrides.OverrideContentColor)
        nullable = new Color?(this.CellStyleOverrides.ContentColor);
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyle != null && cell.CellStyle.OverrideContentColor)
          nullable = new Color?(cell.CellStyle.ContentColor);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null && column.CellStyle.OverrideContentColor)
          nullable = new Color?(column.CellStyle.ContentColor);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null && row.CellStyle.OverrideContentColor)
          nullable = new Color?(row.CellStyle.ContentColor);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null && column.CellStyle != baseCellStyle)
          nullable = new Color?(column.CellStyle.ContentColor);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null && row.CellStyle != baseCellStyle)
          nullable = new Color?(row.CellStyle.ContentColor);
      }
      return nullable;
    }

    public DxfValueFormat GetValueFormat(
      int rowIndex,
      int columnIndex,
      int cellContentIndex)
    {
      DxfValueFormat dxfValueFormat = (DxfValueFormat) null;
      if (rowIndex >= 0 && columnIndex >= 0 && cellContentIndex >= 0)
      {
        DxfTableCellContent cellContent = this.GetCellContent(rowIndex, columnIndex, cellContentIndex);
        if (cellContent != null)
          dxfValueFormat = cellContent.Format.ValueFormat;
      }
      if (dxfValueFormat == null && rowIndex >= 0 && columnIndex >= 0)
        dxfValueFormat = this.Rows[rowIndex].Cells[columnIndex].CellStyleOverrides.ValueFormat;
      if (dxfValueFormat == null && columnIndex >= 0)
        dxfValueFormat = this.Columns[columnIndex].CellStyleOverrides.ValueFormat;
      if (dxfValueFormat == null && rowIndex >= 0)
        dxfValueFormat = this.Rows[rowIndex].CellStyleOverrides.ValueFormat;
      if (dxfValueFormat == null)
        dxfValueFormat = this.CellStyleOverrides.ValueFormat;
      if (dxfValueFormat == null && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyle != null)
          dxfValueFormat = cell.CellStyle.ValueFormat;
      }
      if (dxfValueFormat == null && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null)
          dxfValueFormat = column.CellStyle.ValueFormat;
      }
      if (dxfValueFormat == null && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null)
          dxfValueFormat = row.CellStyle.ValueFormat;
      }
      if (dxfValueFormat == null)
        dxfValueFormat = this.TableStyle.TableCellStyle.ValueFormat;
      return dxfValueFormat;
    }

    public double GetRotation(int rowIndex, int columnIndex, int cellContentIndex)
    {
      double? nullable = this.GetRotationOverride(rowIndex, columnIndex, cellContentIndex, (DxfTableCellStyle) null);
      if (!nullable.HasValue)
        nullable = new double?(this.TableStyle.TableCellStyle.Rotation);
      return nullable.Value;
    }

    public double? GetRotationOverride(
      int rowIndex,
      int columnIndex,
      int cellContentIndex,
      DxfTableCellStyle baseCellStyle)
    {
      double? nullable = new double?();
      if (rowIndex >= 0 && columnIndex >= 0 && cellContentIndex >= 0)
      {
        DxfTableCellContent cellContent = this.GetCellContent(rowIndex, columnIndex, cellContentIndex);
        if (cellContent != null && cellContent.Format.OverrideRotation)
          nullable = new double?(cellContent.Format.Rotation);
      }
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyleOverrides.OverrideRotation)
          nullable = new double?(cell.CellStyleOverrides.Rotation);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyleOverrides.OverrideRotation)
          nullable = new double?(column.CellStyleOverrides.Rotation);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyleOverrides.OverrideRotation)
          nullable = new double?(row.CellStyleOverrides.Rotation);
      }
      if (!nullable.HasValue && this.CellStyleOverrides.OverrideRotation)
        nullable = new double?(this.CellStyleOverrides.Rotation);
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyle != null && cell.CellStyle.OverrideRotation)
          nullable = new double?(cell.CellStyle.Rotation);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null && column.CellStyle.OverrideRotation)
          nullable = new double?(column.CellStyle.Rotation);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null && row.CellStyle.OverrideRotation)
          nullable = new double?(row.CellStyle.Rotation);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null && column.CellStyle != baseCellStyle)
          nullable = new double?(column.CellStyle.Rotation);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null && row.CellStyle != baseCellStyle)
          nullable = new double?(row.CellStyle.Rotation);
      }
      return nullable;
    }

    public double GetHorizontalMargin(int rowIndex, int columnIndex)
    {
      double? nullable = new double?();
      if (rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyleOverrides.OverrideHorizontalMargin)
          nullable = new double?(cell.CellStyleOverrides.HorizontalMargin);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyleOverrides.OverrideHorizontalMargin)
          nullable = new double?(column.CellStyleOverrides.HorizontalMargin);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyleOverrides.OverrideHorizontalMargin)
          nullable = new double?(row.CellStyleOverrides.HorizontalMargin);
      }
      if (!nullable.HasValue && this.CellStyleOverrides.OverrideHorizontalMargin)
        nullable = new double?(this.CellStyleOverrides.HorizontalMargin);
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyle != null)
          nullable = new double?(cell.CellStyle.HorizontalMargin);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null)
          nullable = new double?(column.CellStyle.HorizontalMargin);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null)
          nullable = new double?(row.CellStyle.HorizontalMargin);
      }
      if (!nullable.HasValue)
        nullable = new double?(this.TableStyle.TableCellStyle.HorizontalMargin);
      return nullable.Value;
    }

    public double GetVerticalMargin(int rowIndex, int columnIndex)
    {
      double? nullable = new double?();
      if (rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyleOverrides.OverrideVerticalMargin)
          nullable = new double?(cell.CellStyleOverrides.VerticalMargin);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyleOverrides.OverrideVerticalMargin)
          nullable = new double?(column.CellStyleOverrides.VerticalMargin);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyleOverrides.OverrideVerticalMargin)
          nullable = new double?(row.CellStyleOverrides.VerticalMargin);
      }
      if (!nullable.HasValue && this.CellStyleOverrides.OverrideVerticalMargin)
        nullable = new double?(this.CellStyleOverrides.VerticalMargin);
      if (!nullable.HasValue && rowIndex >= 0 && columnIndex >= 0)
      {
        DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
        if (cell.CellStyle != null)
          nullable = new double?(cell.CellStyle.VerticalMargin);
      }
      if (!nullable.HasValue && columnIndex >= 0)
      {
        DxfTableColumn column = this.Columns[columnIndex];
        if (column.CellStyle != null)
          nullable = new double?(column.CellStyle.VerticalMargin);
      }
      if (!nullable.HasValue && rowIndex >= 0)
      {
        DxfTableRow row = this.Rows[rowIndex];
        if (row.CellStyle != null)
          nullable = new double?(row.CellStyle.VerticalMargin);
      }
      if (!nullable.HasValue)
        nullable = new double?(this.TableStyle.TableCellStyle.VerticalMargin);
      return nullable.Value;
    }

    public DxfTableBorder GetEffectiveBorderInsideHorizontal(
      int rowIndex,
      int columnIndex)
    {
      return this.GetEffectiveBorder(rowIndex, columnIndex, 0);
    }

    public DxfTableBorder GetEffectiveBorderInsideVertical(
      int rowIndex,
      int columnIndex)
    {
      return this.GetEffectiveBorder(rowIndex, columnIndex, 1);
    }

    public DxfTableBorder GetEffectiveBorderTop(int rowIndex, int columnIndex)
    {
      return this.GetEffectiveBorder(rowIndex, columnIndex, 2);
    }

    public DxfTableBorder GetEffectiveBorderRight(int rowIndex, int columnIndex)
    {
      return this.GetEffectiveBorder(rowIndex, columnIndex, 3);
    }

    public DxfTableBorder GetEffectiveBorderBottom(int rowIndex, int columnIndex)
    {
      return this.GetEffectiveBorder(rowIndex, columnIndex, 4);
    }

    public DxfTableBorder GetEffectiveBorderLeft(int rowIndex, int columnIndex)
    {
      return this.GetEffectiveBorder(rowIndex, columnIndex, 5);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_21.ClassNumber;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfTableContent dxfTableContent = (DxfTableContent) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfTableContent == null)
      {
        dxfTableContent = new DxfTableContent();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfTableContent);
        dxfTableContent.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfTableContent;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfTableContent dxfTableContent = (DxfTableContent) from;
      if (dxfTableContent.TableStyle == null)
        this.TableStyle = (DxfTableStyle) null;
      else
        this.TableStyle = Class906.smethod_4(cloneContext, dxfTableContent.TableStyle);
    }

    public override string AcClass
    {
      get
      {
        return "AcDbTableContent";
      }
    }

    public override string ObjectType
    {
      get
      {
        return "TABLECONTENT";
      }
    }

    protected override void InitRowCells(int index, DxfTableRow item)
    {
      base.InitRowCells(index, item);
      if (this.TableStyle == null)
        return;
      item.CellStyle = this.TableStyle.GetRowCellStyle(index);
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal void method_18(Class551 table)
    {
      this.TableStyle = table.TableStyle;
      if (table.FlowDirection.HasValue)
        this.FlowDirection = new TableFlowDirection?(table.FlowDirection.Value);
      this.RowCount = table.RowCount;
      this.ColumnCount = table.ColumnCount;
      if (table.VerticalCellMargin.HasValue)
        this.CellStyleOverrides.VerticalMargin = table.VerticalCellMargin.Value;
      if (table.HorizontalCellMargin.HasValue)
        this.CellStyleOverrides.HorizontalMargin = table.HorizontalCellMargin.Value;
      bool flag1 = table.method_4();
      bool flag2 = table.method_5();
      DxfTableStyle tableStyle = this.TableStyle;
      for (int index1 = 0; index1 < this.Rows.Count; ++index1)
      {
        Class430 row1 = table.Rows[index1];
        DxfTableRow row2 = this.Rows[index1];
        row2.Height = row1.Height;
        switch (index1)
        {
          case 0:
            row2.CellStyle = !flag1 ? tableStyle.TitleCellStyle : (!flag2 ? tableStyle.HeaderCellStyle : tableStyle.DataCellStyle);
            break;
          case 1:
            row2.CellStyle = !flag1 ? (!flag2 ? tableStyle.HeaderCellStyle : tableStyle.DataCellStyle) : tableStyle.DataCellStyle;
            break;
        }
        for (int index2 = 0; index2 < this.Columns.Count; ++index2)
        {
          Class1026 cell1 = row1.Cells[index2];
          DxfTableCell cell2 = row2.Cells[index2];
          if (!this.method_19(table, index1, index2, cell2, cell1))
          {
            this.method_20(cell2, cell1, index1, index2);
            if (cell1.MergedCellCountHorizontal > 1 || cell1.MergedCellCountVertical > 1)
              this.MergedCellRanges.Add(new DxfTableCellRange(index1, index2, index1 + cell1.MergedCellCountVertical - 1, index2 + cell1.MergedCellCountHorizontal - 1));
          }
        }
      }
      for (int index = 0; index < this.Columns.Count; ++index)
        this.Columns[index].Width = table.Columns[index].Width;
    }

    private bool method_19(
      Class551 table,
      int ri,
      int ci,
      DxfTableCell toCell,
      Class1026 fromCell)
    {
      int mergedCellBlockTopRowIndex;
      int mergedCellBlockLeftColumnIndex;
      if (table.method_3(ri, ci, out mergedCellBlockTopRowIndex, out mergedCellBlockLeftColumnIndex))
      {
        Class1026 cell = table.Rows[mergedCellBlockTopRowIndex].Cells[mergedCellBlockLeftColumnIndex];
        if (ri == mergedCellBlockTopRowIndex)
          this.method_23(cell.BorderTop, toCell.CellStyleOverrides.BorderTop);
        if (ri == mergedCellBlockTopRowIndex + cell.MergedCellCountVertical - 1)
          this.method_23(cell.BorderBottom, toCell.CellStyleOverrides.BorderBottom);
        if (ci == mergedCellBlockLeftColumnIndex)
          this.method_23(cell.BorderLeft, toCell.CellStyleOverrides.BorderLeft);
        if (ci == mergedCellBlockLeftColumnIndex + cell.MergedCellCountHorizontal - 1)
          this.method_23(cell.BorderRight, toCell.CellStyleOverrides.BorderRight);
        if (fromCell != cell)
          return true;
      }
      else
      {
        for (int borderIndex = 0; borderIndex < 4; ++borderIndex)
          this.method_23(fromCell.method_6(borderIndex), toCell.CellStyleOverrides.method_21(borderIndex + 2));
      }
      return false;
    }

    private void method_20(DxfTableCell toCell, Class1026 fromCell, int rowIndex, int columnIndex)
    {
      if (toCell.Contents.Count == 0)
        toCell.Contents.Add(new DxfTableCellContent());
      DxfTableCellContent content = toCell.Contents[0];
      switch (fromCell.CellType)
      {
        case Enum47.const_1:
          content.Value.CopyFromShallow(fromCell.Value);
          if (fromCell.BlockOrField is DxfField)
          {
            content.ContentType = TableCellContentType.Field;
            content.ValueObject = fromCell.BlockOrField;
            break;
          }
          content.ContentType = TableCellContentType.Value;
          break;
        case Enum47.const_2:
          content.ValueObject = fromCell.BlockOrField;
          if (!(fromCell.BlockOrField is DxfBlock))
            throw new Exception("Illegal block object of type " + (object) fromCell.BlockOrField.GetType() + ".");
          content.ContentType = TableCellContentType.Block;
          content.Format.AutoScale = fromCell.AutoFit;
          content.Format.BlockScale = fromCell.BlockScale;
          using (List<DxfTableAttribute>.Enumerator enumerator = fromCell.Attributes.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              DxfTableAttribute current = enumerator.Current;
              content.Attributes.Add(current);
            }
            break;
          }
      }
      content.Format.method_5(fromCell.Rotation);
      if (fromCell.Rotation != this.GetRotation(rowIndex, columnIndex, 0))
        content.Format.OverrideRotation = true;
      if (fromCell.TextStyle != null)
        content.Format.TextStyle = fromCell.TextStyle;
      if (fromCell.TextHeight.HasValue)
        content.Format.TextHeight = fromCell.TextHeight.Value;
      if (fromCell.CellAlignment.HasValue)
        toCell.CellStyleOverrides.CellAlignment = fromCell.CellAlignment.Value;
      if (fromCell.BackColor.HasValue)
        toCell.CellStyleOverrides.BackColor = fromCell.BackColor.Value;
      if (!fromCell.ContentColor.HasValue)
        return;
      toCell.CellStyleOverrides.ContentColor = fromCell.ContentColor.Value;
    }

    internal void method_21(Class551 table)
    {
      for (int index1 = 0; index1 < this.Rows.Count; ++index1)
      {
        Class430 row1 = table.Rows[index1];
        DxfTableRow row2 = this.Rows[index1];
        row2.Height = row1.Height;
        for (int index2 = 0; index2 < this.Columns.Count; ++index2)
        {
          Class1026 cell1 = row1.Cells[index2];
          DxfTableCell cell2 = row2.Cells[index2];
          if (!this.method_19(table, index1, index2, cell2, cell1))
            this.method_20(cell2, cell1, index1, index2);
        }
      }
    }

    internal static DxfClass smethod_2(DxfClassCollection classes)
    {
      DxfClass dxfClass = DxfClass.GetClassWithDxfName(classes, "TABLECONTENT");
      if (dxfClass == null)
      {
        dxfClass = new DxfClass();
        dxfClass.ApplicationName = "ObjectDBX Classes";
        dxfClass.ClassNumber = (short) (500 + classes.Count);
        dxfClass.DwgVersion = DwgVersion.Dwg1018;
        dxfClass.MaintenanceVersion = (short) 21;
        dxfClass.ProxyFlags = ProxyFlags.CloningAllowed | ProxyFlags.DisablesProxyWarningDialog;
        dxfClass.CPlusPlusClassName = "AcDbTableContent";
        dxfClass.DxfName = "TABLECONTENT";
        dxfClass.ItemClassId = (short) 499;
        classes.Add(dxfClass);
      }
      return dxfClass;
    }

    private double method_22(string s)
    {
      return 0.0;
    }

    private void method_23(DxfTableBorderOverrides fromBorder, DxfTableBorder toBorder)
    {
      if (fromBorder.Color.HasValue)
        toBorder.Color = fromBorder.Color.Value;
      if (fromBorder.LineWeight.HasValue)
        toBorder.LineWeight = fromBorder.LineWeight.Value;
      if (!fromBorder.Visible.HasValue)
        return;
      toBorder.Visible = fromBorder.Visible.Value;
    }

    private DxfTableBorder GetEffectiveBorder(
      int rowIndex,
      int columnIndex,
      int borderIndex)
    {
      DxfTableCellStyle cellStyle = this.GetCellStyle(rowIndex, columnIndex);
      DxfTableBorder dxfTableBorder = cellStyle == null ? new DxfTableBorder() : cellStyle.method_21(borderIndex);
      dxfTableBorder.ApplyOverrides(this.CellStyleOverrides.method_21(borderIndex));
      DxfTableColumn column = this.Columns[columnIndex];
      dxfTableBorder.ApplyOverrides(column.CellStyleOverrides.method_21(borderIndex));
      DxfTableRow row = this.Rows[rowIndex];
      dxfTableBorder.ApplyOverrides(row.CellStyleOverrides.method_21(borderIndex));
      DxfTableCell cell = this.Rows[rowIndex].Cells[columnIndex];
      dxfTableBorder.ApplyOverrides(cell.CellStyleOverrides.method_21(borderIndex));
      return dxfTableBorder;
    }

    internal override void Write(DxfWriter w)
    {
      base.Write(w);
      w.Write(100, (object) "AcDbTableContent");
      w.method_218(340, (DxfHandledObject) this.TableStyle);
    }
  }
}
