// Decompiled with JetBrains decompiler
// Type: ns45.Class684
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns7;

namespace ns45
{
  internal class Class684 : Class683
  {
    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      if (reader.FileFormatVersion >= Class250.int_68 || reader.FileFormatVersion < Class250.int_73)
        return;
      this.class188_1 = Class188.smethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      writer.imethod_15();
      if (writer.FileFormatVersion >= Class250.int_68 || writer.FileFormatVersion < Class250.int_73)
        return;
      Class188.smethod_1(writer, this.class188_1);
    }
  }
}
