// Decompiled with JetBrains decompiler
// Type: ns16.Class157
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns16
{
  internal class Class157 : Class156
  {
    public const string string_2 = "Spline_Data-adesk-attrib";
    private Point3D[] point3D_0;
    private double double_0;
    private Vector3D vector3D_0;
    private Vector3D vector3D_1;

    public override string imethod_2(int version)
    {
      return "Spline_Data-adesk-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      int length = reader.imethod_5();
      this.point3D_0 = new Point3D[length];
      for (int index = 0; index < length; ++index)
        this.point3D_0[index] = reader.imethod_18();
      this.vector3D_0 = reader.imethod_19();
      this.vector3D_1 = reader.imethod_19();
      this.double_0 = reader.imethod_8();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_4(this.point3D_0.Length);
      foreach (Point3D point3D in this.point3D_0)
        writer.imethod_17(point3D);
      writer.imethod_18(this.vector3D_0);
      writer.imethod_18(this.vector3D_1);
      writer.imethod_7(this.double_0);
    }
  }
}
