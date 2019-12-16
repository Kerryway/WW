// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfXRecordValueCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;

namespace WW.Cad.Model.Objects
{
  public class DxfXRecordValueCollection : List<DxfXRecordValue>
  {
    public void Add(short code, object value)
    {
      this.Add(new DxfXRecordValue(code, value));
    }
  }
}
