// Decompiled with JetBrains decompiler
// Type: ns32.Class372
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns32
{
  internal class Class372 : Class369
  {
    public const string string_0 = "3";
    public const string string_1 = "deg";
    private Vector3D vector3D_1;
    private Vector3D vector3D_2;
    private Vector3D vector3D_3;

    public override string imethod_2(int version)
    {
      return version >= Class250.int_76 ? "deg" : "3";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.vector3D_3 = reader.imethod_19();
      this.vector3D_1 = reader.imethod_19();
      this.vector3D_2 = reader.imethod_19();
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      writer.imethod_18(this.vector3D_3);
      writer.imethod_18(this.vector3D_1);
      writer.imethod_18(this.vector3D_2);
    }
  }
}
