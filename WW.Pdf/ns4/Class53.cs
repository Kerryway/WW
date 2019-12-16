// Decompiled with JetBrains decompiler
// Type: ns4.Class53
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns1;
using ns9;
using System;
using System.Security;

namespace ns4
{
  [SecuritySafeCritical]
  internal class Class53 : IDisposable
  {
    private IntPtr intptr_0;

    public Class53()
    {
      this.intptr_0 = Class61.GetDC(IntPtr.Zero);
    }

    ~Class53()
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
      if (!(this.intptr_0 != IntPtr.Zero))
        return;
      Class61.DeleteDC(this.intptr_0);
      this.intptr_0 = IntPtr.Zero;
    }

    public IntPtr method_0(Class78 font)
    {
      return Class61.SelectObject(this.intptr_0, font.Handle);
    }

    public IntPtr method_1(Enum0 objectType)
    {
      return Class61.GetCurrentObject(this.intptr_0, objectType);
    }

    internal IntPtr Handle
    {
      get
      {
        return this.intptr_0;
      }
    }
  }
}
