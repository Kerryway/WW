// Decompiled with JetBrains decompiler
// Type: ns31.Class364
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using System.Collections.Generic;

namespace ns31
{
  internal abstract class Class364 : Interface3, Interface4
  {
    private static readonly Dictionary<string, Class364.Delegate7> dictionary_0 = new Dictionary<string, Class364.Delegate7>();
    private Class686.Class709 class709_0;
    private double double_0;
    private double double_1;

    static Class364()
    {
      Class364.dictionary_0.Add("functional", (Class364.Delegate7) (() => (Class364) new Class368()));
      Class364.dictionary_0.Add("elliptical", (Class364.Delegate7) (() => (Class364) new Class367()));
      Class364.dictionary_0.Add("fixed_width", (Class364.Delegate7) (() => (Class364) new Class366()));
      Class364.dictionary_0.Add("two_ends", (Class364.Delegate7) (() => (Class364) new Class365()));
    }

    public static Class364 smethod_0(Interface8 reader)
    {
      string key = reader.imethod_14();
      Class364.Delegate7 delegate7;
      if (!Class364.dictionary_0.TryGetValue(key, out delegate7))
        throw new Exception0("Not supported var radius type : " + key);
      Class364 class364 = delegate7();
      class364.imethod_0(reader);
      return class364;
    }

    public static void smethod_1(Interface9 writer, Class364 value)
    {
      string str = value.imethod_2(writer.FileFormatVersion);
      writer.imethod_13(str);
      value.imethod_1(writer);
    }

    public abstract string imethod_2(int version);

    public virtual void imethod_0(Interface8 reader)
    {
      this.class709_0 = new Class686.Class709(reader);
      this.double_0 = reader.imethod_8();
      this.double_1 = reader.imethod_8();
    }

    public virtual void imethod_1(Interface9 writer)
    {
      writer.imethod_12((Interface39) this.class709_0);
      writer.imethod_7(this.double_0);
      writer.imethod_7(this.double_1);
    }

    private delegate Class364 Delegate7();
  }
}
