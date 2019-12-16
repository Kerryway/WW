// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfDictionary
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System.Collections.Generic;

namespace WW.Pdf
{
  public class PdfDictionary : Dictionary<string, IPdfObject>, IPdfObject
  {
    public PdfDictionary()
    {
    }

    public PdfDictionary(string type)
    {
      this.Add("Type", (IPdfObject) new PdfName(type));
    }

    public void Write(ExtendedPdfOutput output)
    {
      output.Write("<<");
      string data = this.Count > 1 ? "\n" : " ";
      output.Write(data);
      foreach (string key in this.Keys)
      {
        output.Write("/" + key + " ");
        IPdfObject pdfObject = this[key];
        output.Write(pdfObject);
        output.Write(data);
      }
      output.Write(">>");
    }
  }
}
