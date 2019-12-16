// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockMoveAction
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockMoveAction : DxfBlockAngleOffsetAction
  {
    private DxfConnectionPoint[] dxfConnectionPoint_0 = new DxfConnectionPoint[2];

    public DxfConnectionPoint[] ActionConnections
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
        return "BLOCKMOVEACTION";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockMoveAction";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockMoveAction dxfBlockMoveAction = (DxfBlockMoveAction) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfBlockMoveAction == null)
      {
        dxfBlockMoveAction = new DxfBlockMoveAction();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfBlockMoveAction);
        dxfBlockMoveAction.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfBlockMoveAction;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockMoveAction dxfBlockMoveAction = (DxfBlockMoveAction) from;
      this.ActionConnections = DxfConnectionPoint.Clone(cloneContext, dxfBlockMoveAction.ActionConnections);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_17.ClassNumber;
    }
  }
}
