// Decompiled with JetBrains decompiler
// Type: ns23.Class208
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns23
{
  internal class Class208 : Class204
  {
    private Class686.Class688 class688_1 = new Class686.Class688(false);
    public const string string_4 = "tapersur";
    public const string string_5 = "orthosur";
    public const string string_6 = "ortho_spl_sur";

    public override string imethod_2(int version)
    {
      if (version < Class250.int_38)
        return "tapersur";
      return version < Class250.int_68 ? "orthosur" : "ortho_spl_sur";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.class688_1.Value = false;
      if (reader.FileFormatVersion < Class250.int_38)
        return;
      reader.imethod_13((Interface39) this.class688_1);
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      if (writer.FileFormatVersion < Class250.int_38)
        return;
      writer.imethod_12((Interface39) this.class688_1);
    }

    protected override int vmethod_0(Interface8 reader)
    {
      return 20900;
    }
  }
}
