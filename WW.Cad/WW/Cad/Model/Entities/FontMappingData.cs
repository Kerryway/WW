// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.FontMappingData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Entities
{
  public class FontMappingData
  {
    private string string_0 = "";
    private int int_0;
    private double double_0;

    public string Font
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value;
      }
    }

    public int PointSize
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

    public double TextHeight
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
  }
}
