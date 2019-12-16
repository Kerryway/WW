// Decompiled with JetBrains decompiler
// Type: ns17.Class164
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns7;
using ns9;

namespace ns17
{
  internal class Class164 : Class163
  {
    public static readonly string[] string_4 = new string[9]{ "undefined", "convex", "concave", "convex_smooth", "concave_smooth", "smooth", "convex_cusp", "concave_cusp", "cusp" };
    public static readonly string[] string_5 = new string[4]{ "default", "cap", "roll_on", "error" };
    public const string string_3 = "ffblend-blend-sys-attrib";
    private int int_2;
    private Class101 class101_0;
    private Class101 class101_1;
    private double double_0;
    private double double_1;
    private double double_2;
    private double double_3;
    private Class686.Class717 class717_0;
    private Class686.Class717 class717_1;
    private double double_4;
    private double double_5;
    private int int_3;
    private Class188 class188_0;
    private int int_4;
    private int int_5;

    public override string imethod_2(int version)
    {
      return "ffblend-blend-sys-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.int_2 = reader.imethod_11(Class164.string_4);
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class101_0 = (Class101) entity));
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class101_1 = (Class101) entity));
      this.double_0 = reader.imethod_8();
      this.double_1 = reader.imethod_8();
      if (reader.FileFormatVersion >= Class250.int_24)
      {
        this.double_2 = reader.imethod_8();
        this.double_3 = reader.imethod_8();
        this.class717_0 = new Class686.Class717(reader);
        this.class717_1 = new Class686.Class717(reader);
      }
      else
      {
        this.double_2 = 0.0;
        this.double_3 = 0.0;
        this.class717_0 = new Class686.Class717(false);
        this.class717_1 = new Class686.Class717(false);
      }
      if (reader.FileFormatVersion >= Class250.int_78)
      {
        this.double_5 = reader.imethod_8();
        this.double_5 = reader.imethod_8();
      }
      else
      {
        this.double_5 = 0.0;
        this.double_5 = 0.0;
      }
      this.int_3 = reader.FileFormatVersion < Class250.int_25 ? 0 : reader.imethod_11(Class164.string_5);
      this.class188_0 = Class188.smethod_0(reader);
      if (reader.FileFormatVersion < Class250.int_78)
        return;
      this.int_4 = reader.imethod_5();
      this.int_5 = reader.imethod_5();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_10(Class164.string_4, this.int_2);
      writer.imethod_6((Class80) this.class101_0);
      writer.imethod_6((Class80) this.class101_1);
      writer.imethod_7(this.double_0);
      writer.imethod_7(this.double_1);
      if (writer.FileFormatVersion >= Class250.int_24)
      {
        writer.imethod_7(this.double_2);
        writer.imethod_7(this.double_3);
        writer.imethod_12((Interface39) this.class717_0);
        writer.imethod_12((Interface39) this.class717_1);
      }
      if (writer.FileFormatVersion >= Class250.int_78)
      {
        writer.imethod_7(this.double_5);
        writer.imethod_7(this.double_5);
      }
      if (writer.FileFormatVersion >= Class250.int_25)
        writer.imethod_10(Class164.string_5, this.int_3);
      Class188.smethod_1(writer, this.class188_0);
      if (writer.FileFormatVersion < Class250.int_78)
        return;
      writer.imethod_4(this.int_4);
      writer.imethod_4(this.int_5);
    }
  }
}
