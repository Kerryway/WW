// Decompiled with JetBrains decompiler
// Type: ns3.Class264
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WW.Cad.Model.Objects;

namespace ns3
{
  internal class Class264 : Class260
  {
    private List<Class567> list_1 = new List<Class567>();
    private int int_0;
    private Class567 class567_0;

    public Class264(DxfCellStyleMap cellStyleMap)
      : base((DxfObject) cellStyleMap)
    {
    }

    public int CellStyleCount
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

    public Class567 CurrentCellStyleBuilder
    {
      get
      {
        return this.class567_0;
      }
    }

    public Class567 method_1()
    {
      this.class567_0 = new Class567(new DxfTableCellStyle());
      this.list_1.Add(this.class567_0);
      return this.class567_0;
    }

    public void ResolveReferences(Class374 modelBuilder, DxfTableStyle tableStyle)
    {
      DxfCellStyleMap dxfCellStyleMap = tableStyle.method_17();
      if (dxfCellStyleMap != null)
      {
        dxfCellStyleMap.CellStyles.Clear();
        foreach (DxfTableCellStyle cellStyle in (Collection<DxfTableCellStyle>) tableStyle.CellStyles)
          dxfCellStyleMap.CellStyles.Add(cellStyle);
      }
      foreach (Class567 class567 in this.list_1)
      {
        int index1 = -1;
        for (int index2 = tableStyle.CellStyles.Count - 1; index2 >= 0; --index2)
        {
          if (string.Compare(tableStyle.CellStyles[index2].Name, class567.CellStyle.Name, StringComparison.InvariantCultureIgnoreCase) == 0)
          {
            index1 = index2;
            break;
          }
        }
        class567.ResolveReferences(modelBuilder);
        if (index1 >= 0)
          tableStyle.CellStyles[index1] = class567.CellStyle;
        else
          tableStyle.CellStyles.Add(class567.CellStyle);
      }
    }
  }
}
