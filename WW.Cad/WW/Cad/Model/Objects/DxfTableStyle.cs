// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfTableStyle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WW.Cad.Base;
using WW.Cad.IO;
using WW.Cad.Model.Entities;
using WW.Collections.Generic;

namespace WW.Cad.Model.Objects
{
  public class DxfTableStyle : DxfObject, INamedObject
  {
    private string string_0 = string.Empty;
    private string string_1 = string.Empty;
    private DxfTableCellStyle dxfTableCellStyle_0 = new DxfTableCellStyle() { Name = "Table", Id = 4 };
    private DxfTableCellStyleCollection dxfTableCellStyleCollection_0 = new DxfTableCellStyleCollection();
    private int int_1 = 101;
    public const string DefaultTableStyleName = "Standard";
    private TableFlowDirection tableFlowDirection_0;
    private ushort ushort_0;
    private bool bool_0;
    private bool bool_1;
    private DxfTableCellStyle dxfTableCellStyle_1;
    private DxfTableCellStyle dxfTableCellStyle_2;
    private DxfTableCellStyle dxfTableCellStyle_3;
    private byte byte_0;
    private int int_0;

    public DxfTableStyle()
      : this((string) null)
    {
    }

    public DxfTableStyle(string name)
      : this(name, true)
    {
    }

    internal DxfTableStyle(string name, bool createDefaultCellStyles)
    {
      this.string_0 = string.IsNullOrEmpty(name) ? string.Empty : name;
      this.dxfTableCellStyleCollection_0.Inserted += new ItemEventHandler<DxfTableCellStyle>(this.method_14);
      this.dxfTableCellStyleCollection_0.Removed += new ItemEventHandler<DxfTableCellStyle>(this.method_13);
      this.dxfTableCellStyleCollection_0.Set += new ItemSetEventHandler<DxfTableCellStyle>(this.method_12);
      if (!createDefaultCellStyles)
        return;
      this.method_11();
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

    public string Description
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public TableFlowDirection FlowDirection
    {
      get
      {
        return this.tableFlowDirection_0;
      }
      set
      {
        this.tableFlowDirection_0 = value;
      }
    }

    public ushort Flags
    {
      get
      {
        return this.ushort_0;
      }
      set
      {
        this.ushort_0 = value;
      }
    }

    public double HorizontalCellMargin
    {
      get
      {
        return this.dxfTableCellStyle_0.HorizontalMargin;
      }
      set
      {
        this.dxfTableCellStyle_0.HorizontalMargin = value;
      }
    }

    public double VerticalCellMargin
    {
      get
      {
        return this.dxfTableCellStyle_0.VerticalMargin;
      }
      set
      {
        this.dxfTableCellStyle_0.VerticalMargin = value;
      }
    }

    public bool SuppressTitle
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

    public bool SuppressHeaderRow
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public DxfTableCellStyle TableCellStyle
    {
      get
      {
        return this.dxfTableCellStyle_0;
      }
    }

    public DxfTableCellStyle TitleCellStyle
    {
      get
      {
        return this.dxfTableCellStyle_1;
      }
    }

    public DxfTableCellStyle HeaderCellStyle
    {
      get
      {
        return this.dxfTableCellStyle_2;
      }
    }

    public DxfTableCellStyle DataCellStyle
    {
      get
      {
        return this.dxfTableCellStyle_3;
      }
    }

    public DxfTableCellStyleCollection CellStyles
    {
      get
      {
        return this.dxfTableCellStyleCollection_0;
      }
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.dxfClass_17.ClassNumber;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return DxfTable.smethod_2(model);
    }

    public override string ObjectType
    {
      get
      {
        return "TABLESTYLE";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbTableStyle";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal override void vmethod_3(DxfModel modelContext)
    {
      base.vmethod_3(modelContext);
      if (this.dxfTableCellStyle_1 != null && !this.dxfTableCellStyleCollection_0.Contains(this.dxfTableCellStyle_1))
        this.dxfTableCellStyleCollection_0.Add(this.dxfTableCellStyle_1);
      if (this.dxfTableCellStyle_2 != null && !this.dxfTableCellStyleCollection_0.Contains(this.dxfTableCellStyle_2))
        this.dxfTableCellStyleCollection_0.Add(this.dxfTableCellStyle_2);
      if (this.dxfTableCellStyle_3 != null && !this.dxfTableCellStyleCollection_0.Contains(this.dxfTableCellStyle_3))
        this.dxfTableCellStyleCollection_0.Add(this.dxfTableCellStyle_3);
      foreach (DxfContentFormat dxfContentFormat in (Collection<DxfTableCellStyle>) this.dxfTableCellStyleCollection_0)
        dxfContentFormat.vmethod_0(modelContext, this);
    }

    public override bool Validate(DxfModel model, IList<DxfMessage> messages)
    {
      bool flag = true;
      foreach (DxfContentFormat dxfContentFormat in (Collection<DxfTableCellStyle>) this.dxfTableCellStyleCollection_0)
      {
        if (!dxfContentFormat.Validate(model, messages))
          flag = false;
      }
      if (!base.Validate(model, messages))
        flag = false;
      return flag;
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfTableStyle dxfTableStyle = (DxfTableStyle) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfTableStyle == null)
      {
        dxfTableStyle = new DxfTableStyle(this.Name, false);
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfTableStyle);
        dxfTableStyle.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfTableStyle;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      this.method_17()?.CellStyles.Clear();
      DxfTableStyle dxfTableStyle = (DxfTableStyle) from;
      this.string_1 = dxfTableStyle.string_1;
      this.tableFlowDirection_0 = dxfTableStyle.tableFlowDirection_0;
      this.ushort_0 = dxfTableStyle.ushort_0;
      this.bool_0 = dxfTableStyle.bool_0;
      this.bool_1 = dxfTableStyle.bool_1;
      this.dxfTableCellStyle_0 = (DxfTableCellStyle) dxfTableStyle.dxfTableCellStyle_0.Clone(cloneContext);
      foreach (DxfContentFormat dxfContentFormat in (Collection<DxfTableCellStyle>) dxfTableStyle.dxfTableCellStyleCollection_0)
        this.dxfTableCellStyleCollection_0.Add((DxfTableCellStyle) dxfContentFormat.Clone(cloneContext));
    }

    internal override void vmethod_1(Class1070 context)
    {
      base.vmethod_1(context);
      int num = 101;
      for (int index = 3; index < this.dxfTableCellStyleCollection_0.Count; ++index)
        this.dxfTableCellStyleCollection_0[index].Id = num++;
      if (this.Model.Header.AcadVersion >= DxfVersion.Dxf21 && context.FileFormat != FileFormat.Dxf)
      {
        DxfDictionary extensionDictionary = this.ExtensionDictionary;
        if (extensionDictionary == null)
          return;
        for (int index = extensionDictionary.Entries.Count - 1; index >= 0; --index)
        {
          if (extensionDictionary.Entries[index].Value is DxfCellStyleMap)
            extensionDictionary.Entries.RemoveAt(index);
        }
      }
      else
      {
        this.Model.method_31((DxfObject) this);
        DxfCellStyleMap dxfCellStyleMap = this.method_17();
        if (dxfCellStyleMap == null)
        {
          if (this.ExtensionDictionary == null)
            this.ExtensionDictionary = new DxfDictionary();
          dxfCellStyleMap = new DxfCellStyleMap();
          this.ExtensionDictionary.Entries.Add((IDictionaryEntry) new DxfDictionaryEntry((DxfObject) dxfCellStyleMap)
          {
            ValueReferenceIsHard = true
          });
        }
        dxfCellStyleMap.CellStyles.Clear();
        foreach (DxfTableCellStyle dxfTableCellStyle in (Collection<DxfTableCellStyle>) this.dxfTableCellStyleCollection_0)
          dxfCellStyleMap.CellStyles.Add(dxfTableCellStyle);
      }
    }

    public DxfTableCellStyle GetRowCellStyle(int rowIndex)
    {
      DxfTableCellStyle dxfTableCellStyle;
      switch (rowIndex)
      {
        case 0:
          dxfTableCellStyle = this.TitleCellStyle;
          break;
        case 1:
          dxfTableCellStyle = this.HeaderCellStyle;
          break;
        default:
          dxfTableCellStyle = this.DataCellStyle;
          break;
      }
      return dxfTableCellStyle;
    }

    public override string ToString()
    {
      return this.string_0;
    }

    internal void method_8(DxfTableCellStyle cellStyle)
    {
      this.dxfTableCellStyle_3 = cellStyle;
    }

    internal void method_9(DxfTableCellStyle cellStyle)
    {
      this.dxfTableCellStyle_2 = cellStyle;
    }

    internal void method_10(DxfTableCellStyle cellStyle)
    {
      this.dxfTableCellStyle_1 = cellStyle;
    }

    internal void method_11()
    {
      if (this.dxfTableCellStyle_3 == null)
      {
        this.dxfTableCellStyle_3 = new DxfTableCellStyle();
        this.dxfTableCellStyle_3.Id = 3;
        this.dxfTableCellStyle_3.Name = "_DATA";
        this.dxfTableCellStyleCollection_0.Insert(0, this.dxfTableCellStyle_3);
      }
      if (this.dxfTableCellStyle_1 == null)
      {
        this.dxfTableCellStyle_1 = new DxfTableCellStyle();
        this.dxfTableCellStyle_1.Id = 1;
        this.dxfTableCellStyle_1.Name = "_TITLE";
        this.dxfTableCellStyle_1.MergeFlags = TableCellStylePropertyFlags.MergeCellsOnCreation;
        this.dxfTableCellStyleCollection_0.Insert(1, this.dxfTableCellStyle_1);
      }
      if (this.dxfTableCellStyle_2 != null)
        return;
      this.dxfTableCellStyle_2 = new DxfTableCellStyle();
      this.dxfTableCellStyle_2.Id = 2;
      this.dxfTableCellStyle_2.Name = "_HEADER";
      this.dxfTableCellStyleCollection_0.Insert(2, this.dxfTableCellStyle_2);
    }

    internal byte Unknown1
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

    internal int Unknown3
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

    private void method_12(
      object sender,
      int index,
      DxfTableCellStyle oldItem,
      DxfTableCellStyle newItem)
    {
      if (oldItem != null)
      {
        oldItem.vmethod_1(this);
        this.method_15(oldItem);
      }
      if (newItem == null)
        return;
      DxfModel model = this.Model;
      if (model != null)
        newItem.vmethod_0(model, this);
      this.method_16(newItem);
    }

    private void method_13(object sender, int index, DxfTableCellStyle item)
    {
      if (item == null)
        return;
      item.vmethod_1(this);
      this.method_15(item);
    }

    private void method_14(object sender, int index, DxfTableCellStyle item)
    {
      if (item == null)
        return;
      DxfModel model = this.Model;
      if (model != null)
        item.vmethod_0(model, this);
      this.method_16(item);
    }

    private void method_15(DxfTableCellStyle cellStyle)
    {
      if (this.dxfTableCellStyle_3 == cellStyle)
        this.dxfTableCellStyle_3 = (DxfTableCellStyle) null;
      else if (this.dxfTableCellStyle_2 == cellStyle)
      {
        this.dxfTableCellStyle_2 = (DxfTableCellStyle) null;
      }
      else
      {
        if (this.dxfTableCellStyle_1 != cellStyle)
          return;
        this.dxfTableCellStyle_1 = (DxfTableCellStyle) null;
      }
    }

    private void method_16(DxfTableCellStyle cellStyle)
    {
      if (cellStyle.Name == "_DATA")
        this.dxfTableCellStyle_3 = cellStyle;
      else if (cellStyle.Name == "_HEADER")
      {
        this.dxfTableCellStyle_2 = cellStyle;
      }
      else
      {
        if (!(cellStyle.Name == "_TITLE"))
          return;
        this.dxfTableCellStyle_1 = cellStyle;
      }
    }

    internal DxfCellStyleMap method_17()
    {
      DxfCellStyleMap dxfCellStyleMap = (DxfCellStyleMap) null;
      DxfDictionary extensionDictionary = this.ExtensionDictionary;
      if (extensionDictionary != null)
      {
        foreach (IDictionaryEntry entry in (ActiveList<IDictionaryEntry>) extensionDictionary.Entries)
        {
          dxfCellStyleMap = entry.Value as DxfCellStyleMap;
          if (dxfCellStyleMap != null)
            break;
        }
      }
      return dxfCellStyleMap;
    }

    internal static class Class422
    {
      public const int int_0 = 0;
      public const int int_1 = 1;
      public const int int_2 = 2;
    }
  }
}
