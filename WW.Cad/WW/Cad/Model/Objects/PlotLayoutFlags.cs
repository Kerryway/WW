// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.PlotLayoutFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects
{
  [Flags]
  public enum PlotLayoutFlags : short
  {
    None = 0,
    PlotViewportBorders = 1,
    ShowPlotStyles = 2,
    PlotCentered = 4,
    PlotHidden = 8,
    UseStandardScale = 16, // 0x0010
    PlotPlotStyles = 32, // 0x0020
    ScaleLineweights = 64, // 0x0040
    PrintLineweights = 128, // 0x0080
    DrawViewportsFirst = 512, // 0x0200
    ModelType = 1024, // 0x0400
    UpdatePaper = 2048, // 0x0800
    ZoomToPaperOnUpdate = 4096, // 0x1000
    Initializing = 8192, // 0x2000
    PreviousPlotInit = 16384, // 0x4000
  }
}
