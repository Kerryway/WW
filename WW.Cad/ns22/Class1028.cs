// Decompiled with JetBrains decompiler
// Type: ns22.Class1028
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;

namespace ns22
{
  internal abstract class Class1028
  {
    public static readonly string[] string_0 = new string[4]{ "none", "low", "high", "both" };

    public static Class1028.Enum49 smethod_0(Interface8 reader)
    {
      if (reader.FileFormatVersion > Class250.int_27)
        return (Class1028.Enum49) reader.imethod_11(Class1028.string_0);
      string str = reader.imethod_14();
      if (str == Class1028.string_0[0])
        return Class1028.Enum49.const_0;
      if (str == Class1028.string_0[1])
        return Class1028.Enum49.const_1;
      if (str == Class1028.string_0[2])
        return Class1028.Enum49.const_2;
      if (!(str == Class1028.string_0[3]))
        throw new Exception0("Unknown b-spline type : " + str);
      return Class1028.Enum49.const_3;
    }

    public static void smethod_1(Interface9 writer, Class1028.Enum49 value)
    {
      if (writer.FileFormatVersion > Class250.int_27)
      {
        writer.imethod_10(Class1028.string_0, (int) value);
      }
      else
      {
        string str;
        switch (value)
        {
          case Class1028.Enum49.const_0:
            str = Class1028.string_0[0];
            break;
          case Class1028.Enum49.const_1:
            str = Class1028.string_0[1];
            break;
          case Class1028.Enum49.const_2:
            str = Class1028.string_0[2];
            break;
          case Class1028.Enum49.const_3:
            str = Class1028.string_0[3];
            break;
          default:
            throw new Exception0("Unknown b-spline type");
        }
        writer.imethod_13(str);
      }
    }

    public enum Enum49
    {
      const_0,
      const_1,
      const_2,
      const_3,
    }
  }
}
