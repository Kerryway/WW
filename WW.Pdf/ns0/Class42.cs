// Decompiled with JetBrains decompiler
// Type: ns0.Class42
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns10;
using ns2;
using ns3;
using ns4;
using ns5;
using ns6;
using ns7;
using ns8;
using ns9;
using System;
using System.IO;
using System.Security;
using System.Text;
using WW.Pdf.Font.Gdi;

namespace ns0
{
  [SecuritySafeCritical]
  internal class Class42
  {
    public const long long_0 = 4294967295;
    private readonly Class80 class80_0;
    private readonly ns4.Class53 class53_0;
    private readonly ns1.Class78 class78_0;
    private readonly ns10.Class66 class66_0;
    private readonly Class52 class52_0;
    private readonly string string_0;
    private Class2 class2_0;
    private Class10 class10_0;
    private Class8 class8_0;
    private Class6 class6_0;
    private Class4 class4_0;
    private Class12 class12_0;
    private byte[] byte_0;

    internal Class42(ns4.Class53 dc, ns1.Class78 currentFont)
    {
      if (dc.Handle == IntPtr.Zero)
        throw new ArgumentNullException(nameof (dc), "Handle to device context cannot be null");
      if (dc.method_1(ns1.Enum0.const_3) == IntPtr.Zero)
        throw new ArgumentException("No font selected into supplied device context", nameof (dc));
      this.class53_0 = dc;
      this.class78_0 = currentFont;
      StringBuilder lpFaceName = new StringBuilder((int) byte.MaxValue);
      Class61.GetTextFace(dc.Handle, lpFaceName.Capacity, lpFaceName);
      this.string_0 = lpFaceName.ToString();
      this.class52_0 = new Class52(dc);
      this.class80_0 = new Class80(new MemoryStream(this.method_0()), this.string_0);
      this.class66_0 = new ns10.Class66(this.EmSquare);
      currentFont.Dispose();
    }

    public string FaceName
    {
      get
      {
        return this.string_0;
      }
    }

    public int EmSquare
    {
      get
      {
        this.method_9();
        return (int) this.class2_0.ushort_1;
      }
    }

    public int ItalicAngle
    {
      get
      {
        this.method_8();
        return this.class66_0.method_0((int) this.class10_0.ItalicAngle);
      }
    }

    public int Ascent
    {
      get
      {
        this.method_7();
        return this.class66_0.method_0((int) this.class8_0.short_0);
      }
    }

    public int Descent
    {
      get
      {
        this.method_7();
        return this.class66_0.method_0((int) this.class8_0.short_1);
      }
    }

    public int CapHeight
    {
      get
      {
        this.method_10();
        return this.class66_0.method_0(this.class4_0.CapHeight);
      }
    }

    public int XHeight
    {
      get
      {
        this.method_10();
        return this.class66_0.method_0(this.class4_0.XHeight);
      }
    }

    public int StemV
    {
      get
      {
        return this.class66_0.method_0(0);
      }
    }

    public ushort FirstChar
    {
      get
      {
        this.method_10();
        return this.class4_0.FirstChar;
      }
    }

    public ushort LastChar
    {
      get
      {
        this.method_10();
        return this.class4_0.LastChar;
      }
    }

    public int AverageWidth
    {
      get
      {
        return 0;
      }
    }

    public int MaxWidth
    {
      get
      {
        return 0;
      }
    }

    public bool IsEmbeddable
    {
      get
      {
        this.method_10();
        return this.class4_0.IsEmbeddable;
      }
    }

    public bool IsSubsettable
    {
      get
      {
        this.method_10();
        return this.class4_0.IsSubsettable;
      }
    }

    public int[] BoundingBox
    {
      get
      {
        this.method_9();
        return new int[4]{ this.class66_0.method_0((int) this.class2_0.short_0), this.class66_0.method_0((int) this.class2_0.short_1), this.class66_0.method_0((int) this.class2_0.short_2), this.class66_0.method_0((int) this.class2_0.short_3) };
      }
    }

    public int Flags
    {
      get
      {
        this.method_10();
        int num = 0;
        if (this.class4_0.IsMonospaced)
          num |= 1;
        if (this.class4_0.IsSerif)
          num |= 2;
        if (this.class4_0.IsScript)
          num |= 4;
        if (this.class4_0.IsItalic)
          num |= 64;
        return !this.class4_0.IsSymbolic ? num | 32 : num | 4;
      }
    }

    public byte[] method_0()
    {
      if (this.byte_0 == null)
      {
        try
        {
          switch (Class61.GetFontData(this.class53_0.Handle, Class46.smethod_0("ttcf"), 0U, (byte[]) null, 0U))
          {
            case 0:
            case uint.MaxValue:
              this.byte_0 = this.method_2();
              break;
            default:
              this.byte_0 = this.method_1();
              break;
          }
        }
        catch (Exception ex)
        {
          throw new Exception(string.Format("Failed to load data for font {0}", (object) this.FaceName), ex);
        }
      }
      return this.byte_0;
    }

    private byte[] method_1()
    {
      return new Class62(this.class53_0).method_0();
    }

    private byte[] method_2()
    {
      uint fontData = Class61.GetFontData(this.class53_0.Handle, 0U, 0U, (byte[]) null, 0U);
      if (fontData == uint.MaxValue)
        throw new InvalidOperationException("No font selected into device context");
      byte[] lpvBuffer = new byte[fontData];
      if (Class61.GetFontData(this.class53_0.Handle, 0U, 0U, lpvBuffer, fontData) == uint.MaxValue)
        throw new Exception("Failed to retrieve table data for font " + this.FaceName);
      return lpvBuffer;
    }

    public GdiKerningPairs KerningPairs
    {
      get
      {
        if (!this.class80_0.method_0("kern"))
          return GdiKerningPairs.Empty;
        this.class12_0 = (Class12) this.class80_0.method_1("kern");
        return new GdiKerningPairs(this.class12_0.KerningPairs, this.class66_0);
      }
    }

    public GdiKerningPairs AnsiKerningPairs
    {
      get
      {
        if (!this.class80_0.method_0("kern"))
          return GdiKerningPairs.Empty;
        this.class12_0 = (Class12) this.class80_0.method_1("kern");
        ns8.Class77 kerningPairs = this.class12_0.KerningPairs;
        ns8.Class77 pairs = new ns8.Class77();
        Class60 class600 = Class60.class60_0;
        for (int index1 = 0; index1 < 256; ++index1)
        {
          ushort left = this.class52_0.method_2((char) index1);
          for (int index2 = 0; index2 < 256; ++index2)
          {
            ushort right = this.class52_0.method_2((char) index2);
            if (kerningPairs.method_0(left, right))
              pairs.method_1(class600.method_0((char) index1), class600.method_0((char) index2), kerningPairs[left, right]);
          }
        }
        return new GdiKerningPairs(pairs, this.class66_0);
      }
    }

    public int[] method_3()
    {
      this.method_6();
      int[] numArray = new int[this.class6_0.Count];
      for (int index = 0; index < this.class6_0.Count; ++index)
        numArray[index] = this.class66_0.method_0((int) this.class6_0[index].AdvanceWidth);
      return numArray;
    }

    public int[] method_4()
    {
      this.method_6();
      int[] numArray = new int[256];
      int num1 = this.class66_0.method_0((int) this.class6_0[0].AdvanceWidth);
      for (int index = 0; index < 256; ++index)
        numArray[index] = num1;
      Class60 class600 = Class60.class60_0;
      for (int index = 0; index < 256; ++index)
      {
        ushort num2 = this.method_5((char) index);
        ushort num3 = class600.method_0((char) index);
        numArray[(int) num3] = this.class66_0.method_0((int) this.class6_0[(int) num2].AdvanceWidth);
      }
      return numArray;
    }

    public ushort method_5(char c)
    {
      return this.class52_0.method_2(c);
    }

    private void method_6()
    {
      if (this.class6_0 != null)
        return;
      this.class6_0 = (Class6) this.method_11("hmtx");
    }

    private void method_7()
    {
      if (this.class8_0 != null)
        return;
      this.class8_0 = (Class8) this.method_11("hhea");
    }

    private void method_8()
    {
      if (this.class10_0 != null)
        return;
      this.class10_0 = (Class10) this.method_11("post");
    }

    private void method_9()
    {
      if (this.class2_0 != null)
        return;
      this.class2_0 = (Class2) this.method_11("head");
    }

    private void method_10()
    {
      if (this.class4_0 != null)
        return;
      this.class4_0 = (Class4) this.method_11("OS/2");
    }

    private Class0 method_11(string name)
    {
      try
      {
        return this.class80_0.method_1(name);
      }
      catch
      {
        throw new Exception(string.Format("Unable to retrieve table {0} from font {1}", (object) name, (object) this.FaceName));
      }
    }
  }
}
