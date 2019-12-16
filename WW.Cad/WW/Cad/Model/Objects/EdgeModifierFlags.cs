// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.EdgeModifierFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects
{
  [Flags]
  public enum EdgeModifierFlags
  {
    None = 0,
    Overhang = 1,
    Jitter = 2,
    Width = 4,
    Color = 8,
    HaloGap = 16, // 0x00000010
    LineType = 32, // 0x00000020
    AlwaysOnTOp = 64, // 0x00000040
    Opacity = 128, // 0x00000080
    Wiggle = 256, // 0x00000100
    Texture = 512, // 0x00000200
  }
}
