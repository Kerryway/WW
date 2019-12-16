// Decompiled with JetBrains decompiler
// Type: ns23.Class1029
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns31;
using ns7;

namespace ns23
{
  internal class Class1029 : Interface3
  {
    public static readonly string[] string_0 = new string[7]{ "circular", "thumbweights", "rot_ellipse", "rounded_chamfer", "rnd_chamfer", "g2_continuous", "chamfer" };
    private Class1029.Enum50 enum50_0;
    private double double_0;
    private double double_1;
    private Class686.Class710 class710_0;
    private Class364 class364_0;

    public virtual void imethod_0(Interface8 reader)
    {
      int num = reader.imethod_11(Class1029.string_0);
      if (num >= 4)
        --num;
      this.enum50_0 = (Class1029.Enum50) num;
      switch (this.enum50_0)
      {
        case Class1029.Enum50.const_1:
          break;
        case Class1029.Enum50.const_2:
          this.double_0 = reader.imethod_8();
          this.double_1 = reader.imethod_8();
          break;
        case Class1029.Enum50.const_4:
          this.class710_0 = new Class686.Class710(reader);
          if (!this.class710_0.Value)
            break;
          this.class364_0 = Class364.smethod_0(reader);
          break;
        default:
          throw new Exception0("Invalid var cross section type : " + (object) this.enum50_0);
      }
    }

    public virtual void imethod_1(Interface9 writer)
    {
      int enum500 = (int) this.enum50_0;
      if (enum500 >= 4)
        ++enum500;
      writer.imethod_10(Class1029.string_0, enum500);
      switch (this.enum50_0)
      {
        case Class1029.Enum50.const_2:
          writer.imethod_7(this.double_0);
          writer.imethod_7(this.double_1);
          break;
        case Class1029.Enum50.const_4:
          writer.imethod_12((Interface39) this.class710_0);
          if (!this.class710_0.Value)
            break;
          Class364.smethod_1(writer, this.class364_0);
          break;
      }
    }

    public enum Enum50
    {
      const_0 = -1,
      const_1 = 0,
      const_2 = 1,
      const_3 = 2,
      const_4 = 3,
      const_5 = 4,
      const_6 = 5,
    }
  }
}
