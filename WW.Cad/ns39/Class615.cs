// Decompiled with JetBrains decompiler
// Type: ns39.Class615
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace ns39
{
  internal class Class615 : Class614
  {
    private int int_4 = 2;
    private int int_1;
    private int int_2;
    private int int_3;
    private uint uint_0;

    public Class615(int sectionPageType)
    {
      this.int_1 = sectionPageType;
    }

    public int SectionPageType
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

    public int DecompressedSize
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

    public int CompressedSize
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

    public int CompressionType
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

    public uint Checksum
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
  }
}
