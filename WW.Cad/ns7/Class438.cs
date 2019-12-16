// Decompiled with JetBrains decompiler
// Type: ns7.Class438
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace ns7
{
  internal class Class438 : Class437, Interface27, Interface28
  {
    private readonly double double_2;

    protected static double smethod_0(double periodicy)
    {
      periodicy = Math.Abs(periodicy);
      if (periodicy == 0.0)
        periodicy = double.PositiveInfinity;
      return periodicy;
    }

    protected static Interface27 smethod_1(double start, double end, double periodicy)
    {
      periodicy = Class438.smethod_0(periodicy);
      if (periodicy != double.PositiveInfinity)
      {
        if (double.IsInfinity(start))
        {
          if (double.IsInfinity(end))
          {
            start = 0.0;
            end = periodicy;
          }
          else
            end = start + periodicy;
        }
        else if (double.IsInfinity(end))
          start = end - periodicy;
        else if (start > end)
        {
          double num = Math.Ceiling((start - end) / periodicy);
          end += num * periodicy;
        }
      }
      return (Interface27) new Class437(start, end);
    }

    public Class438(double start, double end)
      : base(start, end)
    {
      this.double_2 = double.PositiveInfinity;
    }

    public Class438(Interface27 interval)
      : base(interval)
    {
      this.double_2 = double.PositiveInfinity;
    }

    public Class438(double start, double end, double periodicy)
      : base(Class438.smethod_1(start, end, periodicy))
    {
      this.double_2 = Class438.smethod_0(periodicy);
    }

    public Class438(Interface27 interval, double periodicy)
      : this(interval.Start, interval.End, periodicy)
    {
    }

    public bool IsPeriodic
    {
      get
      {
        return this.double_2 != double.PositiveInfinity;
      }
    }

    public double PeriodicLength
    {
      get
      {
        return this.double_2;
      }
    }

    public override string ToString()
    {
      if (!this.IsPeriodic)
        return "[" + (object) this.Start + "," + (object) this.End + "]";
      return "[" + (object) this.Start + "," + (object) this.End + "]%" + (object) this.double_2;
    }
  }
}
