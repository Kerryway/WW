// Decompiled with JetBrains decompiler
// Type: ns23.Class221
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns22;
using ns26;
using ns7;
using WW.Math;

namespace ns23
{
  internal class Class221 : Class197
  {
    public const string string_3 = "rot_spl_sur";
    public const string string_4 = "rotsur";
    private Class242 class242_0;
    private Point3D point3D_0;
    private Vector3D vector3D_0;

    public override string imethod_2(int version)
    {
      return "rot_spl_sur";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.class242_0 = Class242.smethod_0(reader);
      this.point3D_0 = reader.imethod_18();
      this.vector3D_0 = reader.imethod_19();
      if (reader.FileFormatVersion < Class250.int_48)
      {
        this.class439_0 = new Class439(reader);
        this.class439_1 = new Class439(reader);
        if (reader.FileFormatVersion < Class250.int_36)
          return;
        this.class796_0 = new Class796(reader);
        this.class796_1 = new Class796(reader);
      }
      else
        this.method_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.imethod_15();
      Class242.smethod_1(writer, this.class242_0);
      writer.imethod_15();
      writer.imethod_17(this.point3D_0);
      writer.imethod_18(this.vector3D_0);
      writer.imethod_15();
      if (writer.FileFormatVersion < Class250.int_48)
      {
        this.class439_0.method_0(writer);
        this.class439_1.method_0(writer);
        if (writer.FileFormatVersion < Class250.int_36)
          return;
        this.class796_0.method_1(writer);
        this.class796_1.method_1(writer);
      }
      else
        this.method_1(writer);
    }

    protected override int vmethod_0(Interface8 reader)
    {
      return 20900;
    }
  }
}
