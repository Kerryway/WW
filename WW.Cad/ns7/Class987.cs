// Decompiled with JetBrains decompiler
// Type: ns7.Class987
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace ns7
{
  internal class Class987
  {
    private const string string_0 = "EEE MMM dd HH:mm:ss yyyy";
    public const double double_0 = -1.0;
    public const double double_1 = 1E-06;
    public const double double_2 = 1E-10;
    private DateTime dateTime_0;

    public Class987(int version)
    {
      this.Version = version;
      this.MmPerUnit = -1.0;
      this.AbsoluteResolution = 1E-06;
      this.NormalResolution = 1E-10;
      this.dateTime_0 = DateTime.Now;
    }

    public Class987(Interface8 reader)
    {
      this.Version = reader.FileFormatVersion;
      reader.imethod_17(this);
    }

    public int Version { get; set; }

    public int NumberOfRecords { get; set; }

    public int EntityCount { get; set; }

    public bool HistorySaved { get; set; }

    public string Product { get; set; }

    public string AcisVersion { get; set; }

    public DateTime Date
    {
      get
      {
        return this.dateTime_0;
      }
      set
      {
        this.dateTime_0 = value;
      }
    }

    public double MmPerUnit { get; set; }

    public double AbsoluteResolution { get; set; }

    public double NormalResolution { get; set; }

    public void method_0(string dateString)
    {
    }

    public string method_1()
    {
      return "Thu Mar 05 20:03:45 2009";
    }
  }
}
