// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Filter.FlateFilter
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System.IO;
using WW.IO.Compression;

namespace WW.Pdf.Filter
{
  public class FlateFilter : IFilter
  {
    public IPdfObject Name
    {
      get
      {
        return (IPdfObject) new PdfName("FlateDecode");
      }
    }

    public IPdfObject DecodeParameters
    {
      get
      {
        return (IPdfObject) PdfNull.Null;
      }
    }

    public bool HasDecodeParameters
    {
      get
      {
        return false;
      }
    }

    public byte[] Encode(byte[] data)
    {
      using (MemoryStream memoryStream = new MemoryStream(data.Length))
      {
        using (ZlibCompressStream zlibCompressStream = new ZlibCompressStream((Stream) memoryStream, true))
          zlibCompressStream.Write(data, 0, data.Length);
        return memoryStream.ToArray();
      }
    }
  }
}
