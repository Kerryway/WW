// Decompiled with JetBrains decompiler
// Type: ns16.Class159
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns16
{
  internal class Class159 : Class156
  {
    public const string string_2 = "truecolor-adesk-attrib";
    private uint uint_0;

    public override string imethod_2(int version)
    {
      return "truecolor-adesk-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.uint_0 = (uint) reader.imethod_5();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_4((int) this.uint_0);
    }
  }
}
