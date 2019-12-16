// Decompiled with JetBrains decompiler
// Type: ns22.Class647
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns22
{
  internal abstract class Class647
  {
    public static readonly string[] string_0 = new string[3]{ "nubs", "nurbs", "nullbs" };

    public static Class647.Enum23 smethod_0(Interface8 reader)
    {
      string str = reader.imethod_14();
      if (str == Class647.string_0[0])
        return Class647.Enum23.const_0;
      if (str == Class647.string_0[1])
        return Class647.Enum23.const_1;
      if (!(str == Class647.string_0[2]))
        throw new Exception0("Unknown b-spline type : " + str);
      return Class647.Enum23.const_2;
    }

    public static void smethod_1(Interface9 writer, Class647.Enum23 value)
    {
      string str;
      switch (value)
      {
        case Class647.Enum23.const_0:
          str = Class647.string_0[0];
          break;
        case Class647.Enum23.const_1:
          str = Class647.string_0[1];
          break;
        case Class647.Enum23.const_2:
          str = Class647.string_0[2];
          break;
        default:
          throw new Exception0("Unknown b-spline type");
      }
      writer.imethod_13(str);
    }

    public enum Enum23
    {
      const_0,
      const_1,
      const_2,
    }
  }
}
