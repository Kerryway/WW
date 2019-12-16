// Decompiled with JetBrains decompiler
// Type: ns15.Class153
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using ns9;

namespace ns15
{
  internal class Class153 : Class152
  {
    public const string string_3 = "ref_vt-eye-attrib";
    public const string string_4 = "ref_vt-lwd-attrib";
    private Class80 class80_1;
    private Class80 class80_2;

    public override string imethod_2(int version)
    {
      return version >= Class250.int_21 ? "ref_vt-eye-attrib" : "ref_vt-lwd-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class80_1 = entity));
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class80_2 = entity));
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_6(this.class80_1);
      writer.imethod_6(this.class80_2);
    }
  }
}
