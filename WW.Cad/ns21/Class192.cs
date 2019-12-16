// Decompiled with JetBrains decompiler
// Type: ns21.Class192
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns21
{
  internal class Class192 : Class188
  {
    public const string string_0 = "torus";
    private Vector3D vector3D_0;
    private Vector3D vector3D_1;
    private Point3D point3D_0;
    private double double_0;
    private double double_1;
    private Class686.Class695 class695_0;

    public override string imethod_2(int version)
    {
      return "torus";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.point3D_0 = reader.imethod_18();
      this.vector3D_0 = reader.imethod_19();
      this.double_0 = reader.imethod_8();
      this.double_1 = reader.imethod_8();
      if (reader.FileFormatVersion >= Class250.int_4)
      {
        this.vector3D_1 = reader.imethod_19();
        this.class695_0 = new Class686.Class695(reader);
        if (this.vector3D_1.GetLength() < 1E-10)
          throw new Exception0("Invalid vector length : " + (object) this.vector3D_1.GetLength());
      }
      base.imethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.imethod_17(this.point3D_0);
      writer.imethod_18(this.vector3D_0);
      writer.imethod_7(this.double_0);
      writer.imethod_7(this.double_1);
      if (writer.FileFormatVersion >= Class250.int_4)
      {
        writer.imethod_18(this.vector3D_1);
        writer.imethod_12((Interface39) this.class695_0);
        if (this.vector3D_1.GetLength() < 1E-10)
          throw new Exception0("Invalid vector length : " + (object) this.vector3D_1.GetLength());
      }
      base.imethod_1(writer);
    }
  }
}
