// Decompiled with JetBrains decompiler
// Type: ns1.Class78
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns2;
using ns9;
using System;
using System.Security;

namespace ns1
{
  [SecuritySafeCritical]
  internal class Class78 : IDisposable
  {
    private IntPtr intptr_0;
    private readonly string string_0;
    private readonly int int_0;

    public Class78(IntPtr hFont, string faceName, int height)
    {
      this.intptr_0 = hFont;
      this.string_0 = faceName;
      this.int_0 = height;
    }

    ~Class78()
    {
      this.vmethod_0(false);
    }

    public virtual void Dispose()
    {
      this.vmethod_0(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void vmethod_0(bool disposing)
    {
      if (!disposing || !(this.intptr_0 != IntPtr.Zero))
        return;
      Class61.DeleteObject(this.intptr_0);
      this.intptr_0 = IntPtr.Zero;
    }

    public static Class78 smethod_0(string faceName, int height, bool bold, bool italic)
    {
      return new Class78(Class61.CreateFontIndirect(new Class49() { byte_3 = (byte) 1, string_0 = faceName, int_0 = height, int_4 = bold ? 700 : 0, byte_0 = Convert.ToByte(italic) }), faceName, height);
    }

    public static Class78 smethod_1(string faceName, bool bold, bool italic, ns4.Class53 dc)
    {
      Class42 class42;
      using (Class78 font = Class78.smethod_0(faceName, 2048, bold, italic))
      {
        dc.method_0(font);
        class42 = font.method_0(dc);
      }
      return Class78.smethod_0(faceName, -Math.Abs(class42.EmSquare), bold, italic);
    }

    public Class42 method_0(ns4.Class53 dc)
    {
      return new Class42(dc, this);
    }

    public string FaceName
    {
      get
      {
        return this.string_0;
      }
    }

    public int Height
    {
      get
      {
        return this.int_0;
      }
    }

    public IntPtr Handle
    {
      get
      {
        return this.intptr_0;
      }
    }
  }
}
