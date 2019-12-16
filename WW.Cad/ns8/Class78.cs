// Decompiled with JetBrains decompiler
// Type: ns8.Class78
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns8
{
  internal class Class78 : Class69
  {
    public const string string_34 = "plain";
    private Point3D point3D_0;

    public override string imethod_2(int version)
    {
      return "plain";
    }

    public override void imethod_0(Interface8 reader)
    {
      reader.ReadString();
      reader.imethod_5();
      this.point3D_0.X = reader.imethod_8();
      this.point3D_0.Y = reader.imethod_8();
      this.point3D_0.Z = reader.imethod_8();
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.WriteString("color");
      writer.imethod_4(-4);
      writer.imethod_7(this.point3D_0.X);
      writer.imethod_7(this.point3D_0.Y);
      writer.imethod_7(this.point3D_0.Z);
    }
  }
}
