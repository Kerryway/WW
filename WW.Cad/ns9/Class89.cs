// Decompiled with JetBrains decompiler
// Type: ns9.Class89
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns26;

namespace ns9
{
  internal class Class89 : Class88
  {
    public const string string_1 = "straight-curve";

    public override string imethod_2(int version)
    {
      return "straight-curve";
    }

    protected override Interface5 vmethod_6()
    {
      return (Interface5) new Class245();
    }

    public Class245 StraightPrimitive
    {
      get
      {
        return (Class245) this.CurvePrimitive;
      }
    }
  }
}
