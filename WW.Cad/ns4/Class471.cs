// Decompiled with JetBrains decompiler
// Type: ns4.Class471
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace ns4
{
  internal class Class471 : IComparable<Class471>
  {
    private readonly Class471.Enum13 enum13_0;
    private double double_0;
    private char char_0;

    public Class471(Class471.Enum13 type)
    {
      this.enum13_0 = type;
    }

    public Class471(double position)
      : this(Class471.Enum13.const_0)
    {
      this.Position = position;
    }

    public Class471.Enum13 Type
    {
      get
      {
        return this.enum13_0;
      }
    }

    public double Position
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

    public char DecimalPointChar
    {
      get
      {
        return this.char_0;
      }
      set
      {
        this.char_0 = value;
      }
    }

    public int CompareTo(Class471 other)
    {
      double num = this.Position - other.Position;
      if (num == 0.0)
        return 0;
      return num >= 0.0 ? 1 : -1;
    }

    internal enum Enum13 : short
    {
      const_3 = 68, // 0x0044
      const_1 = 99, // 0x0063
      const_2 = 114, // 0x0072
      const_0 = 116, // 0x0074
    }
  }
}
