// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfEvalGraphExpression
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfEvalGraphExpression : DxfObject
  {
    private int int_0 = 29;
    private int int_1 = 6;
    private int int_2 = -1;
    private DxfEvalGraph.GraphNodeId graphNodeId_0;
    private DxfXRecordValue dxfXRecordValue_0;

    public DxfXRecordValue DataValue
    {
      get
      {
        return this.dxfXRecordValue_0;
      }
      set
      {
        this.dxfXRecordValue_0 = value;
      }
    }

    public int VersionMajor
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

    public DxfEvalGraph.GraphNodeId NodeId
    {
      get
      {
        return this.graphNodeId_0;
      }
      set
      {
        this.graphNodeId_0 = value;
      }
    }

    public int VersionMinor
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

    public int UnknownField
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
        return "AcDbEvalExpr";
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
      DxfEvalGraphExpression evalGraphExpression = (DxfEvalGraphExpression) from;
      this.DataValue = (DxfXRecordValue) cloneContext.Clone((IGraphCloneable) evalGraphExpression.DataValue);
      this.VersionMajor = evalGraphExpression.VersionMajor;
      this.NodeId = (DxfEvalGraph.GraphNodeId) cloneContext.Clone((IGraphCloneable) evalGraphExpression.NodeId);
      this.VersionMinor = evalGraphExpression.VersionMinor;
      this.UnknownField = evalGraphExpression.UnknownField;
    }

    internal override bool vmethod_5(DxfModel model)
    {
      return model.Header.Dxf13OrHigher;
    }
  }
}
