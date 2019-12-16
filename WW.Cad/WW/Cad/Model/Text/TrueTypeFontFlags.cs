// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Text.TrueTypeFontFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Text
{
  [Flags]
  public enum TrueTypeFontFlags
  {
    None = 0,
    Bold = 33554432, // 0x02000000
    Italic = 16777216, // 0x01000000
    PitchBitMask = 3,
    FamilyBitMask = 240, // 0x000000F0
    PitchAndFamilyBitMask = FamilyBitMask | PitchBitMask, // 0x000000F3
    CharacterSetBitMask = 65280, // 0x0000FF00
  }
}
