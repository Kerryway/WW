// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.MLineStyleFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects
{
  [Flags]
  public enum MLineStyleFlags : short
  {
    None = 0,
    FillOn = 1,
    DisplayMiters = 2,
    StartSquareEndCap = 16, // 0x0010
    StartInnerArcsCap = 32, // 0x0020
    StartRoundCap = 64, // 0x0040
    EndSquareCap = 256, // 0x0100
    EndInnerArcsCap = 512, // 0x0200
    EndRoundCap = 1024, // 0x0400
  }
}
