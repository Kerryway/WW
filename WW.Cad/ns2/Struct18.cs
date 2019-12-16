// Decompiled with JetBrains decompiler
// Type: ns2.Struct18
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW.Diagnostics;

namespace ns2
{
  internal struct Struct18 : IDumpable
  {
    public static readonly Struct18 struct18_0 = new Struct18(int.MinValue, (object) null);
    private readonly int int_0;
    private string string_0;
    private readonly object object_0;

    public Struct18(int code, object value, string valueString)
    {
      this.int_0 = code;
      if (code != 0)
      {
        this.object_0 = value;
        this.string_0 = valueString;
      }
      else
        this.object_0 = (object) (this.string_0 = valueString.Trim());
    }

    public Struct18(int code, object value)
    {
      this.int_0 = code;
      this.object_0 = value;
      this.string_0 = (string) null;
    }

    public int Code
    {
      get
      {
        return this.int_0;
      }
    }

    public object Value
    {
      get
      {
        return this.object_0;
      }
    }

    public string ValueString
    {
      get
      {
        if (this.string_0 == null && this.object_0 != null)
          this.string_0 = Class820.GetValueString(this.int_0, this.object_0);
        return this.string_0;
      }
    }

    public short Int16
    {
      get
      {
        object obj = this.Value;
        if (obj is short)
          return (short) obj;
        if (!(obj is ushort))
          throw new Exception("Value is not a number.");
        return (short) (ushort) obj;
      }
    }

    public ushort UInt16
    {
      get
      {
        object obj = this.Value;
        if (obj is ushort)
          return (ushort) obj;
        if (!(obj is short))
          throw new Exception("Value is not a number.");
        return (ushort) (short) obj;
      }
    }

    public string GetValueString(int baseCode)
    {
      if (this.string_0 == null && this.object_0 != null)
        this.string_0 = Class820.GetValueString(baseCode, this.object_0);
      return this.string_0;
    }

    public override string ToString()
    {
      return "Code: " + (object) this.int_0 + "\tValue: " + this.Value;
    }

    public override bool Equals(object other)
    {
      return this == (Struct18) other;
    }

    public override int GetHashCode()
    {
      return this.int_0.GetHashCode();
    }

    public static bool operator ==(Struct18 group1, Struct18 group2)
    {
      if (group1.int_0 != group2.int_0)
        return false;
      return group1.Value != null ? group1.Value.Equals(group2.Value) : group2.Value == null;
    }

    public static bool operator !=(Struct18 group1, Struct18 group2)
    {
      return !(group1 == group2);
    }

    public void Dump(DumpWriter w)
    {
      w.WriteField("code", this.int_0);
      w.WriteField("value", this.ValueString);
    }
  }
}
