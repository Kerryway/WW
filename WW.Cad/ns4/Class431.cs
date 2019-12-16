// Decompiled with JetBrains decompiler
// Type: ns4.Class431
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using WW;

namespace ns4
{
  internal class Class431 : Interface25
  {
    private static readonly bool[,] bool_0;

    static Class431()
    {
      int length = Class431.smethod_0(typeof (Enum28));
      Class431.bool_0 = new bool[length, length];
      for (int index = 0; index < length; ++index)
      {
        Class431.bool_0[11, index] = true;
        if (index != 9)
        {
          Class431.bool_0[31, index] = true;
          Class431.bool_0[index, 31] = true;
          Class431.bool_0[index, 20] = index != 20;
        }
      }
    }

    public Pair<string, string> imethod_0(string text, ref int position)
    {
      Class757 class7570 = Class757.class757_0;
      while (--position > 0)
      {
        char ch1 = text[position];
        char ch2 = text[position - 1];
        if (Class431.bool_0[(int) class7570[(uint) ch2], (int) class7570[(uint) ch1]])
          return new Pair<string, string>(text.Substring(0, position), text.Substring(position));
      }
      position = -1;
      return (Pair<string, string>) null;
    }

    public Pair<string, string> imethod_1(string text, ref int position)
    {
      int length = text.Length;
      Class757 class7570 = Class757.class757_0;
      if (position < 0)
        position = 0;
      while (++position < length)
      {
        char ch1 = text[position];
        char ch2 = text[position - 1];
        if (Class431.bool_0[(int) class7570[(uint) ch2], (int) class7570[(uint) ch1]])
          return new Pair<string, string>(text.Substring(0, position), text.Substring(position));
      }
      position = -1;
      return (Pair<string, string>) null;
    }

    private static int smethod_0(Type enumType)
    {
      return Enum.GetValues(enumType).Length;
    }
  }
}
