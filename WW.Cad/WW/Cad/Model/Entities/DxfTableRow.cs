// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableRow
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
  public class DxfTableRow
  {
    private DxfTableCellCollection dxfTableCellCollection_0 = new DxfTableCellCollection();
    private DxfTableCellStyle dxfTableCellStyle_0 = new DxfTableCellStyle() { TableCellStyleType = Enum22.const_2 };
    private DxfTableCustomDataCollection dxfTableCustomDataCollection_0 = new DxfTableCustomDataCollection();
    private double double_0 = 0.36;
    private DxfTableCellStyle dxfTableCellStyle_1;
    private int int_0;

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

    public DxfTableCellCollection Cells
    {
      get
      {
        return this.dxfTableCellCollection_0;
      }
    }

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

    public void ScaleMe(double scaleFactor, CommandGroup undoGroup)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DxfTableRow.Class667 class667 = new DxfTableRow.Class667();
      // ISSUE: reference to a compiler-generated field
      class667.dxfTableRow_0 = this;
      if (scaleFactor == 1.0)
        return;
      // ISSUE: reference to a compiler-generated field
      class667.double_0 = this.double_0;
      this.double_0 *= scaleFactor;
      if (undoGroup != null)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        undoGroup.UndoStack.Push((ICommand) new Command((object) this, new System.Action(new DxfTableRow.Class668()
        {
          class667_0 = class667,
          double_0 = this.double_0
        }.method_0), new System.Action(class667.method_0)));
      }
      this.dxfTableCellStyle_0.ScaleMe(this.dxfTableCellStyle_1, scaleFactor, undoGroup);
      for (int index = this.dxfTableCellCollection_0.Count - 1; index >= 0; --index)
        this.dxfTableCellCollection_0[index].ScaleMe(scaleFactor, undoGroup);
    }

    public DxfTableRow Clone(CloneContext cloneContext)
    {
      DxfTableRow dxfTableRow = new DxfTableRow();
      dxfTableRow.CopyFrom(cloneContext, this);
      return dxfTableRow;
    }

    public void CopyFrom(CloneContext cloneContext, DxfTableRow from)
    {
      foreach (DxfTableCell dxfTableCell in (List<DxfTableCell>) from.dxfTableCellCollection_0)
        this.dxfTableCellCollection_0.Add(dxfTableCell.Clone(cloneContext));
      this.dxfTableCellStyle_0 = (DxfTableCellStyle) cloneContext.Clone((IGraphCloneable) from.dxfTableCellStyle_0);
      this.dxfTableCellStyle_1 = cloneContext.SourceModel != cloneContext.TargetModel ? (DxfTableCellStyle) cloneContext.Clone((IGraphCloneable) from.dxfTableCellStyle_1) : from.dxfTableCellStyle_1;
      this.int_0 = from.int_0;
      foreach (DxfTableCustomData dxfTableCustomData in (List<DxfTableCustomData>) from.dxfTableCustomDataCollection_0)
        this.dxfTableCustomDataCollection_0.Add(dxfTableCustomData);
      this.double_0 = from.double_0;
    }

    internal void Write(DxfWriter w)
    {
      w.Write(301, (object) "ROW");
      w.Write(1, (object) "LINKEDTABLEDATAROW_BEGIN");
      w.Write(90, (object) this.dxfTableCellCollection_0.Count);
      foreach (DxfTableCell dxfTableCell in (List<DxfTableCell>) this.dxfTableCellCollection_0)
        dxfTableCell.Write(w);
      w.Write(91, (object) this.int_0);
      w.Write(301, (object) "CUSTOMDATA");
      this.dxfTableCustomDataCollection_0.Write(w);
      w.Write(309, (object) "LINKEDTABLEDATAROW_END");
      w.Write(1, (object) "FORMATTEDTABLEDATAROW_BEGIN");
      w.Write(300, (object) "ROWTABLEFORMAT");
      this.dxfTableCellStyle_0.method_22(w);
      w.Write(309, (object) "FORMATTEDTABLEDATAROW_END");
      w.Write(1, (object) "TABLEROW_BEGIN");
      w.Write(90, (object) (this.dxfTableCellStyle_1 == null ? 0 : this.dxfTableCellStyle_1.Id));
      w.Write(40, (object) this.double_0);
      w.Write(309, (object) "TABLEROW_END");
    }
  }
}
