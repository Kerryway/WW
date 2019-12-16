// Decompiled with JetBrains decompiler
// Type: ns22.Class195
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns22
{
  internal abstract class Class195
  {
    public static readonly string[] string_0 = new string[3]{ "both", "u", "v" };

    public static Class195.Enum2 smethod_0(Interface8 reader)
    {
      string str = reader.imethod_14();
      if (str == Class195.string_0[0])
        return Class195.Enum2.const_0;
      if (str == Class195.string_0[1])
        return Class195.Enum2.const_1;
      if (!(str == Class195.string_0[2]))
        throw new Exception0("Unknown b-spline rationality type : " + str);
      return Class195.Enum2.const_2;
    }

    public static void smethod_1(Interface9 writer, Class195.Enum2 value)
    {
      string str;
      switch (value)
      {
        case Class195.Enum2.const_0:
          str = Class195.string_0[0];
          break;
        case Class195.Enum2.const_1:
          str = Class195.string_0[1];
          break;
        case Class195.Enum2.const_2:
          str = Class195.string_0[2];
          break;
        default:
          throw new Exception0("Unknown b-spline rationality type");
      }
      writer.imethod_13(str);
    }

    public enum Enum2
    {
      const_0,
      const_1,
      const_2,
    }
  }
}
