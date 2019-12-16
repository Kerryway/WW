// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfTextString
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System.Text;

namespace WW.Pdf
{
  public class PdfTextString : IPdfObject
  {
    private PdfLiteralString pdfLiteralString_0 = new PdfLiteralString();

    private static string smethod_0(ushort c)
    {
      StringBuilder stringBuilder = new StringBuilder(4);
      Encoding bigEndianUnicode = Encoding.BigEndianUnicode;
      char[] chars = new char[1]{ (char) c };
      foreach (byte num in bigEndianUnicode.GetBytes(chars))
        stringBuilder.Append(new string((char) num, 1));
      return stringBuilder.ToString();
    }

    public PdfTextString()
    {
      this.pdfLiteralString_0.IsHexadecimalString = true;
    }

    public PdfTextString(string value)
    {
      this.pdfLiteralString_0.Value = value;
      this.pdfLiteralString_0.IsHexadecimalString = true;
    }

    public string Value
    {
      get
      {
        return this.pdfLiteralString_0.Value;
      }
      set
      {
        this.pdfLiteralString_0.Value = value;
      }
    }

    public void Write(ExtendedPdfOutput output)
    {
      string str = this.Value;
      StringBuilder stringBuilder = new StringBuilder(this.pdfLiteralString_0.Value.Length * 2 + 2);
      stringBuilder.Append('þ');
      stringBuilder.Append('ÿ');
      foreach (char ch in this.pdfLiteralString_0.Value)
        stringBuilder.Append(PdfTextString.smethod_0((ushort) ch));
      this.Value = stringBuilder.ToString();
      this.pdfLiteralString_0.Write(output);
      this.Value = str;
    }
  }
}
