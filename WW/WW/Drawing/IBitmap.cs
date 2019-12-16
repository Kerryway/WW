// Decompiled with JetBrains decompiler
// Type: WW.Drawing.IBitmap
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Drawing;

namespace WW.Drawing
{
  public interface IBitmap : IDisposable
  {
    bool IsValid { get; }

    int Width { get; }

    int Height { get; }

    ArgbColor GetPixel(int x, int y);

    byte GetAlpha(int x, int y);

    int GetRgb(int x, int y);

    byte[] GetRgbaBytes();

    Bitmap Image { get; }

    void LockBits();

    void UnlockBits();
  }
}
