// Decompiled with JetBrains decompiler
// Type: ns8.Class72
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns8
{
  internal class Class72 : Class69
  {
    public const string string_34 = "chrome";
    private Vector3D vector3D_0;
    private Vector3D vector3D_1;
    private double double_0;

    public override string imethod_2(int version)
    {
      return "chrome";
    }

    public override void imethod_0(Interface8 reader)
    {
      for (int index = 0; index < 3; ++index)
      {
        reader.ReadString();
        switch (reader.imethod_5())
        {
          case -5:
            this.vector3D_1.X = reader.imethod_8();
            this.vector3D_1.Y = reader.imethod_8();
            this.vector3D_1.Z = reader.imethod_8();
            break;
          case -4:
            this.vector3D_0.X = reader.imethod_8();
            this.vector3D_0.Y = reader.imethod_8();
            this.vector3D_0.Z = reader.imethod_8();
            break;
          case -2:
            this.double_0 = reader.imethod_8();
            break;
        }
      }
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.WriteString("base color");
      writer.imethod_4(-4);
      writer.imethod_7(this.vector3D_0.X);
      writer.imethod_7(this.vector3D_0.Y);
      writer.imethod_7(this.vector3D_0.Z);
      writer.WriteString("vector");
      writer.imethod_4(-5);
      writer.imethod_7(this.vector3D_1.X);
      writer.imethod_7(this.vector3D_1.Y);
      writer.imethod_7(this.vector3D_1.Z);
      writer.WriteString("mix");
      writer.imethod_4(-2);
      writer.imethod_7(this.double_0);
    }
  }
}
