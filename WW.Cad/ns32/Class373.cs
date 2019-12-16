// Decompiled with JetBrains decompiler
// Type: ns32.Class373
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;
using WW.Math;

namespace ns32
{
  internal class Class373 : Class369
  {
    public static readonly string[] string_2 = new string[4]{ "cylinder", "torus", "pipe", "given_twist" };
    private Class243 class243_0 = new Class243();
    public const string string_0 = "2";
    public const string string_1 = "circle";
    private Class242 class242_0;
    private int int_0;
    private int int_1;
    private int int_2;
    private Class373.Enum40 enum40_0;
    private Point3D point3D_0;
    private Class686.Class690 class690_0;
    private double double_1;
    private Vector3D vector3D_1;
    private Vector3D vector3D_2;
    private double double_2;
    private double double_3;
    private Class686.Class690 class690_1;

    public override string imethod_2(int version)
    {
      return version >= Class250.int_76 ? "circle" : "2";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.class242_0 = Class242.smethod_0(reader);
      if (reader.FileFormatVersion == Class250.int_74)
      {
        this.int_0 = reader.imethod_5();
        this.point3D_0 = this.int_0 == 0 ? Point3D.Zero : reader.imethod_18();
        this.double_2 = reader.imethod_8();
        this.double_3 = reader.imethod_8();
        this.int_1 = reader.imethod_5();
      }
      else
      {
        if (Class250.int_76 > reader.FileFormatVersion)
        {
          this.int_2 = reader.imethod_5();
        }
        else
        {
          this.enum40_0 = (Class373.Enum40) reader.imethod_11(Class373.string_2);
          switch (this.enum40_0)
          {
            case Class373.Enum40.const_0:
              break;
            case Class373.Enum40.const_1:
              this.point3D_0 = reader.imethod_18();
              break;
            case Class373.Enum40.const_2:
              this.class243_0.vmethod_0(reader);
              this.class690_0 = new Class686.Class690(reader);
              this.double_1 = reader.imethod_8();
              break;
            case Class373.Enum40.const_3:
              this.vector3D_1 = reader.imethod_19();
              this.vector3D_2 = reader.imethod_19();
              break;
            default:
              throw new Exception0("surfaceTypeEnum is broken");
          }
        }
        this.double_2 = reader.imethod_8();
        this.double_3 = reader.imethod_8();
        this.class690_1 = new Class686.Class690(reader);
      }
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      Class242.smethod_1(writer, this.class242_0);
      if (writer.FileFormatVersion == Class250.int_74)
      {
        writer.imethod_4(this.int_0);
        if (this.int_0 != 0)
          writer.imethod_17(this.point3D_0);
        writer.imethod_7(this.double_2);
        writer.imethod_7(this.double_3);
        writer.imethod_4(this.int_1);
      }
      else
      {
        if (Class250.int_76 > writer.FileFormatVersion)
        {
          writer.imethod_4(this.int_2);
        }
        else
        {
          writer.imethod_10(Class373.string_2, (int) this.enum40_0);
          switch (this.enum40_0)
          {
            case Class373.Enum40.const_0:
              break;
            case Class373.Enum40.const_1:
              writer.imethod_17(this.point3D_0);
              break;
            case Class373.Enum40.const_2:
              this.class243_0.vmethod_1(writer);
              writer.imethod_12((Interface39) this.class690_0);
              writer.imethod_7(this.double_1);
              break;
            case Class373.Enum40.const_3:
              writer.imethod_18(this.vector3D_1);
              writer.imethod_18(this.vector3D_2);
              break;
            default:
              throw new Exception0("surfaceTypeEnum is broken");
          }
        }
        writer.imethod_7(this.double_2);
        writer.imethod_7(this.double_3);
        writer.imethod_12((Interface39) this.class690_1);
      }
    }

    public enum Enum40
    {
      const_0,
      const_1,
      const_2,
      const_3,
    }
  }
}
