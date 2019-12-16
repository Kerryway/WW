// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfColorGradient
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;

namespace WW.Cad.Model.Entities
{
  public class DxfColorGradient
  {
    internal static readonly DxfColorGradient dxfColorGradient_0 = new DxfColorGradient();
    private string string_0 = string.Empty;
    private List<DxfGradientColor> list_0 = new List<DxfGradientColor>();
    private bool bool_0;
    private int int_0;
    private double double_0;
    private double double_1;
    private bool bool_1;
    private double double_2;

    public DxfColorGradient()
    {
    }

    public DxfColorGradient(string name)
    {
      this.string_0 = name ?? string.Empty;
    }

    public string Name
    {
      get
      {
        return this.string_0;
      }
      set
      {
        this.string_0 = value ?? string.Empty;
      }
    }

    public bool Enabled
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public int Reserved1
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

    public double Angle
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

    public double Shift
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    public bool IsSingleColorGradient
    {
      get
      {
        return this.bool_1;
      }
      set
      {
        this.bool_1 = value;
      }
    }

    public double ColorTint
    {
      get
      {
        return this.double_2;
      }
      set
      {
        this.double_2 = value;
      }
    }

    public List<DxfGradientColor> GradientColors
    {
      get
      {
        return this.list_0;
      }
    }

    public DxfColorGradient Clone()
    {
      DxfColorGradient dxfColorGradient = new DxfColorGradient();
      dxfColorGradient.CopyFrom(this);
      return dxfColorGradient;
    }

    public void CopyFrom(DxfColorGradient from)
    {
      this.string_0 = from.string_0;
      this.bool_0 = from.bool_0;
      this.int_0 = from.int_0;
      this.double_0 = from.double_0;
      this.double_1 = from.double_1;
      this.bool_1 = from.bool_1;
      this.double_2 = from.double_2;
      this.list_0.Clear();
      foreach (DxfGradientColor dxfGradientColor in from.list_0)
        this.list_0.Add(dxfGradientColor.Clone());
    }

    public override string ToString()
    {
      return this.string_0;
    }
  }
}
