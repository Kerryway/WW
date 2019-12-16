// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.ObjectSortingFlags
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model
{
  [Flags]
  public enum ObjectSortingFlags : byte
  {
    NoSorting = 0,
    ObjectSelectionSort = 1,
    ObjectSnapSort = 2,
    RedrawSort = 4,
    SlideSort = 8,
    RegenSort = 16, // 0x10
    PlottingSort = 32, // 0x20
    PostscriptSort = 64, // 0x40
    AllSortingMethods = PostscriptSort | PlottingSort | RegenSort | SlideSort | RedrawSort | ObjectSnapSort | ObjectSelectionSort, // 0x7F
  }
}
