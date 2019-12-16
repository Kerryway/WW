// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.Annotations.DxfScaleCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects.Annotations
{
  public class DxfScaleCollection : ActiveDxfHandledObjectCollection<DxfScale>
  {
    public DxfScale this[string name]
    {
      get
      {
        if (string.IsNullOrEmpty(name))
          return (DxfScale) null;
        foreach (DxfScale dxfScale in (DxfHandledObjectCollection<DxfScale>) this)
        {
          if (string.Compare(dxfScale.Name, name, StringComparison.InvariantCultureIgnoreCase) == 0)
            return dxfScale;
        }
        return (DxfScale) null;
      }
    }

    public bool TryGetValue(string name, out DxfScale scale)
    {
      scale = this[name];
      return scale != null;
    }

    public bool Contains(string name)
    {
      return this[name] != null;
    }
  }
}
