// Decompiled with JetBrains decompiler
// Type: ns17.Class170
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using ns9;

namespace ns17
{
  internal class Class170 : Class162
  {
    public const string string_2 = "tag-sys-attrib";
    private Class686.Class716 class716_0;
    private Class80 class80_1;
    private int int_2;

    public override string imethod_2(int version)
    {
      return "tag-sys-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.class716_0 = new Class686.Class716(reader);
      if (this.class716_0.Value)
        this.int_2 = reader.imethod_5();
      else
        reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class80_1 = entity));
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_12((Interface39) this.class716_0);
      if (this.class716_0.Value)
        writer.imethod_4(this.int_2);
      else
        writer.imethod_6(this.class80_1);
    }
  }
}
