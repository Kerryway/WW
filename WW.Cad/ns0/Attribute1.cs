// Decompiled with JetBrains decompiler
// Type: ns0.Attribute1
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace ns0
{
  internal class Attribute1 : Attribute
  {
    private string string_0;
    private int int_0;

    public Attribute1(string name, int valueGroupCode)
    {
      this.string_0 = name;
      this.int_0 = valueGroupCode;
    }

    public Attribute1(string name)
    {
      this.string_0 = name;
      this.int_0 = -1;
    }

    public string Name
    {
      get
      {
        return this.string_0;
      }
    }

    public int ValueGroupCode
    {
      get
      {
        return this.int_0;
      }
    }
  }
}
