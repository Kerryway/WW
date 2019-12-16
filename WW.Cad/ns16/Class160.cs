// Decompiled with JetBrains decompiler
// Type: ns16.Class160
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns16
{
  internal class Class160 : Class156
  {
    public const string string_2 = "materialadesk-attrib";
    private ulong ulong_0;

    public override string imethod_2(int version)
    {
      return "materialadesk-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      ulong num = (ulong) reader.imethod_5();
      this.ulong_0 = ((ulong) reader.imethod_5() << 32) + num;
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_4((int) (uint) this.ulong_0);
      writer.imethod_4((int) (uint) (this.ulong_0 >> 32));
    }
  }
}
