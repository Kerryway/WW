// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockFlipGrip
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockFlipGrip : DxfBlockGrip
  {
    private WW.Math.Vector3D vector3D_0;
    private DxfEvalGraph.GraphNodeId graphNodeId_3;

    public WW.Math.Vector3D Orientation
    {
      get
      {
        return this.vector3D_0;
      }
      set
      {
        this.vector3D_0 = value;
      }
    }

    public DxfEvalGraph.GraphNodeId FlipExpression
    {
      get
      {
        return this.graphNodeId_3;
      }
      set
      {
        this.graphNodeId_3 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "BLOCKFLIPGRIP";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockFlipGrip";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockFlipGrip dxfBlockFlipGrip = (DxfBlockFlipGrip) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfBlockFlipGrip == null)
      {
        dxfBlockFlipGrip = new DxfBlockFlipGrip();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfBlockFlipGrip);
        dxfBlockFlipGrip.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfBlockFlipGrip;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockFlipGrip dxfBlockFlipGrip = (DxfBlockFlipGrip) from;
      this.Orientation = dxfBlockFlipGrip.Orientation;
      this.FlipExpression = (DxfEvalGraph.GraphNodeId) cloneContext.Clone((IGraphCloneable) dxfBlockFlipGrip.FlipExpression);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_21.ClassNumber;
    }
  }
}
