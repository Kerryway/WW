// Decompiled with JetBrains decompiler
// Type: ns23.Class210
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;

namespace ns23
{
  internal class Class210 : Class209
  {
    public const string string_5 = "cyl_spl_sur";
    public const string string_6 = "cylsur";

    public override string imethod_2(int version)
    {
      if (version >= 21200)
        return "cyl_spl_sur";
      return version >= 20800 ? "cylsur" : "sumsur";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.class242_0 = Class242.smethod_0(reader);
      Class245 class245 = new Class245();
      this.class242_1 = (Class242) class245;
      class245.Direction = reader.imethod_19();
      this.point3D_0 = class245.Position = reader.imethod_18();
      this.method_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.imethod_15();
      Class242.smethod_1(writer, this.class242_0);
      writer.imethod_15();
      Class245 class2421 = (Class245) this.class242_1;
      writer.imethod_18(class2421.Direction);
      writer.imethod_15();
      writer.imethod_17(this.point3D_0);
      writer.imethod_15();
      this.method_1(writer);
    }
  }
}
