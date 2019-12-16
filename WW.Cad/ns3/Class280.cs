// Decompiled with JetBrains decompiler
// Type: ns3.Class280
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System.Collections.Generic;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class280 : Class260
  {
    private string string_0 = string.Empty;
    private List<Class567> list_1 = new List<Class567>();
    private DxfTableStyle dxfTableStyle_0;
    private DxfTableCellStyle dxfTableCellStyle_0;
    private Class567 class567_0;

    public Class280(DxfTableStyle tableStyle)
      : base((DxfObject) tableStyle)
    {
      this.dxfTableStyle_0 = tableStyle;
    }

    public DxfTableStyle TableStyle
    {
      get
      {
        return this.dxfTableStyle_0;
      }
    }

    public string TextStyleName
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

    public DxfTableCellStyle CurrentCellStyle
    {
      get
      {
        return this.dxfTableCellStyle_0;
      }
    }

    public Class567 CurrentCellStyleBuilder
    {
      get
      {
        return this.class567_0;
      }
    }

    public Class567 method_1()
    {
      this.dxfTableCellStyle_0 = new DxfTableCellStyle();
      this.class567_0 = new Class567(this.dxfTableCellStyle_0);
      this.list_1.Add(this.class567_0);
      return this.class567_0;
    }

    public void method_2(Class567 cellStyleBuilder)
    {
      this.list_1.Add(cellStyleBuilder);
    }

    public override void ResolveReferences(Class374 modelBuilder)
    {
      base.ResolveReferences(modelBuilder);
      foreach (Class567 class567 in this.list_1)
        class567.ResolveReferences(modelBuilder);
      bool flag = false;
      DxfDictionary extensionDictionary = this.dxfTableStyle_0.ExtensionDictionary;
      if (extensionDictionary != null && extensionDictionary.Entries.Count > 0)
      {
        IDictionaryEntry first = extensionDictionary.Entries.GetFirst("ACAD_ROUNDTRIP_2008_TABLESTYLE_CELLSTYLEMAP");
        if (first != null)
        {
          DxfCellStyleMap key = first.Value as DxfCellStyleMap;
          Class264 class264;
          if (key != null && modelBuilder.CellStyleMapBuilders.TryGetValue(key, out class264))
          {
            class264.ResolveReferences(modelBuilder, this.dxfTableStyle_0);
            flag = true;
          }
        }
      }
      if (flag)
        return;
      if (this.dxfTableStyle_0.DataCellStyle == null && this.list_1.Count > 0)
      {
        DxfTableCellStyle cellStyle = this.list_1[0].CellStyle;
        if (string.IsNullOrEmpty(cellStyle.Name))
          cellStyle.Name = "_DATA";
        this.dxfTableStyle_0.method_8(cellStyle);
      }
      if (this.dxfTableStyle_0.TitleCellStyle == null && this.list_1.Count > 1)
      {
        DxfTableCellStyle cellStyle = this.list_1[1].CellStyle;
        if (string.IsNullOrEmpty(cellStyle.Name))
          cellStyle.Name = "_TITLE";
        this.dxfTableStyle_0.method_10(cellStyle);
      }
      if (this.dxfTableStyle_0.HeaderCellStyle == null && this.list_1.Count > 2)
      {
        DxfTableCellStyle cellStyle = this.list_1[2].CellStyle;
        if (string.IsNullOrEmpty(cellStyle.Name))
          cellStyle.Name = "_HEADER";
        this.dxfTableStyle_0.method_9(cellStyle);
      }
      foreach (Class567 class567 in this.list_1)
      {
        if (class567.CellStyle != this.dxfTableStyle_0.TableCellStyle)
        {
          DxfTableCellStyle cellStyle = class567.CellStyle;
          DxfTableCellStyle dxfTableCellStyle;
          if (this.dxfTableStyle_0.CellStyles.TryGetValue(cellStyle.Name, out dxfTableCellStyle))
            this.dxfTableStyle_0.CellStyles[this.dxfTableStyle_0.CellStyles.IndexOf(dxfTableCellStyle)] = cellStyle;
          else
            this.dxfTableStyle_0.CellStyles.Add(cellStyle);
        }
      }
    }
  }
}
