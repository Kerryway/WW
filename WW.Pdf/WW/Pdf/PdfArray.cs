// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfArray
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System.Collections.Generic;
using WW.Collections.Generic;

namespace WW.Pdf
{
  public class PdfArray : ActiveList<IPdfObject>, IPdfObject
  {
    public void Write(ExtendedPdfOutput output)
    {
      output.Write("[");
      if (this.Count > 0)
      {
        output.Write(this[0]);
        for (int index = 1; index < this.Count; ++index)
        {
          output.Write(" ");
          output.Write(this[index]);
        }
      }
      output.Write("]");
    }

    public void AddRange(IEnumerable<int> range)
    {
      foreach (int num in range)
        this.Add((IPdfObject) new PdfInt(num));
    }
  }
}
