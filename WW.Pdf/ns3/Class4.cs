// Decompiled with JetBrains decompiler
// Type: ns3.Class4
// Assembly: WW.Pdf, Version=4.0.37.140, Culture=neutral, PublicKeyToken=87d16b8f7b531b65
// MVID: 39BBA07C-9C80-4987-8C90-32F5A6207B92
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Pdf.dll

using ns0;
using ns2;
using System;

namespace ns3
{
  internal class Class4 : Class0
  {
    private byte[] byte_2 = new byte[10];
    private sbyte[] sbyte_0 = new sbyte[4];
    private const int int_0 = 1;
    private const int int_1 = 2;
    private const int int_2 = 3;
    private const int int_3 = 4;
    private const int int_4 = 5;
    private const int int_5 = 7;
    private const int int_6 = 8;
    private const int int_7 = 10;
    private const int int_8 = 12;
    private ushort ushort_0;
    private short short_0;
    private ushort ushort_1;
    private ushort ushort_2;
    private ushort ushort_3;
    private short short_1;
    private short short_2;
    private short short_3;
    private short short_4;
    private short short_5;
    private short short_6;
    private short short_7;
    private short short_8;
    private short short_9;
    private short short_10;
    private byte byte_0;
    private byte byte_1;
    private uint uint_0;
    private uint uint_1;
    private uint uint_2;
    private uint uint_3;
    private ushort ushort_4;
    private ushort ushort_5;
    private ushort ushort_6;
    private short short_11;
    private short short_12;
    private short short_13;
    private ushort ushort_7;
    private ushort ushort_8;
    private uint uint_4;
    private uint uint_5;
    private short short_14;
    private short short_15;
    private ushort ushort_9;
    private ushort ushort_10;
    private ushort ushort_11;

    public Class4(Class41 entry)
      : base(entry)
    {
    }

    public bool IsItalic
    {
      get
      {
        return ((int) this.ushort_4 & 1) == 1;
      }
    }

    public bool IsRegular
    {
      get
      {
        return ((int) this.ushort_4 & 64) == 64;
      }
    }

    public bool IsBold
    {
      get
      {
        if (((int) this.ushort_4 & 32) != 32)
          return this.ushort_1 >= (ushort) 700;
        return true;
      }
    }

    public bool IsMonospaced
    {
      get
      {
        return this.byte_2[3] == (byte) 9;
      }
    }

    public bool IsSymbolic
    {
      get
      {
        return this.byte_0 == (byte) 12;
      }
    }

    public bool IsSerif
    {
      get
      {
        if (this.byte_0 != (byte) 1 && this.byte_0 != (byte) 2 && (this.byte_0 != (byte) 3 && this.byte_0 != (byte) 4) && this.byte_0 != (byte) 5)
          return this.byte_0 == (byte) 7;
        return true;
      }
    }

    public bool IsScript
    {
      get
      {
        return this.byte_0 == (byte) 10;
      }
    }

    public bool IsSansSerif
    {
      get
      {
        return this.byte_0 == (byte) 8;
      }
    }

    public bool IsEmbeddable
    {
      get
      {
        if (!this.InstallableEmbedding && !this.EditableEmbedding)
          return this.PreviewAndPrintEmbedding;
        return true;
      }
    }

    public bool InstallableEmbedding
    {
      get
      {
        return this.ushort_3 == (ushort) 0;
      }
    }

    public bool RestricedLicenseEmbedding
    {
      get
      {
        return ((int) this.ushort_3 & 2) == 2;
      }
    }

    public bool EditableEmbedding
    {
      get
      {
        return ((int) this.ushort_3 & 8) == 8;
      }
    }

    public bool PreviewAndPrintEmbedding
    {
      get
      {
        return ((int) this.ushort_3 & 4) == 4;
      }
    }

    public bool IsSubsettable
    {
      get
      {
        return ((int) this.ushort_3 & 256) != 256;
      }
    }

    public int CapHeight
    {
      get
      {
        return (int) this.short_15;
      }
    }

    public int XHeight
    {
      get
      {
        return (int) this.short_14;
      }
    }

    public ushort FirstChar
    {
      get
      {
        return this.ushort_5;
      }
    }

    public ushort LastChar
    {
      get
      {
        return this.ushort_6;
      }
    }

    protected internal override void vmethod_0(Class80 reader)
    {
      Class74 stream = reader.Stream;
      this.ushort_0 = stream.method_8();
      this.short_0 = stream.method_4();
      this.ushort_1 = stream.method_8();
      this.ushort_2 = stream.method_8();
      this.ushort_3 = (ushort) ((uint) stream.method_8() & 4294967294U);
      this.short_1 = stream.method_4();
      this.short_2 = stream.method_4();
      this.short_3 = stream.method_4();
      this.short_4 = stream.method_4();
      this.short_5 = stream.method_4();
      this.short_6 = stream.method_4();
      this.short_7 = stream.method_4();
      this.short_8 = stream.method_4();
      this.short_9 = stream.method_4();
      this.short_10 = stream.method_4();
      short num = stream.method_4();
      this.byte_0 = (byte) ((uint) num >> 8);
      this.byte_1 = (byte) ((uint) num & (uint) byte.MaxValue);
      stream.method_24(this.byte_2, 0, this.byte_2.Length);
      this.uint_0 = stream.method_14();
      this.uint_1 = stream.method_14();
      this.uint_2 = stream.method_14();
      this.uint_3 = stream.method_14();
      this.sbyte_0[0] = stream.method_2();
      this.sbyte_0[1] = stream.method_2();
      this.sbyte_0[2] = stream.method_2();
      this.sbyte_0[3] = stream.method_2();
      this.ushort_4 = stream.method_8();
      this.ushort_5 = stream.method_8();
      this.ushort_6 = stream.method_8();
      this.short_11 = stream.method_4();
      this.short_12 = stream.method_4();
      this.short_13 = stream.method_4();
      this.ushort_7 = stream.method_8();
      this.ushort_8 = stream.method_8();
      this.uint_4 = stream.method_14();
      this.uint_5 = stream.method_14();
      this.short_14 = stream.method_4();
      this.short_15 = stream.method_4();
      this.ushort_9 = stream.method_8();
      this.ushort_10 = stream.method_8();
      this.ushort_11 = stream.method_8();
    }

    protected internal override void vmethod_1(Class79 writer)
    {
      throw new NotImplementedException("Write is not implemented.");
    }
  }
}
