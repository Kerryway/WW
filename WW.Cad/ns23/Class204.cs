// Decompiled with JetBrains decompiler
// Type: ns23.Class204
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns22;
using ns26;
using ns7;
using WW.Math;

namespace ns23
{
  internal abstract class Class204 : Class197
  {
    public const string string_3 = "tapersur";
    private Class242 class242_0;
    private Class188 class188_0;
    private Class243 class243_0;
    private double double_3;
    protected Vector3D vector3D_0;
    protected double double_4;
    protected double double_5;

    public override void imethod_0(Interface8 reader)
    {
      this.class188_0 = Class188.smethod_0(reader);
      this.class242_0 = Class242.smethod_0(reader);
      if (reader.FileFormatVersion < Class250.int_38)
      {
        this.vector3D_0 = reader.imethod_19();
        this.double_4 = reader.imethod_8();
        this.double_5 = reader.imethod_8();
      }
      if (reader.FileFormatVersion < Class250.int_48)
      {
        this.class439_0 = new Class439(reader);
        this.class439_1 = new Class439(reader);
        this.int_0 = reader.imethod_5();
        if (reader.FileFormatVersion < Class250.int_36)
          return;
        this.class796_0 = new Class796(reader);
        this.class796_1 = new Class796(reader);
      }
      else
      {
        this.class243_0 = new Class243();
        this.class243_0.vmethod_0(reader);
        this.double_3 = reader.imethod_8();
        base.imethod_0(reader);
      }
    }

    public override void imethod_1(Interface9 writer)
    {
      Class188.smethod_1(writer, this.class188_0);
      Class242.smethod_1(writer, this.class242_0);
      if (writer.FileFormatVersion < Class250.int_38)
      {
        writer.imethod_18(this.vector3D_0);
        writer.imethod_7(this.double_4);
        writer.imethod_7(this.double_5);
      }
      if (writer.FileFormatVersion < Class250.int_48)
      {
        this.class439_0.method_0(writer);
        this.class439_1.method_0(writer);
        writer.imethod_4(this.int_0);
        if (writer.FileFormatVersion < Class250.int_36)
          return;
        this.class796_0.method_1(writer);
        this.class796_1.method_1(writer);
      }
      else
      {
        this.class243_0.vmethod_1(writer);
        writer.imethod_7(this.double_3);
        base.imethod_1(writer);
      }
    }

    protected override int vmethod_0(Interface8 reader)
    {
      return 20900;
    }
  }
}
