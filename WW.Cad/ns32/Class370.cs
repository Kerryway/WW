// Decompiled with JetBrains decompiler
// Type: ns32.Class370
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;
using WW.Math;

namespace ns32
{
  internal class Class370 : Class369
  {
    public const string string_0 = "1";
    public const string string_1 = "plane";
    private Vector3D vector3D_1;
    private double double_1;
    private double double_2;
    private Class242 class242_0;

    public override string imethod_2(int version)
    {
      return version >= Class250.int_76 ? "plane" : "1";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.vector3D_1 = reader.imethod_19();
      this.double_1 = reader.imethod_8();
      this.double_2 = reader.imethod_8();
      this.class242_0 = Class242.smethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      writer.imethod_18(this.vector3D_1);
      writer.imethod_7(this.double_1);
      writer.imethod_7(this.double_2);
      Class242.smethod_1(writer, this.class242_0);
    }
  }
}
