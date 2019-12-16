// Decompiled with JetBrains decompiler
// Type: ns8.Class73
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns8
{
  internal class Class73 : Class69
  {
    public const string string_34 = "distant";
    private double double_0;
    private Point3D point3D_0;
    private Point3D point3D_1;
    private Point3D point3D_2;
    private int int_0;
    private int int_1;
    private int int_2;
    private double double_1;

    public override string imethod_2(int version)
    {
      return "distant";
    }

    public override void imethod_0(Interface8 reader)
    {
      for (int index = 0; index < 8; ++index)
      {
        string str = reader.ReadString();
        reader.imethod_5();
        switch (str)
        {
          case "intensity":
            this.double_0 = reader.imethod_8();
            break;
          case "color":
            this.point3D_0.X = reader.imethod_8();
            this.point3D_0.Y = reader.imethod_8();
            this.point3D_0.Z = reader.imethod_8();
            break;
          case "location":
            this.point3D_1.X = reader.imethod_8();
            this.point3D_1.Y = reader.imethod_8();
            this.point3D_1.Z = reader.imethod_8();
            break;
          case "to":
            this.point3D_2.X = reader.imethod_8();
            this.point3D_2.Y = reader.imethod_8();
            this.point3D_2.Z = reader.imethod_8();
            break;
          case "shadows":
            this.int_0 = reader.imethod_5();
            break;
          case "shadow resolution":
            this.int_1 = reader.imethod_5();
            break;
          case "shadow quality":
            this.int_2 = reader.imethod_5();
            break;
          case "shadow softness":
            this.double_1 = reader.imethod_8();
            break;
        }
      }
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.WriteString("intensity");
      writer.imethod_4(-2);
      writer.imethod_7(this.double_0);
      writer.WriteString("color");
      writer.imethod_4(-4);
      writer.imethod_7(this.point3D_0.X);
      writer.imethod_7(this.point3D_0.Y);
      writer.imethod_7(this.point3D_0.Z);
      writer.WriteString("location");
      writer.imethod_4(-5);
      writer.imethod_7(this.point3D_1.X);
      writer.imethod_7(this.point3D_1.Y);
      writer.imethod_7(this.point3D_1.Z);
      writer.WriteString("to");
      writer.imethod_4(-5);
      writer.imethod_7(this.point3D_2.X);
      writer.imethod_7(this.point3D_2.Y);
      writer.imethod_7(this.point3D_2.Z);
      writer.WriteString("shadows");
      writer.imethod_4(-6);
      writer.imethod_4(this.int_0);
      writer.WriteString("shadow resolution");
      writer.imethod_4(-1);
      writer.imethod_7((double) this.int_1);
      writer.WriteString("shadow quality");
      writer.imethod_4(-1);
      writer.imethod_7((double) this.int_2);
      writer.WriteString("shadow softness");
      writer.imethod_4(-2);
      writer.imethod_7(this.double_1);
    }
  }
}
