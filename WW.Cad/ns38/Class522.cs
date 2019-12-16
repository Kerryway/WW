// Decompiled with JetBrains decompiler
// Type: ns38.Class522
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace ns38
{
  internal class Class522
  {
    private byte byte_0;
    private string string_0;
    private Enum15 enum15_0;
    private string string_1;
    private bool bool_0;
    private int int_0;
    private string string_2;
    private Exception exception_0;

    public Class522(string productName)
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

    public Enum15 LicensedEdition
    {
      get
      {
        return this.enum15_0;
      }
      set
      {
        this.enum15_0 = value;
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
