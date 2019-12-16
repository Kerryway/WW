// Decompiled with JetBrains decompiler
// Type: ns1.Class39
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using WW.Pdf;

namespace ns1
{
  internal class Class39 : PdfDictionary
  {
    public const string string_0 = "Adobe";
    public const string string_1 = "Identity";
    public const int int_0 = 0;

    public Class39()
      : this("Adobe", "Identity", 0)
    {
    }

    public Class39(string registry, string ordering, int supplement)
    {
      this["Registry"] = (IPdfObject) new PdfLiteralString(registry);
      this["Ordering"] = (IPdfObject) new PdfLiteralString(ordering);
      this["Supplement"] = (IPdfObject) new PdfInt(supplement);
    }
  }
}
