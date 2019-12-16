// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Font.PdfFontInfo
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System;
using System.Collections.Generic;
using WW.Drawing;

namespace WW.Pdf.Font
{
  public class PdfFontInfo
  {
    private static readonly PdfFontInfo.FontKey fontKey_0 = new PdfFontInfo.FontKey("any", "normal", "normal");
    public const int MaxRegularFontWeight = 600;
    private readonly IDictionary<string, IFontMetric> idictionary_0;
    private readonly IDictionary<PdfFontInfo.FontKey, string> idictionary_1;
    private readonly IDictionary<string, IFontMetric> idictionary_2;

    public PdfFontInfo()
    {
      this.idictionary_1 = (IDictionary<PdfFontInfo.FontKey, string>) new Dictionary<PdfFontInfo.FontKey, string>();
      this.idictionary_2 = (IDictionary<string, IFontMetric>) new Dictionary<string, IFontMetric>();
      this.idictionary_0 = (IDictionary<string, IFontMetric>) new Dictionary<string, IFontMetric>();
    }

    public void AddFontProperties(string name, string family, string style, string weight)
    {
      this.idictionary_1.Add(PdfFontInfo.CreateFontKey(family, style, weight), name);
    }

    public void AddMetrics(string name, IFontMetric metrics)
    {
      this.idictionary_2.Add(name, metrics);
    }

    public string FontLookup(string family, string style, string weight)
    {
      return this.FontLookup(PdfFontInfo.CreateFontKey(family, style, weight));
    }

    public string FontLookup(PdfFontInfo.FontKey key)
    {
      string index;
      if (!this.idictionary_1.TryGetValue(key, out index) && !this.idictionary_1.TryGetValue(new PdfFontInfo.FontKey("any", key.Style, key.Weight), out index) && !this.idictionary_1.TryGetValue(PdfFontInfo.fontKey_0, out index))
        throw new SystemException("no default font defined by OutputConverter");
      this.idictionary_0[index] = this.idictionary_2[index];
      return index;
    }

    private bool method_0(string family, string style, string weight)
    {
      return this.idictionary_1.ContainsKey(PdfFontInfo.CreateFontKey(family, style, weight));
    }

    public static PdfFontInfo.FontKey CreateFontKey(
      string family,
      string style,
      string weight)
    {
      int result = 0;
      if (!string.IsNullOrEmpty(weight) && char.IsNumber(weight, 0) && !int.TryParse(weight, out result))
        result = 0;
      if (result > 600)
        weight = "bold";
      else if (result > 0)
        weight = "normal";
      return new PdfFontInfo.FontKey(family, style, weight);
    }

    public IDictionary<string, IFontMetric> NameToFontMetric
    {
      get
      {
        return this.idictionary_2;
      }
    }

    public IDictionary<PdfFontInfo.FontKey, string> FontKeyToName
    {
      get
      {
        return this.idictionary_1;
      }
    }

    public IFontMetric GetFontByPdfName(string fontName)
    {
      return this.idictionary_2[fontName];
    }

    public IDictionary<string, IFontMetric> UsedNameToFontMetric
    {
      get
      {
        return this.idictionary_0;
      }
    }

    public IFontMetric GetMetricsFor(string fontName)
    {
      this.idictionary_0[fontName] = this.idictionary_2[fontName];
      return this.idictionary_2[fontName];
    }

    public class FontKey
    {
      private string string_0;
      private string string_1;
      private string string_2;

      public FontKey(System.Drawing.Font font)
      {
        this.string_0 = font.FontFamily.Name.Replace(" ", string.Empty);
        this.string_1 = !FontUtil.IsItalic(font) ? "normal" : "italic";
        if (FontUtil.IsBold(font))
          this.string_2 = "bold";
        else
          this.string_2 = "normal";
      }

      public FontKey(string family, string style, string weight)
      {
        this.string_0 = family;
        this.string_1 = style;
        this.string_2 = weight;
      }

      public string Family
      {
        get
        {
          return this.string_0;
        }
      }

      public string Style
      {
        get
        {
          return this.string_1;
        }
      }

      public string Weight
      {
        get
        {
          return this.string_2;
        }
      }

      public override int GetHashCode()
      {
        return this.string_0.GetHashCode() ^ this.string_1.GetHashCode() ^ this.string_2.GetHashCode();
      }

      public override bool Equals(object obj)
      {
        PdfFontInfo.FontKey fontKey = obj as PdfFontInfo.FontKey;
        if (fontKey == null || !(this.string_0 == fontKey.string_0) || !(this.string_1 == fontKey.string_1))
          return false;
        return this.string_2 == fontKey.string_2;
      }

      public override string ToString()
      {
        return this.string_0 + "," + this.string_1 + "," + this.string_2;
      }
    }
  }
}
