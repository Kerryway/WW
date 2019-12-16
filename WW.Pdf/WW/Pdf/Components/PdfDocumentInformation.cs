// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Components.PdfDocumentInformation
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace WW.Pdf.Components
{
  public class PdfDocumentInformation : PdfIndirectObject<PdfDictionary>
  {
    public PdfDocumentInformation()
    {
      this.value = new PdfDictionary();
    }

    public string Title
    {
      get
      {
        return this.method_0(nameof (Title));
      }
      set
      {
        this.method_1(nameof (Title), value);
      }
    }

    public string Author
    {
      get
      {
        return this.method_0(nameof (Author));
      }
      set
      {
        this.method_1(nameof (Author), value);
      }
    }

    public string Subject
    {
      get
      {
        return this.method_0(nameof (Subject));
      }
      set
      {
        this.method_1(nameof (Subject), value);
      }
    }

    public string Keywords
    {
      get
      {
        return this.method_0(nameof (Keywords));
      }
      set
      {
        this.method_1(nameof (Keywords), value);
      }
    }

    public string Creator
    {
      get
      {
        return this.method_0(nameof (Creator));
      }
      set
      {
        this.method_1(nameof (Creator), value);
      }
    }

    public string Producer
    {
      get
      {
        return this.method_0(nameof (Producer));
      }
      set
      {
        this.method_1(nameof (Producer), value);
      }
    }

    public string CreationDate
    {
      get
      {
        return this.method_0(nameof (CreationDate));
      }
      set
      {
        this.method_1(nameof (CreationDate), value);
      }
    }

    public string ModificationDate
    {
      get
      {
        return this.method_0("ModDate");
      }
      set
      {
        this.method_1("ModDate", value);
      }
    }

    private string method_0(string key)
    {
      IPdfObject pdfObject;
      if (this.value.TryGetValue(key, out pdfObject))
        return ((PdfLiteralString) pdfObject).Value;
      return string.Empty;
    }

    private void method_1(string key, string value)
    {
      if (value == null)
        this.value.Remove(key);
      else
        this.value[key] = (IPdfObject) new PdfLiteralString(value);
    }
  }
}
