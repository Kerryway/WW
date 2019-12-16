// Decompiled with JetBrains decompiler
// Type: ns9.Class108
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;

namespace ns9
{
  internal class Class108 : Class107
  {
    public const string string_1 = "tcoedge-coedge";
    private double double_0;
    private double double_1;
    private Class81 class81_1;
    private Class242 class242_0;
    private int int_3;

    public override string imethod_2(int version)
    {
      return "tcoedge-coedge";
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.double_0 = reader.imethod_8();
      this.double_1 = reader.imethod_8();
      if (reader.FileFormatVersion >= Class250.int_68)
      {
        int index = reader.imethod_7();
        if (index < 0)
        {
          this.class81_1 = (Class81) null;
        }
        else
        {
          this.class81_1 = (Class81) reader[index];
          if (this.class81_1 == null)
            reader.imethod_0(index, (Delegate10) (entity => this.class81_1 = (Class81) entity));
        }
      }
      else
        this.class81_1 = (Class81) null;
      this.class242_0 = (Class242) new Class249();
      this.int_3 = 0;
      if (reader.FileFormatVersion < Class250.int_72)
        return;
      this.int_3 = reader.imethod_5();
      if (this.int_3 == 0 && !(reader is Class951))
        return;
      this.class242_0 = Class242.smethod_0(reader);
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      writer.imethod_7(this.double_0);
      writer.imethod_7(this.double_1);
      if (writer.FileFormatVersion >= Class250.int_68)
        writer.imethod_6((Class80) this.class81_1);
      if (writer.FileFormatVersion < Class250.int_72)
        return;
      writer.imethod_4(this.int_3);
      if (this.int_3 == 0 && !(writer is Class950))
        return;
      Class242.smethod_1(writer, this.class242_0);
    }
  }
}
