// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfFileIdentifier
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System;
using WW.Text;

namespace WW.Pdf
{
  public class PdfFileIdentifier : IPdfObject
  {
    private readonly byte[] byte_0;
    private readonly byte[] byte_1;

    public PdfFileIdentifier()
    {
      this.byte_0 = Encodings.Ascii.GetBytes(Guid.NewGuid().ToString("N"));
      this.byte_1 = (byte[]) this.byte_0.Clone();
    }

    public PdfFileIdentifier(byte[] createdPart)
    {
      this.byte_0 = (byte[]) createdPart.Clone();
      this.byte_1 = (byte[]) createdPart.Clone();
    }

    public byte[] CreatedPart
    {
      get
      {
        return this.byte_0;
      }
    }

    public byte[] ModifiedPart
    {
      get
      {
        return this.byte_1;
      }
    }

    public void Write(ExtendedPdfOutput output)
    {
      output.Write("[");
      output.Write(ExtendedPdfOutput.ToPdfHexadecimal(this.CreatedPart));
      output.Write(" ");
      output.Write(ExtendedPdfOutput.ToPdfHexadecimal(this.ModifiedPart));
      output.WriteLine("]");
    }
  }
}
