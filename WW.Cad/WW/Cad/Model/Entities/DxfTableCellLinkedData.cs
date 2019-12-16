// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableCellLinkedData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

namespace WW.Cad.Model.Entities
{
  public class DxfTableCellLinkedData
  {
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private int int_0;
    private int int_1;
    private int int_2;

    public DxfHandledObject DataLink
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_0.Value;
      }
      set
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public int RowCount
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

    public int ColumnCount
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

    public DxfTableCellLinkedData Clone(CloneContext cloneContext)
    {
      DxfTableCellLinkedData tableCellLinkedData = new DxfTableCellLinkedData();
      if (this.DataLink != null)
        tableCellLinkedData.DataLink = (DxfHandledObject) this.DataLink.Clone(cloneContext);
      tableCellLinkedData.int_0 = this.int_0;
      tableCellLinkedData.int_1 = this.int_1;
      tableCellLinkedData.int_2 = this.int_2;
      return tableCellLinkedData;
    }

    internal int UnknownDxfGroup96
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
  }
}
