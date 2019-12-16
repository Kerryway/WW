// Decompiled with JetBrains decompiler
// Type: ns24.Class237
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;

namespace ns24
{
  internal class Class237 : Class224
  {
    public const string string_4 = "proj_int_cur";
    public const string string_5 = "projcur";
    private Class439 class439_2;
    private Class242 class242_1;
    private Class686.Class697 class697_0;

    public override string imethod_2(int version)
    {
      return "proj_int_cur";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.class242_1 = Class242.smethod_0(reader);
      if (Class250.int_68 > reader.FileFormatVersion)
        this.class439_2 = new Class439(reader);
      this.class697_0 = new Class686.Class697(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      Class242.smethod_1(writer, this.class242_1);
      if (Class250.int_68 > writer.FileFormatVersion)
        this.class439_2.method_0(writer);
      writer.imethod_12((Interface39) this.class697_0);
      writer.imethod_15();
    }
  }
}
