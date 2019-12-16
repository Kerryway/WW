// Decompiled with JetBrains decompiler
// Type: ns9.Class186
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns9
{
  internal class Class186 : Class80
  {
    public const string string_0 = "vertex_template";
    private int[] int_2;

    public override string imethod_2(int version)
    {
      return "vertex_template";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      int length = reader.imethod_5();
      this.int_2 = new int[length];
      for (int index = 0; index < length; ++index)
        this.int_2[index] = reader.imethod_5();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      int length = this.int_2.Length;
      writer.imethod_4(length);
      for (int index = 0; index < length; ++index)
        writer.imethod_4(this.int_2[index]);
    }
  }
}
