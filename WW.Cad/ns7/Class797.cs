// Decompiled with JetBrains decompiler
// Type: ns7.Class797
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace ns7
{
  internal class Class797
  {
    private string string_0 = string.Empty;
    private string string_1 = string.Empty;
    private string string_2 = string.Empty;
    private double double_0 = -1.0;
    private double double_1 = 1E-06;
    private double double_2 = 1E-10;
    private int int_0;
    private int int_1;
    private int int_2;
    private bool bool_0;

    public int VersionNumber
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

    public int NumberOfDataRecords
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

    public int EntitiesCount
    {
      get
      {
        return this.int_2;
      }
      set
      {
        this.int_2 = value;
      }
    }

    public bool HasHistory
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

    public string ProductId
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public string AcisVersionString
    {
      get
      {
        return this.string_1;
      }
      set
      {
        this.string_1 = value;
      }
    }

    public string DateTimeString
    {
      get
      {
        return this.string_2;
      }
      set
      {
        this.string_2 = value;
      }
    }

    public double MillimetersPerUnit
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

    public double ResAbs
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

    public double ResNor
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
      }
    }
  }
}
