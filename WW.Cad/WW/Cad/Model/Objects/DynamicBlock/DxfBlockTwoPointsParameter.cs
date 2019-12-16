// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockTwoPointsParameter
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockTwoPointsParameter : DxfBlockParameter
  {
    private DxfEvalGraph.GraphNodeId[] graphNodeId_1 = new DxfEvalGraph.GraphNodeId[4];
    private DxfBlockParameterPropertyInfo[] dxfBlockParameterPropertyInfo_0 = new DxfBlockParameterPropertyInfo[4];
    private WW.Math.Point3D point3D_0;
    private WW.Math.Point3D point3D_1;
    private DxfBlockTwoPointsParameter.PointType pointType_0;

    public DxfBlockTwoPointsParameter.PointType BasePoint
    {
      get
      {
        return this.pointType_0;
      }
      set
      {
        this.pointType_0 = value;
      }
    }

    public DxfEvalGraph.GraphNodeId[] GripIds
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

    public WW.Math.Point3D FirstPoint
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

    public WW.Math.Point3D SecondPoint
    {
      get
      {
        return this.point3D_1;
      }
      set
      {
        this.point3D_1 = value;
      }
    }

    public DxfBlockParameterPropertyInfo[] Properties
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
      DxfBlockTwoPointsParameter twoPointsParameter = (DxfBlockTwoPointsParameter) from;
      this.BasePoint = twoPointsParameter.BasePoint;
      this.FirstPoint = twoPointsParameter.FirstPoint;
      this.SecondPoint = twoPointsParameter.SecondPoint;
      this.GripIds = DxfEvalGraph.GraphNodeId.Clone(cloneContext, twoPointsParameter.GripIds);
      this.Properties = new DxfBlockParameterPropertyInfo[twoPointsParameter.Properties.Length];
      for (int index = 0; index < twoPointsParameter.GripIds.Length; ++index)
        this.Properties[index] = (DxfBlockParameterPropertyInfo) twoPointsParameter.Properties[index].Clone(cloneContext);
    }

    public enum PointType
    {
      StartPoint,
      MiddlePoint,
    }
  }
}
