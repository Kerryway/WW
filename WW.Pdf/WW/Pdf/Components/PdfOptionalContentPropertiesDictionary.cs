// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Components.PdfOptionalContentPropertiesDictionary
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace WW.Pdf.Components
{
  public class PdfOptionalContentPropertiesDictionary : PdfIndirectObject<PdfDictionary>
  {
    public PdfOptionalContentPropertiesDictionary()
    {
      this.Value = (IPdfObject) new PdfDictionary();
      this.value["OCGs"] = (IPdfObject) new PdfArray();
      this.value["D"] = (IPdfObject) new PdfReference();
    }

    private PdfArray Ocgs
    {
      get
      {
        return (PdfArray) this.value["OCGs"];
      }
    }

    public PdfOptionalContentConfigurationDictionary Dictionary
    {
      get
      {
        if (!this.value.ContainsKey("D"))
          return (PdfOptionalContentConfigurationDictionary) null;
        return (PdfOptionalContentConfigurationDictionary) ((PdfReference) this.value["D"]).ReferencedObject;
      }
      set
      {
        ((PdfReference) this.value["D"]).ReferencedObject = (IPdfIndirectObject) value;
      }
    }

    public void Register(PdfOptionalContentGroup ocg, bool defaultVisibility)
    {
      this.Ocgs.Add((IPdfObject) new PdfReference((IPdfIndirectObject) ocg));
      if (defaultVisibility)
        this.Dictionary.On.Add((IPdfObject) new PdfReference((IPdfIndirectObject) ocg));
      else
        this.Dictionary.Off.Add((IPdfObject) new PdfReference((IPdfIndirectObject) ocg));
    }
  }
}
