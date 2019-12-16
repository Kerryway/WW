// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfTableCellRangeCollection
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;

namespace WW.Cad.Model
{
  public class DxfTableCellRangeCollection : List<DxfTableCellRange>
  {
    public DxfTableCellRangeCollection()
    {
    }

    public DxfTableCellRangeCollection(int capacity)
      : base(capacity)
    {
    }

    public DxfTableCellRangeCollection(IEnumerable<DxfTableCellRange> collection)
      : base(collection)
    {
    }

    public DxfTableCellRange FindMatch(
      int topRowIndex,
      int leftColumnIndex,
      int bottomRowIndex,
      int rightColumnIndex)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      return this.Find(new Predicate<DxfTableCellRange>(new DxfTableCellRangeCollection.Class913()
      {
        int_0 = topRowIndex,
        int_1 = leftColumnIndex,
        int_2 = bottomRowIndex,
        int_3 = rightColumnIndex
      }.method_0));
    }

    public DxfTableCellRange FindFirst(int rowIndex, int columnIndex)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      return this.Find(new Predicate<DxfTableCellRange>(new DxfTableCellRangeCollection.Class914()
      {
        int_0 = rowIndex,
        int_1 = columnIndex
      }.method_0));
    }

    public bool AreInSameCellRange(
      int rowIndex1,
      int columnIndex1,
      int rowIndex2,
      int columnIndex2)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      return this.Find(new Predicate<DxfTableCellRange>(new DxfTableCellRangeCollection.Class915()
      {
        int_0 = rowIndex1,
        int_1 = columnIndex1,
        int_2 = rowIndex2,
        int_3 = columnIndex2
      }.method_0)) != null;
    }
  }
}
