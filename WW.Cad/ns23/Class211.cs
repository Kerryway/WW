// Decompiled with JetBrains decompiler
// Type: ns23.Class211
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns23
{
  internal class Class211 : Class197
  {
    public static readonly string[] string_5 = new string[3]{ "UNEXTENDED", "EXTENDED_G1", "VERSION_212_G2" };
    public const string string_3 = "exact_spl_sur";
    public const string string_4 = "exactsur";
    private Class439 class439_2;
    private Class439 class439_3;
    private Class211.Enum19 enum19_0;

    public override string imethod_2(int version)
    {
      return "exact_spl_sur";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.method_0(reader);
      base.vmethod_1(reader);
      if (reader.FileFormatVersion >= Class250.int_30)
      {
        this.class439_2 = new Class439(reader);
        this.class439_3 = new Class439(reader);
      }
      if (reader.FileFormatVersion >= Class250.int_68)
        this.enum19_0 = (Class211.Enum19) reader.imethod_11(Class211.string_5);
      else
        this.enum19_0 = Class211.Enum19.const_0;
    }

    public override void imethod_1(Interface9 writer)
    {
      this.method_1(writer);
      base.vmethod_3(writer);
      if (writer.FileFormatVersion >= Class250.int_30)
      {
        this.class439_2.method_0(writer);
        this.class439_3.method_0(writer);
      }
      if (writer.FileFormatVersion < Class250.int_68)
        return;
      writer.imethod_10(Class211.string_5, (int) this.enum19_0);
    }

    public override void vmethod_1(Interface8 reader)
    {
    }

    public override void vmethod_3(Interface9 writer)
    {
    }

    protected override int vmethod_0(Interface8 reader)
    {
      return 20900;
    }

    public enum Enum19
    {
      const_0,
      const_1,
      const_2,
    }
  }
}
