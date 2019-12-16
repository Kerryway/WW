// Decompiled with JetBrains decompiler
// Type: ns23.Class218
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns7;

namespace ns23
{
  internal class Class218 : Class197
  {
    public const string string_3 = "sub_spl_sur";
    public const string string_4 = "subsur";
    private Class439 class439_2;
    private Class439 class439_3;
    protected Class188 class188_0;

    protected override int vmethod_0(Interface8 reader)
    {
      return 20900;
    }

    public override string imethod_2(int version)
    {
      return version >= Class250.int_68 ? "sub_spl_sur" : "subsur";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.class439_2 = new Class439(reader);
      this.class439_3 = new Class439(reader);
      this.class188_0 = Class188.smethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      this.class439_2.method_0(writer);
      this.class439_3.method_0(writer);
      Class188.smethod_1(writer, this.class188_0);
    }

    public override void vmethod_1(Interface8 reader)
    {
    }

    public override void vmethod_3(Interface9 writer)
    {
    }
  }
}
