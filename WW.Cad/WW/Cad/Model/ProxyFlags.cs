// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.ProxyFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model
{
  [Flags]
  public enum ProxyFlags : ushort
  {
    None = 0,
    EraseAllowed = 1,
    TransformAllowed = 2,
    ColorChangeAllowed = 4,
    LayerChangeAllowed = 8,
    LinetypeChangeAllowed = 16, // 0x0010
    LinetypeScaleChangeAllowed = 32, // 0x0020
    VisibilityChangeAllowed = 64, // 0x0040
    CloningAllowed = 128, // 0x0080
    LineweightChangeAllowed = 256, // 0x0100
    PlotStyleNameChangeAllowed = 512, // 0x0200
    DisablesProxyWarningDialog = 1024, // 0x0400
    R13FormatProxy = 32768, // 0x8000
    AllOperationsExceptCloningAllowed = PlotStyleNameChangeAllowed | LineweightChangeAllowed | VisibilityChangeAllowed | LinetypeScaleChangeAllowed | LinetypeChangeAllowed | LayerChangeAllowed | ColorChangeAllowed | TransformAllowed | EraseAllowed, // 0x037F
    AllOperationsAllowed = AllOperationsExceptCloningAllowed | CloningAllowed, // 0x03FF
  }
}
