// Decompiled with JetBrains decompiler
// Type: ns44.Class651
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;

namespace ns44
{
  internal class Class651 : Class648
  {
    public const string string_0 = "EDGE";
    private Class242 class242_0;
    private double double_0;
    private double double_1;

    public override string imethod_2(int version)
    {
      return "EDGE";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.class242_0 = Class242.smethod_0(reader);
      this.double_0 = reader.imethod_8();
      this.double_1 = reader.imethod_8();
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      writer.imethod_15();
      Class242.smethod_1(writer, this.class242_0);
      writer.imethod_15();
      writer.imethod_7(this.double_0);
      writer.imethod_15();
      writer.imethod_7(this.double_1);
    }
  }
}
