// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Components.PdfPages
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using WW.Collections.Generic;

namespace WW.Pdf.Components
{
  public class PdfPages : PdfIndirectObject<PdfDictionary>
  {
    public PdfPages()
    {
      this.value = new PdfDictionary("Pages");
      PdfArray pdfArray = new PdfArray();
      pdfArray.Added += new ItemEventHandler<IPdfObject>(this.method_1);
      pdfArray.Removed += new ItemEventHandler<IPdfObject>(this.method_0);
      this.value[nameof (Kids)] = (IPdfObject) pdfArray;
      this.value["Count"] = (IPdfObject) new PdfInt(0);
    }

    public PdfArray Kids
    {
      get
      {
        return (PdfArray) this.value[nameof (Kids)];
      }
    }

    private void method_0(object sender, int index, IPdfObject item)
    {
      this.value["Count"] = (IPdfObject) new PdfInt(this.Kids.Count);
    }

    private void method_1(object sender, int index, IPdfObject item)
    {
      this.value["Count"] = (IPdfObject) new PdfInt(this.Kids.Count);
    }
  }
}
