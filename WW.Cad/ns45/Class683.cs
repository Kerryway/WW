// Decompiled with JetBrains decompiler
// Type: ns45.Class683
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns45
{
  internal class Class683 : Class682
  {
    private double double_8;

    public override void imethod_0(Interface8 reader)
    {
      this.double_8 = reader.imethod_8();
      base.imethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.imethod_7(this.double_8);
      writer.imethod_15();
      base.imethod_1(writer);
    }
  }
}
