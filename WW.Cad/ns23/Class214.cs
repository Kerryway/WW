// Decompiled with JetBrains decompiler
// Type: ns23.Class214
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;

namespace ns23
{
  internal class Class214 : Class197
  {
    public const string string_3 = "tubesur";
    protected double double_3;
    protected Class242 class242_0;
    protected bool bool_0;

    public override string imethod_2(int version)
    {
      return "tubesur";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      if (this.bool_0)
        return;
      this.double_3 = reader.imethod_8();
      this.class242_0 = Class242.smethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      if (this.bool_0)
        return;
      writer.imethod_7(this.double_3);
      Class242.smethod_1(writer, this.class242_0);
    }
  }
}
