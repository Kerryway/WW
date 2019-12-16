// Decompiled with JetBrains decompiler
// Type: ns17.Class166
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns17
{
  internal class Class166 : Class165
  {
    public const string string_7 = "const_round-const_round-ffblend-blend-sys-attrib";
    private double double_7;

    public override string imethod_2(int version)
    {
      return "const_round-const_round-ffblend-blend-sys-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.double_7 = reader.imethod_8();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_7(this.double_7);
    }
  }
}
