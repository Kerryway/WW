// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.ZeroSuppressionFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model
{
  [Flags]
  public enum ZeroSuppressionFlags
  {
    None = 0,
    SuppressZeroFeet = 1,
    SuppressZeroInches = 2,
    SuppressLeadingZeros = 4,
    SuppressTrailingZeros = 8,
  }
}
