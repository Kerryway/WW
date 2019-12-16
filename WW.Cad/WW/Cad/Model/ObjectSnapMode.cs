// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.ObjectSnapMode
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model
{
  [Flags]
  public enum ObjectSnapMode : ushort
  {
    None = 0,
    EndPoint = 1,
    MidPoint = 2,
    Center = 4,
    Node = 8,
    Quadrant = 16, // 0x0010
    Intersection = 32, // 0x0020
    Insertion = 64, // 0x0040
    Perpendicular = 128, // 0x0080
    Tangent = 256, // 0x0100
    Nearest = 512, // 0x0200
    ClearsAllObjectSnaps = 1024, // 0x0400
    ApparentIntersection = 2048, // 0x0800
    Extension = 4096, // 0x1000
    Parallel = 8192, // 0x2000
    AllModes = Parallel | Extension | ApparentIntersection | ClearsAllObjectSnaps | Nearest | Tangent | Perpendicular | Insertion | Intersection | Quadrant | Node | Center | MidPoint | EndPoint, // 0x3FFF
    SwitchedOff = 16384, // 0x4000
  }
}
