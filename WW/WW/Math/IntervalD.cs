// Decompiled with JetBrains decompiler
// Type: WW.Math.IntervalD
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

namespace WW.Math
{
  public class IntervalD
  {
    private bool bool_0;
    private bool bool_1;
    private double double_0;
    private double double_1;

    public IntervalD(double value1, double value2)
    {
      this.double_0 = System.Math.Min(value1, value2);
      this.bool_0 = true;
      this.double_1 = System.Math.Max(value1, value2);
      this.bool_1 = true;
    }

    public IntervalD(double min, bool minClosed, double max, bool maxClosed)
    {
      this.double_0 = min;
      this.bool_0 = minClosed;
      this.double_1 = max;
      this.bool_1 = maxClosed;
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

    public bool MinClosed
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
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

    public bool MaxClosed
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public double Delta
    {
      get
      {
        return this.double_1 - this.double_0;
      }
    }

    public override bool Equals(object other)
    {
      IntervalD intervalD = other as IntervalD;
      if (intervalD == null || this.double_0 != intervalD.double_0 || (this.bool_0 != intervalD.bool_0 || this.double_1 != intervalD.double_1))
        return false;
      return this.bool_1 == intervalD.bool_1;
    }

    public override int GetHashCode()
    {
      return this.double_0.GetHashCode() ^ this.double_1.GetHashCode() ^ this.bool_0.GetHashCode() ^ this.bool_1.GetHashCode();
    }

    public bool Contains(double value)
    {
      if ((this.bool_0 ? (value >= this.double_0 ? 1 : 0) : (value > this.double_0 ? 1 : 0)) == 0)
        return false;
      if (!this.bool_1)
        return value < this.double_1;
      return value <= this.double_1;
    }

    public bool Contains(double value, double precision)
    {
      if ((this.bool_0 ? (value > this.double_0 - precision ? 1 : 0) : (value > this.double_0 + precision ? 1 : 0)) == 0)
        return false;
      if (!this.bool_1)
        return value < this.double_1 - precision;
      return value < this.double_1 + precision;
    }

    public bool Overlaps(IntervalD other)
    {
      if ((!this.bool_0 || !other.bool_1 ? (this.double_0 < other.double_1 ? 1 : 0) : (this.double_0 <= other.double_1 ? 1 : 0)) == 0)
        return false;
      if (this.bool_1 && other.bool_0)
        return this.double_1 >= other.double_0;
      return this.double_1 > other.double_0;
    }

    public bool Overlaps(IntervalD other, double precision)
    {
      if ((!this.bool_0 || !other.bool_1 ? (this.double_0 < other.double_1 - precision ? 1 : 0) : (this.double_0 < other.double_1 + precision ? 1 : 0)) == 0)
        return false;
      if (this.bool_1 && other.bool_0)
        return this.double_1 > other.double_0 - precision;
      return this.double_1 > other.double_0 + precision;
    }

    public override string ToString()
    {
      return string.Format("{0} - {1}", (object) this.double_0, (object) this.double_1);
    }

    public static double GetRestrictedValue(double value, double minValue, double maxValue)
    {
      if (value < minValue)
        return minValue;
      if (value > maxValue)
        return maxValue;
      return value;
    }
  }
}
