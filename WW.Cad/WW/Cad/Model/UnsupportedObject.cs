// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.UnsupportedObject
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model
{
  public class UnsupportedObject : IComparable
  {
    private string string_0 = string.Empty;
    private short short_0;
    private uint uint_0;

    public UnsupportedObject()
    {
    }

    public UnsupportedObject(string name)
    {
      this.string_0 = name;
    }

    public UnsupportedObject(UnsupportedObject obj)
    {
      this.string_0 = obj.string_0;
      this.short_0 = obj.short_0;
      this.uint_0 = obj.uint_0;
    }

    public string Name
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

    public short DwgObjectType
    {
      get
      {
        return this.short_0;
      }
      set
      {
        this.short_0 = value;
      }
    }

    public uint Count
    {
      get
      {
        return this.uint_0;
      }
      set
      {
        this.uint_0 = value;
      }
    }

    public int CompareTo(object other)
    {
      return string.Compare(this.string_0, ((UnsupportedObject) other)?.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    public override string ToString()
    {
      string str = this.string_0;
      if (this.short_0 != (short) 0)
        str = str + ", DWG object type = " + this.short_0.ToString();
      return str;
    }
  }
}
