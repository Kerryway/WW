// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.Win.WGL
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace WW.OpenGL.Win
{
  [SecuritySafeCritical]
  [SuppressUnmanagedCodeSecurity]
  public static class WGL
  {
    [DllImport("user32", SetLastError = true)]
    public static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("user32", SetLastError = true)]
    public static extern int ReleaseDC(IntPtr hWnd, IntPtr dc);

    [DllImport("gdi32", SetLastError = true)]
    public static extern int DeleteDC(IntPtr dc);

    [DllImport("gdi32", SetLastError = true)]
    public static extern int ChoosePixelFormat(IntPtr hdc, [In] ref PixelFormatDescriptor pfd);

    [DllImport("gdi32", SetLastError = true)]
    public static extern int DescribePixelFormat(
      IntPtr hdc,
      int pixelFormat,
      uint size,
      [In, Out] ref PixelFormatDescriptor pfd);

    [DllImport("gdi32", SetLastError = true)]
    public static extern int SetPixelFormat(
      IntPtr hdc,
      int iPixelFormat,
      [In] ref PixelFormatDescriptor pfd);

    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern IntPtr CreateDIBSection(
      IntPtr hdc,
      [In] ref BitmapInfo pbmi,
      DIBDataType dataType,
      out IntPtr ppvBits,
      IntPtr hSection,
      uint dwOffset);

    [DllImport("gdi32.dll", SetLastError = true)]
    public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

    [DllImport("opengl32", SetLastError = true)]
    public static extern IntPtr wglCreateContext(IntPtr hdc);

    [DllImport("opengl32", SetLastError = true)]
    public static extern IntPtr wglGetCurrentContext();

    [DllImport("opengl32", SetLastError = true)]
    public static extern int wglMakeCurrent(IntPtr hdc, IntPtr hglrc);

    [DllImport("opengl32", SetLastError = true)]
    public static extern int wglDeleteContext(IntPtr hglrc);

    [DllImport("opengl32", SetLastError = true)]
    public static extern IntPtr wglSwapBuffers(IntPtr hdc);

    static WGL()
    {
      GL.GetString((StringName) 0);
    }
  }
}
