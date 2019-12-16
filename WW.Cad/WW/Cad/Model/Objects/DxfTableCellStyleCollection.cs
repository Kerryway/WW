// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfTableCellStyleCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.ObjectModel;
using WW.Collections.Generic;

namespace WW.Cad.Model.Objects
{
  public class DxfTableCellStyleCollection : ActiveKeyedCollection<string, DxfTableCellStyle>
  {
    protected override string GetKeyForItem(DxfTableCellStyle item)
    {
      if (item != null)
        return item.Name;
      return string.Empty;
    }

    public DxfTableCellStyle GetById(int id)
    {
      if (id == 0)
        return (DxfTableCellStyle) null;
      DxfTableCellStyle dxfTableCellStyle1 = (DxfTableCellStyle) null;
      foreach (DxfTableCellStyle dxfTableCellStyle2 in (Collection<DxfTableCellStyle>) this)
      {
        if (dxfTableCellStyle2.Id == id)
        {
          dxfTableCellStyle1 = dxfTableCellStyle2;
          break;
        }
      }
      return dxfTableCellStyle1;
    }
  }
}
