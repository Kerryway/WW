// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockAngleOffsetAction
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockAngleOffsetAction : DxfBlockAction
  {
    private double double_0 = 1.0;
    private double double_1;
    private int int_6;
    private int int_7;
    private DxfBlockAction.ScaleTypeXY scaleTypeXY_0;

    public DxfBlockAction.ScaleTypeXY ScaleType
    {
      get
      {
        return this.scaleTypeXY_0;
      }
      set
      {
        this.scaleTypeXY_0 = value;
      }
    }

    public double DistanceCoefficient
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

    public double AngleOffset
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

    public int Unknown1
    {
      get
      {
        return this.int_6;
      }
      set
      {
        this.int_6 = value;
      }
    }

    public int Unknown2
    {
      get
      {
        return this.int_6;
      }
      set
      {
        this.int_6 = value;
      }
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      throw new Exception("The class is base. Clone shouldn't be used.");
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockAngleOffsetAction angleOffsetAction = (DxfBlockAngleOffsetAction) from;
      this.DistanceCoefficient = angleOffsetAction.DistanceCoefficient;
      this.AngleOffset = angleOffsetAction.AngleOffset;
      this.Unknown1 = angleOffsetAction.Unknown1;
      this.Unknown2 = angleOffsetAction.Unknown2;
      this.ScaleType = angleOffsetAction.ScaleType;
    }
  }
}
