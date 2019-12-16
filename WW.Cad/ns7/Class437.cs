// Decompiled with JetBrains decompiler
// Type: ns7.Class437
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace ns7
{
  internal class Class437 : Interface27
  {
    private readonly double double_0;
    private readonly double double_1;

    public Class437(double start, double end)
    {
      this.double_0 = start;
      this.double_1 = end;
    }

    public Class437(Interface27 interval)
    {
      this.double_0 = interval.Start;
      this.double_1 = interval.End;
    }

    public double Start
    {
      get
      {
        return this.double_0;
      }
    }

    public double End
    {
      get
      {
        return this.double_1;
      }
    }

    public bool IsUnbound
    {
      get
      {
        if (!this.HasUnboundStart)
          return this.HasUnboundEnd;
        return true;
      }
    }

    public bool HasUnboundStart
    {
      get
      {
        return double.IsInfinity(this.double_0);
      }
    }

    public bool HasUnboundEnd
    {
      get
      {
        return double.IsInfinity(this.double_1);
      }
    }

    public override string ToString()
    {
      return "[" + (object) this.double_0 + "," + (object) this.double_1 + "]";
    }
  }
}
