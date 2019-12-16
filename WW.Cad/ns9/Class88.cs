// Decompiled with JetBrains decompiler
// Type: ns9.Class88
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;
using ns7;

namespace ns9
{
  internal class Class88 : Class81, Interface3, Interface5
  {
    public const string string_0 = "curve";
    protected Interface5 interface5_0;

    protected virtual void vmethod_4(Interface8 reader)
    {
      if (this.UsedAsBase)
        return;
      this.interface5_0 = this.vmethod_6();
      this.interface5_0.imethod_0(reader);
    }

    protected virtual void vmethod_5(Interface9 writer)
    {
      if (this.UsedAsBase)
        return;
      this.interface5_0.imethod_1(writer);
    }

    protected virtual Interface5 vmethod_6()
    {
      return (Interface5) null;
    }

    public virtual Interface5 CurvePrimitive
    {
      get
      {
        return this.interface5_0;
      }
    }

    public virtual bool Reversed
    {
      get
      {
        return false;
      }
    }

    internal override void vmethod_0(Interface8 reader)
    {
      base.vmethod_0(reader);
      this.vmethod_4(reader);
    }

    internal override void vmethod_1(Interface9 writer)
    {
      base.vmethod_1(writer);
      this.vmethod_5(writer);
    }

    public virtual void imethod_3(
      Class95 loop,
      Class88 curve,
      Class107 coedge,
      Class917 approximation,
      Class258 accuracy)
    {
      if (this.interface5_0 == null)
        return;
      this.interface5_0.imethod_3(loop, curve, coedge, approximation, accuracy);
    }
  }
}
