// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfVersion
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model
{
  public enum DxfVersion : short
  {
    Dxf10 = 6,
    Dxf10PlusUnofficial = 8,
    Dxf12 = 9,
    Dxf13 = 12, // 0x000C
    Dxf14Preview = 13, // 0x000D
    Dxf14 = 14, // 0x000E
    Dxf15 = 15, // 0x000F
    Dxf18 = 18, // 0x0012
    Dxf21 = 21, // 0x0015
    Dxf24 = 24, // 0x0018
    Current = 27, // 0x001B
    Dxf27 = 27, // 0x001B
    Unknown = 999, // 0x03E7
  }
}
