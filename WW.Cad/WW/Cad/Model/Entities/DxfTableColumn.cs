// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableColumn
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns42;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.IO;
using WW.Cad.Model.Objects;

namespace WW.Cad.Model.Entities
{
  public class DxfTableColumn
  {
    private string string_0 = string.Empty;
    private DxfTableCustomDataCollection dxfTableCustomDataCollection_0 = new DxfTableCustomDataCollection();
    private DxfTableCellStyle dxfTableCellStyle_0 = new DxfTableCellStyle() { TableCellStyleType = Enum22.const_3 };
    private double double_0 = 2.5;
    private int int_0;
    private DxfTableCellStyle dxfTableCellStyle_1;

    public string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public int CustomData
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

    public DxfTableCustomDataCollection CustomDataCollection
    {
      get
      {
        return this.dxfTableCustomDataCollection_0;
      }
    }

    public DxfTableCellStyle CellStyleOverrides
    {
      get
      {
        return this.dxfTableCellStyle_0;
      }
    }

    public DxfTableCellStyle CellStyle
    {
      get
      {
        return this.dxfTableCellStyle_1;
      }
      set
      {
        this.dxfTableCellStyle_1 = value;
      }
    }

    public double Width
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

    public void ScaleMe(double scaleFactor, CommandGroup undoGroup)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfTableColumn.Class351 class351 = new DxfTableColumn.Class351();
      // ISSUE: reference to a compiler-generated field
      class351.dxfTableColumn_0 = this;
      if (scaleFactor == 1.0)
        return;
      // ISSUE: reference to a compiler-generated field
      class351.double_0 = this.double_0;
      this.double_0 *= scaleFactor;
      if (undoGroup != null)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfTableColumn.Class352()
        {
          class351_0 = class351,
          double_0 = this.double_0
        }.method_0), new System.Action(class351.method_0)));
      }
      this.dxfTableCellStyle_0.ScaleMe(this.dxfTableCellStyle_1, scaleFactor, undoGroup);
    }

    public DxfTableColumn Clone(CloneContext cloneContext)
    {
      DxfTableColumn dxfTableColumn = new DxfTableColumn();
      dxfTableColumn.CopyFrom(this, cloneContext);
      return dxfTableColumn;
    }

    public void CopyFrom(DxfTableColumn from, CloneContext cloneContext)
    {
      this.string_0 = from.string_0;
      this.int_0 = from.int_0;
      foreach (DxfTableCustomData dxfTableCustomData in (List<DxfTableCustomData>) from.dxfTableCustomDataCollection_0)
        this.dxfTableCustomDataCollection_0.Add(dxfTableCustomData.Clone(cloneContext));
      this.dxfTableCellStyle_0 = (DxfTableCellStyle) cloneContext.Clone((IGraphCloneable) from.dxfTableCellStyle_0);
      this.dxfTableCellStyle_1 = cloneContext.SourceModel != cloneContext.TargetModel ? (DxfTableCellStyle) cloneContext.Clone((IGraphCloneable) from.dxfTableCellStyle_1) : from.dxfTableCellStyle_1;
      this.double_0 = from.double_0;
    }

    internal void Write(DxfWriter w)
    {
      w.Write(300, (object) "COLUMN");
      w.Write(1, (object) "LINKEDTABLEDATACOLUMN_BEGIN");
      w.Write(300, (object) this.string_0);
      w.Write(91, (object) this.int_0);
      w.Write(301, (object) "CUSTOMDATA");
      this.dxfTableCustomDataCollection_0.Write(w);
      w.Write(309, (object) "LINKEDTABLEDATACOLUMN_END");
      w.Write(1, (object) "FORMATTEDTABLEDATACOLUMN_BEGIN");
      w.Write(300, (object) "COLUMNTABLEFORMAT");
      this.dxfTableCellStyle_0.method_22(w);
      w.Write(309, (object) "FORMATTEDTABLEDATACOLUMN_END");
      w.Write(1, (object) "TABLECOLUMN_BEGIN");
      w.Write(90, (object) (this.dxfTableCellStyle_1 == null ? 0 : this.dxfTableCellStyle_1.Id));
      w.Write(40, (object) this.double_0);
      w.Write(309, (object) "TABLECOLUMN_END");
    }
  }
}
