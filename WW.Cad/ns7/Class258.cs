// Decompiled with JetBrains decompiler
// Type: ns7.Class258
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace ns7
{
  internal class Class258
  {
    private readonly double double_0;
    private readonly bool bool_0;

    public Class258(double epsilon, bool absolute)
    {
      if (epsilon <= 0.0)
        throw new ArgumentException("epsilon may not be negative or 0!");
      this.double_0 = epsilon;
      this.bool_0 = absolute;
    }

    public double Epsilon
    {
      get
      {
        return this.double_0;
      }
    }

    public bool Absolute
    {
      get
      {
        return this.bool_0;
      }
    }

    public double method_0(double size)
    {
      if (!this.bool_0 && size != 0.0)
        return Math.Abs(size) * this.double_0;
      return this.double_0;
    }
  }
}
