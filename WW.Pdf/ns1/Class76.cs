// Decompiled with JetBrains decompiler
// Type: ns1.Class76
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns4;
using ns9;
using System;
using System.Security;
using System.Text;

namespace ns1
{
  [SecuritySafeCritical]
  internal class Class76
  {
    private readonly Class53 class53_0;
    private readonly ushort ushort_0;
    private readonly ushort ushort_1;
    private ushort[] ushort_2;

    public Class76(Class53 dc, ushort start, ushort end)
    {
      if ((int) start > (int) end)
        throw new ArgumentException("start cannot be greater than end");
      this.class53_0 = dc;
      this.ushort_0 = start;
      this.ushort_1 = end;
    }

    public ushort method_0(char c)
    {
      if (this.ushort_2 == null)
      {
        string lpstr = this.method_1();
        this.ushort_2 = new ushort[lpstr.Length];
        int glyphIndices = (int) Class61.GetGlyphIndices(this.class53_0.Handle, lpstr, lpstr.Length, this.ushort_2, 0U);
      }
      return this.ushort_2[(int) (ushort) ((uint) c - (uint) this.ushort_0)];
    }

    public ushort Start
    {
      get
      {
        return this.ushort_0;
      }
    }

    public ushort End
    {
      get
      {
        return this.ushort_1;
      }
    }

    private string method_1()
    {
      StringBuilder stringBuilder = new StringBuilder((int) this.End - (int) this.Start);
      for (ushort start = this.Start; (int) start <= (int) this.End; ++start)
        stringBuilder.Append((char) start);
      return stringBuilder.ToString();
    }
  }
}
