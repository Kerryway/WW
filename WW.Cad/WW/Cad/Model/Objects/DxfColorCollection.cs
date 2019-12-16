// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DxfColorCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Objects
{
  public class DxfColorCollection : ActiveDxfHandledObjectCollection<DxfColor>
  {
    public DxfColor this[DxfColor.Key key]
    {
      get
      {
        DxfColor dxfColor1 = (DxfColor) null;
        foreach (DxfColor dxfColor2 in (DxfHandledObjectCollection<DxfColor>) this)
        {
          if (dxfColor2.Color.Name == key.Name && dxfColor2.Color.ColorBookName == key.ColorBookName)
          {
            dxfColor1 = dxfColor2;
            break;
          }
        }
        return dxfColor1;
      }
    }

    public DxfColor GetColor(string colorBookName, string colorName)
    {
      DxfColor dxfColor1 = (DxfColor) null;
      foreach (DxfColor dxfColor2 in (DxfHandledObjectCollection<DxfColor>) this)
      {
        if (dxfColor2.Color.Name == colorName && dxfColor2.Color.ColorBookName == colorBookName)
        {
          dxfColor1 = dxfColor2;
          break;
        }
      }
      return dxfColor1;
    }
  }
}
