﻿// Decompiled with JetBrains decompiler
// Type: ns31.Class366
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns31
{
  internal class Class366 : Class364
  {
    public const string string_0 = "fixed_width";
    private double double_2;

    public override string imethod_2(int version)
    {
      return "fixed_width";
    }

    public override void imethod_0(Interface8 reader)
    {
      base.imethod_0(reader);
      this.double_2 = reader.imethod_8();
    }

    public override void imethod_1(Interface9 writer)
    {
      base.imethod_1(writer);
      writer.imethod_7(this.double_2);
    }
  }
}
