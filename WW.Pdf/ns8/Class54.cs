// Decompiled with JetBrains decompiler
// Type: ns8.Class54
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns1;
using ns10;
using ns2;
using ns4;
using ns5;
using ns7;
using ns9;
using System.Collections.Generic;
using System.Security;
using WW.Pdf.Font.Gdi;

namespace ns8
{
  [SecuritySafeCritical]
  internal class Class54
  {
    private readonly IDictionary<string, string> idictionary_0 = (IDictionary<string, string>) new Dictionary<string, string>();
    private readonly FontStyles fontStyles_0 = new FontStyles();
    private const int int_0 = 1;
    private const int int_1 = 2;
    private const int int_2 = 4;
    private const int int_3 = 1;
    private const int int_4 = 2;
    private const byte byte_0 = 0;
    private const byte byte_1 = 1;
    private const byte byte_2 = 2;
    private readonly ns4.Class53 class53_0;

    public Class54(ns4.Class53 dc)
    {
      this.class53_0 = dc;
    }

    public string[] FamilyNames
    {
      get
      {
        Class61.EnumFontFamiliesEx(this.class53_0.Handle, new Class49()
        {
          byte_3 = (byte) 1
        }, new Delegate1(this.method_1), 1, 0);
        List<string> stringList = new List<string>((IEnumerable<string>) this.idictionary_0.Keys);
        stringList.Sort();
        return stringList.ToArray();
      }
    }

    public FontStyles method_0(string familyName)
    {
      this.fontStyles_0.method_0();
      Class61.EnumFontFamilies(this.class53_0.Handle, familyName, new Delegate0(this.method_2), 2);
      return this.fontStyles_0;
    }

    private int method_1(ref Struct3 logFont, ref Struct1 textMetric, uint fontType, int lParam)
    {
      if ((fontType & 4U) > 0U)
      {
        string string0 = logFont.class49_0.string_0;
        if (!this.idictionary_0.ContainsKey(string0))
          this.idictionary_0.Add(string0, string.Empty);
      }
      return 1;
    }

    private int method_2(ref Struct0 logFont, ref Struct1 textMetric, uint fontType, int lParam)
    {
      if ((fontType & 4U) > 0U)
      {
        bool flag = logFont.class49_0.int_4 > 600;
        if (logFont.class49_0.byte_0 == (byte) 0)
        {
          if (flag)
            this.fontStyles_0.BoldAvailable = true;
          else
            this.fontStyles_0.RegularAvailable = true;
        }
        else if (flag)
          this.fontStyles_0.BoldItalicAvailable = true;
        else
          this.fontStyles_0.ItalicAvailable = true;
      }
      return 1;
    }
  }
}
