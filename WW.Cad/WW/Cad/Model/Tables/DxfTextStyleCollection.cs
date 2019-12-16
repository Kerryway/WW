// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.DxfTextStyleCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Tables
{
  public class DxfTextStyleCollection : ActiveDxfHandledObjectCollection<DxfTextStyle>
  {
    public DxfTextStyle this[string name]
    {
      get
      {
        if (string.IsNullOrEmpty(name))
          return (DxfTextStyle) null;
        foreach (DxfTextStyle dxfTextStyle in (DxfHandledObjectCollection<DxfTextStyle>) this)
        {
          if (string.Compare(dxfTextStyle.Name, name, StringComparison.InvariantCultureIgnoreCase) == 0)
            return dxfTextStyle;
        }
        return (DxfTextStyle) null;
      }
    }

    public bool TryGetValue(string name, out DxfTextStyle textStyle)
    {
      textStyle = this[name];
      return textStyle != null;
    }

    public bool Contains(string name)
    {
      return this[name] != null;
    }
  }
}
