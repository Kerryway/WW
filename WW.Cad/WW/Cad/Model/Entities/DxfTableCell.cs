// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableCell
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns37;
using ns42;
using System.Collections.Generic;
using WW.Actions;
using WW.Cad.IO;
using WW.Cad.Model.Objects;

namespace WW.Cad.Model.Entities
{
  public class DxfTableCell
  {
    private string string_0 = string.Empty;
    private DxfTableCustomDataCollection dxfTableCustomDataCollection_0 = new DxfTableCustomDataCollection();
    private DxfTableCellContentCollection dxfTableCellContentCollection_0 = new DxfTableCellContentCollection();
    private DxfTableCellStyle dxfTableCellStyle_0 = new DxfTableCellStyle() { TableCellStyleType = Enum22.const_1 };
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private TableCellStateFlags tableCellStateFlags_0;
    private int int_0;
    private int int_1;
    private DxfTableCellLinkedData dxfTableCellLinkedData_0;
    private DxfTableCellStyle dxfTableCellStyle_1;
    private Class550 class550_0;
    private int int_2;
    private int int_3;
    private int int_4;
    private double double_0;
    private double double_1;

    public TableCellStateFlags StateFlags
    {
      get
      {
        return this.tableCellStateFlags_0;
      }
      set
      {
        this.tableCellStateFlags_0 = value;
      }
    }

    public string ToolTip
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

    public DxfTableCustomDataCollection CustomDataCollection
    {
      get
      {
        return this.dxfTableCustomDataCollection_0;
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

    public DxfTableCellLinkedData LinkedData
    {
      get
      {
        return this.dxfTableCellLinkedData_0;
      }
      set
      {
        this.dxfTableCellLinkedData_0 = value;
      }
    }

    public DxfTableCellContentCollection Contents
    {
      get
      {
        return this.dxfTableCellContentCollection_0;
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

    public void ScaleMe(double scaleFactor, CommandGroup undoGroup)
    {
      foreach (DxfTableCellContent tableCellContent in (List<DxfTableCellContent>) this.dxfTableCellContentCollection_0)
        tableCellContent.ScaleMe(this.dxfTableCellStyle_1, scaleFactor, undoGroup);
    }

    public DxfTableCell Clone(CloneContext cloneContext)
    {
      DxfTableCell dxfTableCell = new DxfTableCell();
      dxfTableCell.CopyFrom(cloneContext, this);
      return dxfTableCell;
    }

    public void CopyFrom(CloneContext cloneContext, DxfTableCell from)
    {
      this.tableCellStateFlags_0 = from.tableCellStateFlags_0;
      this.string_0 = from.string_0;
      foreach (DxfTableCustomData dxfTableCustomData in (List<DxfTableCustomData>) from.dxfTableCustomDataCollection_0)
        this.dxfTableCustomDataCollection_0.Add(dxfTableCustomData.Clone(cloneContext));
      this.int_0 = from.int_0;
      this.int_1 = from.int_1;
      this.dxfTableCellLinkedData_0 = from.dxfTableCellLinkedData_0 != null ? from.dxfTableCellLinkedData_0.Clone(cloneContext) : (DxfTableCellLinkedData) null;
      foreach (DxfTableCellContent tableCellContent in (List<DxfTableCellContent>) from.dxfTableCellContentCollection_0)
        this.dxfTableCellContentCollection_0.Add(tableCellContent.Clone(cloneContext));
      this.dxfTableCellStyle_0 = (DxfTableCellStyle) cloneContext.Clone((IGraphCloneable) from.dxfTableCellStyle_0);
      this.dxfTableCellStyle_1 = cloneContext.SourceModel != cloneContext.TargetModel ? (DxfTableCellStyle) cloneContext.Clone((IGraphCloneable) from.dxfTableCellStyle_1) : from.dxfTableCellStyle_1;
      this.class550_0 = from.class550_0 != null ? from.class550_0.Clone() : (Class550) null;
      this.int_2 = from.int_2;
      this.int_3 = from.int_3;
      this.int_4 = from.int_4;
      this.double_0 = from.double_0;
      this.double_1 = from.double_1;
      if (cloneContext.SourceModel == cloneContext.TargetModel)
        this.UnknownObject = from.UnknownObject;
      else
        this.UnknownObject = (DxfHandledObject) cloneContext.Clone((IGraphCloneable) from.UnknownObject);
    }

    internal int HasLinkDataFlags
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

    internal Class550 Geometry
    {
      get
      {
        return this.class550_0;
      }
      set
      {
        this.class550_0 = value;
      }
    }

    internal int UnknownDxfGroup91A
    {
      get
      {
        return this.int_2;
      }
      set
      {
        this.int_2 = value;
      }
    }

    internal int UnknownDxfGroup91B
    {
      get
      {
        return this.int_3;
      }
      set
      {
        this.int_3 = value;
      }
    }

    internal int GeometryDataFlags
    {
      get
      {
        return this.int_4;
      }
      set
      {
        this.int_4 = value;
      }
    }

    internal double UnknownDxfGroup40
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

    internal double UnknownDxfGroup41
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    internal DxfHandledObject UnknownObject
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_0.Value;
      }
      set
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    internal void Write(DxfWriter w)
    {
      w.Write(300, (object) "CELL");
      w.Write(1, (object) "LINKEDTABLEDATACELL_BEGIN");
      w.Write(90, (object) (int) this.tableCellStateFlags_0);
      w.Write(300, (object) this.string_0);
      w.Write(91, (object) this.int_0);
      w.Write(301, (object) "CUSTOMDATA");
      this.dxfTableCustomDataCollection_0.Write(w);
      w.Write(92, (object) this.int_1);
      w.Write(95, (object) this.dxfTableCellContentCollection_0.Count);
      foreach (DxfTableCellContent tableCellContent in (List<DxfTableCellContent>) this.dxfTableCellContentCollection_0)
        tableCellContent.Write(w);
      w.Write(309, (object) "LINKEDTABLEDATACELL_END");
      w.Write(1, (object) "FORMATTEDTABLEDATACELL_BEGIN");
      w.Write(300, (object) "CELLTABLEFORMAT");
      this.dxfTableCellStyle_0.method_22(w);
      w.Write(309, (object) "FORMATTEDTABLEDATACELL_END");
      w.Write(1, (object) "TABLECELL_BEGIN");
      w.Write(90, (object) (this.dxfTableCellStyle_1 == null ? 0 : this.dxfTableCellStyle_1.Id));
      w.Write(91, (object) this.int_2);
      if (this.int_2 != 0)
      {
        w.Write(91, (object) this.int_3);
        w.Write(40, (object) this.double_0);
        w.Write(41, (object) this.double_1);
        w.method_218(330, this.UnknownObject);
        w.Write(92, (object) this.int_4);
      }
      w.Write(309, (object) "TABLECELL_END");
    }
  }
}
