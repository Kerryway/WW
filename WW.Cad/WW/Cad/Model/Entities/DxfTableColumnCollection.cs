// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableColumnCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Collections.Generic;

namespace WW.Cad.Model.Entities
{
  public class DxfTableColumnCollection : ActiveList<DxfTableColumn>
  {
    public DxfTableColumnCollection()
    {
    }

    public DxfTableColumnCollection(int capacity)
      : base(capacity)
    {
    }

    public DxfTableColumnCollection(IEnumerable<DxfTableColumn> collection)
      : base(collection)
    {
    }
  }
}
