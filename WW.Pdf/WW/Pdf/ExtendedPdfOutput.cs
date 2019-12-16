// Decompiled with JetBrains decompiler
// Type: WW.Pdf.ExtendedPdfOutput
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System.IO;

namespace WW.Pdf
{
  public class ExtendedPdfOutput : IPdfOutput
  {
    private static readonly byte[] byte_0 = new byte[1]{ (byte) 10 };
    private static readonly byte[] byte_1 = new byte[16]{ (byte) 48, (byte) 49, (byte) 50, (byte) 51, (byte) 52, (byte) 53, (byte) 54, (byte) 55, (byte) 56, (byte) 57, (byte) 97, (byte) 98, (byte) 99, (byte) 100, (byte) 101, (byte) 102 };
    private readonly IPdfOutput ipdfOutput_0;

    internal ExtendedPdfOutput(IPdfOutput pdfOut)
    {
      this.ipdfOutput_0 = pdfOut;
    }

    bool IPdfOutput.UseFilters
    {
      get
      {
        return this.ipdfOutput_0.UseFilters;
      }
    }

    void IPdfOutput.Write(byte[] data, int offset, int count)
    {
      this.ipdfOutput_0.Write(data, offset, count);
    }

    public ExtendedPdfOutput WriteLine()
    {
      this.ipdfOutput_0.Write(ExtendedPdfOutput.byte_0, 0, ExtendedPdfOutput.byte_0.Length);
      return this;
    }

    public ExtendedPdfOutput Write(byte[] data)
    {
      this.ipdfOutput_0.Write(data, 0, data.Length);
      return this;
    }

    public ExtendedPdfOutput WriteLine(byte[] data)
    {
      return this.Write(data).WriteLine();
    }

    public ExtendedPdfOutput Write(string data)
    {
      return this.Write(PdfWriter.StandardEncoding.GetBytes(data));
    }

    public ExtendedPdfOutput WriteLine(string data)
    {
      return this.Write(data).WriteLine();
    }

    public ExtendedPdfOutput Write(IPdfObject obj)
    {
      obj.Write(this);
      return this;
    }

    public ExtendedPdfOutput WriteLine(IPdfObject obj)
    {
      return this.Write(obj).WriteLine();
    }

    public static byte[] ToPdfHexadecimal(byte[] data)
    {
      MemoryStream memoryStream = new MemoryStream(data.Length * 2 + 2);
      memoryStream.WriteByte((byte) 60);
      for (int index = 0; index < data.Length; ++index)
      {
        byte num = data[index];
        memoryStream.WriteByte(ExtendedPdfOutput.byte_1[(int) num >> 4]);
        memoryStream.WriteByte(ExtendedPdfOutput.byte_1[(int) num & 15]);
      }
      memoryStream.WriteByte((byte) 62);
      return memoryStream.ToArray();
    }
  }
}
