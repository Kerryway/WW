// Decompiled with JetBrains decompiler
// Type: ns6.Class986
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
  internal class Class986 : IDumpable
  {
    private static readonly uint[] uint_7 = new uint[16]{ 0U, 0U, 2U, 1U, 2U, 4U, 8U, 1U, 2U, 4U, 8U, 4U, 8U, 0U, 0U, 0U };
    private readonly List<byte[]> list_0 = new List<byte[]>();
    private string string_0 = string.Empty;
    public const uint uint_0 = 14;
    private Enum52 enum52_0;
    private uint uint_1;
    private uint uint_2;
    private uint uint_3;
    private uint uint_4;
    private uint uint_5;
    private uint uint_6;

    public Enum52 Flags
    {
      get
      {
        return this.enum52_0;
      }
      set
      {
        this.enum52_0 = value;
      }
    }

    public uint NameIndex
    {
      get
      {
        return this.uint_1;
      }
      set
      {
        this.uint_1 = value;
      }
    }

    public uint Type
    {
      get
      {
        return this.uint_2;
      }
      set
      {
        this.uint_2 = value;
        if (this.uint_2 == 14U)
          return;
        this.uint_4 = Class986.uint_7[(IntPtr) value];
      }
    }

    public uint CustomTypeSize
    {
      get
      {
        return this.uint_3;
      }
      set
      {
        this.uint_3 = value;
      }
    }

    public uint TypeSize
    {
      get
      {
        return this.uint_4;
      }
      set
      {
        this.uint_4 = value;
      }
    }

    public uint Unknown1
    {
      get
      {
        return this.uint_5;
      }
      set
      {
        this.uint_5 = value;
      }
    }

    public uint Unknown2
    {
      get
      {
        return this.uint_6;
      }
      set
      {
        this.uint_6 = value;
      }
    }

    public List<byte[]> PropertyValues
    {
      get
      {
        return this.list_0;
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
      }
    }

    public override string ToString()
    {
      return string.Format("{0}, type: {1}, value count: {2}", (object) this.string_0, (object) this.uint_2, (object) this.list_0.Count);
    }

    internal void Read(Class889 r)
    {
      this.enum52_0 = (Enum52) r.vmethod_8();
      this.uint_1 = r.vmethod_10();
      if ((this.enum52_0 & Enum52.flag_2) == Enum52.flag_0)
      {
        this.uint_2 = r.vmethod_10();
        if (this.uint_2 == 14U)
        {
          this.uint_3 = r.vmethod_10();
          this.uint_4 = this.uint_3;
        }
        else
          this.uint_4 = Class986.uint_7[(IntPtr) this.uint_2];
      }
      if (this.enum52_0 == Enum52.flag_1)
        this.uint_5 = r.vmethod_10();
      else if (this.enum52_0 == Enum52.flag_3)
        this.uint_6 = r.vmethod_10();
      ushort num = r.vmethod_6();
      if (this.uint_4 == 0U)
      {
        if (this.uint_2 != 1U && this.uint_2 != 13U && this.uint_2 != 15U)
          throw new Exception("Unexpected type.");
      }
      else
      {
        this.list_0.Capacity = (int) num;
        for (int index = 0; index < (int) num; ++index)
          this.list_0.Add(r.vmethod_3((int) this.uint_4));
      }
    }

    internal void Write(Class889 w)
    {
      w.vmethod_9((int) this.enum52_0);
      if (this.uint_1 == uint.MaxValue)
        throw new Exception("Uninitialized nameIndex.");
      w.vmethod_11(this.uint_1);
      if ((this.enum52_0 & Enum52.flag_2) == Enum52.flag_0)
      {
        w.vmethod_11(this.uint_2);
        if (this.uint_2 == 14U)
          w.vmethod_11(this.uint_3);
      }
      if (this.enum52_0 == Enum52.flag_1)
        w.vmethod_11(this.uint_5);
      else if (this.enum52_0 == Enum52.flag_3)
        w.vmethod_11(this.uint_6);
      w.vmethod_7((ushort) this.list_0.Count);
      foreach (byte[] numArray in this.list_0)
        w.vmethod_2(numArray, 0, (int) this.uint_4);
    }

    public void Read(DxfReader r)
    {
      if (r.CurrentGroup.Code != 2)
        throw new Exception();
      this.string_0 = (string) r.CurrentGroup.Value;
      r.method_85();
      while (r.CurrentGroup.Code != 0 && (r.CurrentGroup.Code != 2 && (r.CurrentGroup.Code != 101 && r.CurrentGroup != Struct18.struct18_0)))
      {
        switch (r.CurrentGroup.Code)
        {
          case 91:
            this.enum52_0 = (Enum52) r.CurrentGroup.Value;
            break;
          case 280:
            this.uint_2 = (uint) (byte) r.CurrentGroup.Value;
            break;
        }
        r.method_85();
      }
    }

    public void Write(DxfWriter w)
    {
      w.Write(2, (object) this.string_0);
      w.Write(280, (object) (byte) this.uint_2);
      w.Write(91, (object) (int) this.enum52_0);
    }

    public void Dump(DumpWriter w)
    {
      w.WriteField("flags", (int) this.enum52_0);
      w.WriteField("nameIndex", this.uint_1);
      w.WriteField("type", this.uint_2);
      w.WriteField("customTypeSize", this.uint_3);
      w.WriteField("typeSize", this.uint_4);
      w.WriteField("unknown1", this.uint_5);
      w.WriteField("unknown2", this.uint_6);
      w.WriteField("propertyValues", (ICollection) this.list_0);
      w.WriteField("name", this.string_0);
    }
  }
}
