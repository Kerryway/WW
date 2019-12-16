// Decompiled with JetBrains decompiler
// Type: ns25.Class240
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns44;
using ns7;

namespace ns25
{
  internal class Class240 : Class239
  {
    private Class1046 class1046_0 = new Class1046();
    public const string string_2 = "law_par_cur";
    public const string string_3 = "lawpc";
    protected Interface27 interface27_0;

    public override string imethod_2(int version)
    {
      return "law_par_cur";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.class1046_0.imethod_0(reader);
      this.interface27_0 = (Interface27) new Class439(reader.imethod_8(), reader.imethod_8());
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      this.class1046_0.imethod_1(writer);
      writer.imethod_7(this.interface27_0.Start);
      writer.imethod_7(this.interface27_0.End);
    }
  }
}
