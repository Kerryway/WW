// Decompiled with JetBrains decompiler
// Type: ns9.Class105
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns9
{
  internal class Class105 : Class81
  {
    public const string string_0 = "point";
    private Point3D point3D_0;

    public override string imethod_2(int version)
    {
      return "point";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.point3D_0 = reader.imethod_18();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_17(this.point3D_0);
    }

    public override void vmethod_3(Class608 wires)
    {
      int num = wires.method_2(this);
      wires.method_5(num, num);
    }

    public Point3D Location
    {
      get
      {
        return this.point3D_0;
      }
      set
      {
        this.point3D_0 = value;
      }
    }

    public Point3D method_4(Matrix4D transformation)
    {
      return transformation.Transform(this.point3D_0);
    }
  }
}
