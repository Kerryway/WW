// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfGradientColor
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Entities
{
  public class DxfGradientColor
  {
    private double double_0;
    private Color color_0;

    public DxfGradientColor()
    {
    }

    public DxfGradientColor(double value, Color color)
    {
      this.double_0 = value;
      this.color_0 = color;
    }

    public double Value
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

    public Color Color
    {
      get
      {
        return this.color_0;
      }
      set
      {
        this.color_0 = value;
      }
    }

    public DxfGradientColor Clone()
    {
      DxfGradientColor dxfGradientColor = new DxfGradientColor();
      dxfGradientColor.CopyFrom(this);
      return dxfGradientColor;
    }

    public void CopyFrom(DxfGradientColor from)
    {
      this.double_0 = from.double_0;
      this.color_0 = from.color_0;
    }

    public override string ToString()
    {
      return string.Format("Value: {0}, color: {1}", (object) this.double_0, (object) this.color_0);
    }
  }
}
