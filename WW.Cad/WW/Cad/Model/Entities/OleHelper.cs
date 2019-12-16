// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.OleHelper
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;

namespace WW.Cad.Model.Entities
{
  [SecuritySafeCritical]
  [SuppressUnmanagedCodeSecurity]
  public static class OleHelper
  {
    private static Guid guid_0 = new Guid("00000000-0000-0000-C000-000000000046");

    [DllImport("ole32.dll")]
    private static extern int OleSetContainedObject([MarshalAs(UnmanagedType.IUnknown)] object pUnk, bool fContained);

    [DllImport("kernel32.dll")]
    private static extern IntPtr GlobalFree(IntPtr hMem);

    [DllImport("ole32.dll")]
    private static extern int OleDraw(
      [MarshalAs(UnmanagedType.IUnknown)] object pUnk,
      uint dwAspect,
      IntPtr hdcDraw,
      [In] ref Rectangle lprcBounds);

    [DllImport("ole32.dll")]
    private static extern int StgIsStorageILockBytes(OleHelper.Interface17 plkbyt);

    [DllImport("ole32.dll")]
    private static extern int GetHGlobalFromILockBytes(
      OleHelper.Interface17 pLkbyt,
      out IntPtr phglobal);

    [DllImport("kernel32.dll")]
    private static extern IntPtr GlobalLock(IntPtr handle);

    [DllImport("ole32.dll")]
    private static extern int OleLoad(
      OleHelper.Interface19 pStg,
      [In] ref Guid riid,
      OleHelper.Interface16 pClientSite,
      [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern bool GlobalUnlock(IntPtr handle);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr GlobalAlloc(int uFlags, int dwBytes);

    [DllImport("ole32.dll")]
    private static extern int CreateILockBytesOnHGlobal(
      IntPtr hGlobal,
      bool fDeleteOnRelease,
      out OleHelper.Interface17 ppLkbyt);

    [DllImport("ole32.dll")]
    private static extern int StgOpenStorageOnILockBytes(
      OleHelper.Interface17 plkbyt,
      OleHelper.Interface19 pStgPriority,
      uint grfMode,
      IntPtr snbEnclude,
      uint reserved,
      out OleHelper.Interface19 ppstgOpen);

    public static DxfOle.Type OleItemType(DxfOle ole)
    {
      try
      {
        object o = OleHelper.smethod_0(ole);
        if (o == null)
          return DxfOle.Type.Unknown;
        IntPtr iunknownForObject = Marshal.GetIUnknownForObject(o);
        if (iunknownForObject != IntPtr.Zero)
        {
          Guid iid = new Guid("0000011d-0000-0000-C000-000000000046");
          IntPtr ppv;
          Marshal.QueryInterface(iunknownForObject, ref iid, out ppv);
          if (ppv != IntPtr.Zero)
          {
            Marshal.Release(ppv);
            Marshal.Release(iunknownForObject);
            return DxfOle.Type.Link;
          }
          OleHelper.Interface20 objectForIunknown = Marshal.GetObjectForIUnknown(iunknownForObject) as OleHelper.Interface20;
          Marshal.Release(iunknownForObject);
          uint dwStatus = 0;
          return objectForIunknown.imethod_19(1U, ref dwStatus) == 0 && ((int) dwStatus & 8) == 0 ? DxfOle.Type.Embedded : DxfOle.Type.Static;
        }
      }
      catch (Exception ex)
      {
      }
      return DxfOle.Type.Unknown;
    }

    public static string OleUserType(DxfOle ole)
    {
      object o = OleHelper.smethod_0(ole);
      if (o != null)
      {
        IntPtr iunknownForObject = Marshal.GetIUnknownForObject(o);
        if (iunknownForObject != IntPtr.Zero)
        {
          OleHelper.Interface20 objectForIunknown = Marshal.GetObjectForIUnknown(iunknownForObject) as OleHelper.Interface20;
          Marshal.Release(iunknownForObject);
          if (objectForIunknown == null)
            return (string) null;
          string str = (string) null;
          try
          {
            str = objectForIunknown.imethod_13(1U);
          }
          catch (COMException ex)
          {
          }
          return str;
        }
      }
      return (string) null;
    }

    public static void OleHiMetrics(DxfOle ole, out int width, out int height)
    {
      width = 1000;
      height = 1000;
      object o = OleHelper.smethod_0(ole);
      if (o == null)
        return;
      IntPtr iunknownForObject = Marshal.GetIUnknownForObject(o);
      if (!(iunknownForObject != IntPtr.Zero))
        return;
      OleHelper.Interface20 objectForIunknown = Marshal.GetObjectForIUnknown(iunknownForObject) as OleHelper.Interface20;
      Marshal.Release(iunknownForObject);
      if (objectForIunknown == null)
        return;
      if (ole.OleObjectType == DxfOle.Type.Link && objectForIunknown.imethod_11() == 0U)
        objectForIunknown.imethod_10();
      if (ole.OleObjectType == DxfOle.Type.Static)
        return;
      Size psizel = new Size();
      objectForIunknown.imethod_15((uint) ole.DrawAspect, ref psizel);
      width = psizel.Width;
      height = psizel.Height;
    }

    public static string OleLinkPath(DxfOle ole)
    {
      object o = OleHelper.smethod_0(ole);
      if (o != null)
      {
        IntPtr iunknownForObject = Marshal.GetIUnknownForObject(o);
        if (iunknownForObject != IntPtr.Zero)
        {
          OleHelper.Interface21 objectForIunknown = Marshal.GetObjectForIUnknown(iunknownForObject) as OleHelper.Interface21;
          Marshal.Release(iunknownForObject);
          return objectForIunknown?.imethod_5();
        }
      }
      return (string) null;
    }

    private static object smethod_0(DxfOle ole)
    {
      if (ole.OleData == null)
        return (object) null;
      object obj;
      try
      {
        obj = OleHelper.smethod_1(ole);
      }
      catch (Exception ex)
      {
        obj = (object) null;
      }
      if (obj == null)
      {
        try
        {
          obj = OleHelper.smethod_1(ole);
        }
        catch (Exception ex)
        {
          obj = (object) null;
        }
      }
      return obj;
    }

    private static object smethod_1(DxfOle ole)
    {
      int length = ole.OleData.Length;
      if (length == 0)
        return (object) null;
      IntPtr num = OleHelper.GlobalAlloc(34, length);
      if (num == IntPtr.Zero)
        return (object) null;
      object ppvObj;
      try
      {
        IntPtr destination = OleHelper.GlobalLock(num);
        if (destination == IntPtr.Zero)
          return (object) null;
        Marshal.Copy(ole.OleData, 0, destination, ole.OleData.Length);
        OleHelper.GlobalUnlock(num);
        OleHelper.Interface17 ppLkbyt;
        OleHelper.Interface19 ppstgOpen;
        if (OleHelper.CreateILockBytesOnHGlobal(num, true, out ppLkbyt) != 0 || OleHelper.StgOpenStorageOnILockBytes(ppLkbyt, (OleHelper.Interface19) null, 16U, IntPtr.Zero, 0U, out ppstgOpen) != 0)
          return (object) null;
        if (OleHelper.OleLoad(ppstgOpen, ref OleHelper.guid_0, (OleHelper.Interface16) null, out ppvObj) != 0)
          return (object) null;
      }
      finally
      {
        OleHelper.GlobalFree(num);
      }
      return ppvObj;
    }

    public static Bitmap Preview(DxfOle ole, int width, int height)
    {
      object obj = OleHelper.smethod_0(ole);
      if (obj == null || width <= 0 || height <= 0)
        return (Bitmap) null;
      Rectangle lprcBounds = new Rectangle(0, 0, width, height);
      Bitmap bitmap = new Bitmap(width, height);
      int num;
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        IntPtr hdc = graphics.GetHdc();
        try
        {
          num = OleHelper.OleDraw(obj, (uint) ole.DrawAspect, hdc, ref lprcBounds);
        }
        finally
        {
          Marshal.FinalReleaseComObject(obj);
          graphics.ReleaseHdc(hdc);
        }
      }
      if (num == 0)
        return bitmap;
      bitmap.Dispose();
      return (Bitmap) null;
    }

    public static void FinishCreate(DxfOle ole)
    {
      object pUnk = OleHelper.smethod_0(ole);
      if (pUnk == null)
        return;
      OleHelper.OleSetContainedObject(pUnk, true);
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    private struct Struct2
    {
      [MarshalAs(UnmanagedType.U4)]
      public int int_0;
      [MarshalAs(UnmanagedType.U2)]
      public short short_0;
      [MarshalAs(UnmanagedType.U2)]
      public short short_1;
      [MarshalAs(UnmanagedType.U2)]
      public short short_2;
      [MarshalAs(UnmanagedType.U2)]
      public short short_3;
      [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)]
      public byte[] byte_0;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class COMRECT
    {
      public int left;
      public int top;
      public int right;
      public int bottom;

      public COMRECT()
      {
      }

      public COMRECT(int left, int top, int right, int bottom)
      {
        this.left = left;
        this.top = top;
        this.right = right;
        this.bottom = bottom;
      }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    private struct Struct3
    {
      public byte byte_0;
      public byte byte_1;
      public byte byte_2;
      public byte byte_3;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    private struct Struct4
    {
      public short short_0;
      public short short_1;
      public IntPtr intptr_0;
    }

    [Guid("0000010d-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    private interface Interface15
    {
      [MethodImpl(MethodImplOptions.PreserveSig)]
      int Draw(
        [MarshalAs(UnmanagedType.U4)] int dwDrawAspect,
        int lindex,
        IntPtr pvAspect,
        IntPtr ptd,
        IntPtr hdcTargetDev,
        IntPtr hdcDraw,
        ref Rectangle lprcBounds,
        IntPtr lprcWBounds,
        IntPtr pfnContinue,
        int dwContinue);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int imethod_0(
        [MarshalAs(UnmanagedType.U4)] int dwDrawAspect,
        int lindex,
        IntPtr pvAspect,
        IntPtr ptd,
        IntPtr hicTargetDev,
        out IntPtr ppColorSet);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int imethod_1([MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect, out IntPtr pdwFreeze);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int imethod_2([MarshalAs(UnmanagedType.U4)] int dwFreeze);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int imethod_3([MarshalAs(UnmanagedType.U4)] int aspects, [MarshalAs(UnmanagedType.U4)] int advf, [MarshalAs(UnmanagedType.Interface)] IAdviseSink pAdvSink);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int imethod_4([MarshalAs(UnmanagedType.LPArray)] out int[] paspects, [MarshalAs(UnmanagedType.LPArray)] out int[] advf, [MarshalAs(UnmanagedType.LPArray)] out IAdviseSink[] pAdvSink);
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("00000118-0000-0000-C000-000000000046")]
    [ComImport]
    private interface Interface16
    {
      void imethod_0();

      void imethod_1(uint dwAssign, uint dwWhichMoniker, ref object ppmk);

      void imethod_2(ref object ppContainer);

      void imethod_3();

      void imethod_4(bool fShow);

      void imethod_5();
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0000000A-0000-0000-C000-000000000046")]
    [ComImport]
    private interface Interface17
    {
      void imethod_0([MarshalAs(UnmanagedType.U8), In] long ulOffset, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), Out] byte[] pv, [MarshalAs(UnmanagedType.U4), In] int cb, [MarshalAs(UnmanagedType.LPArray), Out] int[] pcbRead);

      void imethod_1([MarshalAs(UnmanagedType.U8), In] long ulOffset, IntPtr pv, [MarshalAs(UnmanagedType.U4), In] int cb, [MarshalAs(UnmanagedType.LPArray), Out] int[] pcbWritten);

      void Flush();

      void imethod_2([MarshalAs(UnmanagedType.U8), In] long cb);

      void imethod_3([MarshalAs(UnmanagedType.U8), In] long libOffset, [MarshalAs(UnmanagedType.U8), In] long cb, [MarshalAs(UnmanagedType.U4), In] int dwLockType);

      void imethod_4([MarshalAs(UnmanagedType.U8), In] long libOffset, [MarshalAs(UnmanagedType.U8), In] long cb, [MarshalAs(UnmanagedType.U4), In] int dwLockType);

      void imethod_5(out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg, [MarshalAs(UnmanagedType.U4), In] int grfStatFlag);
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0000000d-0000-0000-C000-000000000046")]
    [ComImport]
    private interface Interface18
    {
      [MethodImpl(MethodImplOptions.PreserveSig)]
      uint imethod_0(uint celt, [MarshalAs(UnmanagedType.LPArray), Out] System.Runtime.InteropServices.STATSTG[] rgelt, out uint pceltFetched);

      void imethod_1(uint celt);

      void Reset();

      [return: MarshalAs(UnmanagedType.Interface)]
      OleHelper.Interface18 Clone();
    }

    [Guid("0000000b-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    private interface Interface19
    {
      void imethod_0(
        string pwcsName,
        uint grfMode,
        uint reserved1,
        uint reserved2,
        out System.Runtime.InteropServices.ComTypes.IStream ppstm);

      void imethod_1(
        string pwcsName,
        IntPtr reserved1,
        uint grfMode,
        uint reserved2,
        out System.Runtime.InteropServices.ComTypes.IStream ppstm);

      void imethod_2(
        string pwcsName,
        uint grfMode,
        uint reserved1,
        uint reserved2,
        out OleHelper.Interface19 ppstg);

      void imethod_3(
        string pwcsName,
        OleHelper.Interface19 pstgPriority,
        uint grfMode,
        IntPtr snbExclude,
        uint reserved,
        out OleHelper.Interface19 ppstg);

      void CopyTo(
        uint ciidExclude,
        Guid rgiidExclude,
        IntPtr snbExclude,
        OleHelper.Interface19 pstgDest);

      void imethod_4(
        string pwcsName,
        OleHelper.Interface19 pstgDest,
        string pwcsNewName,
        uint grfFlags);

      void Commit(uint grfCommitFlags);

      void imethod_5();

      void imethod_6(
        uint reserved1,
        IntPtr reserved2,
        uint reserved3,
        out OleHelper.Interface18 ppenum);

      void imethod_7(string pwcsName);

      void imethod_8(string pwcsOldName, string pwcsNewName);

      void imethod_9(string pwcsName, System.Runtime.InteropServices.FILETIME pctime, System.Runtime.InteropServices.FILETIME patime, System.Runtime.InteropServices.FILETIME pmtime);

      void imethod_10(Guid clsid);

      void imethod_11(uint grfStateBits, uint grfMask);

      void imethod_12(out System.Runtime.InteropServices.STATSTG pstatstg, uint grfStatFlag);
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("00000112-0000-0000-C000-000000000046")]
    [ComImport]
    private interface Interface20
    {
      void imethod_0(OleHelper.Interface16 pClientSite);

      void imethod_1(ref OleHelper.Interface16 ppClientSite);

      void imethod_2(object szContainerApp, object szContainerObj);

      void imethod_3(uint dwSaveOption);

      void imethod_4(uint dwWhichMoniker, object pmk);

      void imethod_5(uint dwAssign, uint dwWhichMoniker, object ppmk);

      void imethod_6(IDataObject pDataObject, bool fCreation, uint dwReserved);

      void imethod_7(uint dwReserved, ref IDataObject ppDataObject);

      void imethod_8(
        uint iVerb,
        uint lpmsg,
        object pActiveSite,
        uint lindex,
        uint hwndParent,
        uint lprcPosRect);

      void imethod_9(ref object ppEnumOleVerb);

      void imethod_10();

      uint imethod_11();

      void imethod_12(uint pClsid);

      [return: MarshalAs(UnmanagedType.LPWStr)]
      string imethod_13(uint dwFormOfType);

      void imethod_14(uint dwDrawAspect, uint psizel);

      void imethod_15(uint dwDrawAspect, ref Size psizel);

      int imethod_16(IAdviseSink pAdvSink, out uint pdwConnection);

      void imethod_17(uint dwConnection);

      void imethod_18(ref object ppenumAdvise);

      int imethod_19(uint dwAspect, ref uint dwStatus);

      void imethod_20(object pLogpal);
    }

    [Guid("0000011d-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    private interface Interface21
    {
      int imethod_0(uint dwUpdateOpt);

      int imethod_1(ref uint pdwUpdateOpt);

      int imethod_2(IntPtr pmk, IntPtr rclsid);

      int imethod_3(ref IntPtr ppmk);

      int imethod_4(IntPtr pszStatusText);

      [return: MarshalAs(UnmanagedType.LPWStr)]
      string imethod_5();

      int imethod_6(uint bindflags, IntPtr pbc);

      int imethod_7();

      int imethod_8(ref IntPtr ppunk);

      int imethod_9();

      int imethod_10(IntPtr pbc);
    }
  }
}
