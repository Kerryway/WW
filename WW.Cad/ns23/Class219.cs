// Decompiled with JetBrains decompiler
// Type: ns23.Class219
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns7;

namespace ns23
{
  internal class Class219 : Class197
  {
    public const string string_3 = "off_spl_sur";
    public const string string_4 = "offsur";
    private Class188 class188_0;
    private double double_3;
    private Class439 class439_2;
    private Class439 class439_3;
    private Class686.Class690 class690_0;
    private Class686.Class690 class690_1;
    private long long_0;
    private Class686.Class688 class688_1;
    private Class686.Class688 class688_2;

    public override string imethod_2(int tagVersion)
    {
      return "off_spl_sur";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.class188_0 = Class188.smethod_0(reader);
      this.double_3 = reader.imethod_8();
      if (reader.FileFormatVersion < Class250.int_48)
      {
        this.class439_2 = new Class439(reader.imethod_8(), reader.imethod_8());
        this.class439_3 = new Class439(reader.imethod_8(), reader.imethod_8());
      }
      this.class690_0 = new Class686.Class690(reader);
      this.class690_1 = reader.FileFormatVersion < Class250.int_35 ? new Class686.Class690(false) : new Class686.Class690(reader);
      this.class688_1 = reader.FileFormatVersion < Class250.int_69 ? new Class686.Class688(false) : new Class686.Class688(reader);
      this.class688_2 = reader.FileFormatVersion < Class250.int_70 ? new Class686.Class688(false) : new Class686.Class688(reader);
      if (reader.FileFormatVersion < Class250.int_48)
        return;
      this.method_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.imethod_15();
      Class188.smethod_1(writer, this.class188_0);
      writer.imethod_15();
      writer.imethod_7(this.double_3);
      writer.imethod_15();
      if (writer.FileFormatVersion < Class250.int_48)
      {
        writer.imethod_7(this.class439_2.Start);
        writer.imethod_7(this.class439_2.End);
        writer.imethod_7(this.class439_3.Start);
        writer.imethod_7(this.class439_3.End);
      }
      writer.imethod_12((Interface39) this.class690_0);
      if (writer.FileFormatVersion >= Class250.int_35)
        writer.imethod_12((Interface39) this.class690_1);
      if (writer.FileFormatVersion >= Class250.int_69)
        writer.imethod_12((Interface39) this.class688_1);
      if (writer.FileFormatVersion >= Class250.int_70)
        writer.imethod_12((Interface39) this.class688_2);
      if (writer.FileFormatVersion < Class250.int_48)
        return;
      this.method_1(writer);
    }

    protected override int vmethod_0(Interface8 reader)
    {
      return 20900;
    }
  }
}
