// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.ViewportStatusFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Entities
{
  [Flags]
  public enum ViewportStatusFlags
  {
    None = 0,
    PerspectiveMode = 1,
    ClipFront = 2,
    ClipBack = 4,
    FollowUcs = 8,
    ClipFrontNotAtEye = 16, // 0x00000010
    UcsIconVisible = 32, // 0x00000020
    UcsIconAtOrigin = 64, // 0x00000040
    FastZoom = 128, // 0x00000080
    SnapMode = 256, // 0x00000100
    GridMode = 512, // 0x00000200
    IsometricSnapStyle = 1024, // 0x00000400
    HidePlot = 2048, // 0x00000800
    KIsoPairTop = 4096, // 0x00001000
    KIsoPairRight = 8192, // 0x00002000
    LockViewPortZoom = 16384, // 0x00004000
    Reserved = 32768, // 0x00008000
    NonRectangularClip = 65536, // 0x00010000
    DisableViewPort = 131072, // 0x00020000
    DisplayGridBeyondLimits = 262144, // 0x00040000
    GridAdaptive = 524288, // 0x00080000
    GridSubdivisionsAllowed = 1048576, // 0x00100000
    GridFollowUcs = 2097152, // 0x00200000
  }
}
