// Decompiled with JetBrains decompiler
// Type: ns21.Class988
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns22;
using ns7;
using WW.Math;

namespace ns21
{
  internal class Class988 : Interface3
  {
    private Class647.Enum23 enum23_0;
    private Class195.Enum2 enum2_0;
    private Class883.Enum34 enum34_0;
    private Class883.Enum34 enum34_1;
    private Class1028.Enum49 enum49_0;
    private Class1028.Enum49 enum49_1;
    private double[] double_0;
    private double[] double_1;
    private int[] int_0;
    private int[] int_1;
    private Point3D[] point3D_0;
    private double[] double_2;
    private int int_2;
    private int int_3;

    public void imethod_0(Interface8 reader)
    {
      this.enum23_0 = Class647.smethod_0(reader);
      if (this.enum23_0 == Class647.Enum23.const_2)
        return;
      this.int_2 = reader.imethod_5();
      this.int_3 = reader.imethod_5();
      if (this.enum23_0 == Class647.Enum23.const_1)
        this.enum2_0 = Class195.smethod_0(reader);
      this.enum34_0 = Class883.smethod_0(reader);
      this.enum34_1 = Class883.smethod_0(reader);
      this.enum49_0 = Class1028.smethod_0(reader);
      this.enum49_1 = Class1028.smethod_0(reader);
      int length1 = reader.imethod_5();
      int length2 = reader.imethod_5();
      int num1 = 2;
      int num2 = 2;
      this.double_0 = new double[length1];
      this.int_0 = new int[length1];
      for (int index = 0; index < length1; ++index)
      {
        this.double_0[index] = reader.imethod_8();
        this.int_0[index] = reader.imethod_5();
        num1 += this.int_0[index];
      }
      this.double_1 = new double[length2];
      this.int_1 = new int[length2];
      for (int index = 0; index < length2; ++index)
      {
        this.double_1[index] = reader.imethod_8();
        this.int_1[index] = reader.imethod_5();
        num2 += this.int_1[index];
      }
      int num3 = num1 - this.int_2 - 1;
      int num4 = num2 - this.int_3 - 1;
      this.point3D_0 = new Point3D[num3 * num4];
      if (this.enum23_0 == Class647.Enum23.const_1)
      {
        this.double_2 = new double[num3 * num4];
        for (int index = 0; index < this.point3D_0.Length; ++index)
        {
          this.point3D_0[index] = Class794.smethod_15(reader);
          this.double_2[index] = reader.imethod_8();
        }
      }
      else
      {
        for (int index = 0; index < this.point3D_0.Length; ++index)
          this.point3D_0[index] = Class794.smethod_15(reader);
      }
    }

    public void imethod_1(Interface9 writer)
    {
      Class647.smethod_1(writer, this.enum23_0);
      if (this.enum23_0 == Class647.Enum23.const_2)
        return;
      writer.imethod_4(this.int_2);
      writer.imethod_4(this.int_3);
      writer.imethod_15();
      if (this.enum23_0 == Class647.Enum23.const_1)
        Class195.smethod_1(writer, this.enum2_0);
      writer.imethod_10(Class883.string_0, (int) this.enum34_0);
      writer.imethod_10(Class883.string_0, (int) this.enum34_1);
      writer.imethod_10(Class1028.string_0, (int) this.enum49_0);
      writer.imethod_10(Class1028.string_0, (int) this.enum49_1);
      writer.imethod_4(this.double_0.Length);
      writer.imethod_4(this.double_1.Length);
      for (int index = 0; index < this.double_0.Length; ++index)
      {
        writer.imethod_7(this.double_0[index]);
        writer.imethod_4(this.int_0[index]);
        if ((index + 1) % 5 == 0)
          writer.imethod_15();
      }
      if (this.double_0.Length % 5 != 0)
        writer.imethod_15();
      for (int index = 0; index < this.double_1.Length; ++index)
      {
        writer.imethod_7(this.double_1[index]);
        writer.imethod_4(this.int_1[index]);
        if ((index + 1) % 5 == 0)
          writer.imethod_15();
      }
      if (this.double_1.Length % 5 != 0)
        writer.imethod_15();
      if (this.enum23_0 == Class647.Enum23.const_1)
      {
        for (int index = 0; index < this.point3D_0.Length; ++index)
        {
          writer.imethod_7(this.point3D_0[index].X);
          writer.imethod_7(this.point3D_0[index].Y);
          writer.imethod_7(this.point3D_0[index].Z);
          writer.imethod_7(this.double_2[index]);
          writer.imethod_15();
        }
      }
      else
      {
        for (int index = 0; index < this.point3D_0.Length; ++index)
        {
          writer.imethod_7(this.point3D_0[index].X);
          writer.imethod_7(this.point3D_0[index].Y);
          writer.imethod_7(this.point3D_0[index].Z);
          writer.imethod_15();
        }
      }
    }
  }
}
