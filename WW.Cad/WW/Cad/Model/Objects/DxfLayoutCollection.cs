﻿// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfLayoutCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;
using WW.Cad.Base;

namespace WW.Cad.Model.Objects
{
  public class DxfLayoutCollection : ActiveKeyedDxfHandledObjectCollection<string, DxfLayout>
  {
    public DxfLayoutCollection()
      : base((IEqualityComparer<string>) new CaseInsensitiveStringComparer())
    {
    }

    protected override string GetKeyForItem(DxfLayout layout)
    {
      return layout.Name;
    }
  }
}
