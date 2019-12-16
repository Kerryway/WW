// Decompiled with JetBrains decompiler
// Type: ns23.Class197
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns21;
using ns22;
using ns7;
using ns9;
using System.Collections.Generic;

namespace ns23
{
  internal abstract class Class197 : Class196
  {
    private static readonly Dictionary<string, Class197.Delegate4> dictionary_0 = new Dictionary<string, Class197.Delegate4>();
    public static readonly string[] string_0 = new string[5]{ "full", "summary", "none", "historical", "optimal" };
    public static readonly string[] string_1 = new string[4]{ "OPEN", "CLOSED", "PERIODIC", "CLOSURE_UNSET" };
    public static readonly string[] string_2 = new string[5]{ "NON_SINGULAR", "SINGULAR_LOW", "SINGULAR_HIGH", "SINGULAR_BOTH", "SINGULARITY_UNKNOWN" };
    private Class197.Enum3 enum3_0;
    private Class988 class988_0;
    protected Class796 class796_0;
    protected Class796 class796_1;
    private double double_0;
    protected Class439 class439_0;
    protected Class439 class439_1;
    protected int int_0;
    protected int int_1;
    private double[] double_1;
    private double[] double_2;
    protected int int_2;
    protected int int_3;
    private int int_4;
    private Class686.Class688 class688_0;

    static Class197()
    {
      Class197.dictionary_0.Add("exact_spl_sur", (Class197.Delegate4) (() => (Class197) new Class211()));
      Class197.dictionary_0.Add("exactsur", (Class197.Delegate4) (() => (Class197) new Class211()));
      Class197.dictionary_0.Add("sweep_spl_sur", (Class197.Delegate4) (() => (Class197) new Class216()));
      Class197.dictionary_0.Add("sweepsur", (Class197.Delegate4) (() => (Class197) new Class216()));
      Class197.dictionary_0.Add("sweep_sur", (Class197.Delegate4) (() => (Class197) new Class223()));
      Class197.dictionary_0.Add("rot_spl_sur", (Class197.Delegate4) (() => (Class197) new Class221()));
      Class197.dictionary_0.Add("rotsur", (Class197.Delegate4) (() => (Class197) new Class221()));
      Class197.dictionary_0.Add("sum_spl_sur", (Class197.Delegate4) (() => (Class197) new Class209()));
      Class197.dictionary_0.Add("sumsur", (Class197.Delegate4) (() => (Class197) new Class209()));
      Class197.dictionary_0.Add("rb_blend_spl_sur", (Class197.Delegate4) (() => (Class197) new Class203()));
      Class197.dictionary_0.Add("rbblnsur", (Class197.Delegate4) (() => (Class197) new Class203()));
      Class197.dictionary_0.Add("off_spl_sur", (Class197.Delegate4) (() => (Class197) new Class219()));
      Class197.dictionary_0.Add("offsur", (Class197.Delegate4) (() => (Class197) new Class219()));
      Class197.dictionary_0.Add("loft_spl_sur", (Class197.Delegate4) (() => (Class197) new Class217()));
      Class197.dictionary_0.Add("cl_loft_spl_sur", (Class197.Delegate4) (() => (Class197) new Class199()));
      Class197.dictionary_0.Add("net_spl_sur", (Class197.Delegate4) (() => (Class197) new Class222()));
      Class197.dictionary_0.Add("netsur", (Class197.Delegate4) (() => (Class197) new Class222()));
      Class197.dictionary_0.Add("skin_spl_sur", (Class197.Delegate4) (() => (Class197) new Class213()));
      Class197.dictionary_0.Add("skinsur", (Class197.Delegate4) (() => (Class197) new Class213()));
      Class197.dictionary_0.Add("law_spl_sur", (Class197.Delegate4) (() => (Class197) new Class198()));
      Class197.dictionary_0.Add("lawsur", (Class197.Delegate4) (() => (Class197) new Class198()));
      Class197.dictionary_0.Add("helix_spl_line", (Class197.Delegate4) (() => (Class197) new Class220()));
      Class197.dictionary_0.Add("sub_spl_sur", (Class197.Delegate4) (() => (Class197) new Class218()));
      Class197.dictionary_0.Add("subsur", (Class197.Delegate4) (() => (Class197) new Class218()));
      Class197.dictionary_0.Add("tubesur", (Class197.Delegate4) (() => (Class197) new Class214()));
      Class197.dictionary_0.Add("pipe_spl_sur", (Class197.Delegate4) (() => (Class197) new Class215()));
      Class197.dictionary_0.Add("pipesur", (Class197.Delegate4) (() => (Class197) new Class215()));
      Class197.dictionary_0.Add("VBL_SURF", (Class197.Delegate4) (() => (Class197) new Class212()));
      Class197.dictionary_0.Add("vertexblendsur", (Class197.Delegate4) (() => (Class197) new Class212()));
      Class197.dictionary_0.Add("varblendsplsur", (Class197.Delegate4) (() => (Class197) new Class201()));
      Class197.dictionary_0.Add("srf_srf_v_bl_spl_sur", (Class197.Delegate4) (() => (Class197) new Class202()));
      Class197.dictionary_0.Add("srfsrfblndsur", (Class197.Delegate4) (() => (Class197) new Class202()));
      Class197.dictionary_0.Add("tapersur", (Class197.Delegate4) (() => (Class197) new Class208()));
      Class197.dictionary_0.Add("orthosur", (Class197.Delegate4) (() => (Class197) new Class208()));
      Class197.dictionary_0.Add("ortho_spl_sur", (Class197.Delegate4) (() => (Class197) new Class208()));
      Class197.dictionary_0.Add("ruledtapersur", (Class197.Delegate4) (() => (Class197) new Class207()));
      Class197.dictionary_0.Add("swepttapersur", (Class197.Delegate4) (() => (Class197) new Class206()));
      Class197.dictionary_0.Add("ruled_tpr_spl_sur", (Class197.Delegate4) (() => (Class197) new Class207()));
      Class197.dictionary_0.Add("swept_tpr_spl_sur", (Class197.Delegate4) (() => (Class197) new Class206()));
      Class197.dictionary_0.Add("cyl_spl_sur", (Class197.Delegate4) (() => (Class197) new Class210()));
      Class197.dictionary_0.Add("cylsur", (Class197.Delegate4) (() => (Class197) new Class210()));
    }

    public static Class197 smethod_0(Interface8 reader)
    {
      reader.imethod_10();
      string key = reader.imethod_14();
      Class197 class197;
      if (key == "ref")
      {
        int index = reader.imethod_5();
        class197 = (Class197) reader.imethod_1(index);
        if (class197 == null)
          throw new Exception0("Missing subentity : " + (object) index);
      }
      else
      {
        Class197.Delegate4 delegate4;
        if (!Class197.dictionary_0.TryGetValue(key, out delegate4))
          throw new Exception0("Not supported sub spline surface primitive type : " + key);
        class197 = delegate4();
        reader.imethod_2((Class196) class197);
        class197.method_2(reader);
        class197.imethod_0(reader);
        class197.vmethod_1(reader);
      }
      reader.imethod_9();
      return class197;
    }

    public static void smethod_1(Interface9 writer, Class197 subEntity)
    {
      writer.imethod_9();
      int num = writer.imethod_3((Class196) subEntity);
      if (num == -1)
      {
        writer.imethod_2((Class196) subEntity);
        string str = subEntity.imethod_2(writer.FileFormatVersion);
        writer.imethod_13(str);
        subEntity.vmethod_2(writer);
        subEntity.imethod_1(writer);
        subEntity.vmethod_3(writer);
      }
      else
      {
        writer.imethod_13("ref");
        writer.imethod_4(num);
      }
      writer.imethod_8();
    }

    public override void imethod_0(Interface8 reader)
    {
      this.method_0(reader);
    }

    public override void imethod_1(Interface9 writer)
    {
      this.method_1(writer);
    }

    protected virtual int vmethod_0(Interface8 reader)
    {
      throw new Exception0("Uninitialized entity data default version");
    }

    protected void method_0(Interface8 reader)
    {
      this.enum3_0 = reader.FileFormatVersion < Class250.int_48 ? Class197.Enum3.const_0 : (Class197.Enum3) reader.imethod_11(Class197.string_0);
      if (this.enum3_0 == Class197.Enum3.const_0)
      {
        this.class988_0 = new Class988();
        this.class988_0.imethod_0(reader);
        this.double_0 = reader.FileFormatVersion < Class250.int_6 ? 0.0 : reader.imethod_8();
      }
      else if (this.enum3_0 == Class197.Enum3.const_1)
      {
        int length1 = reader.imethod_5();
        this.double_1 = new double[length1];
        for (int index = 0; index < length1; ++index)
          this.double_1[index] = reader.imethod_8();
        int length2 = reader.imethod_5();
        this.double_2 = new double[length2];
        for (int index = 0; index < length2; ++index)
          this.double_2[index] = reader.imethod_8();
        this.double_0 = reader.imethod_8();
        this.int_0 = reader.imethod_11(Class197.string_1);
        this.int_1 = reader.imethod_11(Class197.string_1);
        this.int_2 = reader.imethod_11(Class197.string_2);
        this.int_3 = reader.imethod_11(Class197.string_2);
      }
      else if (this.enum3_0 == Class197.Enum3.const_2)
      {
        this.class439_0 = new Class439(reader);
        this.class439_1 = new Class439(reader);
        this.int_0 = reader.imethod_11(Class197.string_1);
        this.int_1 = reader.imethod_11(Class197.string_1);
        this.int_2 = reader.imethod_11(Class197.string_2);
        this.int_3 = reader.imethod_11(Class197.string_2);
      }
      if (reader.FileFormatVersion < Class250.int_36)
        return;
      this.class796_0 = new Class796(reader);
      this.class796_1 = new Class796(reader);
    }

    protected void method_1(Interface9 writer)
    {
      if (writer.FileFormatVersion >= Class250.int_48)
        writer.imethod_10(Class197.string_0, (int) this.enum3_0);
      if (this.enum3_0 == Class197.Enum3.const_0)
      {
        this.class988_0.imethod_1(writer);
        if (writer.FileFormatVersion >= Class250.int_6)
          writer.imethod_7(this.double_0);
        writer.imethod_15();
      }
      else if (this.enum3_0 == Class197.Enum3.const_1)
      {
        int length1 = this.double_1.Length;
        writer.imethod_4(length1);
        for (int index = 0; index < length1; ++index)
          writer.imethod_7(this.double_1[index]);
        int length2 = this.double_2.Length;
        writer.imethod_4(length2);
        for (int index = 0; index < length2; ++index)
          writer.imethod_7(this.double_2[index]);
        writer.imethod_7(this.double_0);
        writer.imethod_10(Class197.string_1, this.int_0);
        writer.imethod_10(Class197.string_1, this.int_1);
        writer.imethod_10(Class197.string_2, this.int_2);
        writer.imethod_10(Class197.string_2, this.int_3);
        writer.imethod_15();
      }
      else if (this.enum3_0 == Class197.Enum3.const_2)
      {
        this.class439_0.method_0(writer);
        this.class439_1.method_0(writer);
        writer.imethod_10(Class197.string_1, this.int_0);
        writer.imethod_10(Class197.string_1, this.int_1);
        writer.imethod_10(Class197.string_2, this.int_2);
        writer.imethod_10(Class197.string_2, this.int_3);
        writer.imethod_15();
      }
      if (writer.FileFormatVersion < Class250.int_36)
        return;
      this.class796_0.method_1(writer);
      this.class796_1.method_1(writer);
    }

    public void method_2(Interface8 reader)
    {
      if (reader.FileFormatVersion >= Class250.int_68)
        this.int_4 = reader.imethod_5();
      else
        this.int_4 = this.vmethod_0(reader);
    }

    public virtual void vmethod_1(Interface8 reader)
    {
      if (reader.FileFormatVersion < Class250.int_69)
        return;
      this.class688_0 = new Class686.Class688(reader);
    }

    public virtual void vmethod_2(Interface9 writer)
    {
      if (writer.FileFormatVersion < Class250.int_68)
        return;
      writer.imethod_4(this.int_4);
    }

    public virtual void vmethod_3(Interface9 writer)
    {
      if (writer.FileFormatVersion < Class250.int_69)
        return;
      writer.imethod_12((Interface39) this.class688_0);
    }

    private delegate Class197 Delegate4();

    public enum Enum3
    {
      const_0,
      const_1,
      const_2,
      const_3,
      const_4,
    }
  }
}
