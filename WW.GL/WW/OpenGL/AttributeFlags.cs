// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.AttributeFlags
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System;

namespace WW.OpenGL
{
  [Flags]
  public enum AttributeFlags : uint
  {
    None = 0,
    Current = 1,
    Point = 2,
    Line = 4,
    Polygon = 8,
    PolygonStipple = 16, // 0x00000010
    PixelMode = 32, // 0x00000020
    Lighting = 64, // 0x00000040
    Fog = 128, // 0x00000080
    DepthBuffer = 256, // 0x00000100
    AccumBuffer = 512, // 0x00000200
    StencilBuffer = 1024, // 0x00000400
    Viewport = 2048, // 0x00000800
    Transform = 4096, // 0x00001000
    Enable = 8192, // 0x00002000
    ColorBuffer = 16384, // 0x00004000
    Hint = 32768, // 0x00008000
    Eval = 65536, // 0x00010000
    List = 131072, // 0x00020000
    Texture = 262144, // 0x00040000
    Scissor = 524288, // 0x00080000
    All = Scissor | Texture | List | Eval | Hint | ColorBuffer | Enable | Transform | Viewport | StencilBuffer | AccumBuffer | DepthBuffer | Fog | Lighting | PixelMode | PolygonStipple | Polygon | Line | Point | Current, // 0x000FFFFF
  }
}
