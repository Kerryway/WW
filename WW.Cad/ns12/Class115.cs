// Decompiled with JetBrains decompiler
// Type: ns12.Class115
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns10;
using ns7;
using ns9;

namespace ns12
{
  internal class Class115 : Class114
  {
    public const string string_2 = "render-rbase-attrib";
    private Class112 class112_0;
    private Class80 class80_1;
    private int int_2;
    private int int_3;
    private Class744 class744_0;

    public override string imethod_2(int version)
    {
      return "render-rbase-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class112_0 = (Class112) entity));
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class80_1 = entity));
      this.int_2 = reader.imethod_5();
      this.int_3 = reader.imethod_5();
      if (this.int_3 <= 0)
        return;
      this.class744_0 = new Class744();
      this.class744_0.imethod_0(reader);
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_6((Class80) this.class112_0);
      writer.imethod_6(this.class80_1);
      writer.imethod_4(this.int_2);
      writer.imethod_4(this.int_3);
      if (this.int_3 <= 0)
        return;
      this.class744_0.imethod_1(writer);
    }
  }
}
