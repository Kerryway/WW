// Decompiled with JetBrains decompiler
// Type: ns36.Class975
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Runtime.InteropServices;

namespace ns36
{
  internal static class Class975
  {
    [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
    public static extern bool DeleteObject(IntPtr hObject);
  }
}
