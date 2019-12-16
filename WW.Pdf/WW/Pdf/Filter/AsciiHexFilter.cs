// Decompiled with JetBrains decompiler
// Type: WW.Pdf.Filter.AsciiHexFilter
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

namespace WW.Pdf.Filter
{
  public class AsciiHexFilter : IFilter
  {
    private static readonly byte[] byte_0 = new byte[16]{ (byte) 48, (byte) 49, (byte) 50, (byte) 51, (byte) 52, (byte) 53, (byte) 54, (byte) 55, (byte) 56, (byte) 57, (byte) 97, (byte) 98, (byte) 99, (byte) 100, (byte) 101, (byte) 102 };

    public IPdfObject Name
    {
      get
      {
        return (IPdfObject) new PdfName("ASCIIHexDecode");
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
      byte[] numArray1 = new byte[data.Length * 2 + 1];
      int num1 = 0;
      foreach (byte num2 in data)
      {
        byte[] numArray2 = numArray1;
        int index1 = num1;
        int num3 = index1 + 1;
        int num4 = (int) AsciiHexFilter.byte_0[(int) num2 >> 4];
        numArray2[index1] = (byte) num4;
        byte[] numArray3 = numArray1;
        int index2 = num3;
        num1 = index2 + 1;
        int num5 = (int) AsciiHexFilter.byte_0[(int) num2 & 15];
        numArray3[index2] = (byte) num5;
      }
      byte[] numArray4 = numArray1;
      int index = num1;
      int num6 = index + 1;
      numArray4[index] = (byte) 62;
      return numArray1;
    }
  }
}
