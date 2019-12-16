// Decompiled with JetBrains decompiler
// Type: ns23.Class220
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns26;
using ns7;
using WW.Math;

namespace ns23
{
  internal class Class220 : Class197
  {
    protected Class243 class243_0 = new Class243();
    protected Class243 class243_1 = new Class243();
    public const string string_3 = "helix_spl_line";
    private Class439 class439_2;
    private Point3D point3D_0;
    private Vector3D vector3D_0;
    private Vector3D vector3D_1;
    private Vector3D vector3D_2;
    private double double_3;
    private Vector3D vector3D_3;
    protected Class188 class188_0;
    protected Class188 class188_1;
    private Vector3D vector3D_4;

    protected override int vmethod_0(Interface8 reader)
    {
      return 21201;
    }

    public override string imethod_2(int version)
    {
      return "helix_spl_line";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.class439_0 = new Class439(reader);
      this.class439_1 = new Class439(reader);
      this.class439_2 = new Class439(reader);
      this.point3D_0 = reader.imethod_18();
      this.vector3D_0 = reader.imethod_19();
      this.vector3D_1 = reader.imethod_19();
      this.vector3D_2 = reader.imethod_19();
      this.double_3 = reader.imethod_8();
      this.vector3D_3 = reader.imethod_19();
      this.class188_0 = Class188.smethod_0(reader);
      this.class188_1 = Class188.smethod_0(reader);
      this.class243_0.vmethod_0(reader);
      this.class243_1.vmethod_0(reader);
      this.vector3D_4 = reader.imethod_19();
    }

    public override void imethod_1(Interface9 writer)
    {
      if (writer.FileFormatVersion < Class250.int_68)
        throw new Exception0("helix_spl_line should be converted (saving to < 21200)");
      this.class439_0.method_0(writer);
      this.class439_1.method_0(writer);
      this.class439_2.method_0(writer);
      writer.imethod_17(this.point3D_0);
      writer.imethod_18(this.vector3D_0);
      writer.imethod_18(this.vector3D_1);
      writer.imethod_18(this.vector3D_2);
      writer.imethod_7(this.double_3);
      writer.imethod_18(this.vector3D_3);
      Class188.smethod_1(writer, this.class188_0);
      Class188.smethod_1(writer, this.class188_1);
      this.class243_0.vmethod_1(writer);
      this.class243_1.vmethod_1(writer);
      writer.imethod_18(this.vector3D_4);
    }

    public override void vmethod_1(Interface8 reader)
    {
    }

    public override void vmethod_3(Interface9 writer)
    {
    }
  }
}
