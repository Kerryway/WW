// Decompiled with JetBrains decompiler
// Type: ns23.Class215
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns22;
using ns26;
using ns7;

namespace ns23
{
  internal class Class215 : Class214
  {
    public const string string_4 = "pipe_spl_sur";
    public const string string_5 = "pipesur";
    private Class439 class439_2;
    private Class242 class242_1;
    private Class686.Class688 class688_1;

    public override string imethod_2(int version)
    {
      return version >= 21200 ? "pipe_spl_sur" : "pipesur";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.double_3 = reader.imethod_8();
      this.class242_0 = Class242.smethod_0(reader);
      this.class242_1 = Class242.smethod_0(reader);
      this.class439_2 = new Class439(reader);
      if (Class250.int_48 > reader.FileFormatVersion)
      {
        if (Class250.int_36 > reader.FileFormatVersion)
          return;
        this.class796_0 = new Class796(reader);
        this.class796_1 = new Class796(reader);
      }
      else
        this.method_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.imethod_7(this.double_3);
      writer.imethod_15();
      Class242.smethod_1(writer, this.class242_0);
      writer.imethod_15();
      Class242.smethod_1(writer, this.class242_1);
      writer.imethod_15();
      this.class439_2.method_0(writer);
      if (Class250.int_48 > writer.FileFormatVersion)
      {
        if (Class250.int_36 > writer.FileFormatVersion)
          return;
        this.class796_0.method_1(writer);
        this.class796_1.method_1(writer);
      }
      else
        this.method_1(writer);
    }

    protected override int vmethod_0(Interface8 reader)
    {
      return 20900;
    }
  }
}
