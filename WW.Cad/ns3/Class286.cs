// Decompiled with JetBrains decompiler
// Type: ns3.Class286
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Model.Entities;

namespace ns3
{
  internal class Class286 : Class285
  {
    private short short_1;
    private short short_2;
    private short short_3;
    private short short_4;

    public Class286(DxfMeshFace face)
      : base((DxfEntity) face)
    {
    }

    public short Vertex0Index
    {
      get
      {
        return this.short_1;
      }
      set
      {
        this.short_1 = value;
      }
    }

    public short Vertex1Index
    {
      get
      {
        return this.short_2;
      }
      set
      {
        this.short_2 = value;
      }
    }

    public short Vertex2Index
    {
      get
      {
        return this.short_3;
      }
      set
      {
        this.short_3 = value;
      }
    }

    public short Vertex3Index
    {
      get
      {
        return this.short_4;
      }
      set
      {
        this.short_4 = value;
      }
    }
  }
}
