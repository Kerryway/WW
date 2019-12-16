// Decompiled with JetBrains decompiler
// Type: ns14.Class147
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using ns9;

namespace ns14
{
  internal class Class147 : Class144
  {
    public const string string_8 = "pointer_attrib-name_attrib-gen-attrib";
    private Class80 class80_1;

    public override string imethod_2(int version)
    {
      return "pointer_attrib-name_attrib-gen-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class80_1 = entity));
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_6(this.class80_1);
    }
  }
}
