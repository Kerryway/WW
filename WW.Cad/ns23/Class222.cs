// Decompiled with JetBrains decompiler
// Type: ns23.Class222
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns44;
using ns45;
using ns7;
using WW.Math;

namespace ns23
{
  internal class Class222 : Class197
  {
    public const string string_3 = "net_spl_sur";
    public const string string_4 = "netsur";
    private Class683[] class683_0;
    private Class684[] class684_0;
    private double[] double_3;
    private double[] double_4;
    private Class1046 class1046_0;
    private Class1046 class1046_1;
    private Class1046 class1046_2;
    private Class1046 class1046_3;
    private double[] double_5;
    private int int_5;
    private Vector3D[] vector3D_0;

    public override string imethod_2(int version)
    {
      return "net_spl_sur";
    }

    public override void imethod_0(Interface8 reader)
    {
      int length1 = reader.imethod_5();
      this.class684_0 = new Class684[length1];
      for (int index = 0; index < length1; ++index)
      {
        this.class684_0[index] = new Class684();
        this.class684_0[index].imethod_0(reader);
      }
      int length2 = reader.imethod_5();
      this.class683_0 = new Class683[length2];
      for (int index = 0; index < length2; ++index)
      {
        this.class683_0[index] = new Class683();
        this.class683_0[index].imethod_0(reader);
      }
      this.double_3 = new double[length2 * length1];
      this.double_4 = new double[length2 * length1];
      for (int index1 = 0; index1 < length2; ++index1)
      {
        for (int index2 = 0; index2 < length1; ++index2)
        {
          this.double_4[index2 + index1 * length1] = reader.imethod_8();
          this.double_3[index2 + index1 * length1] = reader.imethod_8();
        }
      }
      if (reader.FileFormatVersion >= Class250.int_68)
      {
        int length3 = (length1 < length2 ? length1 : length2) * 2;
        this.double_5 = new double[length3];
        for (int index = 0; index < length3; ++index)
          this.double_5[index] = reader.imethod_8();
        this.int_5 = reader.imethod_5();
        this.vector3D_0 = new Vector3D[length2 * length1];
        for (int index = 0; index < length2 * length1; ++index)
          this.vector3D_0[index] = reader.imethod_19();
      }
      if (reader.FileFormatVersion >= Class250.int_64)
      {
        this.class1046_0 = new Class1046();
        this.class1046_0.imethod_0(reader);
        this.class1046_1 = new Class1046();
        this.class1046_1.imethod_0(reader);
        this.class1046_2 = new Class1046();
        this.class1046_2.imethod_0(reader);
        this.class1046_3 = new Class1046();
        this.class1046_3.imethod_0(reader);
      }
      this.method_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      int length1 = this.class684_0.Length;
      int length2 = this.class683_0.Length;
      writer.imethod_4(length1);
      writer.imethod_15();
      for (int index = 0; index < length1; ++index)
        this.class684_0[index].imethod_1(writer);
      writer.imethod_4(length2);
      writer.imethod_15();
      for (int index = 0; index < length2; ++index)
      {
        this.class683_0[index].imethod_1(writer);
        writer.imethod_15();
      }
      for (int index1 = 0; index1 < length2; ++index1)
      {
        for (int index2 = 0; index2 < length1; ++index2)
        {
          writer.imethod_7(this.double_4[index2 + index1 * length1]);
          writer.imethod_7(this.double_3[index2 + index1 * length1]);
          writer.imethod_15();
        }
      }
      if (writer.FileFormatVersion >= Class250.int_68)
      {
        int num = (length1 < length2 ? length1 : length2) * 2;
        for (int index = 0; index < num; ++index)
        {
          writer.imethod_7(this.double_5[index]);
          if ((index + 1) % 2 == 0)
            writer.imethod_15();
        }
        writer.imethod_4(this.int_5);
        writer.imethod_15();
        for (int index = 0; index < length2 * length1; ++index)
        {
          writer.imethod_18(this.vector3D_0[index]);
          writer.imethod_15();
        }
      }
      if (writer.FileFormatVersion >= Class250.int_64)
      {
        this.class1046_0.imethod_1(writer);
        this.class1046_1.imethod_1(writer);
        this.class1046_2.imethod_1(writer);
        this.class1046_3.imethod_1(writer);
      }
      this.method_1(writer);
    }

    protected override int vmethod_0(Interface8 reader)
    {
      return 20900;
    }
  }
}
