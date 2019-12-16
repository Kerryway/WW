// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableCustomDataCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.IO;

namespace WW.Cad.Model.Entities
{
  public class DxfTableCustomDataCollection : List<DxfTableCustomData>
  {
    public DxfTableCustomDataCollection()
    {
    }

    public DxfTableCustomDataCollection(int capacity)
      : base(capacity)
    {
    }

    public DxfTableCustomDataCollection(IEnumerable<DxfTableCustomData> collection)
      : base(collection)
    {
    }

    internal void Write(DxfWriter w)
    {
      w.Write(1, (object) "DATAMAP_BEGIN");
      w.Write(90, (object) this.Count);
      foreach (DxfTableCustomData dxfTableCustomData in (List<DxfTableCustomData>) this)
        dxfTableCustomData.Write(w);
      w.Write(309, (object) "DATAMAP_END");
    }
  }
}
