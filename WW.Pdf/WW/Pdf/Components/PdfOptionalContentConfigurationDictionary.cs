// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Components.PdfOptionalContentConfigurationDictionary
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace WW.Pdf.Components
{
  public class PdfOptionalContentConfigurationDictionary : PdfIndirectObject<PdfDictionary>
  {
    public PdfOptionalContentConfigurationDictionary()
    {
      this.value = new PdfDictionary();
    }

    public PdfArray On
    {
      get
      {
        if (!this.value.ContainsKey("ON"))
          this.value.Add("ON", (IPdfObject) new PdfArray());
        return (PdfArray) this.value["ON"];
      }
    }

    public PdfArray Off
    {
      get
      {
        if (!this.value.ContainsKey("OFF"))
          this.value.Add("OFF", (IPdfObject) new PdfArray());
        return (PdfArray) this.value["OFF"];
      }
    }

    public PdfArray Order
    {
      get
      {
        if (!this.value.ContainsKey(nameof (Order)))
          this.value.Add(nameof (Order), (IPdfObject) new PdfArray());
        return (PdfArray) this.value[nameof (Order)];
      }
    }
  }
}
