// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfTimeSpan
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model
{
  public struct DxfTimeSpan
  {
    public static DxfTimeSpan Zero = new DxfTimeSpan(0, 0);
    public const int MillisecondsPerDay = 86400000;
    private int int_0;
    private int int_1;

    public unsafe DxfTimeSpan(int days)
    {
      this = new DxfTimeSpan();
      this.int_0 = days;
    }

    public DxfTimeSpan(int days, int milliseconds)
    {
      this.int_0 = days;
      this.int_1 = milliseconds;
    }

    public int Days
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public int Milliseconds
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public int TotalMilliseconds
    {
      get
      {
        return this.int_0 * 86400000 + this.int_1;
      }
    }

    public double TotalDays
    {
      get
      {
        return (double) this.int_0 + (double) this.int_1 / 86400000.0;
      }
    }

    public override string ToString()
    {
      return string.Format("Days: {0}, milliseconds: {1}", (object) this.int_0, (object) this.int_1);
    }
  }
}
