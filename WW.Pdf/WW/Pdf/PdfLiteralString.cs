// Decompiled with JetBrains decompiler
// Type: WW.Pdf.PdfLiteralString
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System.Text;

namespace WW.Pdf
{
  public class PdfLiteralString : IPdfObject
  {
    private string string_0;
    private bool bool_0;

    public PdfLiteralString()
    {
    }

    public PdfLiteralString(string value)
    {
      this.string_0 = value;
    }

    public string Value
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public bool IsHexadecimalString
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public void Write(ExtendedPdfOutput output)
    {
      if (this.bool_0)
      {
        StringBuilder stringBuilder = new StringBuilder(this.string_0.Length * 2);
        for (int index = 0; index < this.string_0.Length; ++index)
          stringBuilder.Append(((byte) this.string_0[index]).ToString("x2"));
        output.Write("<" + (object) stringBuilder + ">");
      }
      else
      {
        string str = this.string_0.Replace("\\", "\\\\").Replace("(", "\\(").Replace(")", "\\)");
        output.Write("(" + str + ")");
      }
    }
  }
}
