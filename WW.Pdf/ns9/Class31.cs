// Decompiled with JetBrains decompiler
// Type: ns9.Class31
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns1;
using ns10;
using ns4;
using System;
using System.Collections.Generic;
using WW.Pdf;
using WW.Pdf.Font;
using WW.Pdf.Font.Gdi;

namespace ns9
{
  internal class Class31 : ns0.Class30, IFontDescriptor
  {
    public const string string_0 = "Identity-H";
    protected Class53 class53_0;
    protected Class42 class42_0;
    protected GdiKerningPairs gdiKerningPairs_0;
    protected int[] int_1;
    protected string string_1;
    protected FontProperties fontProperties_0;
    protected IDictionary<ushort, char> idictionary_0;
    protected Class52 class52_0;

    public Class31(FontProperties properties)
    {
      this.fontProperties_0 = properties;
      this.string_1 = properties.FaceName.Replace(" ", "-");
      this.idictionary_0 = (IDictionary<ushort, char>) new Dictionary<ushort, char>();
      this.method_0();
    }

    private void method_0()
    {
      this.class53_0 = new Class53();
      Class78 class78 = Class78.smethod_1(this.fontProperties_0.FaceName, this.fontProperties_0.IsBold, this.fontProperties_0.IsItalic, this.class53_0);
      this.class52_0 = new Class52(this.class53_0);
      this.class42_0 = class78.method_0(this.class53_0);
    }

    ~Class31()
    {
      this.class53_0.Dispose();
    }

    public override string CidBaseFont
    {
      get
      {
        return this.string_1;
      }
    }

    public override PdfWArray WArray
    {
      get
      {
        List<ushort> ushortList = new List<ushort>((IEnumerable<ushort>) this.idictionary_0.Keys);
        ushortList.Sort();
        int[] widths = this.method_1((IList<ushort>) ushortList);
        PdfWArray pdfWarray = new PdfWArray((int) ushortList[0]);
        pdfWarray.AddEntry(widths);
        return pdfWarray;
      }
    }

    public override IDictionary<ushort, char> CMapEntries
    {
      get
      {
        return (IDictionary<ushort, char>) new Dictionary<ushort, char>(this.idictionary_0);
      }
    }

    private int[] method_1(IList<ushort> indicies)
    {
      int indicy = (int) indicies[0];
      int[] numArray = new int[(int) indicies[indicies.Count - 1] - indicy + 1];
      Array.Clear((Array) numArray, 0, numArray.Length);
      foreach (ushort orderedGlyph in this.OrderedGlyphs)
        numArray[(int) orderedGlyph - indicy] = this.Widths[(int) orderedGlyph];
      return numArray;
    }

    internal IEnumerable<ushort> OrderedGlyphs
    {
      get
      {
        List<ushort> ushortList = new List<ushort>((IEnumerable<ushort>) this.idictionary_0.Keys);
        ushortList.Sort();
        return (IEnumerable<ushort>) ushortList;
      }
    }

    public override PdfFontSubTypeEnum SubType
    {
      get
      {
        return PdfFontSubTypeEnum.CIDFontType2;
      }
    }

    public override string FontName
    {
      get
      {
        return this.string_1;
      }
    }

    public override string Encoding
    {
      get
      {
        return "Identity-H";
      }
    }

    public override IFontDescriptor Descriptor
    {
      get
      {
        return (IFontDescriptor) this;
      }
    }

    public override bool MultiByteFont
    {
      get
      {
        return true;
      }
    }

    public override ushort MapCharacter(char c)
    {
      ushort glyphIndex = this.class52_0.method_2(c);
      this.vmethod_0(glyphIndex, c);
      return glyphIndex;
    }

    protected virtual void vmethod_0(ushort glyphIndex, char c)
    {
      if (this.idictionary_0.ContainsKey(glyphIndex))
        return;
      this.idictionary_0.Add(glyphIndex, c);
    }

    public override int Ascender
    {
      get
      {
        return this.class42_0.Ascent;
      }
    }

    public override int Descender
    {
      get
      {
        return this.class42_0.Descent;
      }
    }

    public override int CapHeight
    {
      get
      {
        return this.class42_0.CapHeight;
      }
    }

    public override int FirstChar
    {
      get
      {
        return (int) this.class42_0.FirstChar;
      }
    }

    public override int LastChar
    {
      get
      {
        return (int) this.class42_0.LastChar;
      }
    }

    public override int GetWidth(ushort charIndex)
    {
      this.method_2();
      return this.int_1[(int) charIndex];
    }

    public override int[] Widths
    {
      get
      {
        this.method_2();
        return this.int_1;
      }
    }

    protected void method_2()
    {
      if (this.int_1 != null)
        return;
      this.int_1 = this.class42_0.method_3();
    }

    public int Flags
    {
      get
      {
        return this.class42_0.Flags;
      }
    }

    public int[] FontBBox
    {
      get
      {
        return this.class42_0.BoundingBox;
      }
    }

    public int ItalicAngle
    {
      get
      {
        return this.class42_0.ItalicAngle;
      }
    }

    public int StemV
    {
      get
      {
        return this.class42_0.StemV;
      }
    }

    public bool HasKerningInfo
    {
      get
      {
        if (this.gdiKerningPairs_0 == null)
          this.gdiKerningPairs_0 = this.class42_0.KerningPairs;
        return this.gdiKerningPairs_0.Count != 0;
      }
    }

    public bool IsEmbeddable
    {
      get
      {
        return this.class42_0.IsEmbeddable;
      }
    }

    public bool IsSubsettable
    {
      get
      {
        return this.class42_0.IsSubsettable;
      }
    }

    public virtual byte[] FontData
    {
      get
      {
        return this.class42_0.method_0();
      }
    }

    public GdiKerningPairs KerningInfo
    {
      get
      {
        if (this.gdiKerningPairs_0 == null)
          this.gdiKerningPairs_0 = this.class42_0.KerningPairs;
        return this.gdiKerningPairs_0;
      }
    }
  }
}
