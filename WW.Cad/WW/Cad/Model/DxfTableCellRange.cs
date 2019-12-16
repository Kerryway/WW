// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.DxfTableCellRange
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.IO;

namespace WW.Cad.Model
{
  public class DxfTableCellRange
  {
    private int int_0;
    private int int_1;
    private int int_2;
    private int int_3;

    public DxfTableCellRange()
    {
    }

    public DxfTableCellRange(
      int topRowIndex,
      int leftColumnIndex,
      int bottomRowIndex,
      int rightColumnIndex)
    {
      this.int_0 = topRowIndex;
      this.int_1 = leftColumnIndex;
      this.int_2 = bottomRowIndex;
      this.int_3 = rightColumnIndex;
    }

    public int TopRowIndex
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

    public int LeftColumnIndex
    {
      get
      {
        return this.int_1;
      }
      set
      {
        this.int_1 = value;
      }
    }

    public int BottomRowIndex
    {
      get
      {
        return this.int_2;
      }
      set
      {
        this.int_2 = value;
      }
    }

    public int RightColumnIndex
    {
      get
      {
        return this.int_3;
      }
      set
      {
        this.int_3 = value;
      }
    }

    public bool Contains(int rowIndex, int columnIndex)
    {
      if (rowIndex >= this.int_0 && rowIndex <= this.int_2 && columnIndex >= this.int_1)
        return columnIndex <= this.int_3;
      return false;
    }

    public bool IsTopLeftCell(int rowIndex, int columnIndex)
    {
      if (rowIndex == this.int_0)
        return columnIndex == this.int_1;
      return false;
    }

    public DxfTableCellRange Clone()
    {
      return new DxfTableCellRange()
      {
        int_0 = this.int_0,
        int_1 = this.int_1,
        int_2 = this.int_2,
        int_3 = this.int_3
      };
    }

    internal void Write(DxfWriter w)
    {
      w.Write(91, (object) this.int_0);
      w.Write(92, (object) this.int_1);
      w.Write(93, (object) this.int_2);
      w.Write(94, (object) this.int_3);
    }
  }
}
