// Decompiled with JetBrains decompiler
// Type: ns24.Class236
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns22;
using ns7;
using WW.Math;

namespace ns24
{
  internal class Class236 : Class224
  {
    public const string string_4 = "helixintcur";
    public const string string_5 = "helix_int_cur";
    private Point3D point3D_0;
    private Vector3D vector3D_0;
    private Vector3D vector3D_1;
    private Vector3D vector3D_2;
    private Vector3D vector3D_3;
    private double double_2;
    private Class439 class439_2;

    public override string imethod_2(int version)
    {
      return version >= Class250.int_68 ? "helix_int_cur" : "helixintcur";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.method_0(reader);
      this.class439_2 = new Class439(reader);
      this.point3D_0 = reader.imethod_18();
      this.vector3D_0 = reader.imethod_19();
      this.vector3D_1 = reader.imethod_19();
      this.vector3D_2 = reader.imethod_19();
      this.double_2 = reader.imethod_8();
      if (reader.FileFormatVersion >= Class250.int_68)
      {
        this.vector3D_3 = reader.imethod_19();
        this.class188_0 = Class188.smethod_0(reader);
        this.class188_1 = Class188.smethod_0(reader);
        this.class243_0.vmethod_0(reader);
        this.class243_1.vmethod_0(reader);
      }
      else
      {
        this.class188_0 = (Class188) new Class189();
        this.class188_1 = (Class188) new Class189();
        this.class243_0.Type = Class647.Enum23.const_2;
        this.class243_1.Type = Class647.Enum23.const_2;
        this.vector3D_3 = this.vector3D_2;
        this.vector3D_3.Normalize();
      }
    }

    public override void imethod_1(Interface9 writer)
    {
      if (writer.FileFormatVersion < Class250.int_73)
        throw new Exception0("helixintcur should be converted (saving to < 20800)");
      this.method_1(writer);
      this.class439_2.method_0(writer);
      writer.imethod_17(this.point3D_0);
      writer.imethod_18(this.vector3D_0);
      writer.imethod_18(this.vector3D_1);
      writer.imethod_18(this.vector3D_2);
      writer.imethod_7(this.double_2);
      if (writer.FileFormatVersion < Class250.int_68)
        return;
      writer.imethod_18(this.vector3D_3);
      Class188.smethod_1(writer, this.class188_0);
      Class188.smethod_1(writer, this.class188_1);
      this.class243_0.vmethod_1(writer);
      this.class243_1.vmethod_1(writer);
    }
  }
}
