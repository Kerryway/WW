// Decompiled with JetBrains decompiler
// Type: WW.Cad.Base.LogStatistics
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Base
{
  public class LogStatistics
  {
    private int int_0;
    private int int_1;
    private int int_2;
    private int int_3;

    public LogStatistics(int totalCount, int debugCount, int warningCount, int errorCount)
    {
      this.int_0 = totalCount;
      this.int_1 = debugCount;
      this.int_2 = warningCount;
      this.int_3 = errorCount;
    }

    public int DebugCount
    {
      get
      {
        return this.int_1;
      }
    }

    public int ErrorCount
    {
      get
      {
        return this.int_3;
      }
    }

    public int TotalCount
    {
      get
      {
        return this.int_0;
      }
    }

    public int WarningCount
    {
      get
      {
        return this.int_2;
      }
    }
  }
}
