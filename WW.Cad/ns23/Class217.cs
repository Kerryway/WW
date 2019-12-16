// Decompiled with JetBrains decompiler
// Type: ns23.Class217
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns45;
using ns7;

namespace ns23
{
  internal class Class217 : Class197
  {
    public const string string_3 = "loft_spl_sur";
    private double[] double_3;
    private Class682[] class682_0;
    private int int_5;
    private int int_6;
    private int int_7;
    private Class439 class439_2;
    private Class439 class439_3;
    private Class686.Class688 class688_1;
    private Class686.Class688 class688_2;
    private Class686.Class688 class688_3;
    private Class686.Class688 class688_4;

    protected override int vmethod_0(Interface8 reader)
    {
      return 21201;
    }

    public override string imethod_2(int version)
    {
      return "loft_spl_sur";
    }

    public override void imethod_0(Interface8 reader)
    {
      int length = reader.imethod_5();
      this.class682_0 = new Class682[length];
      this.double_3 = new double[length];
      for (int index = 0; index < length; ++index)
      {
        this.double_3[index] = reader.imethod_8();
        this.class682_0[index] = new Class682();
        this.class682_0[index].imethod_0(reader);
      }
      this.int_5 = reader.imethod_5();
      this.class439_2 = new Class439(reader);
      this.class439_3 = new Class439(reader);
      this.class688_1 = new Class686.Class688(reader);
      this.class688_2 = new Class686.Class688(reader);
      this.class688_3 = new Class686.Class688(reader);
      this.class688_4 = new Class686.Class688(reader);
      this.int_6 = reader.imethod_5();
      this.int_7 = reader.FileFormatVersion < Class250.int_70 ? 0 : reader.imethod_5();
      base.imethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      if (writer.FileFormatVersion < Class250.int_68)
        throw new Exception0("loft_spl_sur should be converted (saving to < 21200)");
      int length = this.class682_0.Length;
      writer.imethod_4(length);
      for (int index = 0; index < length; ++index)
      {
        writer.imethod_7(this.double_3[index]);
        this.class682_0[index].imethod_1(writer);
      }
      writer.imethod_4(this.int_5);
      this.class439_2.method_0(writer);
      this.class439_3.method_0(writer);
      writer.imethod_12((Interface39) this.class688_1);
      writer.imethod_12((Interface39) this.class688_2);
      writer.imethod_12((Interface39) this.class688_3);
      writer.imethod_12((Interface39) this.class688_4);
      writer.imethod_4(this.int_6);
      if (writer.FileFormatVersion >= Class250.int_70)
        writer.imethod_4(this.int_7);
      base.imethod_1(writer);
    }
  }
}
