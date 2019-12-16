// Decompiled with JetBrains decompiler
// Type: ns9.Class184
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns9
{
  internal class Class184 : Class80
  {
    public const string string_0 = "eye_refinement";
    public const string string_1 = "refinement";
    private int int_2;
    private int int_3;
    private int int_4;
    private int int_5;
    private int int_6;
    private int int_7;
    private double double_0;
    private double double_1;
    private double double_2;
    private double double_3;
    private int int_8;
    private int int_9;
    private int int_10;
    private double double_4;
    private double double_5;
    private double double_6;
    private int int_11;
    private int int_12;
    private int int_13;
    private int int_14;
    private double double_7;
    private int int_15;

    public override string imethod_2(int version)
    {
      return version >= Class250.int_21 ? "eye_refinement" : "refinement";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      if (Class250.int_21 <= reader.FileFormatVersion)
      {
        string str;
        while (true)
        {
          str = reader.ReadString().TrimEnd(' ');
          switch (str)
          {
            case "end_fields":
              goto label_21;
            case "END_FIELDS":
              goto label_1;
            case "gridar":
            case "GRIDAR":
              this.double_3 = reader.imethod_8();
              continue;
            case "grad":
            case "GRAD":
              this.int_6 = reader.imethod_5();
              continue;
            case "grid":
            case "GRID":
              this.int_2 = reader.imethod_5();
              continue;
            case "tri":
            case "TRI":
              this.int_3 = reader.imethod_5();
              continue;
            case "surf":
            case "SURF":
              this.int_4 = reader.imethod_5();
              continue;
            case "stol":
            case "STOL":
              this.double_0 = reader.imethod_8();
              continue;
            case "adj":
            case "ADJ":
              this.int_5 = reader.imethod_5();
              continue;
            case "postcheck":
            case "POSTCHECK":
              this.int_7 = reader.imethod_5();
              continue;
            case "pixarea":
            case "PIXAREA":
              this.double_6 = reader.imethod_8();
              continue;
            case "ntol":
            case "NTOL":
              this.double_1 = reader.imethod_8();
              continue;
            case "hmax":
            case "HMAX":
              this.double_2 = reader.imethod_8();
              continue;
            case "mgrid":
            case "MGRID":
              this.int_8 = reader.imethod_5();
              continue;
            case "ugrid":
            case "UGRID":
              this.int_9 = reader.imethod_5();
              continue;
            case "vgrid":
            case "VGRID":
              this.int_10 = reader.imethod_5();
              continue;
            case "dsil":
            case "DSIL":
              this.double_4 = reader.imethod_8();
              continue;
            case "flatness":
            case "FLATNESS":
              this.double_5 = reader.imethod_8();
              continue;
            case "calc":
            case "CALC":
              this.int_11 = reader.imethod_5();
              continue;
            case "conv":
            case "CONV":
              this.int_12 = reader.imethod_5();
              continue;
            default:
              goto label_22;
          }
        }
label_21:
        return;
label_1:
        return;
label_22:
        throw new Exception0("SatRefinement invalid field : " + str);
      }
      this.int_13 = reader.imethod_5();
      this.int_14 = reader.imethod_5();
      this.double_5 = reader.imethod_8();
      this.double_4 = reader.imethod_8();
      this.double_0 = reader.imethod_8();
      this.double_1 = reader.imethod_8();
      this.double_6 = reader.imethod_8();
      this.double_7 = reader.imethod_8();
      this.int_15 = reader.imethod_5();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      if (Class250.int_21 <= writer.FileFormatVersion)
      {
        writer.WriteString("grid");
        writer.imethod_4(this.int_2);
        writer.WriteString("tri");
        writer.imethod_4(this.int_3);
        writer.WriteString("surf");
        writer.imethod_4(this.int_4);
        writer.WriteString("adj");
        writer.imethod_4(this.int_5);
        writer.WriteString("grad");
        writer.imethod_4(this.int_6);
        writer.WriteString("postcheck");
        writer.imethod_4(this.int_7);
        writer.WriteString("stol");
        writer.imethod_7(this.double_0);
        writer.WriteString("ntol");
        writer.imethod_7(this.double_1);
        writer.WriteString("dsil");
        writer.imethod_7(this.double_4);
        writer.WriteString("flatness");
        writer.imethod_7(this.double_5);
        writer.WriteString("pixarea");
        writer.imethod_7(this.double_6);
        writer.WriteString("hmax");
        writer.imethod_7(this.double_2);
        writer.WriteString("gridar");
        writer.imethod_7(this.double_3);
        writer.WriteString("mgrid");
        writer.imethod_4(this.int_8);
        writer.WriteString("ugrid");
        writer.imethod_4(this.int_9);
        writer.WriteString("vgrid");
        writer.imethod_4(this.int_10);
        writer.WriteString("end_fields");
      }
      else
      {
        writer.imethod_4(this.int_13);
        writer.imethod_4(this.int_14);
        writer.imethod_7(this.double_5);
        writer.imethod_7(this.double_4);
        writer.imethod_7(this.double_0);
        writer.imethod_7(this.double_1);
        writer.imethod_7(this.double_6);
        writer.imethod_7(this.double_7);
        writer.imethod_4(this.int_15);
      }
    }

    public override void imethod_0(Interface8 reader)
    {
      this.vmethod_0(reader);
      bool flag = false;
      while (!flag)
        flag = reader.imethod_16(true);
    }
  }
}
