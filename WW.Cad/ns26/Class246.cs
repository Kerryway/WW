// Decompiled with JetBrains decompiler
// Type: ns26.Class246
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns24;
using ns7;
using ns9;

namespace ns26
{
  internal class Class246 : Class242
  {
    public const string string_0 = "intcurve";
    private Class686.Class690 class690_0;
    private Class224 class224_0;

    public override string imethod_2(int version)
    {
      return "intcurve";
    }

    public override void imethod_0(Interface8 reader)
    {
      this.class690_0 = new Class686.Class690(reader);
      if (reader.FileFormatVersion < Class250.int_5)
        throw new Exception0("Unsupported version for intcurve entity!");
      this.class224_0 = Class224.smethod_0(reader.imethod_20());
      base.imethod_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      writer.imethod_12((Interface39) this.class690_0);
      if (writer.FileFormatVersion < Class250.int_5)
        throw new Exception0("Unsupported version for intcurve entity!");
      Class224.smethod_1(writer, this.class224_0);
      base.imethod_1(writer);
    }

    public override void imethod_3(
      Class95 loop,
      Class88 curve,
      Class107 coedge,
      Class917 approximation,
      Class258 accuracy)
    {
      this.class224_0.Approximation?.imethod_3(loop, curve, coedge, approximation, accuracy);
    }

    public bool IsReversed
    {
      get
      {
        return this.class690_0.Value;
      }
    }
  }
}
