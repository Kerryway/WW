// Decompiled with JetBrains decompiler
// Type: ns10.Class52
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns1;
using ns11;
using ns4;
using ns5;
using ns9;
using System;
using System.Collections;
using System.Security;

namespace ns10
{
  [SecuritySafeCritical]
  internal class Class52
  {
    private static readonly IComparer icomparer_0 = (IComparer) new Class58();
    private Class76[] class76_0;

    public Class52(Class53 dc)
    {
      this.method_0(dc);
    }

    public int Count
    {
      get
      {
        return this.class76_0.Length;
      }
    }

    private void method_0(Class53 dc)
    {
      Class63 lpgs = new Class63();
      if (Class61.GetFontUnicodeRanges(dc.Handle, lpgs) == 0U)
        throw new Exception("Unable to retrieve unicode ranges.");
      this.class76_0 = new Class76[ lpgs.uint_3];
      int index1 = 0;
      int num1 = 0;
      for (; (long) index1 < (long) lpgs.uint_3; ++index1)
      {
        byte[] byte0_1 = lpgs.byte_0;
        int index2 = num1;
        int num2 = index2 + 1;
        int num3 = (int) byte0_1[index2];
        byte[] byte0_2 = lpgs.byte_0;
        int index3 = num2;
        int num4 = index3 + 1;
        int num5 = (int) byte0_2[index3] << 8;
        ushort start = (ushort) (num3 + num5);
        byte[] byte0_3 = lpgs.byte_0;
        int index4 = num4;
        int num6 = index4 + 1;
        int num7 = (int) byte0_3[index4];
        byte[] byte0_4 = lpgs.byte_0;
        int index5 = num6;
        num1 = index5 + 1;
        int num8 = (int) byte0_4[index5] << 8;
        ushort num9 = (ushort) (num7 + num8);
        this.class76_0[index1] = new Class76(dc, start, (ushort) ((int) start + (int) num9 - 1));
      }
    }

    internal Class76 method_1(char c)
    {
      int index = Array.BinarySearch((Array) this.class76_0, 0, this.class76_0.Length, (object) c, Class52.icomparer_0);
      if (index >= 0)
        return this.class76_0[index];
      return (Class76) null;
    }

    public ushort method_2(char c)
    {
      Class76 class76 = this.method_1(c);
      if (class76 != null)
        return class76.method_0(c);
      return 0;
    }
  }
}
