// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfTableCellStyle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns42;
using System;
using WW.Cad.IO;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model.Objects
{
  public class DxfTableCellStyle : DxfContentFormat
  {
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private string string_0 = string.Empty;
    private Color color_1 = Color.None;
    private CellType cellType_0 = CellType.Label;
    private double double_3 = 0.06;
    private double double_4 = 0.06;
    private DxfTableBorder dxfTableBorder_0 = new DxfTableBorder();
    private DxfTableBorder dxfTableBorder_1 = new DxfTableBorder();
    private DxfTableBorder dxfTableBorder_2 = new DxfTableBorder();
    private DxfTableBorder dxfTableBorder_3 = new DxfTableBorder();
    private DxfTableBorder dxfTableBorder_4 = new DxfTableBorder();
    private DxfTableBorder dxfTableBorder_5 = new DxfTableBorder();
    private Enum22 enum22_0 = Enum22.const_5;
    private TableCellContentLayoutFlags tableCellContentLayoutFlags_0 = TableCellContentLayoutFlags.Flow;
    private double double_5 = 0.06;
    private double double_6 = 0.06;
    private double double_7 = 0.18;
    private double double_8 = 0.18;
    public const string NameTitle = "_TITLE";
    public const string NameHeader = "_HEADER";
    public const string NameData = "_DATA";
    private int int_0;
    private TableCellStylePropertyFlags tableCellStylePropertyFlags_2;
    private bool bool_0;
    private TableCellStylePropertyFlags tableCellStylePropertyFlags_3;
    private short short_1;

    public DxfTableCellStyle()
    {
    }

    public DxfTableCellStyle(string name)
      : this()
    {
      this.string_0 = name ?? string.Empty;
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

    public Color BackColor
    {
      get
      {
        return this.color_1;
      }
      set
      {
        this.color_1 = value;
        this.ContentFormatPropertyOverrideFlags |= TableCellStylePropertyFlags.BackgroundColor;
        this.CellStylePropertyOverrideFlags |= TableCellStylePropertyFlags.BackgroundColor;
        this.HasData = true;
        this.bool_0 = true;
      }
    }

    public bool OverrideBackColor
    {
      get
      {
        return (this.CellStylePropertyOverrideFlags & TableCellStylePropertyFlags.BackgroundColor) != TableCellStylePropertyFlags.None;
      }
      set
      {
        if (value)
          this.CellStylePropertyOverrideFlags |= TableCellStylePropertyFlags.BackgroundColor;
        else
          this.CellStylePropertyOverrideFlags &= ~TableCellStylePropertyFlags.BackgroundColor;
      }
    }

    public int Id
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

    public CellType CellType
    {
      get
      {
        return this.cellType_0;
      }
      set
      {
        this.cellType_0 = value;
      }
    }

    public bool MergeCellsOnCreation
    {
      get
      {
        return (this.tableCellStylePropertyFlags_2 & TableCellStylePropertyFlags.MergeCellsOnCreation) != TableCellStylePropertyFlags.None;
      }
      set
      {
        if (value)
          this.tableCellStylePropertyFlags_2 |= TableCellStylePropertyFlags.MergeCellsOnCreation;
        else
          this.tableCellStylePropertyFlags_2 &= ~TableCellStylePropertyFlags.MergeCellsOnCreation;
        this.HasData = true;
      }
    }

    public TableFlowDirection FlowDirection
    {
      get
      {
        return (this.tableCellStylePropertyFlags_2 & TableCellStylePropertyFlags.FlowDirectionBottomToTop) != TableCellStylePropertyFlags.None ? TableFlowDirection.Up : TableFlowDirection.Down;
      }
      set
      {
        if (value == TableFlowDirection.Up)
          this.tableCellStylePropertyFlags_2 |= TableCellStylePropertyFlags.FlowDirectionBottomToTop;
        else
          this.tableCellStylePropertyFlags_2 &= ~TableCellStylePropertyFlags.FlowDirectionBottomToTop;
        this.OverrideFlowDirection = true;
        this.HasData = true;
      }
    }

    public bool OverrideFlowDirection
    {
      get
      {
        return (this.CellStylePropertyOverrideFlags & TableCellStylePropertyFlags.FlowDirectionBottomToTop) != TableCellStylePropertyFlags.None;
      }
      set
      {
        if (value)
          this.CellStylePropertyOverrideFlags |= TableCellStylePropertyFlags.FlowDirectionBottomToTop;
        else
          this.CellStylePropertyOverrideFlags &= ~TableCellStylePropertyFlags.FlowDirectionBottomToTop;
      }
    }

    public bool IsBackColorEnabled
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public double HorizontalMargin
    {
      get
      {
        return this.double_3;
      }
      set
      {
        this.double_3 = value;
        this.tableCellStylePropertyFlags_3 |= TableCellStylePropertyFlags.MarginLeft;
        this.HasMarginOverrides = true;
        this.HasData = true;
      }
    }

    public bool OverrideHorizontalMargin
    {
      get
      {
        return (this.CellStylePropertyOverrideFlags & TableCellStylePropertyFlags.MarginLeft) != TableCellStylePropertyFlags.None;
      }
      set
      {
        if (value)
          this.CellStylePropertyOverrideFlags |= TableCellStylePropertyFlags.MarginLeft;
        else
          this.CellStylePropertyOverrideFlags &= ~TableCellStylePropertyFlags.MarginLeft;
      }
    }

    public double VerticalMargin
    {
      get
      {
        return this.double_4;
      }
      set
      {
        this.double_4 = value;
        this.tableCellStylePropertyFlags_3 |= TableCellStylePropertyFlags.MarginTop;
        this.HasMarginOverrides = true;
        this.HasData = true;
      }
    }

    public bool OverrideVerticalMargin
    {
      get
      {
        return (this.CellStylePropertyOverrideFlags & TableCellStylePropertyFlags.MarginTop) != TableCellStylePropertyFlags.None;
      }
      set
      {
        if (value)
          this.CellStylePropertyOverrideFlags |= TableCellStylePropertyFlags.MarginTop;
        else
          this.CellStylePropertyOverrideFlags &= ~TableCellStylePropertyFlags.MarginTop;
      }
    }

    internal TableCellStylePropertyFlags CellStylePropertyOverrideFlags
    {
      get
      {
        return this.tableCellStylePropertyFlags_3;
      }
      set
      {
        this.tableCellStylePropertyFlags_3 = value;
      }
    }

    public override TableCellStylePropertyFlags PropertyOverrideFlags
    {
      get
      {
        return this.tableCellStylePropertyFlags_3;
      }
      set
      {
        this.tableCellStylePropertyFlags_3 = value;
      }
    }

    public TableCellContentLayoutFlags ContentLayoutFlags
    {
      get
      {
        return this.tableCellContentLayoutFlags_0;
      }
      set
      {
        this.tableCellContentLayoutFlags_0 = value;
        this.tableCellStylePropertyFlags_3 |= TableCellStylePropertyFlags.ContentLayout;
        this.HasData = true;
      }
    }

    public bool OverrideContentLayoutFlags
    {
      get
      {
        return (this.CellStylePropertyOverrideFlags & TableCellStylePropertyFlags.ContentLayout) != TableCellStylePropertyFlags.None;
      }
      set
      {
        if (value)
          this.CellStylePropertyOverrideFlags |= TableCellStylePropertyFlags.ContentLayout;
        else
          this.CellStylePropertyOverrideFlags &= ~TableCellStylePropertyFlags.ContentLayout;
      }
    }

    public bool HasMarginOverrides
    {
      get
      {
        return ((int) this.short_1 & 1) != 0;
      }
      set
      {
        if (value)
          this.short_1 |= (short) 1;
        else
          this.short_1 &= (short) -2;
      }
    }

    public DxfTableBorder BorderInsideHorizontal
    {
      get
      {
        return this.dxfTableBorder_0;
      }
      set
      {
        this.dxfTableBorder_0 = value;
      }
    }

    public DxfTableBorder BorderInsideVertical
    {
      get
      {
        return this.dxfTableBorder_1;
      }
      set
      {
        this.dxfTableBorder_1 = value;
      }
    }

    public DxfTableBorder BorderTop
    {
      get
      {
        return this.dxfTableBorder_2;
      }
      set
      {
        this.dxfTableBorder_2 = value;
      }
    }

    public DxfTableBorder BorderRight
    {
      get
      {
        return this.dxfTableBorder_3;
      }
      set
      {
        this.dxfTableBorder_3 = value;
      }
    }

    public DxfTableBorder BorderBottom
    {
      get
      {
        return this.dxfTableBorder_4;
      }
      set
      {
        this.dxfTableBorder_4 = value;
      }
    }

    public DxfTableBorder BorderLeft
    {
      get
      {
        return this.dxfTableBorder_5;
      }
      set
      {
        this.dxfTableBorder_5 = value;
      }
    }

    public void SetAllBordersLineWeight(short lineWeight)
    {
      this.dxfTableBorder_0.LineWeight = lineWeight;
      this.dxfTableBorder_1.LineWeight = lineWeight;
      this.dxfTableBorder_2.LineWeight = lineWeight;
      this.dxfTableBorder_3.LineWeight = lineWeight;
      this.dxfTableBorder_4.LineWeight = lineWeight;
      this.dxfTableBorder_5.LineWeight = lineWeight;
    }

    public void SetAllBordersLineType(DxfLineType lineType)
    {
      this.dxfTableBorder_0.LineType = lineType;
      this.dxfTableBorder_1.LineType = lineType;
      this.dxfTableBorder_2.LineType = lineType;
      this.dxfTableBorder_3.LineType = lineType;
      this.dxfTableBorder_4.LineType = lineType;
      this.dxfTableBorder_5.LineType = lineType;
    }

    public void SetAllBordersBorderType(BorderType borderType)
    {
      this.dxfTableBorder_0.BorderType = borderType;
      this.dxfTableBorder_1.BorderType = borderType;
      this.dxfTableBorder_2.BorderType = borderType;
      this.dxfTableBorder_3.BorderType = borderType;
      this.dxfTableBorder_4.BorderType = borderType;
      this.dxfTableBorder_5.BorderType = borderType;
    }

    public void SetAllBordersVisible(bool visible)
    {
      this.dxfTableBorder_0.Visible = visible;
      this.dxfTableBorder_1.Visible = visible;
      this.dxfTableBorder_2.Visible = visible;
      this.dxfTableBorder_3.Visible = visible;
      this.dxfTableBorder_4.Visible = visible;
      this.dxfTableBorder_5.Visible = visible;
    }

    public void SetAllBordersColor(Color color)
    {
      this.dxfTableBorder_0.Color = color;
      this.dxfTableBorder_1.Color = color;
      this.dxfTableBorder_2.Color = color;
      this.dxfTableBorder_3.Color = color;
      this.dxfTableBorder_4.Color = color;
      this.dxfTableBorder_5.Color = color;
    }

    public void SetAllBordersSpacing(double spacing)
    {
      this.dxfTableBorder_0.DoubleLineSpacing = spacing;
      this.dxfTableBorder_1.DoubleLineSpacing = spacing;
      this.dxfTableBorder_2.DoubleLineSpacing = spacing;
      this.dxfTableBorder_3.DoubleLineSpacing = spacing;
      this.dxfTableBorder_4.DoubleLineSpacing = spacing;
      this.dxfTableBorder_5.DoubleLineSpacing = spacing;
    }

    public double GetTextHeight()
    {
      return this.TextStyle == null || this.TextStyle.FixedHeight == 0.0 ? this.TextHeight : this.TextStyle.FixedHeight;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfTableCellStyle dxfTableCellStyle = (DxfTableCellStyle) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfTableCellStyle == null)
      {
        dxfTableCellStyle = new DxfTableCellStyle();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfTableCellStyle);
        dxfTableCellStyle.CopyFrom(this, cloneContext);
      }
      return (IGraphCloneable) dxfTableCellStyle;
    }

    public void CopyFrom(DxfTableCellStyle from, CloneContext cloneContext)
    {
      this.CopyFrom((DxfContentFormat) from, cloneContext);
      this.string_0 = from.string_0;
      this.color_1 = from.color_1;
      this.int_0 = from.int_0;
      this.cellType_0 = from.cellType_0;
      this.tableCellStylePropertyFlags_2 = from.tableCellStylePropertyFlags_2;
      this.bool_0 = from.bool_0;
      this.double_3 = from.double_3;
      this.double_4 = from.double_4;
      this.dxfTableBorder_0.CopyFrom(from.dxfTableBorder_0, cloneContext);
      this.dxfTableBorder_1.CopyFrom(from.dxfTableBorder_1, cloneContext);
      this.dxfTableBorder_2.CopyFrom(from.dxfTableBorder_2, cloneContext);
      this.dxfTableBorder_3.CopyFrom(from.dxfTableBorder_3, cloneContext);
      this.dxfTableBorder_4.CopyFrom(from.dxfTableBorder_4, cloneContext);
      this.dxfTableBorder_5.CopyFrom(from.dxfTableBorder_5, cloneContext);
      this.enum22_0 = from.enum22_0;
      this.tableCellStylePropertyFlags_3 = from.tableCellStylePropertyFlags_3;
      this.tableCellContentLayoutFlags_0 = from.tableCellContentLayoutFlags_0;
      this.short_1 = from.short_1;
      this.double_5 = from.double_5;
      this.double_6 = from.double_6;
      this.double_7 = from.double_7;
      this.double_8 = from.double_8;
    }

    public override string ToString()
    {
      return this.Name;
    }

    internal Enum22 TableCellStyleType
    {
      get
      {
        return this.enum22_0;
      }
      set
      {
        this.enum22_0 = value;
      }
    }

    internal TableCellStylePropertyFlags MergeFlags
    {
      get
      {
        return this.tableCellStylePropertyFlags_2;
      }
      set
      {
        this.tableCellStylePropertyFlags_2 = value;
      }
    }

    internal short MarginOverrideFlags
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

    internal double MarginBottom
    {
      get
      {
        return this.double_5;
      }
      set
      {
        this.double_5 = value;
        this.tableCellStylePropertyFlags_3 |= TableCellStylePropertyFlags.MarginBottom;
        this.HasMarginOverrides = true;
        this.HasData = true;
      }
    }

    internal double MarginRight
    {
      get
      {
        return this.double_6;
      }
      set
      {
        this.double_6 = value;
        this.tableCellStylePropertyFlags_3 |= TableCellStylePropertyFlags.MarginRight;
        this.HasMarginOverrides = true;
        this.HasData = true;
      }
    }

    internal double MarginHorizontalSpacing
    {
      get
      {
        return this.double_7;
      }
      set
      {
        this.double_7 = value;
        this.tableCellStylePropertyFlags_3 |= TableCellStylePropertyFlags.MarginHorizontalSpacing;
        this.HasMarginOverrides = true;
        this.HasData = true;
      }
    }

    internal double MarginVerticalSpacing
    {
      get
      {
        return this.double_8;
      }
      set
      {
        this.double_8 = value;
        this.tableCellStylePropertyFlags_3 |= TableCellStylePropertyFlags.MarginVerticalSpacing;
        this.HasMarginOverrides = true;
        this.HasData = true;
      }
    }

    internal int method_8()
    {
      int num = 0;
      if (this.dxfTableBorder_2.HasData)
        num |= 1;
      if (this.dxfTableBorder_0.HasData)
        num |= 2;
      if (this.dxfTableBorder_4.HasData)
        num |= 4;
      if (this.dxfTableBorder_5.HasData)
        num |= 8;
      if (this.dxfTableBorder_1.HasData)
        num |= 16;
      if (this.dxfTableBorder_3.HasData)
        num |= 32;
      return num;
    }

    internal int method_9()
    {
      int num = 0;
      if (this.dxfTableBorder_2.HasData)
        ++num;
      if (this.dxfTableBorder_0.HasData)
        ++num;
      if (this.dxfTableBorder_4.HasData)
        ++num;
      if (this.dxfTableBorder_5.HasData)
        ++num;
      if (this.dxfTableBorder_1.HasData)
        ++num;
      if (this.dxfTableBorder_3.HasData)
        ++num;
      return num;
    }

    internal void method_10(Color backColor)
    {
      this.color_1 = backColor;
    }

    internal void method_11(CellType cellType)
    {
      this.cellType_0 = cellType;
    }

    internal void method_12(TableCellStylePropertyFlags mergeFlags)
    {
      this.tableCellStylePropertyFlags_2 = mergeFlags;
    }

    internal void method_13(bool isBackColorEnabled)
    {
      this.bool_0 = isBackColorEnabled;
    }

    internal void method_14(double horizontalMargin)
    {
      this.double_3 = horizontalMargin;
    }

    internal void method_15(double verticalMargin)
    {
      this.double_4 = verticalMargin;
    }

    internal void method_16(double marginBottom)
    {
      this.double_5 = marginBottom;
    }

    internal void method_17(double marginRight)
    {
      this.double_6 = marginRight;
    }

    internal void method_18(double marginHorizontalSpacing)
    {
      this.double_7 = marginHorizontalSpacing;
    }

    internal void method_19(double marginVerticalSpacing)
    {
      this.double_8 = marginVerticalSpacing;
    }

    internal void method_20(TableCellContentLayoutFlags contentLayoutFlags)
    {
      this.tableCellContentLayoutFlags_0 = contentLayoutFlags;
    }

    internal DxfTableBorder method_21(int index)
    {
      switch (index)
      {
        case 0:
          return this.dxfTableBorder_0;
        case 1:
          return this.dxfTableBorder_1;
        case 2:
          return this.dxfTableBorder_2;
        case 3:
          return this.dxfTableBorder_3;
        case 4:
          return this.dxfTableBorder_4;
        case 5:
          return this.dxfTableBorder_5;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    internal override void vmethod_0(DxfModel modelContext, DxfTableStyle tableStyle)
    {
      base.vmethod_0(modelContext, tableStyle);
      this.TableStyle = tableStyle;
      this.dxfTableBorder_0.method_4(modelContext);
      this.dxfTableBorder_1.method_4(modelContext);
      this.dxfTableBorder_2.method_4(modelContext);
      this.dxfTableBorder_3.method_4(modelContext);
      this.dxfTableBorder_4.method_4(modelContext);
      this.dxfTableBorder_5.method_4(modelContext);
    }

    internal override void vmethod_1(DxfTableStyle tableStyle)
    {
      base.vmethod_1(tableStyle);
      if (this.TableStyle != tableStyle)
        return;
      this.TableStyle = (DxfTableStyle) null;
    }

    internal DxfTableStyle TableStyle
    {
      get
      {
        return (DxfTableStyle) this.dxfObjectReference_0.Value;
      }
      private set
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal void Write(DxfWriter w)
    {
      w.Write(300, (object) "CELLSTYLE");
      this.method_22(w);
      w.Write(1, (object) "CELLSTYLE_BEGIN");
      w.Write(90, (object) this.int_0);
      w.Write(91, (object) (int) this.cellType_0);
      w.Write(300, (object) this.string_0);
      w.Write(309, (object) "CELLSTYLE_END");
    }

    internal void method_22(DxfWriter w)
    {
      w.Write(1, (object) "TABLEFORMAT_BEGIN");
      w.Write(90, (object) (int) this.enum22_0);
      short dataFlags = this.DataFlags;
      int num = this.method_9();
      if (num > 0)
        dataFlags |= (short) 1;
      w.method_219(170, dataFlags);
      if (((int) dataFlags & 1) != 0)
      {
        w.Write(91, (object) (int) this.tableCellStylePropertyFlags_3);
        w.Write(92, (object) (int) this.tableCellStylePropertyFlags_2);
        if (this.bool_0)
          w.method_230(62, this.color_1);
        else
          w.Write(62, (object) (short) 257);
        w.Write(93, (object) (int) this.tableCellContentLayoutFlags_0);
        this.method_7(w);
        w.Write(171, (object) this.short_1);
        if (this.HasMarginOverrides)
          this.method_23(w);
        w.Write(94, (object) num);
        this.dxfTableBorder_2.Write(w, 1);
        this.dxfTableBorder_0.Write(w, 2);
        this.dxfTableBorder_4.Write(w, 4);
        this.dxfTableBorder_5.Write(w, 8);
        this.dxfTableBorder_1.Write(w, 16);
        this.dxfTableBorder_3.Write(w, 32);
      }
      w.Write(309, (object) "TABLEFORMAT_END");
    }

    private void method_23(DxfWriter w)
    {
      w.Write(301, (object) "MARGIN");
      w.Write(1, (object) "CELLMARGIN_BEGIN");
      w.Write(40, (object) this.double_4);
      w.Write(40, (object) this.double_3);
      w.Write(40, (object) this.double_5);
      w.Write(40, (object) this.double_6);
      w.Write(40, (object) this.double_7);
      w.Write(40, (object) this.double_8);
      w.Write(309, (object) "CELLMARGIN_END");
    }
  }
}
