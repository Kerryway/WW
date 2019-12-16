// Decompiled with JetBrains decompiler
// Type: WW.OpenGL.RenderingContext
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using WW.OpenGL.Win;

namespace WW.OpenGL
{
  [SecuritySafeCritical]
  public class RenderingContext : IDisposable
  {
    private IntPtr intptr_0 = IntPtr.Zero;
    private IntPtr intptr_1 = IntPtr.Zero;
    private IntPtr intptr_2 = IntPtr.Zero;
    private object object_0 = new object();
    private bool bool_0;
    private int int_0;

    public RenderingContext(
      IntPtr windowHandle,
      IntPtr hdc,
      bool hdcMustBeDeleted,
      IntPtr hrc,
      int pixelFormatIndex)
    {
      this.intptr_0 = windowHandle;
      this.intptr_1 = hdc;
      this.bool_0 = hdcMustBeDeleted;
      this.intptr_2 = hrc;
      this.int_0 = pixelFormatIndex;
    }

    ~RenderingContext()
    {
      this.Dispose();
    }

    public IntPtr WindowHandle
    {
      get
      {
        return this.intptr_0;
      }
    }

    public IntPtr HDC
    {
      get
      {
        return this.intptr_1;
      }
    }

    public IntPtr HRC
    {
      get
      {
        return this.intptr_2;
      }
    }

    public int PixelFormatIndex
    {
      get
      {
        return this.int_0;
      }
    }

    public void MakeCurrent()
    {
      if (WGL.wglMakeCurrent(this.intptr_1, this.intptr_2) == 0)
        throw new Win32Exception(Marshal.GetLastWin32Error());
    }

    public static RenderingContext FromWindowHandle(
      IntPtr windowHandle,
      PixelFormatDescriptor pfd)
    {
      IntPtr dc = WGL.GetDC(windowHandle);
      WGL.wglSwapBuffers(dc);
      int pixelFormatIndex = RenderingContext.smethod_0(dc, pfd);
      IntPtr context = WGL.wglCreateContext(dc);
      if (context == IntPtr.Zero)
        throw new Win32Exception(Marshal.GetLastWin32Error());
      return new RenderingContext(windowHandle, dc, false, context, pixelFormatIndex);
    }

    public static RenderingContext FromWindowHandle(
      IntPtr windowHandle,
      int pixelFormatIndex)
    {
      IntPtr dc = WGL.GetDC(windowHandle);
      WGL.wglSwapBuffers(dc);
      PixelFormatDescriptor empty = PixelFormatDescriptor.Empty;
      if (WGL.SetPixelFormat(dc, pixelFormatIndex, ref empty) == 0)
        throw new Win32Exception(Marshal.GetLastWin32Error());
      IntPtr context = WGL.wglCreateContext(dc);
      if (context == IntPtr.Zero)
        throw new Win32Exception(Marshal.GetLastWin32Error());
      return new RenderingContext(windowHandle, dc, false, context, pixelFormatIndex);
    }

    public static RenderingContext FromBitmapInfo(
      BitmapInfo bitmapInfo,
      PixelFormatDescriptor pfd,
      out IntPtr bitmapHandle)
    {
      IntPtr dc = WGL.GetDC(IntPtr.Zero);
      IntPtr compatibleDc = WGL.CreateCompatibleDC(dc);
      WGL.ReleaseDC(IntPtr.Zero, dc);
      IntPtr ppvBits;
      bitmapHandle = WGL.CreateDIBSection(compatibleDc, ref bitmapInfo, DIBDataType.RgbColors, out ppvBits, IntPtr.Zero, 0U);
      if (bitmapHandle == IntPtr.Zero)
        throw new InternalException("Error in CreateDIBSection", (Exception) new Win32Exception(Marshal.GetLastWin32Error()));
      if (WGL.SelectObject(compatibleDc, bitmapHandle) == IntPtr.Zero)
        throw new InternalException("SelectObject failed");
      int pixelFormatIndex = RenderingContext.smethod_0(compatibleDc, pfd);
      IntPtr context = WGL.wglCreateContext(compatibleDc);
      if (context == IntPtr.Zero)
        throw new InternalException("Error in wglCreateContext", (Exception) new Win32Exception(Marshal.GetLastWin32Error()));
      return new RenderingContext(IntPtr.Zero, compatibleDc, true, context, pixelFormatIndex);
    }

    private static int smethod_0(IntPtr hdc, PixelFormatDescriptor pfd)
    {
      int iPixelFormat = WGL.ChoosePixelFormat(hdc, ref pfd);
      if (iPixelFormat == 0)
        throw new Win32Exception(Marshal.GetLastWin32Error());
      if (WGL.SetPixelFormat(hdc, iPixelFormat, ref pfd) == 0)
        throw new Win32Exception(Marshal.GetLastWin32Error());
      return iPixelFormat;
    }

    [SecuritySafeCritical]
    public void Dispose()
    {
      lock (this.object_0)
      {
        if (!(this.intptr_2 != IntPtr.Zero))
          return;
        if (WGL.wglDeleteContext(this.intptr_2) == 0)
        {
          int lastWin32Error = Marshal.GetLastWin32Error();
          throw new Win32Exception(lastWin32Error, string.Format("OpenGL DeleteContext call was not successful, error code: {0}", (object) lastWin32Error));
        }
        this.intptr_2 = IntPtr.Zero;
        if (this.bool_0)
        {
          if (WGL.DeleteDC(this.intptr_1) == 0)
          {
            int lastWin32Error = Marshal.GetLastWin32Error();
            throw new Win32Exception(lastWin32Error, string.Format("OpenGL DeleteDC call was not successful, error code: {0}", (object) lastWin32Error));
          }
        }
        else if (WGL.ReleaseDC(this.intptr_0, this.intptr_1) == 0)
        {
          int lastWin32Error = Marshal.GetLastWin32Error();
          throw new Win32Exception(lastWin32Error, string.Format("OpenGL ReleaseDC call was not successful, error code: {0}", (object) lastWin32Error));
        }
        this.intptr_0 = IntPtr.Zero;
        this.intptr_1 = IntPtr.Zero;
        this.int_0 = 0;
      }
    }
  }
}
