// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.Win.BitmapInfo
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System.Runtime.InteropServices;

namespace WW.OpenGL.Win
{
  [StructLayout(LayoutKind.Explicit)]
  public struct BitmapInfo
  {
    [FieldOffset(0)]
    public int Size;
    [FieldOffset(4)]
    public int Width;
    [FieldOffset(8)]
    public int Height;
    [FieldOffset(12)]
    public short Planes;
    [FieldOffset(14)]
    public short BitCount;
    [FieldOffset(16)]
    public int Compression;
    [FieldOffset(20)]
    public int SizeImage;
    [FieldOffset(24)]
    public int XPixelsPerMeter;
    [FieldOffset(28)]
    public int YPixelsPerMeter;
    [FieldOffset(32)]
    public int ColorUsed;
    [FieldOffset(36)]
    public int ColorImportant;
    [FieldOffset(40)]
    public int Colors;
  }
}
