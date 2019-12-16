// Decompiled with JetBrains decompiler
// Type: ns8.Class75
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns8
{
  internal class Class75 : Class69
  {
    public const string string_34 = "simple wood";
    private double double_0;
    private Point3D point3D_0;
    private Point3D point3D_1;
    private Point3D point3D_2;
    private Point3D point3D_3;
    private double double_1;

    public override string imethod_2(int version)
    {
      return "simple wood";
    }

    public override void imethod_0(Interface8 reader)
    {
      for (int index = 0; index < 6; ++index)
      {
        string str = reader.ReadString();
        reader.imethod_5();
        switch (str)
        {
          case "scale":
            this.double_0 = reader.imethod_8();
            break;
          case "light wood color":
            this.point3D_0.X = reader.imethod_8();
            this.point3D_0.Y = reader.imethod_8();
            this.point3D_0.Z = reader.imethod_8();
            break;
          case "dark wood color":
            this.point3D_1.X = reader.imethod_8();
            this.point3D_1.Y = reader.imethod_8();
            this.point3D_1.Z = reader.imethod_8();
            break;
          case "point on axis":
            this.point3D_2.X = reader.imethod_8();
            this.point3D_2.Y = reader.imethod_8();
            this.point3D_2.Z = reader.imethod_8();
            break;
          case "axis direction":
            this.point3D_3.X = reader.imethod_8();
            this.point3D_3.Y = reader.imethod_8();
            this.point3D_3.Z = reader.imethod_8();
            break;
          case "noise":
            this.double_1 = reader.imethod_8();
            break;
        }
      }
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.WriteString("scale");
      writer.imethod_4(-2);
      writer.imethod_7(this.double_0);
      writer.WriteString("light wood color");
      writer.imethod_4(-4);
      writer.imethod_7(this.point3D_0.X);
      writer.imethod_7(this.point3D_0.Y);
      writer.imethod_7(this.point3D_0.Z);
      writer.WriteString("dark wood color");
      writer.imethod_4(-4);
      writer.imethod_7(this.point3D_1.X);
      writer.imethod_7(this.point3D_1.Y);
      writer.imethod_7(this.point3D_1.Z);
      writer.WriteString("point on axis");
      writer.imethod_4(-5);
      writer.imethod_7(this.point3D_2.X);
      writer.imethod_7(this.point3D_2.Y);
      writer.imethod_7(this.point3D_2.Z);
      writer.WriteString("axis direction");
      writer.imethod_4(-5);
      writer.imethod_7(this.point3D_3.X);
      writer.imethod_7(this.point3D_3.Y);
      writer.imethod_7(this.point3D_3.Z);
      writer.WriteString("noise");
      writer.imethod_4(-2);
      writer.imethod_7(this.double_1);
    }
  }
}
