// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.IndexCreationFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model
{
  [Flags]
  public enum IndexCreationFlags : byte
  {
    NoIndex = 0,
    LayerIndex = 1,
    SpatialIndex = 2,
    LayerAndSpatialIndex = SpatialIndex | LayerIndex, // 0x03
  }
}
