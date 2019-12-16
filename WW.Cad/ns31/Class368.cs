// Decompiled with JetBrains decompiler
// Type: ns31.Class368
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;

namespace ns31
{
  internal class Class368 : Class364
  {
    private Class243 class243_0 = new Class243();
    public const string string_0 = "functional";

    public override string imethod_2(int version)
    {
      return "functional";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.class243_0.vmethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      this.class243_0.vmethod_1(writer);
    }
  }
}
