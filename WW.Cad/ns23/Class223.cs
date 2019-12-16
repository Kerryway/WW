// Decompiled with JetBrains decompiler
// Type: ns23.Class223
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;
using WW.Math;

namespace ns23
{
  internal class Class223 : Class197
  {
    public const string string_3 = "sweep_sur";
    private Class686.Class700 class700_0;
    private int int_5;
    private Class242 class242_0;
    private Class439 class439_2;
    private Class686.Class701 class701_0;
    private int int_6;
    private Class686.Class702 class702_0;
    private Class242 class242_1;
    private Class439 class439_3;
    private double double_3;
    private Class686.Class703 class703_0;
    private Class686.Class706 class706_0;
    private Class242 class242_2;
    private Class439 class439_4;
    private int int_7;
    private int int_8;
    private double double_4;
    private double double_5;
    private double double_6;
    private double double_7;
    private double double_8;
    private double double_9;
    private Class686.Class707 class707_0;
    private Class686.Class704 class704_0;
    private Class686.Class705 class705_0;
    private Point3D point3D_0;
    private Vector3D vector3D_0;
    private Point3D point3D_1;
    private Vector3D vector3D_1;
    private Vector3D vector3D_2;
    private Vector3D vector3D_3;

    public override string imethod_2(int version)
    {
      return "sweep_sur";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.class700_0 = new Class686.Class700(reader);
      this.int_5 = reader.imethod_5();
      this.class242_0 = Class242.smethod_0(reader);
      this.class439_2 = new Class439(reader);
      this.class701_0 = new Class686.Class701(reader);
      if (this.class701_0.Value)
      {
        this.point3D_0 = reader.imethod_18();
        this.vector3D_0 = reader.imethod_19();
      }
      if (reader.FileFormatVersion >= Class250.int_69)
      {
        this.point3D_1 = reader.imethod_18();
        this.vector3D_1 = reader.imethod_19();
        this.vector3D_2 = reader.imethod_19();
        this.vector3D_3 = reader.imethod_19();
      }
      this.int_6 = reader.imethod_5();
      this.class702_0 = new Class686.Class702(reader);
      this.class242_1 = Class242.smethod_0(reader);
      this.class439_3 = new Class439(reader);
      this.double_3 = reader.imethod_8();
      this.class703_0 = new Class686.Class703(reader);
      this.class706_0 = new Class686.Class706(reader);
      this.class242_2 = Class242.smethod_0(reader);
      this.class439_4 = new Class439(reader);
      this.int_7 = reader.imethod_5();
      this.int_8 = reader.imethod_5();
      this.double_4 = reader.imethod_8();
      this.double_5 = reader.imethod_8();
      this.double_6 = reader.imethod_8();
      this.double_7 = reader.imethod_8();
      this.double_8 = reader.imethod_8();
      this.double_9 = reader.imethod_8();
      if (reader.FileFormatVersion >= Class250.int_69)
        this.class707_0 = new Class686.Class707(reader);
      this.class704_0 = new Class686.Class704(reader);
      this.class705_0 = new Class686.Class705(reader);
      base.imethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.imethod_12((Interface39) this.class700_0);
      writer.imethod_4(this.int_5);
      Class242.smethod_1(writer, this.class242_0);
      this.class439_2.method_0(writer);
      writer.imethod_12((Interface39) this.class701_0);
      if (this.class701_0.Value)
      {
        writer.imethod_17(this.point3D_0);
        writer.imethod_18(this.vector3D_0);
      }
      if (writer.FileFormatVersion >= Class250.int_69)
      {
        writer.imethod_17(this.point3D_1);
        writer.imethod_18(this.vector3D_1);
        writer.imethod_18(this.vector3D_2);
        writer.imethod_18(this.vector3D_3);
      }
      writer.imethod_4(this.int_6);
      writer.imethod_12((Interface39) this.class702_0);
      Class242.smethod_1(writer, this.class242_1);
      this.class439_3.method_0(writer);
      writer.imethod_7(this.double_3);
      writer.imethod_12((Interface39) this.class703_0);
      writer.imethod_12((Interface39) this.class706_0);
      Class242.smethod_1(writer, this.class242_2);
      this.class439_4.method_0(writer);
      writer.imethod_4(this.int_7);
      writer.imethod_4(this.int_8);
      writer.imethod_7(this.double_4);
      writer.imethod_7(this.double_5);
      writer.imethod_7(this.double_6);
      writer.imethod_7(this.double_7);
      writer.imethod_7(this.double_8);
      writer.imethod_7(this.double_9);
      if (writer.FileFormatVersion >= Class250.int_69)
        writer.imethod_12((Interface39) this.class707_0);
      writer.imethod_12((Interface39) this.class704_0);
      writer.imethod_12((Interface39) this.class705_0);
      base.imethod_1(writer);
    }

    protected override int vmethod_0(Interface8 reader)
    {
      return 21201;
    }
  }
}
