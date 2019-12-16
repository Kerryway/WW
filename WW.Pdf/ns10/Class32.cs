// Decompiled with JetBrains decompiler
// Type: ns10.Class32
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns1;
using ns2;
using ns8;
using ns9;
using System;
using System.IO;
using WW.Pdf;
using WW.Pdf.Font;

namespace ns10
{
  internal class Class32 : Class31
  {
    protected Class48 class48_0;
    protected string string_2;

    public Class32(FontProperties properties)
      : base(properties)
    {
      this.method_3();
      this.string_2 = new Random().Next(1048576, 16777215).ToString("X").Substring(0, 6);
    }

    private void method_3()
    {
      this.class48_0 = new Class48();
      this.class48_0.method_2(0, 1, 2);
    }

    public override PdfWArray WArray
    {
      get
      {
        int[] widths = new int[this.class48_0.Count];
        this.method_2();
        foreach (int subsetIndex in this.class48_0.SubsetIndices)
        {
          int index = this.class48_0.method_4(subsetIndex);
          widths[subsetIndex] = this.int_1[index];
        }
        PdfWArray pdfWarray = new PdfWArray(0);
        pdfWarray.AddEntry(widths);
        return pdfWarray;
      }
    }

    public override string FontName
    {
      get
      {
        return string.Format("{0}+{1}", (object) this.string_2, (object) this.string_1);
      }
    }

    public override ushort MapCharacter(char c)
    {
      return (ushort) this.class48_0.method_3((int) base.MapCharacter(c));
    }

    protected override void vmethod_0(ushort glyphIndex, char c)
    {
      int num = this.class48_0.method_0((int) glyphIndex) ? this.class48_0.method_3((int) glyphIndex) : this.class48_0.method_1((int) glyphIndex);
      if (this.idictionary_0.ContainsKey((ushort) num))
        return;
      this.idictionary_0.Add((ushort) num, c);
    }

    public override int GetWidth(ushort charIndex)
    {
      return base.GetWidth((ushort) this.class48_0.method_4((int) charIndex));
    }

    public override byte[] FontData
    {
      get
      {
        Class56 class56 = new Class56(new Class80(new MemoryStream(this.class42_0.method_0()), this.class42_0.FaceName) { IndexMappings = this.class48_0 });
        MemoryStream output = new MemoryStream();
        class56.method_0(output);
        return output.GetBuffer();
      }
    }
  }
}
