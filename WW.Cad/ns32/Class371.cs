// Decompiled with JetBrains decompiler
// Type: ns32.Class371
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns26;
using ns7;

namespace ns32
{
  internal class Class371 : Class369
  {
    private Class243 class243_0 = new Class243();
    public const string string_0 = "0";
    public const string string_1 = "pcurve";
    private Class686.Class690 class690_0;
    private double double_1;
    private Class188 class188_0;

    public override string imethod_2(int version)
    {
      return version >= Class250.int_76 ? "pcurve" : "0";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.class188_0 = Class188.smethod_0(reader);
      this.class243_0.vmethod_0(reader);
      this.class690_0 = new Class686.Class690(reader);
      this.double_1 = reader.imethod_8();
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      Class188.smethod_1(writer, this.class188_0);
      this.class243_0.vmethod_1(writer);
      writer.imethod_12((Interface39) this.class690_0);
      writer.imethod_7(this.double_1);
    }
  }
}
