// Decompiled with JetBrains decompiler
// Type: ns44.Class650
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using ns9;

namespace ns44
{
  internal class Class650 : Class648
  {
    private Class744 class744_0 = new Class744();
    public const string string_0 = "TRANS";

    public override string imethod_2(int version)
    {
      return "TRANS";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.class744_0.imethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.imethod_15();
      this.class744_0.imethod_1(writer);
    }
  }
}
