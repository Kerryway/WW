// Decompiled with JetBrains decompiler
// Type: ns23.Class201
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;

namespace ns23
{
  internal class Class201 : Class200
  {
    public const string string_4 = "varblendsplsur";
    private Class242 class242_1;
    private Class686.Class714 class714_0;
    private Class686.Class715 class715_0;
    private Class439 class439_4;
    private Class243 class243_0;
    private Class243 class243_1;

    public override string imethod_2(int version)
    {
      return "varblendsplsur";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.class242_1 = Class242.smethod_0(reader);
      this.class714_0 = new Class686.Class714(reader);
      if (Class250.int_45 <= reader.FileFormatVersion)
        this.class715_0 = new Class686.Class715(reader);
      if (Class250.int_68 > reader.FileFormatVersion)
        return;
      this.class439_4 = new Class439(reader);
      this.class243_0 = new Class243();
      this.class243_1 = new Class243();
      this.class243_0.vmethod_0(reader);
      this.class243_1.vmethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      Class242.smethod_1(writer, this.class242_1);
      writer.imethod_15();
      writer.imethod_12((Interface39) this.class714_0);
      writer.imethod_15();
      if (Class250.int_45 <= writer.FileFormatVersion)
      {
        writer.imethod_12((Interface39) this.class715_0);
        writer.imethod_15();
      }
      if (Class250.int_68 > writer.FileFormatVersion)
        return;
      this.class439_4.method_0(writer);
      this.class243_0.vmethod_1(writer);
      this.class243_1.vmethod_1(writer);
      writer.imethod_15();
    }
  }
}
