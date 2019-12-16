// Decompiled with JetBrains decompiler
// Type: ns24.Class228
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns44;
using ns7;
using WW.Math;

namespace ns24
{
  internal class Class228 : Class224
  {
    private Class1046 class1046_0 = new Class1046();
    private Class1046 class1046_1 = new Class1046();
    public const string string_4 = "offset_int_cur";
    public const string string_5 = "offsetintcur";
    private Class242 class242_1;
    private double double_2;
    private double double_3;
    private Vector3D vector3D_0;
    private double double_4;
    private double double_5;

    public override string imethod_2(int version)
    {
      return "offset_int_cur";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.class242_1 = Class242.smethod_0(reader);
      this.double_2 = reader.imethod_8();
      this.double_3 = reader.imethod_8();
      this.vector3D_0 = reader.imethod_19();
      if (Class250.int_34 > reader.FileFormatVersion)
      {
        this.double_4 = reader.imethod_8();
        this.double_5 = reader.imethod_8();
      }
      else
      {
        this.class1046_0.imethod_0(reader);
        this.class1046_1.imethod_0(reader);
      }
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      Class242.smethod_1(writer, this.class242_1);
      writer.imethod_7(this.double_2);
      writer.imethod_7(this.double_3);
      writer.imethod_15();
      writer.imethod_18(this.vector3D_0);
      writer.imethod_15();
      if (Class250.int_34 > writer.FileFormatVersion)
      {
        writer.imethod_7(this.double_4);
        writer.imethod_7(this.double_5);
      }
      else
      {
        this.class1046_0.imethod_1(writer);
        writer.imethod_15();
        this.class1046_1.imethod_1(writer);
        writer.imethod_15();
      }
    }
  }
}
