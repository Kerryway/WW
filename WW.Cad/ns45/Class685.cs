// Decompiled with JetBrains decompiler
// Type: ns45.Class685
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns41;
using ns44;
using ns7;
using WW.Math;

namespace ns45
{
  internal class Class685 : Class682
  {
    private Class1046 class1046_0 = new Class1046();
    private double double_8;
    private double double_9;
    private double double_10;
    private double double_11;
    private double double_12;
    private Vector3D vector3D_0;
    private double double_13;
    private Interface3 interface3_0;

    public override void imethod_0(Interface8 reader)
    {
      this.double_9 = reader.imethod_8();
      this.double_10 = reader.imethod_8();
      this.double_11 = reader.imethod_8();
      this.double_12 = reader.imethod_8();
      this.double_8 = reader.imethod_8();
      base.imethod_0(reader);
      this.vector3D_0 = reader.imethod_19();
      if (reader.FileFormatVersion < Class250.int_68)
        this.class188_1 = Class188.smethod_0(reader);
      this.double_13 = reader.imethod_8();
      if (reader.FileFormatVersion >= Class250.int_42)
        this.class1046_0.imethod_0(reader);
      if (reader.FileFormatVersion < Class250.int_57)
        return;
      this.interface3_0 = Class607.smethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.imethod_7(this.double_9);
      writer.imethod_7(this.double_10);
      writer.imethod_7(this.double_11);
      writer.imethod_7(this.double_12);
      writer.imethod_7(this.double_8);
      writer.imethod_15();
      base.imethod_1(writer);
      writer.imethod_15();
      writer.imethod_18(this.vector3D_0);
      if (writer.FileFormatVersion < Class250.int_68)
        Class188.smethod_1(writer, this.class188_1);
      writer.imethod_7(this.double_13);
      if (writer.FileFormatVersion >= Class250.int_42)
        this.class1046_0.imethod_1(writer);
      if (writer.FileFormatVersion < Class250.int_57)
        return;
      Class607.smethod_1(writer, this.interface3_0, (Interface4) this.interface3_0);
    }
  }
}
