// Decompiled with JetBrains decompiler
// Type: ns44.Class648
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using System.Collections.Generic;

namespace ns44
{
  internal abstract class Class648 : Interface3, Interface4
  {
    private static readonly Dictionary<string, Class648.Delegate17> dictionary_0 = new Dictionary<string, Class648.Delegate17>();

    static Class648()
    {
      Class648.dictionary_0.Add("EDGE", (Class648.Delegate17) (() => (Class648) new Class651()));
      Class648.dictionary_0.Add("SURF", (Class648.Delegate17) (() => (Class648) new Class649()));
      Class648.dictionary_0.Add("TRANS", (Class648.Delegate17) (() => (Class648) new Class650()));
    }

    public static Class648 smethod_0(Interface8 reader)
    {
      string key = reader.ReadString();
      Class648.Delegate17 delegate17;
      if (!Class648.dictionary_0.TryGetValue(key, out delegate17))
        throw new Exception0("Not supported Law data type : " + key);
      Class648 class648 = delegate17();
      class648.imethod_0(reader);
      return class648;
    }

    public static void smethod_1(Interface9 writer, Class648 lawData)
    {
      string str = lawData.imethod_2(writer.FileFormatVersion);
      writer.WriteString(str);
      lawData.imethod_1(writer);
    }

    public abstract string imethod_2(int version);

    public virtual void imethod_0(Interface8 reader)
    {
    }

    public virtual void imethod_1(Interface9 writer)
    {
    }

    private delegate Class648 Delegate17();
  }
}
