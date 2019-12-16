// Decompiled with JetBrains decompiler
// Type: ns24.Class225
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns44;
using ns7;

namespace ns24
{
  internal class Class225 : Class224
  {
    public const string string_4 = "law_int_cur";
    public const string string_5 = "lawintcur";
    private double double_2;
    private double double_3;
    private Class1046 class1046_0;
    private Class1046[] class1046_1;

    public override string imethod_2(int version)
    {
      return "law_int_cur";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      if (reader.FileFormatVersion < Class250.int_48)
      {
        this.double_2 = reader.imethod_8();
        this.double_3 = reader.imethod_8();
      }
      this.class1046_0 = new Class1046();
      this.class1046_0.imethod_0(reader);
      int length = reader.imethod_5();
      this.class1046_1 = new Class1046[length];
      for (int index = 0; index < length; ++index)
      {
        this.class1046_1[index] = new Class1046();
        this.class1046_1[index].imethod_0(reader);
      }
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      if (writer.FileFormatVersion < Class250.int_48)
      {
        writer.imethod_7(this.double_2);
        writer.imethod_7(this.double_3);
        if (writer.FileFormatVersion == Class250.int_77)
          writer.imethod_15();
      }
      this.class1046_0.imethod_1(writer);
      writer.imethod_15();
      int length = this.class1046_1.Length;
      writer.imethod_4(length);
      for (int index = 0; index < length; ++index)
        this.class1046_1[index].imethod_1(writer);
    }
  }
}
