// Decompiled with JetBrains decompiler
// Type: ns2.Class53
// Assembly: WW, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: BD55C298-7046-4DB4-B5D3-FC4FAD79FB41
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.dll

using ns3;
using System;

namespace ns2
{
  internal class Class53
  {
    private byte byte_0;
    private string string_0;
    private Enum0 enum0_0;
    private string string_1;
    private bool bool_0;
    private int int_0;
    private string string_2;
    private Exception exception_0;

    public Class53(string productName)
    {
      this.string_0 = productName;
    }

    public byte Version
    {
      get
      {
        return this.byte_0;
      }
      set
      {
        this.byte_0 = value;
      }
    }

    public string ProductName
    {
      get
      {
        return this.string_0;
      }
    }

    public Enum0 LicensedEdition
    {
      get
      {
        return this.enum0_0;
      }
      set
      {
        this.enum0_0 = value;
      }
    }

    public bool IsTrial
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

    public int TrialDaysLeft
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

    public string Message
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

    public string Licensee
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

    public Exception Exception
    {
      get
      {
        return this.exception_0;
      }
      set
      {
        this.exception_0 = value;
      }
    }
  }
}
