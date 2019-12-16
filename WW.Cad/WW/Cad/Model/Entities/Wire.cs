// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.Wire
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;

namespace WW.Cad.Model.Entities
{
  public class Wire
  {
    private List<WW.Math.Point3D> list_0 = new List<WW.Math.Point3D>();
    private byte byte_0;
    private int int_0;
    private EntityColor entityColor_0;
    private int int_1;
    private WireTransform wireTransform_0;

    public byte Type
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

    public int SelectionMarker
    {
      get
      {
        return this.int_0;
      }
      set
      {
        this.int_0 = value;
      }
    }

    public EntityColor Color
    {
      get
      {
        return this.entityColor_0;
      }
      set
      {
        this.entityColor_0 = value;
      }
    }

    public int AcisIndex
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

    public List<WW.Math.Point3D> Points
    {
      get
      {
        return this.list_0;
      }
    }

    public WireTransform Transform
    {
      get
      {
        return this.wireTransform_0;
      }
      set
      {
        this.wireTransform_0 = value;
      }
    }
  }
}
