// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.BlendingFactorSource
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

namespace WW.OpenGL
{
  public enum BlendingFactorSource : uint
  {
    Zero = 0,
    One = 1,
    SourceAlpha = 770, // 0x00000302
    OneMinusSourceAlpha = 771, // 0x00000303
    DestinationAlpha = 772, // 0x00000304
    OneMinusDestinationAlpha = 773, // 0x00000305
    DestinationColor = 774, // 0x00000306
    OneMinusDestinationColor = 775, // 0x00000307
    SourceAlphaSaturate = 776, // 0x00000308
  }
}
