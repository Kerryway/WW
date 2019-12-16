// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Tables.DxfLineTypeCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;

namespace WW.Cad.Model.Tables
{
  public class DxfLineTypeCollection : ActiveKeyedDxfHandledObjectCollection<string, DxfLineType>
  {
    public DxfLineTypeCollection()
      : base((IEqualityComparer<string>) StringComparer.InvariantCultureIgnoreCase)
    {
    }

    protected override string GetKeyForItem(DxfLineType lineType)
    {
      return lineType.Name;
    }
  }
}
