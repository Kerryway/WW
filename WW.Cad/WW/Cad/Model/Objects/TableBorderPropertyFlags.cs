// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.TableBorderPropertyFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects
{
  [Flags]
  public enum TableBorderPropertyFlags
  {
    None = 0,
    BorderType = 1,
    LineWeight = 2,
    LineType = 4,
    Color = 8,
    Visibility = 16, // 0x00000010
    DoubleLineSpacing = 32, // 0x00000020
    All = DoubleLineSpacing | Visibility | Color | LineType | LineWeight | BorderType, // 0x0000003F
  }
}
