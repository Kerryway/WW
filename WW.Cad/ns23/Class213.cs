// Decompiled with JetBrains decompiler
// Type: ns23.Class213
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns45;
using ns7;

namespace ns23
{
  internal class Class213 : Class197
  {
    public const string string_3 = "skin_spl_sur";
    public const string string_4 = "skinsur";
    private Class686.Class711 class711_0;
    private Class686.Class712 class712_0;
    private Class686.Class713 class713_0;
    private Class685[] class685_0;
    private Class242[] class242_0;

    public override string imethod_2(int version)
    {
      return "skin_spl_sur";
    }

    public override void imethod_0(Interface8 reader)
    {
      if (Class250.int_32 <= reader.FileFormatVersion)
      {
        this.class711_0 = new Class686.Class711(reader);
        this.class712_0 = new Class686.Class712(reader);
        this.class713_0 = new Class686.Class713(reader);
      }
      int length1 = reader.imethod_5();
      this.class685_0 = new Class685[length1];
      for (int index = 0; index < length1; ++index)
      {
        this.class685_0[index] = new Class685();
        this.class685_0[index].imethod_0(reader);
      }
      if (Class250.int_42 <= reader.FileFormatVersion)
      {
        int length2 = reader.imethod_5();
        this.class242_0 = new Class242[length2];
        for (int index = 0; index < length2; ++index)
          this.class242_0[index] = Class242.smethod_0(reader);
      }
      base.imethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      if (Class250.int_32 <= writer.FileFormatVersion)
      {
        writer.imethod_12((Interface39) this.class711_0);
        writer.imethod_12((Interface39) this.class712_0);
        writer.imethod_12((Interface39) this.class713_0);
      }
      int length1 = this.class685_0.Length;
      writer.imethod_4(length1);
      writer.imethod_15();
      for (int index = 0; index < length1; ++index)
      {
        this.class685_0[index].imethod_1(writer);
        writer.imethod_15();
      }
      if (Class250.int_42 <= writer.FileFormatVersion)
      {
        int length2 = this.class242_0.Length;
        writer.imethod_4(length2);
        writer.imethod_15();
        for (int index = 0; index < length2; ++index)
          Class242.smethod_1(writer, this.class242_0[index]);
      }
      base.imethod_1(writer);
    }

    protected override int vmethod_0(Interface8 reader)
    {
      return 20900;
    }
  }
}
