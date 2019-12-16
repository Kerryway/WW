// Decompiled with JetBrains decompiler
// Type: ns23.Class216
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns44;
using ns7;
using WW.Math;

namespace ns23
{
  internal class Class216 : Class197
  {
    private Class1046 class1046_0 = new Class1046();
    private Class1046 class1046_1 = new Class1046();
    private Class1046 class1046_2 = new Class1046();
    public const string string_3 = "sweep_spl_sur";
    public const string string_4 = "sweepsur";
    private Class686.Class708 class708_0;
    private Class242 class242_0;
    private Class242 class242_1;
    private Class686.Class708 class708_1;
    private Vector3D vector3D_0;
    private Vector3D vector3D_1;
    private Point3D point3D_0;
    private Vector3D vector3D_2;
    private Vector3D vector3D_3;
    private Vector3D vector3D_4;
    private double double_3;
    private double double_4;
    private double double_5;
    private double double_6;
    private double double_7;
    private double double_8;

    public override string imethod_2(int version)
    {
      return "sweep_spl_sur";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.class708_0 = new Class686.Class708(reader);
      this.class242_0 = Class242.smethod_0(reader);
      this.class242_1 = Class242.smethod_0(reader);
      this.class708_1 = new Class686.Class708(reader);
      this.vector3D_0 = reader.imethod_19();
      if (reader.FileFormatVersion >= Class250.int_68)
        this.vector3D_1 = reader.imethod_19();
      this.point3D_0 = reader.imethod_18();
      this.vector3D_2 = reader.imethod_19();
      this.vector3D_3 = reader.imethod_19();
      this.vector3D_4 = reader.imethod_19();
      if (Class250.int_48 > reader.FileFormatVersion)
      {
        this.double_3 = reader.imethod_8();
        this.double_4 = reader.imethod_8();
      }
      this.double_5 = reader.imethod_8();
      this.double_6 = reader.imethod_8();
      this.double_7 = reader.imethod_8();
      this.double_8 = reader.imethod_8();
      if (reader.FileFormatVersion >= Class250.int_34)
      {
        this.class1046_0.imethod_0(reader);
        this.class1046_1.imethod_0(reader);
        this.class1046_2.imethod_0(reader);
      }
      base.imethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.imethod_12((Interface39) this.class708_0);
      writer.imethod_15();
      Class242.smethod_1(writer, this.class242_0);
      writer.imethod_15();
      Class242.smethod_1(writer, this.class242_1);
      writer.imethod_15();
      writer.imethod_12((Interface39) this.class708_1);
      writer.imethod_15();
      writer.imethod_18(this.vector3D_0);
      writer.imethod_15();
      if (writer.FileFormatVersion >= Class250.int_68)
      {
        writer.imethod_18(this.vector3D_1);
        writer.imethod_15();
      }
      writer.imethod_17(this.point3D_0);
      writer.imethod_15();
      writer.imethod_18(this.vector3D_2);
      writer.imethod_15();
      writer.imethod_18(this.vector3D_3);
      writer.imethod_15();
      writer.imethod_18(this.vector3D_4);
      writer.imethod_15();
      if (Class250.int_48 > writer.FileFormatVersion)
      {
        writer.imethod_7(this.double_3);
        writer.imethod_7(this.double_4);
      }
      writer.imethod_7(this.double_5);
      writer.imethod_7(this.double_6);
      writer.imethod_15();
      writer.imethod_7(this.double_7);
      writer.imethod_7(this.double_8);
      if (writer.FileFormatVersion >= Class250.int_34)
      {
        this.class1046_0.imethod_1(writer);
        this.class1046_1.imethod_1(writer);
        this.class1046_2.imethod_1(writer);
      }
      base.imethod_1(writer);
    }

    protected override int vmethod_0(Interface8 reader)
    {
      return 20900;
    }
  }
}
