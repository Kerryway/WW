// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.TessellationErrorCode
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

namespace WW.OpenGL
{
  public enum TessellationErrorCode : uint
  {
    MissingBeginPolygon = 100151, // 0x00018737
    MissingBeginContour = 100152, // 0x00018738
    MissingEndPolygon = 100153, // 0x00018739
    MissingEndContour = 100154, // 0x0001873A
    CoordTooLarge = 100155, // 0x0001873B
    NeedCombineCallback = 100156, // 0x0001873C
    Error7 = 100157, // 0x0001873D
    Error8 = 100158, // 0x0001873E
  }
}
