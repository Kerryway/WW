// Decompiled with JetBrains decompiler
// Type: WW.Windows.Caret
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using System;
using System.Runtime.InteropServices;

namespace WW.Windows
{
  public static class Caret
  {
    [DllImport("User32.dll")]
    public static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

    [DllImport("user32.dll")]
    public static extern bool DestroyCaret();

    [DllImport("User32.dll")]
    public static extern int ShowCaret(IntPtr hWnd);

    [DllImport("User32.dll")]
    public static extern int HideCaret(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool SetCaretPos(int x, int y);
  }
}
