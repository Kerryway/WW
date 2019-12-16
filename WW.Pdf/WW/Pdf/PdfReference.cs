// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfReference
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace WW.Pdf
{
  public class PdfReference : IPdfObject
  {
    private IPdfIndirectObject ipdfIndirectObject_0;

    public PdfReference(IPdfIndirectObject referencedObject)
    {
      this.ipdfIndirectObject_0 = referencedObject;
    }

    public PdfReference()
    {
    }

    public IPdfIndirectObject ReferencedObject
    {
      get
      {
        return this.ipdfIndirectObject_0;
      }
      set
      {
        this.ipdfIndirectObject_0 = value;
      }
    }

    public void Write(ExtendedPdfOutput output)
    {
      output.Write(PdfWriter.GetReferenceString(this.ipdfIndirectObject_0));
    }
  }
}
