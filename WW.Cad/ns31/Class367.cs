// Decompiled with JetBrains decompiler
// Type: ns31.Class367
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns31
{
  internal class Class367 : Class364
  {
    public const string string_0 = "elliptical";
    private double double_2;
    private double double_3;
    private double double_4;
    private double double_5;
    private double double_6;
    private double double_7;
    private Class686.Class699 class699_0;

    public override string imethod_2(int version)
    {
      return "elliptical";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.double_2 = reader.imethod_8();
      this.double_3 = reader.imethod_8();
      this.double_4 = reader.imethod_8();
      this.double_5 = reader.imethod_8();
      this.double_6 = reader.imethod_8();
      this.double_7 = reader.imethod_8();
      this.class699_0 = new Class686.Class699(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      writer.imethod_7(this.double_2);
      writer.imethod_7(this.double_3);
      writer.imethod_7(this.double_4);
      writer.imethod_7(this.double_5);
      writer.imethod_7(this.double_6);
      writer.imethod_7(this.double_7);
      writer.imethod_12((Interface39) this.class699_0);
    }
  }
}
