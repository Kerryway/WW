// Decompiled with JetBrains decompiler
// Type: ns26.Class242
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using ns9;
using System.Collections.Generic;

namespace ns26
{
  internal abstract class Class242 : Interface3, Interface4, Interface5
  {
    private static readonly Dictionary<string, Class242.Delegate6> dictionary_0 = new Dictionary<string, Class242.Delegate6>();
    private Class439 class439_0;

    static Class242()
    {
      Class242.dictionary_0.Add("ellipse", (Class242.Delegate6) (() => (Class242) new Class247()));
      Class242.dictionary_0.Add("intcurve", (Class242.Delegate6) (() => (Class242) new Class246()));
      Class242.dictionary_0.Add("straight", (Class242.Delegate6) (() => (Class242) new Class245()));
      Class242.dictionary_0.Add("degenerate_curve", (Class242.Delegate6) (() => (Class242) new Class248()));
      Class242.dictionary_0.Add("null_curve", (Class242.Delegate6) (() => (Class242) new Class249()));
    }

    public static Class242 smethod_0(Interface8 reader)
    {
      string key = reader.imethod_14();
      Class242.Delegate6 delegate6;
      if (!Class242.dictionary_0.TryGetValue(key, out delegate6))
        throw new Exception0("Not supported sub curve primitive type : " + key);
      Class242 class242 = delegate6();
      class242.imethod_0(reader);
      return class242;
    }

    public static void smethod_1(Interface9 writer, Class242 subEntity)
    {
      string str = subEntity.imethod_2(writer.FileFormatVersion);
      writer.imethod_13(str);
      subEntity.imethod_1(writer);
    }

    public abstract string imethod_2(int version);

    public virtual void imethod_0(Interface8 reader)
    {
      this.vmethod_0(reader);
      if (reader.FileFormatVersion < Class250.int_16)
        return;
      this.class439_0 = new Class439(reader);
    }

    public virtual void imethod_1(Interface9 writer)
    {
      this.vmethod_1(writer);
      if (writer.FileFormatVersion < Class250.int_16)
        return;
      this.class439_0.method_0(writer);
    }

    public virtual void vmethod_0(Interface8 reader)
    {
    }

    public virtual void vmethod_1(Interface9 writer)
    {
    }

    public virtual Interface27 Interval
    {
      get
      {
        return (Interface27) this.class439_0;
      }
    }

    public virtual void imethod_3(
      Class95 loop,
      Class88 curve,
      Class107 coedge,
      Class917 approximation,
      Class258 accuracy)
    {
    }

    private delegate Class242 Delegate6();
  }
}
