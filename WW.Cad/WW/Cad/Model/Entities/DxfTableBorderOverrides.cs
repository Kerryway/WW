// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Entities.DxfTableBorderOverrides
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using WW.Cad.Base;
using WW.Cad.Model.Tables;

namespace WW.Cad.Model.Entities
{
  public class DxfTableBorderOverrides
  {
    private short? nullable_0 = new short?();
    private DxfObjectReference dxfObjectReference_0 = DxfObjectReference.Null;
    private WW.Cad.Model.BorderType? nullable_1 = new WW.Cad.Model.BorderType?();
    private bool? nullable_2 = new bool?();
    private WW.Cad.Model.Color? nullable_3 = new WW.Cad.Model.Color?();
    private double? nullable_4 = new double?();

    public short? LineWeight
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

    public DxfLineType LineType
    {
      get
      {
        return (DxfLineType) this.dxfObjectReference_0.Value;
      }
      set
      {
        this.dxfObjectReference_0 = DxfObjectReference.GetReference((IDxfHandledObject) value);
      }
    }

    public WW.Cad.Model.BorderType? BorderType
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

    public bool? Visible
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

    public WW.Cad.Model.Color? Color
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

    public double? DoubleLineSpacing
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

    internal void CopyFrom(DxfTableBorderOverrides from, CloneContext cloneContext)
    {
      this.nullable_0 = from.nullable_0;
      if (from.LineType == null)
      {
        this.LineType = (DxfLineType) null;
      }
      else
      {
        DxfLineType dxfLineType;
        if (cloneContext.SourceModel == cloneContext.TargetModel)
          dxfLineType = from.LineType;
        else if (!cloneContext.TargetModel.LineTypes.TryGetValue(from.LineType.Name, out dxfLineType))
        {
          if (cloneContext.ReferenceResolutionType == ReferenceResolutionType.CloneMissing)
          {
            dxfLineType = (DxfLineType) from.LineType.Clone(cloneContext);
            if (!cloneContext.CloneExact)
              cloneContext.TargetModel.LineTypes.Add(dxfLineType);
          }
          else if (cloneContext.ReferenceResolutionType == ReferenceResolutionType.FailOnMissing)
            throw new DxfException("Line type with name " + from.LineType.Name + " not present in target model.");
        }
        this.LineType = dxfLineType;
      }
      this.nullable_1 = from.nullable_1;
      this.nullable_2 = from.nullable_2;
      this.nullable_3 = from.nullable_3;
      this.nullable_4 = from.nullable_4;
    }

    internal bool method_0(DxfVersion version)
    {
      bool flag = this.nullable_0.HasValue || this.nullable_2.HasValue || this.nullable_3.HasValue;
      if (version >= DxfVersion.Dxf21)
        flag = ((flag ? 1 : 0) | (this.LineType != null || this.nullable_1.HasValue ? 1 : (this.nullable_4.HasValue ? 1 : 0))) != 0;
      return flag;
    }
  }
}
