// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.ClientAttributeFlags
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System;

namespace WW.OpenGL
{
  [Flags]
  public enum ClientAttributeFlags : uint
  {
    PixelStore = 1,
    VertexArray = 2,
    All = 4294967295, // 0xFFFFFFFF
  }
}
