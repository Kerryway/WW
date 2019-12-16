// Decompiled with JetBrains decompiler
// Type: ns23.Class212
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns32;
using ns7;

namespace ns23
{
  internal class Class212 : Class197
  {
    public const string string_3 = "vertexblendsur";
    public const string string_4 = "VBL_SURF";
    private int int_5;
    private Class369[] class369_0;
    private double double_3;

    protected override int vmethod_0(Interface8 reader)
    {
      return 20900;
    }

    public override string imethod_2(int version)
    {
      return version >= 21200 ? "VBL_SURF" : "vertexblendsur";
    }

    public override void imethod_0(Interface8 reader)
    {
      int length = reader.imethod_5();
      this.class369_0 = new Class369[length];
      for (int index = 0; index < length; ++index)
        this.class369_0[index] = Class369.smethod_0(reader);
      this.int_5 = reader.imethod_5();
      this.double_3 = reader.imethod_8();
    }

    public override void imethod_1(Interface9 writer)
    {
      int length = this.class369_0.Length;
      writer.imethod_4(length);
      for (int index = 0; index < length; ++index)
        Class369.smethod_1(writer, this.class369_0[index]);
      writer.imethod_4(this.int_5);
      writer.imethod_7(this.double_3);
    }

    public override void vmethod_1(Interface8 reader)
    {
    }

    public override void vmethod_3(Interface9 writer)
    {
    }
  }
}
