// Decompiled with JetBrains decompiler
// Type: ns21.Class191
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns23;
using ns7;

namespace ns21
{
  internal class Class191 : Class188
  {
    public const string string_0 = "spline";
    private Class686.Class690 class690_0;
    private Class197 class197_0;

    public override string imethod_2(int version)
    {
      return "spline";
    }

    public override void imethod_0(Interface8 reader)
    {
      if (reader.FileFormatVersion >= Class250.int_6)
        this.class690_0 = new Class686.Class690(reader);
      this.class197_0 = Class197.smethod_0(reader);
      base.imethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      if (writer.FileFormatVersion >= Class250.int_6)
        writer.imethod_12((Interface39) this.class690_0);
      Class197.smethod_1(writer, this.class197_0);
      base.imethod_1(writer);
    }
  }
}
