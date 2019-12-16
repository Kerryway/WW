// Decompiled with JetBrains decompiler
// Type: ns32.Class369
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns7;
using System.Collections.Generic;
using WW.Math;

namespace ns32
{
  internal class Class369 : Interface3, Interface4
  {
    private static readonly Dictionary<string, Class369.Delegate8> dictionary_0 = new Dictionary<string, Class369.Delegate8>();
    private double double_0;
    private Class686.Class718 class718_0;
    private Vector3D vector3D_0;
    private Class686.Class719 class719_0;
    private Class686.Class719 class719_1;

    static Class369()
    {
      Class369.dictionary_0.Add("circle", (Class369.Delegate8) (() => (Class369) new Class373()));
      Class369.dictionary_0.Add("2", (Class369.Delegate8) (() => (Class369) new Class373()));
      Class369.dictionary_0.Add("deg", (Class369.Delegate8) (() => (Class369) new Class372()));
      Class369.dictionary_0.Add("3", (Class369.Delegate8) (() => (Class369) new Class372()));
      Class369.dictionary_0.Add("pcurve", (Class369.Delegate8) (() => (Class369) new Class371()));
      Class369.dictionary_0.Add("0", (Class369.Delegate8) (() => (Class369) new Class371()));
      Class369.dictionary_0.Add("plane", (Class369.Delegate8) (() => (Class369) new Class370()));
      Class369.dictionary_0.Add("1", (Class369.Delegate8) (() => (Class369) new Class370()));
    }

    public static Class369 smethod_0(Interface8 reader)
    {
      string key = reader.imethod_14();
      Class369.Delegate8 delegate8;
      if (!Class369.dictionary_0.TryGetValue(key, out delegate8))
        throw new Exception0("Not supported body geometry primitive type : " + key);
      Class369 class369 = delegate8();
      class369.imethod_0(reader);
      return class369;
    }

    public static void smethod_1(Interface9 writer, Class369 bodyGeometry)
    {
      writer.imethod_13(bodyGeometry.imethod_2(writer.FileFormatVersion));
      bodyGeometry.imethod_1(writer);
    }

    public virtual string imethod_2(int version)
    {
      throw new Exception0("Wrong call of SatBodyGeometry.GetTag");
    }

    public virtual void imethod_0(Interface8 reader)
    {
      this.double_0 = 0.0;
      if (reader.FileFormatVersion == Class250.int_9)
      {
        this.double_0 = reader.imethod_8();
      }
      else
      {
        this.class718_0 = new Class686.Class718(reader);
        this.vector3D_0 = reader.imethod_19();
        this.class719_0 = new Class686.Class719(reader);
        this.class719_1 = new Class686.Class719(reader);
        this.double_0 = reader.imethod_8();
      }
    }

    public virtual void imethod_1(Interface9 writer)
    {
      if (writer.FileFormatVersion == Class250.int_9)
      {
        writer.imethod_7(this.double_0);
      }
      else
      {
        writer.imethod_12((Interface39) this.class718_0);
        writer.imethod_18(this.vector3D_0);
        writer.imethod_12((Interface39) this.class719_0);
        writer.imethod_12((Interface39) this.class719_1);
        writer.imethod_7(this.double_0);
      }
    }

    private delegate Class369 Delegate8();
  }
}
