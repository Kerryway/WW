// Decompiled with JetBrains decompiler
// Type: ns41.Class607
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns25;
using ns7;
using System.Collections.Generic;

namespace ns41
{
  internal class Class607 : Interface3, Interface4
  {
    private static readonly Dictionary<string, Class607.Delegate16> dictionary_0 = new Dictionary<string, Class607.Delegate16>();
    public const string string_0 = "pcurve";
    private Class686.Class690 class690_0;
    private Class238 class238_0;
    private double double_0;
    private double double_1;

    static Class607()
    {
      Class607.dictionary_0.Add("pcurve", (Class607.Delegate16) (() => (Interface3) new Class607()));
      Class607.dictionary_0.Add("null_pcurve", (Class607.Delegate16) (() => (Interface3) new Class989()));
    }

    public string imethod_2(int version)
    {
      return "pcurve";
    }

    public virtual void imethod_0(Interface8 reader)
    {
      this.class690_0 = new Class686.Class690(reader);
      this.class238_0 = Class238.smethod_0(reader.imethod_20());
      this.double_0 = reader.imethod_8();
      this.double_1 = reader.imethod_8();
    }

    public virtual void imethod_1(Interface9 writer)
    {
      writer.imethod_12((Interface39) this.class690_0);
      Class238.smethod_1(writer, this.class238_0);
      writer.imethod_7(this.double_0);
      writer.imethod_7(this.double_1);
    }

    public static Interface3 smethod_0(Interface8 reader)
    {
      string key = reader.imethod_14();
      Class607.Delegate16 delegate16;
      if (!Class607.dictionary_0.TryGetValue(key, out delegate16))
        throw new Exception0("Not supported blend support curve type : " + key);
      Interface3 nterface3 = delegate16();
      nterface3.imethod_0(reader);
      return nterface3;
    }

    public static void smethod_1(Interface9 writer, Interface3 subEntity, Interface4 subTagged)
    {
      writer.imethod_13(subTagged.imethod_2(writer.FileFormatVersion));
      subEntity.imethod_1(writer);
    }

    private delegate Interface3 Delegate16();
  }
}
