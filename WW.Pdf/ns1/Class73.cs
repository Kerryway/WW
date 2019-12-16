// Decompiled with JetBrains decompiler
// Type: ns1.Class73
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns2;
using ns3;
using ns4;
using ns6;

namespace ns1
{
  internal class Class73
  {
    private readonly Class5 class5_0;
    private readonly Class80 class80_0;
    private readonly Class41 class41_0;

    public Class73(Class80 reader)
    {
      this.class80_0 = reader;
      this.class41_0 = reader.method_14("glyf");
      this.class5_0 = reader.method_11();
    }

    public Class47 method_0(int glyphIndex)
    {
      ns2.Class74 stream1 = this.class80_0.Stream;
      uint num = this.class41_0.Offset + this.class5_0[glyphIndex];
      long length = this.method_2(glyphIndex);
      Class47 glyph = new Class47(this.class80_0.IndexMappings.method_1(glyphIndex));
      if (length != 0L)
      {
        byte[] numArray = new byte[length];
        stream1.Position = (long) num;
        stream1.method_24(numArray, 0, numArray.Length);
        glyph.method_0(numArray);
        ns2.Class74 stream2 = new ns2.Class74(numArray);
        bool flag = stream2.method_4() < (short) 0;
        stream2.method_25(8L);
        if (flag)
          this.method_1(stream2, glyph);
      }
      return glyph;
    }

    private void method_1(ns2.Class74 stream, Class47 glyph)
    {
      bool flag = true;
      while (flag)
      {
        short num1 = stream.method_4();
        long position = stream.Position;
        int glyphIndex = this.class80_0.IndexMappings.method_1((int) stream.method_4());
        glyph.method_1(glyphIndex);
        stream.Position -= 2L;
        stream.method_5(glyphIndex);
        int num2 = ((int) num1 & 1) <= 0 ? 2 : 4;
        if (((int) num1 & 8) > 0)
          num2 = 2;
        else if (((int) num1 & 64) > 0)
          num2 = 4;
        else if (((int) num1 & 128) > 0)
          num2 = 8;
        if (((int) num1 & 256) > 0)
          num2 = (int) stream.method_8();
        flag = ((int) num1 & 32) > 0;
        stream.method_25((long) num2);
      }
    }

    private long method_2(int index)
    {
      if (index == this.class5_0.Count - 1)
        return (long) (this.class41_0.Length - this.class5_0[index]);
      return (long) (this.class5_0[index + 1] - this.class5_0[index]);
    }
  }
}
