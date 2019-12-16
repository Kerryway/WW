// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.Win.PFD
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

namespace WW.OpenGL.Win
{
  public static class PFD
  {
    public enum PixelType : byte
    {
      RGBA,
      ColorIndex,
    }

    public enum LayerType : byte
    {
      MainPlane = 0,
      OverlayPlane = 1,
      UnderlayPlane = 255, // 0xFF
    }

    [System.Flags]
    public enum Flags : uint
    {
      None = 0,
      DoubleBuffer = 1,
      Stereo = 2,
      DrawToWindow = 4,
      DrawToBitmap = 8,
      SupportGDI = 16, // 0x00000010
      SupportOpenGL = 32, // 0x00000020
      GenericFormat = 64, // 0x00000040
      NeedPalette = 128, // 0x00000080
      NeedSystemPalette = 256, // 0x00000100
      SwapExchange = 512, // 0x00000200
      SwapCopy = 1024, // 0x00000400
      SwapLayerBuffers = 2048, // 0x00000800
      GenericAccelerated = 4096, // 0x00001000
      SupportDirectDraw = 8192, // 0x00002000
      DepthDontCare = 536870912, // 0x20000000
      DoubleBufferDontCare = 1073741824, // 0x40000000
      StereoDontCare = 2147483648, // 0x80000000
    }
  }
}
