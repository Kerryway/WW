// Decompiled with JetBrains decompiler
// Type: ns3.Class184
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Drawing;
using WW.Drawing;

namespace ns3
{
  internal class Class184 : IDisposable, IBitmap
  {
    public bool IsValid
    {
      get
      {
        return false;
      }
    }

    public int Width
    {
      get
      {
        return 0;
      }
    }

    public int Height
    {
      get
      {
        return 0;
      }
    }

    public ArgbColor GetPixel(int x, int y)
    {
      throw new ArgumentException("No pixels for invalid bitmap");
    }

    public byte GetAlpha(int x, int y)
    {
      throw new ArgumentException("No pixels for invalid bitmap");
    }

    public int GetRgb(int x, int y)
    {
      throw new ArgumentException("No pixels for invalid bitmap");
    }

    public byte[] GetRgbaBytes()
    {
      throw new ArgumentException("No pixels for invalid bitmap");
    }

    public void LockBits()
    {
    }

    public void UnlockBits()
    {
    }

    public Bitmap Image
    {
      get
      {
        return (Bitmap) null;
      }
    }

    public void Dispose()
    {
    }
  }
}
