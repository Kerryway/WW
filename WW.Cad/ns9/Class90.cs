// Decompiled with JetBrains decompiler
// Type: ns9.Class90
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;

namespace ns9
{
  internal class Class90 : Class88
  {
    public const string string_1 = "intcurve-curve";

    public override string imethod_2(int version)
    {
      return "intcurve-curve";
    }

    protected override Interface5 vmethod_6()
    {
      return (Interface5) new Class90();
    }

    protected override void vmethod_4(Interface8 reader)
    {
      this.interface5_0 = (Interface5) new Class246();
      this.interface5_0.imethod_0(reader);
    }

    public override Interface5 CurvePrimitive
    {
      get
      {
        return (Interface5) this;
      }
    }

    public bool IsReversed
    {
      get
      {
        return ((Class246) this.interface5_0).IsReversed;
      }
    }
  }
}
