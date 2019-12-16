// Decompiled with JetBrains decompiler
// Type: ns18.Class173
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns18
{
  internal class Class173 : Class172
  {
    public const string string_2 = "named_attribute-st-attrib";
    private string string_3;

    public override string imethod_2(int version)
    {
      return "named_attribute-st-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.string_3 = reader.ReadString();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.WriteString(this.string_3);
    }
  }
}
