// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.BoundaryPathType
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Entities
{
  [Flags]
  public enum BoundaryPathType
  {
    None = 0,
    External = 1,
    Polyline = 2,
    Derived = 4,
    Textbox = 8,
    Outermost = 16, // 0x00000010
    NotClosed = 32, // 0x00000020
    SelfIntersecting = 64, // 0x00000040
    TextIsland = 128, // 0x00000080
    Duplicate = 256, // 0x00000100
    IsAnnotative = 512, // 0x00000200
    DoesNotSupportScale = 1024, // 0x00000400
    ForceAnnoAllVisible = 2048, // 0x00000800
    OrientToPaper = 4096, // 0x00001000
    IsAnnotativeBlock = 8192, // 0x00002000
  }
}
