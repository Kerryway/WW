// Decompiled with JetBrains decompiler
// Type: ns10.Class110
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns10
{
  internal class Class110 : Class109
  {
    public const string string_1 = "rh_light-rh_entity";
    private ns8.Class69 class69_0;

    public override string imethod_2(int version)
    {
      return "rh_light-rh_entity";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.class69_0 = ns8.Class69.smethod_0(reader);
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      ns8.Class69.smethod_1(writer, this.class69_0);
    }
  }
}
