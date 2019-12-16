// Decompiled with JetBrains decompiler
// Type: ns16.Class158
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using WW.Math;

namespace ns16
{
  internal class Class158 : Class156
  {
    public const string string_2 = "materialmapper-adesk-attrib";
    private Matrix4D matrix4D_0;
    private Class158.Enum7 enum7_0;
    private Class158.Enum8 enum8_0;
    private Class158.Enum9 enum9_0;

    public override string imethod_2(int version)
    {
      return "materialmapper-adesk-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.enum7_0 = (Class158.Enum7) reader.imethod_5();
      this.enum8_0 = (Class158.Enum8) reader.imethod_5();
      this.enum9_0 = (Class158.Enum9) reader.imethod_5();
      this.matrix4D_0.M00 = reader.imethod_8();
      this.matrix4D_0.M01 = reader.imethod_8();
      this.matrix4D_0.M02 = reader.imethod_8();
      this.matrix4D_0.M03 = reader.imethod_8();
      this.matrix4D_0.M10 = reader.imethod_8();
      this.matrix4D_0.M11 = reader.imethod_8();
      this.matrix4D_0.M12 = reader.imethod_8();
      this.matrix4D_0.M13 = reader.imethod_8();
      this.matrix4D_0.M20 = reader.imethod_8();
      this.matrix4D_0.M21 = reader.imethod_8();
      this.matrix4D_0.M22 = reader.imethod_8();
      this.matrix4D_0.M23 = reader.imethod_8();
      this.matrix4D_0.M30 = reader.imethod_8();
      this.matrix4D_0.M31 = reader.imethod_8();
      this.matrix4D_0.M32 = reader.imethod_8();
      this.matrix4D_0.M33 = reader.imethod_8();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_4((int) this.enum7_0);
      writer.imethod_4((int) this.enum8_0);
      writer.imethod_4((int) this.enum9_0);
      writer.imethod_7(this.matrix4D_0.M00);
      writer.imethod_7(this.matrix4D_0.M01);
      writer.imethod_7(this.matrix4D_0.M02);
      writer.imethod_7(this.matrix4D_0.M03);
      writer.imethod_7(this.matrix4D_0.M10);
      writer.imethod_7(this.matrix4D_0.M11);
      writer.imethod_7(this.matrix4D_0.M12);
      writer.imethod_7(this.matrix4D_0.M13);
      writer.imethod_7(this.matrix4D_0.M20);
      writer.imethod_7(this.matrix4D_0.M21);
      writer.imethod_7(this.matrix4D_0.M22);
      writer.imethod_7(this.matrix4D_0.M23);
      writer.imethod_7(this.matrix4D_0.M30);
      writer.imethod_7(this.matrix4D_0.M31);
      writer.imethod_7(this.matrix4D_0.M32);
      writer.imethod_7(this.matrix4D_0.M33);
    }

    private enum Enum7
    {
      const_0,
      const_1,
      const_2,
      const_3,
      const_4,
    }

    private enum Enum8
    {
      const_0,
      const_1,
      const_2,
      const_3,
      const_4,
    }

    private enum Enum9
    {
      const_0,
      const_1,
      const_2,
      const_3,
    }
  }
}
