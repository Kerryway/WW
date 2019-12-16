// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockSinglePointParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockSinglePointParameter : DxfBlockParameter
  {
    private WW.Math.Point3D point3D_0;
    private DxfEvalGraph.GraphNodeId graphNodeId_1;
    private DxfBlockParameterPropertyInfo dxfBlockParameterPropertyInfo_0;
    private DxfBlockParameterPropertyInfo dxfBlockParameterPropertyInfo_1;

    public WW.Math.Point3D BasePoint
    {
      get
      {
        return this.point3D_0;
      }
      set
      {
        this.point3D_0 = value;
      }
    }

    public DxfEvalGraph.GraphNodeId GripId
    {
      get
      {
        return this.graphNodeId_1;
      }
      set
      {
        this.graphNodeId_1 = value;
      }
    }

    public DxfBlockParameterPropertyInfo FirstProperty
    {
      get
      {
        return this.dxfBlockParameterPropertyInfo_0;
      }
      set
      {
        this.dxfBlockParameterPropertyInfo_0 = value;
      }
    }

    public DxfBlockParameterPropertyInfo SecondProperty
    {
      get
      {
        return this.dxfBlockParameterPropertyInfo_1;
      }
      set
      {
        this.dxfBlockParameterPropertyInfo_1 = value;
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      throw new Exception("This method shouldn't be called.");
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      throw new Exception("The class is base. Clone shouldn't be used.");
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockSinglePointParameter singlePointParameter = (DxfBlockSinglePointParameter) from;
      this.BasePoint = singlePointParameter.BasePoint;
      this.GripId = (DxfEvalGraph.GraphNodeId) cloneContext.Clone((IGraphCloneable) singlePointParameter.GripId);
      this.FirstProperty = (DxfBlockParameterPropertyInfo) singlePointParameter.FirstProperty.Clone(cloneContext);
      this.SecondProperty = (DxfBlockParameterPropertyInfo) singlePointParameter.SecondProperty.Clone(cloneContext);
    }
  }
}
