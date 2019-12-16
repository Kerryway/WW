// Decompiled with JetBrains decompiler
// Type: ns44.Class649
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns7;

namespace ns44
{
  internal class Class649 : Class648
  {
    public const string string_0 = "SURF";
    private Class188 class188_0;
    private Class439 class439_0;
    private Class439 class439_1;

    public override string imethod_2(int version)
    {
      return "SURF";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.class188_0 = Class188.smethod_0(reader);
      this.class439_0 = new Class439(reader);
      this.class439_1 = new Class439(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      writer.imethod_15();
      Class188.smethod_1(writer, this.class188_0);
      writer.imethod_15();
      this.class439_0.method_0(writer);
      writer.imethod_15();
      this.class439_1.method_0(writer);
    }
  }
}
