// Decompiled with JetBrains decompiler
// Type: ns17.Class165
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns17
{
  internal class Class165 : Class164
  {
    public const string string_6 = "const_round-ffblend-blend-sys-attrib";
    private double double_6;

    public override string imethod_2(int version)
    {
      return "const_round-ffblend-blend-sys-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.double_6 = reader.imethod_8();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_7(this.double_6);
    }
  }
}
