﻿// Decompiled with JetBrains decompiler
// Type: ns9.Class87
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;

namespace ns9
{
  internal class Class87 : Class82
  {
    public const string string_1 = "sphere-surface";

    public override string imethod_2(int version)
    {
      return "sphere-surface";
    }

    protected override Class188 vmethod_4()
    {
      return (Class188) new Class193();
    }

    public Class193 SpherePrimitive
    {
      get
      {
        return (Class193) this.SurfacePrimitive;
      }
    }
  }
}
