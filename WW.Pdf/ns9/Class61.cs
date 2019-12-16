// Decompiled with JetBrains decompiler
// Type: ns9.Class61
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns1;
using ns10;
using ns2;
using ns5;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace ns9
{
  [SecuritySafeCritical]
  [SuppressUnmanagedCodeSecurity]
  internal sealed class Class61
  {
    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    internal static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    internal static extern uint GetFontData(
      IntPtr hdc,
      uint dwTable,
      uint dwOffset,
      [MarshalAs(UnmanagedType.LPArray)] byte[] lpvBuffer,
      uint cbData);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    internal static extern int AddFontResourceEx([MarshalAs(UnmanagedType.LPTStr), In] string lpszFilename, uint fl, int pdv);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    internal static extern bool RemoveFontResourceEx([MarshalAs(UnmanagedType.LPTStr), In] string lpFileName, uint fl, int pdv);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    internal static extern IntPtr CreateFontIndirect([MarshalAs(UnmanagedType.LPStruct)] Class49 lplf);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    internal static extern uint GetGlyphIndices(
      IntPtr hdc,
      string lpstr,
      int c,
      [MarshalAs(UnmanagedType.LPArray)] ushort[] pgi,
      uint fl);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    internal static extern uint GetFontUnicodeRanges(IntPtr hdc, [MarshalAs(UnmanagedType.LPStruct), Out] Class63 lpgs);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    internal static extern IntPtr DeleteObject(IntPtr hgdiobj);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    internal static extern IntPtr GetCurrentObject(IntPtr hdc, Enum0 uObjectType);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    internal static extern int GetTextFace(IntPtr hdc, int nCount, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpFaceName);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    internal static extern bool DeleteDC(IntPtr hdc);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    internal static extern int EnumFontFamilies(
      IntPtr hdc,
      [MarshalAs(UnmanagedType.LPTStr)] string lpszFamily,
      Delegate0 lpEnumFontFamProc,
      int lParam);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    internal static extern int EnumFontFamiliesEx(
      IntPtr hdc,
      [MarshalAs(UnmanagedType.LPStruct)] Class49 lplf,
      Delegate1 lpEnumFontFamProc,
      int lParam,
      int dwFlags);
  }
}
