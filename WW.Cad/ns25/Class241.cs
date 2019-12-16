// Decompiled with JetBrains decompiler
// Type: ns25.Class241
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;

namespace ns25
{
  internal class Class241 : Class238
  {
    private Class246 class246_0 = new Class246();
    public const string string_0 = "imp_par_cur";
    public const string string_1 = "imppc";
    private Class686.Class697 class697_0;

    public override string imethod_2(int version)
    {
      return "imp_par_cur";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.class246_0.imethod_0(reader);
      this.class697_0 = new Class686.Class697(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      this.class246_0.imethod_1(writer);
      writer.imethod_12((Interface39) this.class697_0);
    }
  }
}
