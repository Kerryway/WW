// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfContentStream
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System.IO;

namespace WW.Pdf
{
  public class PdfContentStream : PdfStream, IPdfOutput
  {
    public static readonly byte[] DefaultNewLine = new byte[1]{ (byte) 10 };
    protected MemoryStream stream;
    private readonly ExtendedPdfOutput extendedPdfOutput_0;

    public PdfContentStream()
    {
      this.stream = new MemoryStream();
      this.extendedPdfOutput_0 = new ExtendedPdfOutput((IPdfOutput) this);
    }

    public ExtendedPdfOutput XOut
    {
      get
      {
        return this.extendedPdfOutput_0;
      }
    }

    public override byte[] Data
    {
      get
      {
        return this.stream.ToArray();
      }
    }

    public bool UseFilters
    {
      get
      {
        return true;
      }
    }

    public void Write(byte[] data, int offset, int count)
    {
      this.stream.Write(data, offset, count);
    }
  }
}
