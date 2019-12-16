// Decompiled with JetBrains decompiler
// Type: ns6.Class48
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns2;
using ns28;
using System;
using System.Collections;
using System.Collections.Generic;
using WW.Cad.IO;
using WW.Diagnostics;

namespace ns6
{
  internal class Class48 : IDumpable
  {
    private string string_0 = string.Empty;
    private readonly List<ulong> list_0 = new List<ulong>();
    private readonly List<Class360> list_1 = new List<Class360>();
    private readonly List<Class986> list_2 = new List<Class986>();
    private Enum53 enum53_0 = Enum53.const_0;
    private uint uint_0;

    public uint Index
    {
      get
      {
        return this.uint_0;
      }
      set
      {
        this.uint_0 = value;
      }
    }

    public string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value ?? string.Empty;
        switch (this.string_0)
        {
          case "AcDb3DSolid_ASM_Data":
            this.enum53_0 = Enum53.const_2;
            break;
          case "AcDb_Thumbnail_Schema":
            this.enum53_0 = Enum53.const_1;
            break;
          default:
            this.enum53_0 = Enum53.const_0;
            break;
        }
      }
    }

    public List<ulong> Indexes
    {
      get
      {
        return this.list_0;
      }
    }

    public List<Class360> PropertyDescriptors
    {
      get
      {
        return this.list_1;
      }
    }

    public List<Class986> Properties
    {
      get
      {
        return this.list_2;
      }
    }

    public Enum53 RecordType
    {
      get
      {
        return this.enum53_0;
      }
      set
      {
        this.enum53_0 = value;
      }
    }

    public void Read(Class889 r)
    {
      ushort num1 = r.vmethod_6();
      this.list_0.Capacity = (int) num1;
      for (int index = 0; index < (int) num1; ++index)
        this.list_0.Add(r.vmethod_14());
      ushort num2 = r.vmethod_6();
      this.list_2.Capacity = (int) num2;
      for (int index = 0; index < (int) num2; ++index)
      {
        Class986 class986 = new Class986();
        class986.Read(r);
        this.list_2.Add(class986);
      }
    }

    public void Write(Class889 w)
    {
      w.vmethod_7((ushort) this.list_0.Count);
      foreach (ulong num in this.list_0)
        w.vmethod_15(num);
      w.vmethod_7((ushort) this.list_2.Count);
      foreach (Class986 class986 in this.list_2)
        class986.Write(w);
    }

    public void Read(DxfReader r)
    {
      if (r.CurrentGroup.Code != 0 || r.CurrentGroup.Value as string != "ACDSSCHEMA")
        throw new Exception("Unexpected group.");
      r.method_85();
      while (r.CurrentGroup.Code != 0 && (r.CurrentGroup.Code != 2 && r.CurrentGroup != Struct18.struct18_0))
      {
        switch (r.CurrentGroup.Code)
        {
          case 1:
            this.Name = (string) r.CurrentGroup.Value;
            r.method_85();
            continue;
          case 2:
            Class986 class986 = new Class986();
            class986.Read(r);
            this.list_2.Add(class986);
            continue;
          case 90:
            this.uint_0 = (uint) (int) r.CurrentGroup.Value;
            r.method_85();
            continue;
          case 101:
            Class360 class360 = new Class360();
            class360.Read(r);
            this.list_1.Add(class360);
            continue;
          default:
            r.method_85();
            continue;
        }
      }
    }

    public void Write(DxfWriter w)
    {
      w.Write(0, (object) "ACDSSCHEMA");
      w.Write(90, (object) (int) this.uint_0);
      w.Write(1, (object) this.string_0);
      foreach (Class986 class986 in this.list_2)
        class986.Write(w);
      foreach (Class360 class360 in this.list_1)
        class360.Write(w);
    }

    public override string ToString()
    {
      return string.Format("{0}, indexes: {1}, properties: {2}", (object) this.string_0, (object) this.list_0.Count, (object) this.list_2.Count);
    }

    public void Dump(DumpWriter w)
    {
      w.WriteField("index", this.uint_0);
      w.WriteField("name", this.string_0);
      w.WriteField("indexes", (ICollection) this.list_0);
      w.WriteField("propertyDescriptors", (ICollection) this.list_1);
      w.WriteField("properties", (ICollection) this.list_2);
    }
  }
}
