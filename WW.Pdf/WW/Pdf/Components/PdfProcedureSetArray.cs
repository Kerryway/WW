// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Components.PdfProcedureSetArray
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using WW.Collections.Generic;

namespace WW.Pdf.Components
{
  public class PdfProcedureSetArray : PdfIndirectObject<PdfArray>
  {
    public PdfProcedureSetArray()
    {
      this.value = new PdfArray();
      this.value.Add((IPdfObject) new PdfName("PDF"));
      this.value.Add((IPdfObject) new PdfName("Text"));
    }

    public void AddProcedure(PdfName proc)
    {
      foreach (PdfName pdfName in (ActiveList<IPdfObject>) this.value)
      {
        if (pdfName.Name == proc.Name)
          return;
      }
      this.value.Add((IPdfObject) proc);
    }
  }
}
