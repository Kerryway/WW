// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableBreakHeight
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Entities
{
  public class DxfTableBreakHeight
  {
    private WW.Math.Point3D point3D_0;
    private double double_0;
    private int int_0;

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

    public double Height
    {
      get
      {
        return this.double_0;
      }
      set
      {
        this.double_0 = value;
      }
    }

    public DxfTableBreakHeight Clone()
    {
      DxfTableBreakHeight tableBreakHeight = new DxfTableBreakHeight();
      tableBreakHeight.CopyFrom(this);
      return tableBreakHeight;
    }

    private void CopyFrom(DxfTableBreakHeight from)
    {
      this.point3D_0 = from.point3D_0;
      this.double_0 = from.double_0;
    }

    internal int Flags
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
  }
}
