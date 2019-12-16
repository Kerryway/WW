// Decompiled with JetBrains decompiler
// Type: ns40.Class601
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns26;
using ns7;
using System.Collections.Generic;
using WW.Math;

namespace ns40
{
  internal abstract class Class601 : Interface3, Interface4
  {
    private Class243 class243_0 = new Class243();
    private Class243 class243_1 = new Class243();
    private Class243 class243_2 = new Class243();
    private static readonly Dictionary<string, Class601.Delegate15> dictionary_0 = new Dictionary<string, Class601.Delegate15>();
    private Class188 class188_0;
    private Class242 class242_0;
    private Point3D point3D_0;
    private int int_0;

    static Class601()
    {
      Class601.dictionary_0.Add("blend_support_zero_curve", (Class601.Delegate15) (() => (Class601) new Class606()));
      Class601.dictionary_0.Add("blendsupzro", (Class601.Delegate15) (() => (Class601) new Class606()));
      Class601.dictionary_0.Add("blend_support_surface", (Class601.Delegate15) (() => (Class601) new Class602()));
      Class601.dictionary_0.Add("blendsupsur", (Class601.Delegate15) (() => (Class601) new Class602()));
      Class601.dictionary_0.Add("blend_support_point_curve", (Class601.Delegate15) (() => (Class601) new Class604()));
      Class601.dictionary_0.Add("blendsuppnt", (Class601.Delegate15) (() => (Class601) new Class604()));
      Class601.dictionary_0.Add("blend_support_curve", (Class601.Delegate15) (() => (Class601) new Class603()));
      Class601.dictionary_0.Add("blendsupcur", (Class601.Delegate15) (() => (Class601) new Class603()));
      Class601.dictionary_0.Add("blend_support_cos_curve", (Class601.Delegate15) (() => (Class601) new Class605()));
      Class601.dictionary_0.Add("blendsupcos", (Class601.Delegate15) (() => (Class601) new Class605()));
    }

    public abstract string imethod_2(int version);

    public static Class601 smethod_0(Interface8 reader)
    {
      string key = reader.ReadString();
      Class601.Delegate15 delegate15;
      if (!Class601.dictionary_0.TryGetValue(key, out delegate15))
        throw new Exception0("Not supported blend support curve type : " + key);
      Class601 class601 = delegate15();
      class601.imethod_0(reader);
      return class601;
    }

    public static void smethod_1(Interface9 writer, Class601 value)
    {
      string str = value.imethod_2(writer.FileFormatVersion);
      writer.WriteString(str);
      value.imethod_1(writer);
    }

    public virtual void imethod_0(Interface8 reader)
    {
      this.class188_0 = Class188.smethod_0(reader);
      this.class242_0 = Class242.smethod_0(reader);
      this.class243_0.vmethod_0(reader);
      this.point3D_0 = reader.imethod_18();
      this.int_0 = 0;
      if (reader.FileFormatVersion < Class250.int_68)
        return;
      this.class243_1.vmethod_0(reader);
      this.int_0 = reader.imethod_5();
      this.class243_2.vmethod_0(reader);
    }

    public virtual void imethod_1(Interface9 writer)
    {
      Class188.smethod_1(writer, this.class188_0);
      Class242.smethod_1(writer, this.class242_0);
      this.class243_0.vmethod_1(writer);
      writer.imethod_17(this.point3D_0);
      if (writer.FileFormatVersion < Class250.int_68)
        return;
      this.class243_1.vmethod_1(writer);
      writer.imethod_4(this.int_0);
      this.class243_2.vmethod_1(writer);
    }

    private delegate Class601 Delegate15();
  }
}
