// Decompiled with JetBrains decompiler
// Type: ns14.Class151
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns14
{
  internal class Class151 : Class144
  {
    public const string string_8 = "string_attrib-name_attrib-gen-attrib";
    private string string_9;

    public override string imethod_2(int version)
    {
      return "string_attrib-name_attrib-gen-attrib";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.string_9 = reader.ReadString();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.WriteString(this.string_9);
    }
  }
}
