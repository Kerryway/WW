// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.BackgroundFillInfo
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Entities
{
  public class BackgroundFillInfo
  {
    private double double_0 = 1.5;
    private Color color_0 = Color.ByLayer;
    private Transparency transparency_0 = Transparency.ByLayer;

    public double BorderOffsetFactor
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

    public Transparency Transparency
    {
      get
      {
        return this.transparency_0;
      }
      set
      {
        this.transparency_0 = value;
      }
    }

    public BackgroundFillInfo Clone(CloneContext cloneContext)
    {
      BackgroundFillInfo backgroundFillInfo = new BackgroundFillInfo();
      backgroundFillInfo.CopyFrom(cloneContext, this);
      return backgroundFillInfo;
    }

    public void CopyFrom(CloneContext cloneContext, BackgroundFillInfo from)
    {
      this.double_0 = from.double_0;
      this.color_0 = from.color_0;
      this.transparency_0 = from.transparency_0;
    }
  }
}
