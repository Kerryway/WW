// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockBasePointAction
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using System;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockBasePointAction : DxfBlockAction
  {
    private bool bool_0 = true;
    private DxfConnectionPoint[] dxfConnectionPoint_0 = new DxfConnectionPoint[2];
    private WW.Math.Point3D point3D_1;
    private WW.Math.Point3D point3D_2;

    public WW.Math.Point3D BasePoint
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

    public WW.Math.Point3D Offset
    {
      get
      {
        return this.point3D_2;
      }
      set
      {
        this.point3D_2 = value;
      }
    }

    public bool IndependentFlag
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

    public DxfConnectionPoint[] Connections
    {
      get
      {
        return this.dxfConnectionPoint_0;
      }
      set
      {
        this.dxfConnectionPoint_0 = value;
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
        return "AcDbBlockActionWithBasePt";
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
      DxfBlockBasePointAction blockBasePointAction = (DxfBlockBasePointAction) from;
      this.BasePoint = blockBasePointAction.BasePoint;
      this.Offset = blockBasePointAction.Offset;
      this.IndependentFlag = blockBasePointAction.IndependentFlag;
      this.Connections = DxfConnectionPoint.Clone(cloneContext, blockBasePointAction.Connections);
    }
  }
}
