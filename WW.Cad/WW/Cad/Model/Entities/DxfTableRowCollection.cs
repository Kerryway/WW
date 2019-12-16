// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableRowCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Collections.Generic;

namespace WW.Cad.Model.Entities
{
  public class DxfTableRowCollection : ActiveList<DxfTableRow>
  {
    public DxfTableRowCollection()
    {
    }

    public DxfTableRowCollection(int capacity)
      : base(capacity)
    {
    }

    public DxfTableRowCollection(IEnumerable<DxfTableRow> collection)
      : base(collection)
    {
    }
  }
}
