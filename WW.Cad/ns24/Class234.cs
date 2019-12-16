// Decompiled with JetBrains decompiler
// Type: ns24.Class234
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;

namespace ns24
{
  internal class Class234 : Class224
  {
    public const string string_4 = "off_surf_int_cur";
    public const string string_5 = "offsurfintcur";
    private Class439 class439_2;
    private Class439 class439_3;
    private Class242 class242_1;
    private Class439 class439_4;
    private double double_2;
    private double double_3;
    private double double_4;

    public override string imethod_2(int version)
    {
      return "off_surf_int_cur";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.class439_2 = new Class439(reader);
      this.class439_3 = new Class439(reader);
      this.class242_1 = Class242.smethod_0(reader);
      this.class439_4 = new Class439(reader);
      this.double_2 = reader.imethod_8();
      this.double_3 = reader.imethod_8();
      this.double_4 = reader.imethod_8();
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      this.class439_2.method_0(writer);
      this.class439_3.method_0(writer);
      Class242.smethod_1(writer, this.class242_1);
      this.class439_4.method_0(writer);
      writer.imethod_7(this.double_2);
      writer.imethod_7(this.double_3);
      writer.imethod_7(this.double_4);
    }
  }
}
