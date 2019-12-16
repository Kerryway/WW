// Decompiled with JetBrains decompiler
// Type: ns23.Class200
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns31;
using ns40;
using ns7;

namespace ns23
{
  internal abstract class Class200 : Class197
  {
    public static readonly string[] string_3 = new string[4]{ "no_radius", "single_radius", "one_radius", "two_radii" };
    public static readonly int[] int_12 = new int[4]{ -1, 0, 0, 1 };
    private Class601 class601_0;
    private Class601 class601_1;
    private Class242 class242_0;
    private double double_3;
    private double double_4;
    private Class200.Enum6 enum6_0;
    private Class364 class364_0;
    private Class364 class364_1;
    private Class1029 class1029_0;
    private Class439 class439_2;
    private int int_5;
    private int int_6;
    private Class439 class439_3;
    private int int_7;
    private double double_5;
    private double double_6;
    private int int_8;
    private int int_9;
    private int int_10;
    private int int_11;

    protected override int vmethod_0(Interface8 reader)
    {
      return 20900;
    }

    public override void imethod_0(Interface8 reader)
    {
      this.class601_0 = Class601.smethod_0(reader);
      this.class601_1 = Class601.smethod_0(reader);
      this.class242_0 = Class242.smethod_0(reader);
      this.double_3 = reader.imethod_8();
      this.double_4 = reader.imethod_8();
      this.enum6_0 = (Class200.Enum6) reader.imethod_12(Class200.string_3, Class200.int_12);
      if (this.enum6_0 != Class200.Enum6.const_0)
      {
        this.class364_0 = Class364.smethod_0(reader);
        if (this.enum6_0 == Class200.Enum6.const_2)
          this.class364_1 = Class364.smethod_0(reader);
        this.class1029_0 = new Class1029();
        this.class1029_0.imethod_0(reader);
      }
      if (reader.FileFormatVersion >= Class250.int_48)
      {
        this.class439_2 = new Class439(reader);
      }
      else
      {
        this.class439_0 = new Class439(reader);
        this.class439_2 = new Class439(reader);
        this.class439_1 = new Class439(reader);
        this.int_5 = reader.imethod_5();
        this.int_6 = reader.imethod_5();
      }
      if (reader.FileFormatVersion >= Class250.int_75)
      {
        this.class439_3 = new Class439(reader);
        this.int_7 = reader.imethod_5();
        this.double_6 = reader.imethod_8();
        this.double_5 = reader.imethod_8();
        this.int_8 = reader.imethod_5();
      }
      if (reader.FileFormatVersion >= Class250.int_48)
        this.method_0(reader);
      base.vmethod_1(reader);
      this.int_11 = 0;
      this.int_10 = 0;
      this.int_9 = 0;
      if (reader.FileFormatVersion < Class250.int_68)
        return;
      this.int_9 = reader.imethod_5();
      this.int_10 = reader.imethod_5();
      this.int_11 = reader.imethod_5();
    }

    public override void imethod_1(Interface9 writer)
    {
      Class601.smethod_1(writer, this.class601_0);
      writer.imethod_15();
      Class601.smethod_1(writer, this.class601_1);
      writer.imethod_15();
      Class242.smethod_1(writer, this.class242_0);
      writer.imethod_7(this.double_3);
      writer.imethod_7(this.double_4);
      writer.imethod_15();
      writer.imethod_11(Class200.string_3, Class200.int_12, (int) this.enum6_0);
      if (this.enum6_0 != Class200.Enum6.const_0)
      {
        Class364.smethod_1(writer, this.class364_0);
        if (this.enum6_0 == Class200.Enum6.const_2)
          Class364.smethod_1(writer, this.class364_1);
        this.class1029_0.imethod_1(writer);
      }
      writer.imethod_15();
      if (writer.FileFormatVersion >= Class250.int_48)
      {
        this.class439_2.method_0(writer);
      }
      else
      {
        this.class439_0.method_0(writer);
        this.class439_2.method_0(writer);
        this.class439_1.method_0(writer);
        writer.imethod_4(this.int_5);
        writer.imethod_4(this.int_6);
      }
      writer.imethod_15();
      if (writer.FileFormatVersion >= Class250.int_75)
      {
        this.class439_3.method_0(writer);
        writer.imethod_15();
        writer.imethod_4(this.int_7);
        writer.imethod_7(this.double_6);
        writer.imethod_7(this.double_5);
        writer.imethod_15();
        writer.imethod_4(this.int_8);
        writer.imethod_15();
      }
      if (writer.FileFormatVersion >= Class250.int_48)
        this.method_1(writer);
      base.vmethod_3(writer);
      if (writer.FileFormatVersion < Class250.int_68)
        return;
      writer.imethod_15();
      writer.imethod_4(this.int_9);
      writer.imethod_4(this.int_10);
      writer.imethod_4(this.int_11);
    }

    public override void vmethod_1(Interface8 reader)
    {
    }

    public override void vmethod_3(Interface9 writer)
    {
    }

    public enum Enum6
    {
      const_0 = -1,
      const_1 = 0,
      const_2 = 1,
    }
  }
}
