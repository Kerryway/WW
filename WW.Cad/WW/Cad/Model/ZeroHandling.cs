// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.ZeroHandling
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model
{
  public enum ZeroHandling : byte
  {
    SuppressZeroFeetAndInches = 0,
    ShowZeroFeetAndInches = 1,
    ShowZeroFeetSuppressZeroInches = 2,
    SuppressZeroFeetShowZeroInches = 3,
    SuppressDecimalLeadingZeroes = 4,
    SuppressDecimalTrailingZeroes = 8,
    SuppressDecimalLeadingAndTrailingZeroes = 12, // 0x0C
  }
}
