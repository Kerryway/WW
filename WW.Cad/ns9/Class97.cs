// Decompiled with JetBrains decompiler
// Type: ns9.Class97
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns9
{
  internal class Class97 : Class96
  {
    public const string string_2 = "tedge-edge";
    private double double_2;

    public override string imethod_2(int version)
    {
      return "tedge-edge";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.double_2 = reader.imethod_8();
      if (reader.FileFormatVersion < Class250.int_69)
        return;
      reader.imethod_5();
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_7(this.double_2);
      if (writer.FileFormatVersion < Class250.int_69)
        return;
      writer.imethod_4(21301);
    }
  }
}
