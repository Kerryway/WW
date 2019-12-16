// Decompiled with JetBrains decompiler
// Type: ns24.Class229
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns24
{
  internal class Class229 : Class224
  {
    public static readonly string[] string_6 = new string[5]{ "EXTEND_213", "EXTEND_213_G2", "EXTEND_214_G2", "EXTEND_G1", "UNEXTENDED" };
    public const string string_4 = "exact_int_cur";
    public const string string_5 = "exactcur";
    private Class439 class439_2;
    private int int_3;
    private int int_4;

    public override string imethod_2(int version)
    {
      return "exact_int_cur";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      if (reader.FileFormatVersion >= Class250.int_30)
        this.class439_2 = new Class439(reader);
      if (reader.FileFormatVersion >= Class250.int_69)
      {
        this.int_3 = reader.imethod_11(Class229.string_6);
        this.int_4 = reader.imethod_11(Class229.string_6);
      }
      else
      {
        this.int_3 = 4;
        this.int_4 = 4;
      }
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      if (writer.FileFormatVersion >= Class250.int_30)
        this.class439_2.method_0(writer);
      if (writer.FileFormatVersion < Class250.int_69)
        return;
      writer.imethod_10(Class229.string_6, this.int_3);
      writer.imethod_10(Class229.string_6, this.int_4);
    }

    protected override int vmethod_0()
    {
      return 20900;
    }

    public Class229()
    {
      this.int_4 = 4;
      this.int_3 = 4;
    }
  }
}
