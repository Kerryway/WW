// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfDataCell
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects
{
  public class DxfDataCell
  {
    private DxfDataCellValue dxfDataCellValue_0 = (DxfDataCellValue) DxfDataCellValue.Unknown.Instance;

    public DxfDataCellValue Value
    {
      get
      {
        return this.dxfDataCellValue_0;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        this.dxfDataCellValue_0 = value;
      }
    }

    public DxfDataCell Clone(CloneContext context)
    {
      DxfDataCell dxfDataCell = new DxfDataCell();
      if (this.dxfDataCellValue_0 != null)
        dxfDataCell.Value = this.dxfDataCellValue_0.Clone(context);
      return dxfDataCell;
    }

    public override string ToString()
    {
      return this.dxfDataCellValue_0.ToString();
    }
  }
}
