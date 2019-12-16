// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.ClearBufferFlags
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System;

namespace WW.OpenGL
{
  [Flags]
  public enum ClearBufferFlags : uint
  {
    None = 0,
    ColorBuffer = 16384, // 0x00004000
    AccumBuffer = 512, // 0x00000200
    StencilBuffer = 1024, // 0x00000400
    DepthBuffer = 256, // 0x00000100
  }
}
