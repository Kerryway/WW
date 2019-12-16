// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableBreakData
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System.Collections.Generic;

namespace WW.Cad.Model.Entities
{
  public class DxfTableBreakData
  {
    private TableBreakFlowDirection tableBreakFlowDirection_0 = TableBreakFlowDirection.Right;
    private List<DxfTableBreakHeight> list_0 = new List<DxfTableBreakHeight>();
    private List<DxfTableBreakRowRange> list_1 = new List<DxfTableBreakRowRange>();
    private DxfHandledObjectCollection<DxfTable> dxfHandledObjectCollection_0 = new DxfHandledObjectCollection<DxfTable>();
    private int int_0;
    private TableBreakOptionFlags tableBreakOptionFlags_0;
    private double double_0;
    private int int_1;
    private int int_2;

    public bool HasData
    {
      get
      {
        return (this.int_0 & 1) != 0;
      }
      set
      {
        if (value)
          this.int_0 |= 1;
        else
          this.int_0 &= -2;
      }
    }

    public TableBreakOptionFlags OptionFlags
    {
      get
      {
        return this.tableBreakOptionFlags_0;
      }
      set
      {
        this.tableBreakOptionFlags_0 = value;
      }
    }

    public TableBreakFlowDirection FlowDirection
    {
      get
      {
        return this.tableBreakFlowDirection_0;
      }
      set
      {
        this.tableBreakFlowDirection_0 = value;
      }
    }

    public IList<DxfTableBreakHeight> BreakHeights
    {
      get
      {
        return (IList<DxfTableBreakHeight>) this.list_0;
      }
    }

    public double BreakSpacing
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

    public IList<DxfTableBreakRowRange> RowRanges
    {
      get
      {
        return (IList<DxfTableBreakRowRange>) this.list_1;
      }
    }

    public IList<DxfTable> SubTables
    {
      get
      {
        return (IList<DxfTable>) this.dxfHandledObjectCollection_0;
      }
    }

    public DxfTableBreakData Clone(CloneContext cloneContext)
    {
      DxfTableBreakData dxfTableBreakData = new DxfTableBreakData();
      dxfTableBreakData.CopyFrom(cloneContext, this);
      return dxfTableBreakData;
    }

    public void CopyFrom(CloneContext cloneContext, DxfTableBreakData from)
    {
      this.tableBreakOptionFlags_0 = from.tableBreakOptionFlags_0;
      this.tableBreakFlowDirection_0 = from.tableBreakFlowDirection_0;
      foreach (DxfTableBreakHeight tableBreakHeight in from.list_0)
        this.list_0.Add(tableBreakHeight.Clone());
      this.double_0 = from.double_0;
      foreach (DxfTableBreakRowRange tableBreakRowRange in from.list_1)
        this.list_1.Add(tableBreakRowRange.Clone());
      foreach (DxfHandledObject dxfHandledObject in from.dxfHandledObjectCollection_0)
        this.dxfHandledObjectCollection_0.Add((DxfTable) dxfHandledObject.Clone(cloneContext));
      this.int_1 = from.int_1;
      this.int_2 = from.int_2;
    }

    public int Flags
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

    internal int UnknownFlags1
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

    internal int UnknownFlags2
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
