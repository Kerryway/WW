// Decompiled with JetBrains decompiler
// Type: ns8.Class69
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using System.Collections.Generic;

namespace ns8
{
  internal class Class69 : Interface3, Interface4
  {
    private static readonly Dictionary<string, Class69.Delegate1> dictionary_0 = new Dictionary<string, Class69.Delegate1>();
    public const string string_0 = "base color";
    public const string string_1 = "vector";
    public const string string_2 = "mix";
    public const string string_3 = "ambient factor";
    public const string string_4 = "diffuse factor";
    public const string string_5 = "specular factor";
    public const string string_6 = "mirror factor";
    public const string string_7 = "roughness";
    public const string string_8 = "chrome factor";
    public const string string_9 = "color";
    public const string string_10 = "specular color";
    public const string string_11 = "odd color";
    public const string string_12 = "even color";
    public const string string_13 = "intensity";
    public const string string_14 = "location";
    public const string string_15 = "to";
    public const string string_16 = "shadows";
    public const string string_17 = "shadow resolution";
    public const string string_18 = "shadow quality";
    public const string string_19 = "shadow softness";
    public const string string_20 = "exponent";
    public const string string_21 = "size";
    public const string string_22 = "scale";
    public const string string_23 = "detail";
    public const string string_24 = "ground color";
    public const string string_25 = "vein color";
    public const string string_26 = "vein contrast";
    public const string string_27 = "grain";
    public const string string_28 = "grain scale";
    public const string string_29 = "light wood color";
    public const string string_30 = "dark wood color";
    public const string string_31 = "point on axis";
    public const string string_32 = "axis direction";
    public const string string_33 = "noise";

    public static Class69 smethod_0(Interface8 reader)
    {
      string key = reader.ReadString();
      Class69.Delegate1 delegate1;
      if (!Class69.dictionary_0.TryGetValue(key, out delegate1))
        throw new Exception0("Not supported shader type : " + key);
      Class69 class69 = delegate1();
      class69.imethod_0(reader);
      return class69;
    }

    public static void smethod_1(Interface9 writer, Class69 subEntity)
    {
      string str = subEntity.imethod_2(writer.FileFormatVersion);
      writer.WriteString(str);
      subEntity.imethod_1(writer);
    }

    public virtual string imethod_2(int version)
    {
      return "";
    }

    public virtual void imethod_0(Interface8 reader)
    {
    }

    public virtual void imethod_1(Interface9 writer)
    {
    }

    static Class69()
    {
      Class69.dictionary_0.Add("chrome 2D", (Class69.Delegate1) (() => (Class69) new Class79()));
      Class69.dictionary_0.Add("chrome", (Class69.Delegate1) (() => (Class69) new Class72()));
      Class69.dictionary_0.Add("distant", (Class69.Delegate1) (() => (Class69) new Class73()));
      Class69.dictionary_0.Add("marble", (Class69.Delegate1) (() => (Class69) new Class74()));
      Class69.dictionary_0.Add("mirror", (Class69.Delegate1) (() => (Class69) new Class71()));
      Class69.dictionary_0.Add("none", (Class69.Delegate1) (() => (Class69) new Class76()));
      Class69.dictionary_0.Add("phong", (Class69.Delegate1) (() => (Class69) new Class77()));
      Class69.dictionary_0.Add("plain", (Class69.Delegate1) (() => (Class69) new Class78()));
      Class69.dictionary_0.Add("simple wood", (Class69.Delegate1) (() => (Class69) new Class75()));
      Class69.dictionary_0.Add("wrapped checker", (Class69.Delegate1) (() => (Class69) new Class70()));
    }

    public enum Enum1
    {
      const_4 = -6,
      const_3 = -5,
      const_2 = -4,
      const_1 = -2,
      const_0 = -1,
    }

    private delegate Class69 Delegate1();
  }
}
