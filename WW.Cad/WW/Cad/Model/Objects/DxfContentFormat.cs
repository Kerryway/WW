// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfContentFormat
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Actions;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model.Objects
{
  public class DxfContentFormat : IGraphCloneable
  {
    private double double_0 = 0.18;
    private CellAlignment cellAlignment_0 = CellAlignment.TopLeft;
    private Color color_0 = Color.ByBlock;
    private DxfValueFormat dxfValueFormat_0 = (DxfValueFormat) new DxfValueFormat.General();
    private double double_2 = 1.0;
    private DxfTextStyle dxfTextStyle_0;
    private double double_1;
    private short short_0;
    private TableCellStylePropertyFlags tableCellStylePropertyFlags_0;
    private TableCellStylePropertyFlags tableCellStylePropertyFlags_1;

    public virtual DxfTextStyle TextStyle
    {
      get
      {
        return this.dxfTextStyle_0;
      }
      set
      {
        this.dxfTextStyle_0 = value;
        this.PropertyOverrideFlags |= TableCellStylePropertyFlags.TextStyle;
        this.HasData = true;
      }
    }

    public bool OverrideTextStyle
    {
      get
      {
        return (this.PropertyOverrideFlags & TableCellStylePropertyFlags.TextStyle) != TableCellStylePropertyFlags.None;
      }
      set
      {
        if (value)
          this.PropertyOverrideFlags |= TableCellStylePropertyFlags.TextStyle;
        else
          this.PropertyOverrideFlags &= ~TableCellStylePropertyFlags.TextStyle;
      }
    }

    public double TextHeight
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
        this.PropertyOverrideFlags |= TableCellStylePropertyFlags.TextHeight;
        this.HasData = true;
      }
    }

    public bool OverrideTextHeight
    {
      get
      {
        return (this.PropertyOverrideFlags & TableCellStylePropertyFlags.TextHeight) != TableCellStylePropertyFlags.None;
      }
      set
      {
        if (value)
          this.PropertyOverrideFlags |= TableCellStylePropertyFlags.TextHeight;
        else
          this.PropertyOverrideFlags &= ~TableCellStylePropertyFlags.TextHeight;
      }
    }

    public CellAlignment CellAlignment
    {
      get
      {
        return this.cellAlignment_0;
      }
      set
      {
        this.cellAlignment_0 = value;
        this.PropertyOverrideFlags |= TableCellStylePropertyFlags.Alignment;
        this.HasData = true;
      }
    }

    public bool OverrideCellAlignment
    {
      get
      {
        return (this.PropertyOverrideFlags & TableCellStylePropertyFlags.Alignment) != TableCellStylePropertyFlags.None;
      }
      set
      {
        if (value)
          this.PropertyOverrideFlags |= TableCellStylePropertyFlags.Alignment;
        else
          this.PropertyOverrideFlags &= ~TableCellStylePropertyFlags.Alignment;
      }
    }

    public Color ContentColor
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
        this.PropertyOverrideFlags |= TableCellStylePropertyFlags.ContentColor;
        this.HasData = true;
      }
    }

    public bool OverrideContentColor
    {
      get
      {
        return (this.PropertyOverrideFlags & TableCellStylePropertyFlags.ContentColor) != TableCellStylePropertyFlags.None;
      }
      set
      {
        if (value)
          this.PropertyOverrideFlags |= TableCellStylePropertyFlags.ContentColor;
        else
          this.PropertyOverrideFlags &= ~TableCellStylePropertyFlags.ContentColor;
      }
    }

    public DxfValueFormat ValueFormat
    {
      get
      {
        return this.dxfValueFormat_0;
      }
    }

    public double Rotation
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
        this.PropertyOverrideFlags |= TableCellStylePropertyFlags.Rotation;
        this.HasData = true;
      }
    }

    public bool OverrideRotation
    {
      get
      {
        return (this.PropertyOverrideFlags & TableCellStylePropertyFlags.Rotation) != TableCellStylePropertyFlags.None;
      }
      set
      {
        if (value)
          this.PropertyOverrideFlags |= TableCellStylePropertyFlags.Rotation;
        else
          this.PropertyOverrideFlags &= ~TableCellStylePropertyFlags.Rotation;
      }
    }

    public double BlockScale
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
        this.PropertyOverrideFlags |= TableCellStylePropertyFlags.BlockScale;
        this.HasData = true;
      }
    }

    public bool OverrideBlockScale
    {
      get
      {
        return (this.PropertyOverrideFlags & TableCellStylePropertyFlags.BlockScale) != TableCellStylePropertyFlags.None;
      }
      set
      {
        if (value)
          this.PropertyOverrideFlags |= TableCellStylePropertyFlags.BlockScale;
        else
          this.PropertyOverrideFlags &= ~TableCellStylePropertyFlags.BlockScale;
      }
    }

    internal TableCellStylePropertyFlags ContentFormatPropertyOverrideFlags
    {
      get
      {
        return this.tableCellStylePropertyFlags_0;
      }
      set
      {
        this.tableCellStylePropertyFlags_0 = value;
      }
    }

    public virtual TableCellStylePropertyFlags PropertyOverrideFlags
    {
      get
      {
        return this.tableCellStylePropertyFlags_0;
      }
      set
      {
        this.tableCellStylePropertyFlags_0 = value;
      }
    }

    public bool AutoScale
    {
      get
      {
        return (this.tableCellStylePropertyFlags_1 & TableCellStylePropertyFlags.AutoScale) != TableCellStylePropertyFlags.None;
      }
      set
      {
        if (value)
          this.tableCellStylePropertyFlags_1 |= TableCellStylePropertyFlags.AutoScale;
        else
          this.tableCellStylePropertyFlags_1 &= ~TableCellStylePropertyFlags.AutoScale;
        this.OverrideAutoScale = true;
        this.HasData = true;
      }
    }

    public bool OverrideAutoScale
    {
      get
      {
        return (this.PropertyOverrideFlags & TableCellStylePropertyFlags.AutoScale) != TableCellStylePropertyFlags.None;
      }
      set
      {
        if (value)
          this.PropertyOverrideFlags |= TableCellStylePropertyFlags.AutoScale;
        else
          this.PropertyOverrideFlags &= ~TableCellStylePropertyFlags.AutoScale;
      }
    }

    public bool HasData
    {
      get
      {
        return ((int) this.short_0 & 1) != 0;
      }
      set
      {
        if (value)
          this.short_0 |= (short) 1;
        else
          this.short_0 &= (short) -2;
      }
    }

    public double? GetTextHeightIfOverridden()
    {
      double? nullable = new double?();
      if (this.OverrideTextHeight)
        nullable = new double?(this.double_0);
      else if (this.OverrideTextStyle && this.dxfTextStyle_0 != null && this.dxfTextStyle_0.FixedHeight != 0.0)
        nullable = new double?(this.dxfTextStyle_0.FixedHeight);
      return nullable;
    }

    public void ScaleMe(DxfTableCellStyle cellStyle, double scaleFactor, CommandGroup undoGroup)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfContentFormat.Class548 class548 = new DxfContentFormat.Class548();
      // ISSUE: reference to a compiler-generated field
      class548.dxfContentFormat_0 = this;
      if (scaleFactor == 1.0)
        return;
      // ISSUE: reference to a compiler-generated field
      class548.double_0 = this.double_0;
      // ISSUE: reference to a compiler-generated field
      class548.bool_0 = this.OverrideTextHeight;
      // ISSUE: reference to a compiler-generated field
      class548.double_1 = this.double_2;
      // ISSUE: reference to a compiler-generated field
      class548.bool_1 = this.OverrideBlockScale;
      if (!this.OverrideTextHeight && cellStyle != null)
      {
        this.double_0 = cellStyle.TextHeight * scaleFactor;
        // ISSUE: reference to a compiler-generated field
        this.OverrideTextHeight = this.double_0 != class548.double_0;
        this.double_2 = cellStyle.BlockScale * scaleFactor;
        // ISSUE: reference to a compiler-generated field
        this.OverrideBlockScale = this.double_2 != class548.double_1;
      }
      else
      {
        this.double_0 *= scaleFactor;
        this.double_2 *= scaleFactor;
      }
      if (undoGroup == null)
        return;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfContentFormat.Class549()
      {
        class548_0 = class548,
        double_0 = this.double_0,
        bool_0 = this.OverrideTextHeight,
        double_1 = this.double_2,
        bool_1 = this.OverrideBlockScale
      }.method_0), new System.Action(class548.method_0)));
    }

    public virtual bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      return true;
    }

    public virtual IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfContentFormat dxfContentFormat = new DxfContentFormat();
      dxfContentFormat.CopyFrom(this, cloneContext);
      return (IGraphCloneable) dxfContentFormat;
    }

    public void CopyFrom(DxfContentFormat from, CloneContext cloneContext)
    {
      if (from.TextStyle == null)
        this.dxfTextStyle_0 = (DxfTextStyle) null;
      else if (cloneContext.SourceModel == cloneContext.TargetModel)
        this.dxfTextStyle_0 = from.dxfTextStyle_0;
      else if (!cloneContext.TargetModel.TextStyles.TryGetValue(from.dxfTextStyle_0.Name, out this.dxfTextStyle_0))
      {
        if (cloneContext.ReferenceResolutionType == ReferenceResolutionType.CloneMissing)
        {
          this.dxfTextStyle_0 = (DxfTextStyle) from.dxfTextStyle_0.Clone(cloneContext);
          if (!cloneContext.CloneExact)
            cloneContext.TargetModel.TextStyles.Add(this.dxfTextStyle_0);
        }
        else if (cloneContext.ReferenceResolutionType == ReferenceResolutionType.FailOnMissing)
          throw new DxfException("Missing text style with name " + from.dxfTextStyle_0.Name + " in target model.");
      }
      this.double_0 = from.double_0;
      this.cellAlignment_0 = from.cellAlignment_0;
      this.color_0 = from.color_0;
      this.dxfValueFormat_0 = from.dxfValueFormat_0.Clone();
      this.double_1 = from.double_1;
      this.short_0 = from.short_0;
      this.tableCellStylePropertyFlags_0 = from.tableCellStylePropertyFlags_0;
      this.tableCellStylePropertyFlags_1 = from.tableCellStylePropertyFlags_1;
      this.double_2 = from.double_2;
    }

    internal short DataFlags
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

    internal void method_0(DxfTextStyle textStyle)
    {
      this.dxfTextStyle_0 = textStyle;
    }

    internal void method_1(double textHeight)
    {
      this.double_0 = textHeight;
    }

    internal void method_2(CellAlignment cellAlignment)
    {
      this.cellAlignment_0 = cellAlignment;
    }

    internal void method_3(Color contentColor)
    {
      this.color_0 = contentColor;
    }

    internal void method_4(DxfValueFormat cellFormat)
    {
      this.dxfValueFormat_0 = cellFormat;
    }

    internal void method_5(double rotation)
    {
      this.double_1 = rotation;
    }

    internal void method_6(double blockScale)
    {
      this.double_2 = blockScale;
    }

    internal TableCellStylePropertyFlags PropertyFlags
    {
      get
      {
        return this.tableCellStylePropertyFlags_1;
      }
      set
      {
        this.tableCellStylePropertyFlags_1 = value;
      }
    }

    internal virtual void vmethod_0(DxfModel modelContext, DxfTableStyle tableStyle)
    {
      if (this.dxfTextStyle_0 != null)
        return;
      this.dxfTextStyle_0 = modelContext.DefaultTextStyle;
    }

    internal virtual void vmethod_1(DxfTableStyle tableStyle)
    {
    }

    internal void method_7(DxfWriter w)
    {
      w.Write(300, (object) "CONTENTFORMAT");
      w.Write(1, (object) "CONTENTFORMAT_BEGIN");
      w.Write(90, (object) (int) this.tableCellStylePropertyFlags_0);
      w.Write(91, (object) (int) this.tableCellStylePropertyFlags_1);
      this.dxfValueFormat_0.Write(w);
      w.Write(40, (object) this.double_1);
      w.Write(140, (object) this.double_2);
      w.Write(94, (object) (int) this.cellAlignment_0);
      w.method_230(62, this.color_0);
      w.method_218(340, (DxfHandledObject) (this.dxfTextStyle_0 ?? w.Model.DefaultTextStyle));
      w.Write(144, (object) this.double_0);
      w.Write(309, (object) "CONTENTFORMAT_END");
    }
  }
}
