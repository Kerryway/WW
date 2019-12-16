// Decompiled with JetBrains decompiler
// Type: ns1.Class56
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns2;
using ns3;
using ns4;
using ns5;
using ns6;
using ns7;
using ns8;
using System.IO;

namespace ns1
{
  internal class Class56
  {
    private readonly Class80 class80_0;

    public Class56(Class80 reader)
    {
      this.class80_0 = reader;
    }

    public void method_0(MemoryStream output)
    {
      Class2 class2 = this.class80_0.method_3();
      Class11 class11 = this.class80_0.method_4();
      Class8 class8 = this.class80_0.method_5();
      Class13 class13 = this.class80_0.method_7(true);
      Class7 class7 = this.class80_0.method_9(true);
      Class9 glyfTable = this.class80_0.method_10();
      Class3 class3 = this.class80_0.method_8();
      Class5 class5 = Class56.smethod_0(glyfTable);
      Class6 class6 = this.method_1(glyfTable);
      class11.GlyphCount = glyfTable.Count;
      class8.HMetricCount = glyfTable.Count;
      ns3.Class79 class79 = new ns3.Class79((Stream) output);
      class79.method_0((Class0) class2);
      class79.method_0((Class0) class11);
      class79.method_0((Class0) class8);
      class79.method_0((Class0) class6);
      if (class13 != null)
        class79.method_0((Class0) class13);
      class79.method_0((Class0) class3);
      if (class7 != null)
        class79.method_0((Class0) class7);
      class79.method_0((Class0) class5);
      class79.method_0((Class0) glyfTable);
      class79.method_1();
    }

    private Class6 method_1(Class9 glyfTable)
    {
      Class6 class6_1 = this.class80_0.method_6();
      Class6 class6_2 = new Class6(new Class41("hmtx"), glyfTable.Count);
      Class48 indexMappings = this.class80_0.IndexMappings;
      foreach (int subsetIndex in indexMappings.SubsetIndices)
      {
        int index = indexMappings.method_4(subsetIndex);
        class6_2[subsetIndex] = class6_1[index].method_0();
      }
      return class6_2;
    }

    private static Class5 smethod_0(Class9 glyfTable)
    {
      Class5 class5 = new Class5(new Class41("loca"), glyfTable.Count);
      uint offset = 0;
      for (int index = 0; index < glyfTable.Count; ++index)
      {
        class5.method_1(offset);
        offset += glyfTable[index].Length;
      }
      class5.method_1(offset);
      return class5;
    }
  }
}
