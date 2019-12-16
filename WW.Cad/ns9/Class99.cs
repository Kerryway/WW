// Decompiled with JetBrains decompiler
// Type: ns9.Class99
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns41;
using ns7;

namespace ns9
{
  internal class Class99 : Class81
  {
    public const string string_0 = "pcurve";
    private Interface3 interface3_0;
    private int int_2;
    private Class88 class88_0;
    private Class439 class439_0;

    public override string imethod_2(int version)
    {
      return "pcurve";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.int_2 = reader.imethod_5();
      if (this.int_2 == 0)
      {
        this.interface3_0 = (Interface3) new Class607();
        this.interface3_0.imethod_0(reader);
      }
      else
      {
        reader.imethod_0(reader.imethod_7(), (Delegate10) (entity => this.class88_0 = (Class88) entity));
        if (reader.FileFormatVersion < Class250.int_11)
          return;
        this.class439_0 = new Class439(reader.imethod_8(), reader.imethod_8());
      }
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_4(this.int_2);
      if (this.int_2 == 0)
      {
        this.interface3_0.imethod_1(writer);
      }
      else
      {
        writer.imethod_6((Class80) this.class88_0);
        if (writer.FileFormatVersion < Class250.int_11)
          return;
        writer.imethod_7(this.class439_0.Start);
        writer.imethod_7(this.class439_0.End);
      }
    }
  }
}
