// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Components.PdfOptionalContentGroup
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace WW.Pdf.Components
{
  public class PdfOptionalContentGroup : PdfIndirectObject<PdfDictionary>
  {
    public PdfOptionalContentGroup()
    {
      this.value = new PdfDictionary("OCG");
      this.value[nameof (Name)] = (IPdfObject) new PdfTextString();
    }

    public PdfTextString Name
    {
      get
      {
        return (PdfTextString) this.value[nameof (Name)];
      }
      set
      {
        this.value[nameof (Name)] = (IPdfObject) value;
      }
    }
  }
}
