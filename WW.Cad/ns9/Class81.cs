// Decompiled with JetBrains decompiler
// Type: ns9.Class81
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns9
{
  internal abstract class Class81 : Class80
  {
    private Class80 class80_0;

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      if (reader.FileFormatVersion >= Class250.int_61)
      {
        int index = reader.imethod_7();
        if (index < 0)
          this.class80_0 = (Class80) null;
        else
          reader.imethod_0(index, (Delegate10) (entity => this.class80_0 = entity));
      }
      else
        this.class80_0 = (Class80) null;
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      if (writer.FileFormatVersion < Class250.int_61)
        return;
      writer.imethod_6(this.class80_0);
    }

    public Class80 Pattern
    {
      get
      {
        return this.class80_0;
      }
    }
  }
}
