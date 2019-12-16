// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.DxfVPortCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Tables
{
  public class DxfVPortCollection : ActiveDxfHandledObjectCollection<DxfVPort>
  {
    public DxfVPort GetActiveVPort()
    {
      DxfVPort dxfVport1 = (DxfVPort) null;
      foreach (DxfVPort dxfVport2 in (DxfHandledObjectCollection<DxfVPort>) this)
      {
        if (string.Compare(dxfVport2.Name, "*Active", StringComparison.InvariantCultureIgnoreCase) == 0)
        {
          dxfVport1 = dxfVport2;
          break;
        }
      }
      return dxfVport1;
    }

    public DxfVPort this[string name]
    {
      get
      {
        if (string.IsNullOrEmpty(name))
          return (DxfVPort) null;
        foreach (DxfVPort dxfVport in (DxfHandledObjectCollection<DxfVPort>) this)
        {
          if (string.Compare(dxfVport.Name, name, StringComparison.InvariantCultureIgnoreCase) == 0)
            return dxfVport;
        }
        return (DxfVPort) null;
      }
    }

    public bool TryGetValue(string name, out DxfVPort item)
    {
      item = this[name];
      return item != null;
    }

    public bool Contains(string name)
    {
      return this[name] != null;
    }
  }
}
