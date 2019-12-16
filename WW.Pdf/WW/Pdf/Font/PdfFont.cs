// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Font.PdfFont
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace WW.Pdf.Font
{
  public abstract class PdfFont : PdfIndirectObject<PdfDictionary>
  {
    private const string string_0 = "BaseFont";
    private const string string_1 = "Subtype";
    private const string string_2 = "Name";
    private const string string_3 = "Encoding";
    private const string string_4 = "Font";

    protected PdfFont(string baseFont, string subtype)
    {
      this.value = new PdfDictionary("Font");
      this.value[nameof (BaseFont)] = (IPdfObject) new PdfName(baseFont);
      this.value[nameof (Subtype)] = (IPdfObject) new PdfName(subtype);
    }

    protected PdfFont(string name, string baseFont, string subtype)
      : this(baseFont, subtype)
    {
      this.value[nameof (Name)] = (IPdfObject) new PdfName(name);
    }

    public string Subtype
    {
      get
      {
        return ((PdfName) this.value[nameof (Subtype)]).Name;
      }
      set
      {
        ((PdfName) this.value[nameof (Subtype)]).Name = value;
      }
    }

    public string Name
    {
      get
      {
        if (!this.value.ContainsKey(nameof (Name)))
          return (string) null;
        return ((PdfName) this.value[nameof (Name)]).Name;
      }
      set
      {
        if (this.value.ContainsKey(nameof (Name)))
          ((PdfName) this.value[nameof (Name)]).Name = value;
        else
          this.value[nameof (Name)] = (IPdfObject) new PdfName(value);
      }
    }

    public string BaseFont
    {
      get
      {
        return ((PdfName) this.value[nameof (BaseFont)]).Name;
      }
      set
      {
        ((PdfName) this.value[nameof (BaseFont)]).Name = value.Replace(" ", string.Empty);
      }
    }

    public string Encoding
    {
      get
      {
        if (!this.value.ContainsKey(nameof (Encoding)))
          return (string) null;
        return ((PdfName) this.value[nameof (Encoding)]).Name;
      }
      set
      {
        if (this.value.ContainsKey(nameof (Encoding)))
          ((PdfName) this.value[nameof (Encoding)]).Name = value;
        else
          this.value[nameof (Encoding)] = (IPdfObject) new PdfName(value);
      }
    }
  }
}
