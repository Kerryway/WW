// Decompiled with JetBrains decompiler
// Type: ns8.Class74
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns8
{
  internal class Class74 : Class69
  {
    public const string string_34 = "marble";
    private double double_0;
    private int int_0;
    private Point3D point3D_0;
    private Point3D point3D_1;
    private double double_1;
    private double double_2;
    private double double_3;

    public override string imethod_2(int version)
    {
      return "marble";
    }

    public override void imethod_0(Interface8 reader)
    {
      for (int index = 0; index < 7; ++index)
      {
        string str = reader.ReadString();
        reader.imethod_5();
        switch (str)
        {
          case "scale":
            this.double_0 = reader.imethod_8();
            break;
          case "detail":
            this.int_0 = reader.imethod_5();
            break;
          case "ground color":
            this.point3D_0.X = reader.imethod_8();
            this.point3D_0.Y = reader.imethod_8();
            this.point3D_0.Z = reader.imethod_8();
            break;
          case "vein color":
            this.point3D_1.X = reader.imethod_8();
            this.point3D_1.Y = reader.imethod_8();
            this.point3D_1.Z = reader.imethod_8();
            break;
          case "vein contrast":
            this.double_1 = reader.imethod_8();
            break;
          case "grain":
            this.double_2 = reader.imethod_8();
            break;
          case "grain scale":
            this.double_3 = reader.imethod_8();
            break;
        }
      }
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.WriteString("scale");
      writer.imethod_4(-2);
      writer.imethod_7(this.double_0);
      writer.WriteString("detail");
      writer.imethod_4(-1);
      writer.imethod_4(this.int_0);
      writer.WriteString("ground color");
      writer.imethod_4(-4);
      writer.imethod_7(this.point3D_0.X);
      writer.imethod_7(this.point3D_0.Y);
      writer.imethod_7(this.point3D_0.Z);
      writer.WriteString("vein color");
      writer.imethod_4(-4);
      writer.imethod_7(this.point3D_1.X);
      writer.imethod_7(this.point3D_1.Y);
      writer.imethod_7(this.point3D_1.Z);
      writer.WriteString("vein contrast");
      writer.imethod_4(-2);
      writer.imethod_7(this.double_1);
      writer.WriteString("grain");
      writer.imethod_4(-2);
      writer.imethod_7(this.double_2);
      writer.WriteString("grain scale");
      writer.imethod_4(-2);
      writer.imethod_7(this.double_3);
    }
  }
}
