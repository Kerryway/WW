// Decompiled with JetBrains decompiler
// Type: ns25.Class239
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns26;
using ns7;

namespace ns25
{
  internal class Class239 : Class238
  {
    private Class243 class243_0 = new Class243();
    public const string string_0 = "exp_par_cur";
    public const string string_1 = "exppc";
    private double double_0;
    private Class188 class188_0;

    public override string imethod_2(int version)
    {
      return "exp_par_cur";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.class243_0.vmethod_0(reader);
      this.double_0 = reader.imethod_8();
      this.class188_0 = Class188.smethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      this.class243_0.vmethod_1(writer);
      writer.imethod_7(this.double_0);
      writer.imethod_15();
      Class188.smethod_1(writer, this.class188_0);
    }
  }
}
