// Decompiled with JetBrains decompiler
// Type: ns1.Class984
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns0;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;

namespace ns1
{
  internal class Class984
  {
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private DxfTableBorderOverrides dxfTableBorderOverrides_0 = new DxfTableBorderOverrides();
    private DxfTableBorderOverrides dxfTableBorderOverrides_1 = new DxfTableBorderOverrides();
    private DxfTableBorderOverrides dxfTableBorderOverrides_2 = new DxfTableBorderOverrides();
    private DxfTableBorderOverrides dxfTableBorderOverrides_3 = new DxfTableBorderOverrides();
    private double? nullable_0;
    private WW.Cad.Model.CellAlignment? nullable_1;
    private Color? nullable_2;
    private Color? nullable_3;
    private bool? nullable_4;
    private DxfValueFormat dxfValueFormat_0;

    public DxfTextStyle TextStyle
    {
      get
      {
        return (DxfTextStyle) this.dxfObjectReference_0.Value;
      }
      set
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public double? TextHeight
    {
      get
      {
        return this.nullable_0;
      }
      set
      {
        this.nullable_0 = value;
      }
    }

    public WW.Cad.Model.CellAlignment? CellAlignment
    {
      get
      {
        return this.nullable_1;
      }
      set
      {
        this.nullable_1 = value;
      }
    }

    public Color? ContentColor
    {
      get
      {
        return this.nullable_2;
      }
      set
      {
        this.nullable_2 = value;
      }
    }

    public Color? BackColor
    {
      get
      {
        return this.nullable_3;
      }
      set
      {
        this.nullable_3 = value;
      }
    }

    public bool? IsBackColorEnabled
    {
      get
      {
        return this.nullable_4;
      }
      set
      {
        this.nullable_4 = value;
      }
    }

    public DxfValueFormat CellFormat
    {
      get
      {
        return this.dxfValueFormat_0;
      }
      set
      {
        this.dxfValueFormat_0 = value;
      }
    }

    public DxfTableBorderOverrides BorderTop
    {
      get
      {
        return this.dxfTableBorderOverrides_0;
      }
      set
      {
        this.dxfTableBorderOverrides_0 = value;
      }
    }

    public DxfTableBorderOverrides BorderRight
    {
      get
      {
        return this.dxfTableBorderOverrides_1;
      }
      set
      {
        this.dxfTableBorderOverrides_1 = value;
      }
    }

    public DxfTableBorderOverrides BorderBottom
    {
      get
      {
        return this.dxfTableBorderOverrides_2;
      }
      set
      {
        this.dxfTableBorderOverrides_2 = value;
      }
    }

    public DxfTableBorderOverrides BorderLeft
    {
      get
      {
        return this.dxfTableBorderOverrides_3;
      }
      set
      {
        this.dxfTableBorderOverrides_3 = value;
      }
    }

    public void CopyFrom(Class984 from, CloneContext cloneContext)
    {
      this.TextStyle = Class906.GetTextStyle(cloneContext, from.TextStyle);
      this.nullable_0 = from.nullable_0;
      this.nullable_1 = from.nullable_1;
      this.nullable_2 = from.nullable_2;
      this.nullable_3 = from.nullable_3;
      this.nullable_4 = from.nullable_4;
      this.dxfValueFormat_0 = from.dxfValueFormat_0 == null ? (DxfValueFormat) null : from.dxfValueFormat_0.Clone();
      this.dxfTableBorderOverrides_0.CopyFrom(from.dxfTableBorderOverrides_0, cloneContext);
      this.dxfTableBorderOverrides_1.CopyFrom(from.dxfTableBorderOverrides_1, cloneContext);
      this.dxfTableBorderOverrides_2.CopyFrom(from.dxfTableBorderOverrides_2, cloneContext);
      this.dxfTableBorderOverrides_3.CopyFrom(from.dxfTableBorderOverrides_3, cloneContext);
    }
  }
}
