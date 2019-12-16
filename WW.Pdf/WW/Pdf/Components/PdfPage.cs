// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Components.PdfPage
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace WW.Pdf.Components
{
  public class PdfPage : PdfIndirectObject<PdfDictionary>
  {
    public PdfPage(PdfPages parent)
    {
      this.value = new PdfDictionary("Page");
      this.value[nameof (Parent)] = (IPdfObject) new PdfReference();
      this.Parent = parent;
      this.value[nameof (MediaBox)] = (IPdfObject) new PdfArray();
      this.value[nameof (Contents)] = (IPdfObject) new PdfReference();
      this.value[nameof (Resources)] = (IPdfObject) new PdfResourceDictionary();
    }

    public PdfPages Parent
    {
      get
      {
        return (PdfPages) ((PdfReference) this.value[nameof (Parent)]).ReferencedObject;
      }
      set
      {
        ((PdfReference) this.value[nameof (Parent)]).ReferencedObject = (IPdfIndirectObject) value;
      }
    }

    public PdfArray MediaBox
    {
      get
      {
        return (PdfArray) this.value[nameof (MediaBox)];
      }
    }

    public PdfArray CropBox
    {
      get
      {
        IPdfObject pdfObject;
        this.value.TryGetValue(nameof (CropBox), out pdfObject);
        return (PdfArray) pdfObject;
      }
      set
      {
        this.value[nameof (CropBox)] = (IPdfObject) value;
      }
    }

    public PdfContents Contents
    {
      get
      {
        return (PdfContents) ((PdfReference) this.value[nameof (Contents)]).ReferencedObject;
      }
      set
      {
        ((PdfReference) this.value[nameof (Contents)]).ReferencedObject = (IPdfIndirectObject) value;
      }
    }

    public PdfResourceDictionary Resources
    {
      get
      {
        return (PdfResourceDictionary) this.value[nameof (Resources)];
      }
    }
  }
}
