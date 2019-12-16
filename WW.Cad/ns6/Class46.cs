// Decompiled with JetBrains decompiler
// Type: ns6.Class46
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System;
using System.Collections;
using System.Collections.Generic;
using WW.Diagnostics;

namespace ns6
{
  internal class Class46 : IDumpable
  {
    private readonly List<ulong> list_0 = new List<ulong>();
    private uint uint_0;
    private Class46.Class47[][] class47_0;

    public uint SchemaNameIndex
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

    public List<ulong> SortedIndexes
    {
      get
      {
        return this.list_0;
      }
    }

    public Class46.Class47[][] IdIndexesSet
    {
      get
      {
        return this.class47_0;
      }
      set
      {
        this.class47_0 = value;
      }
    }

    internal void Read(Class889 r)
    {
      this.uint_0 = r.vmethod_10();
      ulong num1 = r.vmethod_14();
      this.list_0.Capacity = (int) num1;
      for (ulong index = 0; index < num1; ++index)
        this.list_0.Add(r.vmethod_14());
      uint num2 = r.vmethod_10();
      if (num2 <= 0U)
        return;
      int num3 = (int) r.vmethod_10();
      this.class47_0 = new Class46.Class47[(IntPtr) num2][];
      for (int index1 = 0; (long) index1 < (long) num2; ++index1)
      {
        uint num4 = r.vmethod_10();
        this.class47_0[index1] = new Class46.Class47[(IntPtr) num4];
        for (int index2 = 0; (long) index2 < (long) num4; ++index2)
        {
          Class46.Class47 class47 = new Class46.Class47();
          class47.Read(r);
          this.class47_0[index1][index2] = class47;
        }
      }
    }

    internal void Write(Class889 w)
    {
      w.vmethod_11(this.uint_0);
      w.vmethod_15((ulong) this.list_0.Count);
      foreach (ulong num in this.list_0)
        w.vmethod_15(num);
      w.vmethod_11((uint) this.class47_0.Length);
      if (this.class47_0.Length <= 0)
        return;
      w.vmethod_11(0U);
      foreach (Class46.Class47[] class47Array in this.class47_0)
      {
        w.vmethod_11((uint) class47Array.Length);
        foreach (Class46.Class47 class47 in class47Array)
          class47.Write(w);
      }
    }

    public void Dump(DumpWriter w)
    {
      w.WriteField("schemaNameIndex", this.uint_0);
      w.WriteField("sortedIndexes", (ICollection) this.list_0);
      w.WriteLine("idIndexesSet {");
      foreach (Class46.Class47[] class47Array in this.class47_0)
      {
        w.WriteLine("item[] {");
        foreach (Class46.Class47 class47 in class47Array)
          w.WriteField("item", (IDumpable) class47);
        w.WriteLine("}");
      }
      w.WriteLine("}");
    }

    public class Class47 : IDumpable
    {
      private readonly List<ulong> list_0 = new List<ulong>();
      private ulong ulong_0;

      public ulong Handle
      {
        get
        {
          return this.ulong_0;
        }
        set
        {
          this.ulong_0 = value;
        }
      }

      public List<ulong> Indexes
      {
        get
        {
          return this.list_0;
        }
      }

      internal void Read(Class889 r)
      {
        this.ulong_0 = r.vmethod_14();
        ulong num = r.vmethod_14();
        for (ulong index = 0; index < num; ++index)
          this.list_0.Add(r.vmethod_14());
      }

      internal void Write(Class889 w)
      {
        w.vmethod_15(this.ulong_0);
        w.vmethod_15((ulong) this.list_0.Count);
        foreach (ulong num in this.list_0)
          w.vmethod_15(num);
      }

      public void Dump(DumpWriter w)
      {
        w.WriteField("handle", this.ulong_0);
        w.WriteField("indexes", (ICollection) this.list_0);
      }
    }
  }
}
