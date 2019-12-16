// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.SplineFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Entities
{
  [Flags]
  public enum SplineFlags : ushort
  {
    None = 0,
    Closed = 1,
    Periodic = 2,
    Rational = 4,
    Planar = 8,
    Linear = 16, // 0x0010
  }
}
