// Decompiled with JetBrains decompiler
// Type: ns6.Class916
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System;
using WW.Diagnostics;

namespace ns6
{
  internal class Class916 : IDumpable
  {
    private uint uint_1 = 1685217642;
    private int int_2 = 128;
    private int int_3 = 2;
    private int int_4 = 2;
    private int int_6 = 1;
    private uint uint_2 = 128;
    private const uint uint_0 = 1685217642;
    private const int int_0 = 128;
    private const int int_1 = 2;
    private int int_5;
    private int int_7;
    private int int_8;
    private uint uint_3;
    private uint uint_4;
    private uint uint_5;
    private uint uint_6;
    private int int_9;

    public uint FileSignature
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

    public int FileHeaderSize
    {
      get
      {
        return this.int_2;
      }
      set
      {
        this.int_2 = value;
      }
    }

    public int Unknown1
    {
      get
      {
        return this.int_3;
      }
      set
      {
        this.int_3 = value;
      }
    }

    public int Version
    {
      get
      {
        return this.int_4;
      }
      set
      {
        this.int_4 = value;
      }
    }

    public int Unknown2
    {
      get
      {
        return this.int_5;
      }
      set
      {
        this.int_5 = value;
      }
    }

    public int DataStorageRevision
    {
      get
      {
        return this.int_6;
      }
      set
      {
        this.int_6 = value;
      }
    }

    public uint SegmentIndexOffset
    {
      get
      {
        return this.uint_2;
      }
      set
      {
        this.uint_2 = value;
      }
    }

    public int SegmentIndexUnknown
    {
      get
      {
        return this.int_7;
      }
      set
      {
        this.int_7 = value;
      }
    }

    public int SegmentIndexEntryCount
    {
      get
      {
        return this.int_8;
      }
      set
      {
        this.int_8 = value;
      }
    }

    public uint SchemaIndexSegmentIndex
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

    public uint DataIndexSegmentIndex
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

    public uint SearchSegmentIndex
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

    public uint PreviousSaveIndex
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

    public int FileSize
    {
      get
      {
        return this.int_9;
      }
      set
      {
        this.int_9 = value;
      }
    }

    public void Dump(DumpWriter w)
    {
      w.WriteField("fileSignature", this.uint_1);
      w.WriteField("fileHeaderSize", this.int_2);
      w.WriteField("unknown1", this.int_3);
      w.WriteField("version", this.int_4);
      w.WriteField("unknown2", this.int_5);
      w.WriteField("dataStorageRevision", this.int_6);
      w.WriteField("segmentIndexOffset", this.uint_2);
      w.WriteField("segmentIndexUnknown", this.int_7);
      w.WriteField("segmentIndexEntryCount", this.int_8);
      w.WriteField("schemaIndexSegmentIndex", this.uint_3);
      w.WriteField("dataIndexSegmentIndex", this.uint_4);
      w.WriteField("searchSegmentIndex", this.uint_5);
      w.WriteField("previousSaveIndex", this.uint_6);
      w.WriteField("fileSize", this.int_9);
    }

    internal void Read(Class889 r)
    {
      this.uint_1 = r.vmethod_10();
      this.int_2 = r.vmethod_8();
      this.int_3 = r.vmethod_8();
      this.int_4 = r.vmethod_8();
      this.int_5 = r.vmethod_8();
      this.int_6 = r.vmethod_8();
      this.uint_2 = r.vmethod_10();
      this.int_7 = r.vmethod_8();
      this.int_8 = r.vmethod_8();
      this.uint_3 = r.vmethod_10();
      this.uint_4 = r.vmethod_10();
      this.uint_5 = r.vmethod_10();
      this.uint_6 = r.vmethod_10();
      this.int_9 = r.vmethod_8();
    }

    internal void Write(Class889 w)
    {
      w.vmethod_11(this.uint_1);
      if (this.uint_1 != 1685217642U)
        throw new Exception("Unexpected signature value " + (object) this.uint_1 + "should be " + (object) 1685217642U + ".");
      w.vmethod_9(this.int_2);
      w.vmethod_9(this.int_3);
      if (this.int_3 != 2 && this.int_3 != 3)
        throw new Exception("Unexpected value " + (object) this.int_3 + "should be 2 or 3.");
      w.vmethod_9(this.int_4);
      if (this.int_4 != 2)
        throw new Exception("Unexpected version value " + (object) this.int_4 + "should be " + (object) 2 + ".");
      w.vmethod_9(this.int_5);
      w.vmethod_9(this.int_6);
      w.vmethod_11(this.uint_2);
      w.vmethod_9(this.int_7);
      w.vmethod_9(this.int_8);
      w.vmethod_11(this.uint_3);
      w.vmethod_11(this.uint_4);
      w.vmethod_11(this.uint_5);
      w.vmethod_11(this.uint_6);
      w.vmethod_9(this.int_9);
    }
  }
}
