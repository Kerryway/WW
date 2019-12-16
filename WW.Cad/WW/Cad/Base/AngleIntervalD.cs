// Decompiled with JetBrains decompiler
// Type: WW.Cad.Base.AngleIntervalD
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Base
{
  public class AngleIntervalD
  {
    private double double_0;
    private double double_1;

    public AngleIntervalD(double min, double max)
    {
      this.double_0 = min;
      this.double_1 = max;
    }

    public double Max
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    public double Min
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

    public bool Contains(double value)
    {
      if (this.double_0 <= this.double_1)
      {
        if (value >= this.double_0)
          return value <= this.double_1;
        return false;
      }
      if (value >= 0.0 && value <= this.double_1)
        return true;
      if (value >= this.double_0)
        return value <= 2.0 * Math.PI;
      return false;
    }

    public bool Overlaps(AngleIntervalD other)
    {
      double num1 = this.double_1 < this.double_0 ? this.double_1 + 2.0 * Math.PI : this.double_1;
      double num2 = other.double_1 < other.double_0 ? other.double_1 + 2.0 * Math.PI : other.double_1;
      if (this.double_0 - 2.0 * Math.PI <= num2 && num1 - 2.0 * Math.PI >= other.double_0 || this.double_0 <= num2 && num1 >= other.double_0)
        return true;
      if (this.double_0 + 2.0 * Math.PI <= num2)
        return num1 + 2.0 * Math.PI >= other.double_0;
      return false;
    }
  }
}
