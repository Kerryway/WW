// Decompiled with JetBrains decompiler
// Type: ns8.Class70
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns8
{
  internal class Class70 : Class69
  {
    public const string string_34 = "wrapped checker";
    private double double_0;
    private Point3D point3D_0;
    private Point3D point3D_1;

    public override string imethod_2(int version)
    {
      return "wrapped checker";
    }

    public override void imethod_0(Interface8 reader)
    {
      for (int index = 0; index < 3; ++index)
      {
        string str = reader.ReadString();
        reader.imethod_5();
        switch (str)
        {
          case "size":
            this.double_0 = reader.imethod_8();
            break;
          case "odd color":
            this.point3D_0.X = reader.imethod_8();
            this.point3D_0.Y = reader.imethod_8();
            this.point3D_0.Z = reader.imethod_8();
            break;
          case "even color":
            this.point3D_1.X = reader.imethod_8();
            this.point3D_1.Y = reader.imethod_8();
            this.point3D_1.Z = reader.imethod_8();
            break;
        }
      }
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.WriteString("size");
      writer.imethod_4(-2);
      writer.imethod_7(this.double_0);
      writer.WriteString("odd color");
      writer.imethod_4(-4);
      writer.imethod_7(this.point3D_0.X);
      writer.imethod_7(this.point3D_0.Y);
      writer.imethod_7(this.point3D_0.Z);
      writer.WriteString("even color");
      writer.imethod_4(-4);
      writer.imethod_7(this.point3D_1.X);
      writer.imethod_7(this.point3D_1.Y);
      writer.imethod_7(this.point3D_1.Z);
    }
  }
}
