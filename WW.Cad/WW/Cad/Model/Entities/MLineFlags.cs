// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.MLineFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Entities
{
  [Flags]
  public enum MLineFlags : short
  {
    None = 0,
    HasAtLeastOneVertex = 1,
    Closed = 2,
    SuppressStartCaps = 4,
    SuppressEndCaps = 8,
  }
}
