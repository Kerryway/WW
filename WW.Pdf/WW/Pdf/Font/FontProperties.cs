// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Font.FontProperties
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace WW.Pdf.Font
{
  public sealed class FontProperties
  {
    private readonly string string_0;
    private readonly string string_1;
    private readonly bool bool_0;
    private readonly bool bool_1;

    public FontProperties(string faceName, bool bold, bool italic)
    {
      this.string_0 = faceName;
      this.string_1 = faceName.Replace(" ", string.Empty);
      this.bool_0 = bold;
      this.bool_1 = italic;
    }

    public string FaceName
    {
      get
      {
        return this.string_0;
      }
    }

    public string PdfBaseName
    {
      get
      {
        return this.string_1;
      }
    }

    public bool IsRegular
    {
      get
      {
        if (!this.IsBold)
          return !this.IsItalic;
        return false;
      }
    }

    public bool IsBold
    {
      get
      {
        return this.bool_0;
      }
    }

    public bool IsItalic
    {
      get
      {
        return this.bool_1;
      }
    }

    public bool IsBoldItalic
    {
      get
      {
        if (this.IsBold)
          return this.IsItalic;
        return false;
      }
    }
  }
}
