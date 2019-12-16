// Decompiled with JetBrains decompiler
// Type: ns26.Class243
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns22;
using ns7;
using WW.Math;

namespace ns26
{
  internal class Class243 : Class242
  {
    private Class883.Enum34 enum34_0;
    private Class647.Enum23 enum23_0;
    private int int_0;
    private int int_1;
    private double[] double_0;
    private int[] int_2;
    private Point2D[] point2D_0;
    private double[] double_1;

    public override string imethod_2(int version)
    {
      return "";
    }

    public Class647.Enum23 Type
    {
      get
      {
        return this.enum23_0;
      }
      set
      {
        this.enum23_0 = value;
      }
    }

    public override void vmethod_0(Interface8 reader)
    {
      this.enum23_0 = Class647.smethod_0(reader);
      if (this.enum23_0 == Class647.Enum23.const_2)
        return;
      this.int_0 = reader.imethod_5();
      this.enum34_0 = Class883.smethod_0(reader);
      this.int_1 = reader.imethod_5();
      this.double_0 = new double[this.int_1];
      this.int_2 = new int[this.int_1];
      int num1 = 0;
      for (int index = 0; index < this.int_1; ++index)
      {
        this.double_0[index] = reader.imethod_8();
        int num2 = reader.imethod_5();
        this.int_2[index] = num2;
        if (index == 0 || index == this.int_1 - 1)
          ++num2;
        num1 += num2;
      }
      this.point2D_0 = new Point2D[num1 - this.int_0 - 1];
      if (this.enum23_0 == Class647.Enum23.const_1)
        this.double_1 = new double[num1 - this.int_0 - 1];
      for (int index = 0; index < this.point2D_0.Length; ++index)
      {
        this.point2D_0[index].X = reader.imethod_8();
        this.point2D_0[index].Y = reader.imethod_8();
        if (this.enum23_0 == Class647.Enum23.const_1)
          this.double_1[index] = reader.imethod_8();
      }
    }

    public override void vmethod_1(Interface9 writer)
    {
      Class647.smethod_1(writer, this.enum23_0);
      if (this.enum23_0 == Class647.Enum23.const_2)
        return;
      writer.imethod_4(this.int_0);
      Class883.smethod_1(writer, this.enum34_0);
      writer.imethod_4(this.int_1);
      writer.imethod_15();
      for (int index = 0; index < this.int_1; ++index)
      {
        writer.imethod_7(this.double_0[index]);
        writer.imethod_4(this.int_2[index]);
        if ((index + 1) % 5 == 0)
          writer.imethod_15();
      }
      if (this.int_1 % 5 != 0)
        writer.imethod_15();
      for (int index = 0; index < this.point2D_0.Length; ++index)
      {
        writer.imethod_7(this.point2D_0[index].X);
        writer.imethod_7(this.point2D_0[index].Y);
        if (this.enum23_0 == Class647.Enum23.const_1)
          writer.imethod_7(this.double_1[index]);
        writer.imethod_15();
      }
    }
  }
}
