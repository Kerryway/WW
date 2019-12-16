// Decompiled with JetBrains decompiler
// Type: ns24.Class232
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns24
{
  internal class Class232 : Class224
  {
    public static readonly string[] string_6 = new string[3]{ "left", "middle", "right" };
    public const string string_4 = "spring_int_cur";
    public const string string_5 = "blndsprngcur";
    private Class232.Enum20 enum20_0;

    public override string imethod_2(int version)
    {
      return "spring_int_cur";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      if (reader.FileFormatVersion < Class250.int_68)
        this.enum20_0 = new Class686.Class698(reader).Value ? Class232.Enum20.const_0 : Class232.Enum20.const_2;
      else
        this.enum20_0 = (Class232.Enum20) reader.imethod_11(Class232.string_6);
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      if (writer.FileFormatVersion < Class250.int_68)
      {
        Class686.Class698 class698 = new Class686.Class698(this.enum20_0 == Class232.Enum20.const_0);
        writer.imethod_12((Interface39) class698);
      }
      else
        writer.imethod_10(Class232.string_6, (int) this.enum20_0);
    }

    protected override int vmethod_0()
    {
      return 20900;
    }

    public enum Enum20
    {
      const_0,
      const_1,
      const_2,
    }
  }
}
