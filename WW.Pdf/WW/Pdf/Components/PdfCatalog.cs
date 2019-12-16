// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Components.PdfCatalog
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System.Collections.Generic;

namespace WW.Pdf.Components
{
  public class PdfCatalog : PdfIndirectObject<PdfDictionary>
  {
    public PdfCatalog()
    {
      this.Value = (IPdfObject) new PdfDictionary("Catalog");
      this.value[nameof (Outlines)] = (IPdfObject) new PdfReference();
      this.value[nameof (Pages)] = (IPdfObject) new PdfReference();
    }

    public PdfOutlines Outlines
    {
      get
      {
        return (PdfOutlines) ((PdfReference) this.value[nameof (Outlines)]).ReferencedObject;
      }
      set
      {
        ((PdfReference) this.value[nameof (Outlines)]).ReferencedObject = (IPdfIndirectObject) value;
      }
    }

    public PdfPages Pages
    {
      get
      {
        return (PdfPages) ((PdfReference) this.value[nameof (Pages)]).ReferencedObject;
      }
      set
      {
        ((PdfReference) this.value[nameof (Pages)]).ReferencedObject = (IPdfIndirectObject) value;
      }
    }

    public PdfOptionalContentPropertiesDictionary OptionalContentProperties
    {
      get
      {
        if (!((Dictionary<string, IPdfObject>) this.Value).ContainsKey("OCProperties"))
          return (PdfOptionalContentPropertiesDictionary) null;
        return (PdfOptionalContentPropertiesDictionary) ((PdfReference) this.value["OCProperties"]).ReferencedObject;
      }
      set
      {
        if (!((Dictionary<string, IPdfObject>) this.Value).ContainsKey("OCProperties"))
          this.value["OCProperties"] = (IPdfObject) new PdfReference();
        ((PdfReference) this.value["OCProperties"]).ReferencedObject = (IPdfIndirectObject) value;
      }
    }
  }
}
