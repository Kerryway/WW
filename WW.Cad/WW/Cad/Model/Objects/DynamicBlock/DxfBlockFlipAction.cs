// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockFlipAction
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockFlipAction : DxfBlockAction
  {
    private DxfConnectionPoint[] dxfConnectionPoint_0 = new DxfConnectionPoint[4];

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
        return "BLOCKFLIPACTION";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockFlipAction";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockFlipAction dxfBlockFlipAction = (DxfBlockFlipAction) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (dxfBlockFlipAction == null)
      {
        dxfBlockFlipAction = new DxfBlockFlipAction();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) dxfBlockFlipAction);
        dxfBlockFlipAction.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) dxfBlockFlipAction;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockFlipAction dxfBlockFlipAction = (DxfBlockFlipAction) from;
      this.ActionConnections = DxfConnectionPoint.Clone(cloneContext, dxfBlockFlipAction.ActionConnections);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_15.ClassNumber;
    }
  }
}
