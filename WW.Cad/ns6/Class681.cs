// Decompiled with JetBrains decompiler
// Type: ns6.Class681
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;
using System;
using WW.Diagnostics;
using WW.Text;

namespace ns6
{
  internal class Class681 : IDumpable
  {
    private ushort ushort_0 = 54700;
    private int int_3 = 1;
    internal const int int_0 = 48;
    private byte[] byte_0;
    private uint uint_0;
    private int int_1;
    private uint uint_1;
    private int int_2;
    private int int_4;
    private int int_5;
    private int int_6;

    public Class681(string name)
    {
      this.byte_0 = Encodings.Ascii.GetBytes(name);
    }

    public ushort Signature
    {
      get
      {
        return this.ushort_0;
      }
      set
      {
        this.ushort_0 = value;
      }
    }

    public byte[] Name
    {
      get
      {
        return this.byte_0;
      }
      set
      {
        this.byte_0 = value;
      }
    }

    public uint SegmentIndex
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

    public int Unknown1
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public uint SegmentSize
    {
      get
      {
        return this.uint_1;
      }
      set
      {
        if (value % 128U != 0U)
          throw new Exception("Size is not a multiple of the alignment size.");
        this.uint_1 = value;
      }
    }

    public int Unknown2
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

    public int DataStorageRevision
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

    public int Unknown3
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

    public int SystemDataAlignmentOffset
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

    public ulong SystemDataLocalOffset
    {
      get
      {
        return (ulong) this.int_5 << 4;
      }
      set
      {
        if (((long) value & 15L) != 0L)
          throw new ArgumentException();
        this.int_5 = (int) (value >> 4);
      }
    }

    public int ObjectDataAlignmentOffset
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

    public ulong ObjectDataLocalOffset
    {
      get
      {
        return (ulong) this.int_6 << 4;
      }
      set
      {
        if (((long) value & 15L) != 0L)
          throw new ArgumentException();
        this.int_6 = (int) (value >> 4);
      }
    }

    public virtual void Dump(DumpWriter w)
    {
      w.WriteField("signature", this.ushort_0);
      w.WriteField("name", Encodings.Ascii.GetString(this.byte_0, 0, this.byte_0.Length));
      w.WriteField("segmentIndex", this.uint_0);
      w.WriteField("unknown1", this.int_1);
      w.WriteField("segmentSize", this.uint_1);
      w.WriteField("unknown2", this.int_2);
      w.WriteField("dataStorageRevision", this.int_3);
      w.WriteField("unknown3", this.int_4);
      w.WriteField("systemDataAlignmentOffset", this.int_5);
      w.WriteField("objectDataAlignmentOffset", this.int_6);
    }

    public override string ToString()
    {
      if (this.byte_0 != null)
        return Encodings.Ascii.GetString(this.byte_0, 0, this.byte_0.Length);
      return string.Empty;
    }

    internal void Read(Class741.Class742 serializer)
    {
      Class889 stream = serializer.Stream;
      this.ushort_0 = stream.vmethod_6();
      this.byte_0 = stream.vmethod_3(6);
      this.uint_0 = stream.vmethod_10();
      this.int_1 = stream.vmethod_8();
      this.uint_1 = stream.vmethod_10();
      this.int_2 = stream.vmethod_8();
      this.int_3 = stream.vmethod_8();
      this.int_4 = stream.vmethod_8();
      this.int_5 = stream.vmethod_8();
      this.int_6 = stream.vmethod_8();
      stream.vmethod_3(8);
    }

    internal void Write(Class741.Class742 serializer)
    {
      Class889 stream = serializer.Stream;
      stream.vmethod_7(this.ushort_0);
      if (this.byte_0 == null || this.byte_0.Length != 6)
        throw new Exception("Name must be 6 bytes long.");
      stream.vmethod_2(this.byte_0, 0, this.byte_0.Length);
      stream.vmethod_11(this.uint_0);
      stream.vmethod_9(this.int_1);
      stream.vmethod_11(this.uint_1);
      stream.vmethod_9(this.int_2);
      stream.vmethod_9(this.int_3);
      stream.vmethod_9(this.int_4);
      stream.vmethod_9(this.int_5);
      stream.vmethod_9(this.int_6);
      for (int index = 0; index < 8; ++index)
        stream.vmethod_1((byte) 85);
    }
  }
}
