// Decompiled with JetBrains decompiler
// Type: ns24.Class224
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns22;
using ns26;
using ns7;
using ns9;
using System.Collections.Generic;

namespace ns24
{
  internal abstract class Class224 : Class196
  {
    protected Class243 class243_0 = new Class243();
    protected Class243 class243_1 = new Class243();
    private static readonly Dictionary<string, Class224.Delegate5> dictionary_0 = new Dictionary<string, Class224.Delegate5>();
    public static readonly string[] string_2 = new string[5]{ "full", "summary", "none", "historical", "optimal" };
    public static readonly string[] string_3 = new string[4]{ "OPEN", "CLOSED", "PERIODIC", "CLOSURE_UNSET" };
    public const string string_0 = "null_surface";
    public const string string_1 = "nullbs";
    private Class224.Enum4 enum4_0;
    private Class242 class242_0;
    protected Class188 class188_0;
    protected Class188 class188_1;
    private Class439 class439_0;
    private Class796 class796_0;
    private double[] double_0;
    private double double_1;
    private Class439 class439_1;
    protected int int_0;
    private int int_1;
    private int int_2;

    static Class224()
    {
      Class224.dictionary_0.Add("exact_int_cur", (Class224.Delegate5) (() => (Class224) new Class229()));
      Class224.dictionary_0.Add("exactcur", (Class224.Delegate5) (() => (Class224) new Class229()));
      Class224.dictionary_0.Add("blend_int_cur", (Class224.Delegate5) (() => (Class224) new Class230()));
      Class224.dictionary_0.Add("bldcur", (Class224.Delegate5) (() => (Class224) new Class230()));
      Class224.dictionary_0.Add("off_int_cur", (Class224.Delegate5) (() => (Class224) new Class231()));
      Class224.dictionary_0.Add("offintcur", (Class224.Delegate5) (() => (Class224) new Class231()));
      Class224.dictionary_0.Add("offset_int_cur", (Class224.Delegate5) (() => (Class224) new Class228()));
      Class224.dictionary_0.Add("offsetintcur", (Class224.Delegate5) (() => (Class224) new Class228()));
      Class224.dictionary_0.Add("int_int_cur", (Class224.Delegate5) (() => (Class224) new Class233()));
      Class224.dictionary_0.Add("surfintcur", (Class224.Delegate5) (() => (Class224) new Class233()));
      Class224.dictionary_0.Add("par_int_cur", (Class224.Delegate5) (() => (Class224) new Class227()));
      Class224.dictionary_0.Add("parcur", (Class224.Delegate5) (() => (Class224) new Class227()));
      Class224.dictionary_0.Add("spring_int_cur", (Class224.Delegate5) (() => (Class224) new Class232()));
      Class224.dictionary_0.Add("blndsprngcur", (Class224.Delegate5) (() => (Class224) new Class232()));
      Class224.dictionary_0.Add("proj_int_cur", (Class224.Delegate5) (() => (Class224) new Class237()));
      Class224.dictionary_0.Add("projcur", (Class224.Delegate5) (() => (Class224) new Class237()));
      Class224.dictionary_0.Add("off_surf_int_cur", (Class224.Delegate5) (() => (Class224) new Class234()));
      Class224.dictionary_0.Add("offsurfintcur", (Class224.Delegate5) (() => (Class224) new Class234()));
      Class224.dictionary_0.Add("law_int_cur", (Class224.Delegate5) (() => (Class224) new Class225()));
      Class224.dictionary_0.Add("lawintcur", (Class224.Delegate5) (() => (Class224) new Class225()));
      Class224.dictionary_0.Add("helix_int_cur", (Class224.Delegate5) (() => (Class224) new Class236()));
      Class224.dictionary_0.Add("helixintcur", (Class224.Delegate5) (() => (Class224) new Class236()));
      Class224.dictionary_0.Add("subset_int_cur", (Class224.Delegate5) (() => (Class224) new Class235()));
      Class224.dictionary_0.Add("subsetintcur", (Class224.Delegate5) (() => (Class224) new Class235()));
      Class224.dictionary_0.Add("surf_int_cur", (Class224.Delegate5) (() => (Class224) new Class226()));
      Class224.dictionary_0.Add("surfcur", (Class224.Delegate5) (() => (Class224) new Class226()));
    }

    public override void imethod_0(Interface8 reader)
    {
      this.method_0(reader);
      this.enum4_0 = reader.FileFormatVersion < Class250.int_48 ? Class224.Enum4.const_0 : (Class224.Enum4) reader.imethod_11(Class224.string_2);
      if (this.enum4_0 == Class224.Enum4.const_0)
      {
        this.class242_0 = (Class242) new Class244();
        this.class242_0.vmethod_0(reader);
        this.double_1 = reader.imethod_8();
      }
      else if (this.enum4_0 == Class224.Enum4.const_2)
      {
        this.class439_1 = new Class439(reader);
        this.int_0 = reader.imethod_11(Class224.string_3);
      }
      else
      {
        int length = reader.imethod_5();
        this.double_0 = new double[length];
        for (int index = 0; index < length; ++index)
          this.double_0[index] = reader.imethod_8();
        this.double_1 = reader.imethod_8();
        this.int_0 = reader.imethod_11(Class224.string_3);
      }
      this.class188_0 = Class188.smethod_0(reader);
      this.class188_1 = Class188.smethod_0(reader);
      this.class243_0.vmethod_0(reader);
      this.class243_1.vmethod_0(reader);
      if (reader.FileFormatVersion >= Class250.int_23)
        this.class439_0 = new Class439(reader);
      if (reader.FileFormatVersion >= Class250.int_36)
        this.class796_0 = new Class796(reader);
      this.int_1 = 0;
      if (reader.FileFormatVersion < Class250.int_68)
        return;
      this.int_1 = reader.imethod_5();
    }

    public override void imethod_1(Interface9 writer)
    {
      this.method_1(writer);
      if (writer.FileFormatVersion >= Class250.int_48)
        writer.imethod_10(Class224.string_2, (int) this.enum4_0);
      if (this.enum4_0 == Class224.Enum4.const_0)
      {
        this.class242_0.vmethod_1(writer);
        writer.imethod_7(this.double_1);
        writer.imethod_15();
      }
      else if (this.enum4_0 == Class224.Enum4.const_2)
      {
        this.class439_1.method_0(writer);
        writer.imethod_10(Class224.string_3, this.int_0);
        writer.imethod_15();
      }
      else
      {
        int length = this.double_0.Length;
        writer.imethod_4(length);
        writer.imethod_15();
        for (int index = 0; index < length; ++index)
          writer.imethod_7(this.double_0[index]);
        writer.imethod_15();
        writer.imethod_7(this.double_1);
        writer.imethod_10(Class224.string_3, this.int_0);
        writer.imethod_15();
      }
      Class188.smethod_1(writer, this.class188_0);
      writer.imethod_15();
      Class188.smethod_1(writer, this.class188_1);
      writer.imethod_15();
      this.class243_0.vmethod_1(writer);
      writer.imethod_15();
      this.class243_1.vmethod_1(writer);
      writer.imethod_15();
      if (writer.FileFormatVersion >= Class250.int_23)
      {
        this.class439_0.method_0(writer);
        writer.imethod_15();
      }
      if (writer.FileFormatVersion >= Class250.int_36)
      {
        this.class796_0.method_1(writer);
        if (writer.FileFormatVersion >= Class250.int_68)
          writer.imethod_15();
      }
      if (writer.FileFormatVersion < Class250.int_68)
        return;
      writer.imethod_4(this.int_1);
    }

    protected virtual int vmethod_0()
    {
      return 21500;
    }

    protected Class224()
    {
      this.int_0 = 4;
      this.int_1 = 0;
    }

    protected void method_0(Interface8 reader)
    {
      if (reader.FileFormatVersion >= Class250.int_69)
        this.int_2 = reader.imethod_5();
      else
        this.int_2 = this.vmethod_0();
    }

    protected void method_1(Interface9 writer)
    {
      if (writer.FileFormatVersion < Class250.int_69)
        return;
      writer.imethod_4(this.int_2);
    }

    public Class242 Approximation
    {
      get
      {
        return this.class242_0;
      }
    }

    public static Class224 smethod_0(Interface8 reader)
    {
      reader.imethod_10();
      string key = reader.imethod_14();
      Class224 class224;
      if (key == "ref")
      {
        int index = reader.imethod_5();
        class224 = (Class224) reader.imethod_1(index);
        if (class224 == null)
          throw new Exception0("Missing subentity : " + (object) index);
      }
      else
      {
        Class224.Delegate5 delegate5;
        if (!Class224.dictionary_0.TryGetValue(key, out delegate5))
          throw new Exception0("Not supported sub curve type : " + key);
        class224 = delegate5();
        reader.imethod_2((Class196) class224);
        class224.imethod_0(reader);
      }
      reader.imethod_9();
      return class224;
    }

    public static void smethod_1(Interface9 writer, Class224 subEntity)
    {
      writer.imethod_9();
      int num = writer.imethod_3((Class196) subEntity);
      if (num == -1)
      {
        writer.imethod_2((Class196) subEntity);
        string str = subEntity.imethod_2(writer.FileFormatVersion);
        writer.imethod_13(str);
        subEntity.imethod_1(writer);
      }
      else
      {
        writer.imethod_13("ref");
        writer.imethod_4(num);
      }
      writer.imethod_8();
    }

    private delegate Class224 Delegate5();

    public enum Enum4
    {
      const_0,
      const_1,
      const_2,
      const_3,
      const_4,
    }
  }
}
