// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableBreakRowRange
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Entities
{
  public class DxfTableBreakRowRange
  {
    private WW.Math.Point3D point3D_0;
    private int int_0;
    private int int_1;

    public WW.Math.Point3D Position
    {
      get
      {
        return this.point3D_0;
      }
      set
      {
        this.point3D_0 = value;
      }
    }

    public int StartRowIndex
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

    public int EndRowIndex
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

    public DxfTableBreakRowRange Clone()
    {
      DxfTableBreakRowRange tableBreakRowRange = new DxfTableBreakRowRange();
      tableBreakRowRange.CopyFrom(this);
      return tableBreakRowRange;
    }

    public void CopyFrom(DxfTableBreakRowRange from)
    {
      this.point3D_0 = from.point3D_0;
      this.int_0 = from.int_0;
      this.int_1 = from.int_1;
    }
  }
}
