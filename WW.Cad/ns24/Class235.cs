// Decompiled with JetBrains decompiler
// Type: ns24.Class235
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;

namespace ns24
{
  internal class Class235 : Class224
  {
    public static readonly string[] string_6 = new string[2]{ "curvature", "tangent" };
    public const string string_4 = "subset_int_cur";
    public const string string_5 = "subsetintcur";
    private Class242 class242_1;
    private int int_3;

    public override string imethod_2(int version)
    {
      return "subset_int_cur";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.int_3 = reader.imethod_11(Class235.string_6);
      this.class242_1 = Class242.smethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      writer.imethod_10(Class235.string_6, this.int_3);
      Class242.smethod_1(writer, this.class242_1);
      writer.imethod_15();
    }

    public enum Enum42
    {
      const_0,
      const_1,
    }
  }
}
