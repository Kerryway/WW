// Decompiled with JetBrains decompiler
// Type: ns7.Class795
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns10;
using ns11;
using ns12;
using ns13;
using ns14;
using ns15;
using ns16;
using ns17;
using ns18;
using ns19;
using ns20;
using ns9;
using System.Collections.Generic;
using System.IO;
using WW.Math;

namespace ns7
{
  internal class Class795 : Interface6, Interface7
  {
    internal static readonly char char_0 = '-';
    private static readonly Dictionary<string, Class795.Delegate18> dictionary_0 = new Dictionary<string, Class795.Delegate18>();
    private IList<Class196> ilist_1 = (IList<Class196>) new List<Class196>();
    private readonly IDictionary<int, IList<Delegate10>> idictionary_0 = (IDictionary<int, IList<Delegate10>>) new Dictionary<int, IList<Delegate10>>();
    private const int int_0 = 256;
    private Class987 class987_0;
    private IList<Class80> ilist_0;
    private IList<Class98> ilist_2;
    private Class187 class187_0;
    private Class795.Enum30 enum30_0;

    private Class795(Class795.Enum30 mode)
    {
      this.enum30_0 = mode;
    }

    public void method_0(Class113 attribute)
    {
      if (attribute.NextAttribute != null)
      {
        if (attribute.PrevAttribute != null)
          attribute.PrevAttribute.NextAttribute = attribute.NextAttribute;
        else
          attribute.OwnEntity.Attribute = attribute.NextAttribute;
        attribute.NextAttribute.PrevAttribute = attribute.PrevAttribute;
      }
      else if (attribute.PrevAttribute != null)
        attribute.PrevAttribute.NextAttribute = attribute.NextAttribute;
      else
        attribute.OwnEntity.Attribute = (Class113) null;
      this.ilist_0[attribute.Index] = (Class80) null;
      for (int index = attribute.Index + 1; index < this.ilist_0.Count; ++index)
        --this.ilist_0[index].Index;
      this.ilist_0.RemoveAt(attribute.Index);
      attribute.Index = -1;
      attribute.NextAttribute = (Class113) null;
      attribute.PrevAttribute = (Class113) null;
      attribute.OwnEntity = (Class80) null;
    }

    public void ReadFrom(string content)
    {
      this.ReadFrom(Class794.smethod_3((Interface6) this, (Interface7) this, content));
    }

    public void ReadFrom(MemoryStream content)
    {
      this.ReadFrom(Class794.smethod_4((Interface6) this, (Interface7) this, content));
    }

    public void WriteTo(int version, out string content)
    {
      Interface9 writer = Class794.smethod_5((Interface6) this, (Interface7) this, version);
      this.ilist_1.Clear();
      writer.imethod_4(version);
      this.class987_0.Product = "CadLib";
      this.class987_0.NumberOfRecords = this.ilist_0.Count;
      this.class987_0.EntityCount = 0;
      foreach (Class80 class80 in (IEnumerable<Class80>) this.ilist_0)
      {
        if (class80 is Class187)
          ++this.class987_0.EntityCount;
        if (class80 is Class98)
          ++this.class987_0.EntityCount;
      }
      writer.imethod_16(this.class987_0);
      this.WriteTo(writer);
      content = writer.SAT;
    }

    public void WriteTo(MemoryStream content, int version)
    {
      Interface9 writer = Class794.smethod_6((Interface6) this, (Interface7) this, content, version);
      this.ilist_1.Clear();
      this.class987_0.Product = "CadLib";
      this.class987_0.NumberOfRecords = this.ilist_0.Count;
      this.class987_0.EntityCount = 0;
      foreach (Class80 class80 in (IEnumerable<Class80>) this.ilist_0)
      {
        if (class80 is Class187)
          ++this.class987_0.EntityCount;
        if (class80 is Class98)
          ++this.class987_0.EntityCount;
      }
      writer.imethod_16(this.class987_0);
      this.WriteTo(writer);
      if (writer.FileFormatVersion >= Class250.int_72)
        writer.imethod_13("End-of-ASM-data");
      else
        writer.imethod_13("End-of-ACIS-data");
    }

    public virtual bool vmethod_0(ref Matrix4D transform)
    {
      foreach (Class80 class80 in (IEnumerable<Class80>) this.ilist_0)
      {
        if (class80 is Class185)
        {
          Class185 class185 = (Class185) class80;
          transform = class185.Transformation;
          return true;
        }
      }
      return false;
    }

    public virtual void ApplyTransformation(Matrix4D transform)
    {
      foreach (Class80 class80 in (IEnumerable<Class80>) this.ilist_0)
      {
        if (class80 is Class98)
        {
          Class98 class98 = (Class98) class80;
          if (class98.Transform == null)
          {
            Class185 class185 = new Class185() { Transformation = transform };
            this.ilist_0.Add((Class80) class185);
            class185.Index = this.ilist_0.Count - 1;
            class98.Transform = class185;
            break;
          }
          class98.Transform.Transformation *= transform;
          break;
        }
      }
    }

    public virtual bool vmethod_1()
    {
      bool flag = false;
      int index = 0;
      while (index < this.ilist_0.Count)
      {
        Class80 class80 = this.ilist_0[index];
        if (!(class80 is Class161) && !(class80 is Class159))
        {
          ++index;
        }
        else
        {
          flag = true;
          this.method_0((Class113) class80);
        }
      }
      return flag;
    }

    public Class987 Header
    {
      get
      {
        return this.class987_0;
      }
    }

    public Class80 method_1(int index)
    {
      if (index >= 0 && index < this.ilist_0.Count)
        return this.ilist_0[index];
      return (Class80) null;
    }

    public int NumberOfEntities
    {
      get
      {
        return this.ilist_0.Count;
      }
    }

    public Class196 method_2(int index)
    {
      if (index >= 0 && index < this.ilist_1.Count)
        return this.ilist_1[index];
      return (Class196) null;
    }

    public int NumberOfSubEntities
    {
      get
      {
        return this.ilist_1.Count;
      }
    }

    public IList<Class98> Bodies
    {
      get
      {
        return this.ilist_2;
      }
    }

    public Class187 Asmheader
    {
      get
      {
        return this.class187_0;
      }
      set
      {
        this.class187_0 = value;
      }
    }

    public Class608 method_3(Class258 accuracy)
    {
      Class608 wires = new Class608(accuracy);
      foreach (Class80 class80 in (IEnumerable<Class98>) this.ilist_2)
        class80.vmethod_3(wires);
      return wires;
    }

    private void ReadFrom(Interface8 reader)
    {
      this.class987_0 = new Class987(reader);
      if (this.enum30_0 == Class795.Enum30.const_1)
        return;
      this.ilist_0 = (IList<Class80>) new List<Class80>(System.Math.Min(this.class987_0.NumberOfRecords, 256));
      this.ilist_2 = (IList<Class98>) new List<Class98>();
      this.class187_0 = (Class187) null;
      Class80 class80;
      while ((class80 = this.method_5(reader)) != null)
      {
        this.ilist_0.Add(class80);
        class80.vmethod_2(this);
        this.method_6(this.ilist_0.Count - 1);
      }
      if (this.idictionary_0.Count != 0)
        throw new Exception0("References in the SAT code couldn't be solved");
    }

    private void WriteTo(Interface9 writer)
    {
      foreach (Class80 entity in (IEnumerable<Class80>) this.ilist_0)
        this.method_4(entity, writer);
    }

    private void method_4(Class80 entity, Interface9 writer)
    {
      string str = entity.imethod_2(writer.FileFormatVersion);
      writer.imethod_13(str);
      entity.imethod_1(writer);
    }

    private Class80 method_5(Interface8 reader)
    {
      if (reader.imethod_4(this.ilist_0.Count) != this.ilist_0.Count)
        throw new Exception0("Unexpected entity index");
      string str = reader.imethod_14();
      if (str == null || "End-of-ACIS-data".Equals(str) || "End-of-ASM-data".Equals(str))
        return (Class80) null;
      Class795.Delegate18 delegate18;
      Class80 class80;
      if (!Class795.dictionary_0.TryGetValue(str, out delegate18))
      {
        string key = str;
        for (int index = key.IndexOf(Class795.char_0); index >= 0 && index + 1 < key.Length; index = key.IndexOf(Class795.char_0))
        {
          key = key.Substring(index + 1);
          if (Class795.dictionary_0.TryGetValue(key, out delegate18))
            break;
        }
        Class80 basicEntity = delegate18 != null ? delegate18() : new Class80();
        class80 = (Class80) new Class94(str, basicEntity);
      }
      else
        class80 = delegate18();
      class80.imethod_0(reader);
      class80.Index = this.ilist_0.Count;
      return class80;
    }

    private void method_6(int index)
    {
      IList<Delegate10> delegate10List;
      if (!this.idictionary_0.TryGetValue(index, out delegate10List))
        return;
      this.idictionary_0.Remove(index);
      Class80 entity = this.ilist_0[index];
      foreach (Delegate10 delegate10 in (IEnumerable<Delegate10>) delegate10List)
        delegate10(entity);
    }

    internal void method_7(Class98 body)
    {
      this.ilist_2.Add(body);
    }

    public void imethod_0(int index, Delegate10 binder)
    {
      if (index < 0)
        binder((Class80) null);
      else if (index < this.ilist_0.Count)
      {
        binder(this.ilist_0[index]);
      }
      else
      {
        IList<Delegate10> delegate10List;
        if (!this.idictionary_0.TryGetValue(index, out delegate10List))
        {
          delegate10List = (IList<Delegate10>) new List<Delegate10>();
          this.idictionary_0.Add(index, delegate10List);
        }
        delegate10List.Add(binder);
      }
    }

    public Class80 this[int index]
    {
      get
      {
        return this.method_1(index);
      }
    }

    public void imethod_2(Class196 subEntity)
    {
      this.ilist_1.Add(subEntity);
    }

    public Class196 imethod_1(int index)
    {
      return this.method_2(index);
    }

    public int imethod_3(Class196 subEntity)
    {
      for (int index = 0; index < this.NumberOfSubEntities; ++index)
      {
        if (this.method_2(index) == subEntity)
          return index;
      }
      return -1;
    }

    public static Class795 CreateFrom(string content, Class795.Enum30 mode)
    {
      Class795 class795 = new Class795(mode);
      class795.ReadFrom(content);
      return class795;
    }

    public static Class795 CreateFrom(MemoryStream content, Class795.Enum30 mode)
    {
      Class795 class795 = new Class795(mode);
      class795.ReadFrom(content);
      return class795;
    }

    static Class795()
    {
      Class795.dictionary_0.Add("attrib", (Class795.Delegate18) (() => (Class80) new Class113()));
      Class795.dictionary_0.Add("adesk-attrib", (Class795.Delegate18) (() => (Class80) new Class156()));
      Class795.dictionary_0.Add("color-adesk-attrib", (Class795.Delegate18) (() => (Class80) new Class161()));
      Class795.dictionary_0.Add("materialadesk-attrib", (Class795.Delegate18) (() => (Class80) new Class160()));
      Class795.dictionary_0.Add("materialmapper-adesk-attrib", (Class795.Delegate18) (() => (Class80) new Class158()));
      Class795.dictionary_0.Add("Spline_Data-adesk-attrib", (Class795.Delegate18) (() => (Class80) new Class157()));
      Class795.dictionary_0.Add("truecolor-adesk-attrib", (Class795.Delegate18) (() => (Class80) new Class159()));
      Class795.dictionary_0.Add("bsiattrib", (Class795.Delegate18) (() => (Class80) new Class180()));
      Class795.dictionary_0.Add("entityId-bsiattrib", (Class795.Delegate18) (() => (Class80) new Class181()));
      Class795.dictionary_0.Add("eye-attrib", (Class795.Delegate18) (() => (Class80) new Class152()));
      Class795.dictionary_0.Add("fmesh-eye-attrib", (Class795.Delegate18) (() => (Class80) new Class154()));
      Class795.dictionary_0.Add("ptlist-eye-attrib", (Class795.Delegate18) (() => (Class80) new Class155()));
      Class795.dictionary_0.Add("ref_vt-eye-attrib", (Class795.Delegate18) (() => (Class80) new Class153()));
      Class795.dictionary_0.Add("lwd-attrib", (Class795.Delegate18) (() => (Class80) new Class152()));
      Class795.dictionary_0.Add("fmesh-lwd-attrib", (Class795.Delegate18) (() => (Class80) new Class154()));
      Class795.dictionary_0.Add("ptlist-lwd-attrib", (Class795.Delegate18) (() => (Class80) new Class155()));
      Class795.dictionary_0.Add("ref_vt-lwd-attrib", (Class795.Delegate18) (() => (Class80) new Class153()));
      Class795.dictionary_0.Add("gen-attrib", (Class795.Delegate18) (() => (Class80) new ns14.Class143()));
      Class795.dictionary_0.Add("name_attrib-gen-attrib", (Class795.Delegate18) (() => (Class80) new ns14.Class144()));
      Class795.dictionary_0.Add("entity_attrib-name_attrib-gen-attrib", (Class795.Delegate18) (() => (Class80) new Class146()));
      Class795.dictionary_0.Add("integer_attrib-name_attrib-gen-attrib", (Class795.Delegate18) (() => (Class80) new Class148()));
      Class795.dictionary_0.Add("pointer_attrib-name_attrib-gen-attrib", (Class795.Delegate18) (() => (Class80) new Class147()));
      Class795.dictionary_0.Add("position_attrib-name_attrib-gen-attrib", (Class795.Delegate18) (() => (Class80) new Class150()));
      Class795.dictionary_0.Add("real_attrib-name_attrib-gen-attrib", (Class795.Delegate18) (() => (Class80) new Class149()));
      Class795.dictionary_0.Add("string_attrib-name_attrib-gen-attrib", (Class795.Delegate18) (() => (Class80) new Class151()));
      Class795.dictionary_0.Add("vector_attrib-name_attrib-gen-attrib", (Class795.Delegate18) (() => (Class80) new Class145()));
      Class795.dictionary_0.Add("aggregate_advspl_attribute-aggregate_geombuild_base_attribute-aggregate_body_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class139()));
      Class795.dictionary_0.Add("aggregate_analytic_solver_attribute-aggregate_geombuild_base_attribute-aggregate_body_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class137()));
      Class795.dictionary_0.Add("aggregate_body_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class133()));
      Class795.dictionary_0.Add("aggregate_geombuild_attribute-aggregate_geombuild_base_attribute-aggregate_body_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class140()));
      Class795.dictionary_0.Add("aggregate_geombuild_base_attribute-aggregate_body_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class134()));
      Class795.dictionary_0.Add("aggregate_isospline_attribute-aggregate_geombuild_base_attribute-aggregate_body_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class138()));
      Class795.dictionary_0.Add("aggregate_secndry_attribute-aggregate_geombuild_base_attribute-aggregate_body_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class135()));
      Class795.dictionary_0.Add("aggregate_sharped_attribute-aggregate_geombuild_base_attribute-aggregate_body_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class136()));
      Class795.dictionary_0.Add("aggregate_simgeom_attribute-aggregate_simgeom_base_attributeattrib", (Class795.Delegate18) (() => (Class80) new Class179()));
      Class795.dictionary_0.Add("aggregate_simgeom_base_attributeattrib", (Class795.Delegate18) (() => (Class80) new Class178()));
      Class795.dictionary_0.Add("aggregate_stitch_attribute-aggregate_stitch_base_attribute-aggregate_body_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class142()));
      Class795.dictionary_0.Add("aggregate_stitch_base_attribute-aggregate_body_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class141()));
      Class795.dictionary_0.Add("attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new Class116()));
      Class795.dictionary_0.Add("attrib_hh_coedge_geombuild-attrib_entity_geombuild-individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class126()));
      Class795.dictionary_0.Add("attrib_hh_curve_geombuild-attrib_entity_geombuild-individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class128()));
      Class795.dictionary_0.Add("attrib_hh_edge_geombuild-attrib_entity_geombuild-individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new Class123()));
      Class795.dictionary_0.Add("attrib_entity_geombuild-individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new Class120()));
      Class795.dictionary_0.Add("attrib_hh_face_geombuild-attrib_entity_geombuild-individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class130()));
      Class795.dictionary_0.Add("individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new Class117()));
      Class795.dictionary_0.Add("individual_simgeom_attribute-simgeom_base_entity_attribute-individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new Class119()));
      Class795.dictionary_0.Add("individual_stitch_attribute-stitch_base_entity_attribute-individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class132()));
      Class795.dictionary_0.Add("attrib_hh_loop_geombuild-attrib_entity_geombuild-individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class125()));
      Class795.dictionary_0.Add("attrib_hh_lump_geombuild-attrib_entity_geombuild-individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new Class122()));
      Class795.dictionary_0.Add("attrib_hh_pcurve_geombuild-attrib_entity_geombuild-individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class127()));
      Class795.dictionary_0.Add("attrib_hh_shell_geombuild-attrib_entity_geombuild-individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new Class121()));
      Class795.dictionary_0.Add("simgeom_base_entity_attribute-individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new Class118()));
      Class795.dictionary_0.Add("stitch_base_entity_attribute-individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class131()));
      Class795.dictionary_0.Add("attrib_hh_surface_geombuild-attrib_entity_geombuild-individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class124()));
      Class795.dictionary_0.Add("attrib_hh_vertex_geombuild-attrib_entity_geombuild-individual_entity_attribute-attrib_HH-attrib", (Class795.Delegate18) (() => (Class80) new ns13.Class129()));
      Class795.dictionary_0.Add("rbase-attrib", (Class795.Delegate18) (() => (Class80) new Class114()));
      Class795.dictionary_0.Add("render-rbase-attrib", (Class795.Delegate18) (() => (Class80) new Class115()));
      Class795.dictionary_0.Add("st-attrib", (Class795.Delegate18) (() => (Class80) new Class172()));
      Class795.dictionary_0.Add("display_attribute-st-attrib", (Class795.Delegate18) (() => (Class80) new Class177()));
      Class795.dictionary_0.Add("id_attribute-st-attrib", (Class795.Delegate18) (() => (Class80) new Class176()));
      Class795.dictionary_0.Add("named_attribute-st-attrib", (Class795.Delegate18) (() => (Class80) new Class173()));
      Class795.dictionary_0.Add("ole_attribute-st-attrib", (Class795.Delegate18) (() => (Class80) new Class174()));
      Class795.dictionary_0.Add("rgb_color-st-attrib", (Class795.Delegate18) (() => (Class80) new Class175()));
      Class795.dictionary_0.Add("sys-attrib", (Class795.Delegate18) (() => (Class80) new Class162()));
      Class795.dictionary_0.Add("blend-sys-attrib", (Class795.Delegate18) (() => (Class80) new Class163()));
      Class795.dictionary_0.Add("ffblend-blend-sys-attrib", (Class795.Delegate18) (() => (Class80) new Class164()));
      Class795.dictionary_0.Add("const_blend-ffblend-blend-sys-attrib", (Class795.Delegate18) (() => (Class80) new Class167()));
      Class795.dictionary_0.Add("const_round-const_round-ffblend-blend-sys-attrib", (Class795.Delegate18) (() => (Class80) new Class166()));
      Class795.dictionary_0.Add("const_chamfer-ffblend-blend-sys-attrib", (Class795.Delegate18) (() => (Class80) new Class168()));
      Class795.dictionary_0.Add("const_round-ffblend-blend-sys-attrib", (Class795.Delegate18) (() => (Class80) new Class165()));
      Class795.dictionary_0.Add("vblend-blend-sys-attrib", (Class795.Delegate18) (() => (Class80) new Class169()));
      Class795.dictionary_0.Add("tag-sys-attrib", (Class795.Delegate18) (() => (Class80) new Class170()));
      Class795.dictionary_0.Add("vertedge-sys-attrib", (Class795.Delegate18) (() => (Class80) new Class171()));
      Class795.dictionary_0.Add("tsl-attrib", (Class795.Delegate18) (() => (Class80) new Class182()));
      Class795.dictionary_0.Add("colour-tsl-attrib", (Class795.Delegate18) (() => (Class80) new ns20.Class183()));
      Class795.dictionary_0.Add("rh_background-rh_entity", (Class795.Delegate18) (() => (Class80) new Class111()));
      Class795.dictionary_0.Add("rh_light-rh_entity", (Class795.Delegate18) (() => (Class80) new Class110()));
      Class795.dictionary_0.Add("rh_material-rh_entity", (Class795.Delegate18) (() => (Class80) new Class112()));
      Class795.dictionary_0.Add("sphere-surface", (Class795.Delegate18) (() => (Class80) new Class87()));
      Class795.dictionary_0.Add("cone-surface", (Class795.Delegate18) (() => (Class80) new Class86()));
      Class795.dictionary_0.Add("spline-surface", (Class795.Delegate18) (() => (Class80) new Class85()));
      Class795.dictionary_0.Add("torus-surface", (Class795.Delegate18) (() => (Class80) new Class84()));
      Class795.dictionary_0.Add("plane-surface", (Class795.Delegate18) (() => (Class80) new Class83()));
      Class795.dictionary_0.Add("eye_refinement", (Class795.Delegate18) (() => (Class80) new Class184()));
      Class795.dictionary_0.Add("refinement", (Class795.Delegate18) (() => (Class80) new Class184()));
      Class795.dictionary_0.Add("asmheader", (Class795.Delegate18) (() => (Class80) new Class187()));
      Class795.dictionary_0.Add("body", (Class795.Delegate18) (() => (Class80) new Class98()));
      Class795.dictionary_0.Add("coedge", (Class795.Delegate18) (() => (Class80) new Class107()));
      Class795.dictionary_0.Add("curve", (Class795.Delegate18) (() => (Class80) new Class88()));
      Class795.dictionary_0.Add("edge", (Class795.Delegate18) (() => (Class80) new Class96()));
      Class795.dictionary_0.Add("ellipse-curve", (Class795.Delegate18) (() => (Class80) new Class91()));
      Class795.dictionary_0.Add("face", (Class795.Delegate18) (() => (Class80) new Class101()));
      Class795.dictionary_0.Add("intcurve-curve", (Class795.Delegate18) (() => (Class80) new Class90()));
      Class795.dictionary_0.Add("loop", (Class795.Delegate18) (() => (Class80) new Class95()));
      Class795.dictionary_0.Add("lump", (Class795.Delegate18) (() => (Class80) new Class100()));
      Class795.dictionary_0.Add("pcurve", (Class795.Delegate18) (() => (Class80) new Class99()));
      Class795.dictionary_0.Add("point", (Class795.Delegate18) (() => (Class80) new Class105()));
      Class795.dictionary_0.Add("shell", (Class795.Delegate18) (() => (Class80) new Class93()));
      Class795.dictionary_0.Add("straight-curve", (Class795.Delegate18) (() => (Class80) new Class89()));
      Class795.dictionary_0.Add("degenerate_curve-curve", (Class795.Delegate18) (() => (Class80) new Class92()));
      Class795.dictionary_0.Add("subshell", (Class795.Delegate18) (() => (Class80) new Class104()));
      Class795.dictionary_0.Add("transform", (Class795.Delegate18) (() => (Class80) new Class185()));
      Class795.dictionary_0.Add("vertex", (Class795.Delegate18) (() => (Class80) new Class102()));
      Class795.dictionary_0.Add("wire", (Class795.Delegate18) (() => (Class80) new Class106()));
      Class795.dictionary_0.Add("tvertex-vertex", (Class795.Delegate18) (() => (Class80) new Class103()));
      Class795.dictionary_0.Add("tedge-edge", (Class795.Delegate18) (() => (Class80) new Class97()));
      Class795.dictionary_0.Add("tcoedge-coedge", (Class795.Delegate18) (() => (Class80) new Class108()));
      Class795.dictionary_0.Add("vertex_template", (Class795.Delegate18) (() => (Class80) new Class186()));
    }

    public enum Enum30 : byte
    {
      const_0,
      const_1,
    }

    private delegate Class80 Delegate18();
  }
}
