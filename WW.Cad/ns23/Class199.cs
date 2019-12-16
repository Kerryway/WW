// Decompiled with JetBrains decompiler
// Type: ns23.Class199
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns45;
using ns7;
using WW.Math;

namespace ns23
{
  internal class Class199 : Class197
  {
    public const string string_3 = "cl_loft_spl_sur";
    private Class682 class682_0;
    private int int_5;
    private Class682[] class682_1;
    private double[] double_3;
    private Class686.Class688 class688_1;
    private Class686.Class688 class688_2;
    private int int_6;
    private Class439 class439_2;
    private Class244 class244_0;
    private Vector3D vector3D_0;
    private Class686.Class688 class688_3;
    private int int_7;
    private Class686.Class688 class688_4;
    private Class686.Class688 class688_5;

    protected override int vmethod_0(Interface8 reader)
    {
      return 21201;
    }

    public override string imethod_2(int version)
    {
      return "cl_loft_spl_sur";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.class688_3 = reader.FileFormatVersion < Class250.int_69 ? new Class686.Class688(false) : new Class686.Class688(reader);
      this.class682_0 = new Class682();
      this.class682_0.imethod_0(reader);
      this.int_5 = reader.imethod_5();
      this.class682_1 = new Class682[this.int_5];
      this.double_3 = new double[this.int_5];
      for (int index = 0; index < this.int_5; ++index)
      {
        this.class682_1[index] = new Class682();
        this.class682_1[index].imethod_0(reader);
        this.double_3[index] = reader.imethod_8();
      }
      this.class688_1 = new Class686.Class688(reader);
      this.class688_2 = new Class686.Class688(reader);
      if (reader.FileFormatVersion >= Class250.int_69)
      {
        this.int_7 = reader.imethod_5();
        this.class688_4 = new Class686.Class688(reader);
        this.class688_5 = new Class686.Class688(reader);
      }
      else
      {
        this.int_7 = 0;
        this.class688_4 = new Class686.Class688(false);
        this.class688_5 = new Class686.Class688(false);
      }
      this.int_6 = reader.imethod_5();
      this.class244_0 = (Class244) null;
      this.vector3D_0 = Vector3D.Zero;
      if (this.int_6 == 1)
      {
        this.class244_0 = new Class244();
        this.class244_0.vmethod_0(reader);
      }
      else
      {
        if (this.int_6 != 0)
          throw new Exception0("cl_loft_spl_sur : invalid type " + (object) this.int_6);
        this.vector3D_0 = reader.imethod_19();
      }
      this.class439_2 = new Class439(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      if (writer.FileFormatVersion < Class250.int_68)
        throw new Exception0("cl_loft_spl_sur should be converted (saving to < 21200)");
      base.imethod_1(writer);
      if (writer.FileFormatVersion >= Class250.int_69)
        writer.imethod_12((Interface39) this.class688_3);
      this.class682_0.imethod_1(writer);
      writer.imethod_4(this.int_5);
      for (int index = 0; index < this.int_5; ++index)
      {
        this.class682_1[index].imethod_1(writer);
        writer.imethod_7(this.double_3[index]);
      }
      writer.imethod_12((Interface39) this.class688_1);
      writer.imethod_12((Interface39) this.class688_2);
      if (writer.FileFormatVersion >= Class250.int_69)
      {
        writer.imethod_4(this.int_7);
        writer.imethod_12((Interface39) this.class688_4);
        writer.imethod_12((Interface39) this.class688_5);
      }
      writer.imethod_4(this.int_6);
      if (this.int_6 == 1)
        this.class244_0.vmethod_1(writer);
      else if (this.int_6 == 0)
        writer.imethod_18(this.vector3D_0);
      this.class439_2.method_0(writer);
    }

    public override void vmethod_1(Interface8 reader)
    {
    }

    public override void vmethod_3(Interface9 writer)
    {
    }
  }
}
