// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.IPlotStyle
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Drawing;

namespace WW.Cad.Model
{
  public interface IPlotStyle
  {
    ArgbColor Color { get; }

    short LineWeight { get; }
  }
}
