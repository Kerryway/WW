// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.EntityEventArgs
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Entities
{
  public class EntityEventArgs : EventArgs
  {
    private readonly DxfEntity dxfEntity_0;

    public EntityEventArgs(DxfEntity entity)
    {
      this.dxfEntity_0 = entity;
    }

    public DxfEntity Entity
    {
      get
      {
        return this.dxfEntity_0;
      }
    }
  }
}
