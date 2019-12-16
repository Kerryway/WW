// Decompiled with JetBrains decompiler
// Type: ns1.Class0
// Assembly: WW.GL, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: AE360D55-38F4-46F1-B4CA-309C1FE9C4FB
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.GL.dll

using ns2;
using System;

namespace ns1
{
  internal class Class0
  {
    private byte byte_0;
    private string string_0;
    private Enum0 enum0_0;
    private string string_1;
    private bool bool_0;
    private int int_0;
    private string string_2;
    private Exception exception_0;

    public Class0(string productName)
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
