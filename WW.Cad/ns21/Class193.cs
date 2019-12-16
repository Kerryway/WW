// Decompiled with JetBrains decompiler
// Type: ns21.Class193
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns21
{
  internal class Class193 : Class188
  {
    public const string string_0 = "sphere";
    private Class686.Class695 class695_0;
    private Point3D point3D_0;
    private double double_0;
    private Vector3D vector3D_0;
    private Vector3D vector3D_1;

    public override string imethod_2(int version)
    {
      return "sphere";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.point3D_0 = reader.imethod_18();
      this.double_0 = reader.imethod_8();
      if (reader.FileFormatVersion >= Class250.int_4)
      {
        this.vector3D_0 = reader.imethod_19();
        this.vector3D_1 = reader.imethod_19();
        this.class695_0 = new Class686.Class695(reader);
      }
      else
      {
        this.vector3D_0 = Vector3D.XAxis;
        this.vector3D_1 = Vector3D.ZAxis;
      }
      base.imethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.imethod_17(this.point3D_0);
      writer.imethod_7(this.double_0);
      if (writer.FileFormatVersion >= Class250.int_4)
      {
        writer.imethod_18(this.vector3D_0);
        writer.imethod_18(this.vector3D_1);
        writer.imethod_12((Interface39) this.class695_0);
      }
      else
      {
        this.vector3D_0 = Vector3D.XAxis;
        this.vector3D_1 = Vector3D.ZAxis;
      }
      base.imethod_1(writer);
    }
  }
}
