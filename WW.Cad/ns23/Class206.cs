﻿// Decompiled with JetBrains decompiler
// Type: ns23.Class206
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns23
{
  internal class Class206 : Class205
  {
    public const string string_4 = "swept_tpr_spl_sur";
    public const string string_5 = "swepttapersur";

    public override string imethod_2(int version)
    {
      return "swepttapersur";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      if (reader.FileFormatVersion < Class250.int_38)
        return;
      this.double_4 = reader.imethod_8();
      this.double_5 = reader.imethod_8();
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      if (writer.FileFormatVersion < Class250.int_38)
        return;
      writer.imethod_7(this.double_4);
      writer.imethod_7(this.double_5);
    }
  }
}
