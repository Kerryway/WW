// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.TableCellStylePropertyFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects
{
  [Flags]
  public enum TableCellStylePropertyFlags
  {
    None = 0,
    DataType = 1,
    DataFormat = 2,
    Rotation = 4,
    BlockScale = 8,
    Alignment = 16, // 0x00000010
    ContentColor = 32, // 0x00000020
    TextStyle = 64, // 0x00000040
    TextHeight = 128, // 0x00000080
    AutoScale = 256, // 0x00000100
    BackgroundColor = 512, // 0x00000200
    MarginLeft = 1024, // 0x00000400
    MarginTop = 2048, // 0x00000800
    MarginRight = 4096, // 0x00001000
    MarginBottom = 8192, // 0x00002000
    MarginHorizontalSpacing = 131072, // 0x00020000
    MarginVerticalSpacing = 262144, // 0x00040000
    ContentLayout = 16384, // 0x00004000
    MergeCellsOnCreation = 32768, // 0x00008000
    FlowDirectionBottomToTop = 65536, // 0x00010000
  }
}
