// Decompiled with JetBrains decompiler
// Type: WW.Cad.Model.Objects.DynamicBlock.DxfBlockRotateAction
// Assembly: WW.Cad, Version=4.0.37.140, Culture=neutral, PublicKeyToken=null
// MVID: E8E0F2D4-1D21-41F0-9953-8161CF39F2BE
// Assembly location: C:\Users\MSN99\Desktop\Cleaned\WW.Cad.dll

using ns28;

namespace WW.Cad.Model.Objects.DynamicBlock
{
  public class DxfBlockRotateAction : DxfBlockBasePointAction
  {
    private DxfConnectionPoint dxfConnectionPoint_1;

    public DxfConnectionPoint ActionConnection
    {
      get
      {
        return this.dxfConnectionPoint_1;
      }
      set
      {
        this.dxfConnectionPoint_1 = value;
      }
    }

    public override string ObjectType
    {
      get
      {
        return "BLOCKROTATEACTION";
      }
    }

    public override string AcClass
    {
      get
      {
        return "AcDbBlockRotateAction";
      }
    }

    public override void Accept(IObjectVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override IGraphCloneable Clone(CloneContext cloneContext)
    {
      DxfBlockRotateAction blockRotateAction = (DxfBlockRotateAction) cloneContext.GetExistingClone((IGraphCloneable) this);
      if (blockRotateAction == null)
      {
        blockRotateAction = new DxfBlockRotateAction();
        cloneContext.RegisterClone((IGraphCloneable) this, (IGraphCloneable) blockRotateAction);
        blockRotateAction.CopyFrom((DxfHandledObject) this, cloneContext);
      }
      return (IGraphCloneable) blockRotateAction;
    }

    public override void CopyFrom(DxfHandledObject from, CloneContext cloneContext)
    {
      base.CopyFrom(from, cloneContext);
      DxfBlockRotateAction blockRotateAction = (DxfBlockRotateAction) from;
      this.ActionConnection = (DxfConnectionPoint) cloneContext.Clone((IGraphCloneable) blockRotateAction.ActionConnection);
    }

    internal override short vmethod_6(Class432 w)
    {
      return w.KnownClasses.class1032_0.dxfClass_12.ClassNumber;
    }
  }
}
