// Decompiled with JetBrains decompiler
// Type: ns25.Class238
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using ns9;
using System.Collections.Generic;

namespace ns25
{
  internal abstract class Class238 : Class196
  {
    private static readonly Dictionary<string, Class238.Delegate12> dictionary_0 = new Dictionary<string, Class238.Delegate12>();

    static Class238()
    {
      Class238.dictionary_0.Add("exp_par_cur", (Class238.Delegate12) (() => (Class238) new Class239()));
      Class238.dictionary_0.Add("exppc", (Class238.Delegate12) (() => (Class238) new Class239()));
      Class238.dictionary_0.Add("imp_par_cur", (Class238.Delegate12) (() => (Class238) new Class241()));
      Class238.dictionary_0.Add("imppc", (Class238.Delegate12) (() => (Class238) new Class241()));
      Class238.dictionary_0.Add("law_par_cur", (Class238.Delegate12) (() => (Class238) new Class240()));
      Class238.dictionary_0.Add("lawpc", (Class238.Delegate12) (() => (Class238) new Class240()));
    }

    public override void imethod_0(Interface8 reader)
    {
    }

    public override void imethod_1(Interface9 writer)
    {
    }

    public static Class238 smethod_0(Interface8 reader)
    {
      reader.imethod_10();
      string key = reader.imethod_14();
      Class238 class238;
      if (key == "ref")
      {
        int index = reader.imethod_5();
        class238 = (Class238) reader.imethod_1(index);
        if (class238 == null)
          throw new Exception0("Missing subentity : " + (object) index);
      }
      else
      {
        Class238.Delegate12 delegate12;
        if (!Class238.dictionary_0.TryGetValue(key, out delegate12))
          throw new Exception0("Not supported sub pcurve type : " + key);
        class238 = delegate12();
        reader.imethod_2((Class196) class238);
        class238.imethod_0(reader);
      }
      reader.imethod_9();
      return class238;
    }

    public static void smethod_1(Interface9 writer, Class238 subEntity)
    {
      writer.imethod_9();
      int num = writer.imethod_3((Class196) subEntity);
      if (num == -1)
      {
        writer.imethod_2((Class196) subEntity);
        string str = subEntity.imethod_2(writer.FileFormatVersion);
        writer.imethod_13(str);
        subEntity.imethod_1(writer);
        writer.imethod_15();
      }
      else
      {
        writer.imethod_13("ref");
        writer.imethod_4(num);
      }
      writer.imethod_8();
    }

    private delegate Class238 Delegate12();
  }
}
