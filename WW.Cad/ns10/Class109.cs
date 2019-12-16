// Decompiled with JetBrains decompiler
// Type: ns10.Class109
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using ns9;

namespace ns10
{
  internal class Class109 : Class80
  {
    public const string string_0 = "rh_entity";
    private int int_2;

    public override string imethod_2(int version)
    {
      return "rh_entity";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.int_2 = reader.imethod_5();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_4(this.int_2);
    }
  }
}
