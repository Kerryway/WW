// Decompiled with JetBrains decompiler
// Type: ns8.Class71
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns8
{
  internal class Class71 : Class69
  {
    public const string string_34 = "mirror";
    private double double_0;
    private double double_1;
    private double double_2;
    private double double_3;
    private double double_4;

    public override string imethod_2(int version)
    {
      return "mirror";
    }

    public override void imethod_0(Interface8 reader)
    {
      for (int index = 0; index < 5; ++index)
      {
        string str = reader.ReadString();
        reader.imethod_5();
        switch (str)
        {
          case "ambient factor":
            this.double_0 = reader.imethod_8();
            break;
          case "diffuse factor":
            this.double_1 = reader.imethod_8();
            break;
          case "specular factor":
            this.double_2 = reader.imethod_8();
            break;
          case "mirror factor":
            this.double_3 = reader.imethod_8();
            break;
          case "roughness":
            this.double_4 = reader.imethod_8();
            break;
        }
      }
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.WriteString("ambient factor");
      writer.imethod_4(-2);
      writer.imethod_7(this.double_0);
      writer.WriteString("diffuse factor");
      writer.imethod_4(-2);
      writer.imethod_7(this.double_1);
      writer.WriteString("specular factor");
      writer.imethod_4(-2);
      writer.imethod_7(this.double_2);
      writer.WriteString("mirror factor");
      writer.imethod_4(-2);
      writer.imethod_7(this.double_3);
      writer.WriteString("roughness");
      writer.imethod_4(-2);
      writer.imethod_7(this.double_4);
    }
  }
}
