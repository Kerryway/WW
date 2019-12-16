// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockGrip
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockGrip : DxfBlockElement
  {
    private DxfEvalGraph.GraphNodeId graphNodeId_1;
    private DxfEvalGraph.GraphNodeId graphNodeId_2;
    private WW.Math.Point3D point3D_0;
    private bool bool_0;
    private int int_6;

    public WW.Math.Point3D Position
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

    public DxfEvalGraph.GraphNodeId GripExpression1
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

    public DxfEvalGraph.GraphNodeId GripExpression2
    {
      get
      {
        return this.graphNodeId_2;
      }
      set
      {
        this.graphNodeId_2 = value;
      }
    }

    public bool CyclingFlag
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

    public int CyclingWeight
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

    public override string ObjectType
    {
      get
      {
        return "";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockGrip";
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
      DxfBlockGrip dxfBlockGrip = (DxfBlockGrip) from;
      this.Position = dxfBlockGrip.Position;
      this.GripExpression1 = (DxfEvalGraph.GraphNodeId) cloneContext.Clone((IGraphCloneable) dxfBlockGrip.GripExpression1);
      this.GripExpression2 = (DxfEvalGraph.GraphNodeId) cloneContext.Clone((IGraphCloneable) dxfBlockGrip.GripExpression2);
      this.CyclingFlag = dxfBlockGrip.CyclingFlag;
      this.CyclingWeight = dxfBlockGrip.CyclingWeight;
    }
  }
}
