// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableCellCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;

namespace WW.Cad.Model.Entities
{
  public class DxfTableCellCollection : List<DxfTableCell>
  {
    public DxfTableCellCollection()
    {
    }

    public DxfTableCellCollection(IEnumerable<DxfTableCell> collection)
      : base(collection)
    {
    }

    public DxfTableCellCollection(int capacity)
      : base(capacity)
    {
    }
  }
}
