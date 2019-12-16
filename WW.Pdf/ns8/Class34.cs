// Decompiled with JetBrains decompiler
// Type: ns8.Class34
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using WW.Pdf;
using WW.Pdf.Filter;

namespace ns8
{
  internal class Class34 : IFilter
  {
    public Class34()
    {
      throw new UnsupportedFilterException("DCTDecode");
    }

    public IPdfObject Name
    {
      get
      {
        return (IPdfObject) new PdfName("DCTDecode");
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
      return data;
    }
  }
}
