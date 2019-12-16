// Decompiled with JetBrains decompiler
// Type: ns8.Class77
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using System;
using System.Collections.Generic;

namespace ns8
{
  internal class Class77
  {
    private readonly IDictionary<uint, int> idictionary_0;

    public Class77()
      : this(100)
    {
    }

    public Class77(int numPairs)
    {
      this.idictionary_0 = (IDictionary<uint, int>) new Dictionary<uint, int>(Math.Max(numPairs, 100));
    }

    public bool method_0(ushort left, ushort right)
    {
      return this.idictionary_0.ContainsKey(Class77.smethod_0(left, right));
    }

    public int this[ushort left, ushort right]
    {
      get
      {
        int num;
        if (this.idictionary_0.TryGetValue(Class77.smethod_0(left, right), out num))
          return num;
        return 0;
      }
    }

    public int Length
    {
      get
      {
        return this.idictionary_0.Count;
      }
    }

    internal void method_1(ushort left, ushort right, int value)
    {
      if (value == 0)
        return;
      uint key = Class77.smethod_0(left, right);
      if (this.idictionary_0.ContainsKey(key))
        return;
      this.idictionary_0[key] = value;
    }

    private static uint smethod_0(ushort left, ushort right)
    {
      return ((uint) left << 16) + (uint) right;
    }
  }
}
