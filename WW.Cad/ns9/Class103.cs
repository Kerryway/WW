// Decompiled with JetBrains decompiler
// Type: ns9.Class103
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns9
{
  internal class Class103 : Class102
  {
    public const string string_1 = "tvertex-vertex";
    private double double_0;
    private double double_1;
    private double double_2;

    public override string imethod_2(int version)
    {
      return "tvertex-vertex";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.double_0 = reader.imethod_8();
      if (reader.FileFormatVersion >= Class250.int_69)
      {
        this.double_1 = reader.imethod_8();
        this.double_2 = reader.imethod_8();
      }
      else
        this.double_1 = this.double_2 = this.double_0;
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_7(this.double_0);
      if (writer.FileFormatVersion < Class250.int_69)
        return;
      writer.imethod_7(this.double_1);
      writer.imethod_7(this.double_2);
    }
  }
}
