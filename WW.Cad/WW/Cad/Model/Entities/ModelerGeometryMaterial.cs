// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.ModelerGeometryMaterial
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Entities
{
  public class ModelerGeometryMaterial
  {
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private int int_0;
    private int int_1;

    public int MaterialIdLow
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

    public int MaterialIdHigh
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

    public DxfHandledObject Material
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_0.Value;
      }
      set
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }
  }
}
