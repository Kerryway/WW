// Decompiled with JetBrains decompiler
// Type: ns14.Class144
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns14
{
  internal class Class144 : Class143
  {
    public static readonly string[] string_4 = new string[4]{ "lose", "keep", "copy", "custom" };
    public static readonly string[] string_5 = new string[6]{ "lose", "keep_kept", "keep_lost", "keep_one", "keep_all", "custom" };
    public static readonly string[] string_6 = new string[4]{ "lose", "keep", "copy", "custom" };
    public static readonly string[] string_7 = new string[4]{ "lose", "ignore", "apply", "custom" };
    public const string string_2 = "name_attrib-gen-attrib";
    private int int_2;
    private int int_3;
    private int int_4;
    private int int_5;
    private string string_3;

    public override string imethod_2(int version)
    {
      return "name_attrib-gen-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.int_2 = reader.imethod_11(Class144.string_4);
      this.int_3 = reader.imethod_11(Class144.string_5);
      this.int_4 = reader.imethod_11(Class144.string_7);
      if (reader.FileFormatVersion >= Class250.int_59)
        this.int_5 = reader.imethod_11(Class144.string_6);
      this.string_3 = reader.ReadString();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_10(Class144.string_4, this.int_2);
      writer.imethod_10(Class144.string_5, this.int_3);
      writer.imethod_10(Class144.string_7, this.int_4);
      if (writer.FileFormatVersion >= Class250.int_59)
        writer.imethod_10(Class144.string_6, this.int_5);
      writer.WriteString(this.string_3);
    }
  }
}
