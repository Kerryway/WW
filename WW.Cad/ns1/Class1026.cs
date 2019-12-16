// Decompiled with JetBrains decompiler
// Type: ns1.Class1026
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;
using System.Collections.Generic;
using WW.Cad.Base;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;

namespace ns1
{
  internal class Class1026
  {
    private bool bool_0 = true;
    private int int_0 = 1;
    private int int_1 = 1;
    private DxfValue dxfValue_0 = new DxfValue();
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private double double_1 = 1.0;
    private DxfObjectReference dxfObjectReference_1 = DxfObjectReference.Null;
    private DxfTableBorderOverrides dxfTableBorderOverrides_0 = new DxfTableBorderOverrides();
    private DxfTableBorderOverrides dxfTableBorderOverrides_1 = new DxfTableBorderOverrides();
    private DxfTableBorderOverrides dxfTableBorderOverrides_2 = new DxfTableBorderOverrides();
    private DxfTableBorderOverrides dxfTableBorderOverrides_3 = new DxfTableBorderOverrides();
    private Enum47 enum47_0;
    private double double_0;
    private DxfTableAttributeCollection dxfTableAttributeCollection_0;
    private double? nullable_0;
    private WW.Cad.Model.CellAlignment? nullable_1;
    private Color? nullable_2;
    private Color? nullable_3;
    private bool? nullable_4;
    private int int_2;
    private Class430 class430_0;

    public Enum47 CellType
    {
      get
      {
        return this.enum47_0;
      }
      set
      {
        this.enum47_0 = value;
      }
    }

    public bool AutoFit
    {
      get
      {
        return this.bool_0;
      }
      set
      {
        this.bool_0 = value;
      }
    }

    public int MergedCellCountHorizontal
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

    public int MergedCellCountVertical
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

    public double Rotation
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

    public DxfValue Value
    {
      get
      {
        return this.dxfValue_0;
      }
    }

    public DxfHandledObject BlockOrField
    {
      get
      {
        return (DxfHandledObject) this.dxfObjectReference_0.Value;
      }
      set
      {
        if (value != null && !(value is DxfBlock) && !(value is DxfField))
          throw new ArgumentException("Value must be a block or a field");
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public double BlockScale
    {
      get
      {
        return this.double_1;
      }
      set
      {
        this.double_1 = value;
      }
    }

    public DxfTableAttributeCollection Attributes
    {
      get
      {
        if (this.dxfTableAttributeCollection_0 == null)
          this.dxfTableAttributeCollection_0 = new DxfTableAttributeCollection();
        return this.dxfTableAttributeCollection_0;
      }
      set
      {
        this.dxfTableAttributeCollection_0 = value;
      }
    }

    public DxfTextStyle TextStyle
    {
      get
      {
        return (DxfTextStyle) this.dxfObjectReference_1.Value;
      }
      set
      {
        this.dxfObjectReference_1 = DxfObjectReference.GetReference((IDxfHandledObject) value);
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

    public int ExtendedFlags
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

    public Class551 Table
    {
      get
      {
        return this.class430_0.Table;
      }
    }

    public Class430 Row
    {
      get
      {
        return this.class430_0;
      }
    }

    public int Index
    {
      get
      {
        return this.class430_0.Cells.IndexOf(this);
      }
    }

    public double GetEffectiveTextHeight(DxfTableCellStyle cellStyle)
    {
      if (!this.nullable_0.HasValue)
        return cellStyle.TextHeight;
      return this.nullable_0.Value;
    }

    public DxfTextStyle method_0(DxfTableCellStyle cellStyle)
    {
      if (this.TextStyle != null)
        return this.TextStyle;
      return cellStyle.TextStyle;
    }

    public Color method_1(DxfTableCellStyle cellStyle)
    {
      if (!this.nullable_2.HasValue)
        return cellStyle.ContentColor;
      return this.nullable_2.Value;
    }

    public WW.Cad.Model.CellAlignment method_2(DxfTableCellStyle cellStyle)
    {
      if (!this.CellAlignment.HasValue)
        return cellStyle.CellAlignment;
      return this.CellAlignment.Value;
    }

    internal bool HasAttributes
    {
      get
      {
        if (this.dxfTableAttributeCollection_0 == null)
          return false;
        return this.dxfTableAttributeCollection_0.Count > 0;
      }
    }

    internal void method_3(Class430 tableRow)
    {
      this.class430_0 = tableRow;
    }

    internal Class1026 Clone(CloneContext cloneContext)
    {
      Class1026 class1026 = new Class1026();
      class1026.CopyFrom(this, cloneContext);
      return class1026;
    }

    internal bool method_4(bool isCellMerged)
    {
      if (this.dxfValue_0 != null && !isCellMerged)
        return this.BlockOrField == null;
      return false;
    }

    internal int method_5(bool cellHasValue)
    {
      int num = 0;
      if (this.dxfValue_0 == null || this.dxfValue_0.Format.DataType == ValueDataType.None || !cellHasValue)
        num |= 1;
      if (this.BlockOrField == null)
        num |= 4;
      return num;
    }

    internal DxfTableBorderOverrides method_6(int borderIndex)
    {
      switch (borderIndex)
      {
        case 0:
          return this.dxfTableBorderOverrides_0;
        case 1:
          return this.dxfTableBorderOverrides_1;
        case 2:
          return this.dxfTableBorderOverrides_2;
        case 3:
          return this.dxfTableBorderOverrides_3;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    internal static int smethod_0(int overrideFlags, short edgeFlags, short virtualEdgeFlags)
    {
      short num = (short) (((int) ~edgeFlags | (int) virtualEdgeFlags) & 15);
      if (num != (short) 0)
      {
        if (((int) num & 1) != 0)
          overrideFlags &= -17473;
        if (((int) num & 2) != 0)
          overrideFlags &= -34945;
        if (((int) num & 4) != 0)
          overrideFlags &= -69889;
        if (((int) num & 8) != 0)
          overrideFlags &= -139777;
      }
      return overrideFlags;
    }

    private void CopyFrom(Class1026 from, CloneContext cloneContext)
    {
      this.enum47_0 = from.enum47_0;
      this.bool_0 = from.bool_0;
      this.int_0 = from.int_0;
      this.int_1 = from.int_1;
      this.double_0 = from.double_0;
      this.dxfValue_0 = from.dxfValue_0 != null ? from.dxfValue_0.Clone(cloneContext) : (DxfValue) null;
      if (from.BlockOrField != null)
      {
        if (cloneContext.SourceModel == cloneContext.TargetModel)
        {
          this.BlockOrField = from.BlockOrField;
        }
        else
        {
          DxfBlock blockOrField = from.BlockOrField as DxfBlock;
          if (blockOrField != null)
          {
            DxfBlock dxfBlock;
            if (!cloneContext.TargetModel.Blocks.TryGetValue(blockOrField.Name, out dxfBlock))
            {
              if (cloneContext.ReferenceResolutionType == ReferenceResolutionType.CloneMissing)
              {
                dxfBlock = (DxfBlock) from.BlockOrField.Clone(cloneContext);
                if (!cloneContext.CloneExact)
                  cloneContext.TargetModel.Blocks.Add(dxfBlock);
              }
              else if (cloneContext.ReferenceResolutionType == ReferenceResolutionType.FailOnMissing)
                throw new DxfException("Block with name " + blockOrField.Name + " not present in target model.");
              this.BlockOrField = (DxfHandledObject) dxfBlock;
            }
          }
          else
          {
            DxfField dxfField = (DxfField) from.BlockOrField.Clone(cloneContext);
            if (!cloneContext.TargetModel.FieldList.Fields.Contains(dxfField))
              cloneContext.TargetModel.FieldList.Fields.Add(dxfField);
            this.BlockOrField = (DxfHandledObject) dxfField;
          }
        }
      }
      this.double_1 = from.double_1;
      if (from.dxfTableAttributeCollection_0 != null)
      {
        foreach (DxfTableAttribute dxfTableAttribute in (List<DxfTableAttribute>) from.dxfTableAttributeCollection_0)
          this.Attributes.Add(dxfTableAttribute.Clone(cloneContext));
      }
      if (from.TextStyle != null)
      {
        if (cloneContext.SourceModel == cloneContext.TargetModel)
        {
          this.TextStyle = from.TextStyle;
        }
        else
        {
          DxfTextStyle textStyle;
          if (cloneContext.TargetModel.TextStyles.TryGetValue(from.TextStyle.Name, out textStyle))
          {
            this.TextStyle = textStyle;
          }
          else
          {
            if (cloneContext.ReferenceResolutionType != ReferenceResolutionType.CloneMissing)
              throw new DxfException("Text style with name " + from.TextStyle.Name + " not present in target model.");
            this.TextStyle = (DxfTextStyle) from.TextStyle.Clone(cloneContext);
            if (!cloneContext.CloneExact)
              cloneContext.TargetModel.TextStyles.Add(this.TextStyle);
          }
        }
      }
      this.nullable_0 = from.nullable_0;
      this.nullable_1 = from.nullable_1;
      this.nullable_2 = from.nullable_2;
      this.nullable_3 = from.nullable_3;
      this.nullable_4 = from.nullable_4;
      this.dxfTableBorderOverrides_0.CopyFrom(from.dxfTableBorderOverrides_0, cloneContext);
      this.dxfTableBorderOverrides_1.CopyFrom(from.dxfTableBorderOverrides_1, cloneContext);
      this.dxfTableBorderOverrides_2.CopyFrom(from.dxfTableBorderOverrides_2, cloneContext);
      this.dxfTableBorderOverrides_3.CopyFrom(from.dxfTableBorderOverrides_3, cloneContext);
      this.int_2 = from.int_2;
    }
  }
}
