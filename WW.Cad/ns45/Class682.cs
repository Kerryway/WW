// Decompiled with JetBrains decompiler
// Type: ns45.Class682
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns26;
using ns7;

namespace ns45
{
  internal class Class682 : Interface3
  {
    private Class243 class243_0 = new Class243();
    private Class244 class244_0 = new Class244();
    private Class243 class243_1 = new Class243();
    private Class188 class188_0;
    private Class686.Class688 class688_0;
    private int int_0;
    private int int_1;
    private int int_2;
    private double double_0;
    private double double_1;
    private double double_2;
    private double double_3;
    private int int_3;
    private int int_4;
    private int int_5;
    private Class242 class242_0;
    private double[] double_4;
    private double[] double_5;
    protected Class242 class242_1;
    protected double double_6;
    protected double double_7;
    protected Class188 class188_1;

    public virtual void imethod_0(Interface8 reader)
    {
      if (reader.FileFormatVersion >= Class250.int_68)
        this.int_0 = reader.imethod_5();
      if (reader.FileFormatVersion >= Class250.int_69)
        this.int_1 = reader.imethod_5();
      this.class242_1 = Class242.smethod_0(reader);
      if (reader.FileFormatVersion < Class250.int_68)
        return;
      if (reader.FileFormatVersion >= Class250.int_69)
      {
        this.class188_0 = Class188.smethod_0(reader);
        this.class243_0.vmethod_0(reader);
        this.class688_0 = new Class686.Class688(reader);
      }
      this.int_2 = reader.imethod_5();
      if (this.int_2 != 212 && this.int_2 != 213)
      {
        this.double_0 = reader.imethod_8();
        this.double_1 = reader.imethod_8();
        this.double_6 = reader.imethod_8();
        this.double_7 = reader.imethod_8();
      }
      else
      {
        int length1 = reader.imethod_5() * 2;
        int length2 = reader.imethod_5() * 2;
        this.double_4 = new double[length1];
        this.double_5 = new double[length2];
        for (int index = 0; index < length1; ++index)
          this.double_4[index] = reader.imethod_8();
        for (int index = 0; index < length2; ++index)
          this.double_5[index] = reader.imethod_8();
      }
      this.double_2 = reader.imethod_8();
      this.double_3 = reader.imethod_8();
      this.int_3 = reader.FileFormatVersion < Class250.int_69 ? reader.imethod_5() : (new Class686.Class688(reader).Value ? 1 : 0);
      if (this.int_3 == 1)
      {
        this.class188_1 = Class188.smethod_0(reader);
        this.class243_1.vmethod_0(reader);
      }
      this.class242_0 = Class242.smethod_0(reader);
      this.int_4 = reader.imethod_5();
      if (this.int_4 == 1)
        this.class244_0.vmethod_0(reader);
      if (reader.FileFormatVersion < Class250.int_69)
        return;
      this.int_5 = reader.imethod_5();
    }

    public virtual void imethod_1(Interface9 writer)
    {
      if (writer.FileFormatVersion >= Class250.int_68)
        writer.imethod_4(this.int_0);
      if (writer.FileFormatVersion >= Class250.int_69)
        writer.imethod_4(this.int_1);
      Class242.smethod_1(writer, this.class242_1);
      if (writer.FileFormatVersion < Class250.int_68)
        return;
      if (writer.FileFormatVersion >= Class250.int_69)
      {
        Class188.smethod_1(writer, this.class188_0);
        this.class243_0.vmethod_1(writer);
        writer.imethod_12((Interface39) this.class688_0);
      }
      else
        writer.imethod_15();
      writer.imethod_4(this.int_2);
      if (this.int_2 != 212 && this.int_2 != 213)
      {
        writer.imethod_7(this.double_0);
        writer.imethod_7(this.double_1);
        writer.imethod_7(this.double_6);
        writer.imethod_7(this.double_7);
      }
      else
      {
        int length1 = this.double_4.Length;
        int length2 = this.double_5.Length;
        writer.imethod_4(length1 / 2);
        writer.imethod_4(length2 / 2);
        for (int index = 0; index < length1; ++index)
          writer.imethod_7(this.double_4[index]);
        for (int index = 0; index < length2; ++index)
          writer.imethod_7(this.double_5[index]);
      }
      writer.imethod_7(this.double_2);
      writer.imethod_7(this.double_3);
      if (writer.FileFormatVersion >= Class250.int_69)
      {
        Class686.Class688 class688 = new Class686.Class688(this.int_3 == 1);
        writer.imethod_12((Interface39) class688);
      }
      else
        writer.imethod_4(this.int_3);
      if (this.int_3 == 1)
      {
        Class188.smethod_1(writer, this.class188_1);
        this.class243_1.vmethod_1(writer);
      }
      Class242.smethod_1(writer, this.class242_0);
      writer.imethod_4(this.int_4);
      if (this.int_4 == 1)
        this.class244_0.vmethod_1(writer);
      if (writer.FileFormatVersion < Class250.int_69)
        return;
      writer.imethod_4(this.int_5);
    }
  }
}
